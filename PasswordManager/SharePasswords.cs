using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class SharePasswords
    {

        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(4096);
        private byte[] IV = new byte[16];
        private byte[] Key = new byte[32];
        String IVStr = "Hsifp85WXkRzgorV";
        private string exceptionMessage;

        public int Id { get; private set; }
        /*   private static string GenerateTestString()
   {
       Guid opportinityId = Guid.NewGuid();
       Guid systemUserId = Guid.NewGuid();
       string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

       StringBuilder sb = new StringBuilder();
       sb.AppendFormat("opportunityid={0}", opportinityId.ToString());
       sb.AppendFormat("&systemuserid={0}", systemUserId.ToString());
       sb.AppendFormat("&currenttime={0}", currentTime);

       return sb.ToString();
   }*/
        public static string GetKeyString(RSAParameters publicKey)
        {

            var stringWriter = new System.IO.StringWriter();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, publicKey);
            return stringWriter.ToString();
        }
        public static string Encrypt(string textToEncrypt, string publicKeyString)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);

            using (var rsa = new RSACryptoServiceProvider(4096))
            {
                try
                {
                    rsa.FromXmlString(publicKeyString.ToString());
                    var encryptedData = rsa.Encrypt(bytesToEncrypt, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string Decrypt(string textToDecrypt, string privateKeyString)
        {
            var bytesToDescrypt = Encoding.UTF8.GetBytes(textToDecrypt);

            using (var rsa = new RSACryptoServiceProvider(4096))
            {
                try
                {

                    // server decrypting data with private key                    
                    rsa.FromXmlString(privateKeyString);

                    var resultBytes = Convert.FromBase64String(textToDecrypt);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        public string AESEncryption(string textvalue)
        {

            IV = Encoding.ASCII.GetBytes(IVStr);
            Key = GenerateSecreteKey();
            byte[] encrypted = new byte[100];
            if (textvalue == null || textvalue.Length <= 0)
                throw new ArgumentException("Brak wiadomości do zaszyfrowania");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentException("Key Exception");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentException("IV Exception");
            Console.WriteLine("Key" + Key);
            Console.WriteLine("IV" + IV);
            using (Aes aesAlg = Aes.Create())
            {

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(Key, IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.WriteLine(textvalue);
                        }
                        encrypted = memoryStream.ToArray();
                        return Convert.ToBase64String(encrypted);
                    }
                }

            }



        }

        public string AESDecryption(string encrypt)
        {
            byte[] values = Convert.FromBase64String(encrypt);
            IV = Encoding.ASCII.GetBytes(IVStr);
            String descrypt = "";
            Key = GenerateSecreteKey();
            if (values == null || values.Length <= 0)
                throw new ArgumentException("Brak wiadomości do zaszyfrowania");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentException("Key Exception");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentException("IV Exception");
            String decrypted = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GenerateSecreteKey();
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(Key, IV);
                using (MemoryStream memoryStream = new MemoryStream(values))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            descrypt = reader.ReadToEnd();
                        }

                    }
                }

            }
            decrypted = descrypt.Replace("\r\n", string.Empty);
            return decrypted;

        }
        public byte[] GenerateSecreteKey()
        {
            String KeyStr = "XNQdnInU5pY6EoKyP9n04ZnrP2BkoTZt";
            byte[] secretKey = CreateMD5(KeyStr);
            return secretKey;
        }
        public byte[] CreateMD5(String input)
        {
            byte[] hashBytes;
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                hashBytes = md5.ComputeHash(inputBytes);
            }
            return hashBytes;
        }
        /*public void encryptdataBase()
        {
            //filePath = SaveDataBaseFile();
            try
            {
                SQLiteConnection.CreateFile(filePath);
                string cs = @"URI=file:C:\Users\Jurek\test.db";
                SqliteConnection sqlite2 = new SqliteConnection();
                sqlite2.Open();
                string sql = @"CREATE TABLE user (id INTEGER PRIMARY KEY AUTOINCREMENT, login VARCHAR(30),
            password_hash VARCHAR(512), salt VARCHAR(20), isPasswordKeptHash BOOLEAN);";
                SQLiteCommand command = new SQLiteCommand(sql);
                command.ExecuteReader();
                command.Dispose();
                string sql2 = @"CREATE TABLE passwords (id INTEGER PRIMARY KEY AUTOINCREMENT, title VARCHAR(256),
            login VARCHAR(256),password VARCHAR(256),web_address VARCHAR(256),description VARCHAR(256));";
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
               
        }*/
    

    }

}

