using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO.Managers
{
	public class RewardMan
	{
		private RewardSQL rewardSQL;
		
		public RewardMan()
		{
			rewardSQL = new RewardSQL();
		}
		public void AddReward(string title, string rewardDescription, string imageURL, int requiredLevel)
		{
			rewardSQL.AddRewardToDB(title, rewardDescription, imageURL, requiredLevel);
		}
	}

}
