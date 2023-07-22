<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentHistory.aspx.cs" Inherits="Sales_PaymentHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
          <table border="0" width="100%">
                    <tr>
                        <td align="right" style="width: 150px">
                            <asp:Label ID="lblStatus" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, PaymentMode %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 250px">
                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="cssDropDown" Width="180px">
                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                <asp:ListItem Text="CASH" Value="CASH"></asp:ListItem>
                                <asp:ListItem Text="LIVE" Value="LIVE"></asp:ListItem>
                                <asp:ListItem Text="PAYZAPP" Value="PAYZAPP"></asp:ListItem>
                                </asp:DropDownList>
                        </td>
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
                       <%-- <td align="right" style="width: 150px">
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
                        </td>--%>
                         <td align="center"  style="width: 400px">
                            <asp:Button ID="btnSearch" runat="server" Text="<%$Resources:Resource,Search %>"
                                CssClass="cssButton" OnClick="btnSearch_Click" />
                            <%--<asp:Button ID="btnViewAll" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                CssClass="cssButton" OnClick="btnViewAll_Click" />--%>
                        </td>
                         <td align="center"  style="width: 400px">
                            <asp:Button ID="btnViewAll" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                CssClass="cssButton" OnClick="btnViewAll_Click" />
                            <%--<asp:Button ID="btnViewAll" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                CssClass="cssButton" OnClick="btnViewAll_Click" />--%>
                        </td>
                    </tr>
                    
                </table>
    <br />
        <asp:GridView Width="70%" ID="gvPayment" Style="min-width: 940px;" CssClass="GridViewStyle" runat="server"
                    ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None" OnRowDataBound="gvPayment_RowDataBound" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvPayment_PageIndexChanging"
                    AutoGenerateColumns="False" >
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrWorkOrder" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, OrderNo %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUserId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkOrderNo").ToString()%>'
                                    ></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrWoStatus" CssClass="cssLabelHeader" runat="server" Text="Payment Status"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentStatus").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrAsmtBillingID" CssClass="cssLabelHeader" runat="server" Text="Payment Date"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentDate").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrAsmtPID" CssClass="cssLabelHeader" runat="server" Text="Payment ID"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentId").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                          <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrAsmtAddressAmount" CssClass="cssLabelHeader" runat="server" Text='Amount'></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Amount").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                          <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrAsmtAddressMode" CssClass="cssLabelHeader" runat="server" Text='Payment Mode'></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblMode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Mode").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                          <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrTransactionID" CssClass="cssLabelHeader" runat="server" Text='Transaction ID'></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTransactionID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TransactionID").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
</asp:Content>

