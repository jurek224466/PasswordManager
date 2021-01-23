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
    public partial class ShareForm : Form
    {
        public static String shareUser="";
        public ShareForm()
        {
            InitializeComponent();
            btnCancel.DialogResult = DialogResult.Cancel;
            
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            SharePasswords sharePasswords = new SharePasswords();
              if (ShareUSer.Text != "")
                {
                    sharePasswords.Consumer = ShareUSer.Text;
                    shareUser = ShareUSer.Text;
                    this.Close();
                }

            
            
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
