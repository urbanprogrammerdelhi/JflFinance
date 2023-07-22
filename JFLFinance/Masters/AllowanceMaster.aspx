<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AllowanceMaster.aspx.cs" Inherits="Masters_AllowanceMaster" Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="1040px" Height="350px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvAllowanceMaster" Width="1020px" CssClass="GridViewStyle" PageSize="12"
                                            runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                            OnRowCancelingEdit="gvAllowanceMaster_RowCancelingEdit" OnRowCommand="gvAllowanceMaster_RowCommand"
                                            OnRowDataBound="gvAllowanceMaster_RowDataBound" OnRowDeleting="gvAllowanceMaster_RowDeleting"
                                            OnRowEditing="gvAllowanceMaster_RowEditing" OnRowUpdating="gvAllowanceMaster_RowUpdating"
                                            ShowFooter="True" OnPageIndexChanging="gvAllowanceMaster_PageIndexChanging">
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
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,AllowanceDescription %>" HeaderStyle-Width="220px"
                                                    FooterStyle-Width="220px" ItemStyle-Width="220px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllowanceDescription" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AllowanceDescription").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtAllowanceDescription" Width="180px" MaxLength="40" CssClass="csstxtbox"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "AllowanceDescription").ToString()%>'
                                                            runat="server"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexpAllowanceDescription" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtAllowanceDescription"  ValidationGroup="vgEdit" ValidationExpression="^[a-zA-Z0-9]{1,40}" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtAllowanceDescription" Width="180px" MaxLength="40" ValidationGroup="vgFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAllowanceDescription" runat="server" ControlToValidate="txtAllowanceDescription"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
<%--                                                        <asp:RegularExpressionValidator ID="regexpAllowanceDescription" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtAllowanceDescription"  ValidationGroup="vgFooter" ValidationExpression="^[a-zA-Z0-9]{1,40}" />--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Element %>" HeaderStyle-Width="120px"
                                                    FooterStyle-Width="120px" ItemStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblElement" CssClass="cssLable" runat="server" Text='<%# Bind("Element") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtElement" Width="90px" CssClass="csstxtbox" runat="server" Text='<%# Bind("Element") %>'></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexpElement" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtElement" ValidationGroup="vgEdit" ValidationExpression="^[a-zA-Z0-9]{1,20}" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtElement" CssClass="csstxtbox" Width="90px" runat="server" Text=""></asp:TextBox>
<%--                                                        <asp:RegularExpressionValidator ID="regexpElement" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtElement"  ValidationGroup="vgFooter" ValidationExpression="^[a-zA-Z0-9]{1,20}" />--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ElementType %>" HeaderStyle-Width="250px"
                                                    FooterStyle-Width="250px" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblElementType" CssClass="cssLable" runat="server" Text='<%# Bind("ElementTypeDesc") %>'></asp:Label>
                                                        <asp:HiddenField ID="hfAllowanceAutoID" runat="server" Value='<%# Bind("AllowanceAutoID") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" Width="150px" ID="ddlElementType" CssClass="cssdropdown">
                                                            <asp:ListItem Text="Calculated" Value="C"></asp:ListItem>
                                                            <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfElementType" runat="server" Value='<%# Bind("ElementType") %>' />
                                                        <asp:HiddenField ID="hfAllowanceAutoID" runat="server" Value='<%# Bind("AllowanceAutoID") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" Width="150px" ID="ddlElementType" CssClass="cssdropdown">
                                                            <asp:ListItem Text="Calculated" Value="C"></asp:ListItem>
                                                            <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,RateID %>" HeaderStyle-Width="250px"
                                                    FooterStyle-Width="250px" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRateID" CssClass="cssLable" runat="server" Text='<%# Bind("RateID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtRateID" runat="server" Text='<%# Bind("RateID") %>' CssClass="csstxtbox"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexpRateID" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtRateID" ValidationGroup="vgEdit" ValidationExpression="^[a-zA-Z0-9]{1,10}" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtRateID" runat="server" Text='<%# Bind("RateID") %>' CssClass="csstxtbox"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexpRateID" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtRateID"  ValidationGroup="vgFooter" ValidationExpression="^[a-zA-Z0-9]{1,10}" />
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
