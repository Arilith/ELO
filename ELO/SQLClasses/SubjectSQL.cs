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
            mySqlManager = new MySqlManager();

            UUID = new Random().Next().ToString() + DateTime.Now.ToString("ddMMYYYYhhiiss");
        }

        public Subject GetSubject(string uuid)
        {
            userManager = new UserMan();

            string findSubjectSql = $"SELECT * FROM subjects WHERE subjectUUID = '{uuid}'";

            MySqlCommand findSubjectCmd = new MySqlCommand(findSubjectSql, mySqlManager.con);

            MySqlDataReader reader = findSubjectCmd.ExecuteReader();

            if (reader.Read())
            {
                string subjectName = reader["subjectName"].ToString();
                string teachersCSV = reader["teacherUUIDs"].ToString();
                string school = reader["school"].ToString();
                reader.Close();

                string[] teacherUUIDs = teachersCSV.Split(',');

                List<Teacher> teachers = new List<Teacher>();

                foreach (string teacherUUID in teacherUUIDs)
                {
                    teachers.Add((Teacher)userManager.FindUserInDataBase(teacherUUID));
                }

                Subject returnSubject = new Subject(subjectName, uuid);

                //TO IMPLEMENT
                returnSubject.SetTeachers(teachers);

                userManager = null;

                return returnSubject;
            }

            reader.Close();
            return null;
        }

        public void AddSubject(string name, string teachers, string school)
        {
            MySqlCommand AddNewSubjectCommand = new MySqlCommand("INSERT INTO subjects (subjectUUID, subjectName, teacherUUIDs, school) VALUES (@subjectUUID, @subjectName, @teacherUUIDs, @school)", mySqlManager.con);

            AddNewSubjectCommand.Parameters.AddWithValue("@subjectUUID", UUID);
            AddNewSubjectCommand.Parameters.AddWithValue("@subjectName", name);
            AddNewSubjectCommand.Parameters.AddWithValue("@teacherUUIDs", teachers);
            AddNewSubjectCommand.Parameters.AddWithValue("@school", school);

            AddNewSubjectCommand.Prepare();
            AddNewSubjectCommand.ExecuteNonQuery();
        }

        public void UpdateTeachers(string teachers, string subjectUUID)
        {
            MySqlCommand UpdateTeachersCommand = new MySqlCommand($"UPDATE subjects SET teachers = @teachers WHERE subjectUUID = '{subjectUUID}'", mySqlManager.con);

            UpdateTeachersCommand.Parameters.AddWithValue("@teachers", teachers);

            UpdateTeachersCommand.Prepare();
            UpdateTeachersCommand.ExecuteNonQuery();
        }

        public List<Subject> GetSubjectList(string school)
        {
            string findSubjectSql = $"SELECT * FROM subjects WHERE school = '{school}'";

            MySqlCommand findSubjectCmd = new MySqlCommand(findSubjectSql, mySqlManager.con);

            MySqlDataReader reader = findSubjectCmd.ExecuteReader();

            List<Subject> returnSubjects = new List<Subject>();

            while (reader.Read())
            {
                string subjectName = reader["subjectName"].ToString();
                string teachersCSV = reader["teacherUUIDs"].ToString();
                string subjectUUID = reader["subjectUUID"].ToString();

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
                Subject returnSubject = new Subject(subjectName, subjectUUID);

                //TO IMPLEMENT
                returnSubject.SetTeachers(teachers);

                returnSubjects.Add(returnSubject);
            }

            reader.Close();
            return returnSubjects;
        }
    }
}