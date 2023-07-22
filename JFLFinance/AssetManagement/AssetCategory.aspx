<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetCategory.aspx.cs"
    EnableViewState="true" Inherits="AssetManagement_AssetCategory" Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetCategory" Font-Bold="True" Height="330px" runat="server">
                <asp:HiddenField ID="hfEmployeeNumber" runat="server" Value="0" />
                <asp:GridView Width="60%" ID="gvAssetCategory" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAssetCategory_RowDataBound" OnRowCommand="gvAssetCategory_RowCommand"
                    OnRowDeleting="gvAssetCategory_RowDeleting" OnRowEditing="gvAssetCategory_RowEditing" OnPageIndexChanging="gvAssetCategory_PageIndexChanging"
                    OnRowUpdating="gvAssetCategory_RowUpdating" OnRowCancelingEdit="gvAssetCategory_RowCancelingEdit">
                    <%--<FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />--%>
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#DBDDF8" />
                    <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" />
                     <PagerStyle BackColor="#2E6293" ForeColor="White"  />
                    <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>

                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName%>" HeaderStyle-ForeColor="White" >
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                    ValidationGroup="EditAssetCategory" />
                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                    CommandName="Cancel" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>" ForeColor="White"
                                    CssClass="cssImgButton" ValidationGroup="NewAssetCategory" CommandName="AddNew" ImageUrl="~/Images/AddNew.gif" />
                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server" ForeColor="White"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="~/Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                    CommandName="Edit" />
                                <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                            </ItemTemplate>
                            <FooterStyle Width="50px" />
                            <HeaderStyle Width="50px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCategory %>" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfAssetCategoryAutoId" runat="server" Value='<%# Bind("AssetCategoryAutoId") %>' />
                                <asp:TextBox ID="txtAssetCategory" MaxLength="100" ValidationGroup="EditAssetCategory" CssClass="csstxtbox" runat="server" Text='<%# Bind("AssetCategoryName") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtAssetCategory" runat="server" ControlToValidate="txtAssetCategory"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetCategory"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:HiddenField ID="hfAssetCategoryAutoIdnew" runat="server" Value="0" />
                                <asp:TextBox ID="txtAssetCategory" MaxLength="100" ValidationGroup="NewAssetCategory" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvnewtxtAssetCategory" runat="server" ControlToValidate="txtAssetCategory"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetCategory"></asp:RequiredFieldValidator>

                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetCategoryAutoId" runat="server" Value='<%# Bind("AssetCategoryAutoId") %>' />
                                <asp:LinkButton ID="LbAssestCategory" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCategoryName") %>' OnClick="LbAssestCategory_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="220px" />
                            <ItemStyle Width="220px" />
                            <FooterStyle Width="220px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblAssetCategory" EnableViewState="False" runat="server" CssClass="csslblErrMsg" ></asp:Label>
            </asp:Panel>

            <asp:Panel ScrollBars="Auto" ID="PanelAssetSubCategory" Font-Bold="True" ForeColor="Red" Height="380px" runat="server" Visible="false" GroupingText="<%$ Resources:Resource,AssetSubCategory %>">
                <asp:HiddenField ID="hfid" runat="server" />
                <asp:GridView Width="60%" ID="gvAssetSubCategory" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAssetSubCategory_RowDataBound" OnRowCommand="gvAssetSubCategory_RowCommand"
                    OnRowDeleting="gvAssetSubCategory_RowDeleting" OnRowEditing="gvAssetSubCategory_RowEditing" OnPageIndexChanging="gvAssetSubCategory_PageIndexChanging"
                    OnRowUpdating="gvAssetSubCategory_RowUpdating" OnRowCancelingEdit="gvAssetSubCategory_RowCancelingEdit">
                   <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#DBDDF8" />
                    <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" />
                       <PagerStyle BackColor="#2E6293" ForeColor="White"  />
                    <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>

                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName%>" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                    ValidationGroup="EditAssetSubCategory" />

                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                    CommandName="Cancel" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="NewAssetSubCategory" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />

                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                    CommandName="Edit" />
                                &nbsp;
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                            </ItemTemplate>
                            <FooterStyle Width="50px" />
                            <HeaderStyle Width="50px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCategory %>" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:Label ID="txtAssetCategory" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCategoryName") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAssestCategory" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCategoryName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetSubCategory %>" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfAssetSubCategoryAutoId" runat="server" Value='<%# Bind("AssetSubCategoryAutoId") %>' />
                                <asp:TextBox ID="txtAssetSubCategory" MaxLength="100" ValidationGroup="EditAssetSubCategory" CssClass="csstxtbox" runat="server" Text='<%# Bind("AssetSubCategoryName") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtAssetSubCategory" runat="server" ControlToValidate="txtAssetSubCategory"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetSubCategory"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:HiddenField ID="hfAssetSubCategoryAutoIdnew" runat="server" Value="0" />

                                <asp:TextBox ID="txtAssetSubCategory" MaxLength="100" ValidationGroup="NewAssetSubCategory" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvnewtxtAsseSubtCategory" runat="server" ControlToValidate="txtAssetSubCategory"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetSubCategory"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetSubCategoryAutoId" runat="server" Value='<%# Bind("AssetSubCategoryAutoId") %>' />
                                <asp:Label ID="lblAssestSubCategory" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetSubCategoryName") %>'></asp:Label>

                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblAssestSubCategoryMsg" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

