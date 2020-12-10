using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    class TodayMan
    {
        public static List<Day> LessonList { get; private set; }

        public TodayMan()
        {
            LessonList = new List<Day>();
        }
    }
}
