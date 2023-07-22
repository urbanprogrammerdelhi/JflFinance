<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPage.master"
    CodeFile="FlatFileInterface.aspx.cs" Inherits="Masters_FlatFileInterface" Title="Flat File Interface" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <div class="container" style="width: 950px">
                    <h2>
                        <span>
                            <asp:LinkButton ID="lnkbtnLocSelect" runat="server" Text="<%$Resources:Resource,Upload %>"></asp:LinkButton>
                        </span>
                    </h2>
                    <div id="section1" class="section">
                        <span>
                        <table>
                            <tr>
                                <td style="text-align: left;">
                                    <asp:FileUpload ID="FileUploadEmployee" Width="500px" EnableViewState="true" CssClass="csstxtbox"
                                        runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnUpload" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Upload %>"
                                        OnClick="btnUpload_Click" />
                                </td>
                            </tr>                            
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="900px" Height="400px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="900px" ID="gvInterfaceLog" runat="server" CellPadding="1" PageSize="15"
                                            AutoGenerateColumns="True"
                                            AllowPaging="True">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />                                            
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        </span>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
