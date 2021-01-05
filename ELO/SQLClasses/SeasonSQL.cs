using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
    public class SeasonSQL
    {
        private string UUID = "lul";
        private MySqlManager mySqlManager;
        public SeasonSQL()
        {
            mySqlManager = new MySqlManager();
        }

        public void AddSeasonToDatabase(string startDate, string endDate, string seasonName)
        {
            MySqlCommand addSeasonCommand = new MySqlCommand($"insert into seasons (name, endDate, startDate, UUID) values (@name, @endDate, @startDate, @UUID)", mySqlManager.con);

            addSeasonCommand.Parameters.AddWithValue("@name", seasonName);
            addSeasonCommand.Parameters.AddWithValue("@endDate", endDate);
            addSeasonCommand.Parameters.AddWithValue("@startDate", startDate);
            addSeasonCommand.Parameters.AddWithValue("@UUID", UUID);
            addSeasonCommand.Prepare();

            addSeasonCommand.ExecuteNonQuery();

        }

        public List<Season> GetSeasonListFromDB(string school)
        {
            List<Season> returnList = new List<Season>();
            MySqlCommand ReadSeasonSqlCommand = new MySqlCommand($"SELECT * FROM seasons WHERE school = {school}", mySqlManager.con);
            MySqlDataReader readSeasonDataReader = ReadSeasonSqlCommand.ExecuteReader();
            while (readSeasonDataReader.Read())
            {
                string returnStartDate =Convert.ToString(readSeasonDataReader["startDate"]);
                string returnEndDate = Convert.ToString(readSeasonDataReader["endDate"]);
                string returnSeasonName = Convert.ToString(readSeasonDataReader["name"]);
                Season newSeason = new Season(returnStartDate, returnEndDate, returnSeasonName);
                returnList.Add(newSeason);
            }
            return returnList;
        }
    }
}
