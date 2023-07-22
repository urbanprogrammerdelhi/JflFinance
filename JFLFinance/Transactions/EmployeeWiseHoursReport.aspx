<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeWiseHoursReport.aspx.cs" Inherits="Transactions_EmployeeWiseHoursReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblReportHeader" runat="server" />
    <script type="text/javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
                args.set_enableAjax(false);
            }
        }
    </script>
    <%--  <div style="text-align: right;">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnBack" runat="server" Text="<%$Resources:Resource,Back %>" CssClass="cssButton"
                        OnClick="btnBack_Click" />
                </td>
            </tr>
        </table>
    </div>--%>
    <table>
        <tr>
            <td>
                <div style="text-align: right;">
                    <asp:Button ID="Button1" runat="server" Text="<%$Resources:Resource,Back %>" CssClass="cssButton"
                        OnClick="btnBack_Click" />
                </div>
                <asp:Panel runat="server" ID="PnlReport" GroupingText="<%$ Resources:Resource, EmployeeWiseHoursReport %>"
                    Height="100%" Width="100%">
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
                    <telerik:RadGrid ID="RadGrid1" GridLines="Both" Width="2000px" Skin="Office2007"
                        runat="server" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound"
                        AllowPaging="true">
                        <ExportSettings Pdf-PageWidth="100%" ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                            <Excel FileExtension="xls" Format="Html" />
                            <Csv FileExtension="csv" />
                        </ExportSettings>
                        <MasterTableView CssClass="RadGrid_MyCustomSkin" CommandItemDisplay="TopAndBottom"
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
</asp:Content>
