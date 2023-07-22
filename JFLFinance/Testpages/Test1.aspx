<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test1.aspx.cs" Inherits="Testpages_Test1" %>
<%@ Register Assembly="DropCheck" Namespace="xMilk" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:DropCheck ID="ddlDivision" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
        TransitionalMode="True" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_Changed">
        </cc1:DropCheck>


        <cc1:DropCheck ID="ddlBranch" runat="server" MaxDropDownHeight="200"
        TransitionalMode="True" Width="800px">
        </cc1:DropCheck>
    </div>
    </form>
</body>
</html>
