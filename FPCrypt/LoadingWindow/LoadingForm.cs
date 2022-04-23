using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.LoadingWindow
{
    public partial class LoadingForm : Form
    {

        private string fingerprintName;
        public LoadingForm(string tittle, string fingerprintName)
        {
            
            InitializeComponent();
            this.tittleLabel.Text = tittle;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../../Resources/Images/loading.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void tittleLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void LogSerial(string message)
        {
            this.textBox1.AppendText(message);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var fingerprintManager = FingerprintManager.getInstance();
            string id = ArduinoCom.registerFingerPrint(fingerprintManager.getCurrentId());
            fingerprintManager.addFP(new Fingerprint(fingerprintName, id));
        }
    }
}
