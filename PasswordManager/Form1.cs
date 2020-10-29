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

            /* byte[] encrypt = cryptography.AESEncryption(value);
             Console.WriteLine("Encrypt : " + Encoding.UTF8.GetString(encrypt, 0, encrypt.Length));
             String result = cryptography.AESDecryption(encrypt);
             Console.WriteLine("Result decrypt text : " + result);*/
            /*    cryptography.EncryptSHA512(value);
                bool checkHash = cryptography.CheckHash(value);
                Console.WriteLine("Check hash ", checkHash);
    */
            byte[] checker= cryptography.EncryptSHA512(value);
            bool result = cryptography.CheckHash(value, checker);
            Console.WriteLine("Values bool "+result);
        }
        /* public string SaveDataBase()
{
String filename = null;
String filePath = null;
String extension = null;
SaveFileDialog saveFile = new SaveFileDialog();
saveFile.Filter = "Text file (.txt)|*.txt|Database file (.db)|*.db | All files |*.*";
saveFile.DefaultExt = "txt";
if (saveFile.ShowDialog() == DialogResult.OK)
{

filename = saveFile.FileName;
filePath = Path.GetFullPath(saveFile.FileName);
String StrValue = "Ala ma kota";
byte[] bytes = Encoding.ASCII.GetBytes(StrValue);
String val = bytes.ToString();
MemoryStream stream = new MemoryStream();
stream.Write(bytes,0,StrValue.Length);
StreamWriter fileStream = new StreamWriter(stream);

}
return filePath;
}
*/
    }
}
