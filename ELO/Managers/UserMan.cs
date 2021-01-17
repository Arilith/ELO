using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class UserMan
    {
        private UserSQL userSQL;

        private ClassManager classMan;

        public UserMan()
        {
            userSQL = new UserSQL();
        }

        public List<Person> GetPersonListFromDB(string school, string type)
        {
            return userSQL.GetList(school, type);
        }

        public List<Person> GetPersonList(string type, string school)
        {
            return userSQL.GetUserList(type, school);
        }

        public void AddStudentsToDatabase(List<CSVStudent> students, string school)
        {
            userSQL.AddStudents(students, school);
        }
        
        public Person FindUserInDataBase(string username, string password, int leerlingnummer, string school, string type)
        {
            return userSQL.FindUserInDataBase(username, password, leerlingnummer, school, type);
        }

        public Person FindUserInDataBase(string uuid)
        {
            return userSQL.FindUserInDataBase(uuid);
        }
        public SysAdmin AddSysAdminToDataBase(string username, string password, string school, string name, string email)
        {
            SysAdmin newAdmin = userSQL.AddAdmin(username, password, school, name, email, 0);

            return newAdmin;
        }

        public Teacher AddTeacherToDataBase(string username, string password, Person loggedInperson, string name, string email, string subjectUUID, string classUUID)
        {
            string school = loggedInperson.School;

            Teacher newTeacher = userSQL.AddTeacher(username, password, school, name, email, 0, subjectUUID, classUUID);

            return newTeacher;
        }

        public string AddStudentToDataBase(int leerlingnummer, string password, string name, string email, string classUUID, Person loggedInPerson)
        {
            classMan = new ClassManager();

            string school = loggedInPerson.School;
            string userName = name.Replace(" ", "");

            string mentorUUID;

            Class fetchedClass = classMan.GetClassFromDatabase(classUUID);
            if (fetchedClass.Mentor != null)
                mentorUUID = fetchedClass.Mentor.UserId;
            else
                return "Je moet eerst een mentor invoeren bij deze klas voordat je er leerlingen bij kan voegen!";

            Student newStudent = userSQL.AddStudent(userName, password, leerlingnummer, school, name, email, classUUID, mentorUUID, 0);

            if (newStudent != null)
                return "Student met success toegevoegd!";
            else
                return "Er is iets fout gegaan met het toevoegen bij de studenten.";

        }

        public List<Student> GetStudentsOfClass(string classUUID, int limit)
        {
            return userSQL.FindStudentsInClass(classUUID, limit);
        }

    }
}