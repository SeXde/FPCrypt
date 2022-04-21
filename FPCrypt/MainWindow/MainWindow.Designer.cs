﻿namespace FPCrypt.MainWindow
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
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnFingerPrint = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Navy;
            this.panelMenu.Controls.Add(this.btnUnlock);
            this.panelMenu.Controls.Add(this.btnLock);
            this.panelMenu.Controls.Add(this.btnFingerPrint);
            this.panelMenu.Controls.Add(this.btnPassword);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(228, 590);
            this.panelMenu.TabIndex = 5;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.panelLogo.Size = new System.Drawing.Size(228, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // btnPassword
            // 
            this.btnPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPassword.FlatAppearance.BorderSize = 0;
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPassword.Image = global::FPCrypt.Properties.Resources.icons8_key_2_48px;
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
            // btnFingerPrint
            // 
            this.btnFingerPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFingerPrint.FlatAppearance.BorderSize = 0;
            this.btnFingerPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFingerPrint.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFingerPrint.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFingerPrint.Image = global::FPCrypt.Properties.Resources.icons8_add_fingerprint_48px;
            this.btnFingerPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFingerPrint.Location = new System.Drawing.Point(0, 140);
            this.btnFingerPrint.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnFingerPrint.Name = "btnFingerPrint";
            this.btnFingerPrint.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnFingerPrint.Size = new System.Drawing.Size(228, 60);
            this.btnFingerPrint.TabIndex = 2;
            this.btnFingerPrint.Text = "  Add fingerprint";
            this.btnFingerPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFingerPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFingerPrint.UseVisualStyleBackColor = true;
            this.btnFingerPrint.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnLock
            // 
            this.btnLock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLock.FlatAppearance.BorderSize = 0;
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLock.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLock.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLock.Image = global::FPCrypt.Properties.Resources.icons8_lock_48px;
            this.btnLock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLock.Location = new System.Drawing.Point(0, 200);
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
            // btnUnlock
            // 
            this.btnUnlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUnlock.FlatAppearance.BorderSize = 0;
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlock.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUnlock.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUnlock.Image = global::FPCrypt.Properties.Resources.icons8_padlock_48px;
            this.btnUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlock.Location = new System.Drawing.Point(0, 260);
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
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPCrypt";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 590);
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
        private Button btnFingerPrint;
        private Label label1;
        private Panel panelTitle;
        private Label labelTitle;
    }
}