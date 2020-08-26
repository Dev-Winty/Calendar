﻿using MySql.Data.MySqlClient;
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
            string dayOfWeek = addDayofWeek.Text;
            string contents = addDayContents.Text;
            int row = int.Parse(addDayRow.Text);
            int column = int.Parse(addDayColumn.Text);

            mainWindow.days.Add(new Day { date = date, dayOfWeek = dayOfWeek, contents = contents, row = row, column = column });
            SendQuery.sendQuery("INSERT INTO `days` VALUES(" + date + ", '" + dayOfWeek + "', '" + contents + "'," + row + ", " + column + ");");
            mainWindow.printCalendar();
            //this.Close();
        }
    }
}
