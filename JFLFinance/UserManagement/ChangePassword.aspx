<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="UserManagement_ChangePassword" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="height: 15px;"">
                        <asp:Label ID="lblDivHdr1" runat="server" Text="<%$ Resources:Resource, ChangePassword %>"></asp:Label>
            </div>
            <div>
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td height="20">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblOldPassword" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, OldPassword %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOldPassword" CssClass="csstxtbox" runat="server" Text="" TextMode="Password"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="txtOldPasswordValidator" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="txtOldPassword" ValidationGroup="vg_Apply">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblNewPassword" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, NewPassWord %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewPassword" CssClass="csstxtbox" runat="server" Text="" TextMode="Password"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="txtNewPasswordValidator" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="txtNewPassword" ValidationGroup="vg_Apply">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblConfirmPassword" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, ConfirmPassword %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" CssClass="csstxtbox" runat="server" Text=""
                                TextMode="Password"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="txtConfirmPasswordValidator" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="txtConfirmPassword" ValidationGroup="vg_Apply">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="txtConfirmPasswordCompareValidator" runat="server" ControlToCompare="txtNewPassword"
                                ControlToValidate="txtConfirmPassword" ErrorMessage="New Password and Confirm Password are not same"
                                ValidationGroup="vg_Apply">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnApply" CssClass="cssButton" runat="server"
                                Text="<%$ Resources:Resource, Apply %>" OnClick="btnApply_Click" ValidationGroup="vg_Apply" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="lblErrorMsg" CssClass="" runat="server" Style="color: Red" Text=""></asp:Label>
                            <a href="javascript:OpenPasswordPolicy()">Group Password Policy Help</a>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <script type="text/javascript" language="javascript">
        function OpenPasswordPolicy() {
            window.open("../Help/GroupPasswordPolicy.html", "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=200, left=200, width=800, height=600");
        }
    </script>
</asp:Content>
