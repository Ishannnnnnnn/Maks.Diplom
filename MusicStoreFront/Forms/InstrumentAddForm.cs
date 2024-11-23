using Application.Dto.InstrumentDto;
using Application.Services;
using Domain.Primitives;

namespace MusicStoreFront.Forms
{
    /// <summary>
    /// Добавление инструмента
    /// </summary>
    public partial class InstrumentAddForm : Form
    {
        private string _filePath;
        private readonly InstrumentService _instrumentService;
        private readonly CancellationToken _cancellationToken;
        
        public InstrumentAddForm(
            InstrumentService instrumentService,
            CancellationToken cancellationToken)
        {
            _instrumentService = instrumentService;
            _cancellationToken = cancellationToken;
            
            InitializeComponent();
        }

        /// <summary>
        /// Установка изображения
        /// </summary>
        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"PNG and JPEG Images|*.png;*.jpeg;*.jpg";
            openFileDialog.Title = @"Select an Avatar (PNG or JPEG only)";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = openFileDialog.FileName;
                FileLabel.Text = _filePath;
            }
        }

        /// <summary>
        /// Добавление инструмента
        /// </summary>
        private async void AddInstrumentButton_Click(object sender, EventArgs e)
        {
            Category category = Category.None;
            if (InstrumentCategory.Text == @"Guitar")
                category = Category.Guitar;
            if (InstrumentCategory.Text == @"Drums")
                category = Category.Drums;
            if (InstrumentCategory.Text == @"Wind")
                category = Category.Wind;
            if (InstrumentCategory.Text == @"Amps")
                category = Category.Amps;
            if (InstrumentCategory.Text == @"Case")
                category = Category.Case;
            
            var newInstrument = new AddInstrumentRequest
            {
                Name = InstrumentName.Text,
                Category = category,
                Price = Convert.ToDecimal(Price.Value)
            };

            if (!string.IsNullOrEmpty(_filePath))
            {
                var contentType = GetContentType(_filePath);
                var fileName = Guid.NewGuid().ToString();

                await using var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
                await _instrumentService.AddAsync(newInstrument, fileStream, fileName, contentType, _cancellationToken);

                MessageBox.Show(@"Инструмент добавлен на склад");
            }
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
