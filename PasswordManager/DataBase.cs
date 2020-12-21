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
       
        String exceptionMessage = "";
        public List<ListViewItem> list = new List<ListViewItem>();
      /* public static String filePath { get; set; }*/
        public Boolean UserLogin = false;
        static String userName { get; set; }
        static byte[] encryptPass { get; set; }
        public int Version { get; private set; }

        public bool CreateDataBaseFile(String filePath)
        {
            //filePath = SaveDataBaseFile();
            try
            {
                /* SQLiteConnection.CreateFile(filePath);*/
                /*string cs = @"URI=file:C:\Users\Jurek\test.db";*/
                SQLiteConnection sqlite2 = new SQLiteConnection(@"DataSource=" + filePath);
                sqlite2.Open();
                string sql = @"CREATE TABLE user (id INTEGER PRIMARY KEY AUTOINCREMENT, login VARCHAR(30),
                    password_hash VARCHAR(512), salt VARCHAR(20), isPasswordKeptHash BOOLEAN);";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                command.ExecuteReader();
                /*command.Dispose();*/
                string sql2 = @"CREATE TABLE passwords (id INTEGER PRIMARY KEY AUTOINCREMENT, title VARCHAR(256),
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
                return true;
                
            }catch(Exception ex)
            {
                exceptionMessage = ex.Message;
                return true;
            }
        }
      
       
        public void GetDataBaseFile(String filePath)
        {
            try
            {
               // string filePath = OpenDataBaseFile();
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
        public bool GetUserData(String filePath)
        {
            try
            {

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

                        DataBaseData dataBaseData = new DataBaseData();
                        dataBaseData.UserName = reader[1].ToString();
                        dataBaseData.Password = reader[2].ToString();
                        dataBaseData.Salt = reader[3].ToString();
                        active.Add(dataBaseData);
                        Console.WriteLine($"{reader[1].ToString()} and {reader[2].ToString()} and {reader[3].ToString()}");


                    }
                    reader.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("No rows found");
                    return false;
                }
               
                connection.Close();



            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
                return false;
            }
        }
        public string [] GetPasswords(String filePath="")
        {
            String title = "";
            String user = "";
            String password = "";
            String web_address = "";
            String descryption = "";
            List<String> lista = new List<string>();
            try
            {
               
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
                        string strippedString = new string(password.Where(c => c <= sbyte.MaxValue).ToArray());
                        Console.WriteLine($"{title} and {user} and {strippedString} and {web_address} and {descryption}");
                        list.Add(new ListViewItem(new String[] { title, user, strippedString + "\\\u00B9", descryption, web_address }));


                    }
                  
                }
                else
                {
                    
                    Console.WriteLine("No rows found");
                }
                if (reader.Read() == null)
                {
                    Console.WriteLine("Null data");
                    return null;
                }
               
                reader.Close();
                connection.Close();

                return new String[] { title, user, password, descryption, web_address };

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
                return null;
            }
            return new String[] { title, user, password, descryption, web_address };

        }
        public String  ChangeValues(string title, String filePath="",string login="", string password="", string webAddress="", string descryption="")
        {
            String commandString = "";
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + filePath);
            connection.Open();
            /* string sql = @"update passwords where title=" + title + "" ";*/
            try
            {
                string sql = "UPDATE passwords SET login = @login, password = @password,web_address=@web,description=@desc Where title = @title";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@web", webAddress);
                command.Parameters.AddWithValue("@desc", descryption);
                commandString=command.CommandText;
                command.ExecuteNonQuery();
            }
            catch (SQLiteException sqlite)
            {
                Console.Error.WriteLine(sqlite.Message);
                commandString = "";
                return commandString;
            }
            catch(Exception exp)
            {
                Console.Error.WriteLine(exp.Message);
                commandString = "";
                return commandString;
            }
            return commandString;
            connection.Close();
        }
        public bool AddPassword(string title, string login, string password,string webAddress, string descryption,String filePath="")
        {
            Cryptography cryptography = new Cryptography();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath))
                {
                    string hashPass = cryptography.AESEncryption(password);
                    /*string passwordStr = Encoding.ASCII.GetString(hashPass);*/
                    SQLiteCommand command = new SQLiteCommand("insert into passwords (title,login,password,web_address,description) values (@title, @login, @password, @web,@desc)", connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@login", login);
                    /* command.Parameters.AddWithValue("@password", passwordStr);*/
                    command.Parameters.AddWithValue("@password", hashPass);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@web", webAddress);
                    command.Parameters.AddWithValue("@desc", descryption);
                    command.ExecuteScalar();
                    Console.WriteLine(command.CommandText);
                    /*  connection.Close();*/

                    return true;
                }
            }catch(SqliteException sqlite)
            {
                return false;
            }
            catch(Exception excpe)
            {
                return false;
            }
        }
        public bool ChangeMainPassword(string oldpassword, string newpassword, string type,String filePath="")
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
            try
            {
                SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath);
                connection.Open();
                Console.WriteLine("Aktualny user" + userName);
                string sql = "UPDATE user SET password_hash = '" + hashPassword + "' WHERE login = '" + userName + "'";


                SQLiteCommand command = new SQLiteCommand(sql, connection);

                command.ExecuteNonQuery();
                Console.WriteLine(command.CommandText.ToString());
                /* connection.Close();*/
                Console.WriteLine("Zmieniono hasło");
                return true;
            }catch(SqliteException sqlite)
            {
                return false;
            }
            catch(Exception exc)
            {
                return false;
            }
            

        }
        public bool LoginUser(string user, string password,string type,String filePath)
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
                        Console.WriteLine("HMAC");


                    String hashPassword = result[2].ToString();
                    String passHMAC = cryptography.GenerateHMACString(password);
                    String loginDbUSer = result[1].ToString();
                    Console.WriteLine("Passwords: form: " + passHMAC +"and database:  "+hashPassword);

                    if (String.Equals(hashPassword, passHMAC) && String.Equals(loginDbUSer, user) && user!=null && password!=null)
                    {
                        UserLogin = true;

                        Console.WriteLine("Logowanie pomyślne HMAC");
                
                    }
                    else
                    {
                        Console.WriteLine("Logowanie nieudane HMAC");
                        UserLogin = false;
                    }


                }   else if (type == "SHA512")
                    {
                        Console.WriteLine("SHA512");
                        String hashPassword = result[2].ToString();
                        String passSHA = cryptography.EncryptSHA512(password);
                        String loginDbUSer = result[1].ToString();
                        if (String.Equals(hashPassword, passSHA) && String.Equals(loginDbUSer, user) && user != null && password != null)
                        {
                            UserLogin = true;
                        Console.WriteLine("Logowanie pomyślne SHA512");
                          
                        }



                    }
                    else
                    {
                     Console.WriteLine("Logowanie nie udało się SHA512");
                    UserLogin = false;
                    }

                    reader.Close();
                    command.Dispose();



            }
              
            return UserLogin;

            

        }
        public bool addNewUser(string user, string password, string type, String filePath)
        {
            UserLogin = true;
            String password_encrypt = "";
            userName = user;
            Cryptography cryptography = new Cryptography();

            string byte_password = "";
            if (type == "HMAC")
            {

                byte_password = cryptography.GenerateHMACString(password);
                Console.WriteLine("HMAc" + byte_password);
            }
            if (type == "SHA512")
            {
                byte_password = cryptography.EncryptSHA512(password);
            }

            try {
                using (SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath))
                {

                    Console.WriteLine(connection.ConnectionString);
                    SQLiteCommand command = new SQLiteCommand("insert into user (login, password_hash,salt,isPasswordKeptHash) values (@login, @engWord, @spaWord, @frequency)", connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@login", user);
                    command.Parameters.AddWithValue("@engWord", byte_password);
                    command.Parameters.AddWithValue("@spaWord", cryptography.GenerateSalt());
                    command.Parameters.AddWithValue("@frequency", false);
                    command.ExecuteScalar();
                    connection.Close();
                    return true;
                    /*  Forms forms= new Forms();
                     forms.Form4Close();*/
                }


            }catch(SqliteException sqlite)
            {
                return false;
            }
            catch(Exception exc)
            {
                return false;
            }
            }
       

    }
   }

