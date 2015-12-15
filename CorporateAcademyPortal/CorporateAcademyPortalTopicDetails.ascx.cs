using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CorporateAcademyPortalScheduleBusinessLogic;

namespace BatchSchedule
{
    public partial class CorporateAcademyPortalTopicDetails : System.Web.UI.UserControl
    {
        //Getter setter methods for Usercontrol Properties
        public string sTopic
        {
            get
            {
                return txtTTopic.Text;
            }
            set
            {
                txtTTopic.Text = value;
            }
        }
        public string sTrainer
        {
            get
            {
                return txtTrainer.Text;
            }
            set
            {
                txtTrainer.Text = value;
            }
        }
        public string sTheoryHours
        {
            get
            {
                return txtTheoryHours.Text;
            }
            set
            {
                txtTheoryHours.Text = value;
            }
        }
        public string sPracticalHours
        {
            get
            {
                return txtPracticalHours.Text;
            }
            set
            {
                txtPracticalHours.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPracticalHours.ReadOnly = true;
            txtTheoryHours.ReadOnly = true;
            txtTrainer.ReadOnly = true;
            txtTTopic.ReadOnly = true;
        }
        //Passing Session value to eventdelete method
        protected void Delete_Click(object sender, EventArgs e)
        {
            new BatchScheduleBusiness().EventDeleteWithDate(Convert.ToDateTime(Session["Date"]));
        }
        //Edit Button Functionality
        protected void Edit_Click(object sender, ImageClickEventArgs e)
        {
            txtPracticalHours.ReadOnly = false;
            txtTheoryHours.ReadOnly = false;
            txtTrainer.ReadOnly = false;
            txtTTopic.ReadOnly = false;
        }
    }
}