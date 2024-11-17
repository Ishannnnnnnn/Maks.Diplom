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
            ((System.ComponentModel.ISupportInitialize)InstrumentStoreTable).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Amount).BeginInit();
            SuspendLayout();
            // 
            // InstrumentStoreTable
            // 
            InstrumentStoreTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InstrumentStoreTable.Location = new Point(12, 73);
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
            BuyButton.Location = new Point(10, 325);
            BuyButton.Name = "BuyButton";
            BuyButton.Size = new Size(735, 55);
            BuyButton.TabIndex = 3;
            BuyButton.Text = "Купить";
            BuyButton.UseVisualStyleBackColor = true;
            BuyButton.Click += BuyButton_Click;
            // 
            // Amount
            // 
            Amount.Location = new Point(673, 292);
            Amount.Name = "Amount";
            Amount.Size = new Size(72, 27);
            Amount.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(606, 299);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 5;
            label2.Text = "Кол-во:";
            // 
            // StoreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 389);
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
    }
}