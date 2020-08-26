using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calendar
{
    /// <summary>
    /// AddDay.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddDay : Window
    {
        MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
        SendQueryDB SendQuery = new SendQueryDB();
        public AddDay()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            int date = int.Parse(addDayDate.Text);
            string contents = addDayContents.Text;

            SendQuery.sendQuery("UPDATE `" + mainWindow.account + "` SET contents='" + contents + "' WHERE date=" + date + ";");
            mainWindow.gridMain.Children.Clear();
            mainWindow.days.Clear();
            mainWindow.loadCalendar();
            mainWindow.printCalendar();
            this.Close();
        }
    }
}
