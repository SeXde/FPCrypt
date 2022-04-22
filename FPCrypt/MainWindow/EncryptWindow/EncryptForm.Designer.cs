namespace FPCrypt.MainWindow.EncryptWindow
{
    partial class EncryptForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.btnFld = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(140, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "File path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(140, 114);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(158, 23);
            this.textPath.TabIndex = 1;
            // 
            // btnFld
            // 
            this.btnFld.BackgroundImage = global::FPCrypt.Properties.Resources.report_3_24;
            this.btnFld.FlatAppearance.BorderSize = 0;
            this.btnFld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFld.Location = new System.Drawing.Point(304, 112);
            this.btnFld.Name = "btnFld";
            this.btnFld.Size = new System.Drawing.Size(24, 24);
            this.btnFld.TabIndex = 2;
            this.btnFld.UseVisualStyleBackColor = true;
            this.btnFld.Click += new System.EventHandler(this.btnFld_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(144, 139);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(38, 17);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "error";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::FPCrypt.Properties.Resources.padlock_48;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.button2.Location = new System.Drawing.Point(208, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(439, 270);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.btnFld);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EncryptForm";
            this.Text = "EncryptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textPath;
        private Button btnFld;
        private Label labelError;
        private Button button2;
    }
}