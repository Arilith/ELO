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
            mySqlManager = new MySqlManager();
        }

        public List<School> GetSchools()
        {
            List<School> schoolList = new List<School>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM schools", mySqlManager.con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                schoolList.Add(new School(reader["school"].ToString()));
            }

            reader.Close();

            return schoolList;

        }

    }
}
