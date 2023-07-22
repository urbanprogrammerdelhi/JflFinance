<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveType.aspx.cs" Inherits="HRManagement_LeaveType" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                                <div class="squareboxgradientcaption" style="height: 20px;">
                                    <asp:Label ID="Label13" runat="server" Text="<%$Resources:Resource,LeaveType %>"></asp:Label>
                                </div>
                                <div>
                                    <asp:Panel ID="PanelAssignmentDetails" GroupingText="<%$Resources:Resource,LeaveType %>"
                                        BorderWidth="0px" runat="server">
                                        <table style="border: 0px;" cellpadding="0" cellspacing="1">
                                            <tr>
                                                <td style="width: 150px; text-align: right">
                                                    <asp:Label ID="lblLeaveType" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveType %>"></asp:Label>
                                                </td>
                                                <td style="width: 150px; text-align: left">
                                                    <asp:TextBox ID="txtLeaveType" MaxLength="5" CssClass="csstxtboxReadonly" Width="100px"
                                                        runat="server" AutoPostBack="true" OnTextChanged="OnTextChanged_txtLeaveType"></asp:TextBox>
                                                    <asp:ImageButton ID="ImgLTCode" AlternateText="SearchClient" runat="server" ImageUrl="~/Images/icosearch.gif"
                                                        ToolTip="<%$Resources:Resource,SearchLeaveType %>" />
                                                    <asp:RequiredFieldValidator ID="txtLeaevTypeValidator" runat="server" ControlToValidate="txtLeaveType"
                                                        ErrorMessage="<%$Resources:Resource,CannotBeLeftBlank %>" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right" style="width: 120px">
                                                    <asp:Label ID="lblLeaveDesc" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveDesc %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 170px">
                                                    <asp:TextBox ID="txtLeaveDesc" MaxLength="30" CssClass="csstxtboxReadonly" Width="140px"
                                                        runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtLeaveValidator" runat="server" ControlToValidate="txtLeaveDesc"
                                                        ErrorMessage="<%$Resources:Resource,CannotBeLeftBlank %>" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td colspan="2" align="center" style="width: 200px">
                                                    <asp:CheckBox ID="chkIsActive" Text="<%$Resources:Resource,IsActive %>" TextAlign="Left"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                        <hr style="height: 2px; background-color: Gray; margin:0;" />
                                        <table border="0" cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td style="width: 150px; text-align: right">
                                                    <asp:Label ID="lblUnits" Text="<%$Resources:Resource,Units%>" runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 150px">
                                                    <asp:DropDownList ID="ddlUnits" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                        Width="100px" OnSelectedIndexChanged="ddlUnits_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: right; width: 150px">
                                                    <asp:Label ID="Label1" Text="<%$Resources:Resource,Units%>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    <asp:Label ID="lblHoursPerUnit" Text="<%$Resources:Resource,InMinute%>" runat="server"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td style="text-align: left" Width="500px">
                                                    <asp:TextBox ID="txtHoursPerUnit" runat="server" CssClass="csstxtbox" MaxLength="5" Enabled= "false"
                                                        Width="60px"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtenderHoursPerUnit" AutoComplete="true"
                                                        AutoCompleteValue="0" AcceptNegative="None" runat="server" TargetControlID="txtHoursPerUnit"
                                                        Mask="999" MessageValidatorTip="true" MaskType="Number" AcceptAMPM="false" ClearTextOnInvalid="true"
                                                        ErrorTooltipEnabled="True">
                                                    </AjaxToolKit:MaskedEditExtender>
                                                    <asp:RangeValidator runat="server" MinimumValue="1" MaximumValue="999" ControlToValidate="txtHoursPerUnit" 
                                                    ErrorMessage="<%$Resources:Resource,LeaveUnitsShouldMoreThanZero%>"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblEntitlementRule" Text="<%$Resources:Resource,EntitlementRule %>"
                                                        runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtEntitlementRule" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblEntitlementUnits" Text="<%$Resources:Resource,EntitlementUnits %>"
                                                        runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtEntitlementUnits" Width="100px" Text="00.00" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" AutoComplete="true" AutoCompleteValue="0"
                                                        AcceptNegative="None" runat="server" TargetControlID="txtEntitlementUnits" Mask="99.99"
                                                        MessageValidatorTip="true" MaskType="Number" AcceptAMPM="false" ClearTextOnInvalid="true"
                                                        ErrorTooltipEnabled="True">
                                                    </AjaxToolKit:MaskedEditExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="lblFrequency" Text="<%$Resources:Resource,Frequency%>" runat="server"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 180px;">
                                                    <asp:DropDownList ID="ddlFreqency" CssClass="cssDropDown" Style="width: 140px;" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblPostingRule" Text="<%$Resources:Resource,PostingRule %>" runat="server"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPostingRule" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblPostingUnitSource" Text="<%$Resources:Resource,PostingUnitSource %>"
                                                        runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlPostingUnitSource" runat="server" CssClass="cssDropDown"
                                                        Width="150px">
                                                        <asp:ListItem Text="Date Time Selection" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Schedule" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Actual Duty" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblMinUnits" Text="<%$Resources:Resource,MinimumUnits %>" runat="server"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMinUnits" Width="100px" runat="server" Text="00.00" CssClass="csstxtbox"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" AutoComplete="true" AutoCompleteValue="0"
                                                        AcceptNegative="None" runat="server" TargetControlID="txtMinUnits" Mask="99.99"
                                                        MessageValidatorTip="true" MaskType="Number" AcceptAMPM="false" ClearTextOnInvalid="true"
                                                        ErrorTooltipEnabled="True">
                                                    </AjaxToolKit:MaskedEditExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblMaxUnits" Text="<%$Resources:Resource,MaximumUnits %>" runat="server"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMaxUnits" Width="100px" runat="server" Text="00.00" CssClass="csstxtbox"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" AutoComplete="true" AutoCompleteValue="0"
                                                        AcceptNegative="None" runat="server" TargetControlID="txtMaxUnits" Mask="999.99"
                                                        MessageValidatorTip="true" MaskType="Number" AcceptAMPM="false" ClearTextOnInvalid="true"
                                                        ErrorTooltipEnabled="True">
                                                    </AjaxToolKit:MaskedEditExtender>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblEncashmentRule" Text="<%$Resources:Resource,EncashmentRule %>"
                                                        runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtEncashmentRule" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblEncashmentUnits" Text="<%$Resources:Resource,EncashmentUnits %>"
                                                        runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtEncashmentUnits" Width="100px" Text="00.00" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender4" AutoComplete="true" AutoCompleteValue="0"
                                                        AcceptNegative="None" runat="server" TargetControlID="txtEncashmentUnits" Mask="99.99"
                                                        MessageValidatorTip="true" MaskType="Number" AcceptAMPM="false" ClearTextOnInvalid="true"
                                                        ErrorTooltipEnabled="True">
                                                    </AjaxToolKit:MaskedEditExtender>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:CheckBox ID="cbCarryOver" AutoPostBack="true" OnCheckedChanged="cbCarryOver_OnCheckedChanged"
                                                        Text="<%$Resources:Resource,CarryOver %>" TextAlign="Left" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblCarryOverRule" Text="<%$Resources:Resource,CarryOverRule %>" runat="server"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtCarryOverRule" Enabled="false" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblCarryOverUnits" Width="100px" Text="<%$Resources:Resource,CarryOverUnits %>"
                                                        runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtCarryOverUnits" Enabled="false" Width="100px" Text="00.00" runat="server"
                                                        CssClass="csstxtbox"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender5" AutoComplete="true" AutoCompleteValue="0"
                                                        AcceptNegative="None" runat="server" TargetControlID="txtCarryOverUnits" Mask="99.99"
                                                        MessageValidatorTip="true" MaskType="Number" AcceptAMPM="false" ClearTextOnInvalid="true"
                                                        ErrorTooltipEnabled="True">
                                                    </AjaxToolKit:MaskedEditExtender>
                                                </td>
                                            </tr>
                                        </table>
                                        <hr style="height: 2px; background-color: Gray; margin:0;" />
                                        <table border="0" cellpadding="0" cellspacing="3" style="width:100%;">
                                            <tr>
                                                <td align="center">
                                                    <asp:CheckBox ID="cbEncashableLeave" Text="<%$Resources:Resource,EncashableLeave %>"
                                                        TextAlign="Left" runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:CheckBox ID="cbAffectsServiceGrowth" Text="<%$Resources:Resource,EffectsServiceGrowth %>"
                                                        TextAlign="Left" runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:CheckBox ID="cbMedicalCertification" Text="<%$Resources:Resource,MedicalCertification %>"
                                                        TextAlign="Left" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:CheckBox ID="cbHolidayInclusive" Text="<%$Resources:Resource,HolidayInclusive %>"
                                                        TextAlign="Left" runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:CheckBox ID="cbWithoutEntitlement" Text="<%$Resources:Resource,WithoutEntitlement %>"
                                                        TextAlign="Left" runat="server" />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0">
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Save %>"
                                                        OnClick="btnSave_Click" ValidationGroup="vg_Add" />
                                                    <%-- <asp:Button ID="btnEdit" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Edit %>"
                                                        OnClick="btnEdit_Click" />--%>
                                                    <asp:Button ID="btnUpdate" runat="server" Visible="false" CssClass="cssButton" Text="<%$ Resources:Resource, Update %>"
                                                        OnClick="btnUpdate_Click" />
                                                    <asp:Button ID="btnDelete" runat="server" Visible="false" CssClass="cssButton" Text="<%$ Resources:Resource, Delete %>"
                                                        OnClick="btnDelete_Click" />
                                                    <asp:Button ID="btnCancel" runat="server" Visible="false" CssClass="cssButton" Text="<%$ Resources:Resource, Cancel %>"
                                                        OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
</asp:Content>
