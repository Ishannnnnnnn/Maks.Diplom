using Application.Services;
using Domain.Entities;
using Domain.Primitives;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма магазинов
    /// </summary>
    public partial class StoreListForm : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly InstrumentService _instrumentService;
        private readonly StoreService _storeService;
        
        private readonly OrderInstrumentService _orderInstrumentService;
        
        private readonly CancellationToken _cancellationToken;
        
        private User? _currentUser;
        private readonly string _jwt;
        
        public StoreListForm(
            string jwt,
            UserService userService,
            OrderService orderService,
            OrderInstrumentService orderInstrumentService,
            InstrumentService instrumentService,
            StoreService storeService,
            CancellationToken cancellationToken)
        {
            _jwt = jwt;
            _userService = userService;
            _orderService = orderService;
            _instrumentService = instrumentService;
            _storeService = storeService;
            
            _orderInstrumentService = orderInstrumentService;

            _cancellationToken = cancellationToken;
            
            InitializeComponent();
            InitializeFormAsync();
        }
        
        private async Task InitializeFormAsync()
        {
            await GetCurrentUser(_jwt, _cancellationToken);
            await LoadStores(_cancellationToken);
            
            if (_currentUser?.Role == Role.Owner)
            {
                AddStoreAdminButton.Visible = true;
                DeleteStoreAdminButton.Visible = true;
            }
            else
            {
                AddStoreAdminButton.Visible = false;
                DeleteStoreAdminButton.Visible = false;
            }
        }
        
        /// <summary>
        /// Загрузка всех магазинов
        /// </summary>
        private async Task LoadStores(CancellationToken cancellationToken)
        {
            var storesResponse = await _storeService.GetAllAsync(cancellationToken);
            var storesData = storesResponse.Select(store => new
            {
                Id = store.Id,
                City = store.Address.City,
                Street = store.Address.Street,
                HouseNumber = store.Address.HouseNumber,
                Phone = store.Phone
            }).ToList();

            StoresTable.DataSource = storesData;
        }

        /// <summary>
        /// Переход на главную страницу
        /// </summary>
        private void главнаяСтраницаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var homeForm = new HomeForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentService,
                _storeService,
                _cancellationToken);
            homeForm.Show();
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
                _instrumentService,
                _storeService,
                _cancellationToken);
            loginForm.Show();
            Hide();
        }

        /// <summary>
        /// Добавление нового магазина
        /// </summary>
        private void AddStoreAdminButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Удаление магазина
        /// </summary>
        private void DeleteStoreAdminButton_Click(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Получение текущего пользователя по токену
        /// </summary>
        /// <param name="jwt">JWT токен.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        private async Task GetCurrentUser(string jwt, CancellationToken cancellationToken)
        {
            _currentUser = await _userService.DecodeJwtToken(jwt, cancellationToken);
        }
    }
}
