using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ELO.SQLClasses
{
	public class RewardSQL
	{
		private string UUID = "griep eets";

		private MySqlManager mySqlManager;
		public RewardSQL() 
		{
			mySqlManager = new MySqlManager();
		}

		public List<Reward> GetRewardListFromDB(string school)
		{ 
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
				

				Reward newReward = new Reward(returnTitle, returnDescription, returnImageURL, returnRequiredLevel);

				returnList.Add(newReward);
			}

			return returnList;
		}

		public void AddRewardToDB(string reward, string rewardDescription, string imageURL, int requiredLevel)
		{
			MySqlCommand addRewardCommand = new MySqlCommand($"Insert into rewards (requiredLevel, reward, description, imageURL, UUID) values (@requiredLevel, @reward, @description, @imageURL, @UUID)", mySqlManager.con);

			addRewardCommand.Parameters.AddWithValue("@requiredLevel", requiredLevel);
			addRewardCommand.Parameters.AddWithValue("@reward", reward);
			addRewardCommand.Parameters.AddWithValue("@description", rewardDescription);
			addRewardCommand.Parameters.AddWithValue("@imageURL", imageURL);
			addRewardCommand.Parameters.AddWithValue("@UUID", UUID);
			addRewardCommand.Prepare();

			addRewardCommand.ExecuteNonQuery();
		}
	}

}
