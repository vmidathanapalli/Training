using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BatchSchedule
{
    public partial class CorporateAcademyPortalCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void cal1_SelectionChanged(object sender, EventArgs e)
        {
        }
        protected void Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CorporateAcademyPortalSchedule.aspx");
        }
    }
}