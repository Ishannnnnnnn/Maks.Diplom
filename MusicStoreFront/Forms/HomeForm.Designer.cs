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
            ToMyProfileButton = new Button();
            ToMyPurchasesButton = new Button();
            ToStoresListButton = new Button();
            LogoutButton = new Button();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI", 15F);
            UsernameLabel.Location = new Point(238, 9);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(299, 35);
            UsernameLabel.TabIndex = 15;
            UsernameLabel.Text = "*Текущий пользователь*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(5, 9);
            label1.Name = "label1";
            label1.Size = new Size(248, 35);
            label1.TabIndex = 14;
            label1.Text = "Добро пожаловать, ";
            // 
            // ToMyProfileButton
            // 
            ToMyProfileButton.Font = new Font("Segoe UI", 12F);
            ToMyProfileButton.Location = new Point(224, 333);
            ToMyProfileButton.Name = "ToMyProfileButton";
            ToMyProfileButton.Size = new Size(249, 52);
            ToMyProfileButton.TabIndex = 13;
            ToMyProfileButton.Text = "Мой профиль";
            ToMyProfileButton.UseVisualStyleBackColor = true;
            ToMyProfileButton.Click += ToMyProfileButton_Click;
            // 
            // ToMyPurchasesButton
            // 
            ToMyPurchasesButton.Font = new Font("Segoe UI", 12F);
            ToMyPurchasesButton.Location = new Point(224, 263);
            ToMyPurchasesButton.Name = "ToMyPurchasesButton";
            ToMyPurchasesButton.Size = new Size(249, 52);
            ToMyPurchasesButton.TabIndex = 12;
            ToMyPurchasesButton.Text = "Мои покупки";
            ToMyPurchasesButton.UseVisualStyleBackColor = true;
            ToMyPurchasesButton.Click += ToMyPurchasesButton_Click;
            // 
            // ToStoresListButton
            // 
            ToStoresListButton.Font = new Font("Segoe UI", 12F);
            ToStoresListButton.Location = new Point(115, 82);
            ToStoresListButton.Name = "ToStoresListButton";
            ToStoresListButton.Size = new Size(473, 159);
            ToStoresListButton.TabIndex = 11;
            ToStoresListButton.Text = "Магазины";
            ToStoresListButton.UseVisualStyleBackColor = true;
            ToStoresListButton.Click += ToStoresListButton_Click;
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(555, 12);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(159, 46);
            LogoutButton.TabIndex = 16;
            LogoutButton.Text = "Выйти из аккаунта";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 406);
            Controls.Add(LogoutButton);
            Controls.Add(UsernameLabel);
            Controls.Add(label1);
            Controls.Add(ToMyProfileButton);
            Controls.Add(ToMyPurchasesButton);
            Controls.Add(ToStoresListButton);
            Name = "HomeForm";
            Text = "Домашняя страница";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernameLabel;
        private Label label1;
        private Button ToMyProfileButton;
        private Button ToMyPurchasesButton;
        private Button ToStoresListButton;
        private Button LogoutButton;
    }
}