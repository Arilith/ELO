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

        public ExamMan()
        {
            examSql = new ExamSQL();
        }

        public List<Exam> GetExamListFromDB(string school, string _class)
        {
            return examSql.GetExamListFromDatabase(school, _class);
        }
        
        public void AddExamToDB(string UUID, int weight, string subjectUUID, string _classUUID, string school)
        {
            examSql.AddExamToDatabase(UUID, weight, subjectUUID, _classUUID, school);
        }
    }
}

