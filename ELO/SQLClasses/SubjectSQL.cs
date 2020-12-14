using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class SubjectSQL
    {
        private MySqlManager mySqlManager;
        public SubjectSQL()
        {
            mySqlManager = new MySqlManager();
        }
        public Subject GetSubject(string uuid)
        {
            string findSubjectSql = "SELECT * FROM subjects WHERE subjectUUID = '" + uuid + "'";

            MySqlCommand findSubjectCmd = new MySqlCommand(findSubjectSql, mySqlManager.con);

            MySqlDataReader reader = findSubjectCmd.ExecuteReader();

            if (reader.Read())
            {
                string subjectName = reader["subjectName"].ToString();
                string teacherUUIDs = reader["teacherUUIDs"].ToString();

                reader.Close();

                return new Subject(subjectName);

            }

            reader.Close();
            return null;
        }

        public void AddSubject(string name, string teachers)
        {
            
        }


    }
}
