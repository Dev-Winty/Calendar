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
        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = emailBx.Text;
            string pwd = encrypt.encryptString(pwdBx.Password);
            if (SendQuery.selectSql("SELECT * FROM `users` WHERE email='" + email + "';", 0) != null)
            {

                if (pwd.Equals(SendQuery.selectSql("SELECT * FROM `users` WHERE email='" + email + "';", 1)))
                {
                    MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
                    mainWindow.account = email;
                    mainWindow.Show();
                    mainWindow.loadCalendar();
                    mainWindow.printCalendar();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("로그인 오류");
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }
    }
}
