using Application.Dto.StoreDto;
using Application.Dto.ValueObjects;
using Application.Services;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма добавления магазина
    /// </summary>
    public partial class StoreAddForm : Form
    {
        private readonly StoreService _storeService;
        private readonly CancellationToken _cancellationToken;
        private readonly StoreListForm _storeListForm;
        private readonly EmailService _emailService;
        
        public StoreAddForm(
            StoreService storeService,
            StoreListForm storeListForm,
            EmailService emailService,
            CancellationToken cancellationToken)
        {
            _storeService = storeService;
            _storeListForm = storeListForm;
            _emailService = emailService;
            _cancellationToken = cancellationToken;
            
            InitializeComponent();
        }

        /// <summary>
        /// Добавление магазина
        /// </summary>
        private async void AddStoreButton_Click(object sender, EventArgs e)
        {
            var city = City.Text;
            var street = Street.Text;
            var houseNumber = Convert.ToInt32(HouseNumber.Text);
            var phone = Phone.Text;

            var store = new AddStoreRequest
            {
                Address = new AddressDto
                {
                    City = city,
                    HouseNumber = houseNumber,
                    Street = street
                },
                Phone = phone
            };

            await _storeService.AddAsync(store, _cancellationToken);
            MessageBox.Show(@"Магазин создан");
            await _storeListForm.LoadStores(_cancellationToken);
        }
    }
}
