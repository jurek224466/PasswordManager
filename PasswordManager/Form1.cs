using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        int FirstLoadDataBase = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
           
            dataBase.CreateDataBaseFile();
            Form4 form = new Form4();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            dataBase.GetDataBaseFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cryptography cryptography = new Cryptography();
             String value = "Ala ma kota i psa";
            /*byte[] va = cryptography.generateHMAC(value);
            string val= Encoding.UTF8.GetString(va, 0, va.Length);
            Console.WriteLine("hmac " + val);*/
            byte[] encrypt = cryptography.AESEncryption(value);
            Console.WriteLine("Encrypt : " + Encoding.UTF8.GetString(encrypt, 0, encrypt.Length));
            String result = cryptography.AESDecryption(encrypt);
            Console.WriteLine("Result decrypt text : " + result);
            cryptography.EncryptSHA512(value);
           /* bool checkHash = cryptography.CheckHashSHA512(value, cryptography.EncryptSHA512(value));
            Console.WriteLine("Check hash ", checkHash);*/

            /*byte[] checker= cryptography.EncryptSHA512(value);
            bool result = cryptography.CheckHash(value, checker);
            Console.WriteLine("Values bool "+result);*/
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            String type = "";
            if (checkHMAC.Checked)
            {
                type = "HMAC";
            }
            else
            {
                type = "SHA512";
            }
            dataBase.LoginUser(textLogin.Text, textPassword.Text, type);
                       

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Cryptography cryptography = new Cryptography();
            String value = "Ala ma kota i psa";
          
            byte[] encrypt = cryptography.AESEncryption(value);
            Console.WriteLine("Encrypt : " + Encoding.UTF8.GetString(encrypt, 0, encrypt.Length));
            String result = cryptography.AESDecryption(encrypt);
            Console.WriteLine("Result decrypt text : " + result);
            cryptography.EncryptSHA512(value);
           
        }
    }
}
