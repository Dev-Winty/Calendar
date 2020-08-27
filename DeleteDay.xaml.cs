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
    /// DeleteDay.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DeleteDay : Window
    {
        MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
        List<int> date = new List<int>();
        SendQueryDB SendQuery = new SendQueryDB();
        public DeleteDay()
        {
            InitializeComponent();
            for (int i = 0; i < 32; i++)
            {
                TextBlock textBlock = new TextBlock();

                textBlock.Text = i.ToString();
                date.Add(i);
            }
            addDayDate.ItemsSource = date;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (addDayDate.Text != "")
            {
                SendQuery.sendQuery("UPDATE `" + mainWindow.account + "` SET contents='' WHERE date=" + addDayDate.Text + ";");
                mainWindow.gridMain.Children.Clear();
                mainWindow.days.Clear();
                mainWindow.loadCalendar();
                mainWindow.printCalendar();
                MessageBox.Show("삭제 완료!");
            }
        }
    }
}
