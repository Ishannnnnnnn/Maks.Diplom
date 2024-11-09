namespace MusicStoreFront.Forms
{
    partial class OrderDetailsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            OrderDate = new Label();
            Amount = new Label();
            SumPrice = new Label();
            InstrumentImage = new PictureBox();
            InstrumentName = new Label();
            StoreAddress = new Label();
            ((System.ComponentModel.ISupportInitialize)InstrumentImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 35);
            label1.TabIndex = 3;
            label1.Text = "Товар: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(160, 35);
            label2.TabIndex = 4;
            label2.Text = "Дата заказа: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(12, 79);
            label3.Name = "label3";
            label3.Size = new Size(108, 35);
            label3.TabIndex = 5;
            label3.Text = "Кол-во: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(12, 114);
            label4.Name = "label4";
            label4.Size = new Size(169, 35);
            label4.TabIndex = 6;
            label4.Text = "Общая цена: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(12, 149);
            label5.Name = "label5";
            label5.Size = new Size(211, 35);
            label5.TabIndex = 7;
            label5.Text = "Адрес магазина: ";
            // 
            // OrderDate
            // 
            OrderDate.AutoSize = true;
            OrderDate.Font = new Font("Segoe UI", 12F);
            OrderDate.Location = new Point(158, 51);
            OrderDate.Name = "OrderDate";
            OrderDate.Size = new Size(133, 28);
            OrderDate.TabIndex = 9;
            OrderDate.Text = "*Дата заказа*";
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.Font = new Font("Segoe UI", 12F);
            Amount.Location = new Point(109, 86);
            Amount.Name = "Amount";
            Amount.Size = new Size(162, 28);
            Amount.TabIndex = 10;
            Amount.Text = "*Кол-во товара*";
            // 
            // SumPrice
            // 
            SumPrice.AutoSize = true;
            SumPrice.Font = new Font("Segoe UI", 12F);
            SumPrice.Location = new Point(169, 119);
            SumPrice.Name = "SumPrice";
            SumPrice.Size = new Size(140, 28);
            SumPrice.TabIndex = 11;
            SumPrice.Text = "*Общая цена*";
            // 
            // InstrumentImage
            // 
            InstrumentImage.Location = new Point(412, 16);
            InstrumentImage.Name = "InstrumentImage";
            InstrumentImage.Size = new Size(206, 114);
            InstrumentImage.TabIndex = 13;
            InstrumentImage.TabStop = false;
            // 
            // InstrumentName
            // 
            InstrumentName.AutoSize = true;
            InstrumentName.Font = new Font("Segoe UI", 12F);
            InstrumentName.Location = new Point(96, 16);
            InstrumentName.Name = "InstrumentName";
            InstrumentName.Size = new Size(226, 28);
            InstrumentName.TabIndex = 14;
            InstrumentName.Text = "*Название иструмента*";
            // 
            // StoreAddress
            // 
            StoreAddress.AutoSize = true;
            StoreAddress.Font = new Font("Segoe UI", 12F);
            StoreAddress.Location = new Point(209, 154);
            StoreAddress.Name = "StoreAddress";
            StoreAddress.Size = new Size(173, 28);
            StoreAddress.TabIndex = 15;
            StoreAddress.Text = "*Адрес магазина*";
            // 
            // OrderDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 197);
            Controls.Add(StoreAddress);
            Controls.Add(InstrumentName);
            Controls.Add(InstrumentImage);
            Controls.Add(SumPrice);
            Controls.Add(Amount);
            Controls.Add(OrderDate);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OrderDetailsForm";
            Text = "Детали заказа";
            ((System.ComponentModel.ISupportInitialize)InstrumentImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label OrderDate;
        private Label Amount;
        private Label SumPrice;
        private PictureBox InstrumentImage;
        private Label InstrumentName;
        private Label StoreAddress;
    }
}