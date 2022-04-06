using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FPCrypt.cryptoUtils.Tests
{
    [TestClass()]
    public class CipherToolTests
    {

        private CipherTool cipherTool;
        private string password, fileName, emptyFileName, plainText;
        private Exception expectedExcetpion;

        [TestInitialize]
        public void Setup()
        {
            cipherTool = new CipherTool();
            password = null;
            fileName = "../../../CryptoUtils/DummyFile.txt";
            emptyFileName = "../../../CryptoUtils/EmptyFile.txt";
            plainText = null;
            expectedExcetpion = null;
        }


        [TestMethod()]
        public void EncryptFileTestCorrectFile()
        {
            password = "wonderful password 987";
            plainText = File.ReadAllText(fileName);
            cipherTool.EncryptFile(fileName, password);
            string cipherText = File.ReadAllText(fileName);
            Assert.IsNotNull(plainText, "Readed plaint text should not be null");
            Assert.IsNotNull(cipherText, "Resulted cipher text cannot be null");
            Assert.AreNotEqual(plainText, cipherText, "Both text should not be the same");
        }

        [TestMethod()]
        public void EncryptFileTestIncorrectFile()
        {
            fileName = "NonExistingFile.notexists";
            password = "wonderful password 987";
            try
            {
                cipherTool.EncryptFile(fileName, password);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion, "We should catch a file exception");
            Assert.AreEqual("File: '" + fileName + "' not found", expectedExcetpion.Message,
                "Messages should match");
        }

        [TestMethod()]
        public void EncryptFileTestNullFile()
        {
            fileName = null;
            password = "wonderful password 987";
            try
            {
                cipherTool.EncryptFile(fileName, password);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion, "We should catch invalidParams exception");
            Assert.AreEqual("Value cannot be null. (Parameter 'File name')", expectedExcetpion.Message, 
                "Both messages should match");
        }

        [TestMethod()]
        public void EncryptFileTestEmptyFile()
        {
            password = "wonderful password 987";
            try
            {
                cipherTool.EncryptFile(emptyFileName, password);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion, "We should catch invalidFormatFile exception");
            Assert.AreEqual("File cannot be empty", expectedExcetpion.Message, "Both messages should match");
        }

        [TestMethod()]
        public void EncryptFileTestNullPassword()
        {
            try
            {
                cipherTool.EncryptFile(fileName, password);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion, "We should catch invalidParams exception");
            Assert.AreEqual("Value cannot be null. (Parameter 'Fingerprint')", expectedExcetpion.Message,
                "Both messages should match");
        }

        [TestMethod()]
        public void DecryptFileTestCorrectFile()
        {
            password = "WonderFul password m8";
            plainText = File.ReadAllText(fileName);
            cipherTool.EncryptFile(fileName, password);
            string cipherText = File.ReadAllText(fileName);
            cipherTool.DecryptFile(fileName, password);
            string plainText2 = File.ReadAllText(fileName);
            Assert.AreEqual(plainText, plainText2, "Both files should be the same");
        }

        [TestMethod()]
        public void DecryptFileTestIncorrectFile()
        {
            password = "WonderFul password m8";
            try
            {
                cipherTool.DecryptFile(fileName, password);
            } catch(Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion, "We should catch NotSupported exception");
            Assert.AreEqual("File cannot be decrypted", expectedExcetpion.Message,
                "Both messages should match");

        }

        [TestMethod()]
        public void DecryptFileTestIncorrectPassword()
        {
            password = "WonderFul password m8";
            cipherTool.EncryptFile(fileName, password);
            try
            {
                cipherTool.DecryptFile(fileName, "Non valid password");
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion, "We should catch NotSupported exception");
            Assert.AreEqual("Fingerprints do not match", expectedExcetpion.Message,
                "Both messages should match");

        }
    }
}