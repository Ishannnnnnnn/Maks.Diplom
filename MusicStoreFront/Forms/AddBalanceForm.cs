using Application.Services;
using Domain.Entities;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма пополнения баланса
    /// </summary>
    public partial class AddBalanceForm : Form
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
        
        public AddBalanceForm(
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
            _instrumentStoreService = instrumentStoreService;
            _instrumentStoreService = instrumentStoreService;
            _orderInstrumentService = orderInstrumentService;
            _emailService = emailService;
            _cancellationToken = cancellationToken;
            
            GetCurrentUser(jwt, _cancellationToken);
            InitializeComponent();
        }

        /// <summary>
        /// Пополнение баланса
        /// </summary>
        private async void AddBalanceButton_Click(object sender, EventArgs e)
        {
            var newBalance = Convert.ToDecimal(BalanceToAdd.Value);
            await _userService.UpdateUserValuesAsync(_currentUser.Id, Math.Abs(newBalance), 0, 0, _cancellationToken);
            MessageBox.Show(@"Баланс успешно пополнен");
        }

        /// <summary>
        /// Возращение
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
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
        /// Получение текущего пользователя по токену
        /// </summary>
        /// <param name="jwt">JWT токен.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        private async void GetCurrentUser(string jwt, CancellationToken cancellationToken)
        {
            _currentUser = await _userService.DecodeJwtToken(jwt, cancellationToken);
        }
    }
}
