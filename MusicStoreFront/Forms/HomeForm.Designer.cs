namespace MusicStoreFront.Forms
{
    partial class HomeForm
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
            UsernameLabel = new Label();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            магазиныToolStripMenuItem = new ToolStripMenuItem();
            вашиЗаказыToolStripMenuItem = new ToolStripMenuItem();
            профильToolStripMenuItem = new ToolStripMenuItem();
            редактироватьПрофильToolStripMenuItem = new ToolStripMenuItem();
            выйтиИзАккаунтаToolStripMenuItem = new ToolStripMenuItem();
            UserTopTable = new DataGridView();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UserTopTable).BeginInit();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI", 15F);
            UsernameLabel.Location = new Point(258, 47);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(299, 35);
            UsernameLabel.TabIndex = 22;
            UsernameLabel.Text = "*Текущий пользователь*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(23, 47);
            label1.Name = "label1";
            label1.Size = new Size(248, 35);
            label1.TabIndex = 21;
            label1.Text = "Добро пожаловать, ";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { магазиныToolStripMenuItem, вашиЗаказыToolStripMenuItem, профильToolStripMenuItem, выйтиИзАккаунтаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(589, 28);
            menuStrip1.TabIndex = 24;
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
            // UserTopTable
            // 
            UserTopTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserTopTable.Location = new Point(23, 134);
            UserTopTable.Name = "UserTopTable";
            UserTopTable.RowHeadersWidth = 51;
            UserTopTable.Size = new Size(552, 175);
            UserTopTable.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(205, 103);
            label2.Name = "label2";
            label2.Size = new Size(189, 28);
            label2.TabIndex = 26;
            label2.Text = "Топ пользователей";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 325);
            Controls.Add(label2);
            Controls.Add(UserTopTable);
            Controls.Add(UsernameLabel);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Name = "HomeForm";
            Text = "Домашняя страница";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UserTopTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label UsernameLabel;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem магазиныToolStripMenuItem;
        private ToolStripMenuItem вашиЗаказыToolStripMenuItem;
        private ToolStripMenuItem профильToolStripMenuItem;
        private ToolStripMenuItem редактироватьПрофильToolStripMenuItem;
        private ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
        private DataGridView UserTopTable;
        private Label label2;
    }
}