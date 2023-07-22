<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HrIdType.aspx.cs" Inherits="Masters_HrIdType" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="btnExport" Visible="true" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>"
        OnClick="btnExport_Click" />
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvIdType" CssClass="GridViewStyle" runat="server"
                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvIdType_RowCommand"
                OnRowUpdating="gvIdType_RowUpdating" OnRowDeleting="gvIdType_RowDeleting" OnRowEditing="gvIdType_RowEditing"
                OnRowCancelingEdit="gvIdType_RowCancelingEdit" OnRowDataBound="gvIdType_RowDataBound"
                OnPageIndexChanging="gvIdType_PageIndexChanging">
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
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Width="50px" />
                        <FooterStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrIdTypeCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, IdTypeCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvhdrIdTypeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdTypeCode").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblgvhdrIdTypeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdTypeCode").ToString()%>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="180px" ID="txtIdTypeCode" CssClass="csstxtbox" MaxLength="32" runat="server"
                                Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdTypeCode" ValidationGroup="vgCFooter" ControlToValidate="txtIdTypeCode"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemStyle Width="200px" />
                        <HeaderStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrIdTypeDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, IdTypeDesc %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvIdTypeDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdTypeDesc").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="280px" ID="txtIdTypeDesc" CssClass="csstxtbox" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem, "IdTypeDesc").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdTypeDesc" ValidationGroup="vgCEdit" ControlToValidate="txtIdTypeDesc"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="280px" ID="txtIdTypeDesc" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdTypeDesc" ValidationGroup="vgCFooter" ControlToValidate="txtIdTypeDesc"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemStyle Width="300px" />
                        <HeaderStyle Width="300px" />
                        <FooterStyle Width="300px" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrCompanyAdd" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, CompanyAddress %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvCompanyAdd" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyAddress").ToString()%>'></asp:Label>
                        </ItemTemplate>--%>
                        <%-- <EditItemTemplate>
                            <asp:TextBox Width="330px" ID="txtCompanyAddress" CssClass="csstxtbox" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem, "CompanyAddress").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCompanyAddress" ValidationGroup="vgCEdit" ControlToValidate="txtCompanyAddress"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>--%>
                        <%--   <FooterTemplate>
                            <asp:TextBox Width="330px" ID="txtCompanyAddress" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCompanyAddress" ValidationGroup="vgCFooter" ControlToValidate="txtCompanyAddress"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>--%>
                        <%--<ItemStyle Width="350px" />--%>
                        <%--   <HeaderStyle Width="350px" />
                        <FooterStyle Width="350px" />
                    </asp:TemplateField>--%>
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

