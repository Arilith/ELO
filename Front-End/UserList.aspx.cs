using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class UserList : System.Web.UI.Page
    {

        public Teacher[] personList =
        {
            new Teacher("Niels Vissers", 18, "DaVinci College", "Student", true, "Aardrijkskunde", new Class("PD-B-18", 20)),
            new Teacher("Tristan van Triest", 18, "Markland College", "Student", true, "Wiskunde", new Class("PD-B-17", 15)),
            new Teacher("Teun Spithoven", 17, "JTC", "Student", true, "Natuurkunde", new Class("PD-B-16", 23)),
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}