﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class SeasonSQL
    {
        private string UUID;
        private MySqlManager mySqlManager;

        public SeasonSQL()
        {
            UUID = new Random().Next().ToString() + DateTime.Now.ToString("s");
        }

        public void AddSeasonToDatabase(string startDate, string endDate, string seasonName, string school)
        {
            mySqlManager = new MySqlManager();
            MySqlCommand addSeasonCommand = new MySqlCommand($"INSERT INTO seasons (name, endDate, startDate, UUID, school) values (@name, @endDate, @startDate, @UUID, @school)", mySqlManager.con);

            addSeasonCommand.Parameters.AddWithValue("@name", seasonName);
            addSeasonCommand.Parameters.AddWithValue("@endDate", endDate);
            addSeasonCommand.Parameters.AddWithValue("@startDate", startDate);
            addSeasonCommand.Parameters.AddWithValue("@UUID", UUID);
            addSeasonCommand.Parameters.AddWithValue("@school", school);
            addSeasonCommand.Prepare();

            addSeasonCommand.ExecuteNonQuery();
            mySqlManager.con.Close();
            mySqlManager = null;
        }

        public List<Season> GetSeasonListFromDB(string school)
        {
            mySqlManager = new MySqlManager();
            List<Season> returnList = new List<Season>();
            MySqlCommand ReadSeasonSqlCommand = new MySqlCommand($"SELECT * FROM seasons WHERE school = '{school}'", mySqlManager.con);
            MySqlDataReader readSeasonDataReader = ReadSeasonSqlCommand.ExecuteReader();
            while (readSeasonDataReader.Read())
            {
                string returnStartDate = Convert.ToString(readSeasonDataReader["startDate"]);
                string returnEndDate = Convert.ToString(readSeasonDataReader["endDate"]);
                string returnSeasonName = Convert.ToString(readSeasonDataReader["name"]);
                string returnUUID = Convert.ToString(readSeasonDataReader["UUID"]);
                Season newSeason = new Season(returnStartDate, returnEndDate, returnSeasonName, returnUUID);
                returnList.Add(newSeason);
            }
            mySqlManager.con.Close();
            mySqlManager = null;
            return returnList;
        }
    }
}