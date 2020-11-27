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

        public Person[] personList =
        {
            new Person("Niels Vissers", 18, "DaVinci College", "Student"),
            new Person("Tristan van Triest", 18, "Markland College", "Student"),
            new Person("Teun Spithoven", 17, "JTC", "Student"),
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}