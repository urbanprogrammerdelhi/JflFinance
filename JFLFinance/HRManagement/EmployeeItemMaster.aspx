<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeItemMaster.aspx.cs" Inherits="Masters_EmployeeItemMaster" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="squareboxgradientcaption" style="height: 20px;">
        <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,EmployeeItemMaster %>"></asp:Label>
    </div>
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvEmpItemMst" CssClass="GridViewStyle" runat="server"
                ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                AutoGenerateColumns="False" OnRowDataBound="gvEmpItemMst_RowDataBound" OnRowCommand="gvEmpItemMst_OnRowCommand"
                OnRowDeleting="gvEmpItemMst_OnRowDeleting" OnRowEditing="gvEmpItemMst_OnRowEditing" OnPageIndexChanging="gvEmpItemMst_PageIndexChanging"
                OnRowUpdating="gvEmpItemMst_OnRowUpdating" OnRowCancelingEdit="gvEmpItemMst_OnRowCancelingEdit">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="EditItemMaster" />
                            &nbsp;
                    <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                        ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                        CommandName="Cancel" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="NewItemMaster" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            &nbsp;
                    <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                        CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                CommandName="Edit" />
                            &nbsp;
                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterStyle Width="100px" />
                        <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ItemCode %>">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtItemCode" CssClass="csstxtbox" MaxLength="20" runat="server" Text='<%# Bind("ItemCode") %>'>></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtItemCode" runat="server" ControlToValidate="txtItemCode" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="EditItemMaster"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtItemCode" CssClass="csstxtbox" MaxLength="20" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtItemCode" runat="server" ControlToValidate="txtItemCode" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="NewItemMaster"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblItemCode" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ItemName %>">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtItemName" CssClass="csstxtbox" MaxLength="100" runat="server" Text='<%# Bind("ItemName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtItemName" runat="server" ControlToValidate="txtItemName" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="EditItemMaster"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:HiddenField ID="gfidnew" Value="0" runat="server" />
                            <asp:TextBox ID="txtItemName" CssClass="csstxtbox" MaxLength="100" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtItemName" runat="server" ControlToValidate="txtItemName" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="NewItemMaster"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblItemName" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,Group %>">
                        <EditItemTemplate>
                            <asp:TextBox Width="160px" ID="txtNewGroup" MaxLength="50" CssClass="csstxtbox" runat="server" Text='<%# Bind("ItemGroupName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtNewGroup" runat="server" ControlToValidate="txtNewGroup" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="EditItemMaster"></asp:RequiredFieldValidator>
                            <%--  <asp:DropDownList runat="server" ID="ddlPost" CssClass="cssDropDown" AutoPostBack="true" Style="padding:0px; margin:0; z-index: 1; position: absolute;" Width="182px" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged" />--%>
                            <%--  <asp:DropDownList ID="ddlGroup" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" runat="server" CssClass="cssDropDown"></asp:DropDownList>--%>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="160px" ID="txtNewGroup" MaxLength="50" CssClass="csstxtbox" runat="server" Style="padding: 0px; z-index: 2; position: absolute; border: 0px; margin-top: -10px; margin-left: 3px;"></asp:TextBox>
                            <asp:DropDownList ID="ddlGroup" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" Style="padding: 0px; margin-top: -12px; z-index: 1; position: absolute;" runat="server" CssClass="cssDropDown" Width="180px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvtxtNewGroup" runat="server" ControlToValidate="txtNewGroup" ErrorMessage="*" SetFocusOnError="True" Style="padding: 0px; margin-top: -8px; margin-left: 188px; z-index: 1; position: absolute;" ValidationGroup="NewItemMaster"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGroup" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemGroupName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,SubGroup %>">
                        <EditItemTemplate>
                            <asp:TextBox Width="160px" ID="txtNewSubGroup" MaxLength="50" CssClass="csstxtbox" runat="server" Text='<%# Bind("ItemSubGroupName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtNewSubGroup" runat="server" ControlToValidate="txtNewSubGroup" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="EditItemMaster"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="160px" ID="txtNewSubGroup" MaxLength="50" CssClass="csstxtbox" runat="server" Style="padding: 0px; z-index: 2; position: absolute; border: 0px; margin-top: -10px; margin-left: 3px;"></asp:TextBox>
                            <asp:DropDownList ID="ddlSubGroup" AutoPostBack="true" Width="180px" OnSelectedIndexChanged="ddlSubGroup_SelectedIndexChanged" runat="server" CssClass="cssDropDown" Style="padding: 0px; margin-top: -12px; z-index: 1; position: absolute;"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvtxtNewSubGroup" runat="server" ControlToValidate="txtNewSubGroup" ErrorMessage="*" Style="padding: 0px; margin-top: -8px; margin-left: 188px; z-index: 1; position: absolute;" SetFocusOnError="True" ValidationGroup="NewItemMaster"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubGroup" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemSubGroupName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblErrorMsg" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
