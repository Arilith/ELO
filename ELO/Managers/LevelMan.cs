using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO.Managers
{
    public class LevelMan
    {
        private LevelSQL levelSql;
        public static List<Level> levelList { get; private set; }


        public LevelMan()
        {
            levelSql = new LevelSQL();
        }

        public void AddLevel(int amoundOfLevels, int maxExp, string seizoen)
        {
            int expPerLevel = Convert.ToInt32(maxExp / amoundOfLevels);
            int requiredExp = expPerLevel;
            for (int i = 0; i < amoundOfLevels; i++)
            {
                requiredExp += expPerLevel;
                levelSql.AddLevelToDatabase(i, requiredExp, seizoen);
            }
        }

        public List<Level> GetLevelListFromDB(string school)
        {
            List<Level> returnList = levelSql.GetLevelsFromDB(school);
            levelList = returnList;
            return returnList;
        }

        public Level FindLevel(string levelUUID)
        {
            Level returnLevel = (Level)GetLevelList().Find(x => x.UUID == levelUUID);
            return returnLevel;
        }

        public List<Level> GetLevelList()
        {
            return levelList;
        }

    }
}
