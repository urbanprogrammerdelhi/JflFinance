<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="temp1.aspx.cs" Inherits="Sales_temp1" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="temp1.aspx.cs" Inherits="Sales_temp1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="ClientDetailsSite" ActiveTabIndex="0" AutoPostBack="true">
            <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelGeocode" runat="server"
                    HeaderText="<%$Resources:Resource,GeoCodeAddress %>" TabIndex="0">
                    <ContentTemplate>        
            <table border="0" width="100%">
                <tr>
                    <td align="right">Address :</td>
                    <td align="left">
                        <asp:TextBox ID="txtAddress" runat="server" Height="96px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                    </td>
                    <td align="right">Formatted Address :</td>
                    <td align="left">
                        <asp:TextBox ID="txtFormattedAddress" BackColor="LightGray" runat="server" Height="96px" ReadOnly="True" TextMode="MultiLine" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnGeocode" CssClass="cssButton" runat="server" Text="Geocode Address" OnClick="btnGeocode_Click" />
                    </td>
                    <td align="right">GPS Location :</td>
                    <td align="left">
                        <asp:TextBox ID="txtLocation" runat="server" BackColor="LightGray" ReadOnly="True" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <uc2:GoogleMapForASPNet runat="server" ID="GoogleMapForASPNet1" />
                    
                
                </ContentTemplate>
                </AjaxToolKit:TabPanel>
                </AjaxToolKit:TabContainer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Content>
    <%--</form>
</body>
</html>--%>
