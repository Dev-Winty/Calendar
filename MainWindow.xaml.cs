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
        public MainWindow()
        {   
            InitializeComponent();
            this.DataContext = DataContext;
            loadCalendar();
            printCalendar();
            
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            saveCalendar();
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

        public void saveCalendar()
        {
            StreamWriter writer = new StreamWriter("Save.txt");
            int i;

            for (i = 0; i < days.Count; i++)
            {
                writer.WriteLine(days[i].date);
                writer.WriteLine(days[i].dayOfWeek);
                writer.WriteLine(days[i].contents);
                writer.WriteLine(days[i].row);
                writer.WriteLine(days[i].column);
            }
            writer.Close();

        }

        public void loadCalendar()
        {
            StreamReader reader = new StreamReader("Save.txt");
            int date = 0;
            string dayOfWeek = "";
            string contents = "";
            int row = 0, column = 0;
            while (reader.Peek() >= 0)
            {   
              
                date = Int32.Parse(reader.ReadLine());
                dayOfWeek = reader.ReadLine();
                contents = reader.ReadLine();
                row = Convert.ToInt32(reader.ReadLine());
                column = Convert.ToInt32(reader.ReadLine());
                days.Add(new Day { date = date, dayOfWeek = dayOfWeek, contents = contents, row = row, column = column });
            }         
            //MessageBox.Show(days[0].date.ToString() + " " + days[0].row.ToString() + " " + days[0].column.ToString());
            reader.Close();
        }
        private void addMenu_Click(object sender, RoutedEventArgs e)
        {
            AddDay addDay = new AddDay();
            addDay.Show();
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
