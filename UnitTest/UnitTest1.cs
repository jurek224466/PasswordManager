using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using PasswordManager;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest
{
    [TestClass]
    public class CryptolographyTest
    {
        [TestMethod]

        public void HMAC()
        {
            String message = "ALa ma kota";
            Cryptography cryptography = new Cryptography();
            string value1 = cryptography.GenerateHMACString(message);
            string value2 = cryptography.GenerateHMACString(message);
           Assert.AreEqual(value1, value2);

        }

        [TestMethod]
        
        public void TestAESEncrypt()
        {
            String textvalue = "Ala ma kota";
            String exceptedValue = "72227E2717B01EFCA106A7CBC34A82BF"; 
           Cryptography cryptography = new Cryptography();
           byte [] byteHash=cryptography.AESEncryption(textvalue);
            string hashRel = BitConverter.ToString(byteHash).Replace("-", String.Empty);
            Assert.AreEqual(exceptedValue,hashRel);
        }
        [TestMethod]
        
        public void TestAESDecrypt()
        {
           

            Cryptography cryptography = new Cryptography();
            String value = "Ala ma kota i psa";
            byte[] encrypt = cryptography.AESEncryption(value);
            String result = cryptography.AESDecryption(encrypt);
            Logger.LogMessage("Decrpt value",result);
            Assert.AreEqual(value, result);
           

        }
        [TestMethod]
        public void MD5Test()
        {
            String excepted = "91162629D258A876EE994E9233B2AD87";
            String tekst = "Ala ma kota";
            Cryptography cryptography = new Cryptography();
            byte [] result=cryptography.CreateMD5(tekst);
            string hashRel = BitConverter.ToString(result).Replace("-", String.Empty);
            string finalHash = hashRel.ToUpper();
            Assert.AreEqual(excepted, hashRel);
        }




        [TestMethod]
        public void CreateDataBase()
        {
            DataBase dataBase = new DataBase();
            bool fdf = dataBase.CreateDataBaseFile();
            Assert.IsTrue(fdf);
        }
        [TestMethod]
        public void OpenDataBaseFile()
        {
            DataBase dataBase = new DataBase();
            string val = dataBase.OpenDataBaseFile();
            Assert.IsNotNull(val);
        }
        [TestMethod]
        public void SaveDataBaseFile()
        {
            DataBase dataBase = new DataBase();
            DataBase.filePath = ":memory:";
            string val = dataBase.SaveDataBaseFile();
            Assert.IsNotNull(val);
        }

    }
}
