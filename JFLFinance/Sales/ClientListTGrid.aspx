<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ClientListTGrid.aspx.cs" Inherits="Sales_ClientListTGrid" %>

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
                            <Excel FileExtension="xls" Format="Html"/>
                            <Csv FileExtension="csv" />
                        </ExportSettings>
                        <MasterTableView CommandItemDisplay="TopAndBottom" ShowHeadersWhenNoRecords="True" AutoGenerateColumns="False" AllowMultiColumnSorting="True" AllowSorting="True" 
                        AllowFilteringByColumn="True" PageSize="10" AllowPaging="True" GridLines="Both" BorderColor="Black">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true" ShowExportToExcelButton="true" ShowExportToPdfButton="true"
                            ExportToCsvText="Csv" ExportToExcelText="Excel" ExportToPdfText="Pdf"/>
                          <Columns>
                                
                                <telerik:GridTemplateColumn DataField="LocationDesc" HeaderText="<%$ Resources:Resource, Branch %>" UniqueName="LocationDesc" SortExpression="LocationDesc">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LocationDesc").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn DataField="ClientCode" HeaderText="<%$ Resources:Resource, ClientCode %>" UniqueName="ClientCode" SortExpression="ClientCode">
                                    <HeaderStyle Width="120px"/>
                                    <ItemStyle Width="120px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientCode" Width="120px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn DataField="ClientName" HeaderText="<%$ Resources:Resource, ClientName %>" UniqueName="ClientName" SortExpression="ClientName">
                                    <HeaderStyle Width="250px"/>
                                    <ItemStyle Width="250px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientName" Width="250px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn DataField="AsmtId" HeaderText="<%$ Resources:Resource, AsmtId %>" UniqueName="AsmtId" SortExpression="AsmtId">
                                    <HeaderStyle Width="150px"/>
                                    
                                    <ItemStyle Width="150px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtId" Width="150px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn DataField="AsmtAddress" HeaderText="<%$ Resources:Resource, AsmtName %>" UniqueName="AsmtAddress" SortExpression="AsmtAddress">
                                    <HeaderStyle Width="300px"/>
                                    <ItemStyle Width="300px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtAddress" Width="300px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtAddress").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <%--New Column Added By Ajay Datta On 10-May-2013 for Assignment Location Name--%>
                                <telerik:GridTemplateColumn DataField="AsmtLocationDesc" HeaderText="<%$ Resources:Resource, AssignmentLocation %>" UniqueName="AsmtLocationDesc" SortExpression="AsmtLocationDesc">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtLocationDesc" Width="200px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtLocationDesc").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn DataField="SoNo" HeaderText="<%$ Resources:Resource, SalesOrder %>" UniqueName="SoNo" SortExpression="SoNo">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSoNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SoNo").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                  

                              
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </ContentTemplate>
        </Ajax:UpdatePanel>


</asp:Content>