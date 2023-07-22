<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaleOrderDetailISR2.aspx.cs"
    Inherits="Transactions_SaleOrderDetailISR2" MasterPageFile="~/MasterPage/MasterPage.master" %>

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
     <%-- <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
    <%-- <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>--%>
        <telerik:RadGrid ID="RadGrid1" Skin="Office2007" AllowPaging="True" runat="server"
        OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand">
        <ExportSettings ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
            <Excel FileExtension="xls" Format="Html" />
            <Csv FileExtension="csv" />
        </ExportSettings>
        <MasterTableView CommandItemDisplay="TopAndBottom" ShowHeadersWhenNoRecords="True"
            AutoGenerateColumns="False" AllowMultiColumnSorting="True" AllowSorting="True"
            AllowFilteringByColumn="True" PageSize="10" >
            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="false"
                ShowExportToExcelButton="true" ShowExportToPdfButton="false" ExportToCsvText="Csv"
                ExportToExcelText="Excel" ExportToPdfText="Pdf" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn DataField="DivisionID" HeaderText="<%$ Resources:Resource, Division %>"
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
                <telerik:GridTemplateColumn DataField="BranchId" HeaderText="<%$ Resources:Resource, Location %>"
                    UniqueName="BranchId" SortExpression="BranchId">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblBranchId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchId").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="BranchName" HeaderText="<%$ Resources:Resource, LocationDescription %>"
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
                <telerik:GridTemplateColumn DataField="AreaDesc" HeaderText="<%$ Resources:Resource, AreaInchargeDetail %>"
                    UniqueName="AreaDesc" SortExpression="AreaDesc">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblAreaInchargeDescription" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaDesc").ToString()%>'></asp:Label>
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
                <telerik:GridTemplateColumn DataField="ClientCode" HeaderText="<%$ Resources:Resource, ClientCode %>"
                    UniqueName="ClientCode" SortExpression="ClientCode">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="ClientName" HeaderText="<%$ Resources:Resource, ClientName %>"
                    UniqueName="ClientName" SortExpression="ClientName">
                    <HeaderStyle Width="300px" />
                    <ItemStyle Width="300px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="ContractNumber" HeaderText="<%$ Resources:Resource, ContractNumber %>"
                    UniqueName="ContractNumber" SortExpression="ContractNumber">
                    <HeaderStyle Width="300px" />
                    <ItemStyle Width="300px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblContractNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContractNumber").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="SoNo" HeaderText="<%$ Resources:Resource, SONo %>"
                    UniqueName="SoNo" SortExpression="SoNo">
                    <HeaderStyle Width="300px" />
                    <ItemStyle Width="300px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblSaleOrderNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SoNo").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="SaleOrderTypeDesc" HeaderText="<%$ Resources:Resource, SaleOrderTypeDesc %>"
                    UniqueName="SaleOrderTypeDesc" SortExpression="SaleOrderTypeDesc">
                    <HeaderStyle Width="300px" />
                    <ItemStyle Width="300px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblSaleOrderType" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SaleOrderTypeDesc").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="BillingPattern" HeaderText="<%$ Resources:Resource, BillingPattern %>"
                    UniqueName="BillingPattern" SortExpression="BillingPattern">
                    <HeaderStyle Width="300px" />
                    <ItemStyle Width="300px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblSaleBillingPattern" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BillingPattern").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="SoLineStartDate" HeaderText="<%$ Resources:Resource, SOLineStartDate %>"
                    UniqueName="SoLineStartDate" SortExpression="SoLineStartDate">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <%--<asp:Label ID="lblSaleSoLineStartDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SoLineStartDate")) %>'></asp:Label>--%>
                        <asp:Label ID="lblSaleSoLineStartDate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SoLineStartDate").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="SoLineEndDate" HeaderText="<%$ Resources:Resource, SOLineEndDate %>"
                    UniqueName="SoLineEndDate" SortExpression="SoLineEndDate">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblSaleSoLineEndDate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOLineEndDate").ToString()%>'></asp:Label>
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
                        <asp:Label ID="lblAsmtName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtName").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            <%--    <telerik:GridTemplateColumn DataField="ServiceCategoryCode" HeaderText="<%$ Resources:Resource, ServiceCategoryCode %>"
                    UniqueName="ServiceCategoryCode" SortExpression="ServiceCategoryCode">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblServiceCategoryCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceCategoryCode").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                <telerik:GridTemplateColumn DataField="PostCode" HeaderText="<%$ Resources:Resource, PostDesc %>"
                    UniqueName="PostCode" SortExpression="PostCode">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblShiftCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="SORank" HeaderText="<%$ Resources:Resource, SORank %>"
                    UniqueName="SORank" SortExpression="SORank">
                    <HeaderStyle Width="200px" />
                    <ItemStyle Width="200px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblSORank" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SORank").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="NoOfPerson" HeaderText="<%$ Resources:Resource, NoOfPersons %>"
                    UniqueName="NoOfPerson" SortExpression="NoOfPerson">
                    <HeaderStyle Width="200px" />
                    <ItemStyle Width="200px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblNoOfPersons" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfPerson").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="TimeFrom" HeaderText="<%$ Resources:Resource, StartTime %>"
                    UniqueName="TimeFrom" SortExpression="TimeFrom">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblTimeFrom" CssClass="cssLable" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "TimeFrom").ToString()%>'></asp:Label>  <%--Text='<%# String.Format("{0:H:mm}",Eval("TimeFrom")) %>'--%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="TimeTo" HeaderText="<%$ Resources:Resource, EndTime %>"
                    UniqueName="TimeTo" SortExpression="TimeTo">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblTimeTo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TimeTo").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="MinWages" HeaderText="<%$ Resources:Resource, PayRate %>"
                    UniqueName="MinWages" SortExpression="MinWages">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblContractPayRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MinWages").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="ChargeRatePerHour" HeaderText="<%$ Resources:Resource, ChargeRatePerHour %>"
                    UniqueName="ChargeRatePerHour" SortExpression="ChargeRatePerHour">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblContractChargeRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ChargeRatePerHour").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="MinProfitability" HeaderText="<%$ Resources:Resource, MinProfitability %>"
                    UniqueName="MinProfitability" SortExpression="MinProfitability">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblMinProfitability" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MinProfitability").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="MaxProfitability" HeaderText="<%$ Resources:Resource, OptimumProfitability %>"
                    UniqueName="MaxProfitability" SortExpression="MaxProfitability">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblMaxProfitability" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "optimumProfitability").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="WeekDays" HeaderText="<%$ Resources:Resource, WeekDay %>"
                    UniqueName="WeekDays" SortExpression="WeekDays">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblWeekDays" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WeekDays").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="PayIndicator" HeaderText="<%$ Resources:Resource, PayRateType %>"
                    UniqueName="PayIndicator" SortExpression="PayIndicator">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblPayIndicator" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PayIndicator").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="SellingPrice" HeaderText="<%$ Resources:Resource, SOLineAmount %>"
                    UniqueName="SellingPrice" SortExpression="SellingPrice">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblSellingPrice" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SellingPrice").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="MonthlyBillingAmount" HeaderText="<%$ Resources:Resource, SONumberMonthlyBillingAmount %>"
                    UniqueName="MonthlyBillingAmount" SortExpression="MonthlyBillingAmount">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" VerticalAlign="Top" />
                    <ItemTemplate>
                        <asp:Label ID="lblMonthlyBillingAmount" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MonthlyBillingAmount").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
            <WebServiceSettings>
                <ODataSettings InitialContainerName="">
                </ODataSettings>
            </WebServiceSettings>
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Office2007">
            <WebServiceSettings>
                <ODataSettings InitialContainerName="">
                </ODataSettings>
            </WebServiceSettings>
        </HeaderContextMenu>
    </telerik:RadGrid>
    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
    <%--  </ContentTemplate>
    </Ajax:UpdatePanel>--%>
</asp:Content>
