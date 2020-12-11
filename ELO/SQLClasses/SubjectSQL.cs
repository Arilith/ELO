using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class SubjectSQL
    {
        public SubjectSQL()
        {

        }
        public Subject GetSubject(string uuid)
        {
            string findSubjectSql = "SELECT * FROM subjects WHERE subjectUUID = '" + uuid + "'";

            MySqlCommand findSubjectCmd = new MySqlCommand(findSubjectSql, MySqlManager.con);

            MySqlDataReader reader = findSubjectCmd.ExecuteReader();

            if (reader.Read())
            {
                string subjectName = reader["subjectName"].ToString();
                string teacherUUIDs = reader["teacherUUIDs"].ToString();

                return new Subject(subjectName);

            }

            return null;
        }

        public void AddSubject(string name, string teachers)
        {
            
        }


    }
}
