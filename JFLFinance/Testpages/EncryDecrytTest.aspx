<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="EncryDecrytTest.aspx.cs" Inherits="Testpages_EncryDecrytTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <table>
      <tr>
      <td>
      <asp:Label ID="lblKey" runat="server" Text="Enter The Key" />
      </td>
      <td>
       <asp:TextBox ID="txtKey" runat="server" ></asp:TextBox>
      
      </td>
      
      </tr>
      </table>
      
       <table>
       <tr>
       <td>
       <asp:Label ID="lblEncry" runat="server" Text="Enter String To Encrypt" />
       </td>
        <td>
        <asp:TextBox ID="txtEncry" runat="server" ></asp:TextBox>
        </td>
        <td>
         <asp:Label ID="lblEncryValue" runat="server" Text="Encrypted String" />
        </td>
        <td>
         <asp:TextBox ID="txtEncryValue" runat="server"></asp:TextBox>
        </td>
        </tr>
       <tr>
       <td>
       <asp:Label ID="lblDecry" runat="server" Text="Enter String To Decrypt" /> 
       </td>
       <td>
       <asp:TextBox ID="txtDecry" runat="server"></asp:TextBox>
       </td>
        <td>
       <asp:Label ID="lblDecryValue" runat="server" Text="Decrypted String" /> 
       </td>
       <td>
       <asp:TextBox ID="txtDecryValue" runat="server"></asp:TextBox>
       </td>
       </tr>
       <tr>
       <td colspan="2">
       <asp:Button ID="btnSubmit" runat="server" Text="EncryptString" onclick="btnSubmit_Click" />
       </td>
        <td colspan="2">
       <asp:Button ID="btnDecrypt" runat="server" Text="DecryptString" 
                onclick="btnDecrypt_Click" />
       </td>
      </tr> 
      </table> 
   
    
    </form>
</body>
</html>
