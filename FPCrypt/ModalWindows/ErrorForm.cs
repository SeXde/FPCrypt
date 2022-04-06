using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.ModalWindows
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string errorMessage)
        {
            InitializeComponent();
            this.textBox1.Text = errorMessage;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
