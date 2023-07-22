<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SecurityDesignReview.aspx.cs" Inherits="OperationManagement_SecurityDesignReview"
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
                                <td width="172" nowrap="nowrap" align="right">
                                    <asp:Label ID="lblDesignChangeNumber" Width="172px" CssClass="cssLabel" runat="server"
                                        Text="<%$Resources:Resource,DesignChgNumber %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDesignChangeNumber" MaxLength="35" Width="110px" AutoPostBack="true"
                                        CssClass="csstxtbox" runat="server" OnTextChanged="txtDesignChangeNumber_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="IMGDesignChangeNumber" AlternateText="<%$Resources:Resource,SearchDesignNumber %>"
                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="right" colspan="4">
                                    <asp:Label ID='lblTrnS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                    <asp:Label ID="lblDesignChangeStatus" runat="server" CssClass="csstxtbox" Width="110px"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="PanelMain" runat="server" Width="98%">
                            <div style="width: 98%;">
                                <div class="squarebox">
                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                        <div style="float: left; width: 900px;">
                                            <tt style="text-align: center;">
                                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,SecurityDesignReview %>"></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td align="right" width="110px">
                                                    <asp:Label ID="Label3" CssClass="cssLabel" Width="80px" runat="server" Text="<%$Resources:Resource,Date %>"></asp:Label>
                                                </td>
                                                <td align="left" width="130">
                                                    <asp:TextBox ID="txtDate" Width="90px" CssClass="csstxtbox" AutoPostBack="true" runat="server"
                                                        OnTextChanged="txtDate_TextChanged" ValidationGroup="Save"></asp:TextBox>
                                                    <asp:ImageButton ID="IMGDate1" Style="vertical-align: middle" CausesValidation="false"
                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtDate" PopupButtonID="IMGDate1" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtDate"
                                                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right" width="120">
                                                    <asp:Label ID="Label4" runat="server" Width="120px" Text="<%$Resources:Resource,DateOfReport %>"></asp:Label>
                                                </td>
                                                <td align="left" width="150">
                                                    <asp:TextBox ID="txtDateOfReport" Width="120px" ValidationGroup="Save" AutoPostBack="true"
                                                        CssClass="csstxtbox" runat="server" OnTextChanged="txtDateOfReport_TextChanged"></asp:TextBox>
                                                    <asp:ImageButton ID="IMG" Style="vertical-align: middle" CausesValidation="false"
                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtDateOfReport" PopupButtonID="IMG" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ControlToValidate="txtDateOfReport"
                                                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right" width="100">
                                                    <asp:Label ID="Label11" runat="server" Width="100px" Text="<%$Resources:Resource,DesignType %>"></asp:Label>
                                                </td>
                                                <td align="left" width="250" style="height: 21px">
                                                    <asp:DropDownList ID="ddlDesignType" Width="200px" CssClass="cssDropDown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" cellpadding="0" border="0">
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Panel ID="PanelAssignmentDetails" Width="890px" GroupingText="<%$Resources:Resource,AssignmentDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890" cellpadding="0">
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="Label9" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:DropDownList ID="ddlClientId" Width="755px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="Label7" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AsmtID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:DropDownList ID="ddlAsmtId" Width="755px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100">
                                                                    <asp:Label ID="Label8" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,BranchID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="150">
                                                                    <asp:TextBox ID="txtBranchID" Enabled="false" CssClass="csstxtbox" Width="140px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" width="470">
                                                                    <asp:TextBox runat="server" CssClass="csstxtbox" Width="598px" ID="txtBranchIDDesc"
                                                                        Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100" nowrap="nowrap">
                                                                    <asp:Label ID="Label10" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3">
                                                                    <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="598px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="890" border="0" cellpadding="0">
                                            <tr>
                                                <td align="right" width="138" nowrap="nowrap">
                                                    <asp:Label ID="Label1" CssClass="cssLabel" Width="138" runat="server" Text="<%$Resources:Resource,RequestedBy %>"></asp:Label>
                                                </td>
                                                <td align="left" width="160">
                                                    <asp:TextBox ID="txtConductedBy" CssClass="csstxtbox" Width="160px" ValidationGroup="Save"
                                                        runat="server" AutoPostBack="True" OnTextChanged="txtConductedBy_TextChanged"></asp:TextBox>
                                                </td>
                                                <td align="left" colspan="1" width="280">
                                                    <asp:TextBox ID="txtEmployeeName" CssClass="csstxtbox" Width="220" Enabled="false"
                                                        runat="server"></asp:TextBox>
                                                    <asp:ImageButton ID="IMGEmployeeNumber" AlternateText="<%$Resources:Resource,SearchRequestIdentifiedBy %>"
                                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtEmployeeName" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right" width="100">
                                                    <asp:Label ID="Label5" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                </td>
                                                <td align="left" width="150">
                                                    <asp:TextBox ID="txtEmployeeDesignation" CssClass="csstxtbox" Enabled="false" runat="server"
                                                        Width="150px"></asp:TextBox>
                                                </td>
                                                <td align="left" width="170" colspan="4">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="140">
                                                    <asp:Label ID="Label6" runat="server" Width="140px" Text="<%$Resources:Resource,ReasonForReview %>"></asp:Label>
                                                </td>
                                                <td align="left" width="140" style="height: 21px">
                                                    <asp:DropDownList ID="ddlReasonForReview" Width="145px" CssClass="cssDropDown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
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
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <div style="width: 950px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width: 930px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="lblDivHdr1" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource,Observation %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="divdatagrid" Width="890px" BorderWidth="1px" runat="server" ScrollBars="Auto"
                                                                Height="100px" CssClass="ScrollBar">
                                                                <asp:GridView Width="1300px" ID="gvObservation" CssClass="GridViewStyle" runat="server"
                                                                    CellPadding="1" PageSize="5" GridLines="Both" AutoGenerateColumns="False" AllowSorting="false"
                                                                    ShowFooter="True" AllowPaging="True" OnDataBound="gvObservation_DataBound" OnPageIndexChanging="gvObservation_PageIndexChanging"
                                                                    OnRowCancelingEdit="gvObservation_RowCancelingEdit" OnRowCommand="gvObservation_RowCommand"
                                                                    OnRowDataBound="gvObservation_RowDataBound" OnRowDeleting="gvObservation_RowDeleting"
                                                                    OnRowEditing="gvObservation_RowEditing" OnRowUpdating="gvObservation_RowUpdating">
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
                                                                                    CssClass="csslnkButton" runat="server" ValidationGroup="GridUpdate" CommandName="Update" />
                                                                                <asp:ImageButton ID="ImageButton2" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                                                <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                                    CssClass="cssImgButton" CommandName="AddNew" ValidationGroup="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                                                <asp:ImageButton ID="lbReset" CausesValidation="false" ToolTip="<%$Resources:Resource,Reset %>"
                                                                                    runat="server" CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                            </FooterTemplate>
                                                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                            <ItemStyle Width="100px" />
                                                                            <FooterStyle Width="80px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="RowID" Visible="False" SortExpression="RowID">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblRowIDEdit" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRowID" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Observation %>" SortExpression="Observation">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtObservation" Width="400px" ValidationGroup="GridUpdate" MaxLength="100"
                                                                                    CssClass="csstxtbox" runat="server" Text='<%# Bind("Observation") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                                                    Text="*" Display="Dynamic" ControlToValidate="txtObservation" ValidationGroup="GridUpdate"></asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label10" CssClass="cssLabel" runat="server" Text='<%# Bind("Observation") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewObservation" Width="400px" MaxLength="100" ValidationGroup="AddNew"
                                                                                    CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                                                                    Text="*" Display="Dynamic" ControlToValidate="txtNewObservation" ValidationGroup="AddNew"></asp:RequiredFieldValidator>
                                                                            </FooterTemplate>
                                                                            <ItemStyle Width="250px" />
                                                                            <HeaderStyle Width="250px" />
                                                                            <FooterStyle Width="250px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Recommendation %>" SortExpression="Recommendation">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtRecommendation" Width="400px" CssClass="csstxtbox" ValidationGroup="GridUpdate"
                                                                                    MaxLength="100" runat="server" Text='<%# Bind("Recommendation") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                                                    Text="*" Display="Dynamic" ControlToValidate="txtRecommendation" ValidationGroup="GridUpdate"></asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRecommendation" CssClass="cssLabel" runat="server" Text='<%# Bind("Recommendation") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewRecommendation" Width="400px" MaxLength="100" ValidationGroup="AddNew"
                                                                                    CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                                                                    Text="*" Display="Dynamic" ControlToValidate="txtNewRecommendation" ValidationGroup="AddNew"></asp:RequiredFieldValidator>
                                                                            </FooterTemplate>
                                                                            <ItemStyle Width="250px" />
                                                                            <HeaderStyle Width="250px" />
                                                                            <FooterStyle Width="250px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Sensitivity %>" SortExpression="Sensitivity">
                                                                            <EditItemTemplate>
                                                                                <asp:DropDownList ID="ddlSensitivity" Width="140px" CssClass="cssDropDown" runat="server">
                                                                                </asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text='<%# Bind("Sensitivity") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:DropDownList ID="ddlNewSensitivity" Width="140px" CssClass="cssDropDown" runat="server">
                                                                                </asp:DropDownList>
                                                                            </FooterTemplate>
                                                                            <ItemStyle Width="150px" />
                                                                            <HeaderStyle Width="150px" />
                                                                            <FooterStyle Width="150px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ImplementationDate %>" Visible="False"
                                                                            SortExpression="ImplementationDate">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtImplementationDate" Width="120px" CssClass="csstxtbox" runat="server"
                                                                                    Enabled="false" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("ImplementationDate")) %>'
                                                                                    AutoPostBack="True" OnTextChanged="txtImplementationDate_TextChanged"></asp:TextBox>
                                                                                <asp:ImageButton ID="IMGDate1" Style="vertical-align: middle" CausesValidation="false"
                                                                                    runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                                    TargetControlID="txtImplementationDate" PopupButtonID="IMGDate1" PopupPosition="TopLeft" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblImplementationDate" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("ImplementationDate")) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewImplementationDate" Width="120px" CssClass="csstxtbox" runat="server"
                                                                                    AutoPostBack="True" OnTextChanged="txtNewImplementationDate_TextChanged"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                            <ItemStyle Width="150px" />
                                                                            <HeaderStyle Width="150px" />
                                                                            <FooterStyle Width="150px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ReasonForPending %>" Visible="False"
                                                                            SortExpression="ReasonForPending">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtReasonForPending" Width="230px" CssClass="csstxtbox" runat="server"
                                                                                    Text='<%# Bind("ReasonForPending") %>' AutoPostBack="True" OnTextChanged="txtReasonForPending_TextChanged"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblReasonForPending" CssClass="cssLabel" runat="server" Text='<%# Bind("ReasonForPending") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewReasonForPending" Width="230px" CssClass="csstxtbox" runat="server"
                                                                                    AutoPostBack="True" OnTextChanged="txtNewReasonForPending_TextChanged"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                            <ItemStyle Width="250px" />
                                                                            <HeaderStyle Width="250px" />
                                                                            <FooterStyle Width="250px" />
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
                                            </div>
                                        </div>
                                        
                                    </div>
                                    <table align="center" border="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Save" runat="server"
                                                    Text="<%$Resources:Resource,Save %>" Visible="false" OnClick="btnSave_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnEdit" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource ,Edit%>"
                                                    OnClick="btnEdit_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnObservationAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                                    Width="180px" Text="<%$Resources:resource,ObservationAuthorized %>" OnClick="btnObservationAuthorize_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnActionAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                                    Width="180px" Text="<%$Resources:Resource,ActionAuthorized %>" ValidationGroup="ActionAuthorize"
                                                    OnClick="btnActionAuthorize_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnUpdate" CssClass="cssButton" ValidationGroup="Save" runat="server"
                                                    Visible="false" Text="<%$Resources:Resource,Update %>" OnClick="btnUpdate_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Cancel %>"
                                                    OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
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
