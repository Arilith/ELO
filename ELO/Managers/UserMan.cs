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

        public static List<Person> personList { get; private set; }

        public UserMan()
        {
            userSQL = new UserSQL();
            personList = new List<Person>();

        }

        // public void AddStudentToPersonList(string name, int age, string school, Class _class, Teacher mentor)
        // {
        //     personList.Add(new Student(name, age, school, "Student", _class, mentor));
        // }
        //
        // public void AddTeacherToPersonList(string name, int age, string school, bool hasGroup, Subject subject, Class _class)
        // {
        //     personList.Add(new Teacher(name, age, school, "Teacher", hasGroup, subject, _class));
        // }
        //
        // public void AddTeacherToPersonList(string name, int age, string school, bool hasGroup, Subject subject)
        // {
        //     personList.Add(new Teacher(name, age, school, "Teacher", hasGroup, subject));
        // }
        //
        // public void AddAdminToPersonList(string name, int age, string school)
        // {
        //     personList.Add(new SysAdmin(name, age, school, "SysAdmin"));
        // }



        public List<Person> GetPersonList()
        {
            return personList;
        }
        public List<Person> GetPersonListFromDB(string school, string type)
        {
            return userSQL.GetList(school, type);
        }

        public List<Student> GetStudentList()
        {
            return personList.OfType<Student>().ToList();
        }

        public List<Person> GetPersonList(string type, string school)
        {
            return userSQL.GetUserList(type, school);
        }

        public List<SysAdmin> GetAdminList()
        {
            return personList.OfType<SysAdmin>().ToList();
        }

        public Teacher GetTeacher(string name)
        {
            return (Teacher)GetPersonList().Find(x => x.Name == name);
        }

        public Student GetStudent(string name)
        {
            return (Student)GetPersonList().Find(x => x.Name == name);
        }

        public SysAdmin GetAdmin(string name)
        {
            return (SysAdmin)GetPersonList().Find(x => x.Name == name);
        }

        public Person GetPerson(string name)
        {
            return GetPersonList().Find(x => x.Name == name);
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
            SysAdmin newAdmin = userSQL.AddAdmin(username, password, school, name, email);

            return newAdmin;
        }

        public Teacher AddTeacherToDataBase(string username, string password, Person loggedInperson, string name, string email)
        {
            string school = loggedInperson.School;

            Teacher newTeacher = userSQL.AddTeacher(username, password, school, name, email);

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

            Student newStudent = userSQL.AddStudent(userName, password, leerlingnummer, school, name, email, classUUID, mentorUUID);

            if (newStudent != null)
                return "Student met success toegevoegd!";
            else
                return "Er is iets fout gegaan met het toevoegen bij de studenten.";

        }

        public List<Student> GetStudentsOfClass(string classUUID)
        {
            return userSQL.FindStudentsInClass(classUUID);
        }

    }
}