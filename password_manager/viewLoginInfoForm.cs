using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_manager
{
    public partial class viewLoginInfoForm : Form
    {
        public viewLoginInfoForm()
        {
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewLoginButton_Click(object sender, EventArgs e)
        {
            var newLoginForm = new newLoginInfoForm();
            newLoginForm.ShowDialog();
        }
    }
}
