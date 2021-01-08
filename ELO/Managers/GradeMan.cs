using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class GradeMan
    {
        public GradeSQL gradeSql;
        public UserMan userMan;
        public SubjectManager subjectManager;

        public GradeMan()
        {
            gradeSql = new GradeSQL();
        }


        public Grade GetGradeFromDataBase(string uuid)
        {
            Grade returnGrade = gradeSql.GetGrade(uuid);

            return returnGrade;
        }

        public List<Grade> GetGradeListFromDatabase(string useruuid, Subject subject, int year)
        {

            List<Grade> returnGradeList = gradeSql.GetGradeList(useruuid, subject, year);

            return returnGradeList;
        }

        public List<Grade> GetGradeListFromDatabase(string useruuid)
        {

            List<Grade> returnGradeList = gradeSql.GetGradeList(useruuid);

            return returnGradeList;
        }

        public void AddGradeToDatabase(string school, string studentuuid, double grade, decimal weight, string subjectName)
        {
            userMan = new UserMan();
            subjectManager = new SubjectManager();
            Student student = (Student)userMan.FindUserInDataBase(studentuuid);
            Subject subject = subjectManager.FindSubjectInDatabase(subjectName);
            userMan = null;
            subjectManager = null;
            gradeSql.AddGradeToDB(school, grade, weight, subject, student);
        }

    }
}
