using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace FPCrypt.cryptoUtils
{
    [Serializable]
    public class CipherTool
    {

        private IDictionary<string, (byte[], string, string)> ivFingerprintMap;
        [NonSerialized]
        private SHA256 mySHA256;
        [NonSerialized]
        private const string fpcExtension = ".fpc";
        [NonSerialized]
        private const string CLASS_FILE = "CipherTool.class.bin";
        [NonSerialized]
        private static CipherTool instance;


        private CipherTool()
        {
            mySHA256 = SHA256.Create();
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(CLASS_FILE, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
            {
                if (stream.Length == 0)
                {
                    ivFingerprintMap = new Dictionary<string, (byte[], string, string)>();
                }
                else
                {
                    CipherTool saved = formatter.Deserialize(stream) as CipherTool;
                    ivFingerprintMap = saved.GetDictionary();
                }
            }  
        }

        public static CipherTool GetInstance()
        {
            if (instance == null)
            {
                instance = new CipherTool();
            }
            return instance;
        }

        public void EncryptFile(string fileName, string fingerprint)
        {
            checkArguments(fileName, fingerprint);
            string text = File.ReadAllText(fileName);

            if (string.IsNullOrEmpty(text))
            {
                throw new FileFormatException("File cannot be empty");
            }
            if (isAlreadyCipher(text))
            {
                throw new FileFormatException("File is already cipher");
            }

            var tuple = EasyAES.Encrypt(text, fingerprint);
            string cipherText = tuple.Item1;
            byte[] cipherFileHash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(cipherText));
            File.WriteAllText(fileName, cipherText);
            string extension = getExtension(fileName);
            ivFingerprintMap.Add(Encoding.ASCII.GetString(cipherFileHash), (tuple.Item2, fingerprint, extension));
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
            changeExtension(fileName, extension, fpcExtension);
        }


        public void DecryptFile(string fileName, string fingerprint)
        {
            checkArguments(fileName, fingerprint);
            string cipherText = File.ReadAllText(fileName);
            byte[] cipherFileHash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(cipherText));
            string cipherFileHashText = Encoding.ASCII.GetString(cipherFileHash);

            if (!ivFingerprintMap.ContainsKey(cipherFileHashText))
            {
                throw new NotSupportedException("File cannot be decrypted, beacuse it hasn't been encrypted");
            }

            var triple = ivFingerprintMap[cipherFileHashText];
            byte [] iv = triple.Item1;
            string usedFingerPrint = triple.Item2;
            string oldExtension = triple.Item3;

            if (!fingerprint.Equals(usedFingerPrint))
            {
                throw new NotSupportedException("Fingerprints do not match");
            }

            string plainText = EasyAES.Decrypt(cipherText, fingerprint, iv);
            File.WriteAllText(fileName, plainText);
            ivFingerprintMap.Remove(cipherFileHashText);
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
            changeExtension(fileName, fpcExtension, oldExtension);
        }


        private void checkArguments(string fileName, string fingerprint)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("File name");
            }
            if (string.IsNullOrEmpty(fingerprint))
            {
                throw new ArgumentNullException("Fingerprint");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File: '" + fileName + "' not found");
            }
        }


        private bool isAlreadyCipher(string text)
        {
            string cipherFileHashText = Encoding.ASCII.GetString(mySHA256.ComputeHash(Encoding.ASCII.GetBytes(text)));
            return ivFingerprintMap.ContainsKey(cipherFileHashText);
        }

        
       private string getExtension(string fileName)
        {
            string extension = null;
            Regex regex = regex = new Regex("[.][a-zA-Z0-9]+$");
            MatchCollection matchCollection = regex.Matches(fileName);
            if (matchCollection.Count == 0)
            {
                extension = String.Empty;
            } else
            {
                extension = matchCollection[0].Value;
            }
            return extension;
        }

        private void changeExtension(string fileName, string oldExtension, string newExtension)
        {
            string newFileName = null;
            if (string.Equals(string.Empty, oldExtension))
            {
                newFileName = fileName + newExtension;
            } else
            {
                newFileName = fileName.Replace(oldExtension, newExtension);
            }
            File.Move(fileName, newFileName);
        }

        protected IDictionary<string, (byte[], string, string)> GetDictionary()
        {
            return ivFingerprintMap;
        }

        public void ClearDB()
        {
            if (File.Exists(CLASS_FILE))
            {
                File.Delete(CLASS_FILE);
            }
        }
    }
}
