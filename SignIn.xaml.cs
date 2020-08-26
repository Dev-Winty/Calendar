using System;
using System.Collections.Generic;
using System.Linq;
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
    /// SignIn.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignIn : Window
    {
        SendQueryDB SendQuery = new SendQueryDB();
        Encrypt encrypt = new Encrypt();

        public SignIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = emailBx.Text;
            bool isSignIn = false;
            string pwd = encrypt.encryptString(pwdBx.Password);
            if (SendQuery.selectSql("SELECT * FROM `users` WHERE email='" + email + "';", 0) != null)
            {

                if (pwd.Equals(SendQuery.selectSql("SELECT * FROM `users` WHERE email='" + email + "';", 1)) && email.Equals(SendQuery.selectSql("SELECT * FROM `users` WHERE email='" + email + "';", 0)))
                {
                    MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
                    mainWindow.Show();
                    this.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("로그인 오류");
            }
            if (!isSignIn)
            {
                MessageBox.Show("로그인 오류");
            }
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }
    }
}
