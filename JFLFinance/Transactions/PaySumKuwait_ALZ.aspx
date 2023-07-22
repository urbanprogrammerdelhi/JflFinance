<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaySumKuwait_ALZ.aspx.cs" Inherits="Transactions_PaySumKuwait_ALZ" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="1" cellspacing="0">
                <tr>
                    <td align="center">
                        <asp:Panel ID="Panel1" Width="600px" Height="150px" GroupingText="<%$ Resources:Resource, PaySum %>" BorderWidth="0px"
                            runat="server" BorderStyle="Solid" EnableTheming="true">
                            <table width="600" border="0">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" CssClass="csslabel" runat="server" Text="<%$ Resources:Resource, HrLocation %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlDivision" AutoPostBack="true" Width="400px" CssClass="cssDropDown"
                                            runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <AjaxToolKit:DropDownExtender ID="ddlDivision_DropDownExtender" runat="server" DynamicServicePath=""
                                            Enabled="True" TargetControlID="ddlDivision">
                                        </AjaxToolKit:DropDownExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" CssClass="csslabel" runat="server" Text="<%$ Resources:Resource, Branch %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlBranch" Width="400px" CssClass="cssDropDown" runat="server">
                                        </asp:DropDownList>
                                        <AjaxToolKit:DropDownExtender ID="ddlBranch_DropDownExtender" runat="server" DynamicServicePath=""
                                            Enabled="True" TargetControlID="ddlBranch">
                                        </AjaxToolKit:DropDownExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label4" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, Month %>"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 200">
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" Width="150px">
                                            <asp:ListItem Value="01" Text="<%$ Resources:Resource, January %>" ></asp:ListItem>
                                            <asp:ListItem Value="02" Text="<%$ Resources:Resource, February %>"></asp:ListItem>
                                            <asp:ListItem Value="03" Text="<%$ Resources:Resource, March %>"></asp:ListItem>
                                            <asp:ListItem Value="04" Text="<%$ Resources:Resource, April %>"></asp:ListItem>
                                            <asp:ListItem Value="05" Text="<%$ Resources:Resource, May %>"></asp:ListItem>
                                            <asp:ListItem Value="06" Text="<%$ Resources:Resource, June %>"></asp:ListItem>
                                            <asp:ListItem Value="07" Text="<%$ Resources:Resource, July %>"></asp:ListItem>
                                            <asp:ListItem Value="08" Text="<%$ Resources:Resource, August %>"></asp:ListItem>
                                            <asp:ListItem Value="09" Text="<%$ Resources:Resource, September %>"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="<%$ Resources:Resource, October %>"></asp:ListItem>
                                            <asp:ListItem Value="11" Text="<%$ Resources:Resource, November %>"></asp:ListItem>
                                            <asp:ListItem Value="12" Text="<%$ Resources:Resource, December %>"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtYear" runat="server" CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnGeneratePaySum" CssClass="cssButton" runat="server" 
                                            Text="<%$ Resources:Resource, Generate %>" onclick="btnGeneratePaySum_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
