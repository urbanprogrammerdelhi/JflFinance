<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllControl.aspx.cs" Inherits="Testpages_AllControl" MasterPageFile="~/MasterPage/MasterPage.master"  %>
<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>
<%--<body>--%>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <form id="form1" runat="server">
    <div>
    
    
    </div>--%>
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
     <ContentTemplate>
    
    
     <asp:TextBox ID="txtEmployeeNumber" runat="server" Text="12345"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:Button ID="Button2" runat="server" Text="Button" />
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server">
    <asp:ListItem Text="" Value="0"></asp:ListItem>
    </asp:DropDownList>
    <asp:ImageButton ID="ImageButton1" runat="server" />
    <asp:TextBox ID="txtFirstName" runat="server" Text="" ForeColor="Red" BackColor=AliceBlue ></asp:TextBox>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
   
    <asp:FileUpload ID="FileUpload1" runat="server" />

       </ContentTemplate>
                </Ajax:UpdatePanel>
   <%-- </form>--%>
    </asp:Content>
<%--</body>
</html>--%>
