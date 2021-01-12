using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Level
    {

        public int RequiredExp { get; private set; }
        public Season ThisSeason { get; private set; }
        public int LevelNumber { get; private set; }
        public string rewardUUID { get; private set; }
        public string UUID { get; private set; }

        public Level(int requiredExp, Season thisSeason, int levelNumber, string rewardUUID, string UUID)
        {
            this.RequiredExp = requiredExp;
            this.ThisSeason = thisSeason;
            this.LevelNumber = levelNumber;
            this.rewardUUID = rewardUUID;
            this.UUID = UUID;
        }
    }
}
