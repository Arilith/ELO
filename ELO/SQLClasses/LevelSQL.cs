﻿using ELO.Managers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class LevelSQL
    {
        private MySqlManager mySqlManager;
        private SeasonMan seasonMan;

        public LevelSQL()
        {
            mySqlManager = new MySqlManager();
        }

        public List<Level> GetLevelsFromDB(string school)
        {
            seasonMan = new SeasonMan();

            // lijst voor levels die gelezen worden
            List<Level> returnList = new List<Level>();

            // filteren van rijen in database en die gefilterde rijen uitlezen
            // de variabele school wordt loggenInperson.School
            MySqlCommand readLevelSqlCommand = new MySqlCommand($"SELECT * FROM levels WHERE school = {school} ORDER BY levelNumber ASC", mySqlManager.con);
            MySqlDataReader readLevelDataReader = readLevelSqlCommand.ExecuteReader();

            //als de datalezen aan het lezen is:
            while (readLevelDataReader.Read())
            {
                // alles uit de database is string dus die zetten we om naar wat je nodig hebt
                int returnRequiredExp = Convert.ToInt32(readLevelDataReader["requiredLevel"]);

                string returnSeasonUUID = readLevelDataReader["seasonUUID"].ToString();
                Season returnSeason = seasonMan.FindSeasonInDB(returnSeasonUUID);

                int returnLevelNumber = Convert.ToInt32(readLevelDataReader["levelNumber"]);
                string returnRewardUUID = readLevelDataReader["rewardUUID"].ToString();
                string returnUUID = readLevelDataReader["UUID"].ToString();
                //met die data een nieuw level maken in de returnlijst
                Level newLevel = new Level(returnRequiredExp, returnSeason, returnLevelNumber, returnRewardUUID, returnUUID);

                returnList.Add(newLevel);
            }

            seasonMan = null;

            //als alle rijen zijn gelezen en in de lijst gezet, return de lijst
            return returnList;
        }

        public void AddLevelToDatabase(int levelNummer, int requiredExp, string seizoen)
        {
        }
    }
}