<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AsmtTagReference.aspx.cs" Inherits="Transactions_AsmtTagReference"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="950" border="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="1050px" Height="460px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvAsmtTagRef" Width="1050px" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" CellPadding="0"
                                            PageSize="15" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvAsmtTagRef_RowCommand"
                                            OnRowDeleting="gvAsmtTagRef_RowDeleting" OnPageIndexChanging="gvAsmtTagRef_PageIndexChanging"
                                            OnRowDataBound="gvAsmtTagRef_RowDataBound">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrTagRefSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTagRefSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, PhoneID %>" HeaderStyle-Width="150px" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrTagId"  Width="80px" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PhoneID %>">  </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTagId" CssClass="cssLable"  Width="100px" runat="server" Text='<%# Eval("TagId").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtNewTagId" Width="95px" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtTagRefIdValidator" runat="server" ControlToValidate="txtNewTagId"
                                                            ErrorMessage="*" ValidationGroup="vg_Add"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Client %>" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrClientCode"  Width="170px" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Client %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClientCode"  Width="170px" CssClass="cssLable" runat="server" Text='<%# Eval("Client").ToString()%>'> </asp:Label>
                                                        <asp:HiddenField ID = "hdClientCode" runat ="server" Value = '<%# Eval("ClientCode").ToString()%>' />
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
                                                        <asp:Label ID="lblgvAsmtCode"  Width="170px" CssClass="cssLable" runat="server" Text='<%# Eval("Asmt").ToString()%>'> </asp:Label>
                                                        <asp:HiddenField ID = "hdAsmtId" runat ="server" Value = '<%# Eval("AsmtId").ToString()%>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlAsmtCode"  Width="170px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAsmtCode_SelectedIndexChanged" CssClass="cssDropDown">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrPostCode"  Width="120px" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Post %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPostCode"  Width="120px" CssClass="cssLable" runat="server" Text='<%# Eval("PostCode").ToString()%>'> </asp:Label>
                                                        <asp:HiddenField ID = "hdPostAutoId" runat ="server" Value = '<%# Eval("PostAutoId").ToString()%>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlPostCode"  Width="120px" runat="server" CssClass="cssDropDown">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveFrom" Width="120px"  CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveFrom %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEffectiveFrom" Width="120px"  CssClass="cssLable" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtEffectiveFrom" Width="80px" CssClass="csstxtbox" runat="server"
                                                            MaxLength="11"></asp:TextBox>
                                                        <asp:HyperLink ID="ImgEffectiveFrom" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                         <AjaxToolKit:CalendarExtender ID="calEffectiveFrom" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEffectiveFrom" PopupButtonID="ImgEffectiveFrom">
                                                        </AjaxToolKit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="txtEffectiveFromValidator" runat="server" ControlToValidate="txtEffectiveFrom"
                                                            ErrorMessage="*" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px" ItemStyle-Width="60px" FooterStyle-Width="60px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveFromTime" CssClass="cssLabelHeader" Width="50px" runat="server" Text="From Time"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvItemEffectiveFromTime" CssClass="cssLable" Width="50px" runat="server" Text='<%# String.Format("{0:HH:mm}", Eval("EffectiveFromTime"))%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvEditEffectiveFromTime" CssClass="cssLable" Width="50px" runat="server" Text='<%# String.Format("{0:HH:mm}", Eval("EffectiveFromTime"))%>'> </asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtNewEffectiveFromTime" ValidationGroup="vg_Add" Width="50px" CssClass="csstxtbox"
                                                            runat="server"></asp:TextBox>
                                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtenderEffectiveFromTime" runat="server" TargetControlID="txtNewEffectiveFromTime"
                                                            Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Time" AcceptAMPM="false" UserTimeFormat="TwentyFourHour" ErrorTooltipEnabled="True" />
                                                        <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidatorEffectiveFromTime" runat="server" ControlExtender="MaskedEditExtenderEffectiveFromTime"
                                                            ControlToValidate="txtNewEffectiveFromTime" SetFocusOnError="true" IsValidEmpty="False"
                                                            Display="Dynamic" EmptyValueBlurredText="*" ValidationGroup="vg_Add" InvalidValueBlurredMessage="*" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="130px" ItemStyle-Width="130px" FooterStyle-Width="130px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveTo"  Width="100px" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveTo %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtgvEffectiveTo"  Width="70px"  CssClass="csstxtbox" runat="server" Text=''></asp:TextBox>
                                                        <asp:HyperLink ID="ImgEffectiveTo" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                        <AjaxToolKit:CalendarExtender ID="calEffectiveTo" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtgvEffectiveTo" PopupButtonID="ImgEffectiveTo">
                                                        </AjaxToolKit:CalendarExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveToTime" CssClass="cssLabelHeader" runat="server" Text="To Time"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtItemEffectiveToTime" ValidationGroup="vg_Edit" CssClass="csstxtbox"
                                                            runat="server"  Width="50px" Text='<%# String.Format("{0:HH:mm}", Eval("EffectiveToTime"))%>'></asp:TextBox>
                                                             <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtenderItemEffectiveToTime" runat="server" TargetControlID="txtItemEffectiveToTime"
                                                            Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Time" AcceptAMPM="false" UserTimeFormat="TwentyFourHour" ErrorTooltipEnabled="True" />
                                                        <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidatorItemEffectiveToTime" runat="server" ControlExtender="MaskedEditExtenderItemEffectiveToTime"
                                                            ControlToValidate="txtItemEffectiveToTime" SetFocusOnError="true" IsValidEmpty="False"
                                                            Display="Dynamic" EmptyValueBlurredText="*" ValidationGroup="vg_Edit" InvalidValueBlurredMessage="*"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CausesValidation="true" CssClass="cssImgButton"
                                                            CommandName="Delete" ToolTip="<%$ Resources:Resource, Close %>" ValidationGroup='<%# Eval("Asmt").ToString()%>'
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
                            <tr>
                                <td align="Left">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
