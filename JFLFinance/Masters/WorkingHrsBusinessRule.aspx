<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkingHrsBusinessRule.aspx.cs" Inherits="Masters_WorkingHrsBusinessRule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.8.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
     <asp:Panel ID="Panel3" runat="server" BorderWidth="0px" Font-Bold="true" ScrollBars="Auto" CssClass="ScrollBar"
        Width="100%" Height="480px">
        <Ajax:UpdatePanel ID="upWorkingHrs" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="PanelWorkingHrs" runat="server" BorderWidth="0px" Font-Bold="true"
                    ScrollBars="Auto" Width="100%" GroupingText="Days">
                    <table border="0" cellpadding="1" cellspacing="0" style="text-align: center" width="100%">
                        <tr>
                            <td style="vertical-align: top">
                                <asp:CheckBox ID="chkSun" runat="server" TextAlign="Right" Text="Sunday(1)" Style="font-size: xx-small" />
                                <asp:CheckBox ID="ChkMon" runat="server" TextAlign="Right" Text="Monday(2)" Style="font-size: xx-small" />
                                <asp:CheckBox ID="ChkTue" runat="server" TextAlign="Right" Text="Tuesday(3)" Style="font-size: xx-small" />
                                <asp:CheckBox ID="ChkWed" runat="server" TextAlign="Right" Text="Wednesday(4)" Style="font-size: xx-small" />
                                <asp:CheckBox ID="ChkThu" runat="server" TextAlign="Right" Text="Thursday(5)" Style="font-size: xx-small" />
                                <asp:CheckBox ID="ChkFri" runat="server" TextAlign="Right" Text="Friday(6)" Style="font-size: xx-small" />
                                <asp:CheckBox ID="ChkSat" runat="server" TextAlign="Right" Text="Saturday(7)" Style="font-size: xx-small" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" BorderWidth="0px" ScrollBars="Auto" Width="100%"
                    GroupingText="Duty Type" Font-Bold="true">
                    <table>
                        <tr>
                            <td style="vertical-align: top">
                                <asp:CheckBoxList ID="chkDutyType" runat="server" Style="font-size: smaller" RepeatDirection="Horizontal"
                                    RepeatLayout="Table" RepeatColumns="5">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" BorderWidth="0px" ScrollBars="Auto" Width="100%"
                    GroupingText="Hours Head" Font-Bold="true">
                    <table>
                        <tr>
                            <asp:Repeater ID="reptHrsHead" OnItemDataBound="DataBound_Event" runat="server">
                                <ItemTemplate>
                                    <table width="650px" border="0">
                                        <tr>
                                            <td width="160px">
                                                <asp:Label ID="lblHrsHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadCode").ToString()%>'> </asp:Label>
                                            </td>
                                            <td width="60px" align="left">
                                                <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="between"> </asp:Label>
                                            </td>
                                            <td width="90px" align="left">
                                                <asp:Label ID="lblHrsFromWithSchedule" CssClass="cssLable" Visible="false" runat="server"
                                                    Text="ScheduleHrs + "> </asp:Label>
                                            </td>
                                            <td width="60px">
                                                <asp:TextBox ID="txtHrsHeadFrom" runat="server" Width="50px" CssClass="csstxtboxSmall"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "HoursFrom").ToString()%>'></asp:TextBox>
                                            </td>
                                            <td width="40px" align="center">
                                                <asp:Label ID="lblAnd" runat="server" Text="&&"></asp:Label>
                                            </td>
                                            <td width="90px" align="left">
                                                <asp:Label ID="lblHrsToWithSchedule" CssClass="cssLable" Visible="false" runat="server"
                                                    Text="ScheduleHrs + "> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHrsHeadTo" runat="server" Width="50px" CssClass="csstxtboxSmall"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "HoursTo").ToString()%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" ValidationGroup="vgPatternid" runat="server" Visible="true"
                                    Text="<%$Resources:Resource,Save %>" CssClass="cssButton" OnClick="btnSave_Click" />
                                <asp:Button ID="btnDelete" ValidationGroup="vgPatternid" runat="server" Visible="true"
                                    Text="<%$Resources:Resource,Delete %>" CssClass="cssButton" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Label ID="lblErrorMsg1" runat="server" CssClass="csslblErrMsg" EnableViewState="false"
                    Text=""></asp:Label>
            </ContentTemplate>
        </Ajax:UpdatePanel>
    </asp:Panel>
    </form>
     <script type="text/javascript">
         function checkNum(evt) {
             var carCode = (evt.which) ? evt.which : event.keyCode
             if (carCode > 31 && (carCode < 48) || (carCode > 57)) {
                 return false;
             }
         }
    </script>
</body>
</html>
