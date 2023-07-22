<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ClientController.aspx.cs" Inherits="MonitorScreen_ClientController" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="TabFlowDiag"
        Width="1050px" Height="500px" ActiveTabIndex="0">
        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelTabFlowDiag" runat="server"
            HeaderText="Attendance" TabIndex="0">
            <ContentTemplate>
                <Ajax:UpdatePanel ID="UPAttendance" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:Panel ID="up1" runat="server">
                                        <table border="0" width="95%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFromTime" CssClass="cssLabel" runat="server" Text="From Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTimeFrom" Width="40px" runat="server" CssClass="csstxtbox" ValidationGroup="VGAttendanceSubmit" />

                                                    <asp:RequiredFieldValidator ID="rfvFrom" runat="server" ControlToValidate="txtTimeFrom"
                                                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGAttendanceSubmit" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="To Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTimeTo" ValidationGroup="VGAttendanceSubmit" Width="40px" runat="server"
                                                        CssClass="csstxtbox" />
                                                    <asp:RequiredFieldValidator ID="rfvTO" runat="server" ControlToValidate="txtTimeTO"
                                                        ValidationGroup="VGAttendanceSubmit" ErrorMessage="*" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="WEF Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtWEF" ValidationGroup="VGAttendanceSubmit" Width="90px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="ajxCal" runat="server" TargetControlID="txtWEF"
                                                        PopupButtonID="imgDate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWEF"
                                                        ErrorMessage="*" ValidationGroup="VGAttendanceSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWET" CssClass="cssLabel" runat="server" Text="WET Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtWET" ValidationGroup="VGAttendanceSubmit" Width="90px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgDateTo" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender7" runat="server"
                                                        TargetControlID="txtWET" PopupButtonID="imgDateTo" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtWET"
                                                        ErrorMessage="*" ValidationGroup="VGAttendanceSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnSubmit" ValidationGroup="VGAttendanceSubmit" runat="server" CssClass="cssButton"
                                                        Text="Submit" OnClick="btnSubmit_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnASubmit" ValidationGroup="VGAttendanceSubmit" runat="server" Style="display: none;" CssClass="cssButton"
                                                        Text="Export" OnClick="btnASubmit_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="1050px" Height="430px"
                                                        ScrollBars="Auto" CssClass="ScrollBar">
                                                        <asp:GridView ID="gvDetail" PageSize="14" Width="1040px" runat="server" AllowPaging="True"
                                                            AutoGenerateColumns="False" OnRowDataBound="gvDetail_RowDataBound" OnPageIndexChanging="gvDetail_PageIndexChanging"
                                                            CellPadding="1" CssClass="GridViewStyle">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ClientCode %>">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnHyperLink" runat="server" CssClass="cssImgButton" ImageUrl="../Images/plus.gif"
                                                                            OnClick="ImgbtnHyperLink_Click" />
                                                                        <asp:Label ID="lblgvAsmtCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="150px" />
                                                                    <HeaderStyle Width="150px" />
                                                                    <ItemStyle Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,ClientName %>" DataField="ClientName" AccessibleHeaderText="ClientName" />
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Schedule %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSchedule" runat="server" Text='<%# Eval("ScheduleCount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Actual Count">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblActualCount" CssClass="cssLable" runat="server" Text='<%# Eval("ActualCount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Incomplete Duty">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncompleteDuty" CssClass="cssLable" runat="server" Text='<%# Eval("InCompleteDuty") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="UnScheduled Employee">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnScheduledEmployee" CssClass="cssLable" runat="server" Text='<%# Eval("UnScheduledCount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Actual Scheduled Match">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblActualScheduleMatchCount" runat="server" Text='<%# Eval("ActualScheduleMatchCount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Status %>">
                                                                    <ItemTemplate>
                                                                        <asp:Image runat="server" ID="IMGRed" ToolTip="Resource status:Green ok/ Red Short" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                Data Not Found !
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img alt="" style="width: 10px; height: 10px; background-color: Red" src='~/Images/Green1.jpg'></img>
                                    <asp:Literal ID="ltrScheduled" runat="server" Text="On Duty less than scheduled"></asp:Literal>
                                </td>
                                <td>
                                    <img alt="" style="width: 10px; height: 10px; background-color: green" src='~/Images/red.jpg'></img>
                                    <asp:Literal ID="Literal1" runat="server" Text="On Duty equals scheduled"></asp:Literal>
                                </td>
                                <td>
                                    <img alt="" style="width: 10px; height: 10px; background-color: blue" src='~/Images/red.jpg'></img>
                                    <asp:Literal ID="Literal2" runat="server" Text="Unscheduled Coverage"></asp:Literal>
                                </td>
                                <td>
                                    <img alt="" style="width: 10px; height: 10px; background-color: orange" src='~/Images/red.jpg'></img>
                                    <asp:Literal ID="LiteralPending" runat="server" Text="Pending & Others"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
                <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;" class="modalBackground">
                            <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%" alt="" src="../Images/spinner.gif" />
                        </div>
                    </ProgressTemplate>
                </Ajax:UpdateProgress>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel visible="False" Style="text-align: left;" TabIndex="1" ID="TabPanel1" runat="server" HeaderText="POP">
            <HeaderTemplate>
                POP
            </HeaderTemplate>
            <ContentTemplate>
                <Ajax:UpdatePanel ID="UPPOP" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="up3" runat="server">
                            <table>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="WEF Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPOPWEF" AutoPostBack="True" OnTextChanged="txtPOPWEF_TextChanged"
                                            runat="server" CssClass="csstxtbox" ValidationGroup="VGPOP" Width="70px" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                        <asp:Image ID="IMGPOPWefDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle;" />
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                            Format="dd-MMM-yyyy" PopupButtonID="IMGPOPWefDate" TargetControlID="txtPOPWEF"></AjaxToolKit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPOPWEF"
                                            ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGPOP"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblToDate" CssClass="cssLabel" runat="server" Text="WET Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPOPWET" AutoPostBack="True" runat="server" CssClass="csstxtbox"
                                            ValidationGroup="VGPOP" Width="70px" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                        <asp:Image ID="IMGPOPToDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle;" />
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True"
                                            Format="dd-MMM-yyyy" PopupButtonID="IMGPOPToDate" TargetControlID="txtPOPWET"></AjaxToolKit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPOPWET"
                                            ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGPOP"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnPOPSubmit" runat="server" CssClass="cssButton" OnClick="btnPOPSubmit_Click"
                                            Text="Submit" ValidationGroup="VGPOP" />
                                        <asp:Button ID="btnPOPExport" runat="server" Visible="false" Text="Export" CssClass="cssButton"
                                            OnClick="btnPOPExport_Click" ValidationGroup="VGPOP" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" BorderWidth="1px" runat="server" Width="950px" Height="430px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:HiddenField ID="HFAsmtCode" runat="server" />
                                        <asp:HiddenField ID="HFPostAutoID" runat="server" />
                                        <asp:HiddenField ID="HFPLocationTagID" runat="server" />
                                        <asp:GridView ID="gvPOP" PageSize="14" Width="950px" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" OnPageIndexChanging="gvPOP_PageIndexChanging" CellPadding="1"
                                            CssClass="GridViewStyle">
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ClientCode %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientCode" runat="server" CssClass="cssLabel" Text="<%#Bind('ClientCode') %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ClientName %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientName" runat="server" CssClass="cssLabel" Text="<%#Bind('ClientName') %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="250px" />
                                                </asp:TemplateField>
                                                <%--//Code Added By  --%>
                                                <asp:TemplateField HeaderText="TagID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTagID" runat="server" CssClass="cssLabel" Text="<%#Bind('TagID') %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Asmt %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAsmt" runat="server" CssClass="cssLabel" Text="<%#Bind('Asmt') %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAsmtCode" runat="server" CssClass="cssLabel" Text="<%#Bind('AsmtCode') %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Post%>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblpostAutoID" runat="server" CssClass="cssLabel" Text="<%#Bind('PostAutoId') %>"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLocationTagID" runat="server" CssClass="cssLabel" Text="<%#Bind('LocationTagID') %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <%--// ENd of Code Added By  --%>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Post %>">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblPostCode" runat="server" ValidationGroup="VGPOP" CssClass="cssLabel"
                                                            Text="<%#Bind('PostCode') %>" OnClientClick="" OnClick="lblPostCode_Click"></asp:LinkButton>
                                                        <asp:GridView ID="gvEmpDetail" PageSize="15" Width="100%" runat="server" AllowPaging="True"
                                                            AutoGenerateColumns="False" OnPageIndexChanging="gvEmpDetail_PageIndexChanging"
                                                            CellPadding="1" CssClass="GridViewStyle">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Employee Number" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmployeeNumber" runat="server" CssClass="cssLabel" Text="<%#Bind('EmployeeNumber') %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmployeeName" runat="server" CssClass="cssLabel" Text="<%#Bind('EmployeeName') %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Time" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTime" runat="server" CssClass="cssLabel" Text="<%#Bind('Time') %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Duty Date" HeaderStyle-Width="120px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDutyDate" runat="server" CssClass="cssLabel" Text="<%#Bind('DutyDate') %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Type" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTxnType" runat="server" CssClass="cssLabel" Text="<%#Bind('Flag') %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="700px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                Data Not Found !
                                            </EmptyDataTemplate>
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel visible="False" Style="text-align: left;" ID="PanelTagIncident" runat="server"
            HeaderText="Incident" TabIndex="2">
            <HeaderTemplate>
                Incident
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <asp:Panel runat="server" ID="upd2">
                                <table border="0" width="80%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblIFromTime" CssClass="cssLabel" runat="server" Text="From Time"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtITimeFrom" Width="40px" runat="server" CssClass="csstxtbox" ValidationGroup="VGIncidentSubmit" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtITimeFrom"
                                                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGIncidentSubmit" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIToTime" CssClass="cssLabel" runat="server" Text="To Time"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtITimeTO" ValidationGroup="VGIncidentSubmit" Width="40px" runat="server"
                                                CssClass="csstxtbox" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtITimeTO"
                                                ValidationGroup="VGIncidentSubmit" ErrorMessage="*" SetFocusOnError="True" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIWEF" CssClass="cssLabel" runat="server" Text="WEF Date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIWEF" ValidationGroup="VGIncidentSubmit" Width="70px" runat="server"
                                                CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                            <asp:Image ID="imgIDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                            <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender2" runat="server"
                                                TargetControlID="txtIWEF" PopupButtonID="imgIDate" Enabled="True" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIWEF"
                                                ErrorMessage="*" ValidationGroup="VGIncidentSubmit" SetFocusOnError="True" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIWET" CssClass="cssLabel" runat="server" Text="WET Date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIWET" ValidationGroup="VGIncidentSubmit" Width="70px" runat="server"
                                                CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                            <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender9" runat="server"
                                                TargetControlID="txtIWET" PopupButtonID="imgIToDate" Enabled="True" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtIWET"
                                                ErrorMessage="*" ValidationGroup="VGIncidentSubmit" SetFocusOnError="True" />
                                            <asp:Image ID="imgIToDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnISubmit" ValidationGroup="VGIncidentSubmit" runat="server" CssClass="cssButton"
                                                Text="Submit" OnClick="btnISubmit_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnIExport" runat="server" CssClass="cssButton" Text="Export" OnClick="btnIExport_Click"
                                                Style="display: none" ValidationGroup="VGIncidentSubmit" />
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" width="100%" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlgvIncident" BorderWidth="1px" runat="server" Width="950px" Height="430px"
                                                ScrollBars="Auto" CssClass="ScrollBar">
                                                <asp:GridView ID="gvIncident" PageSize="14" Width="950px" runat="server" AllowPaging="True"
                                                    AutoGenerateColumns="False" OnPageIndexChanging="gvIncident_PageIndexChanging"
                                                    CellPadding="1" CssClass="GridViewStyle" OnRowCommand="gvIncident_RowCommand"
                                                    OnRowDataBound="gvIncident_RowDataBound">
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Incident ID" DataField="IncidentID" AccessibleHeaderText="IncidentID" />
                                                        <asp:BoundField HeaderText="Incident Type" DataField="IncidentType" AccessibleHeaderText="IncidentType" />
                                                        <asp:BoundField HeaderText="<%$Resources:Resource,Client %>" DataField="ClientName" AccessibleHeaderText="ClientName" />
                                                        <asp:BoundField HeaderText="<%$Resources:Resource,Asmt %>" DataField="Asmt" AccessibleHeaderText="Asmt" />
                                                        <asp:BoundField HeaderText="<%$Resources:Resource,Post %>" DataField="Post" AccessibleHeaderText="Post" />
                                                        <%--//Code Added By  --%>
                                                        <asp:BoundField HeaderText="TagID" DataField="TagID" AccessibleHeaderText="TagID" />
                                                        <asp:BoundField HeaderText="Reported By" DataField="EmployeeNumber" AccessibleHeaderText="EmployeeNumber" />
                                                        <asp:BoundField HeaderText="Time" DataField="Time" AccessibleHeaderText="Time" />
                                                        <%--//Code Added By  --%>
                                                        <asp:BoundField HeaderText="SmsMessage" DataField="SmsMessage" AccessibleHeaderText="SmsMessage" />
                                                        <asp:TemplateField HeaderText="Duty Date" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDutyDate" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:ImageField DataImageUrlField="AviFile" NullImageUrl="~/Images/Noimages.jpg">
                                                            <ControlStyle Height="10px" Width="10px" />
                                                        </asp:ImageField>
                                                        <asp:TemplateField HeaderText="View/Download">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="LnkDownload" runat="server" Target="_blank" NavigateUrl='<%# Eval("Attachment") %>'>View</asp:HyperLink><%--ImageUrl="~/DownloadIcon.jpg"--%>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Attachment") %>'
                                                                    CommandName="cmd" CausesValidation="false">Download</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        Data Not Found !
                                                    </EmptyDataTemplate>
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <Ajax:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;"
                            class="modalBackground">
                            <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                                alt="" src="../Images/spinner.gif" />
                        </div>
                    </ProgressTemplate>
                </Ajax:UpdateProgress>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel visible="False" Style="text-align: left;" ID="PanelTagPanicAlert" runat="server"
            HeaderText="Panic Alert" TabIndex="3">
            <HeaderTemplate>
                Panic Alert
            </HeaderTemplate>
            <ContentTemplate>
                <Ajax:UpdatePanel ID="UPPanic" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:Panel ID="udpPanic" runat="server">
                                        <table border="0" width="80%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPFromTime" CssClass="cssLabel" runat="server" Text="From Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPFromTime" Width="40px" runat="server" CssClass="csstxtbox" ValidationGroup="VGPanicSubmit" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPFromTime"
                                                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGPanicSubmit" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPToTime" CssClass="cssLabel" runat="server" Text="To Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPToTime" ValidationGroup="VGPanicSubmit" Width="40px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPToTime"
                                                        ValidationGroup="VGPanicSubmit" ErrorMessage="*" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPWEF" CssClass="cssLabel" runat="server" Text="WEF Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPWEF" ValidationGroup="VGPanicSubmit" Width="70px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgPDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender3" runat="server"
                                                        TargetControlID="txtPWEF" PopupButtonID="imgPDate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPWEF"
                                                        ErrorMessage="*" ValidationGroup="VGPanicSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text="WET Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPWET" ValidationGroup="VGPanicSubmit" Width="70px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgPToDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender10" runat="server"
                                                        TargetControlID="txtPWET" PopupButtonID="imgPToDate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtPWET"
                                                        ErrorMessage="*" ValidationGroup="VGPanicSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnPSubmit" ValidationGroup="VGPanicSubmit" runat="server" CssClass="cssButton"
                                                        Text="Submit" OnClick="btnPSubmit_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnPExport" runat="server" Visible="false" CssClass="cssButton" Text="Export"
                                                        OnClick="btnPExport_Click" Style="display: none" ValidationGroup="VGPanicSubmit" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlgvPanic" BorderWidth="1px" runat="server" Width="950px" Height="430px"
                                                        ScrollBars="Auto" CssClass="ScrollBar">
                                                        <asp:GridView ID="gvPanic" PageSize="14" Width="800px" runat="server" AllowPaging="True"
                                                            AutoGenerateColumns="False" OnPageIndexChanging="gvPanic_PageIndexChanging" CellPadding="1"
                                                            CssClass="GridViewStyle">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <EmptyDataTemplate>
                                                                Data Not Found !
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Alert Id" DataField="PanicAlertId" AccessibleHeaderText="PanicAlertId" />
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Client %>" DataField="ClientName" AccessibleHeaderText="ClientName" />
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Asmt %>" DataField="Asmt" AccessibleHeaderText="Asmt" />
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Post %>" DataField="Post" AccessibleHeaderText="Post" />
                                                                <asp:BoundField HeaderText="Time" DataField="Time" AccessibleHeaderText="Time" />
                                                                <asp:TemplateField HeaderText="Panic Date" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDutyDate" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
                <Ajax:UpdateProgress ID="UpdateProgress3" runat="server">
                    <ProgressTemplate>
                        <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;"
                            class="modalBackground">
                            <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                                alt="" src="../Images/spinner.gif" />
                        </div>
                    </ProgressTemplate>
                </Ajax:UpdateProgress>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelTagVacantPost" runat="server"
            HeaderText="Vacant Post" TabIndex="4">
            <HeaderTemplate>
                Vacant Post
            </HeaderTemplate>
            <ContentTemplate>
                <Ajax:UpdatePanel ID="UPVacant" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:Panel ID="udpVacant" runat="server">
                                        <table border="0" width="80%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblVFromTime" CssClass="cssLabel" runat="server" Text="From Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVFromTime" Width="40px" runat="server" CssClass="csstxtbox" ValidationGroup="VGVacantSubmit"
                                                        onblur="javascript:timecompair(this);" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtVFromTime"
                                                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGVacantSubmit" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblVToTime" CssClass="cssLabel" runat="server" Text="To Time"> </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVToTime" ValidationGroup="VGVacantSubmit" Width="40px" runat="server"
                                                        CssClass="csstxtbox" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtVToTime"
                                                        ValidationGroup="VGVacantSubmit" ErrorMessage="*" SetFocusOnError="True" />
                                                    <asp:Label ID="lblErrvacntTotime" runat="server" ForeColor="Red" Visible="false" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblVWEF" CssClass="cssLabel" runat="server" Text="WEF Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVWEF" ValidationGroup="VGVacantSubmit" Width="90px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgVDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender4" runat="server"
                                                        TargetControlID="txtVWEF" PopupButtonID="imgVDate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtVWEF"
                                                        ErrorMessage="*" ValidationGroup="VGVacantSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text="WET Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVWET" ValidationGroup="VGVacantSubmit" Width="90px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgVTODate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender11" runat="server"
                                                        TargetControlID="txtVWET" PopupButtonID="imgVTODate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtVWET"
                                                        ErrorMessage="*" ValidationGroup="VGVacantSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnVSubmit" ValidationGroup="VGVacantSubmit" runat="server" CssClass="cssButton"
                                                        Text="Submit" OnClick="btnVSubmit_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnVExport" runat="server" Text="Export" CssClass="cssButton" OnClick="btnVExport_Click"
                                                        ValidationGroup="VGVacantSubmit" Style="display: none" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlgvVacant" BorderWidth="1px" runat="server" Width="950px" Height="430px"
                                                        ScrollBars="Auto" CssClass="ScrollBar">
                                                        <asp:GridView ID="gvVacant" PageSize="14" Width="1500px" runat="server" AllowPaging="True"
                                                            AutoGenerateColumns="False" OnPageIndexChanging="gvVacant_PageIndexChanging"
                                                            CellPadding="1" CssClass="GridViewStyle">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Status" DataField="Status" AccessibleHeaderText="Status" />
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Client %>" DataField="ClientName" AccessibleHeaderText="ClientName" />
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Asmt %>" DataField="Asmt" AccessibleHeaderText="Asmt" />
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Post %>" DataField="PostCode" AccessibleHeaderText="PostCode" />
                                                                <asp:BoundField HeaderText="Off Duty Employee" DataField="OnDutyEmployeeName" AccessibleHeaderText="OnDutyEmployeeName" />
                                                                <asp:BoundField HeaderText="Phone Number" DataField="DutyStartPhoneNumber" AccessibleHeaderText="DutyStartPhoneNumber" />
                                                                <asp:BoundField HeaderText="Duty Date" DataField="DutyStartDutyDate" AccessibleHeaderText="DutyStartDutyDate" />
                                                                <asp:BoundField HeaderText="Sch Time" DataField="OnDutySchTime" AccessibleHeaderText="OnDutySchTime" />
                                                                <asp:BoundField HeaderText="Swipe Time" DataField="OnDutySwipeTime" AccessibleHeaderText="OnDutySwipeTime" />
                                                                <asp:BoundField HeaderText="To Join Employee" DataField="ToJoinEmployeeName" AccessibleHeaderText="ToJoinEmployeeName" />
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                Data Not Found !
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
                <Ajax:UpdateProgress ID="UpdateProgress4" runat="server">
                    <ProgressTemplate>
                        <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;"
                            class="modalBackground">
                            <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                                alt="" src="../Images/spinner.gif" />
                        </div>
                    </ProgressTemplate>
                </Ajax:UpdateProgress>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelTagNoShow" runat="server"
            HeaderText="No Show" TabIndex="5">
            <HeaderTemplate>
                No Show
            </HeaderTemplate>
            <ContentTemplate>
                <Ajax:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:Panel runat="server" ID="udpNoShow">
                                        <table border="0" width="80%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblNFromTime" CssClass="cssLabel" runat="server" Text="From Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNFromTime" Width="40px" runat="server" CssClass="csstxtbox" ValidationGroup="VGShowSubmit" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNFromTime"
                                                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGShowSubmit" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNToTime" CssClass="cssLabel" runat="server" Text="To Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNToTime" ValidationGroup="VGShowSubmit" Width="40px" runat="server"
                                                        CssClass="csstxtbox" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtNToTime"
                                                        ValidationGroup="VGShowSubmit" ErrorMessage="*" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNWEF" CssClass="cssLabel" runat="server" Text="WEF Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNWEF" ValidationGroup="VGShowSubmit" Width="90px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgNDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender5" runat="server"
                                                        TargetControlID="txtNWEF" PopupButtonID="imgNDate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtNWEF"
                                                        ErrorMessage="*" ValidationGroup="VGShowSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="WET Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNWET" ValidationGroup="VGShowSubmit" Width="90px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgNTODate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender12" runat="server"
                                                        TargetControlID="txtNWET" PopupButtonID="imgNTODate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtNWET"
                                                        ErrorMessage="*" ValidationGroup="VGShowSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnNSubmit" ValidationGroup="VGShowSubmit" runat="server" CssClass="cssButton"
                                                        Text="Submit" OnClick="btnNSubmit_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnNExport" runat="server" Text="Export" CssClass="cssButton" OnClick="btnNExport_Click"
                                                        ValidationGroup="VGShowSubmit" Style="display: none" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel3" BorderWidth="1px" runat="server" Width="950px" Height="430px"
                                                        ScrollBars="Auto" CssClass="ScrollBar">
                                                        <asp:GridView ID="gvNoShow" PageSize="14" Width="950px" runat="server" AllowPaging="True"
                                                            AutoGenerateColumns="False" OnPageIndexChanging="gvNoShow_PageIndexChanging"
                                                            CellPadding="1" CssClass="GridViewStyle">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Client %>" DataField="ClientName" AccessibleHeaderText="ClientName" />
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Asmt %>" DataField="Asmt" AccessibleHeaderText="Asmt" />
                                                                <asp:BoundField HeaderText="<%$Resources:Resource,Post %>" DataField="PostCode" AccessibleHeaderText="PostCode" />
                                                                <asp:BoundField HeaderText="Employee" DataField="EmployeeNumber" AccessibleHeaderText="EmployeeNumber" />
                                                                <asp:BoundField HeaderText="Phone" DataField="PhoneNumber" AccessibleHeaderText="PhoneNumber" />
                                                                <asp:BoundField HeaderText="Schedule Time" DataField="ScheduledTimeFrom" AccessibleHeaderText="ScheduledTimeFrom" />
                                                                <asp:BoundField HeaderText="Reporting Time" DataField="ReportingTime" AccessibleHeaderText="ReportingTime" />
                                                                <asp:BoundField HeaderText="Swipe Time" DataField="SwipeTime" AccessibleHeaderText="SwipeTime" />
                                                                <asp:BoundField HeaderText="Time Diff" DataField="TimeDiff" AccessibleHeaderText="TimeDiff" />
                                                                <asp:BoundField HeaderText="Status" DataField="Status" AccessibleHeaderText="Status" />
                                                                <asp:TemplateField HeaderText="Duty Date" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDutyDate" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                Data Not Found !
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
                <Ajax:UpdateProgress ID="UpdateProgress5" runat="server">
                    <ProgressTemplate>
                        <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;"
                            class="modalBackground">
                            <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                                alt="" src="../Images/spinner.gif" />
                        </div>
                    </ProgressTemplate>
                </Ajax:UpdateProgress>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel visible="False" Style="text-align: left;" ID="PanelTagGuardTour" runat="server"
            HeaderText="Guard Tour" TabIndex="6">
            <HeaderTemplate>
                Guard Tour
            </HeaderTemplate>
            <ContentTemplate>
                <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:Panel ID="udpGuardTour" runat="server">
                                        <table border="0" width="350px" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="right" style="width: 80px">
                                                    <asp:Label ID="Label7" CssClass="cssLabel" runat="server" Text="Client"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px">
                                                    <asp:DropDownList ID="ddlClientCode" AutoPostBack="true" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"
                                                        Width="250px" CssClass="cssDropDown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label8" CssClass="cssLabel" runat="server" Text="Assignment"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlAsmtCode" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlAsmtCode_SelectedIndexChanged"
                                                        CssClass="cssDropDown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label9" CssClass="cssLabel" runat="server" Text="Post"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlPostCode" Width="250px" CssClass="cssDropDown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="LabelScans" CssClass="cssLabel" runat="server" Text="Scans"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlScanType" Width="152px" CssClass="cssDropDown" runat="server">
                                                        <asp:ListItem Text="All" Value="ALL"></asp:ListItem>
                                                        <asp:ListItem Text="Missed" Value="MISSED"></asp:ListItem>
                                                        <asp:ListItem Text="Scans" Value="SCANS"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <asp:TextBox Width="450px" CssClass="csstxtbox" ID="txtExportString" Visible="false" runat="server" AutoPostBack="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td align="right" style="width: 80px">
                                                    <asp:Label ID="lblGFromTime" CssClass="cssLabel" runat="server" Text="From Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGFromTime" Width="40px" runat="server" CssClass="csstxtbox" ValidationGroup="VGGuardSubmit" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtGFromTime"
                                                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGGuardSubmit" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblGToTime" CssClass="cssLabel" runat="server" Text="To Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGToTime" ValidationGroup="VGGuardSubmit" Width="40px" runat="server"
                                                        CssClass="csstxtbox" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtGToTime"
                                                        ValidationGroup="VGGuardSubmit" ErrorMessage="*" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblGWef" CssClass="cssLabel" runat="server" Text="WEF Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGWef" ValidationGroup="VGGuardSubmit" Width="70px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgGDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender6" runat="server"
                                                        TargetControlID="txtGWef" PopupButtonID="imgGDate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtGWef"
                                                        ErrorMessage="*" ValidationGroup="VGGuardSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblGTODate" CssClass="cssLabel" runat="server" Text="WET Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGWet" ValidationGroup="VGGuardSubmit" Width="70px" runat="server"
                                                        CssClass="csstxtbox" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="imgGTODate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender13" runat="server"
                                                        TargetControlID="txtGWet" PopupButtonID="imgGTODate" Enabled="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtGWet"
                                                        ErrorMessage="*" ValidationGroup="VGGuardSubmit" SetFocusOnError="True" />
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnGSubmit" ValidationGroup="VGGuardSubmit" runat="server" CssClass="cssButton"
                                                        Text="Submit" OnClick="btnGSubmit_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnGExport" runat="server" Text="Export" CssClass="cssButton" Visible="false"
                                                        OnClick="btnGExport_Click" ValidationGroup="VGGuardSubmit" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnGExportDevX" runat="server" Text="Export - Excel" CssClass="cssButton" Visible="false"
                                                        OnClick="btnGExportDevX_Click" CausesValidation="False" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlgvGuardTour" BorderWidth="1px" runat="server" Width="950px" Height="430px"
                                                        ScrollBars="Auto" CssClass="ScrollBar">
                                                        <asp:HiddenField ID="HFTourID" runat="server" />
                                                        <asp:GridView ID="gvGuardTourID" runat="server" OnPageIndexChanging="gvGuardTourID_PageIndexChanging"
                                                            AllowPaging="True" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle"
                                                            PageSize="14" Width="950px">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Client %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClientName" runat="server" CssClass="cssLabel" Text="<%#Bind('ClientName') %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Asmt %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAsmt" runat="server" CssClass="cssLabel" Text="<%#Bind('Asmt') %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Post %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstartTime" runat="server" CssClass="cssLabel" Text="<%#Bind('PostCode') %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TourID">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblTourID" runat="server" CssClass="cssLabel" Text="<%#Bind('GTourIDDesc') %>"
                                                                            OnClick="lblTourID_Click" ValidationGroup="VGSubmit" />
                                                                        <asp:HiddenField ID="HFGuardTourID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GTourID").ToString()%>' />
                                                                        <asp:GridView ID="gvGuardTour" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                            CellPadding="1" CssClass="GridViewStyle" OnRowDataBound="gvGuardTour_RowDataBound"
                                                                            OnPageIndexChanging="gvGuardTour_PageIndexChanging" PageSize="14" Width="950px">
                                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                            <Columns>
                                                                                <asp:BoundField AccessibleHeaderText="PostTagID" DataField="PostTagID" HeaderText="Post TagID" />
                                                                                <asp:BoundField AccessibleHeaderText="TagIDDesc" ItemStyle-Width="210px" DataField="TagIDDesc" HeaderText="Tag Desc" />
                                                                                <asp:BoundField AccessibleHeaderText="ScheduleTime" ItemStyle-Width="230px" DataField="ScheduleTime" HeaderText="Schedule Time" />
                                                                                <asp:BoundField AccessibleHeaderText="SwipeTime" DataField="SwipeTime" HeaderText="Actual Time" />
                                                                                <asp:BoundField AccessibleHeaderText="DutyDate" ItemStyle-Width="70px" DataField="DutyDate" HeaderText="Scan Date" />
                                                                                <asp:BoundField AccessibleHeaderText="EmployeeNumber" ItemStyle-Width="150px" DataField="EmployeeNumber" HeaderText="Employee On Duty" />
                                                                                <asp:BoundField AccessibleHeaderText="PhoneNumber" DataField="PhoneNumber" HeaderText="Phone" />
                                                                            </Columns>
                                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                        </asp:GridView>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
                <Ajax:UpdateProgress ID="UpdateProgress6" runat="server">
                    <ProgressTemplate>
                        <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;"
                            class="modalBackground">
                            <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                                alt="" src="../Images/spinner.gif" />
                        </div>
                    </ProgressTemplate>
                </Ajax:UpdateProgress>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel visible="False" Style="text-align: left;" TabIndex="1" ID="Unscheduled" runat="server"
            HeaderText="POP">
            <HeaderTemplate>
                Unscheduled
            </HeaderTemplate>
            <ContentTemplate>
                <Ajax:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel4" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td align="right" style="width: 80px">
                                                    <asp:Label ID="lblUnClient" CssClass="cssLabel" runat="server" Text="Client"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px">
                                                    <asp:DropDownList ID="ddlUnClientCode" AutoPostBack="true" OnSelectedIndexChanged="ddlUnClientCode_SelectedIndexChanged"
                                                        Width="250px" CssClass="cssDropDown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblUnAssignment" CssClass="cssLabel" runat="server" Text="Assignment"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlUnAsmtCode" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnAsmtCode_SelectedIndexChanged"
                                                        CssClass="cssDropDown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblUnPost" CssClass="cssLabel" runat="server" Text="Post"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlUnPostCode" Width="250px" CssClass="cssDropDown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblUnFRT" CssClass="cssLabel" runat="server" Text="From Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUnTimeFrom" Width="40px" runat="server" CssClass="csstxtbox"
                                                        ValidationGroup="VGUN" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtUnTimeFrom"
                                                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGUN" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblUnTimeTo" CssClass="cssLabel" runat="server" Text="To Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUnTimeTo" ValidationGroup="VGUN" Width="40px" runat="server"
                                                        CssClass="csstxtbox" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtUnTimeTo"
                                                        ValidationGroup="VGUN" ErrorMessage="*" SetFocusOnError="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblUnWEF" CssClass="cssLabel" runat="server" Text="WEF Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUnWEF" AutoPostBack="True" OnTextChanged="txtUnWEF_TextChanged"
                                                        runat="server" CssClass="csstxtbox" ValidationGroup="VGUN" Width="70px" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="IMGUnWefDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle;" />
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender14" runat="server" Enabled="True"
                                                        Format="dd-MMM-yyyy" PopupButtonID="IMGUnWefDate" TargetControlID="txtUnWEF"></AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtUnWEF"
                                                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGUN"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblUnWET" CssClass="cssLabel" runat="server" Text="WET Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUnWET" AutoPostBack="True" runat="server" CssClass="csstxtbox"
                                                        ValidationGroup="VGUN" Width="70px" onblur="javascript:LocalDateValidation(this);"></asp:TextBox>
                                                    <asp:Image ID="IMGUnToDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle;" />
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender15" runat="server" Enabled="True"
                                                        Format="dd-MMM-yyyy" PopupButtonID="IMGUnToDate" TargetControlID="txtUnWET"></AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtUnWET"
                                                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="VGUN"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnUnSubmit" runat="server" CssClass="cssButton" Text="Submit" ValidationGroup="VGUN"
                                                        OnClick="btnUnSubmit_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUnExport" runat="server" Text="Export" CssClass="cssButton" ValidationGroup="VGUN"
                                                        OnClick="btnUnExport_Click" Style="display: none" />
                                                </td>
                                            </tr>
                                        </table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblUnErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                            </table>
                        </asp:Panel>
                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel5" BorderWidth="1px" runat="server" Width="950px" Height="430px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:GridView ID="gvUnscheduledEmployee" PageSize="14" Width="950px" runat="server"
                                            AllowPaging="True" AutoGenerateColumns="true" OnPageIndexChanging="gvUnscheduledEmployee_PageIndexChanging"
                                            CellPadding="1" CssClass="GridViewStyle">
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <EmptyDataTemplate>
                                                Data Not Found !
                                            </EmptyDataTemplate>
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
    </AjaxToolKit:TabContainer>
    <asp:HiddenField ID="hiddenUrl" runat="server" />
    <%-- For verify the date is valid or not --%>

    <script type="text/javascript">
        function LocalDateValidation(obj) {
            var status;
            if (obj.value == "") { return; }
            status = isDate(obj.value, "dd-MMM-yyyy");
            if (!status) {
                alert("Invalid Date!");
                obj.value = "";
                obj.focus();
            }

            function timecompair(obj) {

                var d1;
                d1 = new Date();
                status = d1.getTime();
                alert(status);

            }
        }
    </script>

</asp:Content>
