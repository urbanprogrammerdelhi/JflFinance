<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CostCenterMapping.aspx.cs" Inherits="Masters_CostCenterMapping" Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" width="100%">
                            <tr>
                                <td style="text-align: right">
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, MainMenu %>"
                                        OnClick="imgBack_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="900px" ID="gvCostCenterMapping" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="false" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvCostCenterMapping_RowCommand"
                                            OnRowEditing="gvCostCenterMapping_RowEditing" OnRowCancelingEdit="gvCostCenterMapping_RowCancelingEdit"
                                            OnRowUpdating="gvCostCenterMapping_RowUpdating" OnRowDeleting="gvCostCenterMapping_RowDeleting"
                                            OnRowDataBound="gvCostCenterMapping_RowDataBound" OnPageIndexChanging="gvCostCenterMapping_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-Width="50px" FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="50px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblClientName" CssClass="cssLabelHeader" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientName" CssClass="cssLabel" Text='<%# Bind("ClientName") %>' runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hfClientCode" runat="server" Value='<%# Bind("ClientCode") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblAssignment" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Assignment %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAssignment" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Assignment").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblAssignment" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Assignment").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
<%--                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlAssignment" CssClass="cssDropDown" OnSelectedIndexChanged="DdlAssignmentSelectedIndexChange"
                                                            AutoPostBack="true" />
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblSiteName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SiteName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSiteName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Site").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblSiteName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Site").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
<%--                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlSite" CssClass="cssDropDown" />
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblCostCenter" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, CostCenter %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCostCenter" CssClass="cssLable" runat="server" Text='<%# Bind("CostCenter") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtCostCenter" CssClass="csstxtbox" runat="server" Text='<%# Bind("CostCenter") %>'></asp:TextBox>
                                                    </EditItemTemplate>
<%--                                                    <FooterTemplate>
                                                        <asp:TextBox runat="server" ID="txtCostCenter" CssClass="csstxtbox,8"></asp:TextBox>
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                        <asp:ImageButton runat="server" ID="lnkbtnDelete" CssClass="csslnkButton" ToolTip="<%$ Resources:Resource, Delete %>"
                                                            CommandName="Delete" ImageUrl="../Images/Delete.gif"></asp:ImageButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                            ValidationGroup="vgHrEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                                            ValidationGroup="vgHrEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                                                    </EditItemTemplate>
<%--                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                            ValidationGroup="vgHrFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                                            ValidationGroup="vgHrFooter" Text="<%$ Resources:Resource, AddNew %>" CommandName="Add"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                                                    </FooterTemplate>--%>
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
</asp:Content>
