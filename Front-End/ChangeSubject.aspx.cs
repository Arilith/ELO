using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class ChangeSubject : System.Web.UI.Page
    {
        public SubjectManager subjectManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            subjectManager = new SubjectManager();
        }
    }
}