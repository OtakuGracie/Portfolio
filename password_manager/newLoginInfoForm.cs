using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_manager
{
    public partial class newLoginInfoForm : Form
    {
        public newLoginInfoForm()
        {
            InitializeComponent();
            passwordLengthTextbox.Text = PasswordGenerator.MINPASSWORDLENGTH.ToString();
        }

        //generate password button click
        private void button1_Click(object sender, EventArgs e)
        {
            int passwordLength;

            if (!int.TryParse(passwordLengthTextbox.Text, out passwordLength))
            {
                MessageBox.Show("Non-numeric characters cannot be in the password length textbox. Using the minimum password length");
                passwordLength = PasswordGenerator.MINPASSWORDLENGTH;
                passwordLengthTextbox.Text = PasswordGenerator.MINPASSWORDLENGTH.ToString();
            }
            else if (passwordLength < PasswordGenerator.MINPASSWORDLENGTH)
            {
                MessageBox.Show("Passwords cannot be less than " + PasswordGenerator.MINPASSWORDLENGTH + " characters long! Using the minimum password length");
                passwordLength = PasswordGenerator.MINPASSWORDLENGTH;
                passwordLengthTextbox.Text = PasswordGenerator.MINPASSWORDLENGTH.ToString();
            }
            else if (passwordLength > PasswordGenerator.MAXPASSWORDLENGTH)
            {
                MessageBox.Show("Passwords cannot be greater in length than " + PasswordGenerator.MAXPASSWORDLENGTH + " characters! Using the maximum password length");
                passwordLength = PasswordGenerator.MAXPASSWORDLENGTH;
                passwordLengthTextbox.Text = PasswordGenerator.MAXPASSWORDLENGTH.ToString();
            }

            passwordTextBox.Text = PasswordGenerator.getInstance().newPassword(passwordLength);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            bool success;
            var database = DatabaseAccess.getInstance();
            //test value for userID
            int userID = 1;


            if (nameTextBox.Text.Trim() == "" || usernameTextBox.Text.Trim() == "" || passwordTextBox.Text.Trim() == "")
            {
                MessageBox.Show("All fields must be filled to submit a new password entry");
            }
            else
            {
                success = database.newPasswordEntry(userID, usernameTextBox.Text, passwordTextBox.Text, nameTextBox.Text);

                if (!success)
                {
                    MessageBox.Show(database.ErrorMessage);
                }
                else
                {
                    MessageBox.Show("New password entry was successfully added");
                }
            }
        }

        private void newLoginInfoForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'passwordManagerDataSet1.LoginInfo' table. You can move, or remove it, as needed.
            this.loginInfoTableAdapter.Fill(this.passwordManagerDataSet1.LoginInfo);

        }
    }
}
