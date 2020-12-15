using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
	public partial class CheckAttendance : System.Web.UI.Page
	{
		public ClassManager classManager;
		public UserMan userManager;
		public Person loggedInPerson;
		protected void Page_Load(object sender, EventArgs e)
		{
			classManager = new ClassManager();
			userManager = new UserMan();

			loggedInPerson = (Person)Session["person"];
			
		}

		

		protected void CheckBoxOA_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckBoxA.Checked == true)
			{
				CheckBoxOA.Checked = false;
				CheckBoxWA.Checked = false;
			}

		}

		protected void CheckBoxWA_CheckedChanged(object sender, EventArgs e)
		{
			CheckBoxOA.Checked = false;
			
		}
		protected void CheckBoxTLO_CheckedChanged(object sender, EventArgs e)
		{
			CheckBoxTLO.Checked = false;
		}
		protected void CheckBoxTLW_CheckedChanged(object sender, EventArgs e)
		{
			
			CheckBoxTLO.Checked = false;
			
		}
	}
}