using System;
using System.Collections.Generic;
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
        public MainWindow()
        {   
            InitializeComponent();
            this.DataContext = DataContext;
            int date = 1;
            int i, j;

            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 7; j++)
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
                    TextBlock textBlock = new TextBlock();
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    switch (date)
                    {
                        case 1:
                            textBlock.Text = "일요일";
                            break;
                        case 2:
                            textBlock.Text = "월요일";
                            break;
                        case 3:
                            textBlock.Text = "화요일";
                            break;
                        case 4:
                            textBlock.Text = "수요일";
                            break;
                        case 5:
                            textBlock.Text = "목요일";
                            break;
                        case 6:
                            textBlock.Text = "금요일";
                            break;
                        case 7:
                            textBlock.Text = "토요일";
                            date = 0;
                            break;
                    }
                    date++;
                    stackPanel.Children.Add(textBlock);
                    border.Child = stackPanel;
                    border.SetValue(Grid.RowProperty, i);
                    border.SetValue(Grid.ColumnProperty, j);
                    gridMain.Children.Add(border);
                }
            }

            
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
