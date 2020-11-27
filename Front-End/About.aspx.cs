using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ELO;

namespace Front_End
{
    public partial class About : Page
    {
        private Person henk;
       
        protected void Page_Load(object sender, EventArgs e)
        {
           henk = new Person("Henk", 32, "Markland College", "Student");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = henk.ToString();
        }

    }
}