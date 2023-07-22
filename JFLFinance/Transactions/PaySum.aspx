<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaySum.aspx.cs" Inherits="Transactions_PaySum" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 950px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width:930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, PaySum %>"></asp:Label></tt></div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="3" cellspacing="0" style="width: 700px">
                                        <tr>
                                            <td style="width: 100" align="right">
                                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, ClientDetails %>" CssClass="cssLable"></asp:Label>
                                            </td>
                                            <td style="width: 500" align="left">
                                                <asp:DropDownList ID="ddlClientCode" Width="300" runat="server" CssClass="cssDropDown">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 100">
                                                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, StartDate %>" CssClass="cssLable"></asp:Label>
                                            </td>
                                            <td align="left" style="width: 400">
                                                <asp:TextBox ID="txtStartDate" runat="server" Text="" CssClass="csstxtbox"></asp:TextBox>
                                                <asp:HyperLink ID="ImgStartDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtStartDate" PopupButtonID="ImgStartDate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 100">
                                                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, EndDate %>" CssClass="cssLable"></asp:Label>
                                            </td>
                                            <td align="left" style="width: 400">
                                                <asp:TextBox ID="txtEndDate" runat="server" Text="" CssClass="csstxtbox"></asp:TextBox>
                                                <asp:HyperLink ID="ImgEndDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtStartDate" PopupButtonID="ImgEndDate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnGenerate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Generate %>"
                                                    ValidationGroup="vg1" OnClick="btnGenerate_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
