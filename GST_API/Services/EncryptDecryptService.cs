using System.Security.Cryptography;
using System.Text;

namespace GST_API.Services
{
    public class EncryptDecryptService
    {
        //private readonly AppSettings _appSettings;

        public EncryptDecryptService()
        {
            //_appSettings = appSettings.Value;
        }

        public string EncryptText(string plainText)
        {
            using (Aes aes = GetEncryptionAlgorithm())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string DecryptText(string cipherText)
        {
            using (Aes aes = GetEncryptionAlgorithm())
            {
                byte[] buffer = Convert.FromBase64String(cipherText);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private Aes GetEncryptionAlgorithm()
        {
            Aes aes = Aes.Create();
            var secretKey = Encoding.UTF8.GetBytes("1203199320052021");
            var initializationVector = Encoding.UTF8.GetBytes("1203199320052021");
            aes.Key = secretKey;
            aes.IV = initializationVector;
            return aes;
        }

    }
}
