<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleRosterEmpWise.aspx.cs"
    Inherits="Transactions_ScheduleRosterEmpWise" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.8.1.min.js"></script>
    <%--<script language="javascript" type="text/javascript" src="../javaScript/jquery-1.11.3.min.js"></script>--%>
    <script language="javascript" type="text/javascript" src="../PageJS/SchGlobalVar.js"></script>
    <script language="javascript" type="text/javascript" src="../PageJS/SchBodyLoad.js"></script>
    <script language="javascript" type="text/javascript" src="../PageJS/SchRightClickFunctions.js"></script>
    <script language="javascript" type="text/javascript" src="../PageJS/SchEmployeeFunctions.js"></script>
    <script language="javascript" type="text/javascript" src="../PageJS/Scheduler.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body onload="javascript:OnLoad();" onclick="javascript:HideDivs();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="script" runat="server" EnablePageMethods="true">
            <Services>
                <asp:ServiceReference Path="../WebServices/WebMethods.asmx" />
            </Services>
        </asp:ScriptManager>
        <Ajax:UpdatePanel ID="UP1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="width: 100%; border-collapse: collapse; border-spacing: 0;">
                    <tr>
                        <td style="text-align: right">
                            <asp:Label CssClass="cssLable" ID="Label15" runat="server" Text="<%$Resources:Resource,AttendanceType %>"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <telerik:RadComboBox ID="ddlAttendanceType" AccessKey="T" Width="100px" runat="server"
                                EnableEmbeddedSkins="true" ForeColor="Red" Font-Bold="true" OnClientSelectedIndexChanged="AttendanceOnClientSelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Schedule %>" Value="Sch" />
                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Actual %>" Value="Act" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td></td>
                        <td style="text-align: right">
                            <asp:Label CssClass="cssLable" ID="Label14" runat="server" Text="<%$Resources:Resource,ScheduleType %>"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <telerik:RadComboBox ID="ddlScheduleType" AccessKey="S" ForeColor="Red"
                                EnableEmbeddedSkins="true" AutoPostBack="false" Width="100px" runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Weekly %>" Value="Weekly" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td></td>
                        <td>
                            <telerik:RadComboBox ID="ddlPostSearch" AllowCustomText="true" Filter="Contains"
                                EnableEmbeddedSkins="true" EmptyMessage="<%$ Resources:Resource, SearchPost %>"
                                LoadingMessage="<%$ Resources:Resource, Loading %>" IsCaseSensitive="false" OnClientKeyPressing="ddlPostSearchOnClientKeyPressing"
                                OnClientDropDownOpening="ddlPostSearchOnClientKeyPressing" OnClientSelectedIndexChanged="ddlPostSearchClientSelectedIndexChanged"
                                MarkFirstMatch="true" NoWrap="true" Width="230px" runat="server">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label CssClass="cssLable" ID="lblMonth" runat="server" Text="<%$ Resources:Resource, Month %>"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ddlMonth" Width="100px" EmptyMessage="<%$ Resources:Resource, NoDataToShow %>"
                                EnableEmbeddedSkins="true" AccessKey="M" runat="server" OnClientSelectedIndexChanged="MonthOnClientSelectedIndexChanged">
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
                        </td>
                        <td style="text-align: left">
                            <telerik:RadNumericTextBox ID="txtYear" NumberFormat-AllowRounding="false" NumberFormat-DecimalDigits="0"
                                AutoPostBack="false" NumberFormat-KeepNotRoundedValue="false" NumberFormat-GroupSeparator=""
                                ShowSpinButtons="true" EmptyMessage="<%$ Resources:Resource, Year %>" MinValue="1950"
                                MaxValue="2999" AccessKey="y" runat="server" MaxLength="4" Width="80px">
                                <ClientEvents OnValueChanged="MonthOnClientSelectedIndexChanged" OnKeyPress="DisableEnterKey" />
                            </telerik:RadNumericTextBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblWeekNo" runat="server" Text="<%$ Resources:Resource,Week%>"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ddlWeek" AllowCustomText="false" AccessKey="W" CloseDropDownOnBlur="true"
                                EnableEmbeddedSkins="true" EmptyMessage="<%$ Resources:Resource, NoDataToShow %>"
                                Width="260px" runat="server" OnClientDropDownClosed="MonthOnClientSelectedIndexChanged"
                                OnClientDropDownOpening="WeekOnClientDropDownOpening">
                            </telerik:RadComboBox>
                            <asp:HiddenField ID="hfEmployeeSearchFinishStatus" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblArea" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Area %>"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ddlArea" AllowCustomText="false" AccessKey="W" CloseDropDownOnBlur="true"
                                OnClientDropDownOpening="AreaOnClientDropDownOpening" OnClientDropDownClosed="AreaOnClientSelectedIndexChanged"
                                Width="230px" runat="server">
                            </telerik:RadComboBox>
                            <asp:HiddenField ID="HFFromDate" runat="server" />
                            <asp:HiddenField ID="HFToDate" runat="server" />
                            <asp:HiddenField ID="HFMultilingualFromDate" runat="server" />
                            <asp:HiddenField ID="HFMultilingualToDate" runat="server" />
                            <asp:HiddenField runat="server" ID="HFMaxDate" />
                        </td>
                    </tr>
                    <tr style="vertical-align: top;">
                        <td style="text-align: right">
                            <asp:Label CssClass="cssLable" ID="lblClientCode" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                        </td>
                        <td colspan="2" style="width: 260px; text-align: left;">
                            <telerik:RadComboBox ID="ddlClient" AllowCustomText="true" AccessKey="C" CloseDropDownOnBlur="true"
                                EnableEmbeddedSkins="true" Filter="Contains" EmptyMessage="<%$ Resources:Resource, NoDataToShow %>"
                                IsCaseSensitive="false" MarkFirstMatch="true" Width="260px" runat="server" OnClientDropDownOpening="ClientDropDownOpening"
                                OnClientDropDownClosed="ClientDropDownClosed" OnClientSelectedIndexChanged="ClientSelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label CssClass="cssLable" ID="Label1" runat="server" Text="<%$ Resources:Resource, Assignment %>"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <telerik:RadComboBox ID="ddAssignment" AllowCustomText="true" AccessKey="A" Filter="Contains"
                                EnableEmbeddedSkins="true" EmptyMessage="<%$ Resources:Resource, NoDataToShow %>"
                                IsCaseSensitive="false" MarkFirstMatch="true" Width="260px" runat="server" OnClientDropDownOpening="AssignmentDropDownOpening"
                                OnClientDropDownClosed="AssignmentOnClientDropDownClosed" OnClientSelectedIndexChanged="AssignmentOnClientSelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label CssClass="cssLable" ID="Label2" runat="server" Text="<%$ Resources:Resource, Post %>"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ddlPost" AllowCustomText="true" Filter="Contains" AccessKey="P"
                                EnableEmbeddedSkins="true" EmptyMessage="<%$ Resources:Resource, NoDataToShow %>"
                                IsCaseSensitive="false" MarkFirstMatch="true" Width="230px" runat="server" OnClientDropDownOpening="PostDropDownOpening"
                                OnClientDropDownClosed="PostOnClientSelectedIndexChanged"
                                OnSelectedIndexChanged="ddlPost_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hfGridPageCount" runat="server" />
                <asp:HiddenField ID="hfSelectedGridPageCount" runat="server" />
                <asp:HiddenField ID="hfSelectedGridPageCountFinal" runat="server" />
                <asp:HiddenField ID="HFCurrentSessionID" runat="server" />
                <asp:HiddenField ID="HFDutyMinCheck" runat="server" />
                <asp:HiddenField ID="HFOTReason" runat="server" />
                <asp:HiddenField ID="HidCon" runat="server" />
                <asp:HiddenField ID="hfParentAsmtID" runat="server" />
                <asp:HiddenField ID="hfParentClientCode" runat="server" />
                <asp:HiddenField ID="hfParentPostCode" runat="server" />
                <asp:HiddenField ID="hfParentDate" runat="server" Value="" />
                <asp:HiddenField runat="server" ID="HFEmployeeSearch" />
                <asp:HiddenField ID="MouseClickColumnID" runat="server" />
                <asp:HiddenField ID="MouseClickRowID" runat="server" />
                <asp:HiddenField ID="HFPagingIndex" runat="server" />
                <asp:HiddenField ID="HFColumnIndex" runat="server" />
                <asp:HiddenField ID="HFRowIndex" runat="server" />
                <asp:HiddenField ID="HFEditColumnIndex" runat="server" />
                <asp:HiddenField ID="HFSolineStartDate" runat="server" />
                <asp:HiddenField ID="HFSolineEndDate" runat="server" />
                <asp:HiddenField ID="HFActualDutyReplacement" runat="server" />
                <asp:HiddenField ID="hfEmployeeSearchDutyDate" runat="server" />
                <asp:HiddenField ID="hfEmployeeSearchClientCode" runat="server" />
                <asp:HiddenField ID="hfEmployeeSearchAsmtId" runat="server" />
                <asp:HiddenField ID="hfEmployeeSearchPostCode" runat="server" />
                <asp:HiddenField ID="hfAreaOldValue" runat="server" />
                <asp:HiddenField ID="hfAreaNewValue" runat="server" />
                <asp:HiddenField ID="hfOldWeek" runat="server" />
                <asp:Label ID="lblOldAsmtCode" EnableViewState="true" runat="server" Style="display: none"></asp:Label>
                <asp:Button ID="btnEditMode" runat="server" OnClick="btnEditMode_OnClick" Style="display: none" />
                <table>
                    <tr>
                        <td>
                            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" AutoSize="false"
                                Modal="true" Skin="WebBlue" EnableShadow="true" Height="550px" Width="850px">
                                <Shortcuts>
                                    <telerik:WindowShortcut CommandName="CloseAll" Shortcut="Esc" />
                                </Shortcuts>
                                <Windows>
                                    <telerik:RadWindow ID="RadWindow" runat="server" AutoSize="false" Overlay="true"
                                        ReloadOnShow="true" ShowContentDuringLoad="false" EnableShadow="true" Height="550px"
                                        Width="1050px" Title="" Modal="true" OnClientClose="RadWindowClose" Behaviors="Default"
                                        Skin="WebBlue">
                                    </telerik:RadWindow>
                                </Windows>
                                <Windows>
                                    <telerik:RadWindow ID="RadWindowConvert" runat="server" Height="550px" Width="850px"
                                        ShowContentDuringLoad="false" EnableShadow="true" Title="" Modal="true" OnClientClose="RadWindowClose"
                                        Behaviors="Default" Skin="WebBlue">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td colspan="8">
                                                        <span id='spanConvertMessage'></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </telerik:RadWindow>
                                </Windows>
                                <Windows>
                                    <telerik:RadWindow ID="RadWindowMessage" runat="server" AutoSize="true" ShowContentDuringLoad="false"
                                        EnableShadow="true" KeepInScreenBounds="false" Width="850px" Height="200px" Title="OverWrite/Error Message"
                                        Modal="true" OnClientClose="RadWindowDuplicateClose" Skin="WebBlue" Behaviors="Close, Move, Resize,Maximize">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td colspan="8">
                                                        <span id='spanErrorMessage'></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <input type="button" accesskey="o" id="btnOverWrite" style="vertical-align: baseline; cursor: hand;"
                                                                        class="cssButton" value="OverWrite" onclick="javascript:OverWriteMultiRecord();" />
                                                                </td>
                                                                <td>
                                                                    <input type="button" accesskey="u" id="btnCheckAll" style="vertical-align: baseline; cursor: hand;"
                                                                        class="cssButton" value="CheckAll" onclick="javascript:CheckAllMultiRecord('');" />
                                                                </td>
                                                                <td>
                                                                    <input type="button" accesskey="u" id="btnUnCheckAll" style="vertical-align: baseline; display: none; cursor: hand;"
                                                                        class="cssButton" value="UnCheckAll" onclick="javascript:UnCheckAllMultiRecord();" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                            <div id="divShift" style="width: 180px; height: 60px; border: 0; display: none; position: absolute">
                                <asp:ListBox ID="LBShift" runat="server" CssClass="cssDropDown" Style="width: 180px; height: 60px"
                                    onclick="javascript:SelectShift(this);" onkeydown="javascript:if(event.keyCode == 13 ) {return false;} else if(event.keyCode == 9) SelectShift(this);"
                                    onkeyup="javascript:if(event.keyCode == 13) SelectShift(this);"></asp:ListBox>
                            </div>
                            <div id="DivShiftPatterns" style="width: 180px; height: 120px; border: 0; display: none; position: absolute">
                                <asp:ListBox ID="LBShiftPatterns" runat="server" CssClass="cssDropDown" Style="width: 180px; height: 120px"
                                    onclick="javascript:SelectShiftPattern(this);" onkeydown="javascript:if(event.keyCode == 13 ) {return false;} else if(event.keyCode == 9) SelectShiftPattern(this);"
                                    onkeyup="javascript:if(event.keyCode == 13) SelectShiftPattern(this);"></asp:ListBox>
                            </div>
                        </td>
                    </tr>
                </table>
                <Ajax:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div id="divEmployeeContainer" style="width: 180px; height: 60px; border: 0; display: none; position: absolute">
                                        <telerik:RadListBox ID="LBEmployeeList" runat="server" SelectionMode="Single" Height="120px"
                                            Width="210px" onclick="javascript:SelectEmployee(this);" onkeydown="javascript:if(event.keyCode == 13 ) {return false;} else if(event.keyCode == 9) SelectEmployee(this);"
                                            onkeyup="javascript:if(event.keyCode == 13 ) SelectEmployee(this);">
                                        </telerik:RadListBox>
                                        <telerik:RadComboBox ID="ddlEmployees" AllowCustomText="true" AccessKey="C" CloseDropDownOnBlur="true"
                                            EnableEmbeddedSkins="true" Filter="Contains" EmptyMessage="<%$ Resources:Resource, NoDataToShow %>"
                                            IsCaseSensitive="false" MarkFirstMatch="true" Width="260px" runat="server" Style="display: none">
                                        </telerik:RadComboBox>
                                        <asp:Button ID="btnFillEmployee" runat="server" OnClick="btnFillEmployee_OnClick"
                                            Style="display: none" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </ContentTemplate>
        </Ajax:UpdatePanel>
        <Ajax:UpdatePanel ID="UP2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td></td>
                        <td>
                            <telerik:RadButton ID="btnProceed" CssClass="cssButton" Style="padding: 0px 24px 0px 24px; height: 30px; text-decoration: none;" EnableEmbeddedSkins="false" runat="server" Text="<%$ Resources:Resource, Proceed %>"
                                OnClick="btnProceed_Click">
                            </telerik:RadButton>
                            <asp:HiddenField ID="HFSoType" runat="server" />
                            <asp:HiddenField ID="HFSOBillable" runat="server" />
                        </td>
                        <td>
                            <asp:UpdatePanel ID="upBack" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <%-- <asp:Button ID="btnBack" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Back %>" />--%>
                                    <asp:Label ID="btnBack" Visible="true" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Back %>"></asp:Label>
                                </ContentTemplate>

                            </asp:UpdatePanel>

                        </td>
                    </tr>
                </table>
                <div id="divRosteringLinks" runat="server">
                    <table style="width: 100%;">
                        <tr style="background-color: #286090">
                            <td style="text-align: left;" class="btn btn-primary btn-xs">
                                <a class="btn btn-primary btn-xs" href="javascript:SearchEmployeeSchedule()">
                                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Resource, SearchEmployeeschedule %>"></asp:Literal></a>
                            </td>
                            <td style="text-align: left;" class="btn btn-primary btn-xs">
                                <a class="btn btn-primary btn-xs" href="javascript:SaleOrderDeployment()">
                                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Resource, SaleOrderDeployment %>"></asp:Literal></a>
                            </td>
                            <td style="text-align: left;" class="btn btn-primary btn-xs">
                                <a class="btn btn-primary btn-xs" href="javascript:SaleOrderConstraint()">
                                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Resource, Constraint %>"></asp:Literal></a>
                            </td>
                            <td style="text-align: left;" class="btn btn-primary btn-xs">
                                <a class="btn btn-primary btn-xs" href="javascript:ClientAndAsmtWiseTotalHours()">
                                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Resource, AssignmentWiseTotalHours %>"></asp:Literal></a>
                            </td>
                            <td style="text-align: left;" class="btn btn-primary btn-xs">
                                <div id="divShiftDetail">
                                    <a class="btn btn-primary btn-xs" href="javascript:SearchShiftDetails()">
                                        <asp:Literal ID="lblShiftDetail" runat="server" Text=" <%$ Resources:Resource, ShiftDetails %>" />
                                    </a>
                                </div>
                            </td>
                            <td style="text-align: right;">
                                <telerik:RadToolTip ID="RadToolTipJobBreakDown" runat="server" Animation="Fade" AutoCloseDelay="1000"
                                    Width="400px" Height="180px" ContentScrolling="Auto" ManualClose="true" MouseTrailing="true"
                                    IsClientID="true">
                                    <p style="text-align: left">
                                        <span id="SpanjobBreakDownSummary" style="width: 230px;" class="cssLable"></span>
                                    </p>
                                    <input type="hidden" id="HFJobBreakDownSchRosterAutoID" />
                                    <input type="button" id="btnJobBreakDown" value="JobbreakDownSummary" onclick="javascript:JobBreakDownSummary();CloseJobBreakDown();" />
                                </telerik:RadToolTip>
                                <asp:LinkButton ID="btntoolTip" class="btn btn-primary btn-xs" runat="server" Text="Legends/Help"></asp:LinkButton>
                                <telerik:RadToolTip ID="tooltip" runat="server" Animation="Fade" AutoCloseDelay="5000000"
                                    Width="900px" Height="350px" ContentScrolling="Auto" ManualClose="true" TargetControlID="btntoolTip"
                                    ShowEvent="OnClick" RelativeTo="Element" IsClientID="true" OnClientShow="LegendClientShow">
                                    <asp:Panel ID="PanelColorCode" Width="100%" runat="server" GroupingText="Colors Used">
                                        <span id="spanLegends" style="width: 100%;" class="cssLable"></span>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel1" runat="server" GroupingText="Shortcut Keys">
                                        <table width="100%">
                                            <tr style="background-color: LightBlue">
                                                <td width="30" style="text-align: center;">S. No.
                                                </td>
                                                <td width="180" style="text-align: center;">Shortcut Keys
                                                </td>
                                                <td width="400" style="text-align: center;">Description
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>1.
                                                </td>
                                                <td>F7 Key
                                                </td>
                                                <td style="text-align: left">This key is used to open <strong>"Lock Schedule"</strong> in Schedule mode and confirm
                                            attendance in Actual mode.
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>2.
                                                </td>
                                                <td>F8 Key
                                                </td>
                                                <td style="text-align: left">This key is used to open <strong>"Create Sequence"</strong>.
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>3.
                                                </td>
                                                <td>F9 Key
                                                </td>
                                                <td style="text-align: left">This key is used to Show <strong>"Total UnScheduled Employees"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>4.
                                                </td>
                                                <td>F10 Key
                                                </td>
                                                <td style="text-align: left">This key is used to Show <strong>"All Employee Constraint Details"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>5.
                                                </td>
                                                <td>ALT + T
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Attendance type dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>6.
                                                </td>
                                                <td>ALT + S
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Schedule type dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>7.
                                                </td>
                                                <td>ALT + M
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Month dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>8.
                                                </td>
                                                <td>ALT + W
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Week dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>9.
                                                </td>
                                                <td>ALT + R
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Area dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>10.
                                                </td>
                                                <td>ALT + Y
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Year dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>11.
                                                </td>
                                                <td>ALT + C
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Client dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>12.
                                                </td>
                                                <td>ALT + A
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Assignment dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>13.
                                                </td>
                                                <td>ALT + P
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Post dropdown"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>14.
                                                </td>
                                                <td>ALT + U
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Check All/Uncheck ALL button in Error message popup"</strong>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>15.
                                                </td>
                                                <td>ALT + O
                                                </td>
                                                <td style="text-align: left">Go to <strong>"Overwrite button in Error message popup"</strong>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </telerik:RadToolTip>
                            </td>
                        </tr>
                    </table>
                </div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:HiddenField ID="HFNumberOfRowsInGrid" runat="server" />
                            <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            <asp:GridView ID="gvScheduleRoster" runat="server" CssClass="GridViewStyle" ShowFooter="true"
                                ClientIDMode="AutoID" AllowPaging="true" CellPadding="1" AutoGenerateColumns="false"
                                FooterStyle-CssClass="GridViewFooterStyle"
                                PagerStyle-CssClass="GridViewPagerStyle"
                                GridLines="Both" AllowSorting="false" OnRowDataBound="gvScheduleRoster_RowDataBound"
                                OnRowCreated="gvScheduleRoster_RowCreated" OnDataBound="gvScheduleRoster_DataBound"
                                OnRowCommand="gvScheduleRoster_RowCommand" OnPageIndexChanging="gvScheduleRoster_PageIndexChanging"
                                OnRowUpdating="gvScheduleRoster_OnRowUpdating">
                                <Columns>
                                    <asp:ButtonField CommandName="ColumnClick" Visible="false" />
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" FooterStyle-CssClass="GridViewFooterStyle"
                                        ItemStyle-CssClass="GridViewRowStyle">
                                        <HeaderTemplate>
                                            <table width="360px">
                                                <tr>
                                                    <td style="text-align: left; width: 15px;">
                                                        <asp:Label ID="Label13" runat="server" Text="<%$Resources:Resource,Sno %>"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left; width: 100px;">
                                                        <asp:Label ID="lblHeaderSoRank" runat="server" Text="<%$ Resources:Resource, EmpNo %>"></asp:Label>
                                                        <asp:TextBox ID="txtEmployeeSearch" Font-Bold="true" BackColor="Transparent" OnTextChanged="txtEmployeeSearch_TextChanged"
                                                            AutoPostBack="true" MaxLength="16" runat="server" Width="55px" CssClass="csstxtboxSmall"></asp:TextBox>
                                                    </td>
                                                    <td style="text-align: left; width: 90px;">
                                                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Resource, Name %>"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left; width: 15px;">
                                                        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, Designation%>"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right; width: 15px;">
                                                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:Resource, Position %>"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right; width: 30px;">
                                                        <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Resource, Code %>"></asp:Label>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowID" Style="display: none;" Width="15px" runat="server" CssClass="cssLabel"
                                                Text='<%# Eval("RowNumber") %>'></asp:Label>
                                            <table style="padding: 0; border-spacing: 0; margin: 0;" width="360px">
                                                <tr>
                                                    <td style="width: 15px;">
                                                        <asp:Label ID="lblSerialNumber" Width="15px" runat="server" CssClass="cssLabel"></asp:Label>
                                                        <asp:HiddenField ID="HGPayrateStatus" runat="server" Value='<%# Eval("WageRateStatus") %>' />
                                                    </td>
                                                    <td style="width: 100px;">
                                                        <asp:TextBox ID="txtEmpNumberDutyDate" Font-Bold="true" Text='<%# Eval("EmployeeNumber") %>'
                                                            MaxLength="16" Width="55px" CssClass="csstxtboxSmall" runat="server" onkeydown="javascript:FunctionCallOnKeyDown('EmployeeNumber',this)"></asp:TextBox>
                                                        <asp:LinkButton ID="IBSearchEmployee" Text="?" Font-Bold="true" Font-Size="Small"
                                                            runat="server" CssClass="cssImgButton"></asp:LinkButton>
                                                        <asp:HiddenField ID="HFOrgEmployeeNumber" runat="server" Value='<%# Eval("EmployeeNumber") %>' />
                                                    </td>
                                                    <td style="width: 90px">
                                                        <asp:TextBox ID="txtEmpNameDutyDate" Font-Bold="true" onkeyup="javascript:SearchEmployee(this);"
                                                            Text='<%# Eval("EmployeeName") %>' CssClass="csstxtboxSmall" runat="server" Width="90px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px">
                                                        <asp:TextBox ID="txtEmpDesignationDesc" Font-Bold="true" Text='<%# Eval("DesignationDesc") %>'
                                                            CssClass="csstxtboxSmall" runat="server" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 30px">
                                                        <asp:TextBox ID="txtPatternPosition" Font-Bold="true" Text='<%# Eval("PatternPosition") %>'
                                                            CssClass="csstxtboxSmall" runat="server" onkeydown="javascript:FunctionCallOnKeyDown('PatternPosition',this)"
                                                            Width="30px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 30px">
                                                        <asp:TextBox ID="txtShiftPatternCode" Font-Bold="true" Text='<%# Eval("ShiftPatternCode") %>'
                                                            onkeyup="javascript:SearchShiftPattern(this)" onkeydown="javascript:FunctionCallOnKeyDown('ShiftPatternCode',this)"
                                                            CssClass="csstxtboxSmall" runat="server" Width="30px"></asp:TextBox>
                                                        <asp:HiddenField ID="hfBorrowedEmployeeStatus" Value='<%# Eval("BorrowedEmployeeStatus") %>'
                                                            runat="server" />
                                                        <asp:HiddenField ID="HFShiftPatternCode" Value='<%# Eval("ShiftPatternCode") %>'
                                                            runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="350px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" ItemStyle-Width="120px"
                                        ItemStyle-CssClass="GridViewRowStyle">
                                        <HeaderTemplate>
                                            <asp:Panel runat="server" ID="reqDiv1">
                                                <asp:Label ID="lblReqSch1" Font-Bold="true" Text="" runat="server"></asp:Label>
                                                <asp:HiddenField ID="HFReqSch1" runat="server" />
                                            </asp:Panel>
                                            <asp:Label ID="lblHeaderDutyDate1" Visible="true" runat="server"></asp:Label>
                                            <br>
                                            <asp:Label ID="lblTempHeaderDutyDate1" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblSelectGvScheduling" ID="lblSelect1" runat="server" Text="&nbsp;"></asp:Label>
                                            <asp:Label ID="lblDutyDate1" Style="border: 1px; font-size: smaller" runat="server"
                                                Text='<%# Eval("1") %>'></asp:Label>
                                            <asp:Label ID="lblSchAutoId1" runat="server" Text='0' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblOtherAssignmentAutoId1" runat="server" Style="display: none"></asp:Label>
                                            <asp:HiddenField ID="HFSchRosterAutoID1" runat="server" />
                                            <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                                <tr>
                                                    <td style="width: 20%;">
                                                        <asp:TextBox ID="txtEmpShiftDutyDate1" Style="text-align: center; display: none;"
                                                            CssClass="csstxtboxSmall" onkeyup="javascript:SearchShift(this);" onkeydown="javascript:FunctionCallOnKeyDown('ShiftCode',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeFrom1" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeFrom',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeTo1" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeTo',this)" runat="server"
                                                            Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" ItemStyle-Width="120px"
                                        ItemStyle-CssClass="GridViewRowStyle">
                                        <HeaderTemplate>
                                            <asp:Panel runat="server" ID="reqDiv2">
                                                <asp:Label ID="lblReqSch2" Font-Bold="true" Text="" runat="server"></asp:Label>
                                                <asp:HiddenField ID="HFReqSch2" runat="server" />
                                            </asp:Panel>
                                            <asp:Label ID="lblHeaderDutyDate2" runat="server"></asp:Label>
                                            <br>
                                            <asp:Label ID="lblTempHeaderDutyDate2" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblSelectGvScheduling" ID="lblSelect2" runat="server" Text="&nbsp;"></asp:Label>
                                            <asp:Label ID="lblDutyDate2" Style="border: 1px; font-size: smaller" runat="server"
                                                Text='<%# Eval("2") %>'></asp:Label>
                                            <asp:Label ID="lblSchAutoId2" runat="server" Text='0' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblOtherAssignmentAutoId2" runat="server" Style="display: none"></asp:Label>
                                            <asp:HiddenField ID="HFSchRosterAutoID2" runat="server" />
                                            <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                                <tr>
                                                    <td style="width: 20%;">
                                                        <asp:TextBox ID="txtEmpShiftDutyDate2" Style="text-align: center; display: none;"
                                                            CssClass="csstxtboxSmall" onkeyup="javascript:SearchShift(this);" onkeydown="javascript:FunctionCallOnKeyDown('ShiftCode',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeFrom2" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeFrom',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeTo2" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeTo',this)" runat="server"
                                                            Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" ItemStyle-Width="120px"
                                        ItemStyle-CssClass="GridViewRowStyle">
                                        <HeaderTemplate>
                                            <asp:Panel runat="server" ID="reqDiv3">
                                                <asp:Label ID="lblReqSch3" Font-Bold="true" Text="" runat="server"></asp:Label>
                                                <asp:HiddenField ID="HFReqSch3" runat="server" />
                                            </asp:Panel>
                                            <asp:Label ID="lblHeaderDutyDate3" runat="server"></asp:Label>
                                            <br>
                                            <asp:Label ID="lblTempHeaderDutyDate3" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblSelectGvScheduling" ID="lblSelect3" runat="server" Text="&nbsp;"></asp:Label>
                                            <asp:Label ID="lblDutyDate3" Style="border: 1px; font-size: smaller" runat="server"
                                                Text='<%# Eval("3") %>'></asp:Label>
                                            <asp:Label ID="lblSchAutoId3" runat="server" Text='0' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblOtherAssignmentAutoId3" runat="server" Style="display: none"></asp:Label>
                                            <asp:HiddenField ID="HFSchRosterAutoID3" runat="server" />
                                            <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                                <tr>
                                                    <td style="width: 20%;">
                                                        <asp:TextBox ID="txtEmpShiftDutyDate3" Style="text-align: center; display: none;"
                                                            CssClass="csstxtboxSmall" onkeyup="javascript:SearchShift(this);" onkeydown="javascript:FunctionCallOnKeyDown('ShiftCode',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeFrom3" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeFrom',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeTo3" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeTo',this)" runat="server"
                                                            Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" ItemStyle-Width="120px"
                                        ItemStyle-CssClass="GridViewRowStyle">
                                        <HeaderTemplate>
                                            <asp:Panel runat="server" ID="reqDiv4">
                                                <asp:Label ID="lblReqSch4" Font-Bold="true" Text="" runat="server"></asp:Label>
                                                <asp:HiddenField ID="HFReqSch4" runat="server" />
                                            </asp:Panel>
                                            <asp:Label ID="lblHeaderDutyDate4" runat="server"></asp:Label>
                                            <br>
                                            <asp:Label ID="lblTempHeaderDutyDate4" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblSelectGvScheduling" ID="lblSelect4" runat="server" Text="&nbsp;"></asp:Label>
                                            <asp:Label ID="lblDutyDate4" Style="border: 1px; font-size: smaller" runat="server"
                                                Text='<%# Eval("4") %>'></asp:Label>
                                            <asp:Label ID="lblSchAutoId4" runat="server" Text='0' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblOtherAssignmentAutoId4" runat="server" Style="display: none"></asp:Label>
                                            <asp:HiddenField ID="HFSchRosterAutoID4" runat="server" />
                                            <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                                <tr>
                                                    <td style="width: 20%;">
                                                        <asp:TextBox ID="txtEmpShiftDutyDate4" Style="text-align: center; display: none;"
                                                            CssClass="csstxtboxSmall" onkeyup="javascript:SearchShift(this);" onkeydown="javascript:FunctionCallOnKeyDown('ShiftCode',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeFrom4" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeFrom',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeTo4" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeTo',this)" runat="server"
                                                            Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" ItemStyle-Width="120px"
                                        ItemStyle-CssClass="GridViewRowStyle">
                                        <HeaderTemplate>
                                            <asp:Panel runat="server" ID="reqDiv5">
                                                <asp:Label ID="lblReqSch5" Font-Bold="true" Text="" runat="server"></asp:Label>
                                                <asp:HiddenField ID="HFReqSch5" runat="server" />
                                            </asp:Panel>
                                            <asp:Label ID="lblHeaderDutyDate5" runat="server"></asp:Label>
                                            <br>
                                            <asp:Label ID="lblTempHeaderDutyDate5" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblSelectGvScheduling" ID="lblSelect5" runat="server" Text="&nbsp;"></asp:Label>
                                            <asp:Label ID="lblDutyDate5" Style="border: 1px; font-size: smaller" runat="server"
                                                Text='<%# Eval("5") %>'></asp:Label>
                                            <asp:Label ID="lblSchAutoId5" runat="server" Text='0' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblOtherAssignmentAutoId5" runat="server" Style="display: none"></asp:Label>
                                            <asp:HiddenField ID="HFSchRosterAutoID5" runat="server" />
                                            <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                                <tr>
                                                    <td style="width: 20%;">
                                                        <asp:TextBox ID="txtEmpShiftDutyDate5" Style="text-align: center; display: none;"
                                                            CssClass="csstxtboxSmall" onkeyup="javascript:SearchShift(this);" onkeydown="javascript:FunctionCallOnKeyDown('ShiftCode',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeFrom5" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeFrom',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeTo5" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeTo',this)" runat="server"
                                                            Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" ItemStyle-Width="120px"
                                        ItemStyle-CssClass="GridViewRowStyle">
                                        <HeaderTemplate>
                                            <asp:Panel runat="server" ID="reqDiv6">
                                                <asp:Label ID="lblReqSch6" Font-Bold="true" Text="" runat="server"></asp:Label>
                                                <asp:HiddenField ID="HFReqSch6" runat="server" />
                                            </asp:Panel>
                                            <asp:Label ID="lblHeaderDutyDate6" runat="server"></asp:Label>
                                            <br>
                                            <asp:Label ID="lblTempHeaderDutyDate6" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblSelectGvScheduling" ID="lblSelect6" runat="server" Text="&nbsp;"></asp:Label>
                                            <asp:Label ID="lblDutyDate6" Style="border: 1px; font-size: smaller" runat="server"
                                                Text='<%# Eval("6") %>'></asp:Label>
                                            <asp:Label ID="lblSchAutoId6" runat="server" Text='0' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblOtherAssignmentAutoId6" runat="server" Style="display: none"></asp:Label>
                                            <asp:HiddenField ID="HFSchRosterAutoID6" runat="server" />
                                            <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                                <tr>
                                                    <td style="width: 20%;">
                                                        <asp:TextBox ID="txtEmpShiftDutyDate6" Style="text-align: center; display: none;"
                                                            CssClass="csstxtboxSmall" onkeyup="javascript:SearchShift(this);" onkeydown="javascript:FunctionCallOnKeyDown('ShiftCode',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeFrom6" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeFrom',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeTo6" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeTo',this)" runat="server"
                                                            Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" ItemStyle-Width="120px"
                                        ItemStyle-CssClass="GridViewRowStyle">
                                        <HeaderTemplate>
                                            <asp:Panel runat="server" ID="reqDiv7">
                                                <asp:Label ID="lblReqSch7" Font-Bold="true" Text="" runat="server"></asp:Label>
                                                <asp:HiddenField ID="HFReqSch7" runat="server" />
                                            </asp:Panel>
                                            <asp:Label ID="lblHeaderDutyDate7" runat="server"></asp:Label>
                                            <br>
                                            <asp:Label ID="lblTempHeaderDutyDate7" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblSelectGvScheduling" ID="lblSelect7" runat="server" Text="&nbsp;"></asp:Label>
                                            <asp:Label ID="lblDutyDate7" Style="border: 1px; font-size: smaller" runat="server"
                                                Text='<%# Eval("7") %>'></asp:Label>
                                            <asp:Label ID="lblSchAutoId7" runat="server" Text='0' Style="display: none"></asp:Label>
                                            <asp:Label ID="lblOtherAssignmentAutoId7" runat="server" Style="display: none"></asp:Label>
                                            <asp:HiddenField ID="HFSchRosterAutoID7" runat="server" />
                                            <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                                <tr>
                                                    <td style="width: 20%;">
                                                        <asp:TextBox ID="txtEmpShiftDutyDate7" Style="text-align: center; display: none;"
                                                            CssClass="csstxtboxSmall" onkeyup="javascript:SearchShift(this);" onkeydown="javascript:FunctionCallOnKeyDown('ShiftCode',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeFrom7" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeFrom',this)"
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40%;">
                                                        <asp:TextBox ID="txtTimeTo7" CssClass="csstxtboxSmall" Style="text-align: center; display: none;"
                                                            onkeydown="javascript:FunctionCallOnKeyDown('TimeTo',this)" runat="server"
                                                            Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GridViewHeaderStyle" ItemStyle-CssClass="GridViewRowStyle"
                                        HeaderText="Total Duty Hrs">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton13" runat="server" OnClientClick="javascript:SetFocusOnControl();return false;"
                                                ImageUrl="~/Images/spacer.gif" />
                                            <asp:Label ID="lblDutyMin" runat="server" CssClass="csslblErrMsg" Width="80px" Text='<%# Eval("DutyMin") %>'></asp:Label>
                                            <asp:ImageButton ID="ImgbtnUpdateTran" Visible="false" ToolTip="<%$Resources:Resource,Reset %>"
                                                ImageUrl="~/Images/Reset.gif" CssClass="csslnkButton" runat="server" CommandName="Update" Height="12px" Width="12px"
                                                searcGroup="Edit" />

                                        </ItemTemplate>
                                        <ItemStyle Width="150px" />
                                        <FooterStyle Width="150px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerTemplate>
                                    <table style="border: 0px;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="if(event.keyCode==0){return false;}"
                                                    ImageUrl="~/Images/spacer.gif" />
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                                    CommandArgument="Prev" CommandName="Page" />
                                                <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                                <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                                <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                                                <asp:ImageButton ID="ImageButton3" onkeydown="if(event.keyCode==13){return false;}"
                                                    runat="server" ImageUrl="~/Images/nextpage.gif" CommandArgument="Next" CommandName="Page" />
                                            </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <%--                    <td>
                        <div id="divShiftDetail">
                            <a class="btn btn-primary btn-xs" href="javascript:SearchShiftDetails()">
                                <asp:Literal ID="lblShiftDetail" runat="server" Text=" <%$ Resources:Resource, ShiftDetails %>" />
                                </a>
                        </div>
                    </td>--%>
                    </tr>
                    <tr>
                        <td>
                            <div id="divShowShiftDet" style="display: none; width: 80%">
                                <span id="spnShiftDetail" />
                            </div>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <div id="divDutyReplacement" style="width: 200px; height: 80px; display: none; border: 1px; border-top: 1px; border-style: solid; border-color: Gray; position: absolute; background: white; left: 180px; top: 150px;">
                                <table style="padding: 0; border-spacing: 0; margin: 0; font-size: xx-small">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource,Reason%>"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlDutyReplacement" CssClass="cssDropDown" runat="server" Width="140">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a id="A11" href="javascript:UpdateDutyReplacement();" style="cursor: pointer">Update</a>
                                        </td>
                                        <td>
                                            <a id="A21" href="javascript:DeleteDutyReplacement();" style="cursor: pointer">Delete</a>
                                        </td>
                                        <td>
                                            <a href="javascript:CloseDutyReplacement();" style="cursor: pointer">Close</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="divAdjustment" style="width: 200px; height: 80px; display: none; border: 1px; border-top: 1px; border-style: solid; border-color: Gray; position: absolute; background: white; left: 180px; top: 150px;">
                                <table style="padding: 0; border-spacing: 0; margin: 0; font-size: xx-small">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAdjustmentHrs" runat="server" Text="<%$ Resources:Resource,Hours%>"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAdjustmentHrs" runat="server" CssClass=" csstxtboxSmall" MaxLength="5"
                                                Text="00.00" Width="30px"></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtenderHoursPerUnit" AutoComplete="true"
                                                AutoCompleteValue="0" AcceptNegative="None" runat="server" TargetControlID="txtAdjustmentHrs"
                                                Mask="99.99" MessageValidatorTip="true" MaskType="Number" AcceptAMPM="false"
                                                ClearTextOnInvalid="true" ErrorTooltipEnabled="True"></AjaxToolKit:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAdjustmentType" runat="server" Text="<%$ Resources:Resource,Type%>"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="AdjType" CssClass="cssDropDown" runat="server" Width="140">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAdjustmentRemark" runat="server" Text="<%$ Resources:Resource,Remark%>"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAdjustmentRemark" runat="server" CssClass=" csstxtboxSmall" MaxLength="100"
                                                Width="140px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a id="SaveAdjustment" href="javascript:funcHoursAdjustment('I');" style="cursor: pointer">Save</a>
                                        </td>
                                        <td>
                                            <a id="DeleteAdjustment" href="javascript:funcHoursAdjustment('D');" style="cursor: pointer">Delete</a>
                                        </td>
                                        <td>
                                            <a href="javascript:CloseAdjustment();" style="cursor: pointer">Close</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <div id="contextMenu1">
                    <telerik:RadContextMenu EnableAutoScroll="true" ID="RadContextMenu" Skin="Office2007"
                        runat="server">
                        <Targets>
                            <telerik:ContextMenuElementTarget ElementID="gvScheduleRoster" />
                        </Targets>
                    </telerik:RadContextMenu>
                </div>
            </ContentTemplate>
            <Triggers>
                <Ajax:PostBackTrigger ControlID="btnEditMode" />
            </Triggers>
        </Ajax:UpdatePanel>
        <table>
            <tr>
                <td>
                    <telerik:RadWindow ID="RadWindowBorrow" runat="server" AutoSize="false" ShowContentDuringLoad="false"
                        EnableShadow="true" KeepInScreenBounds="false" Width="850px" Height="550px" Title=""
                        Modal="true" Skin="WebBlue" Behaviors="Close, Move, Resize, Maximize">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <a href="javascript:ListOfEmployeeGet(this);" id="A14">List of Employees</a>
                                                <a href="javascript:BorrowUnSchEmpDiv(this);" id="text1link">Borrowed Employee</a>
                                                <asp:Button ID="btnExportToExcel" Width="150px" Text="Export To Excel" OnClick="btnExportToExcel_Click"
                                                    runat="server" />
                                                <asp:Button ID="btnUnScheduledEmp" runat="server" OnClick="btnUnScheduledEmp_OnClick"
                                                    Style="display: none" />
                                                <asp:Button ID="btnBorrowedEmp" runat="server" OnClick="btnBorrowedEmp_OnClick" Style="display: none" />
                                            </ContentTemplate>
                                        </Ajax:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <Ajax:UpdatePanel ID="UP3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table width="97%" style="padding: 4px; border-spacing: 0; margin: 0; background-color: #efefef; border: 1px solid #c0c0c0;">
                                        <%--  <tr style="background-color: #6EB6D5;" valign="top">
                                        <td style="width: 91%" colspan="3">
                                        </td>
                                    </tr>--%>
                                        <tr>
                                            <td colspan="5">
                                                <asp:HiddenField ID="HFUnSchEmployeeClickStatus" runat="server" Value="" />
                                                <telerik:RadGrid ID="gvUnScheduledEmployees" runat="server" Width="100%" Height="440px" AllowFilteringByColumn="true"
                                                    OnNeedDataSource="gvUnScheduledEmployees_NeedDataSource" AllowSorting="True"
                                                    AutoGenerateColumns="false" AllowMultiRowSelection="True" AllowPaging="true"
                                                    PageSize="10" ExportSettings-IgnorePaging="true" ShowGroupPanel="True" GridLines="None"
                                                    Skin="Office2007" ExportSettings-ExportOnlyData="true">
                                                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                                    <MasterTableView AllowMultiColumnSorting="True" CommandItemDisplay="TopAndBottom"
                                                        EnableViewState="true">
                                                        <CommandItemSettings ShowExportToExcelButton="false" ShowAddNewRecordButton="false"
                                                            ShowRefreshButton="false"></CommandItemSettings>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn UniqueName="EmployeeNumber" GroupByExpression="EmpNo"
                                                                DataField="EmpNo" SortExpression="EmpNo" HeaderText="Employee No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lnkEmpNo" onclick="javascript:AssignToSelectedTextBox(this);" Style="cursor: hand"
                                                                        runat="server" CommandName="Empclick" Text='<%# Bind("EmpNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn SortExpression="EmpName" HeaderText="<%$ Resources:Resource, EmployeeName %>"
                                                                HeaderButtonType="TextButton" DataField="EmpName">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn SortExpression="DesigNationDesc" HeaderText="<%$ Resources:Resource, Designation %>"
                                                                HeaderButtonType="TextButton" DataField="DesigNationDesc">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn SortExpression="WeeklyDutyMin" HeaderText="Week(Hrs Worked)"
                                                                HeaderButtonType="TextButton" DataField="WeeklyDutyMin">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn SortExpression="MonthDutyMin" HeaderText="Month(Hrs Worked)"
                                                                HeaderButtonType="TextButton" DataField="MonthDutyMin">
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <ExportSettings>
                                                        <Excel Format="ExcelML"></Excel>
                                                    </ExportSettings>
                                                    <ClientSettings AllowDragToGroup="True">
                                                        <Selecting AllowRowSelect="True"></Selecting>
                                                        <ClientEvents OnCommand="KeyPress" />
                                                        <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                                                        <ClientMessages DragToGroupOrReorder="Drag to group" />
                                                        <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True"
                                                            ResizeGridOnColumnResize="False"></Resizing>
                                                    </ClientSettings>
                                                    <GroupingSettings ShowUnGroupButton="true" />
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <Ajax:PostBackTrigger ControlID="btnExportToExcel" />
                                </Triggers>
                            </Ajax:UpdatePanel>
                        </ContentTemplate>
                    </telerik:RadWindow>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadWindow ID="RadWindowEmployeeSearch" runat="server" ShowContentDuringLoad="false"
                        AutoSizeBehaviors="Default" EnableShadow="true" KeepInScreenBounds="false" Title=""
                        Modal="true" Width="850px" Height="400px" OnClientClose="RadWindowClose" Behaviors="Default"
                        Skin="WebBlue" OnClientShow="FillDateEvent">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text='<%$ Resources:Resource,EmployeeNumber %>'></asp:Label>
                                    </td>
                                    <td>
                                        <input type="text" id="search_txtEmployeeNumber" class="csstxtboxSmall" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%$ Resources:Resource,EmployeeName %>'></asp:Label>
                                    </td>
                                    <td>
                                        <input type="text" id="search_txtEmployeeName" class="csstxtboxSmall" maxlength="10"
                                            onkeyup="javascript:SearchEmployeeName(this,'Name');" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFDate" runat="server" Text='<%$ Resources:Resource,FDate %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" CssClass="csstxtbox" runat="server" Width="95px" Enabled="false"></asp:TextBox>
                                        <asp:ImageButton ID="IFDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                        <AjaxToolKit:CalendarExtender ID="calFDate" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtFromDate"
                                            PopupButtonID="IFDate" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblTDate" Text='<%$ Resources:Resource,TDate %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToDate" CssClass="csstxtbox" runat="server" Width="95px" Enabled="false"></asp:TextBox>
                                        <asp:ImageButton ID="ITDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                        <AjaxToolKit:CalendarExtender ID="calTDate" runat="server" TargetControlID="txtToDate"
                                            PopupButtonID="ITDate" Format="dd-MMM-yyyy" />
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <input type="button" id="btnEmploye /eSearch" class="cssButton" value="Go" onclick="javascript:OnEmployeeSearchSelectedIndexChanged();" />
                                    </td>
                                    <td colspan="6">
                                        <div id="divEmployeeList" style="width: 205px; height: 60px; border: 0; display: none; position: absolute">
                                            <telerik:RadListBox ID="lstBox_Employees" runat="server" SelectionMode="Single" Height="120px"
                                                Width="210px" onclick="javascript:func_SelectEmployee(this);" onkeydown="javascript:if(event.keyCode == 13 ) {return false;} else if(event.keyCode == 9) func_SelectEmployee(this);"
                                                onkeyup="javascript:if(event.keyCode == 13) func_SelectEmployee(this);">
                                            </telerik:RadListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <span id='spanEmployeeSchedule'></span>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadWindow>
                </td>
            </tr>
        </table>
    </form>
    <script language="javascript" type="text/javascript">
        document.onkeyup = ShortCutKeysJS;
        function OnLoad() {
            $(document).ready(function () {
                FillWeekDropDown();
            });
        }



        function VariableInitialization() {
            

        <%var accessInfo = new CommonLibrary.Session.AccessInformation();%>
        <%var uInfo = new CommonLibrary.Session.UserInformation(); %>
        
        this.SessionCulture = '<% = uInfo.CountryCode %>';
        this.SessionUserId = '<% = uInfo.UserId %>';
        this.SessionLocationAutoId = '<% = accessInfo.LocationAutoId %>';
        this.SessionCompanyCode = '<% = accessInfo.CompanyCode %>';
        this.SessionHrLocationCode = '<% = accessInfo.HrLocationCode %>';
        this.SessionLocationCode = '<% = accessInfo.LocationCode %>';
        this.SessionLoginType = '<% = uInfo.UserRole %>';
        this.SessionAreaInchargeNumber = '<% = uInfo.EmployeeNumber %>';
        this.IsAreaIncharge = '<% = uInfo.IsAreaIncharge %>';


           
            this.RefresherTrainingPending = '<%= Resources.Resource.RefresherTrainingPending %>';
            this.Trainingisingraceperiod = '<%= Resources.Resource.Trainingisingraceperiod %>';
            this.January = '<%= Resources.Resource.January %>';
            this.February = '<%= Resources.Resource.February %>';
            this.March = '<%= Resources.Resource.March %>';
            this.April = '<%= Resources.Resource.April %>';
            this.May = '<%= Resources.Resource.May %>';
            this.June = '<%= Resources.Resource.June %>';
            this.July = '<%= Resources.Resource.July %>';
            this.August = '<%= Resources.Resource.August %>';
            this.September = '<%= Resources.Resource.September %>';
            this.October = '<%= Resources.Resource.October %>';
            this.November = '<%= Resources.Resource.November %>';
            this.December = '<%= Resources.Resource.December %>';
            this.DateRange = '<%= Resources.Resource.Date %>';
            this.Total = '<%= Resources.Resource.Total %>';
            this.MsgSuccessfullyLocked = '<%= Resources.Resource.MsgSuccessfullyLocked %>';
            this.JobbreakDownSummary = '<%= Resources.Resource.JobbreakDownSummary %>';
            this.InvalidEmpCode = '<%= Resources.Resource.InvalidEmpCode %>';
            this.InvalidShiftPatternPosition = '<%= Resources.Resource.InvalidShiftPatternPosition %>';
            this.EmployeecannotbeleftBlank = '<%= Resources.Resource.EmployeecannotbeleftBlank %>';
            this.All = '<%= Resources.Resource.All %>';
            this.NoDataToShow = '<%= Resources.Resource.NoDataToShow %>';
            this.InvalidAssignment = '<%= Resources.Resource.InvalidAssignment %>';
            this.Dataisnotcopiedproperly = '<%= Resources.Resource.Dataisnotcopiedproperly %>';
            this.FollowingRecordscannotbecopied = '<%= Resources.Resource.FollowingRecordscannotbecopied %>';
            this.SuccessfullyCopied = '<%= Resources.Resource.MsgSuccessfullyCopied %>';
            this.TimeisNotInValidFormat = '<%= Resources.Resource.TimeisNotInValidFormat %>';
            this.HourMustBeBetween0And23 = '<%= Resources.Resource.HourMustBeBetween0And23 %>';
            this.MinuteMustBeBetween0And59 = '<%= Resources.Resource.MinuteMustBeBetween0And59 %>';
            this.NoDatatoCopy = '<%= Resources.Resource.NoDatatoCopy %>';
            this.ShiftCodeCannotbeleftBlank = '<%= Resources.Resource.ShiftCanNotBeLeftBlank %>';
            this.RoleCannotbeleftBlank = '<%= Resources.Resource.RoleCannotbeleftBlank %>';
            this.TimeFromCannotbeleftBlank = '<%= Resources.Resource.TimeFromCannotbeleftBlank %>';
            this.Minimumprofitabilitynotmet = '<%= Resources.Resource.Minimumprofitabilitynotmet %>';
            this.OptimumProfitabilityMismatch = '<%= Resources.Resource.OptimumProfitabilityMismatch %>';
            this.InvalidShiftPattern = '<%= Resources.Resource.InvalidShiftPattern %>';
            this.Deletenotallowedpleaseaddreplacementduty = '<%= Resources.Resource.Deletenotallowedpleaseaddreplacementduty %>';
            this.DutyTypeCannotbeleftBlank = '<%= Resources.Resource.DutyTypeCannotbeleftBlank %>';
            this.Duplicate = '<%= Resources.Resource.Duplicate %>';
            this.AreyousureyouwanttoLocktheSchedule = '<%= Resources.Resource.AreyousureyouwanttoLocktheSchedule %>';
            this.Lockingnotallowedpleasechangetheattendancetypeoftheassignment = '<%= Resources.Resource.Lockingnotallowedpleasechangetheattendancetypeoftheassignment %>';
            this.OverWrite = '<%= Resources.Resource.OverWrite %>';
            this.pageTitle = '<%= Resources.Resource.ScheduleRosterEmpWise %>';//Resources.Resource.ScheduleRosterEmpWise
            this.Insert = '<%= Resources.Resource.Insert %>';
            this.Alert = '<%= Resources.Resource.Alert %>';
            this.ErrorMessage = '<%= Resources.Resource.ErrorMessage %>';
            this.EmployeeNumberCannotbeleftBlank = '<%= Resources.Resource.EmployeeNumberCannotbeleftBlank %>';
            this.InvalidShift = '<%= Resources.Resource.InvalidShift %>';
            this.Converted = '<%= Resources.Resource.Converted %>';
            this.Leave = '<%= Resources.Resource.Leave %>';
            this.Times = '<%= Resources.Resource.Time %>';
            this.Shift = '<%= Resources.Resource.Shift %>';
            this.Close = '<%= Resources.Resource.Close %>';
            this.Copy = '<%= Resources.Resource.Copy %>';
            this.OverWriteShift = '<%= Resources.Resource.OverWriteShift %>';
            this.CheckAll = '<%= Resources.Resource.CheckAll %>';
            this.UnCheckALL = '<%= Resources.Resource.UnCheckALL %>';
            this.EmployeeSkillsDoesNotMatchWithRequiredSkillsDoYouWantToContinue = '<%= Resources.Resource.EmployeeSkillsDoesNotMatchWithRequiredSkillsDoYouWantToContinue %>';
            this.EmployeePayRateIsGreaterThanSaleOrderPayRateDoYouWantToContinue = '<%= Resources.Resource.EmployeePayRateIsGreaterThanSaleOrderPayRateDoYouWantToContinue %>';
            this.TimeToCannotbeleftBlank = '<%= Resources.Resource.TimeToCannotbeleftBlank %>';
            this.Employeeisbarredfromthisassignment = '<%= Resources.Resource.Employeeisbarredfromthisassignment %>';
            this.EmployeeDoesnotbelongstothisArea = '<%= Resources.Resource.EmployeeDoesnotbelongstothisArea %>';
            this.Employeedutydatecannotbegreaterthandateofresignation = '<%= Resources.Resource.Employeedutydatecannotbegreaterthandateofresignation %>';
            this.DutyDateCannotbelessthanjoiningdate = '<%= Resources.Resource.DutyDateCannotbelessthanjoiningdate %>';
            this.FollowingMandatoryskillsdoesnotmatch = '<%= Resources.Resource.FollowingMandatoryskillsdoesnotmatch %>';
            this.AuthorizedRotaCannotbeDeleted = '<%= Resources.Resource.AuthorizedRotaCannotbeDeleted %>';
            this.MsgConfirmDelete = '<%= Resources.Resource.MsgConfirmDelete %>';
            this.MsgComplimentaryDutyTypeCannotChanged = '<%= Resources.Resource.MsgComplimentaryDutyTypeCannotChanged %>';
        }

        function ControlsInitialization() {
            this.ddlMonth = $find('<%= ddlMonth.ClientID %>');
            this.txtYear = $find('<%= txtYear.ClientID %>');
            this.ddlWeek = $find('<%= ddlWeek.ClientID %>');
            <%--this.ddlWeek = $("#<%=ddlWeek.ClientID%>");
            this.ddlWeek = document.getElementById('<%= ddlWeek.ClientID %>');--%>
            this.ddlArea = $find('<%= ddlArea.ClientID %>');
            this.ddlClient = $find('<%= ddlClient.ClientID %>');
            this.ddAssignment = $find('<%= ddAssignment.ClientID %>');
            this.ddlPost = $find('<%= ddlPost.ClientID %>');
            this.btnProceed = $find('<%=btnProceed.ClientID %>');
            this.connectionKey = document.getElementById('<%= HidCon.ClientID %>');
            this.hfEmployeeSearchClientCode = document.getElementById('<%= hfEmployeeSearchClientCode.ClientID %>');
            this.hfEmployeeSearchDutyDate = document.getElementById('<%= hfEmployeeSearchDutyDate.ClientID %>');
            this.HFFromDate = document.getElementById('<%=HFFromDate.ClientID %>');
            this.HFToDate = document.getElementById('<%=HFToDate.ClientID %>');
            this.HFMultilingualFromDate = document.getElementById('<%=HFMultilingualFromDate.ClientID %>');
            this.HFMultilingualToDate = document.getElementById('<%=HFMultilingualToDate.ClientID %>');
            this.HFMaxDate = document.getElementById('<%=HFMaxDate.ClientID %>');
            this.ddlAttendanceType = $find('<%= ddlAttendanceType.ClientID %>');
            this.ddlScheduleType = $find('<%= ddlScheduleType.ClientID %>');
            this.ddlPostSearch = $find('<%= ddlPostSearch.ClientID %>');
            this.RadWindowEmployeeSearch = $find('<%= RadWindowEmployeeSearch.ClientID %>');
            this.gvScheduleRoster = document.getElementById('<%=gvScheduleRoster.ClientID %>');
            this.hfParentClientCode = document.getElementById('<%=hfParentClientCode.ClientID %>');
            this.hfParentAsmtID = document.getElementById('<%=hfParentAsmtID.ClientID %>');
            this.hfEmployeeSearchAsmtId = document.getElementById('<%= hfEmployeeSearchAsmtId.ClientID %>');
            this.divShowShiftDet = document.getElementById('divShowShiftDet');
            this.HFRowIndex = document.getElementById('<%=HFRowIndex.ClientID %>');
            this.hfParentPostCode = document.getElementById('<%=hfParentPostCode.ClientID %>');
            this.hfEmployeeSearchPostCode = document.getElementById('<%= hfEmployeeSearchPostCode.ClientID %>');
            this.RadWindowEmployeeSearch_C_txtFromDate = document.getElementById('RadWindowEmployeeSearch_C_txtFromDate');
            this.RadWindowEmployeeSearch_C_txtToDate = document.getElementById('RadWindowEmployeeSearch_C_txtToDate');
            this.hfAreaOldValue = document.getElementById('<%=hfAreaOldValue.ClientID %>');
            this.LBEmployeeList = $find('<%=LBEmployeeList.ClientID %>');
            this.hfOldWeek = document.getElementById('<% =hfOldWeek.ClientID %>');
            this.hfAreaNewValue = document.getElementById('<%=hfAreaNewValue.ClientID %>');
            this.LBShiftPatterns = document.getElementById('<% =LBShiftPatterns.ClientID %>');
            this.HFNumberOfRowsInGrid = document.getElementById('<%=HFNumberOfRowsInGrid.ClientID %>');
            this.divShift = document.getElementById('divShift');
            this.LBShift = document.getElementById('<% =LBShift.ClientID %>');
            this.search_txtEmployeeNumber = document.getElementById('search_txtEmployeeNumber');
            this.search_txtEmployeeName = document.getElementById('search_txtEmployeeName');
            this.lstBox_Employees = $find('<%=lstBox_Employees.ClientID %>');
            this.ddlEmployees = $find('<%=ddlEmployees.ClientID %>');
            this.divEmployeeList = document.getElementById('divEmployeeList');
            this.divEmployeeContainer = document.getElementById('divEmployeeContainer');
            this.MouseClickColumnID = document.getElementById('<%=MouseClickColumnID.ClientID %>');
            this.MouseClickRowID = document.getElementById('<%=MouseClickRowID.ClientID %>');
            this.HFCurrentSessionID = document.getElementById('<%=HFCurrentSessionID.ClientID %>');
            this.DivShiftPatterns = document.getElementById('DivShiftPatterns');
            this.spanConvertMessage = document.getElementById('spanConvertMessage');
            this.RadWindowConvert = $find('<%=RadWindowConvert.ClientID %>');
            this.hfSelectedGridPageCountFinal = document.getElementById('<%=hfSelectedGridPageCountFinal.ClientID %>');
            this.HFActualDutyReplacement = document.getElementById('<%=HFActualDutyReplacement.ClientID %>');
            this.spanErrorMessage = document.getElementById('spanErrorMessage');
            this.RadWindowMessage = $find('<%=RadWindowMessage.ClientID %>');
            this.btnOverWrite = document.getElementById('btnOverWrite');
            this.btnCheckAll = document.getElementById('btnCheckAll');
            this.btnUnCheckAll = document.getElementById('btnUnCheckAll');
            this.HFSoType = document.getElementById('<%= HFSoType.ClientID %>');
            this.spanEmployeeSchedule = document.getElementById('spanEmployeeSchedule');
            this.lblOldAsmtCode = document.getElementById('<%=lblOldAsmtCode.ClientID %>');
            this.hfEmployeeSearchFinishStatus = document.getElementById('<%= hfEmployeeSearchFinishStatus.ClientID %>');
            this.HFUnSchEmployeeClickStatus = document.getElementById('<%=HFUnSchEmployeeClickStatus.ClientID %>');
            this.btnUnScheduledEmp = document.getElementById('<%=btnUnScheduledEmp.ClientID %>');
            this.RadWindowBorrow = $find('<%=RadWindowBorrow.ClientID %>');
            this.btnBorrowedEmp = document.getElementById('<%=btnBorrowedEmp.ClientID %>');
            this.HFOTReason = document.getElementById('HFOTReason');
            this.RadWindowManager1 = $find("<%= RadWindowManager1.ClientID %>");
            this.RadToolTipJobBreakDown = $find('<%=RadToolTipJobBreakDown.ClientID %>');
            this.SpanjobBreakDownSummary = document.getElementById('SpanjobBreakDownSummary');
            this.spnShiftDetail = document.getElementById('spnShiftDetail');
            this.btnFillEmployee = document.getElementById('<%= btnFillEmployee.ClientID %>');
            this.txtAdjustmentHrs = document.getElementById('<%= txtAdjustmentHrs.ClientID %>');
            this.AdjType = document.getElementById('<%= AdjType.ClientID %>');
            this.txtAdjustmentRemark = document.getElementById('<%= txtAdjustmentRemark.ClientID %>');
            this.divAdjustment = document.getElementById('divAdjustment');
            this.DeleteAdjustment = document.getElementById('DeleteAdjustment');
            this.SaveAdjustment = document.getElementById('SaveAdjustment');
            this.divDutyReplacement = document.getElementById('divDutyReplacement');
            this.ddlDutyReplacement = document.getElementById('<%= ddlDutyReplacement.ClientID %>');
            this.spanLegends = document.getElementById('spanLegends');
            this.HFSOBillable = document.getElementById('HFSOBillable');
        }
        function EnableProceedButtonJS() {
            btnProceed = $find('<%=btnProceed.ClientID %>');
            btnProceed.set_enabled(true);
        }

 function SetFocusOnControl() {
try{
 document.getElementById(controlFocus).focus();
}
catch(err){}
return false;

}
    </script>
</body>
</html>
