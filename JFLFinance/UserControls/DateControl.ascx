<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateControl.ascx.cs" Inherits="UserControls_DateControl" %>
<Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
    <ContentTemplate>
        <table align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left">
                    <asp:TextBox ID="txtDate" Width="110px" CssClass="csstxtbox" runat="server" AutoPostBack="True"
                        OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 180;">
                    <asp:Label ID="lblErrorMsg" CssClass="csslblErrMsg" EnableViewState="false" runat="server"
                        Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</Ajax:UpdatePanel>
