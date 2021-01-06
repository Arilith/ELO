using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO//.Managers
{
    public class SchoolManager
    {

        private SchoolSQL schoolSQL;

        
        public SchoolManager()
        {
            schoolSQL = new SchoolSQL();
        }

        public List<String> GetSchoolList()
        {
            return schoolSQL.GetSchools();
        }
        
    }
}
