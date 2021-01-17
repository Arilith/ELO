using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ELO.SQLClasses
{
    public class RewardSQL
    {
        private string UUID;

        private MySqlManager mySqlManager;

        public RewardSQL()
        {
            UUID = new Random().Next().ToString() + DateTime.Now.ToString("s");
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
                string returnTitle = Convert.ToString(readRewardDataReader["title"]);
                string returnDescription = Convert.ToString(readRewardDataReader["description"]);
                string returnImageURL = Convert.ToString(readRewardDataReader["imageURL"]);
                string returnUUID = readRewardDataReader["UUID"].ToString();

                Reward newReward = new Reward(returnTitle, returnDescription, returnImageURL, returnUUID);

                returnList.Add(newReward);
            }
            mySqlManager.con.Close();
            mySqlManager = null;
            return returnList;
        }

        public void ClaimReward(string studentUUID, string rewardUUID)
        {
            mySqlManager = new MySqlManager();

            MySqlCommand claimRewardCommand = new MySqlCommand($"INSERT INTO claimedrewards (userUUID, rewardUUID) VALUES (@studentUUID, @rewardUUID)", mySqlManager.con);

            claimRewardCommand.Parameters.AddWithValue("@studentUUID", studentUUID);
            claimRewardCommand.Parameters.AddWithValue("@rewardUUID", rewardUUID);

            claimRewardCommand.Prepare();
            claimRewardCommand.ExecuteNonQuery();

            mySqlManager.con.Close();
            mySqlManager = null;

        }

        public List<Reward> GetStudentRewards(string studentUUID)
        {
            mySqlManager = new MySqlManager();
            //Lijst voor Rewards die gelezen worden
            List<Reward> returnList = new List<Reward>();

            // Filteren van rijen in de DB en de gefilterde rijen lezen
            // De variabele school wordt loggedInPerson.School
            MySqlCommand readRewardSqlCommand = new MySqlCommand(cmdText: $"SELECT r.*, c.* FROM claimedrewards AS c LEFT JOIN rewards AS r ON c.rewardUUID = r.UUID WHERE c.userUUID = '{studentUUID}' ORDER BY c.Id DESC", mySqlManager.con);
            MySqlDataReader readRewardDataReader = readRewardSqlCommand.ExecuteReader();

            while (readRewardDataReader.Read())
            {
                //Alles uit de DB is string, dus omzetten naar wat je nodig hebt
                string returnTitle = Convert.ToString(readRewardDataReader["title"]);
                string returnDescription = Convert.ToString(readRewardDataReader["description"]);
                string returnImageURL = Convert.ToString(readRewardDataReader["imageURL"]);
                string returnUUID = readRewardDataReader["UUID"].ToString();

                Reward newReward = new Reward(returnTitle, returnDescription, returnImageURL, returnUUID);

                returnList.Add(newReward);
            }
            mySqlManager.con.Close();
            mySqlManager = null;
            return returnList;
        }

        public void AddRewardToDB(string title, string rewardDescription, string imageURL, string levelUUID, bool isSame)
        {
            mySqlManager = new MySqlManager();

            string changeLevelQuery;

            if (isSame)
                changeLevelQuery = $"UPDATE levels SET rewardUUID = '{UUID}'";
            else
                changeLevelQuery = $"UPDATE levels SET rewardUUID = '{UUID}' WHERE uuid = '{levelUUID}'";

            MySqlCommand addRewardCommand = new MySqlCommand($"Insert into rewards (title, description, imageURL, UUID) values (@title, @description, @imageURL, @UUID)", mySqlManager.con);
            MySqlCommand changeLevelCommand = new MySqlCommand(changeLevelQuery, mySqlManager.con);

            addRewardCommand.Parameters.AddWithValue("@title", title);
            addRewardCommand.Parameters.AddWithValue("@description", rewardDescription);
            addRewardCommand.Parameters.AddWithValue("@imageURL", imageURL);
            addRewardCommand.Parameters.AddWithValue("@UUID", UUID);
            addRewardCommand.Prepare();

            addRewardCommand.ExecuteNonQuery();
            changeLevelCommand.ExecuteNonQuery();

            mySqlManager.con.Close();
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
                string returnUUID = readRewardReader["UUID"].ToString();
                //met die data een nieuw level maken in de returnlijst
                Reward returnReward = new Reward(returnTitle, rewardDescription, imageUrl, returnUUID);

                return returnReward;
            }

            mySqlManager.con.Close();
            mySqlManager = null;
            return null;
        }
    }
}