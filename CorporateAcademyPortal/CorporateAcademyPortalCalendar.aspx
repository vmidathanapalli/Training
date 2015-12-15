<%@ Page Title="" Language="C#" MasterPageFile="~/Corporate Academy Portal.Master" AutoEventWireup="true" CodeBehind="CorporateAcademyPortalCalendar.aspx.cs" Inherits="BatchSchedule.CorporateAcademyPortalCalendar" %>

<%@ Register Namespace="DataControls" Assembly="DataCalendar" TagPrefix="dc" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="CorporateAcademyPortalScheduleBusinessLogic" %>
<%@ Import Namespace="CorporateAcademyPortalScheduleData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="cs" runat="server">

        DataTable dt = new DataTable();
        DataTable GetEventData()
        {
            try
            {
                var bname = new BatchScheduleBusiness().BatchName(Convert.ToInt16((string)Session["BId"]));
                var result = new BatchScheduleBusiness().GetEventDetails(bname);
                date = Convert.ToDateTime(new BatchScheduleBusiness().FromDateCalc(bname));
                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {

                        var row = dt.NewRow();
                        if (!dt.Columns.Contains("Topic"))
                        {
                            dt.Columns.Add("Topic");
                        }
                        if (!dt.Columns.Contains("Trainer"))
                        {
                            dt.Columns.Add("Trainer");
                        }
                        if (!dt.Columns.Contains("TheoryHours"))
                        {
                            dt.Columns.Add("TheoryHours");
                        }
                        if (!dt.Columns.Contains("PracticalHours"))
                        {
                            dt.Columns.Add("PracticalHours");
                        }
                        if (!dt.Columns.Contains("Date"))
                        {
                            dt.Columns.Add("Date");
                        }
                        row["Topic"] = item.Topic;
                        row["PracticalHours"] = item.PracticalHours;
                        row["TheoryHours"] = item.TheoryHours;
                        row["Trainer"] = item.Trainer;
                        row["Date"] = item.Date;
                        dt.Rows.Add(row);
                    }
                }
                else
                {
                    Response.Write("No events created for that Batch");
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                }
            }
            catch
            {
                Response.Write("select a Batch to display calendar");
            }

            return dt;
        }
        //PageLoad method
        public DateTime date;
        void Page_Load(Object o, EventArgs e)
        {
            txtBName.Text = (string)Session["BatchName"];
            var bname = new BatchScheduleBusiness().BatchName(Convert.ToInt16((string)Session["BId"]));
            date = Convert.ToDateTime(new BatchScheduleBusiness().FromDateCalc(bname));
            cal1.DataSource = GetEventData();
            cal1.DayField = "Date";
            DataBind();
        }
    
    </script>

    <html>
    <head>
        <title>Schedule Calendar</title>
        <style>
            a {
                text-decoration: none;
            }

                a:hover {
                    text-decoration: underline;
                }
        </style>
    </head>
    <body>
        <asp:ImageButton ID="btnBack" runat="server" Height="23px" ImageUrl="~/images/back-button.jpg" Width="33px" OnClick="Back_Click" />

        <table align="center" style="height: 109px; width: 450px">
            <tr>
                <td style="font-family: Andalus; font-size: 50px; font-weight: bolder; color: #FF3300">&nbsp;&nbsp;&nbsp;&nbsp; Batch Schedule</td>
            </tr>
            <tr>
                <td style="font-family: Andalus; font-size: x-large; font-style: normal; font-weight: bold">Batch Name:
               <asp:TextBox runat="server" ID="txtBName" Enabled="False" Font-Bold="True" Font-Size="Large" Height="29px" Width="160px"></asp:TextBox></td>
            </tr>

        </table>
        <br />
        <h3>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
        </h3>

        <dc:DataCalendar ID="cal1" runat="server" Width="88%"
            VisibleDate="<%# date %>" OnSelectionChanged="cal1_SelectionChanged" Height="77px" Style="margin-left: 140px">
            <TitleStyle BackColor="Orange"
                ForeColor="Brown"
                Font-Bold="True" />
            <DayStyle HorizontalAlign="Left" VerticalAlign="Top"
                Font-Size="8" Font-Name="Arial" BackColor="lightYellow" />


            <NextPrevStyle ForeColor="Brown"
                Font-Size="18px"
                Font-Bold="True" />

            <OtherMonthDayStyle BackColor="#99CCFF" ForeColor="Green" />
            <WeekendDayStyle BackColor="Silver" />

            <itemtemplate>
                    <br />                    
                   <img src='images/notification.gif' height="12" width="12" align="absmiddle" border="0"/>
                     
                        Topic: <%# Container.DataItem["Topic"] %><br />
                        By: <%# Container.DataItem["Trainer"] %><br />
                        Theory: <%# Container.DataItem["TheoryHours"] %> hours<br />
                        Practicals: <%# Container.DataItem["PracticalHours"] %> hours
                                     
                </itemtemplate>

            <noeventstemplate>
                  <br />
                    <br />
                    <br />
                 
                    <br />
                    <br />
                  
                &nbsp;&nbsp;&nbsp;</noeventstemplate>
        </dc:DataCalendar>
     </body>
    </html>
</asp:Content>
