<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AusPayGlobalOutput.aspx.cs" Inherits="Transactions_AusPayGlobalOutput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td style="width: 200px">
                        <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,ClientName %> "
                            CssClass="cssLable"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="cssDropDown" Width="350px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"></asp:TextBox>
                        <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                            TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                        </AjaxToolKit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"></asp:TextBox>
                        <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                            TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                        </AjaxToolKit:CalendarExtender>
                    </td>
                </tr>
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
                    <td colspan="2">
                        <dx:ASPxGridView ID="PayGlobalOutput" runat="server" Width="950px" AutoGenerateColumns="True" >
                            <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                                ShowHorizontalScrollBar="True" />
                            <SettingsPager AlwaysShowPager="True" PageSize="10">
                            </SettingsPager>
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="PayGlobalOutput">
                        </dx:ASPxGridViewExporter>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" Text=""></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <table>
        <tr>
            <td>
                <asp:Button ID="bntProceed" runat="server" Text="<%$Resources:Resource,Proceed %>"
                    OnClick="bntProceed_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Export to Excel" CssClass="cssButton"
                    OnClick="btn_submit" />
            </td>
        </tr>
    </table>
</asp:Content>
