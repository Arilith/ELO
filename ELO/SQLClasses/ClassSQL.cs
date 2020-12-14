using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    class ClassSQL
    {
        private string uuid;
        private string date;

        public UserSQL userSql;

        public ClassSQL()
        {
            uuid = new Random().Next().ToString() + DateTime.Now.ToString("ddmmYYYhhiiss");
            date = DateTime.Now.ToString("u");
        }

        public List<Class> GetClassList(string school)
        {
            return null;
        }

        public List<Class> GetClassList(string school, string level)
        {
            return null;
        }

        public Class GetClass(string school, string level, string name)
        {
            return null;
        }

        public Class GetClass(string school, string name)
        {
            string findClassSql = "SELECT * FROM classes WHERE school = '" + school + "' AND className = '" + name + "'";

            MySqlCommand findClassCommand = new MySqlCommand(findClassSql, MySqlManager.con);

            MySqlDataReader reader = findClassCommand.ExecuteReader();

            if (reader.Read())
            {
                string className = reader["className"].ToString();
                string cluster = reader["cluster"].ToString();
                string stream = reader["level"].ToString();
                string leshuis = reader["leshuis"].ToString();
                string mentorUUID = reader["mentorUUID"].ToString();
                int studyYear = Convert.ToInt32(reader["studyYear"]);

                reader.Close();

                Teacher mentor = (Teacher)userSql.FindUserInDataBase(mentorUUID);

                return new Class(className, cluster, leshuis, stream, studyYear, mentor);

            }

            return null;
        }

        public Class GetClassByMentor(string school, string mentorName)
        {
            return null;
        }

        public Class GetClass(string uuid)
        {
            return null;
        }

        public void CreateClass(string className, string level, string cluster, string leshuis, int studyYear, string school)
        {
            string AddClassSql = "INSERT INTO classes(className, level, uuid, cluster, leshuis, studyYear, school) VALUES (@className, @level, @uuid, @cluster, @leshuis, @studyYear, @school)";
            MySqlCommand AddClassCmd;



            AddClassCmd = new MySqlCommand(AddClassSql, MySqlManager.con);

            AddClassCmd.Parameters.AddWithValue("@className", className);
            AddClassCmd.Parameters.AddWithValue("@level", level);
            AddClassCmd.Parameters.AddWithValue("@uuid", uuid);
            AddClassCmd.Parameters.AddWithValue("@cluster", cluster);
            AddClassCmd.Parameters.AddWithValue("@leshuis", leshuis);
            AddClassCmd.Parameters.AddWithValue("@studyYear", studyYear);
            AddClassCmd.Parameters.AddWithValue("@school", school);

            AddClassCmd.Prepare();
            AddClassCmd.ExecuteNonQuery();

            //return new Class(className, cluster, leshuis, level, studyYear);
        }

    }
}
