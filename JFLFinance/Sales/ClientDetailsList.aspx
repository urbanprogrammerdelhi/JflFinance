<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ClientDetailsList.aspx.cs" Inherits="Sales_ClientDetailsList"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="right">
                <asp:LinkButton ID="lbtnClientList" Visible="false" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource, ClientList %>" OnClick="lbtnClientList_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbtnClientMaster" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource, ClientMaster %>" OnClick="lbtnClientMaster_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbtnCreateAsmtId" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource, CreateAsmtAddress %>" OnClick="lbtnCreateAsmtId_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                            Width="125px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblhdrClient" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtClientCode" runat="server" CssClass="csstxtbox" AutoPostBack="True" OnTextChanged="txtClientCode_TextChanged"></asp:TextBox>
                        <asp:Image ID="ImgClientCode_CCH" runat="server" ImageUrl="~/Images/icosearch.gif" />
                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="280" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvClientDetails" CssClass="GridViewStyle" runat="server" Width="2900px"
                ShowFooter="false" AllowPaging="true" Visible="true" PageSize="14" CellPadding="1"
                GridLines="None" AutoGenerateColumns="false" OnRowDataBound="gvClientDetails_RowDataBound"
                OnRowDeleting="gvClientDetails_RowDeleting" OnDataBound="gvClientDetails_DataBound"
                OnPageIndexChanging="gvClientDetails_PageIndexChanging" OnRowCommand="gvClientDetails_RowCommand">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Left"/>
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <asp:ImageButton ID="ImgbtnPost" runat="server" CssClass="cssImgButton" ToolTip="<%$ Resources:Resource, Post %>"
                                ImageUrl="../Images/Post.png" OnClick="ImgbtnPost_Click" />
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
                            <asp:HiddenField ID="hfIsBillable" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IsBillable").ToString()%>'/>
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
                            <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
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
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrAsmtId" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AsmtId %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'
                                OnClick="lblgvAsmtId_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrAsmtName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AsmtName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvAsmtName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"AsmtName").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrAsmtAddressType" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AddressType %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvAsmtAddressType" CssClass="cssLable" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrAreaID" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AreaID %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvAreaID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AreaID").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrAsmtAddress" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Address %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvAsmtAddress" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"AsmtAddress").ToString() %>'></asp:Label>
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
                            <asp:Label ID="lblgvhdrPin" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Zip %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvPin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Pin").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
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
                            <asp:Label ID="lblgvhdrFax" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Fax %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvFax" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fax").ToString() %>'></asp:Label>
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
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientContactPerson" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource, ClientContactPerson %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientContactPerson" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientContactPerson").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientContactPersonDesignation" CssClass="cssLabelHeader"
                                runat="server" Text="<%$ Resources:Resource, ClientContactPersonDesignation %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientContactPersonDesignation" CssClass="cssLable" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem,"ClientContactPersonDesignation").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrClientContactPersonMobile" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource, ClientContactPersonMobile %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvClientContactPersonMobile" CssClass="cssLable" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem,"ClientContactPersonMobile").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrPremisesType" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PremisesType %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvPremisesType" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PremisesType").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrComments" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Comment %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvComments" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Comments").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
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
