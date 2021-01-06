﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class HomeworkSQL
    {
        private MySqlManager MySqlManager;

        private SubjectManager subjectManager;
        private ClassManager classManager;

        public HomeworkSQL()
        {
            MySqlManager = new MySqlManager();
        }

        // public List<Homework> GetHomeWorkList(string school, string className, string subject)
        // {
        //
        // }


        public List<Homework> GetHomeWorkList(string school, string subject)
        {

            subjectManager = new SubjectManager();
            classManager = new ClassManager();

            MySqlCommand getHomeworkCommand = new MySqlCommand($"SELECT * FROM homework WHERE school = '{school}' AND subject = '{subject}'", MySqlManager.con);
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


                Subject insertSubject = subjectManager.FindSubject(returnSubject);
                Class insertClass = classManager.GetClassFromDatabase(returnClass);


                returnList.Add(new Homework(returnTitle, insertSubject, returnContent, returnDate, insertClass));

            }

            homeworkReader.Close();

            classManager = null;
            subjectManager = null;

            return returnList;
        }

        public void AddHomeworkToDB(string school, string title, string duedate, string content, string classUUID, string subject)
        {
            MySqlCommand addHomeworkCommand = new MySqlCommand($"INSERT INTO homework (subject, school, title, content, duedate, classUUID, subject) VALUES ({subject}, {school}, {title}, {content}, {duedate}, {classUUID}, {subject})", MySqlManager.con);
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

                string returnSubject = homeworkReader["subject"].ToString();
                string returnContent = homeworkReader["content"].ToString();
                string returnClass = homeworkReader["classUUID"].ToString();
                string returnDate = homeworkReader["duedate"].ToString();

                homeworkReader.Close();
                
                Subject insertSubject = subjectManager.FindSubjectInDatabase(returnSubject);
                Class insertClass = classManager.GetClassFromDatabase(returnClass);

                classManager = null;
                subjectManager = null;

                //return new Homework(returnContent, insertSubject, returnDate, insertClass);
            }
            homeworkReader.Close();

            classManager = null;
            subjectManager = null;

            return null;
        }
        
    }
}
