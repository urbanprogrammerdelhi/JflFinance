<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecurityServiceConfirmationReport.aspx.cs"
    Inherits="Transactions_SecurityServiceConfirmationReport" MasterPageFile="~/MasterPage/MasterPage.master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="850px" GroupingText="<%$Resources:Resource,ReportType %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true" 
                    Height="300px">
                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="PanelCustomer" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0"> 
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblCustomer" runat="server" Text="<%$Resources:Resource,Client %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlCustomer" runat="server" Width="250px" MaxHeight="350px"
                                                CheckedItemsTexts="DisplayAllInInput" EmptyMessage="Please Select" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelSaleOrderType" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,SaleOrder %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlSoNo" runat="server" Width="250px" MaxHeight="350px"
                                                CheckBoxes="true" EnableCheckAllItemsCheckBox="true" Filter="StartsWith" CheckedItemsTexts="DisplayAllInInput"
                                                EmptyMessage="Please Select" AllowCustomText="true" AutoPostBack="true">
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
                                            </script>
                                            <asp:TextBox ID="txtFromDate" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                                                OnTextChanged="txtFromDate_TextChanged" ></asp:TextBox>
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
                                            <asp:TextBox ID="txtToDate"  runat="server" Text="" CssClass="csstxtbox" AutoPostBack="false"></asp:TextBox>
                                            <asp:HyperLink ID="ImgToDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PnlRemarks" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,ContactPerson %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtContact" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                                                Width="250px" MaxLength="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,ContactNumber %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtContactNumber" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                                                Width="150px" MaxLength="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,Remarks %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRemark" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                                                Width="250px" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                    <asp:Panel ID="PanelButton" Width="808px" BorderWidth="0px" runat="server" 
                        Height="80px">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td style="width: 400px">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnInvoiceprocess" runat="server" CssClass="cssButton" 
                                        OnClick="btnInvoiceprocess_Click" Text="<%$Resources:Resource, InvoiceProcess %>" />
                                </td>
                                <td align="left" style="width: 400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" />
                                </td>
                                <td align="left" style="width: 400px">
                                    &nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="true" runat="server"
                                        CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                   <%-- </ContentTemplate>
                    </Ajax:UpdatePanel>--%>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
