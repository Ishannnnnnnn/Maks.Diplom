namespace MusicStoreFront.Forms
{
    partial class ProfileForm
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
            NameLabel = new Label();
            label2 = new Label();
            EmailLabel = new Label();
            ToProfileUpdateButton = new Button();
            NicknameLabel = new Label();
            label4 = new Label();
            label3 = new Label();
            RegistrationDateLabel = new Label();
            AvatarPictureBox = new PictureBox();
            DeleteUserButton = new Button();
            menuStrip1 = new MenuStrip();
            главнаяСтраницаToolStripMenuItem = new ToolStripMenuItem();
            магазиныToolStripMenuItem = new ToolStripMenuItem();
            вашиЗаказыToolStripMenuItem = new ToolStripMenuItem();
            выйтиИзАккаунтаToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)AvatarPictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(17, 44);
            label1.Name = "label1";
            label1.Size = new Size(70, 35);
            label1.TabIndex = 1;
            label1.Text = "Имя:";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 12F);
            NameLabel.Location = new Point(84, 49);
            NameLabel.Name = "NameLabel";
            NameLabel.RightToLeft = RightToLeft.No;
            NameLabel.Size = new Size(198, 28);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "*Имя пользователя*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(20, 102);
            label2.Name = "label2";
            label2.Size = new Size(90, 35);
            label2.TabIndex = 3;
            label2.Text = "Почта:";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Segoe UI", 12F);
            EmailLabel.Location = new Point(106, 107);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(214, 28);
            EmailLabel.TabIndex = 4;
            EmailLabel.Text = "*Почта пользователя*";
            // 
            // ToProfileUpdateButton
            // 
            ToProfileUpdateButton.Location = new Point(19, 183);
            ToProfileUpdateButton.Name = "ToProfileUpdateButton";
            ToProfileUpdateButton.Size = new Size(608, 62);
            ToProfileUpdateButton.TabIndex = 7;
            ToProfileUpdateButton.Text = "Изменить данные";
            ToProfileUpdateButton.UseVisualStyleBackColor = true;
            ToProfileUpdateButton.Click += ToProfileUpdateButton_Click;
            // 
            // NicknameLabel
            // 
            NicknameLabel.AutoSize = true;
            NicknameLabel.Font = new Font("Segoe UI", 12F);
            NicknameLabel.Location = new Point(139, 77);
            NicknameLabel.Name = "NicknameLabel";
            NicknameLabel.RightToLeft = RightToLeft.No;
            NicknameLabel.Size = new Size(243, 28);
            NicknameLabel.TabIndex = 9;
            NicknameLabel.Text = "*Никнейм пользователя*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(17, 72);
            label4.Name = "label4";
            label4.Size = new Size(125, 35);
            label4.TabIndex = 8;
            label4.Text = "Никнейм:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(20, 135);
            label3.Name = "label3";
            label3.Size = new Size(228, 35);
            label3.TabIndex = 10;
            label3.Text = "Дата регистрации:";
            // 
            // RegistrationDateLabel
            // 
            RegistrationDateLabel.AutoSize = true;
            RegistrationDateLabel.Font = new Font("Segoe UI", 12F);
            RegistrationDateLabel.Location = new Point(240, 142);
            RegistrationDateLabel.Name = "RegistrationDateLabel";
            RegistrationDateLabel.Size = new Size(323, 28);
            RegistrationDateLabel.TabIndex = 11;
            RegistrationDateLabel.Text = "*Дата регистрации пользователя*";
            // 
            // AvatarPictureBox
            // 
            AvatarPictureBox.Location = new Point(425, 38);
            AvatarPictureBox.Name = "AvatarPictureBox";
            AvatarPictureBox.Size = new Size(202, 101);
            AvatarPictureBox.TabIndex = 12;
            AvatarPictureBox.TabStop = false;
            // 
            // DeleteUserButton
            // 
            DeleteUserButton.BackColor = Color.LightCoral;
            DeleteUserButton.Location = new Point(19, 251);
            DeleteUserButton.Name = "DeleteUserButton";
            DeleteUserButton.Size = new Size(608, 29);
            DeleteUserButton.TabIndex = 13;
            DeleteUserButton.Text = "Удалить профиль";
            DeleteUserButton.UseVisualStyleBackColor = false;
            DeleteUserButton.Click += DeleteUserButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { главнаяСтраницаToolStripMenuItem, магазиныToolStripMenuItem, вашиЗаказыToolStripMenuItem, выйтиИзАккаунтаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(641, 28);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // главнаяСтраницаToolStripMenuItem
            // 
            главнаяСтраницаToolStripMenuItem.Name = "главнаяСтраницаToolStripMenuItem";
            главнаяСтраницаToolStripMenuItem.Size = new Size(148, 24);
            главнаяСтраницаToolStripMenuItem.Text = "Главная страница";
            главнаяСтраницаToolStripMenuItem.Click += главнаяСтраницаToolStripMenuItem_Click;
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
            // выйтиИзАккаунтаToolStripMenuItem
            // 
            выйтиИзАккаунтаToolStripMenuItem.Name = "выйтиИзАккаунтаToolStripMenuItem";
            выйтиИзАккаунтаToolStripMenuItem.Size = new Size(151, 24);
            выйтиИзАккаунтаToolStripMenuItem.Text = "Выйти из аккаунта";
            выйтиИзАккаунтаToolStripMenuItem.Click += выйтиИзАккаунтаToolStripMenuItem_Click;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 292);
            Controls.Add(DeleteUserButton);
            Controls.Add(AvatarPictureBox);
            Controls.Add(RegistrationDateLabel);
            Controls.Add(label3);
            Controls.Add(NicknameLabel);
            Controls.Add(label4);
            Controls.Add(ToProfileUpdateButton);
            Controls.Add(EmailLabel);
            Controls.Add(label2);
            Controls.Add(NameLabel);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ProfileForm";
            Text = "Профиль";
            ((System.ComponentModel.ISupportInitialize)AvatarPictureBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label NameLabel;
        private Label label2;
        private Label EmailLabel;
        private Button ToProfileUpdateButton;
        private Label NicknameLabel;
        private Label label4;
        private Label label3;
        private Label RegistrationDateLabel;
        private PictureBox AvatarPictureBox;
        private Button DeleteUserButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem главнаяСтраницаToolStripMenuItem;
        private ToolStripMenuItem магазиныToolStripMenuItem;
        private ToolStripMenuItem вашиЗаказыToolStripMenuItem;
        private ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
    }
}