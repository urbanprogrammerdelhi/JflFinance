<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KPI.aspx.cs" Inherits="Testpages_KPI" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            WaitControlDisplayAfter="200" InteractiveDeviceInfos="(Collection)" ProcessingMode="Remote"
            Height="970px" AsyncRendering="false" InteractivityPostBackMode="AlwaysSynchronous"
            KeepSessionAlive="true" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
            Width="1260px" Visible="false" ViewStateMode="Enabled" PageCountMode="Actual">
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
