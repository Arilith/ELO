using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELO.SQLClasses;
using ELO;

namespace ELO
{
    public class ExamMan
    {
        public ExamSQL examSql;
        public List<Exam> examList { get; private set; }

        public ExamMan()
        {
            examList = new List<Exam>();
            examSql = new ExamSQL();
        }

        public List<Exam> GetExamListFromDB(string school, string _class)
        {
            return examSql.GetExamListFromDatabase(school, _class);
        }

        public Exam GetExam(string uuid)
        {
            return examList.Find(x => x.UUID == uuid);
        }

        public void AddExamToDB(string UUID, int weight, string subjectUUID, string _classUUID, string school)
        {
            examSql.AddExamToDatabase(UUID, weight, subjectUUID, _classUUID, school);
        }
    }
}

