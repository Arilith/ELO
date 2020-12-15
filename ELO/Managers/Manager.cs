using System;
using System.Collections.Generic;
using System.Text;
using ELO;

namespace ELO
{
    public class Manager
    {
        public static ClassManager classMan = new ClassManager();
        public static UserMan userMan = new UserMan();
        public static BookMan bookMan = new BookMan();
        public static GradeMan gradeMan = new GradeMan();
        public static HwMan hwMan = new HwMan();
        public static FileManager fileMan = new FileManager();
        public static SubjectManager subjectMan = new SubjectManager();
        public static SchoolManager schoolManager = new SchoolManager();
        public static TodayMan todayMan = new TodayMan();
        public static ClassroomMan classroomMan = new ClassroomMan();
        public static LeermiddelMan leermiddelMan = new LeermiddelMan();

    }
}
