<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeUserAreaIncharge.aspx.cs"
    Inherits="UserManagement_ChangeUserAreaIncharge" MasterPageFile="~/MasterPage/MasterPage.master" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0px" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 950px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,ChangeAreaIncharge %>"></asp:Label></tt></div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0px" cellpadding="3" cellspacing="0">
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
                                                <asp:Label CssClass="cssLable" ID="lblPassword" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                            </td>
                                            <td style="width: 200px; text-align: left">
                                                <asp:TextBox MaxLength="50" CssClass="csstxtbox" ID="txtEmployeeNumber" runat="server"
                                                     Width="149px"></asp:TextBox>
                                                    <asp:HyperLink ID="hlkSearch" runat="server" ImageUrl="~/Images/search.png" Visible="true" Target="_search"></asp:HyperLink>
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
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </div>
                            </div>
                            
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
