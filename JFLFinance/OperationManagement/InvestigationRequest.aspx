<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="InvestigationRequest.aspx.cs" Inherits="OperationManagement_InvestigationRequest"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="950" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="135" align="left" nowrap="nowrap">
                                    <asp:Label ID="lblInvestigationReq" Width="135px" CssClass="cssLabel" runat="server"
                                        Text="<%$ Resources:Resource, InvestigationNumber %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:HiddenField ID="hfLocationAutoID" runat="server" />
                                    <asp:TextBox ID="txtInvestigationNo" MaxLength="35" Width="110px" AutoPostBack="true"
                                        CssClass="csstxtbox" runat="server" OnTextChanged="txtInvestigationNo_TextChanged"></asp:TextBox>
                                    <AjaxToolKit:AutoCompleteExtender runat="server" BehaviorID="AutoCompleteEx" ID="autoComplete1"
                                        TargetControlID="txtInvestigationNo" ServicePath="~/WebServices/AutoCompleteTextBox.asmx"
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
                                    <asp:ImageButton ID="imgInvestigationSearch" AlternateText="<%$ Resources:Resource, SearchInvestigation %>"
                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="right" width="160">
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
                                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, InvestigationRequest %>"></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" width="890px" style="vertical-align: top">
                                            <tr>
                                                <td align="right" width="100">
                                                    <asp:Label ID="lblInvReqDate" CssClass="cssLabel" Width="90px" runat="server" Text="<%$ Resources:Resource, InvestigationRequestDate %>"
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" width="150">
                                                    <asp:TextBox ID="txtInvReqDate" AutoPostBack="true" OnTextChanged="txtInvReqDate_TextChanged"
                                                        Enabled="false" Width="110px" CssClass="csstxtbox" runat="server" Style="text-align: justify"
                                                        ValidationGroup="Apply"></asp:TextBox>
                                                    <asp:ImageButton ID="IMGInvReqDate" Style="vertical-align: middle" CausesValidation="true"
                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtInvReqDate" PopupButtonID="IMGInvReqDate" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtInvReqDate" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblInvestigationStatus" CssClass="cssLabel" Width="110px" runat="server"
                                                        Text="<%$ Resources:Resource, InvestigationStatus %>"></asp:Label>
                                                </td>
                                                <td align="left" width="140">
                                                    <asp:DropDownList ID="ddlInvestigationStatus" AutoPostBack="false" Width="160px"
                                                        CssClass="cssDropDown" runat="server">
                                                        <asp:ListItem Text="<%$ Resources:Resource, Pending %>" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="<%$ Resources:Resource, Completed %>" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table width="100%" border="0">
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Panel ID="PanelAssignmentDetails" Width="890px" GroupingText="<%$ Resources:Resource, IncidentDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890">
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="lblIncCompNo" Width="100px" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, IncidentComplainNo %>"
                                                                        Font-Bold="True"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtIncidentNo" MaxLength="32" CssClass="csstxtbox" Width="110px"
                                                                        runat="server" AutoPostBack="True" OnTextChanged="txtIncCompNo_TextChanged"></asp:TextBox>
                                                                    <asp:ImageButton ID="IMGIncidentSearch" AlternateText="<%$ Resources:Resource, SearchIncident %>"
                                                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtIncidentNo" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblIncident" Width="100px" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, IncidentType %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="150px">
                                                                    <asp:TextBox ID="txtIncidentType" MaxLength="32" CssClass="csstxtbox" Width="150px"
                                                                        runat="server" AutoPostBack="True" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblOccDate" CssClass="cssLabel" Width="100px" runat="server" Text="<%$ Resources:Resource, OccuranceDate %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="150px">
                                                                    <asp:TextBox ID="txtOccDate" AutoPostBack="false" Width="160px" CssClass="csstxtbox"
                                                                        runat="server" Style="text-align: justify" ValidationGroup="Apply" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblCustID" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="5">
                                                                    <asp:DropDownList ID="ddlClientId" Width="740px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        Enabled="false" runat="server" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblAssignNo" CssClass="cssLabel" Width="100px" runat="server" Text="<%$Resources:Resource,AsmtID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="5">
                                                                    <asp:DropDownList ID="ddlAsmtId" Width="740px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        Enabled="false" runat="server" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblAreaID" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="570px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table border="0" width="890px">
                                            <tr>
                                                <td align="right" width="120" nowrap="nowrap">
                                                    <asp:Label ID="lblInvReason" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ReasonForInvestigation %>"
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" width="150px" colspan="4">
                                                    <asp:DropDownList ID="ddlInvReason" AutoPostBack="true" Width="145px" CssClass="cssDropDown"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                        ControlToValidate="ddlInvReason" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblDetails" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Details %>"
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" nowrap="nowrap" colspan="4">
                                                    <asp:TextBox ID="txtDetails" CssClass="csstxtbox" Width="755px" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtDetails" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" nowrap="nowrap">
                                                    <asp:Label ID="lblRequstedBy" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,RequestedBy %>"
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" nowrap="nowrap">
                                                    <asp:TextBox ID="txtEmployeeID" CssClass="csstxtbox" Width="140px" runat="server"
                                                        AutoPostBack="true" OnTextChanged="txtEmployeeID_TextChanged"></asp:TextBox>
                                                    <asp:ImageButton ID="IMGEmployeeNumber" AlternateText="<%$Resources:Resource,SearchClient %>"
                                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtEmployeeID" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right" nowrap="nowrap">
                                                    <asp:Label ID="lblDesignation" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                </td>
                                                <td align="left" nowrap="nowrap">
                                                    <asp:TextBox ID="txtEmpDesignation" CssClass="csstxtbox" Width="140px" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:LinkButton ID="lnkInvestigationDetails" runat="server" Text="<%$Resources:Resource,InvestigationDetail %>"
                                                        OnClick="lnkInvestigationDetails_Click"></asp:LinkButton>
                                                    <%-- <asp:HyperLink ID="lnkInvestigationDetails" runat="server" NavigateUrl="~/OperationManagement/InvestigationRequestDetails.aspx"></asp:HyperLink>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" nowrap="nowrap" width="100">
                                                </td>
                                                <td align="right" nowrap="nowrap" width="140">
                                                </td>
                                                <td align="right" colspan="3">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table width="890">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlUploadDoc" runat="server" GroupingText="<%$ Resources:Resource, UploadDownload %>">
                                                        <div id="DIVUpload" runat="server">
                                                            <table width="700" border="0" align="center">
                                                                <tr>
                                                                    <td align="right" width="180px">
                                                                        <asp:Label ID="LabelUploadDesc" Width="150px" runat="server" CssClass="cssLabel"
                                                                            Text="<%$ Resources:Resource, UploadDesc %>"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="400">
                                                                        <asp:TextBox ID="txtUploadDesc" Width="400px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" width="180px" nowrap="nowrap">
                                                                        <asp:Label ID="lblFileUpload" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, UploadDownload %>"></asp:Label>
                                                                    </td>
                                                                    <td width="400">
                                                                        <asp:FileUpload ID="EmployeeDocUpload" CssClass="csstxtbox" Width="400px" Height="19px"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td align="left" width="100">
                                                                        <asp:Button ID="btnUpload" CssClass="cssButton" runat="server" Height="19px" Text="<%$ Resources:Resource, Upload %>"
                                                                            Enabled="false" OnClick="btnUpload_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div id="dvFileUploadGrid" runat="server">
                                                            <table width="700" border="0" align="center">
                                                                <tr>
                                                                    <td>
                                                                        <div id="DivGridView" runat="server">
                                                                            <div style="width: 700px;">
                                                                                <div class="squarebox">
                                                                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                                                        <div style="float: left; width: 670px;">
                                                                                            <tt style="text-align: center;">
                                                                                                <asp:Label ID="Label23" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, DownloadInfo %>"></asp:Label></tt></div>
                                                                                    </div>
                                                                                    <div class="squareboxcontent">
                                                                                        <asp:Panel ID="pnlFileUpload" runat="server" Height="65px" ScrollBars="Auto">
                                                                                            <asp:GridView Width="650px" ID="gvEmployeeDocument" AllowPaging="True" CssClass="GridViewStyle"
                                                                                                runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" AllowSorting="False"
                                                                                                PageSize="6" OnRowDataBound="gvEmployeeDocument_RowDataBound" OnRowDeleting="gvEmployeeDocument_RowDeleting">
                                                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, SerialNumber %>">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, FileName %>" SortExpression="FileName">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lbFileName" CssClass="csslink" runat="server" Text='<%# Bind("FileName") %>'
                                                                                                                OnClick="lbFileName_Click" OnPreRender="lbFileName_PreRender"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, Description %>" SortExpression="UploadDesc">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblUploadDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("UploadDesc") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, Date %>" SortExpression="UploadDesc">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblUploadDate" CssClass="cssLabel" runat="server" Text='<%# Bind("UploadDate") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, Action %>">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                                                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </asp:Panel>
                                                                                    </div>
                                                                                </div>
                                                                                
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                        OnClick="btnAddNew_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Apply" runat="server"
                                        Text="<%$Resources:Resource,Save %>" Visible="false" OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAuthorize" CssClass="cssButton" ValidationGroup="Apply" Visible="false"
                                        runat="server" Text="<%$Resources:Resource,Authorize %>" OnClick="btnAuthorize_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEdit" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Edit %>"
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
                                <td align="center">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" CssClass="csslblErrMsg" runat="server"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnUpload" />
                    </Triggers>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
