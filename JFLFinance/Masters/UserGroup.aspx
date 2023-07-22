<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserGroup.aspx.cs" Inherits="Masters_UserGroup" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvUserGroup" CssClass="GridViewStyle" runat="server"
                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvUserGroup_RowCommand"
                OnRowUpdating="gvUserGroup_RowUpdating" OnRowDeleting="gvUserGroup_RowDeleting"
                OnRowEditing="gvUserGroup_RowEditing" OnRowCancelingEdit="gvUserGroup_RowCancelingEdit"
                OnRowDataBound="gvUserGroup_RowDataBound" OnPageIndexChanging="gvUserGroup_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" Text='<%# Container.DataItemIndex + 1 %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="40px" />
                        <HeaderStyle Width="40px" />
                        <FooterStyle Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrUGCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserGroupCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvUGCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserGroupCode").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblgvUGCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserGroupCode").ToString()%>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="120px" ID="txtUGCode" CssClass="csstxtbox" runat="server" Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUGCode" ValidationGroup="vgCFooter" ControlToValidate="txtUGCode"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrUGName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserGroupName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvUGName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserGroupName").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="280px" ID="txtUGName" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserGroupName").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUGName" ValidationGroup="vgCEdit" ControlToValidate="txtUGName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="280px" ID="txtUGName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUGName" ValidationGroup="vgCFooter" ControlToValidate="txtUGName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%--<asp:Label ID="lblRedirect" runat="server" CssClass="cssLabel" Text="Add functionality"></asp:Label>--%>
                            <asp:HyperLink ID="hlAccessRights" runat="server" Text="AddFunctionality"></asp:HyperLink>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnEdit" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                ValidationGroup="vgCEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                ValidationGroup="vgCEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, AddNew %>" ValidationGroup="vgCFooter" CommandName="Add"></asp:LinkButton>
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
