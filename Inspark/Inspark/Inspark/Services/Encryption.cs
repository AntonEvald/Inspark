using System;
using System.Security.Cryptography;
using System.Text;

namespace Inspark.Services
{
    public class Encryption
    {

        public static string IV = "qo1lc3sjd8zpt9cx";
        public static string Key = "ow7dxys8g1for9tnc2ansdfgoletkfjv";

        public static string Decrypt(string encrypted)
        {
            byte[] encBytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider endec = new AesCryptoServiceProvider();
            endec.BlockSize = 128;
            endec.KeySize = 256;
            endec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            endec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            endec.Padding = PaddingMode.PKCS7;
            endec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = endec.CreateDecryptor(endec.Key, endec.IV);

            byte[] dec = icrypt.TransformFinalBlock(encBytes, 0, encBytes.Length);
            icrypt.Dispose();

            return ASCIIEncoding.ASCII.GetString(dec);
        }
    }
}
