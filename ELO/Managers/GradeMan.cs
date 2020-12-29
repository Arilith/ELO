using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class GradeMan
    {
        public static List<Grade> gradelist {get; private set;}

        public GradeSQL GradeSql;

        public GradeMan()
        {
            gradelist = new List<Grade>();
        }
        public void AddGradeToList(Student student, Class _class, double grade, string date, string subject, decimal weight)
        {
            //gradelist.Add(new Grade(student, _class , grade, date, subject, weight));
        }
        public List<Grade> GetGradeList()
        {
            return gradelist;
        }

        public void AddGradeToDataBase()
        {

        }

        public Grade GetGradeFromDataBase(string uuid)
        {

            Grade returnGrade = GradeSql.GetGrade(uuid);

            return returnGrade;
        }

        public List<Grade> GetGradeListFromDatabase(string useruuid, Subject subject, int year)
        {

            List<Grade> returnGradeList = GradeSql.GetGradeList(useruuid, subject, year);

            return returnGradeList;
        }

        public void AddGradeToDatabase(string school, string studentuuid, double grade, int weight, Subject subject, Student student)
        {
            GradeSql.AddGradeToDB(school, studentuuid, grade, weight, subject, student);
        }

    }
}
