using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class SubjectSQL
    {
        private MySqlManager mySqlManager;
        private UserMan userManager;

        private UserSQL userSql;

        private string UUID;

        public SubjectSQL()
        {
            UUID = new Random().Next().ToString() + DateTime.Now.ToString("s");
        }

        public Subject GetSubject(string uuid)
        {
            mySqlManager = new MySqlManager();
            userManager = new UserMan();

            string findSubjectSql = $"SELECT * FROM subjects WHERE subjectUUID = '{uuid}'";

            MySqlCommand findSubjectCmd = new MySqlCommand(findSubjectSql, mySqlManager.con);

            MySqlDataReader reader = findSubjectCmd.ExecuteReader();

            if (reader.Read())
            {
                string subjectName = reader["subjectName"].ToString();
                string school = reader["school"].ToString();
                string icon = reader["icon"].ToString();
                reader.Close();

                Subject returnSubject = new Subject(subjectName, uuid, icon);

                userManager = null;

                return returnSubject;
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            reader.Close();
            return null;
        }

        public List<Teacher> GetTeachersBySubject(Subject subject)
        {
            mySqlManager = new MySqlManager();
            userSql = new UserSQL();

            MySqlCommand findTeachersCommand = new MySqlCommand($"SELECT * FROM users WHERE subjectUUID = '{subject.uuid}'", mySqlManager.con);

            MySqlDataReader reader = findTeachersCommand.ExecuteReader();

            List<Teacher> returnTeachers = new List<Teacher>();

            while (reader.Read())
            {
                returnTeachers.Add(userSql.ConvertReaderToTeacher(reader));
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            reader.Close();
            return returnTeachers;
        }

        public void AddSubject(string name, string[] teachers, string school, string icon)
        {
            mySqlManager = new MySqlManager();
            MySqlCommand AddNewSubjectCommand = new MySqlCommand("INSERT INTO subjects (subjectUUID, subjectName, school, icon) VALUES (@subjectUUID, @subjectName, @school, @icon)", mySqlManager.con);

            AddNewSubjectCommand.Parameters.AddWithValue("@subjectUUID", UUID);
            AddNewSubjectCommand.Parameters.AddWithValue("@subjectName", name);
            AddNewSubjectCommand.Parameters.AddWithValue("@school", school);
            AddNewSubjectCommand.Parameters.AddWithValue("@icon", icon);

            foreach (string teacherUUID in teachers)
            {
                MySqlCommand ChangeTeacherCommand = new MySqlCommand($"UPDATE users SET subjectUUID = '{UUID}' WHERE uuid = '{teacherUUID}'", mySqlManager.con);
                ChangeTeacherCommand.ExecuteNonQuery();
            }

            AddNewSubjectCommand.Prepare();
            AddNewSubjectCommand.ExecuteNonQuery();
            mySqlManager.con.Close();
            mySqlManager = null;
        }

        public void UpdateTeachers(string teachers, string subjectUUID)
        {
            mySqlManager = new MySqlManager();
            MySqlCommand UpdateTeachersCommand = new MySqlCommand($"UPDATE subjects SET teachers = @teachers WHERE subjectUUID = '{subjectUUID}'", mySqlManager.con);

            UpdateTeachersCommand.Parameters.AddWithValue("@teachers", teachers);

            UpdateTeachersCommand.Prepare();
            UpdateTeachersCommand.ExecuteNonQuery();
            mySqlManager.con.Close();
            mySqlManager = null;
        }

        public List<Subject> GetSubjectList(string school)
        {
            mySqlManager = new MySqlManager();
            string findSubjectSql = $"SELECT * FROM subjects WHERE school = '{school}'";

            MySqlCommand findSubjectCmd = new MySqlCommand(findSubjectSql, mySqlManager.con);

            MySqlDataReader reader = findSubjectCmd.ExecuteReader();

            List<Subject> returnSubjects = new List<Subject>();

            while (reader.Read())
            {
                string subjectName = reader["subjectName"].ToString();
                string subjectUUID = reader["subjectUUID"].ToString();
                string icon = reader["icon"].ToString();

                Subject returnSubject = new Subject(subjectName, subjectUUID, icon);
                
                returnSubjects.Add(returnSubject);
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            reader.Close();
            return returnSubjects;
        }
    }
}