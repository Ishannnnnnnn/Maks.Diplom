using Application.Services;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Форма просмотра конкретного заказа
    /// </summary>
    public partial class OrderDetailsForm : Form
    {
        private readonly OrderService _orderService;
        private readonly CancellationToken _cancellationToken;
        private readonly Guid _orderId;
        
        public OrderDetailsForm(
            OrderService orderService,
            Guid orderId,
            CancellationToken cancellationToken)
        {
            _orderService = orderService;
            _cancellationToken = cancellationToken;
            _orderId = orderId;
            
            LoadOrderDetails();
            InitializeComponent();
        }
        
        /// <summary>
        /// Загрузка данных заказа
        /// </summary>
        private async void LoadOrderDetails()
        {
            var order = await _orderService.GetByIdAsync(_orderId, _cancellationToken);
            if (order != null)
            {
                OrderDate.Text = order.OrderDate.ToString("dd.MM.yyyy");
                InstrumentName.Text = string.Join(", ", order.OrderInstruments.Select(oi => oi.Instrument.Name));
                StoreAddress.Text = order.Store.Address.City + @" " + order.Store.Address.Street + @" " + order.Store.Address.HouseNumber;
                InstrumentImage.SizeMode = PictureBoxSizeMode.Zoom;
                InstrumentImage.LoadAsync(string.Join(", ", order.OrderInstruments.Select(oi => oi.Instrument.ImageUrl)));
                Amount.Text = order.OrderInstruments.Sum(oi => oi.Amount).ToString();
                SumPrice.Text = order.OrderInstruments.Sum(oi => oi.Price) + @"$";
            }
        }
    }
}
