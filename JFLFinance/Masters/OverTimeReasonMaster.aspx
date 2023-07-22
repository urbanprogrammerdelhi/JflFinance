<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="OverTimeReasonMaster.aspx.cs" Inherits="Masters_OverTimeReasonMaster"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="940px" Height="350px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvOTReasonMaster" Width="920px" CssClass="GridViewStyle" PageSize="12"
                                            runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                            OnRowCancelingEdit="gvOTReasonMaster_RowCancelingEdit" OnRowCommand="gvOTReasonMaster_RowCommand"
                                            OnRowDataBound="gvOTReasonMaster_RowDataBound" OnRowDeleting="gvOTReasonMaster_RowDeleting"
                                            OnRowEditing="gvOTReasonMaster_RowEditing" OnRowUpdating="gvOTReasonMaster_RowUpdating"
                                            ShowFooter="True" OnPageIndexChanging="gvOTReasonMaster_PageIndexChanging">
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
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ReasonCode %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOTReasonCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReasonCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtOTReasonCode" Width="180px" MaxLength="25" CssClass="csstxtbox"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ReasonCode").ToString()%>' runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtOTReasonCode" Width="180px" MaxLength="90" ValidationGroup="vgFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvOTReasonCode" runat="server" ControlToValidate="txtOTReasonCode"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ReasonDesc %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOTReasonDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReasonDesc").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtOTReasonDesc" Width="180px" MaxLength="25" CssClass="csstxtbox"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ReasonDesc").ToString()%>' runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtOTReasonDesc" Width="180px" MaxLength="90" ValidationGroup="vgFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvOTReasonDesc" runat="server" ControlToValidate="txtOTReasonDesc"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<% $Resources:Resource,IsActive %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsActive" CssClass="cssLable" runat="server" Text='<%# Bind("IsActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="cbIsActive" Checked='<%# Bind("IsActive") %>' CssClass="cssCheckBox"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="cbIsActive" CssClass="cssCheckBox" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgEdit" />
                                                        <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                        <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif"
                                                            CssClass="cssImgButton" runat="server" ValidationGroup="vgFooter" CommandName="AddNew" />
                                                        <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif"
                                                            CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField runat="server" ID="hfglobalRole" Value="" />
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
