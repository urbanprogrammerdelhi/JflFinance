<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SaleItemTypeMaster.aspx.cs" Inherits="Sales_SaleItemTypeMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hfspDecimalPlace"  runat="server" Value="{0:n2}" />
            <asp:GridView ID="gvItemType" Width="100%" CssClass="GridViewStyle" PageSize="15"
                runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                OnRowCancelingEdit="gvItemType_RowCancelingEdit" OnRowCommand="gvItemType_RowCommand"
                OnRowDataBound="gvItemType_RowDataBound" OnRowDeleting="gvItemType_RowDeleting"
                OnRowEditing="gvItemType_RowEditing" OnRowUpdating="gvItemType_RowUpdating" ShowFooter="True"
                OnPageIndexChanging="gvItemType_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                        FooterStyle-Width="50px" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ItemTypeCode %>" HeaderStyle-Width="200px"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label Width="180px" ID="lblItemTypeCode" CssClass="cssLable" runat="server"
                                Text='<%# Eval("ItemTypeCode") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label Width="180px" ID="lblItemTypeCode" CssClass="cssLable" runat="server"
                                Text='<%# Eval("ItemTypeCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtItemTypeCode" Width="180px" MaxLength="16" ValidationGroup="vgFooter"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvItemTypeCode"  runat="server" ControlToValidate="txtItemTypeCode"
                                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="vgFooter" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ItemDesc %>" HeaderStyle-Width="400px"
                        FooterStyle-Width="400px" ItemStyle-Width="400px">
                        <ItemTemplate>
                            <asp:Label ID="lblItemDesc" CssClass="cssLable" runat="server" Text='<%# Bind("ItemDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtItemDesc" Width="380px" MaxLength="50" ValidationGroup="vgEdit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("ItemDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvItemDesc" runat="server" ControlToValidate="txtItemDesc"
                                ValidationGroup="vgEdit" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtItemDesc" Width="380px" MaxLength="50" ValidationGroup="vgFooter"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvItemDesc" runat="server" ControlToValidate="txtItemDesc"
                                ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="200px"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <HeaderTemplate>
                        <asp:Label ID="lblValueCurr" CssClass="cssLabelHeader" runat="server" Font-Size=X-Small
                                Text="<%$Resources:Resource,Value %>"></asp:Label>
                        </HeaderTemplate>
                                                    
                        <ItemTemplate>
                            <asp:Label ID="lblValue" CssClass="cssLable" runat="server" Text='<%#String.Format(hfspDecimalPlace.Value,Eval("Value")) %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtValue" Width="180px" MaxLength="10" ValidationGroup="vgEdit"
                                CssClass="csstxtbox" runat="server" Text='<%#String.Format(hfspDecimalPlace.Value,Eval("Value")) %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvValue" runat="server" ControlToValidate="txtValue"
                                ValidationGroup="vgEdit" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtValue" Width="180px" MaxLength="10" ValidationGroup="vgFooter"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvValue" runat="server" ControlToValidate="txtValue"
                                ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                        FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgEdit" />
                            <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif"
                                CssClass="cssImgButton" runat="server" ValidationGroup="vgFooter" CommandName="AddNew" />
                            <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif"
                                CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
