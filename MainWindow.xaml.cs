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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Calendar
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {   
        public string dayOfWeek = "";
        public int date = 0;
        public List<Day> days = new List<Day>();
        SendQueryDB SendQuery = new SendQueryDB();
        public string account = "";
        public MainWindow()
        {   
            InitializeComponent();
            this.DataContext = DataContext; 
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        public void printCalendar()
        {
            int i;

            for (i = 0; i < days.Count; i++)
            {
                StackPanel stackPanel = new StackPanel();
                Border border = new Border()
                {
                    CornerRadius = new CornerRadius(20),
                    BorderThickness = new Thickness()
                    {
                        Bottom = 2,
                        Left = 2,
                        Right = 2,
                        Top = 2
                    },
                    BorderBrush = new SolidColorBrush(Colors.Silver) { Opacity = 0.7 },
                    Margin = new Thickness(2),
                    Padding = new Thickness(4)
                };
                TextBlock title = new TextBlock();
                TextBlock contents = new TextBlock();
                title.HorizontalAlignment = HorizontalAlignment.Center;
                title.FontWeight = FontWeights.Bold;
                contents.HorizontalAlignment = HorizontalAlignment.Center;
                
                border.Name = "index" + days[i].date.ToString();
                title.Text = days[i].date.ToString() + " " + days[i].dayOfWeek;
                contents.Text = days[i].contents;
                stackPanel.Children.Add(title);
                stackPanel.Children.Add(contents);
                border.Child = stackPanel;
                border.SetValue(Grid.RowProperty, days[i].row);
                border.SetValue(Grid.ColumnProperty, days[i].column);
                gridMain.Children.Add(border);
            }
        }
        public void loadCalendar()
        {
            int date;
            string dayOfWeek;
            string contents;
            int row, column;
            int i;

            for (i = 1; i < 32; i++)
            {
                date = int.Parse(SendQuery.selectSql("SELECT * FROM `days` WHERE date = " + i + ";", 0));
                dayOfWeek = SendQuery.selectSql("SELECT * FROM `days` WHERE date = " + i + ";", 1);
                contents = SendQuery.selectSql("SELECT * FROM `" + account + "` WHERE date = " + i + ";", 1);
                row = int.Parse(SendQuery.selectSql("SELECT * FROM `days` WHERE date = " + i + ";", 3));
                column = int.Parse(SendQuery.selectSql("SELECT * FROM `days` WHERE date = " + i + ";", 4));

                days.Add(new Day { date = date, dayOfWeek = dayOfWeek, contents = contents, row = row, column = column});
            }
            
        }

        private void addMenu_Click(object sender, RoutedEventArgs e)
        {
            AddDay addDay = new AddDay();
            addDay.Show();
        }

        private void addSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadCalendar();
            printCalendar();
        }
    }
    public class Day
    {
        public string dayOfWeek { get; set; }
        public int date { get; set; }
        public string contents { get; set; }
        public int row { get; set; }
        public int column { get; set; }
    }
}
