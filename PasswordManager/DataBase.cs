using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace PasswordManager
{
    public class DataBase
    {
        SaveFileDialog saveFile = new SaveFileDialog();
        String exceptionMessage = "";
        public List<ListViewItem> list = new List<ListViewItem>();
       public static String filePath { get; set; }
        public Boolean UserLogin = false;
        static String userName { get; set; }
        static byte[] encryptPass { get; set; }
        public int Version { get; private set; }

        public bool CreateDataBaseFile()
        {
            filePath = SaveDataBaseFile();
            try
            {
                /* SQLiteConnection.CreateFile(filePath);*/
                /*string cs = @"URI=file:C:\Users\Jurek\test.db";*/
                SQLiteConnection sqlite2 = new SQLiteConnection(@"DataSource=" + filePath);
                sqlite2.Open();
                string sql = @"CREATE TABLE user(id INTEGER PRIMARY KEY AUTOINCREMENT, login VARCHAR(30),
                    password_hash VARCHAR(512), salt VARCHAR(20), isPasswordKeptHash BOOLEAN);";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                command.ExecuteReader();
                command.Dispose();
                string sql2 = @"CREATE TABLE passwords(id INTEGER PRIMARY KEY AUTOINCREMENT, title VARCHAR(256),
                    login VARCHAR(256),password VARCHAR(256),web_address VARCHAR(256),description VARCHAR(256));";
                SQLiteCommand command2 = new SQLiteCommand(sql2, sqlite2);
                command2.ExecuteReader();
                command2.Dispose();
                sqlite2.Close();
                return true;
            }
            catch (SQLiteException e)
            {
                exceptionMessage = e.Message;
                return false;
            }
        }
       public string SaveDataBaseFile()
        {

            String filename;
            saveFile.Filter = "DataBase file | *.db";
            saveFile.DefaultExt = "db";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                filename = saveFile.FileName;
                filePath = Path.GetFullPath(saveFile.FileName);

            }
            return filePath;
        }
       public string OpenDataBaseFile()
        {
            String filename = null;
            filePath = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "DataBase file | *.db";
            openFile.DefaultExt = "db";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filename = openFile.FileName;
                filePath = Path.GetFullPath(openFile.FileName);

            }
            return filePath;
        }
        public void GetDataBaseFile()
        {
            try
            {
                string filePath = OpenDataBaseFile();
                SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath);
                
                    connection.Open();
                    string[] result = new string[7];
                string[] result2 = new string[7];
                string sql = "select * from user";
                    SQLiteCommand command = new SQLiteCommand(sql,connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                List<DataBaseData> active = new List<DataBaseData>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DataBaseData dataBaseData = new DataBaseData();
                        dataBaseData.UserName = reader[1].ToString();
                        dataBaseData.Password = reader[2].ToString();
                        dataBaseData.Salt = reader[3].ToString();
                        active.Add(dataBaseData);
                        Console.WriteLine($"{reader[1].ToString()} and {reader[2].ToString()} and {reader[3].ToString()}");


                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                    reader.Close();
                    connection.Close();
                   


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
        }
        public void GetUserData(String source)
        {
            try
            {
                string filePath = OpenDataBaseFile();
                SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath);

                connection.Open();
                string[] result = new string[7];
                string[] result2 = new string[7];
                string sql = "select * from password";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                List<DataBaseData> active = new List<DataBaseData>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DataBaseData dataBaseData = new DataBaseData();
                        dataBaseData.UserName = reader[1].ToString();
                        dataBaseData.Password = reader[2].ToString();
                        dataBaseData.Salt = reader[3].ToString();
                        active.Add(dataBaseData);
                        Console.WriteLine($"{reader[1].ToString()} and {reader[2].ToString()} and {reader[3].ToString()}");


                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                reader.Close();
                connection.Close();



            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
        }
        public string [] GetPasswords()
        {
            String title = "";
            String user = "";
            String password = "";
            String web_address = "";
            String descryption = "";
            List<String> lista = new List<string>();
            try
            {
                string filePath = OpenDataBaseFile();
                SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath);
               
                connection.Open();
                string[] result = new string[7];
                string[] result2 = new string[7];
                string sql = "select * from passwords";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                List<DataBaseData> active = new List<DataBaseData>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                      
                        title = reader[1].ToString();
                        user = reader[2].ToString();
                        password = reader[3].ToString();
                        web_address = reader[4].ToString();
                        descryption = reader[5].ToString();
                        Console.WriteLine($"{reader[1].ToString()} and {reader[2].ToString()} and {reader[3].ToString()} and { reader[4].ToString()} and { reader[5].ToString()}");
                        list.Add(new ListViewItem(new String[] { title, user, password, descryption, web_address }));
                        

                    }
                  
                }
                else
                {
                    
                    Console.WriteLine("No rows found");
                }
               
                reader.Close();
                connection.Close();

                return new String[] { title, user, password, descryption, web_address };

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
            return new String[] { title, user, password, descryption, web_address };

        }
        public void ChangeValues(string title, string login="", string password="", string webAddress="", string descryption="")
        {
            SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath);
            connection.Open();
            string sql = @"update passwords where title="+title+"";

            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.Parameters.Add("user", DbType.String).Value = "aka";
            command.Parameters.Add("password", DbType.String).Value = "aka";
            command.Parameters.Add("id", DbType.String).Value = "alsls";
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
        public void AddPassword(string title, string login, string password,string webAddress, string descryption)
        {
            Cryptography cryptography = new Cryptography();
            using (SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath))
            {
                byte []hashPass = cryptography.AESEncryption(password);
                string passwordStr = Encoding.UTF8.GetString(hashPass);
                SQLiteCommand command = new SQLiteCommand("insert into passwords (title,login,password,web_address,description) values (@title, @login, @password, @web,@desc)", connection);
                connection.Open();
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password",passwordStr);
                command.Parameters.AddWithValue("@login",login);
                command.Parameters.AddWithValue("@title",title);
                command.Parameters.AddWithValue("@web",webAddress);
                command.Parameters.AddWithValue("@desc",descryption);
                command.ExecuteScalar();
                Console.WriteLine(command.CommandText);
                connection.Close();

               
            }
        }
        public void ChangeMainPassword(string oldpassword, string newpassword, string type)
        {
            Cryptography c = new Cryptography();
            String hashPassword="";
            if (type == "HMAC")
            {
                hashPassword = c.GenerateHMACString(newpassword);
            }
            if (type == "SHA512")
            {
                hashPassword=c.EncryptSHA512(newpassword);
            }
            Console.WriteLine("Zmienianie hasło");
           
                SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath);
                connection.Open();
            Console.WriteLine("Aktualny user" + userName);
                string sql = "UPDATE user SET password_hash = '"+hashPassword + "' WHERE login = '" + userName + "'";


                SQLiteCommand command = new SQLiteCommand(sql, connection);
                
                command.ExecuteNonQuery();
            Console.WriteLine(command.CommandText.ToString());
                connection.Close();
                Console.WriteLine("Zmieniono hasło");

            

        }
        public void LoginUser(string user, string password,string type)
        {
            Cryptography cryptography = new Cryptography();
            
                using (var sqlite2 = new SQLiteConnection(@"DataSource=" + filePath))
                {
                    sqlite2.Open();

                    string[] result = new string[5];
                    string sql = "select * from user";
                    userName = user;
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                    SQLiteDataReader reader = command.ExecuteReader();
                    String DBLogin = "";
                    while (reader.Read())
                    {
                        result[0] = reader[0].ToString();
                        result[1] = reader[1].ToString();
                        result[2] = reader[2].ToString();


                    }
                    if (type == "HMAC")
                    {
                        Console.WriteLine("HMAAC");

                        String hashPassword = result[2].ToString();

                    String passHMAC = cryptography.GenerateHMACString(hashPassword);
                        Console.WriteLine("Password generate " + passHMAC);
                        String loginDbUSer = result[1].ToString();
                        if (passHMAC == hashPassword && loginDbUSer == user)
                        {
                            UserLogin = true;

                            Console.WriteLine("Logowanie pomyślne");
                            Form1 form1 = new Form1();
                            form1.Close();
                            Form2 form2 = new Form2();
                            form2.Show();
                        }


                    }
                    if (type == "SHA512")
                    {
                        Console.WriteLine("SHA512");
                        String hashPassword = result[2].ToString();
                        String passSHA = cryptography.EncryptSHA512(password);
                        String loginDbUSer = result[1].ToString();
                        if (String.Equals(hashPassword, passSHA) && String.Equals(loginDbUSer, user))
                        {
                            UserLogin = true;

                            Console.WriteLine("Logowanie pomyślne");
                            Form1 form1 = new Form1();
                            form1.Close();
                            Form2 form2 = new Form2();
                            form2.Show();
                        }



                    }
                    else
                    {
                        Console.WriteLine("Logowanie nie udało się");
                    }

                    reader.Close();
                    command.Dispose();



                }
                UserLogin = true;

            

        }
        public void addNewUser(string user, string password, string type)
        {
            UserLogin = true;
            String password_encrypt = "";
            userName = user;
            Cryptography cryptography = new Cryptography();
           
            string byte_password = ""; 
            if (type == "HMAC")
            {
                Console.WriteLine("Password generate " + password);
                byte_password = cryptography.GenerateHMACString(password);
            }
            if(type=="SHA512")
            {
                byte_password = cryptography.EncryptSHA512(password);
            }

            using (SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath))
            {
              
                
                SQLiteCommand command = new SQLiteCommand("insert into user (login, password_hash,salt,isPasswordKeptHash) values (@login, @engWord, @spaWord, @frequency)", connection);
                connection.Open();
                command.Parameters.AddWithValue("@login", user);
                command.Parameters.AddWithValue("@engWord",byte_password);
                command.Parameters.AddWithValue("@spaWord", cryptography.GenerateSalt());
                command.Parameters.AddWithValue("@frequency", false);
              
                var ds=command.ExecuteScalar();
                Console.WriteLine(ds.ToString());
                connection.Close();

                Form4 form4 = new Form4();
                form4.Close();
            }
         


        }
       
    }
}