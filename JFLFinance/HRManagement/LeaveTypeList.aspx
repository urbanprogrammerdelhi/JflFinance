<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveTypeList.aspx.cs" Inherits="HRManagement_LeaveTypeList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LinkButton ID="btnLeaveType" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource, LeaveType %>" OnClick="btnLeaveType_Click"></asp:LinkButton>
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvLeaveType" runat="server" PageSize="15" AllowPaging="True"
                AutoGenerateColumns="False" OnRowDataBound="gvLeaveType_RowDataBound" 
                OnRowCommand="gvLeaveType_RowCommand" OnPageIndexChanging="gvLeaveType_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderLeaveTypeCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,LeaveType %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkLeaveTypeCode" runat="server" Text='<%# Bind("Leave_Code") %>'
                                CssClass="csslnkButton" OnClick="LinkLeaveTypeCode_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderLeaveTypeDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,LeaveDesc %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLeaveTypeDesc" CssClass="cssLable" runat="server" Text='<%# Bind("Leave_Desc") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderLeaveUnit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Units %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLeaveTypeUnit" CssClass="cssLable" runat="server" Text='<%# Bind("Leave_Unit") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblAssociatedLeavecode" CssClass="cssLabelHeader" runat="server" Text="Associated Leave"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="HdnAssociatedLeave" runat="server" Value='<%# Bind("AssociatedLeaveCode") %>' />
                            <asp:DropDownList ID="ddlAssiciatedLeavecode" runat="server" CssClass="cssDropDown"
                                Width="150px">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:ImageButton ID="btnImgUpdateAssociatedLeave" runat="server" ImageUrl="~/Images/AddNew.GIF"
                                ToolTip="Update Associated Leave" CommandName="UpdateAssociatedLeave" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderMore" CssClass="cssLabelHeader" runat="server" Text=""></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                            <asp:ImageButton ID="btnImgImgMore" runat="server" ImageUrl="~/Images/more.GIF" ToolTip="More Detail"
                                CommandName="MoreDetail" />
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <div class="squareboxgradientcaption" style="height: 20px;">
                <asp:Label ID="Label13" runat="server" Text="<%$Resources:Resource,LeaveType %>"></asp:Label>:&nbsp;
                <asp:Label ID="gridHeaderSubLeaveType" runat="server"></asp:Label>
            </div>
            <asp:GridView Width="100%" ID="gvSubLeaveType" runat="server" PageSize="5" AllowPaging="True"
                AutoGenerateColumns="False" ShowFooter="true" OnRowCommand="gvSubLeaveType_RowCommand"
                OnRowDeleting="gvSubLeaveType_RowDeleting" OnRowEditing="gvSubLeaveType_RowEditing"
                OnRowUpdating="gvSubLeaveType_RowUpdating" OnRowCancelingEdit="gvSubLeaveType_RowCancelingEdit">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderSubLeaveTypeCode" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource,SubLeaveType %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubLeaveTypeCode" CssClass="cssLabel" runat="server" Text='<%# Bind("SubLeaveCode") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtSubLeaveTypeCode" runat="server" MaxLength="10" CssClass="csstxtbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="SubLeaveTypeCodeValidator" runat="server" ControlToValidate="txtSubLeaveTypeCode"
                                ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderSubLeaveTypeDesc" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource,SubLeaveType %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubLeaveTypeDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("SubLeaveDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditSubLeaveTypeDesc" runat="server" MaxLength="50" CssClass="csstxtbox"
                                Text='<%# Bind("SubLeaveDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtEditSubLeaveTypeDescValidator" runat="server"
                                ControlToValidate="txtEditSubLeaveTypeDesc" ErrorMessage="Cannot be blank!" ValidationGroup="vg_Edit">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtSubLeaveTypeDesc" runat="server" MaxLength="50" CssClass="csstxtbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtSubLeaveTypeDescValidator" runat="server" ControlToValidate="txtSubLeaveTypeDesc"
                                ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
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
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="AddNew"
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
            <asp:HiddenField ID="HdnLeaveTypeCode" runat="server" />
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
