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
    public partial class Form2 : Form
    {
        public static byte [] HashPassword;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form3 = new Form();
            form3.Show();
            
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
                dataBase.ChangeMainPassword(textBoxOldPassword.Text, textBoxNewPassword.Text, type);
            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            dataBase.GetPasswords();
            for(int i = 0; i < dataBase.list.Count; i++)
            {
                listView1.Items.Add(dataBase.list[i]);
            }
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            Cryptography c = new Cryptography();
            DataBase dataBase = new DataBase();
            HashPassword = c.AESEncryption(textPassword.Text);
            Console.WriteLine("HAshcode 1" + Encoding.UTF8.GetString(HashPassword));
            
            dataBase.AddPassword(textTitle.Text,textlogin.Text,HashPassword.ToString(),textWebAddress.Text,textDesc.Text);
            listView1.Items.Add(new ListViewItem(new string[] { textTitle.Text, textlogin.Text, Encoding.UTF8.GetString(HashPassword), textWebAddress.Text, textDesc.Text }));
         
            string decodePassword = c.AESDecryption(HashPassword);
            Console.WriteLine("Odszyfrowane hasło: " + decodePassword);
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
          
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBase dataBase = new DataBase();
            dataBase.UserLogin = false;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            String title = listView1.SelectedItems[0].Text;
            String name = listView1.SelectedItems[0].SubItems[0].Text;
            String one = listView1.SelectedItems[0].SubItems[1].Text;
             String two = listView1.SelectedItems[0].SubItems[2].Text;
            String three = listView1.SelectedItems[0].SubItems[3].Text;
            Console.WriteLine($"{name} {one} {two} {three} ");
            
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {

            string hashPass = listView1.SelectedItems[0].SubItems[2].Text;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(hashPass);
            Cryptography c = new Cryptography();
            string decodePassword = c.AESDecryption(passwordBytes);

            Console.WriteLine("Password2: " + decodePassword);
            listView1.SelectedItems[0].SubItems[2].Text = decodePassword;
            String password = listView1.SelectedItems[0].SubItems[3].Text;
            Console.WriteLine("Password" + password);

        }
    }
}
