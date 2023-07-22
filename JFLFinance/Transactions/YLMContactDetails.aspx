<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YLMContactDetails.aspx.cs" Inherits="Transactions_YLMContactDetails" MasterPageFile="~/MasterPage/MasterPage.master" %>
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
               <table>
               <tr>
               <td align="right">
                <asp:Button ID="btnBack" runat="server" Text ="<%$ Resources:Resource,Back %>" OnClick = "btnBack_Click" CssClass="cssButton" />
               </td>
              </tr>
              <tr>
              <td>
                     <asp:Panel runat="server" ID="PnlReport" GroupingText="<%$ Resources:Resource, YLMContactDetails %>" Height="100%" Width="100%">
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
                   <%-- <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                        <div style="float: left; width: 870px;">
                            <tt style="text-align: center;"><asp:Label ID="lblReportHeader" CssClass="squareboxgradientcaption" runat="server" Text=""></asp:Label></tt>
                        </div>
                    </div>--%>
                 
                    <telerik:RadGrid id="RadGrid1"  Skin="Office2007"  runat="server" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound">
                        <ExportSettings ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                           <%-- <Pdf PageBottomMargin="" PageFooterMargin="" PageHeaderMargin="" PageHeight="11in" PageLeftMargin="" PageRightMargin="" PageTopMargin="" PageWidth="8.5in" />--%>
                            <Excel FileExtension="xls" Format="Html" />
                         <%--   <Csv FileExtension="csv" />--%>
                        </ExportSettings>
                        <MasterTableView CommandItemDisplay="TopAndBottom" ShowHeadersWhenNoRecords="True" AutoGenerateColumns="False" AllowMultiColumnSorting="True" AllowSorting="True" 
                        AllowFilteringByColumn="True" PageSize="10" AllowPaging="True">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="false" ShowExportToExcelButton="true" ShowExportToPdfButton="false"
                            ExportToCsvText="Csv" ExportToExcelText="Excel" ExportToPdfText="Pdf"/>
                          <Columns>
                                
                                    <telerik:GridTemplateColumn DataField="DivisionID" HeaderText="<%$ Resources:Resource, Division %>" UniqueName="DivisionID" SortExpression="DivisionID">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDivisionID"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DivisionID").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                     </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn DataField="DivisionName" HeaderText="<%$ Resources:Resource, DivisionName %>" UniqueName="DivisionName" SortExpression="DivisionName">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDivisionName"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DivisionName").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                   </telerik:GridTemplateColumn>
                                   
                                    <telerik:GridTemplateColumn DataField="BranchID" HeaderText="<%$ Resources:Resource, BranchID %>" UniqueName="BranchID" SortExpression="BranchID">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchID").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                     </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn DataField="BranchName" HeaderText="<%$ Resources:Resource, Branch %>" UniqueName="BranchName" SortExpression="BranchName">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchName").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn DataField="AreaIncharge" HeaderText="<%$ Resources:Resource, AreaIncharge %>" UniqueName="AreaIncharge" SortExpression="AreaIncharge">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAreaIncharge"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaIncharge").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <%--Added New Column--%>
                                 <telerik:GridTemplateColumn DataField="AreaDesc" HeaderText="<%$ Resources:Resource, AreaDesc %>" UniqueName="AreaDesc" SortExpression="AreaDesc">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAreaDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaDesc").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn DataField="AreaID" HeaderText="<%$ Resources:Resource, Area %>" UniqueName="AreaID" SortExpression="AreaID">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblArea" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaID").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="ClientCode" HeaderText="<%$ Resources:Resource, ClientCode %>" UniqueName="ClientCode" SortExpression="ClientCode">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="ClientName" HeaderText="<%$ Resources:Resource, ClientName %>" UniqueName="ClientName" SortExpression="ClientName">
                                    <HeaderStyle Width="300px"/>
                                    <ItemStyle Width="300px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn DataField="ContractNumber" HeaderText="<%$ Resources:Resource, ContractNumber %>" UniqueName="ContractNumber" SortExpression="ContractNumber">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblContractNumber"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContractNumber").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                      </telerik:GridTemplateColumn>
                               
                                <telerik:GridTemplateColumn DataField="AsmtId" HeaderText="<%$ Resources:Resource, AsmtID %>" UniqueName="AsmtId" SortExpression="AsmtID">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtID").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="AsmtAddress" HeaderText="<%$ Resources:Resource, AsmtName %>" UniqueName="AsmtName" SortExpression="AsmtAddress">
                                    <HeaderStyle Width="350px"/>
                                    <ItemStyle Width="350px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsmtName"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtName").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                
                                     <telerik:GridTemplateColumn DataField="ServiceCategoryCode" HeaderText="<%$ Resources:Resource, ServiceCategoryCode %>" UniqueName="ServiceCategoryCode" SortExpression="ServiceCategoryCode">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblServiceCategoryCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceCategoryCode").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                              
                                <telerik:GridTemplateColumn DataField="PostCode" HeaderText="<%$ Resources:Resource, PostCode %>" UniqueName="PostCode" SortExpression="PostCode">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblShiftCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostCode").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                 <telerik:GridTemplateColumn DataField="PostDesc" HeaderText="<%$ Resources:Resource, PostDesc %>" UniqueName="PostDesc" SortExpression="PostDesc">
                                    <HeaderStyle Width="200px"/>
                                    <ItemStyle Width="200px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostDesc"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                   <telerik:GridTemplateColumn DataField="PhoneNumbers" HeaderText="<%$ Resources:Resource, PhoneNumber %>" UniqueName="PhoneNumbers" SortExpression="PhoneNumbers">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhoneNumbers" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PhoneNumbers").ToString()%>' ForeColor="Black" ></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                  <telerik:GridTemplateColumn DataField="AttendanceType" HeaderText="<%$ Resources:Resource, AttendanceType %>" UniqueName="AttendanceType" SortExpression="AttendanceType">
                                    <HeaderStyle Width="100px"/>
                                    <ItemStyle Width="100px" VerticalAlign="Top" ForeColor="Black"/>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAttendanceType"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AttendanceType").ToString()%>' ForeColor="Black" ></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

         
                               
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </ContentTemplate>
        </Ajax:UpdatePanel>
        </asp:Panel>
         
    </td>
      </tr>
              
  </table>
</asp:Content>