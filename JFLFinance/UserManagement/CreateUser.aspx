<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreateUser.aspx.cs" Inherits="UserManagement_CreateUser" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, MainMenu %>" OnClick="imgBack_Click" />
            <div>
                <table border="0" cellpadding="1" cellspacing="0" style="width: 600px">
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblUserID" runat="server" Text="<%$ Resources:Resource, UserID %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:TextBox CssClass="csstxtbox" ID="txtUserID" MaxLength="20" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtUserID_Validator" runat="server" ControlToValidate="txtUserID"
                                ValidationGroup="vg1"  ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblUserName" runat="server" Text="<%$ Resources:Resource, UserName %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:TextBox CssClass="csstxtbox" ID="txtUserName" MaxLength="50" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtUserName_Validator" runat="server" ControlToValidate="txtUserName"
                                ValidationGroup="vg1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblPassword" runat="server" Text="<%$ Resources:Resource, Password %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:TextBox CssClass="csstxtbox" ID="txtPassword" MaxLength="50" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtPassword_Validator" runat="server" ControlToValidate="txtPassword"
                                ValidationGroup="vg1"  ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblConfirmPassword" runat="server" Text="<%$ Resources:Resource, ConfirmPassword %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:TextBox CssClass="csstxtbox" MaxLength="50" ID="txtConfirmPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtConfirmPassword_Validator" runat="server" ControlToValidate="txtConfirmPassword"
                                ValidationGroup="vg1"  ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="txtConfirmPassword_CompValidator" runat="server" ControlToCompare="txtPassword"
                                ControlToValidate="txtConfirmPassword" ValidationGroup="vg1" ErrorMessage="Confirm Password does not match with Password!">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblUserType" runat="server" Text="<%$ Resources:Resource, UserType %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:DropDownList CssClass="cssDropDown" ID="ddlUserType" runat="server" Width="155px" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblUserGroup" runat="server" Text="<%$ Resources:Resource, UserGroupName %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:DropDownList CssClass="cssDropDown" ID="ddlUserGroup" runat="server" Width="155px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--Code added By  --%>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblEmailID" runat="server" Text="<%$Resources:Resource, EmailID %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:TextBox ID="txtEmailId" CssClass="csstxtbox" runat="server" Width="150px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Email ID"
                                ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblMobileNumber" runat="server" Text="<%$Resources:Resource, MobileNumber %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:TextBox ID="txtMobileNumber" CssClass="csstxtbox" runat="server" Width="150px"
                                MaxLength="20"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobileNumber" ValidationGroup="vg1" Enabled="false" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Mobile No."
                                ControlToValidate="txtMobileNumber" ValidationExpression="\+?\d+"></asp:RegularExpressionValidator>
                           
                          
                        </td>
                    </tr>
                    <%--Code added By  --%>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblIsActive" runat="server" Text="<%$ Resources:Resource, Active %>"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:CheckBox ID="cbIsActive" runat="server" />
                        </td>
                    </tr>
                        <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label1" runat="server" Text="<%$ Resources:Resource, IsEmployee %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="cbIsEmployee" runat="server" AutoPostBack="true" />
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtEmployeeCode" Visible="false" 
                                ontextchanged="txtEmployeeCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:HyperLink ID="hlkSearch" runat="server" ImageUrl="~/Images/search.png" Visible="false" Target="_search"></asp:HyperLink>
                              <asp:RequiredFieldValidator ID="RfvEmployeeCode" runat="server" ControlToValidate="txtEmployeeCode" ValidationGroup="vg1" Enabled="false" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td align="left" colspan="2">
                            <asp:Button ID="btnSave" Style="width: 62px" runat="server" CssClass="fieldText"
                                Text="<%$ Resources:Resource, Apply %>" OnClick="btnSave_Click" ValidationGroup="vg1" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                            <br />
                            <asp:Label ID="lblErrorMsg" CssClass="" runat="server" Style="color: Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
