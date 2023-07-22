<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="OTReasonMapping.aspx.cs" Inherits="Masters_OTReasonMapping" Title="Over Time Reason Mapping" %>

<%@ Register Src="../MS_Control/MultipleSelection.ascx" TagName="MultipleSelection"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td style="width: 1035px">
                <table border="0">
                    <tr>
                        <td align="right" style="width:100px">
                            <asp:Label ID="lblOTReason" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,OTReason %>"></asp:Label>
                        </td>
                        <td style="width: 90px">
                            <uc1:MultipleSelection ID="msddlOTReason" runat="server" />
                        </td>
                        <td style="width: 598px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblLocation" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Location %>"></asp:Label>
                        </td>
                        <td style="width: 90px">
                            <asp:TextBox ID="txtLocation" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                        </td>
                        <td style="width: 598px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblClient" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Client %>"></asp:Label>
                        </td>
                        <td style="width: 90px">
                            <uc1:MultipleSelection ID="msddlClient" runat="server" />
                        </td>
                        <td align="left" style="width: 598px">
                            <asp:Button ID="btnGoClient" runat="server" Width="50px" CssClass="cssButton" OnClick="btnGoClient_Click"
                                Text="<%$Resources:Resource,Go %>" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblAssignment" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Assignment %>"></asp:Label>
                        </td>
                        <td style="width: 90px">
                            <uc1:MultipleSelection ID="msddlAssignment" runat="server" />
                        </td>
                        <td align="left" style="width: 598px">
                            <asp:Button ID="btnAssignment" runat="server" Width="50px" CssClass="cssButton" Text="<%$Resources:Resource,Go %>"
                                OnClick="btnGoAssignment_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblPost" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Post %>"></asp:Label>
                        </td>
                        <td colspan="2">
                            <uc1:MultipleSelection ID="msddlPost" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="center">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Submit %>"
                                OnClick="btnSubmit_Click" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="pnl" BorderWidth="1px" runat="server" Width="940px" Height="350px"
                                ScrollBars="Auto" CssClass="ScrollBar">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="940px" Height="350px"
                                                ScrollBars="Auto" CssClass="ScrollBar">
                                                <asp:GridView ID="gvOTReasonMapping" Width="920px" CssClass="GridViewStyle" PageSize="12"
                                                    runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                                    OnRowDeleting="gvOTReasonMapping_RowDeleting" OnPageIndexChanging="gvOTReasonMapping_PageIndexChanging"
                                                    OnRowDataBound="gvOTReasonMapping_RowDataBound" ShowFooter="False">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                                            FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hfReasonAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ResonAutoID").ToString()%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Branch %>" HeaderStyle-Width="200px"
                                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLocation" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LocationDesc").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Client %>" HeaderStyle-Width="200px"
                                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClient" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'></asp:Label>
                                                                <asp:HiddenField ID="hfClientCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Assignment %>" HeaderStyle-Width="200px"
                                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAssignment" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtAddress").ToString()%>'></asp:Label>
                                                                <asp:HiddenField ID="hfAsmtCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AsmtCode").ToString()%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Post %>" HeaderStyle-Width="200px"
                                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Post").ToString()%>'></asp:Label>
                                                                <asp:HiddenField ID="hfPost" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Post").ToString()%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,OTReason %>" HeaderStyle-Width="200px"
                                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOTReason" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReasonDesc").ToString()%>'></asp:Label>
                                                                <asp:HiddenField ID="hfOTReasonCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ReasonCode").ToString()%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                                                            FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
