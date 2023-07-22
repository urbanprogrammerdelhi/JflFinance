<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="BulkInvoiceAuthorisation.aspx.cs" Inherits="Invoice_BulkInvoiceAuthorisation"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/jscript">
var oldgridSelectedColor;
var newgridSelectedColor = '#7ca8d3';
function CheckUncheckAllLoc(ObjCheckBox, ObjNameToCheck)
{
    var frm = document.aspnetForm;
    var ChkState=ObjCheckBox.checked;
    
    var objCell = ObjCheckBox.parentElement.parentElement;
    var objRow = objCell.parentElement;
    var objTable = objRow.parentElement.parentElement;
    
    var mycolor;
    if (ObjCheckBox.checked == true) 
    {
        oldgridSelectedColor = objCell.style.backgroundColor;
        mycolor = newgridSelectedColor;
    }
    else
    {
        mycolor = oldgridSelectedColor;
    }
    
    for(i=0; i< frm.length;i++)
    {
        e = frm.elements[i];
        if(e.type=='checkbox' && e.name.indexOf(ObjNameToCheck) != -1 && e.disabled == false)
        {
            e.checked= ChkState ;
            e.parentElement.parentElement.style.backgroundColor=mycolor;
        }
    }
}
function CheckUncheckCB(ObjCheckBox)
{ 
    var mycolor;
    if (ObjCheckBox.checked == false) 
    {
        mycolor = oldgridSelectedColor;
        ObjCheckBox.parentElement.parentElement.style.backgroundColor = mycolor;
    }
    else
    {
        oldgridSelectedColor = ObjCheckBox.parentElement.parentElement.style.backgroundColor;
        mycolor = newgridSelectedColor;
        ObjCheckBox.parentElement.parentElement.style.backgroundColor = mycolor;
    }
}
    </script>

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 950px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left;width:930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label3" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, BulkInvoiceAuthorise %>"></asp:Label></tt></div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblClient" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:DropDownList CssClass="cssDropDown" Width="300px" ID="ddlClientCode" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInvoiceType" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, InvoiceType %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlInvoiceType" Width="152px" runat="server" CssClass="cssDropDown">
                                                </asp:DropDownList>
                                            </td>
                                            <tr>
                                                <tr>
                                                    <td align="right" style="width: 200px">
                                                        <asp:Label ID="lblInvDateFrom" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, PostDateFrom %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 150px">
                                                        <asp:TextBox Width="80px" ID="txtPostFromDate" CssClass="csstxtboxRequired" runat="server"
                                                            AutoPostBack="true" OnTextChanged="txtPostFromDate_TextChanged"></asp:TextBox><asp:HyperLink
                                                                Style="vertical-align: top;" ID="HlimgInvoiceDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                        <asp:RequiredFieldValidator ID="rfvPostFromDate" ValidationGroup="vgCEdit" ControlToValidate="txtPostFromDate"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblInvDateTo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, PostDateTo %>"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox Width="80px" ID="txtPostToDate" CssClass="csstxtboxRequired" MaxLength="16"
                                                            runat="server"></asp:TextBox><asp:HyperLink Style="vertical-align: top;" ID="HlimgPeriodFrom"
                                                                runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                        <asp:RequiredFieldValidator ID="rfvPostToDate" ValidationGroup="vgCEdit" ControlToValidate="txtPostToDate"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblUnAuthorizedInvoiceNet" CssClass="cssLableRequired" runat="server"
                                                            Text="<%$ Resources:Resource, UnauthorizedInvoiceNet %>"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox Width="80px" ID="txtUnAuthorizedInvoiceNet" CssClass="csstxtbox" runat="server"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="4">
                                                        <asp:Button ID="btnProceed" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Proceed %>"
                                                            OnClick="btnProceed_Click" />
                                                        <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, btnAuthorize %>"
                                                            OnClick="btnAuthorize_Click" />
                                                        <%-- <asp:Button ID="btnBack" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, Invoice %>" Text=" <%$ Resources:Resource, BtnBack %>" OnClick="btnBack_Click" />--%>
                                                    </td>
                                                </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <Ajax:UpdatePanel runat="server" ID="upError" UpdateMode="Always">
                    <ContentTemplate>
                        <div id="divErrorMsg" style="width: 550px; height: 50px; position: absolute; left: 30%;
                            top: 40%; background-color: Transparent;">
                            <asp:Label Style="border-color: Red; border-width: 2px; border-style: solid; background-color: white;
                                z-index: 100;" EnableViewState="false" ID="lblErrorMsg" Text="" runat="server"
                                CssClass="csslblErrMsg" onclick="javascript:this.style.display = 'none';"></asp:Label>
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 950px;">
                <div class="squarebox">
                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                        <div style="float: left;width:930px;">
                            <tt style="text-align: center;">
                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, BulkInvoiceListForAuthorize %>"></asp:Label></tt></div>
                    </div>
                    <div class="squareboxcontent">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:GridView Width="900px" ID="gvBulkInvoiceDetails" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="False" CellPadding="0"
                                        GridLines="None" AutoGenerateColumns="false">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cbAllSelect" runat="server" AutoPostBack="true" OnCheckedChanged="cbAllSelect_CheckedChanged"
                                                        CssClass="cssCheckBox" Text="<%$ Resources:Resource, SelectAll %>" onclick="javascript:CheckUncheckAllLoc(this,'cbSelect');" />
                                                    <%--  <asp:Label ID="lblClientCode" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbSelect" CssClass="cssCheckBox" runat="server" AutoPostBack="true"
                                                        OnCheckedChanged="cbSelect_CheckedChanged" Checked="false" onclick="javascript:CheckUncheckCB(this);" />
                                                    <%-- <asp:Label ID="lblClientCode" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>' CssClass="cssLable" runat="server"></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblClientCode" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientCode" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblClientName" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrInvoiceNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, InvoiceNo %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceNo" Text='<%# DataBinder.Eval(Container.DataItem, "InvoiceNo").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrSoNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SoNo %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSoNo" Text='<%# DataBinder.Eval(Container.DataItem, "SoNo").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblInvoiceNetAmount" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, InvoiceNetAmt %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceNetAmount" Text='<%# DataBinder.Eval(Container.DataItem, "GrandTotal").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblInvoiceStatus" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Status %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceStatus" Text='<%# DataBinder.Eval(Container.DataItem, "Status").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceNet" Text='<%# DataBinder.Eval(Container.DataItem, "Net").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <Ajax:AsyncPostBackTrigger ControlID="btnProceed" EventName="Click" />
            <Ajax:AsyncPostBackTrigger ControlID="btnAuthorize" EventName="Click" />
        </Triggers>
    </Ajax:UpdatePanel>
</asp:Content>
