using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddClass : System.Web.UI.Page
    {
        private ClassManager classManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            classManager = new ClassManager();

            if (IsPostBack)
            {
                Person loggedInPerson = (Person) Session["person"];
                classManager.AddNewClassToDatabase(Request.Form["name"], Request.Form["leshuis"], Request.Form["stream"], Request.Form["cluster"], Convert.ToInt32(Request.Form["studyyear"]), loggedInPerson);

                OutputLabel.Text = "Klas Succesvol toegevoegd!";
            }
        }

    }
}