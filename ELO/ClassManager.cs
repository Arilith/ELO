using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class ClassManager
    {

        public List<Class> classList { get; private set; }

        public ClassManager()
        {
            classList = new List<Class>();

            classList.Add(new Class("PD-B-18", 20));
            classList.Add(new Class("PD-B-16", 15));
            classList.Add(new Class("PD-B-17", 24));
        }

        public List<Class> GetClassList()
        {
            return classList;
        }

        public Class GetClass(int index)
        {
            return classList[index];
        }

        public void AddNewClass(string name, int amountOfStudents)
        {
            classList.Add(new Class(name, amountOfStudents));
        }

    }
}
