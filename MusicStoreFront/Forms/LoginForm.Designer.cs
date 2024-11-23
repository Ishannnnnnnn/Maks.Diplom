namespace MusicStoreFront.Forms;

partial class LoginForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        Email = new TextBox();
        label1 = new Label();
        Password = new TextBox();
        LoginButton = new Button();
        ToRegisterButton = new Button();
        label2 = new Label();
        label3 = new Label();
        SuspendLayout();
        // 
        // Email
        // 
        Email.Location = new Point(12, 100);
        Email.Name = "Email";
        Email.Size = new Size(405, 27);
        Email.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 20F);
        label1.Location = new Point(156, 21);
        label1.Name = "label1";
        label1.Size = new Size(94, 46);
        label1.TabIndex = 1;
        label1.Text = "Вход";
        // 
        // Password
        // 
        Password.Location = new Point(12, 164);
        Password.Name = "Password";
        Password.Size = new Size(405, 27);
        Password.TabIndex = 2;
        // 
        // LoginButton
        // 
        LoginButton.Location = new Point(12, 206);
        LoginButton.Name = "LoginButton";
        LoginButton.Size = new Size(405, 53);
        LoginButton.TabIndex = 3;
        LoginButton.Text = "Войти";
        LoginButton.UseVisualStyleBackColor = true;
        LoginButton.Click += LoginButton_Click;
        // 
        // ToRegisterButton
        // 
        ToRegisterButton.Location = new Point(12, 265);
        ToRegisterButton.Name = "ToRegisterButton";
        ToRegisterButton.Size = new Size(405, 29);
        ToRegisterButton.TabIndex = 4;
        ToRegisterButton.Text = "Регистрация";
        ToRegisterButton.UseVisualStyleBackColor = true;
        ToRegisterButton.Click += ToRegisterButton_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 77);
        label2.Name = "label2";
        label2.Size = new Size(51, 20);
        label2.TabIndex = 5;
        label2.Text = "Почта";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 141);
        label3.Name = "label3";
        label3.Size = new Size(62, 20);
        label3.TabIndex = 6;
        label3.Text = "Пароль";
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(429, 304);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(ToRegisterButton);
        Controls.Add(LoginButton);
        Controls.Add(Password);
        Controls.Add(label1);
        Controls.Add(Email);
        Name = "LoginForm";
        Text = "Вход";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox Email;
    private Label label1;
    private TextBox Password;
    private Button LoginButton;
    private Button ToRegisterButton;
    private Label label2;
    private Label label3;
}