<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="IDIssuingReceiving.aspx.cs" Inherits="HRManagement_IDIssuingReceiving" Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 98%;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label13" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, IDIssuing %>"></asp:Label>
                                        </tt>
                                    </div>
                                    <div style="float: right; vertical-align: middle">
                                        
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <asp:Panel ID="PanelIDIssuing" BorderWidth="0px" runat="server" Width="98%" Height="190"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                            <tr>
                                                <td colspan="5" align="right">
                                                    <asp:Label ID="LblIssueStatus" Width="150px" runat="server" Text="<%$ Resources:Resource, IssuingStatus %>" CssClass="cssLabel">
                                                    </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtIssueStatus" runat="server" CssClass="csstxtboxReadonly" ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="right">
                                                    <asp:Label ID="LblEmployeeNumber" Width="150px" runat="server" Text="<%$ Resources:Resource, EmployeeNumber %>" CssClass="cssLabel">
                                                    </asp:Label>
                                                </td>
                                                <td align="left" width="200">
                                                    <asp:TextBox ID="TxtEmployeeNumber" runat="server" CssClass="csstxtboxReadonly" OnTextChanged="TxtEmployeeNumber_OnTextChanged"
                                                        AutoPostBack="true">
                                                    </asp:TextBox>
                                                    <asp:ImageButton ID="imgEmployeeNumberSearch" runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="<%$ Resources:Resource, SearchEmployee %>" />
                                                </td>
                                                <td align="right" width="150">
                                                    <asp:Label ID="LblEmployeeName" Width="150px" runat="server" Text="<%$ Resources:Resource, EmployeeName %>" CssClass="cssLabel">
                                                    </asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <asp:TextBox ID="TxtEmployeeName" runat="server" CssClass="csstxtboxReadonly">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="LblIdType" runat="server" Text="<%$ Resources:Resource, IDType %>" CssClass="cssLabel">
                                                
                                                    </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlIdType" runat="server" CssClass="cssDropDown" Width="130px" OnTextChanged = "ddlIdType_OnTextChanged" AutoPostBack = "true">
                                                    </asp:DropDownList>
                                                </td>
                                                
                                                <td align="right" width="150">
                                                    <asp:Label ID="LblIdNo" runat="server" Text="<%$ Resources:Resource, IDNumber %>" CssClass="cssLabel">
                            
                                                    </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtIdNo" runat="server" CssClass="csstxtboxReadonly" Width="100px">
                                                    </asp:TextBox>
                                                </td>
                                                
                                                  <td align="right">
                                                    <asp:Label ID="LblPurOfIssue" runat="server" Text="<%$ Resources:Resource, PurposeOfIssue %>" CssClass="cssLabel" Width ="100px">
                                                    </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlPurOfIssue" runat="server" CssClass="cssDropDown" Width="150px">
                                                    </asp:DropDownList>
                                                </td>
                                                
                                                
                                              
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="LblDateOfIssue" runat="server" Text="<%$ Resources:Resource, DateOfIssue %>" CssClass="cssLabel">
                                                    </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtDateOfIssue" runat="server" CssClass="csstxtboxReadonly">
                                                    </asp:TextBox>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender8" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="TxtDateOfIssue" PopupButtonID="IMGDate" />
                                                </td>
                                                <td align="right"  width="150">
                                                    <asp:Label ID="LblExDateOFReturn" Width="150" runat="server" Text="<%$ Resources:Resource, ExpectedDateOfReturn %>"
                                                        CssClass="cssLabel"> 
                                                    </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtExDateOFReturn" runat="server" CssClass="csstxtboxReadonly">
                                                    </asp:TextBox>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="TxtExDateOFReturn" PopupButtonID="IMGDate" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="LblIssueRemarks" runat="server" Text="<%$ Resources:Resource, Remarks %>" CssClass="cssLabel">
                                                    </asp:Label>
                                                </td>
                                                <td colspan="5" align="left">
                                                    <asp:TextBox ID="TxtIssueRemarks" runat="server" CssClass="csstxtboxReadonly" Width="750">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="text-align: center">
                                                    <asp:Label EnableViewState="false" ID="lblErrMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td colspan = "6">
                                            &nbsp;
                                            </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <asp:Button ID="Button1" runat="server" CssClass="cssButton" Width="100px" OnClick ="btnSave_Click" Text="<%$ Resources:Resource, Save %>" />
                                                    <asp:Button ID="Button2" runat="server" CssClass="cssButton" Width="100px" Text="<%$ Resources:Resource, Update %>" />
                                                    <asp:Button ID="Button3" runat="server" CssClass="cssButton" Width="100px" OnClick ="btnAuthorize_Click" Text="<%$ Resources:Resource, Authorize %>" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <div style="width: 98%;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label1" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, IDReceving %>"></asp:Label>
                                        </tt>
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <asp:Panel ID="PanelIDReceving" BorderWidth="0px" runat="server" Width="98%" Height="120px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <table width="97%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <tr>
                                                    <td colspan="6">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="LblDateOfReciept" runat="server" Text="<%$ Resources:Resource, DateOfReciept %>" CssClass="cssLabel">
                                                    </asp:Label>
                                                </td>
                                                <td align="left" style="width: 148px">
                                                    <asp:TextBox ID="TxtDateOfReciept" runat="server" CssClass="csstxtboxReadonly">
                                                    </asp:TextBox>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="TxtDateOfReciept" PopupButtonID="IMGDate" />
                                                </td>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="LblRecieptStatus" runat="server" Text="<%$ Resources:Resource, RecieptStatus %>" CssClass="cssLabel">
                                                    </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtRecieptStatus" runat="server" CssClass="csstxtboxReadonly">
                                                    </asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="LblRecieptRemarks" runat="server" Text="<%$ Resources:Resource, Remarks %>" CssClass="cssLabel">
                                                    </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtRecieptRemarks" runat="server" CssClass="csstxtboxReadonly" Width="500px">
                                                    </asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="text-align: center">
                                                    <asp:Label EnableViewState="false" ID="lblErr1" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <asp:Button ID="BtnADD" runat="server" CssClass="cssButton" Width="100px" Text="<%$ Resources:Resource, Save %>" />
                                                    <asp:Button ID="BtnUpdate" runat="server" CssClass="cssButton" Width="100px" Text="<%$ Resources:Resource, Update %>" />
                                                    <asp:Button ID="BtnDelete" runat="server" CssClass="cssButton" Width="100px" Text="<%$ Resources:Resource, Authorize %>" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
