using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.MainWindow
{
    public partial class ListFingerprintItem : UserControl
    {

        private Fingerprint fingerprint;
        private MainWindow mainWindow;
        public ListFingerprintItem(Fingerprint fingerprint, MainWindow mainWindow)
        {
            InitializeComponent();
            this.fingerprint = fingerprint;
            labelFP.Text = fingerprint.getName();
            this.mainWindow = mainWindow;
        }

        public void updateItem(Fingerprint fingerprint)
        {
            this.fingerprint = fingerprint;
            labelFP.Text = fingerprint.getName();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void editNameButton_Click(object sender, EventArgs e)
        {
            new ModifyFingerPrintNameWindow.ModifyfingerprintnameForm(fingerprint, mainWindow).ShowDialog();

        }

        private void deleteFingerButton_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteFingerButton_Click_1(object sender, EventArgs e)
        {
            var result = new ModalWindows.WarningForm("If you remove this fingerprint some data could be lost").ShowDialog();
            if (result == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    ArduinoCom.deleteFingerPrint(Int32.Parse(fingerprint.getFingerprintValue()));
                    FingerprintManager.getInstance().deleteFP(fingerprint);
                    mainWindow.loadFingerprints();
                    new ModalWindows.InfoForm("Fingerprint was deleted successfully").ShowDialog();
                }
                catch (Exception ex)
                {
                    new ModalWindows.ErrorForm(ex.Message);
                }
                Cursor = Cursors.Arrow;
            }
        }
    }
}
