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
        private readonly EmailService _emailService;

        private readonly OrderInstrumentService _orderInstrumentService;
        private readonly InstrumentStoreService _instrumentStoreService;

        private readonly CancellationToken _cancellationToken;

        private User? _currentUser;
        private readonly string _jwt;

        public StoreListForm(
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
            _jwt = jwt;
            _userService = userService;
            _orderService = orderService;
            _instrumentService = instrumentService;
            _storeService = storeService;

            _orderInstrumentService = orderInstrumentService;
            _instrumentStoreService = instrumentStoreService;
            _emailService = emailService;

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
                CreateInstrumentButton.Visible = true;
            }
            else
            {
                AddStoreAdminButton.Visible = false;
                DeleteStoreAdminButton.Visible = false;
                CreateInstrumentButton.Visible = false;
            }
        }

        /// <summary>
        /// Загрузка всех магазинов
        /// </summary>
        public async Task LoadStores(CancellationToken cancellationToken)
        {
            var storesResponse = await _storeService.GetAllAsync(cancellationToken);
            var storesData = storesResponse.Select(store => new
            {
                StoreId = store.Id,
                City = store.Address.City,
                Street = store.Address.Street,
                HouseNumber = store.Address.HouseNumber,
                Phone = store.Phone
            }).ToList();

            StoresTable.DataSource = storesData;
        }

        /// <summary>
        /// Переход в магазин
        /// </summary>
        private void StoresTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedRow = StoresTable.Rows[e.RowIndex];
            var storeId = (Guid)selectedRow.Cells["StoreId"].Value;

            var storeForm = new StoreForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _emailService,
                storeId,
                _cancellationToken);
            storeForm.Show();
            Hide();
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
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _emailService,
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
        /// Добавление нового магазина
        /// </summary>
        private void AddStoreAdminButton_Click(object sender, EventArgs e)
        {
            var storeAddForm = new StoreAddForm(
                _storeService,
                this,
                _emailService,
                _cancellationToken);
            storeAddForm.ShowDialog();
        }

        /// <summary>
        /// Удаление магазина
        /// </summary>
        private async void DeleteStoreAdminButton_Click(object sender, EventArgs e)
        {
            var selectedRow = StoresTable.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow == null)
                MessageBox.Show(@"Пожалуйста, выберите магазин для удаления.");

            var storeId = (Guid)selectedRow?.Cells["StoreId"].Value;
            await _storeService.DeleteAsync(storeId, _cancellationToken);
            MessageBox.Show(@"Магазин удален");
            await LoadStores(_cancellationToken);
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

        /// <summary>
        /// Добавление инструмента на склад
        /// </summary>
        private void CreateInstrumentButton_Click(object sender, EventArgs e)
        {
            var instrumentAddForm = new InstrumentAddForm(_instrumentService, _cancellationToken);
            instrumentAddForm.ShowDialog();
        }
    }
}
