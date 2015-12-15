<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorporateAcademyPortalAddNewEvent.aspx.cs" Inherits="BatchSchedule.CorporateAcademyPortalAddNewEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/BatchSchedule.css" />
    <script lang="javascript" type="text/javascript" src="Javascripts/BatchSchedule.js">

    </script>
    <script>
        function Validate() {
            var Date = document.getElementById('<%=drpdwnDates.ClientID %>').value;
            var Topic = document.getElementById('<%=txtTTopic.ClientID %>').value;
            var Trainer = document.getElementById('<%=txtTrainer.ClientID %>').value;
            var TheoryHours = document.getElementById('<%=txtTheoryHours.ClientID %>').value;
            var PracticalHours = document.getElementById('<%=txtPracticalHours.ClientID %>').value;

            if (Date == "0") {
                alert("Select Date");
                document.getElementById("<%=drpdwnDates.ClientID%>").focus();
                  return false;
              }

              if (Topic == "") {
                  alert("Enter Topic");
                  return false;
              }

              if (Trainer == "") {
                  alert("Enter Trainer Name");
                  return false;
              }

              if (TheoryHours == "") {
                  alert("Enter TheoryHours");
                  return false;
              }
              if (PracticalHours == "") {
                  alert("Enter PracticalHours");
                  return false;
              }

              return true;
          }
    </script>
    <style type="text/css">
        .auto-style7 {
            width: 214px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="popup_Titlebar" id="PopupHeader">

            <div class="popup_Buttons" style="background-color: #006699; height: 24px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label id="lblTitle" style="color: #FFFFFF; font-family: Andalus"> ADD NEW EVENT</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="btnCancel" onclick="cancel();" type="button" value="" style="background-position: center center; background-image: url('images/Cancel.jpg'); background-repeat: no-repeat; background-attachment: inherit; height: 22px; width: 23px;" />
            </div>
        </div>
        <div>
            <table id="tblName" class="auto-style5" runat="server">

                <tr>
                    <td colspan="2" class="auto-style2">
                        <table>
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="Label1" runat="server" Text="Batch Name:"></asp:Label>
                                </td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="txtBatchName" MaxLength="30" runat="server" Width="90px" Enabled="False" Height="16px" ReadOnly="True" Style="margin-left: 0px"></asp:TextBox>
                                </td>
                                <td class="auto-style0">
                                    <asp:Label ID="lblBatchId" runat="server" Text="Batch Id: "></asp:Label>
                                </td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="txtBatchId" MaxLength="30" runat="server" Width="88px" ReadOnly="True" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblEventDate" runat="server" Text="Event Date: "></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="drpdwnDates" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropdownDates_SelectedIndexChanged" AppendDataBoundItems="True">
                            <asp:ListItem Text="Select Date" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblDay" runat="server" Text="Event Day: "></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDay" MaxLength="30" runat="server" Width="250" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblTTopic" runat="server" Text="Topic: "></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtTTopic" MaxLength="30" runat="server" Width="250"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTrainer" runat="server" Text="Trainer: "></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtTrainer" MaxLength="30" runat="server" Width="250" OnKeyPress="return CheckNum();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="background-color: #FFCC99;" id="lblBatchName">
                        <asp:Literal ID="litTheory" runat="server" Text="Theory Sessions"></asp:Literal>
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
                                <td>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTheoryHours" MaxLength="10" runat="server" Width="60" OnKeyPress="return CheckInteger();"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="background-color: #CCCCCC">
                        <asp:Literal ID="litPracticals" runat="server" Text="Lab Sessions"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPracticalTime" runat="server" Text="Practical Time: "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPracticalHours" MaxLength="10" runat="server" Width="60" OnKeyPress="return CheckInteger();"></asp:TextBox>
                                </td>
                                <td>&nbsp;&nbsp;
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label runat="server" Visible="False" ForeColor="Red" ID="lblAddNewEventError"></asp:Label></td>
                </tr>
            </table>
            <asp:Button ID="btnSaveNewEvent" runat="server" Text="Save" Height="22px" OnClick="SaveNewEvent_Click" Width="115px" Font-Size="Medium" ForeColor="#FF9900" ViewStateMode="Enabled" OnClientClick="return Validate();" />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClear" runat="server" Height="23px" OnClick="Clear_Click" Text="Clear" Width="103px" Font-Size="Medium" ForeColor="#FF9900" />
        </div>
    </form>
</body>
</html>
