using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class GradeSQL
    {
        private MySqlManager _mySqlManager;
        private UserMan userManager;
        private SchoolManager schoolManager;
        private ClassManager classManager;
        private SubjectManager subjectManager;

        private double grade;
        private int weight;
        private string school;
        private string subjectString;
        private string uuid;
        private string gradeClass;
        private string date;
        private string studentuuid;
        private int year;
        private Homework homework;

        public GradeSQL()
        {
        }

        public void AddGradeToDB(string school, double grade, decimal weight, Subject subject, Student student, Homework homework)
        {
            _mySqlManager = new MySqlManager();
            MySqlCommand addGradeCommand = new MySqlCommand("INSERT INTO grades (school, grade, weight, subjectUUID, userUUID, classUUID, homeworkUUID) VALUES (@school, @grade, @weight, @subjectUUID, @userUUID, @classUUID, @homeworkUUID)", _mySqlManager.con);

            addGradeCommand.Parameters.AddWithValue("@school", school);
            addGradeCommand.Parameters.AddWithValue("@grade", grade);
            addGradeCommand.Parameters.AddWithValue("@weight", weight);
            addGradeCommand.Parameters.AddWithValue("@subjectUUID", subject.uuid);
            addGradeCommand.Parameters.AddWithValue("@userUUID", student.UserId);
            addGradeCommand.Parameters.AddWithValue("@classUUID", student.PartOfClass.UUID);
            addGradeCommand.Parameters.AddWithValue("@homeworkUUID", homework.UUID);

            addGradeCommand.Prepare();
            addGradeCommand.ExecuteNonQuery();
            _mySqlManager.con.Close();
            _mySqlManager = null;
        }

        public List<Grade> GetGradeList(string studentuuid)
        {
            //Initialize the managers
            _mySqlManager = new MySqlManager();
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
                GetItemsFromReader(Grades);

                //Get objects from the strings
                Student studentObj = (Student)userManager.FindUserInDataBase(studentuuid);
                Class gradeClassObj = classManager.GetClassFromDatabase(gradeClass);
                Subject gradeSubjectObj = subjectManager.FindSubjectInDatabase(subjectString);

                returnGrades.Add(new Grade(studentObj, gradeClassObj, grade, date, gradeSubjectObj, weight, year, homework));
            }

            _mySqlManager.con.Close();
            _mySqlManager = null;
            userManager = null;
            classManager = null;
            subjectManager = null;

            return returnGrades;
        }

        public List<Grade> GetGradeList(string studentuuid, Subject subjectObj, int year)
        {
            //Initialize the managers
            _mySqlManager = new MySqlManager();
            userManager = new UserMan();
            classManager = new ClassManager();
            subjectManager = new SubjectManager();

            //Make a new list to return eventually.
            List<Grade> returnGrades = new List<Grade>();

            //Get all grades where the user is the requested user.
            MySqlCommand GetGradesCmd = new MySqlCommand($"SELECT * FROM grades WHERE userUUID = '{studentuuid}' AND subjectUUID = '{subjectObj.uuid}'", _mySqlManager.con);
            MySqlDataReader Grades = GetGradesCmd.ExecuteReader();

            //Go through all roles
            while (Grades.Read())
            {
                //Initialize Fields
                GetItemsFromReader(Grades);

                //Get objects from the strings
                Student studentObj = (Student)userManager.FindUserInDataBase(studentuuid);
                Class gradeClassObj = classManager.GetClassFromDatabase(gradeClass);

                returnGrades.Add(new Grade(studentObj, gradeClassObj, grade, date, subjectObj, weight, year, homework));
            }

            _mySqlManager.con.Close();
            _mySqlManager = null;
            userManager = null;
            classManager = null;
            subjectManager = null;

            return returnGrades;
        }

        public List<Grade> GetGradeListOfStudent(string studentuuid, int limit)
        {
            //Initialize the managers
            _mySqlManager = new MySqlManager();
            userManager = new UserMan();
            classManager = new ClassManager();
            subjectManager = new SubjectManager();

            //Make a new list to return eventually.
            List<Grade> returnGrades = new List<Grade>();

            //Get all grades where the user is the requested user.
            MySqlCommand GetGradesCmd = new MySqlCommand($"SELECT * FROM grades WHERE userUUID = '{studentuuid}' ORDER BY Id DESC LIMIT {limit}", _mySqlManager.con);
            MySqlDataReader Grades = GetGradesCmd.ExecuteReader();

            //Go through all roles
            while (Grades.Read())
            {
                //Initialize Fields
                GetItemsFromReader(Grades);

                //Get objects from the strings
                Student studentObj = (Student)userManager.FindUserInDataBase(studentuuid);
                Class gradeClassObj = classManager.GetClassFromDatabase(gradeClass);
                string returnSubjectUUID = Grades["subjectUUID"].ToString();
                Subject returnSubject = subjectManager.FindSubjectInDatabase(returnSubjectUUID);

                returnGrades.Add(new Grade(studentObj, gradeClassObj, grade, date, returnSubject, weight, year, homework));
            }

            _mySqlManager.con.Close();
            _mySqlManager = null;
            userManager = null;
            classManager = null;
            subjectManager = null;

            return returnGrades;
        }

        public Grade GetGrade(string gradeuuid)
        {
            //Initialize the managers
            _mySqlManager = new MySqlManager();
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
                GetItemsFromReader(Grades);

                //Get objects from the strings
                Student studentObj = (Student)userManager.FindUserInDataBase(studentuuid);
                Class gradeClassObj = classManager.GetClassFromDatabase(gradeClass);
                Subject subjectObj = subjectManager.FindSubjectInDatabase(subjectString);

                returnGrade = new Grade(studentObj, gradeClassObj, grade, date, subjectObj, weight, year, homework);

                _mySqlManager.con.Close();
                _mySqlManager = null;
                classManager = null;
                subjectManager = null;

                return returnGrade;
            }

            _mySqlManager.con.Close();
            _mySqlManager = null;
            userManager = null;
            classManager = null;
            subjectManager = null;

            return null;
        }

        public void GetItemsFromReader(MySqlDataReader reader)
        {
            HwMan homeworkManager = new HwMan();

            //Initialize Fields
            grade = Convert.ToDouble(reader["grade"]);
            weight = Convert.ToInt32(reader["weight"]);
            school = Convert.ToString(reader["school"]);
            subjectString = Convert.ToString(reader["subjectUUID"]);
            uuid = Convert.ToString(reader["uuid"]);
            gradeClass = Convert.ToString(reader["classUUID"]);
            date = Convert.ToString(reader["date"]);
            studentuuid = Convert.ToString(reader["userUUID"]);
            year = Convert.ToInt32(reader["year"]);
            homework = homeworkManager.GetHomeworkFromDB(Convert.ToString(reader["homeworkUUID"]));
        }
    }
}