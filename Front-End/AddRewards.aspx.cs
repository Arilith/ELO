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
	public partial class AddRewards : System.Web.UI.Page
	{
		public RewardMan rewardMan;
        public LevelMan levelManager;

        public Person loggedInPerson;

		protected void Page_Load(object sender, EventArgs e)
		{
			rewardMan = new RewardMan();
			levelManager = new LevelMan();

            loggedInPerson = (Person)Session["person"];

			if (IsPostBack)
			{
				string title = Request.Form["title"];
				string rewardDescription = Request.Form["rewardDescription"];
				string imageURL = Request.Form["imageURL"];
				string levelUUID = Request.Form["levelUUID"];

                string isSameStr = Request.Form["same"];
                bool isSame = isSameStr == "on";

				rewardMan.AddReward(title, rewardDescription, imageURL, levelUUID, isSame);
				
				OutputLabel.Text = "Beloning toegevoegd!";
			}
		}
	}
}