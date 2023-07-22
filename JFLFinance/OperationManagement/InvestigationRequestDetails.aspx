<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="InvestigationRequestDetails.aspx.cs" Inherits="OperationManagement_InvestigationRequestDetails"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="950" border="0">
                            <tr>
                                <td width="200" align="right">
                                    <asp:Label ID="lblInvestigationReq" Width="180px" CssClass="cssLabel" runat="server"
                                        Text="Investigation Detail Number"></asp:Label>
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
                                    <asp:ImageButton ID="IMGInvestigationNo" AlternateText="SearchInvestigation" runat="server"
                                        ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="right">
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
                                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="Investigation Details"></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" width="890px">
                                            <tr>
                                                <td align="right" width="140">
                                                    <asp:Label ID="lblInvDetDate" CssClass="cssLabel" Width="100px" runat="server" Text="Inv. Det. Date"
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" width="150">
                                                    <asp:TextBox ID="txtInvDetDate" AutoPostBack="false" Width="110px" CssClass="csstxtbox"
                                                        Enabled="false" runat="server" Style="text-align: justify" ValidationGroup="Apply"></asp:TextBox>
                                                    <asp:ImageButton ID="IMGInvReqDate" Style="vertical-align: middle" CausesValidation="true"
                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtInvDetDate" PopupButtonID="IMGInvReqDate" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtInvDetDate" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0">
                                            <tr>
                                                <td colspan="5" style="height: 194px">
                                                    <asp:Panel ID="PanelAssignmentDetails" Width="910px" GroupingText="Incident/Complaint Details"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890">
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblInvestigationNoShow" Width="100px" CssClass="cssLabel" runat="server"
                                                                        Text="Inv. Req. No."></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:TextBox ID="txtInvestigationNoShow" MaxLength="32" Enabled="false" CssClass="csstxtbox"
                                                                        Width="110px" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblIncidentNo" CssClass="cssLabel" Width="90px" runat="server" Text="Inc./Comp. No."></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtIncidentNo" AutoPostBack="false" Width="110px" CssClass="csstxtbox"
                                                                        runat="server" Style="text-align: justify" ValidationGroup="Apply" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblCustID" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140px">
                                                                    <asp:DropDownList ID="ddlClientId" Width="450px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        Enabled="false" runat="server" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblIncident" Width="130px" CssClass="cssLabel" runat="server" Text="Incident Type"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtIncidentType" MaxLength="32" CssClass="csstxtbox" Width="110px"
                                                                        runat="server" AutoPostBack="True" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblAssignNo" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AsmtID %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlAsmtId" Width="450px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        Enabled="false" runat="server" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblAreaID" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="110px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblAreaDesc" Width="130px" CssClass="cssLabel" runat="server" Text="Area Desc"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="445px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblReasonForInv" Width="100px" CssClass="cssLabel" runat="server"
                                                                        Text="Reason For Inv."></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtReasonForInv" CssClass="csstxtbox" Enabled="false" Width="110px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblDetails" Width="130px" CssClass="cssLabel" runat="server" Text="Details"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDetails" CssClass="csstxtbox" Enabled="false" Width="445px" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblInvPreparedBy" Width="100px" CssClass="cssLabel" runat="server"
                                                                        Text="Prepared By" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtEmployeeID" AutoPostBack="true" CssClass="csstxtbox" Width="110px"
                                                                        runat="server" OnTextChanged="txtEmployeeID_TextChanged1"></asp:TextBox>
                                                                    <asp:ImageButton ID="IMGEmployeeNumber" AlternateText="SearchInvestigation" runat="server"
                                                                        ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtEmployeeID" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblName" Width="130px" CssClass="cssLabel" runat="server" Text="Name"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtEmployeeName" CssClass="csstxtbox" Enabled="false" Width="445px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblDesignation" Width="100px" CssClass="cssLabel" runat="server" Text="Designation"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtEmpDesignation" CssClass="csstxtbox" Enabled="false" Width="110px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblFindings" Width="130px" CssClass="cssLabel" runat="server" Text="Findings"
                                                                        Font-Bold="True"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtFindings" CssClass="csstxtbox" Width="445px" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtFindings" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblLegalAssist" Width="100px" CssClass="cssLabel" runat="server" Text="Legal Assistance"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlLegalAssistance" AutoPostBack="true" Width="115px" CssClass="cssDropDown"
                                                                        runat="server">
                                                                        <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblInvolved" Width="130px" CssClass="cssLabel" runat="server" Text="Staff Involved"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlStaffInvolved" AutoPostBack="true" Width="115px" CssClass="cssDropDown"
                                                                        runat="server">
                                                                        <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblCustInvolved" Width="100px" CssClass="cssLabel" runat="server"
                                                                        Text="Cust. Involved"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlCustInvolved" AutoPostBack="true" Width="115px" CssClass="cssDropDown"
                                                                        runat="server">
                                                                        <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right" colspan="2">
                                                                    <asp:HyperLink ID="lnkInvestigationRequest" runat="server" NavigateUrl="~/OperationManagement/InvestigationRequest.aspx">Investigation Request</asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" width="890px">
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
                                                                        <asp:FileUpload ID="EmployeeDocUpload" CssClass="csstxtbox" Width="400px" Height="19px" runat="server" />
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
                                                                                                                OnClick="lbFileName_Click" OnPreRender ="lbFileName_PreRender"></asp:LinkButton>
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
                        <br />
                        <table align="center" border="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" CssClass="cssButton" 
                                        OnClick="btnSave_Click" Text="<%$Resources:Resource,Save %>" 
                                        ValidationGroup="Apply" Visible="false" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" 
                                        OnClick="btnAuthorize_Click" Text="Authorize" ValidationGroup="Apply" 
                                        Visible="false" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEdit" runat="server" CssClass="cssButton" 
                                        OnClick="btnEdit_Click" Text="Edit" Visible="false" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" 
                                        OnClick="btnUpdate_Click" Text="<%$Resources:Resource,Update %>" 
                                        ValidationGroup="Apply" Visible="false" />
                                </td>
                                <td>
                                    <asp:Button ID="btnReset" runat="server" CssClass="cssButton" 
                                        OnClick="btnReset_Click" Text="<%$Resources:Resource,Reset %>" 
                                        Visible="false" />
                                </td>
                                <td>
                                    <asp:HiddenField ID="hfMessageToEdit" runat="server" />
                                    <asp:HiddenField ID="hfInvRequestDate" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="890">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblError" runat="server" CssClass="csslblErrMsg" 
                                        EnableViewState="false" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 18px">
                                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" 
                                        EnableViewState="false" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnUpload" />
                    </Triggers>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
