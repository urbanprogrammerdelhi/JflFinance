<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CostSheetList.aspx.cs" Inherits="Sales_CostSheetList" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center">
                
                
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <div class="container" style="width: 950px;">
                                        <h2>
                                            <tt><a id="A1" href="#" runat="server" onclick="expandSection('Div1')">
                                                <asp:Label ID="lblDivHdr1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, CostSheet %>"></asp:Label></a></tt></h2>
                                        <div id="Div1" class="section" style="overflow: auto; width: 950px; height: 450px">
                                            <table>
                                                <tr>
                                                    <td align="right" width="150">
                                                        <asp:Label Width="150px" ID="lblfixClientName" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:DropDownList AutoPostBack="true" CssClass="cssDropDown" Width="550px" ID="ddlClientCode" runat="server" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="940px" Height="350px" ScrollBars="Auto" CssClass="ScrollBar">
                                                <asp:GridView Width="940" ID="gvCostSheet" CssClass="GridViewStyle" runat="server"
                                                    ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                                                    AutoGenerateColumns="False" OnRowCommand="gvCostSheet_RowCommand" OnRowDataBound="gvCostSheet_RowDataBound">
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
                                                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="50px" />
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrCostSheetNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, CostSheetNo %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCostSheetNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CostSheetNo").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="150px" />
                                                            <HeaderStyle Width="150px" />
                                                            <ItemStyle Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrCostSheetStatus" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Status %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCostSheetStatus" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CostSheetStatus").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <ItemStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrCostSheetDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, CostSheetDate %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCostSheetDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("CostSheetDate")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <ItemStyle Width="100px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="btnAddNew" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,AddNew %>" OnClick="btnAddNew_Click" />
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

