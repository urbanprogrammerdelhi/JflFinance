<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterSearch.master"
    AutoEventWireup="true" CodeFile="AssetWorkOrderLineDept.aspx.cs" Inherits="Sales_AssetWorkOrderLineDept" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="DropCheck" Namespace="xMilk" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 1230px; height: 550px; overflow: scroll;">
        <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pWorkOrder" Font-Bold="True" GroupingText="<%$ Resources:Resource, AssetWorkOrder %>" runat="server" BorderWidth="0px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height: 20px; border-spacing: 5px 1px; border-collapse: separate;">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblfixAssetWoNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AssetWONo %>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAssetWoNo" CssClass="cssLabelHeader" runat="server">
                                </asp:Label><asp:HiddenField ID="hfLocationAutoId" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfixAssetWOAmendNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AssetWOAmendNo %>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAssetWOAmendNo" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfixAssetWOLineNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AssetWoLineNo %>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAssetWOLineNo" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfixWoStatus" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, WOStatus %>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblWoStatus" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                <asp:HiddenField ID="hfWoStatus" runat="server" />
                                <asp:HiddenField ID="hfIsMAXAssetWOAmendNo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHdrAssetCode" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AssetCode %>" />
                            </td>
                            <td align="left">
                                <asp:HiddenField runat="server" ID="hfAssetAutoId" />
                                <asp:Label ID="lblAssetCode" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblHdrAssetName" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AssetName %>" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAssetName" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblHdrModelNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ModelNo %>" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblModelNo" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblHdrSerialNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SerialNo %>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSerialNo" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHdrAssetServiceTypeName" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AssetServiceTypeName %>" />
                            </td>
                            <td align="left">
                                <asp:HiddenField runat="server" ID="hfAssetServiceTypeAutoId" />
                                <asp:Label ID="lblAssetServiceTypeName" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pClient" Font-Bold="True" GroupingText="<%$ Resources:Resource,Client %>" runat="server" BorderWidth="0px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height: 20px; border-spacing: 5px 1px; border-collapse: separate;">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblClientCode" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ClientCode %>" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblClientCodeValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblClientName" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ClientName %>" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblClientNameValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAsmtID" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AsmtId %>" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAsmtIDValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblAsmtName" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AsmtName %>" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAsmtNameValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblPostID" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Post %>" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPostIDValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pServicePattern" Font-Bold="True" GroupingText="<%$ Resources:Resource, ServicePattern %>" runat="server" BorderWidth="0px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height: 20px; border-spacing: 5px 1px; border-collapse: separate;">
                        <tr>
                            <td align="right" style="width: 200px;">
                                <asp:Label ID="lblHdrSavedFrequency" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Frequency %>" />
                            </td>
                            <td align="left" style="width: 300px;">
                                <asp:Label ID="lblSavedFrequency" CssClass="cssLabelHeader" runat="server" Text="" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                    <div runat="server" id="divSavedFrequencyMonthly">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height: 20px; border-spacing: 5px 1px; border-collapse: separate;">
                            <tr>
                                <td align="right" style="width: 200px;">
                                    <asp:Label ID="lblHdrSavedMonthNumber" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, MonthNumber %>" />
                                </td>
                                <td align="left" style="width: 300px;">
                                    <asp:Label ID="lblSavedMonthNumber" CssClass="cssLabelHeader" runat="server" Text="" />
                                </td>
                                <td align="right" style="width: 200px;">
                                    <asp:Label ID="lblHdrSavedMonthDate" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, MonthDate %>" />
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblSavedMonthDate" CssClass="cssLabelHeader" runat="server" Text="" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div runat="server" id="divSavedFrequencyWeekly">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height: 20px; border-spacing: 5px 1px; border-collapse: separate;">
                            <tr>
                                <td align="right"style="width: 200px;">
                                    <asp:Label ID="lblHdrSavedWeekNumber" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, WeekNumber %>" />
                                </td>
                                <td align="left"style="width: 300px;">
                                    <asp:Label ID="lblSavedWeekNumber" CssClass="cssLabelHeader" runat="server" Text="" />
                                </td>
                                <td align="right"style="width: 200px;">
                                    <asp:Label ID="lblHdrSavedWeekDay" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, WeekDay %>" />
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblSavedWeekDay" CssClass="cssLabelHeader" runat="server" Text="" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div runat="server" id="divSavedFrequencyOneTime">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height: 20px; border-spacing: 5px 1px; border-collapse: separate;">
                            <tr>
                                <td align="right" style="width: 200px;">
                                    <asp:Label ID="lblHdrSavedDate" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Date %>" />
                                </td>
                                <td align="left" style="width: 300px;">
                                    <asp:Label ID="lblSavedDate" CssClass="cssLabelHeader" runat="server" Text="" />
                                </td>
                                <td colspan="2"></td>
                            </tr>
                        </table>
                    </div>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height: 20px; border-spacing: 5px 1px; border-collapse: separate;">
                        <tr>
                            <td align="right" style="width: 200px;">
                                <asp:Label ID="lblHdrSavedFromTime" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, FromTime %>" />
                            </td>
                            <td align="left" style="width: 300px;">
                                <asp:Label ID="lblSavedFromTime" CssClass="cssLabelHeader" runat="server" Text="" />
                            </td>
                            <td align="right" style="width: 200px;">
                                <asp:Label ID="lblHdrSavedToTime" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ToTime %>" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSavedToTime" CssClass="cssLabelHeader" runat="server" Text="" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </br>
                <div class="squareboxgradientcaption" style="height: 20px;">
                    <asp:Label ID="Label23" runat="server" Text="<%$Resources:Resource,ServicePattern %>"></asp:Label>
                </div>
                <div>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height: 20px; border-spacing: 5px 1px; border-collapse: separate;">
                        <tr>
                            <td align="right" style="width: 25%">
                                <asp:Label ID="lblHdrFrequency" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Frequency %>" />
                            </td>
                            <td align="left" style="width: 25%">
                                <asp:DropDownList runat="server" ID="ddlFrequency" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlFrequency_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td style="width: 25%"></td>
                            <td style="width: 25%"></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div runat="server" id="divFrequencyWeekly">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; border-spacing: 0px 0px;">
                                        <tr>
                                            <td align="right" style="width: 25%">
                                                <asp:Label ID="lblHdrWeekNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, WeekNumber %>" />
                                            </td>
                                            <td align="left" style="width: 25%">
                                                <cc1:DropCheck ID="ddlWeekNo" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="200px">
                                                </cc1:DropCheck>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:Label ID="lblHdrWeekDay" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, WeekDay %>" />
                                            </td>
                                            <td align="left" style="width: 25%">
                                                <cc1:DropCheck ID="ddlWeekDay" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="200px">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div runat="server" id="divFrequencyOneTime">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; border-spacing: 0px 0px;">
                                        <tr>
                                            <td align="right" style="width: 25%">
                                                <asp:Label ID="Label1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Date %>" />
                                            </td>
                                            <td align="left" style="width: 25%">
                                                <asp:TextBox ID="txtServiceDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: top;" ID="hlServiceDate" runat="server" Height="19px"
                                                    Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CEServiceDate" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtServiceDate"
                                                    PopupButtonID="hlServiceDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                            </td>
                                            <td align="right" style="width: 25%"></td>
                                            <td align="left" style="width: 25%"></td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div runat="server" id="divFrequencyMonthly">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; border-spacing: 0px 0px;">
                                        <tr>
                                            <td align="right" style="width: 25%">
                                                <asp:Label ID="lblHdrMonthNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MonthNumber %>" />
                                            </td>
                                            <td align="left" style="width: 25%">
                                                <cc1:DropCheck ID="ddlMonth" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="200px">
                                                </cc1:DropCheck>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:Label ID="lblHdrMonthDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MonthDate %>" />
                                            </td>
                                            <td align="left" style="width: 25%">
                                                <cc1:DropCheck ID="ddlMonthDate" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="200px">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%">
                                <asp:Label ID="lblHdrFromTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, FromTime %>"></asp:Label>
                            </td>
                            <td align="left" style="width: 25%">
                                <asp:TextBox ID="txtFromTime" CssClass="csstxtbox" MaxLength="5" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 25%">
                                <asp:Label ID="lblHdrToTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ToTime %>"></asp:Label>
                            </td>
                            <td align="left" style="width: 25%">
                                <asp:TextBox ID="txtToTime" CssClass="csstxtbox" MaxLength="5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button runat="server" ID="btnSave" CssClass="cssButton" Width="150px" Text="Save" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label CssClass="cssLabel" ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </Ajax:UpdatePanel>
    </div>
</asp:Content>

