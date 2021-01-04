using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace ELO.SQLClasses
{
    public class LevelSQL
    {
        private MySqlManager mySqlManager;
        
        public LevelSQL()
        {
            mySqlManager = new MySqlManager();
        }

        public void AddLevelToDatabase(int levelNummer, int requiredExp, string seizoen)
        {

        }


    }
}
