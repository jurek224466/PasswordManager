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

namespace PasswordManager
{
    public class DataBase
    {
        SaveFileDialog saveFile = new SaveFileDialog();
        String exceptionMessage = "";
        String filePath;
        public Boolean UserLogin = false;
        public int Version { get; private set; }

        public void CreateDataBaseFile()
        {
            filePath = SaveDataBaseFile();
            try
            {
                /* SQLiteConnection.CreateFile(filePath);*/
                /*string cs = @"URI=file:C:\Users\Jurek\test.db";*/
                SQLiteConnection sqlite2 = new SQLiteConnection(@"DataSource="+filePath);
                sqlite2.Open();
                string sql = @"CREATE TABLE user(id INTEGER PRIMARY KEY, login VARCHAR(30),
                    password_hash VARCHAR(512), salt VARCHAR(20), isPasswordKeptHash BOOLEAN);";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                command.ExecuteReader();
                command.Dispose();
                string sql2 = @"CREATE TABLE password(id INTEGER PRIMARY KEY, password VARCHAR(256),
                    id_user INTEGER,web_address VARCHAR(256),description VARCHAR(256),login VARCHAR(30));";
                SQLiteCommand command2 = new SQLiteCommand(sql2, sqlite2);
                command2.ExecuteReader();
                command2.Dispose();
                sqlite2.Close();
            }catch(SQLiteException e)
            {
                exceptionMessage = e.Message;
            }
        }
        private string SaveDataBaseFile()
        {
            String filename = null;
            String filePath = null;
            String extension = null;
            
            saveFile.Filter = "DataBase file | *.db";
            saveFile.DefaultExt = "db";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                filename = saveFile.FileName;
                filePath = Path.GetFullPath(saveFile.FileName);
                
            }
            return filePath;
        }
        private string OpenDataBaseFile()
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
            string filePath = OpenDataBaseFile();
          
        
            
            using (var sqlite2 = new SQLiteConnection(@"DataSource="+filePath))
            {
                sqlite2.Open();
                string[] result = new string[3];
                string sql = "select * from user";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result[0] = reader[0].ToString();
                    result[1] = reader[1].ToString();
                    result[2] = reader[2].ToString();
                    result[3] = reader[3].ToString();
                    result[4] = reader[4].ToString();
                    result[5] = reader[5].ToString();
                }
                reader.Close();
                command.Dispose();
                for(int i = 0; i <= 2; i++)
                {
                    Console.WriteLine("Result: " + i +" "+ result[i]);
                }
               
                
            }
        }
        public void GetUserData()
        {
            using (var sqlite2 = new SQLiteConnection(@"DataSource=" + filePath))
            {
                sqlite2.Open();
                string[] result = new string[3];
                string sql = "select * from user";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result[0] = reader[0].ToString();
                    result[1] = reader[1].ToString();
                    result[2] = reader[2].ToString();
                    result[3] = reader[3].ToString();
                    result[4] = reader[4].ToString();
                    result[5] = reader[5].ToString();
                }
                reader.Close();
                command.Dispose();
                for (int i = 0; i <= 2; i++)
                {
                    Console.WriteLine("Result: " + i + " " + result[i]);
                }


            }
        }
        public void GetPasswords()
        {
            using (var sqlite2 = new SQLiteConnection(@"DataSource=" + filePath))
            {
                sqlite2.Open();
                string[] result = new string[3];
                string sql = "select * from user";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result[0] = reader[0].ToString();
                    result[1] = reader[1].ToString();
                    result[2] = reader[2].ToString();
                    result[3] = reader[3].ToString();
                    result[4] = reader[4].ToString();
                    result[5] = reader[5].ToString();
                }
                reader.Close();
                command.Dispose();
                for (int i = 0; i <= 2; i++)
                {
                    Console.WriteLine("Result: " + i + " " + result[i]);
                }


            }
        }
        public void ChangeValues()
        {
            SQLiteConnection sqlite2 = new SQLiteConnection(@"DataSource=" + filePath);
            sqlite2.Open();
            string sql = @"CREATE TABLE user(id INTEGER PRIMARY KEY, login VARCHAR(30),
                    password_hash VARCHAR(512), salt VARCHAR(20), isPasswordKeptHash BOOLEAN);";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
            command.ExecuteReader();
            command.Dispose();
        }
        public void ChangeMainPassword()
        {
            SQLiteConnection sqlite2 = new SQLiteConnection(@"DataSource=" + filePath);
            sqlite2.Open();
            string sql = @"update user where password;";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
            
            command.Dispose();
        }
        public void ChangeEditPassword()
        {

        }


                   
        }
    }
