<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterSearch.master" AutoEventWireup="true"
    CodeFile="EmployeeDocumentUpload.aspx.cs" Inherits="HRManagement_EmployeeDocumentUpload" Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="DIVUpload" runat="server">
        <table width="700" border="0" align="center">
            <tr>
                <td align="right" width="150">
                    <asp:Label ID="LabelUploadDesc" Width="150px" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, UploadDesc %>"></asp:Label>
                </td>
                <td align="left" width="400">
                    <asp:TextBox ID="txtUploadDesc" Width="400px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="140" nowrap="nowrap">
                    <asp:Label ID="lblFileUpload" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, EmployeeDocumentUpload %>"></asp:Label>
                </td>
                <td width="400">
                    <asp:FileUpload ID="EmployeeDocUpload" CssClass="csstxtbox" Width="400px" runat="server" />
                </td>
                <td align="left" width="100">
                    <asp:Button ID="btnUpload1" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource, Upload %>" OnClick="btnUpload1_Click" />
                </td>
            </tr>
        </table>
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" Text="" CssClass="csslblErrMsg"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="700" border="0" align="center">
        <tr>
            <td>
                <div id="DivGridView" runat="server">
                            <div class="squareboxgradientcaption" style="height: 25px;">
                                        <asp:Label ID="Label23" runat="server" Text="<%$ Resources:Resource, DownloadInfo %>"></asp:Label>
                            </div>
                            <div>
                                <asp:GridView Width="650px" ID="gvEmployeeDocument" AllowPaging="True" CssClass="GridViewStyle"
                                    runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" AllowSorting="True"
                                    PageSize="6" OnRowDataBound="gvEmployeeDocument_RowDataBound" OnRowDeleting="gvEmployeeDocument_RowDeleting">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource, SerialNumber %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource, FileName %>" SortExpression="FileName">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbFileName" CssClass="csslink" runat="server" Text='<%# Bind("FileName") %>'
                                                    OnClick="lbFileName_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource, Description %>" SortExpression="UploadDesc">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text='<%# Bind("UploadDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource, Action %>">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
