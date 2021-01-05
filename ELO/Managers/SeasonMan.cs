using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO.Managers
{
    public class SeasonMan
    {
        private SeasonSQL seasonSQL;
        public SeasonMan()
        {
            seasonSQL = new SeasonSQL();
        }
        public void AddSeason(string startDate, string endDate, string seasonName)
        {
            seasonSQL.AddSeasonToDatabase(startDate, endDate, seasonName);
        }
    }
}
