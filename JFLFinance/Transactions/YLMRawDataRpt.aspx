<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="YLMRawDataRpt.aspx.cs" Inherits="Transactions_YLMRawDataRpt" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true" ShowExportToExcelButton="true" ShowExportToPdfButton="true"
                            ExportToCsvText="Csv" ExportToExcelText="Excel" ExportToPdfText="Pdf"/>
                          <Columns>
                                
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
                               
                                <telerik:GridTemplateColumn DataField="AsmtId" HeaderText="<%$ Resources:Resource, AsmtID %>" UniqueName="AsmtId" SortExpression="AsmtID">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtID").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="AsmtAddress" HeaderText="<%$ Resources:Resource, AsmtName %>" UniqueName="AsmtName" SortExpression="AsmtAddress">
                                    <HeaderStyle Width="350px"/>
                                    <ItemStyle Width="350px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtAddress").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                              
                                <telerik:GridTemplateColumn DataField="PostCode" HeaderText="<%$ Resources:Resource, PostCode %>" UniqueName="PostCode" SortExpression="PostCode">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblShiftCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostCode").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn DataField="PostDesc" HeaderText="<%$ Resources:Resource, PostDesc %>" UniqueName="PostDesc" SortExpression="PostDesc">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn DataField="EmployeeNumber" HeaderText="<%$ Resources:Resource, EmployeeNumber %>" UniqueName="EmployeeNumber" SortExpression="EmployeeNumber">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                               
                                                             
                               <telerik:GridTemplateColumn DataField="EmployeeName" HeaderText="<%$ Resources:Resource, EmployeeName %>" UniqueName="EmployeeName" SortExpression="EmployeeName">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                  <telerik:GridTemplateColumn DataField="YLMProcessedDutyDate" HeaderText="<%$ Resources:Resource, DutyDate %>" UniqueName="YLMProcessedDutyDate" SortExpression="YLMProcessedDutyDate">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDutyDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("YLMProcessedDutyDate")) %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                               

                                <telerik:GridTemplateColumn DataField="SchTimeFrom" HeaderText="<%$ Resources:Resource, CallTime %>" UniqueName="SchTimeFrom" SortExpression="SchTimeFrom">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSchTimeFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:H:mm}",Eval("CallTime")) %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                              <telerik:GridTemplateColumn DataField="Action" HeaderText="<%$ Resources:Resource, Action %>" UniqueName="Action" SortExpression="Action">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblShiftCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Action").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>


                             <telerik:GridTemplateColumn DataField="YLMUID" HeaderText="<%$ Resources:Resource, YLMUID %>" UniqueName="YLMUID" SortExpression="YLMUID">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblShiftCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "YLMUID").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                


                               
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </ContentTemplate>
        </Ajax:UpdatePanel>


</asp:Content>

