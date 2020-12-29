using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace ELO.SQLClasses
{
    public class MySqlManager
    {
        public string connectionString = @"server=145.220.75.138;userid=usr;password=banaan3306;database=ELO";

        public MySqlConnection con;

        public MySqlManager()
        {
            con = new MySqlConnection(connectionString);
            con.Open();
        }

    }
}
