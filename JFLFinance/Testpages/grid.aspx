<%@ Page Language="C#" AutoEventWireup="true" CodeFile="grid.aspx.cs" Inherits="Testpages_grid" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<%--        <table cellpadding="4" width="680" cellspacing="0" border="0" style="background-color: #efefef;
            border: 1px solid #c0c0c0;">--%>
            <%--<tr style="background-color: #6EB6D5;" valign="top">
                <td align="right" style="width: 9%; padding-right: 10px;">
                    <asp:ImageButton ID="closebutton" runat="server" src="../Images/delete.png" OnClick="closebutton_Click"
                        border="0" alt="Close" Style="cursor: hand" />
                </td>
            </tr>--%>
<%--            <tr>
                <td>--%>
                    <dx:ASPxGridView ID="grid" runat="server" Width="100%" AutoGenerateColumns="True">
                        <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                            ShowHorizontalScrollBar="True" />
                        <SettingsBehavior ColumnResizeMode="Control" />
                        <SettingsPager AlwaysShowPager="True" PageSize="10">
                        </SettingsPager>
                    </dx:ASPxGridView>                    
<%--                </td>
            </tr>
            <tr>
                <td>--%>
                    <asp:Button ID="Button1" runat="server" Text="Export to Excel" CssClass="cssButton"
                        OnClick="btn_submit" />
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="grid">
                    </dx:ASPxGridViewExporter>
<%--                </td>
            </tr>
        </table>--%>
    </div>
    </form>
</body>
</html>
