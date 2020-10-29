using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Form4 : Form
    {
        private String new_password = "";
        private string old_password = "";
        public Form4()
        {
            InitializeComponent();
        }

        
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword != txtNewPassword)
            {
                MessageBox.Show("New password isnt same that COnfirm password");
            }
            if (txtOldPassword.Text == null || txtNewPassword.Text==null || txtConfirmPassword.Text==null)
            {
                MessageBox.Show("Add empty TextBox");
            }
            else
            {
                DataBase dataBase = new DataBase();

            }
        }

        private void btnCancelPassword_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            txtOldPassword.Text = "";
        }
    }
}
