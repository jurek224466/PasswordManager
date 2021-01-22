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
        SymmetricAlgorithm encryption;
        public String fileKeyPrivateKey = "keys.db";
        public String pepper = "r226rwf4wro3o23w4ww83i7ii43je44";


        public string EncryptSHA512(string message)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                DataBaseData dataBase = new DataBaseData();
                byte[] sourcecBytes = Encoding.UTF8.GetBytes(message + pepper+dataBase.Salt);
                Console.WriteLine(dataBase.Salt);
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
        
    


        
        public string AESEncryption(string textvalue)
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
   /*     public static void EncryptFile(string filePath, byte[] key)
        {
            string tempFileName = Path.GetTempFileName();

            using (SymmetricAlgorithm cipher = Aes.Create())
            using (FileStream fileStream = File.OpenRead(filePath))
            using (FileStream tempFile = File.Create(tempFileName))
            {
                cipher.Key = key;
                // aes.IV will be automatically populated with a secure random value
                byte[] iv = cipher.IV;

                // Write a marker header so we can identify how to read this file in the future
                tempFile.WriteByte(69);
                tempFile.WriteByte(74);
                tempFile.WriteByte(66);
                tempFile.WriteByte(65);
                tempFile.WriteByte(69);
                tempFile.WriteByte(83);

                tempFile.Write(iv, 0, iv.Length);

                using (var cryptoStream =
                    new CryptoStream(tempFile, cipher.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    fileStream.CopyTo(cryptoStream);
                }
            }

            File.Delete(filePath);
            File.Move(tempFileName, filePath);
        }

        public static void DecryptFile(string filePath, byte[] key)
        {
            string tempFileName = Path.GetTempFileName();

            using (SymmetricAlgorithm cipher = Aes.Create())
            using (FileStream fileStream = File.OpenRead(filePath))
            using (FileStream tempFile = File.Create(tempFileName))
            {
                cipher.Key = key;
                byte[] iv = new byte[cipher.BlockSize / 8];
                byte[] headerBytes = new byte[6];
                int remain = headerBytes.Length;

                while (remain != 0)
                {
                    int read = fileStream.Read(headerBytes, headerBytes.Length - remain, remain);

                    if (read == 0)
                    {
                        throw new EndOfStreamException();
                    }

                    remain -= read;
                }

                if (headerBytes[0] != 69 ||
                    headerBytes[1] != 74 ||
                    headerBytes[2] != 66 ||
                    headerBytes[3] != 65 ||
                    headerBytes[4] != 69 ||
                    headerBytes[5] != 83)
                {
                    throw new InvalidOperationException();
                }

                remain = iv.Length;

                while (remain != 0)
                {
                    int read = fileStream.Read(iv, iv.Length - remain, remain);

                    if (read == 0)
                    {
                        throw new EndOfStreamException();
                    }

                    remain -= read;
                }

                cipher.IV = iv;

                using (var cryptoStream =
                    new CryptoStream(tempFile, cipher.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    fileStream.CopyTo(cryptoStream);
                }
            }

            File.Delete(filePath);
            File.Move(tempFileName, filePath);
        }*/

    }
   

    }

