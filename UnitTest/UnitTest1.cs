using System;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
namespace UnitTest
{
    [TestClass]
    public class CryptolographyTest
    {
       
 
        public byte [] TestAESEncrypt(string textvalue)
        {
           Cryptography cryptography = new Cryptography();
           return  cryptography.AESEncryption("Ala ma kota");
        }
        [TestMethod]
        public void TestAESDecrypt()
        {
            String Exspected = "Ala ma kota";
            Cryptography cryptography = new Cryptography();
            String valuesString = "";
            byte [] values =TestAESEncrypt(Exspected);
            valuesString = cryptography.AESDecryption(values);
           
        }
        [TestMethod]
        public void SaveDataBaseTest()
        {
            DataBase database = new DataBase();
        }
        [TestMethod]
        public void GetDataBaseText()
        {

            DataBase dataBase = new DataBase();
        }
    }
}
