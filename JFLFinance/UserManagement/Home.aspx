<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="UserManagement_Home" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="TabFlowDiag"
        ActiveTabIndex="0" AutoPostBack="false" onactivetabchanged="TabFlowDiag_ActiveTabChanged">
        <AjaxToolKit:TabPanel ID="TabPanel1" runat="server" HeaderText="<%$ Resources:Resource, ToDoList %>" Visible="false">
            <ContentTemplate>
                <asp:LinkButton ID="lbtnToDoList"  visible="False" runat="server" Text="<%$ Resources:Resource, YourPage %>" CssClass="btn btn-primary btn-xs" OnClick="lbtnToDoList_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbPendingSaleOrder" runat="server" Text="<%$ Resources:Resource, PendingSaleOrder %>" CssClass="btn btn-primary btn-xs" OnClick="lbPendingSaleOrder_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbPendingContract" runat="server" Text="<%$ Resources:Resource, PendingContract %>" CssClass="btn btn-primary btn-xs" OnClick="lbPendingContract_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbContractReview" runat="server" Text="<%$ Resources:Resource, ContractReview %>" CssClass="btn btn-primary btn-xs" OnClick="lbContractReview_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbrptContractExpiry" runat="server" Text="<%$ Resources:Resource, rptContractExpiry %>" CssClass="btn btn-primary btn-xs" OnClick="lbrptContractExpiry_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbPendingBorrowEmployeeRequest" runat="server" Text="<%$ Resources:Resource, PendingBorrowEmployeeRequest %>" CssClass="btn btn-primary btn-xs" OnClick="lbPendingBorrowEmployeeRequest_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lblContactDashBoard" runat="server" Text="<%$ Resources:Resource, ContractDashBoard %>" CssClass="btn btn-primary btn-xs" OnClick="lblContactDashBoard_Click"></asp:LinkButton>
                <asp:Panel runat="server" ID="pnlToDoList">
                            <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div id="divSaleOrder" runat="server" style="width: 50%;" visible="false">
                                        <asp:Label ID="lblSaleOrderHeader" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, PendingSaleOrder %>"></asp:Label>
                                        <asp:GridView ID="gvSaleOrder" runat="server" AllowPaging="false" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvSaleOrder_RowDataBound" ShowFooter="false" ShowHeader="true" Visible="true" Width="530px">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientCode" runat="server" CssClass="cssLableRequired" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, SaleOrder %>" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnSONO" runat="server" CssClass="csslnkButton" OnClick="lbtnSONO_Click" Text='<%# DataBinder.Eval(Container.DataItem, "Code").ToString()%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Status %>" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "Status").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div id="divContract" runat="server" style="width: 50%;" visible="false">
                                        <asp:Label ID="lblContractHeader" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, PendingContract %>"></asp:Label>
                                        <asp:GridView ID="gvContract" runat="server" AllowPaging="false" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvContract_RowDataBound" ShowFooter="false" ShowHeader="true" Visible="true" Width="530px">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientCode" runat="server" CssClass="cssLableRequired" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ContractNumber %>" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnContractNo" runat="server" CssClass="csslnkButton" OnClick="lbtnContractNo_Click" Text='<%# DataBinder.Eval(Container.DataItem, "Code").ToString()%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Status %>" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "Status").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div id="divContractReview" runat="server" style="width: 50%;" visible="false">
                                        <asp:Label ID="Label2" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, ContractReview %>"></asp:Label>
                                        <asp:GridView ID="gvContractReview" runat="server" AllowPaging="false" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvContractReview_RowDataBound" ShowFooter="false" ShowHeader="true" Visible="true" Width="530px">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientCode" runat="server" CssClass="cssLableRequired" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ContractNumber %>" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnContractNo" runat="server" CssClass="csslnkButton" OnClick="lbtnContractReview_Click" Text='<%# DataBinder.Eval(Container.DataItem, "Code").ToString()%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ContractReviewDate %>" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContractExpDt" runat="server" CssClass="cssLable" Text=' <%# String.Format("{0:dd-MMM-yyyy}", Eval("ContReviewDate"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div id="divrptContractExpiry" runat="server" style="width: 50%;" visible="false">
                                        <asp:Label ID="Label1" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, rptContractExpiry %>"></asp:Label>
                                        <asp:GridView ID="gvContractExp" runat="server" AllowPaging="false" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvContractExp_RowDataBound" ShowFooter="false" ShowHeader="true" Visible="true" Width="530px">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientCode" runat="server" CssClass="cssLableRequired" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ContractNumber %>" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnContractNo" runat="server" CssClass="csslnkButton" OnClick="lbtnContractExpNo_Click" Text='<%# DataBinder.Eval(Container.DataItem, "Code").ToString()%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, DateOfExpiry %>" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContractExpDt" runat="server" CssClass="cssLable" Text=' <%# String.Format("{0:dd-MMM-yyyy}", Eval("ContEndDate"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div id="divAsmt" runat="server" style="width: 50%;" visible="false">
                                        <%-- <asp:Label ID="lblAsmtHeader" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLabelHeader" runat="server"></asp:Label>--%>
                                        <asp:GridView ID="gvAsmt" runat="server" AllowPaging="false" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvAsmt_RowDataBound" ShowFooter="false" ShowHeader="true" Visible="true" Width="530px">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientCode" runat="server" CssClass="cssLableRequired" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Assignment %>" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnAsmtNo" runat="server" CssClass="csslnkButton" OnClick="lbtnAsmtNo_Click" Text='<%# DataBinder.Eval(Container.DataItem, "Code").ToString()%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Status %>" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "Status").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div id="divHours" runat="server" style="width: 50%;" visible="false">
                                        <%-- <asp:Label ID="lblScheduleHoursVsContractedHrs" Text="<%$ Resources:Resource, Hours %>" CssClass="cssLabelHeader" runat="server"></asp:Label>--%>
                                        <asp:GridView ID="gvSchHrsVsCont" runat="server" AllowPaging="false" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvSchHrsVsCont_RowDataBound" ShowFooter="false" ShowHeader="true" Visible="true" Width="530px">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSClientCode" runat="server" CssClass="cssLableRequired" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Assignment %>" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblAsmtNo" runat="server" CssClass="csslnkButton" OnClick="lblAsmtNo_Click" Text='<%# DataBinder.Eval(Container.DataItem, "Code").ToString()%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Hours %>" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDiffHrs" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "DiffSCHTOSALES").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Status %>" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSstatus" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "Status").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div id="divRequest" runat="server" style="width: 50%;" visible="false">
                                        <asp:Label ID="lblRequestNo" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, PendingBorrowEmployeeRequest %>"></asp:Label>
                                        <br />
                                        <asp:GridView ID="gvRequestNo" runat="server" AllowPaging="false" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvRequestNo_RowDataBound" ShowFooter="false" ShowHeader="true" Visible="true" Width="530px">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Assignment %>" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblRequestNo" runat="server" CssClass="csslnkButton" OnClick="lblRequestNo_Click" Text='<%# DataBinder.Eval(Container.DataItem, "RequestNo").ToString()%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Status %>" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSstatus" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "RequestStatus").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div id="divContractDashboard" runat="server" visible="false" >
                                        <asp:Label ID="Label3" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, ContractDashBoard %>"></asp:Label>
                                        <br />
                                          <div class="mydiv">
                   <%-- <a href="#" style="color: #444444; font-size: 18px; font-weight: 400; line-height: 32.4px;">Required</a>--%>
                    <table style="width: 100%; margin-left: 15px;" cellpadding="0">
                        <tr>
                            <td><asp:Label ID="Label4" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, NoOfCustomer %>"></asp:Label>
                                <asp:Label ID="lblCustomerNo" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label5" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, NoOfContract %>"></asp:Label>
                                <asp:Label ID="lblContractNo" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label6" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, NoOfSaleOrder %>"></asp:Label>
                                <asp:Label ID="lblSaleOrderNo" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                                         <div class="mydiv">
                   <%-- <a href="#" style="color: #444444; font-size: 18px; font-weight: 400; line-height: 32.4px;">Required</a>--%>
                    <table style="width: 100%; margin-left: 15px;" cellpadding="0">
                        <tr>
                            <td><asp:Label ID="Label7" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, TotalContHours %>"></asp:Label>
                                <asp:Label ID="lblTotalHours" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label8" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, TotalRequiredPersons %>"></asp:Label>
                                <asp:Label ID="lblTotalPerson" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                       
                    </table>
                </div>
                                          <div id="divContractDashboards" runat="server" style="width: 100%;" >
                                        <asp:GridView ID="gvContractDashboard" runat="server" AllowPaging="true" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvContractDashboard_RowDataBound" PageSize="10" ShowFooter="false" ShowHeader="true" Visible="true" Width="70%" OnPageIndexChanging="gvContractDashboard_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle"  />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                           
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSstatus" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>' ></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientName %>" ItemStyle-Width="500px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSstatus" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>' ></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, NoOfContracts %>" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSstatus" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfContracts").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, NoOfSaleOrders %>" ItemStyle-Width="110px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRequestNo" runat="server" CssClass="cssLable"  Text='<%# DataBinder.Eval(Container.DataItem, "NoOfSaleOrders").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="<%$ Resources:Resource, Site %>" ItemStyle-Width="40px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRequestNo" runat="server" CssClass="cssLable"  Text='<%# DataBinder.Eval(Container.DataItem, "SiteDetail").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="<%$ Resources:Resource, ContractedHrs %>" ItemStyle-Width="170px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRequestNo" runat="server" CssClass="cssLable"  Text='<%# DataBinder.Eval(Container.DataItem, "ContractedHrs").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, NoOfPersonsRequired %>" ItemStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRequestNo" runat="server" CssClass="cssLable"  Text='<%# DataBinder.Eval(Container.DataItem, "NoOfPersonsRequired").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                            </Columns>
                                        </asp:GridView>
                                              </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                </asp:Panel>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
    </AjaxToolKit:TabContainer>
     <style>
        .mydiv {
            border-top-color: #444444;
            border-top-width: thick;
            border-top-style: solid;
            box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
            height: 100px;
            margin: 10px;
            width: 30%;
            float: left;

            padding: 4px;Border-radius: 6px;
        }
    </style>
</asp:Content>
