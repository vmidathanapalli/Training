using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BatchSchedule
{
    public partial class CorporateAcademyPortalAdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtUserName.Focus();
        }    
        //Onclick Functionality For Submit Button
        protected void Submit_Click(object sender, EventArgs e)
        {
            this.Session["uname"] = txtUserName.Text;
            this.Session["Password"] = txtPWD.Text;
            if (txtUserName.Text == string.Empty || txtPWD.Text == string.Empty)
            {
                lblLoginError.Visible = true;
                lblLoginError.Text = "**UserName or Password is Empty";
            }
            else if (txtUserName.Text == "Admin" && txtPWD.Text == "Admin")
            {
                Response.Redirect("CorporateAcademyPortalSchedule.aspx");
            }
            else
            {
                lblLoginError.Visible = true;
                lblLoginError.Text = "**UserName or Password is Incorrect";
                txtUserName.Text = string.Empty;
            }
        }
        //Onclick Functionality For Reset Button
        protected void Reset_Click1(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty; ;
            txtPWD.Text = string.Empty;
            lblLoginError.Visible = false;
        }
    }
}
