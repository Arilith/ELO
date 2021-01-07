using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class GradeMan
    {
        public GradeSQL GradeSql;
        public UserMan userMan;
        public SubjectManager subjectManager;

        public GradeMan()
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

        public void AddGradeToDatabase(string school, string studentuuid, double grade, decimal weight, string subjectName)
        {
            userMan = new UserMan();
            subjectManager = new SubjectManager();
            Student student = userMan.GetStudent(studentuuid);
            Subject subject = subjectManager.FindSubject(subjectName);
            userMan = null;
            subjectManager = null;
            GradeSql.AddGradeToDB(school, studentuuid, grade, weight, subject, student);
        }

    }
}
