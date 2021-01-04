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

        public Level(int requiredExp, Season thisSeason, int levelNumber)
        {
            this.RequiredExp = requiredExp;
            this.ThisSeason = thisSeason;
            this.LevelNumber = levelNumber;
        }
    }
}
