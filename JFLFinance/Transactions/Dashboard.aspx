<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Transactions_Dashboard" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <asp:Panel ID="PanelReportType" Width="700px" Height="420px" GroupingText="KPI Report"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <asp:Panel ID="PanelLocation" Width="700px" BorderWidth="0px" runat="server">
                            <table width="650px" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="lblCompany" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, Company %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblCompanyCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="ddlCompany" runat="server" Width="100%" MaxHeight="100%"
                                            CheckedItemsTexts="DisplayAllInInput" Filter="StartsWith" EmptyMessage="Please Select"
                                            OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" AutoPostBack="true"
                                            CausesValidation="false">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblHrLocation" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, HrLocation %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblHrLocationCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="ddlHrLocation" runat="server" Width="250px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true" EmptyMessage="Please Select"  AllowCustomText="true"
                                            EnableCheckAllItemsCheckBox="true" OnSelectedIndexChanged="ddlHrLocation_SelectedIndexChanged"
                                            AutoPostBack="true" >
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
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" AllowCustomText="true"
                                            AutoPostBack="false" Filter="StartsWith" EmptyMessage="Please Select" CausesValidation="false">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblMonth" runat="server" Text="<%$ Resources:Resource, Month %>"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="ddlMonth" Width="180px" EnableEmbeddedSkins="true" AccessKey="M"
                                            AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                                            OnTextChanged="txtYear_TextChanged" MaxValue="2999" AccessKey="y" runat="server"
                                            MaxLength="4" Width="80px">
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                    </td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rblYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblYear_SelectedIndexChanged">
                                            <asp:ListItem Text="Rolling Year" Value="RY" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Year To Date" Value="YD"></asp:ListItem>
                                            <asp:ListItem Text="Monthwise" Value="MW"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblScreenType" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource, NewScreen %>"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Panel ID="chkScreen" runat="server" Width="100%">
                                            <%--<asp:CheckBox ID="chkDefaultScreen" CssClass="cssCheckBox" runat="server" Text="<%$Resources:Resource, Default %>"
                                                Checked="true" ValidationGroup="chkScreen" CausesValidation="true" AutoPostBack="true"  OnCheckedChanged="chkDefaultScreen_CheckedChanged" />--%>
                                            <asp:CheckBox ID="chkNewScreen" CssClass="cssCheckBox" runat="server" Text="" Checked="true"
                                                ValidationGroup="chkScreen" CausesValidation="true" AutoPostBack="true" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr style="visibility: hidden;">
                                    <td align="right">
                                        <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"
                                            Enabled="false"></asp:TextBox>
                                        <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                        </AjaxToolKit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr style="visibility: hidden;">
                                    <td align="right">
                                        <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"
                                            Enabled="false"></asp:TextBox>
                                        <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                        </AjaxToolKit:CalendarExtender>
                                        <%-- <asp:CompareValidator ID="cvDate" runat="server" ControlToValidate="txtToDate"  ControlToCompare="txtFromDate"
                                       Type="Date" ErrorMessage="Should be Greater then From Date" Operator="GreaterThan"   /> --%>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </telerik:RadAjaxPanel>
                    <asp:Panel ID="PanelButton" Width="700px" BorderWidth="0px" runat="server">
                        <table width="650px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="150px">
                                    <asp:Label ID="lblReportPopUp" EnableViewState="false" runat="server" CssClass="csslblErrMsg"
                                        Visible="false"></asp:Label>
                                </td>
                                <td align="left" width="400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" OnClientClick="SetTarget()" />
                                </td>
                            </tr>
                            <tr>
                                <td width="150px">
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <%----%>
    <script type="text/javascript">

        function SetTarget() {

            if (document.getElementById('<%= chkNewScreen.ClientID %>').checked) {
                document.forms[0].target = "_blank";
            }
            else {
                document.forms[0].target = "";
            }

        }

    </script>
</asp:Content>
