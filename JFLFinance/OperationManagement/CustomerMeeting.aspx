<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="true" CodeFile="CustomerMeeting.aspx.cs" Inherits="OperationManagement_CustomerMeeting"
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
                                <td width="100">
                                    <asp:Label ID="lblMeetingNo" Width="80px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,MeetingNo %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMeetingNo" MaxLength="35" Width="120px" AutoPostBack="true" CssClass="csstxtbox"
                                        runat="server" OnTextChanged="txtMeetingNo_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="IMGMeetingNumber" AlternateText="<%$Resources:Resource,SearchClientMeeting%>"
                                        runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td width="200">
                                    <asp:Label ID='lblTrnS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                    <asp:Label ID="lblMeetingStatus" CssClass="csstxtbox" runat="server" Width="110px"
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
                                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,ClientMeetingDetail %>"></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" width="890" style="vertical-align: top" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="right" width="100">
                                                    <asp:Label ID="Label3" CssClass="cssLabel" Width="80px" runat="server" Text="<%$Resources:Resource,Date %>"></asp:Label>
                                                </td>
                                                <td align="left" width="150">
                                                    <asp:TextBox ID="txtMeetingDate" ValidationGroup="Save" Width="110px" CssClass="csstxtbox"
                                                        Enabled="false" runat="server" Style="text-align: justify"></asp:TextBox>
                                                    <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtMeetingDate" PopupButtonID="IMGDate" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtMeetingDate" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right" width="100">
                                                    <asp:Label ID="Label4" runat="server" Width="90px" Text="<%$Resources:Resource,MeetingType %>"></asp:Label>
                                                </td>
                                                <td align="left" width="160">
                                                    <asp:DropDownList ID="ddlMeetingType" AutoPostBack="false" Width="160px" CssClass="cssDropDown"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="300">
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Panel ID="PanelAssignmentDetails" Width="890px" GroupingText="<%$Resources:Resource,AssignmentDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890px" cellpadding="1" cellspacing="1">
                                                            <tr>
                                                                <td align="right" width="100px" nowrap="nowrap">
                                                                    <asp:Label ID="Label8" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:DropDownList ID="ddlClientId" Width="755px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="100px">
                                                                    <asp:Label ID="Label7" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AsmtID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:DropDownList ID="ddlAsmtId" Width="755px" CssClass="cssDropDown" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="height: 23px">
                                                                    <asp:Label ID="Label10" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140" style="height: 23px">
                                                                    <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="height: 23px">
                                                                    <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="600px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <table border="0" width="100%" cellpadding="1" cellspacing="1">
                                                        <tr>
                                                            <td align="right" width="155px">
                                                                <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerRepresentative %>"></asp:Label>
                                                            </td>
                                                            <td colspan="3" align="left">
                                                                <asp:TextBox ID="txtCustomerRepresentative" ValidationGroup="Save" Width="752" CssClass="csstxtbox"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtCustomerRepresentative" ValidationGroup="Save" ErrorMessage="*"
                                                                    Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" width="150">
                                                                <asp:Label ID="Label5" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Context %>"></asp:Label>
                                                            </td>
                                                            <td align="left" width="200">
                                                                <asp:DropDownList ID="ddlContext" Width="200" CssClass="cssDropDown" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" width="200">
                                                                <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,IncidentComplainNo %>"></asp:Label>
                                                            </td>
                                                            <td align="left" nowrap="nowrap">
                                                                <asp:DropDownList ID="ddlIncidentNo" Width="300" CssClass="cssDropDown" runat="server" Enabled="false">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lblErrorMsg" EnableViewState="false" CssClass="csslblErrMsg" runat="server"
                                            Text=""></asp:Label>
                                        <table width="100%" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelOurRep" Width="890px" GroupingText="<%$Resources:Resource,OurRepresentativeDetail %>"
                                                        BorderWidth="0px" ScrollBars="Auto" CssClass="ScrollBar" Height="95px" runat="server">
                                                        <asp:GridView Width="850px" ID="gvOurRepresentative" PageSize="2" CssClass="GridViewStyle"
                                                            runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" AllowSorting="false"
                                                            ShowFooter="True" OnRowCancelingEdit="gvOurRepresentative_RowCancelingEdit"
                                                            OnRowCommand="gvOurRepresentative_RowCommand" OnRowDataBound="gvOurRepresentative_RowDataBound"
                                                            OnRowDeleting="gvOurRepresentative_RowDeleting" OnRowEditing="gvOurRepresentative_RowEditing"
                                                            OnRowUpdating="gvOurRepresentative_RowUpdating">
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
                                                                            ValidationGroup="vgEdit" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="ImageButton2" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
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
                                                                            CssClass="cssImgButton" ValidationGroup="vgAddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,OurRepresentative %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtOurRepresentative" CssClass="csstxtbox" Text='<%# Eval("G4s_representative") %>'
                                                                            runat="server" AutoPostBack="True" ValidationGroup="vgEdit" OnTextChanged="txtOurRepresentative_TextChanged"></asp:TextBox>
                                                                        <asp:Label ID="lblOurRepresentative" Visible="false" runat="server" Text='<%# Eval("G4s_representative") %>'></asp:Label>
                                                                        <asp:ImageButton ID="imgOurRepresentative" AlternateText="<%$Resources:Resource,SearchEmployee %>"
                                                                            runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" Display="Dynamic"
                                                                            ControlToValidate="txtOurRepresentative" ValidationGroup="vgEdit" ErrorMessage="*"
                                                                            Text="*"></asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewOurRepresentative" EnableViewState="false" ValidationGroup="vgAddNew"
                                                                            CssClass="csstxtbox" runat="server" AutoPostBack="True" OnTextChanged="txtNewOurRepresentative_TextChanged"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgNewOurRepresentative" AlternateText="SearchClient" runat="server"
                                                                            ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic"
                                                                            ControlToValidate="txtNewOurRepresentative" ValidationGroup="vgAddNew" ErrorMessage="*"
                                                                            Text="*"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOurRepresentative" CssClass="cssLabel" runat="server" Text='<%# Bind("G4s_representative") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Name %>">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblName" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblNewName" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Designation %>">
                                                                    <EditItemTemplate>
                                                                        &nbsp;<asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblNewDesignation" CssClass="cssLabel" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelActionInfoToClient" Width="890px" GroupingText="<%$Resources:Resource,ActionInfoToClient %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                                            <tr>
                                                                <td align="right" width="150">
                                                                    <asp:Label ID="Label11" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,InfoDetail %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="740">
                                                                    <asp:TextBox ID="txtInfoDetail" ValidationGroup="Update" Width="720" CssClass="csstxtbox"
                                                                        runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtInfoDetail" ValidationGroup="ActionAuthorize" ErrorMessage="*"
                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="150" align="right">
                                                                    <asp:Label ID="Label12" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Date %>"></asp:Label>
                                                                </td>
                                                                <td width="200" align="left">
                                                                    <asp:TextBox ID="txtOnDate" ValidationGroup="ActionAuthorize" CssClass="csstxtbox"
                                                                        Enabled="false" runat="server"></asp:TextBox>
                                                                    <asp:ImageButton ID="IMGOnDate" Style="vertical-align: middle" CausesValidation="false"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtOnDate" PopupButtonID="IMGOnDate" PopupPosition="TopLeft" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtOnDate" ValidationGroup="ActionAuthorize" ErrorMessage="*"
                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="tabel1" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel2" Width="890px" GroupingText="<%$Resources:Resource,ClientMeetingDetail %>"
                                                        BorderWidth="1px" runat="server" ScrollBars="Auto" Height="120" CssClass="ScrollBar">
                                                        <table cellpadding="1" cellspacing="1">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView Width="2150px" ID="gvClientMeetingDetail" CssClass="GridViewStyle"
                                                                        runat="server" CellPadding="1" PageSize="3" GridLines="None" AutoGenerateColumns="False"
                                                                        AllowSorting="false" ShowFooter="True" OnRowDataBound="gvClientMeetingDetail_RowDataBound"
                                                                        OnRowCancelingEdit="gvClientMeetingDetail_RowCancelingEdit"
                                                                        OnRowCommand="gvClientMeetingDetail_RowCommand" OnRowDeleting="gvClientMeetingDetail_RowDeleting"
                                                                        OnRowEditing="gvClientMeetingDetail_RowEditing" OnRowUpdating="gvClientMeetingDetail_RowUpdating">
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
                                                                                        CssClass="cssImgButton" CommandName="AddNew" ValidationGroup="AddNewClient" ImageUrl="../Images/AddNew.gif" />
                                                                                    <asp:ImageButton ID="lbReset" CausesValidation="false" ToolTip="<%$Resources:Resource,Reset %>"
                                                                                        runat="server" CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                                </FooterTemplate>
                                                                                <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                                <ItemStyle Width="100px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="RowID" Visible="false" SortExpression="RowID">
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblRowIDEdit" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblRowID" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,ObservationType %>" SortExpression="Observation_Type">
                                                                                <EditItemTemplate>
                                                                                    <asp:DropDownList ID="ddlObservationType" Width="300px" CssClass="cssDropDown" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Width="300px" Text='<%# Bind("Observation_Type") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:DropDownList ID="ddlNewObservationType" Width="300px" CssClass="cssDropDown"
                                                                                        runat="server">
                                                                                    </asp:DropDownList>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,Observation %>" ControlStyle-Width="300px" SortExpression="Observation">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtObservation" CssClass="csstxtbox" Width="300px" runat="server" Text='<%# Bind("Observation") %>'></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtObservation" ValidationGroup="EditClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Width="280px" Text='<%# Bind("Observation") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox ID="txtNewObservation" CssClass="csstxtbox" Width="300px" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtNewObservation" ValidationGroup="AddNewClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,CorrectiveMeasures %>" SortExpression="Corrective_Measures">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtCorrectiveMeasures" CssClass="csstxtbox" Width="300px" runat="server" Text='<%# Bind("Corrective_Measures") %>'></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtCorrectiveMeasures" ValidationGroup="EditClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Width="300px" Text='<%# Bind("Corrective_Measures") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox ID="txtNewCorrectiveMeasures" CssClass="csstxtbox" Width="300px" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtNewCorrectiveMeasures" ValidationGroup="AddNewClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,PromisedDate %>" SortExpression="Promised_Date" ItemStyle-Width="150px" HeaderStyle-Width="150px">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtPromisedDate" ValidationGroup="EditClient" CssClass="csstxtbox" Width="80px"
                                                                                        Enabled="false" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}", Eval("Promised_Date")) %>'></asp:TextBox>
                                                                                    <asp:ImageButton ID="IMGPromisedDate" Style="vertical-align: top" CausesValidation="false"
                                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                                                        TargetControlID="txtPromisedDate" PopupButtonID="IMGPromisedDate" PopupPosition="TopLeft" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtPromisedDate" ValidationGroup="EditClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Width="130px" Text='<%#String.Format("{0:d-MMM-yyyy}", Eval("Promised_Date")) %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox ID="txtNewPromisedDate" ValidationGroup="AddNewClient" CssClass="csstxtbox" Width="80px"
                                                                                        Enabled="false" runat="server"></asp:TextBox>
                                                                                    <asp:ImageButton ID="IMGNewPromisedDate" Style="vertical-align: top" CausesValidation="false"
                                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                                                        TargetControlID="txtNewPromisedDate" PopupButtonID="IMGNewPromisedDate" PopupPosition="TopLeft" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtNewPromisedDate" ValidationGroup="AddNewClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,ActionPlanned %>" Visible="false"
                                                                                SortExpression="Action_Planned">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtActionPlanned" CssClass="csstxtbox" runat="server" Width="200px" Text='<%# Bind("Action_Planned") %>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblActionPlanned" CssClass="cssLabel" runat="server" Width="200px" Text='<%# Bind("Action_Planned") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox ID="txtNewActionPlanned" CssClass="csstxtbox" Width="200px" runat="server"></asp:TextBox>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,Responsibility %>" Visible="false" ItemStyle-Width="150px"
                                                                                SortExpression="Responsibility">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtResponsibility" ValidationGroup="EditClient" CssClass="csstxtbox" Width="80px"
                                                                                        runat="server" Text='<%# Bind("Responsibility") %>' AutoPostBack="True" OnTextChanged="txtResponsibility_TextChanged"></asp:TextBox>
                                                                                    <asp:ImageButton ID="imgResponsibility" AlternateText="Search Employee" runat="server"
                                                                                        ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtResponsibility" ValidationGroup="EditClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Width="130px" Text='<%# Bind("Responsibility") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox ID="txtNewResponsibility" ValidationGroup="AddNewClient" CssClass="csstxtbox" Width="80px"
                                                                                        runat="server" AutoPostBack="True" OnTextChanged="txtNewResponsibility_TextChanged"></asp:TextBox>
                                                                                    <asp:ImageButton ID="imgNewResponsibility" AlternateText="Search Employee" runat="server"
                                                                                        ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtNewResponsibility" ValidationGroup="AddNewClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,Name %>" Visible="false" SortExpression="Name">
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblName" CssClass="cssLabel" runat="server" Width="150px" Text='<%# Bind("Name") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label7" CssClass="cssLabel" runat="server" Width="150px" Text='<%# Bind("Name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblNewName" CssClass="cssLabel" Width="150px" runat="server"></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,Designation %>" Visible="false"
                                                                                SortExpression="Designation">
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Width="250px" Text='<%# Bind("Designation") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label8" CssClass="cssLabel" runat="server" Width="250px" Text='<%# Bind("Designation") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblNewDesignation" CssClass="cssLabel" Width="250px" runat="server"></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,ActionDate %>" Visible="false" ItemStyle-Width="150px" HeaderStyle-Width="130px"
                                                                                SortExpression="Action_Date">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtActionDate" ValidationGroup="EditClient" CssClass="csstxtbox" Width="80px"
                                                                                        Enabled="false" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}", Eval("Action_Date")) %>'></asp:TextBox>
                                                                                    <asp:ImageButton ID="IMGActionDate" Visible="true" Style="vertical-align: top;"
                                                                                        CausesValidation="false" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                                        TargetControlID="txtActionDate" PopupButtonID="IMGActionDate" PopupPosition="TopLeft" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtActionDate" ValidationGroup="EditClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblActionDate" CssClass="cssLabel" runat="server" Width="130px" Text='<%#String.Format("{0:d-MMM-yyyy}", Eval("Action_Date")) %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox ID="txtNewActionDate" ValidationGroup="AddNewClient" CssClass="csstxtbox" Width="80px"
                                                                                        Enabled="false" runat="server"></asp:TextBox>
                                                                                    <asp:ImageButton ID="IMGNewActionDate" Style="vertical-align: top" CausesValidation="false"
                                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                                                        TargetControlID="txtNewActionDate" PopupButtonID="IMGNewActionDate" PopupPosition="TopLeft" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtNewActionDate" ValidationGroup="AddNewClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,Remarks %>" Visible="false"
                                                                                SortExpression="Remarks">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtRemarks" Width="200px" ValidationGroup="EditClient" CssClass="csstxtbox"
                                                                                        runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtRemarks" ValidationGroup="EditClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblRemarks" CssClass="cssLabel" runat="server" Width="200px" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox ID="txtNewRemarks" ValidationGroup="AddNewClient" Width="200px" CssClass="csstxtbox"
                                                                                        runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtNewRemarks" ValidationGroup="AddNewClient" ErrorMessage="*"
                                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlNextMeetingDetail" Width="890px" GroupingText="<%$Resources:Resource,NextMeetingDetails %>"
                                                        runat="server">
                                                        <table width="890px">
                                                            <tr>
                                                                <td align="right" style="width:150px;">
                                                                    <asp:Label ID="lblMOM" runat="server" Text="<%$Resources:Resource,MinutesOfMeeting %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtMOM" runat="server" TextMode="MultiLine" Width="700px"></asp:TextBox>
                                                                </td>
                                                                </tr>
                                                                <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblNextActionPlan" runat="server" Text="<%$Resources:Resource,ActionPlan %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtNextActionPlan" runat="server" TextMode="MultiLine" Width="700px"></asp:TextBox>
                                                                </td>
                                                                </tr>
                                                                <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblNextMeetingDate" runat="server" Text="<%$Resources:Resource,NextMeetingDate %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtNextMeetingDate" ValidationGroup="ActionAuthorize" CssClass="csstxtbox"
                                                                        Enabled="false" runat="server"></asp:TextBox>
                                                                    <asp:ImageButton ID="IMGNextMeetingDate" Style="vertical-align: middle" CausesValidation="false"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender6" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtNextMeetingDate" PopupButtonID="IMGNextMeetingDate" PopupPosition="TopLeft" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtNextMeetingDate" ValidationGroup="ActionAuthorize" ErrorMessage="*"
                                                                        Text="*"></asp:RequiredFieldValidator>
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
                        </asp:Panel>
                        <table cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                        Visible="False" ValidationGroup="NoGroup" OnClick="btnAddNew_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Save" CommandName="Save"
                                        runat="server" Text="<%$Resources:Resource,Save %>" Visible="false" OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" CssClass="cssButton" ValidationGroup="Save" runat="server"
                                        Visible="false" Text="<%$Resources:Resource,Update %>" OnClick="btnUpdate_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnObservationAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Width="120px" Text="<%$Resources:resource,ObservationAuthorized %>" OnClick="btnObservationAuthorize_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnPlanAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Width="120px" Text="<%$Resources:resource,PlanAuthorized %>" OnClick="btnPlanAuthorize_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnActionAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Width="120px" Text="<%$Resources:Resource,ActionAuthorized %>" ValidationGroup="ActionAuthorize"
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
                        <table>
                            <tr>
                                <td>
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
