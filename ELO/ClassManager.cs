using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class ClassManager
    {

        public List<Class> classList { get; private set; }

        public ClassManager()
        {
            classList = new List<Class>();

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

        public void AddNewClass(string name, int amountOfStudents, string leshuis, string stream, string cluster, int studyYear, Teacher mentorTeacher)
        {
            classList.Add(new Class(name, amountOfStudents, cluster, leshuis, stream, studyYear, mentorTeacher));
        }

    }
}
