<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetWorkOrderList.aspx.cs" Inherits="Sales_AssetWorkOrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="squareboxgradientcaption" style="height: 20px;">
                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,AssetServiceWorkOrder %>"></asp:Label>
            </div>
            <div style="overflow:auto;">
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                        </td>
                        <td colspan="3" align="left">
                            <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                                Width="229px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblfixClientName" CssClass="cssLabel" runat="server"
                                Text="<%$ Resources:Resource, Client %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList AutoPostBack="true" CssClass="cssDropDown" Width="380px" ID="ddlClientCode"
                                runat="server" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImgbtnSearchWO" ToolTip="<%$Resources:Resource,SearchClient %>"
                                ImageUrl="../Images/icosearch.gif" runat="server" />
                        </td>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblAssmtId" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,AsmtId  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAsmtId" Width="400px" CssClass="cssDropDown" runat="server"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:GridView Width="50%" ID="gvWorkOrder" Style="min-width:500px;" CssClass="GridViewStyle" runat="server"
                    ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvWorkOrder_RowDataBound">
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
                                <asp:Label ID="lblgvhdrWorkOrder" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AssetWoNo %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvWorkOrder" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AssetWoNo").ToString()%>'
                                    OnClick="lblgvWorkOrder_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrWoStatus" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, WorkOrderStatus %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvWoStatus" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WoStatus").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
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
                        <asp:TemplateField Visible="false">
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
                <asp:Button ID="btnAddNew" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,AddNew %>" OnClick="btnAddNew_Click" />
            </div>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
