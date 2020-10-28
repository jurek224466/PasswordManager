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
        
        String pepper = "r226rwf4wro3o23w4ww83i7ii43je44";


        public byte[] EncryptSHA512(string message)
        {

            byte[] data = new byte[100];
            data = Encoding.ASCII.GetBytes(message+pepper);
            byte[] result = null;
            SHA512 hash = new SHA512Managed();
            result = hash.ComputeHash(data);
            return result;
        }
     /*   public  string SHA512Hash(string value)
        {
            byte[] encryptedBytes;

            using (var hashTool = new SHA512Managed())
            {
                encryptedBytes = hashTool.ComputeHash(System.Text.Encoding.UTF8.GetBytes(string.Concat(value)));
                hashTool.Clear();
            }

            return Convert.ToBase64String(encryptedBytes);
        }*/
        public bool CheckHash(string password,byte [] storeHash)
        {
            bool err = false;
            using (SHA512 hmac =SHA512.Create())
            {

                
                byte[] computeHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(password+pepper)); //plus salt
                
                for (int i = 0; i < storeHash.Length; i++)
                {
                    if (storeHash[i] != computeHash[i])
                    {
                        err = true;
                    }
                }
                return err;
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
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(cryptoStream))
                            {
                                writer.WriteLine(textvalue);
                            }
                            encrypted = memoryStream.ToArray();
                        }
                    }
                    return encrypted;
                } 
          
            
            
        } 
    
        public string AESDecryption(byte [] values)
        {
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
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key,aesAlg.IV);
                using (MemoryStream memoryStream = new MemoryStream(values))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            decrypted = reader.ReadToEnd();
                        }
                      
                    }
                }
            }
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

