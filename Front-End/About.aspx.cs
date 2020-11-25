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
    public partial class About : Page
    {
        private Class1 test;

        protected void Page_Load(object sender, EventArgs e)
        {
            test = new Class1();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = this.test.testString;
        }
    }
}