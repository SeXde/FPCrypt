namespace FPCrypt
{
    partial class Form1
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
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.FPCryptLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(325, 195);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.PlaceholderText = "Password";
            this.PasswordTextBox.Size = new System.Drawing.Size(155, 23);
            this.PasswordTextBox.TabIndex = 0;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextBox_KeyPress);
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(372, 265);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(75, 23);
            this.LogInButton.TabIndex = 1;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ErrorLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.ErrorLabel.Location = new System.Drawing.Point(325, 230);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(86, 15);
            this.ErrorLabel.TabIndex = 2;
            this.ErrorLabel.Text = "Error Message";
            this.ErrorLabel.Visible = false;
            // 
            // FPCryptLabel
            // 
            this.FPCryptLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FPCryptLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FPCryptLabel.Location = new System.Drawing.Point(325, 111);
            this.FPCryptLabel.Name = "FPCryptLabel";
            this.FPCryptLabel.Size = new System.Drawing.Size(155, 50);
            this.FPCryptLabel.TabIndex = 3;
            this.FPCryptLabel.Text = "FPCrypt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FPCryptLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Name = "Form1";
            this.Text = "FPCrypt - Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox PasswordTextBox;
        private Button LogInButton;
        private Label ErrorLabel;
        private Label FPCryptLabel;
    }
}