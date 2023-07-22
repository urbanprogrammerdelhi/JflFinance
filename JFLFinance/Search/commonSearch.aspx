<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commonSearch.aspx.cs" Inherits="Search_commonSearch" Title="<%$ Resources:Resource, AppTitle %>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server" style="border:0px" >
        <table border="0" cellpadding="1">
            <tr>
                <td style="text-align:left">
                    <asp:PlaceHolder runat="server" ID="PHSearch"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Submit %>" OnClick="btnSubmit_Click" />
                </td>
            </tr>
            <tr>
                <td height="5px">
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Panel ID="P1" BorderWidth="0px" runat="server" Width="700" Height="220px" ScrollBars="Auto"  CssClass="ScrollBar">
                    <asp:GridView ID="gvSearchResult" AllowPaging="true" PageSize="15" 
                            CssClass="GridViewStyle" runat="server" ShowHeader="true"
                        Visible="true" CellPadding="3" GridLines="None" AutoGenerateColumns="true" 
                            OnRowDataBound="gvSearchResult_RowDataBound" 
                            onpageindexchanging="gvSearchResult_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                    </asp:GridView>
                    </asp:Panel>
                    <asp:Label ID="lblerr" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="txtObjectName" runat="server" />
        <asp:HiddenField ID="txtOutputFields" runat="server" />
        <asp:HiddenField ID="txtReturnColumn" runat="server" Value="0" />
        <asp:HiddenField ID="txtReturnColumn2" runat="server" Value="0" />
        
        
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../javaScript/gvExtFunctionality.js"></script>
<script language="javascript" type="text/javascript" src="../PageJS/CommonSearch.js"></script>
