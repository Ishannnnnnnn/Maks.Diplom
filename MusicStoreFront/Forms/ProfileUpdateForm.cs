using Application.Dto.UserDto;
using Application.Dto.ValueObjects;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма обновления пользователя
    /// </summary>
    public partial class ProfileUpdateForm : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly InstrumentService _instrumentService;
        private readonly StoreService _storeService;
        
        private readonly OrderInstrumentService _orderInstrumentService;
        private readonly InstrumentStoreService _instrumentStoreService;
        
        private readonly CancellationToken _cancellationToken;
        
        private readonly Guid _newFileId;
        private readonly IMapper _mapper;
        private readonly string _jwt;
        private string _avatarUrl;
        private string _avatarFilePath;
        private User? _currentUser;
        
        public ProfileUpdateForm(
            string jwt,
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
            
            _newFileId = Guid.NewGuid();
            _jwt = jwt;
            GetCurrentUser(jwt, _cancellationToken);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserMappingProfile>();
            });
            _mapper = config.CreateMapper();
            
            InitializeComponent();
        }

        /// <summary>
        /// Применение изменений
        /// </summary>
        private async void ApplyChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var updatedUser = new UpdateUserRequest
                {
                    Id = _currentUser.Id,
                    FullName = new FullNameDto { Name = UserName.Text, Surname = Surname.Text, Patronymic = Patronymic.Text },
                    Nickname = Nickname.Text,
                    Email = Email.Text,
                    Password = Password.Text,
                    Role = Role.User,
                    Balance = _currentUser.Balance,
                    MoneySpend = _currentUser.MoneySpend,
                    Purchases = _currentUser.Purchases
                };
                
                var user = _mapper.Map<User>(updatedUser);
                user.Validate();
                
                if (!string.IsNullOrEmpty(_avatarFilePath))
                {
                    var contentType = GetContentType(_avatarFilePath);
                    var fileName = _newFileId.ToString();

                    await using var fileStream = new FileStream(_avatarFilePath, FileMode.Open, FileAccess.Read);
                    await _userService.UpdateAsync(updatedUser, fileStream, fileName, contentType, _cancellationToken);
                    
                    MessageBox.Show(@"Обновление профиля успешно");
                    var profileForm = new ProfileForm(
                        _jwt,
                        _userService,
                        _orderService,
                        _orderInstrumentService,
                        _instrumentStoreService,
                        _instrumentService,
                        _storeService,
                        _cancellationToken);
                    profileForm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show(@"Необходимо выбрать аватар");
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка обновления профиля", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выбор аватара
        /// </summary>
        private void SelectAvatarButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"PNG and JPEG Images|*.png;*.jpeg;*.jpg";
            openFileDialog.Title = @"Select an Avatar (PNG or JPEG only)";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _avatarFilePath = openFileDialog.FileName;
                AvatarFileLabel.Text = _avatarFilePath;
            }
        }
        
        /// <summary>
        /// Получение текущего пользователя по токену
        /// </summary>
        /// <param name="jwt">JWT токен.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        private async void GetCurrentUser(string jwt, CancellationToken cancellationToken)
        {
            _currentUser = await _userService.DecodeJwtToken(jwt, cancellationToken);
            UserName.Text = _currentUser?.FullName.Name;
            Surname.Text = _currentUser?.FullName.Surname;
            Patronymic.Text = _currentUser?.FullName.Patronymic;
            Nickname.Text = _currentUser?.Nickname;
            Email.Text = _currentUser?.Email;
        }
        
        /// <summary>
        /// Получение типа файла
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <returns>Тип файла.</returns>
        private string? GetContentType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                _ => null
            };
        }
    }
}
