<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ProcessBranchWiseEffectiveness.aspx.cs" Inherits="Reports_DashBoard_ProcessBranchWiseEffectiveness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 950px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, Process %>"></asp:Label></tt></div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="3" cellspacing="0" style="width: 700px">
                                        <tr>
                                            <td style="width: 100" align="right">
                                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, Division %>"
                                                    CssClass="cssLable"></asp:Label>
                                            </td>
                                            <td style="width: 500" align="left">
                                                <asp:DropDownList ID="ddlDivision" Width="300" runat="server" 
                                                    CssClass="cssDropDown" AutoPostBack="true" 
                                                    onselectedindexchanged="ddlDivision_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100" align="right">
                                                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, Branch %>"
                                                    CssClass="cssLable"></asp:Label>
                                            </td>
                                            <td style="width: 500" align="left">
                                                <asp:DropDownList ID="ddlBranch" AutoPostBack="false" Width="300" runat="server" CssClass="cssDropDown">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblMonth" runat="server"
                                                    Text="<%$ Resources:Resource, Year %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="cssDropDown" Width="80"
                                                    AutoPostBack="true" >

                                                </asp:DropDownList>
                                                
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="height: 30px">
                                                &nbsp;
                                            </td>
                                            <td align="left" style="height: 30px">
                                                <asp:Button ID="btnProcess" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Process%>"
                                                    OnClick="btnProcess_Click" />
                                            </td>
                                        </tr>
                                           <tr>
                                            <td align="left" colspan="2">
                                                <br>
                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                <br>
                                                <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                Please wait.....<img alt="" src="../Images/ajax-loader.gif" />
                                                </ProgressTemplate>
                                                </Ajax:UpdateProgress>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>

