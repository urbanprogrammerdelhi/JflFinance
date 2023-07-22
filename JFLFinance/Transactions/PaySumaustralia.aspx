<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaySumaustralia.aspx.cs" Inherits="Transactions_PaySumaustralia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="2" cellpadding="2" style="background-color: #f3f3f3" width="98%">
                <tr>
                    <td width="120px">
                        <asp:Label ID="lblSelectingBR" Text="Select PaySum Code" runat="server" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlBR" runat="server" Width="310px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPeriod" Text="<%$ Resources:Resource, Period %>" runat="server"
                            CssClass="cssLabel"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label CssClass="cssLable" ID="lblYear" runat="server" Text="<%$ Resources:Resource, Year %>"></asp:Label>
                        <asp:TextBox MaxLength="4" Width="25px" CssClass="csstxtboxSmall" ID="txtYear" runat="server"
                            AutoPostBack="true" OnTextChanged="txtYear_TextChanged">
                        </asp:TextBox>
                        <asp:Label CssClass="cssLable" ID="lblMonth" runat="server" Text="<%$ Resources:Resource, Month %>"></asp:Label>
                        <asp:DropDownList ID="ddlMonth" Width="70px" runat="server" CssClass="cssDropDownSmall"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                            <asp:ListItem Text="<%$ Resources:Resource, January%>" Value="1"></asp:ListItem>
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
                        <asp:Label ID="lblWeekNo" runat="server" Text="<%$ Resources:Resource,Week%>"></asp:Label>
                        <asp:DropDownList ID="ddlWeek" Width="100px" AutoPostBack="true" CssClass="cssDropDownSmall"
                            runat="server" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtFDate" Width="88px" runat="server" AutoPostBack="true" CssClass="csstxtbox"></asp:TextBox>
                        <asp:HyperLink ID="ImgFDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                        <asp:TextBox ID="TxtTDate" Width="88px" runat="server" AutoPostBack="true" CssClass="csstxtbox"></asp:TextBox>
                        <asp:HyperLink ID="ImgTDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnViewPaysum" runat="server" CssClass="cssButton" Text="View" OnClick="btnViewPaysum_Click" />
                        &nbsp;
                        <asp:Button ID="btnGeneratePaysum" runat="server" CssClass="cssButton" Text="Export to csv"
                            OnClick="btnGeneratePaysum_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <table>
                    <tr>
                        <td align="center" colspan="2">
                            <%--<Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        processing......
                                        <img id="imgspin" runat="server" alt="" src="../Images/spinner.gif" />
                                    </ProgressTemplate>
                                </Ajax:UpdateProgress>--%>
                        </td>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <table>
                    <tr>
                        <td>
                            <dx:ASPxGridView ID="PaysumGridView1" runat="server" Width="950px" AutoGenerateColumns="True">
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                                    ShowHorizontalScrollBar="True" />
                                <SettingsPager AlwaysShowPager="True" PageSize="5">
                                </SettingsPager>
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
