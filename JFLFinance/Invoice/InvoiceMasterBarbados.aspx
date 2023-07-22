<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="InvoiceMasterBarbados.aspx.cs" Inherits="Sales_InvoiceMasterBarbados"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 950px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 931px;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="height: 12px; width: 33%">
                                                </td>
                                                <td style="height: 12px; width: 33%" align="center">
                                                    <asp:Label ID="lblDivHdr1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Invoice %>"></asp:Label>
                                                </td>
                                                <td style="height: 12px; width: 33%" align="right">
                                                    <asp:Label Width="130px" ID="lblfixInvStatus" CssClass="cssLabelHeader" runat="server"
                                                        Text="<%$ Resources:Resource, InvoiceStatus %>"></asp:Label>
                                                    <asp:Label Width="130px" Style="font-weight: bold;" ID="lblInvStatus" CssClass="csstxtboxReadonly"
                                                        runat="server"></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hfInvStatus" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="right" style="width: 120px">
                                                <asp:Label ID="lblfixInvNo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, InvoiceNo %>"></asp:Label>
                                            </td>
                                            <td align="left" style="width: 150px">
                                                <asp:TextBox Width="125px" ID="txtInvNo" AutoPostBack="true" CssClass="csstxtboxReadonly"
                                                    MaxLength="32" runat="server" OnTextChanged="txtInvNo_TextChanged"></asp:TextBox><asp:ImageButton
                                                        Width="18px" Height="16px" ID="ImgBtnSearchInv" ImageUrl="../Images/icosearch.gif"
                                                        runat="server" />
                                            </td>
                                            <td align="right" style="width: 120px">
                                                <asp:Label ID="lblfixInvDate" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, InvoiceDate %>"></asp:Label>
                                            </td>
                                            <td align="left" style="width: 120px">
                                                <asp:TextBox Width="80px" ID="txtInvoiceDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="txtInvoiceDate_CalendarExtender" runat="server"
                                                    Enabled="True" FirstDayOfWeek="Monday" Format="dd-MMM-yyyy" TargetControlID="txtInvoiceDate">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvInvDate" ValidationGroup="vgCEdit" ControlToValidate="txtInvoiceDate"
                                                    runat="server" Text="*" ErrorMessage="Invoice Date Required"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInvPeriodFrom" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, PeriodFrom %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="80px" ID="txtPeriodFrom" CssClass="csstxtboxRequired" MaxLength="16"
                                                    runat="server"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="txtPeriodFrom_CalendarExtender" runat="server"
                                                    Enabled="True" FirstDayOfWeek="Monday" Format="dd-MMM-yyyy" TargetControlID="txtPeriodFrom">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvPeriodFrom" ValidationGroup="vgCEdit" ControlToValidate="txtPeriodFrom"
                                                    runat="server" Text="*" ErrorMessage="Period From Required"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInvPeriodTo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, PeriodTo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="80px" ID="txtPeriodTo" CssClass="csstxtboxRequired" MaxLength="16"
                                                    runat="server"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="txtPeriodTo_CalendarExtender" runat="server" Enabled="True"
                                                    FirstDayOfWeek="Monday" Format="dd-MMM-yyyy" TargetControlID="txtPeriodTo">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvPeriodTo" ValidationGroup="vgCEdit" ControlToValidate="txtPeriodTo"
                                                    runat="server" Text="*" ErrorMessage="Period To Required"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblfixClientCode" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="150px" ID="txtClientCode" CssClass="csstxtboxReadonly" MaxLength="16"
                                                    runat="server" OnTextChanged="txtClientCode_TextChanged"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblfixClientName" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="5">
                                                <asp:TextBox Width="498px" ID="txtClientName" CssClass="csstxtboxReadonly" ReadOnly="true"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblSONo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, SONO %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="150px" ID="txtSoNo" CssClass="csstxtboxReadonly" MaxLength="16"
                                                    runat="server" OnTextChanged="txtSoNo_TextChanged"></asp:TextBox>
                                                <td align="right">
                                                    <asp:Label ID="lblBillingID" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, BillingID %>"></asp:Label>
                                                </td>
                                                <td align="left" colspan="5">
                                                    <asp:TextBox Width="80px" ID="txtBillingID" CssClass="csstxtboxReadonly" ReadOnly="true"
                                                        runat="server"></asp:TextBox><asp:TextBox Width="415px" ID="txtBillingAddress" CssClass="csstxtboxReadonly"
                                                            ReadOnly="true" runat="server"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblInvoiceType" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, InvoiceType %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlInvoiceType" Width="152px" CssClass="cssDropDown" runat="server">
                                                    <asp:ListItem Text="<%$Resources:Resource,InvTypFixed%>" Value="FIXED"></asp:ListItem>
                                                    <asp:ListItem Text="<%$Resources:Resource,InvTypActual%>" Value="ACTUAL"></asp:ListItem>
                                                    <asp:ListItem Text="<%$Resources:Resource,InvTypActualDaysInMonth%>" Value="ACTUAL DAYS IN MONTH"></asp:ListItem>
                                                    <asp:ListItem Text="<%$Resources:Resource,InvTypAsPerSchedule%>" Value="AS PER SCHEDULE"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblPostingDate" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, PostingDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox Width="80px" ID="txtPostingDate" CssClass="csstxtboxRequired" MaxLength="16"
                                                    runat="server"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="txtPostingDate_CalendarExtender" runat="server"
                                                    Enabled="True" FirstDayOfWeek="Monday" Format="dd-MMM-yyyy" TargetControlID="txtPostingDate">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="vgCSave"
                                                    ControlToValidate="txtPostingDate" runat="server" Text="*" ErrorMessage="Posting Date Required"
                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblRemarks" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox Width="300px" CssClass="csstxtbox" ID="txtRemarks" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="height: 1px; background-color: Gray;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="8">
                                                <asp:Button ID="btnProceed" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Proceed %>"
                                                    OnClick="btnProceed_Click" />
                                                <asp:Button ID="btnSave" runat="server" ValidationGroup="vgCSave" CssClass="cssButton"
                                                    Text="<%$ Resources:Resource, Save %>" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Update %>"
                                                    OnClick="btnUpdate_Click" ValidationGroup="vgCSave" />
                                                <asp:Button ID="btnRefetch" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Refetch %>"
                                                    OnClick="btnRefetch_Click" />
                                                <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Delete%>"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnReversal" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, btnReversal %>"
                                                    OnClick="btnReversal_Click" />
                                                <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, btnAuthorize %>"
                                                    OnClick="btnAuthorize_Click" />
                                                <asp:Button ID="btnViewReport" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, ViewReport %>"
                                                    OnClick="btnViewReport_Click" />
                                                <asp:Button ID="btnBack" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, Invoice %>"
                                                    Text=" <%$ Resources:Resource, BtnBack %>" OnClick="btnBack_Click" />
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vgCSave"
                                                    ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
                                                <asp:HiddenField ID="HFTerminationDate" runat="server" />
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
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                    <ContentTemplate>
                        <div style="width: 1000px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 930px;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="height: 12px; width: 33%">
                                                </td>
                                                <td style="height: 12px; width: 33%" align="center">
                                                    <asp:Label ID="lblDivHdr2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SaleOrderLines %>"></asp:Label>
                                                </td>
                                                <td style="height: 12px; width: 33%" align="right">
                                                    <asp:Label Width="130px" Style="text-align: right" ID="lblFixSOLineTotalValue" CssClass="cssLabelHeader"
                                                        runat="server" Text="<%$ Resources:Resource, TotalValue %>"></asp:Label>
                                                    <asp:Label Width="130px" Style="text-align: right; font-weight: bold;" ID="lblSOLineTotalValue"
                                                        CssClass="csstxtboxReadonly" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="left">
                                                <asp:GridView Width="950px" ID="gvSaleOrderDetails" CssClass="GridViewStyle" runat="server"
                                                    ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="False" CellPadding="0"
                                                    GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvSaleOrderDetails_RowCommand"
                                                    OnRowEditing="gvSaleOrderDetails_RowEditing" OnRowCancelingEdit="gvSaleOrderDetails_RowCancelingEdit"
                                                    OnRowDataBound="gvSaleOrderDetails_RowDataBound" OnRowUpdating="gvSaleOrderDetails_RowUpdating">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField FooterStyle-Width="75px" HeaderStyle-Width="75px" ItemStyle-Width="75px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblaction" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnDelete" Visible="false" runat="server" CssClass="cssImgButton"
                                                                    CommandName="Delete" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                    ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                    ValidationGroup="vgCEdit1" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                    ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                    ToolTip="<%$ Resources:Resource, AddNew %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSOAmendNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SOAmendNo %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSOAmendNO" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOAmendNo").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblgvSOAmendNO" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOAmendNo").ToString()%>'></asp:Label>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSOLineNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SOLineNo %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSOLineNO" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOLineNo").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblgvSOLineNO" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOLineNo").ToString()%>'></asp:Label>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="75px" HeaderStyle-Width="75px" ItemStyle-Width="75px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrAsmtId" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, AsmtId %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'></asp:Label>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="110px" HeaderStyle-Width="110px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrBillingDesignation" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, BillingDesignation %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvBillingDesignation" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BillingDesignation").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="90px" ID="txtBillingDesignation" CssClass="csstxtboxRequired"
                                                                    MaxLength="50" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BillingDesignation").ToString()%>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvBillingDesignation" ValidationGroup="vgCEdit"
                                                                    ControlToValidate="txtBillingDesignation" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="90px" ID="txtBillingDesignation" CssClass="csstxtboxRequired"
                                                                    MaxLength="70" runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvBillingDesignation" ValidationGroup="vgCFooter"
                                                                    ControlToValidate="txtBillingDesignation" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="45px" HeaderStyle-Width="45px" ItemStyle-Width="45px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrNoOfPost" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, NoOfPost %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvNoOfPost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfPost").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="45px" ID="txtNoOfPost" CssClass="csstxtboxRequired" MaxLength="4"
                                                                    runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfPost").ToString()%>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvNoOfPost" ValidationGroup="vgCEdit" ControlToValidate="txtNoOfPost"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator runat="server" Type="Integer" ID="rvNoOfPost" ValidationGroup="vgCEdit"
                                                                    ControlToValidate="txtNoOfPost" MinimumValue="1" MaximumValue="9999" ErrorMessage="*"></asp:RangeValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="45px" ID="txtNoOfPost" CssClass="csstxtboxRequired" MaxLength="4"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvNoOfPost" ValidationGroup="vgCFooter" ControlToValidate="txtNoOfPost"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator runat="server" Type="Integer" ID="rvNoOfPost" ValidationGroup="vgCEdit"
                                                                    ControlToValidate="txtNoOfPost" MinimumValue="1" MaximumValue="9999" ErrorMessage="*"></asp:RangeValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="45px" HeaderStyle-Width="45px" ItemStyle-Width="45px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrHours" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Hours %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHours" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hours").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="45px" ID="txtHours" CssClass="csstxtboxRequired" MaxLength="6"
                                                                    runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hours").ToString()%>'></asp:TextBox>
                                                                <asp:HiddenField runat="server" ID="hfSellingPrice" Value='<%# DataBinder.Eval(Container.DataItem, "SellingPrice").ToString()%>' />
                                                                <asp:HiddenField runat="server" ID="HFRowNumber" Value='<%# DataBinder.Eval(Container.DataItem, "RowNumber").ToString()%>' />
                                                                <asp:RequiredFieldValidator ID="rfvHours" ValidationGroup="vgCEdit" ControlToValidate="txtHours"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator runat="server" Type="Double" ID="rvHours" ValidationGroup="vgCEdit"
                                                                    ControlToValidate="txtHours" MinimumValue="1.00" MaximumValue="24.00" ErrorMessage="*"></asp:RangeValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="45px" ID="txtHours" CssClass="csstxtboxRequired" MaxLength="6"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvHours" ValidationGroup="vgCFooter" ControlToValidate="txtHours"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator runat="server" Type="Double" ID="rvHours" ValidationGroup="vgCFooter"
                                                                    ControlToValidate="txtHours" MinimumValue="1.00" MaximumValue="24.00" ErrorMessage="*"></asp:RangeValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="80px" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSellingPrice" CssClass="cssLabelHeader" runat="server" Text="Selling Price"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:HiddenField runat="server" ID="hfSellingPrice" Value='<%# DataBinder.Eval(Container.DataItem, "SellingPrice").ToString()%>' />
                                                                <asp:Label ID="lblgvSellingPrice" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:n3}", DataBinder.Eval(Container.DataItem, "SellingPrice"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="70px" ID="txtSellingPrice" CssClass="csstxtboxReadonly" MaxLength="10"
                                                                    runat="server" Text='<%# String.Format("{0:n3}",DataBinder.Eval(Container.DataItem, "SellingPrice"))%>'></asp:TextBox>
                                                                <%--  <asp:HiddenField runat="server" ID="hfSellingPrice" Value='<%# DataBinder.Eval(Container.DataItem, "SellingPrice").ToString()%>' />--%>
                                                                <asp:RequiredFieldValidator ID="rfvSellingPrice" ValidationGroup="vgCEdit" ControlToValidate="txtSellingPrice"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="60px" ID="txtSellingPrice" CssClass="csstxtboxReadonly" MaxLength="10"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvSellingPrice" ValidationGroup="vgCFooter" ControlToValidate="txtSellingPrice"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="70px" HeaderStyle-Width="70px" ItemStyle-Width="70px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrDaysInMonth" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DaysInMonth %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvDaysInMonth" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DaysInMonth").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="60px" ID="txtDaysInMonth" CssClass="csstxtboxRequired" MaxLength="5"
                                                                    AutoPostBack="true" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DaysInMonth").ToString()%>'
                                                                    OnTextChanged="txtDaysInMonth_TextChangedET"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvDaysInMonth" ValidationGroup="vgCEdit" ControlToValidate="txtDaysInMonth"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <%--<asp:RangeValidator runat="server" Type="Double" ID="rvDaysInMonth" ValidationGroup="vgCEdit" ControlToValidate="txtDaysInMonth" MinimumValue="1.00" MaximumValue="31.00" ErrorMessage="*"></asp:RangeValidator>--%>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="60px" ID="txtDaysInMonth" CssClass="csstxtboxRequired" MaxLength="5"
                                                                    AutoPostBack="true" runat="server" OnTextChanged="txtDaysInMonth_TextChangedFT"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvDaysInMonth" ValidationGroup="vgCFooter" ControlToValidate="txtDaysInMonth"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <%--<asp:RangeValidator runat="server" Type="Double" ID="rvDaysInMonth" ValidationGroup="vgCFooter" ControlToValidate="txtDaysInMonth" MinimumValue="1.00" MaximumValue="31.00" ErrorMessage="*"></asp:RangeValidator>--%>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="70px" HeaderStyle-Width="70px" ItemStyle-Width="70px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrHoursInMonth" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, HoursInMonth %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHoursInMonth" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursInMonth").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="70px" ID="txtHoursInMonth" CssClass="csstxtboxReadonly" MaxLength="10"
                                                                    runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursInMonth").ToString()%>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvHoursInMonth" ValidationGroup="vgCEdit" ControlToValidate="txtHoursInMonth"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="70px" ID="txtHoursInMonth" CssClass="csstxtboxReadonly" MaxLength="10"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvHoursInMonth" ValidationGroup="vgCFooter" ControlToValidate="txtHoursInMonth"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="80px" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrOtherAllowances" CssClass="cssLabelGVHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, OtherAllowances %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvOtherAllowances" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:n3}",Eval("OtherAllowances")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="70px" ID="txtOtherAllowances" CssClass="csstxtbox" MaxLength="50"
                                                                    runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OtherAllowances").ToString()%>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvOtherAllowances" ValidationGroup="vgCEdit" ControlToValidate="txtOtherAllowances"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="70px" ID="txtOtherAllowances" CssClass="csstxtbox" MaxLength="50"
                                                                    Text="0" runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvOtherAllowances" ValidationGroup="vgCFooter" ControlToValidate="txtOtherAllowances"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="80px" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrMonthlyBilling" Width="70px" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, MonthlyBilling %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvMonthlyBilling" Width="70px" CssClass="cssLable" runat="server"
                                                                    Text='<%# String.Format("{0:n3}",Eval("MonthlyBilling")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="70px" ID="txtMonthlyBilling" CssClass="csstxtboxReadonly" MaxLength="15"
                                                                    runat="server" Text='<%# String.Format("{0:n3}",Eval("MonthlyBilling")) %>'></asp:TextBox>
                                                                <asp:HiddenField runat="server" ID="hfRatePerHour" Value='<%# String.Format("{0:n3}",Eval("ChargeRatePerHour")) %>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="70px" ID="txtMonthlyBilling" CssClass="csstxtboxReadonly" MaxLength="15"
                                                                    runat="server"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="80px" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrChargeRatePerHr" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, SellingPrice %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:HiddenField runat="server" ID="hfRatePerHour" Value='<%# String.Format("{0:n3}",Eval("ChargeRatePerHour")) %>' />
                                                                <asp:Label ID="lblgvChargeRatePerHr" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:n3}",Eval("ChargeRatePerHour")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="70px" ID="txtChargeRatePerHr" CssClass="csstxtboxReadonly" MaxLength="10"
                                                                    runat="server" Text='<%# String.Format("{0:n3}",Eval("ChargeRatePerHour")) %>'></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvChargeRatePerHr" ValidationGroup="vgCEdit" ControlToValidate="txtChargeRatePerHr"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="70px" ID="txtChargeRatePerHr" CssClass="csstxtboxReadonly" MaxLength="10"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvChargeRatePerHr" ValidationGroup="vgCFooter" ControlToValidate="txtChargeRatePerHr"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrActualDaysInMonth" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, DaysInMonth %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvActualDaysInMonth" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActualDaysInMonth").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrActualHoursInMonth" CssClass="cssLabelGVHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, ActualHoursInMonth %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvActualHoursInMonth" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActualHoursInMonth").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="80px" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrActualOtherAllowances" CssClass="cssLabelGVHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, OtherAllowances %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvActualOtherAllowances" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:n3}",Eval("ActualOtherAllowances")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="80px" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrActualMonthlyBilling" Width="70px" CssClass="cssLabelHeader"
                                                                    runat="server" Text="<%$ Resources:Resource, ActualMonthlyBilling %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvActualMonthlyBilling" Width="70px" CssClass="cssLable" runat="server"
                                                                    Text='<%# String.Format("{0:n3}",Eval("ActualMonthlyBilling")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSOLineStartDate" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, StartDate %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSOLineStartDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineStartDate")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="60px" ID="txtSOLineStartDate" CssClass="csstxtboxRequired" runat="server"
                                                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineStartDate")) %>'></asp:TextBox><asp:HyperLink
                                                                        Style="vertical-align: top; height: 16px; width: 22px;" ID="HlimgSOLineStartDate"
                                                                        runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:HiddenField runat="server" ID="hfieldSOLineStartDate" />
                                                                <asp:TextBox Width="60px" ID="txtSOLineStartDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox><asp:HyperLink
                                                                    Style="vertical-align: top; height: 16px; width: 22px;" ID="HlimgSOLineStartDate"
                                                                    runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                                <asp:RequiredFieldValidator ID="rfvSOLineStartDate" ValidationGroup="vgCFooter" ControlToValidate="txtSOLineStartDate"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="110px" HeaderStyle-Width="110px" ItemStyle-Width="110px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSOLineEndDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EndDate %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSOLineEndDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineEndDate")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="60px" ID="txtSOLineEndDate" CssClass="csstxtboxRequired" runat="server"
                                                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineEndDate")) %>'></asp:TextBox><asp:HyperLink
                                                                        Style="vertical-align: top; height: 16px; width: 22px;" ID="HlimgSOLineEndDate"
                                                                        runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:HiddenField runat="server" ID="hfieldSOLineEndDate" />
                                                                <asp:TextBox Width="60px" ID="txtSOLineEndDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox><asp:HyperLink
                                                                    Style="vertical-align: top; height: 16px; width: 22px;" ID="HlimgSOLineEndDate"
                                                                    runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink><asp:RequiredFieldValidator
                                                                        ID="rfvSOLineEndDate" ValidationGroup="vgCFooter" ControlToValidate="txtSOLineEndDate"
                                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="80px" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSOLineRemarks" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSOLineRemarks" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:HiddenField runat="server" ID="hfieldSOLineStartDate" Value='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineStartDate")) %>' />
                                                                <asp:HiddenField runat="server" ID="hfieldSOLineEndDate" Value='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineEndDate")) %>' />
                                                                <asp:TextBox Width="70px" ID="txtSOLineRemarks" MaxLength="200" CssClass="csstxtbox"
                                                                    runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks").ToString()%>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="70px" ID="txtSOLineRemarks" MaxLength="200" CssClass="csstxtbox"
                                                                    runat="server"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField ReadOnly="true" DataField="DutyTypeCode" />
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
                        <Ajax:AsyncPostBackTrigger ControlID="btnReversal" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnRevSave" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnAuthorize" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnRefetch" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="ddlInvoiceType" EventName="SelectedIndexChanged" />
                        <Ajax:AsyncPostBackTrigger ControlID="txtInvNo" />
                    </Triggers>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                    <ContentTemplate>
                        <div style="width: 950px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 930px;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="height: 12px; width: 33%">
                                                </td>
                                                <td style="height: 12px; width: 33%" align="center">
                                                    <asp:Label ID="Label2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SaleOrderItems %>"></asp:Label>
                                                </td>
                                                <td style="height: 12px; width: 33%" align="right">
                                                    <asp:Label Width="130px" Style="text-align: right" ID="lblFixSOItemTotalValue" CssClass="cssLabelHeader"
                                                        runat="server" Text="<%$ Resources:Resource, TotalValue %>"></asp:Label>
                                                    <asp:Label Width="130px" Style="text-align: right; font-weight: bold;" ID="lblSOItemTotalValue"
                                                        CssClass="csstxtboxReadonly" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="left">
                                                <asp:GridView Width="930" ID="gvSOItemDetails" CssClass="GridViewStyle" runat="server"
                                                    ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                                    CellPadding="0" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvSOItemDetails_RowCommand"
                                                    OnRowUpdating="gvSOItemDetails_RowUpdating" OnRowDeleting="gvSOItemDetails_RowDeleting"
                                                    OnRowEditing="gvSOItemDetails_RowEditing" OnRowCancelingEdit="gvSOItemDetails_RowCancelingEdit"
                                                    OnRowDataBound="gvSOItemDetails_RowDataBound">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-Width="75px" FooterStyle-Width="75px" ItemStyle-Width="75px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblaction" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnDelete" Visible="false" runat="server" CssClass="cssImgButton"
                                                                    CommandName="Delete" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                    ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                    ValidationGroup="vgCEdit1" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                    ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                    ToolTip="<%$ Resources:Resource, AddNew %>" ValidationGroup="vgCFooter1" ImageUrl="../Images/AddNew.gif" />
                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="50px" FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrAmendNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ItemTypeCode %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvAmendNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SoAmendNo").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblgvAmendNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SoAmendNo").ToString()%>'></asp:Label>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrItemTypeCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ItemTypeCode %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hfgvItemTypeCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ItemTypeCode").ToString()%>' />
                                                                <asp:Label ID="lblgvItemTypeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemDesc").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:HiddenField ID="hfgvItemTypeCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ItemTypeCode").ToString()%>' />
                                                                <asp:Label ID="lblgvItemTypeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemDesc").ToString()%>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList CssClass="cssDropDown" Width="130px" runat="server" ID="ddlItemTypeCode">
                                                                </asp:DropDownList>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrQty" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Qty %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvQty" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qty").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <%--<EditItemTemplate>
                                                                <asp:TextBox Width="60px" ID="txtQty" CssClass="csstxtboxRequired" MaxLength="15"
                                                                    runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qty").ToString()%>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvQty" ValidationGroup="vgCEdit1" ControlToValidate="txtQty"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator runat="server" ID="rvQty" Type="Double" ValidationGroup="vgCEdit1"
                                                                    ControlToValidate="txtQty" MinimumValue="0.001" MaximumValue="99999999.0" ErrorMessage="*"></asp:RangeValidator>
                                                            </EditItemTemplate>--%>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="60px" ID="txtQty" CssClass="csstxtboxRequired" MaxLength="15"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvQty" ValidationGroup="vgCFooter1" ControlToValidate="txtQty"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator runat="server" ID="rvQty" Type="Double" ValidationGroup="vgCFooter1"
                                                                    ControlToValidate="txtQty" MinimumValue="0.001" MaximumValue="99999999.0" ErrorMessage="*"></asp:RangeValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrRate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Rate %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvRate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:f}", DataBinder.Eval(Container.DataItem, "Rate"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <%--<EditItemTemplate>
                                                                <asp:TextBox Width="80px" ID="txtRate" CssClass="csstxtboxRequired" MaxLength="15"
                                                                    runat="server" Text='<%# String.Format("{0:n3}", DataBinder.Eval(Container.DataItem, "Rate"))%>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvRate" ValidationGroup="vgCEdit1" ControlToValidate="txtRate"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>--%>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="80px" ID="txtRate" CssClass="csstxtboxRequired" MaxLength="15"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvRate" ValidationGroup="vgCFooter1" ControlToValidate="txtRate"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="80px" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrItemMonthlyBilling" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, MonthlyBilling %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvItemMonthlyBilling" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:n3}",Eval("MonthlyBilling")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="60px" ID="txtItemMonthlyBilling" CssClass="csstxtbox" MaxLength="20"
                                                                    runat="server" Text='<%# String.Format("{0:f}",Eval("MonthlyBilling")) %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="60px" ID="txtItemMonthlyBilling" CssClass="csstxtbox" MaxLength="20"
                                                                    runat="server"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSOLineItemRemarks" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSOLineItemRemarks" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="60px" ID="txtSOLineItemRemarks" MaxLength="200" CssClass="csstxtbox"
                                                                    runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks").ToString()%>'></asp:TextBox>
                                                                <asp:HiddenField runat="server" ID="hfieldSOLineItemStartDate" Value='<%# String.Format("{0:dd-MMM-yyyy}", Eval("ItemStartDate"))%>' />
                                                                <asp:HiddenField runat="server" ID="hfieldSOLineItemEndDate" Value='<%# String.Format("{0:dd-MMM-yyyy}", Eval("ItemEndDate"))%>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox Width="60px" ID="txtSOLineItemRemarks" MaxLength="200" CssClass="csstxtbox"
                                                                    runat="server"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSOLineItemStartDate" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, StartDate %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSOLineItemStartDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ItemStartDate")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSOLineItemEndDate" CssClass="cssLabelHeader" runat="server"
                                                                    Text="<%$ Resources:Resource, EndDate %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSOLineItemEndDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ItemEndDate")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrAction" CssClass="cssLabelHeader" runat="server" Text="Edit"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnEditBill" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                    ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="~/Images/Edit.gif" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnUpdateBill" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                    ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="~/Images/Save.gif" />
                                                                <asp:ImageButton ID="ImgbtnCancelBill" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                    ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="~/Images/Cancel.gif" />
                                                            </EditItemTemplate>
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
                        <Ajax:AsyncPostBackTrigger ControlID="btnReversal" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnRevSave" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnAuthorize" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnRefetch" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                        <Ajax:AsyncPostBackTrigger ControlID="ddlInvoiceType" EventName="SelectedIndexChanged" />
                        <Ajax:AsyncPostBackTrigger ControlID="txtInvNo" />
                    </Triggers>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Always">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right" width="82%">
                        <asp:Label Width="130px" ID="lblSubTotal" CssClass="cssLableRequired" runat="server"
                            Text="<%$ Resources:Resource, SubTotal %>"></asp:Label>
                    </td>
                    <td align="left" width="18%">
                        <asp:TextBox Width="120px" ID="txtSubTotal" CssClass="csstxtboxRequired" MaxLength="16"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="82%">
                        <asp:Label Width="130px" ID="lblTax" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, Tax %>"></asp:Label>
                    </td>
                    <td align="left" width="18%">
                        <asp:TextBox Width="120px" ID="txtTax" CssClass="csstxtboxRequired" MaxLength="16"
                            runat="server" AutoPostBack="true" OnTextChanged="txtTax_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtTax" ValidationGroup="vgCSave" ControlToValidate="txtTax"
                            runat="server" Text="*" ErrorMessage="Tax Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="82%">
                        <asp:Label Width="130px" ID="lblGrandTotal" CssClass="cssLableRequired" runat="server"
                            Text="<%$ Resources:Resource, GrandTotal %>"></asp:Label>
                    </td>
                    <td align="left" width="18%">
                        <asp:TextBox Width="120px" ID="txtGrandTotal" CssClass="csstxtboxRequired" MaxLength="16"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtGrandTotal" ValidationGroup="vgCSave" ControlToValidate="txtGrandTotal"
                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <table>
        <tr>
            <td>
                <asp:Panel ID="Panel4" ScrollBars="none" runat="server" Width="350" Style="display: none;">
                    <asp:Button ID="Button2" runat="server" Style="display: none" />
                    <AjaxToolKit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button2"
                        PopupControlID="Panel4" X="300" Drag="true" Y="150" BackgroundCssClass="modalBackground" />
                    <Ajax:UpdatePanel runat="server" ID="upReversal" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="width: 350;">
                                <div class="squarebox">
                                    <div class="squareboxgradientcaption" style="height: 5px; cursor: pointer;" ">
                                        <div style="float: left">
                                            <tt style="text-align: center;">
                                                <asp:Label ID="Label4" CssClass="squareboxgradientcaption" runat="server" Text="Reversal Details"></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="label19" runat="server" CssClass="cssLabel" Text="Invoice Number"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtrevInvoiceNumber" Enabled="false" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="label1" runat="server" CssClass="cssLabel" Text="Invoice Date"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtRevInvoiceDate" Enabled="false" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblReversalDate" runat="server" CssClass="cssLabel" Text="Reversal Date"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtReversalDate" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    <asp:HyperLink Style="vertical-align: top;" ID="IMGReversalDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=""
                                                        Text="*" ControlToValidate="txtReversalDate" ValidationGroup="btnRevSave"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text="Reason"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtrevReason" TextMode="MultiLine" Height="50" CssClass="csstxtbox"
                                                        runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnRevSave" ValidationGroup="btnRevSave" CssClass="cssButton" runat="server"
                                                        Text="Save" OnClick="btnRevSave_Click" />
                                                    <asp:Button ID="btnReversalCancel" CssClass="cssButton" runat="server" Text="Cancel"
                                                        OnClick="btnReversalCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblRevErrormsg" runat="server" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        function CalculateHoursInMonthNMonthlyBilling(strIdtxtNoOfPost, strIdtxtHours, strIdtxtDaysInMonth, strIdtxtHoursInMonth, strIdtxtOtherAllowances, strIdtxtMonthlyBilling, strIdtxtSellingPrice, strIdhfRatePerHour) {

            var objtxtNoOfPost = document.getElementById(strIdtxtNoOfPost);
            var objtxtHours = document.getElementById(strIdtxtHours);
            var objtxtDaysInMonth = document.getElementById(strIdtxtDaysInMonth);
            var objtxtHoursInMonth = document.getElementById(strIdtxtHoursInMonth);
            var objtxtOtherAllowances = document.getElementById(strIdtxtOtherAllowances);
            var objxtMonthlyBilling = document.getElementById(strIdtxtMonthlyBilling);
            var objtxtSellingPrice = document.getElementById(strIdtxtSellingPrice);
            var objIdhfRatePerHour = document.getElementById(strIdhfRatePerHour);

            if (objtxtNoOfPost.value.length > 0 && objtxtHours.value.length > 0 && objtxtDaysInMonth.value.length > 0) {
                objtxtHoursInMonth.value = parseFloat(objtxtNoOfPost.value) * parseFloat(objtxtHours.value) * parseFloat(objtxtDaysInMonth.value);
            }
            if (objtxtNoOfPost.value.length > 0 && objtxtHours.value.length > 0 && objtxtDaysInMonth.value.length > 0 && objtxtHoursInMonth.value.length > 0 && objtxtSellingPrice.value.length > 0 && objIdhfRatePerHour.value.length > 0) {
                if (objtxtOtherAllowances.value.length == 0) {
                    objtxtOtherAllowances.value = 0;
                }
                objxtMonthlyBilling.value = (parseFloat(objIdhfRatePerHour.value) * parseFloat(objtxtNoOfPost.value) * parseFloat(objtxtHours.value) * parseFloat(objtxtDaysInMonth.value)) + parseFloat(objtxtOtherAllowances.value);
            }
        }
    </script>

</asp:Content>
