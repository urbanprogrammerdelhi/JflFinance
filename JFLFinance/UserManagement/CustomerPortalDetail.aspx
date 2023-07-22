<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CustomerPortalDetail.aspx.cs" Inherits="UserManagement_CustomerPortalDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 98%;">
        <div class="squarebox">
            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" onclick="togglePannelAnimatedStatus(nextSibling,100,50)">
                <div style="float: left; height: 20;">
                    <asp:Label ID="Label2" Style="text-align: center;" CssClass="squareboxgradientcaption"
                        runat="server" Text="<%$Resources:Resource,UserDetail %>"></asp:Label>
                </div>
            </div>
            <div class="squareboxcontent">
                <asp:GridView runat="server" ShowFooter="true" AllowPaging="True" AllowSorting="false"
                    AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None"
                    ID="gvUserDetails" Width="80%">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,CustomerEmployee %>">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbCustomerName" CssClass="csslnkButton" OnClick="lbCustomerName_Click" runat="server" Text='<%# Eval("CustomerName") %>'></asp:LinkButton>
                                <asp:HiddenField ID="hfCustomerCode" runat="server" Value='<%# Eval("CustomerCode") %>' />
                                <asp:HiddenField ID="hfportalLoginGuid" runat="server" Value='<%# Eval("PortalLoginGuid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,AccountID %>">
                            <ItemTemplate>
                                <asp:Label ID="lblAccountID" CssClass="cssLabel" runat="server" Text='<%# Eval("AccountID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,LoginID %>">
                            <ItemTemplate>
                                <asp:Label ID="lblLoginID" CssClass="cssLabel" runat="server" Text='<%# Eval("LoginID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,UserName %>">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" CssClass="cssLabel" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,EmailID %>">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" CssClass="cssLabel" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,Active %>">
                            <ItemTemplate>
                                <asp:Label ID="lblActive" CssClass="cssLabel" runat="server" Text='<%# Eval("Active") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
