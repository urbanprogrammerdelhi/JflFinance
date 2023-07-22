<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Paysum_ISR.aspx.cs" Inherits="Transactions_Paysum_ISR" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                        <%--Code added by Manish on 23-apr-2012 for paysum output format --%>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,PaysumOutput %>"
                                    CssClass="cssLable"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButton ID="paysumOutputHorizontally" GroupName="paysumFormat" runat="server"
                                    Checked="true" Text="<%$Resources:Resource,PaysumHrsHeadHorizontlly %>" />
                                <asp:RadioButton ID="paysumOutputVertically" GroupName="paysumFormat" runat="server"
                                    Text="<%$Resources:Resource,PaysumHrsHeadVertically %>" />
                            </td>
                        </tr>
                        <%--end Code added by Manish on 23-apr-2012 for paysum output format --%>
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
                                <asp:HiddenField ID="businessRuleCode" runat="server" Value="" />
                                <asp:Button ID="btnGenerateData" runat="server" CssClass="cssButton" Text="View"
                                    OnClick="btnGenerateData_OnClick" />
                            </td>
                            <td>
                                <asp:Button ID="btnPaySum" runat="server" CssClass="cssButton" Text="Export To Text"
                                    OnClick="btnPaySum_OnClick" Visible="false" />
                            </td>
                        </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <table>
                    <tr>
                        <td>
                            <dx:ASPxGridView ID="PaysumGridView1" runat="server" Width="950px" AutoGenerateColumns="True">
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                                    ShowHorizontalScrollBar="True" />
                                <SettingsPager AlwaysShowPager="True" PageSize="10">
                                </SettingsPager>
                            </dx:ASPxGridView>
                            <dx:ASPxGridView ID="PaysumGridView2" runat="server" Width="950px" AutoGenerateColumns="True">
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                                    ShowHorizontalScrollBar="True" />
                                <SettingsPager AlwaysShowPager="True" PageSize="10">
                                </SettingsPager>
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                            </dx:ASPxGridViewExporter>
                        </td>
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
                <asp:Button ID="btnExportToCsv" runat="server" Text="Export to Csv" CssClass="cssButton"
                    OnClick="btnExportToCsv_submit" />
            </td>
        </tr>
    </table>
</asp:Content>
