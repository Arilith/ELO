using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    class GradeMan
    {
        public static List<Grade> gradelist {get; private set;}
        public GradeMan()
        {
            gradelist = new List<Grade>();
        }
        public void AddGradeToList(Student student, Class _class, decimal grade, string date, string subject, decimal weight)
        {
            gradelist.Add(new Grade(student, _class , grade, date, subject, weight));
        }
        public List<Grade> GetGradeList()
        {
            return gradelist;
        }
    }
}
