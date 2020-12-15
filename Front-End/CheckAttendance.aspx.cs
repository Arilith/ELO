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
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		

		protected void CheckBoxOA_CheckedChanged(object sender, EventArgs e)
		{
			int points;
			CheckBoxWA.Checked = false;
			points =  - 5;
		}

		protected void CheckBoxWA_CheckedChanged(object sender, EventArgs e)
		{
			CheckBoxOA.Checked = false;
			
		}
		protected void CheckBoxTLO_CheckedChanged(object sender, EventArgs e)
		{
			int points;
			CheckBoxTLO.Checked = false;
			points = -5;
		}
		protected void CheckBoxTLW_CheckedChanged(object sender, EventArgs e)
		{
			
			CheckBoxTLO.Checked = false;
			
		}
	}
}