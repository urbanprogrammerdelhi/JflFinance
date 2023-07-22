<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testService.aspx.cs" Inherits="testService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:FileUpload ID="afuDocumentDetailPurchase" runat="server" />
          <asp:Button ID="btnUploaddocument" Text='<%$ Resources:Resource, Upload%>' CssClass="cssButton" runat="server" OnClick="btnUploaddocument_Click"  /><br />
    </div>
    </form>
</body>
</html>
