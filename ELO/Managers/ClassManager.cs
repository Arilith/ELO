using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class ClassManager
    {

        private ClassSQL classSql;

        public ClassManager()
        {
            classSql = new ClassSQL();
        }

        public void AddNewClassToDatabase(string name, string leshuis, string stream, string cluster, int studyYear, Person loggedInPerson)
        {
            string school = loggedInPerson.School;
            classSql.CreateClass(name, stream, cluster, leshuis, studyYear, school);
        }

        public Class GetClassFromDatabase(string uuid)
        {
            return classSql.GetClass(uuid);
        }

        public string GetClassUUIDFromDatabase(string className)
        {
            return GetClassFromDatabase(className).UUID;
        }

        public List<Class> GetClassListFromDatabase(string school, string level)
        {
            return classSql.GetClassList(school, level);
        }
        public List<Class> GetClassListFromDatabase(string school)
        {
            return classSql.GetClassList(school);
        }

        public Class GetClassFromClassList(string school, string className)
        {
            return classSql.GetClassList(school).Find(x => x.Name == className);
        }

        public int GetAmountOfStudentsInClass(string classUUID)
        {

            return classSql.GetAmountOfStudents(classUUID);
        }
        public List<Student> GetStudentsInClass(string classUUID)
        {
            return classSql.GetStudentsInClass(classUUID);
        }

        public void UpdateMentor(string classUUID, string mentorUUID)
        {
            classSql.UpdateMentor(classUUID, mentorUUID);
        }

    }
}
