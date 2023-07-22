<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterHeader.master" AutoEventWireup="true"
    CodeFile="MasterMenu.aspx.cs" Inherits="UserManagement_MasterMenu" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%; height:100%; vertical-align: top; margin: 0;" border="0" cellpadding="0"
        cellspacing="0">
        <tr>
            <td align="center">
                
                
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="PnlMainMenu" runat="server" Height="400px" Width="100%">
                        <table border="0" style="vertical-align: middle; height: 400px; width: 100%;" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 50px;">
                                    </td>
                                    <td align="center">
                                        <table border="0" cellpadding="0" cellspacing="0" width="205px" style="text-align: left;  background:ThreeDFace; display:none;">
                                            <tr>
                                                <td style="height:350px; width:201px; vertical-align:top; text-align:left; background-image:url(../Images/MenuHead.bmp);background-repeat:repeat-x;">
                                                    <table>
                                                        <tr>
                                                            <td style="width:10px;"></td>
                                                            <td style="height:70px;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:10px;">&nbsp#</td>
                                                            <td><asp:HyperLink CssClass="csslinkMM" ID="hlnkMenuCreation" NavigateUrl="~/UserManagement/MenuCreation.aspx" runat="server" Text="<%$ Resources:Resource, MenuManagement %>"></asp:HyperLink></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:10px;">&nbsp#</td>
                                                            <td><asp:HyperLink CssClass="csslinkMM" ID="hlnkCreateCompany" NavigateUrl="../Masters/Company.aspx" runat="server" Text="<%$ Resources:Resource, CreateCompany %>"></asp:HyperLink></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:10px;">&nbsp#</td>
                                                            <td><asp:HyperLink CssClass="csslinkMM" ID="hlnkCreateHrLocation" NavigateUrl="../Masters/HrLocation.aspx" runat="server" Text="<%$ Resources:Resource, CreateHrLocation %>"></asp:HyperLink></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:10px;">&nbsp#</td>
                                                            <td><asp:HyperLink CssClass="csslinkMM" ID="hlnkCreateLocation" runat="server" NavigateUrl="../Masters/Location.aspx" Text="<%$ Resources:Resource, CreateLocation %>"></asp:HyperLink></td>
                                                        </tr>
                                                          <tr>
                                                            <td style="width:10px;">&nbsp#</td>
                                                            <td><asp:HyperLink CssClass="csslinkMM" ID="HLSystemParameter" runat="server" NavigateUrl="~/UserManagement/SystemParameter.aspx" Text="System Parameter"></asp:HyperLink></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:10px;">&nbsp#</td>
                                                            <td>
                                                                <asp:HyperLink CssClass="csslinkMM" ID="HyperLink1" runat="server" Text="Reset all passwords with new encription"></asp:HyperLink>
                                                                <asp:ImageButton ID="ImgResetPassword" runat="server" Width="20px" Height="10px" ImageUrl="~/Images/spacer.gif" onclick="ImgResetPassword_Click" />
                                                            </td>
                                                        </tr>
<%--                                                        <tr>
                                                            <td style="width:10px;">&nbsp#</td>
                                                            <td><asp:HyperLink CssClass="csslinkMM" ID="hlnkSiteMap" NavigateUrl="../UserManagement/SiteMap.aspx" runat="server" Text="<%$ Resources:Resource, SiteMap %>"></asp:HyperLink></td>
                                                        </tr>
--%>                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="center">:
                                        <table border="0" cellpadding="0" cellspacing="0" width="205px" style="text-align: left; background-color:ThreeDFace ">
                                            <tr>
                                                <td style="height:350px; width:201px; vertical-align:top; text-align:left; background-image:url(../Images/MenuHead.bmp);background-repeat:repeat-x;">
                                                    <table>
                                                        <tr>
                                                            <td style="width:10px;"></td>
                                                            <td style="height:70px;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:10px;">&nbsp#</td>
                                                            <td><asp:HyperLink CssClass="csslinkMM" ID="hlnkMainSelection" NavigateUrl="../UserManagement/MainSelection.aspx" runat="server" Text="<%$ Resources:Resource, LocationSelection %>"></asp:HyperLink></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50px">
                                    </td>
                                 </tr>
                          </table>
                        </asp:Panel>
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="lblErrMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </td>
                        </tr>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
