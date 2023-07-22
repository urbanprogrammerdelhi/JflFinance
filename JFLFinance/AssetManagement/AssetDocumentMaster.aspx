<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" EnableViewState="true" CodeFile="AssetDocumentMaster.aspx.cs" Inherits="AssetManagement_AssetDocumentMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="DIVUpload" runat="server">
        <table align="center" width="900px" border="0" cellspacing="0px" cellpadding="0px" style="font-size: small;">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Select Document" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Document Type" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Document Detail" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="afuDocumentDetailPurchase" runat="server" />
                    <asp:HiddenField ID="AssetId" runat="server" Value="0" />
                    <asp:HiddenField ID="Category" runat="server" Value="0" />
                    <asp:HiddenField ID="hfDocumentName" runat="server" Value="0" />
                </td>
                <td>
                    <asp:Label ID="DocType" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDocumentdesc" runat="server" CssClass="csstxtbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDocumentdesc" ControlToValidate="txtDocumentdesc" Display="Dynamic" runat="server" Text="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator>

                </td>
                <td>

                    <asp:Button ID="btnUploaddocument" Text='<%$ Resources:Resource, Upload%>' CssClass="cssButton" runat="server" OnClick="btnUploaddocument_Click" ValidationGroup="Upload" /><br />



                </td>
                <td>
                    <%--  <asp:Button ID="btnDownloadDoc" Text="Download" CssClass="cssButton" runat="server" Visible="false"  OnClick="btnDownloadDoc_Click"/><br />--%>
               
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:Panel ID="PanelDocumentUpload" runat="server" Style="margin-left: 20px">
        <asp:GridView Width="100%" ID="gvDocumentDetail" CssClass="GridViewStyle" runat="server" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
            AutoGenerateColumns="False" OnPageIndexChanging="gvDocumentDetail_PageIndexChanging" OnRowDeleting="gvDocumentDetail_RowDeleting">
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,DocumentDescription %>">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfDocumentType" runat="server" Value='<%#Bind("DocumentType") %>' />
                        <asp:HiddenField ID="hfDocumentTypeAutoId" runat="server" Value='<%#Bind("DocumentTypeAutoId") %>' />
                        <asp:HiddenField ID="hfAssetDocumentAutoId" runat="server" Value='<%#Bind("AssetDocumentAutoId") %>' />
                        <asp:Label ID="DocumentDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("DocumentDesc") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                    <ItemStyle Width="200px" />
                    <FooterStyle Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,DocumentDetail %>">
                    <ItemTemplate>
                        <asp:Label ID="lblFileName" CssClass="cssLabel" runat="server" Text='<%# Bind("DocumentFileName") %>'></asp:Label>
                        <asp:ImageButton ID="imgBtnDownload" runat="server" OnClick="imgBtnDownload_Click" CommandArgument='<%# Eval("DocumentFileName") %>' ImageUrl="~/Images/downloaddoc.png"></asp:ImageButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText='<%$ Resources:Resource,EditColName%>'>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/Delete.gif" ToolTip="<%$Resources:Resource,Delete %>" Height="20px" Width="20px" CommandName="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblDocument" runat="server" ForeColor="Red"></asp:Label>
      </asp:Panel>
</asp:Content>

