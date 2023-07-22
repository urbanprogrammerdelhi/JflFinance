<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePasswordAdmin.aspx.cs" Inherits="UserManagement_ChangePasswordAdmin"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="squareboxgradientcaption" style="height: 15px;">
                <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,ChangePassword %>"></asp:Label>
            </div>
            <div>
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td align="right">
                            <asp:Label Width="150px" CssClass="cssLable" ID="lblUserID" runat="server" Text="<%$Resources:Resource,UserID %>"></asp:Label>
                        </td>
                        <td style="width: 200px; text-align: left">
                            <asp:TextBox ReadOnly="true" CssClass="csstxtbox" ID="txtUserID" Width="149px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblPassword" runat="server" Text="<%$Resources:Resource,Password %>"></asp:Label>
                        </td>
                        <td style="width: 200px; text-align: left">
                            <asp:TextBox MaxLength="50" CssClass="csstxtbox" ID="txtPassword" runat="server"
                                TextMode="Password" Width="149px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblConfirmPassword" runat="server" Text="<%$Resources:Resource,ConfirmPassword %>"></asp:Label>
                        </td>
                        <td style="width: 200px; text-align: left">
                            <asp:TextBox MaxLength="50" CssClass="csstxtbox" ID="txtConfirmPassword" runat="server"
                                TextMode="Password" Width="149px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 72px">
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnSubmit" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Submit %>"
                                OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnBack" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,back %>"
                                OnClick="btnBack_Click" />
                                <asp:HiddenField ID="HFCompanyCode" runat="server" />
                                <asp:HiddenField ID="HFCountryCode" runat="server" />
                        </td>
                    </tr> 
                </table>
                <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                <br/><asp:Label EnableViewState="false" ID="lblErrorMsg1" runat="server" CssClass="csslblErrMsg"></asp:Label>
                <br/><a href="javascript:OpenPasswordPolicy()">Group Password Policy Help</a>
            </div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <script type="text/javascript" language="javascript">
        function OpenPasswordPolicy() {
            window.open("../Help/GroupPasswordPolicy.html", "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=200, left=200, width=800, height=600");
        }
    </script>
</asp:Content>
