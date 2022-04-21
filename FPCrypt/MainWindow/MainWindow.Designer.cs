namespace FPCrypt.MainWindow
{
    partial class MainWindow
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnPassword = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnAddFP = new System.Windows.Forms.Button();
            this.btnDeleteFP = new System.Windows.Forms.Button();
            this.btnEditFP = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panelMenu.Controls.Add(this.btnEditFP);
            this.panelMenu.Controls.Add(this.btnDeleteFP);
            this.panelMenu.Controls.Add(this.btnAddFP);
            this.panelMenu.Controls.Add(this.btnUnlock);
            this.panelMenu.Controls.Add(this.btnLock);
            this.panelMenu.Controls.Add(this.btnPassword);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(228, 590);
            this.panelMenu.TabIndex = 5;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUnlock.FlatAppearance.BorderSize = 0;
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlock.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUnlock.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUnlock.Image = global::FPCrypt.Properties.Resources.padlock_2_48;
            this.btnUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlock.Location = new System.Drawing.Point(0, 200);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUnlock.Size = new System.Drawing.Size(228, 60);
            this.btnUnlock.TabIndex = 4;
            this.btnUnlock.Text = "  Decrypt file";
            this.btnUnlock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnlock.UseVisualStyleBackColor = true;
            // 
            // btnLock
            // 
            this.btnLock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLock.FlatAppearance.BorderSize = 0;
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLock.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLock.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLock.Image = global::FPCrypt.Properties.Resources.padlock_48;
            this.btnLock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLock.Location = new System.Drawing.Point(0, 140);
            this.btnLock.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnLock.Name = "btnLock";
            this.btnLock.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLock.Size = new System.Drawing.Size(228, 60);
            this.btnLock.TabIndex = 3;
            this.btnLock.Text = "  Encrypt file";
            this.btnLock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLock.UseVisualStyleBackColor = true;
            // 
            // btnPassword
            // 
            this.btnPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPassword.FlatAppearance.BorderSize = 0;
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPassword.Image = global::FPCrypt.Properties.Resources.key_5_48;
            this.btnPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassword.Location = new System.Drawing.Point(0, 80);
            this.btnPassword.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnPassword.Size = new System.Drawing.Size(228, 60);
            this.btnPassword.TabIndex = 1;
            this.btnPassword.Text = "  Password";
            this.btnPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPassword.UseVisualStyleBackColor = true;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.panelLogo.Size = new System.Drawing.Size(228, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPCrypt";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(228, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(775, 80);
            this.panelTitle.TabIndex = 6;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(271, 21);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(293, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Fingerprint manager";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddFP
            // 
            this.btnAddFP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddFP.FlatAppearance.BorderSize = 0;
            this.btnAddFP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFP.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddFP.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAddFP.Image = global::FPCrypt.Properties.Resources.icons8_touch_id_48;
            this.btnAddFP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFP.Location = new System.Drawing.Point(0, 260);
            this.btnAddFP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnAddFP.Name = "btnAddFP";
            this.btnAddFP.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnAddFP.Size = new System.Drawing.Size(228, 60);
            this.btnAddFP.TabIndex = 5;
            this.btnAddFP.Text = "  Add fingerprint";
            this.btnAddFP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddFP.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFP
            // 
            this.btnDeleteFP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteFP.FlatAppearance.BorderSize = 0;
            this.btnDeleteFP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFP.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteFP.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteFP.Image = global::FPCrypt.Properties.Resources.delete_48;
            this.btnDeleteFP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFP.Location = new System.Drawing.Point(0, 320);
            this.btnDeleteFP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnDeleteFP.Name = "btnDeleteFP";
            this.btnDeleteFP.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDeleteFP.Size = new System.Drawing.Size(228, 60);
            this.btnDeleteFP.TabIndex = 6;
            this.btnDeleteFP.Text = "  Delete fingerprint";
            this.btnDeleteFP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteFP.UseVisualStyleBackColor = true;
            // 
            // btnEditFP
            // 
            this.btnEditFP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditFP.FlatAppearance.BorderSize = 0;
            this.btnEditFP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditFP.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditFP.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEditFP.Image = global::FPCrypt.Properties.Resources.edit_2_48;
            this.btnEditFP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditFP.Location = new System.Drawing.Point(0, 380);
            this.btnEditFP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnEditFP.Name = "btnEditFP";
            this.btnEditFP.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnEditFP.Size = new System.Drawing.Size(228, 60);
            this.btnEditFP.TabIndex = 7;
            this.btnEditFP.Text = "  Edit fingerprint";
            this.btnEditFP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditFP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditFP.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(228, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 510);
            this.panel1.TabIndex = 7;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 590);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainWindow";
            this.Text = "FPCrypt";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelMenu;
        private Panel panelLogo;
        private Button btnPassword;
        private Button btnUnlock;
        private Button btnLock;
        private Label label1;
        private Panel panelTitle;
        private Label labelTitle;
        private Button btnEditFP;
        private Button btnDeleteFP;
        private Button btnAddFP;
        private Panel panel1;
    }
}