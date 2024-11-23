namespace MusicStoreFront.Forms
{
    partial class RegisterForm
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
            RegisterButton = new Button();
            label6 = new Label();
            label5 = new Label();
            Password = new TextBox();
            Email = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Surname = new TextBox();
            Patronymic = new TextBox();
            UserName = new TextBox();
            ReturnButton = new Button();
            label = new Label();
            Nickname = new TextBox();
            SelectAvatarButton = new Button();
            AvatarFileLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(167, 9);
            label1.Name = "label1";
            label1.Size = new Size(214, 46);
            label1.TabIndex = 38;
            label1.Text = "Регистрация";
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(12, 388);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(563, 66);
            RegisterButton.TabIndex = 65;
            RegisterButton.Text = "Зарегистрироваться";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 283);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 64;
            label6.Text = "Пароль";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 208);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 63;
            label5.Text = "Почта";
            // 
            // Password
            // 
            Password.Location = new Point(12, 306);
            Password.Name = "Password";
            Password.Size = new Size(563, 27);
            Password.TabIndex = 62;
            // 
            // Email
            // 
            Email.Location = new Point(12, 231);
            Email.Name = "Email";
            Email.Size = new Size(563, 27);
            Email.TabIndex = 61;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(322, 78);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 77;
            label4.Text = "Отчество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 78);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 76;
            label3.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 75;
            label2.Text = "Имя";
            // 
            // Surname
            // 
            Surname.Location = new Point(167, 101);
            Surname.Name = "Surname";
            Surname.Size = new Size(149, 27);
            Surname.TabIndex = 79;
            // 
            // Patronymic
            // 
            Patronymic.Location = new Point(322, 101);
            Patronymic.Name = "Patronymic";
            Patronymic.Size = new Size(253, 27);
            Patronymic.TabIndex = 80;
            // 
            // UserName
            // 
            UserName.Location = new Point(12, 101);
            UserName.Name = "UserName";
            UserName.Size = new Size(149, 27);
            UserName.TabIndex = 81;
            // 
            // ReturnButton
            // 
            ReturnButton.Location = new Point(454, 9);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(127, 42);
            ReturnButton.TabIndex = 82;
            ReturnButton.Text = "Назад";
            ReturnButton.UseVisualStyleBackColor = true;
            ReturnButton.Click += ReturnButton_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(12, 143);
            label.Name = "label";
            label.Size = new Size(73, 20);
            label.TabIndex = 84;
            label.Text = "Никнейм";
            // 
            // Nickname
            // 
            Nickname.Location = new Point(12, 166);
            Nickname.Name = "Nickname";
            Nickname.Size = new Size(563, 27);
            Nickname.TabIndex = 83;
            // 
            // SelectAvatarButton
            // 
            SelectAvatarButton.Location = new Point(12, 353);
            SelectAvatarButton.Name = "SelectAvatarButton";
            SelectAvatarButton.Size = new Size(171, 29);
            SelectAvatarButton.TabIndex = 85;
            SelectAvatarButton.Text = "Выбрать аватар";
            SelectAvatarButton.UseVisualStyleBackColor = true;
            SelectAvatarButton.Click += SelectAvatarButton_Click;
            // 
            // AvatarFileLabel
            // 
            AvatarFileLabel.AutoSize = true;
            AvatarFileLabel.Location = new Point(190, 357);
            AvatarFileLabel.Name = "AvatarFileLabel";
            AvatarFileLabel.Size = new Size(137, 20);
            AvatarFileLabel.TabIndex = 86;
            AvatarFileLabel.Text = "Аватар не выбран";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 468);
            Controls.Add(AvatarFileLabel);
            Controls.Add(SelectAvatarButton);
            Controls.Add(label);
            Controls.Add(Nickname);
            Controls.Add(ReturnButton);
            Controls.Add(UserName);
            Controls.Add(Patronymic);
            Controls.Add(Surname);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(RegisterButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(Password);
            Controls.Add(Email);
            Controls.Add(label1);
            Name = "RegisterForm";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button RegisterButton;
        private Label label6;
        private Label label5;
        private TextBox Password;
        private TextBox Email;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox Surname;
        private TextBox Patronymic;
        private TextBox UserName;
        private Button ReturnButton;
        private Label label;
        private TextBox Nickname;
        private Button SelectAvatarButton;
        private Label AvatarFileLabel;
    }
}