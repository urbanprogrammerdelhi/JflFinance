<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterSearch.master"
    AutoEventWireup="true" CodeFile="SOLineDeptShifts.aspx.cs" Inherits="Sales_SOLineDeptShifts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width:1230px; height:550px; overflow:scroll;">
                    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; line-height:20px; border-spacing: 5px 1px; border-collapse:separate;">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblClientCode" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ClientCode %>" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblClientCodeValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblClientName" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ClientName %>" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblClientNameValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblfixSoNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SONo %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSoNo" CssClass="cssLabelHeader" runat="server">
                                        </asp:Label><asp:HiddenField ID="hfLocationAutoId" runat="server" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblfixSOAmendNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SOAmendNo %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSOAmendNo" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblfixSoStatus" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SOStatus %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSoStatus" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hfIsMAXSOAmendNo" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblAsmtID" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AsmtId %>" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblAsmtIDValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblAsmtName" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AsmtName %>" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblAsmtNameValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblPostID" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Post %>" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPostIDValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblfixSOLineNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SOLineNo %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSOLineNo" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblSORank" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SORank %>" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSORankValue" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="squareboxgradientcaption" style="height: 20px;">
                                <asp:Label ID="Label23" runat="server" Text="<%$Resources:Resource,WeeklyDepPattern %>"></asp:Label>
                            </div>
                                <div>
                                    <asp:HiddenField ID="hfHours" runat="server" />
                                    <asp:HiddenField ID="hfspDecimalPlace" runat="server" Value="{0:0.##}" />
                                    <asp:HiddenField ID="hfNoOfPost" runat="server" />
                                    <asp:HiddenField ID="HFSoLineActiveStatus" runat="server" />
                                    <asp:HiddenField ID="hfChargeRatePerHrs" runat="server" />
                                    <asp:HiddenField ID="hfPayRatePerHrs" runat="server" />
                                    <asp:HiddenField ID="hfIsAllowanceBillable" runat="server" />
                                    <asp:HiddenField ID="hfOtherAllowance" runat="server" />
                                    <asp:HiddenField ID="hfRemainingDays" runat="server" />
                                    <asp:HiddenField ID="hfBillingPattern" runat="server" />
                                    <asp:HiddenField ID="hiddenFieldBillable" runat="server" />
                                    <asp:HiddenField ID="hiddenFieldOTChargeRateActive" runat="server" />
                                    <asp:HiddenField ID="hiddenFieldHChargeRateActive" runat="server" />
                                    <asp:HiddenField ID="hiddenFieldOChargeRateActive" runat="server" />
                                    <asp:HiddenField ID="hiddenFieldHolidayDept" runat="server" />
                                </div>
                                <asp:GridView Width="1850px" ID="gvPattren" CssClass="GridViewStyle" runat="server"
                                    ShowFooter="True" AllowPaging="True" PageSize="15"
                                    CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvPattren_RowCommand"
                                    OnRowUpdating="gvPattren_RowUpdating" OnRowDataBound="gvPattren_RowDataBound"
                                    OnRowEditing="gvPattren_RowEditing" OnRowCancelingEdit="gvPattren_RowCancelingEdit"
                                    OnRowDeleting="gvPattren_RowDeleting" 
                                    OnPageIndexChanging="gvPattren_PageIndexChanging">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                ToolTip="<%$ Resources:Resource, Delete %>" OnClientClick="return confirm('Do you want to Delete');"
                                                                ImageUrl="../Images/Delete.gif" />
                                                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                OnClientClick="javascript:PayRateValidation(this)" ValidationGroup="vgHrEdit"
                                                                ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                                                ValidationGroup="vgHrEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                                                Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="AddNew"
                                                    ToolTip="<%$Resources:Resource,Save %>" OnClientClick="javascript:PayRateValidation(this)"
                                                    ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                    ToolTip="<%$Resources:Resource, Reset %>" OnClick="btnReset_Click" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <ItemStyle Width="70px" />
                                            <HeaderStyle Width="70px" />
                                            <FooterStyle Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblgvhdrWeekNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, WeekNO %>"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvWeekNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WeekNo").ToString()%>'></asp:Label>
                                                <asp:HiddenField ID="hfSaleOrderDeptShiftAutoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SaleOrderDeptShiftAutoId").ToString()%>' />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TxtEditWeekNo" Enabled="false" CssClass="csstxtbox" Width="30px"
                                                    runat="server" MaxLength="5" Text='<%# Bind("WeekNo") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="txtEditWeekNoValidator" runat="server" ControlToValidate="TxtEditWeekNo"
                                                    ErrorMessage="<%$Resources:Resource,CannotBeLeftBlank %>" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="TxtWeekNo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                    Text="12345"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="txtWeekNoValidator" runat="server" ControlToValidate="TxtWeekNo"
                                                    ErrorMessage="<%$Resources:Resource,CannotBeLeftBlank %>" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <FooterStyle Width="85px" />
                                            <HeaderStyle Width="85px" />
                                            <ItemStyle Width="85px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblgvhdrShift" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Shift %>"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbShift" OnClientClick="javascript:OpenRadWindow();" OnClick="lbShift_Click"
                                                    CssClass="cssLabel" runat="server" Text='<%# Bind("ShiftCode") %>' ToolTip='<%# Bind("ShiftDesc") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlShift" Enabled="false" runat="server" Width="150px" CssClass="cssDropDown"
                                                    OnSelectedIndexChanged="ddlShiftEdit_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:HiddenField runat="server" ID="hfShift" Value='<%# Bind("ShiftCode") %>' />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlShift" runat="server" Width="150px" CssClass="cssDropDown"
                                                    OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <FooterStyle Width="150px" />
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblgvhdrRows" CssClass="cssLabelHeader" runat="server" Text=""></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Table ID="tbl1" runat="server" CellSpacing="0" CellPadding="0" border="0" Style="border: 0px;
                                                    width: 100%;">
                                                    <asp:TableRow ID="TableRow1" runat="server" Style="background-color: #C9DBEC">
                                                        <asp:TableCell ID="TableCell1" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="ltrNoOfPersons" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,NoOfPersons %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow2" runat="server" Style="background-color: #FFFFFF">
                                                        <asp:TableCell ID="TableCell2" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblgvSellingRate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ChargeRatePerHour %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow3" runat="server" Style="background-color: #C9DBEC">
                                                        <asp:TableCell ID="TableCell3" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblgvPayRate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PayRatePerHour %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow4" runat="server" Style="background-color: #FFFFFF">
                                                        <asp:TableCell ID="TableCell4" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShiftTime %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow5" runat="server" Style="background-color: #CCCCCC">
                                                        <asp:TableCell ID="TableCell5" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblHours" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Hours %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Table ID="tbl1" runat="server" CellSpacing="0" CellPadding="0" border="0" Style="border: 0px;
                                                    width: 100%;">
                                                    <asp:TableRow ID="TableRow6" runat="server" Style="background-color: #C9DBEC; height: 20px;">
                                                        <asp:TableCell ID="TableCell6" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="ltrNoOfPersons" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,NoOfPersons %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow7" runat="server" Style="background-color: #FFFFFF; height: 20px;">
                                                        <asp:TableCell ID="TableCell7" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblgvSellingRate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ChargeRatePerHour %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow8" runat="server" Style="background-color: #C9DBEC; height: 20px;">
                                                        <asp:TableCell ID="TableCell8" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblgvPayRate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PayRatePerHour %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow9" runat="server" Style="background-color: #FFFFFF; height: 20px;">
                                                        <asp:TableCell ID="TableCell9" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShiftTime %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow10" runat="server" Style="background-color: #CCCCCC; height: 15px;">
                                                        <asp:TableCell ID="TableCell10" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblHours" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Hours %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Table ID="tbl1" runat="server" CellSpacing="0" CellPadding="0" border="0" Style="border: 0px;
                                                    width: 100%;">
                                                    <asp:TableRow ID="TableRow11" runat="server" Style="background-color: #C9DBEC; height: 20px;">
                                                        <asp:TableCell ID="TableCell11" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="ltrMondayNoOfPersons" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,NoOfPersons %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow12" runat="server" Style="background-color: #FFFFFF; height: 20px;">
                                                        <asp:TableCell ID="TableCell12" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblgvSellingRate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ChargeRatePerHour %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow13" runat="server" Style="background-color: #C9DBEC; height: 20px;">
                                                        <asp:TableCell ID="TableCell13" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblgvPayRate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PayRatePerHour %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow14" runat="server" Style="background-color: #FFFFFF; height: 20px;">
                                                        <asp:TableCell ID="TableCell14" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShiftTime %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow ID="TableRow15" runat="server" Style="background-color: #CCCCCC; height: 20px;">
                                                        <asp:TableCell ID="TableCell15" runat="server" Style="border: 0px; text-align: right;
                                                            white-space: nowrap;">
                                                            <asp:Label ID="lblHours" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Hours %>"></asp:Label>&nbsp;:&nbsp;
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrSunday" runat="server" Text="<%$Resources:Resource,Sunday %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSunNoOfPersons" CssClass="cssLabel" runat="server" Text='<%# Eval("SunNoOfPersons")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSunSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblSunOTSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunOTSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblSunHSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunHSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblSunOSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunOSellingRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSunPayRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunPayRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSunTimeFrom" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("SunHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("SunTimeFrom"))%>'></asp:Label>
                                                            <asp:Label ID="lblSunTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:Label ID="lblSunTimeTo" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("SunHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("SunTimeTo"))%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSunHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("SunHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfSunHrs" runat="server" Value='<%# Eval("SunHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtSunNoOfPersons" CssClass="csstxtbox" Width="50px" runat="server"
                                                                MaxLength="4" Text='<%# Eval("SunNoOfPersons")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtSunSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtSunOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunOTSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtSunHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunHSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtSunOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunOSellingRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtSunPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SunPayRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtEditSunTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("SunTimeFrom"))%>'></asp:TextBox>
                                                            <asp:Label ID="lblSunTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtEditSunTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("SunTimeTo"))%>'></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditSunErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSunHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("SunHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfSunHrs" runat="server" Value='<%# Eval("SunHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtSunNoOfPersons" CssClass="csstxtbox" Width="15px" runat="server"
                                                                MaxLength="4" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtSunSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtSunOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtSunHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtSunOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtSunPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtSunTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text=""></asp:TextBox>
                                                            <asp:Label ID="lblSunTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtSunTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                Text=""></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditSunErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC; height: 20px;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSunHrs" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                            <asp:ImageButton ID="ImgbtnCopyTime" runat="server" CssClass="cssImgButton" CommandName="CopyTime"
                                                                ToolTip="Copy To All" ImageUrl="../Images/copy.png" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrMonday" runat="server" Text="<%$Resources:Resource,Monday %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblMonNoOfPersons" CssClass="cssLabel" runat="server" Text='<%# Eval("MonNoOfPersons")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblMonSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblMonOTSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonOTSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblMonHSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonHSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblMonOSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonOSellingRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblMonPayRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonPayRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblMonTimeFrom" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("MonHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("MonTimeFrom"))%>'></asp:Label>
                                                            <asp:Label ID="lblMonTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:Label ID="lblMonTimeTo" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("MonHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("MonTimeTo"))%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblMonHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("MonHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfMonHrs" runat="server" Value='<%# Eval("MonHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtMonNoOfPersons" CssClass="csstxtbox" Width="50px" runat="server"
                                                                MaxLength="4" Text='<%# Eval("MonNoOfPersons")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtMonSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtMonOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonOTSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtMonHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonHSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtMonOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonOSellingRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtMonPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonPayRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtEditMonTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("MonTimeFrom"))%>'></asp:TextBox>
                                                            <asp:Label ID="lblMonTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtEditMonTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("MonTimeTo"))%>'></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditMonErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblMonHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("MonHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfMonHrs" runat="server" Value='<%# Eval("MonHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtMonNoOfPersons" CssClass="csstxtbox" Width="15px" runat="server"
                                                                MaxLength="4" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtMonSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtMonOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtMonHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtMonOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtMonPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtMonTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text=""></asp:TextBox>
                                                            <asp:Label ID="lblMonTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtMonTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                Text=""></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditMonErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC; height: 20px;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblMonHrs" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrTuesday" runat="server" Text="<%$Resources:Resource,Tuesday %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblTueNoOfPersons" CssClass="cssLabel" runat="server" Text='<%# Eval("TueNoOfPersons")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblTueSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TueSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblTueOTSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TueOTSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblTueHSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TueHSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblTueOSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TueOSellingRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblTuePayRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TuePayRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblTueTimeFrom" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("TueHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("TueTimeFrom"))%>'></asp:Label>
                                                            <asp:Label ID="lblTueTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:Label ID="lblTueTimeTo" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("TueHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("TueTimeTo"))%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblTueHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("TueHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfTueHrs" runat="server" Value='<%# Eval("TueHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtTueNoOfPersons" CssClass="csstxtbox" Width="50px" runat="server"
                                                                MaxLength="4" Text='<%# Eval("TueNoOfPersons")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtTueSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TueSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtTueOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TueOTSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtTueHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TueHSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtTueOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TueOSellingRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtTuePayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("TuePayRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtEditTueTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("TueTimeFrom"))%>'></asp:TextBox>
                                                            <asp:Label ID="lblTueTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtEditTueTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("TueTimeTo"))%>'></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditTueErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblTueHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("TueHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfTueHrs" runat="server" Value='<%# Eval("TueHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtTueNoOfPersons" CssClass="csstxtbox" Width="15px" runat="server"
                                                                MaxLength="4" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtTueSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtTueOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtTueHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtTueOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtTuePayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtTueTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text=""></asp:TextBox>
                                                            <asp:Label ID="lblTueTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtTueTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                Text=""></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditTueErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC; height: 20px;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblTueHrs" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrWednesday" runat="server" Text="<%$Resources:Resource,Wednesday %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblWedNoOfPersons" CssClass="cssLabel" runat="server" Text='<%# Eval("WedNoOfPersons")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblWedSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblWedOTSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedOTSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblWedHSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedHSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblWedOSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedOSellingRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblWedPayRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedPayRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblWedTimeFrom" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("WedHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("WedTimeFrom"))%>'></asp:Label>
                                                            <asp:Label ID="lblWedTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:Label ID="lblWedTimeTo" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("WedHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("WedTimeTo"))%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblWedHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("WedHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfWedHrs" runat="server" Value='<%# Eval("WedHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtWedNoOfPersons" CssClass="csstxtbox" Width="50px" runat="server"
                                                                MaxLength="4" Text='<%# Eval("WedNoOfPersons")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtWedSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtWedOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedOTSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtWedHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedHSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtWedOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedOSellingRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtWedPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("WedPayRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtEditWedTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("WedTimeFrom"))%>'></asp:TextBox>
                                                            <asp:Label ID="lblWedTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtEditWedTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("WedTimeTo"))%>'></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditWedErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblWedHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("WedHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfWedHrs" runat="server" Value='<%# Eval("WedHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtWedNoOfPersons" CssClass="csstxtbox" Width="15px" runat="server"
                                                                MaxLength="4" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtWedSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtWedOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtWedHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtWedOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtWedPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtWedTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text=""></asp:TextBox>
                                                            <asp:Label ID="lblWedTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtWedTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                Text=""></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditWedErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC; height: 20px;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblWedHrs" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrThursday" runat="server" Text="<%$Resources:Resource,Thursday %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblThuNoOfPersons" CssClass="cssLabel" runat="server" Text='<%# Eval("ThuNoOfPersons")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblThuSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblThuOTSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuOTSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblThuHSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuHSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblThuOSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuOSellingRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblThuPayRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuPayRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblThuTimeFrom" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("ThuHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("ThuTimeFrom"))%>'></asp:Label>
                                                            <asp:Label ID="lblThuTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:Label ID="lblThuTimeTo" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("ThuHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("ThuTimeTo"))%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblThuHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("ThuHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfThuHrs" runat="server" Value='<%# Eval("ThuHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtThuNoOfPersons" CssClass="csstxtbox" Width="50px" runat="server"
                                                                MaxLength="4" Text='<%# Eval("ThuNoOfPersons")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtThuSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtThuOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuOTSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtThuHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuHSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtThuOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuOSellingRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtThuPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ThuPayRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtEditThuTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("ThuTimeFrom"))%>'></asp:TextBox>
                                                            <asp:Label ID="lblThuTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtEditThuTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("ThuTimeTo"))%>'></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditThuErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblThuHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("ThuHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfThuHrs" runat="server" Value='<%# Eval("ThuHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtThuNoOfPersons" CssClass="csstxtbox" Width="15px" runat="server"
                                                                MaxLength="4" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtThuSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtThuOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtThuHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtThuOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtThuPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtThuTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text=""></asp:TextBox>
                                                            <asp:Label ID="lblThuTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtThuTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                Text=""></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditThuErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC; height: 20px;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblThuHrs" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrFriday" runat="server" Text="<%$Resources:Resource,Friday %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblFriNoOfPersons" CssClass="cssLabel" runat="server" Text='<%# Eval("FriNoOfPersons")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblFriSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblFriOTSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriOTSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblFriHSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriHSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblFriOSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriOSellingRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblFriPayRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriPayRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblFriTimeFrom" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("FriHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("FriTimeFrom"))%>'></asp:Label>
                                                            <asp:Label ID="lblFriTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:Label ID="lblFriTimeTo" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("FriHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("FriTimeTo"))%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblFriHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("FriHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfFriHrs" runat="server" Value='<%# Eval("FriHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtFriNoOfPersons" CssClass="csstxtbox" Width="50px" runat="server"
                                                                MaxLength="4" Text='<%# Eval("FriNoOfPersons")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtFriSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtFriOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriOTSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtFriHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriHSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtFriOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriOSellingRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtFriPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("FriPayRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtEditFriTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("FriTimeFrom"))%>'></asp:TextBox>
                                                            <asp:Label ID="lblFriTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtEditFriTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("FriTimeTo"))%>'></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditFriErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblFriHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("FriHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfFriHrs" runat="server" Value='<%# Eval("FriHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtFriNoOfPersons" CssClass="csstxtbox" Width="15px" runat="server"
                                                                MaxLength="4" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtFriSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtFriOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtFriHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtFriOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtFriPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtFriTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text=""></asp:TextBox>
                                                            <asp:Label ID="lblFriTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtFriTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                Text=""></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditFriErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC; height: 20px;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblFriHrs" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrSaturday" runat="server" Text="<%$Resources:Resource,Saturday %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSatNoOfPersons" CssClass="cssLabel" runat="server" Text='<%# Eval("SatNoOfPersons")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSatSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblSatOTSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatOTSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblSatHSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatHSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblSatOSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatOSellingRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSatPayRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatPayRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSatTimeFrom" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("SatHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("SatTimeFrom"))%>'></asp:Label>
                                                            <asp:Label ID="lblSatTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:Label ID="lblSatTimeTo" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("SatHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("SatTimeTo"))%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSatHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("SatHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfSatHrs" runat="server" Value='<%# Eval("SatHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtSatNoOfPersons" CssClass="csstxtbox" Width="50px" runat="server"
                                                                MaxLength="4" Text='<%# Eval("SatNoOfPersons")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtSatSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtSatOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatOTSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtSatHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatHSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtSatOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatOSellingRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtSatPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("SatPayRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtEditSatTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("SatTimeFrom"))%>'></asp:TextBox>
                                                            <asp:Label ID="lblSatTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtEditSatTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("SatTimeTo"))%>'></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditSatErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSatHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("SatHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfSatHrs" runat="server" Value='<%# Eval("SatHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtSatNoOfPersons" CssClass="csstxtbox" Width="15px" runat="server"
                                                                MaxLength="4" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtSatSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtSatOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtSatHSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtSatOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtSatPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtSatTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text=""></asp:TextBox>
                                                            <asp:Label ID="lblSatTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtSatTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                Text=""></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditSatErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC; height: 20px;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblSatHrs" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                                                
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrHoliday" runat="server" Text="<%$Resources:Resource,Holiday %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblHolidayNoOfPersons" CssClass="cssLabel" runat="server" Text='<%# Eval("HolidayNoOfPersons")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblHolidaySellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("HolidaySellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblHolidayOTSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("HolidayOTSellingRate")) %>'></asp:Label>
                                                            <asp:Label ID="lblHolidayOSellingRate" CssClass="cssLabelBox" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("HolidayOSellingRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblHolidayPayRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("HolidayPayRate")) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblHolidayTimeFrom" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("HolidayHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("HolidayTimeFrom"))%>'></asp:Label>
                                                            <asp:Label ID="lblHolidayTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:Label ID="lblHolidayTimeTo" CssClass="cssLabel" runat="server" ToolTip='<%# Eval("HolidayHrs")%>'
                                                                Text='<%# String.Format("{0:HH:mm}",Eval("HolidayTimeTo"))%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblHolidayHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("HolidayHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfHolidayHrs" runat="server" Value='<%# Eval("HolidayHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtHolidayNoOfPersons" CssClass="csstxtbox" Width="50px" runat="server"
                                                                MaxLength="4" Text='<%# Eval("HolidayNoOfPersons")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtHolidaySellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("HolidaySellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtHolidayOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("HolidayOTSellingRate")) %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtHolidayOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("HolidayOSellingRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtHolidayPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("HolidayPayRate")) %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtEditHolidayTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("HolidayTimeFrom"))%>'></asp:TextBox>
                                                            <asp:Label ID="lblHolidayTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtEditHolidayTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("HolidayTimeTo"))%>'></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditHolidayErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblHolidayHrs" CssClass="cssLabel" runat="server" Text='<%# Eval("HolidayHrs")%>'></asp:Label>
                                                            <asp:HiddenField ID="hfHolidayHrs" runat="server" Value='<%# Eval("HolidayHrs")%>'></asp:HiddenField>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtHolidayNoOfPersons" CssClass="csstxtbox" Width="15px" runat="server"
                                                                MaxLength="4" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtHolidaySellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtHolidayOTSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                            <asp:TextBox ID="txtHolidayOSellingRate" CssClass="cssLabelBox" Width="25px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #C9DBEC">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="txtHolidayPayRate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                MaxLength="10" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #FFFFFF">
                                                        <td style="border: 0px">
                                                            <asp:TextBox ID="TxtHolidayTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                MaxLength="5" Text=""></asp:TextBox>
                                                            <asp:Label ID="lblHolidayTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                            <asp:TextBox ID="TxtHolidayTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                Text=""></asp:TextBox>
                                                            <asp:Label EnableViewState="false" ID="lblEditHolidayErrorMsg" Text="" runat="server"
                                                                CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #CCCCCC; height: 20px;">
                                                        <td style="border: 0px">
                                                            <asp:Label ID="lblHolidayHrs" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblgvhdrHolidayType" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, HolidayType %>"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvHolidayTypeDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HolidayTypeDesc").ToString()%>'></asp:Label>
                                                <asp:HiddenField runat="server" ID="hfHolidayTypeCode" Value='<%# Bind("HolidayTypeCode") %>' />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlHolidayTypeCode" runat="server" Width="150px" CssClass="cssDropDown">
                                                </asp:DropDownList>
                                                <asp:HiddenField runat="server" ID="hfHolidayTypeCode" Value='<%# Bind("HolidayTypeCode") %>' />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlHolidayTypeCode" runat="server" Width="150px" CssClass="cssDropDown">
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <FooterStyle Width="150px" />
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Literal ID="ltrSaleOrderDeptShiftUID" runat="server" Text="<%$Resources:Resource,UniqueId %>"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSaleOrderDeptShiftUID" CssClass="cssLabel" runat="server" Text='<%# Eval("SaleOrderDeptShiftUIDControlDigit")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblSaleOrderDeptShiftUID" CssClass="cssLabel" runat="server" Text='<%# Eval("SaleOrderDeptShiftUIDControlDigit")%>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <asp:HiddenField runat="server" ID="hfSaleOrderDeptShiftAutoIdForDelete" />
                                    <asp:HiddenField runat="server" ID="hfSaleOrderDeptShiftUpdateOrDelete" />
                                    <asp:HiddenField runat="server" ID="hfSaleOrderDeptShiftUpdateStatus" />
                                    <asp:HiddenField runat="server" ID="hfSaleOrderDeptShiftRowIndex" />
                                    <asp:HiddenField runat="server" ID="hfHoursInMonthERP" />
                                    <asp:HiddenField runat="server" ID="hfBaseHrsInMonth" Value="0.00" />
                                    <asp:HiddenField ID="HFShiftCode" runat="server" />
                                    <asp:HiddenField ID="HFWeekNo" runat="server" />
                                    <asp:HiddenField ID="HFDeptSunTimeFrom" runat="server" />
                                    <asp:HiddenField ID="HFDeptSunTimeTo" runat="server" />
                                    <asp:HiddenField ID="HFDeptMonTimeFrom" runat="server" />
                                    <asp:HiddenField ID="HFDeptMonTimeTo" runat="server" />
                                    <asp:HiddenField ID="HFDeptTueTimeFrom" runat="server" />
                                    <asp:HiddenField ID="HFDeptTueTimeTo" runat="server" />
                                    <asp:HiddenField ID="HFDeptWedTimeFrom" runat="server" />
                                    <asp:HiddenField ID="HFDeptWedTimeTo" runat="server" />
                                    <asp:HiddenField ID="HFDeptThuTimeFrom" runat="server" />
                                    <asp:HiddenField ID="HFDeptThuTimeTo" runat="server" />
                                    <asp:HiddenField ID="HFDeptFriTimeFrom" runat="server" />
                                    <asp:HiddenField ID="HFDeptFriTimeTo" runat="server" />
                                    <asp:HiddenField ID="HFDeptSatTimeFrom" runat="server" />
                                    <asp:HiddenField ID="HFDeptSatTimeTo" runat="server" />
                                    <asp:HiddenField ID="HFDeptHolidayTimeFrom" runat="server" />
                                    <asp:HiddenField ID="HFDeptHolidayTimeTo" runat="server" />
                                </div>
                            <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, AverageHoursInMonth %>"></asp:Label>(HH:MM)
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAverageHoursInMonth" Width="120px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                        <asp:HiddenField ID="HfAverageHoursInMonth" runat="server"></asp:HiddenField>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, ComputedMonthlyValue %>"></asp:Label>
                                        <asp:Label ID="lblavgdays" runat="server"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtComputedMonthlyValue" MaxLength="15" CssClass="csstxtbox"
                                         Width="120px" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Resource, MonthlyBilling %>"></asp:Label>
                                        <asp:Label ID="lblmonthbilling" runat="server"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFixedMonthlyBilling" MaxLength="15" CssClass="csstxtbox"
                                            Width="120px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, AverageDaysInMonth %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAverageDaysInMonth" Width="120px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    </td>
                                                                
                                </tr>
                            </table>
                            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>


                            <asp:Panel ID="Panel2" BackColor="white" ScrollBars="Auto" CssClass="ScrollBar" runat="server"
                                Height="460" Width="750px" Style="display: none;">
                                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                                <AjaxToolKit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
                                    PopupControlID="Panel2" BackgroundCssClass="modalBackground" />
                                <Ajax:UpdatePanel runat="server" ID="UpdatePanelDeleteRota" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Panel ID="PanelDeleteRota" Visible="true" Width="700px" BorderWidth="1px" runat="server">
                                            <div style="width: 700px;">
                                                <div class="squarebox">
                                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                        <div style="float: left; width: 700px">
                                                            <tt style="text-align: center;">
                                                                <asp:Label ID="LblRotaDetail" CssClass="squareboxgradientcaption" runat="server"
                                                                    Text="<%$Resources:Resource,RotaDetail %>"></asp:Label></tt></div>
                                                    </div>
                                                    <div class="squareboxcontent">
                                                        <asp:Panel ID="Panel3" Visible="true" Width="100%" BorderWidth="1px" runat="server"
                                                            ScrollBars="Auto" CssClass="ScrollBar">
                                                            <table border="1" width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView Width="940px" ID="gvDeleteRota" CssClass="GridViewStyle" runat="server"
                                                                            CellPadding="1" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
                                                                            OnDataBound="gvDeleteRota_DataBound" OnPageIndexChanging="gvDeleteRota_PageIndexChanging"
                                                                            OnRowCommand="gvDeleteRota_RowCommand">
                                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,AsmtAddress %>" SortExpression="AsmtID">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAsmtCode" runat="server" Text='<%# Bind("AsmtID") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,SoLineNo %>" SortExpression="SoLineNo">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPDLineNo" runat="server" Text='<%# Bind("SoLineNo") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EmployeeNumber %>" SortExpression="EmployeeNumber">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEmployeeNumber" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,DutyDate %>" SortExpression="DutyDate">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label3" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("DutyDate"))%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,ShiftCode %>" SortExpression="ShiftCode">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ShiftCode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,TimeFrom %>" SortExpression="TimeFrom">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label9" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,TimeTo %>" SortExpression="TimeTo">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label10" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <PagerTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                                                                                CommandArgument="First" CommandName="Page" />
                                                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                                                                                CommandArgument="Prev" CommandName="Page" />
                                                                                            <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                                                                            <asp:DropDownList ID="ddlPagesDeleteRota" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                                                                                OnSelectedIndexChanged="ddlPagesDeleteRota_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                            <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                                                                            <asp:Label ID="lblPageCountDeleteRota" ForeColor="Black" runat="server"></asp:Label>
                                                                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                                                                                CommandArgument="Next" CommandName="Page" />
                                                                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                                                                                CommandArgument="Last" CommandName="Page" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </PagerTemplate>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="PanelScheduleRoster" Visible="true" Height="450px" Width="700px" BorderWidth="1px"
                                            runat="server" ScrollBars="Auto">
                                            <div style="width: 700px;">
                                                <div class="squarebox" style="width: 700px;">
                                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                        <div style="float: left; width: 700px">
                                                            <tt style="text-align: center;">
                                                                <asp:Label ID="Label11" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,ScheduleRosterDetails %>"></asp:Label></tt></div>
                                                    </div>
                                                    <div class="squareboxcontent">
                                                        <asp:Panel ID="Panel1" Visible="true" Width="800px" BorderWidth="1px" runat="server">
                                                            <asp:GridView Width="940px" ID="gvScheduleRoster" CssClass="GridViewStyle" runat="server"
                                                                CellPadding="1" AllowPaging="true" PageSize="10" AutoGenerateColumns="False"
                                                                OnPageIndexChanging="gvScheduleRoster_PageIndexChanging" OnRowCommand="gvScheduleRoster_RowCommand"
                                                                OnDataBound="gvScheduleRoster_DataBound">
                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,AsmtAddress %>" SortExpression="AsmtID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAsmtCode" runat="server" Text='<%# Bind("AsmtID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,SoLineNo %>" SortExpression="SoLineNo">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPDLineNo" runat="server" Text='<%# Bind("SoLineNo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,EmployeeNumber %>" SortExpression="EmployeeNumber">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmployeeNumber" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,DutyDate %>" SortExpression="DutyDate">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("DutyDate"))%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ShiftCode %>" SortExpression="ShiftCode">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("ShiftCode") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,TimeFrom %>" SortExpression="TimeFrom">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label9" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,TimeTo %>" SortExpression="TimeTo">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label10" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                                                                    CommandArgument="First" CommandName="Page" />
                                                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                                                                    CommandArgument="Prev" CommandName="Page" />
                                                                                <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                                                                <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                                                                    OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                                <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                                                                <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                                                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                                                                    CommandArgument="Next" CommandName="Page" />
                                                                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                                                                    CommandArgument="Last" CommandName="Page" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </PagerTemplate>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </Ajax:UpdatePanel>
                                <table border="0" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnDelete" runat="server" Text="<%$Resources:Resource,Delete %>"
                                                CssClass="cssButton" OnClick="btnDelete_onClick" />
                                            <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:Resource,Cancel %>"
                                                CssClass="cssButton" OnClick="btnCancel_onClick" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
        <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <telerik:RadWindow ID="RadWindow" runat="server" DestroyOnClose="true" ShowContentDuringLoad="false"
                                EnableShadow="true" KeepInScreenBounds="false" Title="<%$ Resources:Resource, BreakBetweenShift %>"
                                Width="1200px" Height="500px" Modal="true" OnClientClose="RadWindowClose" Behaviors="Default"
                                Skin="WebBlue">
                                <ContentTemplate>
                                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Label ID="lblErrorMsgBreak" runat="server" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                                            <asp:GridView Width="100%" ID="gvShiftBreak" CssClass="GridViewStyle" runat="server"
                                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvShiftBreak_RowCommand"
                                                OnRowUpdating="gvShiftBreak_RowUpdating" OnRowDataBound="gvShiftBreak_RowDataBound"
                                                OnRowEditing="gvShiftBreak_RowEditing" OnRowCancelingEdit="gvShiftBreak_RowCancelingEdit"
                                                OnRowDeleting="gvShiftBreak_RowDeleting" OnPageIndexChanging="gvShiftBreak_PageIndexChanging">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                            ToolTip="<%$ Resources:Resource, Delete %>" OnClientClick="return confirm('Do you want to Delete');"
                                                                            ImageUrl="../Images/Delete.gif" />
                                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                            ValidationGroup="vgHrEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                                                            ValidationGroup="vgHrEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                                                            Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="AddNew"
                                                                ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                ToolTip="<%$Resources:Resource, Reset %>" OnClick="btnReset_Click" ImageUrl="../Images/Reset.gif" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrShift" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Shift %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblShift" CssClass="cssLabel" runat="server" Text='<%# Bind("ShiftCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblShift" CssClass="cssLabel" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrRows" CssClass="cssLabelHeader" runat="server" Text=""></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Table ID="tbl1" runat="server" CellSpacing="0" CellPadding="0" border="0" Style="border: 0px;
                                                                width: 100%;">
                                                                <asp:TableRow ID="TableRow4" runat="server" Style="background-color: #FFFFFF">
                                                                    <asp:TableCell ID="TableCell4" runat="server" Style="border: 0px; text-align: right;
                                                                        white-space: nowrap;">
                                                                        <asp:Label ID="lblShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShiftTime %>"></asp:Label>&nbsp;:&nbsp;
                                                                    </asp:TableCell>
                                                                </asp:TableRow>
                                                            </asp:Table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Table ID="tbl1" runat="server" CellSpacing="0" CellPadding="0" border="0" Style="border: 0px;
                                                                width: 100%;">
                                                                <asp:TableRow ID="TableRow9" runat="server" Style="background-color: #FFFFFF; height: 20px;">
                                                                    <asp:TableCell ID="TableCell9" runat="server" Style="border: 0px; text-align: right;
                                                                        white-space: nowrap;">
                                                                        <asp:Label ID="lblShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShiftTime %>"></asp:Label>&nbsp;:&nbsp;
                                                                    </asp:TableCell>
                                                                </asp:TableRow>
                                                            </asp:Table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Table ID="tbl1" runat="server" CellSpacing="0" CellPadding="0" border="0" Style="border: 0px;
                                                                width: 100%;">
                                                                <asp:TableRow ID="TableRow14" runat="server" Style="background-color: #FFFFFF; height: 20px;">
                                                                    <asp:TableCell ID="TableCell14" runat="server" Style="border: 0px; text-align: right;
                                                                        white-space: nowrap;">
                                                                        <asp:Label ID="lblShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShiftTime %>"></asp:Label>&nbsp;:&nbsp;
                                                                    </asp:TableCell>
                                                                </asp:TableRow>
                                                            </asp:Table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrSunday" runat="server" Text="<%$Resources:Resource,Sunday %>"></asp:Literal>
                                                            <asp:Label ID="ltrBreakSunday" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:Label ID="lblSunTimeFrom" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("SunTimeFrom"))%>'></asp:Label>
                                                                        <asp:Label ID="lblSunTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:Label ID="lblSunTimeTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("SunTimeTo"))%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptSunTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptSunTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptSunTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptSunTimeTo"))%>' />
                                                                        <asp:HiddenField ID="HFBreakLineNo" runat="server" Value='<%# Eval("BreakLineNo")%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtEditSunTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("SunTimeFrom"))%>'></asp:TextBox>
                                                                        <asp:Label ID="lblSunTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtEditSunTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("SunTimeTo"))%>'></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditSunErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptSunTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptSunTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptSunTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptSunTimeTo"))%>' />
                                                                        <asp:HiddenField ID="HFBreakLineNo" runat="server" Value='<%# Eval("BreakLineNo")%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtSunTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text=""></asp:TextBox>
                                                                        <asp:Label ID="lblSunTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtSunTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                            Text=""></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditSunErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:ImageButton ID="ImgbtnCopyTime" runat="server" CssClass="cssImgButton" CommandName="CopyTime" ToolTip="Copy To All" ImageUrl="../Images/copy.png" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrMonday" runat="server" Text="<%$Resources:Resource,Monday %>"></asp:Literal>
                                                            <asp:Label ID="ltrBreakMonday" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF;">
                                                                    <td style="border: 0px">
                                                                        <asp:Label ID="lblMonTimeFrom" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("MonTimeFrom"))%>'></asp:Label>
                                                                        <asp:Label ID="lblMonTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:Label ID="lblMonTimeTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("MonTimeTo"))%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptMonTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptMonTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptMonTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptMonTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtEditMonTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("MonTimeFrom"))%>'></asp:TextBox>
                                                                        <asp:Label ID="lblMonTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtEditMonTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("MonTimeTo"))%>'></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditMonErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptMonTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptMonTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptMonTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptMonTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtMonTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text=""></asp:TextBox>
                                                                        <asp:Label ID="lblMonTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtMonTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                            Text=""></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditMonErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrTuesday" runat="server" Text="<%$Resources:Resource,Tuesday %>"></asp:Literal>
                                                            <asp:Label ID="ltrBreakTuesday" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:Label ID="lblTueTimeFrom" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("TueTimeFrom"))%>'></asp:Label>
                                                                        <asp:Label ID="lblTueTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:Label ID="lblTueTimeTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("TueTimeTo"))%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptTueTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptTueTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptTueTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptTueTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtEditTueTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("TueTimeFrom"))%>'></asp:TextBox>
                                                                        <asp:Label ID="lblTueTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtEditTueTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("TueTimeTo"))%>'></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditTueErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptTueTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptTueTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptTueTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptTueTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtTueTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text=""></asp:TextBox>
                                                                        <asp:Label ID="lblTueTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtTueTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                            Text=""></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditTueErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrWednesday" runat="server" Text="<%$Resources:Resource,Wednesday %>"></asp:Literal>
                                                            <asp:Label ID="ltrBreakWednesday" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:Label ID="lblWedTimeFrom" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("WedTimeFrom"))%>'></asp:Label>
                                                                        <asp:Label ID="lblWedTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:Label ID="lblWedTimeTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("WedTimeTo"))%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptWedTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptWedTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptWedTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptWedTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtEditWedTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("WedTimeFrom"))%>'></asp:TextBox>
                                                                        <asp:Label ID="lblWedTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtEditWedTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("WedTimeTo"))%>'></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditWedErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptWedTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptWedTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptWedTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptWedTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtWedTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text=""></asp:TextBox>
                                                                        <asp:Label ID="lblWedTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtWedTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                            Text=""></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditWedErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrThursday" runat="server" Text="<%$Resources:Resource,Thursday %>"></asp:Literal>
                                                            <asp:Label ID="ltrBreakThursday" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:Label ID="lblThuTimeFrom" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("ThuTimeFrom"))%>'></asp:Label>
                                                                        <asp:Label ID="lblThuTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:Label ID="lblThuTimeTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("ThuTimeTo"))%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptThuTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptThuTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptThuTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptThuTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtEditThuTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("ThuTimeFrom"))%>'></asp:TextBox>
                                                                        <asp:Label ID="lblThuTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtEditThuTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("ThuTimeTo"))%>'></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditThuErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptThuTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptThuTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptThuTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptThuTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtThuTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text=""></asp:TextBox>
                                                                        <asp:Label ID="lblThuTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtThuTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                            Text=""></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditThuErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrFriday" runat="server" Text="<%$Resources:Resource,Friday %>"></asp:Literal>
                                                            <asp:Label ID="ltrBreakFriday" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:Label ID="lblFriTimeFrom" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("FriTimeFrom"))%>'></asp:Label>
                                                                        <asp:Label ID="lblFriTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:Label ID="lblFriTimeTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("FriTimeTo"))%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptFriTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptFriTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptFriTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptFriTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtEditFriTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("FriTimeFrom"))%>'></asp:TextBox>
                                                                        <asp:Label ID="lblFriTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtEditFriTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("FriTimeTo"))%>'></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditFriErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptFriTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptFriTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptFriTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptFriTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtFriTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text=""></asp:TextBox>
                                                                        <asp:Label ID="lblFriTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtFriTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                            Text=""></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditFriErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrSaturday" runat="server" Text="<%$Resources:Resource,Saturday %>"></asp:Literal>
                                                            <asp:Label ID="ltrBreakSaturday" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:Label ID="lblSatTimeFrom" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("SatTimeFrom"))%>'></asp:Label>
                                                                        <asp:Label ID="lblSatTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:Label ID="lblSatTimeTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("SatTimeTo"))%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptSatTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptSatTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptSatTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptSatTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtEditSatTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("SatTimeFrom"))%>'></asp:TextBox>
                                                                        <asp:Label ID="lblSatTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtEditSatTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("SatTimeTo"))%>'></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditSatErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptSatTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptSatTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptSatTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptSatTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtSatTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text=""></asp:TextBox>
                                                                        <asp:Label ID="lblSatTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtSatTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                            Text=""></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditSatErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrHoliday" runat="server" Text="<%$Resources:Resource,Holiday %>"></asp:Literal>
                                                            <asp:Label ID="ltrBreakHoliday" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%;">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:Label ID="lblHolidayTimeFrom" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("HolidayTimeFrom"))%>'></asp:Label>
                                                                        <asp:Label ID="lblHolidayTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:Label ID="lblHolidayTimeTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("HolidayTimeTo"))%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptHolidayTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptHolidayTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptHolidayTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptHolidayTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtEditHolidayTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("HolidayTimeFrom"))%>'></asp:TextBox>
                                                                        <asp:Label ID="lblHolidayTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtEditHolidayTimeTo" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text='<%# String.Format("{0:HH:mm}",Eval("HolidayTimeTo"))%>'></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditHolidayErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                        <asp:HiddenField ID="HFDeptHolidayTimeFrom" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptHolidayTimeFrom"))%>' />
                                                                        <asp:HiddenField ID="HFDeptHolidayTimeTo" runat="server" Value='<%# String.Format("{0:HH:mm}",Eval("DeptHolidayTimeTo"))%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" style="border: 0px; width: 100%">
                                                                <tr style="background-color: #FFFFFF">
                                                                    <td style="border: 0px">
                                                                        <asp:TextBox ID="TxtHolidayTimeFrom" CssClass="csstxtbox" Width="30px" runat="server"
                                                                            MaxLength="5" Text=""></asp:TextBox>
                                                                        <asp:Label ID="lblHolidayTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                                        <asp:TextBox ID="TxtHolidayTimeTo" CssClass="csstxtbox" Width="30px" runat="server" MaxLength="5"
                                                                            Text=""></asp:TextBox>
                                                                        <asp:Label EnableViewState="false" ID="lblEditHolidayErrorMsg" Text="" runat="server"
                                                                            CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrSaturday1" runat="server" Text="<%$Resources:Resource,Billable %>"></asp:Literal>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbBillable" Enabled="false" runat="server" Checked='<%# Eval("IsBillable")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:CheckBox ID="cbBillable" runat="server" Checked='<%# Eval("IsBillable")%>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:CheckBox ID="cbBillable" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="ltrSaturday2" runat="server" Text="IsPayable"></asp:Literal>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbPayable" Enabled="false" runat="server" Checked='<%# Eval("IsPayable")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:CheckBox ID="cbPayable" runat="server" Checked='<%# Eval("IsPayable")%>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:CheckBox ID="cbPayable" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </Ajax:UpdatePanel>
                                </ContentTemplate>
                            </telerik:RadWindow>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </Ajax:UpdatePanel>
