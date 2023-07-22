<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Client.aspx.cs" Inherits="Masters_Client"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                
                
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvClient" CssClass="GridViewStyle" runat="server" Width="1700"
                                            ShowFooter="true" AllowPaging="true" Visible="true" PageSize="15" CellPadding="1"
                                            GridLines="None" AutoGenerateColumns="false" OnRowDataBound="gvClient_RowDataBound">
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
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10px" />
                                                    <HeaderStyle Width="10px" />
                                                    <FooterStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrClientCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnHyperLink" runat="server" CssClass="cssImgButton" CommandName="ImgbtnHyperLink"
                                                            ToolTip="<%$ Resources:Resource, ViewDetails %>" ImageUrl="../Images/plus.gif"
                                                            OnClick="ImgbtnHyperLink_Click" />
                                                        <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="90px" />
                                                    <HeaderStyle Width="90px" />
                                                    <FooterStyle Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrClientName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClientName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientName").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="200px" />
                                                    <FooterStyle Width="200px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrClientAddress" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Address %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClientAddress" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"AddressLine1").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="250px" />
                                                    <HeaderStyle Width="250px" />
                                                    <FooterStyle Width="250px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrCity" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, City %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvCity" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"City").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="120px" />
                                                    <HeaderStyle Width="120px" />
                                                    <FooterStyle Width="120px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrState" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, State %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvState" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"State").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="120px" />
                                                    <HeaderStyle Width="120px" />
                                                    <FooterStyle Width="120px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrCountry" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Country %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvCountry" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CountryCode").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="120px" />
                                                    <HeaderStyle Width="120px" />
                                                    <FooterStyle Width="120px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrZip" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Zip %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvZip" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Pin").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="70px" />
                                                    <HeaderStyle Width="70px" />
                                                    <FooterStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrPhone" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Phone %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPhone" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Phone").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="100px" />
                                                    <HeaderStyle Width="100px" />
                                                    <FooterStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrEmail" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Email %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEmail" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Email").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="150px" />
                                                    <HeaderStyle Width="150px" />
                                                    <FooterStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrContactPerson" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ContactPerson %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvContactPerson" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Email").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="150px" />
                                                    <HeaderStyle Width="150px" />
                                                    <FooterStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrComment" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Comment %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvComment" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Comments").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        &nbsp;<asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" OnClientClick="return confirm('<%$ Resources:Resource , MsgConfirmDelete %>');"
                                                            ImageUrl="../Images/Delete.gif" OnClick="ImgbtnDelete_Click" />
                                                        &nbsp;<asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" OnClick="ImgbtnEdit_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                    <HeaderStyle Width="80px" />
                                                    <FooterStyle Width="80px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:LinkButton ID="AddNewClient" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, AddNew %>"
                                            OnClick="AddNewClient_Click"></asp:LinkButton>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
