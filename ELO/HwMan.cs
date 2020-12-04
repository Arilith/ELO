using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELO
{
    public class HwMan
    {

        public static List<Homework> homeworkList { get; private set; }

        public HwMan()
        {
            homeworkList = new List<Homework>();
        }

        public void AddHomework(string work, string subject, string dueDate, Class _class)
        {
            Homework homework = new Homework(subject, work, dueDate, _class);
            homeworkList.Add(homework);
        }
        public List<Homework> GetHomeworkList()
        {
            return homeworkList;
        }
       


    }
}
