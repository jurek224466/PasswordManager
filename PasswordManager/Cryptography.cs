using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PasswordManager
{
    public class Cryptography
    {


        private byte[] IV = new byte[16];
        private byte[] Key = new byte[32];
        String IVStr = "Hsifp85WXkRzgorV";

        public String pepper = "r226rwf4wro3o23w4ww83i7ii43je44";


        public string EncryptSHA512(string message)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] sourcecBytes = Encoding.UTF8.GetBytes(message + pepper);
                byte[] hashBytes = sha512.ComputeHash(sourcecBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }


        }

        public string GenerateHMACString(string inputString)
        {
            string secret_key = "A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=";
            var secretKeyByteArray = Convert.FromBase64String(secret_key);
            using (HMAC hmac = new HMACSHA256(secretKeyByteArray))
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(inputString);
                byte[] hashBytes = hmac.ComputeHash(sourceBytes);
                string hash = Convert.ToBase64String(hashBytes);
                return hash;

            }
        }
        
    


        
        public byte[] AESEncryption(string textvalue)
        {

            IV = Encoding.ASCII.GetBytes(IVStr);
            Key = GenerateSecreteKey();
            byte[] encrypted= new byte[100];
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
                    
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(Key,IV);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(cryptoStream))
                            {
                                writer.WriteLine(textvalue);
                            }
                            encrypted = memoryStream.ToArray();
                        return encrypted;
                    }
                    }
                   
                } 
          
            
            
        } 
    
        public string AESDecryption(byte [] values)
        {

            IV = Encoding.ASCII.GetBytes(IVStr);
            String descrypt = "";
            Key = GenerateSecreteKey();
            if (values== null || values.Length <= 0)
                throw new ArgumentException("Brak wiadomości do zaszyfrowania");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentException("Key Exception");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentException("IV Exception");
            String decrypted=null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GenerateSecreteKey();
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(Key,IV);
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
            decrypted= descrypt.Replace("\r\n", string.Empty);
            return decrypted;

        }
        public byte [] CreateMD5(String input)
        {
            byte[] hashBytes;
            using (MD5 md5=MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                hashBytes = md5.ComputeHash(inputBytes);
            }
            return hashBytes;
        }
        public byte [] GenerateSecreteKey()
        {
            String KeyStr = "XNQdnInU5pY6EoKyP9n04ZnrP2BkoTZt";
            byte[] secretKey = CreateMD5(KeyStr);
            return secretKey;
        }
        public string GenerateSalt()
        {
            Guid guid = Guid.NewGuid();
            string result = guid.ToString();
            return result;
        }
    }
   

    }

