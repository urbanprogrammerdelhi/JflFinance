<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadingSwipeRpt.aspx.cs"
    Inherits="Transactions_UploadingSwipeRpt" MasterPageFile="~/MasterPage/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="TabFlowDiag"
        Width="950px" Height="400px" ActiveTabIndex="0">
        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelTabFlowDiag" runat="server"
            HeaderText="Attendance">
            <ContentTemplate>
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%; border: 0px solid #FFFFFF">
                    <tr>
                        <td>
                            <table style="width: 100%; vertical-align: middle">
                                <tr style="height: 12px">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 60%; border: 1px solid #B7CEEC">
                                            <tr style="height: 25px" align="center">
                                                <td>
                                                    <asp:Label ID="UploadSwipe" runat="server" Text="<%$ Resources:Resource,UploadSwipeRpt %>"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px" align="center">
                                                    <asp:FileUpload ID="flUploadSwipe" runat="server" CssClass="upload" Height="23px"
                                                        Width="184px" />
                                                </td>
                                            </tr>
                                            <tr style="height: 35px" align="center">
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="width: 48%" align="right">
                                                                <asp:Button ID="btnSaveFile" runat="server" Text="<%$ Resources:Resource,SaveFile %>"
                                                                    CssClass="cssButton" OnClick="btnSaveFile_Click" />
                                                            </td>
                                                            <td style="width: 4%">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="width: 48%" align="left">
                                                                <asp:Button ID="btnReset" runat="server" Text="<%$ Resources:Resource,Reset %>" CssClass="cssButton"
                                                                    OnClick="btnReset_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px">
                            <asp:Label ID="MsgFileStatus" runat="server" CssClass="cssLabel"></asp:Label>
                        </td>
                    </tr>
                    <tr align="center" style="height: 25px">
                        <td>
                            <asp:Label ID="Note" runat="server" CssClass="cssLabel" Text="NOTE:  System date format must be ''DD-MM-YYYY'' for Uploading Files"></asp:Label>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <Ajax:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grvUploadSwipe" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False"
                                        Width="575px" AllowPaging="True" CellPadding="1" OnRowCommand="grvUploadSwipe_RowCommand"
                                        DataKeyNames="userfile_name" OnRowDeleting="grvUploadSwipe_RowDeleting">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:CommandField HeaderText="<%$Resources:Resource,SelectFile %>" ButtonType="Button"
                                                SelectText="Upload" ShowSelectButton="true" ItemStyle-VerticalAlign="Middle">
                                                <ItemStyle VerticalAlign="Middle" />
                                            </asp:CommandField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,UserFileName %>">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbl1" Text='<%# Bind("userfile_name") %>'> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,ServerFileName %>">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbl2" Text='<%# Bind("Serverfile_name") %>'> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField SelectText="Delete File" ItemStyle-VerticalAlign="Middle" ShowDeleteButton="True">
                                            </asp:CommandField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <Ajax:PostBackTrigger ControlID="grvUploadSwipe" />
                                </Triggers>
                            </Ajax:UpdatePanel>
                        </td>
                    </tr>
                    <tr style="width: 25px" align="center">
                        <td>
                        </td>
                    </tr>
                    <tr style="width: 45px" align="center">
                        <td align="center">
                        </td>
                </table>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel Style="text-align: left;" TabIndex="1" ID="TabPanel1" runat="server" HeaderText="POP">
            <ContentTemplate>
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%; border: 0px solid #FFFFFF">
                    <tr>
                        <td>
                            <table style="width: 100%; vertical-align: middle">
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel21" Width="700px" runat="server" GroupingText="POP Upload">
                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td style="height: 25px" align="center">
                                                        <asp:FileUpload ID="FUPOPUpload" runat="server" CssClass="upload" Height="23px" Width="350px" />
                                                    </td>
                                                </tr>
                                                <tr style="height: 35px" align="center">
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td style="width: 48%" align="right">
                                                                    <asp:Button ID="btnPOPUpload" runat="server" Text="<%$ Resources:Resource,Upload %>"
                                                                        CssClass="cssButton" OnClick="btnPOPUpload_Click" />
                                                                </td>
                                                                <td style="width: 48%" align="left">
                                                                    <asp:Button ID="Button2" runat="server" Text="<%$ Resources:Resource,Reset %>" CssClass="cssButton"
                                                                        OnClick="btnReset_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="center" style="height: 25px">
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text="NOTE:  System date format must be ''DD-MM-YYYY'' for Uploading Files"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
    </AjaxToolKit:TabContainer>
</asp:Content>
