namespace MusicStoreFront.Forms
{
    partial class MyPurchasesForm
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
            OrdersTable = new DataGridView();
            menuStrip1 = new MenuStrip();
            главнаяСтраницыToolStripMenuItem = new ToolStripMenuItem();
            магазиныToolStripMenuItem = new ToolStripMenuItem();
            профильToolStripMenuItem = new ToolStripMenuItem();
            редактироватьПрофильToolStripMenuItem = new ToolStripMenuItem();
            выйтиИзАккаунтаToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)OrdersTable).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // OrdersTable
            // 
            OrdersTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrdersTable.Location = new Point(12, 41);
            OrdersTable.Name = "OrdersTable";
            OrdersTable.RowHeadersWidth = 51;
            OrdersTable.Size = new Size(942, 424);
            OrdersTable.TabIndex = 1;
            OrdersTable.CellContentClick += OrdersTable_CellContentClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { главнаяСтраницыToolStripMenuItem, магазиныToolStripMenuItem, профильToolStripMenuItem, выйтиИзАккаунтаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(966, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // главнаяСтраницыToolStripMenuItem
            // 
            главнаяСтраницыToolStripMenuItem.Name = "главнаяСтраницыToolStripMenuItem";
            главнаяСтраницыToolStripMenuItem.Size = new Size(151, 24);
            главнаяСтраницыToolStripMenuItem.Text = "Главная страницы";
            главнаяСтраницыToolStripMenuItem.Click += главнаяСтраницыToolStripMenuItem_Click;
            // 
            // магазиныToolStripMenuItem
            // 
            магазиныToolStripMenuItem.Name = "магазиныToolStripMenuItem";
            магазиныToolStripMenuItem.Size = new Size(94, 24);
            магазиныToolStripMenuItem.Text = "Магазины";
            магазиныToolStripMenuItem.Click += магазиныToolStripMenuItem_Click;
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
            редактироватьПрофильToolStripMenuItem.Click += редактироватьПрофильToolStripMenuItem_Click_1;
            // 
            // выйтиИзАккаунтаToolStripMenuItem
            // 
            выйтиИзАккаунтаToolStripMenuItem.Name = "выйтиИзАккаунтаToolStripMenuItem";
            выйтиИзАккаунтаToolStripMenuItem.Size = new Size(151, 24);
            выйтиИзАккаунтаToolStripMenuItem.Text = "Выйти из аккаунта";
            выйтиИзАккаунтаToolStripMenuItem.Click += выйтиИзАккаунтаToolStripMenuItem_Click;
            // 
            // MyPurchasesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 477);
            Controls.Add(OrdersTable);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MyPurchasesForm";
            Text = "Ваши заказы";
            ((System.ComponentModel.ISupportInitialize)OrdersTable).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView OrdersTable;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem главнаяСтраницыToolStripMenuItem;
        private ToolStripMenuItem магазиныToolStripMenuItem;
        private ToolStripMenuItem профильToolStripMenuItem;
        private ToolStripMenuItem редактироватьПрофильToolStripMenuItem;
        private ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
    }
}