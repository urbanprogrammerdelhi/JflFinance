<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="UnscheduledEmployeesRpt.aspx.cs" Inherits="Transactions_UnscheduledEmployeesRpt" %>

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
    <table>
        <tr>
            <td>
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--     <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                <div style="float: left; width: 870px;">
                    <tt style="text-align: center;">
                        <asp:Label ID="lblReportHeader" CssClass="squareboxgradientcaption" runat="server"
                            Text=""></asp:Label></tt>
                </div>
            </div>--%>
                        <telerik:RadGrid ID="RadGrid1"  Skin="Office2007"  Width="100%" runat="server"
                            OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound">
                            <ExportSettings ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                                <Pdf PageBottomMargin="" PageFooterMargin="" PageHeaderMargin="" PageHeight="11in"
                                    PageLeftMargin="" PageRightMargin="" PageTopMargin="" PageWidth="8.5in" />
                                <Excel FileExtension="xls" Format="Html" />
                                <Csv FileExtension="csv" />
                            </ExportSettings>
                            <MasterTableView CommandItemDisplay="TopAndBottom"
                                ShowHeadersWhenNoRecords="True" AutoGenerateColumns="False" AllowMultiColumnSorting="True"
                                AllowSorting="True" AllowFilteringByColumn="True" PageSize="10" AllowPaging="True">
                                <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true"
                                    ShowExportToExcelButton="true" ShowExportToPdfButton="true" ExportToCsvText="Csv"
                                    ExportToExcelText="Excel" ExportToPdfText="Pdf" />
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="false" DataField="FromDate" HeaderText="<%$ Resources:Resource, FromDate %>"
                                        UniqueName="FromDate" SortExpression="FromDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromDate" Width="120px" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("FromDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="ToDate" AllowFiltering="false" HeaderText="<%$ Resources:Resource, ToDate %>"
                                        UniqueName="ToDate" SortExpression="ToDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToDate" Width="120px" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ToDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="LocationDesc" HeaderText="<%$ Resources:Resource, LocationDesc %>"
                                        UniqueName="LocationDesc" SortExpression="LocationDesc">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLocationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LocationDesc").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="EmpNo" HeaderText="<%$ Resources:Resource, EmployeeNumber %>"
                                        UniqueName="EmpNo" SortExpression="EmpNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmpNo").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="EmpName" HeaderText="<%$ Resources:Resource, EmployeeName %>"
                                        UniqueName="EmpName" SortExpression="EmpName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmpName").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="AreaID" HeaderText="<%$ Resources:Resource, AreaID %>"
                                        UniqueName="AreaID" SortExpression="AreaID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAreaID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaID").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="AreaDesc" HeaderText="<%$ Resources:Resource, AreaDesc %>"
                                        UniqueName="AreaDesc" SortExpression="AreaDesc">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAreaDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaDesc").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="AreaIncharge" HeaderText="<%$ Resources:Resource, AreaIncharge %>"
                                        UniqueName="AreaIncharge" SortExpression="AreaIncharge">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAreaIncharge" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaIncharge").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="AreaInchargeName" HeaderText="<%$ Resources:Resource, Name %>"
                                        UniqueName="AreaInchargeName" SortExpression="AreaInchargeName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAreaInchargeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaInchargeName").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="MonthlyDutyMin" HeaderText="<%$ Resources:Resource, Hours %>"
                                        UniqueName="MonthlyDutyMin" SortExpression="MonthlyDutyMin">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonthlyDutyMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MonthlyDutyMin").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="LastShiftDate" AllowFiltering="false" HeaderText="<%$ Resources:Resource, LastShiftDateWorked %>"
                                        UniqueName="LastShiftDate" SortExpression="LastShiftDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastShiftDateWorked" Width="120px" CssClass="cssLable" runat="server"
                                                Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("LastShiftDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="ClientCodeName" HeaderText="<%$ Resources:Resource, LastShiftClientWorked %>"
                                        UniqueName="ClientCodeName" SortExpression="ClientCodeName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientCodeName" Width="400px" CssClass="cssLable" runat="server"
                                                Text='<%# DataBinder.Eval(Container.DataItem, "ClientCodeName").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="AsmtIDAsmtName" HeaderText="<%$ Resources:Resource, LastShiftAsmtWorked %>"
                                        UniqueName="AsmtIDAsmtName" SortExpression="AsmtIDAsmtName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAsmtIDAsmtName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtIDAsmtName").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
