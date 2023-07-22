<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="AttendanceVarificationProcesses.aspx.cs"
    Inherits="Transactions_AttendanceVarificationProcesses" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "">
<html>
<head>
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
</head>
<body>
 <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <telerik:RadGrid ID="gvPaysumReadyness" runat="server" Width="98%" Height="300" OnNeedDataSource="gvPaysumReadyness_NeedDataSource"
                    AllowSorting="True" AllowMultiRowSelection="True" AllowPaging="false"  ExportSettings-IgnorePaging="true" ShowGroupPanel="True"
                    GridLines="None"  AutoGenerateColumns="False" Skin="Office2007" ExportSettings-ExportOnlyData="true">
                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                    <MasterTableView AllowMultiColumnSorting="True" CommandItemDisplay="TopAndBottom">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false" ></CommandItemSettings>
                        <Columns>
                            <telerik:GridBoundColumn SortExpression="ProcessName" HeaderText="ProcessName" HeaderButtonType="TextButton"
                                DataField="ProcessName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="Comment" HeaderText="Comment" HeaderButtonType="TextButton"
                                DataField="Comment">
                                <HeaderStyle Width="125px"></HeaderStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="EmployeeNumber" HeaderText="EmployeeNumber"
                                HeaderButtonType="TextButton" DataField="EmployeeNumber">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="AsmtCode" HeaderText="AsmtCode" HeaderButtonType="TextButton"
                                DataField="AsmtCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="LocationCode" HeaderText="LocationCode"
                                HeaderButtonType="TextButton" DataField="LocationCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="TotalHours" HeaderText="TotalHours" HeaderButtonType="TextButton"
                                DataField="TotalHours">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <ExportSettings>
                        <Excel Format="ExcelML"></Excel>
                    </ExportSettings>
                    <ClientSettings AllowDragToGroup="True" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True"></Selecting>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                        <ClientMessages DragToGroupOrReorder="Drag to group" />
                        <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True"
                            ResizeGridOnColumnResize="False"></Resizing>
                    </ClientSettings>
                    <GroupingSettings ShowUnGroupButton="true" />
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
