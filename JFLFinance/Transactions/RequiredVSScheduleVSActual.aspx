<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RequiredVSScheduleVSActual.aspx.cs" Inherits="Transactions_RequiredVSScheduleVSActual"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div1" style="overflow: auto; width: 99%; height: 450px; border-color: Black;
        border: 1px; border-style: solid">
        <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="2" style="width: 100%">
                    <tr>
                        <td align="left" style="width: 60px">
                            <asp:Label CssClass="cssLable" Visible="false" ID="lblFromDate" runat="server" Text="<%$ Resources:Resource, FromDate %>"></asp:Label>
                            <asp:Label CssClass="cssLable" ID="lblYear" runat="server" Text="<%$ Resources:Resource, Year %>"></asp:Label>
                            <asp:TextBox MaxLength="4" Width="25px" CssClass="csstxtboxSmall" ID="txtYear" runat="server"
                                AutoPostBack="true" OnTextChanged="txtYear_TextChanged">
                            </asp:TextBox>
                        </td>
                        <td align="left" style="width: 120px">
                            &nbsp;
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
                            <asp:TextBox Visible="false" CssClass="csstxtboxSmall" ID="txtFromDate" runat="server"
                                Width="80"></asp:TextBox>
                            <asp:HyperLink Visible="false" ID="ImgFromDate" Style="vertical-align: middle;" runat="server"
                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="ceFromDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtFromDate" PopupButtonID="ImgFromDate" />
                        </td>
                        <td align="right" style="width: 60px">
                            <asp:Label Visible="false" CssClass="cssLable" ID="lblToDate" runat="server" Text="<%$ Resources:Resource, ToDate %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 120px">
                            <asp:Label ID="lblWeekNo" runat="server" Text="<%$ Resources:Resource,Week%>"></asp:Label>
                            <asp:DropDownList ID="ddlWeek" Width="100px" AutoPostBack="true" CssClass="cssDropDownSmall"
                                OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                            <asp:TextBox Visible="false" CssClass="csstxtboxSmall" ID="txtToDate" runat="server"
                                Width="80"></asp:TextBox>
                            <asp:HyperLink Visible="false" ID="ImgToDate" Style="vertical-align: middle;" runat="server"
                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="ceToDate" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtToDate"
                                PopupButtonID="ImgToDate" />
                        </td>
                        <td colspan="3" align="right">
                            <asp:Literal ID="ltrUnderPost" runat="server" Text="<%$ Resources:Resource, UnderPost %>"></asp:Literal>
                            <img alt="Under Post" style="width: 10px; height: 10px; background-color: Yellow"
                                src='../Images/spacer.gif'></img>
                            <asp:Literal ID="ltrOverPost" runat="server" Text="<%$ Resources:Resource, OverPost %>"></asp:Literal>
                            <img alt="Over Post" style="width: 10px; height: 10px; background-color: Red" src='../Images/spacer.gif'></img>
                            <asp:Literal ID="ltrFulfilled" runat="server" Text="<%$ Resources:Resource, FulFilled %>"></asp:Literal>
                            <img alt="Fulfilled" style="width: 10px; height: 10px; background-color: Green" src='../Images/spacer.gif'></img>
                            <asp:Literal ID="ltrBlank" runat="server" Text="<%$ Resources:Resource, Blank %>"></asp:Literal>
                            <img alt="Blank" style="width: 10px; height: 10px; background-color: Gray" src='../Images/spacer.gif'></img>
                            <asp:Literal ID="ltrNotRequired" runat="server" Text="<%$ Resources:Resource, NotRequired %>"></asp:Literal>
                            <img alt="Not Required" style="width: 10px; height: 10px; background-color: Blue"
                                src='../Images/spacer.gif'></img>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblArea" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Area %>"></asp:Label>
                            <asp:DropDownList ID="ddlArea" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged"
                                runat="server" CssClass="cssDropDownSmall">
                            </asp:DropDownList>
                        </td>
                        <td align="left" colspan="2">
                            <asp:Label CssClass="cssLable" ID="lblClient" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlClientCode" runat="server">
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImgbtnSearchSONO" ToolTip="<%$Resources:Resource,SearchClient %>"
                                ImageUrl="../Images/icosearch.gif" runat="server" />
                            <%--<img id="imgSearchClient" alt="search" src="../Images/icosearch.gif" onclick="javascript:window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=' + <%=ddlClientCode.ClientID.ToString() %>  + '&Company=' + <%=BaseCompanyCode.ToString()%>  + '&HrLocation=&Location=' + <%=BaseLocationCode.ToString()%> +'''+ ',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')"/>
                                            <img id="img1" alt="search" src="../Images/icosearch.gif" onclick="javascript:window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=ctl00_ContentPlaceHolder1_ddlClientCode&Company=AMSSKW&HrLocation=&Location=AMSSBRN',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')"/>--%>
                            <%--<asp:TextBox ID="txtClientCode" CssClass="csstxtboxSmall" MaxLength="16" Width="80" runat="server"></asp:TextBox>--%>
                        </td>
                        <td align="left" colspan="2">
                            <asp:Label CssClass="cssLable" ID="Label1" runat="server" Text="<%$ Resources:Resource, Select %>"></asp:Label>
                            <asp:DropDownList CssClass="cssDropDown" Width="150px" ID="ddlSelect" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnProceed" runat="server" CssClass="cssButton" Text=" <%$ Resources:Resource, Proceed%>"
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
                    </tr>
                </table>
            </ContentTemplate>
        </Ajax:UpdatePanel>
        <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView Width="100%" ID="gvReqSchAct" CssClass="GridViewStyle" runat="server"
                    ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="21"
                    CellPadding="0" GridLines="None" AutoGenerateColumns="false" OnRowDataBound="gvReqSchAct_RowDataBound"
                    OnRowCommand="gvReqSchAct_RowCommand" OnPageIndexChanging="gvReqSchAct_PageIndexChanging"
                    OnDataBound="gvReqSchAct_DataBound">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                    </Columns>
                    <PagerTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                            CommandArgument="First" CommandName="Page" />
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                            CommandArgument="Prev" CommandName="Page" />
                        <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                        <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                        <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                            CommandArgument="Next" CommandName="Page" />
                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                            CommandArgument="Last" CommandName="Page" />
                    </PagerTemplate>
                </asp:GridView>
                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <Ajax:AsyncPostBackTrigger ControlID="btnProceed" EventName="Click" />
            </Triggers>
        </Ajax:UpdatePanel>
        <asp:Label runat="server" ID="lblerr"></asp:Label>
    </div>
    <script type="text/javascript" language="javascript">
        var Page;
        var postBackElement;
        function pageLoad() {
            Page = Sys.WebForms.PageRequestManager.getInstance();
            Page.add_beginRequest(OnBeginRequest);
            Page.add_endRequest(endRequest);
        }

        function OnBeginRequest(sender, args) {
            postBackElement = args.get_postBackElement();
            postBackElement.disabled = true;
        }

        function endRequest(sender, args) {
            postBackElement.disabled = false;

        }      
   
    </script>
</asp:Content>
