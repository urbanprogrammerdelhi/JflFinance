<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="InvoiceTaxHeads.aspx.cs" Inherits="Invoice_InvoiceTaxHeads" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
    <ContentTemplate>
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px" ScrollBars="Auto" CssClass="ScrollBar">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>

                                    </td>
                                </tr>
                            </table>
                </asp:Panel>
            </td>
        </tr>
        
        <tr>
            <td align="center">
                <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </td>
        </tr>
    </table>
    </ContentTemplate>
</Ajax:UpdatePanel>   
</asp:Content>
