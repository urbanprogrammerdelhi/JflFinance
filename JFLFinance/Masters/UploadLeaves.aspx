<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="UploadLeaves.aspx.cs" Inherits="Masters_UploadLeaves" Title="Upload Leave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            processing......
                                            <img id="imgspin" runat="server" alt="" src="../Images/spinner.gif" />
                                        </ProgressTemplate>
                                    </Ajax:UpdateProgress>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblFromLocation" runat="server" CssClass="csslabel" Text="PayGlobal Branch"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFromLocation" Width="300" runat="server" CssClass="cssdropdown" >
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblToLocation" runat="server" CssClass="csslabel" Text="Magnon Branch"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtToLocation" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblLeaveCal" runat="server" CssClass="csslabel" Text="Leave Calender"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLeaveCal" runat="server" CssClass="cssdropdown">
                                    </asp:DropDownList>
                                </td>
                            </tr>                            
                            <tr>
                                <td colspan="7" align="center">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="cssbutton" Text="Upload Leaves"
                                        OnClick="btnUpdate_Click" />
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblUploadedEmployees" Text="" runat="server" CssClass="csslabel" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDuplicateEmployees" Text="" runat="server" CssClass="csslabel"
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
