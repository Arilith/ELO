/*
using System;
using System.Collections.Generic;
using System.Text;

namespace ELO.Managers
{
    class ExamMan
    {
        private ExamSQL examSQL;
        public List<Exam> examList { get; private set; }

        public ExamManager()
        {
            examList = new List<Exam>();
            examSQL = new examSQL();
        }

        public List<Exam> GetExamList()
        {
            return examSQL.GetSchools();
        }

        public School GetSchool(string uuid)
        {
            return examList.Find(x => x.uuid == uuid);
        }
    }
}
*/
