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
        public ListFingerprintItem(Fingerprint fingerprint)
        {
            InitializeComponent();
            this.fingerprint = fingerprint;
            labelFP.Text = fingerprint.getName();
        }

        public void updateItem(Fingerprint fingerprint)
        {
            this.fingerprint = fingerprint;
            labelFP.Text = fingerprint.getName();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
