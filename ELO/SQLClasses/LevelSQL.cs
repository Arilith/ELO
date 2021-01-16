using ELO.Managers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class LevelSQL
    {
        private MySqlManager mySqlManager;
        private SeasonMan seasonMan;

        private string UUID;

        public LevelSQL()
        {
            UUID = new Random().Next().ToString() + DateTime.Now.ToString("s");
        }

        public List<Level> GetLevelsFromDB(string school)
        {
            mySqlManager = new MySqlManager();
            seasonMan = new SeasonMan();

            // lijst voor levels die gelezen worden
            List<Level> returnList = new List<Level>();

            // filteren van rijen in database en die gefilterde rijen uitlezen
            // de variabele school wordt loggenInperson.School
            MySqlCommand readLevelSqlCommand = new MySqlCommand($"SELECT * FROM levels WHERE school = '{school}' ORDER BY levelNumber ASC", mySqlManager.con);
            MySqlDataReader readLevelDataReader = readLevelSqlCommand.ExecuteReader();

            //als de datalezen aan het lezen is:
            while (readLevelDataReader.Read())
            {
                // alles uit de database is string dus die zetten we om naar wat je nodig hebt
                int returnRequiredExp = Convert.ToInt32(readLevelDataReader["requiredExp"]);

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
            mySqlManager.con.Close();
            mySqlManager = null;

            //als alle rijen zijn gelezen en in de lijst gezet, return de lijst
            return returnList;
        }

        public void AddLevelToDatabase(int amountOfLevels, int maxExp, string seizoen, string school)
        {
            mySqlManager = new MySqlManager();

            string AddLevelsSQL = "";

            int expPerLevel = Convert.ToInt32(maxExp / amountOfLevels);
            int requiredExp = 0;
            for (int i = 1; i <= amountOfLevels; i++)
            {
                requiredExp += expPerLevel;
                AddLevelsSQL +=
                    $"INSERT INTO levels (requiredExp, seasonUUID, levelNumber, UUID, school) VALUES ('{requiredExp}', '{seizoen}', '{i}', RAND(), '{school}');";
            }

            MySqlCommand addLevelsToDatabase = new MySqlCommand(AddLevelsSQL, mySqlManager.con);

            addLevelsToDatabase.ExecuteNonQuery();

            mySqlManager.con.Close();
            mySqlManager = null;
        }

        public Level FindLevel(string levelUUID)
        {
            mySqlManager = new MySqlManager();
            seasonMan = new SeasonMan();
            MySqlCommand findLevelInDatabase = new MySqlCommand($"SELECT * FROM levels WHERE UUID = '{levelUUID}'", mySqlManager.con);
            MySqlDataReader readLevelReader = findLevelInDatabase.ExecuteReader();
            if (readLevelReader.Read())
            {
                // alles uit de database is string dus die zetten we om naar wat je nodig hebt
                int returnRequiredExp = Convert.ToInt32(readLevelReader["requiredExp"]);

                string returnSeasonUUID = readLevelReader["seasonUUID"].ToString();
                Season returnSeason = seasonMan.FindSeasonInDB(returnSeasonUUID);

                int returnLevelNumber = Convert.ToInt32(readLevelReader["levelNumber"]);
                string returnRewardUUID = readLevelReader["rewardUUID"].ToString();
                string returnUUID = readLevelReader["UUID"].ToString();
                //met die data een nieuw level maken in de returnlijst
                Level newLevel = new Level(returnRequiredExp, returnSeason, returnLevelNumber, returnRewardUUID, returnUUID);

                return newLevel;
            }

            seasonMan = null;
            mySqlManager.con.Close();
            mySqlManager = null;
            return null;
        }
    }
}