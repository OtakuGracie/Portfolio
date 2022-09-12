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
    public partial class newUserForm : Form
    {

        private const int MINMASTERPASSWORDLENGTH = 12;
        private const int MAXMASTERPASSWORDLENGTH = 30;
        
        
        public newUserForm()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //submit button
        private void button1_Click(object sender, EventArgs e)
        {
            bool success;
            var database = DatabaseAccess.getInstance();
            

            if (usernameTextBox.Text.Trim() == "" || passwordTextBox.Text.Trim() == "")
            {
                MessageBox.Show("All fields must be filled to create a new account");
            }
            else if (passwordTextBox.Text.Length < MINMASTERPASSWORDLENGTH)
            {
                MessageBox.Show("Your master password must be at least " + MINMASTERPASSWORDLENGTH + " characters in length");
            }
            else if (passwordTextBox.Text.Length > MAXMASTERPASSWORDLENGTH)
            {
                MessageBox.Show("Your master password cannot be more than " + MAXMASTERPASSWORDLENGTH + " characters in length");
            }
            else
            {
                success = database.newUserEntry(usernameTextBox.Text, passwordTextBox.Text);

                if (!success)
                {
                    MessageBox.Show(database.ErrorMessage);
                }
                else
                {
                    MessageBox.Show("New account was successfully added");

                    var viewLoginForm = new newLoginInfoForm();
                    viewLoginForm.ShowDialog();
                }
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
