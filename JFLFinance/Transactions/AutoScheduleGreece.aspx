<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AutoScheduleGreece.aspx.cs" Inherits="Transactions_AutoScheduleGreece"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 70%;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 670px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label4" Style="text-align: center;" CssClass="squareboxgradientcaption"
                                                runat="server" Text="<%$ Resources:Resource, AutoSchedule %>"> </asp:Label>
                                        </tt>
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="1" cellspacing="1" style="width: 700px">
                                        <%--<tr>
                                            <td align="right" style="height: 27px">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label1" runat="server" Text="<%$ Resources:Resource, SelectPeriod %>"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 27px">
                                                <asp:DropDownList ID="ddlPayPeriod" runat="server" CssClass="cssDropDown" Width="122"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlPayPeriod_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>--%>
                                        <tr>
                                            <td align="right">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblMonth" runat="server"
                                                    Text="<%$ Resources:Resource, MonthYear %>"></asp:Label>
                                            </td>
                                            <td align="left" width="120">
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
                                                <asp:TextBox ID="txtYear" runat="server" CssClass="csstxtboxSmall" Text="" MaxLength="4"
                                                    Width="30" OnTextChanged="txtYear_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox BackColor="LightGray" CssClass="csstxtboxSmall" Text="" ID="txtFromDate"
                                                    runat="server" Enabled="false" AutoPostBack="true" Width="90" ToolTip="Read only"></asp:TextBox>
                                                &nbsp;
                                                <asp:TextBox BackColor="LightGray" CssClass="csstxtboxSmall" Text="" ID="txtToDate"
                                                    runat="server" Enabled="false" AutoPostBack="true" Width="90" ToolTip="Read only"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblMonth_Nextperiod" runat="server"
                                                    Text="<%$ Resources:Resource,NextPeriodMonthYear%>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlMonth_Nextperiod" runat="server" CssClass="cssDropDown"
                                                    Width="80" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_Nextperiod_SelectedIndexChanged">
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
                                                <asp:TextBox ID="txtYear_Nextperiod" runat="server" CssClass="csstxtboxSmall" Text=""
                                                    MaxLength="4" Width="30" OnTextChanged="txtYear_Nextperiod_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox BackColor="LightGray" CssClass="csstxtboxSmall" Text="" ID="txtFromDate_NextPeriod"
                                                    runat="server" Enabled="false" AutoPostBack="true" Width="90" ToolTip="Read only"></asp:TextBox>
                                                &nbsp;
                                                <asp:TextBox BackColor="LightGray" CssClass="csstxtboxSmall" Text="" ID="txtToDate_NextPeriod"
                                                    runat="server" Enabled="false" AutoPostBack="true" Width="90" ToolTip="Read only"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="200" style="height: 27px">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label2" runat="server" Text="<%$ Resources:Resource,SelectClient%>"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left" style="height: 27px">
                                                <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" Width="250"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label3" runat="server" Text="<%$ Resources:Resource,SelectAssignment%>"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:DropDownList ID="ddlAssignment" runat="server" CssClass="cssDropDown" Width="250">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="HFStartDate" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left" height="30">
                                                <asp:Button ID="btnProceed" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Proceed%>"
                                                    OnClick="btnProceed_Click" />
                                                <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                                                    <ProgressTemplate>
                                                        <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;"
                                                            class="modalBackground">
                                                            <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                                                                alt="" src="../Images/spinner.gif" />
                                                        </div>
                                                    </ProgressTemplate>
                                                </Ajax:UpdateProgress>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="3">
                                                <br>
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
