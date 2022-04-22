using FPCrypt.MainWindow;

namespace FPCrypt
{
    public partial class Form1 : Form
    {

        private MasterPasswordManager masterPasswordManager;
        public Form1()
        {
            InitializeComponent();
            masterPasswordManager = MasterPasswordManager.getInstance();
            if(masterPasswordManager.isFirstTime())
            {
                LogInButton.Text = "Sign up";
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            var error = detectErrors();

            if (error != null)
            {
                setError(error);
            }
            else
            {
                if (masterPasswordManager.isFirstTime())
                {
                    masterPasswordManager.setPassword(PasswordTextBox.Text);
                    PasswordTextBox.Text = "Log in";
                } else
                {
                    if (!masterPasswordManager.checkMasterpassword(PasswordTextBox.Text))
                    {
                        setError("Passwords do not match!");
                    } else
                    {
                        this.Hide();
                        var form2 = new MainWindow.MainWindow();
                        form2.Closed += (s, args) => this.Close();
                        form2.Show();
                        ErrorLabel.Visible = false;
                    }
                }
            }
        }

        private string? detectErrors()
        {
            var password = PasswordTextBox.Text;
            if (password == null || password.Length == 0)
            {
                return "You need to provide a password";
            }

            if (password.Length < 6)
            {
                return "The password needs at least 6 characters";
            }

            return null;
        }

        private void setError(string message)
        {
            ErrorLabel.Text = message;
            ErrorLabel.Visible = true;
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Detect Enter key
            {
                LogInButton.PerformClick();
            }
        }
    }
}