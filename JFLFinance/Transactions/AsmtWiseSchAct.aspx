<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#"  AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPage.master"
CodeFile="AsmtWiseSchAct.aspx.cs" Inherits="Transactions_AsmtWiseSchAct" EnableEventValidation="false"%> 
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
                            <tt style="text-align: center;"><asp:Label ID="lblReportHeader" CssClass="squareboxgradientcaption" runat="server" Text=""></asp:Label></tt>
                        </div>
                    </div>

                    <telerik:RadGrid id="RadGrid1"  Skin="Office2007"  runat="server" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound">
                        <ExportSettings ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                            <Pdf PageBottomMargin="" PageFooterMargin="" PageHeaderMargin="" PageHeight="11in" PageLeftMargin="" PageRightMargin="" PageTopMargin="" PageWidth="8.5in" />
                            <Excel FileExtension="xls" Format="Html" />
                            <Csv FileExtension="csv" />
                        </ExportSettings>
                        <MasterTableView CommandItemDisplay="TopAndBottom" ShowHeadersWhenNoRecords="True" AutoGenerateColumns="False" AllowMultiColumnSorting="True" AllowSorting="True" 
                        AllowFilteringByColumn="True" PageSize="10" AllowPaging="True">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true" ShowExportToExcelButton="true" ShowExportToPdfButton="false"
                            ExportToCsvText="Csv" ExportToExcelText="Excel" ExportToPdfText="Pdf"/>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="<%$ Resources:Resource,SerialNumber %>" UniqueName="SerialNumber" AllowFiltering="false"  ForceExtractValue="InEditMode">
                                    <HeaderStyle Width="50px"/>
                                    <ItemStyle Width="50px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="ClientCode" HeaderText="<%$ Resources:Resource, ClientCode %>" UniqueName="ClientCode" SortExpression="ClientCode">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="ClientName" HeaderText="<%$ Resources:Resource, ClientName %>" UniqueName="ClientName" SortExpression="ClientName">
                                    <HeaderStyle Width="300px"/>
                                    <ItemStyle Width="300px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="AsmtCode" HeaderText="<%$ Resources:Resource, AsmtCode %>" UniqueName="AsmtCode" SortExpression="AsmtCode">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtCode").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="AsmtId" HeaderText="<%$ Resources:Resource, AsmtId %>" UniqueName="AsmtId" SortExpression="AsmtId">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="AsmtName" HeaderText="<%$ Resources:Resource, AsmtName %>" UniqueName="AsmtName" SortExpression="AsmtName">
                                    <HeaderStyle Width="350px"/>
                                    <ItemStyle Width="350px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtName").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="SoNo" HeaderText="<%$ Resources:Resource, SoNo %>" UniqueName="SoNo" SortExpression="SoNo">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSoNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SoNo").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="ShiftCode" HeaderText="<%$ Resources:Resource, ShiftCode %>" UniqueName="ShiftCode" SortExpression="ShiftCode">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblShiftCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ShiftCode").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="DutyDate" HeaderText="<%$ Resources:Resource, DutyDate %>" UniqueName="DutyDate" SortExpression="DutyDate">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDutyDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="EmployeeNumber" HeaderText="<%$ Resources:Resource, EmployeeNumber %>" UniqueName="EmployeeNumber" SortExpression="EmployeeNumber">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="EmpName" HeaderText="<%$ Resources:Resource, EmployeeName %>" UniqueName="EmpName" SortExpression="EmpName">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmpName").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="DesignationCode" HeaderText="<%$ Resources:Resource, DesignationCode %>" UniqueName="DesignationCode" SortExpression="DesignationCode">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DesignationCode").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="DesignationDesc" HeaderText="<%$ Resources:Resource, DesignationDesc %>" UniqueName="DesignationDesc" SortExpression="DesignationDesc">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DesignationDesc").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="SORank" HeaderText="<%$ Resources:Resource, SORank %>" UniqueName="SORank" SortExpression="SORank">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSORank" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SORank").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="PostCode" HeaderText="<%$ Resources:Resource, PostCode %>" UniqueName="PostCode" SortExpression="PostCode">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostCode").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="PostDesc" HeaderText="<%$ Resources:Resource, PostDesc %>" UniqueName="PostDesc" SortExpression="PostDesc">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="StdShiftFromTime" HeaderText="<%$ Resources:Resource, FromTime %>" UniqueName="StdShiftFromTime" SortExpression="StdShiftFromTime">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate><%-- Manish 25-06-2012 change the format into 24hrs replaced hh to H--%>
                                        <asp:Label ID="lblStdShiftFromTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:H:mm}",Eval("StdShiftFromTime")) %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="StdShiftToTime" HeaderText="<%$ Resources:Resource, ToTime %>" UniqueName="StdShiftToTime" SortExpression="StdShiftToTime">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate> <%-- Manish 25-06-2012 change the format into 24hrs replaced hh to H--%>
                                        <asp:Label ID="lblStdShiftToTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:H:mm}",Eval("StdShiftToTime")) %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="YLMUniqueId" HeaderText="<%$ Resources:Resource, YLMUniqueId %>" UniqueName="YLMUniqueId" SortExpression="YLMUniqueId">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblYLMUniqueId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "YLMUniqueId").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </ContentTemplate>
        </Ajax:UpdatePanel>
</asp:Content>