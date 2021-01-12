using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO.Managers
{
    public class BattlePassManager
    {
        // key lvl 1 tot 100, reward is de value van de key
        public Dictionary<Level, Reward> GetBattlePassLevelsBySchool(string schoolUUID)
        {
            LevelSQL levelSql = new LevelSQL();
            LevelMan levelMan = new LevelMan();
            RewardMan rewardMan = new RewardMan();
            Dictionary<Level, Reward> returnDictionary = new Dictionary<Level, Reward>();

            foreach (Level level in levelSql.GetLevelsFromDB(schoolUUID))
            {
                Level returnLevel = levelMan.FindLevel(level.UUID);
                Reward returnReward = rewardMan.FindReward(level.rewardUUID);
                returnDictionary.Add(returnLevel, returnReward);
            }

            levelSql = null;
            levelMan = null;
            rewardMan = null;

            return returnDictionary;
            // alle levels uit database
            // for i = 0--100 loop dr op
            // voor ieder level het reward erbij
            // iedere reward in de goeie slot
        }
    }
}
