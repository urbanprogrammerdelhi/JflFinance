<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="NightCheckVisitAction.aspx.cs" Inherits="OperationManagement_NightCheckVisitAction"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" width="950" style="vertical-align: top" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="right" nowrap="nowrap" width="185px">
                                    <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CheckVisitActionNumber %>"></asp:Label>
                                </td>
                                <td align="left" width="200">
                                    <asp:TextBox ID="txtCheckVisitActionNumber" Width="200" CssClass="csstxtbox" runat="server"
                                        AutoPostBack="True" OnTextChanged="txtCheckVisitActionNumber_TextChanged"></asp:TextBox>
                                </td>
                                <td align="left" width="50">
                                    <asp:ImageButton ID="IMGCheckVisitActionNumber" AlternateText="<%$Resources:Resource,SearchNightCheckVisitActionNumber %>"
                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="right">
                                    <asp:Label ID='lblTrnS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                    <asp:Label ID="lblCheckVisitActionStatus" Width="140px" CssClass="csstxtbox" runat="server"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" style="vertical-align: top;" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <div style="width: 950px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width: 930px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label3" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,Main %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table border="0" width="930" style="vertical-align: top" cellpadding="1" cellspacing="1">
                                                    <tr>
                                                        <td align="right" width="175px">
                                                            <asp:Label ID="Label1" Width="120" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Date %>"></asp:Label>
                                                        </td>
                                                        <td align="left" width="810">
                                                            <asp:TextBox ID="txtDate" CssClass="csstxtbox" runat="server" AutoPostBack="true" Enabled="false"
                                                                OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                                            <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" CausesValidation="false"
                                                                runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                TargetControlID="txtDate" PopupButtonID="ImageButton1" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                ControlToValidate="txtDate" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="960" border="0" cellpadding="1" cellspacing="1">
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="Panel2" Width="890px " GroupingText="<%$Resources:Resource,CheckVisitDetail %>"
                                                                BorderWidth="0px" runat="server">
                                                                <table width="890px" border="0" cellpadding="1" cellspacing="1">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label4" CssClass="csslabel" runat="server" Width="140px" Text="<%$Resources:Resource,CheckVisitNumber %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtCheckVisitNumber" CssClass="csstxtbox" Width="120px" runat="server"
                                                                                AutoPostBack="True" OnTextChanged="txtCheckVisitNumber_TextChanged"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtCheckVisitNumber" ValidationGroup="Save" ErrorMessage="*"
                                                                                Text="*"></asp:RequiredFieldValidator>
                                                                            <asp:ImageButton ID="IMGCheckVisitNumber" AlternateText="<%$Resources:Resource,SearchNightCheckVisitNumber %>"
                                                                                runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label5" CssClass="csslabel" runat="server" Width="120px" Text="<%$Resources:Resource,CheckVisitType %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtCheckVisitType" Enabled="false" CssClass="csstxtbox" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td colspan="2" width="330px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" nowrap="nowrap">
                                                                            <asp:Label ID="Label63" CssClass="csslabel" Width="120" runat="server" Text="<%$Resources:Resource,CheckVisitDate %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="160">
                                                                            <asp:TextBox ID="txtCheckVisitDate" Enabled="false" CssClass="csstxtbox" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label71" CssClass="csslabel" Width="120px" runat="server" Text="<%$Resources:Resource,TimeFrom %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtTimeFrom" Enabled="false" CssClass="csstxtbox" Width="140px" ValidationGroup="Save"
                                                                                runat="server"></asp:TextBox>
                                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTimeFrom"
                                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                                ErrorTooltipEnabled="True" />
                                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                                                ControlToValidate="txtTimeFrom" ValidationGroup="Save" IsValidEmpty="False" Display="Dynamic"
                                                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" />
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label16" CssClass="csslabel" Width="100px" runat="server" Text="<%$Resources:Resource,TimeTo %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtTimeTo" Enabled="false" CssClass="csstxtbox" Width="130px" ValidationGroup="Save"
                                                                                runat="server"></asp:TextBox>
                                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTimeTo"
                                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                                ErrorTooltipEnabled="True" />
                                                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                                                                ControlToValidate="txtTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                                                InvalidValueBlurredMessage="*" ValidationGroup="Save" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label9" CssClass="csslabel" runat="server" Text="<%$Resources:Resource,ConductedBy %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtEmployeeID" Enabled="false" CssClass="csstxtbox" Width="140px"
                                                                                runat="server" AutoPostBack="True" OnTextChanged="txtEmployeeID_TextChanged"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:TextBox ID="txtEmployeeName" Enabled="false" Width="265px" CssClass="csstxtbox"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label10" CssClass="csslabel" Width="100px" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDesignation" Enabled="false" CssClass="csstxtbox" Width="130px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="960" cellpadding="1" cellspacing="1">
                                                    <tr>
                                                        <td colspan="5">
                                                            <asp:Panel ID="PanelAssignmentDetails" Width="890px" GroupingText="<%$Resources:Resource,AssignmentDetails %>"
                                                                BorderWidth="0px" runat="server">
                                                                <table border="0" width="890" cellpadding="1" cellspacing="1">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label13" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:DropDownList ID="ddlClientId" Width="715px" CssClass="cssDropDown" AutoPostBack="true" Enabled= "false"
                                                                                runat="server" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label11" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AsmtID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:DropDownList ID="ddlAsmtId" Width="715px" CssClass="cssDropDown" runat="server" Enabled= "false"
                                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label12" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,BranchID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtBranchID" Enabled="false" CssClass="csstxtbox" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox runat="server" CssClass="csstxtbox" Width="555px" ID="txtBranchIDDesc"
                                                                                Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label15" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="555px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="visibility: hidden;">
                                                                        <%--Unused Controls Commented by  on 31-May-2013--%>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="txtCustomerID" CssClass="csstxtbox" Enabled="false" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                            <asp:TextBox ID="txtCustomerDesc" CssClass="csstxtbox" Enabled="false" Width="600px"
                                                                                runat="server"></asp:TextBox>
                                                                            <asp:Label ID="Label14" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AddressID %>"></asp:Label>
                                                                            <asp:TextBox ID="txtAddressID" CssClass="csstxtbox" Enabled="false" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                            <asp:TextBox ID="txtAddressDesc" CssClass="csstxtbox" Enabled="false" Width="600px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblErrorMsg" EnableViewState="false" CssClass="csslblErrMsg" runat="server"
                                                                Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="PanelGridView" Visible="false" Width="890px" BorderWidth="1px" runat="server"
                                                                ScrollBars="Horizontal" Height="150" CssClass="ScrollBar">
                                                                <asp:GridView Width="2000px" ID="gvNightCheckVisitAction" CssClass="GridViewStyle"
                                                                    runat="server" CellPadding="1" PageSize="8" GridLines="None" AutoGenerateColumns="False"
                                                                    AllowSorting="False" onmousemove="TableResize_OnMouseMove(this);" onmouseup="TableResize_OnMouseUp(this);"
                                                                    onmousedown="TableResize_OnMouseDown(this);" ShowFooter="false" AllowPaging="True"
                                                                    OnRowCancelingEdit="gvNightCheckVisitAction_RowCancelingEdit" OnRowCommand="gvNightCheckVisitAction_RowCommand"
                                                                    OnRowDataBound="gvNightCheckVisitAction_RowDataBound" OnRowDeleting="gvNightCheckVisitAction_RowDeleting"
                                                                    OnRowEditing="gvNightCheckVisitAction_RowEditing" OnRowUpdating="gvNightCheckVisitAction_RowUpdating">
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
                                                                                    CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CommandName="Update" />
                                                                                <asp:ImageButton ID="ImageButton2" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                            <ItemStyle Width="100px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="AutoID" Visible="False" SortExpression="AutoID">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblAutoIDEdit" CssClass="cssLabel" runat="server" Text='<%# Bind("AutoID") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAutoID" CssClass="cssLabel" runat="server" Text='<%# Bind("AutoID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="RowID" Visible="False" SortExpression="RowID">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblRowIDEdit" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRowID" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ItemDesc" Visible="False" SortExpression="ItemDesc">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblItemDescEdit" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemDesc") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblItemDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemDesc") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ObservationType %>" SortExpression="Observation_Type">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblObservationType" Text='<%# Bind("Observation_Type") %>' Width="150px"
                                                                                    CssClass="cssLabel" runat="server">
                                                                                </asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text='<%# Bind("Observation_Type") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Observation %>" SortExpression="Observation">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblObservation" CssClass="cssLabel" runat="server" Text='<%# Bind("Observation") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text='<%# Bind("Observation") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ComplainAgainst %>" SortExpression="ComplainAgainst">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblComplainAgainst" CssClass="cssLabel" runat="server" Text='<%# Bind("ComplainAgainst") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label61" CssClass="cssLabel" runat="server" Text='<%# Bind("ComplainAgainst") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" SortExpression="EmployeeName">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblEmployeeName" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label72" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>" SortExpression="EmployeeDesignation">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblEmployeeDesignation" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeDesignation") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label81" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeDesignation") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ActionPlanned %>" SortExpression="ActionPlanned">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtActionPlanned" CssClass="csstxtbox" runat="server" Text='<%# Bind("ActionPlanned") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic"
                                                                                    ControlToValidate="txtActionPlanned" ValidationGroup="Edit" ErrorMessage="*"
                                                                                    Text="*"></asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblActionPlanned" CssClass="cssLabel" runat="server" Text='<%# Bind("ActionPlanned") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Responsible %>" SortExpression="Responsible">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtResponsibility" ValidationGroup="EditClient" CssClass="csstxtbox"
                                                                                    runat="server" Text='<%# Bind("Responsible") %>' AutoPostBack="True" OnTextChanged="txtResponsibility_TextChanged"></asp:TextBox>
                                                                                <asp:ImageButton ID="imgResponsibility" AlternateText="Search Employee Number" runat="server"
                                                                                    ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic"
                                                                                    ControlToValidate="txtResponsibility" ValidationGroup="Edit" ErrorMessage="*"
                                                                                    Text="*"></asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label62" CssClass="cssLabel" runat="server" Text='<%# Bind("Responsible") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" SortExpression="Name">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblName" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label7" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>" SortExpression="Designation">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label82" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ActionDate %>" SortExpression="ActionDate">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtActionDate" ValidationGroup="EditClient" CssClass="csstxtbox"
                                                                                    runat="server" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("ActionDate")) %>'
                                                                                    AutoPostBack="True" OnTextChanged="txtActionDate_TextChanged"></asp:TextBox>
                                                                                <asp:ImageButton ID="IMGActionDate" Visible="true" Style="vertical-align: middle"
                                                                                    CausesValidation="false" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                                                    TargetControlID="txtActionDate" PopupButtonID="IMGActionDate" PopupPosition="TopLeft" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblActionDate" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("ActionDate")) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Remarks %>" Visible="False"
                                                                            SortExpression="Remarks">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtRemarks" Width="250" ValidationGroup="EditClient" CssClass="csstxtbox"
                                                                                    runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRemarks" CssClass="cssLabel" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <PagerTemplate>
                                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                                                            CommandArgument="First" CommandName="Page" />
                                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                                                            CommandArgument="Prev" CommandName="Page" />
                                                                        <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                                                        <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True">
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
                                                    <tr>
                                                        <td>
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
                                        Visible="False" ValidationGroup="NoGroup" OnClick="btnAddNew_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Save" CommandName="Save" Enabled = "false"
                                        runat="server" Text="<%$Resources:Resource,Save %>" Visible="false" OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" CssClass="cssButton" ValidationGroup="Save" runat="server"
                                        Visible="false" Text="<%$Resources:Resource,Update %>" OnClick="btnUpdate_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnPlanAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Text="<%$Resources:resource,PlanAuthorized %>" OnClick="btnPlanAuthorize_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnActionAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Text="<%$Resources:Resource,ActionAuthorized %>" ValidationGroup="ActionAuthorize"
                                        OnClick="btnActionAuthorize_Click" />
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
