<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="NightCheckVisitDetail.aspx.cs" Inherits="OperationManagement_NightCheckVisitDetail"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" width="100%" style="vertical-align: top" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="right" width="200">
                                    <asp:Label ID="Label1" CssClass="cssLabel" Width="200" runat="server" Text="<%$Resources:Resource,CheckVisitType %>"></asp:Label>
                                </td>
                                <td align="left" width="200">
                                    <asp:DropDownList Width="200" CssClass="cssDropDown" ID="ddlCheckVisitType" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" width="200">
                                    <asp:Label ID="Label2" Width="200" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CheckVisitNumber %>"></asp:Label>
                                </td>
                                <td align="left" width="200">
                                    <asp:TextBox ID="txtCheckVisitNumber" CssClass="csstxtbox" Width="180" runat="server"
                                        AutoPostBack="True" OnTextChanged="txtCheckVisitNumber_TextChanged"></asp:TextBox>
                                </td>
                                <td align="left" width="50">
                                    <asp:ImageButton ID="IMGCheckVisitNumber" AlternateText="<%$Resources:Resource,SearchNightCheckVisitNumber %>" runat="server"
                                        ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="left" width="200">
                                    <%--Added & Modify by  on 24-May-2013--%>
                                    <asp:Label ID='lblTrnS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                    <asp:Label ID="lblCheckVisitStatus" CssClass="csstxtbox" Width="110" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="1000" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div style="width: 950px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width:930px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label3" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,Main %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table border="0" width="930" style="vertical-align: top" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="right" width="100">
                                                            <asp:Label ID="Label4" CssClass="cssLabel" Width="100" runat="server" Text="<%$Resources:Resource,Date %>"></asp:Label>
                                                        </td>
                                                        <td align="left" width="180">
                                                            <asp:TextBox ID="txtDate" CssClass="csstxtbox" Width="130" ValidationGroup="Save"
                                                                runat="server" AutoPostBack="True" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                                            <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                                runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                TargetControlID="txtDate" PopupButtonID="IMGDate" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                ControlToValidate="txtDate" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="right" width="100">
                                                            <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,TimeFrom %>"></asp:Label>
                                                        </td>
                                                        <td align="left" width="180">
                                                            <asp:TextBox ID="txtTimeFrom" CssClass="csstxtbox" Width="150" ValidationGroup="Save"
                                                                runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTimeFrom"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                                ControlToValidate="txtTimeFrom" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="Save" />
                                                        </td>
                                                        <td align="right" width="100">
                                                            <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,TimeTo %>"></asp:Label>
                                                        </td>
                                                        <td align="left" width="260">
                                                            <asp:TextBox ID="txtTimeTo" CssClass="csstxtbox" ValidationGroup="Save" runat="server"></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTimeTo"
                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                ErrorTooltipEnabled="True" />
                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                                                ControlToValidate="txtTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                InvalidValueBlurredMessage="*" ValidationGroup="Save" />
                                                           <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToCompare="txtTimeFrom"
                                                                ControlToValidate="txtTimeTo" Display="static" ValidationGroup="Save" Operator="GreaterThan"
                                                                SetFocusOnError="True"></asp:CompareValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" width="100">
                                                            <asp:Label ID="Label7" CssClass="cssLabel" Width="100" runat="server" Text="<%$Resources:Resource,ConductedBy %>"></asp:Label>
                                                        </td>
                                                        <td align="left" width="180">
                                                            <asp:TextBox ID="txtConductedBy" CssClass="csstxtbox" Width="180" ValidationGroup="Save"
                                                                runat="server" AutoPostBack="True" OnTextChanged="txtConductedBy_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="txtEmployeeName" CssClass="csstxtbox" Width="280" Enabled="false"
                                                                runat="server">
                                                            </asp:TextBox>
                                                            <asp:ImageButton ID="IMGEmployeeNumber" AlternateText="<%$Resources:Resource,SearchConductedBy %>" runat="server"
                                                                ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="Label8" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmployeeDesignation" CssClass="csstxtbox" Enabled="false" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic"
                                                                ControlToValidate="txtConductedBy" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblErrorMsg" EnableViewState="false" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="divdatagrid" Width="890px" BorderWidth="1px" runat="server" ScrollBars="Horizontal"
                                                                Height="300" CssClass="ScrollBar">
                                                                <asp:GridView Width="2600px" UseAccessibleHeader="True" ID="gvNightCheckVisit" CssClass="GridViewStyle"
                                                                    runat="server" CellPadding="1" PageSize="8" GridLines="Both" AutoGenerateColumns="False"
                                                                    AllowSorting="false" ShowFooter="True" AllowPaging="True"
                                                                    OnPageIndexChanging="gvNightCheckVisit_PageIndexChanging" OnRowCancelingEdit="gvNightCheckVisit_RowCancelingEdit"
                                                                    OnRowCommand="gvNightCheckVisit_RowCommand" OnRowDataBound="gvNightCheckVisit_RowDataBound"
                                                                    OnRowDeleting="gvNightCheckVisit_RowDeleting" OnRowEditing="gvNightCheckVisit_RowEditing"
                                                                    OnRowUpdating="gvNightCheckVisit_RowUpdating" OnDataBound="gvNightCheckVisit_DataBound">
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
                                                                                    CssClass="csslnkButton" runat="server" CommandName="Update" />
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
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="RowID" Visible="False" SortExpression="RowID">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblRowIDEdit" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRowID" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,CustomerID %>" SortExpression="ClientCode">
                                                                            <EditItemTemplate>
                                                                                <asp:DropDownList ID="ddlClientId" Width="200px" CssClass="cssDropDown" AutoPostBack="true"
                                                                                runat="server" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text='<%# Bind("ClientCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:DropDownList ID="ddlNewClientId" Width="200px" CssClass="cssDropDown" AutoPostBack="true"
                                                                                runat="server" OnSelectedIndexChanged="ddlNewClientId_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,ClientName %>" SortExpression="Name">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtClientName" CssClass="csstxtbox" runat="server" Text='<%# Bind("ClientName") %>' Enabled="false"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label54" CssClass="cssLabel" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewClientName" CssClass="csstxtbox" runat="server" Enabled="false"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AsmtID %>" SortExpression="AsmtId">
                                                                            <EditItemTemplate>
                                                                                <asp:DropDownList ID="ddlAsmtId" Width="200px" CssClass="cssDropDown" runat="server" Enabled= "false"
                                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAsmtCode" CssClass="cssLabel" runat="server" Text='<%# Bind("AsmtId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:DropDownList ID="ddlNewAsmtId" Width="200px" CssClass="cssDropDown" runat="server" Enabled= "false"
                                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlNewAsmtId_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,BranchID %>" SortExpression="LocationCode">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtBranchID" CssClass="csstxtbox" runat="server" Text='<%# Bind("LocationCode") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text='<%# Bind("LocationCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewBranchID" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Branch %>" SortExpression="LocationDesc">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtBranch" CssClass="csstxtbox" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewBranch" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AsmtAddress %>" SortExpression="AsmtAddress">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtAsmtAddress" CssClass="csstxtbox" runat="server" Text='<%# Bind("AsmtAddress") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text='<%# Bind("AsmtAddress") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewAsmtAddress" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>" SortExpression="EmployeeID">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtEmployeeNumber" CssClass="csstxtbox" runat="server" Text='<%# Bind("EmployeeID") %>'
                                                                                    AutoPostBack="True" OnTextChanged="txtEmployeeNumber_TextChanged"></asp:TextBox>
                                                                                    <asp:ImageButton ID="imgEmployeeNumberEdit" AlternateText="Search Employee Number"
                                                                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmployeeID" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewEmployeeNumber" ValidationGroup="AddNew" CssClass="csstxtbox"
                                                                                    runat="server" AutoPostBack="True" OnTextChanged="txtNewEmployeeNumber_TextChanged"></asp:TextBox>
                                                                                     <asp:ImageButton ID="imgEmployeeNumberFooter" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                                                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" Display="Dynamic"
                                                                                    ControlToValidate="txtNewEmployeeNumber" ValidationGroup="AddNew" ErrorMessage="*"
                                                                                    Text="*"></asp:RequiredFieldValidator>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" SortExpression="EmpName">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtEmployeeName" CssClass="csstxtbox" runat="server" Text='<%# Bind("EmpName") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label51" CssClass="cssLabel" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewEmployeeName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>" SortExpression="DesignationDesc">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtDesignation" CssClass="csstxtbox" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label52" CssClass="cssLabel" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewDesignation" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,TimeFrom %>" SortExpression="TimeFrom">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtTimeFrom" CssClass="csstxtbox" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:TextBox>
                                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTimeFrom"
                                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                                    ErrorTooltipEnabled="True" />
                                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                                                                    ControlToValidate="txtTimeFrom" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                                    InvalidValueBlurredMessage="*" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTimeFrom" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewTimeFrom" ValidationGroup="AddNew" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender21" runat="server" TargetControlID="txtNewTimeFrom"
                                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                                    ErrorTooltipEnabled="True" />
                                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator26" runat="server" ControlExtender="MaskedEditExtender21"
                                                                                    ControlToValidate="txtNewTimeFrom" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                                    InvalidValueBlurredMessage="*" ValidationGroup="AddNew" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,TimeTo %>" SortExpression="TimeTo">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtTimeTo" CssClass="csstxtbox" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:TextBox>
                                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender22" runat="server" TargetControlID="txtTimeTo"
                                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                                    ErrorTooltipEnabled="True" />
                                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator25" runat="server" ControlExtender="MaskedEditExtender22"
                                                                                    ControlToValidate="txtTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                                    InvalidValueBlurredMessage="*" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTimeTo" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewTimeTo" ValidationGroup="AddNew" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender23" runat="server" TargetControlID="txtNewTimeTo"
                                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                                    ErrorTooltipEnabled="True" />
                                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator23" runat="server" ControlExtender="MaskedEditExtender23"
                                                                                    ControlToValidate="txtNewTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                                    InvalidValueBlurredMessage="*" ValidationGroup="AddNew" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ObservationType %>" SortExpression="Observation_Type">
                                                                            <EditItemTemplate>
                                                                                <asp:DropDownList ID="ddlObservationType" Width="150" CssClass="cssDropDown" runat="server">
                                                                                </asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblObservation_Type" CssClass="cssLabel" runat="server" Text='<%# Bind("Observation_Type") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:DropDownList ID="ddlNewObservationType" Width="150" CssClass="cssDropDown" runat="server">
                                                                                </asp:DropDownList>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ItemDesc" Visible="False" SortExpression="ItemDesc">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblItemDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemDesc") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Observation %>" SortExpression="Observation">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtObservation" CssClass="csstxtbox" runat="server" Text='<%# Bind("Observation") %>' Width="350px"
                                                                                    AutoPostBack="True" OnTextChanged="txtObservation_TextChanged"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label10" CssClass="cssLabel" runat="server" Text='<%# Bind("Observation") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtNewObservation" ValidationGroup="AddNew" CssClass="csstxtbox" Width="350px"
                                                                                    runat="server" AutoPostBack="True" OnTextChanged="txtNewObservation_TextChanged"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" Display="Dynamic"
                                                                                    ControlToValidate="txtNewObservation" ValidationGroup="AddNew" ErrorMessage="*"
                                                                                    Text="*"></asp:RequiredFieldValidator>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ActionStatus %>" SortExpression="Action_Status">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblActionStatus" CssClass="cssLabel" runat="server" Text='<%# Bind("Action_Status") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ActionNumber %>" SortExpression="Action_Number">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblActionNumber" CssClass="cssLabel" runat="server" Text='<%# Bind("Action_Number") %>'></asp:Label>
                                                                            </ItemTemplate>
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
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                        Visible="False" OnClick="btnAddNew_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" CssClass="cssButton" CommandName="Save" ValidationGroup="Save"
                                        runat="server" Text="<%$Resources:Resource,Save %>" Visible="false" OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" CssClass="cssButton" runat="server" Visible="false" Text="<%$Resources:Resource,Update %>"
                                        OnClick="btnUpdate_Click" ValidationGroup="Save" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Text="<%$Resources:Resource,Authorized %>" OnClick="btnAuthorize_Click" />
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
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
