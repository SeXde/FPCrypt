namespace FPCrypt.MainWindow.DecryptWindow
{
    partial class DecryptForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.btnFld = new System.Windows.Forms.Button();
            this.textPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::FPCrypt.Properties.Resources.padlock_2_48;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.button2.Location = new System.Drawing.Point(193, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(129, 125);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(38, 17);
            this.labelError.TabIndex = 9;
            this.labelError.Text = "error";
            // 
            // btnFld
            // 
            this.btnFld.BackgroundImage = global::FPCrypt.Properties.Resources.report_3_24;
            this.btnFld.FlatAppearance.BorderSize = 0;
            this.btnFld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFld.Location = new System.Drawing.Point(289, 98);
            this.btnFld.Name = "btnFld";
            this.btnFld.Size = new System.Drawing.Size(24, 24);
            this.btnFld.TabIndex = 8;
            this.btnFld.UseVisualStyleBackColor = true;
            this.btnFld.Click += new System.EventHandler(this.btnFld_Click);
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(125, 100);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(158, 23);
            this.textPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(125, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "File path";
            // 
            // DecryptForm
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DecryptForm";
            this.Text = "DecryptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button2;
        private Label labelError;
        private Button btnFld;
        private TextBox textPath;
        private Label label1;
    }
}