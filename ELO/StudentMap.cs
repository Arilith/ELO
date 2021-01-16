using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;

namespace ELO
{
    public class StudentMap : ClassMap<Student>
    {

        public ClassManager classManager;

        public StudentMap(string school)
        {
            classManager = new ClassManager();
            

            Map(m => m.Name).Name("name");

        }

    }
}
