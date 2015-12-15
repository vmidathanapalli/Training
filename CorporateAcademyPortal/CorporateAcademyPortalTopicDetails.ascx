<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CorporateAcademyPortalTopicDetails.ascx.cs" Inherits="BatchSchedule.CorporateAcademyPortalTopicDetails" %>
<script lang="javascript" type="text/javascript" src="Javascripts/BatchSchedule.js">

</script>
<link rel="stylesheet" type="text/css" href="CSS/BatchSchedule.css" />
<table id="tblName" runat="server" class="ForeColor">
    <tr>
        <td colspan="2" style="background-color: Orange;">
            <asp:Literal ID="litTheory" runat="server" Text="Theory Sessions"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="lblTTopic" runat="server" Text="Topic: "></asp:Label>
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtTTopic" MaxLength="30" runat="server" Width="250" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblTrainer" runat="server" Text="Trainer: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTrainer" MaxLength="30" runat="server" Width="250" ReadOnly="True" OnKeyPress="return CheckNum();"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblTheoryTime" runat="server" Text="Theory Time: "></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtTheoryHours" MaxLength="1" runat="server" Width="60" ReadOnly="True" OnKeyPress="return CheckInteger();"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="background-color: #C0C0C0">
            <asp:Literal ID="litPracticals" runat="server" Text="Lab Sessions"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblPracticalTime" runat="server" Text="Practical Time: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPracticalHours" MaxLength="1" runat="server" Width="60" ReadOnly="True" OnKeyPress="return CheckInteger();"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Visible="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ImageButton ID="btnEdit" runat="server" Height="21px" ImageUrl="~/images/edit.png" Width="26px" OnClick="Edit_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
