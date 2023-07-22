<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_Operation_kenya.aspx.cs" Inherits="Transactions_RptGroup_Operation_kenya"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Assembly="DropCheck" Namespace="xMilk" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <%--  <Ajax:UpdatePanel ID="Up1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                <asp:Panel ID="PanelReportType" Width="700px" Height="420px" GroupingText="<%$Resources:Resource,Operations %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <asp:Panel ID="Panel1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,ReportType %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlReportName" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelLocation" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource,HrLocation %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label10" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="4">
                                    <%--<uc1:MultipleSelection ID="msddlBranch" runat="server" />--%>
                                    <cc1:DropCheck ID="ddlBranch" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200" TransitionalMode="True"
                                        Width="350px">
                                    </cc1:DropCheck>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelEmployee" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,EmployeeNumber %> "
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <Ajax:UpdatePanel runat="server" ID="UPEmployees" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlEmployeeNumber" runat="server" CssClass="cssDropDown" Width="328">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImgBtnEmployees" runat="server" ToolTip="Refresh Employees"
                                                ImageUrl="~/Images/Reset.gif" OnClick="RefreshEmpList_Click" />
                                        </ContentTemplate>
                                    </Ajax:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelNoOfMonth" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, NoOfMonths %>"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="TxtMonth" Width="50px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelClientCode" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,ClientName %> "
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="cssDropDown" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged" Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAsmtCode" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label8" runat="server" Text="<%$Resources:Resource,Assignment %> "
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlAsmtCode" runat="server" CssClass="cssDropDown" AutoPostBack="false"
                                        Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelStatus" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblStatus" runat="server" Text="<%$ Resources:Resource,Status %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="cssDropDown" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelMetStatus" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblMetStatus" runat="server" Text="<%$ Resources:Resource,Status %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlMetStatus" runat="server" CssClass="cssDropDown" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelTraStatus" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblTraStatus" runat="server" Text="<%$ Resources:Resource,Status %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlTraStatus" runat="server" CssClass="cssDropDown" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelIncidentOption" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblOption" runat="server" Text="<%$ Resources:Resource,Option %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlOption" runat="server" CssClass="cssDropDown" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelDates" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                    <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                    <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="200px">
                                </td>
                                <td align="left" width="400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" />
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
                <%--</ContentTemplate>
                </Ajax:UpdatePanel>--%>
            </td>
        </tr>
    </table>
</asp:Content>
