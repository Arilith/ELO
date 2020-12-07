using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class SubjectManager
    {
        public List<Subject> Subjects { get; private set; }

        public SubjectManager()
        {
            Subjects = new List<Subject>();
        }

        public Subject FindSubject(string name)
        {
            return Subjects.Find(x => x.Name == name);
        }

        public void AddTeacherToSubject(Teacher teacher, Subject subject)
        {
            Subjects.Find(x => x.Name == subject.Name).Teachers.Add(teacher);
        }

        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }

        public Subject FindSubject(Teacher teacher)
        {
            //HELP MEH
            // return Subjects.Find(x => x.Teachers.Find(y => y.Name == teacher.Name));
            return null;
        }

        public List<Subject> GetSubjectList()
        {
            return Subjects;
        }

    }
}
