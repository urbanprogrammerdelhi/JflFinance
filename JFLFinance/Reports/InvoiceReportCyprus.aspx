<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceReportCyprus.aspx.cs"
    Inherits="Reports_InvoiceReportCyprus" MasterPageFile="~/MasterPage/MasterPage.master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="850px" GroupingText="<%$Resources:Resource,ReportType %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <asp:Panel ID="PanelLocation" Width="700px" BorderWidth="0px" runat="server">
                            <table width="650px" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblHrLocation" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, HrLocation %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblHrLocationCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="ddlHrLocation" runat="server" Width="250px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" EmptyMessage="Please Select" AllowCustomText="true"
                                            OnSelectedIndexChanged="ddlHrLocation_SelectedIndexChanged" AutoPostBack="true">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLocation" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, Location %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLocationCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="ddlLocation" runat="server" Width="250px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" AllowCustomText="true" AutoPostBack="true"
                                            Filter="StartsWith" EmptyMessage="Please Select" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"
                                            CausesValidation="false">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="lblAreaId" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaID %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddlAreaId" runat="server" Width="250px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaId_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblCustomer" runat="server" Text="<%$Resources:Resource,Client %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddlCustomer" runat="server" Width="250px" MaxHeight="350px"
                                            CheckBoxes="true" EnableCheckAllItemsCheckBox="true" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"
                                            Filter="StartsWith" CheckedItemsTexts="DisplayAllInInput" EmptyMessage="Please Select"
                                            AllowCustomText="true" AutoPostBack="true">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label runat="server" ID="SoNo" CssClass="cssLable" Text="<%$ Resources:Resource, SoNo %>"></asp:Label>
                                    </td>
                                    <td align="left" colspan="3">
                                        <asp:DropDownList ID="ddlSoNo" runat="server" Width="180px" CssClass="cssDropDown">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="lblInvoiceType" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, BillingPattern %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlInvoiceType" Width="180px" CssClass="cssDropDown" runat="server"
                                            AutoPostBack="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblMonth" runat="server" Text="<%$ Resources:Resource, Month %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddlMonth" Width="130px" EnableEmbeddedSkins="true" AccessKey="M"
                                            runat="server">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource, January%>" Value="1" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,February%>" Value="2" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,March%>" Value="3" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,April%>" Value="4" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,May%>" Value="5" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,June%>" Value="6" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,July%>" Value="7" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,August%>" Value="8" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,September%>" Value="9" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,October%>" Value="10" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,November%>" Value="11" />
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,December%>" Value="12" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <telerik:RadNumericTextBox ID="txtYear" NumberFormat-AllowRounding="false" NumberFormat-DecimalDigits="0"
                                            NumberFormat-KeepNotRoundedValue="false" NumberFormat-GroupSeparator="" ShowSpinButtons="true"
                                            EmptyMessage="<%$ Resources:Resource, Year %>" MinValue="1950" AutoPostBack="true"
                                            MaxValue="2999" AccessKey="y" runat="server" MaxLength="4" Width="60px">
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="lblVat" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, Vat %>"></asp:Label>
                                    </td>
                                    <td align="left" colspan="3">
                                        <asp:TextBox ID="txtVat" runat="server" Width="120px" MaxLength="6" CssClass="csstxtbox"
                                            Text="0"></asp:TextBox>
                                        <asp:Label ID="lblPercent" runat="server" CssClass="cssLable" Text="%"></asp:Label>
                                        <asp:RegularExpressionValidator ID="regexpVat" runat="server" ErrorMessage="*" ControlToValidate="txtVat"
                                            ValidationGroup="vgFooter" ValidationExpression="^[\d]{1,12}(\.[\d]{1,4})?$" />
                                        <asp:RequiredFieldValidator ID="reqExpVat" runat="server" ErrorMessage="*" ControlToValidate="txtVat"
                                            ValidationGroup="vgFooter" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </telerik:RadAjaxPanel>
                    <br/>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td style="width: 200px">
                                </td>
                                <td align="left" style="width: 500px">
                                    <asp:Button ID="btnViewReport" OnClientClick="javascript:ClearErrorMsg();" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" /> &nbsp;
                                    <asp:Button ID="btnPDFReport" runat="server" Text="<%$Resources:Resource,PDFPrint %>" CssClass="cssButton" OnClick = "btnPDFReport_Click" />
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
            </td>
        </tr>
    </table>
    <telerik:RadCodeBlock ID="d" runat="server">
    <script type="text/javascript">
        function ClearErrorMsg() {
            document.getElementById('<%=lblErrorMsg.ClientID %>').innerText = "";
        } 
    </script>
    
    </telerik:RadCodeBlock>
</asp:Content>
