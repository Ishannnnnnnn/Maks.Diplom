using Application.Dto.User.Auth;
using Application.Services;

namespace MusicStoreFront.Forms;

/// <summary>
/// Форма входа
/// </summary>
public partial class LoginForm : Form
{
    private readonly CancellationToken _cancellationToken;
    private readonly UserService _userService;
    
    public LoginForm(
        UserService userService,
        CancellationToken cancellationToken)
    {
        _userService = userService;
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
            var homeForm = new HomeForm(user.Token, _userService, _cancellationToken);
            homeForm.Show();
            Hide();
        }
    }

    /// <summary>
    /// Переход на RegisterForm
    /// </summary>
    private void ToRegisterButton_Click(object sender, EventArgs e)
    {
        var registerForm = new RegisterForm( _userService, _cancellationToken);
        registerForm.Show();
        Hide();
    }
}