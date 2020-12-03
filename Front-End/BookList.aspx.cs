using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class BookList : System.Web.UI.Page
    {
        public string Book1;
        private static int number = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Manager.bookMan.AddBook(TextBoxTitle.Text, number);
            number++;
            
        }
    }
}