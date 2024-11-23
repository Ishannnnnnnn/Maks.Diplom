namespace MusicStoreFront.Forms
{
    partial class StoreAddForm
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
            AddStoreButton = new Button();
            City = new TextBox();
            Street = new TextBox();
            HouseNumber = new TextBox();
            Phone = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // AddStoreButton
            // 
            AddStoreButton.Location = new Point(12, 272);
            AddStoreButton.Name = "AddStoreButton";
            AddStoreButton.Size = new Size(258, 41);
            AddStoreButton.TabIndex = 0;
            AddStoreButton.Text = "Добавить магазин";
            AddStoreButton.UseVisualStyleBackColor = true;
            AddStoreButton.Click += AddStoreButton_Click;
            // 
            // City
            // 
            City.Location = new Point(12, 36);
            City.Name = "City";
            City.Size = new Size(258, 27);
            City.TabIndex = 1;
            // 
            // Street
            // 
            Street.Location = new Point(12, 103);
            Street.Name = "Street";
            Street.Size = new Size(258, 27);
            Street.TabIndex = 2;
            // 
            // HouseNumber
            // 
            HouseNumber.Location = new Point(12, 164);
            HouseNumber.Name = "HouseNumber";
            HouseNumber.Size = new Size(258, 27);
            HouseNumber.TabIndex = 3;
            // 
            // Phone
            // 
            Phone.Location = new Point(12, 223);
            Phone.Name = "Phone";
            Phone.Size = new Size(258, 27);
            Phone.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 5;
            label1.Text = "Город";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 6;
            label2.Text = "Улица";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 141);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 7;
            label3.Text = "Номер дома";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 200);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 8;
            label4.Text = "Телефон";
            // 
            // StoreAddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 325);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Phone);
            Controls.Add(HouseNumber);
            Controls.Add(Street);
            Controls.Add(City);
            Controls.Add(AddStoreButton);
            Name = "StoreAddForm";
            Text = "StoreAddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddStoreButton;
        private TextBox City;
        private TextBox Street;
        private TextBox HouseNumber;
        private TextBox Phone;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}