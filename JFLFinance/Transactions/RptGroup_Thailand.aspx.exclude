<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="RptGroup_Thailand.aspx.cs"
    Inherits="Transactions_RptGroup_Thailand" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.8.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptMng" runat="server">
    </asp:ScriptManager>
    <table width="80%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="600px" GroupingText="<%$Resources:Resource,Report %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <asp:Panel ID="Panel1" Width="800px" BorderWidth="0px" runat="server">
                            <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,ReportType %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblReportName" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="ddlReportName" runat="server" Width="350px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="false" EmptyMessage="<%$Resources:Resource,Select %>"
                                            AllowCustomText="true" EnableCheckAllItemsCheckBox="false" OnSelectedIndexChanged="DdlReportName_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelAttendanceType" runat="server" Width="100%">
                            <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,AttendanceType %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblAttendaneType" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="ddlAttendaneType" runat="server" Width="350px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="false" EmptyMessage="<%$Resources:Resource,Select %>"
                                            AllowCustomText="true" EnableCheckAllItemsCheckBox="false" OnSelectedIndexChanged="DdlAttendaneType_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelHoursType" runat="server" Width="100%">
                            <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,HoursType %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblHourType" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="ddlHourType" runat="server" Width="350px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true" EnableCheckAllItemsCheckBox="true"
                                            AllowCustomText="true" AutoPostBack="true" Filter="StartsWith" EmptyMessage="<%$Resources:Resource,Select %>"
                                            CausesValidation="false" OnClientDropDownClosing="showDialogInitially">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelDivision" Width="800px" BorderWidth="0px" runat="server">
                            <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Resource, HrLocation %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblHrLocationCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="DdlDivision" runat="server" Width="350px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="false" EmptyMessage="<%$Resources:Resource,Select %>"
                                            AllowCustomText="true" EnableCheckAllItemsCheckBox="false" OnSelectedIndexChanged="DdlDivision_SelectedIndexChanged"
                                            AutoPostBack="true">
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
                                    <td align="left">
                                        <asp:Label ID="lblLocationCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="DdlBranch" runat="server" Width="350px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true" EnableCheckAllItemsCheckBox="true"
                                            AllowCustomText="true" AutoPostBack="false" Filter="StartsWith" EmptyMessage="<%$Resources:Resource,Select %>"
                                            CausesValidation="false">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelMonth" Width="800px" BorderWidth="0px" runat="server">
                            <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="Label20" runat="server" Text="<%$ Resources:Resource, Month %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblMonth" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                                        <telerik:RadComboBox ID="DdlMonth" runat="server" Width="350px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="false" EnableCheckAllItemsCheckBox="false"
                                            AllowCustomText="true" AutoPostBack="true" Filter="StartsWith" EmptyMessage="<%$Resources:Resource,Select %>"
                                            CausesValidation="false" OnSelectedIndexChanged="DdlMonth_SelectedIndexChanged">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource,January%>" Value="1" />
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
                                        <asp:TextBox ID="txtYear" runat="server" Width="50px" CssClass="csstxtbox" AutoPostBack="True"
                                            OnKeyUp="javascript:validateNumeric(this);" OnTextChanged="TxtYear_OnTextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HFStartDate" runat="server" />
                                        <asp:HiddenField ID="HFEndDate" runat="server" />
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
                    </telerik:RadAjaxPanel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="400px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="left">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="BtnViewReport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadWindowManager ID="WindowManagerPop" runat="server" Behaviors="Close"
                    VisibleStatusbar="False" Modal="False">
                    <Windows>
                        <telerik:RadWindow ID="ModalPopup" runat="server" AutoSize="false" ShowContentDuringLoad="false"
                            EnableShadow="true" KeepInScreenBounds="false" Width="350px" Height="350px" Title="<%$ Resources:Resource,Select %>"
                            Modal="true" Skin="WebBlue" Behaviors="Close, Move" OnClientClose="clearFilters">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="LblName" runat="server" Text="<%$Resources:Resource,Name %>" CssClass="cssLabel"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtName" CssClass="csstxtboxRequired" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox Text="" ID="TxtFromDatePop" CssClass="csstxtboxRequired" runat="server"
                                                AutoPostBack="false"></asp:TextBox>
                                            <asp:HyperLink ID="ImgFromDatePop" Style="vertical-align: middle;" runat="server"
                                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="TxtFromDatePop" PopupButtonID="ImgFromDatePop">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox Text="" ID="TxtToDatePop" CssClass="csstxtboxRequired" runat="server"
                                                AutoPostBack="false"></asp:TextBox>
                                            <asp:HyperLink ID="ImgToDatePop" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="TxtToDatePop" PopupButtonID="ImgToDatePop">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="BtnOk" runat="server" CssClass="cssButton" OnClick="BtnOK_Click"
                                                Text="<%$ Resources:Resource,Save %>" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Label ID="lblErrorMsgPop" runat="server" CssClass="csslblErrMsg" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </telerik:RadWindow>
                    </Windows>
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:TextBox ID="TxtAssign" runat="server" TextMode="MultiLine" Text="" CssClass="csstxtboxNobdr"
                    Height="250px" Visible="false" Width="100%"></asp:TextBox>
                <asp:GridView AllowPaging="true" runat="server" ID="GVHoursType" AutoGenerateColumns="true"
                    CssClass="GridViewStyle" CellPadding="1" Visible="false" Width="95%" PageSize="5"
                    ShowFooter="false" ShowHeader="true" HeaderStyle-CssClass="GridViewFixedHeaderStyle">
                    <HeaderStyle CssClass="GridViewFixedHeaderStyle" />
                    <PagerStyle CssClass="GridViewFixedPagerStyle" />
                    <PagerSettings Mode="Numeric" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <Columns>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
    <script language="javascript" type="text/javascript">

        function togglePopupModality() {
            var wnd = window.$find("<%=ModalPopup.ClientID %>");
            wnd.set_modal(!wnd.get_modal());
            if (!wnd.get_modal()) document.documentElement.focus();
        }
        function showDialogInitially(sender, eventArgs) {

            //var ddlReportType = document.getElementById("ddlReportName");
            var ddlReportType = window.$find("<%=ddlReportName.ClientID %>");
            if (ddlReportType.get_selectedItem().get_value() != "UnitReg3mnthComparision") {
                //alert(ddlReportType.get_selectedItem().get_value());
                return;
            }
            if (sender.get_text() == "Select" || sender.get_text() == "") {
                //eventArgs.set_cancel(true);
                return;
            }
            else {

                var wnd = window.$find("<%=ModalPopup.ClientID %>");
                wnd.show();
                window.Sys.Application.remove_load(showDialogInitially);
                eventArgs.set_cancel(false);


            }
        }
        function clearFilters(sender, args) {
            var combo = window.$find("<%= ddlHourType.ClientID %>");
            combo.trackChanges();
            for (var i = 0; i < combo.get_items().get_count(); i++) {
                combo.get_items().getItem(i).set_checked(false);
            }
            combo.commitChanges();
        }


        //                Sys.Application.add_load(showDialogInitially);
    </script>
</body>
</html>
