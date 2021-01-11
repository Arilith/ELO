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
        public Dictionary<Level, Reward> battlePassItems;
        public BattlePassManager battlePassMan;

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInPerson = (Person)Session["person"];
            rewardMan = new RewardMan();
            levelMan = new LevelMan();
            battlePassMan = new BattlePassManager();
        }

        // dit moet in de front end komen in de loop
        public void GetBattlePass(string schoolUUID)
        {
            battlePassItems = new battlePassMan.GetBattlePassItemsBySchool(schoolUUID);
        }
    }
}