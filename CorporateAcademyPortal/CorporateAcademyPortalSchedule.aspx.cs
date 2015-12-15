using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CorporateAcademyPortalScheduleBusinessLogic;
namespace BatchSchedule
{
    public partial class CorporateAcademyPortalSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                //Fetching Session Values
                var Uname = this.Session["uname"];
                var Pwd = this.Session["Password"];
                string adminName = "Admin";
                string password ="Admin";
                if (!(Convert.ToString(Uname) == adminName && Convert.ToString(Pwd) == password))
                {
                    btnSchedule.Visible = false;
                    btnCreateNewEvent.Visible = false;
                    btnLogout.Visible = false;
                }
                else
                {
                    btnBack.Visible = false;
                    btnLogout.Visible = true;
                    btnSchedule.Visible = true;
                    btnCreateNewEvent.Visible = true;
                }
            }
        }
        //For Binding Each Item Present in repeater
        protected void RepSchedule_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //Finding Repeater Controls
                TextBox txtBatchDate = (TextBox)e.Item.FindControl("txtBatchDate");
                Label lblDay = (Label)e.Item.FindControl("lblDay");
                //Finding UserControls inside repeater
                CorporateAcademyPortalTopicDetails ucTopicDetails = e.Item.FindControl("ucTopicDetails") as CorporateAcademyPortalTopicDetails;
                var repItem = e.Item.DataItem as CorporateAcademyPortalScheduleBusinessObject.NewEvent;
                if (repItem != null)
                {
                    txtBatchDate.Text = repItem.Date.ToString().Substring(0, 10);
                    string Date = txtBatchDate.Text;
                    DateTime dt = Convert.ToDateTime(Date);
                    Session["Date"] = repItem.Date;
                    lblDay.Text = dt.DayOfWeek.ToString();
                    ucTopicDetails.sTopic = repItem.Topic;
                    ucTopicDetails.sTrainer = repItem.Trainer;
                    ucTopicDetails.sTheoryHours = repItem.TheoryHours.ToString();
                    ucTopicDetails.sPracticalHours = repItem.PracticalHours.ToString();
                }
                else if (Convert.ToDateTime(Session["Date"]) != repItem.Date)
                {
                    txtBatchDate.Text = repItem.Date.ToString().Substring(0, 10);
                    string Date = txtBatchDate.Text;
                    DateTime dt = Convert.ToDateTime(Date);
                    lblDay.Text = string.Empty;
                    Session["Date"] = txtBatchDate.Text; ;
                    ucTopicDetails.sTopic = string.Empty;
                    ucTopicDetails.sTrainer = string.Empty;
                    ucTopicDetails.sTheoryHours = string.Empty;
                    ucTopicDetails.sPracticalHours = string.Empty;
                }
            }
        }
        //On changing dropdown selection 
        protected void DdlBatchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblBatchNameError.Visible = false;
                txtFromDate.Text = new BatchScheduleBusiness().FromDateCalc(ddlBatchName.Text).ToShortDateString();
                txtToDate.Text = new BatchScheduleBusiness().ToDateCalc(ddlBatchName.Text).ToShortDateString();
                var bid = new BatchScheduleBusiness().BatchId(ddlBatchName.Text);
                var bname = ddlBatchName.Text;
                Session["BatchName"] = bname;
                Session["BatchId"] = bid.ToString();
                Session["BId"] = bid.ToString();
            }
            catch
            {
                string script = "alert(\"Select a valid Batch name\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        //Functionality For Commands being executed inside repeater (Edit ,Delete etc)
        protected void RepSchedule_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // Here we use switch state to distinguish which link button is clicked based 
            //====== on command name supplied to the link button.
            switch (e.CommandName)
            {
                case ("Delete"):
                    int id = Convert.ToInt16(e.CommandArgument);
                    DeleteEvent(id);
                    break;
                case ("Edit"):
                    id = Convert.ToInt16(e.CommandArgument);
                    CorporateAcademyPortalTopicDetails ucTopicDetails = e.Item.FindControl("ucTopicDetails") as CorporateAcademyPortalTopicDetails;
                    CorporateAcademyPortalSchedule txtbox = e.Item.FindControl("txtBatchDate") as CorporateAcademyPortalSchedule;
                    new BatchScheduleBusiness().EventDetailsWithId(id, ucTopicDetails.sTopic, ucTopicDetails.sTrainer, Convert.ToInt32(ucTopicDetails.sPracticalHours), Convert.ToInt32(ucTopicDetails.sTheoryHours));
                    string script = "alert(\"Event edited successfully\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    break;
            }
        }
        //Deleting Event from Schedule
        void DeleteEvent(int id)
        {
            new BatchScheduleBusiness().DeleteEvent(id);
            string script = "alert(\"Event deleted successfully\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
        //Onclick Functionality For Calendar view Button
        protected void Calendar_Click(object sender, EventArgs e)
        {
            try
            {
                var result = new BatchScheduleBusiness().GetEventDetails(new BatchScheduleBusiness().BatchName(Convert.ToInt16(Session["BatchId"])));
                if (result.Count == 0)
                {
                    lblBatchNameError.Visible = true;
                    lblBatchNameError.Text = "*No Events are present in the Batch";
                }
                else
                {
                    Response.Redirect("CorporateAcademyPortalCalendar.aspx");
                }
            }
            catch
            {
                lblBatchNameError.Visible = true;
                lblBatchNameError.Text = "Select A Valid Batch";
            }

        }
        //Onclick Functionality For Showing Schedule Button
        protected void Schedule_Click(object sender, EventArgs e)
        {
            try
            {
                txtFromDate.Text = new BatchScheduleBusiness().FromDateCalc(ddlBatchName.Text).ToShortDateString();
                txtToDate.Text = new BatchScheduleBusiness().ToDateCalc(ddlBatchName.Text).ToShortDateString();
                var bid = new BatchScheduleBusiness().BatchId(ddlBatchName.Text);
                var bname = ddlBatchName.Text;
                Session["BatchName"] = bname;
                Session["BatchId"] = bid.ToString();
                Session["BId"] = bid.ToString();
                DateTime EndDate = new BatchScheduleBusiness().ToDateCalc(ddlBatchName.Text);
                DateTime StartDate = new BatchScheduleBusiness().FromDateCalc(ddlBatchName.Text);  
                var dates = new BatchScheduleBusiness().CalcBetweenDates(ddlBatchName.Text).ToList<CorporateAcademyPortalScheduleBusinessObject.NewEvent>();
                var eventquery = new BatchScheduleBusiness().GetEventDetails(ddlBatchName.Text).ToList<CorporateAcademyPortalScheduleBusinessObject.NewEvent>();
                var sl = eventquery.ToList<CorporateAcademyPortalScheduleBusinessObject.NewEvent>();
                repSchedule.DataSource = sl.OrderBy(x => x.Date);
                repSchedule.DataBind();
            }
            catch
            {
                lblBatchNameError.Visible = true;
                lblBatchNameError.Text = "Select A Valid Batch";
            }
        }
        protected void Logoff_Click(object sender, ImageClickEventArgs e)
        {
            Session["uname"] = string.Empty;
            Session["Password"] = string.Empty;
            Response.Redirect("CorporateAcademyPortalHomePage.aspx");
        }
        protected void Back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CorporateAcademyPortalHomePage.aspx");
        }
        protected void CreateNewEvent_Click(object sender, EventArgs e)
        {
        }
    }
}


