using System.Globalization;
using Application.Dto.OrderDto;
using Application.Dto.OrderInstrumentDto;
using Application.Services;
using Domain.Entities;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма магазина
    /// </summary>
    public partial class StoreForm : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly InstrumentService _instrumentService;
        private readonly StoreService _storeService;
        
        private readonly OrderInstrumentService _orderInstrumentService;
        private readonly InstrumentStoreService _instrumentStoreService;
        
        private readonly CancellationToken _cancellationToken;
        
        private User? _currentUser;
        private readonly string _jwt;
        private readonly Guid _storeId;

        public StoreForm(
            string jwt,
            UserService userService,
            OrderService orderService,
            OrderInstrumentService orderInstrumentService,
            InstrumentStoreService instrumentStoreService,
            InstrumentService instrumentService,
            StoreService storeService,
            Guid storeId,
            CancellationToken cancellationToken)
        {
            _jwt = jwt;
            _userService = userService;
            _orderService = orderService;
            _instrumentService = instrumentService;
            _storeService = storeService;
            
            _orderInstrumentService = orderInstrumentService;
            _instrumentStoreService = instrumentStoreService;

            _cancellationToken = cancellationToken;
            _storeId = storeId;
            
            GetCurrentUser(jwt, _cancellationToken);
            GetCurrentStoreItems(storeId, _cancellationToken);
            InitializeComponent();
        }

        /// <summary>
        /// Покупка товара
        /// </summary>
        private async void BuyButton_Click(object sender, EventArgs e)
        {
            var selectedRow = InstrumentStoreTable.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow == null)
            {
                MessageBox.Show(@"Пожалуйста, выберите товар для покупки.");
                return;
            }
            if (_currentUser.Balance < (decimal)selectedRow.Cells["Price"].Value * Convert.ToInt32(Amount.Value.ToString(CultureInfo.InvariantCulture)))
            {
                MessageBox.Show(@"Вам не хватает баланса для данной покупки!");
                return;
            }
            if ((int)selectedRow.Cells["Amount"].Value < Convert.ToInt32(Amount.Value.ToString(CultureInfo.InvariantCulture)))
            {
                MessageBox.Show(@"В магазине нет столько товаров данного вида!");
                return;
            }

            var storeDto = await _storeService.GetByIdAsync(_storeId, _cancellationToken);
            
            var order = new AddOrderRequest
            {
                OrderDate = DateTime.Now.ToUniversalTime(),
                StoreId = storeDto.Id,
                UserId = _currentUser.Id
            };

            var createdOrderDto = await _orderService.AddAsync(order, _cancellationToken);

            var createdOrder = new Order(
                createdOrderDto.Id,
                createdOrderDto.OrderDate,
                createdOrderDto.StoreId,
                createdOrderDto.UserId,
                _currentUser);

            var instrumentDto =
                await _instrumentService.GetByIdAsync(
                    (Guid)selectedRow.Cells["InstrumentId"].Value,
                    _cancellationToken);
            
            var instrument = new Instrument(
                instrumentDto.Id,
                instrumentDto.Name,
                instrumentDto.Category,
                instrumentDto.Price);

            var orderInstrument = new AddOrderInstrumentRequest
            {
                OrderId = createdOrder.Id,
                InstrumentId = (Guid)selectedRow.Cells["InstrumentId"].Value,
                Amount = Convert.ToInt32(Amount.Value),
                Price = Convert.ToInt32(Amount.Value) * instrument.Price
            };

            await _orderInstrumentService.AddAsync(orderInstrument, _cancellationToken);
            await _userService.UpdateUserValuesAsync(
                _currentUser.Id,
                -Math.Abs(orderInstrument.Price),
                orderInstrument.Price,
                orderInstrument.Amount,
                _cancellationToken);
            await _instrumentStoreService.UpdateInstrumentAmountAsync(
                (Guid)selectedRow.Cells["Id"].Value,
                -Math.Abs(orderInstrument.Amount),
                _cancellationToken);
            
            await GetCurrentUser(_jwt, _cancellationToken);
            await GetCurrentStoreItems(_storeId, _cancellationToken);
            
            MessageBox.Show(@"Покупка совершена!");
        }

        /// <summary>
        /// Получение информации о конкретном инструменте
        /// </summary>
        private void InstrumentStoreTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedRow = InstrumentStoreTable.Rows[e.RowIndex];
            var instrumentId = (Guid)selectedRow.Cells["InstrumentId"].Value;

            var instrumentForm = new InstrumentForm(); 
            instrumentForm.ShowDialog();
        }
        
        /// <summary>
        /// Получение текущего пользователя по токену
        /// </summary>
        /// <param name="jwt">JWT токен.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        private async Task GetCurrentUser(string jwt, CancellationToken cancellationToken)
        {
            _currentUser = await _userService.DecodeJwtToken(jwt, cancellationToken);
            балансПолзователяToolStripMenuItem.Text = _currentUser?.Balance.ToString(CultureInfo.InvariantCulture) + '$';
        }

        /// <summary>
        /// Получение всех инструментов в магазине
        /// </summary>
        /// <param name="storeId">Идентификатор магазина.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        private async Task GetCurrentStoreItems(Guid storeId, CancellationToken cancellationToken)
        {
            var instrumentStores = await _instrumentStoreService.GetAllByStoreIdAsync(storeId, cancellationToken);
            InstrumentStoreTable.DataSource = instrumentStores.Select(instrumentStores => new
            {
                Id = instrumentStores.Id,
                InstrumentId = instrumentStores.Instrument.Id,
                InstrumentName = instrumentStores.Instrument.Name,
                instrumentStores.Amount,
                instrumentStores.Instrument.Price
            }).ToList();
        }

        /// <summary>
        /// Переход на страницу магазинов
        /// </summary>
        private void магазиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var storeListForm = new StoreListForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _cancellationToken);
            storeListForm.Show();
            Hide();
        }

        /// <summary>
        /// Переход на страницу заказов пользователя
        /// </summary>
        private void вашиЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myPurchasesForm = new MyPurchasesForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _cancellationToken);
            myPurchasesForm.Show();
            Hide();
        }

        /// <summary>
        /// Переход в профиль
        /// </summary>
        private void профильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var profileForm = new ProfileForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _cancellationToken);
            profileForm.Show();
            Hide();
        }

        /// <summary>
        /// Открытие редактирования профиля
        /// </summary>
        private void редактироватьПрофильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var profileUpdateForm = new ProfileUpdateForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _cancellationToken);
            profileUpdateForm.ShowDialog();
        }

        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _cancellationToken);
            loginForm.Show();
            Hide();
        }
    }
}
