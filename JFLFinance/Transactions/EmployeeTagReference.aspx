<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeTagReference.aspx.cs" Inherits="Transactions_EmployeeTagReference"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="950" border="0">
                            <tr>
                                <td width="150">
                                    <asp:DropDownList ID="ddlSearchBy" Width="150px" runat="server" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td width="230">
                                    <asp:TextBox ID="txtSearch" Width="200px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hfSearchText" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="Button1" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                                        OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnViewAll" Visible="false" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                        OnClick="btnViewAll_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table width="950" border="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvEmpTagRef" Width="950" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" CellPadding="0"
                                            PageSize="15" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvEmpTagRef_RowCommand"
                                            OnRowDeleting="gvEmpTagRef_RowDeleting" OnPageIndexChanging="gvEmpTagRef_PageIndexChanging"
                                            OnRowDataBound="gvEmpTagRef_RowDataBound">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="50" HeaderStyle-Width="50" FooterStyle-Width="50">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrTagRefSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTagRefSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle Width="50px" />
                                                    <HeaderStyle Width="50px" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100" HeaderStyle-Width="200" HeaderText="<%$ Resources:Resource, TagId %>"
                                                    HeaderStyle-HorizontalAlign="Left" FooterStyle-Width="200">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrTagId" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, TagId %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTagId" CssClass="cssLable" runat="server" Text='<%# Eval("EmployeeTagID").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtNewTagId" Width="80" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtTagRefIdValidator" runat="server" ControlToValidate="txtNewTagId"
                                                            ErrorMessage="cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle Width="100px" />
                                                    <HeaderStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100" HeaderStyle-Width="100" HeaderText="<%$ Resources:Resource,EmployeeNumber %>"
                                                    HeaderStyle-HorizontalAlign="Left" FooterStyle-Width="100">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEmployeeNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Eval("EmployeeNumber").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="TxtEmployeeNumber" Width="80" CssClass="csstxtbox" runat="server"
                                                            AutoPostBack="false" MaxLength="16"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtEmployeeNumberValidator" runat="server" ControlToValidate="TxtEmployeeNumber"
                                                            ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle Width="100px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="200" HeaderStyle-Width="200" HeaderText="<%$ Resources:Resource,EmployeeName %>"
                                                    HeaderStyle-HorizontalAlign="Left" FooterStyle-Width="200">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEmployeeName" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,EmployeeName %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAbsconderName" CssClass="cssLable" runat="server" Text='<%# Eval("EmployeeName").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <%-- <FooterTemplate>
                                                        <asp:TextBox ID="txtNewEmployeeName" Width="180" CssClass="csstxtbox" runat="server"
                                                            MaxLength="100"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtNewEmployeeValidator" runat="server" ControlToValidate="txtNewEmployeeName"
                                                            ErrorMessage="cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>--%>
                                                    <FooterStyle Width="200px" />
                                                    <HeaderStyle Width="180px" />
                                                    <ItemStyle Width="200px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="220" HeaderStyle-Width="220" HeaderStyle-HorizontalAlign="Left"
                                                    FooterStyle-Width="220">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveFrom %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtEffectiveFrom" Width="70" CssClass="csstxtbox" runat="server"
                                                            MaxLength="11"></asp:TextBox>
                                                        <asp:HyperLink ID="ImgEffectiveFrom" Style="vertical-align: middle; border: 1px"
                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEffectiveFrom" PopupButtonID="ImgEffectiveFrom">
                                                        </AjaxToolKit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="txtEffectiveFromValidator" runat="server" ControlToValidate="txtEffectiveFrom"
                                                            ErrorMessage="cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle Width="120px" />
                                                    <HeaderStyle Width="120px" />
                                                    <ItemStyle Width="120px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150" HeaderStyle-Width="150" HeaderStyle-HorizontalAlign="Left"
                                                    FooterStyle-Width="120">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveTo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveTo %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtgvEffectiveTo" Width="80px" CssClass="csstxtbox" runat="server"
                                                            Text=''></asp:TextBox>
                                                        <asp:HyperLink ID="ImgEffectiveTo" Style="vertical-align: middle; border: 1px" runat="server"
                                                            ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtgvEffectiveTo" PopupButtonID="ImgEffectiveTo">
                                                        </AjaxToolKit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="txtEffectiveToValidator" runat="server" ControlToValidate="txtgvEffectiveTo"
                                                            ErrorMessage="cannot be blank!" ValidationGroup='<%# Eval("EmployeeNumber").ToString()%>'>*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="150px" />
                                                    <ItemStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CausesValidation="true" CssClass="cssImgButton"
                                                            CommandName="Delete" ToolTip="<%$ Resources:Resource, Close %>" ValidationGroup='<%# Eval("EmployeeNumber").ToString()%>'
                                                            ImageUrl="../Images/TerminateEmp.gif" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="true" CssClass="cssImgButton"
                                                            CommandName="Delete1" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add New"
                                                            ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" OnClick="btnReset_Click"
                                                            CommandName="Reset" ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="200">
                                                    <ItemTemplate>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="200px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="Left">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
