using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace ELO.SQLClasses
{
    public static class MySQLManager
    {
        public static string connectionString = @"server=localhost;userid=root;password=;database=ELO";

        public static MySqlConnection con;

        static MySQLManager()
        {
            con = new MySqlConnection(connectionString);
            con.Open();
        }

    }
}
