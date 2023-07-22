<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientMapping.aspx.cs" Inherits="Masters_ClientMapping" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="ClientDetails" Width="100%" ActiveTabIndex="0" AutoPostBack="true">
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelClientDetails" runat="server" HeaderText="<%$Resources:Resource,ClientBranchMapping %>" TabIndex="0">
                        <ContentTemplate>
                            <div style="text-align:right;">
                                <asp:LinkButton ID="lbClientDetails" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource, ClientDetails %>" OnClick="lbClientDetails_Click"></asp:LinkButton>
                            </div>
                            <div style="text-align:center;">
                                <asp:Label ID="lblLocation" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, Location %>"></asp:Label>
                                <asp:DropDownList ID="ddlLocation" CssClass="cssDropDown" Width="260" runat="server" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                                <div>
                                    <table border="0" cellpadding="3" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblAllClient" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, UnMappedClients %>"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblMappedClient" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, MappedClients %>"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ListBox AutoPostBack="false" ID="lbAllClient" runat="server" CssClass="" SelectionMode="Multiple"
                                                    Rows="11" Width="260"></asp:ListBox>
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ImgBtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                    ToolTip="<%$ Resources:Resource, Add %>" ImageUrl="../Images/Add.gif" OnClick="ImgBtnAdd_Click" />
                                                <br/>
                                                <br/>
                                                <asp:ImageButton ID="ImgBtnRemove" runat="server" CssClass="cssImgButton" CommandName="Remove"
                                                    ToolTip="<%$ Resources:Resource, Remove %>" ImageUrl="../Images/Remove.gif" OnClick="ImgBtnRemove_Click" />
                                            </td>
                                            <td align="center">
                                                <asp:ListBox ID="lbMappedClient" runat="server" CssClass="" SelectionMode="Multiple"
                                                    Rows="11" Width="260"></asp:ListBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:Button ID="btnApply" Text="<%$ Resources:Resource, Apply %>" runat="server" CssClass="cssButton" OnClick="btnApply_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                        
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelCustomerMeeting" runat="server" HeaderText="<%$Resources:Resource,ClientMeetingDetail %>" TabIndex="0">
                        <ContentTemplate>
                            <div>
                                <table border="0" cellpadding="3" cellspacing="0" style="width:100%">
                                    <tr>
                                        <td align="right" width="300px">
                                            <asp:Label ID="lblhdrClient" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:TextBox ID="txtClientCode" runat="server" CssClass="csstxtbox" OnTextChanged="txtClientCode_TextChanged"
                                                AutoPostBack="true" Width="200px"></asp:TextBox>
                                            <%--<asp:Image ID="ImgClientCode_CCH" runat="server" ImageUrl="~/Images/icosearch.gif"  />--%>
                                            <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                Width="280px" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 300px">
                                            <asp:Label CssClass="cssLable" ID="lblFrequency" runat="server" Text="<%$ Resources:Resource, Frequency %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList CssClass="cssDropDownRequired" runat="server" ID="ddlFrequencySch" AutoPostBack="false" Width="200px">
                                                <asp:ListItem Text="Per Week" Value="PerWeek"></asp:ListItem>
                                                <asp:ListItem Text="Per 2nd Week" Value="Per2Week"></asp:ListItem>
                                                <asp:ListItem Text="Per Month" Value="PerMonth" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Per 2nd Month" Value="Per2Month" />
                                                <asp:ListItem Text="Per 3rd Month" Value="Per3Month" />
                                                <asp:ListItem Text="Per 6th Month" Value="Per6Month" />
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" style="width: 100px">
                                            <asp:Label CssClass="cssLable" ID="lblSchClntMeeting" runat="server" Text="<%$ Resources:Resource,SchClientMeeting %>" Visible="false"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 180px">
                                            <asp:TextBox CssClass="csstxtboxRequired" Width="80px" ID="txtSchClntMeeting" runat="server"
                                                Visible="false" Text="1" Enabled="false" MaxLength="2"></asp:TextBox>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="ajxSchClntMeeting" runat="server" FilterType="Numbers"
                                                TargetControlID="txtSchClntMeeting" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btnApplyMeeting" Text="<%$ Resources:Resource, Apply %>" runat="server"
                                                CssClass="cssButton" OnClick="btnApplyMeeting_Click" Enabled="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblerror" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
            </AjaxToolKit:TabContainer>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
