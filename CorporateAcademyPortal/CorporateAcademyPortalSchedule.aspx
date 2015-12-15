<%@ Page Title="" Language="C#" MasterPageFile="~/Corporate Academy Portal.Master" AutoEventWireup="true" CodeBehind="CorporateAcademyPortalSchedule.aspx.cs" Inherits="BatchSchedule.CorporateAcademyPortalSchedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/CorporateAcademyPortalTopicDetails.ascx" TagName="eventDetails" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style7 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <link rel="stylesheet" type="text/css" href="CSS/BatchSchedule.css" />
        <script lang="javascript" type="text/javascript" src="Javascripts/BatchSchedule.js">

        </script>
    </head>
    <body>
        <table align="left" style="height: 31px; width: 0px" class="ForeColor">
            <tr>
                <td>
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="Back_Click1" />
                </td>
            </tr>
        </table>
        <table align="right" style="height: 31px; width: 0px" class="ForeColor">
            <tr>
                <td>
                    <asp:ImageButton ID="btnLogout" runat="server" Height="25px" ImageAlign="Right" ImageUrl="~/images/Log-Out.jpg" Width="63px" OnClick="Logoff_Click" Visible="False" />

                </td>
            </tr>
        </table>

        <table class="Table" align="center" class="ForeColor">
            <tr>
                <td>
                    <label style="font-family: Andalus; font-size: xx-large; font-weight: bold;">Batch Schedule</label></td>
            </tr>
        </table>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="CorporateAcademyPortalScheduleData.CorporateAcademyPortalDataClassesDataContext" EntityTypeName="" TableName="Batches" Select="new (BatchId, BatchName, FromDate, ToDate)">
            </asp:LinqDataSource>
            <table align="center">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblBatch" runat="server" Text="Batch" Font-Bold="True" Font-Size="Larger"></asp:Label>:</td>

                    <td class="auto-style7">&nbsp;<asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="LinqDataSource1" DataTextField="BatchName" DataValueField="BatchName" AutoPostBack="True" AppendDataBoundItems="True" Height="20px" Width="119px" OnSelectedIndexChanged="DdlBatchName_SelectedIndexChanged">
                        <asp:ListItem Text="Select Batch"></asp:ListItem>
                    </asp:DropDownList></td>

                    <td class="auto-style7">
                        <asp:Button ID="btnSchedule" runat="server" Text="Show Schedule" OnClick="Schedule_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblBatchNameError" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
                </tr>


                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblFromDate" runat="server" Text="FromDate" Font-Bold="True" Font-Size="Larger"></asp:Label>:</td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" Enabled="False" ForeColor="#CCCCCC" ReadOnly="True" Style="margin-left: 3px" Width="116px"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblToDate" runat="server" Text="ToDate" Font-Bold="True" Font-Size="Larger"></asp:Label>:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtToDate" runat="server" Style="margin-left: 3px" Enabled="False" ReadOnly="True" Width="116px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnCalendar" runat="server" Text="Calendar view" OnClick="Calendar_Click" Width="155px" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style1">

                        <asp:Button ID="btnCreateNewEvent" runat="server" Text="Create New Event" OnClick="CreateNewEvent_Click" />
                        <asp:ModalPopupExtender ID="btnCreateNewEvent_ModalPopupExtender" runat="server" Enabled="True" PopupControlID="Panl1" TargetControlID="btnCreateNewEvent" CancelControlID="btnCancel" BackgroundCssClass="Background">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" Style="display: none">
                            <iframe id="irm1" style="width: 400px; height: 400px" src="CorporateAcademyPortalAddNewEvent.aspx" runat="server"></iframe>
                            <div class="popup_Buttons" style="display: none">

                                <input id="btnCancel" type="button" value="Cancel" />
                            </div>

                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="repSchedule" runat="server" OnItemDataBound="RepSchedule_OnItemDataBound" OnItemCommand="RepSchedule_ItemCommand">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Table ID="Table1" runat="server" BorderStyle="Inset" CaptionAlign="Bottom" valign="middle" Height="50" Width="100" align="center" class="ForeColor">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Date</asp:TableHeaderCell><asp:TableHeaderCell>Event</asp:TableHeaderCell></asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:TextBox ID="txtBatchDate" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox><br />
                                <asp:Label ID="lblDay" runat="server"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <uc:eventDetails ID="ucTopicDetails" runat="server" />
                                <br />
                          <asp:Button ID="imgBtnEdit" CommandName="Edit" ToolTip="Edit a record." CommandArgument='<%#Eval("EventId") %>' runat="server" Text="Save" Visible="True" />
                                <asp:Button ToolTip="Delete a record." OnClientClick="javascript:return confirm('Are you sure to delete record?')" ID="imgBtnDelete" CommandName="Delete" CommandArgument='<%#Eval("EventId") %>' runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </ItemTemplate>
            </asp:Repeater>
            <hr />
            <br />
            <br />
        </div>
    </body>
    </html>
</asp:Content>
