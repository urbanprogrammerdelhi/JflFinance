<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="UserControls_Search" %>
<table width="900" border="0">
    <tr>
        <td width="200">
            <asp:DropDownList AutoPostBack="true" ID="ddlSearchBy" Width="200px" runat="server"
                CssClass="cssDropDown" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td width="230">
            <asp:TextBox ID="txtSearch" Visible="true" Width="200px" CssClass="csstxtbox" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtSearchDate" Visible="false" Width="200px" CssClass="csstxtbox"
                runat="server"></asp:TextBox>
            <asp:HyperLink ID="imgSearchGrid" Style="vertical-align: middle;" Visible="false"
                runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
            <asp:HiddenField ID="hfSearchText" runat="server" />
        </td>
        <td align="left">
            <asp:Button ID="Button1" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                OnClick="btnSearch_Click" />
        </td>
        <td>
            <asp:Button ID="btnViewAll" Visible="false" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                OnClick="btnViewAll_Click" />
        </td>
    </tr>
</table>
