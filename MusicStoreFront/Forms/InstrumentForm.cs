using Application.Dto.InstrumentDto;
using Application.Dto.InstrumentStoreDto;
using Application.Services;
using Domain.Entities;
using Domain.Primitives;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма инструмента
    /// </summary>
    public partial class InstrumentForm : Form
    {
        private readonly GetByIdInstrumentResponse _instrument;
        private readonly GetByIdInstrumentStoreResponse _instrumentStore;

        private readonly InstrumentService _instrumentService;
        private readonly InstrumentStoreService _instrumentStoreService;
        private readonly CancellationToken _cancellationToken;

        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly StoreService _storeService;

        private readonly OrderInstrumentService _orderInstrumentService;

        private User? _currentUser;
        private readonly string _jwt;
        private readonly Guid _storeId;
        private readonly EmailService _emailService;

        public InstrumentForm(
            string jwt,
            UserService userService,
            OrderService orderService,
            OrderInstrumentService orderInstrumentService,
            InstrumentStoreService instrumentStoreService,
            InstrumentService instrumentService,
            StoreService storeService,
            Guid storeId,
            GetByIdInstrumentResponse instrument,
            GetByIdInstrumentStoreResponse instrumentStore,
            User currentUser,
            EmailService emailService,
            CancellationToken cancellationToken)
        {
            _instrument = instrument;
            _instrumentStore = instrumentStore;
            _jwt = jwt;
            _userService = userService;
            _orderService = orderService;
            _instrumentService = instrumentService;
            _storeService = storeService;
            _currentUser = currentUser;
            _emailService = emailService;

            _orderInstrumentService = orderInstrumentService;
            _instrumentStoreService = instrumentStoreService;

            _cancellationToken = cancellationToken;
            _storeId = storeId;

            InitializeComponent();

            InstrumentName.Text = _instrument.Name;
            InstrumentCategory.Text = _instrument.Category.ToString();
            Price.Value = Convert.ToDecimal(_instrument.Price);
            Amount.Value = Convert.ToInt32(_instrumentStore.Amount);
            ImageBox.LoadAsync(_instrument.ImageUrl);
            ImageBox.SizeMode = PictureBoxSizeMode.Zoom;

            DeleteInstrumentButton.Visible = false;
            UpdateButton.Visible = false;
            if (currentUser.Role == Role.Owner)
            {
                DeleteInstrumentButton.Visible = true;
                UpdateButton.Visible = true;
            }
        }

        /// <summary>
        /// Удаление инструмента
        /// </summary>
        private async void DeleteInstrumentButton_Click(object sender, EventArgs e)
        {
            await _instrumentService.DeleteAsync(_instrument.Id, _cancellationToken);
            var storeForm = new StoreForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _emailService,
                _storeId,
                _cancellationToken);
            storeForm.Show();
            Hide();
        }

        /// <summary>
        /// Обновление инструмента и его кол-во на складе магазина
        /// </summary>
        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            await _instrumentStoreService.UpdateInstrumentAmountValueAsync(
                _instrumentStore.Id,
                Convert.ToInt32(Amount.Value),
                _cancellationToken);

            Category category = Category.None;

            if (InstrumentCategory.Text == @"Guitar")
                category = Category.Guitar;
            if (InstrumentCategory.Text == @"Drums")
                category = Category.Drums;
            if (InstrumentCategory.Text == @"Wind")
                category = Category.Wind;
            if (InstrumentCategory.Text == @"Amps")
                category = Category.Amps;
            if (InstrumentCategory.Text == @"GuitarPick")
                category = Category.GuitarPick;
            if (InstrumentCategory.Text == @"Case")
                category = Category.Case;

            var updatedInstrument = new UpdateInstrumentRequest
            {
                Id = _instrument.Id,
                Name = InstrumentName.Text,
                Category = category,
                Price = Convert.ToDecimal(Price.Value)
            };

            await _instrumentService.UpdateAsync(
                updatedInstrument,
                _cancellationToken);

            MessageBox.Show(@"Инструмент обновлен");
        }

        /// <summary>
        /// Назад
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            var storeForm = new StoreForm(
                _jwt,
                _userService,
                _orderService,
                _orderInstrumentService,
                _instrumentStoreService,
                _instrumentService,
                _storeService,
                _emailService,
                _storeId,
                _cancellationToken);
            storeForm.Show();
            Hide();
        }
    }
}
