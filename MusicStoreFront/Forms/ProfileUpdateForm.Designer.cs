namespace MusicStoreFront.Forms
{
    partial class ProfileUpdateForm
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
            ApplyChangesButton = new Button();
            UserName = new TextBox();
            Patronymic = new TextBox();
            Surname = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label6 = new Label();
            label5 = new Label();
            Password = new TextBox();
            Email = new TextBox();
            ReturnButton = new Button();
            AvatarFileLabel = new Label();
            SelectAvatarButton = new Button();
            label1 = new Label();
            Nickname = new TextBox();
            SuspendLayout();
            // 
            // ApplyChangesButton
            // 
            ApplyChangesButton.Location = new Point(10, 327);
            ApplyChangesButton.Name = "ApplyChangesButton";
            ApplyChangesButton.Size = new Size(563, 71);
            ApplyChangesButton.TabIndex = 0;
            ApplyChangesButton.Text = "Обновить профиль";
            ApplyChangesButton.UseVisualStyleBackColor = true;
            ApplyChangesButton.Click += ApplyChangesButton_Click;
            // 
            // UserName
            // 
            UserName.Location = new Point(10, 39);
            UserName.Name = "UserName";
            UserName.Size = new Size(149, 27);
            UserName.TabIndex = 91;
            // 
            // Patronymic
            // 
            Patronymic.Location = new Point(320, 39);
            Patronymic.Name = "Patronymic";
            Patronymic.Size = new Size(253, 27);
            Patronymic.TabIndex = 90;
            // 
            // Surname
            // 
            Surname.Location = new Point(165, 39);
            Surname.Name = "Surname";
            Surname.Size = new Size(149, 27);
            Surname.TabIndex = 89;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(320, 16);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 88;
            label4.Text = "Отчество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(165, 16);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 87;
            label3.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 16);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 86;
            label2.Text = "Имя";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 217);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 85;
            label6.Text = "Пароль";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 142);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 84;
            label5.Text = "Почта";
            // 
            // Password
            // 
            Password.Location = new Point(10, 240);
            Password.Name = "Password";
            Password.Size = new Size(563, 27);
            Password.TabIndex = 83;
            // 
            // Email
            // 
            Email.Location = new Point(10, 165);
            Email.Name = "Email";
            Email.Size = new Size(563, 27);
            Email.TabIndex = 82;
            // 
            // ReturnButton
            // 
            ReturnButton.Location = new Point(10, 404);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(563, 31);
            ReturnButton.TabIndex = 92;
            ReturnButton.Text = "Назад";
            ReturnButton.UseVisualStyleBackColor = true;
            ReturnButton.Click += ReturnButton_Click;
            // 
            // AvatarFileLabel
            // 
            AvatarFileLabel.AutoSize = true;
            AvatarFileLabel.Location = new Point(190, 287);
            AvatarFileLabel.Name = "AvatarFileLabel";
            AvatarFileLabel.Size = new Size(137, 20);
            AvatarFileLabel.TabIndex = 94;
            AvatarFileLabel.Text = "Аватар не выбран";
            // 
            // SelectAvatarButton
            // 
            SelectAvatarButton.Location = new Point(12, 283);
            SelectAvatarButton.Name = "SelectAvatarButton";
            SelectAvatarButton.Size = new Size(171, 29);
            SelectAvatarButton.TabIndex = 93;
            SelectAvatarButton.Text = "Выбрать аватар";
            SelectAvatarButton.UseVisualStyleBackColor = true;
            SelectAvatarButton.Click += SelectAvatarButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 78);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 96;
            label1.Text = "Никнейм";
            // 
            // Nickname
            // 
            Nickname.Location = new Point(10, 101);
            Nickname.Name = "Nickname";
            Nickname.Size = new Size(563, 27);
            Nickname.TabIndex = 95;
            // 
            // ProfileUpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 443);
            Controls.Add(label1);
            Controls.Add(Nickname);
            Controls.Add(AvatarFileLabel);
            Controls.Add(SelectAvatarButton);
            Controls.Add(ReturnButton);
            Controls.Add(UserName);
            Controls.Add(Patronymic);
            Controls.Add(Surname);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(Password);
            Controls.Add(Email);
            Controls.Add(ApplyChangesButton);
            Name = "ProfileUpdateForm";
            Text = "Обновление профиля";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ApplyChangesButton;
        private TextBox UserName;
        private TextBox Patronymic;
        private TextBox Surname;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label5;
        private TextBox Password;
        private TextBox Email;
        private Button ReturnButton;
        private Label AvatarFileLabel;
        private Button SelectAvatarButton;
        private Label label1;
        private TextBox Nickname;
    }
}