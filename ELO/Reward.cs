using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
	public class Reward
	{
		public string Title { get; private set;  }
		public string RewardDescription { get; private set; }
		public string ImageURL { get; private set; }
        public string UUID { get; private set; }

		public Reward(string title, string rewardDescription, string imageURL, string UUID)
		{
			this.Title = title;
			this.RewardDescription = rewardDescription;
			this.ImageURL = imageURL;
            this.UUID = UUID;
        }
	}
}
