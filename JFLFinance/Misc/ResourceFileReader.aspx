<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResourceFileReader.aspx.cs" Inherits="Misc_ResourceFileReader" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:DropDownList ID="cmbResources" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbResources_SelectedIndexChanged"
            Width="275px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" Width="275px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%= ++indexNum %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Key">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container,"DataItem.Key") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Value">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container,"DataItem.Value") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='EditResourceFile.aspx?key=<%# DataBinder.Eval(Container,"DataItem.Key") %>&file=<%=cmbResources.SelectedItem.Text %>&id=<%=indexNum - 1 %>'>
                            Edit</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
