<%@ Page Title="CorporateAcademyPortalAdminLogin" Language="C#" MasterPageFile="~/Corporate Academy Portal.Master" AutoEventWireup="true" CodeBehind="CorporateAcademyPortalAdminLogin.aspx.cs" Inherits="BatchSchedule.CorporateAcademyPortalAdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <link rel="stylesheet" type="text/css" href="CSS/BatchSchedule.css" />
    <body>
        <div>
            <table align="center" style="height: 103px; width: 416px" class="ForeColor">
                <tr>
                    <td>
                        <label style="font-family: Andalus; font-size: xx-large; font-weight: bolder; font-style: normal; color: #FF6600">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LOGIN PAGE</label></td>
                </tr>
            </table>
            <table align="center" style="height: 241px; width: 378px" class="ForeColor">
                <tr>
                    <td colspan="2">
                        <label style="font-family: Andalus; font-size: x-large; font-style: normal; font-variant: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Admin Login </label>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium">Username:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Height="16px" Width="119px" />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium">Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPWD" runat="server" TextMode="Password" Height="16px" Width="119px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblLoginError" runat="Server" ForeColor="Red" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td>

                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Height="33px" Width="91px" OnClick="Submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnReset" runat="server" Text="Reset" Height="32px" Width="78px" OnClick="Reset_Click1" />
                    </td>
                </tr>

            </table>
        </div>

    </body>
    </html>

</asp:Content>
