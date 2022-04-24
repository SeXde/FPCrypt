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
    public partial class MainWindow : Form
    {
        private FingerprintManager fingerprintManager;
        private HashSet<Fingerprint> fingerprints;
        public MainWindow()
        {
            InitializeComponent();
            fingerprintManager = FingerprintManager.getInstance();
            fingerprints = new HashSet<Fingerprint>();
            loadFingerprints();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            new PasswordWindow.PasswordForm().ShowDialog();

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
           new EncryptWindow.EncryptForm().ShowDialog();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            new DecryptWindow.DecryptForm().ShowDialog();
        }

        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            new AddFingerPrintWindow.AddFingerpirntForm(this).ShowDialog();
        }

        public void loadFingerprints()
        {
            foreach (var fingerprint in fingerprintManager.getFingerprints())
            {
                if (!fingerprints.Contains(fingerprint))
                {
                    var fpItem = new ListFingerprintItem(fingerprint);
                    this.flowLayoutPanel1.Controls.Add(fpItem);
                    fingerprints.Add(fingerprint);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
