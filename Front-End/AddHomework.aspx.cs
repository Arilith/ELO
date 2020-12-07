﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddHomework : System.Web.UI.Page
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

            string work = Request.Form["work"];
            string dueDate =Request.Form["dueDate"];
            string subject = Request.Form["subject"];

            Class linkedClass = Manager.classMan.GetClass(Request.Form["_class"]);

			Manager.hwMan.AddHomework(work, subject, dueDate, linkedClass);

			OutputLabel.Text = "Huiswerk ingevoerd!";
        }
    }
}