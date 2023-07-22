<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Sales_UserList" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView Width="70%" ID="gvUserList" Style="min-width: 940px;" CssClass="GridViewStyle" runat="server"
                    ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None" OnRowDataBound="gvUserList_RowDataBound" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvUserList_PageIndexChanging"
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
                                <asp:Label ID="lblgvhdrWorkOrder" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserID %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUserId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserId").ToString()%>'
                                    ></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrWoStatus" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserName %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrAsmtBillingID" CssClass="cssLabelHeader" runat="server" Text='<%$ Resources:Resource, Email %>'></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailId").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrAsmtAddress" CssClass="cssLabelHeader" runat="server" Text='<%$ Resources:Resource, MobileNumber %>'></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblMobile" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
</asp:Content>

