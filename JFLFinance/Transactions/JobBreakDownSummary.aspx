<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobBreakDownSummary.aspx.cs"
    Inherits="Transactions_JobBreakDownSummary" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script language="javascript" src="../javaScript/ScheduleRosterNew.js" type="text/javascript"></script>
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Ajax:ScriptManager ID="script" runat="server">
        </Ajax:ScriptManager>
        <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
            <ContentTemplate>
                <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="EmpDetails"
                    ActiveTabIndex="0">
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPanelBreakHrs" runat="server"
                        HeaderText="<%$Resources:Resource,BreakHours %>" TabIndex="0">
                        <ContentTemplate>
                            <asp:Panel ID="PanelSchEmpDetail" runat="server" GroupingText="<%$ Resources:Resource,EmployeeDetail %>">
                                <table width="700px" border="0">
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblEmployeeNumber" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label13" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblEmployeeName" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,DutyDate %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDutyDate" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Time %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblFromTime" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                            <asp:Label ID="lblToTime" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                            <asp:HiddenField ID="HFIsConverted" runat="server" />
                                              <asp:HiddenField ID="hfMaxBreakHours" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <asp:Label ID="lblBreakHrsErrorMsg" CssClass="csslblErrMsg" EnableViewState="False"
                                                runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelBreakHrsGridDetails" runat="server" GroupingText="<%$ Resources:Resource,EmployeeDetail %>">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView Width="700px" ID="gvBreakHrsDetails" CssClass="GridViewStyle" runat="server"
                                                ShowFooter="True" AllowPaging="True" PageSize="15" CellPadding="1" GridLines="None"
                                                AutoGenerateColumns="False" OnRowCommand="GvBreakHrsDetails_RowCommand" OnRowDataBound="GvBreakHrsDetails_RowDataBound"
                                                OnRowUpdating="GvBreakHrsDetails_RowUpdating" OnPageIndexChanging="GvBreakHrsDetails_PageIndexChanging"
                                                OnRowCancelingEdit="GvBreakHrsDetails_RowCancelingEdit" OnRowDeleting="GvBreakHrsDetails_RowDeleting"
                                                OnRowEditing="GvBreakHrsDetails_RowEditing" OnSorting="gvBreakHrsDetails_Sorting">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                        <EditItemTemplate>
                                                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                                CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImageButton2" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                CssClass="cssImgButton" ValidationGroup="AddJob" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                        </FooterTemplate>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                CssClass="csslnkButton" ValidationGroup="JobEdit" runat="server" CausesValidation="False"
                                                                CommandName="Edit" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                        </ItemTemplate>
                                                        <FooterStyle Width="100px" />
                                                        <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeNumberRep1" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeNumberReg") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblEmployeeNumberRep1" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeNumberReg") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblEmployeeNumberRep1" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeNumberReg") %>'></asp:Label>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="150px" />
                                                        <ItemStyle Width="150px" />
                                                        <HeaderStyle Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,FromTime %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeFrom" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:HH:mm}", Eval("TimeFrom"))%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeFrom" ValidationGroup="JobEdit" CssClass="csstxtbox" Width="60px"
                                                                runat="server" Text='<%# String.Format("{0:HH:mm}", Eval("TimeFrom"))%>'></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender34" runat="server" TargetControlID="txtTimeFrom"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator34" runat="server" ControlExtender="MaskedEditExtender34"
                                                                ControlToValidate="txtTimeFrom" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="JobEdit" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFooterTimeFrom" ValidationGroup="AddJob" CssClass="csstxtbox"
                                                                Width="60px" runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender341" runat="server" TargetControlID="txtFooterTimeFrom"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator341" runat="server" ControlExtender="MaskedEditExtender341"
                                                                ControlToValidate="txtFooterTimeFrom" IsValidEmpty="False" Display="Dynamic"
                                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="AddJob" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="80px" />
                                                        <ItemStyle Width="80px" />
                                                        <HeaderStyle Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ToTime %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeTo" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:HH:mm}", Eval("TimeTo"))%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeTo" CssClass="csstxtbox" ValidationGroup="JobEdit" Width="60px"
                                                                runat="server" Text='<%# String.Format("{0:HH:mm}", Eval("TimeTo"))%>'></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender342" runat="server" TargetControlID="txtTimeTo"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator342" runat="server" ControlExtender="MaskedEditExtender342"
                                                                ControlToValidate="txtTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="JobEdit" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFooterTimeTo" ValidationGroup="AddJob" CssClass="csstxtbox" Width="60px"
                                                                runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender343" runat="server" TargetControlID="txtFooterTimeTo"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator343" runat="server" ControlExtender="MaskedEditExtender343"
                                                                ControlToValidate="txtFooterTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="AddJob" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="80px" />
                                                        <ItemStyle Width="80px" />
                                                        <HeaderStyle Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ReplacedEmployeeNumber %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeNumberRep" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                            <asp:HiddenField ID="HFBreakHourAutoID" runat="server" Value='<%# Bind("BreakHourAutoID") %>' />
                                                            <asp:HiddenField ID="HFReplacedSchRosterAutoID" runat="server" Value='<%# Bind("ReplacedSchRosterAutoID") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlEmployeeNumberRep" CssClass="cssDropDown" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="HFEmployeeNumberRep" runat="server" Value='<%# Bind("EmployeeNumberRep") %>' />
                                                            <asp:HiddenField ID="HFBreakHourAutoID" runat="server" Value='<%# Bind("BreakHourAutoID") %>' />
                                                            <asp:HiddenField ID="HFReplacedSchRosterAutoID" runat="server" Value='<%# Bind("ReplacedSchRosterAutoID") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlFooterEmployeeNumberRep" CssClass="cssDropDown" runat="server">
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="150px" />
                                                        <ItemStyle Width="150px" />
                                                        <HeaderStyle Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,IsBillable %>">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CBIsPayable" Enabled="false" CssClass="cssCheckBox" runat="server"
                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsPayable").ToString())%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:CheckBox ID="CBIsPayable" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsPayable").ToString())%>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:CheckBox ID="CBFooterIsPayable" CssClass="cssCheckBox" runat="server" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="40px" />
                                                        <ItemStyle Width="40px" />
                                                        <HeaderStyle Width="40px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPanelRole" runat="server"
                        HeaderText="<%$Resources:Resource,Role %>" TabIndex="1">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" GroupingText="<%$Resources:Resource,EmployeeDetail %>">
                                <table width="700px" border="0">
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblRoleEmployeeNumber" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label15" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeName %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblRoleEmployeeName" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DutyDate %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblRoleDutyDate" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label8" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Time %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblRoleTimeFrom" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                            <asp:Label ID="lblRoleTimeTo" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HFRoleFromTime" runat="server" />
                                        <asp:HiddenField ID="HFRoleToTime" runat="server" />
                                        <asp:Label ID="lblErrorMsg" CssClass="csslblErrMsg" EnableViewState="false" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel2" runat="server" GroupingText="<%$Resources:Resource,Role %>">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView Width="700px" ID="gvRole" CssClass="GridViewStyle" runat="server" ShowFooter="true"
                                                ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15" CellPadding="1"
                                                GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GvRole_RowDataBound"
                                                OnRowCommand="GvRole_RowCommand" OnPageIndexChanging="GvRole_PageIndexChanging"
                                                OnRowCancelingEdit="GvRole_RowCancelingEdit" OnRowDeleting="GvRole_RowDeleting"
                                                OnRowEditing="GvRole_RowEditing" OnRowUpdating="GvRole_RowUpdating">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                        <EditItemTemplate>
                                                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                                CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="EditRole1" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                CommandName="Cancel" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                CssClass="cssImgButton" ValidationGroup="AddRole1" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
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
                                                        <FooterStyle Width="100px" />
                                                        <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,RoleCode %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" CssClass="cssLabel" Text='<%# Bind("RoleDesc") %>'></asp:Label>
                                                            <asp:HiddenField ID="HFRoleCode" runat="server" Value='<%# Bind("RoleCode") %>' />
                                                            <asp:HiddenField ID="HFRoleAutoID" runat="server" Value='<%# Bind("RoleAutoID") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlRoleCode" Width="250px" CssClass="cssDropDown" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="HFRoleCode" runat="server" Value='<%# Bind("RoleCode") %>' />
                                                            <asp:HiddenField ID="HFRoleAutoID" runat="server" Value='<%# Bind("RoleAutoID") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlFooterRoleCode" Width="250px" CssClass="cssDropDown" runat="server">
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="250px" />
                                                        <HeaderStyle Width="250px" CssClass="cssLabelHeader" />
                                                        <ItemStyle Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,FromTime %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeFrom" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeFrom" ValidationGroup="EditRole1" CssClass="csstxtbox" Width="60px"
                                                                runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender34" runat="server" TargetControlID="txtTimeFrom"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator34" runat="server" ControlExtender="MaskedEditExtender34"
                                                                ControlToValidate="txtTimeFrom" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="EditRole1" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFooterTimeFrom" ValidationGroup="AddRole1" CssClass="csstxtbox"
                                                                Width="60px" runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender37" runat="server" TargetControlID="txtFooterTimeFrom"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator37" runat="server" ControlExtender="MaskedEditExtender37"
                                                                ControlToValidate="txtFooterTimeFrom" IsValidEmpty="False" Display="Dynamic"
                                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="AddRole1" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100px" />
                                                        <ItemStyle Width="100px" />
                                                        <HeaderStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ToTime %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeTo" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeTo" ValidationGroup="EditRole1" CssClass="csstxtbox" Width="60px"
                                                                runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender35" runat="server" TargetControlID="txtTimeTo"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator35" runat="server" ControlExtender="MaskedEditExtender35"
                                                                ControlToValidate="txtTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="EditRole1" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFooterTimeTo" ValidationGroup="AddRole1" CssClass="csstxtbox"
                                                                Width="60px" runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender36" runat="server" TargetControlID="txtFooterTimeTo"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator36" runat="server" ControlExtender="MaskedEditExtender36"
                                                                ControlToValidate="txtFooterTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="AddRole1" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100px" />
                                                        <ItemStyle Width="100px" />
                                                        <HeaderStyle Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPanelTask" runat="server"
                        HeaderText="<%$Resources:Resource,Task %>" TabIndex="1">
                        <ContentTemplate>
                            <asp:Panel ID="Panel4" runat="server" GroupingText="<%$Resources:Resource,EmployeeDetail %>">
                                <table width="700px" border="0">
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label11" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTaskEmployeeNumber" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label17" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeName %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTaskEmployeeName" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label14" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DutyDate %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTaskDutyDate" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label16" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Time %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTaskTimeFrom" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                            <asp:Label ID="lblTaskTimeTo" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HFTaskFromTime" runat="server" />
                                        <asp:HiddenField ID="HFTaskFromTo" runat="server" />
                                        <asp:Label ID="Label19" CssClass="csslblErrMsg" EnableViewState="false" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel5" runat="server" GroupingText="<%$Resources:Resource,Task %>">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView Width="700px" ID="gvTask" CssClass="GridViewStyle" runat="server" ShowFooter="true"
                                                ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15" CellPadding="1"
                                                GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GvTask_RowDataBound"
                                                OnRowCommand="GvTask_RowCommand" OnPageIndexChanging="GvTask_PageIndexChanging"
                                                OnRowCancelingEdit="GvTask_RowCancelingEdit" OnRowDeleting="GvTask_RowDeleting"
                                                OnRowEditing="GvTask_RowEditing" OnRowUpdating="GvTask_RowUpdating">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                        <EditItemTemplate>
                                                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                                CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                CommandName="Cancel" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                CssClass="cssImgButton" ValidationGroup="AddTask" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                        </FooterTemplate>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                CssClass="csslnkButton" ValidationGroup="EditTask" runat="server" CausesValidation="False"
                                                                CommandName="Edit" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                        </ItemTemplate>
                                                        <FooterStyle Width="100px" />
                                                        <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,TaskDesc %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTaskDesc" runat="server" CssClass="cssLabel" Text='<%# Bind("TaskDesc") %>'></asp:Label>
                                                            <asp:HiddenField ID="HFTaskAutoId" runat="server" Value='<%# Bind("TaskAutoId") %>' />
                                                            <asp:HiddenField ID="HFtrnTaskAutoID" runat="server" Value='<%# Bind("trnTaskAutoID") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlTaskAutoId" Width="250px" CssClass="cssDropDown" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="HFTaskAutoId" runat="server" Value='<%# Bind("TaskAutoId") %>' />
                                                            <asp:HiddenField ID="HFtrnTaskAutoID" runat="server" Value='<%# Bind("trnTaskAutoID") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlFooterTaskAutoId" Width="250px" CssClass="cssDropDown" runat="server">
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="250px" />
                                                        <HeaderStyle Width="250px" CssClass="cssLabelHeader" />
                                                        <ItemStyle Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,FromTime %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeFrom" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeFrom" ValidationGroup="EditTask" CssClass="csstxtbox" Width="60px"
                                                                runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender34" runat="server" TargetControlID="txtTimeFrom"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator34" runat="server" ControlExtender="MaskedEditExtender34"
                                                                ControlToValidate="txtTimeFrom" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="EditTask" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFooterTimeFrom" ValidationGroup="AddTask" CssClass="csstxtbox"
                                                                Width="60px" runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender33" runat="server" TargetControlID="txtFooterTimeFrom"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator33" runat="server" ControlExtender="MaskedEditExtender33"
                                                                ControlToValidate="txtFooterTimeFrom" IsValidEmpty="False" Display="Dynamic"
                                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="AddTask" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100px" />
                                                        <ItemStyle Width="100px" />
                                                        <HeaderStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ToTime %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeTo" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeTo" ValidationGroup="EditTask" CssClass="csstxtbox" Width="60px"
                                                                runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender32" runat="server" TargetControlID="txtTimeTo"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator32" runat="server" ControlExtender="MaskedEditExtender32"
                                                                ControlToValidate="txtTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="EditTask" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFooterTimeTo" ValidationGroup="AddTask" CssClass="csstxtbox"
                                                                Width="60px" runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender31" runat="server" TargetControlID="txtFooterTimeTo"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator31" runat="server" ControlExtender="MaskedEditExtender31"
                                                                ControlToValidate="txtFooterTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="AddTask" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100px" />
                                                        <ItemStyle Width="100px" />
                                                        <HeaderStyle Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPanelAllowancesDetails" runat="server"
                        HeaderText="<%$Resources:Resource,AllowanceDetails %>" TabIndex="2">
                        <ContentTemplate>
                            <asp:HiddenField ID="hfspDecimalPlace" runat="server" Value="{0:n2}" />
                            <asp:Panel ID="Panel6" runat="server" GroupingText="<%$Resources:Resource,EmployeeDetail %>">
                                <table width="800px" border="0">
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label18" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblEmployeeNumberAllowanceDetails" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="Label20" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeName %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblEmployeeNameAllowanceDetails" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label21" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DutyDate %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDutyDateAllowanceDetails" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label22" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Time %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblFromTimeAllowanceDetails" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                            <asp:Label ID="lblToTimeAllowanceDetails" CssClass="csstxtboxRequired" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hd1" runat="server" />
                                        <asp:HiddenField ID="hd2" runat="server" />
                                        <asp:Label ID="lblAllowanceDetailsErrorMsg" CssClass="csslblErrMsg" EnableViewState="false"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel7" runat="server" GroupingText="<%$ Resources:Resource,Allowance %>" ScrollBars="Auto" Height= "250px" >
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView Width="1500px" ID="gvAllowanceDetails" CssClass="GridViewStyle" runat="server"
                                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvAllowanceDetails_RowDataBound"
                                                OnRowCommand="gvAllowanceDetails_RowCommand" OnPageIndexChanging="gvAllowanceDetails_PageIndexChanging"
                                                OnRowCancelingEdit="gvAllowanceDetails_RowCancelingEdit" OnRowDeleting="gvAllowanceDetails_RowDeleting"
                                                OnRowEditing="gvAllowanceDetails_RowEditing" OnRowUpdating="gvAllowanceDetails_RowUpdating">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                        <EditItemTemplate>
                                                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                                CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="EditAllowance" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                CommandName="Cancel" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                CssClass="cssImgButton" ValidationGroup="AddNewAllowance" CommandName="AddNew"
                                                                ImageUrl="../Images/AddNew.gif" />
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
                                                        <FooterStyle Width="100px" />
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,AllowanceDescription %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAllowanceDetailsDescription" runat="server" CssClass="cssLabel"
                                                                Text='<%# Bind("AllowanceDescription") %>'></asp:Label>
                                                            <%--<asp:HiddenField ID="hfRosterAllowanceDetailsAutoID" runat="server" Value='<%# Bind("RosterAllowanceAutoID") %>' />--%>
                                                            <asp:HiddenField ID="hfRosterAllowanceDetailsAutoId" runat="server" Value='<%# Bind("TrnAllowanceAutoId") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlAllowanceDetailsDescription" Width="250px" CssClass="cssDropDown" Enabled="false"
                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlAllowanceDetailsDescription_OnSelectedChange"
                                                                runat="server">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hfAllowanceDetailsAutoId" runat="server" Value='<%# Bind("AllowanceAutoID") %>' />
                                                            <%--<asp:HiddenField ID="hfRosterAllowanceDetailsAutoID" runat="server" Value='<%# Bind("RosterAllowanceAutoID") %>' />--%>
                                                            <asp:HiddenField ID="hfRosterAllowanceDetailsAutoId" runat="server" Value='<%# Bind("TrnAllowanceAutoId") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlAllowanceDetailsDescription" Width="250px" CssClass="cssDropDown"
                                                                OnSelectedIndexChanged="ddlAllowanceDetailsDescription_SelectedIndexChange" AutoPostBack="true"
                                                                runat="server">
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="250px" />
                                                        <HeaderStyle Width="250px" />
                                                        <ItemStyle Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,PayrollCode %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblElementDetails" runat="server" CssClass="cssLabel" Text='<%# Bind("Element") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblElementDetails" runat="server" CssClass="cssLabel" Text='<%# Bind("Element") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblElementDetails" runat="server" CssClass="cssLabel" Text='<%# Bind("Element") %>'></asp:Label>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100px" />
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Type %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblElementTypeDetails" runat="server" CssClass="cssLabel" Text='<%# Bind("ElementType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblElementTypeDetails" runat="server" CssClass="cssLabel" Text='<%# Bind("ElementType") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblElementTypeDetails" runat="server" CssClass="cssLabel" Text='<%# Bind("ElementType") %>'></asp:Label>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="120px" />
                                                        <HeaderStyle Width="120px"/>
                                                        <ItemStyle Width="120px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,FromTime %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeFromDetails" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:HH:mm}",Eval("FromTime")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeFromDetails" CssClass="csstxtbox" ValidationGroup="EditAllowance" Width="60px" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("FromTime")) %>'></asp:TextBox>
                                                             <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender401Details" runat="server" TargetControlID="txtTimeFromDetails"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator401Details" runat="server" ControlExtender="MaskedEditExtender401Details"
                                                                ControlToValidate="txtTimeFromDetails" IsValidEmpty="true" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="EditAllowance" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFooterTimeFromDetails" CssClass="csstxtbox" ValidationGroup="AddNewAllowance" Width="60px" runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender40Details" runat="server" TargetControlID="txtFooterTimeFromDetails"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator40Details" runat="server" ControlExtender="MaskedEditExtender40Details"
                                                                ControlToValidate="txtFooterTimeFromDetails" IsValidEmpty="true" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="AddNewAllowance" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="80px" BackColor = "LightGray"/>
                                                        <ItemStyle Width="80px" BackColor = "LightGray"/>
                                                        <HeaderStyle Width="80px" BackColor = "LightGray" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ToTime %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeToDetails" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:HH:mm}",Eval("ToTime")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeToDetails" CssClass="csstxtbox" Width="60px" ValidationGroup="EditAllowance" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("ToTime")) %>'></asp:TextBox>
                                                             <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender403Details" runat="server" TargetControlID="txtTimeToDetails"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator403Details" runat="server" ControlExtender="MaskedEditExtender403Details"
                                                                ControlToValidate="txtTimeToDetails" IsValidEmpty="true" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="EditAllowance" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFooterTimeToDetails" CssClass="csstxtbox" ValidationGroup="AddNewAllowance" Width="60px" runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender41Details" runat="server" TargetControlID="txtFooterTimeToDetails"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator41Details" runat="server" ControlExtender="MaskedEditExtender41Details"
                                                                ControlToValidate="txtFooterTimeToDetails" IsValidEmpty="true" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="AddNewAllowance" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="80px" BackColor = "LightGray"/>
                                                        <ItemStyle Width="80px" BackColor = "LightGray"/>
                                                        <HeaderStyle Width="80px" BackColor = "LightGray"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Rate %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRateIdDetails" runat="server" CssClass="cssLabel" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("RateID")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblRateIdDetails" runat="server" CssClass="cssLabel" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("RateID")) %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblRateIdDetails" runat="server" CssClass="cssLabel" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("RateID")) %>'></asp:Label>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100px" BackColor = "LightGray"/>
                                                        <HeaderStyle Width="100px" BackColor = "LightGray"/>
                                                        <ItemStyle Width="100px" BackColor = "LightGray"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Measurement %>" HeaderStyle-Width="150px"
                                                        FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMeasurement" CssClass="cssLable" runat="server" Text='<%# Bind("Measurement") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblMeasurement" CssClass="cssLable" runat="server" Text='<%# Bind("Measurement") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblMeasurement" CssClass="cssLable" runat="server" Text='<%# Bind("Measurement") %>'></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Unit %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitDetails" runat="server" CssClass="cssLabel" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("Unit")) %>'></asp:Label>
                                                            <asp:HiddenField ID="hfUnitTypeDetails" runat="server" Value='<%# Bind("UnitType") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <%--<asp:Label ID="lblUnitDetails" runat="server" CssClass="cssLabel" Text='<%# Bind("Unit") %>'></asp:Label>--%>
                                                            <asp:TextBox ID="txtUnitDetails" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("Unit")) %>' CssClass="csstxtbox" AutoPostBack="true" OnTextChanged = "txtUnitDetails_OnEditTextChanged"></asp:TextBox>
                                                            <asp:HiddenField ID="hfUnitTypeDetails" runat="server" Value='<%# Bind("UnitType") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <%--<asp:Label ID="lblUnitDetails" runat="server" CssClass="cssLabel" Text='<%# Bind("Unit") %>'></asp:Label>--%>
                                                            <asp:TextBox ID="txtUnitDetails" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("Unit")) %>' CssClass="csstxtbox" AutoPostBack="true" OnTextChanged = "txtUnitDetails_OnTextChanged"></asp:TextBox>
                                                            <asp:HiddenField ID="hfUnitTypeDetails" runat="server" Value='<%# Bind("UnitType") %>' />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="90px" BackColor = "DarkGray"/>
                                                        <HeaderStyle Width="90px" BackColor = "DarkGray"/>
                                                        <ItemStyle Width="90px" BackColor = "DarkGray"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,AmountPaid %>" HeaderStyle-Width="110px" HeaderStyle-BackColor= "DarkGray" ItemStyle-BackColor= "DarkGray"
                                                        FooterStyle-Width="110px" ItemStyle-Width="110px" FooterStyle-BackColor= "DarkGray">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmountPaid" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("AmountPaid")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtAmountPaid" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("AmountPaid")) %>'
                                                                CssClass="csstxtbox"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtAmountPaid" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("AmountPaid")) %>' 
                                                                CssClass="csstxtbox"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="<%$Resources:Resource,Billable %>">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBillable" runat="server" CssClass="cssLabel" Text='<%# Bind("IsBillable") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList runat="server" Width="100px" ID="ddlBillable" CssClass="cssdropdown">
                                                                <asp:ListItem Text="<%$Resources:Resource,No %>" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="<%$Resources:Resource,Yes %>" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hfBillable" runat="server" Value='<%# Bind("IsBillable") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList runat="server" Width="100px" ID="ddlBillable" CssClass="cssdropdown">
                                                                <asp:ListItem Text="<%$Resources:Resource,No %>" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="<%$Resources:Resource,Yes %>" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100px" BackColor = "DarkGray"/>
                                                        <HeaderStyle Width="100px" BackColor = "DarkGray"/>
                                                        <ItemStyle Width="100px" BackColor = "DarkGray"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Comment %>" HeaderStyle-Width="200px" HeaderStyle-BackColor= "DarkGray" ItemStyle-BackColor= "DarkGray" FooterStyle-BackColor= "DarkGray"
                                                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblComment" CssClass="cssLable" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtComment" runat="server" Text='<%# Bind("Comment") %>' Width= "200px"
                                                                CssClass="csstxtbox"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtComment" runat="server" Text='<%# Bind("Comment") %>' Width= "200px"
                                                                CssClass="csstxtbox"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                </AjaxToolKit:TabContainer>
            </ContentTemplate>
        </Ajax:UpdatePanel>
    </div>
    <script language="javascript" type="text/javascript">

        window.onbeforeunload = CallParentWindowFunction;
        function CallParentWindowFunction() {
            window.returnValue = "1";
            //                        if (window.opener != null) {
            //                            window.opener.ParentWindowFunction1();
            //                        }

        }
    </script>
    </form>
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
</body>
</html>
