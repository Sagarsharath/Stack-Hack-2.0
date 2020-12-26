using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace HRM.Rest.Services.Util
{
    public static class Crypto
    {
        private static string _salt = "*1234567890!@#$%^&*()14344*";
        public static string Encrypt(string text)
        {
            var hashmd5 = new MD5CryptoServiceProvider();
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(text);
            byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(_salt));
            hashmd5.Clear();

            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] resultArray = transform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
        }

        public static string Decrypt(string text)
        {
            try
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                byte[] toDecryptArray = Convert.FromBase64String(text);
                byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(_salt));
                hashmd5.Clear();

                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] resultArray = transform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                    return Encoding.UTF8.GetString(resultArray);
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
