<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConstraintType.aspx.cs" Inherits="Masters_ConstraintType" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel ID="upConstraintType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvConstraintType" CssClass="GridViewStyle" runat="server"
                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvConstraintType_RowCommand"
                OnRowUpdating="gvConstraintType_RowUpdating" OnRowDeleting="gvConstraintType_RowDeleting"
                OnRowEditing="gvConstraintType_RowEditing" OnRowCancelingEdit="gvConstraintType_RowCancelingEdit"
                OnRowDataBound="gvConstraintType_RowDataBound" OnPageIndexChanging="gvConstraintType_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
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
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Width="50px" />
                        <FooterStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ConstraintTypeCode %>">
                        <ItemTemplate>
                            <asp:Label ID="lblConstraintTypeCode" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeCode").ToString()%>'></asp:Label>
                            <asp:HiddenField ID="HFConstraintTypeAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeAutoID").ToString()%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblEditConstraintTypeCode" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeCode").ToString()%>'></asp:Label>
                            <asp:HiddenField ID="HFConstraintTypeAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeAutoID").ToString()%>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtConstraintTypeCode" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                        </FooterTemplate>
                        <ItemStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ConstraintTypeDesc %>">
                        <ItemTemplate>
                            <asp:Label ID="lblConstraintTypeDesc" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeDesc").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtConstraintTypeDesc" Width="250px" CssClass="csstxtbox" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeDesc").ToString()%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtConstraintTypeDesc" Width="250px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                        </FooterTemplate>
                        <ItemStyle Width="250px" />
                        <HeaderStyle Width="250px" />
                        <FooterStyle Width="250px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
