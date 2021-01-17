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
    public partial class AddSeason : System.Web.UI.Page
    {
        SeasonMan seasonMan;

        private Person loggedInPerson;

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInPerson = (Person) Session["person"];
            seasonMan = new SeasonMan();
            if (IsPostBack)
            {
                string startDate = Request.Form["startdate"];
                string endDate = Request.Form["enddate"];
                string seasonName = Request.Form["seasonname"];

                seasonMan.AddSeason(startDate, endDate, seasonName, loggedInPerson.School);
            }

        }
    }
}