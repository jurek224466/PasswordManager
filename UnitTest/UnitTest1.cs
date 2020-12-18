﻿using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using PasswordManager;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTest
{
    [TestFixture]
    public class CryptolographyTest
    {

        [DeploymentItem(@"x86\SQLite.Interop.dll", "x86")]
        [DeploymentItem(@"x64\SQLite.Interop.dll", "x64")]
        [TestMethod]
        [TestCase("Ala ma kota")]
        [TestCase("Kot ma psa")]
        public void HMAC(string message)
        {
           /* String message = "ALa ma kota";*/
            Cryptography cryptography = new Cryptography();
            string value1 = cryptography.GenerateHMACString(message);
            string value2 = cryptography.GenerateHMACString(message);
            Assert.AreEqual(value1, value2);

        }

        [TestMethod]
        [TestCase("Ala ma kota", "72227E2717B01EFCA106A7CBC34A82BF")]
        [TestCase ("Ola ma psa", "0D045E3705818080B67E75EC1211CB30")]
        public void TestAESEncrypt(string textvalue,string exceptedValue)
        {
            /*String textvalue = "Ala ma kota";
            String exceptedValue = "72227E2717B01EFCA106A7CBC34A82BF";*/
            Cryptography cryptography = new Cryptography();
            byte[] byteHash = cryptography.AESEncryption(textvalue);
            string hashRel = BitConverter.ToString(byteHash).Replace("-", String.Empty);
            Assert.AreEqual(exceptedValue, hashRel);
        }
        [TestMethod]
        [TestCase("Ala ma kota", "Ala ma kota")]
        [TestCase("Ola ma psa", "Ola ma psa")]
        public void TestAESDecrypt(string value,string result)
        {


            Cryptography cryptography = new Cryptography();
            /*String value = "Ala ma kota i psa";*/
            byte[] encrypt = cryptography.AESEncryption(value);
         /*   String result = cryptography.AESDecryption(encrypt);*/
            Logger.LogMessage("Decrpt value", result);
            Assert.AreEqual(value, result);


        }
        [TestMethod]
        [TestCase("Ala ma kota", "91162629D258A876EE994E9233B2AD87")]
        [TestCase("Ola ma psa", "DEBCE6B45740276FA817E9B88B3611E5")]
        public void MD5Test(string tekst,string excepted)
        {
           /* String excepted = "91162629D258A876EE994E9233B2AD87";
            String tekst = "Ala ma kota";*/
            Cryptography cryptography = new Cryptography();
            byte[] result = cryptography.CreateMD5(tekst);
            string hashRel = BitConverter.ToString(result).Replace("-", String.Empty);
            string finalHash = hashRel.ToUpper();
            Assert.AreEqual(excepted, hashRel);
        }

    }
    [TestClass]
    public class DataBaseTest
    {

        String filePath = @"C:\Users\Jurek\Desktop\PasswordManager\test.db";

        [TestMethod]
        public void GetPasswords()
        {

            DataBase dataBase = new DataBase();
            var dane=dataBase.GetPasswords(filePath);
            Assert.IsNotNull(dane);
           
        }
        

        [TestMethod]
          public void GetDataBaseFile()
          {
            
           DataBase dataBase = new DataBase();
           dataBase.GetDataBaseFile(filePath);
           

          }
        [TestMethod]
        public void GetUserData()
        {

            DataBase dataBase = new DataBase();
           bool test= dataBase.GetUserData(filePath);
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void CreateDatabase()
        {
           
            DataBase dataBase = new DataBase();
            bool check=dataBase.CreateDataBaseFile(filePath);
            Assert.IsTrue(check);

        }
        [TestMethod]
        public void ChangeValue()
        {

             DataBase dataBase = new DataBase();
            string result=dataBase.ChangeValues("tytul", filePath, "user", "pass", "http://google.com", "Opis ogolnie");
            Assert.IsNotNull(result);
           
        }
        [TestMethod]
        public void ChangeMainPassword()
        {
         
            DataBase dataBase = new DataBase();
            bool result=dataBase.ChangeMainPassword("old", "new", "HMAC",filePath);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LoginUser()
        {
            
            DataBase dataBase = new DataBase();
            bool login=dataBase.LoginUser("test", "test", "HMAC",filePath);
            Assert.IsTrue(login);
        }
        [TestMethod]
        public void AddNewUser()
        {

            DataBase dataBase = new DataBase();
            bool test=dataBase.addNewUser("user", "pass", "HMAC", filePath);
            Assert.IsTrue(test);

        }
        [TestMethod]
        public void AddPassword()
        {
            DataBase dataBase = new DataBase();
            bool result=dataBase.AddPassword("Facebook", "test", "ala", "http://facebook.com", "facebook", filePath);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
        }
      

    }

}