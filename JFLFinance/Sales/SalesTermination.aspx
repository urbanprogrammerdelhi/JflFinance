<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesTermination.aspx.cs"
    Inherits="Sales.Sales_SalesTermination" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager EnablePartialRendering="true" EnableScriptGlobalization="true"
        ScriptMode="Release" EnableScriptLocalization="true" ID="script" runat="server" AsyncPostBackTimeOut="36000">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadSplitter2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <ClientEvents OnRequestStart="RequestStart" OnResponseEnd="ResponseEnd" />
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <asp:Panel ID="Panel1" runat="server">
        <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblClientCode" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 260px;">
                            <telerik:RadComboBox ID="ddlTerminationType" AccessKey="T" Width="260px" runat="server"
                                AutoPostBack="true" ForeColor="Red" Font-Bold="true" OnSelectedIndexChanged="ddlTerminationType_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, SaleOrder %>" Value="SoNo" />
                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Client %>" Value="Client" />
                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Assignment %>" Value="Assignment" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label2" runat="server" Text="<%$ Resources:Resource, SortedBy %>"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ddlSortedBy" AccessKey="S" Width="260px" runat="server"
                                AutoPostBack="true" ForeColor="Red" Font-Bold="true" OnSelectedIndexChanged="ddlSortedBy_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <telerik:RadSplitter ID="RadSplitter2" LiveResize="true" runat="server" Orientation="Vertical"
                                Width="100%">
                                <telerik:RadPane ID="Radpane1" ShowContentDuringLoad="false" Scrolling="Both" Width="20%"
                                    MinWidth="200" MaxWidth="350" runat="server">
                                    <div style="width: 249px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <telerik:RadTreeView ID="tvMenu" ExpandAnimation-Duration="1000" CollapseAnimation-Duration="1000"
                                                        MultipleSelect="false" Width="100%" runat="server" EnableDragAndDrop="true" EnableDragAndDropBetweenNodes="false"
                                                        Skin="WebBlue" OnNodeClick="tvMenu_NodeClick" OnNodeDrop="tvMenu_NodeDrop">
                                                    </telerik:RadTreeView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </telerik:RadPane>
                                <telerik:RadSplitBar ID="Radsplitbar4" runat="server" CollapseMode="Forward" />
                                <telerik:RadPane ID="Radpane51" ShowContentDuringLoad="true" Width="70%" Scrolling="Both"
                                    runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadComboBox ID="ddlSelectedItems" AccessKey="S" Width="260px" runat="server"
                                                    CheckedItemsTexts="FitInInput" AutoPostBack="true" ForeColor="Red" Font-Bold="true"
                                                    CheckBoxes="true" OnItemChecked="ddlSelectedItems_ItemChecked">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, Status %>"></asp:Label>
                                            </td>
                                            <td align="right" colspan="2">
                                                <asp:Label ID="lblStatus" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView Width="1200px" ID="gvSaleTermination" CssClass="GridViewStyle" runat="server"
                                        EmptyDataText="<%$ Resources:Resource, NoDataToShow %>" CellPadding="1" PageSize="8"
                                        AutoGenerateColumns="False" OnRowDataBound="gvSaleTermination_RowDataBound">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText='<%$ Resources:Resource, Client %>'>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" CssClass="cssLabel" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                    <asp:HiddenField ID="HFClientCode" runat="server" Value='<%#Bind("ClientCode") %>' />
                                                    <asp:HiddenField ID="HFRowNumber" runat="server" Value='<%#Bind("RowNumber") %>' />
                                                    <asp:HiddenField ID="HFContractNumber" runat="server" Value='<%#Bind("ContractNumber") %>' />
                                                    <asp:HiddenField ID="HFSoAmendNo" runat="server" Value='<%#Bind("SoAmendNo") %>' />
                                                    <asp:HiddenField ID="HFAttendanceDeleteStatus" runat="server" Value='<%#Bind("AttendanceDeleteStatus") %>' />
                                                    <asp:HiddenField ID="HFTerminationLevel" runat="server" Value='<%#Bind("TerminationLevel") %>' />
                                                    <asp:HiddenField ID="HFTerminationStatus" runat="server" Value='<%#Bind("TerminationStatus") %>' />
                                                    <asp:HiddenField ID="HFMinActDate" runat="server" Value='<%#Bind("MinActDate") %>' />
                                                    <asp:HiddenField ID="HFMaxActDate" runat="server" Value='<%#Bind("MaxAcDate") %>' />
                                                    <asp:HiddenField ID="HFMinSchDate" runat="server" Value='<%#Bind("MinSchDate") %>' />
                                                    <asp:HiddenField ID="HFMaxSchDate" runat="server" Value='<%#Bind("MaxSchDate") %>' />
                                                    <asp:HiddenField ID="HFMinRotaAuthorizedDate" runat="server" Value='<%#Bind("MinAuthorizedRotaDate") %>' />
                                                    <asp:HiddenField ID="HFMaxRotaAuthorizedDate" runat="server" Value='<%#Bind("MaxAuthorizedRotaDate") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='<%$ Resources:Resource, Assignment %>'>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAsmtID" CssClass="cssLabel" runat="server" Text='<%# Bind("AsmtID") %>'></asp:Label>
                                                    (<asp:Label ID="lblAsmtName" CssClass="cssLabel" runat="server" Text='<%# Bind("AsmtAddress") %>'></asp:Label>)
                                                    <asp:HiddenField ID="HFAsmtID" runat="server" Value='<%#Bind("AsmtID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='<%$ Resources:Resource, Post %>'>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPostCode" CssClass="cssLabel" runat="server" Text='<%# Bind("PostCode") %>'></asp:Label>
                                                    (<asp:Label ID="lblPostDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("PostDesc") %>'></asp:Label>)
                                                    <asp:HiddenField ID="HFPostAutoID" runat="server" Value='<%#Bind("PostAutoID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='<%$ Resources:Resource, SONO %>'>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSONO" CssClass="cssLabel" runat="server" Text='<%# Bind("SoNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='<%$ Resources:Resource, SoStatus %>'>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSoStatus" CssClass="cssLabel" runat="server" Text='<%# Bind("SoStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='<%$ Resources:Resource, SOLineNo %>'>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSOLineNo" CssClass="cssLabel" runat="server" Text='<%# Bind("SoLineNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='<%$ Resources:Resource, SoRank %>'>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSoRank" CssClass="cssLabel" runat="server" Text='<%# Bind("SoRank") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,Active %>">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lbUnCheckALL" runat="server" Text="<%$Resources:Resource,UnCheckALL %>"
                                                        OnClientClick="javascript:OpenRadWindowForBulkEntry(this.id);"></asp:LinkButton>
                                                    <br />
                                                    <asp:Label ID="lblhdrActive" runat="server" Text="<%$Resources:Resource,Active %>"
                                                        CssClass="cssLabelHeader"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Bind("Active") %>' onclick="javascript:OpenRadWindowForSingleEntry(this.id);" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,StartDate %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSOLineStartDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("SOLineStartDate"))%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,EndDate %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSOLineEndDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("SOLineEndDate"))%>'></asp:Label>
                                                    <asp:HiddenField ID="HFSoLineWefDate" runat="server" Value='<%# String.Format("{0:dd-MMM-yyyy}", Eval("SOLineWEFDate"))%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,WEFDate %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWEFDate" CssClass="cssLabel" runat="server" Text='<%# Eval("WithEffectiveDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,TerminationReason %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTerminationReason" CssClass="cssLabel" runat="server" Text='<%# Bind("TerminationReason") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,Action %>">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbRotaStatus" CssClass="csslnkButton" runat="server" OnClick="lbRotaStatus_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HfASSoNo" runat="server" />
                                    <asp:HiddenField ID="HfASSoLineNo" runat="server" />
                                    <asp:HiddenField ID="HfASPostAutoId" runat="server" />
                                    <asp:HiddenField ID="HfASWEFDate" runat="server" />
                                    <asp:HiddenField ID="HFRotaDeleteStatus" runat="server" />
                                    <asp:HiddenField ID="HFCurrentRowIndex" runat="server" />
                                </telerik:RadPane>
                            </telerik:RadSplitter>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="btnSave"  OnClick="btnSave_Click" runat="server" Text="<%$Resources:Resource,Save%>"
                                ToolTip="<%$Resources:Resource,Save%>">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnAuthorize"  OnClick="btnAuthorize_Click" runat="server"
                                Text="<%$Resources:Resource,Authorize%>" ToolTip="<%$Resources:Resource,Authorize%>">
                            </telerik:RadButton>
                            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="btnRollBackTermination"  OnClick="btnRollBackTermination_Click"
                                runat="server" Text="<%$Resources:Resource,RollBackTermination%>" ToolTip="<%$Resources:Resource,RollBackTermination %>">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel2" BackColor="white" ScrollBars="Auto" CssClass="ScrollBar" runat="server"
                    Height="550px" Width="920px" Style="display: none;">
                    <asp:Button ID="btnShowPopup" CssClass="cssButton" runat="server" Style="display: none" />
                    <AjaxToolKit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
                        PopupControlID="Panel2" BackgroundCssClass="modalBackground" />
                    <Ajax:UpdatePanel runat="server" ID="UpdatePanelDeleteRota" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="PanelDeleteRota" Visible="true" Width="920px" BorderWidth="1px" runat="server">
                                <div style="width: 900px;">
                                    <div class="squarebox">
                                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                            <div style="float: left; width: 700px">
                                                <tt style="text-align: center;">
                                                    <asp:Label ID="LblRotaDetail" CssClass="squareboxgradientcaption" runat="server"
                                                        Text="<%$Resources:Resource,RotaDetail %>"></asp:Label></tt></div>
                                        </div>
                                        <div class="squareboxcontent">
                                            <asp:GridView Width="900px" ID="gvDeleteRota" CssClass="GridViewStyle" runat="server"
                                                CellPadding="1" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
                                                OnDataBound="gvDeleteRota_DataBound" OnPageIndexChanging="gvDeleteRota_PageIndexChanging"
                                                OnRowCommand="gvDeleteRota_RowCommand">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,AsmtId %>" SortExpression="AsmtID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAsmtId" runat="server" Text='<%# Bind("AsmtId") %>'></asp:Label>
                                                            <asp:HiddenField ID="HfSoNo" runat="server" Value='<%# Bind("SoNo") %>' />
                                                            <asp:HiddenField ID="HfSoLineNo" runat="server" Value='<%# Bind("SoLineNo") %>' />
                                                            <asp:HiddenField ID="HfPostAutoId" runat="server" Value='<%# Bind("PostAutoId") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,SoRank %>" SortExpression="SoRank">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSoRank" runat="server" Text='<%# Bind("SoRank") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,EmployeeNumber %>" SortExpression="EmployeeNumber">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeNumber" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Name %>" SortExpression="Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,DutyDate %>" SortExpression="DutyDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("DutyDate"))%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ShiftCode %>" SortExpression="ShiftCode">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("ShiftCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,TimeFrom %>" SortExpression="TimeFrom">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label9" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,TimeTo %>" SortExpression="TimeTo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label10" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                                                    CommandArgument="First" CommandName="Page" />
                                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                                                    CommandArgument="Prev" CommandName="Page" />
                                                                <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                                                <asp:DropDownList ID="ddlPagesDeleteRota" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlPagesDeleteRota_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                                                <asp:Label ID="lblPageCountDeleteRota" ForeColor="Black" runat="server"></asp:Label>
                                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                                                    CommandArgument="Next" CommandName="Page" />
                                                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                                                    CommandArgument="Last" CommandName="Page" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PanelScheduleRoster" Visible="true" Width="920px" BorderWidth="1px"
                                runat="server" ScrollBars="Auto">
                                <div style="width: 900px;">
                                    <div class="squarebox">
                                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                            <div style="float: left; width: 700px">
                                                <tt style="text-align: center;">
                                                    <asp:Label ID="Label11" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,ScheduleRosterDetails %>"></asp:Label></tt></div>
                                        </div>
                                        <asp:GridView Width="900px" ID="gvScheduleRoster" CssClass="GridViewStyle" runat="server"
                                            CellPadding="1" AllowPaging="true" PageSize="10" AutoGenerateColumns="False"
                                            OnPageIndexChanging="gvScheduleRoster_PageIndexChanging" OnRowCommand="gvScheduleRoster_RowCommand"
                                            OnDataBound="gvScheduleRoster_DataBound">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,AsmtId %>" SortExpression="AsmtID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAsmtId" runat="server" Text='<%# Bind("AsmtId") %>'></asp:Label>
                                                        <asp:HiddenField ID="HfSoNo" runat="server" Value='<%# Bind("SoNo") %>' />
                                                        <asp:HiddenField ID="HfSoLineNo" runat="server" Value='<%# Bind("SoLineNo") %>' />
                                                        <asp:HiddenField ID="HfPostAutoId" runat="server" Value='<%# Bind("PostAutoId") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,SoRank %>" SortExpression="SoRank">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSoRank" runat="server" Text='<%# Bind("SoRank") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EmployeeNumber %>" SortExpression="EmployeeNumber">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeNumber" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Name %>" SortExpression="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,DutyDate %>" SortExpression="DutyDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("DutyDate"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ShiftCode %>" SortExpression="ShiftCode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ShiftCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,TimeFrom %>" SortExpression="TimeFrom">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label9" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,TimeTo %>" SortExpression="TimeTo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label10" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
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
                                                        </td>
                                                    </tr>
                                                </table>
                                            </PagerTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                    <table border="0" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnDelete" runat="server" Text="<%$Resources:Resource,Delete %>" CssClass="cssButton"
                                     OnClick="btnDelete_onClick" />
                                <asp:Button ID="Button1" runat="server" Text="<%$Resources:Resource,Cancel %>" CssClass="cssButton"
                                    OnClick="btnCancel_onClick" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </Ajax:UpdatePanel>
        <table>
            <tr>
                <td>
                    <telerik:RadWindow ID="RadWindow" ClientIDMode="Predictable" runat="server" DestroyOnClose="true" OnClientClose="CloseRadWindow"
                        ShowContentDuringLoad="false" EnableShadow="true" KeepInScreenBounds="false"
                        Width="500px" Height="300px" Title="" Modal="true" Skin="WebBlue" Behaviors="Close,Move, Resize,Maximize">
                        <ContentTemplate>
                            <Ajax:UpdatePanel ID="UP3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblHdrWEFDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,WEFDate %>"></asp:Label>
                                                <asp:HiddenField ID="HFClickStatus" runat="server" />
                                                <asp:HiddenField ID="HFRowIndex" runat="server" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtWithEffectiveDate" Width="80px" CssClass="csstxtbox" runat="server" CausesValidation="True"
                                                    Enabled="false"></asp:TextBox>
                                                <asp:ImageButton ID="IMGWithEffectiveDate" Style="vertical-align: middle;" CausesValidation="true"
                                                    runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" PopupPosition="TopRight" Format="dd-MMM-yyyy"
                                                    runat="server" TargetControlID="txtWithEffectiveDate" PopupButtonID="IMGWithEffectiveDate" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWithEffectiveDate" ErrorMessage="*" ValidationGroup="UpdateTerminationDetails" ></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblHdrTerminationReason" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,TerminationReason %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                               
                                                     <asp:TextBox ID="txtTerminationReason" Height="120px" Width="250px" TextMode="MultiLine" onChange="javascript:Count(this,95);" CausesValidation="True"
                                                    CssClass="csstxtbox" runat="server" AutoPostBack="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTerminationReason" ErrorMessage="*" ValidationGroup="UpdateTerminationDetails" ></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="btnBulkSave"  OnClick="btnBulkSave_Click" OnClientClicked="CloseRadPopUp" CauseValidation="true" ValidationGroup="UpdateTerminationDetails"
                                              runat="server" Text="<%$Resources:Resource,Save %>">
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnCancel"  OnClientClicked="ClosePopUp" OnClick="btnCancel_Click"
                                                     runat="server" Text="<%$Resources:Resource,Cancel%>">
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnGridUpdate" Style="display: none;" CssClass="cssButton" runat="server" OnClick="btnGridUpdate_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </Ajax:UpdatePanel>
                        </ContentTemplate>
                    </telerik:RadWindow>
                    <asp:HiddenField ID="SaveButtonText" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
    <script language ="javascript" src="../javaScript/jquery-1.8.1.min.js" type ="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function ControlInitializer() {
            this.txtTerminationReason = document.getElementById('<%=txtTerminationReason.ClientID%>');
            this.txtWithEffectiveDate = document.getElementById('<%=txtWithEffectiveDate.ClientID%>');
            this.currentLoadingPanel = ("<%= RadAjaxLoadingPanel1.ClientID %>");
            this.currentUpdatedControl = ("<%= Panel1.ClientID %>");
            this.btnBulkSave = $find("<%= btnBulkSave.ClientID %>");
            this.clicks = document.getElementById('<%=HFClickStatus.ClientID%>').value;
            this.gv = document.getElementById('<%=btnGridUpdate.ClientID %>');
            this.RI = document.getElementById('<%=HFRowIndex.ClientID%>');
            this.RadWindow = $find('<%= RadWindow.ClientID %>');
            this.SaveButtonText = document.getElementById('<%=SaveButtonText.ClientID%>');
        }
    </script>
    <script type="text/javascript" language="javascript" src="../PageJS/SalesTermination.js"></script>
</body>
</html>
