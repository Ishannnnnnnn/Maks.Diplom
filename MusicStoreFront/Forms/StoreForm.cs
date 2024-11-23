using System.Globalization;
using Application.Dto.InstrumentStoreDto;
using Application.Dto.OrderDto;
using Application.Dto.OrderInstrumentDto;
using Application.Services;
using Domain.Entities;
using Domain.Primitives;

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
        private readonly EmailService _emailService;

        private void TextChanged(object sender, EventArgs e) => UpdateData();

        public StoreForm(
            string jwt,
            UserService userService,
            OrderService orderService,
            OrderInstrumentService orderInstrumentService,
            InstrumentStoreService instrumentStoreService,
            InstrumentService instrumentService,
            StoreService storeService,
            EmailService emailService,
            Guid storeId,
            CancellationToken cancellationToken)
        {
            _jwt = jwt;
            _userService = userService;
            _orderService = orderService;
            _instrumentService = instrumentService;
            _storeService = storeService;
            _emailService = emailService;

            _orderInstrumentService = orderInstrumentService;
            _instrumentStoreService = instrumentStoreService;
            
            _cancellationToken = cancellationToken;
            _storeId = storeId;

            GetCurrentUser(jwt, _cancellationToken);
            GetCurrentStoreItems(storeId, _cancellationToken);

            InitializeComponent();

            AddInstrumentButton.Visible = false;
            DeleteInstrumentButton.Visible = false;
            AmountToAdd.Visible = false;
            InstrumentToAdd.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            InstrumentToAdd.Visible = false;
            
            Amount.Visible = true;
            label2.Visible = true;

            MaxPrice.Value = 10000;

            Search.TextChanged += TextChanged;
            MaxPrice.TextChanged += TextChanged;
            MinPrice.TextChanged += TextChanged;

            LoadInstrumentsToComboBox();
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

            GetCurrentUser(_jwt, _cancellationToken);
            MessageBox.Show(@"Покупка совершена!");
            await GetCurrentStoreItems(_storeId, _cancellationToken);
            
            string receiptBody = $"Уважаемый {_currentUser.FullName.Surname} {_currentUser.FullName.Name} {_currentUser.FullName.Patronymic},\n\n" +
                                 $"Вы успешно приобрели {instrument.Name} в количестве {orderInstrument.Amount}.\n" +
                                 $"Общая стоимость: {orderInstrument.Price}$.\n\n" +
                                 "Спасибо за покупку в нашем магазине!";
            await _emailService.SendEmailAsync(_currentUser.Email, "Квитанция о покупке", receiptBody);
        }

        /// <summary>
        /// Получение информации о конкретном инструменте
        /// </summary>
        private async void InstrumentStoreTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedRow = InstrumentStoreTable.Rows[e.RowIndex];
            var instrumentId = (Guid)selectedRow.Cells["InstrumentId"].Value;
            var instrumentStoreId = (Guid)selectedRow.Cells["Id"].Value;
            var instrument = await _instrumentService.GetByIdAsync(instrumentId, _cancellationToken);
            var instrumentStore = await _instrumentStoreService.GetByIdAsync(instrumentStoreId, _cancellationToken);
            
            var instrumentForm = new InstrumentForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _storeId,
                instrument,
                instrumentStore,
                _currentUser,
                _emailService,
                _cancellationToken);
            instrumentForm.Show();
            Hide();
        }

        /// <summary>
        /// Получение текущего пользователя по токену
        /// </summary>
        /// <param name="jwt">JWT токен.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        private async Task GetCurrentUser(string jwt, CancellationToken cancellationToken)
        {
            _currentUser = await _userService.DecodeJwtToken(jwt, cancellationToken);
            if (_currentUser.Role == Role.Owner)
            {
                балансПолзователяToolStripMenuItem.Text = @"Владелец";
                AddInstrumentButton.Visible = true;
                DeleteInstrumentButton.Visible = true;
                BuyButton.Visible = false;
                Amount.Visible = false;
                label2.Visible = false;
                AmountToAdd.Visible = true;
                InstrumentToAdd.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                InstrumentToAdd.Visible = true;
            }
            else
                балансПолзователяToolStripMenuItem.Text = _currentUser?.Balance.ToString(CultureInfo.InvariantCulture) + '$';
        }

        /// <summary>
        /// Получение всех инструментов в магазине
        /// </summary>
        /// <param name="storeId">Идентификатор магазина.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public async Task GetCurrentStoreItems(Guid storeId, CancellationToken cancellationToken)
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
                _emailService,
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
                _emailService,
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
                _emailService,
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
                _emailService,
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
                _emailService,
                _cancellationToken);
            loginForm.Show();
            Hide();
        }

        /// <summary>
        /// Добавление инструмента в магазин
        /// </summary>
        private async void AddInstrumentButton_Click(object sender, EventArgs e)
        {
            if (InstrumentToAdd.SelectedValue is Guid selectedInstrumentId)
            {
                var instrumentStoreRequest = new AddInstrumentStoreRequest
                {
                    StoreId = _storeId,
                    InstrumentId = selectedInstrumentId,
                    Amount = Convert.ToInt32(AmountToAdd.Value)
                };

                var isExist = await _instrumentStoreService.GetByInstrumentIdAsync(selectedInstrumentId, _cancellationToken);
                if (isExist)
                    MessageBox.Show(@"Данный инструмент уже есть в данном магазине");
                else
                {
                    await _instrumentStoreService.AddAsync(instrumentStoreRequest, _cancellationToken);
                    MessageBox.Show(@"Инструмент добавлен в магазин");
                }
            }

            await GetCurrentStoreItems(_storeId, _cancellationToken);
        }

        /// <summary>
        /// Удаление инструмента
        /// </summary>
        private async void DeleteInstrumentButton_Click(object sender, EventArgs e)
        {
            var selectedRow = InstrumentStoreTable.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow == null)
                MessageBox.Show(@"Пожалуйста, выберите инструмент для удаления из магазина.");

            var instrumentId = (Guid)selectedRow?.Cells["Id"].Value;
            await _instrumentStoreService.DeleteAsync(instrumentId, _cancellationToken);
            MessageBox.Show(@"Инструмент удален из магазина");
            await GetCurrentStoreItems(_storeId, _cancellationToken);
            LoadInstrumentsToComboBox();
        }

        /// <summary>
        /// Сортировка
        /// </summary>
        private async void UpdateData()
        {
            var nameFilter = Search.Text;
            var minPrice = decimal.TryParse(MinPrice.Text, out var min) ? min : 0;
            var maxPrice = decimal.TryParse(MaxPrice.Text, out var max) ? max : decimal.MaxValue;

            var instrumentStores = await _instrumentStoreService.GetAllByStoreIdAsync(_storeId, _cancellationToken);

            var filteredInstruments = instrumentStores
                .Where(inst =>
                    inst.Instrument.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase) &&
                    inst.Instrument.Price >= minPrice &&
                    inst.Instrument.Price <= maxPrice)
                .OrderBy(inst => inst.Instrument.Name)
                .ThenBy(inst => inst.Instrument.Price)
                .Select(inst => new
                {
                    Id = inst.Id,
                    InstrumentId = inst.Instrument.Id,
                    InstrumentName = inst.Instrument.Name,
                    inst.Amount,
                    inst.Instrument.Price
                })
                .ToList();

            InstrumentStoreTable.DataSource = filteredInstruments;
        }
        
        /// <summary>
        /// Загрузка данных инструментов в ComboBox.
        /// </summary>
        private async Task LoadInstrumentsToComboBox()
        {
            var instruments = await _instrumentService.GetAllAsync(_cancellationToken);
            
            InstrumentToAdd.DisplayMember = "Name";
            InstrumentToAdd.ValueMember = "Id";
            InstrumentToAdd.DataSource = instruments.Select(inst => new 
            {
                inst.Id, 
                inst.Name 
            }).ToList();
        }
    }
}
