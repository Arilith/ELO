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
        public string Boek1;
        private int nummer = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Book boek = new Book(TextBoxTitle.Text, nummer);
            Label1.Text = boek.Title;
            nummer++;
        }
    }
}