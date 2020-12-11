using System;
using System.Collections.Generic;
using System.Text;
using ELO;

namespace ELO
{
    public class ClassroomMan
    {
        public List<Classroom> classroomList { get; private set; }

        public ClassroomMan() {
            
            classroomList = new List<Classroom>();

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
    }
}
