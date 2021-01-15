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
        public HwMan homeworkManager;
        public GradeMan()
        {
        }


        public Grade GetGradeFromDataBase(string uuid)
        {
            gradeSql = new GradeSQL();
            Grade returnGrade = gradeSql.GetGrade(uuid);
            gradeSql = null;
            return returnGrade;
        }

        public List<Grade> GetGradeListFromDatabase(string useruuid, Subject subject, int year)
        {
            gradeSql = new GradeSQL();
            List<Grade> returnGradeList = gradeSql.GetGradeList(useruuid, subject, year);
            gradeSql = null;
            return returnGradeList;
        }

        public List<Grade> GetGradeListFromDatabase(string useruuid)
        {
            gradeSql = new GradeSQL();
            List<Grade> returnGradeList = gradeSql.GetGradeList(useruuid);
            gradeSql = null;
            return returnGradeList;
        }

        public void AddGradeToDatabase(string school, string studentuuid, double grade, decimal weight, string homeworkUUID)
        {
            userMan = new UserMan();
            subjectManager = new SubjectManager();
            homeworkManager = new HwMan();

            Student student = (Student)userMan.FindUserInDataBase(studentuuid);
            
            Homework homework = homeworkManager.GetHomeworkFromDB(homeworkUUID);
            Subject subject = homework.Subject;

            int xpToAdd = Convert.ToInt32(Math.Round(homework.Exp * (grade / 100)));

            userMan = null;
            subjectManager = null;
            gradeSql = new GradeSQL();
            gradeSql.AddGradeToDB(school, grade, weight, subject, student, homework, xpToAdd);
            gradeSql = null;
        }

        public List<Grade> GetRecentGrades(string studentUUID, int limit)
        {
            gradeSql = new GradeSQL();
            List<Grade> returnList = new List<Grade>(gradeSql.GetGradeListOfStudent(studentUUID, limit));
            gradeSql = null;
            return returnList;
        }
    }
}
