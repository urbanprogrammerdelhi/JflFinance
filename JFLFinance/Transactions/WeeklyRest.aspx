<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/MasterPage/MasterPage.master" CodeFile="WeeklyRest.aspx.cs"
    Inherits="Transactions_WeeklyRest" EnableEventValidation="false" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                <div style="float: left; width: 870px;">
                    <tt style="text-align: center;">
                        <asp:Label ID="lblReportHeader" CssClass="squareboxgradientcaption" runat="server"
                            Text=""></asp:Label></tt>
                </div>
            </div>
            <asp:Button ID="btnBack" runat="server" Text ="<%$ Resources:Resource,Back %>" OnClick = "btnBack_Click" />
             <asp:HiddenField runat="server" ID="HfBack" Value="" />
            <telerik:RadGrid ID="RadGrid1"  Skin="Office2007"  runat="server" OnNeedDataSource="RadGrid1_NeedDataSource"
                OnItemDataBound="RadGrid1_ItemDataBound" Width="900px">
                <ExportSettings ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                    <Pdf PageBottomMargin="" PageFooterMargin="" PageHeaderMargin="" PageHeight="11in"
                        PageLeftMargin="" PageRightMargin="" PageTopMargin="" PageWidth="8.5in" />
                    <Excel FileExtension="xls" Format="Html" />
                    <Csv FileExtension="csv" />
                </ExportSettings>
                <MasterTableView CommandItemDisplay="TopAndBottom"
                    ShowHeadersWhenNoRecords="True" AutoGenerateColumns="False" AllowMultiColumnSorting="True"
                    AllowSorting="True" AllowFilteringByColumn="false" PageSize="10" AllowPaging="True">
                    <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="false"
                        ShowExportToExcelButton="true" ShowExportToPdfButton="false" ExportToCsvText="Csv"
                        ExportToExcelText="Excel" ExportToPdfText="Pdf" />
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:Resource,SerialNumber %>" UniqueName="SerialNumber"
                            AllowFiltering="false" ForceExtractValue="InEditMode">
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         <telerik:GridTemplateColumn DataField="Month" HeaderText="<%$ Resources:Resource, Month %>"
                            UniqueName="Month" SortExpression="Month">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblMonth" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Month").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn DataField="WeekFrom-WeekTo" HeaderText="<%$ Resources:Resource, FromToWeek %>"
                            UniqueName="WeekFrom-WeekTo" SortExpression="WeekFrom-WeekTo">
                            <HeaderStyle Width="400px" />
                            <ItemStyle Width="400px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblWeekFrom_WeekTo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WeekFrom-WeekTo").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                      
                        <telerik:GridTemplateColumn DataField="EmployeeNumber" HeaderText="<%$ Resources:Resource, EmployeeNumber %>"
                            UniqueName="EmployeeNumber" SortExpression="EmployeeNumber">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="EmpName" HeaderText="<%$ Resources:Resource, EmployeeName %>"
                            UniqueName="EmpName" SortExpression="EmpName">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblEmpName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmpName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="BranchCode" HeaderText="<%$ Resources:Resource, BranchID %>"
                            UniqueName="BranchCode" SortExpression="BranchCode">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="BranchCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchCode").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="AreaID" HeaderText="<%$ Resources:Resource, AreaID %>"
                            UniqueName="AreaID" SortExpression="AreaID">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblAreaID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaID").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="AreaInchargeName" HeaderText="<%$ Resources:Resource, AreaIncharge %>"
                            UniqueName="AreaInchargeName" SortExpression="AreaInchargeName">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblAreaInchargeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaInchargeName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="WeeklyRestFlag" HeaderText="<%$ Resources:Resource, WeeklyRest %>" UniqueName="WeeklyRestFlag"
                            SortExpression="WeeklyRestFlag">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblWeekRest" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WeeklyRestFlag").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                           <telerik:GridTemplateColumn DataField="Count" HeaderText="<%$ Resources:Resource, WeeklyRestCount %>" UniqueName="Count"
                            SortExpression="Count">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblCount" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Count").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
