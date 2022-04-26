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
            var error = WindowsUtils.WindowsUtils.detectErrors(PasswordTextBox.Text);

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
                    infoForm.ShowDialog(this);
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

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}