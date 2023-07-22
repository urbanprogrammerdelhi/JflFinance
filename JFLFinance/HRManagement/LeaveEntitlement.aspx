<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveEntitlement.aspx.cs"
    Inherits="HRManagement_LeaveEntitlement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <Ajax:ScriptManager ID="sm" runat="server"></Ajax:ScriptManager>
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                                <div class="squareboxgradientcaption" style="height: 20px;">
                                            <asp:Label ID="Label13" runat="server" Text="<%$Resources:Resource,LeaveEntitlement%>"></asp:Label>
                                </div>
                                <div>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                        <tr>
                                            <td style="width: 18%" align="right">
                                                <asp:Label ID="Label1" CssClass="cssLabel" Width="150px" runat="server" Text="<%$Resources:Resource,LeaveCalendarCode %>"></asp:Label>
                                            </td>
                                            <td style="width: 20%" align="left">
                                                <asp:TextBox MaxLength="16" AutoPostBack="true" ID="txtLeaveCalendarCode" OnTextChanged="txtLeaveCalendarCode_OnTextChanged"
                                                    Width="150px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                <asp:ImageButton ID="ImgLCCode" AlternateText="SearchClient" runat="server" ImageUrl="~/Images/icosearch.gif"
                                                    ToolTip="<%$Resources:Resource,SearchLeaveCalendar %>" />
                                            </td>
                                            <td colspan="4" align="left">
                                                <asp:Label Width="262px" Style="font-weight: bold;" ID="lblLeaveCalendarDesc" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label>
                                                <%--<asp:Label ID="lblLeaveCalendarDesc" CssClass="csstxtboxReadonly" runat="server"></asp:Label> --%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EffectiveFrom %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label Width="150px" Style="font-weight: bold;" ID="lblEffectiveFrom" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 12%" align="right">
                                                <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EffectiveTo %>"></asp:Label>
                                            </td>
                                            <td style="width: 20%" align="left">
                                                <asp:Label Width="150px" Style="font-weight: bold;" ID="lblEffectiveTo" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 1px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 1px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmployeeNumber" AutoPostBack="true" OnTextChanged="txtEmployeeNumber_OnTextChanged"
                                                    Width="150px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                <asp:ImageButton ID="imgEmployeeNumberSearch" AlternateText="<%$Resources:Resource,SearchEmployee %>"
                                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="<%$Resources:Resource,SearchEmployee %>" />
                                            </td>
                                            <td colspan="4" align="left">
                                                <asp:Label Width="262px" Style="font-weight: bold;" ID="lblEmployeeName" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label>
                                                <%--<asp:Label ID="lblLeaveCalendarDesc" CssClass="csstxtboxReadonly" runat="server"></asp:Label> --%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblLeaveType" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveType %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlLeaveType_OnSelectedIndexChanged"
                                                    AutoPostBack="true" Width="160px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblUnit" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Units %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label Width="150px" Style="font-weight: bold;" ID="lblUnits" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--                                            <td align="right">
                                                <asp:Label ID="lblApplicationNo" CssClass="cssLabel" runat="server" Text="Application No"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlApplicationNo" runat="server" OnSelectedIndexChanged="ddlApplicationNo_OnSelectedIndexChanged"
                                                    CssClass="cssDropDown" AutoPostBack="true" Width="100px">
                                                </asp:DropDownList>
                                            </td>
                                            --%>
                                            <td align="right">
                                                <asp:Label ID="lblBalanceUnits" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveBalance %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox MaxLength="5" ID="txtLeaveBalanceUnits" ReadOnly="true" Style="font-weight: bold;
                                                    color: Red;" Width="150px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblLeaveUnits" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveEntitledUnits %>"></asp:Label>
                                            </td>
                                            <td colspan="3" align="left">
                                                <asp:TextBox ID="txtEntitledUnits" Width="100px" Text="000.00" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender4" AutoComplete="true" AutoCompleteValue="0"
                                                    AcceptNegative="None" runat="server" TargetControlID="txtEntitledUnits" Mask="999.99"
                                                    MessageValidatorTip="true" MaskType="Number" AcceptAMPM="false" ClearTextOnInvalid="true"
                                                    ErrorTooltipEnabled="True">
                                                </AjaxToolKit:MaskedEditExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 1px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 1px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center">
                                                <asp:Label EnableViewState="false" ID="lblErrMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center">
                                                <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Save %>"
                                                    OnClick="btnSave_Click" ValidationGroup="vg_Add" />
                                                <asp:HiddenField ID="HFLeaveBalanceControlID" runat="server" />
                                                <asp:HiddenField ID="HFLeaveBalnce" runat="server" />
                                                <%-- <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Update %>"
                                                    OnClick="btnUpdate_Click" />
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Delete %>"
                                                    OnClick="btnDelete_Click" />
                                                --%>
                                                <asp:Button ID="btnReset" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Reset %>"
                                                    OnClick="btnReset_Click" />
                                                <asp:Button ID="btnBack" Style="display: none;" runat="server" CssClass="cssButton"
                                                    Text="<%$ Resources:Resource, Back %>" OnClick="btnBack_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
    </form>
      <script language="javascript" type="text/javascript">

          window.onbeforeunload = function () { ReturnValue(); }
          function ReturnValue() {
              if (document.getElementById('<%=HFLeaveBalnce.ClientID %>').value == "000.0") {
                  document.getElementById('<%=HFLeaveBalnce.ClientID %>').value = "";
              }
              if (document.getElementById('<%=HFLeaveBalnce.ClientID %>').value != "") {
                  window.opener.document.getElementById(document.getElementById('<%=HFLeaveBalanceControlID.ClientID %>').value).value = document.getElementById('<%=HFLeaveBalnce.ClientID %>').value;
              }

          }
    
    </script>
</body>
</html>
