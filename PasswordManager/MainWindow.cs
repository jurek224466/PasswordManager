using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class shareLogin : Form
    {
       /* public static byte[] HashPassword;*/
        public static string HashPassword;
        public shareLogin()
        {
            InitializeComponent();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            string type = "";
            if (radioButtonHMAC.Checked)
            {
                type = "HMAC";
            }
            if (radioButtonSHA512.Checked)
            {
                type = "SHA512";
            }

            Console.WriteLine("Zmiana hasła");
            DataBase dataBase = new DataBase();
            if (String.Equals(textBoxNewPassword.Text, textBoxNewPasswordRepeat.Text))
            {
                dataBase.ChangeMainPassword(textBoxOldPassword.Text, textBoxNewPassword.Text, type, Files.filePath);
            }
            else
            {
                errorLabel.ForeColor = Color.Red;
                errorLabel.Text = "New passwords isn't same";
            }
           
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            
            string hashPass = listView1.SelectedItems[0].SubItems[2].Text;
        
            Cryptography c = new Cryptography();
     
            string decodePassword = c.AESDecryption(hashPass);
            listView1.SelectedItems[0].SubItems[2].Text = decodePassword;
            String password = listView1.SelectedItems[0].SubItems[3].Text;


        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            Cryptography c = new Cryptography();
            DataBase dataBase = new DataBase();

            HashPassword = c.AESEncryption(textPassword.Text);
          /*  Console.WriteLine("HAshcode 1" + Encoding.ASCII.GetString(HashPassword));*/

            dataBase.AddPassword(textTitle.Text, textlogin.Text, HashPassword, textWebAddress.Text, textDesc.Text, Files.filePath);
            listView1.Items.Add(new ListViewItem(new string[] { textTitle.Text, textlogin.Text,HashPassword, textWebAddress.Text, textDesc.Text }));

            string decodePassword = c.AESDecryption(HashPassword);
            Console.WriteLine("Odszyfrowane hasło: " + decodePassword);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            DataBase dataBase = new DataBase();
            dataBase.GetPasswords(Files.filePath);
            for (int i = 0; i < dataBase.list.Count; i++)
            {
                listView1.Items.Add(dataBase.list[i]);
            }
            SharePasswords sharePasswords = new SharePasswords();
            sharePasswords.CreateDataBaseShare(Files.filePath);
            sharePasswords.GetSharedPasswords(Files.filePath);
            for (int i = 0; i <sharePasswords.shareList.Count; i++)
            {
                sharedListview.Items.Add(sharePasswords.shareList[i]);
            }





        }

        private void btnEvent_Click(object sender, EventArgs e)
        {

        }

        private void btnShare_Click(object sender, EventArgs e)
        {

            DateTime currentTime = DateTime.Now;
            String title=listView1.SelectedItems[0].SubItems[0].Text;
            String login= listView1.SelectedItems[0].SubItems[1].Text;
            String password = listView1.SelectedItems[0].SubItems[2].Text;
            String descrpition= listView1.SelectedItems[0].SubItems[3].Text;
            String webAddress = listView1.SelectedItems[0].SubItems[4].Text;
            SharePasswords sharePasswords = new SharePasswords();
            ShareForm shareForm = new ShareForm();
            shareForm.ShowDialog();
            sharePasswords.AddPassword(Files.filePath, login, password, webAddress, descrpition, currentTime,ShareForm.shareUser, false,title);
           /* sharePasswords.UpdatePassword();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
