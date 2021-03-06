﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELO.SQLClasses;
using ELO;

namespace ELO
{
    public class HwMan
    {
        public HomeworkSQL homeworkSql;

        public HwMan()
        {
            homeworkSql = new HomeworkSQL();
        }

        public Homework GetHomeworkFromDB(string homeworkUUID)
        {
            return homeworkSql.GetHomeworkFromDatabase(homeworkUUID);
        }

        public List<Homework> GetHomeWorkForClassFromDB(string school, Class _class)
        {
            return homeworkSql.GetHomeWorkForClass(school, _class);
        }

        public List<Homework> GetHomeworkForSubjectFromDB(string school, Subject subject)
        {
            return homeworkSql.GetHomeworkForSubject(school, subject);
        }

        public List<Homework> GetHomeWorkFromDB(string school)
        {
            return homeworkSql.GetHomeWorkList(school);
        }

        public void AddHomeWorkToDB(string school, string title, string duedate, string content, string classUUID,
            string subject, int exp, bool isTest, bool ForGrade)
        {
            homeworkSql.AddHomeworkToDB(school, title, duedate, content, classUUID, subject, exp, isTest, ForGrade);
        }

        public List<Homework> GetHomeworkOfStudentFromDatabase(string loggedInStudentClassUUID, int limit)
        {
            return homeworkSql.GetHomeworkOfStudent(loggedInStudentClassUUID, limit);
        }
    }
}
