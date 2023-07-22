<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeDocumentMaster.aspx.cs" EnableViewState="true" Inherits="Masters_EmployeeDocumentMaster" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<script language="javascript" type="text/javascript">
        window.onload = function () {
            var fileUpload = document.getElementById("fileUpload");
            fileUpload.onchange = function () {
                if (typeof (FileReader) != "undefined") {
                    var dvPreview = document.getElementById("dvPreview");
                    dvPreview.innerHTML = "";

                    for (var i = 0; i < fileUpload.files.length; i++) {
                        var file = fileUpload.files[i];
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            var img = document.createElement("IMG");
                            img.height = "100";
                            img.width = "100";
                            img.src = e.target.result;
                            dvPreview.appendChild(img);
                        }
                        reader.readAsDataURL(file);

                    }
                } else {
                    alert("This browser does not support HTML5 FileReader.");
                }
            }
        };
    </script>--%>
    <br />
    <table align="center" width="900px" border="0" cellspacing="0px" cellpadding="0px">

        <tr>
            <td>
                <asp:Label ID="lblidno" runat="server" Text="ID Number" Font-Bold="true"></asp:Label>
            </td>

            <td>
                <asp:Label ID="Label1" runat="server" Text="Document Description" Font-Bold="true"></asp:Label>
            </td>


            <td>
                <asp:Label ID="Label2" runat="server" Text="Document Detail" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Is Verified" Font-Bold="true"></asp:Label>
            </td>

            <td></td>


        </tr>
        <tr>
            <td>
                <asp:Label ID="lblid" runat="server" Text="" ForeColor="Blue"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDocumentdesc" runat="server" CssClass="csstxtbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Rfvdesc" runat="server" ControlToValidate="txtDocumentdesc"
                    ErrorMessage="*" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:FileUpload ID="afuDocumentDetail" runat="server" AllowMultiple="true" />
            </td>
            <td>
                <asp:CheckBox ID="ckbItemIsverified" TextAlign="Left" runat="server" />
                <asp:HiddenField ID="PassportId" runat="server" Value="0" />
            </td>
            <td>
                <asp:Button ID="btnUploaddocument" Text='<%$ Resources:Resource, Upload%>' CssClass="cssButton" runat="server" ValidationGroup="Edit" OnClick="btnUploaddocument_Click" /><br />
                <asp:Label ID="lblGetdocs" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>

    </table>
    <br />
    <br />
    <asp:GridView Width="100%" ID="gvDocumentDetail" CssClass="GridViewStyle" runat="server" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
        AutoGenerateColumns="False" OnRowDataBound="gvDocumentDetail_RowDataBound" OnPageIndexChanging="gvDocumentDetail_PageIndexChanging" OnRowUpdating="gvDocumentDetail_RowUpdating" OnRowDeleting="gvDocumentDetail_RowDeleting">
        <FooterStyle CssClass="GridViewFooterStyle" />
        <RowStyle CssClass="GridViewRowStyle" />
        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
        <PagerStyle CssClass="GridViewPagerStyle" />
        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
        <HeaderStyle CssClass="GridViewHeaderStyle" />
        <Columns>
            <asp:TemplateField HeaderText="<%$ Resources:Resource,DocumentDescription %>">
                <ItemTemplate>
                    <asp:HiddenField ID="PassportId" runat="server" Value='<%#Bind("PassportId") %>' />
                    <asp:HiddenField ID="DocumentId" runat="server" Value='<%#Bind("DocumentId") %>' />
                    <asp:HiddenField ID="hfidnew" runat="server" Value='<%#Bind("IDNumber") %>' />
                    <asp:Label ID="DocumentDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("DocumentDesc") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                <ItemStyle Width="200px" />
                <FooterStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:Resource,DocumentDetail %>">
                <ItemTemplate>
                    <asp:Label ID="Label47" CssClass="cssLabel" runat="server" Text='<%# Bind("DocumentFileName") %>'></asp:Label>
                    <asp:ImageButton ID="lnkbtnUpload" runat="server" OnClick="lnkbtnUpload_Click" CommandArgument='<%# Eval("DocumentFileName") %>' ImageUrl="~/Images/downloaddoc.png"></asp:ImageButton>
                </ItemTemplate>
                <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                <ItemStyle Width="400px" />
                <FooterStyle Width="400px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources:Resource,IsVerified%>'>
                <ItemTemplate>
                    <asp:Label ID="lblverified" Text='<%# Bind("IsVerified") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources:Resource,EditColName%>'>
                <ItemTemplate>
                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/Delete.gif" ToolTip="<%$Resources:Resource,Delete %>" Height="20px" Width="20px" CommandName="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lbldocument" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
