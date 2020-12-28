using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace ELO.SQLClasses
{
    public class GradeSQL
    {

        private readonly MySqlManager _mySqlManager;
        private UserMan userManager;
        private SchoolManager schoolManager;
        private ClassManager classManager;
        private SubjectManager subjectManager;

        public GradeSQL()
        {
            _mySqlManager = new MySqlManager();

        }


        public void AddGradeToDB(string school, string studentuuid, double grade, int weight, Subject subject)
        {

        }

        public List<Grade> GetGradeList(string studentuuid)
        {
            //Initialize the managers
            userManager = new UserMan();
            classManager = new ClassManager();
            subjectManager = new SubjectManager();

            //Make a new list to return eventually.
            List<Grade> returnGrades = new List<Grade>();

            //Get all grades where the user is the requested user.
            MySqlCommand GetGradesCmd = new MySqlCommand($"SELECT * FROM grades WHERE userUUID = '{studentuuid}'", _mySqlManager.con);
            MySqlDataReader Grades = GetGradesCmd.ExecuteReader();

            //Go through all roles
            while (Grades.Read())
            {
                //Initialize Fields
                double grade = Convert.ToDouble(Grades["grade"]);
                int weight = Convert.ToInt32(Grades["weight"]);
                string school = Convert.ToString(Grades["school"]);
                string subject = Convert.ToString(Grades["subjectUUID"]);
                string uuid = Convert.ToString(Grades["uuid"]);
                string gradeClass = Convert.ToString(Grades["classUUID"]);
                string date = Convert.ToString(Grades["date"]);

                //Get objects from the strings
                Student studentObj = (Student)userManager.FindUserInDataBase(studentuuid);
                Class gradeClassObj = classManager.GetClassFromDatabase(gradeClass);
                Subject gradeSubjectObj = subjectManager.FindSubjectInDatabase(subject);

                returnGrades.Add(new Grade(studentObj, gradeClassObj, grade, date, gradeSubjectObj, weight));

            }

            return returnGrades;
        }

        public List<Grade> GetGradeList(string studentuuid, Subject subjectObj)
        {

            //Initialize the managers
            userManager = new UserMan();
            classManager = new ClassManager();
            subjectManager = new SubjectManager();

            //Make a new list to return eventually.
            List<Grade> returnGrades = new List<Grade>();


            //Get all grades where the user is the requested user.
            MySqlCommand GetGradesCmd = new MySqlCommand($"SELECT * FROM grades WHERE userUUID = '{studentuuid}' AND subjectUUID = {subjectObj.uuid}", _mySqlManager.con);
            MySqlDataReader Grades = GetGradesCmd.ExecuteReader();

            //Go through all roles
            while (Grades.Read())
            {
                //Initialize Fields
                double grade = Convert.ToDouble(Grades["grade"]);
                int weight = Convert.ToInt32(Grades["weight"]);
                string school = Convert.ToString(Grades["school"]);
                string subjectString = Convert.ToString(Grades["subjectUUID"]);
                string uuid = Convert.ToString(Grades["uuid"]);
                string gradeClass = Convert.ToString(Grades["classUUID"]);
                string date = Convert.ToString(Grades["date"]);

                //Get objects from the strings
                Student studentObj = (Student)userManager.FindUserInDataBase(studentuuid);
                Class gradeClassObj = classManager.GetClassFromDatabase(gradeClass);

                returnGrades.Add(new Grade(studentObj, gradeClassObj, grade, date, subjectObj, weight));

            }

            return returnGrades;

        }

        public Grade GetGrade(string gradeuuid)
        {

            //Initialize the managers
            userManager = new UserMan();
            classManager = new ClassManager();
            subjectManager = new SubjectManager();

            //Make a new list to return eventually.
            Grade returnGrade;


            //Get all grades where the user is the requested user.
            MySqlCommand GetGradesCmd = new MySqlCommand($"SELECT * FROM grades WHERE uuid = '{gradeuuid}'", _mySqlManager.con);
            MySqlDataReader Grades = GetGradesCmd.ExecuteReader();



            //Go through all roles
            if (Grades.Read())
            {
                //Initialize Fields
                double grade = Convert.ToDouble(Grades["grade"]);
                int weight = Convert.ToInt32(Grades["weight"]);
                string school = Convert.ToString(Grades["school"]);
                string subjectString = Convert.ToString(Grades["subjectUUID"]);
                string uuid = Convert.ToString(Grades["uuid"]);
                string gradeClass = Convert.ToString(Grades["classUUID"]);
                string date = Convert.ToString(Grades["date"]);
                string studentuuid = Convert.ToString(Grades["studentUUID"]);
                //Get objects from the strings
                Student studentObj = (Student)userManager.FindUserInDataBase(studentuuid);
                Class gradeClassObj = classManager.GetClassFromDatabase(gradeClass);
                Subject subjectObj = subjectManager.FindSubjectInDatabase(subjectString);

                returnGrade = new Grade(studentObj, gradeClassObj, grade, date, subjectObj, weight);
                return returnGrade;

            }

            return null;
        }

    }
}
