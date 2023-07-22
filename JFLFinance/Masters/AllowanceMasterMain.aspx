<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AllowanceMasterMain.aspx.cs" Inherits="Masters_AllowanceMasterMain"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfspDecimalPlace" runat="server" Value="{0:n2}" />
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
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,AllowanceCode %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllowanceCode" CssClass="cssLable" runat="server" Text='<%# Bind("AllowanceCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblAllowanceCode" CssClass="cssLable" runat="server" Text='<%# Bind("AllowanceCode") %>'></asp:Label>
                                                        <%--<asp:TextBox ID="txtAllowanceCode" Width="90px" CssClass="csstxtbox" runat="server" Text='<%# Bind("AllowanceCode") %>'></asp:TextBox>--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtAllowanceCode" CssClass="csstxtbox" Width="80px" runat="server"
                                                            Text=""></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAllowanceCode" runat="server" ControlToValidate="txtAllowanceCode"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,AllowanceDescription %>" HeaderStyle-Width="120px"
                                                    FooterStyle-Width="120px" ItemStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllowanceDescription" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AllowanceDescription").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtAllowanceDescription" Width="120px" MaxLength="40" CssClass="csstxtbox"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "AllowanceDescription").ToString()%>'
                                                            runat="server"></asp:TextBox>
                                                        <%--  <asp:RegularExpressionValidator ID="regexpAllowanceDescription" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtAllowanceDescription"  ValidationGroup="vgEdit" ValidationExpression="^[a-zA-Z0-9]{1,40}" />--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtAllowanceDescription" Width="120px" MaxLength="40" ValidationGroup="vgFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAllowanceDescription" runat="server" ControlToValidate="txtAllowanceDescription"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ElementCode %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblElement" CssClass="cssLable" runat="server" Text='<%# Bind("Element") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtElement" Width="80px" CssClass="csstxtbox" runat="server" Text='<%# Bind("Element") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvElement" runat="server" ControlToValidate="txtElement"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <%-- <asp:RegularExpressionValidator ID="regexpElement" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtElement" ValidationGroup="vgEdit" ValidationExpression="^[a-zA-Z0-9]{1,20}" />--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtElement" CssClass="csstxtbox" Width="80px" runat="server" Text=""></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvElement" runat="server" ControlToValidate="txtElement"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Type %>" HeaderStyle-Width="90px"
                                                    FooterStyle-Width="90px" ItemStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblElementType" CssClass="cssLable" runat="server" Text='<%# Bind("ElementTypeDesc") %>'></asp:Label>
                                                        <asp:HiddenField ID="hfAllowanceAutoID" runat="server" Value='<%# Bind("AllowanceAutoID") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" Width="90px" ID="ddlElementType" CssClass="cssDropDown">
                                                            <asp:ListItem Text="Calculated" Value="C"></asp:ListItem>
                                                            <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfElementType" runat="server" Value='<%# Bind("ElementType") %>' />
                                                        <asp:HiddenField ID="hfAllowanceAutoID" runat="server" Value='<%# Bind("AllowanceAutoID") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" Width="90px" ID="ddlElementType" CssClass="cssDropDown">
                                                            <asp:ListItem Text="Calculated" Value="C"></asp:ListItem>
                                                            <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Designation %>" HeaderStyle-Width="180px"
                                                    FooterStyle-Width="180px" ItemStyle-Width="180px">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlDesignation" CssClass="cssDropDown" Width="180px" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfDesignation" runat="server" Value='<%# Bind("DesignationCode") %>' />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                                                        <asp:Label ID="lblDesignationCode" Visible="false" runat="server" Text='<%# Bind("DesignationCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlDesignation" CssClass="cssDropDown" Width="180px" runat="server">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,UnitType %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitType" CssClass="cssLable" runat="server" Text='<%# Bind("UnitType") %>'></asp:Label>
                                                        <asp:HiddenField ID="hfUnitType" runat="server" Value='<%# Bind("UnitType") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" Width="80px" ID="ddlUnitType" CssClass="cssDropDown">
                                                            <asp:ListItem Text="Unit" Value="Unit"></asp:ListItem>
                                                            <asp:ListItem Text="Time" Value="Time"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfUnitType" runat="server" Value='<%# Bind("UnitType") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" Width="80px" ID="ddlUnitType" CssClass="cssDropDown">
                                                            <asp:ListItem Text="Unit" Value="Unit"></asp:ListItem>
                                                            <asp:ListItem Text="Time" Value="Time"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Rate %>" HeaderStyle-Width="90px"
                                                    FooterStyle-Width="90px" ItemStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRateID" CssClass="cssLable" runat="server" Text= '<%# String.Format(hfspDecimalPlace.Value,Eval("RateID")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtRateID" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("RateID")) %>' Width="60px"
                                                            CssClass="csstxtbox"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexpRateID" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtRateID" ValidationGroup="vgEdit" ValidationExpression="^^[\d]{1,12}(\.[\d]{1,4})?$" />
                                                        <asp:RequiredFieldValidator ID="rfvRateID" runat="server" ControlToValidate="txtRateID"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtRateID" runat="server" Text='<%# Bind("RateID") %>' Width="60px"
                                                            CssClass="csstxtbox"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexpRateID" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtRateID" ValidationGroup="vgFooter" ValidationExpression="^[\d]{1,12}(\.[\d]{1,4})?$" />
                                                        <asp:RequiredFieldValidator ID="rfvRateID" runat="server" ControlToValidate="txtRateID"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Measurement %>" HeaderStyle-Width="150px"
                                                    FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMeasurement" CssClass="cssLable" runat="server" Text='<%# Bind("Measurement") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtMeasurement" runat="server" Text='<%# Bind("Measurement") %>'
                                                            CssClass="csstxtbox"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="regexpMeasurement" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtMeasurement" ValidationGroup="vgEdit" ValidationExpression="^[a-zA-Z0-9]{1,10}" />--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtMeasurement" runat="server" Text='<%# Bind("Measurement") %>'
                                                            CssClass="csstxtbox"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="regexpMeasurement" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtMeasurement"  ValidationGroup="vgFooter" ValidationExpression="^[a-zA-Z0-9]{1,10}" />--%>
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
