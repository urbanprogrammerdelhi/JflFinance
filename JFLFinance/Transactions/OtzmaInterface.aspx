<%@ Page Title="" Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage/MasterPage.master"  CodeFile="OtzmaInterface.aspx.cs" Inherits="Transactions_OtzmaInterface" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
                                <td align="center">
                                                 
                                        <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" CssClass="cssButton"
                                            Text="<%$ Resources:Resource, Proceed %>" />
                                    </td>
                                </tr>

                                <tr>
                                <td align="center">
                                
                                 <asp:Label  runat="server" ID="lblMessage" Visible=false Font-Bold=true ></asp:Label>
                                </td>
                                
                                </tr>
                                </table>


</asp:Content>

