<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Language.aspx.cs" Inherits="Masters_Language" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="btnExport" Visible="true" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>"
                OnClick="btnExport_Click" />
            <asp:GridView ID="gvLanguage" Width="100%" CssClass="GridViewStyle" PageSize="15"
                runat="server" AllowPaging="true" CellPadding="1" GridLines="None" DataKeyNames="LanguageCode"
                AutoGenerateColumns="False" OnRowCancelingEdit="gvLanguage_RowCancelingEdit"
                OnRowCommand="gvLanguage_RowCommand" OnRowDataBound="gvLanguage_RowDataBound"
                OnRowDeleting="gvLanguage_RowDeleting" OnRowEditing="gvLanguage_RowEditing" OnRowUpdating="gvLanguage_RowUpdating"
                ShowFooter="True" OnPageIndexChanging="gvLanguage_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                        FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,LanguageCode %>" HeaderStyle-Width="200px"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <EditItemTemplate>
                            <asp:Label ID="lblLanguageCode" CssClass="cssLable" runat="server" Text='<%# Eval("LanguageCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" CssClass="cssLable" Width="180px" runat="server" Text='<%# Bind("LanguageCode") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewLanguageCode" Width="180px" MaxLength="10" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewLanguageCode"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,LanguageDesc %>" HeaderStyle-Width="600px"
                        FooterStyle-Width="600px" ItemStyle-Width="600px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLanguageDesc" Width="580px" MaxLength="25" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("LanguageDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLanguageDesc"
                                ValidationGroup="Edit" ErrorMessage="" SetFocusOnError="True" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text='<%# Bind("LanguageDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewLanguageDesc" Width="580px" MaxLength="25" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewLanguageDesc"
                                ValidationGroup="AddNew" ErrorMessage="" SetFocusOnError="True" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                        FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdateLang" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImageButton2Lang" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEditLang" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="IBDeleteLang" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
    </ContentTemplate>
</Ajax:UpdatePanel>   
</asp:Content>
