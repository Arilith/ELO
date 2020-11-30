using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELO
{
    public class UserMan
    {
        public List<Person> personList;

        public UserMan()
        {
            personList = new List<Person>();
        }

        public void AddStudentToPersonList(string name, int age, string school, Class clazz, Teacher mentor)
        {
            personList.Add(new Student(name, age, school, "Student", clazz, mentor));
        }

        public void AddTeacherToPersonList(string name, int age, string school, bool hasGroup, string subject, Class clazz)
        {
            personList.Add(new Teacher(name, age, school, "Teacher", hasGroup, subject, clazz));
        }

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

        public Teacher GetTeacher(string name)
        {
            return (Teacher)GetPersonList().Find(x => x.Name == name);
        }

        public Student GetStudent(string name)
        {
            return (Student)GetPersonList().Find(x => x.Name == name);
        }

        public Person GetPerson(string name)
        {
            return GetPersonList().Find(x => x.Name == name);
        }
    }
}