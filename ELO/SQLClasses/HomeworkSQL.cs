using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class HomeworkSQL
    {
        private MySqlManager MySqlManager;

        private SubjectManager subjectManager;
        private ClassManager classManager;

        private string UUID = "Huiswerk";

        public HomeworkSQL()
        {
            MySqlManager = new MySqlManager();
        }

        // public List<Homework> GetHomeWorkList(string school, string className, string subject)
        // {
        //
        // }

        public List<Homework> GetHomeWorkList(string school)
        {
            subjectManager = new SubjectManager();
            classManager = new ClassManager();

            MySqlCommand getHomeworkCommand = new MySqlCommand($"SELECT * FROM homework WHERE school = '{school}'", MySqlManager.con);
            MySqlDataReader homeworkReader = getHomeworkCommand.ExecuteReader();

            List<Homework> returnList = new List<Homework>();

            while (homeworkReader.Read())
            {
                string returnSchool = homeworkReader["school"].ToString();
                string returnSubject = homeworkReader["subject"].ToString();
                string returnTitle = homeworkReader["title"].ToString();
                string returnContent = homeworkReader["content"].ToString();
                int returnId = Convert.ToInt32(homeworkReader["Id"]);
                string returnClass = homeworkReader["classUUID"].ToString();
                string returnDate = homeworkReader["duedate"].ToString();
                int returnExp = Convert.ToInt32(homeworkReader["exp"]);


                Subject insertSubject = subjectManager.FindSubject(returnSubject);
                Class insertClass = classManager.GetClassFromDatabase(returnClass);

                returnList.Add(new Homework(returnTitle, insertSubject, returnContent, returnDate, insertClass, returnExp));
            }

            homeworkReader.Close();

            classManager = null;
            subjectManager = null;

            return returnList;
        }

        public List<Homework> GetHomeWorkForClass(string school, Class _class)
        {
            throw new NotImplementedException();
        }

        public void AddHomeworkToDB(string school, string title, string duedate, string content, string classUUID, string subject, int exp)
        {
            MySqlCommand addHomeworkCommand = new MySqlCommand($"INSERT INTO homework (subject, school, title, content, duedate, classUUID, exp, UUID) VALUES ('{subject}', '{school}', '{title}', '{content}', '{duedate}', '{classUUID}', '{exp}', '{UUID}')", MySqlManager.con);
            addHomeworkCommand.ExecuteNonQuery();
        }

        public Homework GetHomeworkFromDatabase(string homeworkUUID)
        {
            subjectManager = new SubjectManager();
            classManager = new ClassManager();

            MySqlCommand getHomeworkCommand = new MySqlCommand($"SELECT * FROM homework WHERE UUID = '{homeworkUUID}'", MySqlManager.con);
            MySqlDataReader homeworkReader = getHomeworkCommand.ExecuteReader();

            if (homeworkReader.Read())
            {
                string returnTitle = homeworkReader["Title"].ToString();
                string returnSubject = homeworkReader["subject"].ToString();
                string returnContent = homeworkReader["content"].ToString();
                string returnClass = homeworkReader["classUUID"].ToString();
                string returnDate = homeworkReader["duedate"].ToString();
                int returnExp = Convert.ToInt32(homeworkReader["exp"]);


                homeworkReader.Close();

                Subject insertSubject = subjectManager.FindSubjectInDatabase(returnSubject);
                Class insertClass = classManager.GetClassFromDatabase(returnClass);

                classManager = null;
                subjectManager = null;

                return new Homework(returnTitle, insertSubject, returnContent, returnDate, insertClass, returnExp);
            }
            homeworkReader.Close();

            classManager = null;
            subjectManager = null;

            return null;
        }
    }
}