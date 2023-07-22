<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Qualification.aspx.cs" Inherits="Masters_Qualification" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button ID="btnExport" Visible="true" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>"
        OnClick="btnExport_Click" />
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvQualification" PageSize="15" CssClass="GridViewStyle"
                runat="server" ShowFooter="True" AllowPaging="True" CellPadding="1" DataKeyNames="QualificationCode"
                AutoGenerateColumns="False" OnRowCommand="gvQualification_RowCommand" OnRowEditing="gvQualification_RowEditing"
                OnRowUpdating="gvQualification_RowUpdating" OnSelectedIndexChanged="gvQualification_SelectedIndexChanged"
                OnDataBound="gvQualification_DataBound" OnRowCancelingEdit="gvQualification_RowCancelingEdit"
                OnRowDeleting="gvQualification_RowDeleting" OnPageIndexChanging="gvQualification_PageIndexChanging"
                OnRowDataBound="gvQualification_RowDataBound">
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
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,QualificationCode %>" HeaderStyle-Width="200px"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <EditItemTemplate>
                            <asp:Label ID="lblEditQualificationCode" CssClass="cssLable" runat="server" Text='<%# Eval("QualificationCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationCode" Width="180px" CssClass="cssLable" runat="server"
                                Text='<%# Bind("QualificationCode") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewQualificationCode" ValidationGroup="AddNew" Width="180px"
                                MaxLength="16" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtNewQualificationCode"
                                Display="Dynamic" ErrorMessage="" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,QualificationDesc %>" HeaderStyle-Width="600px"
                        FooterStyle-Width="600px" ItemStyle-Width="600px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQualificationDesc" ValidationGroup="Edit" Width="580px" MaxLength="50"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("QualificationDesc") %>'></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQualificationDesc"
                                Display="Dynamic" ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text='<%# Bind("QualificationDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewQualificationDesc" ValidationGroup="AddNew" Width="580px"
                                MaxLength="50" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewQualificationDesc"
                                Display="Dynamic" ErrorMessage="" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdateQual" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImageButton2Qual" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEditQual" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                CommandName="Edit" />
                            <asp:ImageButton ID="IBDeleteQual" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
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
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
