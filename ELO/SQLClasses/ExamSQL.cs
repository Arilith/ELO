using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class ExamSQL
    {
        private MySqlManager mySqlManager;
        private Class _class;
        private SubjectManager subjectManager;
        private ClassManager classManager;
        private SchoolManager schoolManager;

        public ExamSQL()
        {
        }

        public List<Exam> GetExamListFromDatabase(string school, string _classUUID)
        {
            mySqlManager = new MySqlManager();
            subjectManager = new SubjectManager();
            classManager = new ClassManager();

            MySqlCommand getExamCommand = new MySqlCommand($"SELECT * FROM exams WHERE school = '{school}' AND classUUID = '{_classUUID}'", MySqlManager.con);
            MySqlDataReader ExamReader = getExamCommand.ExecuteReader();
            List<Exam> returnList = new List<Exam>();

            while (ExamReader.Read())
            {
                string returnUUID = ExamReader["UUID"].ToString();
                int returnWeight = Convert.ToInt32(ExamReader["weight"]);
                string returnSubjectUUID = ExamReader["subjectUUID"].ToString();
                string returnClassUUID = ExamReader["classUUID"].ToString();
                string returnSchool = ExamReader["school"].ToString();

                Subject insertSubject = subjectManager.FindSubject(returnSubjectUUID);
                Class insertClass = classManager.GetClassFromDatabase(returnClassUUID);

                returnList.Add(new Exam(returnUUID, insertSubject, returnWeight, insertClass, returnSchool));
            }

            ExamReader.Close();
            mySqlManager.con.Close();
            mySqlManager = null;
            return returnList;
        }

        public void AddExamToDatabase(string UUID, int weight, string subjectUUID, string _classUUID, string school)
        {
            mySqlManager = new MySqlManager();
            MySqlCommand addExamCommand = new MySqlCommand($"INSERT INTO appointments (UUID, weight, subjectUUID, classUUID, school) VALUES ({UUID}, {weight}, {subjectUUID}, {_classUUID}, {school})", MySqlManager.con);
            addExamCommand.ExecuteNonQuery();
            mySqlManager.con.Close();
            mySqlManager = null;
        }
    }
}