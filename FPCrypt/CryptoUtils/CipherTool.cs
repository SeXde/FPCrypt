using System.Security.Cryptography;
using System.Text;

namespace FPCrypt.cryptoUtils
{
    public class CipherTool
    {
        private IDictionary<string, (byte[], string)> ivFingerprintMap = new Dictionary<string, (byte[], string)>();
        private SHA256 mySHA256 = SHA256.Create();

        public void EncryptFile(string fileName, string fingerprint)
        {
            checkArguments(fileName, fingerprint);

            string text = File.ReadAllText(fileName);

            if (string.IsNullOrEmpty(text))
            {
                throw new FileFormatException("File cannot be empty");
            }

            //Encrypt file
            var tuple = EasyAES.Encrypt(text, fingerprint);
            string cipherText = tuple.Item1;

            byte[] cipherFileHash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(cipherText));
       

            File.WriteAllText(fileName, cipherText);

            //Save auto generated iv and fingerprint used
            ivFingerprintMap.Add(Encoding.ASCII.GetString(cipherFileHash), (tuple.Item2, fingerprint));

        }

        public void DecryptFile(string fileName, string fingerprint)
        {
            checkArguments(fileName, fingerprint);

            string cipherText = File.ReadAllText(fileName);

            byte[] cipherFileHash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(cipherText));
            string cipherFileHashText = Encoding.ASCII.GetString(cipherFileHash);
            if (!ivFingerprintMap.ContainsKey(cipherFileHashText))
            {
                throw new NotSupportedException("File cannot be decrypted");
            }
            if (!fingerprint.Equals(ivFingerprintMap[cipherFileHashText].Item2))
            {
                throw new NotSupportedException("Fingerprints do not match");
            }

            byte[] iv = ivFingerprintMap[cipherFileHashText].Item1;
            string plainText = EasyAES.Decrypt(cipherText, fingerprint, iv);

            File.WriteAllText(fileName, plainText);

            ivFingerprintMap.Remove(cipherFileHashText);

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
    }
}
