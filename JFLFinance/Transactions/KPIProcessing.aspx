<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KPIProcessing.aspx.cs" Inherits="Transactions_KPIProcessing" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager EnablePartialRendering="true" EnableScriptGlobalization="true"
        ScriptMode="Release" EnableScriptLocalization="true" ID="script" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/javaScript/validation.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <table border="0" cellpadding="1" cellspacing="2" style="width: 100%">
            <tr>
                <td align="right">
                    <asp:Label CssClass="cssLable" ID="Label1" runat="server" Text="<%$ Resources:Resource, Process %>"></asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddlProcessing" Width="260px" EnableEmbeddedSkins="true"
                        AccessKey="M" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProcessing_SelectedIndexChanged">
                        <Items>
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Monthly%>" Value="Month" />
                           <%-- <telerik:RadComboBoxItem Text="<%$ Resources:Resource,Weekly%>" Value="Weekly" />--%>
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label CssClass="cssLable" ID="lblMonth" runat="server" Text="<%$ Resources:Resource, Month %>"></asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddlMonth" Width="180px" EnableEmbeddedSkins="true" AccessKey="M"
                        AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                        <Items>
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource, January%>" Value="1" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,February%>" Value="2" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,March%>" Value="3" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,April%>" Value="4" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,May%>" Value="5" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,June%>" Value="6" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,July%>" Value="7" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,August%>" Value="8" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,September%>" Value="9" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,October%>" Value="10" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,November%>" Value="11" />
                            <telerik:RadComboBoxItem Text="<%$ Resources:Resource,December%>" Value="12" />
                        </Items>
                    </telerik:RadComboBox>
                    <telerik:RadNumericTextBox ID="txtYear" NumberFormat-AllowRounding="false" NumberFormat-DecimalDigits="0"
                        NumberFormat-KeepNotRoundedValue="false" NumberFormat-GroupSeparator="" ShowSpinButtons="true"
                        EmptyMessage="<%$ Resources:Resource, Year %>" MinValue="1950" AutoPostBack="true"
                        OnTextChanged="txtYear_TextChanged" MaxValue="2999" AccessKey="y" runat="server"
                        MaxLength="4" Width="80px">
                    </telerik:RadNumericTextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblWeekNo" runat="server" Text="<%$ Resources:Resource,Week%>"></asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddlWeek" Width="260px" runat="server" AccessKey="W" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged" EnableEmbeddedSkins="true">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,Date %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox CssClass="csstxtboxSmall" Enabled="false" Text="" ID="txtFromDate" runat="server"
                        Width="80px" AutoPostBack="false"></asp:TextBox>
                    -
                    <asp:TextBox CssClass="csstxtboxSmall" Enabled="false" Text="" ID="txtToDate" runat="server"
                        Width="80px" AutoPostBack="false"></asp:TextBox>
                    <asp:HiddenField ID="HFFromDate" runat="server" />
                    <asp:HiddenField ID="HFToDate" runat="server" />
                    <asp:HiddenField ID="weekStartDate" runat="server" />
                    <asp:HiddenField ID="weekEndDate" runat="server" />
                    <asp:HiddenField ID="HFMaxDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center">
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnProcess" runat="server" Text="<%$Resources:Resource,Process %>"
                                    CssClass="cssButton" OnClick="btnProcess_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
