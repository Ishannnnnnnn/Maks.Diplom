using Application.Services;
using Domain.Entities;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма всех заказов пользователя
    /// </summary>
    public partial class MyPurchasesForm : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly InstrumentService _instrumentService;
        private readonly StoreService _storeService;
        private readonly EmailService _emailService;
        
        private readonly OrderInstrumentService _orderInstrumentService;
        private readonly InstrumentStoreService _instrumentStoreService;

        private readonly CancellationToken _cancellationToken;

        private readonly string _jwt;
        private User? _currentUser;

        public MyPurchasesForm(
            string jwt,
            UserService userService,
            OrderService orderService,
            OrderInstrumentService orderInstrumentService,
            InstrumentStoreService instrumentStoreService,
            InstrumentService instrumentService,
            StoreService storeService,
            EmailService emailService,
            CancellationToken cancellationToken)
        {
            _userService = userService;
            _orderService = orderService;
            _instrumentService = instrumentService;
            _storeService = storeService;
            _emailService = emailService;
            
            _orderInstrumentService = orderInstrumentService;
            _instrumentStoreService = instrumentStoreService;

            _cancellationToken = cancellationToken;

            _jwt = jwt;
            GetCurrentUser(jwt, _cancellationToken);

            InitializeComponent();
        }

        /// <summary>
        /// Просмотр конкретного заказа
        /// </summary>
        private void OrdersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedRow = OrdersTable.Rows[e.RowIndex];
            var orderId = (Guid)selectedRow.Cells["OrderId"].Value;

            var orderDetailsForm = new OrderDetailsForm(
                _orderService,
                orderId,
                _emailService,
                _cancellationToken);
            orderDetailsForm.ShowDialog();
        }

        /// <summary>
        /// Загрузка всех заказов текущего пользователя и отображение в таблице
        /// </summary>
        private async void LoadUserOrders(CancellationToken cancellationToken)
        {
            if (_currentUser == null)
                return;

            var ordersResponse = await _orderService.GetAllByUserIdAsync(_currentUser.Id, cancellationToken);
            var ordersData = ordersResponse.Select(order => new
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate.ToString("dd.MM.yyyy"),
                Address = order.Store?.Address.City + @" " + order.Store?.Address.Street + @" " + order.Store?.Address.HouseNumber,
                Item = string.Join(", ", order.OrderInstruments.Select(oi => oi.Instrument.Name)),
                Amount = order.OrderInstruments.Sum(oi => oi.Amount),
                TotalPrice = order.OrderInstruments.Sum(oi => oi.Price)
            }).ToList();

            OrdersTable.DataSource = ordersData;
        }

        /// <summary>
        /// Получение текущего пользователя по токену
        /// </summary>
        /// <param name="jwt">JWT токен.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        private async void GetCurrentUser(string jwt, CancellationToken cancellationToken)
        {
            _currentUser = await _userService.DecodeJwtToken(jwt, cancellationToken);
            LoadUserOrders(_cancellationToken);
        }

        /// <summary>
        /// Переход на главную страницу
        /// </summary>
        private void главнаяСтраницыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var homeForm = new HomeForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _emailService,
                _cancellationToken);
            homeForm.Show();
            Hide();
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
        private void редактироватьПрофильToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}
