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
        SendQueryDB SendQuery = new SendQueryDB();
        Encrypt encrypt = new Encrypt();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            //MessageBox.Show(pwdBx.Password);
            SendQuery.sendQuery("INSERT INTO `users` VALUES('" + emailBx.Text + "', '" + encrypt.encryptString(pwdBx.Password) + "');");
            SendQuery.sendQuery("CREATE TABLE `" + emailBx.Text + "` (`date` INT NOT NULL,`dayofweek` VARCHAR(45) NOT NULL,`contents` VARCHAR(200) ,`row` INT NOT NULL,`column` INT NOT NULL);");
            MessageBox.Show("가입 완료");
            signIn.Show();
            this.Close();
        }
    }


}
