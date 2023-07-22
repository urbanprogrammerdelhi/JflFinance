<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="EncryptDecrypt_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <BotDetect:Captcha ID="SampleCaptcha" runat="server"></BotDetect:Captcha>
        <asp:textbox ID="CaptchaCodeTextBox" runat="server"></asp:textbox>
    </div>
    </form>
</body>
</html>
