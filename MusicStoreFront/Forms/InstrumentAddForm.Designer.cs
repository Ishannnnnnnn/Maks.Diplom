namespace MusicStoreFront.Forms
{
    partial class InstrumentAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SelectImageButton = new Button();
            InstrumentName = new TextBox();
            InstrumentCategory = new ComboBox();
            Price = new NumericUpDown();
            AddInstrumentButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            FileLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)Price).BeginInit();
            SuspendLayout();
            // 
            // SelectImageButton
            // 
            SelectImageButton.Location = new Point(12, 80);
            SelectImageButton.Name = "SelectImageButton";
            SelectImageButton.Size = new Size(183, 29);
            SelectImageButton.TabIndex = 0;
            SelectImageButton.Text = "Выбрать изображение";
            SelectImageButton.UseVisualStyleBackColor = true;
            SelectImageButton.Click += SelectImageButton_Click;
            // 
            // InstrumentName
            // 
            InstrumentName.Location = new Point(12, 34);
            InstrumentName.Name = "InstrumentName";
            InstrumentName.Size = new Size(168, 27);
            InstrumentName.TabIndex = 1;
            // 
            // InstrumentCategory
            // 
            InstrumentCategory.FormattingEnabled = true;
            InstrumentCategory.Items.AddRange(new object[] { "Drums", "Amps", "Wind", "Guitar", "GuitarPick", "Case" });
            InstrumentCategory.Location = new Point(186, 34);
            InstrumentCategory.Name = "InstrumentCategory";
            InstrumentCategory.Size = new Size(168, 28);
            InstrumentCategory.TabIndex = 2;
            // 
            // Price
            // 
            Price.Location = new Point(360, 35);
            Price.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            Price.Name = "Price";
            Price.Size = new Size(168, 27);
            Price.TabIndex = 3;
            // 
            // AddInstrumentButton
            // 
            AddInstrumentButton.Location = new Point(12, 132);
            AddInstrumentButton.Name = "AddInstrumentButton";
            AddInstrumentButton.Size = new Size(520, 49);
            AddInstrumentButton.TabIndex = 4;
            AddInstrumentButton.Text = "Добавить инструмент";
            AddInstrumentButton.UseVisualStyleBackColor = true;
            AddInstrumentButton.Click += AddInstrumentButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 5;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 11);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 6;
            label2.Text = "Категория";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(360, 12);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 7;
            label3.Text = "Цена";
            // 
            // FileLabel
            // 
            FileLabel.AutoSize = true;
            FileLabel.Location = new Point(201, 89);
            FileLabel.Name = "FileLabel";
            FileLabel.Size = new Size(0, 20);
            FileLabel.TabIndex = 8;
            // 
            // InstrumentAddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 195);
            Controls.Add(FileLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AddInstrumentButton);
            Controls.Add(Price);
            Controls.Add(InstrumentCategory);
            Controls.Add(InstrumentName);
            Controls.Add(SelectImageButton);
            Name = "InstrumentAddForm";
            Text = "Добавление инструмента";
            ((System.ComponentModel.ISupportInitialize)Price).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SelectImageButton;
        private TextBox InstrumentName;
        private ComboBox InstrumentCategory;
        private NumericUpDown Price;
        private Button AddInstrumentButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label FileLabel;
    }
}