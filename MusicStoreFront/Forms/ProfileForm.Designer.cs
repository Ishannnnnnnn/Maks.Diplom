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
            ReturnButton = new Button();
            ToProfileUpdateButton = new Button();
            NicknameLabel = new Label();
            label4 = new Label();
            label3 = new Label();
            RegistrationDateLabel = new Label();
            AvatarPictureBox = new PictureBox();
            DeleteUserButton = new Button();
            ((System.ComponentModel.ISupportInitialize)AvatarPictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(21, 23);
            label1.Name = "label1";
            label1.Size = new Size(70, 35);
            label1.TabIndex = 1;
            label1.Text = "Имя:";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 12F);
            NameLabel.Location = new Point(88, 28);
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
            label2.Location = new Point(19, 81);
            label2.Name = "label2";
            label2.Size = new Size(90, 35);
            label2.TabIndex = 3;
            label2.Text = "Почта:";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Segoe UI", 12F);
            EmailLabel.Location = new Point(105, 86);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(214, 28);
            EmailLabel.TabIndex = 4;
            EmailLabel.Text = "*Почта пользователя*";
            // 
            // ReturnButton
            // 
            ReturnButton.Location = new Point(21, 220);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(608, 49);
            ReturnButton.TabIndex = 6;
            ReturnButton.Text = "Назад";
            ReturnButton.UseVisualStyleBackColor = true;
            ReturnButton.Click += ReturnButton_Click;
            // 
            // ToProfileUpdateButton
            // 
            ToProfileUpdateButton.Location = new Point(21, 152);
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
            NicknameLabel.Location = new Point(141, 56);
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
            label4.Location = new Point(19, 51);
            label4.Name = "label4";
            label4.Size = new Size(125, 35);
            label4.TabIndex = 8;
            label4.Text = "Никнейм:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(21, 114);
            label3.Name = "label3";
            label3.Size = new Size(228, 35);
            label3.TabIndex = 10;
            label3.Text = "Дата регистрации:";
            // 
            // RegistrationDateLabel
            // 
            RegistrationDateLabel.AutoSize = true;
            RegistrationDateLabel.Font = new Font("Segoe UI", 12F);
            RegistrationDateLabel.Location = new Point(241, 121);
            RegistrationDateLabel.Name = "RegistrationDateLabel";
            RegistrationDateLabel.Size = new Size(323, 28);
            RegistrationDateLabel.TabIndex = 11;
            RegistrationDateLabel.Text = "*Дата регистрации пользователя*";
            // 
            // AvatarPictureBox
            // 
            AvatarPictureBox.Location = new Point(427, 12);
            AvatarPictureBox.Name = "AvatarPictureBox";
            AvatarPictureBox.Size = new Size(202, 106);
            AvatarPictureBox.TabIndex = 12;
            AvatarPictureBox.TabStop = false;
            // 
            // DeleteUserButton
            // 
            DeleteUserButton.BackColor = Color.LightCoral;
            DeleteUserButton.Location = new Point(21, 275);
            DeleteUserButton.Name = "DeleteUserButton";
            DeleteUserButton.Size = new Size(608, 29);
            DeleteUserButton.TabIndex = 13;
            DeleteUserButton.Text = "Удалить профиль";
            DeleteUserButton.UseVisualStyleBackColor = false;
            DeleteUserButton.Click += DeleteUserButton_Click;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 316);
            Controls.Add(DeleteUserButton);
            Controls.Add(AvatarPictureBox);
            Controls.Add(RegistrationDateLabel);
            Controls.Add(label3);
            Controls.Add(NicknameLabel);
            Controls.Add(label4);
            Controls.Add(ToProfileUpdateButton);
            Controls.Add(ReturnButton);
            Controls.Add(EmailLabel);
            Controls.Add(label2);
            Controls.Add(NameLabel);
            Controls.Add(label1);
            Name = "ProfileForm";
            Text = "Профиль";
            ((System.ComponentModel.ISupportInitialize)AvatarPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label NameLabel;
        private Label label2;
        private Label EmailLabel;
        private Button ReturnButton;
        private Button ToProfileUpdateButton;
        private Label NicknameLabel;
        private Label label4;
        private Label label3;
        private Label RegistrationDateLabel;
        private PictureBox AvatarPictureBox;
        private Button DeleteUserButton;
    }
}