<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ToMerhavCSV.aspx.cs"
    Inherits="Transactions_ToMerhavCSV" MasterPageFile="~/MasterPage/MasterPage.master"
    Title="To Merhav O/P" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="PanelAreaID" Width="60%" BorderWidth="0px" runat="server">
        <table width="100%">
            <tr>
                <td align="right" style="width: 30%">
                    <asp:Label ID="lblHrLocation" runat="server" CssClass="cssLabel" Width="100px" Text="<%$ Resources:Resource,HrLocation %>"></asp:Label>
                </td>
                <td align="left" style="width: 50%">
                    <asp:DropDownList ID="ddlHrLocation" runat="server" CssClass="cssDropDown" Width="160px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 30%">
                    <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Width="100px" Text="<%$ Resources:Resource,Location %>"></asp:Label>
                </td>
                <td align="left" style="width: 50%">
                    <asp:DropDownList ID="ddlLocation" runat="server" CssClass="cssDropDown" Width="160px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 30%">
                    <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Width="100px" Text="<%$ Resources:Resource,FromDate %>"></asp:Label>
                </td>
                <td align="left" style="width: 50%">
                    <asp:TextBox ID="txtFromDate" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                        OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                    <asp:HyperLink ID="ImgFromDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                    </AjaxToolKit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 30%">
                    <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Width="100px" Text="<%$ Resources:Resource,ToDate %>"></asp:Label>
                </td>
                <td align="left" style="width: 50%">
                    <asp:TextBox ID="txtToDate" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                        OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                    <asp:HyperLink ID="ImgToDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                    </AjaxToolKit:CalendarExtender>
                </td>
            </tr>
            <tr align="center">
                <td align="center" colspan="2">
                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="cssLabel"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnClick" runat="server" CssClass="cssButtonControl" Width="100px"
                        Text="<%$ Resources:Resource,Proceed %>" OnClick="btnClick_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
