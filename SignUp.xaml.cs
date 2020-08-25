using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// SignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUp : Window
    {
        private readonly string key = "";
        public SignUp()
        {
            InitializeComponent();
        }
        private string encryptString(string targetString)
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
            } catch (Exception ex)
            {
                MessageBox.Show("암호화 오류");
            }
            return endedString;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }


}
