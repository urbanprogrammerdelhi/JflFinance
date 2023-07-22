<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="VehicleScheduling.aspx.cs" Inherits="Transactions_VehicleScheduling"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="970" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <div style="width: 950px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 930px;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, VehicleScheduling %>"></asp:Label></tt></div>
                        </div>
                        <div class="squareboxcontent">
                            <Ajax:UpdatePanel runat="server" ID="upWeekOffHeader" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label CssClass="cssLable" ID="lblFromDate" runat="server" Text="<%$ Resources:Resource, FromDate  %>"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox Width="80px" ID="txtFromDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: top;" ID="hlFromDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                            </td>
                                            <td>
                                                <asp:Label CssClass="cssLable" ID="lblToDate" runat="server" Text="<%$ Resources:Resource, ToDate  %>"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox Width="80px" ID="txtToDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: top;" ID="hlToDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnProceed" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Proceed %>"
                                                    OnClick="btnProceed_Click" />
                                            </td>
                                           <%-- <td>
                                                <table style="width: 300px; text-align: left">
                                                    <tr>
                                                        <td>
                                                            <img id="ImgBtnSearch" alt="search" src="../Images/icosearch.gif" onclick="javascript:expandSection('divSearchWeekOff')" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div id="divSearchWeekOff" class="container" style="width: 382px; text-align: center;
                                                    display: none; position: absolute;">
                                                    <h2>
                                                        <tt><a id="A2" href="#" runat="server" onclick="expandSection('divSearch')">
                                                            <asp:Label ID="Label1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, search %>"></asp:Label></a></tt></h2>
                                                    <div id="divSearch" class="section" style="overflow: auto; width: 380px; height: 110px;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label CssClass="cssLable" ID="lblEmpNumber" runat="server" Text="<%$ Resources:Resource, EmployeeNumber  %>"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSearchEmpNumberOPR" runat="server" CssClass="cssDropDown"
                                                                        Width="80px">
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlSearchEmpNumberCON" runat="server" CssClass="cssDropDown"
                                                                        Width="100px">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtEmpNumber" runat="server" CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label CssClass="cssLable" ID="lblFirstName" runat="server" Text="<%$ Resources:Resource, FirstName  %>"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSearchFirstNameOPR" runat="server" CssClass="cssDropDown"
                                                                        Width="80px">
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlSearchFirstNameCON" runat="server" CssClass="cssDropDown"
                                                                        Width="100px">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtEmpFirstName" runat="server" CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label CssClass="cssLable" ID="lblLastName" runat="server" Text="<%$ Resources:Resource, LastName  %>"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSearchLastNameOPR" runat="server" CssClass="cssDropDown"
                                                                        Width="80px">
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlSearchLastNameCON" runat="server" CssClass="cssDropDown"
                                                                        Width="100px">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtEmpLastName" runat="server" CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Button ID="btnSearchWeekOff" CssClass="cssSearchButton" runat="server" ToolTip="<%$ Resources:Resource, Search %>"
                                                                        Text="<%$ Resources:Resource, Search %>" OnClick="btnSearchWeekOff_Click" />
                                                                    <asp:Button ID="btnReset" CssClass="cssButton" runat="server" ToolTip="<%$ Resources:Resource, Reset %>"
                                                                        Text="<%$ Resources:Resource, Reset %>" OnClick="btnReset_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </Ajax:UpdatePanel>
                            <Ajax:UpdatePanel runat="server" ID="upgvVehicle" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="gvVehicle" Width="950px" CssClass="GridViewStyle" runat="server"
                                        AllowPaging="true" PageSize="15" CellPadding="0" CellSpacing="0" GridLines="None"
                                        AutoGenerateColumns="false" ShowFooter="false" OnRowCommand="gvVehicle_RowCommand"
                                        OnRowDataBound="gvVehicle_RowDataBound" OnPageIndexChanging="gvVehicle_PageIndexChanging"
                                        OnDataBound="gvVehicle_DataBound" EmptyDataText="fadFSDF">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                        </Columns>
                                        <PagerTemplate>
                                            <table>
                                                <tr>
                                                    <td>
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
                                                        <%--<asp:Label ID="lblWarning" CssClass="cssLabel" BorderColor="DarkRed" runat="server" Text="Save your Changes Before Moving to next page"></asp:Label>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </PagerTemplate>
                                    </asp:GridView>
                                    <asp:Button ID="btnAdd" CssClass="cssSaveButton" runat="server" ToolTip="<%$ Resources:Resource, Save %>"
                                        Text="<%$ Resources:Resource, Save %>" OnClick="btnAdd_Click" />
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <Ajax:AsyncPostBackTrigger ControlID="btnProceed" EventName="Click" />
                                    <Ajax:AsyncPostBackTrigger ControlID="btnSearchWeekOff" EventName="Click" />
                                </Triggers>
                            </Ajax:UpdatePanel>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
