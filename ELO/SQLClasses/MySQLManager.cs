using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace ELO.SQLClasses
{
    public static class MySqlManager
    {
        public static string connectionString = @"server=145.220.75.138;userid=usr;password=banaan3306;database=ELO";

        public static MySqlConnection con;

        static MySqlManager()
        {
            con = new MySqlConnection(connectionString);
            con.Open();
        }

    }
}
