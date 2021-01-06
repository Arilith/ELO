using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class SchoolSQL
    {
        private MySqlManager mySqlManager;
        public SchoolSQL()
        {
            
        }

        public List<String> GetSchools()
        {
            mySqlManager = new MySqlManager();

            List<String> schoolList = new List<String>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM schools", mySqlManager.con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                schoolList.Add(reader["school"].ToString());
            }

            reader.Close();
            mySqlManager = null;

            return schoolList;

        }

    }
}
