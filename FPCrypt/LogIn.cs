using FPCrypt.MainWindow;

namespace FPCrypt
{
    public partial class LogIn : Form
    {

        private MasterPasswordManager masterPasswordManager;
        public LogIn()
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
                    LogInButton.Text = "Log In";
                    var infoForm = new ModalWindows.InfoForm("Password was successfully created");
                    infoForm.ShowDialog();
                } else
                {
                    if (!masterPasswordManager.checkMasterpassword(PasswordTextBox.Text))
                    {
                        setError("Passwords do not match!");
                    } else
                    {
                        WindowsUtils.WindowsUtils.changeView(this, new MainWindow.MainWindow());
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

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}