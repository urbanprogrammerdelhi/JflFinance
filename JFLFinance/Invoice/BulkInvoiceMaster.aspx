<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="BulkInvoiceMaster.aspx.cs" Inherits="Invoice_BulkInvoiceMaster" Title="<%$ Resources:Resource, AppTitle %>" %>

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
function HideButton()
    {
        document.getElementById('<%=btnGenerateInvoices.ClientID %>').style.display='none'
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
                                    <div style="float: left; width: 930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, BulkInvoicing %>"></asp:Label></tt></div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="0" cellspacing="0" width="950px">
                                        <tr>
                                            <td align="right" style="width: 100px">
                                                <asp:Label ID="lblfixInvDate" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, InvoiceDate %>"></asp:Label>
                                            </td>
                                            <td align="left" style="width: 120px">
                                                <asp:TextBox Width="80px" ID="txtInvoiceDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox><asp:HyperLink
                                                    Style="vertical-align: top;" ID="HlimgInvoiceDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                <asp:RequiredFieldValidator ID="rfvInvDate" ValidationGroup="vgCEdit" ControlToValidate="txtInvoiceDate"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInvPeriodFrom" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, PeriodFrom %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="80px" ID="txtPeriodFrom" CssClass="csstxtboxRequired" MaxLength="16"
                                                    runat="server"></asp:TextBox><asp:HyperLink Style="vertical-align: top;" ID="HlimgPeriodFrom"
                                                        runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                <asp:RequiredFieldValidator ID="rfvPeriodFrom" ValidationGroup="vgCEdit" ControlToValidate="txtPeriodFrom"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInvPeriodTo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, PeriodTo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="80px" ID="txtPeriodTo" CssClass="csstxtboxRequired" MaxLength="16"
                                                    runat="server"></asp:TextBox><asp:HyperLink Style="vertical-align: top;" ID="HlimgPeriodTo"
                                                        runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                <asp:RequiredFieldValidator ID="rfvPeriodTo" ValidationGroup="vgCEdit" ControlToValidate="txtPeriodTo"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblPostDate" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, PostingDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="80px" ID="txtpostingDate" CssClass="csstxtboxRequired" MaxLength="16"
                                                    runat="server"></asp:TextBox><asp:HyperLink Style="vertical-align: top;" ID="HlimgPostDate"
                                                        runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                <asp:RequiredFieldValidator ID="rfvPostDate" ValidationGroup="vgCEdit" ControlToValidate="txtpostingDate"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblClient" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:DropDownList CssClass="cssDropDown" Width="350px" ID="ddlClientCode" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblfixSOType" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, SOType %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList CssClass="cssDropDown" Width="100px" ID="ddlSoType" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInvoiceType" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, BillingPattern %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlInvoiceType" Width="130px" runat="server" CssClass="cssDropDown">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRemarks" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox Width="348px" CssClass="csstxtbox" ID="txtRemarks" MaxLength="200" runat="server"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTax" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, Tax %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="100px" ID="txtTax" CssClass="csstxtboxRequired" MaxLength="16"
                                                    runat="server"></asp:TextBox><b>%</b>
                                                <asp:RequiredFieldValidator ID="rfvtxtTax" ControlToValidate="txtTax" runat="server"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="8" style="height: 5px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="8" style="height: 1px; background-color: Silver;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="8" style="height: 5px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="8">
                                                <asp:Button ID="btnProceed" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Proceed %>"
                                                    OnClick="btnProceed_Click" />
                                                <asp:Button ID="btnGenerateInvoices" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, GenerateInvoices %>"
                                                    OnClick="btnGenerateInvoices_Click" OnClientClick="javascript:HideButton();" />
                                                <asp:Button ID="btnBack" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, BtnBack %>"
                                                    Text=" <%$ Resources:Resource, BtnBack %>" OnClick="btnBack_Click" />
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
                                z-index: 100;" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"
                                onclick="javascript:this.style.display = 'none';"></asp:Label>
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
                        <div style="float: left; width: 930px;">
                            <tt style="text-align: center;">
                                <asp:Label ID="Label3" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, BulkInvoicing %>"></asp:Label></tt></div>
                    </div>
                    <div class="squareboxcontent">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 95%">
                            <tr>
                                <td>
                                    <asp:GridView Width="900px" ID="gvSoDetails" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="false" PageSize="8"
                                        CellPadding="0" GridLines="None" AutoGenerateColumns="false" OnRowDataBound="gvSoDetails_RowDataBound"
                                        OnPageIndexChanging="gvSoDetails_PageIndexChanging">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cbAllSelect" ReadOnly="True" runat="server" AutoPostBack="true"
                                                        CssClass="cssCheckBox" Text="<%$ Resources:Resource, SelectAll %>" OnCheckedChanged="cbAllSelect_CheckedChanged"
                                                        onclick="javascript:CheckUncheckAllLoc(this,'cbSelect');" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbSelect" AutoPostBack="true" ReadOnly="True" CssClass="cssCheckBox"
                                                        runat="server" Checked="false" OnCheckedChanged="cbSelect_CheckedChanged" onclick="javascript:CheckUncheckCB(this);" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrClientCode" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientCode" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrClientName" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'
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
                                                    <asp:Label ID="lblgvhdrRemarks" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvInvNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, InvoiceNo %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--  <asp:Label ID="lblInvNo" Text='<%# DataBinder.Eval(Container.DataItem, "InvoiceNo").ToString()%>' CssClass="cssLable" runat="server"></asp:Label>--%>
                                                    <asp:LinkButton ID="lbtnInvoiceNo" Text='<%# DataBinder.Eval(Container.DataItem, "InvoiceNo").ToString()%>'
                                                        CssClass="csslnkButton" runat="server" OnClick="lbtnInvoiceNo1_Click1"> </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView Width="900px" ID="gvBulkInvoiceDetails" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="true" ShowHeader="true" Visible="False" AllowPaging="False" CellPadding="0"
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
                                                    <asp:Label ID="lblgvhdrBulkInvoiceCode" CssClass="cssLabelGVHeader" runat="server"
                                                        Text="<%$ Resources:Resource, BulkInvoiceCode %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBulkInvoiceCode" Text='<%# DataBinder.Eval(Container.DataItem, "BulkInvoiceCode").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrClientCode" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientCode" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'
                                                        CssClass="cssLable" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrClientName" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'
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
                                                    <asp:Label ID="lblgvhdrInvoiceNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, InvoiceNo %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%-- <asp:Label ID="lblInvoiceNo" Text='<%# DataBinder.Eval(Container.DataItem, "InvoiceNo").ToString()%>' CssClass="cssLable" runat="server"></asp:Label>--%>
                                                    <asp:LinkButton ID="lbtnInvoiceNo" Text='<%# DataBinder.Eval(Container.DataItem, "InvoiceNo").ToString()%>'
                                                        CssClass="csslnkButton" runat="server" OnClick="lbtnInvoiceNo_Click"> </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrRemarks" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks").ToString()%>'
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
            <Ajax:AsyncPostBackTrigger ControlID="btnGenerateInvoices" EventName="Click" />
        </Triggers>
    </Ajax:UpdatePanel>
</asp:Content>