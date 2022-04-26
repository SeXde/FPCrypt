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
        private MainWindow mainWindow;
        public ModifyfingerprintnameForm(Fingerprint fingerprint, MainWindow mainWindow)
        {
            InitializeComponent();
            label2.Text = "";
            this.fingerprint = fingerprint;
            this.mainWindow = mainWindow;
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                    mainWindow.loadFingerprints();
                    WindowsUtils.WindowsUtils.changeView(this, new ModalWindows.InfoForm("Fingerprint was modified successfully"));
                }
            }
        }

        private void ModifyfingerprintnameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
