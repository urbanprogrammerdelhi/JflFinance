<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BarredEmployees.aspx.cs" Inherits="Transactions_BarredEmployees" %>
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
            <telerik:AjaxSetting AjaxControlID="RadGridBarredEmployees">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridBarredEmployees" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <%--<telerik:RadAjaxPanel ID="P1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">--%>
        <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>--%>
        <table>
            <tr>
                <td>
                 <div style=" text-align:right;">             
                 <asp:Button ID="btnBack" runat="server" Text ="<%$ Resources:Resource,Back %>" OnClick = "btnBack_Click" CssClass="cssButton" />
                 </div>
                 <asp:Panel runat="server" ID="PnlReport" GroupingText="<%$ Resources:Resource, BarredEmployees %>"
                   Height="100%" Width="100%">
                <telerik:RadGrid ID="RadGridBarredEmployees" GridLines="Both" Width="2000px"  Skin="Office2007"  runat="server"
                    OnNeedDataSource="RadGridBarredEmployees_NeedDataSource" OnItemDataBound="RadGridBarredEmployees_ItemDataBound" AllowPaging = "true">
                    <ExportSettings Pdf-PageWidth="100%" ExportOnlyData="true"  IgnorePaging="true" OpenInNewWindow="true">
                        <Excel FileExtension="xls" Format="Html" />
                        <Csv FileExtension="csv" />
                    </ExportSettings>
                    
                    <MasterTableView CommandItemDisplay="TopAndBottom" 
                        ShowHeadersWhenNoRecords="True" AutoGenerateColumns="true" AllowMultiColumnSorting="True"
                        AllowSorting="True" AllowFilteringByColumn="false" PageSize="10" AllowPaging="True">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true"
                            ShowExportToExcelButton="true" ShowExportToPdfButton="false" ExportToCsvText="Csv"
                            ExportToExcelText="Excel" />
                    </MasterTableView>
                    <ClientSettings AllowColumnsReorder="true" ReorderColumnsOnClient="true" ColumnsReorderMethod="Swap">
                    </ClientSettings>
                </telerik:RadGrid>
                </asp:Panel>
            </td>
        </tr>
    </table>
    
    <%--</telerik:RadAjaxPanel>--%>

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
