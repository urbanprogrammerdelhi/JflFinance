<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterHeader.master" AutoEventWireup="true" CodeFile="SiteMap.aspx.cs" Inherits="UserManagement_SiteMap" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="height:40px" align="right">
            <asp:HyperLink ID="hlMasterMenu" CssClass="csslblPageHeader" NavigateUrl="~/UserManagement/MasterMenu.aspx" runat="server" Text="<%$ Resources:Resource, MainMenu %>"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:SiteMapDataSource id="nav1" runat="server" />
            <asp:TreeView ID="TreeView1" runat="server" DataSourceId="nav1" BackColor="AliceBlue" BorderColor="Maroon" />
        </td>
    </tr>
</table>
</asp:Content>

