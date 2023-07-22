<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConstraintGridReport.aspx.cs" Inherits="Transactions_ConstraintGridReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportTo") >= 0) {
                args.set_enableAjax(false);
            }
        }
         
    </script>
    <table width="100%">
        <tr>
            <td align="right" style="height: 25px">
                <asp:Button runat="server" ID="BtnBack" Text="<%$ Resources:Resource,Back %>" OnClick="BtnBack_OnClick"
                    CssClass="cssButton" />
                <asp:HiddenField runat="server" ID="HfBack" Value="" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel runat="server" ID="PnlReport" Border="0" GroupingText="">
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
                    <telerik:RadGrid ID="RadGrid1" Skin="Office2007" runat="server" AllowPaging="True"
                        OnNeedDataSource="RadGrid1_NeedDataSource" PageSize="10" OnItemCommand="RadGrid1_ItemCommand"
                        OnPageIndexChanged="RadGrid1_PageIndexChanged">
                        <%--<ExportSettings HideStructureColumns="true" ExportOnlyData="true" IgnorePaging="true">
                        </ExportSettings>--%>
                        <ExportSettings Pdf-PageWidth="100%" ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                            <Excel FileExtension="xls" Format="Html" />
                            <Csv FileExtension="csv" />
                        </ExportSettings>
                        <MasterTableView CssClass="RadGrid_MyCustomSkin" CommandItemDisplay="TopAndBottom"
                            RetrieveAllDataFields="True" ShowHeadersWhenNoRecords="True" AutoGenerateColumns="False"
                            AllowMultiColumnSorting="True" AllowSorting="True" EnableColumnsViewState="True">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" ShowExportToExcelButton="true"
                                ExportToCsvText="Csv" ExportToExcelText="Excel" />
                        </MasterTableView>
                    </telerik:RadGrid>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
