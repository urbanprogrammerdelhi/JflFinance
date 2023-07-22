<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="IncidentMaster.aspx.cs" Inherits="OperationManagement_IncidentMaster"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="890" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="180">
                                    <asp:Label ID="lblIncidentNo" Width="180px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,IncidentComplainNo %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtIncidentNo" MaxLength="35" Width="120px" AutoPostBack="true"
                                        CssClass="csstxtbox" runat="server" OnTextChanged="txtIncidentNo_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="IMGIncidentSearch" AlternateText="<%$ Resources:Resource, SearchIncident %>"
                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="left">
                                    <asp:Label ID='lblTrnS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                    <asp:Label ID="lblIncidentStatus" runat="server" CssClass="csstxtbox" Width="110px"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblError" runat="server" Text="" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="PanelMain" runat="server" Width="98%">
                            <div style="width: 98%;">
                                <div class="squarebox">
                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                        <div style="float: left;">
                                            <tt style="text-align: center; height: 20;">
                                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,IncidentMaster %>"></asp:Label></tt>
                                            <%-- <table border="1"><tr><td></td></tr></table>--%>
                                        </div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" width="890" style="vertical-align: top">
                                            <tr>
                                                <td align="right" width="100">
                                                    <asp:Label ID="Label3" CssClass="cssLabel" Width="80px" runat="server" Text="<%$Resources:Resource,ReportingDate %>"></asp:Label>
                                                </td>
                                                <td align="left" width="150">
                                                    <asp:TextBox ID="txtReportingDate" AutoPostBack="True" Width="110px" CssClass="csstxtbox"
                                                        Enabled="false" runat="server" Style="text-align: justify" ValidationGroup="Apply"
                                                        OnTextChanged="txtReportingDate_TextChanged"></asp:TextBox>
                                                    <asp:HyperLink ID="IMGReportingDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CEIMGReportingDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtReportingDate" PopupButtonID="IMGReportingDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtReportingDate" ValidationGroup="Apply" ErrorMessage="*"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right" width="100">
                                                    <asp:Label ID="Label4" runat="server" Width="90px" Text="<%$Resources:Resource,ReportingTime %>"></asp:Label>
                                                </td>
                                                <td align="left" width="150">
                                                    <asp:TextBox ID="txtReportingTime" CssClass="csstxtbox" Width="120px" runat="server"
                                                        Enabled="false" ValidationGroup="Apply" />
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtReportingTime"
                                                        ClearTextOnInvalid="true" Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                        OnInvalidCssClass="MaskedEditError" MaskType="Time" AcceptAMPM="false" UserTimeFormat="None"
                                                        ErrorTooltipEnabled="True" />
                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                                                        ControlToValidate="txtReportingTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                        InvalidValueBlurredMessage="*" ValidationGroup="Apply" />
                                                </td>
                                                <td align="right" width="150">
                                                    <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,IncidentType %>"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" width="160">
                                                    <asp:DropDownList ID="ddlIncidentType" AutoPostBack="true" Width="160px" CssClass="cssDropDown"
                                                        runat="server" OnSelectedIndexChanged="ddlIncidentType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Panel ID="PanelAssignmentDetails" Width="890px" GroupingText="<%$Resources:Resource,AssignmentDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890">
                                                            <tr>
                                                                <td align="right" width="100px">
                                                                    <asp:Label ID="Label8" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="600px" colspan="3">
                                                                    <asp:DropDownList ID="ddlClientId" Width="765px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100px">
                                                                    <asp:Label ID="Label7" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AsmtID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="600px" colspan="3">
                                                                    <asp:DropDownList ID="ddlAsmtId" Width="765px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label6" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,BranchID %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtBranchID" Enabled="false" CssClass="csstxtbox" Width="140px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:TextBox runat="server" CssClass="csstxtbox" Width="610px" ID="txtBranchIDDesc"
                                                                        Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label10" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="610px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Panel ID="PanelIncidentDetails" Width="890px" GroupingText="<%$Resources:Resource,IncidentDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890" style="vertical-align: top">
                                                            <tr>
                                                                <td align="right" style="width: 100px;">
                                                                    <asp:Label ID="Label11" CssClass="cssLabel" Width="100px" runat="server" Text="<%$Resources:Resource,ReportedBy %>"></asp:Label>
                                                                </td>
                                                                <td align="left" style="width: 160px;">
                                                                    <asp:TextBox ID="txtReportedBy" MaxLength="50" ValidationGroup="Apply" Width="130px"
                                                                        CssClass="csstxtbox" runat="server" Style="text-align: justify"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtReportedBy" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="Label12" runat="server" Width="100px" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                                </td>
                                                                <td align="left" style="width: 180px;">
                                                                    <asp:TextBox ID="txtDesignation" MaxLength="35" ValidationGroup="Apply" CssClass="csstxtbox"
                                                                        Width="180px" runat="server" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtDesignation" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="Label13" runat="server" Width="80px" Text="<%$Resources:Resource,Nature %>"
                                                                        CssClass="cssLabel"></asp:Label>
                                                                </td>
                                                                <td align="left" style="width: 160px;">
                                                                    <asp:DropDownList ID="ddlNature" Width="170px" CssClass="cssDropDown" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label14" CssClass="cssLabel" Width="100px" runat="server" Text="<%$Resources:Resource,Description %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="5">
                                                                    <asp:TextBox ID="txtDescription" MaxLength="1000" TextMode="MultiLine" Height="30px"
                                                                        Width="755px" CssClass="csstxtbox" runat="server" Style="text-align: justify"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label1" CssClass="cssLabel" Width="80px" runat="server" Text="<%$Resources:Resource,LossValue %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtLossValue" Width="130px" CssClass="csstxtbox" runat="server"
                                                                        Style="text-align: justify" MaxLength="13"></asp:TextBox>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="Label15" CssClass="cssLabel" Width="100px" runat="server" Text="<%$Resources:Resource,MaterialStolen %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:TextBox ID="txtMaterialStolen" MaxLength="1000" Width="180px" CssClass="csstxtbox"
                                                                        runat="server" Style="text-align: justify"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label16" CssClass="cssLabel" Width="80px" runat="server" Text="<%$Resources:Resource,PoliceInvolved %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlPoliceInvolved" Width="134px" runat="server" AutoPostBack="true"
                                                                        CssClass="cssDropDown" OnSelectedIndexChanged="ddlPoliceInvolved_SelectedIndexChanged">
                                                                        <asp:ListItem Value="False" Text="<%$Resources:Resource,No %>"></asp:ListItem>
                                                                        <asp:ListItem Value="True" Text="<%$Resources:Resource,Yes %>"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblPoliceRefNo" CssClass="cssLabel" Width="100px" Visible="false"
                                                                        runat="server" Text="<%$Resources:Resource,PoliceRefNo %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:TextBox ID="txtPoliceRefNo" MaxLength="1000" Width="180px" CssClass="csstxtbox"
                                                                        Visible="false" runat="server" Style="text-align: justify"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <%--End--%>
                                                                <td align="right">
                                                                    <asp:Label ID="Label18" CssClass="cssLabel" Width="80px" runat="server" Text="<%$Resources:Resource,OccuranceDate %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtOccurenceDate" Width="130px" CssClass="csstxtbox" runat="server"
                                                                        Enabled="false" Style="text-align: justify" ValidationGroup="Apply" AutoPostBack="True"
                                                                        OnTextChanged="txtOccurenceDate_TextChanged"></asp:TextBox>
                                                                    <asp:ImageButton ID="IMGOccurenceDate" Style="vertical-align: middle" CausesValidation="true"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtOccurenceDate" PopupButtonID="IMGOccurenceDate" PopupPosition="TopLeft" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtOccurenceDate" ValidationGroup="Apply" ErrorMessage="*"
                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="Label17" runat="server" CssClass="cssLabel" Width="90px" Text="<%$Resources:Resource,OccuranceTime %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="3">
                                                                    <asp:TextBox ID="txtOccurenceTime" CssClass="csstxtbox" Width="180px" runat="server"
                                                                        ValidationGroup="Apply" />
                                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtOccurenceTime"
                                                                        ClearTextOnInvalid="true" Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" MaskType="Time" AcceptAMPM="false" UserTimeFormat="None"
                                                                        ErrorTooltipEnabled="True" />
                                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                                        ControlToValidate="txtOccurenceTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                        InvalidValueBlurredMessage="*" ValidationGroup="Apply" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label19" CssClass="cssLabel" Width="100px" runat="server" Text="<%$Resources:Resource,EnteredBy %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="3">
                                                                    <asp:TextBox ID="txtEmployeeID" MaxLength="16" CssClass="csstxtbox" Width="130px"
                                                                        runat="server" AutoPostBack="True" OnTextChanged="txtEmployeeID_TextChanged"></asp:TextBox>
                                                                    <asp:TextBox ID="txtEmployeeName" Enabled="false" CssClass="csstxtbox" Width="320px"
                                                                        runat="server"></asp:TextBox>
                                                                    <asp:ImageButton ID="IMGEmployeeNumber" AlternateText="<%$Resources:Resource,SearchEmployee %>"
                                                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtEmployeeID" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="Label20" CssClass="cssLabel" Width="80px" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtEmpDesignation" Enabled="false" CssClass="csstxtbox" Width="165px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label21" CssClass="cssLabel" Width="100px" runat="server" Text="<%$Resources:Resource,SupportReq %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="5">
                                                                    <asp:TextBox ID="txtSupportReq" MaxLength="100" CssClass="csstxtbox" Width="458px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
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
                                                                    <td align="right" width="180px">
                                                                        <asp:Label ID="lblFileUpload" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, UploadDownload %>"></asp:Label>
                                                                    </td>
                                                                    <td width="400">
                                                                        <asp:FileUpload ID="EmployeeDocUpload" CssClass="csstxtbox" Width="400px" Height="19px" runat="server" />
                                                                    </td>
                                                                    <td align="left" width="100">
                                                                        <asp:Button ID="btnUpload" CssClass="cssButton" Height="19px" runat="server" Text="<%$ Resources:Resource, Upload %>"
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
                        <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblGridError" runat="server" Text="" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                                <table>
                                    <tr>
                                        <td style="height: 40px">
                                            <asp:Panel ID="PanelGvIncidentInfo" runat="server" Height="120px" Width="910px" ScrollBars="Auto"
                                                CssClass="ScrollBar">
                                                <asp:GridView Width="890px" ID="gvIncidentInfo" ShowFooter="true" CssClass="GridViewStyle"
                                                    runat="server" CellPadding="1" AllowPaging="false" GridLines="None" AutoGenerateColumns="False"
                                                    AllowSorting="false" OnRowCancelingEdit="gvIncidentInfo_RowCancelingEdit" OnRowDataBound="gvIncidentInfo_RowDataBound"
                                                    OnRowDeleting="gvIncidentInfo_RowDeleting" OnRowEditing="gvIncidentInfo_RowEditing"
                                                    OnRowUpdating="gvIncidentInfo_RowUpdating" OnRowCommand="gvIncidentInfo_RowCommand"
                                                    onmousemove="TableResize_OnMouseMove(this);" onmouseup="TableResize_OnMouseUp(this);"
                                                    onmousedown="TableResize_OnMouseDown(this);" OnDataBound="gvIncidentInfo_DataBound"
                                                    OnPageIndexChanging="gvIncidentInfo_PageIndexChanging">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                            <EditItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnUpdate" CausesValidation="true" ToolTip="<%$Resources:Resource,Update %>"
                                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                                    ValidationGroup="Edit" />
                                                                &nbsp;
                                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                    CommandName="Cancel" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                    CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                                    CommandName="Edit" />
                                                                &nbsp;
                                                                <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                    CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                                &nbsp;
                                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                            <ItemStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,MessageTo %>" SortExpression="MessageTo">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtMessageToEdit" CssClass="csstxtbox" MaxLength="16" runat="server"
                                                                    Text='<%# Bind("MessageTo") %>' AutoPostBack="True" OnTextChanged="txtMessageToEdit_TextChanged"></asp:TextBox>
                                                                <asp:ImageButton ID="IMGMessageToEdit" AlternateText="<%$Resources:Resource,SearchEmployee %>"
                                                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                <asp:Label ID="lblMessageToEdit" Visible="false" runat="server" Text='<%# Bind("MessageTo") %>'></asp:Label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtMessageToEdit" ValidationGroup="Edit" ErrorMessage="*"
                                                                    Text="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMessageToEdit" CssClass="csslabel" runat="server" Text='<%# Bind("MessageTo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtNewMessageTo" MaxLength="16" CssClass="csstxtbox" runat="server"
                                                                    AutoPostBack="True" OnTextChanged="txtNewMessageTo_TextChanged"></asp:TextBox>
                                                                <asp:ImageButton ID="IMGNewMessageTo" AlternateText="<%$Resources:Resource,SearchEmployee %>"
                                                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtNewMessageTo" ValidationGroup="AddNew" ErrorMessage="*"
                                                                    Text="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Name %>" SortExpression="Name">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtNameEdit" CssClass="csstxtbox" Enabled="false" runat="server"
                                                                    Text='<%# Bind("Name") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtNewName" CssClass="csstxtbox" runat="server" Enabled="false"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>" SortExpression="DesignationDesc">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtDesignationEdit" CssClass="csstxtbox" Enabled="false" runat="server"
                                                                    Text='<%# Bind("DesignationDesc") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtNewDesignation" CssClass="csstxtbox" Enabled="false" runat="server"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Date %>" SortExpression="Date">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtDateEdit" AutoPostBack="true" CssClass="csstxtbox" runat="server"
                                                                    Enabled="false" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("Date")) %>' OnTextChanged="txtDateEdit_TextChanged"></asp:TextBox>
                                                                <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                                    runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                    TargetControlID="txtDateEdit" PopupButtonID="IMGDate" PopupPosition="TopLeft" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtDateEdit" ValidationGroup="Edit" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDate" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("Date")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtNewDate" CssClass="csstxtbox" runat="server" AutoPostBack="true"
                                                                    Enabled="false" OnTextChanged="txtNewDate_TextChanged"></asp:TextBox>
                                                                <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                                    runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                    TargetControlID="txtNewDate" PopupButtonID="IMGDate" PopupPosition="TopLeft" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtNewDate" ValidationGroup="AddNew" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Time %>" SortExpression="Time">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtTimeEdit" CssClass="csstxtbox" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("Time")) %>'></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTimeEdit"
                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                    ErrorTooltipEnabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator25" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtTimeEdit" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                    InvalidValueBlurredMessage="*" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtTimeEdit" ValidationGroup="Edit" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTime" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("Time")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtNewTime" CssClass="csstxtbox" runat="server" ValidationGroup="AddNew"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtNewTime"
                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                    ClearTextOnInvalid="true" MaskType="Time" AcceptAMPM="false" UserTimeFormat="None"
                                                                    ErrorTooltipEnabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="mevNewTime" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtNewTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                    InvalidValueBlurredMessage="*" ValidationGroup="AddNew" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerTemplate>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                                            CommandArgument="First" CommandName="Page" />
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                                            CommandArgument="Prev" CommandName="Page" />
                                                        <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                                        <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                                        <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                                            CommandArgument="Next" CommandName="Page" />
                                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                                            CommandArgument="Last" CommandName="Page" />
                                                    </PagerTemplate>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </Ajax:UpdatePanel>
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
                                    <asp:Button ID="btnEdit" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource ,Edit%>"
                                        OnClick="btnEdit_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Text="<%$Resources:Resource ,Authorized%>" OnClick="btnAuthorize_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" CssClass="cssButton" ValidationGroup="Apply" runat="server"
                                        Visible="false" Text="<%$Resources:Resource,Update %>" OnClick="btnUpdate_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Cancel %>"
                                        OnClick="btnCancel_Click" />
                                </td>
                                <td>
                                    <asp:HiddenField ID="hfMessageToEdit" runat="server" />
                                    <asp:HiddenField ID="hfAsmtStartDate" runat="server" />
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
