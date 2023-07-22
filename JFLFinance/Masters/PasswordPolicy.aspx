<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PasswordPolicy.aspx.cs" Inherits="Masters_PasswordPolicy" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPasswordPolicyActive" runat="server" CssClass="cssLabelHeader"
        Text="<%$ Resources:Resource, KeepPasswordPolicyActive %>"></asp:Label>
    <asp:CheckBox ID="chkIsActive" Checked="true" runat="server" />
    <br />
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlUpper" runat="server" Width="500px" GroupingText="Password">
                            <table border="0" cellpadding="3" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMinLen" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, MinimumLength %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMinLen" runat="server" CssClass="csstxtbox" Text="6" MaxLength="1"
                                           OnKeyUp="javascript:validateNumeric(this);"  Columns="10" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfMaxLen" runat="server" ErrorMessage="*" ControlToValidate="txtMinLen"
                                            ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMinUpperCase" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, MinUpperCase %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMinUpperCase" runat="server" CssClass="csstxtbox" Text="6" MaxLength="1"
                                           OnKeyUp="javascript:validateNumeric(this);"  Columns="10"  Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfMinUpperCase" runat="server" ErrorMessage="*" ControlToValidate="txtMinUpperCase"
                                            ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNumericChar" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, AtLeastOneNumericCharacterPresent %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddNumeric" runat="server" CssClass="cssDropDown"  Enabled="false">
                                            <asp:ListItem Text="<%$ Resources:Resource, Yes %>" Value="1" Selected="True" />
                                            <asp:ListItem Text="<%$ Resources:Resource, No %>" Value="0" />
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSpecialChar" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, AtLeastOneSpecialCharacterPresent %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddSpecialChar" runat="server" CssClass="cssDropDown"  Enabled="false">
                                            <asp:ListItem Text="<%$ Resources:Resource, Yes %>" Value="1" Selected="True" />
                                            <asp:ListItem Text="<%$ Resources:Resource, No %>" Value="0" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblExpDay" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, ExpiryDays %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtExpDay" runat="server" CssClass="csstxtbox" Text="30" MaxLength="3"
                                          OnKeyUp="javascript:validateNumeric(this);"  Columns="10"  Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtExpDay" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblExpWarB4" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, ShowExpiryWarningBefore %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtExpWarB4" runat="server" CssClass="csstxtbox" Text="10" MaxLength="3"
                                          OnKeyUp="javascript:validateNumeric(this);"  Columns="10"  Enabled="false"></asp:TextBox>
                                        <asp:Label ID="lblDaysExpWarB4" runat="server" CssClass="cssLabel" Text="days" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtExpWarB4" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPwdUniqness" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, PasswordUniqenessResuseAfter %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPwdUniqness" runat="server" CssClass="csstxtbox" Text="5" MaxLength="3"
                                          OnKeyUp="javascript:validateNumeric(this);"  Columns="10"  Enabled="false"></asp:TextBox>
                                        <asp:Label ID="lblDaysPwdUniqness" runat="server" CssClass="cssLabel" Text="times" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                          OnKeyUp="javascript:validateNumeric(this);"  ControlToValidate="txtPwdUniqness" ForeColor="Red" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlLower" runat="server" Width="500px" GroupingText="User">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDisableAcc" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, DisableUnusedAccountAfter %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDisableAcc" runat="server" CssClass="csstxtbox" Text="0" MaxLength="3"
                                          OnKeyUp="javascript:validateNumeric(this);"  Columns="10"  Enabled="false"></asp:TextBox>
                                        <asp:Label ID="lblDaysDisableAcc" runat="server" CssClass="cssLabel" Text="days" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtDisableAcc" ForeColor="Red" />
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>
                                        <asp:Label ID="lblRemove" runat="server" CssClass="cssLabel" Text="Remove Unused Account After"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemove" runat="server" CssClass="csstxtbox" Text="0" Columns="10"></asp:TextBox>
                                        <asp:Label ID="lblDaysRemove" runat="server" CssClass="cssLabel" Text="days" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtRemove" ForeColor="Red" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblUnsuccessAtmp" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, NumberOfUnsuccessfulAttempts %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUnsuccessAtmp" runat="server" CssClass="csstxtbox" Text="5" OnKeyUp="javascript:validateNumeric(this);" Columns="10"  Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtUnsuccessAtmp" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblUnsuccessLogin" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, DisableAfterUnsuccessfulLoginAttempts %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddUnsuccessLogin" runat="server" CssClass="cssDropDown"  Enabled="false">
                                            <asp:ListItem Text="<%$ Resources:Resource, Yes %>" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="<%$ Resources:Resource, No %>" Value="0" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlBottom" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnApply" runat="server" Text="<%$ Resources:Resource, Apply %>" OnClick="btnApply_Click" CssClass="cssButton" />
                                        <asp:Button ID="btnReset" runat="server" Text="<%$ Resources:Resource, Reset %>" CssClass="cssButton" CausesValidation="false"
                                            OnClick="btnReset_Click" />
                                        <asp:Button ID="btnClear" runat="server" Text="<%$ Resources:Resource, Clear %>" CssClass="cssButton" CausesValidation="false"
                                            OnClick="btnClear_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:Resource, Cancel %>" OnClick="btnCancel_Click"
                                            CssClass="cssButton" CausesValidation="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
