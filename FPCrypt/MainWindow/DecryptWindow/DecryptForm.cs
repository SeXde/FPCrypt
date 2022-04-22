using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.MainWindow.DecryptWindow
{
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();
            labelError.Text = "";
        }

        private void btnFld_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "FPCrypt files (*.fpc)|.fpc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textPath.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelError.Text = "";
            if (string.IsNullOrEmpty(textPath.Text))
            {
                labelError.Text = "File path cannot be empty";
            }
            else
            {
                var fingerprintManager = FingerprintManager.getInstance();
                // TODO call arduino window
            }
        }
    }
}
