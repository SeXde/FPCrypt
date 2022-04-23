using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.MainWindow.AddFingerPrintWindow
{
    public partial class AddFingerpirntForm : Form
    {
        public AddFingerpirntForm()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                label2.Text = "Fingerprint name cannot be empty";
            } else
            {
                FingerprintManager fingerprintManager = FingerprintManager.getInstance();
                if (!fingerprintManager.isPickable(this.textBox1.Text))
                {
                    label2.Text = "Name is already taken";
                } else
                {
                    var loadingForm = new LoadingWindow.LoadingForm("Adding fingerprint", textBox1.Text);
                    WindowsUtils.WindowsUtils.changeView(this, loadingForm);
                }
            }
        }
    }
}
