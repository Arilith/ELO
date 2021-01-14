using System;
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
        }

        public Homework GetHomeworkFromDB(string homeworkUUID)
        {
            homeworkSql = new HomeworkSQL();
            return homeworkSql.GetHomeworkFromDatabase(homeworkUUID);
            homeworkSql = null;
        }

        public List<Homework> GetHomeWorkForClassFromDB(string school, Class _class)
        {
            homeworkSql = new HomeworkSQL();
            return homeworkSql.GetHomeWorkForClass(school, _class);
            homeworkSql = null;
        }

        public List<Homework> GetHomeworkForSubjectFromDB(string school, Subject subject)
        {
            homeworkSql = new HomeworkSQL();
            return homeworkSql.GetHomeworkForSubject(school, subject);
            homeworkSql = null;
        }

        public List<Homework> GetHomeWorkFromDB(string school)
        {
            homeworkSql = new HomeworkSQL();
            return homeworkSql.GetHomeWorkList(school);
            homeworkSql = null;
        }

        public void AddHomeWorkToDB(string school, string title, string duedate, string content, string classUUID,
            string subject, int exp, bool isTest, bool ForGrade)
        {
            homeworkSql = new HomeworkSQL();
            homeworkSql.AddHomeworkToDB(school, title, duedate, content, classUUID, subject, exp, isTest, ForGrade);
            homeworkSql = null;
        }

    }
}
