<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="true" CodeFile="BreakShiftDetails.aspx.cs" Inherits="Sales_BreakShiftDetails" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblSearch" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Search %>"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSearch" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Text="<%$ Resources:Resource,ClientCode %>" Value="ClientCode"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Resource,Assignment %>" Value="AsmtID"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Resource,Post %>" Value="Post"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="csstxtbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Go %>"
                    OnClick="BtnSearchClick" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right">
                <asp:CheckBox ID="CBLastAmendment" runat="server" Checked="true" Text="<%$ Resources:Resource,LastAmendment %>"
                    AutoPostBack="true" OnCheckedChanged="CbLastAmendmentCheckedChanged" />
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="100%" Height="480px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:HiddenField runat="server" ID="hfAsmtID" Value="" />
                                        <asp:HiddenField runat="server" ID="hfClientCode" Value="" />
                                        <asp:HiddenField ID="hfPostAutoID" runat="server" Value="" />
                                        <asp:GridView Width="100%" ID="gvPost" CssClass="GridViewStyle" runat="server" ShowFooter="true"
                                            ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15" CellPadding="1"
                                            GridLines="None" AutoGenerateColumns="False" OnRowCommand="GvPostRowCommand" OnRowDeleting="GvPostRowDeleting"
                                            OnRowEditing="GvPostRowEditing" OnRowCancelingEdit="GvPostRowCancelingEdit" OnRowUpdating="GvPostRowUpdating"
                                            OnRowDataBound="GvPostRowDataBound" OnPageIndexChanging="GvPostPageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>">
                                                        </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="1%" />
                                                    <HeaderStyle Width="1%" />
                                                    <FooterStyle Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAmendNo" CssClass="cssLabelHeader" runat="server" Text="Amend No"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmendNo" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmendNo").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblAmendNo" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmendNo").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="1%" />
                                                    <HeaderStyle Width="1%" />
                                                    <FooterStyle Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrClientCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# Eval("ClientName")%>'></asp:Label>
                                                        <asp:HiddenField ID="hfClientCode" runat="server" Value='<%# Eval("ClientCode")%>' />
                                                        <asp:HiddenField ID="hfAsmtID" runat="server" Value='<%# Eval("AsmtId")%>' />
                                                        <asp:HiddenField ID="hfPostAutoID" runat="server" Value='<%# Eval("post")%>' />
                                                        <asp:HiddenField ID="hfMaxAmendNoStatus" runat="server" Value='<%# Eval("AmendNoStatus")%>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'></asp:Label>
                                                        <asp:HiddenField ID="hfClientCode" runat="server" Value='<%# Eval("ClientCode")%>' />
                                                        <asp:HiddenField ID="hfAsmtID" runat="server" Value='<%# Eval("AsmtId")%>' />
                                                        <asp:HiddenField ID="hfPostAutoID" runat="server" Value='<%# Eval("post")%>' />
                                                        <asp:HiddenField ID="hfMaxAmendNoStatus" runat="server" Value='<%# Eval("AmendNoStatus")%>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <telerik:RadComboBox ID="ddlClient" AllowCustomText="true" Filter="Contains" EnableEmbeddedSkins="true"
                                                            CheckBoxes="True" AutoPostBack="true"
                                                            IsCaseSensitive="false" OnSelectedIndexChanged="DdlClientSelectedIndexChanged"
                                                            MarkFirstMatch="true" NoWrap="false" Width="100%" runat="server">
                                                        </telerik:RadComboBox>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="20%" />
                                                    <HeaderStyle Width="20%" />
                                                    <FooterStyle Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAsmtId" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AsmtId %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtName").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtName").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <telerik:RadComboBox ID="ddlAsmt" AllowCustomText="true" Filter="Contains" EnableEmbeddedSkins="true"
                                                            CheckBoxes="True" AutoPostBack="true"
                                                            IsCaseSensitive="false" OnSelectedIndexChanged="DdlAsmtSelectedIndexChanged"
                                                            MarkFirstMatch="true" NoWrap="false" Width="100%" runat="server">
                                                        </telerik:RadComboBox>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="20%" />
                                                    <HeaderStyle Width="20%" />
                                                    <FooterStyle Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrPostDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PostDesc %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPostDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostDesc").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvPostDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <telerik:RadComboBox ID="ddlPost" AllowCustomText="true" Filter="Contains" EnableEmbeddedSkins="true"
                                                            CheckBoxes="True" AutoPostBack="False" 
                                                            IsCaseSensitive="false" MarkFirstMatch="true" NoWrap="false" Width="100%" runat="server">
                                                        </telerik:RadComboBox>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="20%" />
                                                    <HeaderStyle Width="20%" />
                                                    <FooterStyle Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="8%" FooterStyle-Width="8%" ItemStyle-Width="8%">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrShift" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShiftHours %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvShift" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Shift").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvShift" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Shift").ToString() %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="40px" ID="txtShift" CssClass="csstxtbox" runat="server" MaxLength="4"></asp:TextBox>
                                                        <asp:RangeValidator ID="rvFactor" runat="server" Type="Double" MinimumValue="1" MaximumValue="24"
                                                            ControlToValidate="txtShift" ErrorMessage="*" ValidationGroup="vgHrFooter" />
                                                        <asp:RequiredFieldValidator ID="rfvFactor" ValidationGroup="vgHrFooter" ControlToValidate="txtShift"
                                                            runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="8%" FooterStyle-Width="8%" ItemStyle-Width="8%">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrBreakHours" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, BreakMinutes %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvBreakHours" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BreakHours").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="40px" ID="txtEditBreakHours" CssClass="csstxtbox" MaxLength="6"
                                                            runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BreakHours").ToString()%>'></asp:TextBox>
                                                        <asp:RangeValidator ID="rvEditBreakHours" runat="server" Type="Double" MinimumValue="1"
                                                            MaximumValue="1440" ControlToValidate="txtEditBreakHours" ErrorMessage="*" ValidationGroup="vgHrEdit" />
                                                        <asp:RequiredFieldValidator ID="rfvEditBreakHours" ValidationGroup="vgHrEdit" ControlToValidate="txtEditBreakHours"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="40px" ID="txtBreakHours" CssClass="csstxtbox" runat="server"
                                                            MaxLength="6"></asp:TextBox>
                                                        <asp:RangeValidator ID="rvBreakHours" runat="server" Type="Double" MinimumValue="1"
                                                            MaximumValue="1440" ControlToValidate="txtBreakHours" ErrorMessage="*" ValidationGroup="vgHrFooter" />
                                                        <asp:RequiredFieldValidator ID="rfvBreakHours" ValidationGroup="vgHrFooter" ControlToValidate="txtBreakHours"
                                                            runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="10%" FooterStyle-Width="10%" ItemStyle-Width="10%">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" Visible="true" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="imgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="imgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                            ValidationGroup="vgHrEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                        <asp:Button ID="btnExportEdit" Visible="true" Enabled="false" CssClass="cssButton"
                                                            runat="server" Text="<%$Resources:Resource,ExporttoExcel %>" OnClick="BtnExportEditClick" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="imgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                            ValidationGroup="vgHrFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:Button ID="btnExport" Visible="true" Enabled="false" CssClass="cssButton" runat="server"
                                                            Text="<%$Resources:Resource,ExporttoExcel %>" OnClick="BtnExportClick" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">

        window.onbeforeunload = CallParentWindowFunction;
        function CallParentWindowFunction() {

            if (window.opener != null) {
                window.opener.ParentWindowFunction();
            }
        }
    </script>
</asp:Content>
