using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddLeermiddel : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }
        private void ConvertAndInsertData()
        {
            string subject = Request.Form["subject"];
            string niveau = Request.Form["niveau"];
            int leerjaar = Convert.ToInt32(Request.Form["leerjaar"]);
            string link = Request.Form["link"];
            string description = Request.Form["description"];

            Manager.leermiddelMan.AddleermiddelToList(subject, niveau, leerjaar, link, description);

        }
    }
}

