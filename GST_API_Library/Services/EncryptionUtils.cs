using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

namespace GST_API_Library.Services
{
    public class EncryptionUtils
    {

        public static bool isProduction = false;
        private const string devKey = @"\GST_API\Resource\GSTN_G2B_SANDBOX_UAT_public.cert.cer";
        private const string productionKey = @"\GST_API\Resource\GSTN_G2B_Prod_public.cer";
        public static X509Certificate2 getPublicKey()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            string key = isProduction?productionKey:devKey;
            X509Certificate2 cert2 = new X509Certificate2(GSTNConstants.base_path +key );//System.IO.Path.Combine(GSTNConstants.base_path, "Resources\\GSTN_G2A_SANDBOX_UAT_public.cer"));

            return cert2;
        }

        public static string GenerateHMAC(string message, string secret)
        {
            secret = secret ?? "";
            byte[] keyByte = Encoding.UTF8.GetBytes(secret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            return GenerateHMAC(messageBytes, keyByte);


        }

        public static String GetHash(String text, String key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public static string GenerateHMAC(byte[] data, byte[] EK)
        {
            using (var HMACSHA256 = new HMACSHA256(EK))
            {
                byte[] hashmessage = HMACSHA256.ComputeHash(data);
                return Convert.ToBase64String(hashmessage);
            }
        }


        public static string AesEncrypt(byte[] dataToEncrypt, byte[] keyBytes)
        {
            AesManaged tdes = new AesManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Key = keyBytes,
                // Encoding.ASCII.GetBytes(key);
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform crypt = tdes.CreateEncryptor();
            byte[] cipher = crypt.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            tdes.Clear();
            return Convert.ToBase64String(cipher, 0, cipher.Length);
        }


        public static byte[] AesDecrypt(string encryptedText, byte[] keys)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
            return AesDecrypt(dataToDecrypt, keys);
        }


        public static byte[] AesDecrypt(byte[] dataToDecrypt, byte[] keyBytes)
        {
            AesManaged tdes = new AesManaged();
            tdes.KeySize = 256;
            tdes.BlockSize = 128;
            tdes.Key = keyBytes;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform decrypt__1 = tdes.CreateDecryptor();
            byte[] deCipher = decrypt__1.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            tdes.Clear();
            return deCipher;
        }




        public static string RSAEncrypt(string input,string basePath)
        {
            byte[] bytesToBeEncrypted = Encoding.ASCII.GetBytes(input);
            return RsaEncrypt(bytesToBeEncrypted);
        }

        private static readonly byte[] Salt = new byte[] {
            10,
            20,
            30,
            40,
            50,
            60,
            70,
            80
        };
        public static byte[] CreateAesKey()
        {

            System.Security.Cryptography.AesCryptoServiceProvider crypto = new System.Security.Cryptography.AesCryptoServiceProvider();
            crypto.KeySize = 256;
            crypto.GenerateKey();
            byte[] key = crypto.Key;
            return key;
        }

        public static string RsaEncrypt(byte[] bytesToBeEncrypted)
        {
            X509Certificate2 certificate = getPublicKey();
            RSA rsa = certificate.GetRSAPublicKey();
            byte[] bytesEncrypted = rsa.Encrypt(bytesToBeEncrypted,RSAEncryptionPadding.Pkcs1);

            string result = Convert.ToBase64String(bytesEncrypted);
            return result;
        }

        public static byte[] sha256_hash(string value)
        {

            using (SHA256 hash = SHA256Managed.Create())
            {
                Byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                return result;
            }

        }



        public static byte[] convertStringToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }


        public static string RsaEncryptBC(byte[] bytesToEncrypt)
        {

            var encryptEngine = new Pkcs1Encoding(new RsaEngine());
            string certificateLocation = "Resources\\GSTN_G2B_SANDBOX_UAT_public.pem";
            string publicKey = File.ReadAllText(certificateLocation).Replace("RSA PUBLIC", "PUBLIC");


            using (var txtreader = new StringReader(publicKey))
            {
                var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();

                encryptEngine.Init(true, keyParameter);
            }

            var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
            return encrypted;

        }

        public static byte[] CreateAesKeyBC()
        {
            SecureRandom random = new SecureRandom();
            byte[] keyBytes = new byte[32]; //32 Bytes = 256 Bits
            random.NextBytes(keyBytes);

            var key = ParameterUtilities.CreateKeyParameter("AES", keyBytes);
            return key.GetKey();
        }

        public byte[] Hash(string text, string key)
        {
            var hmac = new HMac(new Sha256Digest());
            hmac.Init(new KeyParameter(Encoding.UTF8.GetBytes(key)));
            byte[] result = new byte[hmac.GetMacSize()];
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            hmac.BlockUpdate(bytes, 0, bytes.Length);
            hmac.DoFinal(result, 0);

            return result;
        }

        public static string GenerateHMACBC(byte[] data, byte[] EK)
        {
            var hmac = new HMac(new Sha256Digest());
            hmac.Init(new KeyParameter(EK));
            byte[] hashMessage = new byte[hmac.GetMacSize()];
            hmac.BlockUpdate(data, 0, data.Length);
            hmac.DoFinal(hashMessage, 0);
            return Convert.ToBase64String(hashMessage);
        }
    }

}
