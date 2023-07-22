<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPage.master" 
CodeFile="TaskMaster.aspx.cs" Inherits="Masters_TaskMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvTaskMaster" Width="100%" CssClass="GridViewStyle" PageSize="12"
                runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                OnRowCancelingEdit="gvTaskMaster_RowCancelingEdit" OnRowCommand="gvTaskMaster_RowCommand"
                OnRowDataBound="gvTaskMaster_RowDataBound" OnRowDeleting="gvTaskMaster_RowDeleting"
                OnRowEditing="gvTaskMaster_RowEditing" OnRowUpdating="gvTaskMaster_RowUpdating" ShowFooter="True"
                OnPageIndexChanging="gvTaskMaster_PageIndexChanging">
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
                    <asp:TemplateField HeaderText="<%$Resources:Resource,TaskDesc %>" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                        <ItemTemplate>
                            <asp:Label ID="lblTaskDesc" CssClass="cssLable" runat="server" Text='<%# Bind("TaskDesc") %>'></asp:Label>
                            <asp:HiddenField ID="hfTaskAutoId" runat="server" Value='<%# Bind("TaskAutoId") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTaskDesc" Width = "400px"  MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("TaskDesc") %>'></asp:TextBox>
                            <asp:HiddenField ID="hfTaskAutoId" runat="server" Value='<%# Bind("TaskAutoId") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTaskDesc" Width = "400px" MaxLength="100" CssClass="csstxtbox" ValidationGroup="vgFooter" runat="server" Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTaskDesc" runat="server" ControlToValidate="txtTaskDesc" ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgEdit" />
                            <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" CssClass="cssImgButton" runat="server" ValidationGroup="vgFooter" CommandName="AddNew" />
                            <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif" CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>