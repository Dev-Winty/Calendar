using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Calendar
{
    class SendQueryDB
    {
        public void sendQuery(string cmd)
        {
            using (MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=calendar;Uid=root;Pwd=winty0320"))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(cmd, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {                   
                }
            }
        }
    }
}
