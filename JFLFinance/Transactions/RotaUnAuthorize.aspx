<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RotaUnAuthorize.aspx.cs" Inherits="Transactions_RotaUnAuthorize" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 700px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 670px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label5" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, RotaUnAuthorize %>"></asp:Label></tt></div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="1" cellspacing="1" style="width: 700px">
                                       <%-- <tr>
                                            <td align="right" style="height: 27px">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label2" runat="server" Text="<%$ Resources:Resource, SelectPeriod %>"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 27px">
                                                <asp:DropDownList ID="ddlPayPeriod" runat="server" CssClass="cssDropDown" Width="122">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="right">
                                                <asp:Label CssClass="cssLable" ID="Label1" runat="server" Text="<%$ Resources:Resource, MonthYear %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown">
                                                    <asp:ListItem Text="<%$ Resources:Resource,January%>" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,February%>" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,March%>" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,April%>" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,May%>" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,June%>" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,July%>" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,August%>" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,September%>" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,October%>" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,November%>" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,December%>" Value="12"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox CssClass="csstxtbox" ID="txtYear" runat="server" Width="30" MaxLength="4"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="txtYear_val" runat="server" ControlToValidate="txtYear"
                                                    ValidationGroup="vg1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnUnAuthorize" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, UnAuthorize %>"
                                                    ValidationGroup="vg1" OnClick="btnUnAuthorize_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
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
