<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shiftPattern.aspx.cs" Inherits="Transactions_shiftPattern" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Shift Pattern</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                    <asp:GridView ID="gvShiftPattern" runat="server" CssClass="gridView" AutoGenerateColumns="false"  >
                    <Columns>
                    <asp:TemplateField HeaderStyle-Width = "50px">
                         <HeaderTemplate>
                            <asp:Label ID="lblgvHdrPatternCode" runat="server" Text="patternCode" ></asp:Label>
                         </HeaderTemplate>
                         <ItemTemplate>
                             <asp:LinkButton ID="btnPatternCode" runat="server" CssClass="cssLinkButton" Text='<%# DataBinder.Eval(Container.DataItem, "shiftPatternCode")%>' ></asp:LinkButton>
                         </ItemTemplate>                    
                    </asp:TemplateField> 
                    <asp:TemplateField >
                         <HeaderTemplate>
                            <asp:Label ID="lblgvHdrPattern" runat="server" Text="Pattern" ></asp:Label>
                         </HeaderTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblPattern" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "shiftPattern")%>' ></asp:Label>
                         </ItemTemplate>                    
                    </asp:TemplateField>                    
                    </Columns>    
                    </asp:GridView>  
    </div>
    </form>
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
</body>
</html>
