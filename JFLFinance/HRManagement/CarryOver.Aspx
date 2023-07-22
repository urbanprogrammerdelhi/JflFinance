<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CarryOver.aspx.cs" Inherits="HRManagement_CarryOver" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                                <div class="squareboxgradientcaption" style="height:20px;">
                                    <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Resource, CarryOver %>" ></asp:Label>
                                </div>
                                <div>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                        <tr>
                                            <td style="width: 18%" align="right">
                                                <asp:Label ID="Label1" CssClass="cssLabel" Width="150px" runat="server" Text="<%$Resources:Resource,LeaveCalendarCode %>"></asp:Label>
                                            </td>
                                            <td style="width: 20%" align="left">
                                                <asp:TextBox MaxLength="8" AutoPostBack="true" ID="txtLeaveCalendarCode" OnTextChanged="txtLeaveCalendarCode_OnTextChanged"
                                                    Width="150px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                <asp:ImageButton ID="ImgLCCode" AlternateText="SearchClient" runat="server"
                                                    ImageUrl="~/Images/icosearch.gif" ToolTip="<%$Resources:Resource,SearchLeaveCalendar %>" />
                                                    
                                            </td>
                                            <td colspan="4" align="left">
                                                <asp:Label Width="262px" Style="font-weight: bold;" ID="lblLeaveCalendarDesc" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label>
                                                <%--<asp:Label ID="lblLeaveCalendarDesc" CssClass="csstxtboxReadonly" runat="server"></asp:Label> --%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EffectiveFrom %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label Width="150px" Style="font-weight: bold;" ID="lblEffectiveFrom" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 12%" align="right">
                                                <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EffectiveTo %>"></asp:Label>
                                            </td>
                                            <td style="width: 20%" align="left">
                                                <asp:Label Width="150px" Style="font-weight: bold;" ID="lblEffectiveTo" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 1px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 1px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center">
                                                <asp:Label EnableViewState="false" ID="lblErrMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center">
                                                <asp:Button ID="btnProcess" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Process %>" />
                                                <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Authorize %>"
                                                     ValidationGroup="vg_Add" />
                                                <asp:Button ID="btnReset" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Reset %>" />
                                                
                                                     
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
</asp:Content>
