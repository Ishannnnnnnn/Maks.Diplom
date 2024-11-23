namespace MusicStoreFront.Forms
{
    partial class StoreForm
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
            InstrumentStoreTable = new DataGridView();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            магазиныToolStripMenuItem = new ToolStripMenuItem();
            вашиЗаказыToolStripMenuItem = new ToolStripMenuItem();
            профильToolStripMenuItem = new ToolStripMenuItem();
            редактироватьПрофильToolStripMenuItem = new ToolStripMenuItem();
            выйтиИзАккаунтаToolStripMenuItem = new ToolStripMenuItem();
            балансПолзователяToolStripMenuItem = new ToolStripMenuItem();
            BuyButton = new Button();
            Amount = new NumericUpDown();
            label2 = new Label();
            Search = new TextBox();
            MinPrice = new NumericUpDown();
            MaxPrice = new NumericUpDown();
            Цена = new Label();
            label3 = new Label();
            AddInstrumentButton = new Button();
            DeleteInstrumentButton = new Button();
            AmountToAdd = new NumericUpDown();
            InstrumentToAdd = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)InstrumentStoreTable).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Amount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AmountToAdd).BeginInit();
            SuspendLayout();
            // 
            // InstrumentStoreTable
            // 
            InstrumentStoreTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InstrumentStoreTable.Location = new Point(10, 139);
            InstrumentStoreTable.Name = "InstrumentStoreTable";
            InstrumentStoreTable.RowHeadersWidth = 51;
            InstrumentStoreTable.Size = new Size(735, 213);
            InstrumentStoreTable.TabIndex = 0;
            InstrumentStoreTable.CellContentClick += InstrumentStoreTable_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(328, 35);
            label1.Name = "label1";
            label1.Size = new Size(102, 35);
            label1.TabIndex = 1;
            label1.Text = "Товары";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { магазиныToolStripMenuItem, вашиЗаказыToolStripMenuItem, профильToolStripMenuItem, выйтиИзАккаунтаToolStripMenuItem, балансПолзователяToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(757, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // магазиныToolStripMenuItem
            // 
            магазиныToolStripMenuItem.Name = "магазиныToolStripMenuItem";
            магазиныToolStripMenuItem.Size = new Size(94, 24);
            магазиныToolStripMenuItem.Text = "Магазины";
            магазиныToolStripMenuItem.Click += магазиныToolStripMenuItem_Click;
            // 
            // вашиЗаказыToolStripMenuItem
            // 
            вашиЗаказыToolStripMenuItem.Name = "вашиЗаказыToolStripMenuItem";
            вашиЗаказыToolStripMenuItem.Size = new Size(113, 24);
            вашиЗаказыToolStripMenuItem.Text = "Ваши заказы";
            вашиЗаказыToolStripMenuItem.Click += вашиЗаказыToolStripMenuItem_Click;
            // 
            // профильToolStripMenuItem
            // 
            профильToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { редактироватьПрофильToolStripMenuItem });
            профильToolStripMenuItem.Name = "профильToolStripMenuItem";
            профильToolStripMenuItem.Size = new Size(87, 24);
            профильToolStripMenuItem.Text = "Профиль";
            профильToolStripMenuItem.Click += профильToolStripMenuItem_Click;
            // 
            // редактироватьПрофильToolStripMenuItem
            // 
            редактироватьПрофильToolStripMenuItem.Name = "редактироватьПрофильToolStripMenuItem";
            редактироватьПрофильToolStripMenuItem.Size = new Size(260, 26);
            редактироватьПрофильToolStripMenuItem.Text = "Редактировать профиль";
            редактироватьПрофильToolStripMenuItem.Click += редактироватьПрофильToolStripMenuItem_Click;
            // 
            // выйтиИзАккаунтаToolStripMenuItem
            // 
            выйтиИзАккаунтаToolStripMenuItem.Name = "выйтиИзАккаунтаToolStripMenuItem";
            выйтиИзАккаунтаToolStripMenuItem.Size = new Size(151, 24);
            выйтиИзАккаунтаToolStripMenuItem.Text = "Выйти из аккаунта";
            выйтиИзАккаунтаToolStripMenuItem.Click += выйтиИзАккаунтаToolStripMenuItem_Click;
            // 
            // балансПолзователяToolStripMenuItem
            // 
            балансПолзователяToolStripMenuItem.Name = "балансПолзователяToolStripMenuItem";
            балансПолзователяToolStripMenuItem.Size = new Size(176, 24);
            балансПолзователяToolStripMenuItem.Text = "*Баланс ползователя*";
            // 
            // BuyButton
            // 
            BuyButton.Location = new Point(12, 391);
            BuyButton.Name = "BuyButton";
            BuyButton.Size = new Size(735, 55);
            BuyButton.TabIndex = 3;
            BuyButton.Text = "Купить";
            BuyButton.UseVisualStyleBackColor = true;
            BuyButton.Click += BuyButton_Click;
            // 
            // Amount
            // 
            Amount.Location = new Point(673, 358);
            Amount.Name = "Amount";
            Amount.Size = new Size(72, 27);
            Amount.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(606, 365);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 5;
            label2.Text = "Кол-во:";
            // 
            // Search
            // 
            Search.Location = new Point(12, 73);
            Search.Name = "Search";
            Search.Size = new Size(733, 27);
            Search.TabIndex = 6;
            // 
            // MinPrice
            // 
            MinPrice.Location = new Point(548, 106);
            MinPrice.Name = "MinPrice";
            MinPrice.Size = new Size(82, 27);
            MinPrice.TabIndex = 7;
            // 
            // MaxPrice
            // 
            MaxPrice.Location = new Point(663, 106);
            MaxPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            MaxPrice.Name = "MaxPrice";
            MaxPrice.Size = new Size(82, 27);
            MaxPrice.TabIndex = 8;
            // 
            // Цена
            // 
            Цена.AutoSize = true;
            Цена.Location = new Point(475, 113);
            Цена.Name = "Цена";
            Цена.Size = new Size(67, 20);
            Цена.TabIndex = 9;
            Цена.Text = "Цена: от";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(636, 113);
            label3.Name = "label3";
            label3.Size = new Size(26, 20);
            label3.TabIndex = 10;
            label3.Text = "до";
            // 
            // AddInstrumentButton
            // 
            AddInstrumentButton.Location = new Point(12, 495);
            AddInstrumentButton.Name = "AddInstrumentButton";
            AddInstrumentButton.Size = new Size(733, 29);
            AddInstrumentButton.TabIndex = 11;
            AddInstrumentButton.Text = "Добавить товар";
            AddInstrumentButton.UseVisualStyleBackColor = true;
            AddInstrumentButton.Click += AddInstrumentButton_Click;
            // 
            // DeleteInstrumentButton
            // 
            DeleteInstrumentButton.BackColor = Color.FromArgb(255, 128, 128);
            DeleteInstrumentButton.Location = new Point(591, 38);
            DeleteInstrumentButton.Name = "DeleteInstrumentButton";
            DeleteInstrumentButton.Size = new Size(154, 29);
            DeleteInstrumentButton.TabIndex = 12;
            DeleteInstrumentButton.Text = "Удалить товар";
            DeleteInstrumentButton.UseVisualStyleBackColor = false;
            DeleteInstrumentButton.Click += DeleteInstrumentButton_Click;
            // 
            // AmountToAdd
            // 
            AmountToAdd.Location = new Point(395, 460);
            AmountToAdd.Name = "AmountToAdd";
            AmountToAdd.Size = new Size(74, 27);
            AmountToAdd.TabIndex = 13;
            // 
            // InstrumentToAdd
            // 
            InstrumentToAdd.FormattingEnabled = true;
            InstrumentToAdd.Location = new Point(146, 460);
            InstrumentToAdd.Name = "InstrumentToAdd";
            InstrumentToAdd.Size = new Size(151, 28);
            InstrumentToAdd.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 463);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 15;
            label4.Text = "Товар со склада:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(328, 463);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 16;
            label5.Text = "Кол-во:";
            // 
            // StoreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 536);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(InstrumentToAdd);
            Controls.Add(AmountToAdd);
            Controls.Add(DeleteInstrumentButton);
            Controls.Add(AddInstrumentButton);
            Controls.Add(label3);
            Controls.Add(Цена);
            Controls.Add(MaxPrice);
            Controls.Add(MinPrice);
            Controls.Add(Search);
            Controls.Add(label2);
            Controls.Add(Amount);
            Controls.Add(BuyButton);
            Controls.Add(label1);
            Controls.Add(InstrumentStoreTable);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "StoreForm";
            Text = "StoreForm";
            ((System.ComponentModel.ISupportInitialize)InstrumentStoreTable).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Amount).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)AmountToAdd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView InstrumentStoreTable;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem магазиныToolStripMenuItem;
        private ToolStripMenuItem вашиЗаказыToolStripMenuItem;
        private ToolStripMenuItem профильToolStripMenuItem;
        private ToolStripMenuItem редактироватьПрофильToolStripMenuItem;
        private ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
        private ToolStripMenuItem балансПолзователяToolStripMenuItem;
        private Button BuyButton;
        private NumericUpDown Amount;
        private Label label2;
        private TextBox Search;
        private NumericUpDown MinPrice;
        private NumericUpDown MaxPrice;
        private Label Цена;
        private Label label3;
        private Button AddInstrumentButton;
        private Button DeleteInstrumentButton;
        private NumericUpDown AmountToAdd;
        private ComboBox InstrumentToAdd;
        private Label label4;
        private Label label5;
    }
}