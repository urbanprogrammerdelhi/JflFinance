<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_Training.aspx.cs" Inherits="RptGroup_Training" Title="<%$ Resources:Resource, AppTitle %>" %>

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
                            <asp:Panel ID="PanelDivision" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Resource, HrLocation %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlDivision" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlDivisionName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlDivisionName_SelectedIndexChanged">
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
                                            <telerik:RadComboBox ID="ddlBranch" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlBranchName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlBranchName_SelectedIndexChanged">
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
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlAreaInchargeCode" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaInchargeCode_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlAreaInchargeName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaInchargeName_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAreaID" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label2" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaID %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="DDLAreaID" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="DDLAreaID_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlAreaName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaName_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelEmployee" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlEmployeeNumber" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlEmployeeNumber_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlEmployeeName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlEmployeeName_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelHours" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label14" runat="server" Text="<%$ Resources:Resource, Hours %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td style="text-align: justify;" align="left">
                                            <asp:TextBox ID="txtHours" MaxLength="3" runat="server" Text="" CssClass="csstxtbox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHours"
                                                ErrorMessage="<%$ Resources:Resource, CannotBeLeftBlank %>" ValidationGroup="Amend"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelLAType" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label16" runat="server" Text="<%$Resources:Resource,AvailibiltyType %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="DDLAType" runat="server" Width="150px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,Forward %>" Value="Forward" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,Backward %>" Value="Backward" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <%--<asp:DropDownList ID="DDLAType" runat="server" Width="300" CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$Resources:Resource,Forward %>" Value="Forward"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource,Backward %>" Value="Backward"></asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelShiftCode" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label17" runat="server" Text="<%$Resources:Resource,ShiftCode %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="DDLShiftCode" runat="server" Width="250px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="DDLShiftCode_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelOption" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label15" runat="server" Text="<%$ Resources:Resource, Option %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlOption" runat="server" Width="150px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Selected="true" Text="<%$Resources:Resource,Scheduled %>"
                                                        Value="Scheduled" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,Actual %>" Value="Actual" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelScheduleType" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Resource, Type %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlReporttype" runat="server" MaxHeight="350px" Height="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Selected="True" Value="All" Text="All Mismatches"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="SchAttendMismatch" Text="Schedule  Attended Mismatch">
                                                    </telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="SchNotAttend" Text="Schedule - Not Attended "></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="NotSchAttend" Text="Not Schedule - Attended "></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ShiftMismatch" Text="Shift Mismatch "></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="TimeMismatch" Text="Time Mismatch "></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelClientCode" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlClientCode" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlClientName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAsmt" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlAsmtCode" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAsmtCode_OnSelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlAsmtName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAsmtName_OnSelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelTraining" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="LabelTraining" runat="server" Text="<%$ Resources:Resource, Training %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlTrainingCode" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlTrainingCode_OnSelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlTrainingName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlTrainingName_OnSelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelClientDetail" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="DDLClientDetail" AutoPostBack="True" runat="server" CssClass="cssDropDown"
                                                Width="350px" OnSelectedIndexChanged="DDLClientDetail_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAsmtId" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="DDLAsmtID" AutoPostBack="True" runat="server" CssClass="cssDropDown"
                                                Width="350px" OnSelectedIndexChanged="DDLAsmtID_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelMonth" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label20" runat="server" Text="<%$Resources:Resource,MonthYear %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlMonth" runat="server" Width="350px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,January %>" Value="1" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,February %>" Value="2" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,March %>" Value="3" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,April %>" Value="4" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,May %>" Value="5" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,June %>" Value="6" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,July %>" Value="7" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,August %>" Value="8" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,September %>" Value="9" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,October %>" Value="10" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,November %>" Value="11" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,December %>" Value="12" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <asp:TextBox ID="txtYear" runat="server" CssClass="csstxtboxSmall" Text="" MaxLength="4"
                                                Width="30"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="ForNextNDays" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="LabForNextNDays" runat="server" Text="<%$Resources:Resource,ForNextNDays %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:TextBox ID="txtForNextNDays" runat="server" CssClass="csstxtboxSmall" Text=""
                                                MaxLength="2" Width="30"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelShift" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblfixSOType" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, Shift %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlShift" runat="server" Width="250px" MaxHeight="350px"
                                                Filter="StartsWith">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelSource" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="lblRptType" runat="server" Text="<%$Resources:Resource,Source %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlRptType" runat="server" Width="350px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,Schedule %>" Value="Sch" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,AllPostWithSchedule %>" Value="SchDep" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,AllPostWithoutSchedule %>" Value="Dep" />
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
                            <asp:Panel ID="PanelAsOnDate" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label runat="server" ID="label4" CssClass="cssLable" Text="<%$ Resources:Resource, DutyDate %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:TextBox ID="txtAsOnDate" OnTextChanged="txtAsOnDate_TextChanged" AutoPostBack="true"
                                                runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            <asp:HyperLink ID="ImgAsOnDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtAsOnDate" PopupButtonID="ImgAsOnDate">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelPost" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label19" runat="server" Text="<%$Resources:Resource,Post %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DDLPost" Width="300" runat="server" AutoPostBack="true" CssClass="cssDropDown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelDayShift" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblDayStartTime" runat="server" Text="Day Shift Starts From" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 150px">
                                            <asp:TextBox ID="txtDayStartTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                                runat="server" Text="06:00" />
                                        </td>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblDayEndTime" runat="server" Text="Ends at" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDayEndTime" MaxLength="5" CssClass="csstxtbox" Width="50px" runat="server"
                                                Text="17:59" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelNightShift" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblNightStartTime" runat="server" Text="Night Shift Starts From" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 150px">
                                            <asp:TextBox ID="txtNightStartTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                                runat="server" Text="18:00" />
                                        </td>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblNightEndTime" runat="server" Text="Ends at" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNightEndTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                                runat="server" Text="05:59" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelShiftTimeFromTo" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblTimeFrom" runat="server" Text="Shift Starts From" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 100px">
                                            <asp:TextBox ID="TxtTimeFrom" MaxLength="5" CssClass="csstxtbox" Width="50px" runat="server"
                                                Text='<%# Bind("TimeFrom") %>' />
                                        </td>
                                        <td align="right" style="width: 150px">
                                            <asp:Label ID="lblTimeTo" runat="server" Text="Ends at" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TxtTimeTo" MaxLength="5" CssClass="csstxtbox" Width="50px" runat="server"
                                                Text='<%# Bind("TimeTo") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelRosterOrSchedule" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblRosterOrSchedule" runat="server" Text="Actual / Schedule" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlRosterOrSchedule" runat="server" Width="350px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,Actual %>" Value="Actual" />
                                                    <telerik:RadComboBoxItem Selected="true" Text="<%$Resources:Resource,Schedule %>"
                                                        Value="Schedule" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelOptAvailPersonnel" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label18" runat="server" Text="<%$ Resources:Resource, Type %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlOptionAvailPersonnel" runat="server" CssClass="cssDropDown"
                                                Width="350px">
                                                <asp:ListItem Selected="True" Value="0" Text="S/O with < 60 hrs"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="S/O with duties ending 8 hrs before requested shift"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="officers starting 2 hrs after requested shift and onwards up to 12 hrs"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelReportGrid" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="LabelReportGrid" runat="server" Text="<%$Resources:Resource, Output %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <telerik:RadComboBox ID="ddlReportGrid" runat="server" Width="350px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Selected="True" Text="<%$Resources:Resource,Report %>" Value="Report" />
                                                    <telerik:RadComboBoxItem Text="<%$Resources:Resource,Grid %>" Value="Grid" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <%--Manish For YLM report--%>
                              <asp:Panel ID="PanelAttendanceType" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label21" runat="server" Text="<%$Resources:Resource, AttendanceType %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                                        <telerik:RadComboBox ID="ddlAttendanceType" runat="server" Width="250px" MaxHeight="350px" Filter="StartsWith">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="<%$ Resources:Resource, All%>" Value="0" />
                                                                <telerik:RadComboBoxItem Text="Matched" Value="1" />
                                                                <telerik:RadComboBoxItem Text="Un-Matched" Value="2" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                    </tr>
                                </table>
                            </asp:Panel>


                              <%-- 27-11-2012 Manish For Grouping on  report--%>
                              <asp:Panel ID="pnlEmpGrouping" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblEmpGrp" runat="server" Text="<%$Resources:Resource, PageWiseEmployeeGrouping %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                                        <asp:CheckBox ID="chkEmpGroping" runat="server"   CssClass="cssCheckBox" />
                                                        
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
                                        CssClass="cssButton" OnClick="btnViewReport_Click" />
                                    <asp:Button ID="Button1" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>"
                                        CssClass="cssButton" OnClick="btnExport_Click"/>
                                </td>
                                <%--<td align="left" style="width: 400px">
                                    <asp:Button ID="btnExport" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>"
                                        CssClass="cssButton" OnClick="btnExport_Click"/>
                                </td>--%>
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
</asp:Content>