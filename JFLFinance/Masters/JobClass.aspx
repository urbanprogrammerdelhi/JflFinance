<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="JobClass.aspx.cs" Inherits="Masters_JobClass" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvJobClass" CssClass="GridViewStyle" runat="server"
                ShowFooter="True" AllowPaging="True" PageSize="15" CellPadding="1" GridLines="None"
                AutoGenerateColumns="False" OnPageIndexChanging="gvJobClass_PageIndexChanging"
                OnRowCancelingEdit="gvJobClass_RowCancelingEdit" OnRowCommand="gvJobClass_RowCommand"
                OnRowDataBound="gvJobClass_RowDataBound" OnRowDeleting="gvJobClass_RowDeleting"
                OnRowEditing="gvJobClass_RowEditing" OnRowUpdating="gvJobClass_RowUpdating">
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
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,JobClassCode %>" HeaderStyle-Width="200px"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblJobClassCode" CssClass="cssLabel" runat="server" Text='<%# Bind("JobClassCode") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" />
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewJobClassCode" MaxLength="16" Width="85%" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtNewJobClassCode"
                                ErrorMessage="" ValidationGroup="AddNew" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,JobClassDesc %>" HeaderStyle-Width="600px"
                        FooterStyle-Width="600px" ItemStyle-Width="600px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtJobClassDesc" CssClass="csstxtbox" Width="550px" MaxLength="50"
                                runat="server" Text='<%# Bind("JobClassDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtJobClassDesc"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("JobClassDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewJobClassDesc" Width="550px" MaxLength="50" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewJobClassDesc"
                                ErrorMessage="" ValidationGroup="AddNew" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$ Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImageButton2" ToolTip="<%$ Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEdit" ToolTip="<%$ Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif" CssClass="csslnkButton"
                                ValidationGroup="Edit" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="IBDelete" ToolTip="<%$ Resources:Resource,Delete %>"  ImageUrl="~/Images/Delete.gif" runat="server"
                                CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$ Resources:Resource,AddNew %>"  CssClass="cssImgButton"
                                ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="lbReset" ToolTip="<%$ Resources:Resource,Reset %>" runat="server" CssClass="cssImgButton"
                                CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                        <FooterStyle Width="100px" />
                        <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
