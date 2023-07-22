<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeWorkHistoryDetail.aspx.cs"
    Inherits="HRManagement_EmployeeWorkHistoryDetail" MasterPageFile="~/MasterPage/MasterPage.master" %>

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
            <telerik:AjaxSetting AjaxControlID="rgEmployeeWorkHistory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgEmployeeWorkHistory" />
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
                            Text=""></asp:Label>
                    </tt>
                </div>
            </div>
            <asp:Button runat="server" ID="btnBack" Text="<%$ Resources:Resource, Back %>" OnClick="btnBack_Click" CssClass="cssButton"/>
            <telerik:RadGrid ID="rgEmployeeWorkHistory" Skin="Office2007" runat="server" OnNeedDataSource="rgEmployeeWorkHistory_NeedDataSource"
                OnItemDataBound="rgEmployeeWorkHistory_ItemDataBound">
                <ExportSettings ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                    <Pdf PageBottomMargin="" PageFooterMargin="" PageHeaderMargin="" PageHeight="11in"
                        PageLeftMargin="" PageRightMargin="" PageTopMargin="" PageWidth="8.5in" />
                    <Excel FileExtension="xls" Format="Html" />
                </ExportSettings>
                <MasterTableView CommandItemDisplay="TopAndBottom" ShowHeadersWhenNoRecords="True"
                    AutoGenerateColumns="False" AllowMultiColumnSorting="True" AllowSorting="True"
                    AllowFilteringByColumn="True" PageSize="10" AllowPaging="True">
                    <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="false"
                        ShowExportToExcelButton="true" ShowExportToPdfButton="false" ExportToCsvText="Csv"
                        ExportToExcelText="Excel" ExportToPdfText="Pdf" />
                    <Columns>
                        <telerik:GridTemplateColumn DataField="DivisionId" HeaderText="<%$ Resources:Resource, DivisionId %>"
                            UniqueName="DivisionId" SortExpression="DivisionId">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DivisionId").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="DivisionName" HeaderText="<%$ Resources:Resource, DivisionName %>"
                            UniqueName="DivisionName" SortExpression="DivisionName">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DivisionName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="BranchId" HeaderText="<%$ Resources:Resource, BranchID %>"
                            UniqueName="BranchId" SortExpression="BranchId">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblBranchId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchId").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="BranchName" HeaderText="<%$ Resources:Resource, BranchName %>"
                            UniqueName="BranchName" SortExpression="BranchName">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblBranchName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="AreaIncharge" HeaderText="<%$ Resources:Resource, AreaIncharge %>"
                            UniqueName="AreaIncharge" SortExpression="AreaIncharge">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblAreaIncharge" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaIncharge").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="AreaID" HeaderText="<%$ Resources:Resource, AreaID %>"
                            UniqueName="AreaID" SortExpression="AreaID">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblAreaID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaID").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="AreaDesc" HeaderText="<%$ Resources:Resource, AreaDesc %>"
                            UniqueName="AreaDesc" SortExpression="AreaDesc">
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblAreaInchargeDescription" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaDesc").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="EmployeeNumber" HeaderText="<%$ Resources:Resource, EmployeeNumber %>"
                            UniqueName="EmployeeNumber" SortExpression="EmployeeNumber">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="EmployeeName" HeaderText="<%$ Resources:Resource, EmployeeName %>"
                            UniqueName="EmployeeName" SortExpression="EmployeeName">
                            <HeaderStyle Width="300px" />
                            <ItemStyle Width="300px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="ClientCode" HeaderText="<%$ Resources:Resource, ClientCode %>"
                            UniqueName="ClientCode" SortExpression="ClientCode">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="ClientName" HeaderText="<%$ Resources:Resource, ClientName %>"
                            UniqueName="ClientName" SortExpression="ClientName">
                            <HeaderStyle Width="350px" />
                            <ItemStyle Width="350px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblClientName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="AsmtId" HeaderText="<%$ Resources:Resource, AsmtID %>"
                            UniqueName="AsmtId" SortExpression="AsmtID">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtID").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="AsmtAddress" HeaderText="<%$ Resources:Resource, AsmtName %>"
                            UniqueName="AsmtName" SortExpression="AsmtAddress">
                            <HeaderStyle Width="350px" />
                            <ItemStyle Width="350px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblAsmtName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtAddress").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         <telerik:GridDateTimeColumn DataField="StartDate" HeaderText="<%$ Resources:Resource, StartDate %>"
                            UniqueName="StartDate" SortExpression="StartDate" PickerType="DatePicker" FilterControlWidth="100px"
                        DataFormatString="{0:dd-MMM-yyyy}"  ShowFilterIcon="false" ItemStyle-CssClass="cssLable" AutoPostBackOnFilter="true"> 
                        </telerik:GridDateTimeColumn>
                 <telerik:GridDateTimeColumn DataField="LastWorkingDate" HeaderText="<%$ Resources:Resource, LastWorkingDate %>"
                            UniqueName="LastWorkingDate" SortExpression="LastWorkingDate" PickerType="DatePicker" FilterControlWidth="100px"
                        DataFormatString="{0:dd-MMM-yyyy}"  ShowFilterIcon="false" ItemStyle-CssClass="cssLable" AutoPostBackOnFilter="true"> 
                        </telerik:GridDateTimeColumn>
                  
                        <telerik:GridTemplateColumn DataField="Shifts" HeaderText="<%$ Resources:Resource, DutyCount %>"
                            UniqueName="Shifts" SortExpression="Shifts">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblShifts" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Shifts").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="TotalHours" HeaderText="<%$ Resources:Resource, TotalHours %>"
                            UniqueName="TotalHours" SortExpression="TotalHours">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotalHours" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHours").ToString()%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="ConfirmStatus" HeaderText="<%$ Resources:Resource, ConfirmDuty %>"
                            UniqueName="ConfirmStatus" SortExpression="ConfirmStatus">
                            <HeaderStyle Width="200px" />
                              <FilterTemplate>
                    <telerik:RadComboBox ID="rcbConfirmStatus" 
                      SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("ConfirmStatus").CurrentFilterValue %>'
                        runat="server" OnClientSelectedIndexChanged="ConfirmStatusIndexChange" Width="100px">
                        <Items>
                             <telerik:RadComboBoxItem Text="<%$Resources:Resource, All %>"  Selected="true"/>
                            <telerik:RadComboBoxItem Text="<%$Resources:Resource, Confirmed %>" Value="<%$Resources:Resource, Confirmed %>"/>
                            <telerik:RadComboBoxItem Text="<%$Resources:Resource, NotConfirmed %>" Value="NotConfirmed" />
                                               
                        </Items>
                    </telerik:RadComboBox>
                    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                        <script type="text/javascript">
                            function ConfirmStatusIndexChange(sender, args) {
                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                tableView.filter("ConfirmStatus", args.get_item().get_value(), "EqualTo");
                            }
                        </script>
                    </telerik:RadScriptBlock>
                </FilterTemplate>
                            <ItemStyle Width="200px" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblConfirmDuty" CssClass="cssLable" runat="server" Text='<%# GetGlobalResourceObject("Resource", Eval("ConfirmStatus").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            <br />
            <asp:Label ID="lblConfirmed" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            <br />
            <asp:Label ID="lblNotConfirmed" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
