﻿using Application.Services;
using Domain.Entities;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма профиля пользователя
    /// </summary>
    public partial class ProfileForm : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly InstrumentService _instrumentService;
        private readonly StoreService _storeService;
        
        private readonly OrderInstrumentService _orderInstrumentService;

        private readonly CancellationToken _cancellationToken;

        private User? _currentUser;
        private readonly string _jwt;

        public ProfileForm(
            string jwt,
            UserService userService,
            OrderService orderService,
            OrderInstrumentService orderInstrumentService,
            InstrumentService instrumentService,
            StoreService storeService,
            CancellationToken cancellationToken)
        {
            _userService = userService;
            _orderService = orderService;
            _instrumentService = instrumentService;
            _storeService = storeService;
            
            _orderInstrumentService = orderInstrumentService;

            _cancellationToken = cancellationToken;

            _jwt = jwt;
            GetCurrentUser(jwt, _cancellationToken);

            InitializeComponent();
        }

        /// <summary>
        /// Открытие страницы изменения профиля
        /// </summary>
        private void ToProfileUpdateButton_Click(object sender, EventArgs e)
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
        /// Удаление профиля
        /// </summary>
        private async void DeleteUserButton_Click(object sender, EventArgs e)
        {
            if (_currentUser != null)
                await _userService.DeleteAsync(_currentUser.Id, _cancellationToken);

            MessageBox.Show(@"Профиль успешно удален");

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
            AvatarPictureBox.LoadAsync(_currentUser?.AvatarUrl);
            AvatarPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
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
        /// Переход на страницу магазинов
        /// </summary>
        private void магазиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var storeListForm = new StoreListForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
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
                _instrumentService,
                _storeService,
                _cancellationToken);
            myPurchasesForm.Show();
            Hide();
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
    }
}
