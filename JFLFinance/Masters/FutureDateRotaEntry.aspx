<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="FutureDateRotaEntry.aspx.cs" Inherits="Masters_FutureDateRotaEntry" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                
                
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="text-align: right">
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, MainMenu %>"
                                        OnClick="imgBack_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="PanelFutureDateRotaEntry" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="945px" ID="gvFutureDateRotaEntry" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" 
                                            
                                            OnRowCommand="gvFutureDateRotaEntry_RowCommand"
                                            OnRowDeleting="gvFutureDateRotaEntry_RowDeleting" 
                                            OnRowDataBound="gvFutureDateRotaEntry_RowDataBound" 
                                            OnPageIndexChanging="gvFutureDateRotaEntry_PageIndexChanging">
                                            
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-Width="25px" FooterStyle-Width="25px" ItemStyle-Width="25px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrClientDesc" Width="175px" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, Client%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvItmClientDesc" Width="175px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientDesc").ToString()%>'></asp:Label>
                                                        <asp:HiddenField ID="HFItmClient" Value='<%# Bind("ClientCode") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList Width="175px" ID="ddlClient" CssClass="cssDropDown" runat="server"
                                                            OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlClient" ValidationGroup="vgLFooter" ControlToValidate="ddlClient"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAssignment" Width="380px" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, Assignment%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvItmAssignment" Width="380px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AssignmentDesc").ToString()%>'></asp:Label>
                                                        <asp:HiddenField ID="HFItmAssignment" Value='<%# Bind("AsmtCode") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList Width="380px" ID="ddlAssignment" CssClass="cssDropDown" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlAssignment"  ValidationGroup="vgLFooter" ControlToValidate="ddlAssignment"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAllowed" Width="80px" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, FutureDateRotaEntry%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvItmAllowed" Width="80px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FutureDateRotaEntryDesc").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate >
                                                        <asp:DropDownList Width="80px" ID="ddlAllowed" CssClass="cssDropDown" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlAllowed"  ValidationGroup="vgLFooter" ControlToValidate="ddlAllowed"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                        <asp:LinkButton runat="server" Visible="false" ID="lnkbtnDelete" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                            ValidationGroup="vgLFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:LinkButton runat="server" Visible="false" ID="lnkbtnAdd" CssClass="csslnkButton"
                                                            ValidationGroup="vgLFooter" Text="<%$ Resources:Resource, AddNew %>" CommandName="Add"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                        <asp:LinkButton runat="server" Visible="false" ID="lnkbtnReset" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
