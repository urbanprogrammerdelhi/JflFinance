<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/MasterPage/MasterHeader.master"
    CodeFile="MenuCreation.aspx.cs" Inherits="UserManagement_MenuCreation" Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="MessageBox" Namespace="MessageBox" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <asp:ImageButton ID="imgBack" CssClass="cssButton" runat="server" AlternateText="<%$ Resources:Resource, Back %>" ToolTip="<%$ Resources:Resource, MainMenu %>" OnClick="imgBack_Click" />
            <asp:GridView Width="100%" ID="gvMenuHead" CssClass="GridViewStyle" runat="server"
                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="20"
                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvMenuHead_RowCommand"
                OnRowUpdating="gvMenuHead_RowUpdating" OnRowDeleting="gvMenuHead_RowDeleting"
                OnRowEditing="gvMenuHead_RowEditing" OnRowCancelingEdit="gvMenuHead_RowCancelingEdit"
                OnSelectedIndexChanged="gvMenuHead_SelectedIndexChanged" OnRowDataBound="gvMenuHead_RowDataBound"
                OnPageIndexChanging="gvMenuHead_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" Visible="False" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrMenuHeadCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuHeadCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbMenuHeadCode" CssClass="csslnkButton" runat="server" CommandName="Select"
                                Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>' OnClick="lbMenuHeadCode_OnClick"></asp:LinkButton>
                            <asp:Label ID="lblMenuHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>' Visible="false"></asp:Label>
                            <asp:HiddenField runat="server" ID="hfMenuHeadAutoId" Value='<%# DataBinder.Eval(Container.DataItem, "MenuHeadAutoId").ToString()%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblMenuHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>'></asp:Label>
                            <asp:HiddenField runat="server" ID="hfMenuHeadAutoId" Value='<%# DataBinder.Eval(Container.DataItem, "MenuHeadAutoId").ToString()%>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="85%" ID="txtMenuHeadCode" CssClass="csstxtbox" runat="server"
                                MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMenuHeadCode" ValidationGroup="vgFooter" ControlToValidate="txtMenuHeadCode"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <FooterStyle Width="180px" />
                        <HeaderStyle Width="180px" />
                        <ItemStyle Width="180px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrMenuHeadName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuHeadName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMenuHeadName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadName").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="92%" ID="txtMenuHeadName" CssClass="csstxtbox" runat="server"
                                MaxLength="50" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadName").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMenuHeadName" ValidationGroup="vgEdit" ControlToValidate="txtMenuHeadName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="92%" ID="txtMenuHeadName" CssClass="csstxtbox" runat="server"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMenuHeadName" ValidationGroup="vgFooter" ControlToValidate="txtMenuHeadName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrPositionNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuPosition %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPositionNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PositionNo").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="80%" ID="txtPositionNo" CssClass="csstxtbox" runat="server" MaxLength="2"
                                Text='<%# DataBinder.Eval(Container.DataItem, "PositionNo").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPositionNo" ValidationGroup="vgEdit" ControlToValidate="txtPositionNo"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="80%" ID="txtPositionNo" CssClass="csstxtbox" runat="server" MaxLength="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPositionNo" ValidationGroup="vgFooter" ControlToValidate="txtPositionNo"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <FooterStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrIsActive" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, IsActive %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblIsActive" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsActive").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbIsActive" CssClass="cssCheckBox" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive")%>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="cbIsActive" CssClass="cssCheckBox" runat="server" />
                        </FooterTemplate>
                        <FooterStyle Width="60px" />
                        <HeaderStyle Width="60px" />
                        <ItemStyle Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrParentMenuHeadCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParentMenu %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblParentMenuHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParentMenuHeadCode").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hfParentMenuHeadCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ParentMenuHeadCode").ToString()%>' />
                            <asp:HiddenField runat="server" ID="hfParentMenuHeadAutoId" Value='<%# DataBinder.Eval(Container.DataItem, "ParentMenuHeadAutoId").ToString()%>' />
                            <asp:DropDownList Width="85%" runat="server" ID="ddlParentMenuHeadCode" CssClass="cssDropDown"></asp:DropDownList>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList Width="85%" runat="server" ID="ddlParentMenuHeadCode" CssClass="cssDropDown"></asp:DropDownList>
                        </FooterTemplate>
                        <FooterStyle Width="180px" />
                        <HeaderStyle Width="180px" />
                        <ItemStyle Width="180px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnEdit" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                ValidationGroup="vgEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Update %>" CommandName="Update" ValidationGroup="vgEdit"></asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                ValidationGroup="vgFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, AddNew %>" CommandName="Add" ValidationGroup="vgFooter"></asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                        </FooterTemplate>
                        <FooterStyle Width="130px" />
                        <HeaderStyle Width="130px" />
                        <ItemStyle Width="130px" />
                    </asp:TemplateField>
                </Columns>
                <PagerSettings FirstPageText="|&lt;" LastPageText="&gt;|" Mode="NumericFirstLast" />
            </asp:GridView>
            <asp:Label ID="lblhdrMenuHeadName" Text="" runat="server" CssClass="csslblPageHeader"></asp:Label>
            <asp:Label ID="lblhdrMenuHeadCode" Visible="false" Text="" runat="server" CssClass="csslblPageHeader"></asp:Label>
            <asp:HiddenField ID="hfhdrMenuHeadAutoId" runat="server" Value="" />
            <asp:GridView Width="100%" ID="gvMenuNode" CssClass="GridViewStyle" runat="server"
                AllowPaging="true" PageSize="20" ShowFooter="true" ShowHeader="true" Visible="true"
                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvMenuNode_RowCommand"
                OnRowUpdating="gvMenuNode_RowUpdating" OnRowDeleting="gvMenuNode_RowDeleting"
                OnRowEditing="gvMenuNode_RowEditing" OnRowCancelingEdit="gvMenuNode_RowCancelingEdit"
                OnRowDataBound="gvMenuNode_RowDataBound" OnPageIndexChanging="gvMenuNode_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:BoundField DataField="MenuNodeAutoId" HeaderText="Menu Node AutoId" Visible="false" />
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrMenuHeadCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuHeadCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMenuHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblMenuHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="80%" ID="txtMenuHeadCode" CssClass="csstxtbox" runat="server"
                                MaxLength="20" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMenuHeadCode" ValidationGroup="vgMNFooter" ControlToValidate="txtMenuHeadCode"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrMenuNodeCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuNodeCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMenuNodeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeCode").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblMenuNodeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeCode").ToString()%>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="120px" ID="txtMenuNodeCode" CssClass="csstxtbox" runat="server"
                                MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMenuNodeCode" ValidationGroup="vgMNFooter" ControlToValidate="txtMenuNodeCode"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <FooterStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrMenuNodeName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuNodeName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMenuNodeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeName").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="120px" ID="txtMenuNodeName" CssClass="csstxtbox" runat="server"
                                MaxLength="50" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeName").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMenuNodeName" ValidationGroup="vgMNEdit" ControlToValidate="txtMenuNodeName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="120px" ID="txtMenuNodeName" CssClass="csstxtbox" runat="server"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMenuNodeName" ValidationGroup="vgMNFooter" ControlToValidate="txtMenuNodeName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <FooterStyle Width="150px" />
                        <HeaderStyle Width="150px" />
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrPageName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PageName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPageName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PageName").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="90%" ID="txtPageName" CssClass="csstxtbox" runat="server" MaxLength="150"
                                Text='<%# DataBinder.Eval(Container.DataItem, "PageName").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPageName" ValidationGroup="vgMNEdit" ControlToValidate="txtPageName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="90%" ID="txtPageName" CssClass="csstxtbox" runat="server" MaxLength="150"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPageName" ValidationGroup="vgMNFooter" ControlToValidate="txtPageName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                                            
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrDependOn" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DependOn %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDependOn" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DependOnMenuNodeName").ToString()%>'></asp:Label>
                        </ItemTemplate> 
                        <EditItemTemplate>
                            <asp:HiddenField ID="hfDependOn" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DependOn").ToString()%>' />                                                    
                            <asp:DropDownList Width="85%" runat="server" ID="ddlDependOn" CssClass="cssDropDown"></asp:DropDownList>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList Width="85%" runat="server" ID="ddlDependOn" CssClass="cssDropDown"></asp:DropDownList>
                        </FooterTemplate>
                        <FooterStyle Width="180px" />
                        <HeaderStyle Width="180px" />
                        <ItemStyle Width="180px" />
                    </asp:TemplateField>
                                            
                                            
                                            
                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrPositionNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuPosition %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPositionNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PositionNo").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="80%" ID="txtPositionNo" CssClass="csstxtbox" runat="server" MaxLength="2"
                                Text='<%# DataBinder.Eval(Container.DataItem, "PositionNo").ToString()%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPositionNo" ValidationGroup="vgMNEdit" ControlToValidate="txtPositionNo"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="80%" ID="txtPositionNo" CssClass="csstxtbox" runat="server" MaxLength="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPositionNo" ValidationGroup="vgMNFooter" ControlToValidate="txtPositionNo"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="60px" FooterStyle-Width="60px" ItemStyle-Width="60px">
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrIsActive" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, IsActive %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblIsActive" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsActive").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbIsActive" CssClass="cssCheckBox" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive")%>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="cbIsActive" CssClass="cssCheckBox" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="130px" FooterStyle-Width="130px" ItemStyle-Width="130px">
                        <HeaderTemplate>
                            <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnEdit" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                ValidationGroup="vgMNEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Update %>" CommandName="Update" ValidationGroup="vgMNEdit"></asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                ValidationGroup="vgMNFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, AddNew %>" CommandName="Add" ValidationGroup="vgMNFooter"></asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblErrMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
