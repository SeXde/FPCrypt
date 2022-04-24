using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.MainWindow.ModifyFingerPrintNameWindow
{
    public partial class ModifyfingerprintnameForm : Form
    {
        private Fingerprint fingerprint;
        public ModifyfingerprintnameForm(Fingerprint fingerprint)
        {
            InitializeComponent();
            label2.Text = "";
            this.fingerprint = fingerprint; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                label2.Text = "Introduce the new name first";
            }
            else
            {
                FingerprintManager manager = FingerprintManager.getInstance();
                if (!manager.isPickable(this.textBox1.Text))
                {
                    label2.Text = "Name is alredy in use";
                }
                else
                {
                    Fingerprint newFingerprint = new Fingerprint(this.textBox1.Text, fingerprint.getFingerprintValue());
                    manager.modifyFP(fingerprint, newFingerprint);
                }
            }
        }
    }
}
