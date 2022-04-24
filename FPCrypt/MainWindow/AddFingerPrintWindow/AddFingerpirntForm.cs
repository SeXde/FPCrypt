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

        private MainWindow mainForm;
        public AddFingerpirntForm(MainWindow mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
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
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        string fp = ArduinoCom.registerFingerPrint(fingerprintManager.getCurrentId());
                        fingerprintManager.addFP(new Fingerprint(textBox1.Text, fp));
                        mainForm.loadFingerprints();
                        WindowsUtils.WindowsUtils.changeView(this, new ModalWindows.InfoForm("Fingerprint was created successfully"));
                    } catch (Exception ex)
                    {
                        label2.Text = ex.Message;
                    }
                    Cursor = Cursors.Arrow;
                }
            }
        }

        private void AddFingerpirntForm_Load(object sender, EventArgs e)
        {

        }
    }
}
