<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="UserDetail.aspx.cs" Inherits="Masters_UserDetail"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:MultiView ID="MultiViewUserDetail" ActiveViewIndex="0" runat="server">
                <asp:View ID="ViewUserDetail" runat="server">
                    <%--<asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                        ScrollBars="Auto" CssClass="ScrollBar">--%>
                        <table width="100%" border="0">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSearch" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Search %>"></asp:Label>
                                </td>
                                <td align="left" style="width: 180px;">
                                    <asp:DropDownList ID="ddlSearchBy" Width="180px" runat="server" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 150px;">
                                    <asp:TextBox ID="txtSearch" Width="150px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hfSearchText" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnSearchUsers" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnViewAll" Visible="false" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                        OnClick="btnViewAll_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="gvUserDetail" PageSize="15" CellPadding="1" CssClass="GridViewStyle"
                            runat="server" OnRowEditing="gvUserDetail_RowEditing" AutoGenerateColumns="False"
                            OnRowUpdating="gvUserDetail_RowUpdating" OnRowCancelingEdit="gvUserDetail_RowCancelingEdit"
                            OnRowDeleting="gvUserDetail_RowDeleting" OnRowUpdated="gvUserDetail_RowUpdated" OnRowCommand="gvUserDetail_RowCommand"
                            DataKeyNames="UserID" OnRowDataBound="gvUserDetail_RowDataBound" AllowPaging="True"
                            OnPageIndexChanging="gvUserDetail_PageIndexChanging">
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                    ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label CssClass="cssLable" ID="lblSerialNo" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,UserID %>" HeaderStyle-Width="120px"
                                    ItemStyle-Width="120px">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUserID" MaxLength="20" Width="100px" CssClass="csstxtbox" Enabled="false"
                                            ReadOnly="true" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbUserID" CssClass="csslnkButton" runat="server" OnClick="lbUserID_Click"
                                            Text='<%# Bind("UserID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource ,UserName %>" HeaderStyle-Width="200px"
                                    ItemStyle-Width="200px">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUserName" Width="185px" ValidationGroup="Edit" MaxLength="50"
                                            CssClass="csstxtbox" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ValidationGroup="Edit" ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" CssClass="cssLable" runat="server" Text='<%# Bind("UserName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource , Password %>" HeaderStyle-Width="120px"
                                    ItemStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShowPassword" Visible="false" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("Password") %>'></asp:Label>
                                        <asp:LinkButton ID="lbShowPassword" Visible="false" CssClass="csslnkButton" runat="server"
                                            CausesValidation="False" CommandName="ShowPassword" OnClick="lbShowPassword_Click1"
                                            Text="<%$Resources:Resource,ShowPassword %>"></asp:LinkButton>
                                        <asp:LinkButton ID="lbHidePassword" Visible="false" CssClass="csslnkButton" runat="server"
                                            CommandName="HidePassword" OnClick="lbHidePassword_Click" Text="<%$Resources:Resource,HidePassword %>"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lbChangePassword" CssClass="csslnkButton" runat="server" CommandName="ChangePassword"
                                            OnClick="lbChangePassword_Click" Text="<%$Resources:Resource,ChangePassword %>"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource , EmployeeNumber %>" HeaderStyle-Width="120px"
                                    ItemStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShowEmployee" Visible="true" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lbChangeEmployee" CssClass="csslnkButton" runat="server" CommandName="ChangeEmployee"
                                            OnClick="lbChangeEmployee_Click" Text="<%$Resources:Resource,ChangeEmployee %>"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource , UserType %>" HeaderStyle-Width="220px"
                                    ItemStyle-Width="220px">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlUserType" Width="90px" AutoPostBack="true" CssClass="cssDropDown"
                                            runat="server" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlTransferUserID" Width="90px" Visible="false" CssClass="cssDropDown"
                                            runat="server">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblUserTypeDesc" Visible="false" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("IsAdmin") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserType" Visible="false" CssClass="cssLable" runat="server" Text='<%# Bind("IsAdmin") %>'></asp:Label>
                                        <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text='<%# Bind("IsAdminDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource , UserGroupName %>" HeaderStyle-Width="220px"
                                    ItemStyle-Width="220px">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlUserGroupName" Width="90px" AutoPostBack="true" CssClass="cssDropDown"
                                            runat="server" OnSelectedIndexChanged="ddlUserGroupName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblUserGroupDesc" Visible="false" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("UserGroupCode") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserGroupCode" Visible="false" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("UserGroupCode") %>'></asp:Label>
                                        <asp:Label ID="lblUserGroupName" CssClass="cssLable" runat="server" Text='<%# Bind("UserGroupName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource ,IsActive %>" HeaderStyle-Width="100px"
                                    ItemStyle-Width="100px">
                                    <EditItemTemplate>
                                        &nbsp;<asp:DropDownList Width="70px" ID="ddlIsActive" CssClass="cssDropDown" runat="server"
                                            SelectedValue='<%# Eval("IsActive") %>'>
                                            <asp:ListItem Value="True" Text="<%$ Resources:Resource , Yes %>"></asp:ListItem>
                                            <asp:ListItem Value="False" Text="<%$ Resources:Resource , No %>"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbIsActive" Enabled="false" runat="server" Checked='<%# Bind("IsActive") %>' />
                                        <%--<asp:Label ID="Label5" CssClass="cssLable" runat="server" Text='<%# Bind("IsActive") %>'></asp:Label>--%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource , EditColName %>">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ImgbtnUpdateUserDetail" ValidationGroup="Edit" ToolTip="<%$Resources:Resource,Update %>"
                                            ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update" />
                                        <asp:ImageButton ID="ImageButton2UserDetail" ToolTip="<%$Resources:Resource,Cancel %>"
                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                            CommandName="Cancel" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="IBLocationRight" ToolTip="<%$Resources:Resource,UserLocationRights %>" ImageUrl="~/Images/sites/Inspection.png"
                                            CssClass="csslnkButton" runat="server" CommandName="LocationRight" />
                                        <asp:ImageButton ID="IBSiteRight" ToolTip="<%$Resources:Resource,UserSiteRights %>" ImageUrl="~/Images/sites/phone.png"
                                            CssClass="csslnkButton" runat="server" CommandName="SiteRight" />
                                        <asp:ImageButton ID="IBEditUserDetail" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                            CssClass="csslnkButton" runat="server" CommandName="Edit" />
                                        <asp:ImageButton ID="IBDeleteUserDetail" ToolTip="<%$Resources:Resource,Delete %>"
                                            ImageUrl="~/Images/Delete.gif" runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                    </ItemTemplate>
                                    <FooterStyle Width="100px" />
                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    <%--</asp:Panel>--%>
                </asp:View>
            </asp:MultiView>
            <%--  <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Edit" runat="server" />--%>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
            <asp:MultiView ID="MultiViewDeleteUser" runat="server">
                <asp:View ID="ViewDeleteUser" runat="server">
                    <%--<asp:Panel ID="Panel2" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                        ScrollBars="Auto" CssClass="ScrollBar">--%>
                        <asp:GridView ID="gvDeleteUserDetail" Width="950px" runat="server" AutoGenerateColumns="False"
                            OnRowDataBound="gvDeleteUserDetail_RowDataBound" DataKeyNames="UserID">
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                    ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label CssClass="cssLable" ID="lblSerialNo" Width="35px" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="35px" CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,UserID %>" HeaderStyle-Width="120px"
                                    ItemStyle-Width="120px">
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserID" CssClass="cssLabel" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource ,UserName %>" HeaderStyle-Width="200px"
                                    ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource , UserType %>" HeaderStyle-Width="100px"
                                    ItemStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text='<%# Bind("IsAdminDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource ,IsActive %>" HeaderStyle-Width="100px"
                                    ItemStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text='<%# Bind("IsActive") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:Resource,NewUserID %>" HeaderStyle-Width="180px"
                                    ItemStyle-Width="180px">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlUserID" CssClass="cssDropDown" Width="180px" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    <%--</asp:Panel>--%>
                    <asp:Button ID="btnSaveAll" EnableViewState="false" runat="server" CssClass="cssButton"
                        OnClick="btnSaveAll_Click1" Text="<%$Resources: Resource,Save%>" />
                    <asp:Button ID="btnBack" EnableViewState="false" runat="server" CssClass="cssButton"
                        OnClick="btnBack_Click" Text="<%$Resources:Resource,Back %>" />
                </asp:View>
            </asp:MultiView>
            <asp:HiddenField ID="hfUserID" Value="" runat="server" />
            <asp:HiddenField ID="hfUserType" runat="server" Value="" />
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
