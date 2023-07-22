<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Category.aspx.cs" Inherits="Masters_Category" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvCategory" Width="100%" CssClass="GridViewStyle" runat="server"
                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" CellPadding="3"
                GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCategory_SelectedIndexChanged"
                OnRowEditing="gvCategory_rowEditing" OnRowUpdating="gvCategory_RowUpdating" OnRowCommand="gvCategory_RowCommand"
                OnRowDeleting="gvCategory_RowDeleting" OnPageIndexChanging="gvCategory_PageIndexChanging"
                OnRowCancelingEdit="lnkBtnCancel_Click" OnDataBound="gvCategory_DataBound" OnRowDataBound="gvCategory_RowDataBound">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="50" HeaderStyle-Width="50" FooterStyle-Width="50">
                        <HeaderTemplate>
                            <asp:Label ID="lblgvHdrCategorySno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvCategorySno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="250" HeaderStyle-Width="250" FooterStyle-Width="250">
                        <HeaderTemplate>
                            <asp:Label ID="lblgvHdrCategoryCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,CategoryCode %>"> </asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvCategoryCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryCode").ToString()%>'> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblgvCategoryCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryCode").ToString()%>'> </asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TxtCategoryCode" Width="200" CssClass="csstxtbox" runat="server"
                                MaxLength="16"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtCategoryCodeValidator" runat="server" ControlToValidate="TxtCategoryCode"
                                ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="500" HeaderStyle-Width="500" FooterStyle-Width="500">
                        <HeaderTemplate>
                            <asp:Label ID="lblgvHdrCategoryName" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,CategoryDescription %>"> </asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvcategoryName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryDesc").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCategoryDesc" Width="450" CssClass="csstxtbox" runat="server"
                                MaxLength="50" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryDesc").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtCategoryDescValidator" runat="server" ControlToValidate="txtCategoryDesc"
                                ErrorMessage="cannot be blank!" ValidationGroup="vg_Edit">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewCategoryDesc" Width="450" CssClass="csstxtbox" runat="server"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtNewCategoryDescValidator" runat="server" ControlToValidate="txtNewCategoryDesc"
                                ErrorMessage="cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <HeaderStyle Width="180px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                ValidationGroup="vg_Edit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                OnClick="lnkBtnCancel_Click" ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add New"
                                ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                ToolTip="<%$ Resources:Resource, Reset %>" OnClick="btnReset_Click" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
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
            <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
