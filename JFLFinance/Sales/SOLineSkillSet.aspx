<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SOLineSkillSet.aspx.cs" Inherits="Sales_SOLineSkillSet"
    Title="<%$Resources:Resource,AppTitle %>" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
                    <label id="IfrmLabel" style=" color:White"  ></label>
                    <Ajax:ScriptManager ID="script" runat="server">
                    </Ajax:ScriptManager>
                    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="EmpDetails" ActiveTabIndex="0">
                                <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPanel1" runat="server" HeaderText="<%$Resources:Resource,Skills %>" TabIndex="0">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td style="text-align:right;">
                                                    <asp:Label ID="lblClientCode" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ClientCode %>"/>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="lblClientCodeValue"  CssClass="cssLabelHeader" runat="server"  Style="font-weight: bold;"  Width="90px" ></asp:Label>
                                                </td>
                                                <td style="text-align:right;">
                                                    <asp:Label ID="lblClientName"   CssClass="cssLabel"  runat="server" Text="<%$ Resources:Resource, ClientName %>"/>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="lblClientNameValue"   CssClass="cssLabelHeader"  Style="font-weight: bold;" runat="server"  ></asp:Label>
                                                </td>
                                                <td style="text-align:right;">
                                                    <asp:Label ID="lblfixSoNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SONo %>"></asp:Label>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label  Style="font-weight: bold;" ID="lblSoNo" CssClass="cssLabelHeader" runat="server"></asp:Label><asp:HiddenField ID="hfLocationAutoId" runat="server" />
                                                </td>
                                                <td style="text-align:right;">
                                                    <asp:Label  ID="lblfixSOAmendNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SOAmendNo %>"></asp:Label>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label  Style="font-weight: bold;" ID="lblSOAmendNo" CssClass="cssLabelHeader" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align:right;">
                                                    <asp:Label ID="lblfixSoStatus" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SOStatus %>"></asp:Label>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label Width="100px" Style="font-weight: bold;" ID="lblSoStatus" CssClass="cssLabelHeader" runat="server"></asp:Label><asp:HiddenField ID="hfIsMAXSOAmendNo" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align:right;">
                                                    <asp:Label ID="lblAsmtID" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, AsmtId %>"/>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="lblAsmtIDValue"  CssClass="cssLabelHeader"  runat="server" Style="font-weight: bold;"></asp:Label>
                                                </td>
                                                <td style="text-align:right;">
                                                    <asp:Label ID="lblAsmtName" CssClass="cssLabel"  runat="server" Text="<%$ Resources:Resource, AsmtName %>"/>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="lblAsmtNameValue"  CssClass="cssLabelHeader"  runat="server"  Style="font-weight: bold;"  ></asp:Label>
                                                </td>
                                                <td style="text-align:right;">
                                                    <asp:Label ID="lblpostID" CssClass="cssLabel"  runat="server" Text="<%$ Resources:Resource, Post %>"/>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="lblpostIdValue"  CssClass="cssLabelHeader"  runat="server"  Style="font-weight: bold;"  ></asp:Label>
                                                </td>
                                                <td style="text-align:right;">
                                                    <asp:Label ID="lblfixSOLineNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SOLineNo %>"></asp:Label>
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="lblSOLineNo" CssClass="cssLabelHeader" runat="server" Style="font-weight: bold;"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField runat="server" ID="hfSOLineSkillsAutoID" />
                                        <div class="squareboxgradientcaption" style="height: 20px;">
                                            <asp:Label ID="Label3" Style="text-align: center;" runat="server" Text="<%$Resources:Resource,Skills %>"></asp:Label>
                                        </div>
                                        <div>
                                            <table border="0" cellpadding="1" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td style="vertical-align: top; text-align: left;">
                                                        <asp:GridView Width="98%" ID="gvQualification" CssClass="GridViewStyle" runat="server"
                                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvQualification_RowCommand"
                                                            OnRowUpdating="gvQualification_RowUpdating" OnRowDataBound="gvQualification_RowDataBound"
                                                            OnRowCancelingEdit="gvQualification_RowCancelingEdit" OnPageIndexChanging="gvQualification_PageIndexChanging"
                                                            OnRowDeleting="gvQualification_RowDeleting" OnRowEditing="gvQualification_RowEditing">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblaction" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                            ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                            ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrQualificationCode" runat="server" Text="<%$ Resources:Resource, QualificationCode %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvQualificationCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QualificationDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFQualificationCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "QualificationCode").ToString()%>' />
                                                                            <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlQualificationCode"
                                                                            runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hfQualificationCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "QualificationCode").ToString()%>' />
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlQualificationCode"
                                                                            runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrIsMandatoryQualification" runat="server" Text="<%$ Resources:Resource, RigidityLevel %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQualificationRigiditylevel" runat="server" CssClass="cssLabel"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFQualificationRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                        <%-- <asp:CheckBox ID="cbIsMandatoryQualification" CssClass="cssCheckBox" runat="server"
                                                                            Enabled="false" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsMandatory").ToString())%>' />--%>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <%--<asp:CheckBox ID="cbIsMandatoryQualification" CssClass="cssCheckBox" runat="server"
                                                                            Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsMandatory").ToString())%>' />--%>
                                                                        <asp:HiddenField ID="HFQualificationRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                        <asp:DropDownList ID="ddlQualificationRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLQualificationRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <%--<asp:CheckBox ID="cbIsMandatoryQualification" CssClass="cssCheckBox" runat="server" />--%>
                                                                        <asp:DropDownList ID="ddlQualificationRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLQualificationRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td style="vertical-align: top; text-align: left;">
                                                        <asp:GridView Width="98%" ID="gvLanguage" CssClass="GridViewStyle" runat="server"
                                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvLanguage_RowCommand"
                                                            OnRowUpdating="gvLanguage_RowUpdating" OnRowDataBound="gvLanguage_RowDataBound"
                                                            OnRowCancelingEdit="gvLanguage_RowCancelingEdit" OnPageIndexChanging="gvLanguage_PageIndexChanging"
                                                            OnRowDeleting="gvLanguage_RowDeleting" OnRowEditing="gvLanguage_RowEditing">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblaction" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                            ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                            ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrLanguageCode" runat="server" Text="<%$ Resources:Resource, LanguageCode %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvLanguageCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LanguageDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFLanguageCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LanguageCode").ToString()%>' />
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlLanguageCode" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hfLanguageCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LanguageCode").ToString()%>' />
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlLanguageCode" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrIsMandatoryLanguage" runat="server" Text="<%$ Resources:Resource, RigidityLevel %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%--<asp:CheckBox ID="cbIsMandatoryLanguage" CssClass="cssCheckBox" runat="server" Enabled="false"
                                                                            Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsMandatory").ToString())%>' />--%>
                                                                        <asp:Label ID="lblLanguageRigiditylevel" runat="server" CssClass="cssLabel"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFLanguageRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <%-- <asp:CheckBox ID="cbIsMandatoryLanguage" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsMandatory").ToString())%>' />--%>
                                                                        <asp:HiddenField ID="HFLanguageRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                        <asp:DropDownList ID="ddlLanguageRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLLanguageRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <%-- <asp:CheckBox ID="cbIsMandatoryLanguage" CssClass="cssCheckBox" runat="server" />--%>
                                                                        <asp:DropDownList ID="ddlLanguageRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLLanguageRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem  Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; text-align: left;">
                                                        <asp:GridView Width="98%" ID="gvOSkill" CssClass="GridViewStyle" runat="server"
                                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvOSkill_RowCommand"
                                                            OnRowUpdating="gvOSkill_RowUpdating" OnRowDataBound="gvOSkill_RowDataBound" OnRowCancelingEdit="gvOSkill_RowCancelingEdit"
                                                            OnRowDeleting="gvOSkill_RowDeleting" OnPageIndexChanging="gvOSkill_PageIndexChanging"
                                                            OnRowEditing="gvOSkill_RowEditing">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblaction"  runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                            ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                            ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOSkillCode"  runat="server" Text="<%$ Resources:Resource, IdDetails %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOSkillCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IDTypeDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFSkillCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OtherSkillCode").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlOSkillCode" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hfOSkillCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OtherSkillCode").ToString()%>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlOSkillCode" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrIsMandatoryOSkill" runat="server"
                                                                            Text="<%$ Resources:Resource, RigidityLevel %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRigiditylevel" runat="server" CssClass="cssLabel"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="HFSkillRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                        <asp:DropDownList ID="ddlSkillRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlSkillRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem  Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td style="vertical-align: top; text-align: left;">
                                                        <asp:GridView Width="98%" ID="gvTraining" CssClass="GridViewStyle" runat="server"
                                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvTraining_RowCommand"
                                                            OnRowUpdating="gvTraining_RowUpdating" OnRowDataBound="gvTraining_RowDataBound"
                                                            OnRowCancelingEdit="gvTraining_RowCancelingEdit" OnPageIndexChanging="gvTraining_PageIndexChanging"
                                                            OnRowDeleting="gvTraining_RowDeleting" OnRowEditing="gvTraining_RowEditing">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblaction" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                            ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                            ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTrainingCode" runat="server" Text="<%$ Resources:Resource, TrainingCode %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTrainingCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TrainingDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFTrainingCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TrainingCode").ToString()%>' />
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlTrainingCode" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hfTrainingCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TrainingCode").ToString()%>' />
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlTrainingCode" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrIsMandatoryTraining" runat="server"
                                                                            Text="<%$ Resources:Resource, RigidityLevel %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRigiditylevel" runat="server" CssClass="cssLabel"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="HFTrainingRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                        <asp:DropDownList ID="ddlTrainingRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlTrainingRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem  Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:GridView Width="100%" ID="gvSaleConstraint" CssClass="GridViewStyle" runat="server"
                                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvSaleConstraint_RowCommand"
                                                            OnRowUpdating="gvSaleConstraint_RowUpdating" OnRowDeleting="gvSaleConstraint_RowDeleting"
                                                            OnRowEditing="gvSaleConstraint_RowEditing" OnRowCancelingEdit="gvSaleConstraint_RowCancelingEdit"
                                                            OnRowDataBound="gvSaleConstraint_RowDataBound" OnPageIndexChanging="gvSaleConstraint_PageIndexChanging">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblaction" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
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
                                                                        <asp:Label ID="lblgvhdrSerialNo" runat="server" Text="<%$ Resources:Resource,SoLineNo %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSoLineNo" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "SoLineNo").ToString()%>'
                                                                            runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="50px" />
                                                                    <HeaderStyle Width="50px" />
                                                                    <FooterStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Code %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblConstraintType" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFConstraintTypeAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeAutoID").ToString()%>' />
                                                                        <asp:HiddenField ID="HFSaleConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SaleConstraintAutoID").ToString()%>' />
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlConstraintType" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                                            OnSelectedIndexChanged="ddlConstraintType_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="HFConstraintTypeAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeAutoID").ToString()%>' />
                                                                        <asp:HiddenField ID="HFSaleConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SaleConstraintAutoID").ToString()%>' />
                                                                        <asp:HiddenField ID="HFClientConstraint" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraint").ToString()%>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlConstraintType" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintType_SelectedIndexChanged"
                                                                            runat="server" CssClass="cssDropDown">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Width="100px" />
                                                                    <HeaderStyle Width="100px" />
                                                                    <FooterStyle Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Description %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblConstraintDesc" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFConstraintCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintCode").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlConstraintDesc" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintDesc_SelectedIndexChanged"
                                                                            runat="server" CssClass="cssDropDown">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="HFConstraintCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintCode").ToString()%>' />
                                                                        <asp:HiddenField ID="HFConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintAutoID").ToString()%>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlConstraintDesc" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintDesc_SelectedIndexChanged"
                                                                            runat="server" CssClass="cssDropDown">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Width="250px" />
                                                                    <HeaderStyle Width="250px" />
                                                                    <FooterStyle Width="250px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Operator %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOperator" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Operator").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="HFOperator" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OperatorValue").ToString()%>' />
                                                                        <asp:DropDownList ID="ddlOperator" Width="100px" CssClass="cssDropDown" runat="server">
                                                                            <asp:ListItem Text="Greater Than" Value=">"></asp:ListItem>
                                                                            <asp:ListItem Text="Less Than" Value="<"></asp:ListItem>
                                                                            <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                                                            <asp:ListItem Text="Like" Value="%"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlOperator" Width="100px" CssClass="cssDropDown" runat="server">
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
                                                                        <asp:DropDownList ID="ddlValue" Style="display: none;" Width="150px" runat="server"
                                                                            CssClass="cssDropDown">
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtValue" Width="150px" runat="server" CssClass="csstxtbox" Text='<%# DataBinder.Eval(Container.DataItem, "Value").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlValue" Style="display: none;" Width="150px" runat="server"
                                                                            CssClass="cssDropDown">
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtValue" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,RigidityLevel %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRigiditylevel" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                        <asp:HiddenField ID="HFRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="HFConstraintRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                        <asp:DropDownList ID="ddlConstraintRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlConstraintRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                        <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                            <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                            <asp:ListItem  Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblConstraintErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text="Save" OnClick="btnSave_Click" />
                                        </div>
                                        <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    </ContentTemplate>
                                </AjaxToolKit:TabPanel>
                            </AjaxToolKit:TabContainer>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
    </form>
</body>
</html>
