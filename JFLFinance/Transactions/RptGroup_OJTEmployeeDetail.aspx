<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_OJTEmployeeDetail.aspx.cs" Inherits="RptGroup_OJTEmployeeDetail" Title="<%$ Resources:Resource, AppTitle %>" %>
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
                            <asp:Panel ID="PanelDivision" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Resource, HrLocation %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlDivision" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelBranch" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Resource, Branch %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlBranch" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAreaIncharge" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblAreaIncharge" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaIncharge %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlAreaInchargeCode" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaInchargeCode_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAreaID" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label2" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, Area %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlAreaId" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaId_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelEmployee" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, Employee %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlEmployeeNumber" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelScheduleType" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label15" runat="server" Text="<%$ Resources:Resource, ScheduleType %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlScheduleType" runat="server" Width="150px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,Actual %>" Value="Actual" Selected="true" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,Scheduled %>" Value="Scheduled" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelBillable" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Resource, Paid%>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlBillable" runat="server" Width="150px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource, All %>" Value="All" Selected="true" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource, Paid %>" Value="1" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource, NotPaid %>" Value="0" />
                                                </Items>
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
                                            <asp:Label ID="lblObjectFrom" runat="server" CssClass="cssLabel"></asp:Label>
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
                                            <asp:Label ID="lblObjectTo" runat="server" CssClass="cssLabel"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td style="width: 400px">
                                </td>
                                <td align="left" style="width: 400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" OnClientClick="disableButton(this);" />
                                        <asp:Label ID="lblWait" runat="server" CssClass="csslblErrMsg" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <telerik:RadGrid ID="RadGrid1" Skin="Office2007" runat="server">
                        <ExportSettings ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
                            <Pdf PageBottomMargin="" PageFooterMargin="" PageHeaderMargin="" PageHeight="11in"
                                PageLeftMargin="" PageRightMargin="" PageTopMargin="" PageWidth="8.5in" />
                            <Excel FileExtension="xls" Format="Html" />
                            <Csv FileExtension="csv" />
                        </ExportSettings>
                    </telerik:RadGrid>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function disableButton(obj) {
            obj.style.display = "none";
            document.getElementById('<%= lblWait.ClientID %>').innerText = "Please wait.....";
        }
    </script>
</asp:Content>
