<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyCaping.aspx.cs" Inherits="UserManagement_DutyCaping" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="script" runat="server">
        </asp:ScriptManager>
        <Ajax:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView Width="100%" ID="CappingHeader" CssClass="GridViewStyle" runat="server"
                                ShowFooter="True" AllowPaging="True" PageSize="7" CellPadding="1" GridLines="None"
                                AutoGenerateColumns="False" AllowSorting="false" OnRowCommand="CappingHeader_RowCommand"
                                OnRowDataBound="CappingHeader_RowDataBound" OnPageIndexChanging="CappingHeader_PageIndexChanging"
                                OnRowCancelingEdit="CappingHeader_RowCancelingEdit" OnRowDeleting="CappingHeader_RowDeleting"
                                OnRowEditing="CappingHeader_RowEditing" OnRowUpdating="CappingHeader_RowUpdating">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>" HeaderStyle-Width="5%">
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                CssClass="csslnkButton" runat="server" CommandName="Update" />
                                            <asp:ImageButton ID="ImageButton2" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                CssClass="cssImgButton" ValidationGroup="Save" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                            &nbsp;
                                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                            &nbsp;
                                            <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,CappingCode %>" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="CappingHeaderCode" Width="98%" runat="server" OnClick="CappingHeaderCode_Click"
                                                CssClass="csslnkButton" Text='<%# Bind("CappingRuleCode") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="CappingHeaderCode" ValidationGroup="Save" Width="98%" runat="server"
                                                CssClass="csstxtbox"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,CappingDescription %>" HeaderStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingHeaderDescription1" Width="98%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("CappingRuleDescription") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="CappingHeaderDescription" Width="98%" runat="server" CssClass="csstxtbox"
                                                Text='<%# Bind("CappingRuleDescription") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="CappingHeaderDescription" ValidationGroup="Save" Width="98%" runat="server"
                                                CssClass="csstxtbox"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,CappingLevel %>" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingHeaderLevel" Width="98%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("CappingRuleLevel") %>'></asp:Label>
                                            <asp:HiddenField ID="hfCappingHeaderLevel" runat="server" Value='<%# Bind("CappingRuleLevel") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="CappingHeaderLevel" Width="98%" AutoPostBack="true" OnSelectedIndexChanged="CappingHeaderLevel_SelectedIndexChanged"
                                                runat="server" CssClass="cssDropDown">
                                                <asp:ListItem Text="User" Value="U" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="User Group" Value="UG"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,CappingLevelDesc %>" HeaderStyle-Width="98%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingHeaderLevelDesc1" runat="server" Width="98%" CssClass="cssLabel"
                                                Text='<%# Bind("CappingRuleLevelDescription") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox ID="CappingHeaderLevelDesc" runat="server" Width="98%" CheckBoxes="true"
                                                EnableCheckAllItemsCheckBox="true">
                                            </telerik:RadComboBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <telerik:RadComboBox ID="CappingHeaderLevelDesc" runat="server" Width="98%" CheckBoxes="true"
                                                EnableCheckAllItemsCheckBox="true">
                                            </telerik:RadComboBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView Width="100%" Visible="false" ID="CappingDetail" CssClass="GridViewStyle"
                                runat="server" ShowFooter="True" AllowPaging="True" PageSize="7" CellPadding="1"
                                GridLines="None" AutoGenerateColumns="False" AllowSorting="false" OnRowCommand="CappingDetail_RowCommand"
                                OnRowDataBound="CappingDetail_RowDataBound" OnPageIndexChanging="CappingDetail_PageIndexChanging"
                                OnRowCancelingEdit="CappingDetail_RowCancelingEdit" OnRowDeleting="CappingDetail_RowDeleting"
                                OnRowEditing="CappingDetail_RowEditing" OnRowUpdating="CappingDetail_RowUpdating">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>" HeaderStyle-Width="5%">
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                CssClass="csslnkButton" runat="server" CommandName="Update" />
                                            <asp:ImageButton ID="ImageButton2" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                CssClass="cssImgButton" ValidationGroup="Save" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                            &nbsp;
                                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                            &nbsp;
                                            <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,CappingCode %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingHeaderCode" Width="98%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("CappingRuleCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="CappingHeaderCode" Width="98%" runat="server" CssClass="cssLabel"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ContractDays %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailContractDays1" Width="98%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("ContractDays") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="CappingDetailContractDays" Width="98%" Enabled="False" runat="server" CssClass="cssDropDown">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="HFCappingDetailContractDays" runat="server" Value='<%# Bind("ContractDays") %>' />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="CappingDetailContractDays" Width="98%" runat="server" CssClass="cssDropDown">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,AttendanceType %>" HeaderStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailAttendanceType1" Width="98%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("AttendanceType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="HFCappingDetailAttendanceType" runat="server" Value='<%# Bind("AttendanceType") %>' />
                                            <asp:DropDownList ID="CappingDetailAttendanceType"  Enabled="False" Width="98%" runat="server" CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$ Resources:Resource, Schedule %>" Value="Sch"></asp:ListItem>
                                                <asp:ListItem Text="<%$ Resources:Resource, Actual %>" Value="Act"></asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="CappingDetailAttendanceType" Width="98%" runat="server" CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$ Resources:Resource, Schedule %>" Value="Sch"></asp:ListItem>
                                                <asp:ListItem Text="<%$ Resources:Resource, Actual %>" Value="Act"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,MaxNumberOfHoursPerDay %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailMaxNumberOfHoursPerDay" Width="60%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("MaxNumberOfHoursPerDay") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="CappingDetailMaxNumberOfHoursPerDay" Text='<%# Bind("MaxNumberOfHoursPerDay") %>'
                                                Width="60%" runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender311" runat="server" TargetControlID="CappingDetailMaxNumberOfHoursPerDay"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%--<AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator311" runat="server" ControlExtender="MaskedEditExtender311"
                                                ControlToValidate="CappingDetailMaxNumberOfHoursPerDay" IsValidEmpty="true" Display="Dynamic"
                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="CappingDetailMaxNumberOfHoursPerDay" ValidationGroup="Save" Width="60%"
                                                runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender39" runat="server" TargetControlID="CappingDetailMaxNumberOfHoursPerDay"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator39" runat="server" ControlExtender="MaskedEditExtender39"
                                                ControlToValidate="CappingDetailMaxNumberOfHoursPerDay" IsValidEmpty="true" Display="Dynamic"
                                                EmptyValueBlurredText="*" ValidationGroup="Save" InvalidValueBlurredMessage="*" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,BreakBetweenShift %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailBreakBetweenShift" Width="60%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("BreakBetweenShift") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="CappingDetailBreakBetweenShift" Text='<%# Bind("BreakBetweenShift") %>'
                                                Width="60%" runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender38" runat="server" TargetControlID="CappingDetailBreakBetweenShift"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator38" runat="server" ControlExtender="MaskedEditExtender38"
                                                ControlToValidate="CappingDetailBreakBetweenShift" IsValidEmpty="true" Display="Dynamic"
                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="CappingDetailBreakBetweenShift" ValidationGroup="Save" Width="60%"
                                                runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender37" runat="server" TargetControlID="CappingDetailBreakBetweenShift"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator37" runat="server" ControlExtender="MaskedEditExtender37"
                                                ControlToValidate="CappingDetailBreakBetweenShift" ValidationGroup="Save" IsValidEmpty="true"
                                                Display="Dynamic" EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,MaxWorkingDaysInWeek %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailMaxWorkingDaysInWeek1" Width="98%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("MaxWorkingDaysInWeek") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="CappingDetailMaxWorkingDaysInWeek" Width="98%" runat="server"
                                                CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$Resources:Resource,Select %>" Value=""></asp:ListItem>
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="HFCappingDetailMaxWorkingDaysInWeek" runat="server" Value='<%# Bind("MaxWorkingDaysInWeek") %>' />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="CappingDetailMaxWorkingDaysInWeek" Width="98%" runat="server"
                                                CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$Resources:Resource,Select %>" Value=""></asp:ListItem>
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,MaxNightShiftInWeek %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailMaxNightShiftInWeek1" Width="98%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("MaxNightShiftInWeek") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="CappingDetailMaxNightShiftInWeek" Width="98%" runat="server"
                                                CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$Resources:Resource,Select %>" Value=""></asp:ListItem>
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="HFCappingDetailMaxNightShiftInWeek" runat="server" Value='<%# Bind("MaxNightShiftInWeek") %>' />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="CappingDetailMaxNightShiftInWeek" Width="98%" runat="server"
                                                CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$Resources:Resource,Select %>" Value=""></asp:ListItem>
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,MaxWeekHours %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailMaxWeekHours" Width="98%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("MaxWeekHours") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="CappingDetailMaxWeekHours" Text='<%# Bind("MaxWeekHours") %>' Width="60%"
                                                runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender36" runat="server" TargetControlID="CappingDetailMaxWeekHours"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator36" runat="server" ControlExtender="MaskedEditExtender36"
                                                ControlToValidate="CappingDetailMaxWeekHours" IsValidEmpty="true" Display="Dynamic"
                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="CappingDetailMaxWeekHours" ValidationGroup="Save" Width="60%" runat="server"
                                                CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender35" runat="server" TargetControlID="CappingDetailMaxWeekHours"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator35" ValidationGroup="Save"
                                                runat="server" ControlExtender="MaskedEditExtender35" ControlToValidate="CappingDetailMaxWeekHours"
                                                IsValidEmpty="true" Display="Dynamic" EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,WeeklyRest %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailWeeklyRest" Width="60%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("WeeklyRest") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="CappingDetailWeeklyRest" Text='<%# Bind("WeeklyRest") %>' Width="60%"
                                                runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender34" runat="server" TargetControlID="CappingDetailWeeklyRest"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator34" runat="server" ControlExtender="MaskedEditExtender34"
                                                ControlToValidate="CappingDetailWeeklyRest" IsValidEmpty="true" Display="Dynamic"
                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="CappingDetailWeeklyRest" Width="60%" runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender33" runat="server" TargetControlID="CappingDetailWeeklyRest"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%--  <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator33" ValidationGroup="Save"
                                                runat="server" ControlExtender="MaskedEditExtender33" ControlToValidate="CappingDetailWeeklyRest"
                                                IsValidEmpty="true" Display="Dynamic" EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,MaxHoursInShift %>" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="CappingDetailGapBetweenTwoShifts" Width="60%" runat="server" CssClass="cssLabel"
                                                Text='<%# Bind("MaxHoursInShift") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="CappingDetailMaxHoursInShift" Text='<%# Bind("MaxHoursInShift") %>'
                                                Width="60%" runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender32" runat="server" TargetControlID="CappingDetailMaxHoursInShift"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator32" runat="server" ControlExtender="MaskedEditExtender32"
                                                ControlToValidate="CappingDetailGapBetweenTwoShifts" IsValidEmpty="true" Display="Dynamic"
                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="CappingDetailMaxHoursInShift" ValidationGroup="Save" Width="60%"
                                                runat="server" CssClass="csstxtbox">
                                            </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender31" runat="server" TargetControlID="CappingDetailMaxHoursInShift"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator31" ValidationGroup="Save"
                                                runat="server" ControlExtender="MaskedEditExtender31" ControlToValidate="CappingDetailGapBetweenTwoShifts"
                                                IsValidEmpty="true" Display="Dynamic" EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,DisableProfitabilityCheck %>"
                                        HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProfitability" Width="98%" runat="server" CssClass="cssLabel"></asp:Label>
                                            <asp:HiddenField ID="HFProfitabilityCheck" runat="server" Value='<%# Bind("ProfitabilityCheck") %>'/>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlProfitability" Width="98%" runat="server" CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$Resources:Resource,Yes %>" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource,No %>"  Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            
                                            <asp:HiddenField ID="HFProfitabilityCheck" runat="server" Value='<%# Bind("ProfitabilityCheck") %>'/>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlProfitability" Width="98%" runat="server" CssClass="cssDropDown">
                                                <asp:ListItem Text="<%$Resources:Resource,Yes %>" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource,No %>" Selected="True" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:HiddenField ID="HFCappingCode" runat="server" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </Ajax:UpdatePanel>
    </div>
    </form>
</body>
</html>
