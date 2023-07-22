<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroupThailand.aspx.cs" Inherits="Transactions_RptGroupThailand" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="850px" GroupingText="<%$Resources:Resource,ReportType %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="PanelReportTypeMain" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="LabReportTypeMain" runat="server" Text="<%$Resources:Resource,ReportType %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlReportTypeMain" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlReportTypeMain_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel1" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,ReportName %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlReportName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged">
                                            </telerik:RadComboBox>
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
                                            <asp:TextBox ID="txtFromDate" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                                                OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                            <asp:HyperLink ID="ImgFromDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtToDate" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                                                OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                            <asp:HyperLink ID="ImgToDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                
                                <td colspan=2" align="center" style="height:40px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="height:40px">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
