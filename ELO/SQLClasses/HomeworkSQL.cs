using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class HomeworkSQL
    {
        private SubjectManager subjectManager;
        private ClassManager classManager;
        private string UUID = new Random().Next().ToString() + DateTime.Now.ToString("s");

        public List<Homework> GetHomeWorkList(string school)
        {
            MySqlManager mySqlManager = new MySqlManager();
            subjectManager = new SubjectManager();
            classManager = new ClassManager();

            MySqlCommand getHomeworkCommand = new MySqlCommand($"SELECT * FROM homework WHERE school = '{school}'", mySqlManager.con);
            MySqlDataReader homeworkReader = getHomeworkCommand.ExecuteReader();

            List<Homework> returnList = new List<Homework>();

            while (homeworkReader.Read())
            {
                string returnSchool = homeworkReader["school"].ToString();
                string returnSubject = homeworkReader["subject"].ToString();
                string returnTitle = homeworkReader["title"].ToString();
                string returnContent = homeworkReader["content"].ToString();
                string returnUUID = Convert.ToString(homeworkReader["UUID"]);
                string returnClass = homeworkReader["classUUID"].ToString();
                string returnDate = homeworkReader["duedate"].ToString();
                int returnExp = Convert.ToInt32(homeworkReader["exp"]);
                int returnIsTest = Convert.ToInt32(homeworkReader["istest"]);
                bool isTest = returnIsTest == 1;
                int returnForGrade = Convert.ToInt32(homeworkReader["forgrade"]);
                bool forGrade = returnForGrade == 1;


                Subject insertSubject = subjectManager.FindSubjectInDatabase(returnSubject);
                Class insertClass = classManager.GetClassFromDatabase(returnClass);

                returnList.Add(new Homework(returnTitle, insertSubject, returnContent, returnDate, insertClass, returnExp, isTest, returnUUID, forGrade));
            }

            homeworkReader.Close();

            mySqlManager.con.Close();
            mySqlManager = null;
            classManager = null;
            subjectManager = null;

            return returnList;
        }

        public List<Homework> GetHomeworkForSubject(string school, Subject subject)
        {
            MySqlManager mySqlManager = new MySqlManager();
            subjectManager = new SubjectManager();
            classManager = new ClassManager();

            MySqlCommand getHomeworkCommand = new MySqlCommand($"SELECT * FROM homework WHERE school = '{school}' AND subjectUUID = '{subject.uuid}'", mySqlManager.con);
            MySqlDataReader homeworkReader = getHomeworkCommand.ExecuteReader();

            List<Homework> returnList = new List<Homework>();

            while (homeworkReader.Read())
            {
                string returnSchool = homeworkReader["school"].ToString();
                string returnSubject = homeworkReader["subjectUUID"].ToString();
                string returnTitle = homeworkReader["title"].ToString();
                string returnContent = homeworkReader["content"].ToString();
                string returnUUID = Convert.ToString(homeworkReader["UUID"]);
                string returnClass = homeworkReader["classUUID"].ToString();
                string returnDate = homeworkReader["duedate"].ToString();
                int returnExp = Convert.ToInt32(homeworkReader["exp"]);
                int returnIsTest = Convert.ToInt32(homeworkReader["istest"]);
                bool isTest = returnIsTest == 1;
                int returnForGrade = Convert.ToInt32(homeworkReader["forgrade"]);
                bool forGrade = returnForGrade == 1;

                Subject insertSubject = subjectManager.FindSubjectInDatabase(returnSubject);
                Class insertClass = classManager.GetClassFromDatabase(returnClass);

                returnList.Add(new Homework(returnTitle, insertSubject, returnContent, returnDate, insertClass, returnExp, isTest, returnUUID, forGrade));
            }

            homeworkReader.Close();

            mySqlManager.con.Close();
            mySqlManager = null;
            classManager = null;
            subjectManager = null;
            mySqlManager.con.Close();
            mySqlManager = null;

            return returnList;
        }

        public List<Homework> GetHomeWorkForClass(string school, Class _class)
        {
            MySqlManager mySqlManager = new MySqlManager();
            subjectManager = new SubjectManager();
            classManager = new ClassManager();

            MySqlCommand getHomeworkCommand = new MySqlCommand($"SELECT * FROM homework WHERE school = '{school}' AND classUUID = '{_class.UUID}'", mySqlManager.con);
            MySqlDataReader homeworkReader = getHomeworkCommand.ExecuteReader();

            List<Homework> returnList = new List<Homework>();

            while (homeworkReader.Read())
            {
                string returnSchool = homeworkReader["school"].ToString();
                string returnSubject = homeworkReader["subjectUUID"].ToString();
                string returnTitle = homeworkReader["title"].ToString();
                string returnContent = homeworkReader["content"].ToString();
                string returnUUID = Convert.ToString(homeworkReader["UUID"]);
                string returnClass = homeworkReader["classUUID"].ToString();
                string returnDate = homeworkReader["duedate"].ToString();
                int returnExp = Convert.ToInt32(homeworkReader["exp"]);
                int returnIsTest = Convert.ToInt32(homeworkReader["istest"]);
                bool isTest = returnIsTest == 1;
                int returnForGrade = Convert.ToInt32(homeworkReader["forgrade"]);
                bool forGrade = returnForGrade == 1;

                Subject insertSubject = subjectManager.FindSubjectInDatabase(returnSubject);
                Class insertClass = classManager.GetClassFromDatabase(returnClass);

                returnList.Add(new Homework(returnTitle, insertSubject, returnContent, returnDate, insertClass, returnExp, isTest, returnUUID, forGrade));
            }

            homeworkReader.Close();

            mySqlManager.con.Close();
            mySqlManager = null;
            classManager = null;
            subjectManager = null;

            return returnList;
        }



        public void AddHomeworkToDB(string school, string title, string duedate, string content, string classUUID, string subjectUUID, int exp, bool isTest, bool forGrade)
        {
            MySqlManager mySqlManager = new MySqlManager();
            MySqlCommand addHomeworkCommand = new MySqlCommand($"INSERT INTO homework (subjectUUID, school, title, content, duedate, classUUID, exp, UUID, istest, forgrade) VALUES (@subjectUUID, @school, @title, @content, @duedate, @classUUID, @exp, @UUID, @istest, @forgrade)", mySqlManager.con);


            addHomeworkCommand.Parameters.AddWithValue("@subjectUUID", subjectUUID);
            addHomeworkCommand.Parameters.AddWithValue("@school", school);
            addHomeworkCommand.Parameters.AddWithValue("@title", title);
            addHomeworkCommand.Parameters.AddWithValue("@content", content);
            addHomeworkCommand.Parameters.AddWithValue("@duedate", duedate);
            addHomeworkCommand.Parameters.AddWithValue("@classUUID", classUUID);
            addHomeworkCommand.Parameters.AddWithValue("@exp", exp);
            addHomeworkCommand.Parameters.AddWithValue("@UUID", UUID);
            addHomeworkCommand.Parameters.AddWithValue("@istest", isTest);
            addHomeworkCommand.Parameters.AddWithValue("@forgrade", forGrade);


            addHomeworkCommand.Prepare();
            addHomeworkCommand.ExecuteNonQuery();

            mySqlManager.con.Close();
            mySqlManager = null;
        }

        public Homework GetHomeworkFromDatabase(string homeworkUUID)
        {
            MySqlManager mySqlManager = new MySqlManager();
            subjectManager = new SubjectManager();
            classManager = new ClassManager();

            MySqlCommand getHomeworkCommand = new MySqlCommand($"SELECT * FROM homework WHERE UUID = '{homeworkUUID}'", mySqlManager.con);
            MySqlDataReader homeworkReader = getHomeworkCommand.ExecuteReader();

            if (homeworkReader.Read())
            {
                string returnTitle = homeworkReader["Title"].ToString();
                string returnSubject = homeworkReader["subjectUUID"].ToString();
                string returnContent = homeworkReader["content"].ToString();
                string returnClass = homeworkReader["classUUID"].ToString();
                string returnDate = homeworkReader["duedate"].ToString();
                int returnExp = Convert.ToInt32(homeworkReader["exp"]);
                int returnIsTest = Convert.ToInt32(homeworkReader["istest"]);
                string returnUUID = Convert.ToString(homeworkReader["UUID"]);
                bool isTest = returnIsTest == 1;
                int returnForGrade = Convert.ToInt32(homeworkReader["forgrade"]);
                bool forGrade = returnForGrade == 1;

                homeworkReader.Close();

                Subject insertSubject = subjectManager.FindSubjectInDatabase(returnSubject);
                Class insertClass = classManager.GetClassFromDatabase(returnClass);

                mySqlManager.con.Close();
                mySqlManager = null;
                classManager = null;
                subjectManager = null;

                return new Homework(returnTitle, insertSubject, returnContent, returnDate, insertClass, returnExp, isTest, returnUUID, forGrade);
            }
            homeworkReader.Close();

            mySqlManager.con.Close();
            mySqlManager = null;
            classManager = null;
            subjectManager = null;

            return null;
        }
    }
}