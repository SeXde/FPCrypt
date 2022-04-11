namespace FPCrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                ErrorLabel.Visible = false;
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

            string actualPassword = "";
            if (password != actualPassword)
            {
                return "The password is not correct";
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