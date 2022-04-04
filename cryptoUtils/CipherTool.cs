using System.Security.Cryptography;
using System.Text;

namespace FPCrypt.cryptoUtils
{
    internal class CipherTool
    {
        private IDictionary<byte[], byte[]> ivMap = new Dictionary<byte[], byte[]>();
        private IDictionary<byte[], string> fingerprintMap = new Dictionary<byte[], string>();
        private SHA256 mySHA256 = SHA256.Create();

        public void EncryptFile(string fileName, string fingerprint)
        {
            checkArguments(fileName, fingerprint);

            string text = File.ReadAllText(fileName);

            //Encrypt file
            var tuple = EasyAES.Encrypt(text, fingerprint);
            string cipherText = tuple.Item1;

            byte[] cipherFileHash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(cipherText));
       

            File.WriteAllText(cipherText, fileName);

            //Save auto generated iv and fingerprint used
            ivMap.Add(cipherFileHash, tuple.Item2);
            fingerprintMap.Add(cipherFileHash, fingerprint);

        }

        public void DecryptFile(string fileName, string fingerprint)
        {
            checkArguments(fileName, fingerprint);

            string cipherText = File.ReadAllText(fileName);

            byte[] cipherFileHash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(cipherText));
            if (!ivMap.ContainsKey(cipherFileHash))
            {
                throw new NotSupportedException("File cannot be decrypted");
            }
            if (!fingerprint.Equals(fingerprintMap[cipherFileHash]))
            {
                throw new NotSupportedException("Fingerprints do not match");
            }

            byte[] iv = ivMap[cipherFileHash];
            string plainText = EasyAES.Decrypt(cipherText, fingerprint, iv);

            File.WriteAllText(fileName, plainText);

            ivMap.Remove(cipherFileHash);
            fingerprintMap.Remove(cipherFileHash);

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
                throw new FileNotFoundException("File: '{0}' not found", fileName);
            }
        }
    }
}
