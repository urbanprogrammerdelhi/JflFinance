<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaudiPaySum.aspx.cs" Inherits="Transactions_SaudiPaySum" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
    <telerik:RadScriptManager EnablePartialRendering="true" EnableScriptGlobalization="true"
        ScriptMode="Release" EnableScriptLocalization="true" ID="script" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server" ClientEvents-OnRequestStart="onRequestStart"
        ClientEvents-OnResponseEnd="onResponseEnd">
      <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGridSaudiPaysum">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridSaudiPaysum" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <%--<telerik:RadAjaxPanel ID="P1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">--%>
    
    <table>
        <tr>
            <td>
                <asp:Label ID="lblSelectingBR" Text="<%$ Resources:Resource, BusinessRule%>" runat="server" CssClass="cssLabel"></asp:Label>
                <asp:DropDownList ID="ddlBusinessRuleCode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBusinessRuleCode_SelectedIndexChanged"
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPeriod" Text="<%$ Resources:Resource, Period %>" runat="server"
                    CssClass="cssLabel"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlPeriodCollection" runat="server" CssClass="cssDropDown"
                    Height="22px" Width="185px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnGeneratePaysum" runat="server" CssClass="cssButton" OnClick="btnGeneratePaysum_Click"
                    Text="Generate Paysum" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" Width="250px"></asp:Label>
                <td align="left" colspan="2">
                    &nbsp;
                </td>
            </td>
        </tr>
        <tr>
             <td>
                <telerik:RadGrid ID="RadGridSaudiPaysum" GridLines="Both" Width="2000px"  Skin="Office2007"  runat="server"
                    OnNeedDataSource="RadGridSaudiPaysum_NeedDataSource" OnItemDataBound="RadGridSaudiPaysum_ItemDataBound" AllowPaging = "true" OnColumnCreated = "RadGridSaudiPaysum_OnColumnCreated">
                    <ExportSettings Pdf-PageWidth="100%" ExportOnlyData="true"  IgnorePaging="true" OpenInNewWindow="true">
                        <Excel FileExtension="xls" Format="Html" />
                        <Csv FileExtension="csv" />
                    </ExportSettings>
                    <MasterTableView CommandItemDisplay="TopAndBottom"
                        ShowHeadersWhenNoRecords="True" AutoGenerateColumns="true" AllowMultiColumnSorting="True"
                        AllowSorting="True" AllowFilteringByColumn="True" PageSize="10" AllowPaging="True">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true"
                            ShowExportToExcelButton="true" ShowExportToPdfButton="false" ExportToCsvText="Csv"
                            ExportToExcelText="Excel" />
                    </MasterTableView>
                    <ClientSettings AllowColumnsReorder="true" ReorderColumnsOnClient="true" ColumnsReorderMethod="Swap">
                    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>                    
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
    </script>
</body>
</html>
