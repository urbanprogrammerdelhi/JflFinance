<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreatePortalUser.aspx.cs" Inherits="UserManagement_CreatePortalUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 98%;">
                <div class="squarebox">
                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" onclick="togglePannelAnimatedStatus(nextSibling,100,50)">
                        <div style="float: left; height: 20;">
                            <asp:Label ID="Label2" Style="text-align: center;" CssClass="squareboxgradientcaption"
                                runat="server" Text="<%$Resources:Resource,PageHdrCreateUser %>"></asp:Label>
                        </div>
                    </div>
                    <div class="squareboxcontent">
                        <table width="100%">
                            <tr>
                                <td style="text-align: right; width: 30%">
                                    <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, UserType %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="ddlUserType" Width="30%" runat="server" AutoPostBack="true"
                                        CssClass="cssDropDown" 
                                        onselectedindexchanged="ddlUserType_SelectedIndexChanged">
                                        <asp:ListItem Text="<%$ Resources:Resource, Employee %>" Value="<%$ Resources:Resource, Employee %>"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="<%$ Resources:Resource, Customer %>" Value="<%$ Resources:Resource, Customer %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, CustomerCode %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="ddlCustomer" Width="30%" runat="server" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label4" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, AccountID %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtAccountID" Width="30%" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAccountId" ValidationGroup="vgSave" ControlToValidate="txtAccountID"
                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label5" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, LoginID %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtloginID" Width="30%" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vgSave"
                                        ControlToValidate="txtloginID" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label6" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, UserName %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtUserName" Width="30%" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgSave"
                                        ControlToValidate="txtUserName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label7" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, EmailID %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtEmail" Width="30%" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="vgSave"
                                        ControlToValidate="txtEmail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label8" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, Password %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtPassword" Width="30%" CssClass="csstxtbox" TextMode="Password"
                                        runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vgSave"
                                        ControlToValidate="txtPassword" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label9" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, ConfirmPassword %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtConfirmPassword" Width="30%" CssClass="csstxtbox" TextMode="Password"
                                        runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="vgSave"
                                        ControlToValidate="txtConfirmPassword" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword"
                                        ControlToCompare="txtPassword" SetFocusOnError="true" Text="<%$ Resources:Resource, PasswordConfirmPasswordShouldMatch %>"
                                        ErrorMessage="*"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label10" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, Active %>"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:CheckBox ID="CBActive" CssClass="cssCheckBox" runat="server" />
                                    <asp:HiddenField ID="HFPortalLoginGuid" runat="server" />
                                    <asp:HiddenField ID="hfPassword" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                    <asp:Button ID="btnSave" ValidationGroup="vgSave" CssClass="cssButton" runat="server" OnClick="btnSave_Click"
                                        Text="<%$ Resources:Resource, Save %>" />
                                         <asp:Button ID="btnUpdate" Visible="false" ValidationGroup="vgSave" CssClass="cssButton" runat="server" OnClick="btnUpdate_Click"
                                        Text="<%$ Resources:Resource, Update %>" />
                                         <asp:Button ID="btnBack" Visible="false" ValidationGroup="vgSave" CssClass="cssButton" runat="server" OnClick="btnBack_Click"
                                        Text="<%$ Resources:Resource, Back %>" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:Panel ID="Panel1" GroupingText="InCharge Details" runat="server" ScrollBars="Auto">
                                        <asp:GridView runat="server" ShowFooter="true" AllowPaging="True" AllowSorting="false"
                                            AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None"
                                            ID="gvInchargeDetails" Width="80%" OnPageIndexChanging="gvInchargeDetails_PageIndexChanging"
                                            OnRowCancelingEdit="gvInchargeDetails_RowCancelingEdit" OnRowCommand="gvInchargeDetails_RowCommand"
                                            OnRowDataBound="gvInchargeDetails_RowDataBound" OnRowDeleting="gvInchargeDetails_RowDeleting"
                                            OnRowEditing="gvInchargeDetails_RowEditing" 
                                            onrowupdating="gvInchargeDetails_RowUpdating" >
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Incharge %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInChargeID" Width="95%" CssClass="cssLabel" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                                        <asp:HiddenField ID="HFCustomerInchargeGuid" runat="server" Value='<%# Eval("CustomerInchargeGuid") %>' />
                                                        <asp:HiddenField ID="HFInChargeNumber" runat="server" Value='<%# Eval("InchargeID") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlInchargeId" Width="95%" CssClass="cssDropDown" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="HFInchargeId" runat="server" Value='<%# Eval("InchargeID") %>' />
                                                        <asp:HiddenField ID="HFCustomerInchargeGuid" runat="server" Value='<%# Eval("CustomerInchargeGuid") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlInchargeId" Width="95%" CssClass="cssDropDown" runat="server">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <FooterStyle Width="40%" />
                                                    <HeaderStyle Width="40%" />
                                                    <ItemStyle Width="40%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, EmailID %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmailId" CssClass="cssLabel" Width="90%" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEmailId" CssClass="csstxtbox" Width="90%" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vgCEdit" ControlToValidate="txtEmailId"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtEmailId" CssClass="csstxtbox" Width="90%" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="vgCFooter" ControlToValidate="txtEmailId"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle Width="25%" />
                                                    <HeaderStyle Width="25%" />
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Phone %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPhoneNumber" CssClass="cssLabel" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPhoneNumber" CssClass="csstxtbox" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvPhoneNumber" ValidationGroup="vgCEdit" ControlToValidate="txtPhoneNumber"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtPhoneNumber" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvPhoneNumber" ValidationGroup="vgCFooter" ControlToValidate="txtPhoneNumber"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle Width="18%" />
                                                    <HeaderStyle Width="18%" />
                                                    <ItemStyle Width="18%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnEdit" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                            ValidationGroup="vgCEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                                            ValidationGroup="vgCEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                            ToolTip="<%$Resources:Resource,Add %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Add %>" ValidationGroup="vgCFooter" CommandName="Add"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="5%" />
                                                    <HeaderStyle Width="5%" />
                                                    <FooterStyle Width="5%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                      
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
