using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.Managers; 

namespace Front_End
{
	public partial class HwList : System.Web.UI.Page
	{
		HwMan homeworkManager;

		protected void Page_Load(object sender, EventArgs e)
		{
			homeworkManager = new HwMan();
		}
	}
}