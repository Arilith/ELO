using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class SubjectSQL
    {
        private MySqlManager mySqlManager;
        private UserMan userManager;
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
                string teachersCSV = reader["teacherUUIDs"].ToString();
                string school = reader["school"].ToString();
                string icon = reader["icon"].ToString();
                reader.Close();

                string[] teacherUUIDs = teachersCSV.Split(',');

                List<Teacher> teachers = new List<Teacher>();

                foreach (string teacherUUID in teacherUUIDs)
                {
                    teachers.Add((Teacher)userManager.FindUserInDataBase(teacherUUID));
                }

                Subject returnSubject = new Subject(subjectName, uuid, icon);

                //TO IMPLEMENT
                returnSubject.SetTeachers(teachers);

                userManager = null;

                return returnSubject;
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            reader.Close();
            return null;
        }

        public void AddSubject(string name, string teachers, string school, string icon)
        {
            mySqlManager = new MySqlManager();
            MySqlCommand AddNewSubjectCommand = new MySqlCommand("INSERT INTO subjects (subjectUUID, subjectName, teacherUUIDs, school, icon) VALUES (@subjectUUID, @subjectName, @teacherUUIDs, @school, @icon)", mySqlManager.con);

            AddNewSubjectCommand.Parameters.AddWithValue("@subjectUUID", UUID);
            AddNewSubjectCommand.Parameters.AddWithValue("@subjectName", name);
            AddNewSubjectCommand.Parameters.AddWithValue("@teacherUUIDs", teachers);
            AddNewSubjectCommand.Parameters.AddWithValue("@school", school);
            AddNewSubjectCommand.Parameters.AddWithValue("@icon", icon);

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
                string teachersCSV = reader["teacherUUIDs"].ToString();
                string subjectUUID = reader["subjectUUID"].ToString();
                string icon = reader["icon"].ToString();

                string[] teacherUUIDs = teachersCSV.Split(',');

                List<Teacher> teachers = new List<Teacher>();
                // userManager = new UserMan();
                //
                // foreach (string teacherUUID in teacherUUIDs)
                // {
                //     teachers.Add((Teacher)userManager.FindUserInDataBase(teacherUUID));
                // }
                //
                // userManager = null;
                Subject returnSubject = new Subject(subjectName, subjectUUID, icon);

                //TO IMPLEMENT
                returnSubject.SetTeachers(teachers);

                returnSubjects.Add(returnSubject);
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            reader.Close();
            return returnSubjects;
        }
    }
}