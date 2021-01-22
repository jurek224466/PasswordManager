using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class AppLogsEvents
    {
        private string exceptionMessage;
       
        public void AddTable(String filePath)
        {
            //filePath = SaveDataBaseFile();
            try
            {
                /* SQLiteConnection.CreateFile(filePath);*/
                /*string cs = @"URI=file:C:\Users\Jurek\test.db";*/
                SQLiteConnection sqlite2 = new SQLiteConnection(@"DataSource=" + filePath);
                sqlite2.Open();
                string sql = @"CREATE TABLE data_base_event (id INTEGER PRIMARY KEY AUTOINCREMENT, id_user VARCHAR(30),
                    );";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                command.ExecuteReader();
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
        public String getLogs(String filePath,String user)
        {


            try
            {

                SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath);

                connection.Open();
                string[] result = new string[7];
                string[] result2 = new string[7];
                string sql = "select * from events where login_name='"+user+"'";
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
                   
                }
                else
                {
                    Console.WriteLine("No rows found");
                    
                }

                connection.Close();



            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
               
            }
            return "ala";
        }
    
    public void addEvent(string user, string function_name, string type, String filePath)
    {
        
       
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"DataSource=" + filePath))
            {

                Console.WriteLine(connection.ConnectionString);
                SQLiteCommand command = new SQLiteCommand("insert into events (function_name,login_name,time,type_event) values (@functionName, @loginName, @time, @type_event)", connection);
                connection.Open();
                DateTime dateTime = DateTime.Now;
                command.Parameters.AddWithValue("@login", user);
                command.Parameters.AddWithValue("@engWord", "Aa");
                command.Parameters.AddWithValue("@spaWord", dateTime);
                command.Parameters.AddWithValue("@frequency", false);
                command.ExecuteScalar();
                connection.Close();
               
                /*  Forms forms= new Forms();
                 forms.Form4Close();*/
            }


        }
        catch (SQLiteException sqlite)
        {
            Console.Error.WriteLine(sqlite.Message);
        }
        catch (Exception exc)
        {
            Console.Error.WriteLine(exc.Message);
        }
    }
    }


}

