<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptInvoicePng.aspx.cs" Inherits="Transactions_RptInvoicePng" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table1" width="100%" border="0" cellpadding="3" cellspacing="0" runat="server">
        <tr>
            <td align="left">
                <div id="Div1" runat="server" style="width: 100%;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 100%;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label5" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,Invoice %>"></asp:Label></tt></div>
                        </div>
                        <div id="Div2" class="squareboxcontent" style="text-align: left; width: 100%" runat="server">
                            <table id="Table2" border="0" cellpadding="1" cellspacing="0" style="width: 100%"
                                runat="server">
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 180px">
                                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                        <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                        </AjaxToolKit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 180px">
                                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                        <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                        </AjaxToolKit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,SOType %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 180px">
                                        <asp:DropDownList cssClass="cssDropDown" ID="ddlSoType" runat= "server" AutoPostBack="false" ></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnProceed" runat="server" Text="<%$Resources:Resource,Proceed %>"
                                            CssClass="cssButton" OnClick="btnProceed_Click" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="cssButton" OnClick="btnExport_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
                                            <Triggers>
                                                <Ajax:PostBackTrigger ControlID="btnExport" />
                                                <asp:PostBackTrigger ControlID="btnExport"></asp:PostBackTrigger>
                                                <asp:PostBackTrigger ControlID="btnExport"></asp:PostBackTrigger>
                                                <asp:PostBackTrigger ControlID="btnExport"></asp:PostBackTrigger>
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:Panel ID="panel1" runat="server" GroupingText="" Width="940px">
                                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                    <asp:GridView ID="gvInvoice" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                                                        CellPadding="0" CssClass="GridViewStyle" GridLines="Both" ShowFooter="false"
                                                        ShowHeader="true" Visible="true" Width="960px" >
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <PagerStyle CssClass="GridViewFixedPagerStyle" />
                                                        <Columns>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </Ajax:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
