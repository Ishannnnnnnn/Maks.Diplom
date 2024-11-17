using Application.Dto.UserDto.Auth;
using Application.Services;

namespace MusicStoreFront.Forms;

/// <summary>
/// Форма входа
/// </summary>
public partial class LoginForm : Form
{
    private readonly UserService _userService;
    private readonly OrderService _orderService;
    private readonly InstrumentService _instrumentService;
    private readonly StoreService _storeService;
    
    private readonly OrderInstrumentService _orderInstrumentService;
    private readonly InstrumentStoreService _instrumentStoreService;
    
    private readonly CancellationToken _cancellationToken;
    
    public LoginForm(
        UserService userService,
        OrderService orderService,
        OrderInstrumentService orderInstrumentService,
        InstrumentStoreService instrumentStoreService,
        InstrumentService instrumentService,
        StoreService storeService,
        CancellationToken cancellationToken)
    {
        _userService = userService;
        _orderService = orderService;
        _instrumentService = instrumentService;
        _storeService = storeService;
        
        _orderInstrumentService = orderInstrumentService;
        _instrumentStoreService = instrumentStoreService;
        
        _cancellationToken = cancellationToken;
        
        InitializeComponent();
    }

    /// <summary>
    /// Вход в аккаунт
    /// </summary>
    private async void LoginButton_Click(object sender, EventArgs e)
    {
        var loginRequest = new LoginUserRequest
        {
            Email = Email.Text,
            Password = Password.Text
        };
        var user = await _userService.LoginAsync(loginRequest, _cancellationToken);

        if (user == null)
            MessageBox.Show(@"Неверный логин или пароль");
        else
        {
            var homeForm = new HomeForm(
                user.Token,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _cancellationToken);
            homeForm.Show();
            Hide();
        }
    }

    /// <summary>
    /// Переход на RegisterForm
    /// </summary>
    private void ToRegisterButton_Click(object sender, EventArgs e)
    {
        var registerForm = new RegisterForm(
            _userService,
            _orderService,
            _orderInstrumentService,
            _instrumentStoreService,
            _instrumentService,
            _storeService,
            _cancellationToken);
        registerForm.Show();
        Hide();
    }
}