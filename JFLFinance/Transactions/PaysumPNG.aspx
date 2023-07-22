<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaysumPNG.aspx.cs" Inherits="Transactions_PaysumPNG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" Text=""></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <table>
                    <tr>
                        <tr>
                            <td align="center" colspan="2">
                                <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        processing......
                                        <img id="imgspin" runat="server" alt="" src="../Images/spinner.gif" />
                                    </ProgressTemplate>
                                </Ajax:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label3" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtFDate" Width="88px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                <asp:HyperLink ID="ImgFDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtTDate" Width="88px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                <asp:HyperLink ID="ImgTDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Button ID="btnGenerateData" runat="server" CssClass="cssButton" Text="View"
                                    OnClick="btnGenerateData_OnClick" />
                            </td>
                        </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <table>
                    <tr>
                        <td>
                            <dx:ASPxGridView ID="PaysumPNG" runat="server" Width="950px" AutoGenerateColumns="True">
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                                    ShowHorizontalScrollBar="True" />
                                <SettingsPager AlwaysShowPager="True" PageSize="10">
                                </SettingsPager>
                            </dx:ASPxGridView>
                        </td>
                        <tr>
                            <td>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="PaysumPNG">
                                </dx:ASPxGridViewExporter>
                            </td>
                        </tr>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <table>
        <tr>
            <td align="left">
                <asp:Button ID="Button1" runat="server" Text="Export to Excel" CssClass="cssButton"
                    OnClick="btn_submit" />
            </td>
        </tr>
    </table>
</asp:Content>
