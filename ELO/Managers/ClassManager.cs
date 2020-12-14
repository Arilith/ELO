using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class ClassManager
    {

        public List<Class> classList { get; private set; }

        private ClassSQL classSql;

        public ClassManager()
        {
            classList = new List<Class>();
            classSql = new ClassSQL();
        }

        public List<Class> GetClassList()
        {
            return classList;
        }

        public Class GetClass(int index)
        {
            return classList[index];
        }

        public Class GetClass(string name)
        {
            return classList.Find(x => x.Name == name);
        }

        // public void AddNewClass(string name, int amountOfStudents, string leshuis, string stream, string cluster, int studyYear, Teacher mentorTeacher)
        // {
        //     classList.Add(new Class(name, amountOfStudents, cluster, leshuis, stream, studyYear, mentorTeacher));
        // }

        public void AddNewClassToDatabase(string name, string leshuis, string stream, string cluster, int studyYear, Person loggedInPerson)
        {
            string school = loggedInPerson.School;
            classSql.CreateClass(name, stream, cluster, leshuis, studyYear, school);
        }

        public Class GetClassFromDatabase(string uuid)
        {
            return classSql.GetClass(uuid);
        }


        public List<Class> GetClassListFromDatabase(string school, string level)
        {
            return classSql.GetClassList(school, level);
        }
        public List<Class> GetClassListFromDatabase(string school)
        {
            return classSql.GetClassList(school);
        }

        public int GetAmountOfStudentsInClass(string classUUID)
        {

            return classSql.GetAmountOfStudents(classUUID);
        }

        public List<Student> GetStudentsInClass(string classUUID)
        {
            return classSql.GetStudentsInClass(classUUID);
        }

    }
}
