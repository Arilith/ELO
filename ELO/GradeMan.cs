using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    class GradeMan
    {
        public static List<Grade> gradelist {get; private set;}
        public GradeMan()
        {
            gradelist = new List<Grade>();
        }
    }
}
