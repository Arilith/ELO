using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class SubjectManager
    {
        private SubjectSQL subjectSql;

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

            Subject foundSubject = Subjects.Find(x => x.Name == subject.Name);

            //Check of er wel een leraar is ingevuld. Anders niet invoegen.
            if(teacher != null)
            {
                foundSubject.Teachers.Add(teacher);
            }
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

        public List<Teacher> GetTeacherListBySubject(Subject subject)
        {
            return Subjects.Find(x => x.Name == subject.Name).Teachers;
        }

        public void AddNewSubjectForm(string subjectName, string teachers)
        {
            Subject newSubject = new Subject(subjectName);
            Subjects.Add(newSubject);

            string[] teacherList = teachers.Split(',');
            foreach (string teacher in teacherList)
            {
                Teacher newTeacher = Manager.userMan.GetTeacher(teacher);
                AddTeacherToSubject(newTeacher, newSubject);
            }
        }

        public Subject FindSubjectInDatabase(string uuid)
        {
            return subjectSql.GetSubject(uuid);
        }

    }
}
