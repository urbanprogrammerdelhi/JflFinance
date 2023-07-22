<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptGroup_ARegister.aspx.cs"
    Inherits="Transactions_rptGroup_ARegister" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager EnablePartialRendering="true" EnableScriptGlobalization="true"
        ScriptMode="Release" EnableScriptLocalization="true" ID="script" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server" ClientEvents-OnRequestStart="onRequestStart"
        ClientEvents-OnResponseEnd="onResponseEnd">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <%-- <telerik:RadAjaxPanel ID="Panel1" runat="server" EnableAJAX="true" LoadingPanelID="RadAjaxLoadingPanel1">--%>
    <asp:Panel ID="pnlParam" runat="server" GroupingText="<%$Resources:Resource,ARegister %>"
        Width="700px">
        <table>
            <tr>
                <td align="left" style="width: 120px">
                    <asp:Label ID="lblDivision" runat="server" Text="<%$Resources:Resource,HrLocation %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left" colspan="3">
                    <telerik:RadComboBox ID="ddlDivision" runat="server" Width="350px" MaxHeight="350px"
                        CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true" EmptyMessage="Please Select"
                        AllowCustomText="true" EnableCheckAllItemsCheckBox="true" OnSelectedIndexChanged="DdlDivisionSelectedIndexChanged"
                        AutoPostBack="true">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 120px">
                    <asp:Label ID="lblBranch" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left" colspan="4">
                    <telerik:RadComboBox ID="ddlBranch" runat="server" Width="350px" MaxHeight="350px"
                        CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true" EmptyMessage="Please Select"
                        AllowCustomText="true" EnableCheckAllItemsCheckBox="true" OnSelectedIndexChanged="DdlBranchSelectedIndexChanged"
                        AutoPostBack="true">
                    </telerik:RadComboBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="LableCentralisedBillable" CssClass="cssLabel" runat="server" Text="Include Centralized Billing"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbIncludeCentralizedBilling" AutoPostBack="true" OnCheckedChanged="cbIncludeCentralizedBilling_CheckedChanged" runat="server" CssClass="cssCheckBox" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCustomer" runat="server" Text="<%$Resources:Resource,Client %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="ddlCustomer" runat="server" Width="350px" MaxHeight="350px"
                        EmptyMessage="Please Select" CheckBoxes="true" EnableCheckAllItemsCheckBox="false" OnClientDropDownOpening="OnClientDropDownOpening"
                        AutoPostBack="false" Filter="StartsWith" CheckedItemsTexts="DisplayAllInInput">
                        <%--OnSelectedIndexChanged="ddlAsmtName_SelectedIndexChanged"--%>
                    </telerik:RadComboBox>
                    <%-- <asp:DropDownList Width="120px" ID="DDLCategory" runat="server" CssClass="cssDropDown">
                    </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblYear" runat="server" Text="<%$Resources:Resource,Year %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddlYear" runat="server" Width="250px" MaxHeight="350px"
                        CheckBoxes="false" EnableCheckAllItemsCheckBox="false" AutoPostBack="true" Filter="StartsWith">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblMonth" runat="server" Text="<%$Resources:Resource,Month %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddlMonth" Width="100px" EmptyMessage="<%$ Resources:Resource, Month %>"
                        EnableEmbeddedSkins="true" AccessKey="M" runat="server">
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
                </td>
            </tr>
           
            <tr>
                <td>
                    <asp:Button ID="btnGenerateData" runat="server" CssClass="cssButton" OnClick="btnGenerateData_Click"
                        Text="View" />
                    <%--<asp:Button ID="btnProcess" runat="server" Text="<%$ Resources:Resource,Process%>"
                                    CssClass="cssButton" OnClick="btnProcess_Click"></asp:Button>--%>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                    <div id="processDiv" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;
                        text-align: center; display: none">
                        <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                            alt="" src="../Images/spinner.gif" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlGrid" runat="server" GroupingText="">
        <table>
            <tr>
                <td colspan="4">
                    <telerik:RadGrid ID="RadGrid1" GridLines="Both" Width="2000px" Skin="Office2007"
                        runat="server" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound">
                        <ExportSettings Pdf-PageWidth="100%" ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                            <Excel FileExtension="xls" Format="Html" />
                            <Csv FileExtension="csv" />
                        </ExportSettings>
                        <MasterTableView CommandItemDisplay="TopAndBottom" ShowHeadersWhenNoRecords="True"
                            AutoGenerateColumns="true" AllowMultiColumnSorting="True" AllowSorting="True"
                            AllowFilteringByColumn="false" PageSize="10" AllowPaging="True">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true"
                                ShowExportToExcelButton="true" ShowExportToPdfButton="false" ExportToCsvText="Csv"
                                ExportToExcelText="Excel" ExportToPdfText="Pdf" />
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%--</telerik:RadAjaxPanel>--%>
    <%--  </ContentTemplate>
    </Ajax:UpdatePanel>--%>
    </form>
    <script language="javascript" type="text/javascript">



        var currentLoadingPanel = null;
        var currentUpdatedControl = null;
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 || args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 || args.get_eventTarget().indexOf("ExportToCsvButton") >= 0)
                args.set_enableAjax(false);
        }
        function onResponseEnd() {
        }


        function OnClientDropDownOpening(sender, eventArgs) {
//            var items = sender.get_items();
//            var checkbox = items.getItem(0).get_checkBoxElement();
//            checkbox.style.display = "none";


        }

    </script>
</body>
</html>
