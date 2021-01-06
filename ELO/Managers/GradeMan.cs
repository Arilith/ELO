using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class GradeMan
    {
        public GradeSQL GradeSql;

        public GradeMan()
        {

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
