using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
	public class Reward
	{
		public string Rewards { get; private set;  }
		public string RewardDescription { get; private set; }
		public string ImageURL { get; private set; }
		public Level RequiredLevel { get; private set; }

		public Reward(string rewards, string rewardDescription, string imageURL, Level requiredLevel)
		{
			this.Rewards = rewards;
			this.RewardDescription = rewardDescription;
			this.ImageURL = imageURL;
			this.RequiredLevel = requiredLevel;
		}
	}
}
