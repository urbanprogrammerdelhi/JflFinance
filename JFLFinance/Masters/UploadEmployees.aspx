<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="UploadEmployees.aspx.cs" Inherits="Masters_UploadEmployees" Title="Upload Employee" %>

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
                                <td align="left">
                                    <asp:DropDownList ID="ddlFromLocation" Width="300" runat="server" CssClass="cssdropdown">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblToLocation" runat="server" CssClass="csslabel" Text="Magnon Branch"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtToLocation" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Label ID="Label1" runat="server" CssClass="csslabel" Text="Area"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAreaID" Width="300" runat="server" CssClass="cssdropdown"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="cssbutton" Text="Upload Employees"
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
                                <td>
                                </td>
                                <td>
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
