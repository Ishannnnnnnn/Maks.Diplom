namespace MusicStoreFront.Forms
{
    partial class InstrumentForm
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
            UpdateButton = new Button();
            ImageBox = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            DeleteInstrumentButton = new Button();
            InstrumentName = new TextBox();
            InstrumentCategory = new ComboBox();
            Price = new NumericUpDown();
            Amount = new NumericUpDown();
            ReturnButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ImageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Price).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Amount).BeginInit();
            SuspendLayout();
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(12, 154);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(776, 29);
            UpdateButton.TabIndex = 1;
            UpdateButton.Text = "Обновить";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // ImageBox
            // 
            ImageBox.Location = new Point(578, 12);
            ImageBox.Name = "ImageBox";
            ImageBox.Size = new Size(210, 106);
            ImageBox.TabIndex = 2;
            ImageBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(109, 28);
            label1.TabIndex = 3;
            label1.Text = "Название: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 4;
            label2.Text = "Категория: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 88);
            label3.Name = "label3";
            label3.Size = new Size(129, 28);
            label3.TabIndex = 5;
            label3.Text = "Цена за 1 ед:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 116);
            label4.Name = "label4";
            label4.Size = new Size(352, 28);
            label4.TabIndex = 6;
            label4.Text = "Кол-во на складе данного магазина: ";
            // 
            // DeleteInstrumentButton
            // 
            DeleteInstrumentButton.Location = new Point(12, 189);
            DeleteInstrumentButton.Name = "DeleteInstrumentButton";
            DeleteInstrumentButton.Size = new Size(776, 29);
            DeleteInstrumentButton.TabIndex = 7;
            DeleteInstrumentButton.Text = "Удалить товар со склада";
            DeleteInstrumentButton.UseVisualStyleBackColor = true;
            DeleteInstrumentButton.Click += DeleteInstrumentButton_Click;
            // 
            // InstrumentName
            // 
            InstrumentName.Location = new Point(115, 13);
            InstrumentName.Name = "InstrumentName";
            InstrumentName.Size = new Size(162, 27);
            InstrumentName.TabIndex = 8;
            // 
            // InstrumentCategory
            // 
            InstrumentCategory.FormattingEnabled = true;
            InstrumentCategory.Items.AddRange(new object[] { "Guitar", "GuitarPick", "Amps", "Case", "Wind", "Drums" });
            InstrumentCategory.Location = new Point(126, 46);
            InstrumentCategory.Name = "InstrumentCategory";
            InstrumentCategory.Size = new Size(151, 28);
            InstrumentCategory.TabIndex = 9;
            // 
            // Price
            // 
            Price.Location = new Point(147, 93);
            Price.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            Price.Name = "Price";
            Price.Size = new Size(93, 27);
            Price.TabIndex = 10;
            // 
            // Amount
            // 
            Amount.Location = new Point(360, 121);
            Amount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            Amount.Name = "Amount";
            Amount.Size = new Size(75, 27);
            Amount.TabIndex = 11;
            // 
            // ReturnButton
            // 
            ReturnButton.Location = new Point(694, 124);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(94, 29);
            ReturnButton.TabIndex = 12;
            ReturnButton.Text = "Назад";
            ReturnButton.UseVisualStyleBackColor = true;
            ReturnButton.Click += ReturnButton_Click;
            // 
            // InstrumentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 228);
            Controls.Add(ReturnButton);
            Controls.Add(Amount);
            Controls.Add(Price);
            Controls.Add(InstrumentCategory);
            Controls.Add(InstrumentName);
            Controls.Add(DeleteInstrumentButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ImageBox);
            Controls.Add(UpdateButton);
            Name = "InstrumentForm";
            Text = "InstrumentForm";
            ((System.ComponentModel.ISupportInitialize)ImageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)Price).EndInit();
            ((System.ComponentModel.ISupportInitialize)Amount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button UpdateButton;
        private PictureBox ImageBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button DeleteInstrumentButton;
        private TextBox InstrumentName;
        private ComboBox InstrumentCategory;
        private NumericUpDown Price;
        private NumericUpDown Amount;
        private Button ReturnButton;
    }
}