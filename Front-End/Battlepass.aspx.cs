using ELO;
using ELO.Managers;
using System;
using System.Collections.Generic;
using ELO.Managers;

namespace Front_End
{
    public partial class BattlePass : System.Web.UI.Page
    {
        public Person loggedInPerson;
        public RewardMan rewardMan;
        public LevelMan levelMan;
        public BattlePassManager battlePassMan;

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInPerson = (Person)Session["person"];
            rewardMan = new RewardMan();
            levelMan = new LevelMan();
            battlePassMan = new BattlePassManager();
        }

        // dit moet in de front end komen in de loop
        public Dictionary<Level, Reward> GetBattlePass(string schoolUUID)
        {
            // returned uit de database een dictionary van een reward die bij een level hoort
            Dictionary<Level, Reward> battlePassItems = new Dictionary<Level, Reward>(battlePassMan.GetBattlePassLevelsBySchool(schoolUUID));
            return battlePassItems;
        }
    }
}