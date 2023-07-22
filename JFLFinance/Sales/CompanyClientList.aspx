<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="CompanyClientList.aspx.cs" Inherits="Sales_CompanyClientList"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
    <ContentTemplate>
        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="right">
                    <asp:LinkButton ID="lbMapClient" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource, MapNewClient %>" OnClick="lbMapClient_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lbAddClientToLocation" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource, AddClientToLocation %>" OnClick="lbAddClientToLocation_Click"></asp:LinkButton>
                </td>
            </tr>
            </table>
            <asp:GridView ID="gvClient" CssClass="GridViewStyle" runat="server" Width="3650"
                ShowFooter="true" AllowPaging="true" Visible="true" PageSize="14" CellPadding="1"
                GridLines="None" AutoGenerateColumns="false" OnRowDataBound="gvClient_RowDataBound" OnRowDeleting="gvClient_RowDeleting"
                OnRowCommand="gvClient_RowCommand" OnDataBound="gvClient_DataBound" OnPageIndexChanging="gvClient_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <%--
                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit" ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" OnClick="ImgbtnEdit_Click" />
                            --%>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Width="50px" />
                        <FooterStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>' OnClick="lbgvClientCode_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrMClientCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ManualClientCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvMClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ManualClientCode").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientName").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientAddressLine1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Address %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientAddressLine1" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientAddressLine1").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientAddressLine2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Address %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientAddressLine2" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientAddressLine2").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientAddressLine3" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Address %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientAddressLine3" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientAddressLine3").ToString() %>'></asp:Label>
                        </ItemTemplate>
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
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrState" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, State %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvState" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"State").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrPin" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Zip %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvPin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Pin").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrCountryCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Country %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvCountryCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CountryCode").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                        <HeaderStyle Width="120px" />
                        <FooterStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrPhone" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Phone %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvPhone" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Phone").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrFax" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Fax %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvFax" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fax").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrWebSite" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, WebSite %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvWebSite" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"WebSite").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrEmail" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Email %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvEmail" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Email").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientContactPerson" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientContactPerson %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientContactPerson" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientContactPerson").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                        <HeaderStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientContactPersonDesignation" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientContactPersonDesignation %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientContactPersonDesignation" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientContactPersonDesignation").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientContactPersonMobile" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientContactPersonMobile %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientContactPersonMobile" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientContactPersonMobile").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                        <HeaderStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrOurContactPerson" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, OurContactPerson %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvOurContactPerson" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OurContactPerson").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                        <HeaderStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrOurContactPersonEmpNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, OurContactPersonEmpNo %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvOurContactPersonEmpNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OurContactPersonEmpNo").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                        <HeaderStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrOurContactPersonMobile" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, OurContactPersonMobile %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvOurContactPersonMobile" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OurContactPersonMobile").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                        <HeaderStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrComments" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Comment %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvComments" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Comments").ToString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                        CommandArgument="First" CommandName="Page" />
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                        CommandArgument="Prev" CommandName="Page" />
                    <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                    <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                    <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                        CommandArgument="Next" CommandName="Page" />
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                        CommandArgument="Last" CommandName="Page" />
                </PagerTemplate>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
    </ContentTemplate>
</Ajax:UpdatePanel>
</asp:Content>
