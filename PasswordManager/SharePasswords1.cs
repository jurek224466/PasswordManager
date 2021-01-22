using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
   public class SharePasswords
    {

    
        private long id;
        private String owner;
        private String consumer;
        private DateTime date;
        private bool editableBidirectional;
        private String title;
        private String webAddress;
        private String description;
        private String login;
        private String password;
        private string exceptionMessage;


        public SharePasswords(long id, string owner, string consumer, DateTime date, bool editableBidirectional, string title, string webAddress, string description, string login, string password)
        {
            this.id = id;
            this.owner = owner;
            this.consumer = consumer;
            this.date = date;
            this.editableBidirectional = editableBidirectional;
            this.title = title;
            this.webAddress = webAddress;
            this.description = description;
            this.login = login;
            this.password = password;
        }
        public SharePasswords()
        {

        }

        public long Id { get => id; set => id = value; }
        public string Owner { get => owner; set => owner = value; }
        public string Consumer { get => consumer; set => consumer = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool EditableBidirectional { get => editableBidirectional; set => editableBidirectional = value; }
        public string Title { get => title; set => title = value; }
        public string WebAddress { get => webAddress; set => webAddress = value; }
        public string Description { get => description; set => description = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

        public void SharePassword()
        {

        }
        public void AddPassword(String filePath,String login,String password,String webAddress,String description,DateTime Date,String consumer,Boolean editableBidirectional,String title)
        {
           
            String password_encrypt = "";
          

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath))
                {
                    /*ShareForm shareForm = new ShareForm();
                    shareForm.ShowDialog();*/
                    Console.WriteLine(connection.ConnectionString);
                    DataBase dataBase = new DataBase();
                    SQLiteCommand command = new SQLiteCommand("insert into share_password (login,password,title,description,date,webAddress,owner,consumer,edit) values (?,?,?,?,?,?,?,?,?)", connection);
                    connection.Open();
                    String owner = DataBase.userName;
                  /*  command.Parameters.AddWithValue("@id", id);*/
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@descripion", description);
                    command.Parameters.AddWithValue("@date", Date);
                    command.Parameters.AddWithValue("@webAddress",webAddress);
                    command.Parameters.AddWithValue("@owner",DataBase.loginCurrentUser);
                    command.Parameters.AddWithValue("@consumer", consumer);
                    command.Parameters.AddWithValue("@editable", editableBidirectional);
                    command.ExecuteScalar();
                    connection.Close();
                   
                    /*  Forms forms= new Forms();
                     forms.Form4Close();*/
                }


            }
            catch (SqliteException sqlite)
            {
                Console.Error.WriteLine(sqlite.Message);
            }
           /* catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
            }*/
        }

        public void CreateDataBaseShare(String filePath)
        {
            //filePath = SaveDataBaseFile();
            try
            {
                /* SQLiteConnection.CreateFile(filePath);*/
               
                SQLiteConnection sqlite2 = new SQLiteConnection(@"DataSource=" + filePath);
                sqlite2.Open();
               
                string sql2 = @"CREATE TABLE if not exists share_password (id INTEGER PRIMARY KEY AUTOINCREMENT, login VARCHAR(256),password VARCHAR(256),title VARCHAR(256),
                    description VARCHAR(256),date VARCHAR(256),webAddress VARCHAR(256),owner VARCHAR(256),consumer VARCHAR(256),edit boolean);";
                SQLiteCommand command2 = new SQLiteCommand(sql2, sqlite2);
                command2.ExecuteReader();
                command2.Dispose();
                sqlite2.Close();
              

            }
            catch (SQLiteException e)
            {
                exceptionMessage = e.Message;
                

            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
                
            }
        }
        public void deleteSharePassword(int id, String owner, String editable,String filePath)
        {
            //filePath = SaveDataBaseFile();
            try
            {
                /* SQLiteConnection.CreateFile(filePath);*/
                /*string cs = @"URI=file:C:\Users\Jurek\test.db";*/
                SQLiteConnection sqlite2 = new SQLiteConnection(@"DataSource=" + filePath);
                sqlite2.Open();

                string sql2 = @"delete from share_password where id='" + id + "' and owner='" + owner + "'";
                SQLiteCommand command2 = new SQLiteCommand(sql2, sqlite2);
                command2.ExecuteReader();
                command2.Dispose();
                sqlite2.Close();


            }
            catch (SQLiteException e)
            {
                exceptionMessage = e.Message;


            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;

            }
        }

        public string[] GetSharedPasswords(String filePath = "")
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
                string sql = "select * from passwords where consumer='" + DataBase.loginCurrentUser + "'";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                /*   command.Parameters.AddWithValue("@login", user);*/
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



    }



}


