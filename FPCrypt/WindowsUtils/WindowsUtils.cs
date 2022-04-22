using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCrypt.WindowsUtils
{
    public static class WindowsUtils
    {
        public static void changeView(Form oldForm, Form newForm)
        {
            oldForm.Hide();
            newForm.Closed += (s, args) => oldForm.Close();
            newForm.Show();
        }

        public static string? detectErrors(string password)
        {
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
    }
}
