<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SiteInstruction.aspx.cs" Inherits="Masters_SiteInstruction" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="950" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="225" align="right" nowrap="nowrap">
                                    <asp:Label ID="lblAsmtInstNo" Width="225px" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AssignmentInstructionNumber %>"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAssignInstNo" MaxLength="35" Width="110px" AutoPostBack="true"
                                        CssClass="csstxtbox" runat="server" OnTextChanged="txtAssignInstNo_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="IMGInstructionSearch" AlternateText="<%$Resources:Resource,SearchInstruction%>"
                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="right" width="160">
                                    <asp:Label ID='lblTrnS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                    <asp:Label ID="lblStatus" CssClass="csstxtbox" Width="110px" runat="server" Style="text-align: center"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Panel ID="PanelMain" runat="server" Width="98%">
                            <div style="width: 98%;">
                                <div class="squarebox">
                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;">
                                        <div style="float: left; width: 900px;">
                                            <tt style="text-align: center;">
                                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,AssignmentInst %>"></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" width="890px" style="vertical-align: top">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblAssignInstDate" CssClass="cssLabel" Width="90px" runat="server"
                                                        Text="<%$ Resources:Resource, Date %>" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" width="190">
                                                    <asp:TextBox ID="txtAssignInstDate" AutoPostBack="false" Width="110px" CssClass="csstxtbox"
                                                        Enabled="false" runat="server" Style="text-align: justify" ValidationGroup="Apply"></asp:TextBox>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtAssignInstDate" PopupButtonID="IMGAssignInstDate" />
                                                    <asp:ImageButton ID="IMGAssignInstDate" Visible="true" Style="vertical-align: middle"
                                                        CausesValidation="false" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtAssignInstDate" ValidationGroup="Apply" ErrorMessage="*"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblNextRivisionDate" CssClass="cssLabel" Width="150px" runat="server"
                                                        Text="<%$ Resources:Resource, NextRivisionDate %>" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" width="190">
                                                    <asp:TextBox ID="txtNextRivisionDate" AutoPostBack="false" Width="110px" CssClass="csstxtbox"
                                                        Enabled="false" runat="server" Style="text-align: justify" ValidationGroup="Apply"
                                                        OnTextChanged="txtNextRivisionDate_TextChanged"></asp:TextBox>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtNextRivisionDate" PopupButtonID="IMGNextRivisionDate" />
                                                    <asp:ImageButton ID="IMGNextRivisionDate" Visible="true" Style="vertical-align: middle"
                                                        CausesValidation="false" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtNextRivisionDate" ValidationGroup="Apply" ErrorMessage="*"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right" width="600" colspan="6">
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0">
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Panel ID="PanelAssignmentDetails" Width="890px" GroupingText="<%$ Resources:Resource, AssignmentDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890">
                                                            <tr>
                                                                <td align="right" width="120">
                                                                    <asp:Label ID="Label3" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:DropDownList ID="ddlClientId" Width="750px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblAssignNo" CssClass="cssLabel" Width="100px" runat="server" Text="<%$ Resources:Resource, AsmtID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:DropDownList ID="ddlAsmtId" Width="750px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="hfAsmtStartDate" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblAreaID" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="595px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0">
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Panel ID="pnlOtherDetails" Width="890px" GroupingText="<%$ Resources:Resource, OtherDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890px">
                                                            <tr>
                                                                <td align="right" nowrap="nowrap">
                                                                    <asp:Label ID="lblPrepDate" Width="100px" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, PreparedDate %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="180px" nowrap="nowrap">
                                                                    <asp:TextBox ID="txtPrepDate" runat="server" Width="140px" CssClass="csstxtbox" Enabled="false"
                                                                        Style="text-align: justify" ValidationGroup="Apply"></asp:TextBox>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtPrepDate" PopupButtonID="IMGPrepDate" />
                                                                    <asp:ImageButton ID="IMGPrepDate" Visible="true" Style="vertical-align: middle" CausesValidation="false"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtPrepDate" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" width="90" nowrap="nowrap">
                                                                    <asp:Label ID="lblReason" Width="90px" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Reason %>"></asp:Label>
                                                                </td>
                                                                <td align="right" width="130" nowrap="nowrap">
                                                                    <asp:DropDownList ID="ddlInstReason" AutoPostBack="false" Width="130px" CssClass="cssDropDown"
                                                                        runat="server">
                                                                        <asp:ListItem Text="<%$ Resources:Resource,Initial%>" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$ Resources:Resource,Routine%>" Value="1"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                                        ControlToValidate="ddlInstReason" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" width="100" nowrap="nowrap">
                                                                    <asp:Label ID="lblClientSigned" Width="100px" CssClass="cssLabel" runat="server"
                                                                        Text="<%$ Resources:Resource,ClientSigned%>"></asp:Label>
                                                                </td>
                                                                <td align="left" nowrap="nowrap" style="width: 206px">
                                                                    <asp:DropDownList ID="ddlClientSinged" AutoPostBack="true" Width="115px" CssClass="cssDropDown"
                                                                        runat="server" OnSelectedIndexChanged="ddlClientSinged_TextChanged">
                                                                        <asp:ListItem Text="<%$ Resources:Resource,Yes%>" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$ Resources:Resource,No%>" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                                        ControlToValidate="ddlClientSinged" ValidationGroup="Apply" ErrorMessage="*"
                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" width="680" colspan="1">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" nowrap="nowrap">
                                                                    <asp:Label ID="lblSignDate" Width="100px" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,SingingDate%>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="180px" nowrap="nowrap">
                                                                    <asp:TextBox ID="txtSingingDate" runat="server" Width="140px" CssClass="csstxtbox"
                                                                        Enabled="false" Style="text-align: justify" ValidationGroup="Apply"></asp:TextBox>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtSingingDate" PopupButtonID="IMGSingingDate" />
                                                                    <asp:ImageButton ID="IMGSingingDate" Visible="true" Style="vertical-align: middle"
                                                                        CausesValidation="false" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                </td>
                                                                <td align="right" width="90" nowrap="nowrap">
                                                                    <asp:Label ID="lblClientRepSinged" Width="90px" CssClass="cssLabel" runat="server"
                                                                        Text="<%$ Resources:Resource,ClientRepresentative %>"></asp:Label>
                                                                </td>
                                                                <td align="right" width="125" nowrap="nowrap">
                                                                    <asp:TextBox ID="txtClientRepSinged" CssClass="csstxtbox" Width="125px" runat="server"
                                                                        AutoPostBack="false"></asp:TextBox>
                                                                </td>
                                                                <td align="right" width="100" nowrap="nowrap">
                                                                    <asp:Label ID="lblDesignationClient" Width="100px" CssClass="cssLabel" runat="server"
                                                                        Text="<%$ Resources:Resource,Designation%>"></asp:Label>
                                                                </td>
                                                                <td align="left" nowrap="nowrap" style="width: 216px">
                                                                    <asp:TextBox ID="txtDesignation" CssClass="csstxtbox" Width="216px" runat="server"
                                                                        AutoPostBack="false"></asp:TextBox>
                                                                </td>
                                                                <td align="right" width="680" colspan="1">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" nowrap="nowrap">
                                                                    <asp:Label ID="lblResonNotSigned" Width="120px" CssClass="cssLabel" runat="server"
                                                                        Text="<%$ Resources:Resource,ReasonNotSigned%>"></asp:Label>
                                                                </td>
                                                                <td align="right" width="745" nowrap="nowrap" colspan="5">
                                                                    <asp:TextBox ID="txtReasonNotSigned" CssClass="csstxtbox" Width="745px" runat="server"
                                                                        AutoPostBack="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" nowrap="nowrap">
                                                                    <asp:Label ID="lblIndustryType" Width="100px" CssClass="cssLabel" runat="server"
                                                                        Visible="false" Text="<%$ Resources:Resource,Industry%>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="180" nowrap="nowrap">
                                                                    <asp:HiddenField ID="hfLocationAutoID" runat="server" />
                                                                    <asp:DropDownList ID="ddlIndustryType" AutoPostBack="true" Width="200px" CssClass="cssDropDown"
                                                                        runat="server" OnSelectedIndexChanged="ddlIndustryType_SelectedIndexChanged"
                                                                        Visible="false">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right" width="680" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="120" nowrap="nowrap">
                                                                    <asp:Label ID="lblPreparedBy" Width="100px" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, PreparedBy %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="190" nowrap="nowrap">
                                                                    <asp:TextBox ID="txtEmployeeID" CssClass="csstxtbox" Width="140px" runat="server"
                                                                        AutoPostBack="true" OnTextChanged="txtEmployeeID_TextChanged"></asp:TextBox>
                                                                    <asp:ImageButton ID="IMGEmployeeNumber" AlternateText="SearchClient" runat="server"
                                                                        ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtEmployeeID" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" width="210" nowrap="nowrap" colspan="2">
                                                                    <asp:Label ID="lblEmployeeName" Width="230px" CssClass="csstxtbox" runat="server"
                                                                        Style="text-align: left"></asp:Label>
                                                                </td>
                                                                <td align="right" nowrap="nowrap">
                                                                    <asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Designation %>"></asp:Label>
                                                                </td>
                                                                <td align="right" nowrap="nowrap" style="width: 216px">
                                                                    <asp:Label ID="lblEmpDesignation" Width="216px" CssClass="csstxtbox" runat="server"
                                                                        Style="text-align: left"></asp:Label>
                                                                </td>
                                                                <td align="right" width="380" colspan="1">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="890px" border="0">
                                            <tr>
                                                <td colspan="5">
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
                                                                                                                OnClick="lbFileName_Click"  OnPreRender ="lbFileName_PreRender"></asp:LinkButton>
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
                        <table width="890" border="0">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblError" runat="server" Text="" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label1" EnableViewState="false" CssClass="csslblErrMsg" runat="server"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <div style="width: 950px;">
                                            <div class="squarebox">
                                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                    <div style="float: left; width: 930px;">
                                                        <tt style="text-align: center;">
                                                            <asp:Label ID="lblDivHdr1" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, SiteInstructionForIndustry %>"></asp:Label></tt></div>
                                                </div>
                                                <div class="squareboxcontent">
                                                    <asp:Panel ID="PanelOurRep" BorderWidth="0px" ScrollBars="Auto" CssClass="ScrollBar"
                                                        Height="100px" runat="server">
                                                        <asp:GridView Width="900px" ID="gvSiteInstruction" CssClass="GridViewStyle" runat="server"
                                                            ShowFooter="True" AllowPaging="True" AllowSorting="false" PageSize="6" CellPadding="1"
                                                            GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvSiteInstruction_PageIndexChanging"
                                                            OnRowCancelingEdit="gvSiteInstruction_RowCancelingEdit" OnRowCommand="gvSiteInstruction_RowCommand"
                                                            OnRowDataBound="gvSiteInstruction_RowDataBound" OnRowUpdating="gvSiteInstruction_RowUpdating"
                                                            DataKeyNames="SiteInstruction" OnRowEditing="gvSiteInstruction_RowEditing" OnSorting="gvSiteInstruction_Sorting"
                                                            OnRowDeleting="gvSiteInstruction_RowDeleting">
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
                                                                            CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="EditSiteInstruction" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                            CommandName="Cancel" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                            CssClass="cssImgButton" ValidationGroup="AddNewSiteInstruction" CommandName="AddNew"
                                                                            ImageUrl="../Images/AddNew.gif" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                            CssClass="csslnkButton" ValidationGroup="EditSiteInstruction" runat="server"
                                                                            CausesValidation="False" CommandName="Edit" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="IBDeleteSiteInstruction" ToolTip="<%$Resources:Resource,Delete %>"
                                                                            ImageUrl="~/Images/Delete.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                                                            CommandName="Delete" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                                                    <ItemStyle Width="50px" />
                                                                    <FooterStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Row ID" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblRowID" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowID" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="600px" />
                                                                    <ItemStyle Width="600px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblInstructionType" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,InstructionType %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInstructionType" CssClass="cssLable" runat="server" Text='<%# Bind("ItemDesc") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList Width="250px" Height="25px" ID="ddlInstructionType" CssClass="csstxtbox" AutoPostBack="true" runat="server" />
                                                                        <asp:HiddenField ID="hfInstructionType" runat="server" Value='<%# Bind("InstructionTypeID") %>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList Width="250px" Height="25px" ID="ddlInstructionType" CssClass="csstxtbox" OnSelectedIndexChanged="ddlInstructionType_SelectedIndexChanged"
                                                                            AutoPostBack="true" runat="server" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Instruction %>" SortExpression="SiteInstruction">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtSiteInstruction" Width="580px" MaxLength="255" CssClass="csstxtbox" AutoPostBack="true"
                                                                            Text='<%# Bind("SiteInstruction") %>' runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSiteInstruction"
                                                                            ErrorMessage="" ValidationGroup="EditSiteInstruction" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSiteInstruction" CssClass="cssLabel" runat="server" Text='<%# Bind("SiteInstruction") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                         <telerik:RadComboBox ID="txtNewSiteInstruction" AllowCustomText="true" AccessKey="C" CloseDropDownOnBlur="true"
                                                                            EnableEmbeddedSkins="true" Filter="Contains" IsCaseSensitive="false" Width="580px" runat="server">
                                                                        </telerik:RadComboBox>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="600px" />
                                                                    <ItemStyle Width="670px" />
                                                                    <FooterStyle Width="670px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </div>
                                            </div>
                                            
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                            OnClick="btnAddNew_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Apply" runat="server"
                                            Text="<%$Resources:Resource,Save %>" OnClick="btnSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAuthorize" CssClass="cssButton" runat="server" Text="Authorize"
                                            OnClick="btnAuthorize_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnEdit" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Edit %>"
                                            OnClick="btnEdit_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdate" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Update %>"
                                            OnClick="btnUpdate_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnReset" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Reset %>"
                                            OnClick="btnReset_Click" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hfMessageToEdit" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                                    <asp:HiddenField ID="hfSiteInstruction" runat="server" />
                                    <asp:HiddenField ID="hfMessageDisable" runat="server" Value="<%$Resources:Resource,Disable %>" />
                                    <asp:HiddenField ID="hfMessageUpdate" runat="server" Value="<%$Resources:Resource,Update %>" />
                                    <asp:HiddenField ID="hfResult" runat="server" />
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
