<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_ScheduleKenya.aspx.cs" Inherits="Transactions_RptGroup_ScheduleKenya"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="600px" GroupingText="<%$Resources:Resource,Schedules %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                        <ContentTemplate>
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
                            <asp:Panel ID="PanelAreaIncharge" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label20" runat="server" Text="<%$Resources:Resource,AreaIncharge %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlAreaIncharge" runat="server" Width="300" CssClass="cssDropDown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label21" runat="server" Text="<%$Resources:Resource,Blank %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox runat="server" ID="txtBlankRows" CssClass="csstxtbox"></asp:TextBox>
                                            <asp:RegularExpressionValidator ControlToValidate="txtBlankRows" ID="vldBlankRows"
                                                runat="server" SetFocusOnError="true" ValidationExpression="^[0-9]*$" ErrorMessage="*">
                                            </asp:RegularExpressionValidator>
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
                                            <asp:DropDownList ID="DDLShiftCode" Width="300" runat="server" OnSelectedIndexChanged="DDLShiftCode_SelectedIndexChanged"
                                                AutoPostBack="true" CssClass="cssDropDown">
                                            </asp:DropDownList>
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
                                            <asp:DropDownList ID="ddlRptType" CssClass="cssDropDown" Style="width: 300px;" runat="server">
                                                <asp:ListItem Text="<%$Resources:Resource,Schedule %>" Value="Sch"></asp:ListItem>
                                                <%--<asp:ListItem Text="<%$Resources:Resource,AllPostWithSchedule %>" Value="SchDep"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource,AllPostWithoutSchedule %>" Value="Dep"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource,Actual %>" Value="Act"></asp:ListItem>--%>
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
                            <asp:Panel ID="PanelAreaID" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label2" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaID %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="150px" ID="DDLAreaID"
                                                runat="server" OnSelectedIndexChanged="DDLAreaID_SelectedIndexChanged">
                                            </asp:DropDownList>
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
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlEmployeeNumber" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                                                Width="350px">
                                            </asp:DropDownList>
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
                                            <asp:DropDownList ID="DDLAType" runat="server" Width="300" CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$Resources:Resource,Forward %>" Value="Forward"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource,Backward %>" Value="Backward"></asp:ListItem>
                                            </asp:DropDownList>
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
                                            <asp:DropDownList ID="ddlOption" Width="350" CssClass="cssDropDown" runat="server">
                                                <asp:ListItem Value="Scheduled" Text="<%$ Resources:Resource, Scheduled %>"></asp:ListItem>
                                                <asp:ListItem Selected="True" Text="<%$ Resources:Resource, Actual %>" Value="Actual"> </asp:ListItem>
                                            </asp:DropDownList>
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
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                                Width="350px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                            </asp:DropDownList>
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
                                            <asp:DropDownList ID="ddlBranch" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                                                runat="server" CssClass="cssDropDown" Width="350px">
                                            </asp:DropDownList>
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
                                            <asp:DropDownList ID="ddlReporttype" runat="server" CssClass="cssDropDown" Width="350px">
                                                <asp:ListItem Selected="True" Value="All" Text="All Mismatches"></asp:ListItem>
                                                <asp:ListItem Value="SchAttendMismatch" Text="Schedule  Attended Mismatch"></asp:ListItem>
                                                <asp:ListItem Value="SchNotAttend" Text="Schedule - Not Attended "></asp:ListItem>
                                                <asp:ListItem Value="NotSchAttend" Text="Not Schedule - Attended "></asp:ListItem>
                                                <asp:ListItem Value="ShiftMismatch" Text="Shift Mismatch "></asp:ListItem>
                                                <asp:ListItem Value="TimeMismatch" Text="Time Mismatch "></asp:ListItem>
                                            </asp:DropDownList>
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
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlClientCode" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                                Width="350px" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAsmt" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblAsmtID" runat="server" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlAsmtCode" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlAsmtCode_OnSelectedIndexChanged"
                                                CssClass="cssDropDown" Width="350px">
                                            </asp:DropDownList>
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
                            <asp:Panel ID="PanelShift" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblfixSOType" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, Shift %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList CssClass="cssDropDown" Width="150px" ID="ddlShift" runat="server">
                                            </asp:DropDownList>
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
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txtDayStartTime"
                                                Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator14" runat="server" ControlExtender="MaskedEditExtender1"
                                                ControlToValidate="txtDayStartTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                SetFocusOnError="true" Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd"
                                                ErrorMessage="MaskedEditValidator1" CssClass="csslblErrMsg" />
                                        </td>
                                        <td align="left" style="width: 135px">
                                            <asp:Label ID="lblDayEndTime" runat="server" Text="Ends at" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDayEndTime" MaxLength="5" CssClass="csstxtbox" Width="50px" runat="server"
                                                Text="17:59" />
                                              <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDayEndTime"
                                                Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                ControlToValidate="txtDayEndTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                SetFocusOnError="true" Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd"
                                                ErrorMessage="MaskedEditValidator1" CssClass="csslblErrMsg" />
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
                                             <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtNightStartTime"
                                                Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender1"
                                                ControlToValidate="txtNightStartTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                SetFocusOnError="true" Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd"
                                                ErrorMessage="MaskedEditValidator1" CssClass="csslblErrMsg" />
                                        </td>
                                        <td align="left" style="width: 135px">
                                            <asp:Label ID="lblNightEndTime" runat="server" Text="Ends at" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNightEndTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                                runat="server" Text="05:59" />
                                             <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtNightEndTime"
                                                Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender1"
                                                ControlToValidate="txtNightEndTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                SetFocusOnError="true" Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd"
                                                ErrorMessage="MaskedEditValidator1" CssClass="csslblErrMsg" />
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
                            <asp:Panel ID="pnlShiftType" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblShiftType" runat="server" Text="Shift Type" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 100px" colspan="3">
                                            <asp:DropDownList ID="ddlShiftType" runat="server" CssClass="cssDropDown">
                                                <asp:ListItem Text="Day" Value="D"></asp:ListItem>
                                                <asp:ListItem Text="Night" Value="N"></asp:ListItem>
                                            </asp:DropDownList>
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
                            <asp:Panel ID="PanelGropOnShift" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblShiftGrouping" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, ShiftGrouping %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:CheckBox ID="chkShiftGroping" runat="server" CssClass="cssCheckBox" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelGroupOnPost" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblPostGrouping" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, PostGrouping %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:CheckBox ID="chkPostGroping" runat="server" CssClass="cssCheckBox" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="center" style="width: 400px" colspan="3">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="width: 400px" align="center">
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
