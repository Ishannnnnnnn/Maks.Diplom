namespace MusicStoreFront.Forms
{
    partial class AddBalanceForm
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
            BalanceToAdd = new NumericUpDown();
            AddBalanceButton = new Button();
            ReturnButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)BalanceToAdd).BeginInit();
            SuspendLayout();
            // 
            // BalanceToAdd
            // 
            BalanceToAdd.Location = new Point(12, 30);
            BalanceToAdd.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            BalanceToAdd.Name = "BalanceToAdd";
            BalanceToAdd.Size = new Size(178, 27);
            BalanceToAdd.TabIndex = 0;
            // 
            // AddBalanceButton
            // 
            AddBalanceButton.Location = new Point(12, 63);
            AddBalanceButton.Name = "AddBalanceButton";
            AddBalanceButton.Size = new Size(178, 29);
            AddBalanceButton.TabIndex = 1;
            AddBalanceButton.Text = "Пополнить";
            AddBalanceButton.UseVisualStyleBackColor = true;
            AddBalanceButton.Click += AddBalanceButton_Click;
            // 
            // ReturnButton
            // 
            ReturnButton.Location = new Point(12, 98);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(178, 29);
            ReturnButton.TabIndex = 2;
            ReturnButton.Text = "Отмена";
            ReturnButton.UseVisualStyleBackColor = true;
            ReturnButton.Click += ReturnButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 3;
            label1.Text = "Кол-во денег";
            // 
            // AddBalanceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(199, 145);
            Controls.Add(label1);
            Controls.Add(ReturnButton);
            Controls.Add(AddBalanceButton);
            Controls.Add(BalanceToAdd);
            Name = "AddBalanceForm";
            Text = "AddBalanceForm";
            ((System.ComponentModel.ISupportInitialize)BalanceToAdd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown BalanceToAdd;
        private Button AddBalanceButton;
        private Button ReturnButton;
        private Label label1;
    }
}