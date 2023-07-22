<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="WarningMaster.aspx.cs" Inherits="OperationManagement_WarningMaster"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
              <%--  <asp:ScriptManager ID="ToolkitScriptManager2" EnableScriptGlobalization="true"
                    EnableScriptLocalization="true" runat="server" EnablePartialRendering="true">--%>
                
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" width="100%" align="left" style="vertical-align: top" cellpadding="1"
                            cellspacing="1">
                            <tr>
                                <td align="right" width="130">
                                    <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,StatusChangeNo %>"></asp:Label>
                                </td>
                                <td align="left" width="200"> 
                                    <asp:TextBox ID="txtStatusChgNo" CssClass="csstxtbox" Width="150px" runat="server"
                                        AutoPostBack="True" OnTextChanged="txtStatusChgNo_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="IMGStatusChgNo" AlternateText="<%$Resources:Resource,SearchStatusChangeNumber %>" 
                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="right" width="200">
                                    <asp:Label ID="lblddlAmendNo" runat="server" Text="<%$Resources:Resource,AmendNo %>"></asp:Label>
                                </td>
                                <td align="left" width="200">
                                    <asp:DropDownList ID="ddlAmendNo" CssClass="cssDropDown" Width="150px" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlAmendNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblAmendNo" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left" width="200">
                                    <asp:Label ID="lblWarningDamageStatus" Font-Bold="true" Width="150px" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <div style="width: 950px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width:930px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label3" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,WarningMaster %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table border="0" width="930" style="vertical-align: top" cellpadding="1" cellspacing="1">
                                                    <tr>
                                                        <td align="right" style="width:150px">
                                                            <asp:Label ID="Label4" CssClass="cssLabel" Width="150px" runat="server" Text="<%$Resources:Resource,StatusChangeDate %>"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width:200px">
                                                            <asp:TextBox ID="txtStatusChgDate" AutoPostBack="true" ValidationGroup="Save" Width="120px" CssClass="csstxtbox"
                                                                runat="server" OnTextChanged="txtStatusChgDate_TextChanged"></asp:TextBox>
                                                            <asp:ImageButton ID="IMGStatusChgDate" Style="vertical-align: middle" CausesValidation="false"
                                                                runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                                TargetControlID="txtStatusChgDate" PopupButtonID="IMGStatusChgDate" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                ControlToValidate="txtStatusChgDate" ValidationGroup="Save" ErrorMessage="*"
                                                                Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="right" width="100">
                                                            <asp:Label ID="lblAmendDate" runat="server" Width="90px" Text="<%$ Resources:Resource,AmendDate %>" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="left" width="150">
                                                            <asp:TextBox ID="txtAmendDate" Width="120px" AutoPostBack="true" CssClass="csstxtbox" runat="server"
                                                                Style="text-align: justify" OnTextChanged="txtAmendDate_TextChanged" Visible="False"></asp:TextBox>
                                                            <asp:ImageButton ID="IMGAmendDate" Style="vertical-align: middle" CausesValidation="false"
                                                                runat="server" ImageUrl="~/Images/pdate.gif" Visible="False"></asp:ImageButton>
                                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                TargetControlID="txtAmendDate" PopupButtonID="IMGAmendDate" />
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,Status %>" CssClass="cssLabel"></asp:Label>
                                                        </td>
                                                        <td align="left" width="200">
                                                            <asp:DropDownList ID="ddlStatus" Width="200px" CssClass="cssDropDown" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="1" cellspacing="1">
                                                    <tr>
                                                        <td colspan="5">
                                                            <asp:Panel ID="PanelAssignmentDetails" Width="930px" GroupingText="<%$Resources:Resource,AssignmentDetails %>"
                                                                BorderWidth="0px" runat="server">
                                                                <table border="0" width="920" cellpadding="1" cellspacing="1">
                                                                    <tr>
                                                                        <td align="right" width="120">
                                                                            <asp:Label ID="Label8" Width="120px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AssignmentNumber %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="2" width="180">
                                                                            <asp:TextBox ID="txtAssignNo" MaxLength="32" ValidationGroup="Save" CssClass="csstxtbox"
                                                                                Width="140px" runat="server" AutoPostBack="True" OnTextChanged="txtAssignNo_TextChanged"></asp:TextBox>
                                                                            <asp:ImageButton ID="imgAssignSearch" AlternateText= "<%$Resources:Resource,SearchAssignment %>" runat="server"
                                                                                ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtAssignNo" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="120" nowrap="nowrap">
                                                                            <asp:Label ID="Label9" Width="120px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="140">
                                                                            <asp:TextBox ID="txtCustomerID" CssClass="csstxtbox" Enabled="false" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" colspan="3">
                                                                            <asp:TextBox ID="txtCustomerDesc" CssClass="csstxtbox" Enabled="false" Width="640px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="120" nowrap="nowrap">
                                                                            <asp:Label ID="Label10" Width="120px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AddressID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="140">
                                                                            <asp:TextBox ID="txtAddressID" CssClass="csstxtbox" Enabled="false" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" colspan="3">
                                                                            <asp:TextBox ID="txtAddressDesc" CssClass="csstxtbox" Enabled="false" Width="640px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="120" nowrap="nowrap">
                                                                            <asp:Label ID="Label11" Width="120px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="140">
                                                                            <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" colspan="3">
                                                                            <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="640px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblErrorMsg" runat="server" Text="" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                                <table cellpadding="1" cellspacing="1">
                                                    <tr>
                                                        <td colspan="5">
                                                            <asp:Panel ID="PanelIncidentDetails" Width="930px" GroupingText="<%$Resources:Resource,Details %>"
                                                                BorderWidth="0px" runat="server">
                                                                <table border="0" width="920" style="vertical-align: top" cellpadding="1" cellspacing="1">
                                                                    <tr>
                                                                        <td align="right" width="120">
                                                                            <asp:Label ID="Label7" CssClass="cssLabel" Width="120px" runat="server" Text="<%$Resources:Resource,MeetingNo %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="150">
                                                                            <asp:DropDownList ID="ddlMeetingNo" Width="130" CssClass="cssDropDown" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="right" width="120" nowrap="nowrap">
                                                                            <asp:Label ID="Label12" runat="server" Width="120px" Text="<%$Resources:resource,ReasonForChange %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="150">
                                                                            <asp:DropDownList ID="ddlReason4Change" CssClass="cssDropDown" Width="150px" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="right" width="130" nowrap="nowrap">
                                                                            <asp:Label ID="Label13" runat="server" Width="130px" Text="<%$Resources:Resource,ComfortStatusOf %>"
                                                                                CssClass="cssLabel"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="150">
                                                                            <asp:DropDownList ID="ddlComfortStatusOf" Width="150px" CssClass="cssDropDown" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="120">
                                                                            <asp:Label ID="Label16" CssClass="cssLabel" Width="120px" runat="server" Text="<%$Resources:Resource,IncidentComplainNo %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="150">
                                                                            <%--<asp:TextBox ID="txtIncidentNo" MaxLength="35" CssClass="csstxtbox" Width="150px"
                                                                                runat="server" AutoPostBack="True" OnTextChanged="txtIncidentNo_TextChanged"></asp:TextBox>--%>
                                                                            <asp:DropDownList ID="ddlIncidentNo" Width="130" CssClass="cssDropDown" runat="server"
                                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlIncidentNo_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="right" width="120">
                                                                            <asp:Label ID="Label18" CssClass="cssLabel" Width="120px" runat="server" Text="<%$Resources:Resource,IncidentType %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="200">
                                                                            <asp:TextBox ID="txtIncidentType" Enabled="false" Width="120px" CssClass="csstxtbox"
                                                                                runat="server" Style="text-align: justify"></asp:TextBox>
                                                                        </td>
                                                                        <td align="right" width="130">
                                                                            <asp:Label ID="Label17" runat="server" Width="130px" Text="<%$Resources:Resource,InvestigationStatus %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="150">
                                                                            <asp:TextBox ID="txtInvestigationStatus" Enabled="false" MaxLength="25" CssClass="csstxtbox"
                                                                                Width="120px" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="120">
                                                                            <asp:Label ID="Label19" CssClass="cssLabel" Width="120px" runat="server" Text="<%$Resources:Resource,EnteredBy %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="3">
                                                                            <asp:TextBox ID="txtEmployeeID" MaxLength="16" CssClass="csstxtbox" Width="120px"
                                                                                runat="server" AutoPostBack="True" OnTextChanged="txtEmployeeID_TextChanged"></asp:TextBox>
                                                                            <asp:TextBox ID="txtEmployeeName" Enabled="false" CssClass="csstxtbox" Width="300px"
                                                                                runat="server"></asp:TextBox>
                                                                            <asp:ImageButton ID="IMGEmployeeNumber" AlternateText="<%$Resources:Resource,SearchEmployee %>"  runat="server"
                                                                                ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtEmployeeID" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="right" width="130">
                                                                            <asp:Label ID="Label20" CssClass="cssLabel" Width="130px" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDesignation" Enabled="false" CssClass="csstxtbox" Width="120px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="120" nowrap="nowrap">
                                                                            <asp:Label ID="Label21" CssClass="cssLabel" Width="120px" runat="server" Text="<%$Resources:Resource,FinancialImplication %>"></asp:Label>
                                                                        </td>
                                                                        <td colspan="5" align="left">
                                                                            <asp:TextBox ID="txtFinancialImplication" MaxLength="100" CssClass="csstxtbox" Width="750px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="120">
                                                                            <asp:Label ID="Label14" CssClass="cssLabel" Width="120px" runat="server" Text="<%$Resources:Resource,BriefOfproblem %>"></asp:Label>
                                                                        </td>
                                                                        <td colspan="5" align="left">
                                                                            <asp:TextBox ID="txtBriefOfProblem" MaxLength="100" CssClass="csstxtbox" Width="750px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" nowrap="nowrap">
                                                                            <asp:Label ID="Label15" CssClass="cssLabel" Width="100px" runat="server" Text="<%$Resources:Resource,BriefOfResolution %>"></asp:Label>
                                                                        </td>
                                                                        <td colspan="5" align="left">
                                                                            <asp:TextBox ID="txtBriefOfResolution" MaxLength="100" CssClass="csstxtbox" Width="750px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                        OnClick="btnAddNew_Click" Visible="False" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Save" CommandName="Save"
                                        runat="server" Text="<%$Resources:Resource,Save %>" Visible="false" OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" CssClass="cssButton" runat="server" Visible="false" Text="<%$Resources:Resource,Update %>"
                                        OnClick="btnUpdate_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Text="<%$Resources:resource,Authorized %>" OnClick="btnAuthorize_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAmend" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Amend %>"
                                        OnClick="btnAmend_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEdit" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Edit %>"
                                        OnClick="btnEdit_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Cancel %>"
                                        OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hfIncidentNumber" runat="server" />
                                    <asp:HiddenField ID="hfMeetingNumber" runat="server" />
                                    <asp:HiddenField ID="hfAsmtStartDate" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
