using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.Managers;

namespace Front_End
{
    public partial class AddLevel : System.Web.UI.Page
    {
        public LevelMan levelManager;
        public SeasonMan seasonManager;
        public Person loggedInPerson;

        protected void Page_Load(object sender, EventArgs e)
        {
            levelManager = new LevelMan();
            seasonManager = new SeasonMan();
            loggedInPerson = (Person) Session["person"];

            if (IsPostBack)
            {
                int levelNummer = Convert.ToInt32(Request.Form["levelnummer"]);
                int requiredExp = Convert.ToInt32(Request.Form["requiredexp"]);
                string seizoen = Convert.ToString(Request.Form["season"]);

                levelManager.AddLevel(levelNummer, requiredExp, seizoen);
            }

        }
    }
}