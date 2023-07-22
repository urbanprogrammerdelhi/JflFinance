<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Constraint.aspx.cs" Inherits="Masters_Constraint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel ID="upConstraintType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td align="right">
                        <asp:Label ID="lblConstraintType" runat="server" Text="<%$Resources:Resource,ConstraintType %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlConstraintType" AutoPostBack="true" CssClass="cssDropDown"
                            runat="server" OnSelectedIndexChanged="ddlConstraintType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnExport" Visible="true" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>"
                            OnClick="btnExport_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView Width="100%" ID="gvConstraint" CssClass="GridViewStyle" runat="server"
                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvConstraint_RowCommand"
                OnRowUpdating="gvConstraint_RowUpdating" OnRowDeleting="gvConstraint_RowDeleting"
                OnRowEditing="gvConstraint_RowEditing" OnRowCancelingEdit="gvConstraint_RowCancelingEdit"
                OnRowDataBound="gvConstraint_RowDataBound" OnPageIndexChanging="gvConstraint_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnEdit" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                ValidationGroup="vgCEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                ValidationGroup="vgCEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, AddNew %>" ValidationGroup="vgCFooter" CommandName="Add"></asp:LinkButton>
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Width="50px" />
                        <FooterStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,Code %>">
                        <ItemTemplate>
                            <asp:Label ID="lblConstraintCode" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintCode").ToString()%>'></asp:Label>
                            <asp:HiddenField ID="HFConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintAutoID").ToString()%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblConstraintCode" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintCode").ToString()%>'></asp:Label>
                            <asp:HiddenField ID="HFConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintAutoID").ToString()%>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtConstraintCode" AutoPostBack="true" OnTextChanged="txtConstraintCode_TextChanged" runat="server" CssClass="csstxtbox"></asp:TextBox>
                        </FooterTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,Description %>">
                        <ItemTemplate>
                            <asp:Label ID="lblConstraintDesc" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintDesc").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtConstraintDesc" Width="300px" runat="server" CssClass="cssLabel"
                                Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintDesc").ToString()%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtConstraintDesc" Width="300px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                        </FooterTemplate>
                        <ItemStyle Width="300px" />
                        <HeaderStyle Width="300px" />
                        <FooterStyle Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,Operator %>">
                        <ItemTemplate>
                            <asp:Label ID="lblOperator" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Operator").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="HFOperator" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OperatorValue").ToString()%>' />
                            <asp:DropDownList ID="ddlOperator" Width="150px" CssClass="cssDropDown" runat="server">
                                <asp:ListItem Text="Greater Than" Value=">"></asp:ListItem>
                                <asp:ListItem Text="Less Than" Value="<"></asp:ListItem>
                                <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                <asp:ListItem Text="Like" Value="%"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlOperator" Width="150px" CssClass="cssDropDown" runat="server">
                                <asp:ListItem Text="Greater Than" Value=">"></asp:ListItem>
                                <asp:ListItem Text="Less Than" Value="<"></asp:ListItem>
                                <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                <asp:ListItem Text="Like" Value="%"></asp:ListItem>
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,Value %>">
                        <ItemTemplate>
                            <asp:Label ID="lblValue" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Value").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtValue" Width="150px" runat="server" CssClass="csstxtbox" Text='<%# DataBinder.Eval(Container.DataItem, "Value").ToString()%>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtValue" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
