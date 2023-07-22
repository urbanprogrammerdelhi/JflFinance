<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PopInterval.aspx.cs" Inherits="TestPages_PopInterval" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="950" border="0">
        <%--  <tr>
            <td width="150">
                <asp:DropDownList ID="ddlSearchBy" Width="150px" runat="server" CssClass="cssDropDown">
                </asp:DropDownList>
            </td>
            <td width="230">
                <asp:TextBox ID="txtSearch" Width="200px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                <asp:HiddenField ID="hfSearchText" runat="server" />
            </td>
            <td align="left">
                <asp:Button ID="btnSearch" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                    OnClick="btnSearch_Click" CausesValidation="false" />
                <asp:Button ID="btnViewAll" Visible="false" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                    OnClick="btnViewAll_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>--%>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="1050" border="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="1050px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gv" Width="1050px" CssClass="GridViewStyle" runat="server" ShowFooter="true"
                                            ShowHeader="true" Visible="true" AllowPaging="true" CellPadding="0" PageSize="15"
                                            GridLines="None" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" OnRowDeleting="gv_RowDeleting"
                                            OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" OnRowEditing="gv_RowEditing"
                                            OnRowUpdating="gv_RowUpdating" OnRowCancelingEdit="gv_RowCancelingEdit">
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
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Client %>" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrClientCode" Width="170px" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,Client %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Visible ="false" Text='<%# Eval("ClientCode").ToString()%>'> </asp:Label>
                                                        <asp:Label ID="lblClient" Width="170px" CssClass="cssLable" runat="server" Text='<%# Eval("ClientName").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlClientCode" Width="170px" runat="server" CssClass="cssDropDown"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Asmt %>" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrAsmtCode" Width="170px" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,Asmt %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAsmtCode" CssClass="cssLable" Visible= "false" runat="server" Text='<%# Eval("AsmtCode").ToString()%>'> </asp:Label>
                                                        <asp:Label ID="lblAsmt" Width="170px" CssClass="cssLable" runat="server" Text='<%# Eval("AsmtAddress").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlAsmtCode" Width="170px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlAsmtCode_SelectedIndexChanged" CssClass="cssDropDown">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrPostCode" Width="150px" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,Post %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPostCode" Width="150px" CssClass="cssLable" runat="server" Text='<%# Eval("PostCode")%>'> </asp:Label>
                                                        <asp:HiddenField ID= "hdgvPostCode" runat="server" Value='<%# Eval("PostAutoId").ToString()%>'> </asp:HiddenField>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlPostCode" Width="150px" runat="server" CssClass="cssDropDown">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrInterval" Width="90px" CssClass="cssLabelHeader" runat="server"
                                                            Text="Time Interval Hr"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvInterval" Width="80px" CssClass="cssLable" runat="server" Text='<%#string.Format("{0:f2}",Eval("POPInterval"))%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:HiddenField ID="HFDuration" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "POPInterval").ToString()%>' />
                                                        <asp:DropDownList ID="ddlInterval" Width="80px" runat="server" CssClass="cssDropDown">
                                                           <asp:ListItem Text=".5" Value="30"></asp:ListItem>
                                                             <asp:ListItem Text="1" Value="60"></asp:ListItem>
                                                              <asp:ListItem Text="1.5" Value="90"></asp:ListItem>
                                                            <asp:ListItem Text="2" Value="120"></asp:ListItem>
                                                             <asp:ListItem Text="2.5" Value="150"></asp:ListItem>
                                                            <asp:ListItem Text="3" Value="180"></asp:ListItem>
                                                          <%--<asp:ListItem Text="4" Value="240"></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlNewInterval" Width="80px" runat="server" CssClass="cssDropDown">
                                                            
                                                           <asp:ListItem Text=".5" Value="30"></asp:ListItem>
                                                             <asp:ListItem Text="1" Value="60"></asp:ListItem>
                                                             <asp:ListItem Text="1.5" Value="90"></asp:ListItem>
                                                            <asp:ListItem Text="2" Value="120"></asp:ListItem>
                                                            <asp:ListItem Text="2.5" Value="150"></asp:ListItem>
                                                            <asp:ListItem Text="3" Value="180"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEffectiveFrom" Width="120px" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,StartTime %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEffectiveFrom" Width="120px" CssClass="cssLable" runat="server"
                                                            Text='<%# string.Format("{0:HH:mm}",Eval("PopStartTime"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPopStartTime" ValidationGroup="vg_Edit" CssClass="csstxtbox"
                                                            runat="server" Width="50px" Text='<%# String.Format("{0:HH:mm}", Eval("PopStartTime"))%>'></asp:TextBox>
                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPopStartTime"
                                                             Mask="99:99" MaskType="Time" UserTimeFormat="TwentyFourHour" ErrorTooltipEnabled="True"
                                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                            CultureTimePlaceholder="" Enabled="True"/>
                                                        <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                            ControlToValidate="txtPopStartTime" SetFocusOnError="True" >
                                                        </AjaxToolKit:MaskedEditValidator>
                                                        

                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtEffectiveFrom" Width="80px" CssClass="csstxtbox" runat="server"
                                                            MaxLength="15"></asp:TextBox>
                                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtEffectiveFrom"
                                                            Mask="99:99" MaskType="Time" UserTimeFormat="TwentyFourHour" ErrorTooltipEnabled="True"
                                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                            CultureTimePlaceholder="" Enabled="True" />
                                                        <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                            ControlToValidate="txtEffectiveFrom" SetFocusOnError="True" IsValidEmpty="False"
                                                            Display="Dynamic" EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ErrorMessage="MaskedEditExtender1">
                                                        </AjaxToolKit:MaskedEditValidator>
                                                        <asp:RequiredFieldValidator ID="txtEffectiveFromValidator" runat="server" ControlToValidate="txtEffectiveFrom"
                                                            ErrorMessage="*">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CausesValidation="true" CssClass="cssImgButton"
                                                            CommandName="Delete" ToolTip="<%$ Resources:Resource, Close %>" ValidationGroup='<%# Eval("AsmtCode").ToString()%>'
                                                            ImageUrl="../Images/TerminateEmp.gif" />
                                                      
                                                         <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" ValidationGroup='<%# Eval("AsmtCode").ToString()%>' />
                                                        <%--&nbsp;
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="true" CssClass="cssImgButton"
                                                            CommandName="Delete1" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />--%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                            ValidationGroup="vg_Edit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" CausesValidation="false" />
                                                    </EditItemTemplate>
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
