namespace MusicStoreFront.Forms
{
    partial class StoreListForm
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
            menuStrip1 = new MenuStrip();
            главнаяСтраницаToolStripMenuItem = new ToolStripMenuItem();
            вашиЗаказыToolStripMenuItem = new ToolStripMenuItem();
            профильToolStripMenuItem = new ToolStripMenuItem();
            редактироватьПрофильToolStripMenuItem = new ToolStripMenuItem();
            выйтиИзАккаунтаToolStripMenuItem = new ToolStripMenuItem();
            StoresTable = new DataGridView();
            AddStoreAdminButton = new Button();
            DeleteStoreAdminButton = new Button();
            CreateInstrumentButton = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StoresTable).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { главнаяСтраницаToolStripMenuItem, вашиЗаказыToolStripMenuItem, профильToolStripMenuItem, выйтиИзАккаунтаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // главнаяСтраницаToolStripMenuItem
            // 
            главнаяСтраницаToolStripMenuItem.Name = "главнаяСтраницаToolStripMenuItem";
            главнаяСтраницаToolStripMenuItem.Size = new Size(148, 24);
            главнаяСтраницаToolStripMenuItem.Text = "Главная страница";
            главнаяСтраницаToolStripMenuItem.Click += главнаяСтраницаToolStripMenuItem_Click;
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
            // StoresTable
            // 
            StoresTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StoresTable.Location = new Point(13, 45);
            StoresTable.Name = "StoresTable";
            StoresTable.RowHeadersWidth = 51;
            StoresTable.Size = new Size(776, 394);
            StoresTable.TabIndex = 1;
            StoresTable.CellContentClick += StoresTable_CellContentClick;
            // 
            // AddStoreAdminButton
            // 
            AddStoreAdminButton.Location = new Point(13, 445);
            AddStoreAdminButton.Name = "AddStoreAdminButton";
            AddStoreAdminButton.Size = new Size(775, 29);
            AddStoreAdminButton.TabIndex = 2;
            AddStoreAdminButton.Text = "Создать новый магазин";
            AddStoreAdminButton.UseVisualStyleBackColor = true;
            AddStoreAdminButton.Click += AddStoreAdminButton_Click;
            // 
            // DeleteStoreAdminButton
            // 
            DeleteStoreAdminButton.BackColor = Color.FromArgb(255, 128, 128);
            DeleteStoreAdminButton.Location = new Point(14, 519);
            DeleteStoreAdminButton.Name = "DeleteStoreAdminButton";
            DeleteStoreAdminButton.Size = new Size(775, 29);
            DeleteStoreAdminButton.TabIndex = 3;
            DeleteStoreAdminButton.Text = "Удалить магазин";
            DeleteStoreAdminButton.UseVisualStyleBackColor = false;
            DeleteStoreAdminButton.Click += DeleteStoreAdminButton_Click;
            // 
            // CreateInstrumentButton
            // 
            CreateInstrumentButton.Location = new Point(14, 484);
            CreateInstrumentButton.Name = "CreateInstrumentButton";
            CreateInstrumentButton.Size = new Size(775, 29);
            CreateInstrumentButton.TabIndex = 4;
            CreateInstrumentButton.Text = "Завести новый инструмент на склад\r\n";
            CreateInstrumentButton.UseVisualStyleBackColor = true;
            CreateInstrumentButton.Click += CreateInstrumentButton_Click;
            // 
            // StoreListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 560);
            Controls.Add(CreateInstrumentButton);
            Controls.Add(DeleteStoreAdminButton);
            Controls.Add(AddStoreAdminButton);
            Controls.Add(StoresTable);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "StoreListForm";
            Text = "Магазины";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)StoresTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem главнаяСтраницаToolStripMenuItem;
        private ToolStripMenuItem вашиЗаказыToolStripMenuItem;
        private ToolStripMenuItem профильToolStripMenuItem;
        private ToolStripMenuItem редактироватьПрофильToolStripMenuItem;
        private ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
        private DataGridView StoresTable;
        private Button AddStoreAdminButton;
        private Button DeleteStoreAdminButton;
        private Button CreateInstrumentButton;
    }
}