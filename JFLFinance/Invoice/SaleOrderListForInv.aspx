<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SaleOrderListForInv.aspx.cs" Inherits="Sales_SaleOrderListForInv" Title="<%$ Resources:Resource, AppTitle %>" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <div style="width: 950px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left;width:930px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, SaleOrder %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table>
                                                    <tr>
                                                        <td align="right" width="150">
                                                            <asp:Label Width="150px" ID="lblfixClientName" CssClass="cssLabel" runat="server"
                                                                Text="<%$ Resources:Resource, Client %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList AutoPostBack="true" CssClass="cssDropDown" Width="550px" ID="ddlClientCode"
                                                                runat="server" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="940px" Height="350px"
                                                    ScrollBars="Auto" CssClass="ScrollBar">
                                                    <asp:GridView Width="940" ID="gvSaleOrder" CssClass="GridViewStyle" runat="server"
                                                        ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                                                        AutoGenerateColumns="False" OnRowCommand="gvSaleOrder_RowCommand" 
                                                        OnRowDataBound="gvSaleOrder_RowDataBound">
                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnSelect" runat="server" CssClass="cssImgButton" CommandName="Select"
                                                                        ToolTip="<%$ Resources:Resource, Select %>" ImageUrl="../Images/tick.gif" OnClick="ImgbtnSelect_Click" />
                                                                </ItemTemplate>
                                                                <FooterStyle Width="50px" />
                                                                <HeaderStyle Width="50px" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                                <FooterStyle Width="50px" />
                                                                <HeaderStyle Width="50px" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvhdrSaleOrder" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SONo %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvSaleOrder" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SoNo").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle Width="150px" />
                                                                <HeaderStyle Width="150px" />
                                                                <ItemStyle Width="150px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvhdrSOStatus" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SOStatus %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvSOStatus" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOStatus").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle Width="100px" />
                                                                <HeaderStyle Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvhdrSOType" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SOType %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvSOType" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOType").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle Width="100px" />
                                                                <HeaderStyle Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvhdrAsmtBillingID" CssClass="cssLabelHeader" runat="server" Text='<%$ Resources:Resource, AsmtBillingID %>'></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvAsmtBillingID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtBillingID").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle Width="100px" />
                                                                <HeaderStyle Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvhdrAsmtAddress" CssClass="cssLabelHeader" runat="server" Text='<%$ Resources:Resource, Address %>'></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvAsmtAddress" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtAddress").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle Width="350px" />
                                                                <HeaderStyle Width="350px" />
                                                                <ItemStyle Width="350px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                                <br />
                                                <asp:Button ID="btnAddNew" runat="server" CssClass="cssButton" Text="Add New"
                                                    OnClick="btnAddNew_Click" />
                                            </div>
                                        </div>
                                    </div>
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
