namespace FPCrypt.MainWindow
{
    partial class ListFingerprintItem
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelFP = new System.Windows.Forms.Label();
            this.editNameButton = new System.Windows.Forms.PictureBox();
            this.deleteFingerButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNameButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteFingerButton)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FPCrypt.Properties.Resources.icons8_touch_id_100;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 93);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelFP
            // 
            this.labelFP.AutoSize = true;
            this.labelFP.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFP.ForeColor = System.Drawing.Color.White;
            this.labelFP.Location = new System.Drawing.Point(3, 96);
            this.labelFP.Name = "labelFP";
            this.labelFP.Size = new System.Drawing.Size(57, 15);
            this.labelFP.TabIndex = 2;
            this.labelFP.Text = "Huella 1";
            // 
            // editNameButton
            // 
            this.editNameButton.Image = global::FPCrypt.Properties.Resources.edit_2_48;
            this.editNameButton.Location = new System.Drawing.Point(49, 114);
            this.editNameButton.Name = "editNameButton";
            this.editNameButton.Size = new System.Drawing.Size(24, 23);
            this.editNameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.editNameButton.TabIndex = 4;
            this.editNameButton.TabStop = false;
            this.editNameButton.Click += new System.EventHandler(this.editNameButton_Click);
            // 
            // deleteFingerButton
            // 
            this.deleteFingerButton.Image = global::FPCrypt.Properties.Resources.delete_48;
            this.deleteFingerButton.Location = new System.Drawing.Point(79, 114);
            this.deleteFingerButton.Name = "deleteFingerButton";
            this.deleteFingerButton.Size = new System.Drawing.Size(24, 23);
            this.deleteFingerButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deleteFingerButton.TabIndex = 5;
            this.deleteFingerButton.TabStop = false;
            this.deleteFingerButton.Click += new System.EventHandler(this.deleteFingerButton_Click);
            // 
            // ListFingerprintItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.deleteFingerButton);
            this.Controls.Add(this.editNameButton);
            this.Controls.Add(this.labelFP);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ListFingerprintItem";
            this.Size = new System.Drawing.Size(106, 140);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNameButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteFingerButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelFP;
        private PictureBox editNameButton;
        private PictureBox deleteFingerButton;
    }
}
