using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    class Forms
    {
        public void Form4Close()
        {
            FormRegistry form4 = new FormRegistry();
            form4.Close();
        }
        public void Form4View()
        {
            FormRegistry form4 = new FormRegistry();
            form4.Show();
        }

        public void LoginUser()
        {
            FormLogin form1 = new FormLogin();
            form1.Close();
            shareLogin form2 = new shareLogin();
            form2.Show();
        }
    }
}
