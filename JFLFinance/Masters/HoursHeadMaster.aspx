<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="HoursHeadMaster.aspx.cs" Inherits="Masters_HoursHeadMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <table width="900px">
                            <tr>
                                <td>
                                    <asp:GridView ID="gvHrsHeadGroup" runat="server" Width="600px" CssClass="GridViewStyle"
                                        ShowFooter="true" ShowHeader="true" AllowPaging="true" AutoGenerateColumns="False"
                                        OnRowCommand="gvHrsHeadGroup_RowCommand" OnRowCancelingEdit="gvHrsHeadGroup_RowCancelingEdit"
                                        OnRowDeleting="gvHrsHeadGroup_RowDeleting" OnRowEditing="gvHrsHeadGroup_RowEditing"
                                        OnRowUpdated="gvHrsHeadGroup_RowUpdated" OnRowUpdating="gvHrsHeadGroup_RowUpdating">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvHdrHrsHeadSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvHrsHeadGroupSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvHdrHrsHeadGroupCode" CssClass="cssLabelHeader" runat="server"
                                                        Text="HoursHeadGroup Code"> </asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkgvHrsHrsHeadGroupCode" CssClass="csslnkButton" runat="server"
                                                        Text='<%# Bind("HoursHeadGroupCode") %>' OnClick="LinkgvHrsHrsHeadGroupCode_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="TxtNewHrsHeadGroupCode" Width="200" CssClass="csstxtbox" runat="server"
                                                        MaxLength="16"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtHrsHeadCodeValidator" runat="server" ControlToValidate="TxtNewHrsHeadGroupCode"
                                                        ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvHdrHrsHeadGroupDesc" CssClass="cssLabelHeader" runat="server"
                                                        Text="HoursHeadGroup Desc"> </asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvHrsHeadGroupDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadGroupDesc").ToString()%>'> </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtHrsHeadGroupDesc" Width="200" CssClass="csstxtbox" runat="server"
                                                        MaxLength="32" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadGroupDesc").ToString()%>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtHrsHeadDescValidator" runat="server" ControlToValidate="txtHrsHeadGroupDesc"
                                                        ErrorMessage="cannot be blank!" ValidationGroup="vg_Edit">*</asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtNewHrsHeadGroupDesc" Width="200" CssClass="csstxtbox" runat="server"
                                                        MaxLength="16"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtNewHrsHeadDescValidator" runat="server" ControlToValidate="txtNewHrsHeadGroupDesc"
                                                        ErrorMessage="cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
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
                                                        ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                        ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                    <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                        ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                </FooterTemplate>
                                                <ItemStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <FooterStyle Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HdnHrsHeadGroupCode" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvHrsHead" runat="server" Width="600px" CssClass="GridViewStyle"
                                        ShowFooter="true" ShowHeader="true" AllowPaging="true" AutoGenerateColumns="False"
                                        OnRowCommand="gvHrsHead_RowCommand" OnRowCancelingEdit="gvHrsHead_RowCancelingEdit"
                                        OnRowDeleting="gvHrsHead_RowDeleting" OnRowEditing="gvHrsHead_RowEditing" OnRowUpdated="gvHrsHead_RowUpdated"
                                        OnRowUpdating="gvHrsHead_RowUpdating">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvHdrHrsHeadSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvHrsHeadSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvHdrHrsHeadCode" CssClass="cssLabelHeader" runat="server" Text="HoursHead Code"> </asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvHrsHeadCode" runat="server" CssClass="cssLabel" Text='<%# Bind("HoursHeadCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="TxtNewHrsHeadCode" Width="200" CssClass="csstxtbox" runat="server"
                                                        MaxLength="16"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtHrsHeadCodeValidator1" runat="server" ControlToValidate="TxtNewHrsHeadCode"
                                                        ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add1">*</asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvHdrHrsHeadDesc" CssClass="cssLabelHeader" runat="server" Text="HoursHead Desc"> </asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvHrsHeadDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadDesc").ToString()%>'> </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtHrsHeadDesc" Width="200" CssClass="csstxtbox" runat="server"
                                                        MaxLength="32" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadDesc").ToString()%>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtHrsHeadDescValidator1" runat="server" ControlToValidate="txtHrsHeadDesc"
                                                        ErrorMessage="cannot be blank!" ValidationGroup="vg_Edit1">*</asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtNewHrsHeadDesc" Width="200" CssClass="csstxtbox" runat="server"
                                                        MaxLength="16"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtNewHrsHeadDescValidator1" runat="server" ControlToValidate="txtNewHrsHeadDesc"
                                                        ErrorMessage="cannot be blank!" ValidationGroup="vg_Add1">*</asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                        ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                    <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                        ValidationGroup="vg_Edit1" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                    <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                        ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                        ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add1" ImageUrl="../Images/AddNew.gif" />
                                                    <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                        ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                </FooterTemplate>
                                                <ItemStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <FooterStyle Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
