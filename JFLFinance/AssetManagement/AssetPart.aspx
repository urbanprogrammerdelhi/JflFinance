<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetPart.aspx.cs" Inherits="AssetManagement_AssetPart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvAssetPart" Width="100%" CssClass="GridViewStyle" PageSize="15"
                runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                AutoGenerateColumns="False" OnRowCancelingEdit="gvAssetPart_RowCancelingEdit"
                OnRowCommand="gvAssetPart_RowCommand" OnRowDataBound="gvAssetPart_RowDataBound"
                OnRowDeleting="gvAssetPart_RowDeleting" OnRowEditing="gvAssetPart_RowEditing" OnRowUpdating="gvAssetPart_RowUpdating"
                ShowFooter="True" OnPageIndexChanging="gvAssetPart_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCategory %>" HeaderStyle-ForeColor="White">
                        <EditItemTemplate>
                            <asp:HiddenField ID="hfAssetPartsAutoId" runat="server" Value='<%# Bind("AssetPartsAutoId") %>' />
                            <asp:Label ID="lblAssetCategory" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCategoryName") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlAssetCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlAssetCategory_SelectedIndexChanged" CssClass="cssDropDown" Width="85%" runat="server">
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="hfAssetPartsAutoId" runat="server" Value='<%# Bind("AssetPartsAutoId") %>' />
                            <asp:Label ID="lblAssetCategory" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCategoryName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetSubCategory %>" HeaderStyle-ForeColor="White">
                        <EditItemTemplate>
                            <asp:Label ID="lblAssetSubCategory" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetSubCategoryName") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlAssetSubCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlAssetSubCategory_SelectedIndexChanged" CssClass="cssDropDown" Width="85%" runat="server">
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAssetSubCategory" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetSubCategoryName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ManufacturerName %>" HeaderStyle-ForeColor="White">
                        <EditItemTemplate>
                            <asp:Label ID="lblManufacturerName" CssClass="cssLabel" runat="server" Text='<%# Bind("ManufacturerName") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlManufacturerName" AutoPostBack="true" OnSelectedIndexChanged="ddlManufacturerName_SelectedIndexChanged" CssClass="cssDropDown" Width="85%" runat="server">
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblManufacturerName" CssClass="cssLabel" runat="server" Text='<%# Bind("ManufacturerName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>" HeaderStyle-ForeColor="White">
                        <EditItemTemplate>
                            <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlAssetName" AutoPostBack="true" OnSelectedIndexChanged="ddlAssetName_SelectedIndexChanged" CssClass="cssDropDown" Width="85%" runat="server">
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelNo %>" HeaderStyle-ForeColor="White">
                        <EditItemTemplate>
                            <asp:Label ID="lblModelNo" CssClass="cssLabel" runat="server" Text='<%# Bind("ModelNo") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlModelNo" AutoPostBack="false" CssClass="cssDropDown" Width="85%" runat="server">
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblModelNo" CssClass="cssLabel" runat="server" Text='<%# Bind("ModelNo") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,AssetPartNo %>" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAssetPartNo" Width="100px" MaxLength="50" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("AssetPartNo") %>'></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvPart" runat="server" ControlToValidate="txtAssetPartNo"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAssetPartNo" CssClass="cssLable" runat="server" Text='<%# Bind("AssetPartNo") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewAssetPartNo" Width="100px" MaxLength="50" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvpartnew" runat="server" ControlToValidate="txtNewAssetPartNo"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,AssetPartName %>" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAssetPartName" Width="100px" MaxLength="50" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("AssetPartName") %>'></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvPartname" runat="server" ControlToValidate="txtAssetPartName"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAssetPartName" CssClass="cssLable" runat="server" Text='<%# Bind("AssetPartName") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewAssetPartName" Width="100px" MaxLength="50" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvPartnamenew" runat="server" ControlToValidate="txtNewAssetPartName"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,AssetPartQuantity %>" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAssetPartQuantity" Width="100px" MaxLength="10" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("AssetPartQuantity") %>'></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvPartQuantity" runat="server" ControlToValidate="txtAssetPartQuantity"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAssetPartQuantity" CssClass="cssLable" runat="server" Text='<%# Bind("AssetPartQuantity") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewAssetPartQuantity" Width="100px" MaxLength="10" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvPartQuantitynew" runat="server" ControlToValidate="txtNewAssetPartQuantity"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
