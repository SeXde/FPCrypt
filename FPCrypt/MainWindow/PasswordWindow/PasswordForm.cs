using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.MainWindow.PasswordWindow
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            errorLabel1.Text = "";
            errorLabel2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error1 = WindowsUtils.WindowsUtils.detectErrors(oldPasswordText.Text);
            string error2 = WindowsUtils.WindowsUtils.detectErrors(newPasswordText.Text);
            errorLabel1.Text = error1;
            errorLabel2.Text = error2;
            if (error1 == null && error2 == null)
            {
                var master = MasterPasswordManager.getInstance();
                if (!master.checkMasterpassword(oldPasswordText.Text)) {
                    errorLabel1.Text = "Passwords do not match";
                } else
                {
                    master.setPassword(newPasswordText.Text);
                    var infoForm = new ModalWindows.InfoForm("Password was successfully changed");
                    WindowsUtils.WindowsUtils.changeView(this, infoForm);
                    
                }
            }
        }
    }
}
