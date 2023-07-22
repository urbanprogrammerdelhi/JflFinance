<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterSearch.master" AutoEventWireup="true"
    CodeFile="SOItemDeptPattren.aspx.cs" Inherits="Sales_SOItemDeptPattren" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/jscript">
        var oldgridSelectedColor;
        var newgridSelectedColor = '#7ca8d3';
        function CheckUncheckAllLoc(ObjCheckBox, ObjNameToCheck) {
            var frm = document.aspnetForm;
            var ChkState = ObjCheckBox.checked;

            var objCell = ObjCheckBox.parentElement.parentElement;
            var objRow = objCell.parentElement;
            var objTable = objRow.parentElement.parentElement;

            var mycolor;
            if (ObjCheckBox.checked == true) {
                oldgridSelectedColor = objCell.style.backgroundColor;
                mycolor = newgridSelectedColor;
            }
            else {
                mycolor = oldgridSelectedColor;
            }

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(ObjNameToCheck) != -1 && e.disabled == false) {
                    e.checked = ChkState;
                    e.parentElement.parentElement.style.backgroundColor = mycolor;
                }
            }
        }
        function CheckUncheckCB(ObjCheckBox) {
            var mycolor;
            if (ObjCheckBox.checked == false) {
                mycolor = oldgridSelectedColor;
                ObjCheckBox.parentElement.parentElement.style.backgroundColor = mycolor;
            }
            else {
                oldgridSelectedColor = ObjCheckBox.parentElement.parentElement.style.backgroundColor;
                mycolor = newgridSelectedColor;
                ObjCheckBox.parentElement.parentElement.style.backgroundColor = mycolor;
            }
        }
    </script>

    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td height="20px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--<div class="container" style="width: 790px;">
                                        <h2>
                                            <tt><a id="A2" href="#" runat="server" onclick="expandSection('Div3')">
                                                <asp:Label ID="Label1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, WeeklyDepPattern %>"></asp:Label></a></tt></h2>
                                        <div id="Div3" class="section" style="overflow: auto; width: 790px; height: 270px">--%>
                                    <div style="width: 790px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width: 770px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label23" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,WeeklyDepPattern %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label Width="150px" ID="lblfixSoNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SONo %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label Width="150px" Style="font-weight: bold;" ID="lblSoNo" CssClass="csstxtbox"
                                                                runat="server" Text=""></asp:Label>
                                                            <asp:HiddenField ID="hfLocationAutoId" runat="server" />
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label Width="150px" ID="lblfixSOAmendNo" CssClass="cssLabel" runat="server"
                                                                Text="<%$ Resources:Resource, SOAmendNo %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label Width="150px" Style="font-weight: bold;" ID="lblSOAmendNo" CssClass="csstxtbox"
                                                                runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label Width="150px" ID="lblfixAsmtID" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AsmtID %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label Width="150px" Style="font-weight: bold;" ID="lblAsmtID" CssClass="csstxtbox"
                                                                runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label Width="150px" ID="lblfixSoStatus" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SOStatus %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label Width="150px" Style="font-weight: bold;" ID="lblSoStatus" CssClass="csstxtbox"
                                                                runat="server" Text=""></asp:Label><asp:HiddenField ID="hfIsMAXSOAmendNo" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:HiddenField ID="hfQty" runat="server" />
                                                            <asp:HiddenField ID="HFSoItemActiveStatus" runat="server" />
                                                            <asp:HiddenField ID="hfRate" runat="server" />
                                                            <asp:HiddenField ID="hfIsBillable" runat="server" />
                                                            <asp:HiddenField ID="hfDaysInMonth" runat="server" />
                                                            <asp:HiddenField ID="hfRemainingDays" runat="server" />
                                                            <asp:HiddenField ID="hfBillingPattern" runat="server" />
                                                            <asp:HiddenField ID="HFItemTypeCode" runat="server" />
                                                            <asp:HiddenField ID="HFActualDaysInMonth" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:GridView Width="790px" ID="gvPattren" CssClass="GridViewStyle" runat="server"
                                                    ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                                    CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvPattren_RowDataBound">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-Width="85px" FooterStyle-Width="85px" ItemStyle-Width="85px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrWeekNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, WeekNO %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvWeekNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WeekNo").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbAllSun" CssClass="cssCheckBox" runat="server" Text="<%$ Resources:Resource, Sunday %>"
                                                                    onclick="javascript:CheckUncheckAllLoc(this,'cbSun');" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbSun" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Sun").ToString())%>'
                                                                    onclick="javascript:CheckUncheckCB(this);" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbAllMon" CssClass="cssCheckBox" runat="server" Text="<%$ Resources:Resource, Monday %>"
                                                                    onclick="javascript:CheckUncheckAllLoc(this,'cbMon');" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbMon" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Mon").ToString())%>'
                                                                    onclick="javascript:CheckUncheckCB(this);" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbAllTue" CssClass="cssCheckBox" runat="server" Text="<%$ Resources:Resource, Tuesday %>"
                                                                    onclick="javascript:CheckUncheckAllLoc(this,'cbTue');" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbTue" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Tue").ToString())%>'
                                                                    onclick="javascript:CheckUncheckCB(this);" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="120px" FooterStyle-Width="120px" ItemStyle-Width="120px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbAllWed" CssClass="cssCheckBox" runat="server" Text="<%$ Resources:Resource, Wednesday %>"
                                                                    onclick="javascript:CheckUncheckAllLoc(this,'cbWed');" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbWed" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Wed").ToString())%>'
                                                                    onclick="javascript:CheckUncheckCB(this);" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbAllThu" CssClass="cssCheckBox" runat="server" Text="<%$ Resources:Resource, Thursday %>"
                                                                    onclick="javascript:CheckUncheckAllLoc(this,'cbThu');" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbThu" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Thu").ToString())%>'
                                                                    onclick="javascript:CheckUncheckCB(this);" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbAllFri" CssClass="cssCheckBox" runat="server" Text="<%$ Resources:Resource, Friday %>"
                                                                    onclick="javascript:CheckUncheckAllLoc(this,'cbFri');" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbFri" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Fri").ToString())%>'
                                                                    onclick="javascript:CheckUncheckCB(this);" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbAllSat" CssClass="cssCheckBox" runat="server" Text="<%$ Resources:Resource, Saturday %>"
                                                                    onclick="javascript:CheckUncheckAllLoc(this,'cbSat');" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbSat" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Sat").ToString())%>'
                                                                    onclick="javascript:CheckUncheckCB(this);" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrHoursInWeek" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, HoursInWeek %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHoursInWeek" CssClass="cssLable" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="lblExcludedDays" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-- <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDaysInWeek" CssClass="cssLable" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                                <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Resource, Rate %>"></asp:Label>
                                                            <asp:TextBox ID="txtTotalRate" MaxLength="15" CssClass="csstxtbox" Text="" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="cssButton"
                                        Text="<%$ Resources:Resource, Save %>" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
