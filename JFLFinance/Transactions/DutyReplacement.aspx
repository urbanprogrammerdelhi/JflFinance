<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyReplacement.aspx.cs"
    Inherits="Transactions_DutyReplacement" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ScriptMode="Release">
    </asp:ScriptManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <table width="100%">
            <tr>
                <td>
                    <Ajax:UpdatePanel ID="UP1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="panelSelectedEmployee" runat="server" GroupingText="Selected Employee Details">
                                <table width="50%">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,EmployeeName %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblEmployeeName" Width="150px" runat="server" CssClass="cssLabelBox"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDesignation" Width="150px" runat="server" CssClass="cssLabelBox"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="panel1" runat="server" GroupingText="Replaced Employee Details">
                                <table width="50%">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label18" runat="server" Text='<%$ Resources:Resource,EmployeeName %>'></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlReplacedEmployee" AllowCustomText="true" AccessKey="E" AutoPostBack="true"
                                                CloseDropDownOnBlur="true" Filter="Contains" EmptyMessage="<%$ Resources:Resource, Select %>"
                                                IsCaseSensitive="false" MarkFirstMatch="true" Width="380px" runat="server" OnSelectedIndexChanged="ddlReplacedEmployee_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="panel2" runat="server" GroupingText="Selected Employee Duty Details">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="HFFromDate" runat="server" />
                                            <asp:HiddenField ID="HFToDate" runat="server" />
                                            <asp:HiddenField ID="HFArea" runat="server" />
                                            <asp:HiddenField ID="HFWeekNo" runat="server" />
                                            <asp:HiddenField ID="HFSelectedSchRosterAutoID" runat="server" />
                                            <asp:HiddenField ID="HFClientCode" runat="server" />
                                            <asp:HiddenField ID="HFAsmtID" runat="server" />
                                            <asp:HiddenField ID="HFPostAutoID" runat="server" />
                                            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                            <asp:GridView ID="gvDutyDetails" CssClass="GridViewStyle" runat="server" ShowFooter="True"
                                                AllowPaging="false" AutoGenerateColumns="False" AllowSorting="false" OnRowCommand="gvDutyDetails_RowCommand"
                                                OnRowDataBound="gvDutyDetails_RowDataBound">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText='<%$ Resources:Resource,DutyDate %>'>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDutyDate" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                                            <asp:HiddenField ID="HFAutoID" runat="server" Value='<%# Eval("AutoID") %>' />
                                                            <asp:HiddenField ID="HFOldEmployeeNumber" runat="server" Value='<%# Eval("EmployeeNumber") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText='<%$ Resources:Resource,ShiftDetails %>'>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblShiftDetails" runat="server" CssClass="cssLabel" Text='<%# Eval("ShiftDetails") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbCheck" CssClass="cssCheckBox" Checked="false" AutoPostBack="true"
                                                                OnCheckedChanged="cbCheck_CheckedChanged" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText='<%$ Resources:Resource,EditColName %>'>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                runat="server" CssClass="csslnkButton" OnClick="IBDelete_Click" CausesValidation="False" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label3" runat="server" Text='<%$ Resources:Resource,Reason %>'></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlReason" AllowCustomText="true" AccessKey="R" CloseDropDownOnBlur="true"
                                                Filter="Contains" IsCaseSensitive="false" MarkFirstMatch="true" Width="380px"
                                                runat="server">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Resource, Save %>" CssClass="cssButton"
                                                OnClick="btnSave_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
