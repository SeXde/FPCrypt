using System.Text;
using System.Security.Cryptography;


public class EasyAES
{
    public static (string, byte[]?) Encrypt(string plainText, string password)
    {

        if (string.IsNullOrEmpty(plainText))
        {
            return (string.Empty, null);
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("password");
        }

        SHA256 mySHA256 = SHA256.Create();
        byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));

        Aes aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        aes.Key = key;
        aes.GenerateIV();

        MemoryStream memoryStream = new MemoryStream();
        ICryptoTransform aesEncryptor = aes.CreateEncryptor();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

        byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
        cryptoStream.FlushFinalBlock();
        byte[] cipherBytes = memoryStream.ToArray();

        memoryStream.Close();
        cryptoStream.Close();

        string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);
        return (cipherText, aes.IV);
    }

    public static string Decrypt(string cipherText, string password, byte[] iv)
    {

        if (string.IsNullOrEmpty(cipherText))
        {
            return string.Empty;
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("password");
        }

        SHA256 mySHA256 = SHA256.Create();
        byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));

        Aes aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        aes.Key = key;
        aes.IV = iv;

        MemoryStream memoryStream = new MemoryStream();
        ICryptoTransform aesDecryptor = aes.CreateDecryptor();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
        cryptoStream.FlushFinalBlock();
        byte[] plainBytes = memoryStream.ToArray();
        string plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);

        memoryStream.Close();
        cryptoStream.Close();

        return plainText;
    }

}
