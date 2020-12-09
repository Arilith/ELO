using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class SchoolSQL
    {


        public SchoolSQL()
        {

        }

        public List<School> GetSchools()
        {
            List<School> schoolList = new List<School>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM schools", MySqlManager.con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                schoolList.Add(new School(reader.GetValue(reader.GetOrdinal("School")).ToString()));
            }

            reader.Close();

            return schoolList;

        }

    }
}
