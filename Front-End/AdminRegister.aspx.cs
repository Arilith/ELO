using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
namespace Front_End
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        public SchoolManager schoolManager;
        public UserMan userManager;

        public Person results;

        protected void Page_Load(object sender, EventArgs e)
        {
            schoolManager = new SchoolManager();
            userManager = new UserMan();

            if (IsPostBack)
            {
                results = userManager.AddSysAdminToDataBase(Request.Form["username"], Request.Form["password"], Request.Form["school"], Request.Form["name"], Request.Form["email"]);
                if (results.Name != null)
                {
                    MessageLabel.Text = "Nieuw beheeraccount succesvol aangemaakt!";
                }
                 // Session["person"] = results;
            }

        }
    }
}