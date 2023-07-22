<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ControlPanel.aspx.cs" Inherits="MonitorScreen_ControlPanel" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
    <style type="text/css">
        .fixedcell
        {
            height: 16px;
            padding: 0 2 0 2px;
            background-color: #C2BFA5;
            border-left: 1px solid #E1E0D2;
            border-top: 1px solid #E1E0D2;
            border-right: 1px solid #8D8961;
            border-bottom: 1px solid #8D8961;
        }
    </style>
</head>
<body style="margin: 2px" bgcolor="#f3f3f3">
    <form id="form1" runat="server">
    <Ajax:ScriptManager ID="script" runat="server">
    </Ajax:ScriptManager>
    <table border="0" cellpadding="1" cellspacing="1" width="100%" style="background-color: #f3f3f3;
        text-align: center">
        <tr>
            <td colspan="0" style="height: 30px;">
                <asp:Button ID="btnStopRefresh" runat="server" Text="Stop Auto Refresh" OnClick="btnStopRefresh_Click"
                    CssClass="cssButtonControl" />
                <asp:Button ID="btnStartRefresh" runat="server" Text="Start Auto Refresh" OnClick="btnStartRefresh_Click"
                    CssClass="cssButtonControl" />
                <asp:Label ID="lblRefreshTime" runat="server" CssClass="csslblErrMsg" Visible="false"></asp:Label>
                <%--Monitor--%>
            </td>
            <td>
                <asp:Button ID="btnPopOut" runat="server" Text="FULL SCREEN" OnClick="btnPopOut_Click"
                    CssClass="cssButtonControl" OnClientClick="target='_blank';" />
            </td>
            <td>
                <asp:ImageButton ID="imgrefresh" runat="server" ImageUrl="~/Images/refresh.png" OnClick="imgrefresh_Click"
                    ImageAlign="Right" AlternateText="Refresh" />
            </td>
        </tr>
        <tr>
            <td width="48%" valign="top">
                <div id="divIncident" style="display: none;">
                    <Ajax:UpdatePanel ID="UPIncident" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <%--<asp:Panel ID="pnlIncident" Height="150px" ScrollBars="Auto" GroupingText="Incident"
                            runat="server" Font-Bold="true"  Style="background-color: White" >--%>
                            <div style="width: 96%; background-color: White; height: 36px; border-style: solid;
                                border-color: red; border-width: 1px; border-bottom-width: 0px">
                                <table border="0" width="100%" cellpadding="0" cellspacing="1" style="color: White;
                                    font-family: Tahoma; font-size: smaller; font-weight: bold; height: 36px">
                                    <tr>
                                        <td class="fixedcell" colspan="7">
                                            <%-- <img alt="Incident" src="../Images/incidentIcon.jpg" height="16px"/ >--%>
                                            <span style="font-size: 14px">Incident</span>
                                        </td>
                                    </tr>
                                    <%--  <tr bgcolor="red">
                                    <td width="5%">
                                        &nbsp
                                    </td>
                                    <td width="10%">
                                        Post
                                    </td>
                                    <td width="10%" title="Incident Type">
                                        Type
                                    </td>
                                    <td width="20%" title="ReportedBy">
                                        EMPNO
                                    </td>
                                    <td width="30%">
                                        Name
                                    </td>
                                    <td width="15%">
                                        Phone
                                    </td>
                                    <td width="10%">
                                        Time
                                    </td>
                                </tr>--%>
                                </table>
                            </div>
                            <div style="width: 96%; background-color: White; height: 120px; border-style: solid;
                                border-color: red; border-width: 1px; border-top-width: 0px; overflow: auto">
                                <asp:GridView Width="100%" ID="gvIncident" UseAccessibleHeader="true" CssClass="GridViewStyle"
                                    runat="server" CellPadding="1" CellSpacing="0" GridLines="None" ShowHeader="true"
                                    AutoGenerateColumns="False" AllowSorting="false" OnRowDataBound="gvIncident_RowDataBound">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <%--<AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />--%>
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="lblEmpty" runat="server" CssClass="csslblErrMsg" Text="No Data To Show"></asp:Label>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="3%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusIncident" runat="server" Text="<%#Bind('ReadStatus') %>"
                                                    Style="display: none;"></asp:Label>
                                                <asp:ImageButton runat="server" ID="IMGReadStatusIncident" OnClick="IMGReadStatusIncident_Click"
                                                   ToolTip="<%$Resources:Resource,ControlPanelFlagImageToolTip %>" ImageUrl='<%# (int)Eval("ReadStatus")==1 ? Page.ResolveUrl("~/Images/GreenFlag.jpg") : Page.ResolveUrl("~/Images/RedFlag.jpg") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,ClientName %>" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClientName" runat="server" CssClass="cssLabelNFC"  Text="<%#Bind('ClientName') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Assignment %>" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssignment" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Assignment') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Post" ItemStyle-Width="7%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPost" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Post') %>"></asp:Label>
                                                <asp:HiddenField ID="lblIncidentID" runat="server" Value="<%#Bind('IncidentID') %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Code added by  --%>
                                        <asp:TemplateField HeaderText="TagID" ItemStyle-Width="18%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTagID" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('LocationDesc') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--End of Code added by  --%>
                                        <%-- <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIncidentID"  style=" display:none;" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('IncidentID') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="IncidentType" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIncidentType" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('IncidentType') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ReportedBy" ItemStyle-Width="8%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReportedBy" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('EmployeeNumber') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('EmployeeName') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Phone" ItemStyle-Width="7%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPhone" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Phone') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Time" ItemStyle-Width="6%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('TIME') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Code added by  --%>
                                        <asp:TemplateField HeaderText="SMS" ItemStyle-Width="3%">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lblImgBtn" runat="server" CssClass="cssImgButton" Width="20px"
                                                    ImageUrl="~/Images/message.png" ToolTip="<%#Bind('SmsMessage') %>" />
                                                <%--<asp:Label ID="lblSmsMessage" runat="server" CssClass="cssLabel" Text="<%#Bind('SmsMessage') %>"></asp:Label>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Code added by  --%>
                                        <%-- <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIncidentID" runat="server" CssClass="cssLabel" Text="<%#Bind('IncidentID') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            
                            <%--</asp:Panel>--%>
                            <%--<Ajax:Timer ID="TimerIncident" runat="server" Interval="10000" OnTick="TimerIncident_Tick">
                            </Ajax:Timer>--%>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                </div>
            </td>
            <td valign="top" id="divPanicAlert" style="display: none;">
                <Ajax:UpdatePanel ID="UPPanicAlert" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--<asp:Panel ID="Panel1" Height="150px" ScrollBars="Auto" GroupingText="Panic Alerts"
                            runat="server" Font-Bold="true" Style="background-color: White">--%>
                        <div style="width: 98%; background-color: White; height: 36px; border-style: solid;
                            border-color: red; border-width: 1px; border-bottom-width: 0px">
                            <table border="0" width="100%" cellpadding="0" cellspacing="1" style="color: white;
                                font-family: Tahoma; font-size: smaller; font-weight: bold; height: 30px">
                                <tr>
                                    <td colspan="7" class="fixedcell">
                                        <%-- <img alt="Incident" src="../Images/panicIcon.jpg" height="16px"/ >--%>
                                        <span style="font-size: 14px">Panic</span>
                                    </td>
                                </tr>
                                <%--   <tr bgcolor="red">
                                    <td width="5%">
                                        &nbsp
                                    </td>
                                    <td width="10%">
                                        Post
                                    </td>
                                    <td width="15%">
                                        Alert ID
                                    </td>
                                    <td width="20%" title="Reported By">
                                        EMPNO
                                    </td>
                                    <td width="25%">
                                        Name
                                    </td>
                                    <td width="15%">
                                        Phone
                                    </td>
                                    <td width="15%">
                                        Time
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                        <div style="width: 98%; background-color: White; height: 120px; border-style: solid;
                            border-color: red; border-width: 1px; border-top-width: 0px; overflow: auto">
                            <asp:GridView Width="100%" ID="gvPanicAlert" UseAccessibleHeader="true" CssClass="GridViewStyle"
                                runat="server" ShowHeader="true" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                AllowSorting="false" OnRowDataBound="gvPanicAlert_RowDataBound">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <%--<AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />--%>
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="lblEmpty" runat="server" CssClass="csslblErrMsg" Text="No Data To Show"></asp:Label>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatusPanic" runat="server" Text="<%#Bind('ReadStatus') %>" Style="display: none;"></asp:Label>
                                            <asp:ImageButton runat="server" ID="IMGReadStatusPanic" OnClick="IMGReadStatusPanic_Click"
                                                ToolTip="<%$Resources:Resource,ControlPanelFlagImageToolTip %>" ImageUrl='<%# (int)Eval("ReadStatus")==1 ? Page.ResolveUrl("~/Images/GreenFlag.jpg") : Page.ResolveUrl("~/Images/RedFlag.jpg") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="<%$Resources:Resource,ClientName %>" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClientName" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('ClientName') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Assignment %>" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssignment" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Assignment') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    <asp:TemplateField HeaderText="Post" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPost" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Post') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alert ID" ItemStyle-Width="1%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPanicAlertId" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('PanicAlertId') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--      <asp:TemplateField HeaderText="Emp No" ItemStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeNumber" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('EmployeeNumber') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('EmployeeName') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Phone') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Time" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTime" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('TIME') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        
                        <%-- </asp:Panel>--%>
                        <%--<Ajax:Timer ID="TimerPanicAlert" runat="server" Interval="10000" OnTick="TimerPanicAlert_Tick">
                            </Ajax:Timer>--%>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
                <Ajax:UpdatePanel ID="UPNoShow" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--<asp:Panel ID="Panel2" Height="150px" ScrollBars="Auto" GroupingText="No Show" runat="server"
                            Font-Bold="true" Style="background-color: White">--%>
                        <div style="width: 98%; background-color: White; height: 36px; border-style: solid;
                            border-color: #B7CEEC; border-width: 1px; border-bottom-width: 0px">
                            <table border="0" width="100%" cellpadding="0" cellspacing="1" style="color: black;
                                font-family: Tahoma; font-size: smaller; font-weight: bold; height: 36px">
                                <tr>
                                    <td colspan="8" class="fixedcell">
                                        <%-- <img alt="Show No Show" src="../Images/ShowIcon.gif" height="16px"/ >--%>
                                        <span style="font-size: 14px; color: white">No Show</span>
                                    </td>
                                </tr>
                                <%-- <tr bgcolor="#B7CEEC">
                                    <td width="5%">
                                        &nbsp
                                    </td>
                                    <td width="10%">
                                        Post
                                    </td>
                                    <td width="15%" title="Employee Number">
                                        EmpNo
                                    </td>
                                    <td width="25%">
                                        Name
                                    </td>
                                    <td width="15%">
                                        Phone
                                    </td>
                                    <td width="10%" title="Scheduled Time">
                                        SchTime
                                    </td>
                                    <td width="10%">
                                        LateBy
                                    </td>
                                    <td width="10%">
                                        Status
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                        <div style="width: 98%; background-color: White; height: 120px; border-style: solid;
                            border-color: #B7CEEC; border-width: 1px; border-top-width: 0px; overflow: auto">
                            <asp:GridView Width="100%" ID="gvNoShow" UseAccessibleHeader="true" runat="server"
                                CellPadding="1" ShowHeader="true" GridLines="None" AutoGenerateColumns="False"
                                AllowSorting="false" OnRowDataBound="gvNoShow_RowDataBound">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <%--  <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />--%>
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="lblEmpty" runat="server" CssClass="csslblErrMsg" Text="No Data To Show"></asp:Label>
                                </EmptyDataTemplate>
                                <Columns>
                                    <%-- <asp:TemplateField HeaderText="" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReadStatusNoShow" runat="server" Text="<%#Bind('ReadStatus') %>"
                                                Style="display: none;"></asp:Label>
                                            <asp:ImageButton runat="server" ID="IMGReadStatusNoShow" OnClick="IMGReadStatusNoShow_Click"
                                                ToolTip="Green Not read/ Red Short" ImageUrl='<%# (int)Eval("ReadStatus")==1 ? Page.ResolveUrl("~/Images/GreenFlag.jpg") : Page.ResolveUrl("~/Images/RedFlag.jpg") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ClientName %>" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientName" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('ClientName') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Assignment %>" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssignment" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Assignment') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post" ItemStyle-Width="7%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPostCode" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('PostCode') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Emp No" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeNumber" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('EmployeeDetail') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--                <asp:TemplateField HeaderText="Name" ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeName" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('EmployeeName') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Phone" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhoneNumber" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('PhoneNumber') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SchTime" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblScheduledTimeFrom" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('ScheduledTimeFrom') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Late By" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTimeDiff" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('TimeDiff') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-Width="7%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Status') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        
                        <%--</asp:Panel>--%>
                        <%--<Ajax:Timer ID="TimerNoShow" runat="server" Interval="10000" OnTick="TimerNoShow_Tick">
                            </Ajax:Timer>--%>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr><tr>
            <td colspan="2">
                <Ajax:UpdatePanel ID="UPVacantPost" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--<asp:Panel ID="Panel3" Height="150px" ScrollBars="Auto" GroupingText="Vacant Post"
                            runat="server" Font-Bold="true" Style="background-color: White">--%>
                        <div style="width: 98%; background-color: White; height: 36px; border-style: solid;
                            border-color: #B7CEEC; border-width: 1px; border-bottom-width: 0px">
                            <table border="0" width="100%" cellpadding="0" cellspacing="1" style="color: black;
                                font-family: Tahoma; font-size: smaller; font-weight: bold; height: 30px">
                                <tr>
                                    <td colspan="9" class="fixedcell">
                                        <%--<img alt="Vacant Post" src="../Images/Blank.gif" height="16px"/ >--%>
                                        <span style="font-size: 14px; color: White">Vacant Post</span>
                                    </td>
                                </tr>
                                <%--  <tr bgcolor="#B7CEEC">
                                    <td width="5%">
                                        &nbsp
                                    </td>
                                    <td width="10%">
                                        Post
                                    </td>
                                    <td width="10%" title="Post vacant for">
                                        Vacant
                                    </td>
                                    <td width="10%" title="Off Duty Employee & Phone no">
                                        OffDuty
                                    </td>
                                    <td width="10%">
                                        OutTime
                                    </td>
                                    <td width="15%" title="To Join Employee & Phone no">
                                        ToJoin
                                    </td>
                                    <td width="10%">
                                        InTime
                                    </td>
                                    <td width="15%">
                                        Date
                                    </td>
                                    <td width="15%">
                                        Status
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                        <div style="width: 98%; background-color: White; height: 120px; border-style: solid;
                            border-color: #B7CEEC; border-width: 1px; border-top-width: 0px; overflow: auto">
                            <asp:GridView Width="100%" ID="gvVacantPost" UseAccessibleHeader="true" ShowHeader="true"
                                CssClass="GridViewStyle" runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                AllowSorting="false" OnRowDataBound="gvVacantPost_RowDataBound">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <%-- <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />--%>
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="lblEmpty" runat="server" CssClass="csslblErrMsg" Text="No Data To Show"></asp:Label>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ClientName %>" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientName" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('ClientName') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Assignment %>" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssignment" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Asmt') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPostCode" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('PostCode') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OffDuty" ItemStyle-Width="10%">
                                        <%--Emp No & Phone Off Duty--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDutyCompletedEmployeeNumber" runat="server" CssClass="cssLabelNFC"
                                                Text="<%#Bind('OnDutyEmployeeName') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PhoneNo" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStartPhoneNo" runat="server" CssClass="cssLabelNFC" Text='<%# Eval("DutyStartPhoneNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SchTime" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStartSchTime" runat="server" CssClass="cssLabelNFC" Text='<%# Eval("OnDutySchTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SwipeTime" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStartSwipeTime" runat="server" CssClass="cssLabelNFC" Text='<%# Eval("OnDutySwipeTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ToJoin" ItemStyle-Width="15%">
                                        <%--Emp No & Phone To Join--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndEmployeeNumber" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('ToJoinEmployeeName') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="PhoneNo" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndEmpPhoneNo" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('DutyEndPhoneNumber') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SchTime" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndSchTime" runat="server" CssClass="cssLabelNFC" Text='<%# Eval("ToJoinSchTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SwipeTime" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndSwipeTime" runat="server" CssClass="cssLabelNFC" Text='<%# Eval("ToJoinSwipeTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                            <%--</asp:Panel>--%>
                        </div>
                        
                        <%-- <Ajax:Timer ID="TimerVacantPost" runat="server" Interval="10000" OnTick="TimerVacantPost_Tick">
                            </Ajax:Timer>--%>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top" id="divPOPResponse" style="display: none;">
                <Ajax:UpdatePanel ID="UPPOPResponse" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%-- <asp:Panel ID="Panel5" Height="150px" ScrollBars="Auto" GroupingText="POP No Response/Lone Worker"
                            runat="server" Font-Bold="true" Style="background-color: White">--%>
                        <div style="width: 96%; background-color: White; height: 36px; border-style: solid;
                            border-color: #F7DA7E; border-width: 1px; border-bottom-width: 0px">
                            <table border="0" width="100%" cellpadding="0" cellspacing="1" style="color: black;
                                font-family: Tahoma; font-size: smaller; font-weight: bold; height: 30px">
                                <tr>
                                    <td colspan="5" class="fixedcell">
                                        <%-- <img alt="POP" src="../Images/popIcon.jpg" height="14px"/ >--%>
                                        <span style="font-size: 14px; color: White">POP/Lone Worker</span>
                                    </td>
                                </tr>
                                <%-- <tr bgcolor="#F7DA7E">
                                     <td width="5%">
                                       Commented Coloumn &nbsp
                                    </td>
                                    <td width="14%">
                                        Post
                                    </td>
                                  <td width="25%">
                                      Commented Coloumn  EmpNO
                                    </td>
                                    <td width="22%" title="Scheduled Swipe">
                                        Sch Swipe
                                    </td>
                                    <td width="28%">
                                        LastSwipe
                                    </td>
                                    <td width="22%">
                                        TimeDiff
                                    </td>
                                   <td width="15%">
                                       Commented Coloumn Time
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                        <div style="width: 96%; background-color: White; height: 120px; border-style: solid;
                            border-color: #F7DA7E; border-width: 1px; border-top-width: 0px; overflow: auto">
                            <asp:GridView Width="100%" ID="gvPOPResponse" UseAccessibleHeader="true" ShowHeader="true"
                                runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" AllowSorting="false"
                                OnRowDataBound="gvPOPResponse_RowDataBound">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <%--<AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />--%>
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="lblEmpty" runat="server" CssClass="csslblErrMsg" Text="No Data To Show"></asp:Label>
                                </EmptyDataTemplate>
                                <Columns>
                                <asp:TemplateField HeaderText="<%$Resources:Resource,ClientName %>" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientName" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('ClientName') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Assignment %>" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssignment" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Assignment') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="Post" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Post') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--Code Added by  --%>
                                    <asp:TemplateField HeaderText="TagID" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTagID" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('TagID') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--End of Code Added by  --%>
                                    <%-- <asp:TemplateField HeaderText="Emp no" ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeNumber" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('EmployeeNumber') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--                                    <asp:TemplateField HeaderText="Phone Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPhoneNumber" runat="server" CssClass="cssLabel" Text="<%#Bind('PhoneNumber') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Sch Swipe" ItemStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblScheduledSwipe" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('ScheduledSwipe') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LastSwipe" ItemStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastSwipe" runat="server" CssClass="cssLabelNFC" Text='<%#String.Format("{0:dd-MMM-yyyy hh:mm}",Eval("LastSwipe")) %>'></asp:Label><%--Bind('LastSwipe')--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TimeDiff" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTimeSinceLastSwipe" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('TIMESINCELASTSWIPE') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--   <asp:TemplateField HeaderText="Type" ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Flag') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                            <%--</asp:Panel>--%>
                        </div>
                        
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
            <td valign="top" id="divGuardTour" style="display: none;">
                <Ajax:UpdatePanel ID="UPGuardTour" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%-- <asp:Panel ID="Panel4" Height="150px" ScrollBars="Auto" GroupingText="Guard Tour"
                            runat="server" Font-Bold="true" Style="background-color: White">--%>
                        <div style="width: 98%; background-color: White; height: 36px; border-style: solid;
                            border-color: #F7DA7E; border-width: 1px; border-bottom-width: 0px">
                            <table border="0" width="100%" cellpadding="0" cellspacing="" style="color: black;
                                font-family: Tahoma; font-size: smaller; font-weight: bold; height: 30px">
                                <tr>
                                    <td colspan="7" class="fixedcell">
                                        <%--<img alt="Guard Tour" src="../Images/GuardTourIcon.gif" height="14px"/ >--%>
                                        <span style="font-size: 14px; color: White">Guard Tour</span>
                                    </td>
                                </tr>
                                <%--  <tr bgcolor="#F7DA7E">
                                    <td width="5%">
                                        &nbsp
                                    </td>
                                    <td width="13%">
                                        Post
                                    </td>
                                    <td width="20%">
                                        Missing Tag
                                    </td>
                                    <td width="22%" title="Scheduled Swipe">
                                        Sch Swipe
                                    </td>
                                    <td width="14%">
                                        SwipeTime
                                    </td>
                                    <td width="15%">
                                        EmpNo
                                    </td>
                                    <td width="15%">
                                        Phone
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                        <div style="width: 96%; background-color: White; height: 120px; border-style: solid;
                            border-color: #F7DA7E; border-width: 1px; border-top-width: 0px; overflow: auto">
                            <asp:GridView Width="100%" ID="gvGuardTour" UseAccessibleHeader="true" ShowHeader="true"
                                CssClass="GridViewStyle" runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                AllowSorting="false" OnRowDataBound="gvGuardTour_RowDataBound">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <%-- <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />--%>
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="lblEmpty" runat="server" CssClass="csslblErrMsg" Text="No Data To Show"></asp:Label>
                                </EmptyDataTemplate>
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReadStatusGuardTour" runat="server" Text="<%#Bind('ReadStatus') %>"
                                                Style="display: none;"></asp:Label>
                                            <asp:ImageButton runat="server" ID="IMGReadStatusGuardTour" OnClick="IMGReadStatusGuardTour_Click"
                                                ToolTip="Green Not read/ Red Short" ImageUrl='<%# (int)Eval("ReadStatus")==1 ? Page.ResolveUrl("~/Images/GreenFlag.jpg") : Page.ResolveUrl("~/Images/RedFlag.jpg") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ClientName %>" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientName" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('ClientName') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Assignment %>" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssignment" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('Assignment') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPostCode" runat="server" CssClass="cssLabelNFCRed" Text="<%#Bind('POSTID') %>"
                                                ToolTip='<%# Bind("GuardTourDesc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Missing Tag" ItemStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMissingTagID" runat="server" CssClass="cssLabelNFCRed" Text="<%#Bind('TagIDDesc') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Swipe Time" ItemStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSwipeTime" runat="server" CssClass="cssLabelNFCRed" Text="<%#Bind('ScheduleTime') %>"></asp:Label>
                                            <asp:HiddenField ID="HFSwipeTime" runat="server" Value="<%#Bind('ScheduleTime') %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Actual Swipe Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActualSwipeTime" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('SwipeTime') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="Date" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblDutyDate" runat="server" CssClass="cssLabelNFC" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="Emp No" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeNumber" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('EmployeeNumber') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="Phone" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" CssClass="cssLabelNFC" Text="<%#Bind('PhoneNumber') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                        
                        <%--</asp:Panel>--%>
                        <%-- <Ajax:Timer ID="TimerGvGuardTour" runat="server" Interval="1000" OnTick="TimerGvGuardTour_Tick">
                        </Ajax:Timer>--%>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <Ajax:Timer ID="TimerGvGuardTour" runat="server" Interval="60000" OnTick="TimerGvGuardTour_Tick">
                        </Ajax:Timer>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
