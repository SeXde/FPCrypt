using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FPCrypt.cryptoUtils.Tests
{
    [TestClass()]
    public class CipherToolTests
    {

        private CipherTool cipherTool;
        private string password, fileName, emptyFileName, plainText, newFileName, path;
        private Exception expectedException;

        [TestInitialize]
        public void Setup()
        {
            cipherTool = CipherTool.GetInstance();
            password = "WonderFul password m8";
            path = "../../../CryptoUtils/";
            fileName = path + "DummyFile.txt";
            newFileName = path + "DummyFile.fpc";
            emptyFileName = path + "EmptyFile.txt";
            plainText = null;
            expectedException = null;
        }


        [TestMethod()]
        public void EncryptFileTestCorrectFile()
        {
            plainText = File.ReadAllText(fileName);
            cipherTool.EncryptFile(fileName, password);
            string cipherText = File.ReadAllText(newFileName);
            Assert.IsNotNull(plainText, "Readed plaint text should not be null");
            Assert.IsNotNull(cipherText, "Resulted cipher text cannot be null");
            Assert.AreNotEqual(plainText, cipherText, "Both text should not be the same");
            cipherTool.DecryptFile(newFileName, password);
        }


        [TestMethod()]
        public void EncryptFileTestIncorrectFile()
        {
            fileName = "NonExistingFile.notexists";
            try
            {
                cipherTool.EncryptFile(fileName, password);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsNotNull(expectedException, "We should catch a file format exception");
            Assert.AreEqual("File: '" + fileName + "' not found", expectedException.Message,
                "Messages should match");
        }


        [TestMethod()]
        public void EncryptFileTestCipherFile()
        {
            cipherTool.EncryptFile(fileName, password);
            try
            {
                cipherTool.EncryptFile(newFileName, password);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            cipherTool.DecryptFile(newFileName, password);
            Assert.IsNotNull(expectedException, "We should catch a file format exception");
            Assert.AreEqual("File is already cipher", expectedException.Message,
                "Messages should match");
        }


        [TestMethod()]
        public void EncryptFileTestNullFile()
        {
            fileName = null;
            try
            {
                cipherTool.EncryptFile(fileName, password);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsNotNull(expectedException, "We should catch invalidParams exception");
            Assert.AreEqual("Value cannot be null. (Parameter 'File name')", expectedException.Message, 
                "Both messages should match");
        }


        [TestMethod()]
        public void EncryptFileTestEmptyFile()
        {
            try
            {
                cipherTool.EncryptFile(emptyFileName, password);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsNotNull(expectedException, "We should catch invalidFormatFile exception");
            Assert.AreEqual("File cannot be empty", expectedException.Message, "Both messages should match");
        }


        [TestMethod()]
        public void EncryptFileTestNullPassword()
        {
            try
            {
                cipherTool.EncryptFile(fileName, null);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsNotNull(expectedException, "We should catch invalidParams exception");
            Assert.AreEqual("Value cannot be null. (Parameter 'Fingerprint')", expectedException.Message,
                "Both messages should match");
        }


        [TestMethod()]
        public void DecryptFileTestCorrectFile()
        {
            plainText = File.ReadAllText(fileName);
            cipherTool.EncryptFile(fileName, password);
            string cipherText = File.ReadAllText(newFileName);
            cipherTool.DecryptFile(newFileName, password);
            string plainText2 = File.ReadAllText(fileName);
            Assert.AreEqual(plainText, plainText2, "Both files should be the same");
        }


        [TestMethod()]
        public void DecryptFileTestIncorrectFile()
        {
            try
            {
                cipherTool.DecryptFile(fileName, password);
            } catch(Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsNotNull(expectedException, "We should catch NotSupported exception");
            Assert.AreEqual("File cannot be decrypted, beacuse it hasn't been encrypted", expectedException.Message,
                "Both messages should match");
        }


        [TestMethod()]
        public void DecryptFileTestIncorrectPassword()
        {
            cipherTool.EncryptFile(fileName, password);
            try
            {
                cipherTool.DecryptFile(newFileName, "Non valid password");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            cipherTool.DecryptFile(newFileName, password);
            Assert.IsNotNull(expectedException, "We should catch NotSupported exception");
            Assert.AreEqual("Fingerprints do not match", expectedException.Message,
                "Both messages should match");

        }


        [TestMethod()]
        public void DecryptFileTestDecryptedFile()
        {
            cipherTool.EncryptFile(fileName, password);
            cipherTool.DecryptFile(newFileName, password);
            try
            {
                cipherTool.DecryptFile(fileName, password);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsNotNull(expectedException, "We should catch NotSupported exception");
            Assert.AreEqual("File cannot be decrypted, beacuse it hasn't been encrypted", expectedException.Message,
                "Both messages should match");

        }


        [TestMethod()]
        public void DecryptFileTestDecryptedTwoTimesFile()
        {
            string originalText = File.ReadAllText(fileName);
            cipherTool.EncryptFile(fileName, password);
            string oneTimeCipheredText = File.ReadAllText(newFileName);
            cipherTool.DecryptFile(newFileName, password);
            string originalText2 = File.ReadAllText(fileName);
            cipherTool.EncryptFile(fileName, password);
            string secondTimeCipheredText = File.ReadAllText(newFileName);
            cipherTool.DecryptFile(newFileName, password);
            string originalText3 = File.ReadAllText(fileName);
            Assert.AreEqual(originalText, originalText2, originalText3, "All text should be equal");
            Assert.AreNotEqual(oneTimeCipheredText, secondTimeCipheredText, "Both text should be different");
        }


        [TestMethod()]
        public void NoExtensionFileTest()
        {
            string noExtensionFileName = path + "file";
            string noExtensionFileNameEncrypted = path + "file.fpc";
            plainText = File.ReadAllText(noExtensionFileName);
            cipherTool.EncryptFile(noExtensionFileName, password);
            string cipherText = File.ReadAllText(noExtensionFileNameEncrypted);
            cipherTool.DecryptFile(noExtensionFileNameEncrypted, password);
            string plainText2 = File.ReadAllText(noExtensionFileName);
            Assert.AreEqual(plainText, plainText2);
            Assert.AreNotEqual(plainText2, cipherText);

        }


        [TestMethod()]
        public void SerializeTest()
        {
            cipherTool.EncryptFile(fileName, password);
            CipherTool cipherTool2 = CipherTool.GetInstance();
            cipherTool2.DecryptFile(newFileName, password);
            CipherTool cipherTool3 = CipherTool.GetInstance();
            cipherTool3.EncryptFile(fileName, password);
            cipherTool3.DecryptFile(newFileName, password);
            cipherTool3.ClearDB();
        }
    }
}
