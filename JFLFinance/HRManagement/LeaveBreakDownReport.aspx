<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveBreakDownReport.aspx.cs" Inherits="HRManagement_LeaveBreakDownReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportTo") >= 0) {
                args.set_enableAjax(false);
            }
        }
         
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadGrid ID="RadGrid1"  Skin="Office2007"  runat="server" OnNeedDataSource="RadGrid1_NeedDataSource"
        AllowPaging="True" PageSize="10" OnItemDataBound="RadGrid1_ItemDataBound">
        <ExportSettings HideStructureColumns="true"  ExportOnlyData="true" IgnorePaging="true">
        </ExportSettings>
        <MasterTableView  CommandItemDisplay="TopAndBottom"
            ShowHeadersWhenNoRecords="True" AutoGenerateColumns="true" AllowMultiColumnSorting="True"
            AllowSorting="True" AllowFilteringByColumn="True">
            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true"
                ShowExportToExcelButton="true" ExportToCsvText="Csv" ExportToExcelText="Excel" />
        </MasterTableView>
    </telerik:RadGrid>
    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
</asp:Content>
