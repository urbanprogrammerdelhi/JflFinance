<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="IncidentTracking.aspx.cs" Inherits="OperationManagement_IncidentTracking"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="19%" align="right" nowrap="nowrap">
                                    <asp:Label ID="lblIncidentTracking" Width="180px" CssClass="cssLabel" runat="server"
                                        Text="<%$Resources:Resource,IncidentComplainNo %>"></asp:Label>&nbsp;&nbsp;
                                </td>
                                <td align="left" width="61%">
                                    <asp:HiddenField ID="hfLocationAutoID" runat="server" />
                                    <asp:TextBox ID="txtIncidentNo" MaxLength="35" Width="110px" AutoPostBack="true"
                                        CssClass="csstxtbox" runat="server" OnTextChanged="txtIncidentNo_TextChanged"></asp:TextBox>
                                    <AjaxToolKit:AutoCompleteExtender runat="server" BehaviorID="AutoCompleteEx" ID="autoComplete1"
                                        TargetControlID="txtIncidentNo" ServicePath="~/WebServices/AutoCompleteTextBox.asmx"
                                        ServiceMethod="AutoCompleteTextBoxIncidentNumber" ContextKey="<%=hfLocationAutoID.Value %>"
                                        MinimumPrefixLength="1" CompletionInterval="1000" EnableCaching="true" CompletionListCssClass="autocomplete_completionListElement"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                        DelimiterCharacters=";, :">
                                        <Animations>
                                            <OnShow>
                                                <Sequence>
                                                    <%-- Make the completion list transparent and then show it --%>
                                                    <OpacityAction Opacity="0" />
                                                    <HideAction Visible="true" />
                                                    
                                                    <%--Cache the original size of the completion list the first time
                                                        the animation is played and then set it to zero --%>
                                                    <ScriptAction Script="
                                                        // Cache the size and setup the initial size
                                                        var behavior = $find('AutoCompleteEx');
                                                        if (!behavior._height) {
                                                            var target = behavior.get_completionList();
                                                            behavior._height = target.offsetHeight - 2;
                                                            target.style.height = '0px';
                                                        }" />
                                                    
                                                    <%-- Expand from 0px to the appropriate size while fading in --%>
                                                    <Parallel Duration=".4">
                                                        <FadeIn />
                                                        <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                                                    </Parallel>
                                                </Sequence>
                                            </OnShow>
                                            <OnHide>
                                                <%-- Collapse down to 0px and fade out --%>
                                                <Parallel Duration=".4">
                                                    <FadeOut />
                                                    <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                                                </Parallel>
                                            </OnHide>
                                        </Animations>
                                    </AjaxToolKit:AutoCompleteExtender>
                                    <asp:ImageButton ID="imgIncSearch" AlternateText="SearchIncident" runat="server"
                                        ImageUrl="~/Images/icosearch.gif" ToolTip="<%$Resources:Resource,SearchIncident %>" />
                                </td>
                                <td align="right" width="170px">
                                    <asp:Label ID='lblTrnS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                    <asp:Label ID="lblStatus" CssClass="csstxtbox" Width="110px" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="PanelMain" runat="server" Width="98%">
                            <div style="width: 98%;">
                                <div class="squarebox">
                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;">
                                        <div style="float: left; width: 900px;">
                                            <tt style="text-align: center;">
                                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,IncidentDetails %>"></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" width="100%">
                                            <tr>
                                                <td align="right" width="19%">
                                                    <asp:Label ID="lblIncidentTrackingDt" CssClass="cssLabel" Width="100px" runat="server"
                                                        Text="<%$Resources:Resource,StatusDate %>" Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                                                </td>
                                                <td align="left" width="62%">
                                                    <asp:TextBox ID="txtIncidentTrackingDt" Width="110px" CssClass="csstxtbox" AutoPostBack="true"
                                                        runat="server" OnTextChanged="txtIncidentTrackingDt_TextChanged" ValidationGroup="Apply"></asp:TextBox>
                                                        <asp:ImageButton ID="ImgStatus" Style="vertical-align: middle" CausesValidation="false"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtIncidentTrackingDt" PopupButtonID="ImgStatus" PopupPosition="TopLeft" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtIncidentTrackingDt"
                                                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Apply"></asp:RequiredFieldValidator>
                                                </td>
                                                <td colspan="1" width="130">
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0">
                                            <tr>
                                                <td colspan="5" style="height: 194px">
                                                    <asp:Panel ID="PanelAssignmentDetails" Width="890px" GroupingText="<%$Resources:Resource,IncidentDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890">
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblIncident" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,IncidentType %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtIncidentType" MaxLength="32" CssClass="csstxtbox" Width="110px"
                                                                        runat="server" AutoPostBack="True" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblAssignNo" Width="130px" CssClass="cssLabel" runat="server" Visible="false" Text="<%$Resources:Resource,AssignmentNumber %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="160">
                                                                    <asp:HiddenField ID ="hdClientCode" runat="server" />  <%--Added by  on 22-May-2013--%>
                                                                    <asp:TextBox ID="txtAssignNo" MaxLength="32" CssClass="csstxtbox"  ValidationGroup="Apply" Width="110px" runat="server"
                                                                        AutoPostBack="True" Enabled="false" Visible="false"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="txtAssignNo"
                                                                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Apply"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblCustID" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtCustomerID" CssClass="csstxtbox" Enabled="false" Width="110px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblCustName" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ClientName %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="160">
                                                                    <asp:TextBox ID="txtCustomerDesc" CssClass="csstxtbox" Enabled="false" Width="385px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100" style="height: 23px">
                                                                    <asp:Label ID="lblAddressID" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AsmtID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140" style="height: 23px">
                                                                    <asp:TextBox ID="txtAddressID" CssClass="csstxtbox" Enabled="false" Width="110px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblAddress" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Address %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="160">
                                                                    <asp:TextBox ID="txtAddressDesc" CssClass="csstxtbox" Enabled="false" Width="385px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblAreaID" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="110px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblAreaDesc" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaDesc %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="160">
                                                                    <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="385px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblNatureOfInc" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,NatureOfIncident %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtNatureofInc" CssClass="csstxtbox" Enabled="false" Width="110px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblDetails" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Details %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="160">
                                                                    <asp:TextBox ID="txtDetails" CssClass="csstxtbox" Enabled="false" Width="385px" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblIncReportedBy" Width="130px" CssClass="cssLabel" runat="server"
                                                                        Text="<%$Resources:Resource,ReportedBy %>" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                <td align="left" width="150">
                                                                    <asp:TextBox ID="txtEmployeeID" AutoPostBack="true"  ValidationGroup="Apply" CssClass="csstxtbox" Width="110px"
                                                                        runat="server" OnTextChanged="txtEmployeeID_TextChanged1"></asp:TextBox>
                                                                    <asp:ImageButton ID="imgEmpSearch" AlternateText="<%$Resources:Resource,SearchReportedBy %>"
                                                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtEmployeeID" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" width="140px">
                                                                    <asp:TextBox ID="txtEmployeeName" CssClass="csstxtbox" Enabled="false" Width="140px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="height: 23px">
                                                                    <asp:TextBox ID="txtEmpDesignation" CssClass="csstxtbox" Enabled="false" Width="385px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100px" style="height: 23px">
                                                                    <asp:Label ID="lblReportedDate" Width="130px" CssClass="cssLabel" runat="server"
                                                                        Text="<%$Resources:Resource,ReportingDate %>" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                <td align="left" width="160px" style="height: 23px">
                                                                    <asp:TextBox ID="txtReportedDate" Width="110px" CssClass="csstxtbox" AutoPostBack="true" Enabled="false" 
                                                                        runat="server" OnTextChanged="txtReportedDate_TextChanged" ValidationGroup="Apply"></asp:TextBox>
                                                                    <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtReportedDate" PopupButtonID="IMGDate" PopupPosition="TopLeft" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtReportedDate"
                                                                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Apply"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblReportedTime" Width="130px" CssClass="cssLabel" runat="server"
                                                                        Text="<%$Resources:Resource,ReportingTime %>" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtTimeFrom" CssClass="csstxtbox" Width="110px" ValidationGroup="Apply"
                                                                        runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtTimeFrom"
                                                                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Apply"></asp:RequiredFieldValidator>
                                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTimeFrom"
                                                                        Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                        MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                        ErrorTooltipEnabled="True" />
                                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                                        ControlToValidate="txtTimeFrom" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                        InvalidValueBlurredMessage="*" ValidationGroup="Apply" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100" valign="top">
                                                                    <asp:Label ID="lblIncidentStatus" Width="130px" CssClass="cssLabel" runat="server"
                                                                        Text="<%$Resources:Resource,Status %>"></asp:Label>
                                                                </td>
                                                                <%--Modify by  on 29-May-2013--%>
                                                                <td align="left" width="440px" colspan="3">
                                                                    <asp:TextBox ID="txtIncStatus" CssClass="csstxtbox" Width="730px" Height="80px" runat="server"
                                                                        TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100" valign="top">
                                                                    <asp:Label ID="lblActionTaken" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Action %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="440px" colspan="3">
                                                                    <asp:TextBox ID="txtActionTaken" CssClass="csstxtbox" Width="730px" Height="80px"
                                                                        runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                                <%--End--%>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <table border="0" align="center">
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Apply" runat="server"
                                        Text="<%$Resources:Resource,Save %>" Visible="false" OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAuthorize" CssClass="cssButton" ValidationGroup="Apply" Visible="false"
                                        runat="server" Text="Authorize" OnClick="btnAuthorize_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEdit" CssClass="cssButton" Visible="false" runat="server" Text="Amend"
                                        OnClick="btnEdit_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" CssClass="cssButton" runat="server" ValidationGroup="Apply"
                                        Visible="false" Text="<%$Resources:Resource,Update %>" OnClick="btnUpdate_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnReset" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Reset %>"
                                        OnClick="btnReset_Click" />
                                </td>
                                <td>
                                    <asp:HiddenField ID="hfMessageToEdit" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <table width="890" border="0">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblError" runat="server" Text="" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 18px">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" CssClass="csslblErrMsg" runat="server"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
