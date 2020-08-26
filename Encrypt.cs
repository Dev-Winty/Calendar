using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Calendar
{
    class Encrypt
    {
        private readonly string key = "J@McQfTjWnZr4u7x!A%D*G-KaPdRgUkX";
        public string encryptString(string targetString)
        {
            string endedString = "";
            try
            {
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                byte[] vs = System.Text.Encoding.Unicode.GetBytes(targetString);
                byte[] salt = Encoding.ASCII.GetBytes(key.Length.ToString());
                PasswordDeriveBytes secretKey = new PasswordDeriveBytes(key, salt);
                ICryptoTransform encrytor = rijndaelManaged.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encrytor, CryptoStreamMode.Write);


                cryptoStream.Write(vs, 0, vs.Length);
                cryptoStream.FlushFinalBlock();
                byte[] chiperBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                endedString = Convert.ToBase64String(chiperBytes);
            }
            catch (Exception ex)
            {
            }
            return endedString;

        }
    }
}
