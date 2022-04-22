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
    }
}
