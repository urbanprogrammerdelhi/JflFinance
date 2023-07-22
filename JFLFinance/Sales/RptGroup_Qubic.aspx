<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RptGroup_Qubic.aspx.cs" Inherits="Sales_RptGroup_Qubic" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="800px" Height="520px" GroupingText="<%$Resources:Resource,Client %>" BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <asp:Panel ID="Panel1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,ReportType %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlReportName" AutoPostBack="true" runat="server" CssClass="cssDropDown" Width="350px" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="300px">
                                </td>
                                <td align="left" width="400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>" CssClass="cssButton" OnClick="btnViewReport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>