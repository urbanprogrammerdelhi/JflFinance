<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ZipMaster.aspx.cs" Inherits="Masters_ZipMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Panel1" BorderWidth="0" runat="server">
            <asp:GridView ID="gvGroupZip" Width="100%" CssClass="GridViewStyle" PageSize="12"
                runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                OnRowCancelingEdit="gvGroupZip_RowCancelingEdit" OnRowCommand="gvGroupZip_RowCommand"
                OnRowDataBound="gvGroupZip_RowDataBound" OnRowDeleting="gvGroupZip_RowDeleting"
                OnRowEditing="gvGroupZip_RowEditing" OnRowUpdating="gvGroupZip_RowUpdating" ShowFooter="True"
                OnPageIndexChanging="gvGroupZip_PageIndexChanging">
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
                    <asp:TemplateField HeaderText="<%$Resources:Resource,GroupZipCode %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblGroupZipCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GroupZipCode").ToString()%>' OnClick="lblGroupZipCode_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lblGroupZipCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GroupZipCode").ToString()%>' OnClick="lblGroupZipCode_Click"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtGroupZipCode" Width="380px" MaxLength="25" ValidationGroup="vgFooter" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvGroupZipCode" runat="server" ControlToValidate="txtGroupZipCode" ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,GroupZipDesc %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblGroupZipDesc" CssClass="cssLable" runat="server" Text='<%# Bind("GroupZipDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGroupZipDesc" Width="380px" MaxLength="100" ValidationGroup="vgEdit" Text='<%# Bind("GroupZipDesc") %>' CssClass="csstxtbox" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtGroupZipDesc" Width="380px" MaxLength="100" ValidationGroup="vgFooter" CssClass="csstxtbox" runat="server"></asp:TextBox>
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
        </asp:Panel>
        <br />
        <asp:HiddenField runat="server" id="hfglobalGroupZipCode" Value=""/>
        <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        <asp:Panel ID="Panel2" BorderWidth="0" runat="server">
            <asp:GridView ID="gvZip" Width="100%" CssClass="GridViewStyle" PageSize="15"
                runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                OnRowCancelingEdit="gvZip_RowCancelingEdit" OnRowCommand="gvZip_RowCommand"
                OnRowDataBound="gvZip_RowDataBound" OnRowDeleting="gvZip_RowDeleting"
                OnRowEditing="gvZip_RowEditing" OnRowUpdating="gvZip_RowUpdating" ShowFooter="True"
                OnPageIndexChanging="gvZip_PageIndexChanging" onmousemove="TableResize_OnMouseMove(this);" onmouseup="TableResize_OnMouseUp(this);" onmousedown="TableResize_OnMouseDown(this);">
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
                    <asp:TemplateField HeaderText="<%$Resources:Resource,GroupZipCode %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblGroupZipCode" CssClass="cssLable" runat="server" Text='<%# Bind("GroupZipCode") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblGroupZipCode" CssClass="cssLable" runat="server" Text='<%# Bind("GroupZipCode") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ZipCode %>" HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lblZipCode" CssClass="cssLable" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblZipCode" CssClass="cssLable" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtZipCode" CssClass="csstxtbox" MaxLength="25" Width="80" Text="" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" Display="Dynamic" ControlToValidate="txtZipCode" ValidationGroup="vgFooter1" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ZipDesc %>" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                        <ItemTemplate>
                            <asp:Label ID="lblZipDesc" CssClass="cssLable" runat="server" Text='<%# Bind("ZipDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtZipDesc" CssClass="csstxtbox" MaxLength="100" Width="280" Text='<%# Bind("ZipDesc") %>' runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvZipDesc" runat="server" Display="Dynamic" ControlToValidate="txtZipDesc" ValidationGroup="vgEdit1" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtZipDesc" CssClass="csstxtbox" MaxLength="25" Width="280" Text="" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvZipDesc" runat="server" Display="Dynamic" ControlToValidate="txtZipDesc" ValidationGroup="vgFooter1" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgEdit1" />
                            <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" CssClass="cssImgButton" runat="server" ValidationGroup="vgFooter1" CommandName="AddNew" />
                            <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif" CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
</Ajax:UpdatePanel>
</asp:Content>
