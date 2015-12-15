using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CorporateAcademyPortalScheduleBusinessLogic;
using CorporateAcademyPortalScheduleBusinessObject;
namespace BatchSchedule
{
    public partial class CorporateAcademyPortalAddNewEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtBatchName.Text = (string)Session["BatchName"];
                txtBatchId.Text = (string)Session["BatchId"];
                if (Session["BatchId"] != null)
                {
                    drpdwnDates.DataSource = new BatchScheduleBusiness().CalcDates(Convert.ToInt16(Session["BatchId"]));
                    drpdwnDates.DataBind();
                }
            }
        }
        //Onclick Functionality For Save Button
        protected void SaveNewEvent_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.txtTheoryHours.Text) + Convert.ToInt16(this.txtPracticalHours.Text) > 9)
                {
                    lblAddNewEventError.Visible = true;
                    lblAddNewEventError.Text = "*The Theory and PracticalHours cannot exceed 9 hours";
                }
                else
                {
                    NewEvent objEvent = new NewEvent();
                    objEvent.BatchId = Convert.ToInt32(this.txtBatchId.Text.Trim());
                    objEvent.Date = Convert.ToDateTime(this.drpdwnDates.Text);
                    objEvent.Topic = this.txtTTopic.Text;
                    objEvent.Trainer = this.txtTrainer.Text;
                    objEvent.TheoryHours = Convert.ToInt32(this.txtTheoryHours.Text);
                    objEvent.PracticalHours = Convert.ToInt32(this.txtPracticalHours.Text);
                    new BatchScheduleBusiness().InsertEvent(objEvent);
                    string script = "alert(\"Event added successfully\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch
            {
                string script = "alert(\"Event adding failed\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        //Onclick Functionality For Clear Button
        protected void Clear_Click(object sender, EventArgs e)
        {
            drpdwnDates.SelectedValue = "0";
            txtDay.Text = string.Empty;
            txtTTopic.Text = string.Empty;
            txtTrainer.Text = string.Empty;
            txtTheoryHours.Text = string.Empty;
            txtPracticalHours.Text = string.Empty;
            lblAddNewEventError.Visible = false;
        }
        //On changing DropDown Value
        protected void DropdownDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDay.Text = string.Empty;
                txtTTopic.Enabled = true;
                if (DateTime.Compare(Convert.ToDateTime(this.drpdwnDates.Text), DateTime.Today) < 0)
                {
                    lblAddNewEventError.Visible = true;
                    lblAddNewEventError.Text = "This date is now passed";
                    txtTTopic.Enabled = false;
                }
                else
                {
                    txtDay.Text = Convert.ToDateTime(this.drpdwnDates.Text).DayOfWeek.ToString();
                    if (txtDay.Text == "Sunday" || txtDay.Text == "Saturday")
                    {
                        lblAddNewEventError.Visible = true;
                        lblAddNewEventError.Text = "Cannot create event on a weekend";
                        txtTTopic.Enabled = false;
                    }
                }
            }
            catch
            {
                string script = "alert(\"Select a valid Date\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}