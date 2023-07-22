<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="WorkOrderList.aspx.cs" Inherits="Sales_WorkOrderList"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelWorkOrderMaster" Font-Bold="True" ForeColor="Red" Height="400px" runat="server">

                <table border="0" width="100%">
                    <tr>
                        <td align="right" style="width: 150px">
                            <asp:Label ID="lblStatus" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, OrderStatus %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 250px">
                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="cssDropDown" Width="180px">
                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                <asp:ListItem Text="NEW" Value="NEW"></asp:ListItem>
                                <asp:ListItem Text="SCHEDULED" Value="SCHEDULED"></asp:ListItem>
                                <asp:ListItem Text="CANCELLED" Value="CANCELLED"></asp:ListItem>
                                <asp:ListItem Text="ONTHEWAY" Value="ONTHEWAY"></asp:ListItem>
                                <asp:ListItem Text="BREAKDOWN" Value="BREAKDOWN"></asp:ListItem>
                                <asp:ListItem Text="REJECT" Value="REJECT"></asp:ListItem>
                                <asp:ListItem Text="INPROGRESS" Value="INPROGRESS"></asp:ListItem>
                                <asp:ListItem Text="ONHOLD" Value="ONHOLD"></asp:ListItem>
                                <asp:ListItem Text="DONE" Value="DONE"></asp:ListItem>
                                <asp:ListItem Text="CLOSE" Value="CLOSE"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 150px">
                            <asp:Label ID="lblFromDate" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, FromDate %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 250px">

                            <asp:TextBox ID="txtFromDate" CssClass="csstxtbox" runat="server" Style="width: 100px"></asp:TextBox>
                            <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtFromDate" PopupButtonID="ImgFromDate"></AjaxToolKit:CalendarExtender>
                        </td>
                        <td align="right" style="width: 150px">
                            <asp:Label ID="lblToDate" runat="server" CssClass="cssLabel"
                                Text="<%$ Resources:Resource, ToDate %>"></asp:Label>
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="csstxtbox" Style="width: 100px"></asp:TextBox>
                            <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtToDate" PopupButtonID="ImgToDate"></AjaxToolKit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <asp:Label ID="lblHdrOrderNo" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, OrderNo %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 250px">
                            <asp:TextBox ID="txtWorkOrderNo" MaxLength="25" CssClass="csstxtbox" runat="server" Style="width: 100px"></asp:TextBox>
                            <AjaxToolKit:AutoCompleteExtender ServiceMethod="SearchPlumbingWorkOrder" MinimumPrefixLength="2" CompletionInterval="100"
                                EnableCaching="false" CompletionSetCount="10" TargetControlID="txtWorkOrderNo"
                                ID="AceWoNo" runat="server" FirstRowSelected="true">
                            </AjaxToolKit:AutoCompleteExtender>
                        </td>
                        <td align="right" style="width: 150px">
                            <asp:Label ID="lblHdrClientCode" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 250px">
                            <asp:TextBox ID="txtClientUserId" MaxLength="25" CssClass="csstxtbox" runat="server" Style="width: 100px"></asp:TextBox>
                            <AjaxToolKit:AutoCompleteExtender ServiceMethod="SearchClientUserId" MinimumPrefixLength="2" CompletionInterval="100"
                                EnableCaching="false" CompletionSetCount="10" TargetControlID="txtClientUserId"
                                ID="AceClientUserId" runat="server" FirstRowSelected="true">
                            </AjaxToolKit:AutoCompleteExtender>
                        </td>
                        <td align="center" colspan="2" style="width: 400px">
                            <asp:Button ID="btnSearch" runat="server" Text="<%$Resources:Resource,Search %>"
                                CssClass="cssButton" OnClick="btnSearch_Click" />
                            <%--<asp:Button ID="btnViewAll" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                CssClass="cssButton" OnClick="btnViewAll_Click" />--%>
                        </td>
                    </tr>

                </table>
                <asp:Label ID="lblError" runat="server" CssClass="csslblErrMsg"></asp:Label>
                <br />
                <asp:GridView Width="1500px" ID="gvWorkOrderMaster" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnPageIndexChanging="gvWorkOrderMaster_PageIndexChanging" OnRowDataBound="gvWorkOrderMaster_RowDataBound">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblaction" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDeployment" runat="server" Height="16px"
                                    ImageUrl="~/Images/employee-scheduling-enable.png" ToolTip="<%$ Resources:Resource, Deployment %>"
                                    Width="16px" OnClick="ImgBtnDeployment_Click" />
                                <asp:ImageButton ID="imgbtnEdit" runat="server" CssClass="cssImgButton"
                                    ImageUrl="../Images/Edit.gif" ToolTip="<%$ Resources:Resource, Edit %>" OnClick="imgbtnEdit_Click"/>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,OrderNo %>">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfWorkOrderAutoId" runat="server" Value='<%# Bind("WorkOrderAutoId") %>' />
                                <asp:Label ID="lblOrderNo" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("workorderno") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,OrderDate %>">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("ModifiedDate")) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,OrderStatus %>">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderStatus" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="<%$ Resources:Resource,PreferredDate %>">
                            <ItemTemplate>
                                <asp:Label ID="lblfromdate" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("preferredfromdate")) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,PreferredTimeSlot %>">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" Width="120px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("preferredfromtime") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="120px" />
                            <ItemStyle Width="120px" />
                            <FooterStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Service %>">
                            <ItemTemplate>
                                <asp:Label ID="lblService" Width="300px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("servicecategoryname") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>">
                            <ItemTemplate>
                                <asp:Label ID="lblUserId" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("UserID") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientName %>">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Address %>">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" Width="300px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("OrderAddress") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <%-- <asp:Button ID="btnAddNew" runat="server" Text="Add New" Style="margin-left: 500px;" CssClass="cssButton" OnClick="btnAddNew_Click" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
