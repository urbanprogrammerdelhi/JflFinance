<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TimeTextBox.ascx.cs" Inherits="UserControls_TimeTextBox" %>
<table>
    <tr>
        <td>
            <asp:TextBox ID="txtTime" MaxLength="5" CssClass="csstxtbox" runat="server" AutoPostBack="True"
                OnTextChanged="txtTime_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblMsg" CssClass="csslblErrMsg" EnableViewState="false" runat="server"
                Text=""></asp:Label>
        </td>
    </tr>
</table>
