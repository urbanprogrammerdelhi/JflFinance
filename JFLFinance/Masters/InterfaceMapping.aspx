<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="InterfaceMapping.aspx.cs" Inherits="Masters_InterfaceMapping" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="1" cellpadding="3" cellspacing="0">
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Text="Main Screen"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainGroup" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlMainGroup_SelectedIndexChange">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <%--<asp:Label ID="lblMainGroup" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Submit %>"></asp:Label>--%>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Text="Child Screen"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubGroup" runat="server" CssClass="cssDropDown" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <%--<asp:Label ID="lblSubGroup" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Submit %>"></asp:Label>--%>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmit" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Submit %>"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="950px" ID="gvInterfaceMapping" PageSize="15" CssClass="GridViewStyle"
                                            runat="server" ShowFooter="True" AllowPaging="True" CellPadding="1" DataKeyNames="RowAutoId"
                                            AutoGenerateColumns="False" OnRowCommand="gvInterfaceMapping_RowCommand" OnRowEditing="gvInterfaceMapping_RowEditing"
                                            OnRowUpdating="gvInterfaceMapping_RowUpdating" OnRowCancelingEdit="gvInterfaceMapping_RowCancelingEdit"
                                            OnRowDeleting="gvInterfaceMapping_RowDeleting" OnPageIndexChanging="gvInterfaceMapping_PageIndexChanging"
                                            OnRowDataBound="gvInterfaceMapping_RowDataBound">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                                    FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Color %>" HeaderStyle-Width="30px"
                                                    FooterStyle-Width="30px" ItemStyle-Width="30px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblColor" Width="20px" CssClass="cssLable" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtColor" CssClass="csstxtbox" Text='<%# Eval("Color") %>' runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtColor" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SColumnName%>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSColumnName" Width="180px" CssClass="cssLable" runat="server" Text='<%# Bind("SColumnName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSColumnName" ReadOnly="true" CssClass="csstxtbox" Text='<%# Eval("SColumnName") %>'
                                                            runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="hfRowAutoId" runat="server" Value='<%# Bind("RowAutoId") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtSColumnName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SDataType %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSDataType" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("SDataType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSDataType" ReadOnly="true" CssClass="csstxtbox" Text='<%# Eval("SDataType") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtSDataType" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SLength %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSLength" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("SLength") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSLength" ReadOnly="true" CssClass="csstxtbox" Text='<%# Eval("SLength") %>' runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtSLength" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SPerc %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSPerc" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("SPerc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSPerc" ReadOnly="true" CssClass="csstxtbox" Text='<%# Eval("SPerc") %>' runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtSPerc" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SNullable %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblSNullable" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("SNullable") %>'></asp:Label>--%>
                                                        <asp:CheckBox ID="cbSNullable" Checked='<%# Eval("SNullable") %>' CssClass="cssCheckBox"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="cbSNullable" Enabled="false" CssClass="cssCheckBox" runat="server" />
                                                        <asp:HiddenField ID="hfSNullable" runat="server" Value='<%# Bind("SNullable") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="cbSNullable" CssClass="cssCheckBox" runat="server" />
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SEditable %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <%--                                                        <asp:Label ID="lblSEditable" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("SEditable") %>'></asp:Label>--%>
                                                        <asp:CheckBox ID="cbSEditable" Checked='<%# Eval("SEditable") %>' CssClass="cssCheckBox"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="cbSEditable" CssClass="cssCheckBox" runat="server" />
                                                        <asp:HiddenField ID="hfSEditable" runat="server" Value='<%# Bind("SEditable") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="cbSEditable" CssClass="cssCheckBox" runat="server" />
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="<%$ Resources:Resource,STableName %>"
                                                    HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSTableName" Width="180px" CssClass="cssLable" runat="server" Text='<%# Bind("STableName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSTableName" CssClass="csstxtbox" Text='<%# Eval("STableName") %>'
                                                            runat="server"></asp:TextBox>
                                                            <asp:Label ID="lblSTableName" Visible="false" Width="180px" CssClass="cssLable" runat="server" Text='<%# Bind("STableName") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtSTableName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="hfSTableName" runat="server" Value='<%# Bind("STableName") %>' />
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="<%$ Resources:Resource,SCollation %>"
                                                    HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSCollation" Width="180px" CssClass="cssLable" runat="server" Text='<%# Bind("SCollation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSCollation" CssClass="csstxtbox" Text='<%# Eval("SCollation") %>'
                                                            runat="server"></asp:TextBox>                                                            
                                                            <asp:Label ID="lblSCollation" Visible="false" Width="180px" CssClass="cssLable" runat="server" Text='<%# Bind("SCollation") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtSCollation" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="hfSCollation" runat="server" Value='<%# Bind("SCollation") %>' />
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="<%$ Resources:Resource,ScreenName %>"
                                                    HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblScreenName" Width="180px" CssClass="cssLable" runat="server" Text='<%# Bind("ScreenName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtScreenName" CssClass="csstxtbox" Text='<%# Eval("ScreenName") %>'
                                                            runat="server"></asp:TextBox>
                                                            <asp:Label ID="lblScreenName" Visible="false" Width="180px" CssClass="cssLable" runat="server" Text='<%# Bind("ScreenName") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtScreenName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="hfScreenName" runat="server" Value='<%# Bind("ScreenName") %>' />
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SScreenFieldName %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSScreenFieldName" Width="180px" CssClass="cssLable" runat="server"
                                                            Text='<%# Bind("SScreenFieldName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSScreenFieldName" CssClass="csstxtbox" Text='<%# Eval("SScreenFieldName") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtSScreenFieldName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SDescription %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSDescription" Width="180px" CssClass="cssLable" runat="server"
                                                            Text='<%# Bind("SDescription") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSDescription" CssClass="csstxtbox" Text='<%# Eval("SDescription") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtSDescription" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SMandatory %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblSMandatory" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("SMandatory") %>'></asp:Label>--%>
                                                        <asp:CheckBox ID="cbSMandatory" Checked='<%# Eval("SMandatory") %>' CssClass="cssCheckBox"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="cbSMandatory" Enabled="false" CssClass="cssCheckBox" runat="server" />
                                                        <asp:HiddenField ID="hfSMandatory" runat="server" Value='<%# Bind("SMandatory") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="cbSMandatory" CssClass="cssCheckBox" runat="server" />
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IsProvided %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblIsProvided" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("IsProvided") %>'></asp:Label>--%>
                                                        <asp:CheckBox ID="cbIsProvided" Checked='<%# Eval("IsProvided") %>' CssClass="cssCheckBox"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="cbIsProvided" ReadOnly="true" CssClass="cssCheckBox" runat="server" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="cbIsProvided" CssClass="cssCheckBox" runat="server" />
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ColumnName %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblColumnName" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("ColumnName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtColumnName" CssClass="csstxtbox" Text='<%# Eval("ColumnName") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtColumnName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DataType %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDataType" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("DataType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlDataType" runat="server" CssClass="cssDropDown">
                                                            <asp:ListItem Text="nvarchar" Value="nvarchar"></asp:ListItem>
                                                            <asp:ListItem Text="varchar" Value="varchar"></asp:ListItem>
                                                            <asp:ListItem Text="numeric" Value="numeric"></asp:ListItem>
                                                            <asp:ListItem Text="int" Value="int"></asp:ListItem>
                                                            <asp:ListItem Text="datetime" Value="datetime"></asp:ListItem>
                                                            <asp:ListItem Text="bit" Value="bit"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfDataType" runat="server" Value='<%# Bind("DataType") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlDataType" runat="server" CssClass="cssDropDown">
                                                            <asp:ListItem Text="nvarchar" Value="nvarchar"></asp:ListItem>
                                                            <asp:ListItem Text="varchar" Value="varchar"></asp:ListItem>
                                                            <asp:ListItem Text="numeric" Value="numeric"></asp:ListItem>
                                                            <asp:ListItem Text="int" Value="int"></asp:ListItem>
                                                            <asp:ListItem Text="datetime" Value="datetime"></asp:ListItem>
                                                            <asp:ListItem Text="bit" Value="bit"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Length %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLength" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("Length") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtLength" CssClass="csstxtbox" Text='<%# Eval("Length") %>' runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtLength" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SPerc %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPerc" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("Perc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPerc" CssClass="csstxtbox" Text='<%# Eval("Perc") %>' runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtPerc" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Nullable %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblNullable" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("Nullable") %>'></asp:Label>--%>
                                                        <asp:CheckBox ID="cbNullable" Checked='<%# Eval("Nullable") %>' CssClass="cssCheckBox"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="cbNullable" CssClass="cssCheckBox" runat="server" />
                                                        <asp:HiddenField ID="hfNullable" runat="server" Value='<%# Bind("Nullable") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="cbNullable" CssClass="cssCheckBox" runat="server" />
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DataBaseName %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDataBaseName" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("DataBaseName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtDataBaseName" CssClass="csstxtbox" Text='<%# Eval("DataBaseName") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtDataBaseName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,TableName %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTableName" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("TableName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtTableName" CssClass="csstxtbox" Text='<%# Eval("TableName") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTableName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="<%$ Resources:Resource,Collation %>"
                                                    HeaderStyle-Width="80px" FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCollation" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("Collation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtCollation" CssClass="csstxtbox" Text='<%# Eval("Collation") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtCollation" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ScreenFieldName %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblScreenFieldName" Width="80px" CssClass="cssLable" runat="server"
                                                            Text='<%# Bind("ScreenFieldName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtScreenFieldName" CssClass="csstxtbox" Text='<%# Eval("ScreenFieldName") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtScreenFieldName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Description %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtDescription" CssClass="csstxtbox" Text='<%# Eval("Description") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtDescription" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SourceType %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSourceType" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("SourceType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlSourceType" CssClass="cssDropDown" runat="server">
                                                            <asp:ListItem Text="Table" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="View" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfSourceType" runat="server" Value='<%# Bind("SourceType") %>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlSourceType" CssClass="cssDropDown" runat="server">
                                                            <asp:ListItem Text="Table" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="View" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DefaultValue %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDefaultValue" Width="80px" CssClass="cssLable" runat="server" Text='<%# Bind("DefaultValue") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtDefaultValue" CssClass="csstxtbox" Text='<%# Eval("DefaultValue") %>'
                                                            runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtDefaultValue" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdateMapping" ToolTip="<%$Resources:Resource,Update %>"
                                                            ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                            ValidationGroup="Edit" />
                                                        <asp:ImageButton ID="ImageButton2Mapping" ToolTip="<%$Resources:Resource,Cancel %>"
                                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                            CommandName="Cancel" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IBEditMapping" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                            CommandName="Edit" />
                                                        <asp:ImageButton ID="IBDeleteMapping" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                            CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                    <FooterStyle Width="100px" />
                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
