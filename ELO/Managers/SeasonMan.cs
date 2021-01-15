using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO.Managers
{
    public class SeasonMan
    {
        private SeasonSQL seasonSQL;
        public List<Season> Seasons { get; private set; }
        
        public SeasonMan()
        {
            seasonSQL = new SeasonSQL();
            Seasons = new List<Season>();
        }
        public void AddSeason(string startDate, string endDate, string seasonName)
        {
            seasonSQL.AddSeasonToDatabase(startDate, endDate, seasonName);
        }

        public Season FindSeasonInDB(string seasonUUID)
        {
            return Seasons.Find(x => x.UUID == seasonUUID);
        }

        public List<Season> getSeasonListFromDB(string school)
        {
            return seasonSQL.GetSeasonListFromDB(school);
        }
    }
}
