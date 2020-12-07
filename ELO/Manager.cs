using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Manager
    {
        public static ClassManager classMan = new ClassManager();
        public static UserMan userMan = new UserMan();
        public static BookMan bookMan = new BookMan();
        public static GradeMan gradeMan = new GradeMan();
        public static HwMan hwMan = new HwMan();
        public static DB db = new DB();
    }


}
