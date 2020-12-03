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

        public void AddHomeworkToList(string work, string subject, string dueDate, string _class)
        {
            homeworkList.Add(new Homework(subject, work, dueDate, _class));
        }
        public List<Homework> GetHomeworkList()
        {
            return homeworkList;
        }
       


    }
}
