using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.MainWindow.EncryptWindow
{
    public partial class EncryptForm : Form
    {
        public EncryptForm()
        {
            InitializeComponent();
            this.labelError.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFld_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
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
            } else
            {
                var fingerprintManager = FingerprintManager.getInstance();
                Cursor = Cursors.WaitCursor;
                try
                {
                    string fp = ArduinoCom.readFingerPrint();
                    if (!fingerprintManager.isPresent(fp))
                    {
                        labelError.Text = "Fingerprint is not registered.";
                    } else
                    {
                        try
                        {
                            cryptoUtils.CipherTool.GetInstance().EncryptFile(textPath.Text, fp);
                            WindowsUtils.WindowsUtils.changeView(this, new ModalWindows.InfoForm("File was successfully encrypted"));
                        } catch(Exception ex2)
                        {
                            labelError.Text = ex2.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    labelError.Text = ex.Message;
                }
                Cursor = Cursors.Arrow;
            }
        }

        private void labelError_Click(object sender, EventArgs e)
        {

        }

        private void textPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
