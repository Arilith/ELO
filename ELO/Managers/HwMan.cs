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

        public static List<Homework> homeworkList { get; private set; }

        public HwMan()
        {
            homeworkList = new List<Homework>();
            homeworkSql = new HomeworkSQL();
        }

        public void AddHomework(string work, string subject, string dueDate, Class _class)
        {
            Homework homework = new Homework(subject, work, dueDate, _class);
            homeworkList.Add(homework);
        }
        public List<Homework> GetHomeworkList()
        {
            return homeworkList;
        }

        public Homework GetHomework(string name)
        {
            return homeworkList.Find(x => x.Work == name);
        }

        public List<Homework> GetHomeWorkFromDB(string school, string subject)
        {
            return homeworkSql.GetHomeWorkList(school, subject);
        }

        public void AddHomeWorkToDB(string school, string title, string duedate, string content, string classUUID,
            string subject)
        {
            homeworkSql.AddHomeworkToDB(school, title, duedate, content, classUUID, subject);
        }

    }
}
