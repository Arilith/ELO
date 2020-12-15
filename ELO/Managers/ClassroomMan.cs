using System;
using System.Collections.Generic;
using System.Text;
using ELO;
using ELO.SQLClasses;

namespace ELO
{
    public class ClassroomMan
    {
        public List<Classroom> classroomList { get; private set; }
        private ClassroomSQL classroomSql;

        public ClassroomMan() {
            
            classroomList = new List<Classroom>();
            classroomSql = new ClassroomSQL();
        }
    

        public List<Classroom> GetClassroomList()
        {
            return classroomList;
        }

        public Classroom GetClassroom(int index)
        {
            return classroomList[index];
        }

        public Classroom GetClassroom(string name)
        {
            return classroomList.Find(x => x.Name == name);
        }

        public List<Classroom> GetClassroomList(string school)
        {
            return classroomSql.GetClassroomListFromDatabase(school);
        }
    }
}
