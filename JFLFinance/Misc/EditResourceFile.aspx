<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditResourceFile.aspx.cs" Inherits="Misc_EditResourceFile" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="DivEdit">
        <asp:Label ID="Label1" runat="server"></asp:Label>:<asp:TextBox ID="txtResourceValue"
            runat="server"></asp:TextBox><br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
        <asp:Label ID="Label2" runat="server"></asp:Label><br />
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
