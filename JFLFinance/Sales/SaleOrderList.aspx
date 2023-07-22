<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SaleOrderList.aspx.cs" Inherits="Sales_SaleOrderList" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="squareboxgradientcaption" style="height: 20px;">
                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,SaleOrder %>"></asp:Label>
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
                            <asp:ImageButton ID="ImgbtnSearchSONO" ToolTip="<%$Resources:Resource,SearchClient %>"
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
                <asp:GridView Width="100%" ID="gvSaleOrder" Style="min-width: 940px;" CssClass="GridViewStyle" runat="server"
                    ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowCommand="gvSaleOrder_RowCommand" OnRowDataBound="gvSaleOrder_RowDataBound">
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
                                <asp:Label ID="lblgvhdrSaleOrder" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SONo %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvSaleOrder" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SoNo").ToString()%>'
                                    OnClick="lblgvSaleOrder_Click"></asp:LinkButton>
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
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrAssignmentDetails" CssClass="cssLabelHeader" runat="server" Text='<%$ Resources:Resource, AssignmentDetails %>'></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvAssignmentDetails" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AssignmentDetails").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="350px" />
                            <HeaderStyle Width="350px" />
                            <ItemStyle Width="350px" />
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnAddNew" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,AddNew %>" OnClick="btnAddNew_Click" />
            </div>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
