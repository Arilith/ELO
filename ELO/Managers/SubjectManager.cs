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
            subjectSql = new SubjectSQL();
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


        public List<Teacher> GetTeacherListBySubject(Subject subject)
        {
            return Subjects.Find(x => x.Name == subject.Name).Teachers;
        }

        // public void AddNewSubjectForm(string subjectName, string teachers)
        // {
        //     Subject newSubject = new Subject(subjectName);
        //     Subjects.Add(newSubject);
        //
        //     string[] teacherList = teachers.Split(',');
        //     foreach (string teacher in teacherList)
        //     {
        //         Teacher newTeacher = Manager.userMan.GetTeacher(teacher);
        //         AddTeacherToSubject(newTeacher, newSubject);
        //     }
        // }

        public void AddNewSubjectToDataBase(string subjectName, string school, string teachers, string icon)
        {
            subjectSql.AddSubject(subjectName, teachers, school, icon);
        }

        public void UpdateSubjectTeachers(string subjectUUID, string teachers)
        {
            subjectSql.UpdateTeachers(teachers, subjectUUID);
        }

        public Subject FindSubjectInDatabase(string uuid)
        {
            return subjectSql.GetSubject(uuid);
        }

        public List<Subject> GetSubjectList(string school)
        {
            return subjectSql.GetSubjectList(school);
        }

        public Subject FindSubjectUUID(string uuid)
        {
            return Subjects.Find(x => x.uuid == uuid);
        }
    }
}
