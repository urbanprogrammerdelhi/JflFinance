<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CurrencyMaster.aspx.cs" Inherits="Masters_CurrencyMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up11">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                    <asp:GridView Width="940px" ID="gvCurrency" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="True" AllowPaging="True" PageSize="15" CellPadding="1" GridLines="None"
                                        AutoGenerateColumns="False" AllowSorting="false" OnRowCommand="gvCurrency_RowCommand"
                                        OnRowDataBound="gvCurrency_RowDataBound" OnPageIndexChanging="gvCurrency_PageIndexChanging"
                                        OnRowCancelingEdit="gvCurrency_RowCancelingEdit" OnRowDeleting="gvCurrency_RowDeleting"
                                        OnRowEditing="gvCurrency_RowEditing" OnRowUpdating="gvCurrency_RowUpdating">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                                FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,CurrencyCode %>" HeaderStyle-Width="200px"
                                                FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblCurrencyCode" CssClass="cssLabel" runat="server" Text='<%# Eval("CurrencyCode") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtNewCurrencyCode" CssClass="csstxtbox" Width="85%" MaxLength="16"
                                                        runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewCurrencyCode"
                                                        ErrorMessage="" ValidationGroup="AddNew" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCurrencyCode" CssClass="cssLabel" runat="server" Text='<%# Bind("CurrencyCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,CurrencyDesc %>" HeaderStyle-Width="600px"
                                                FooterStyle-Width="600px" ItemStyle-Width="600px">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtCurrencyDesc" CssClass="csstxtbox" Width="550px" MaxLength="50"
                                                        runat="server" Text='<%# Bind("CurrencyDesc") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCurrencyDesc"
                                                        ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtNewCurrencyDesc" CssClass="csstxtbox" Width="550px" MaxLength="50"
                                                        ValidationGroup="AddNew" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewCurrencyDesc"
                                                        ErrorMessage="" ValidationGroup="AddNew" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text='<%# Bind("CurrencyDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,CurrencySymbol %>">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtCurrencySymbol" CssClass="csstxtbox" runat="server" Text='<%# Eval("CurrencySymbol") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtNewCurrencySymbol" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCurrencySymbol" CssClass="cssLabel" runat="server" Text='<%# Bind("CurrencySymbol") %>'></asp:Label>
                                                </ItemTemplate>
                                                 <HeaderStyle CssClass="cssLabelHeader" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                        CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ImageButton2" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                        CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,AddNew %>"
                                                        CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                        CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                        CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                        CommandName="Edit" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                        runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                </ItemTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 16px">
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
