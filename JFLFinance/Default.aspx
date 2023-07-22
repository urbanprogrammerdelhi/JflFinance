<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    Title="IFM 360" 
     %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--<link rel="Subsection" href="ifm.ico" type="image/x-icon" />--%>
    <link runat="server" rel="shortcut icon" href="~/ifm.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="~/ifm.ico" type="image/ico" />
    <link href="css/custom-style.css" rel="stylesheet" type="text/css"/>

    <%--<script type="text/javascript" language="javascript" src="~/javaScript/jquery-1.8.1.min.js"></script>--%>
    <script type="text/javascript" language="javascript" src="javaScript/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" language="javascript" src="PageJS/Default.js"></script>
    <title></title>
</head>
<body class="login-class" style="background-color:#2E6292;">
    <form id="form1" runat="server">

    <%--<p class="loginheader">FieldWeb</p>--%>
    <p class="loginheader"><asp:Label ID="lblSoftwareName" CssClass="cssLabelSoftwareName" runat="server" Visible="false"></asp:Label>
        <asp:Image ID="imgcmpy" runat="server" ImageUrl="~/Images/ifm.png" />
    </p>
    <div class="loginbox">
      
    <asp:TextBox ID="txtUserID" CssClass="cssLogintxtbox username" runat="server" placeholder="<%$ Resources:Resource, LoginID %>" oncopy="return false" onpaste="return false" oncut="return false" ></asp:TextBox>
    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="cssLogintxtbox password" runat="server" AutoPostBack="false" placeholder="<%$ Resources:Resource, Password %>" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>    
    <%--<asp:Label ID="Label1" CssClass="cssLoginLabel" runat="server" Text="<%$ Resources:Resource, SelectLanguage %>"></asp:Label>--%>
    <asp:DropDownList AutoPostBack="true" ID="ddllanguage" CssClass="cssDropDown dropdownlogin" onKeyUp="SomeKeyPressed(event)"
                runat="server" OnSelectedIndexChanged="ddllanguage_SelectedIndexChanged">
                <asp:ListItem Text="<%$Resources:Resource,DefaultLanguage %>" Value="<%$Resources:Resource,DefaultLanguageValue %>"></asp:ListItem>
                <%--<asp:ListItem Text="<%$Resources:Resource,FrenchLanguage %>" Value="<%$Resources:Resource,FrenchLanguageValue %>"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Resource,OtherLanguage %>" Value="<%$Resources:Resource,OtherLanguageValue %>"></asp:ListItem>--%>
                    <asp:ListItem Text="<%$Resources:Resource,ArabicLanguage %>" Value="<%$Resources:Resource,ArabicLanguageValue %>"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Resource,IsraelLanguage %>" Value="<%$Resources:Resource,IsraelLanguageValue %>"></asp:ListItem>
                <%--<asp:ListItem Text="<%$Resources:Resource,ChineseLanguage %>" Value="<%$Resources:Resource,ChineseLanguageValue %>"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Resource,SpanishLanguage %>" Value="<%$Resources:Resource,SpanishLanguageValue %>"></asp:ListItem>--%>
            </asp:DropDownList>
        <div style="padding-left:50px;">
            <BotDetect:Captcha ID="SampleCaptcha" runat="server"></BotDetect:Captcha>
        </div>
        <asp:textbox ID="CaptchaCodeTextBox" CssClass="cssLogintxtbox username" runat="server" placeholder="Captcha"></asp:textbox>
        <BotDetect:CaptchaValidator ID="SampleCaptchaValidator" 
        runat="server" ControlToValidate="CaptchaCodeTextBox" CaptchaControl="SampleCaptcha"
        ErrorMessage="Retype the characters exactly as they appear in the picture" 
        EnableClientScript="true" SetFocusOnError="true">Incorrect CAPTCHA code
      </BotDetect:CaptchaValidator>
        <br />
      <asp:Label ID="ValidationPassedLabel" runat="server" CssClass="correct" Visible="False" Text="Validation passed!" />
    </div>
    <div class="sigin"> <asp:Button ID="btnLogin" runat="server" CssClass="cssLoginButton" OnClick="btnLogin_onclick" Text="<%$ Resources:Resource, SineIN %>" />
                <br /><br /><a href="#" >FORGOT PASSWORD</a>
    </div>
        <div runat="server" id="DivDirection" dir='<%$Resources:Resource,TextDirection %>'>
            <br />
            <asp:Label style="display: block;text-align: center;color: red;font-weight:bold; opacity: 0.8;" ID="lbErrMsg" EnableViewState="false" CssClass="cssLoginErrorMsgLable" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbErrMsg1" EnableViewState="false" CssClass="cssLoginErrorMsgLable" runat="server" Text=""></asp:Label>
            <asp:Label ID="ScreenResolution" runat="server" Visible="false" />

            <p class="cssLoginFooterText">
            <asp:Label ID="lblSoftwareVersion" runat="server"></asp:Label>&nbsp;
            <asp:Label ID="lblRelease" runat="server"></asp:Label>&nbsp;
            <asp:ImageButton ID="ImgConfiguration" runat="server" Width="20px" Height="10px" style="cursor:default;" ImageUrl="~/Images/spacer.gif" onclick="ImgConfiguration_Click" />
            </p>
            <%--<asp:Label ID="Label2" CssClass="cssLoginLabel" runat="server" Text="<%$ Resources:Resource, Country %>"></asp:Label>--%>
            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="cssDropDown hide-obj"
                style="background-color:transparent; border:0; color:transparent; -webkit-appearance: none;-moz-appearance: none;">
            </asp:DropDownList>
            <p class="cssLoginFooterText">
              <%--  <asp:Literal runat="server" ID="LoginFooter1" Text="<%$ Resources:Resource, LoginFooter1 %>" /><br />
                <asp:Literal runat="server" ID="LoginFooter2" Text="<%$ Resources:Resource, LoginFooter2 %>" /><br />--%>
            </p>
        </div>

    </form>
    <script type="text/javascript">
        function SomeKeyPressed(e)
        {
            //alert(e.keyCode);
            //190 for .
            if (e.keyCode == 190)
            {
                //alert(document.getElementById('<%=ddlCountry.ClientID%>').options[document.getElementById('<%=ddlCountry.ClientID%>').selectedIndex].text);
                document.getElementById('<%=ddlCountry.ClientID%>').style.display = 'block';
            }
            
        }
    </script>
</body>
</html>
