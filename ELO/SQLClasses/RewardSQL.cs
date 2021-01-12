using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class RewardSQL
    {
        private string UUID = "Reward";

        private MySqlManager mySqlManager;

        public RewardSQL()
        {
        }

        public List<Reward> GetRewardFromDB(string school)
        {
            mySqlManager = new MySqlManager();
            //Lijst voor Rewards die gelezen worden
            List<Reward> returnList = new List<Reward>();

            // Filteren van rijen in de DB en de gefilterde rijen lezen
            // De variabele school wordt loggedInPerson.School
            MySqlCommand readRewardSqlCommand = new MySqlCommand(cmdText: $"SELECT * FROM rewards WHERE school = {school} ORDER BY requiredLevel ASC", mySqlManager.con);
            MySqlDataReader readRewardDataReader = readRewardSqlCommand.ExecuteReader();

            while (readRewardDataReader.Read())
            {
                //Alles uit de DB is string, dus omzetten naar wat je nodig hebt
                int returnRequiredLevel = Convert.ToInt32(readRewardDataReader["requiredLevel"]);

                string returnTitle = Convert.ToString(readRewardDataReader["title"]);
                string returnDescription = Convert.ToString(readRewardDataReader["description"]);
                string returnImageURL = Convert.ToString(readRewardDataReader["imageURL"]);
                string returnUUID = readRewardDataReader["UUID"].ToString();

                Reward newReward = new Reward(returnTitle, returnDescription, returnImageURL, returnRequiredLevel, returnUUID);

                returnList.Add(newReward);
            }
            mySqlManager = null;
            return returnList;
        }

        public void AddRewardToDB(string reward, string rewardDescription, string imageURL, int requiredLevel)
        {
            mySqlManager = new MySqlManager();
            MySqlCommand addRewardCommand = new MySqlCommand($"Insert into rewards (requiredLevel, reward, description, imageURL, UUID) values (@requiredLevel, @reward, @description, @imageURL, @UUID)", mySqlManager.con);

            addRewardCommand.Parameters.AddWithValue("@requiredLevel", requiredLevel);
            addRewardCommand.Parameters.AddWithValue("@reward", reward);
            addRewardCommand.Parameters.AddWithValue("@description", rewardDescription);
            addRewardCommand.Parameters.AddWithValue("@imageURL", imageURL);
            addRewardCommand.Parameters.AddWithValue("@UUID", UUID);
            addRewardCommand.Prepare();

            addRewardCommand.ExecuteNonQuery();
            mySqlManager = null;
        }

        public Reward FindReward(string rewardUUID)
        {
            mySqlManager = new MySqlManager();
            MySqlCommand findRewardInDatabase = new MySqlCommand($"SELECT * FROM rewards WHERE UUID = '{rewardUUID}'", mySqlManager.con);
            MySqlDataReader readRewardReader = findRewardInDatabase.ExecuteReader();
            if (readRewardReader.Read())
            {
                // alles uit de database is string dus die zetten we om naar wat je nodig hebt
                string returnTitle = readRewardReader["title"].ToString();
                string rewardDescription = readRewardReader["description"].ToString();
                string imageUrl = readRewardReader["imageURL"].ToString();
                int requiredLevel = Convert.ToInt32(readRewardReader["requiredLevel"]);
                string returnUUID = readRewardReader["UUID"].ToString();
                //met die data een nieuw level maken in de returnlijst
                Reward returnReward = new Reward(returnTitle, rewardDescription, imageUrl, requiredLevel, returnUUID);

                return returnReward;
            }

            mySqlManager = null;
            return null;
        }
    }
}