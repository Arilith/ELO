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
    public partial class LevelManagerPage : System.Web.UI.Page
    {

        public LevelMan levelManager;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            levelManager = new LevelMan();

            if (IsPostBack)
            {

                int levelNummer = Convert.ToInt32(Request.Form["levelnummer"]);
                int requiredExp = Convert.ToInt32(Request.Form["requiredexp"]);
                string seizoen = Convert.ToString(Request.Form["seizoen"]);

                levelManager.AddLevel(levelNummer, requiredExp, seizoen);
            }

        }
    }
}