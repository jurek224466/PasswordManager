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
    public partial class FormRegistry : Form
    {
        public FormRegistry()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            String type;
           
            if (checkHMAC.Checked)
            {
                type = "HMAC";
            }
            else
            {
                type = "SHA512";
            }
            if (Equals(textConfirmPassword, textPassword)!=false)
            {
                MessageBox.Show("Passwords is difference");
            }
            DataBase data = new DataBase();
          
            data.addNewUser(textUser.Text, textPassword.Text,type,Files.filePath);
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
