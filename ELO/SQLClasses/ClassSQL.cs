using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    class ClassSQL
    {
        private MySqlManager mysqlManager;

        private string uuid;
        private string date;

        public UserSQL userSql;

        public ClassSQL()
        {
            mysqlManager = new MySqlManager();
            
            uuid = new Random().Next().ToString() + DateTime.Now.ToString("ddmmYYYhhiiss");
            date = DateTime.Now.ToString("u");
        }

        public List<Class> GetClassList(string school)
        {
            userSql = new UserSQL();

            List<Class> returnList = new List<Class>();

            MySqlCommand getClassListCommand = new MySqlCommand($"SELECT * FROM classes WHERE school = '{school}'", mysqlManager.con);
            MySqlDataReader classReader = getClassListCommand.ExecuteReader();

            while (classReader.Read())
            {
                string returnName = classReader["className"].ToString();
                string level = classReader["className"].ToString();
                string uuid = classReader["uuid"].ToString();
                string mentorUUID = classReader["mentorUUID"].ToString();
                int studyYear = Convert.ToInt32(classReader["studyYear"]);
                string cluster = classReader["className"].ToString();
                string leshuis = classReader["className"].ToString();

                Teacher foundTeacher = (Teacher)userSql.FindUserInDataBase(mentorUUID);

                returnList.Add(new Class(returnName, cluster, leshuis, level, studyYear, foundTeacher, uuid));

            }

            classReader.Close();

            userSql = null;

            return returnList;
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
            userSql = new UserSQL();

            string findClassSql = "SELECT * FROM classes WHERE school = '" + school + "' AND className = '" + name + "'";

            MySqlCommand findClassCommand = new MySqlCommand(findClassSql, mysqlManager.con);

            MySqlDataReader reader = findClassCommand.ExecuteReader();

            if (reader.Read())
            {
                string className = reader["className"].ToString();
                string cluster = reader["cluster"].ToString();
                string stream = reader["level"].ToString();
                string leshuis = reader["leshuis"].ToString();
                string mentorUUID = reader["mentorUUID"].ToString();
                string classUUID = reader["uuid"].ToString();
                int studyYear = Convert.ToInt32(reader["studyYear"]);

                reader.Close();

                Teacher mentor = (Teacher)userSql.FindUserInDataBase(mentorUUID);

                return new Class(className, cluster, leshuis, stream, studyYear, mentor, classUUID);

            }

            userSql = null;

            return null;
        }

        public Class GetClassByMentor(string school, string mentorName)
        {
            return null;
        }

        public Class GetClass(string uuid)
        {
            userSql = new UserSQL();

            string findClassSql = "SELECT * FROM classes WHERE uuid = '" + uuid + "'";

            MySqlCommand findClassCommand = new MySqlCommand(findClassSql, mysqlManager.con);

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

                return new Class(className, cluster, leshuis, stream, studyYear, mentor, uuid);

            }

            userSql = null;

            return null;
        }

        public void CreateClass(string className, string level, string cluster, string leshuis, int studyYear, string school)
        {
            string addClassSql = "INSERT INTO classes(className, level, uuid, cluster, leshuis, studyYear, school) VALUES (@className, @level, @uuid, @cluster, @leshuis, @studyYear, @school)";
            MySqlCommand addClassCmd;



            addClassCmd = new MySqlCommand(addClassSql, mysqlManager.con);

            addClassCmd.Parameters.AddWithValue("@className", className);
            addClassCmd.Parameters.AddWithValue("@level", level);
            addClassCmd.Parameters.AddWithValue("@uuid", uuid);
            addClassCmd.Parameters.AddWithValue("@cluster", cluster);
            addClassCmd.Parameters.AddWithValue("@leshuis", leshuis);
            addClassCmd.Parameters.AddWithValue("@studyYear", studyYear);
            addClassCmd.Parameters.AddWithValue("@school", school);

            addClassCmd.Prepare();
            addClassCmd.ExecuteNonQuery();

            //return new Class(className, cluster, leshuis, level, studyYear);
        }

        public int GetAmountOfStudents(string classUUID)
        {
            MySqlCommand amountOfStudentsCmd = new MySqlCommand($"SELECT Id FROM users WHERE classUUID = '{classUUID}'", mysqlManager.con);
            MySqlDataReader amountOfStudentsReader = amountOfStudentsCmd.ExecuteReader();
            return amountOfStudentsReader.RowCount();
        }

        public List<Student> GetStudentsInClass(string classUUID)
        {
            MySqlCommand studentsInClassCmd = new MySqlCommand($"SELECT * FROM users WHERE classUUID = '{classUUID}'", mysqlManager.con);
            MySqlDataReader studentsInClassReader = studentsInClassCmd.ExecuteReader();

            List<Student> returnList = new List<Student>();

            userSql = new UserSQL();

            while (studentsInClassReader.Read())
            {
                string studentUUID = studentsInClassReader["uuid"].ToString();

                returnList.Add((Student)userSql.FindUserInDataBase(studentUUID));
            }

            return returnList;

        }

        public void UpdateMentor(string classUUID, string mentorUUID)
        {
            string changeMentorSql = $"UPDATE classes SET mentorUUID = @mentorUUID WHERE uuid = '{classUUID}'";
            MySqlCommand changeMentorCmd;

            changeMentorCmd = new MySqlCommand(changeMentorSql, mysqlManager.con);

            changeMentorCmd.Parameters.AddWithValue("@mentorUUID", mentorUUID);

            changeMentorCmd.Prepare();
            changeMentorCmd.ExecuteNonQuery();
        }
    }
}
