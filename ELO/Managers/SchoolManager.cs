using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO.Managers
{
    public class SchoolManager
    {

        private SchoolSQL schoolSQL;


        public List<School> schools { get; private set; }

        public SchoolManager()
        {
            schools = new List<School>();
            schoolSQL = new SchoolSQL();
        }

        public List<School> GetSchoolList()
        {
            return schoolSQL.GetSchools();
        }

    }
}
