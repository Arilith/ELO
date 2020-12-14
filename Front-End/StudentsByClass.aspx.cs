﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class StudentsByClass : System.Web.UI.Page
    {
        public ClassManager classManager;
        public Person loggedInPerson;
        protected void Page_Load(object sender, EventArgs e)
        {
            classManager = new ClassManager();
            loggedInPerson = (Person) Session["person"];
        }
    }
}