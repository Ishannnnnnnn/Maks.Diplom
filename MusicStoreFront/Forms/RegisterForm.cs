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
    /// Форма регистрации
    /// </summary>
    public partial class RegisterForm : Form
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly InstrumentService _instrumentService;
        private readonly StoreService _storeService;
        
        private readonly OrderInstrumentService _orderInstrumentService;
        
        private readonly IMapper _mapper;
        private readonly CancellationToken _cancellationToken;
        
        private string _avatarUrl;
        private string _avatarFilePath;
        private readonly Guid _newFileId;

        public RegisterForm(
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
            _newFileId = Guid.NewGuid();
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserMappingProfile>();
            });
            _mapper = config.CreateMapper();
            
            InitializeComponent();
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new AddUserRequest
                {
                    FullName = new FullNameDto { Name = UserName.Text, Surname = Surname.Text, Patronymic = Patronymic.Text },
                    Nickname = Nickname.Text,
                    Email = Email.Text,
                    Password = Password.Text,
                    Role = Role.User,
                    Balance = 0,
                    MoneySpend = 0,
                    Purchases = 0
                };
                
                var user = _mapper.Map<User>(newUser);
                user.Validate();
                
                if (!string.IsNullOrEmpty(_avatarFilePath))
                {
                    var contentType = GetContentType(_avatarFilePath);
                    var fileName = _newFileId.ToString();

                    await using var fileStream = new FileStream(_avatarFilePath, FileMode.Open, FileAccess.Read);
                    await _userService.AddAsync(newUser, fileStream, fileName, contentType, _cancellationToken);
                    
                    MessageBox.Show(@"Регистрация успешна");
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
                else
                {
                    MessageBox.Show(@"Необходимо выбрать аватар");
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выбрать аватар
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
        /// Вернуться на окно входа
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
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
