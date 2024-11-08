using Application.Services;
using Domain.Entities;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма профиля пользователя
    /// </summary>
    public partial class ProfileForm : Form
    {
        private readonly string _jwt;
        private readonly UserService _userService;
        private readonly CancellationToken _cancellationToken;
        private User? _currentUser;

        public ProfileForm(
            string jwt,
            UserService userService,
            CancellationToken cancellationToken)
        {
            _jwt = jwt;
            _userService = userService; ;
            _cancellationToken = cancellationToken;
            GetCurrentUser(jwt, _cancellationToken);

            InitializeComponent();
        }

        /// <summary>
        /// Переход на страницу изменения профиля
        /// </summary>
        private void ToProfileUpdateButton_Click(object sender, EventArgs e)
        {
            var profileUpdateForm = new ProfileUpdateForm(_jwt, _userService, _cancellationToken);
            profileUpdateForm.Show();
            Hide();
        }
        
        /// <summary>
        /// Удаление профиля
        /// </summary>
        private async void DeleteUserButton_Click(object sender, EventArgs e)
        {
            if (_currentUser != null) 
                await _userService.DeleteAsync(_currentUser.Id, _cancellationToken);

            MessageBox.Show(@"Профиль успешно удален");

            var loginForm = new LoginForm(_userService, _cancellationToken);
            loginForm.Show();
            Hide();
        }

        /// <summary>
        /// Возвращение на домашнюю страницу
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            var homeForm = new HomeForm(_jwt, _userService, _cancellationToken);
            homeForm.Show();
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
            NameLabel.Text = _currentUser?.FullName.Name + @" " + _currentUser?.FullName.Surname + @" " + _currentUser?.FullName.Patronymic;
            NicknameLabel.Text = _currentUser?.Nickname;
            EmailLabel.Text = _currentUser?.Email;
            RegistrationDateLabel.Text = _currentUser?.RegistrationDate.ToString();
            AvatarPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            AvatarPictureBox.LoadAsync(_currentUser?.AvatarUrl);
        }
    }
}
