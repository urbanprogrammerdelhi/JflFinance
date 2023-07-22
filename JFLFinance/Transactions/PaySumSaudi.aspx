<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaySumSaudi.aspx.cs" Inherits="Transactions_PaySumSaudi" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" GroupingText="<%$ Resources:Resource, PaySum %>" Width="600px"
                            runat="server">
                            <table border="0" cellpadding="3" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="width: 100" align="right">
                                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, ClientDetails %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 500" align="left">
                                        <asp:DropDownList ID="ddlClientCode" Width="300" runat="server" CssClass="cssDropDown">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblMonth" runat="server"
                                            Text="<%$ Resources:Resource, MonthYear %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" Width="80"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                                        <asp:TextBox ID="txtYear" OnTextChanged="txtYear_OnTextChanged" runat="server" AutoPostBack="true"   CssClass="csstxtboxSmall" Text="" MaxLength="4"
                                            Width="30"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100">
                                        <asp:Label ID="Label3" runat="server" Enabled="false" Text="<%$ Resources:Resource, StartDate %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 400">
                                        <asp:TextBox ID="txtStartDate" Enabled="false" OnTextChanged="txtStartDate_TextChanged" AutoPostBack="true"
                                            runat="server" Text="" CssClass="csstxtbox"></asp:TextBox>
                                       <%-- <asp:HyperLink ID="ImgStartDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtStartDate" PopupButtonID="ImgStartDate" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100">
                                        <asp:Label ID="Label4" Enabled="false"   runat="server" Text="<%$ Resources:Resource, EndDate %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 400">
                                        <asp:TextBox ID="txtEndDate" Enabled="false" OnTextChanged="txtEndDate_TextChanged" AutoPostBack="true"
                                            runat="server" Text="" CssClass="csstxtbox"></asp:TextBox>
                                       <%-- <asp:HyperLink ID="ImgEndDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtEndDate" PopupButtonID="ImgEndDate" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnGenerate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Generate %>"
                                            ValidationGroup="vg1" OnClick="btnGenerate_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%--</div>
                            </div>
                            
                        </div>--%>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
