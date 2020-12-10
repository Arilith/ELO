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

        public List<Student> GetStudentList()
        {
            return personList.OfType<Student>().ToList();
        }

        public List<Teacher> GetTeacherList()
        {
            return personList.OfType<Teacher>().ToList();
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

    }
}