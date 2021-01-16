﻿using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO.Managers
{
	public class RewardMan
	{
		private RewardSQL rewardSQL;
        private List<Reward> rewardList = new List<Reward>();
        public RewardMan()
		{
			rewardSQL = new RewardSQL();
		}
		public void AddReward(string title, string rewardDescription, string imageURL, string levelUUID)
		{
			rewardSQL.AddRewardToDB(title, rewardDescription, imageURL, levelUUID);
		}

		public void GetRewardListFromDB(string school)
		{
			rewardSQL.GetRewardFromDB(school);

		}

        public Reward FindReward(string rewardUUID)
        {
            Reward returnReward = rewardSQL.FindReward(rewardUUID);
            return returnReward;
		}

		public List<Reward> GetRewardList()
        {
            return rewardList;
        }
	}

}
