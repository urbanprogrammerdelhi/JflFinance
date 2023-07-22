<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SystemParameter.aspx.cs" Inherits="Masters_SystemParameter"  Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="EmpDetails"
                ActiveTabIndex="0" AutoPostBack="false">
                <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelEmployeeDetails" runat="server"
                    HeaderText="Schedule" TabIndex="0">
                    <HeaderTemplate>
                        Schedule
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table width="750px" border="0">
                            <tr>
                                <td align="right" style="width: 280px;">
                                    <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, AttendanceScreenType%>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAttendanceType" AutoPostBack="True" Width="150px" runat="server"
                                        CssClass="cssDropDown" OnSelectedIndexChanged="ddlAttendanceType_SelectedIndexChanged">
                                         <asp:ListItem Text="<%$Resources:Resource, Select%>" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource, Weekly%>" Value="Weekly"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource, Fortnightly%>" Value="Fortnightly"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource, Monthly%>" Value="Monthly"></asp:ListItem>
                                        <%--<asp:ListItem Text="DateRange" Value="Date"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <asp:Panel ID="PanelControls" runat="server" Visible="False">
                                <tr>
                                    <td align="right">
                                    </td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="RBLWeekly" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RBLWeekly_SelectedIndexChanged">
                                            <asp:ListItem Text="<%$Resources:Resource, WeekDay%>" Value="WeekDay"></asp:ListItem>
                                            <asp:ListItem Text="<%$Resources:Resource, Day%>" Value="Day"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <asp:Panel ID="panelWeekStartDay" Visible="false" runat="server">
                                        <td align="right">
                                            <asp:Label ID="lblWeekStartDay" runat="server" CssClass="cssLabel"  Text="<%$Resources:Resource, WeekStartDay%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlWeekStartDay" runat="server" CssClass="cssDropDownSmall"
                                                Width="100px">
                                                <asp:ListItem Text="<%$Resources:Resource, Sunday%>" Value="Sunday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Monday%>" Value="Monday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Tuesday%>" Value="Tuesday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Wednesday%>" Value="Wednesday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Thursday%>" Value="Thursday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Friday%>" Value="Friday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Saturday%>" Value="Saturday"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelWeekEndDay" Visible="false" runat="server">
                                        <td align="right">
                                            <asp:Label ID="lblWeekEndDay" runat="server" CssClass="cssLabel"  Text="<%$Resources:Resource, WeekEndDay%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlWeekEndDay" runat="server" CssClass="cssDropDownSmall" Width="100px">
                                               <asp:ListItem Text="<%$Resources:Resource, Sunday%>" Value="Sunday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Monday%>" Value="Monday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Tuesday%>" Value="Tuesday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Wednesday%>" Value="Wednesday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Thursday%>" Value="Thursday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Friday%>" Value="Friday"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Saturday%>" Value="Saturday"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelFortnight" Visible="false" runat="server">
                                        <td align="right">
                                            <asp:Label ID="lblStartDay" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, StartDay%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStartDay" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblDaysInFirstFortnight" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, NoofDaysInFirstFortnight%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                        <asp:DropDownList ID="ddlNoOfDayInFirstFortnight" Width="50px" runat="server" CssClass="cssDropDown">
                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                        </asp:DropDownList>
                                            <%--<asp:TextBox ID="txtNoOfDayInFirstFortnight" runat="server" CssClass="csstxtbox"></asp:TextBox>--%>
                                        </td>
                                    </asp:Panel>
                                </tr>
                                <asp:Panel ID="panelmonthly" Visible="false" runat="server">
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="RBLMonthly" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RBLMonthly_SelectedIndexChanged">
                                                <asp:ListItem Text="<%$Resources:Resource, PayPeriod%>" Value="PayPeriod"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, ManualPeriod%>" Value="ManualPeriod"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, FromDay%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFromDay" CssClass="cssDropDown" runat="server">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                                <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                                <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                                <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                                <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                                <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                                <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, ToDay%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlToDay" CssClass="cssDropDown" runat="server">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                                <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                                <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                                <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                                <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                                <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                                <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="paneldateRange" runat="server">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, FromDate%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="True" CssClass="csstxtboxRequired"
                                                OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                            <asp:ImageButton ID="IMGFromDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                Format="dd-MMM-yyyy" PopupButtonID="IMGFromDate" TargetControlID="txtFromDate">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, ToDate%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="True" CssClass="csstxtboxRequired"
                                                OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                            <asp:ImageButton ID="IMGToDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                Format="dd-MMM-yyyy" PopupButtonID="IMGToDate" TargetControlID="txtToDate">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label9" runat="server" CssClass="cssLabel"  Text="<%$Resources:Resource, MaxHoursinaWeek%>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMaxHoursInWeek" runat="server" CssClass="csstxtboxRequired"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RFVHrsinWeek" runat="server" ControlToValidate="txtMaxHoursInWeek"
                                            ErrorMessage="*" Text="*" SetFocusOnError="true" ValidationGroup="VGSave"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label10" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, MaxHoursinaMonth%>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMaxHoursInMonth" runat="server" CssClass="csstxtboxRequired"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMaxHoursInMonth"
                                            ErrorMessage="*" Text="*" SetFocusOnError="true" ValidationGroup="VGSave"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, MaxdutyMininaday%>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMaxDutyMinInDay" runat="server" CssClass="csstxtboxRequired"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaxDutyMinInDay"
                                            ErrorMessage="*" Text="*" SetFocusOnError="true" ValidationGroup="VGSave"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label11" runat="server" CssClass="cssLabel"  Text="<%$Resources:Resource, MinbreakbetweenconsecutiveDuty%>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMinBreakBtwDuty" runat="server" CssClass="csstxtboxRequired"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMinBreakBtwDuty"
                                            ErrorMessage="*" Text="*" SetFocusOnError="true" ValidationGroup="VGSave"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" CssClass="cssLabel"  Text="<%$Resources:Resource, ApplyPatternType%>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlApplyPatternType" Width="150px" runat="server" CssClass="cssDropDown">
                                           <asp:ListItem Text="<%$Resources:Resource, Weekly%>" Value="Weekly"></asp:ListItem>
                                            <asp:ListItem Text="<%$Resources:Resource, Fortnightly%>" Value="Fortnightly"></asp:ListItem>
                                            <asp:ListItem Text="<%$Resources:Resource, Monthly%>" Value="Monthly"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnSave" runat="server" CssClass="cssButton" OnClick="btnSave_OnClick"
                                            ValidationGroup="VGSave" Text="<%$Resources:Resource, Save%>"/>
                                    </td>
                                     <td align="left">
                                        <asp:Button ID="btnLoadDefault" runat="server" CssClass="cssButton" OnClick="btnLoadDefault_OnClick"
                                           Text="<%$Resources:Resource, DefaultParameters%>" />
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                    </ContentTemplate>
                </AjaxToolKit:TabPanel>
            </AjaxToolKit:TabContainer>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
