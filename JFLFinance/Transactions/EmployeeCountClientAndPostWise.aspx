<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeCountClientAndPostWise.aspx.cs"
    Inherits="Transactions_EmployeeCountClientAndPostWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <script language ="javascript" type ="text/javascript" src="../javaScript/jquery-1.8.1.min.js"></script>
    <script language="javascript" src="../PageJS/EmployeeCountClientAndPostWise.js" type="text/javascript"></script>
</head>
<body onload="OnLoad();">
    <form id="form1" runat="server">
    <div>
        <Ajax:ScriptManager ID="script" runat="server" EnablePageMethods = "True">
            <Services>
                <Ajax:ServiceReference Path="../WebServices/WebMethods.asmx" />
            </Services>
        </Ajax:ScriptManager>
        <div style="width: 550;">
            <div class="squarebox">
                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;">
                    <div style="float: left; width: 100%">
                        <tt style="text-align: center;">
                            <asp:Label ID="Label15" CssClass="squareboxgradientcaption" runat="server" Text="Assignment Wise Total Hours"></asp:Label></tt></div>
                </div>
                <div class="squareboxcontent">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="90px">
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <span id="spanShowEmployeeCountClientAndPostWise" style="width: 100%; overflow: auto;"
                                        class="cssLable"></span>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <div style="width: 550;">
            <div class="squarebox">
                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;">
                    <div style="float: left; width: 100%">
                        <tt style="text-align: center;">
                            <asp:Label ID="Label1" CssClass="squareboxgradientcaption" runat="server" Text="Post Wise Total Employee Count"></asp:Label></tt></div>
                </div>
                <div class="squareboxcontent">
                 <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Height="150px">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <span id="spanEmployeeCount" style="width: 100%" class="cssLable"></span>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="HFAsmtCode" runat="server" />
        <asp:HiddenField ID="HFConnectionString" runat="server" />
        <asp:HiddenField ID="HFCompanyCode" runat="server" />
        <asp:HiddenField ID="HFHrLocationCode" runat="server" />
        <asp:HiddenField ID="HFLocationCode" runat="server" />
        <asp:HiddenField ID="HFFromDate" runat="server" />
        <asp:HiddenField ID="HFToDate" runat="server" />
        <asp:HiddenField ID="HFAttendanceType" runat="server" />
        <asp:HiddenField ID="HFPost" runat="server" />
        <asp:HiddenField ID="HFClientCode" runat="server" />
    </div>
    </form>

<script language="javascript" type="text/javascript">
    function ControlInitializer() {
        this.DateRange = "<%= Resources.Resource.Date %>";
        this.Total = '<%= Resources.Resource.Total %>';
        this.HFAsmtCode = document.getElementById("<% =HFAsmtCode.ClientID %>");
        this.HFPost = document.getElementById('<%=HFPost.ClientID %>');
        this.HFConnectionString = document.getElementById('<%= HFConnectionString.ClientID %>');
        this.HFCompanyCode = document.getElementById('<%= HFCompanyCode.ClientID %>');
        this.HFHrLocationCode = document.getElementById('<%= HFHrLocationCode.ClientID %>');
        this.HFLocationCode = document.getElementById('<%= HFLocationCode.ClientID %>');
        this.HFAttendanceType = document.getElementById('<%= HFAttendanceType.ClientID %>');
        this.HFFromDate = document.getElementById('<%= HFFromDate.ClientID %>');
        this.HFToDate = document.getElementById('<%= HFToDate.ClientID %>');
        this.HFClientCode = document.getElementById('<%= HFClientCode.ClientID %>');
        this.spanShowEmployeeCountClientAndPostWise = document.getElementById('spanShowEmployeeCountClientAndPostWise');
        this.spanEmployeeCount = document.getElementById('spanEmployeeCount');
    }
    </script>    
</body>
</html>
