using Application.Services;
using Domain.Entities;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма домашней страницы
    /// </summary>
    public partial class HomeForm : Form
    {
        private readonly string _jwt;
        private User? _currentUser;
        
        private readonly UserService _userService;
        private readonly CancellationToken _cancellationToken;
        
        public HomeForm(
            string jwt,
            UserService userService,
            CancellationToken cancellationToken)
        {
            _jwt = jwt;
            _userService = userService;
            _cancellationToken = cancellationToken;
            GetCurrentUser(jwt, _cancellationToken);
            
            InitializeComponent();
        }
        
        private void ToStoresListButton_Click(object sender, EventArgs e)
        {

        }

        private void ToMyPurchasesButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Переход в профиль текущего пользователя
        /// </summary>
        private void ToMyProfileButton_Click(object sender, EventArgs e)
        {
            var profileForm = new ProfileForm(_jwt, _userService, _cancellationToken);
            profileForm.Show();
            Hide();
        }
        
        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_userService, _cancellationToken);
            loginForm.Show();
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
            UsernameLabel.Text = _currentUser?.FullName.Name + @" " + _currentUser?.FullName.Surname;
        }
    }
}