</div>
    <script language="javascript" type="text/javascript">

        function OpenRadWindow() {
            var RadWindowMessage = $find('<%=RadWindow.ClientID %>');
            RadWindowMessage.show();
        }
        function RadWindowClose() {
            var RadWindowMessage = $find('<%=RadWindow.ClientID %>');
            RadWindowMessage.close();
        }

        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
        }

        document.onkeypress = stopRKey;
        var ZeroNotAllowed = '<%= Resources.Resource.PostPayRateCannotBeZero %>';
        function PayRateValidation(obj) {
            var values = obj.id.split('_');
            var Prefix = values[0] + values[1] + values[2] + values[3];
            var GridView = document.getElementById('<%=gvPattren.ClientID%>');
            var Inputs = GridView.getElementsByTagName("input");
            var pattern = /PayRate/;
            var patternReq = /NoOfPersons/;
            var num = 0;
            var numPersons = 0;
            var PayRateType = getParameterByName("PayRateType");
            var confirm_value = document.createElement("INPUT");

            for (var i = 0; i < Inputs.length; ++i) {
                var element = Inputs[i];
                var match = element.id.split('_');
                match = match[0] + match[1] + match[2] + match[3];

                if (patternReq.test(element.id) && Prefix == match) {
                    if (document.getElementById(element.id).value != null) {
                        numPersons = isNaN(parseFloat(document.getElementById(element.id).value)) ? 0 : parseFloat(document.getElementById(element.id).value);
                    }
                }

                if (pattern.test(element.id) && Prefix == match) {
                    if (document.getElementById(element.id).value != null) {
                        ////num = (isNaN(parseFloat(num)) ? 0 : parseFloat(num)) + (isNaN(parseFloat(document.getElementById(element.id).value)) ? 0 : parseFloat(document.getElementById(element.id).value)); ;
                        num = (isNaN(parseFloat(document.getElementById(element.id).value)) ? 0 : parseFloat(document.getElementById(element.id).value));
                        confirm_value.type = "hidden";
                        confirm_value.name = "confirm_value";
                        confirm_value.value = null;
                        if (numPersons > 0 && num <= 0 && PayRateType == "Post") {

                            alert(ZeroNotAllowed);
                            confirm_value.value = "No";
                            break;
                        }
                        else
                            confirm_value.value = "Yes";

                        numPersons = 0;
                    }
                }
            }


            document.forms[0].appendChild(confirm_value);

        }

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    results = regex.exec(location.search);
            return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        
      
    </script>
</asp:Content>
