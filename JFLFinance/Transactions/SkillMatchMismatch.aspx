<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SkillMatchMismatch.aspx.cs"
    Inherits="Transactions_SkillMatchMismatch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="Stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hfGridPageCount" runat="server" />
    <asp:HiddenField ID="hfSelectedGridPageCount" runat="server" />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblSearch" runat="server" Text="<%$Resources:Resource,Search %>" CssClass="cssLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="csstxtbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="<%$Resources:Resource,Search %>"
                    OnClick="btnSearch_Click" CssClass="cssButton" />
            </td>
            <td>
                <asp:Button ID="btnViewAll" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                    OnClick="btnViewAll_Click" CssClass="cssButton" />
            </td>
        </tr>
        
    </table>
    <asp:Panel ID="Panel1" runat="server" Width="100%" Height="500px" ScrollBars="Auto"
        CssClass="ScrollBar">
        <asp:GridView ID="gvSkillMatchMismatch" PageSize="20" Width="100%" runat="server"
            AllowPaging="True" AutoGenerateColumns="false" CellPadding="1" CssClass="GridViewStyle"
            OnRowCommand="gvSkillMatchMismatch_RowCommand" OnDataBound="gvSkillMatchMismatch_DataBound"
            OnRowDataBound="gvSkillMatchMismatch_RowDataBound" OnPageIndexChanging="gvSkillMatchMismatch_PageIndexChanging">
            <PagerTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                CommandArgument="First" CommandName="Page" />
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                CommandArgument="Prev" CommandName="Page" />
                            <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                            <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                            <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                CommandArgument="Next" CommandName="Page" />
                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                CommandArgument="Last" CommandName="Page" />
                        </td>
                    </tr>
                </table>
            </PagerTemplate>
        </asp:GridView>
    </asp:Panel>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblMandatory" runat="server" Text="<%$Resources:Resource,Mandatory %>"></asp:Label>
            </td>
            <td>
                <asp:Image ID="imMandatory" runat="server" ImageUrl="~/Images/Mandatory.png" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,Recommended %>"></asp:Label>
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Recommended.png" />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,Informative %>"></asp:Label>
            </td>
            <td>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Informative.png" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
