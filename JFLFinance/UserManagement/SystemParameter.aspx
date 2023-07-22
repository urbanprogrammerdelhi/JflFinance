<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#"  MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SystemParameter.aspx.cs" Inherits="UserManagement_SystemParameter" %>
<%@ Register Assembly="MessageBox" Namespace="MessageBox" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" style="margin: 0px; width: 100%">
                            <tr>
                                <td style="text-align: right">
                                    <cc1:MessageBox ID="MessageBox1" Position="Center" runat="server" />
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, MainMenu %>"
                                        OnClick="imgBack_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView Width="100%" ID="gvParamHead" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="5"
                                        CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvParamHead_RowCommand"
                                        OnRowUpdating="gvParamHead_RowUpdating" OnRowDeleting="gvParamHead_RowDeleting"
                                        OnRowEditing="gvParamHead_RowEditing" OnRowCancelingEdit="gvParamHead_RowCancelingEdit"
                                        OnSelectedIndexChanged="gvParamHead_SelectedIndexChanged" OnRowDataBound="gvParamHead_RowDataBound"
                                        OnPageIndexChanging="gvParamHead_PageIndexChanging">
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
                                                    <asp:Label ID="lblgvhdrParamCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamCode %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnSelect" runat="server" CssClass="cssImgButton" CommandName="Select"
                                                        ImageUrl="../Images/Select.gif" />
                                                    <asp:LinkButton ID="lbParamCode" CssClass="csslnkButton" runat="server" CommandName="Select"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ParamCode").ToString()%>' OnClick="lbParamCode_OnClick"></asp:LinkButton>
                                                    <asp:Label ID="lblParamCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamCode").ToString()%>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblParamCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamCode").ToString()%>'></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox Width="85%" ID="txtParamCode" CssClass="csstxtbox" runat="server" MaxLength="80"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvParamCode" ValidationGroup="vgFooter" ControlToValidate="txtParamCode"
                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <FooterStyle Width="180px" />
                                                <HeaderStyle Width="180px" />
                                                <ItemStyle Width="180px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrParamDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamDesc %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamDesc").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="92%" ID="txtParamDesc" CssClass="csstxtbox" runat="server"
                                                        MaxLength="250" Text='<%# DataBinder.Eval(Container.DataItem, "ParamDesc").ToString()%>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvParamDesc" ValidationGroup="vgEdit" ControlToValidate="txtParamDesc"
                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox Width="92%" ID="txtParamDesc" CssClass="csstxtbox" runat="server"
                                                        MaxLength="250"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvParamDesc" ValidationGroup="vgFooter" ControlToValidate="txtParamDesc"
                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrParamImplementationLevel" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamImplementationLevel %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamImplementationLevel" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamImplementationLevel").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlParamImplementationLevel" Filter="StartsWith"/>
                                                    <asp:HiddenField ID="hfParamImplementationLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ParamImplementationLevel").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlParamImplementationLevel" Filter="StartsWith"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrParamType" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamType %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamType" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamType").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlParamType" Filter="StartsWith"/>
                                                    <asp:HiddenField ID="hfParamType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ParamType").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlParamType" Filter="StartsWith"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrParamDateType" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamDateType %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamDateType" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamDataType").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlParamDateType" Filter="StartsWith"/>
                                                    <asp:HiddenField ID="hfParamDataType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ParamDataType").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlParamDateType" Filter="StartsWith"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrIsEditable" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, IsEditable %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsEditable" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsEditable").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbIsEditable" CssClass="cssCheckBox" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsEditable")%>' />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:CheckBox ID="cbIsEditable" CssClass="cssCheckBox" runat="server" />
                                                </FooterTemplate>
                                                <FooterStyle Width="60px" />
                                                <HeaderStyle Width="60px" />
                                                <ItemStyle Width="60px" />
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
                                                    <asp:Label ID="lblgvhdrUserLevelToDefinedValues" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserLevelToDefinedValues %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserLevelToDefinedValues" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserLevelToDefinedValues").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlUserLevelToDefinedValues" Filter="StartsWith"/>
                                                    <asp:HiddenField ID="hfUserLevelToDefinedValues" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "UserLevelToDefinedValues").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlUserLevelToDefinedValues" Filter="StartsWith"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
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
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <asp:Label ID="lblhdrParamDesc" Text="" runat="server" CssClass="csslblPageHeader"></asp:Label>
                                    <asp:Label ID="lblhdrParamCode" Visible="false" Text="" runat="server" CssClass="csslblPageHeader"></asp:Label>
                                    <asp:HiddenField runat="server" ID="hfDataType" Value=""/>
                                    <asp:HiddenField runat="server" ID="hfIsEditable" Value=""/>
                                    <asp:HiddenField runat="server" ID="hfUserLevel" Value=""/>
                                    <asp:HiddenField runat="server" ID="hfImplementationLevel" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView Width="1700" ID="gvParamValue" CssClass="GridViewStyle" runat="server"
                                        AllowPaging="true" PageSize="8" ShowFooter="true" ShowHeader="true" Visible="true"
                                        CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvParamValue_RowCommand"
                                        OnRowUpdating="gvParamValue_RowUpdating" OnRowDeleting="gvParamValue_RowDeleting"
                                        OnRowEditing="gvParamValue_RowEditing" OnRowCancelingEdit="gvParamValue_RowCancelingEdit"
                                        OnRowDataBound="gvParamValue_RowDataBound" OnPageIndexChanging="gvParamValue_PageIndexChanging">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrParamCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamCode %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamCode").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblParamCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamCode").ToString()%>'></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox Width="80%" ID="txtParamCode" CssClass="csstxtbox" runat="server"
                                                        MaxLength="20" ReadOnly="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvParamCode" ValidationGroup="vgMNFooter" ControlToValidate="txtParamCode"
                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrLevel1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Level1 %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" ID="hfParamValuesAutoId" Value='<%# DataBinder.Eval(Container.DataItem, "ParamValuesAutoId").ToString()%>'/>
                                                    <asp:Label ID="lblLevel1" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Level1").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField runat="server" ID="hfParamValuesAutoId" Value='<%# DataBinder.Eval(Container.DataItem, "ParamValuesAutoId").ToString()%>'/>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevel1" Filter="StartsWith" AutoPostBack="true"
                                                        onselectedindexchanged="ddlLevel1_ETSelectedIndexChanged"/>
                                                    <asp:HiddenField ID="hfLevel1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Level1").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevel1" Filter="StartsWith" onselectedindexchanged="ddlLevel1_FTSelectedIndexChanged"  AutoPostBack="true"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrLevelCode1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, LevelCode1 %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLevelCode1" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LevelCode1").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevelCode1" Filter="StartsWith" onselectedindexchanged="ddlLevelCode1_ETSelectedIndexChanged"  AutoPostBack="true"/>
                                                    <asp:HiddenField ID="hfLevelCode1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LevelCode1").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevelCode1" Filter="StartsWith" onselectedindexchanged="ddlLevelCode1_FTSelectedIndexChanged"  AutoPostBack="true"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrLevel2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Level2 %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLevel2" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Level2").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevel2" Filter="StartsWith" onselectedindexchanged="ddlLevel2_ETSelectedIndexChanged"  AutoPostBack="true"/>
                                                    <asp:HiddenField ID="hfLevel2" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Level2").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevel2" Filter="StartsWith" onselectedindexchanged="ddlLevel2_FTSelectedIndexChanged"  AutoPostBack="true"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrLevelCode2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, LevelCode2 %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLevelCode2" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LevelCode2").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevelCode2" Filter="StartsWith" onselectedindexchanged="ddlLevelCode2_ETSelectedIndexChanged"  AutoPostBack="true"/>
                                                    <asp:HiddenField ID="hfLevelCode2" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LevelCode2").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevelCode2" Filter="Contains" onselectedindexchanged="ddlLevelCode2_FTSelectedIndexChanged"  AutoPostBack="true"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrLevel3" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Level3 %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLevel3" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Level3").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevel3" Filter="StartsWith" onselectedindexchanged="ddlLevel3_ETSelectedIndexChanged"  AutoPostBack="true"/>
                                                    <asp:HiddenField ID="hfLevel3" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Level3").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevel3" Filter="StartsWith" onselectedindexchanged="ddlLevel3_FTSelectedIndexChanged"  AutoPostBack="true"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrLevelCode3" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, LevelCode3 %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLevelCode3" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LevelCode3").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevelCode3" Filter="StartsWith" onselectedindexchanged="ddlLevelCode3_ETSelectedIndexChanged"  AutoPostBack="true"/>
                                                    <asp:HiddenField ID="hfLevelCode3" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LevelCode3").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevelCode3" Filter="StartsWith" onselectedindexchanged="ddlLevelCode3_FTSelectedIndexChanged"  AutoPostBack="true"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrLevel4" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Level4 %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLevel4" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Level4").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevel4" Filter="StartsWith" AutoPostBack="true" onselectedindexchanged="ddlLevel4_ETSelectedIndexChanged"/>
                                                    <asp:HiddenField ID="hfLevel4" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Level4").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevel4" Filter="StartsWith" AutoPostBack="true" onselectedindexchanged="ddlLevel4_FTSelectedIndexChanged"/>
                                                </FooterTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrLevelCode4" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, LevelCode4 %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLevelCode4" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LevelCode4").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevelCode4" Filter="StartsWith" onselectedindexchanged="ddlLevelCode4_ETSelectedIndexChanged"/>
                                                    <asp:HiddenField ID="hfLevelCode4" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LevelCode4").ToString()%>'></asp:HiddenField>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadComboBox runat="server" ID="ddlLevelCode4" Filter="StartsWith" onselectedindexchanged="ddlLevelCode4_FTSelectedIndexChanged"/>
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
                                                    <asp:Label ID="lblgvhdrParamValue1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamValue %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamValue1" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamValue1").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="120px" ID="txtParamValue1" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamValue1").ToString()%>' MaxLength="100"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox Width="120px" ID="txtParamValue1" CssClass="csstxtbox" runat="server"
                                                        MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvParamValue1" ValidationGroup="vgMNFooter" ControlToValidate="txtParamValue1"
                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <FooterStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                             <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrParamValue2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamValue %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamValue2" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamValue2").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="120px" ID="txtParamValue2" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamValue2").ToString()%>' MaxLength="100"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox Width="120px" ID="txtParamValue2" CssClass="csstxtbox" runat="server"
                                                        MaxLength="100"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="rfvParamValue2" ValidationGroup="vgMNFooter" ControlToValidate="txtParamValue2"
                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                </FooterTemplate>
                                                <FooterStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                             <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrParamValue3" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamValue %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamValue3" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamValue3").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="120px" ID="txtParamValue3" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamValue3").ToString()%>' MaxLength="100"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox Width="120px" ID="txtParamValue3" CssClass="csstxtbox" runat="server"
                                                        MaxLength="100"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="rfvParamValue3" ValidationGroup="vgMNFooter" ControlToValidate="txtParamValue3"
                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                </FooterTemplate>
                                                <FooterStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                             <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrParamValue4" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ParamValue %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParamValue4" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamValue4").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="120px" ID="txtParamValue4" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParamValue4").ToString()%>' MaxLength="100"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox Width="120px" ID="txtParamValue4" CssClass="csstxtbox" runat="server"
                                                        MaxLength="100"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="rfvParamValue4" ValidationGroup="vgMNFooter" ControlToValidate="txtParamValue4"
                                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                </FooterTemplate>
                                                <FooterStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle Width="150px" />
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
                                                <FooterStyle Width="130px" />
                                                <HeaderStyle Width="130px" />
                                                <ItemStyle Width="130px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblErrMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
