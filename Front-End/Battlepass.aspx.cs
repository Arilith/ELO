using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.Managers;
using ELO.SQLClasses;

namespace Front_End
{
    public partial class BattlePass : System.Web.UI.Page
    {
        public RewardMan rewardMan;
        public SeasonMan seasonMan;
        public LevelMan levelMan;
        public Person loggedInPerson;


        protected void Page_Load(object sender, EventArgs e)
        {
            levelMan = new LevelMan();
            rewardMan = new RewardMan();
            seasonMan = new SeasonMan();
            loggedInPerson = (Person)Session["person"];
        }
    }
}