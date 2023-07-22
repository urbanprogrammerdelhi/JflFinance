<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeCategory.aspx.cs" Inherits="Masters_EmployeeCategory" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" style="width: 400px; text-align: left;" align="left">
                                        <tr>
                                            <td style="width: 150px; text-align: left; vertical-align: middle;">
                                                <asp:Label CssClass="cssLable" ID="lblSearch" Width="100px" runat="server" Text="<%$Resources:Resource,SearchEmployee %>"></asp:Label>
                                                <img id="ImgBtnSearch" src="../Images/icosearch.gif" onclick="javascript:expandSection('divSearchWeekOff');" />
                                            </td>
                                            <td style="width: 100px; text-align: left;" align="left">
                                                <div id="divSearchWeekOff" class="container" style="width: 382px; text-align: center;
                                                    display: none; position: absolute;">
                                                    <h2>
                                                        <tt><a id="A2" href="#" runat="server" onclick="expandSection('divSearch')">
                                                            <asp:Label ID="Label1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, search %>"></asp:Label></a></tt></h2>
                                                    <div id="divSearch" class="section" style="overflow: auto; width: 380px; height: 110px;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label CssClass="cssLable" ID="lblEmpNumber" runat="server" Text="<%$ Resources:Resource, EmployeeNumber  %>"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSearchEmpNumberOPR" runat="server" CssClass="cssDropDown"
                                                                        Width="80px">
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlSearchEmpNumberCON" runat="server" CssClass="cssDropDown"
                                                                        Width="100px">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtEmpNumber" runat="server" CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label CssClass="cssLable" ID="lblFirstName" runat="server" Text="<%$ Resources:Resource, FirstName  %>"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSearchFirstNameOPR" runat="server" CssClass="cssDropDown"
                                                                        Width="80px">
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlSearchFirstNameCON" runat="server" CssClass="cssDropDown"
                                                                        Width="100px">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtEmpFirstName" runat="server" CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label CssClass="cssLable" ID="lblLastName" runat="server" Text="<%$ Resources:Resource, LastName  %>"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSearchLastNameOPR" runat="server" CssClass="cssDropDown"
                                                                        Width="80px">
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlSearchLastNameCON" runat="server" CssClass="cssDropDown"
                                                                        Width="100px">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtEmpLastName" runat="server" CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Button ID="btnSearchWeekOff" CssClass="cssSearchButton" runat="server" ToolTip="<%$ Resources:Resource, Search %>"
                                                                        Text="<%$ Resources:Resource, Search %>" OnClick="BtnSearchWeekOff_Click" />
                                                                    <asp:Button ID="btnReset" CssClass="cssButton" runat="server" ToolTip="<%$ Resources:Resource, Reset %>"
                                                                        Text="<%$ Resources:Resource, Reset %>" OnClick="BtnReset_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="1250px" ID="GvEmployeeCategory" runat="server" AllowPaging="True"
                                            CellPadding="1" ShowFooter="True" Visible="true" GridLines="None" AutoGenerateColumns="False"
                                            OnRowEditing="GvEmployeeCategory_RowEditing" OnRowUpdating="GvEmployeeCategory_RowUpdating"
                                            OnRowCancelingEdit="GvEmployeeCategory_RowCancelingEdit" OnRowDataBound="GvEmployeeCategory_RowDataBound"
                                            OnPageIndexChanging="GvEmployeeCategory_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-Width="50px" FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderSerial" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerial" CssClass="cssLable" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Company Name" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCompanyDesc" CssClass="cssLable" runat="server" Text='<%# Bind("CompanyDesc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCompanyDesc" CssClass="cssLable" runat="server" Text='<%# Eval("CompanyDesc") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEmployeeNumber" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Eval("EmployeeNumber") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="250px" FooterStyle-Width="250px" ItemStyle-Width="250px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" CssClass="cssLable" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblName" CssClass="cssLable" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderCategoryCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, CategoryCode %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategoryCode" CssClass="cssLable" runat="server" Text='<%# Bind("CategoryCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCategoryCode" CssClass="cssLable" runat="server" Text='<%# Eval("CategoryCode") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderCategoryDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, CategoryDescription %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategoryDesc" CssClass="cssLable" runat="server" Text='<%# Bind("CategoryDesc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCategoryDesc" CssClass="cssLable" runat="server" Text='<%# Eval("CategoryDesc") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EffectiveFrom %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False" HeaderStyle-Width="200px" FooterStyle-Width="200px"
                                                    ItemStyle-Width="200px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveTo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EffectiveTo %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveTo" CssClass="cssLable" runat="server" Text='<%# Bind("EffectiveTo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="150px" ID="txtEffectiveTo" CssClass="csstxtbox" runat="server"
                                                            Text='<%# Bind("EffectiveTo") %>'></asp:TextBox>
                                                        <asp:HyperLink Style="vertical-align: top;" ID="imgEffectiveToDate" runat="server"
                                                            ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                        <AjaxToolKit:CalendarExtender ID="CEimgEffectiveToDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveTo" PopupButtonID="imgEffectiveToDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="reqEffectiveTo" SetFocusOnError="true" ErrorMessage="*"
                                                            runat="server" ControlToValidate="txtEffectiveTo"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False" HeaderStyle-Width="200px" FooterStyle-Width="200px"
                                                    ItemStyle-Width="200px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderFutureCategory" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource, FutureCategory %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFutureCategory" CssClass="cssLable" runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList Width="180px" ID="cmbFutureCategory" CssClass="csstxtbox" runat="server" />
                                                        <asp:CompareValidator ID="comFutureCategory" ErrorMessage="*" SetFocusOnError="true"
                                                            ValueToCompare='<%# Bind("CategoryCode") %>' Operator="NotEqual" ControlToValidate="cmbFutureCategory"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderAction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Action %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CausesValidation="True"
                                                            CommandName="Update" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CausesValidation="False"
                                                            CommandName="Cancel" ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CausesValidation="False"
                                                            CommandName="Edit" ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
