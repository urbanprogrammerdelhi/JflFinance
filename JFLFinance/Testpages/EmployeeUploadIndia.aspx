<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeUploadIndia.aspx.cs" Inherits="Transactions_EmployeeUploadIndia"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="up1" runat="server" Width="500px" Height="80px" Visible="false" GroupingText="Employee Data Uploading">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblEmpcode" runat="server" Text="Employee Code" CssClass="cssLable">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtEmpcode" runat="server" CssClass="csstxtbox" Width="100px">            
                            </asp:TextBox>
                            &nbsp;
                            <asp:Button ID="BtnProcess" CssClass="cssButton" runat="server" Text="Upload" OnClick="BtnProcess_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" Width="500px" Height="100px" GroupingText="Leave Uploading">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlMonth" Width="70px" runat="server" CssClass="cssDropDownSmall"
                                AutoPostBack="false" onchange="javascript:DatesGet('Month');">
                                <asp:ListItem Text="<%$ Resources:Resource, January%>" Value="1"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,February%>" Value="2"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,March%>" Value="3"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,April%>" Value="4"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,May%>" Value="5"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,June%>" Value="6"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,July%>" Value="7"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,August%>" Value="8"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,September%>" Value="9"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,October%>" Value="10"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,November%>" Value="11"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Resource,December%>" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox MaxLength="4" Width="25px" CssClass="csstxtboxSmall" ID="txtYear" runat="server"
                                AutoPostBack="false">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:LinkButton ID="btnLeaveUpload" runat="server" CssClass="" Text="" OnClick="btnLeaveUpload_Click"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:Label ID="lblLeaveErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="up2" runat="server" Width="500px" Height="80px" Visible="false" GroupingText="Clientwise Sales Data Uploading">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblClientCode" runat="server" Text="Client Code" CssClass="cssLable">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtClientCode" MaxLength="6" runat="server" CssClass="csstxtbox"
                                Width="100px">            
                            </asp:TextBox>
                            &nbsp;
                            <asp:Button ID="BtnProcess2" CssClass="cssButton" runat="server" Text="Upload" OnClick="BtnProcess2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblErrorMsg2" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    Data uploading please wait.....
                    <img alt="" id="imgprogress" runat="server" src="../Images/spinner.gif" />
                </ProgressTemplate>
            </Ajax:UpdateProgress>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
