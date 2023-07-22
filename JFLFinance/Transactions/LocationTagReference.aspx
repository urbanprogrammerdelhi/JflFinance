<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LocationTagReference.aspx.cs"
    Inherits="Transactions_LocationTagReference" MasterPageFile="~/MasterPage/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="950" border="0">
                            <tr>
                                <td width="150">
                                    <asp:DropDownList ID="ddlSearchBy" Width="150px" runat="server" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td width="230">
                                    <asp:TextBox ID="txtSearch" Width="200px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hfSearchText" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="Button1" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                                        OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnViewAll" Visible="false" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                        OnClick="btnViewAll_Click" />
                                    <asp:Button ID="btnExport" Visible="true" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>"
                                        OnClick="btnExport_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="950" border="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="1050px" Height="470px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvLocTagRef" Width="1350px" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" CellPadding="0"
                                            PageSize="10" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvLocTagRef_RowCommand"
                                            OnRowDeleting="gvLocTagRef_RowDeleting" OnPageIndexChanging="gvLocTagRef_PageIndexChanging"
                                            OnRowDataBound="gvLocTagRef_RowDataBound">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-Width="30px" FooterStyle-Width="30px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrTagRefSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTagRefSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle Width="50px" />
                                                    <HeaderStyle Width="50px" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField FooterStyle-Width="120px" HeaderStyle-Width="120px" ItemStyle-Width="120px" >
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrTagType" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Type %>" Width="80px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTagType" CssClass="cssLable" runat="server" Text='<%# Eval("TagType").ToString()  %>' Width="80px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList CssClass="cssDropDown" runat="server" ID="ddlTagType" Width="80px">
                                                            <asp:ListItem Selected="True" Text="Location" Value="LOC"> </asp:ListItem>
                                                            <asp:ListItem Selected="False" Text="<%$ Resources:Resource,Equipment %>" Value="EQP"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-Width="120px" HeaderText="<%$ Resources:Resource, TagId %>"
                                                    HeaderStyle-HorizontalAlign="Left" FooterStyle-Width="120px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrTagId" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, TagId %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTagId" CssClass="cssLable" runat="server" Text='<%# Eval("TagID").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtNewTagId" CssClass="csstxtbox" Width="70px" runat="server" MaxLength="10"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtTagRefIdValidator" runat="server" ControlToValidate="txtNewTagId" Width="1px"
                                                            ErrorMessage="cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-Width="200px" HeaderText="<%$ Resources:Resource,TagDescription %>"
                                                    HeaderStyle-HorizontalAlign="Left" FooterStyle-Width="200px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrTagDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,TagDescription %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTagDesc" CssClass="cssLable" runat="server" Text='<%# Eval("TagDescription").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTagDesc" CssClass="csstxtbox" runat="server" AutoPostBack="false" Width="160px"
                                                            MaxLength="255"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtEmployeeNumberValidator" runat="server" ControlToValidate="txtTagDesc"
                                                            ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Client %>" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrClientCode"  Width="170px" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Client %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClientCode"  Width="170px" CssClass="cssLable" runat="server" Text='<%# Eval("ClientCode").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlClientCode" Width="170px" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Asmt %>" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrAsmtCode"  Width="170px" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Asmt %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAsmtCode"  Width="170px" CssClass="cssLable" runat="server" Text='<%# Eval("AsmtCode").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlAsmtCode"  Width="170px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAsmtCode_SelectedIndexChanged" CssClass="cssDropDown">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="170px" HeaderStyle-Width="170px" HeaderText="<%$ Resources:Resource,Post %>"
                                                    HeaderStyle-HorizontalAlign="Left" FooterStyle-Width="170px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrPost" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,Post %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPost" CssClass="cssLable" runat="server" Text='<%# Eval("PostID").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlPostID" CssClass="cssDropDown" Width="170px">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="170px" HeaderStyle-Width="170px" HeaderStyle-HorizontalAlign="Left"
                                                    FooterStyle-Width="170px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveFrom %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtEffectiveFrom" Width="70px" CssClass="csstxtbox" runat="server"
                                                            MaxLength="11"></asp:TextBox>
                                                        <asp:HyperLink ID="ImgEffectiveFrom" Style="vertical-align: middle; width: 10px;
                                                            border: 1px" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEffectiveFrom" PopupButtonID="ImgEffectiveFrom" >
                                                        </AjaxToolKit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="txtEffectiveFromValidator" runat="server" ControlToValidate="txtEffectiveFrom" SetFocusOnError="true" 
                                                            ErrorMessage="cannot be blank!" ValidationGroup="vg_Add" Width="2px">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="158px" HeaderStyle-Width="158px" HeaderStyle-HorizontalAlign="Left"
                                                    FooterStyle-Width="158px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveTo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveTo %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtgvEffectiveTo" CssClass="csstxtbox" runat="server" Width="70px"
                                                            Text=''></asp:TextBox>
                                                        <asp:HyperLink ID="ImgEffectiveTo" Style="vertical-align: middle; width: 10px; border: 1px"
                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server" 
                                                            TargetControlID="txtgvEffectiveTo" PopupButtonID="ImgEffectiveTo">
                                                        </AjaxToolKit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="txtEffectiveToValidator" runat="server" ControlToValidate="txtgvEffectiveTo" SetFocusOnError="true"
                                                            Width="1px" ErrorMessage="cannot be blank!" ValidationGroup='<%# Eval("TagID").ToString()%>'>*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CausesValidation="true" CssClass="cssImgButton"
                                                            CommandName="Delete" ToolTip="<%$ Resources:Resource, Close %>" ValidationGroup='<%# Eval("TagID").ToString()%>'
                                                            ImageUrl="../Images/TerminateEmp.gif" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="true" CssClass="cssImgButton"
                                                            CommandName="Delete1" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add New"
                                                            ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" OnClick="btnReset_Click"
                                                            CommandName="Reset" ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
