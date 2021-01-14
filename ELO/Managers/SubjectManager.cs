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


        public List<Teacher> GetTeachersBySubject(Subject subject)
        {
            subjectSql = new SubjectSQL();
            return subjectSql.GetTeachersBySubject(subject);
            subjectSql = null;
        }
        
        
        public void AddNewSubjectToDataBase(string subjectName, string school, string teachers, string icon)
        {
            subjectSql = new SubjectSQL();

            string[] teacherArray = teachers.Split(',');

            subjectSql.AddSubject(subjectName, teacherArray, school, icon);
            subjectSql = null;
        }

        public void UpdateSubjectTeachers(string subjectUUID, string teachers)
        {
            subjectSql = new SubjectSQL();
            subjectSql.UpdateTeachers(teachers, subjectUUID);
            subjectSql = null;
        }

        public Subject FindSubjectInDatabase(string uuid)
        {
            subjectSql = new SubjectSQL();
            return subjectSql.GetSubject(uuid);
            subjectSql = null;
        }

        public List<Subject> GetSubjectList(string school)
        {
            subjectSql = new SubjectSQL();
            return subjectSql.GetSubjectList(school);
            subjectSql = null;
        }

    }
}
