<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="BusinessRulesGeneric.aspx.cs" Inherits="Masters_BusinessRulesGeneric" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Assembly="DropCheck" Namespace="xMilk" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
                        <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="Tab1" Width="100%"
                            ActiveTabIndex="0" OnActiveTabChanged="Tab1_TabChanged" AutoPostBack="true">
                            <%--Step1 Define Hours Heads--%>
                            <AjaxToolKit:TabPanel Style="text-align: left" ID="TabHoursHead" runat="server" TabIndex="0" HeaderText="Step1">
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" CssClass="cssLabelHeader" Text="Define Hours Heads"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvHrsHeadGroup" runat="server" Width="100%" CssClass="GridViewStyle"
                                                    ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="gvHrsHeadGroup_RowCommand"
                                                    OnRowCancelingEdit="gvHrsHeadGroup_RowCancelingEdit" OnRowDeleting="gvHrsHeadGroup_RowDeleting"
                                                    OnRowEditing="gvHrsHeadGroup_RowEditing" PageSize="5" OnRowUpdated="gvHrsHeadGroup_RowUpdated"
                                                    OnRowUpdating="gvHrsHeadGroup_RowUpdating" OnPageIndexChanging="gvHrsHeadGroup_PageIndexChanging">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrHrsHeadSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHrsHeadGroupSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrHrsHeadGroupCode" CssClass="cssLabelHeader" runat="server"
                                                                    Text="HoursHeadGroup Code"> </asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkgvHrsHrsHeadGroupCode" CssClass="csslnkButton" runat="server"
                                                                    Text='<%# Bind("HoursHeadGroupCode") %>' OnClick="LinkgvHrsHrsHeadGroupCode_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TxtNewHrsHeadGroupCode" Width="200" CssClass="csstxtbox" runat="server"
                                                                    MaxLength="16"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="txtHrsHeadCodeValidator" runat="server" ControlToValidate="TxtNewHrsHeadGroupCode"
                                                                    ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrHrsHeadGroupDesc" CssClass="cssLabelHeader" runat="server"
                                                                    Text="HoursHeadGroup Desc"> </asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHrsHeadGroupDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadGroupDesc").ToString()%>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtHrsHeadGroupDesc" Width="200" CssClass="csstxtbox" runat="server"
                                                                    MaxLength="32" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadGroupDesc").ToString()%>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="txtHrsHeadDescValidator" runat="server" ControlToValidate="txtHrsHeadGroupDesc"
                                                                    ErrorMessage="cannot be blank!" ValidationGroup="vg_Edit">*</asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtNewHrsHeadGroupDesc" Width="200" CssClass="csstxtbox" runat="server"
                                                                    MaxLength="16"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="txtNewHrsHeadDescValidator" runat="server" ControlToValidate="txtNewHrsHeadGroupDesc"
                                                                    ErrorMessage="cannot be blank!" ValidationGroup="vg_Add">*</asp:RequiredFieldValidator>
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
                                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                    ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                            <ItemStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <FooterStyle Width="100px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="HdnHrsHeadGroupCode" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panelHrsHead" runat="server">
                                                    <asp:GridView ID="gvHrsHead" runat="server" Width="100%" CssClass="GridViewStyle"
                                                        ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="gvHrsHead_RowCommand"
                                                        OnRowCancelingEdit="gvHrsHead_RowCancelingEdit" OnRowDeleting="gvHrsHead_RowDeleting"
                                                        OnPageIndexChanging="gvHrsHead_PageIndexChanging" OnRowEditing="gvHrsHead_RowEditing"
                                                        OnRowUpdated="gvHrsHead_RowUpdated" OnRowUpdating="gvHrsHead_RowUpdating">
                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrHrsHeadSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvHrsHeadSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrHrsHeadCode" CssClass="cssLabelHeader" runat="server" Text="HoursHead Code"> </asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvHrsHeadCode" runat="server" CssClass="cssLabel" Text='<%# Bind("HoursHeadCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtNewHrsHeadCode" Width="160" CssClass="csstxtbox" runat="server"
                                                                        MaxLength="16"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="txtHrsHeadCodeValidator1" runat="server" ControlToValidate="TxtNewHrsHeadCode"
                                                                        ErrorMessage="Cannot be blank!" ValidationGroup="vg_Add1">*</asp:RequiredFieldValidator>
                                                                </FooterTemplate>
                                                                <HeaderStyle Width="180px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrHrsHeadDesc" CssClass="cssLabelHeader" runat="server" Text="HoursHead Desc"> </asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvHrsHeadDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadDesc").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtHrsHeadDesc" Width="180" CssClass="csstxtbox" runat="server"
                                                                        MaxLength="32" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadDesc").ToString()%>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="txtHrsHeadDescValidator1" runat="server" ControlToValidate="txtHrsHeadDesc"
                                                                        ErrorMessage="cannot be blank!" ValidationGroup="vg_Edit1">*</asp:RequiredFieldValidator>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtNewHrsHeadDesc" Width="180" CssClass="csstxtbox" runat="server"
                                                                        MaxLength="16"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="txtNewHrsHeadDescValidator1" runat="server" ControlToValidate="txtNewHrsHeadDesc"
                                                                        ErrorMessage="cannot be blank!" ValidationGroup="vg_Add1">*</asp:RequiredFieldValidator>
                                                                </FooterTemplate>
                                                                <HeaderStyle Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrOtTye" CssClass="cssLabelHeader" runat="server" Text="Is OT"> </asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkgvOtType" runat="server" CssClass="cssCheckBox" Enabled="false"
                                                                        Checked='<%# DataBinder.Eval(Container.DataItem, "IsOTType").ToString().Equals("True")   %>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="chkgvEditOtType" runat="server" CssClass="cssCheckBox" Checked='<%# DataBinder.Eval(Container.DataItem, "IsOTType").ToString().Equals("True")   %>' />
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="chkgvFtrOtType" runat="server" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <HeaderStyle Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrreplacePostelement" CssClass="cssLabelHeader" runat="server"
                                                                        Text="IsRPE" ToolTip="Is Replace Post Element"> </asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkgvreplacePostelement" runat="server" CssClass="cssCheckBox"
                                                                        Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "ReplacePostElement").ToString().Equals("True")   %>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="chkgvEditreplacePostelement" runat="server" CssClass="cssCheckBox"
                                                                        Checked='<%# DataBinder.Eval(Container.DataItem, "ReplacePostElement").ToString().Equals("True")   %>' />
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="chkgvFtrreplacePostelement" runat="server" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <HeaderStyle Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrIsPlannedOT" CssClass="cssLabelHeader" runat="server" Text="IsPlannedOT"> </asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkgvIsPlannedOT" runat="server" CssClass="cssCheckBox" Enabled="false"
                                                                        Checked='<%# DataBinder.Eval(Container.DataItem, "IsPlannedOT").ToString().Equals("True")   %>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="chkgvEditIsPlannedOT" runat="server" CssClass="cssCheckBox" Checked='<%# DataBinder.Eval(Container.DataItem, "IsPlannedOT").ToString().Equals("True")   %>' />
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="chkgvFtIsPlannedOT" runat="server" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <HeaderStyle Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrEqui" CssClass="cssLabelHeader" runat="server" Text="EquivalentHours(%)"> </asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvEqui" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EquivalentPercentage").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtEquivalentHrs" runat="server" CssClass="csstxtbox" MaxLength="3"
                                                                        Width="60"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="txtEquivalentHrsValidator" runat="server" ControlToValidate="txtEquivalentHrs"
                                                                        ErrorMessage="cannot be blank!" ValidationGroup="vg_Add1">*</asp:RequiredFieldValidator>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrInvHrsCategory" runat="server" CssClass="cssLabelHeader" Text="InvHrs Category"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInvHrsCategory" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem,"InvHoursHeadCode").ToString() %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlEditInvHrsCategory" runat="server" SelectedValue='<%#DataBinder.Eval(Container.DataItem,"InvHoursHeadCode").ToString()  %>'>
                                                                        <asp:ListItem Text="<%$Resources:Resource,Normal %>" Value="Normal"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,OT %>" Value="OT"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,Holiday %>" Value="Holiday"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,WeekOff %>" Value="WeekOff"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,NonBillable %>" Value="NonBillable"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlInvHrsCategory" runat="server">
                                                                        <asp:ListItem Text="<%$Resources:Resource,Normal %>" Value="Normal"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,OT %>" Value="OT"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,Holiday %>" Value="Holiday"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,WeekOff %>" Value="WeekOff"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,NonBillable %>" Value="NonBillable"></asp:ListItem>
                                                                    </asp:DropDownList>
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
                                                                        ValidationGroup="vg_Edit1" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                    <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                        ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                        ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add1" ImageUrl="../Images/AddNew.gif" />
                                                                    <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                        ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                </FooterTemplate>
                                                                <ItemStyle Width="100px" />
                                                                <HeaderStyle Width="100px" />
                                                                <FooterStyle Width="100px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Label EnableViewState="False" ID="lblStep1Error" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--Step2  Define Holiday Timings for Clients--%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabClientHoliday" TabIndex="3" runat="server" HeaderText="Step2">
                                <ContentTemplate>
                                    <asp:Label ID="lblHolidayHead" runat="server" CssClass="cssLabelHeader" Text="Define Holiday Timings for Clients"></asp:Label>
                                    <asp:Panel ID="HolidayTypePanel" runat="server">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:RadioButton ID="DateBasedHoliday" GroupName="HolidayRadio" runat="server" Checked="True"
                                                        Text="Date based Holiday (do not consider times)" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButton ID="TimeBasedHoliday" GroupName="HolidayRadio" runat="server" Text="Date + Time based Holiday" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:TextBox ID="txtHolidayFromTime" CssClass="csstxtbox" runat="server" Width="36px"
                                                        MaxLength="5"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtHolidayFromTime"
                                                        Mask="99:99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                    &nbsp;
                                                    <asp:TextBox ID="txtHolidayToTime" CssClass="csstxtbox" runat="server" Width="36px"
                                                        MaxLength="5"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtHolidayToTime"
                                                        Mask="99:99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: middle; text-align: center">
                                                    <br />
                                                    <asp:LinkButton ID="HolidayType" runat="server" Text="Submit" OnClick="HolidayType_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:GridView Width="100%" ID="gvHoliday" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                                        AutoGenerateColumns="False" OnPageIndexChanging="gvHoliday_PageIndexChanging"
                                        OnDataBound="gvHoliday_DataBound">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,HolidayCode %>">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkHolidayCode" CssClass="csslnkButton" OnClick="lnkHolidayCode_Click"
                                                        runat="server" Text='<%# Bind("HolidayDescCode") %>'></asp:LinkButton>
                                                    <asp:HiddenField ID="hfHolidayCode" runat="server" Value='<%# Bind("HolidayCode") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                                                <ItemStyle Width="300px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,HolidayDate %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHolidayDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy HH:mm}",Eval("HolidayDateFrom")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                                <ItemStyle Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,HolidayDate %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHolidayDateTo" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy HH:mm}",Eval("HolidayDateTo")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                                <ItemStyle Width="200px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                                CommandArgument="First" CommandName="Page" />
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                                CommandArgument="Prev" CommandName="Page" />
                                            <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                            <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                            <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                                CommandArgument="Next" CommandName="Page" />
                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                                CommandArgument="Last" CommandName="Page" />
                                        </PagerTemplate>
                                    </asp:GridView>
                                    <br />
                                    <asp:GridView ID="gvClientHoliday" runat="server" Width="100%" CssClass="GridViewStyle"
                                        AllowPaging="True" AutoGenerateColumns="False" OnRowEditing="gvClientHoliday_RowEditing"
                                        OnRowUpdating="gvClientHoliday_RowUpdating" OnRowCancelingEdit="gvClientHoliday_RowCancelingEdit"
                                        OnPageIndexChanging="gvClientHoliday_PageIndexChanging">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHdrgvClientHolidaySno" CssClass="cssLabelHeader" runat="server"
                                                        Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvClientHolidaySno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="40px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHdrgvClientHolidayClientCode" runat="server" CssClass="cssLabel"
                                                        Text="Client Code"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvClientHolidayClientCode" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "ClientCode")%>'></asp:Label>
                                                    <asp:HiddenField ID="hidgvClientHolidayDate" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "HolidayDate")%>' />
                                                    <asp:HiddenField ID="hidgvClientHolidayCode" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "HolidayCode")%>' />
                                                    <asp:HiddenField ID="hidgvClientHolidayAutoId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "AutoId")%>' />
                                                </ItemTemplate>
                                                <HeaderStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHdrgvClientHolidayClientName" runat="server" CssClass="cssLabel"
                                                        Text="Client Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvClientHolidayClientname" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "ClientName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="300px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHdrgvClientHolidayFromTime" runat="server" CssClass="cssLabel"
                                                        Text="From(Time)"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvClientHolidayFromTime" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "TimeFrom","{0:dd-MMM-yyyy HH:mm}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtgvClientHolidayFromTime" runat="server" CssClass="csstxtbox"
                                                        Style="width: 80px;" AutoPostBack="true" Text='<%#DataBinder.Eval(Container.DataItem, "TimeFrom","{0:dd-MMM-yyyy HH:mm}")%>'
                                                        Enabled="false"></asp:TextBox>
                                                    <asp:HyperLink ID="imggvClientHolidayFromTime" Style="vertical-align: middle;" runat="server"
                                                        ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtgvClientHolidayFromTime" PopupButtonID="imggvClientHolidayFromTime" />
                                                </EditItemTemplate>
                                                <HeaderStyle Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvHdrgvClientHolidayToTime" runat="server" CssClass="cssLabel"
                                                        Text="To(Time)"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvClientHolidayToTime" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "TimeTo","{0:dd-MMM-yyyy HH:mm}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtgvClientHolidayToTime" runat="server" CssClass="csstxtbox" Style="width: 80px;"
                                                        AutoPostBack="true" Text='<%#DataBinder.Eval(Container.DataItem, "TimeTo","{0:dd-MMM-yyyy HH:mm}")%>'
                                                        Enabled="false"></asp:TextBox>
                                                    <asp:HyperLink ID="ImggvClientHolidayToTime" Style="vertical-align: middle;" runat="server"
                                                        ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                </EditItemTemplate>
                                                <HeaderStyle Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                        ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                    <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                        ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                </EditItemTemplate>
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="lblMsgHolidayError" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--Step3  Define Rule --%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabBR" runat="server" TabIndex="4"
                                HeaderText="Step3">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblHrsDistributionRule" runat="server" CssClass="cssLabelHeader" Text="Define Rule"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSelectingBR" Text="Select Buisness Rule" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBR" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlBR_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBRCode" Text="Business Rule Code" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBusinessRule" runat="server" MaxLength="16" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBusinessRuleDesc" Text="Description" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td class="style1">
                                                <asp:TextBox ID="txtBusinessRuleDesc" Width="190px" runat="server" MaxLength="100"
                                                    CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <%--PaySum Code--%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSelectpaysumCode" Text="Select PaySum" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPaysumCode" runat="server" Width="200px" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlPaysumCode_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblpaySumCode" Text="PaySum Code" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaySumCode" runat="server" MaxLength="16" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPaySumcodeDesc" Text="Description" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td class="style1">
                                                <asp:TextBox ID="txtPaySumcodeDesc" Width="190px" runat="server" MaxLength="100"
                                                    CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--END PaySum --%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblEffectiveFrom" Text="EffectiveFrom" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtEffectiveFrom" runat="server" CssClass="csstxtboxSmall"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFrom" PopupButtonID="txtEffectiveFrom" Enabled="True">
                                                </AjaxToolKit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl" Text="<%$ Resources:Resource, Company %>" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList Width="400px" ID="ddlCompany" runat="server" CssClass="cssDropDown"
                                                    OnSelectedIndexChanged="ddlCompany_Changed">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDivision" Text="<%$ Resources:Resource, HrLocation %>" runat="server"
                                                    CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <cc1:DropCheck ID="ddlDivision" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_Changed">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBranch" Text="<%$ Resources:Resource, Location %>" runat="server"
                                                    CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <cc1:DropCheck ID="ddlBranch" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="400px" OnSelectedIndexChanged="ddlBranch_Changed">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClient" Text="<%$ Resources:Resource, ClientName %>" runat="server"
                                                    CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <cc1:DropCheck ID="ddlClient" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="400px">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" Text="<%$ Resources:Resource, CategoryDescription %>" runat="server"
                                                    CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <cc1:DropCheck ID="ddlEmpCategory" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="400px">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LabelJobClass" Text="<%$ Resources:Resource, JobClass %>" runat="server"
                                                    CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <cc1:DropCheck ID="ddlJobClass" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="400px">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LabelJobType" Text="<%$ Resources:Resource, JobType %>" runat="server"
                                                    CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <cc1:DropCheck ID="ddlJobType" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="400px">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label31" Text="<%$ Resources:Resource, Designation %>" runat="server"
                                                    CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <cc1:DropCheck ID="ddlDesignation" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="400px">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" Text="Contractual Days" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <cc1:DropCheck ID="ddlContractDaysType" CssClass="cssDropDown" runat="server" MaxDropDownHeight="200"
                                                    TransitionalMode="True" Width="400px">
                                                </cc1:DropCheck>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label26" Text="Is Default Rule" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkIsDefaultRule" runat="server" CssClass="cssCheckBox" />
                                            </td>
                                        </tr>
                                        <%-- Added new two value ConsiderBreakHrs    ConsiderUnconfirmedDuty--%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblConsiderBreakHrs" Text="<%$ Resources:Resource, ConsiderBreakHrs %>"
                                                    runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:CheckBox ID="chkConsiderBreakHrs" runat="server" CssClass="cssCheckBox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblConsiderUnconfirmedDuty" Text="<%$ Resources:Resource, ConsiderUnconfirmedDuty %>"
                                                    runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:CheckBox ID="chkConsiderUnconfirmedDuty" runat="server" CssClass="cssCheckBox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td colspan="3">
                                                <asp:Button ID="btnSave" Text="<%$ Resources:Resource, Save %>" runat="server" CssClass="cssButton"
                                                    OnClick="btnSave_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:Resource, Delete %>"
                                                    CssClass="cssButton" OnClick="btnClose_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblerror" runat="server" Width="250px" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--Step4 Define PayPeriod --%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPayPeriod" runat="server"
                                TabIndex="5" HeaderText="Step4">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="Label6" runat="server" CssClass="cssLabelHeader" Text="Define PayPeriod"></asp:Label>
                                                <asp:Label ID="lblBusinessRuleStep6" CssClass=" cssLabel" runat="server"></asp:Label>
                                                <asp:Label ID="lblpaySumPayperiodHeader" runat="server" CssClass="cssLabelHeader"
                                                    Text="PaySum Code"></asp:Label>
                                                <asp:Label ID="lblpaySumcodePayperiod" CssClass=" cssLabel" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="RadioMonthly" runat="server" GroupName="PayPeriod" Text="Monthly"
                                                    Width="150px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblStartDay_Monyhly" runat="server" Text="Start Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStartDay_Monthly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEndDay_Monthly" runat="server" Text="End Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEndDay_Monthly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:RadioButton ID="RadioFortnightly" runat="server" GroupName="PayPeriod" Text="Fortnightly"
                                                    Width="150px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="First Fortnight Start Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStartDay_FirstFortnightly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="First Fortnight End Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEndDay_FirstFortnightly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="Second Fortnight Start Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStartDay_SecondFortnightly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="Second Fortnight End Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEndDay_SecondFortnightly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:RadioButton ID="RadioWeekly" runat="server" GroupName="PayPeriod" Text="Weekly"
                                                    Width="150px" />
                                                <asp:RadioButton ID="RadioTwoWeeks" runat="server" GroupName="PayPeriod" Text="Two Weeks"
                                                    Width="150px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="Week Start Day"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStartDay_Weekly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text="Week End Day"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEndDay_Weekly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <br />
                                                <asp:Button ID="btnSavePeriod" Text="<%$ Resources:Resource, Save %>" runat="server"
                                                    CssClass="cssButton" OnClick="btnSavePeriod_Click" />
                                                &nbsp;
                                                <asp:Button ID="btnDeletePeriod" Text="<%$ Resources:Resource, Delete %>" runat="server"
                                                    CssClass="cssButton" OnClick="btnDeletePeriod_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblErrorMsgPayperiod" runat="server" Width="250px" CssClass="csslblErrMsg"></asp:Label>
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--Step5 Define Shifts --%>
                            <%-- ------------To handel Afternoon shift Manish 8-jan2013----------------%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabShift" runat="server" TabIndex="1"
                                HeaderText="Step5">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" CssClass="cssLabelHeader" Text="Define Shifts"></asp:Label>
                                                <asp:Label ID="lblBusinessRuleStep2" CssClass=" cssLabel" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblShiftMode" runat="server" Text="<%$ Resources:Resource,Mode %>" />
                                                <asp:DropDownList ID="ddlgvShiftMode" runat="server" CssClass="cssDropDown" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlgvShiftMode_Changed" Width="80px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvShift" runat="server" ShowFooter="True" Width="500px" CssClass="GridViewStyle"
                                                    AutoGenerateColumns="False" OnRowCommand="gvShift_RowCommand" OnRowDeleting="gvShift_RowDeleting"
                                                    OnRowEditing="gvShift_RowEditing" OnRowCancelingEdit="gvShift_RowCancelingEdit">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrShiftSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvShiftSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrShiftName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Shift %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvShiftName" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <%-- <asp:TextBox ID="txtgvShiftName" CssClass="csstxtbox" Width="90px" runat="server"
                                                        MaxLength="20"></asp:TextBox>
                                                                --%>
                                                                <asp:DropDownList ID="ddlgvShiftName" runat="server" CssClass="cssDropDown" AutoPostBack="True">
                                                                    <asp:ListItem Text="Day" Value="Day"></asp:ListItem>
                                                                    <asp:ListItem Text="After Noon" Value="AfterNoon"></asp:ListItem>
                                                                    <asp:ListItem Text="Night" Value="Night"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </FooterTemplate>
                                                            <ControlStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrShiftStartTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,StartTime %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvShiftStartTime" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftStartTime","{0:HH:mm}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtgvShiftStartTime" CssClass="csstxtbox" runat="server" Width="36px"
                                                                    MaxLength="5"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtgvShiftStartTime"
                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                    ErrorTooltipEnabled="True" />
                                                                <%--<AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtgvShiftStartTime" IsValidEmpty="false" Display="Dynamic"
                                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" />--%>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrShiftEndTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EndTime %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvShiftEndTime" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftEndTime","{0:HH:mm}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtgvShiftEndTime" CssClass="csstxtbox" runat="server" Width="36px"
                                                                    MaxLength="5"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtgvShiftEndTime"
                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                    ErrorTooltipEnabled="True" />
                                                                <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                                        ControlToValidate="txtgvShiftEndTime" IsValidEmpty="false" Display="Dynamic"
                                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" />--%>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrShiftMinimumMin" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Minimum Min"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvShiftMinimumMin" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftMinimumMinutes") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtgvShiftMinimumMin" CssClass="csstxtbox" runat="server" Width="40px"
                                                                    MaxLength="3"></asp:TextBox>
                                                                <%-- <asp:RequiredFieldValidator ID="rfvShiftMinimumMin" runat="server" ControlToValidate=txtgvShiftMinimumMin ErrorMessage="*"
                                                       ValidationGroup="vgAdd" />--%>
                                                                <asp:RangeValidator ID="rvMinimumMin" runat="server" ControlToValidate="txtgvShiftMinimumMin"
                                                                    ValidationGroup="vgAdd" MinimumValue="0" MaximumValue="999" ErrorMessage="*"></asp:RangeValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrIsDefault" CssClass="cssLabelHeader" runat="server" Text="Default Shift"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHdrIsDefault" CssClass="cssLable" runat="server" Text='<%# Bind("IsDefault") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:CheckBox ID="rdgvIsDefault" runat="server" Width="40px" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrGroup1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,StartRange %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHdrStartRange" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftStartRange","{0:HH:mm}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtgvShiftStartRange" CssClass="csstxtbox" runat="server" Width="36px"
                                                                    MaxLength="5"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="mskEdStartRange" runat="server" TargetControlID="txtgvShiftStartRange"
                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                    ErrorTooltipEnabled="True" />
                                                                <%--  <AjaxToolKit:MaskedEditValidator ID="mskValStartRange" runat="server" ControlExtender="mskEdStartRange"
                                                        ControlToValidate="txtgvShiftStartRange" IsValidEmpty="true" Display="Dynamic"
                                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" />--%>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdEndRange" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EndRange %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHdEndRange" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftEndRange","{0:HH:mm}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtgvShiftEndRange" CssClass="csstxtbox" runat="server" Width="36px"
                                                                    MaxLength="5"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="mskEdEndRange" runat="server" TargetControlID="txtgvShiftEndRange"
                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                    ErrorTooltipEnabled="True" />
                                                                <%-- <AjaxToolKit:MaskedEditValidator ID="maskValEndRange" runat="server" ControlExtender="mskEdEndRange"
                                                        ControlToValidate="txtgvShiftEndRange" IsValidEmpty="true" Display="Dynamic" 
                                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" />--%>
                                                                <%-- <asp:TextBox ID="txtgvGroup2" CssClass="csstxtbox" runat="server" Width="40px" />--%>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrShiftAction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Action %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                    ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                <%--<asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />--%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="AddNew"
                                                                    ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:Label ID="LabelErrorMsgShift" runat="server" Width="250px" CssClass="csslblErrMsg"></asp:Label>
                                        </tr>
                                        </td>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--Step6 Set Weekly Off Timings for Clients --%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabClientWeekOff" TabIndex="2"
                                runat="server" HeaderText="Step6">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" CssClass="cssLabelHeader" Text="Set Weekly Off Timings for Clients"></asp:Label>
                                                <asp:Label ID="lblBusinessRuleStepCW" CssClass=" cssLabel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblWeeklyOff" runat="server" Text="<%$ Resources:Resource,WeeklyOff %>" />
                                                <asp:DropDownList ID="ddlWeeklyOff" runat="server" CssClass="cssDropDown" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlWeeklyOff_Changed">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvClientWeeklyOff" runat="server" Width="500px" CssClass="GridViewStyle"
                                                    ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="gvClientWeeklyOff_RowCommand"
                                                    OnRowEditing="gvClientWeeklyOff_RowEditing" OnRowCancelingEdit="gvClientWeeklyOff_RowCancelingEdit"
                                                    OnRowUpdating="gvClientWeeklyOff_RowUpdating" OnRowDeleting="gvClientWeeklyOff_RowDeleting">
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="gvClientWeeklyOffHdrID" runat="server" CssClass="cssLabelHeader" Text="ID"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="gvClientWeeklyOffID" runat="server" CssClass="csslnkButton" Text='<%# Bind("WeeklyOffID") %>'
                                                                    OnClick="linkBtnViewClient_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="gvClientWeeklyOffHdrFrom" runat="server" CssClass="cssLabelHeader"
                                                                    Text="From Time"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="gvClientWeeklyOffLblDayFrom" runat="server" CssClass="cssLabel" Text='<%# Bind("DayFrom") %>'></asp:Label>
                                                                <asp:Label ID="gvClientWeeklyOffLblTimeFrom" runat="server" CssClass="cssLabel" Text='<%# Bind("TimeFrom","{0:HH:mm}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="gvClientWeeklyOffTxtDayFrom" Width="60px" runat="server" CssClass=" csstxtbox"
                                                                    Text='<%# Bind("DayFrom") %>'></asp:TextBox>&nbsp;
                                                                <asp:TextBox ID="gvClientWeeklyOffTxtTimeFrom" Width="36px" runat="server" CssClass="csstxtbox"
                                                                    Text='<%# Bind("TimeFrom","{0:HH:mm}") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlDayFrom" runat="server" Width="60px" CssClass="cssDropDown">
                                                                    <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                                                                    <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                                                                    <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                                                                    <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                                                                    <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtClientWeeklyOffFromTime" CssClass="csstxtbox" runat="server"
                                                                    Width="36px" MaxLength="5"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtClientWeeklyOffFromTime"
                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                    ErrorTooltipEnabled="True" />
                                                                <%-- <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtClientWeeklyOffFromTime" IsValidEmpty="False" Display="Dynamic"
                                                                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="vgAddClientWeeklyOff" />--%>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="gvClientWeeklyOffHdrTo" runat="server" CssClass="cssLabelHeader" Text="To Time"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="gvClientWeeklyOffDayTo" runat="server" CssClass="cssLabel" Text='<%# Bind("DayTo") %>'></asp:Label>
                                                                <asp:Label ID="gvClientWeeklyOffTimeTo" runat="server" CssClass="cssLabel" Text='<%# Bind("TimeTo","{0:HH:mm}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="gvClientWeeklyOffTxtDayTo" Width="60px" runat="server" CssClass=" csstxtbox"
                                                                    Text='<%# Bind("DayTo") %>'></asp:TextBox>&nbsp;
                                                                <asp:TextBox ID="gvClientWeeklyOffTxtTimeTo" Width="36px" runat="server" CssClass="csstxtbox"
                                                                    Text='<%# Bind("TimeTo","{0:HH:mm}") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlDayTo" runat="server" Width="60px" CssClass="cssDropDown">
                                                                    <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                                                                    <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                                                                    <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                                                                    <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                                                                    <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtClientWeeklyOffToTime" CssClass="csstxtbox" runat="server" Width="36px"
                                                                    MaxLength="5"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtClientWeeklyOffToTime"
                                                                    Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                    MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                                    ErrorTooltipEnabled="True" />
                                                                <%--<AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                                                    ControlToValidate="txtClientWeeklyOffToTime" IsValidEmpty="False" Display="Dynamic"
                                                                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="vgAddClientWeeklyOff" />--%>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="gvClientWeeklyOffBasedOn" runat="server" CssClass="cssLabelHeader"
                                                                    Text="Actual/Schedule"></asp:Label>
                                                            </HeaderTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlWeekOfBasedOn" runat="server" Width="100px" CssClass="cssDropDown">
                                                                    <asp:ListItem Text="Schedule" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Actual" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
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
                                                                    ValidationGroup="vgAddClientWeekOff" ToolTip="<%$ Resources:Resource, Update %>"
                                                                    ImageUrl="../Images/Save.gif" />
                                                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                    ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                    ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgAddClientWeekOff"
                                                                    ImageUrl="../Images/AddNew.gif" />
                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                            <ItemStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <FooterStyle Width="100px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:HiddenField ID="HdnCompanyCode" runat="server" />
                                                <asp:HiddenField ID="HdnBrCode" runat="server" />
                                                <asp:HiddenField ID="hdnPaySumCode" runat="server" />
                                                <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                <asp:GridView ID="gvClientWhTime" runat="server" Width="900px" CssClass="GridViewStyle"
                                                    AllowPaging="True" AutoGenerateColumns="False">
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrClientWHSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvClientWHSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="40px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHdrgvClientWhTimeClientCode" runat="server" CssClass="cssLabel"
                                                                    Text="Client Code"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkgvClientWhTimeClientCode" runat="server" CssClass="csslnkButton"
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "ClientCode")%>' OnClick="linkgvClientWhTimeClientCode_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHdrgvClientWhTimeClientName" runat="server" CssClass="cssLabel"
                                                                    Text="Client Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvClientWhTimeClientname" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "ClientName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="300px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHdrgvClientWhTimeFromDay" runat="server" CssClass="cssLabel" Text="From(day)"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvClientWhTimeFromDay" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "DayFrom")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="70px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHdrgvClientWhTimeFromTime" runat="server" CssClass="cssLabel" Text="From(Time)"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvClientWhTimeFromTime" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "TimeFrom")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrClientWhTimeToDay" runat="server" CssClass="cssLabel" Text="To(Day)"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvClientWhTimeToDay" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "DayTo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="70px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrClientWhTimeToTime" runat="server" CssClass="cssLabel" Text="To(Time)"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvClientWhTimeToTime" runat="server" CssClass="cssLabel" Text='<%#DataBinder.Eval(Container.DataItem, "TimeTo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField></asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:Panel ID="panSetWhTime" runat="server" Visible="False">
                                                    <table>
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:Label ID="Label5" runat="server" CssClass="cssLabelHeader" Text="Client "></asp:Label>
                                                                <asp:Label ID="lblClientCode" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100px">
                                                                <asp:Label ID="lblEditClientWHTime" runat="server" CssClass="cssLabel" Text="Set Timings"></asp:Label>
                                                            </td>
                                                            <td width="60px">
                                                                <asp:DropDownList ID="ddlEditDayFrom" runat="server" Width="60px" CssClass="cssDropDown">
                                                                    <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                                                                    <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                                                                    <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                                                                    <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                                                                    <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="60px">
                                                                <asp:TextBox ID="txtEditTimeFrom" runat="server" CssClass="csstxtbox" Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td width="40px" align="center">
                                                                To
                                                            </td>
                                                            <td width="60px">
                                                                <asp:DropDownList ID="ddlEditDayTo" runat="server" Width="60px" CssClass="cssDropDown">
                                                                    <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                                                                    <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                                                                    <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                                                                    <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                                                                    <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="60px">
                                                                <asp:TextBox ID="txtEditTimeTo" runat="server" CssClass="csstxtbox" Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnClientWHTimeSave" runat="server" CssClass="cssButton" Text="Save"
                                                                    OnClick="btnClientWHTimeSave_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:Label ID="lblErrorMsg1" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--Step7 Distribute Duty Hours --%>
                            <AjaxToolKit:TabPanel Style="text-align: left; overflow: auto" ID="TabHoursDistribution"
                                runat="server" TabIndex="6" HeaderText="Step7">
                                <ContentTemplate>
                                    <asp:Label ID="Label23" runat="server" CssClass="cssLabelHeader" Text="Distribute Duty Hours"></asp:Label>
                                    <asp:Label ID="lblBusinessRuleStep7" CssClass=" cssLabel" runat="server"></asp:Label>
                                    <table width="700px">
                                        <tr>
                                            <td width="180px">
                                                <asp:Label ID="Label15" runat="server" CssClass="cssLabel" Text="Select Hours Type"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistributionRule" runat="server" CssClass="cssDropDown"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlDistributionRule_SelectedIndexChanged"
                                                    Width="200px">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                    Width="160px" Visible="false">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" CssClass="cssLabel" Text="Shift"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlShift" runat="server" CssClass="cssDropDown" AutoPostBack="True"
                                                    Width="200px" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label27" runat="server" CssClass="cssLabel" Text="OverTime based On"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlScheduleBasedOTPeriod" Width="80px" CssClass="cssDropDown"
                                                    AutoPostBack="True" runat="server" Visible="false">
                                                    <asp:ListItem Text="Daily" Value="Daily" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlScheduleBasedOT" Width="120px" OnSelectedIndexChanged="ddlScheduleBasedOT_SelectedIndexChanged"
                                                    CssClass="cssDropDown" AutoPostBack="True" runat="server">
                                                    <asp:ListItem Text="Attendance" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Schedule Hours" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Contract" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="PostWise" Value="4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label28" runat="server" CssClass="cssLabel" Text="Include Zero Schedule Hours"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkZeroScheduleHrs" runat="server" CssClass="cssCheckBox" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="width: 100%; overflow: auto">
                                        <asp:GridView ID="gvHoursDistribution" runat="server" ShowFooter="True" Width="100%"
                                            CssClass="GridViewStyle" AutoGenerateColumns="False" OnRowCommand="gvHoursDistribution_RowCommand"
                                            OnDataBound="gvHoursDistribution_DataBound" OnRowDeleting="gvHoursDistribution_RowDeleting">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblDays" CssClass="cssLabel" runat="server" Text="Days"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDays" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WeekDay").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <table cellspacing="0" style="width: 200px">
                                                            <tr>
                                                                <td style="vertical-align: top">
                                                                    <asp:CheckBox ID="chkSun" runat="server" Text="Sunday(1)" Style="font-size: xx-small"
                                                                        Checked="true" />
                                                                    <asp:CheckBox ID="ChkMon" runat="server" Text="Monday(2)" Style="font-size: xx-small"
                                                                        Checked="true" />
                                                                    <asp:CheckBox ID="ChkTue" runat="server" Text="Tuesday(3)" Style="font-size: xx-small"
                                                                        Checked="true" />
                                                                    <asp:CheckBox ID="ChkWed" runat="server" Text="Wednesday(4)" Style="font-size: xx-small"
                                                                        Checked="true" />
                                                                </td>
                                                                <td style="vertical-align: top">
                                                                    <asp:CheckBox ID="ChkThu" runat="server" Text="Thursday(5)" Style="font-size: xx-small"
                                                                        Checked="true" />
                                                                    <asp:CheckBox ID="ChkFri" runat="server" Text="Friday(6)" Style="font-size: xx-small"
                                                                        Checked="true" />
                                                                    <asp:CheckBox ID="ChkSat" runat="server" Text="Saturday(7)" Style="font-size: xx-small"
                                                                        Checked="true" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblDays" CssClass="cssLabel" runat="server" Text="DutyType"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDutyType" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DutyType").ToString()%>'></asp:Label>
                                                        <asp:HiddenField ID="HdnRowGuid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Guid").ToString()%>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBoxList ID="chkDutyType" runat="server" Style="font-size: smaller" RepeatDirection="Horizontal"
                                                            RepeatLayout="Table" RepeatColumns="2">
                                                        </asp:CheckBoxList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <%--  <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblDays" CssClass="cssLabel" runat="server" Text="ScheduleOverTimePeriod"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblScheduleoverTimeperiod" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OverTimeBasedOnPeriod").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Repeater ID="reptHrsHead" runat="server">
                                                            <ItemTemplate>
                                                                <table style="width: 650px; border: 0px; margin: 0px">
                                                                    <tr>
                                                                        <td width="160px">
                                                                            <asp:Label ID="lblHrsHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadCode").ToString()%>'> </asp:Label>
                                                                        </td>
                                                                        <td width="60px" align="right">
                                                                            <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="between"> </asp:Label>
                                                                        </td>
                                                                        <td width="90px" align="right">
                                                                            <asp:Label ID="lblHrsFromWithSchedule1" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PreHoursFrom").ToString()%>'> </asp:Label>
                                                                            <%--Visible='<%# DataBinder.Eval(Container.DataItem, "HoursFromWithSchedule")%>'--%>
                                                                        </td>
                                                                        <td width="60px">
                                                                            <asp:Label ID="lblHrsHeadFrom" runat="server" Width="50px" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "HoursFrom").ToString()%>'></asp:Label>
                                                                        </td>
                                                                        <td width="40px" align="center">
                                                                            <asp:Label ID="lblAnd" runat="server" Text="&&"></asp:Label>
                                                                        </td>
                                                                        <td width="90px" align="right">
                                                                            <asp:Label ID="lblHrsToWithSchedule1" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PreHoursTo").ToString()%>'> </asp:Label>
                                                                            <%--Text="ScheduleHrs + ">--%>
                                                                            <%-- Visible='<%# DataBinder.Eval(Container.DataItem, "HoursToWithSchedule")%>'--%>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblHrsHeadTo" runat="server" Width="50px" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "HoursTo").ToString()%>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Repeater ID="reptHrsHeadFooter" runat="server">
                                                            <ItemTemplate>
                                                                <table width="650px" border="0">
                                                                    <tr>
                                                                        <td width="160px">
                                                                            <asp:Label ID="lblHrsHeadCodeFooter" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadCode").ToString()%>'> </asp:Label>
                                                                        </td>
                                                                        <td width="60px" align="left">
                                                                            <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="between"> </asp:Label>
                                                                        </td>
                                                                        <td width="90px" align="left">
                                                                            <%-- <asp:Label ID="lblHrsFromWithSchedule" CssClass="cssLable" Visible="false" runat="server"
                                                                                Text="ScheduleHrs + "> </asp:Label>--%>
                                                                            <%-- //Manish 14-jan-2014 dropdown to --%>
                                                                            <asp:DropDownList ID="lblHrsFromWithSchedule" Visible="false" runat="server" CssClass="cssDropDown">
                                                                                <asp:ListItem Text="ScheduleHrs +" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <%-- //To handel post OT factor.--%>
                                                                            <asp:DropDownList ID="ddldutyOTFFrom" Visible="false" runat="server" CssClass="cssDropDown">
                                                                                <asp:ListItem Text="Duty-POTF" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <%--  //End //Manish 14-jan-2014 dropdown to --%>
                                                                        </td>
                                                                        <td width="60px">
                                                                            <asp:TextBox ID="txtHrsHeadFromFooter" runat="server" Width="50px" CssClass="csstxtboxSmall"
                                                                                Text='<%# DataBinder.Eval(Container.DataItem, "HoursFrom").ToString()%>'></asp:TextBox>
                                                                            <asp:DropDownList ID="ddlOverTimeFrom" Visible="false" CssClass="cssDropDown" runat="server">
                                                                                <asp:ListItem Text="Duty Start" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="Contract Start" Value="2"></asp:ListItem>
                                                                                <asp:ListItem Text="Duty End" Value="3"></asp:ListItem>
                                                                                <asp:ListItem Text="Contract End" Value="4"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="40px" align="center">
                                                                            <asp:Label ID="lblAnd" runat="server" Text="&&"></asp:Label>
                                                                        </td>
                                                                        <td width="90px" align="left">
                                                                            <%--<asp:Label ID="lblHrsToWithSchedule" CssClass="cssLable" Visible="false" runat="server"
                                                                                Text="ScheduleHrs + "> </asp:Label>--%>
                                                                            <asp:DropDownList ID="lblHrsToWithSchedule" Visible="false" runat="server" CssClass="cssDropDown">
                                                                                <asp:ListItem Text="ScheduleHrs +" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <%-- //To handel post OT factor.--%>
                                                                            <asp:DropDownList ID="ddldutyOTFTo" Visible="false" runat="server" CssClass="cssDropDown">
                                                                                <asp:ListItem Text="Duty-POTF" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtHrsHeadToFooter" runat="server" Width="50px" CssClass="csstxtboxSmall"
                                                                                Text='<%# DataBinder.Eval(Container.DataItem, "HoursTo").ToString()%>'></asp:TextBox>
                                                                            <asp:DropDownList ID="ddlOverTimeTo" Visible="false" CssClass="cssDropDown" runat="server">
                                                                                <asp:ListItem Text="Duty Start" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="Contract Start" Value="2"></asp:ListItem>
                                                                                <asp:ListItem Text="Duty End" Value="3"></asp:ListItem>
                                                                                <asp:ListItem Text="Contract End" Value="4"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHoursDistributionAction" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,Action %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                        <%--<asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />--%>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="AddNew"
                                                            ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <asp:Label ID="lblErrorMsgHrsDistribution" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    <br />
                                    <a id="a" runat="server" class="cssLabel" style="cursor: pointer"><b>Not Working Hrs</b></a>
                                    <div style="width: 100%; overflow: auto">
                                        <asp:GridView ID="gvNWHoursDistribution" runat="server" ShowFooter="True" Width="600px"
                                            AllowPaging="true" PageSize="5" CssClass="GridViewStyle" AutoGenerateColumns="False"
                                            OnRowCommand="gvNWHoursDistribution_RowCommand" OnDataBound="gvNWHoursDistribution_DataBound"
                                            OnRowDeleting="gvNWHoursDistribution_RowDeleting" OnPageIndexChanging="gvNWHoursDistribution_PageIndexChanging">
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        s
                                                        <asp:Repeater ID="reptNWHrsHead" runat="server">
                                                            <ItemTemplate>
                                                                <table style="width: 400px; border: 0px; margin: 0px">
                                                                    <tr>
                                                                        <td width="160px">
                                                                            <asp:Label ID="lblHrsHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadCode").ToString()%>'> </asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNWHrsHead" runat="server" Width="50px" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "NWHours").ToString()%>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Repeater ID="reptNWHrsHeadFooter" runat="server">
                                                            <ItemTemplate>
                                                                <table width="400px" border="0">
                                                                    <tr>
                                                                        <td width="160px">
                                                                            <asp:Label ID="lblHrsHeadCodeFooter" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursHeadCode").ToString()%>'> </asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtNWHrsHeadFooter" runat="server" Width="50px" CssClass="csstxtboxSmall"
                                                                                Text='<%# DataBinder.Eval(Container.DataItem, "NWHours").ToString()%>'></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkCondition" runat="server" CssClass="csslnkButton" Text="With Condition"></asp:LinkButton>
                                                        <asp:HiddenField ID="RowGUID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GUID").ToString()%>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHoursDistributionAction" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,Action %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="AddNew"
                                                            ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%-- Step8 ------------------Added New Tab to handel  Elelement Replacement -------------------------------------%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabElementReplace" runat="server"
                                TabIndex="11" HeaderText="Step8">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDisAdjHeader" runat="server" CssClass="cssLabelHeader" Text="Running Total Adjustment"></asp:Label>
                                                <asp:Label ID="lblBusinessRuleStepDisAdj" runat="server" CssClass="cssLabelHeader"
                                                    Text="Running Total Adjustment"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td>
                                                <asp:Label ID="lblDisAdjPeriod" runat="server" Text="Period"></asp:Label>
                                                <asp:DropDownList ID="ddlDisAdjPeriod" runat="server">
                                                    <asp:ListItem Value="Cyclic" Text="Cyclic" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblDisAdjMode" runat="server" Text="Mode"></asp:Label>
                                                <asp:DropDownList ID="ddlDisAdjMode" runat="server">
                                                    <asp:ListItem Value="RunningTotal" Text="Running Total" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvHrsheadDisAdj" runat="server" Width="800px" CssClass="GridViewStyle"
                                                    ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="gvHrsheadDisAdj_RowCommand"
                                                    OnRowDeleting="gvHrsheadDisAdj_RowDeleting" OnPageIndexChanging="gvHrsheadDisAdj_PageIndexChanging">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField >
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrelementsDisAdj" CssClass="cssLabelHeader" runat="server" Text="Element(s) Running Total "> </asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvElementsDisAdj" runat="server" style="table-layout:fixed; width:50%; word-wrap:break-word"  CssClass="cssLabel"
                                                                    Text='<%# Bind("HoursHeadCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <telerik:RadComboBox ID="ddlgvFtrHrsAdjElements" runat="server" MaxHeight="350px"
                                                                    Width="190" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" AutoPostBack="true"
                                                                    AllowCustomText="true" Filter="StartsWith">
                                                                </telerik:RadComboBox>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="200px" />
                                                            <ItemStyle Width="200px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHdrDisAdjoperator" CssClass="cssLabelHeader" runat="server" Text="Is Greater"
                                                                    ToolTip="Is Greater"> </asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDisAdjoperator" runat="server" CssClass="cssLabel" Text=">" />
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFtrDisAdjoperator" runat="server" CssClass="cssLabel" Text=">" />
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrHrsAdj" CssClass="cssLabelHeader" runat="server" Text="Value"> </asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHrsAdj" CssClass="cssLable" runat="server" Text='<%#Bind("HoursHeadValue")%>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtgvFtrHrsAdj" runat="server" MaxLength="5" Width="50"></asp:TextBox>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="ajkTxtHrsAdj" runat="server" FilterType="Numbers"
                                                                    TargetControlID="txtgvFtrHrsAdj">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="txtFtrHrsAdj" runat="server" ControlToValidate="txtgvFtrHrsAdj"
                                                                    ErrorMessage="cannot be blank!" ValidationGroup="disAdj">*</asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrElementTobeReplaced" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Element" ToolTip="Element To be Replaced"> </asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvElementTobeReplaced" runat="server" CssClass="cssLabel" Text='<%# Bind("FromHoursHead") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlgvFtrElementTobeReplaced" runat="server">
                                                                </asp:DropDownList>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrElementReplace" CssClass="cssLabelHeader" runat="server" Text="Replaced by"> </asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvElementReplace" runat="server" CssClass="cssLabel" Text="Replaced by"> </asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblgvFtrElementReplace" runat="server" Text="Replaced by" CssClass="cssLabel" />
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrElementReplacedFrom" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Element" ToolTip="Element Replaced From"> </asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvElementReplacedFrom" runat="server" CssClass="cssLabel" Text='<%# Bind("ToHoursHead") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlgvFtrElementReplacedFrom" runat="server">
                                                                </asp:DropDownList>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                    ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                <%--  <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />--%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="ImgbtnAddElement" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                    ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="disAdj" ImageUrl="../Images/AddNew.gif" />
                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                            <ItemStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <FooterStyle Width="100px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblErrorMsgDisAdj" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--  ------------------ ENd Added New Tab to handel  Elelement Replacement -------------------------------------%>
                            <%--Step9 Weekly Hours Adujstment --%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPanel1" runat="server" TabIndex="7"
                                HeaderText="Step9">
                                <ContentTemplate>
                                    <asp:Label ID="Label13" runat="server" CssClass="cssLabelHeader" Text="Weekly Hours Adujstment"></asp:Label>
                                    <asp:Label ID="lblBusinessRuleStep8" runat="server" CssClass="cssLabel" Text=""></asp:Label>
                                    <asp:Panel ID="panFormulaInputValues" runat="server" Font-Bold="true" Font-Size="Smaller"
                                        ForeColor="Gray" GroupingText="Formula Input Values">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWeekHours" runat="server" CssClass="cssLabel" Text="Weekly Hours"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" CssClass="cssLabel" Text="Weekly Days"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" CssClass="cssLabel" Text="Operators"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" CssClass="cssLabel" Text="logicalOps"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" CssClass="cssLabel" Text="Numbers"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label25" runat="server" CssClass="cssLabel" Text="Formula"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ListBox AutoPostBack="false" ID="lbWeeklyHoursHead" runat="server" Font-Size="X-Small"
                                                        SelectionMode="Single" Rows="12" Width="170" ondblClick="javascript:furmulaBuilder(this,'WeeklyHours');">
                                                    </asp:ListBox>
                                                </td>
                                                <td>
                                                    <asp:ListBox AutoPostBack="false" ID="lbWeeklydaysHead" runat="server" Font-Size="X-Small"
                                                        SelectionMode="Single" Rows="12" Width="170" ondblClick="javascript:furmulaBuilder(this,'WeeklyDays');">
                                                    </asp:ListBox>
                                                </td>
                                                <td>
                                                    <asp:ListBox AutoPostBack="false" ID="lbOperators" runat="server" Font-Size="X-Small"
                                                        SelectionMode="Single" Rows="12" Width="50" ondblClick="javascript:furmulaBuilder(this,'Operator');">
                                                        <asp:ListItem Text="+" Value="+"></asp:ListItem>
                                                        <asp:ListItem Text="-" Value="-"></asp:ListItem>
                                                        <asp:ListItem Text="*" Value="*"></asp:ListItem>
                                                        <asp:ListItem Text="/" Value="/"></asp:ListItem>
                                                        <asp:ListItem Text="(" Value="("></asp:ListItem>
                                                        <asp:ListItem Text=")" Value=")"></asp:ListItem>
                                                    </asp:ListBox>
                                                </td>
                                                <td>
                                                    <asp:ListBox AutoPostBack="false" ID="lblConditionalOperators" runat="server" Font-Size="X-Small"
                                                        SelectionMode="Single" Rows="12" Width="50" ondblClick="javascript:furmulaBuilder(this,'ConditionalOperator');">
                                                        <asp:ListItem Text="IF" Value=" IF "></asp:ListItem>
                                                        <asp:ListItem Text="THEN" Value=" THEN "></asp:ListItem>
                                                        <asp:ListItem Text="ELSE" Value=" ELSE "></asp:ListItem>
                                                        <asp:ListItem Text="END" Value=" END "></asp:ListItem>
                                                        <asp:ListItem Text=">" Value=" > "></asp:ListItem>
                                                        <asp:ListItem Text="&gt;=" Value="&gt;="></asp:ListItem>
                                                        <asp:ListItem Text="<" Value=" < "></asp:ListItem>
                                                        <asp:ListItem Text="&lt;=" Value="&lt;="></asp:ListItem>
                                                        <asp:ListItem Text="!=" Value="!="></asp:ListItem>
                                                        <asp:ListItem Text="OR" Value=" OR "></asp:ListItem>
                                                        <asp:ListItem Text="AND" Value=" AND "></asp:ListItem>
                                                    </asp:ListBox>
                                                </td>
                                                <td>
                                                    <asp:ListBox AutoPostBack="false" ID="ListBox1" runat="server" Font-Size="X-Small"
                                                        SelectionMode="Single" Rows="12" Width="50" ondblClick="javascript:furmulaBuilder(this,'Constant');">
                                                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    </asp:ListBox>
                                                </td>
                                                <td>
                                                    <asp:ListBox AutoPostBack="false" ID="lbFormula" runat="server" Font-Size="X-Small"
                                                        SelectionMode="Single" Rows="12" Width="100" ondblClick="javascript:furmulaBuilder(this,'Formula');">
                                                    </asp:ListBox>
                                                </td>
                                                <td style="vertical-align: top">
                                                    <input type="button" value="Show Formula" class="cssButton" onclick="javascript:showFormula();" />
                                                    <br />
                                                    <asp:Button ID="btnDeleteFormula" runat="server" CssClass="cssButton" Text="Delete Formula"
                                                        OnClick="btnDeleteFormula_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PanFormulaExpression" runat="server" Font-Bold="true" ForeColor="Gray"
                                        GroupingText="Formula Expression">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFormulaExp" runat="server" CssClass="cssLabel" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ListBox AutoPostBack="false" ID="lbFormulaExp" runat="server" CssClass="" SelectionMode="Single"
                                                        Rows="10" Width="200" ondblClick="javascript:removeItem(this);"></asp:ListBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFormulaname" runat="server" CssClass="cssLabel" Text="Formula Name"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="txtFormulaName" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="btnSaveFormula" runat="server" CssClass="cssButton" Text="Save Formula"
                                                        OnClientClick="javascript:furmulaBuilderExp();" OnClick="btnSaveFormula_Click" />
                                                    <br />
                                                    <asp:CheckBox ID="chkIsPartOfPaysum" runat="server" CssClass="cssCheckBox" Text="Is it a part of paysum" />
                                                    <br />
                                                    <asp:Label ID="lblErrorMsgFormulaBuilder" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                    <asp:HiddenField ID="hid_FormulaExp" runat="server" />
                                                    <asp:HiddenField ID="hid_FormulaExpType" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--Step10 Define Paysum Format  --%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPaysumFormat" runat="server"
                                TabIndex="8" HeaderText="Step10">
                                <ContentTemplate>
                                    <asp:Label ID="Label24" runat="server" CssClass="cssLabelHeader" Text="Define Paysum Format"></asp:Label>
                                    <div class="squareboxcontent">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblpaySumcodeFormat" runat="server" CssClass="cssLabelHeader" Text="Paysum Code"></asp:Label>
                                                    <asp:DropDownList ID="ddlPaySumCodeFormat" runat="server" Width="200px" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlPaySumCodeFormat_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvPaysumHead" runat="server" ShowFooter="True" Width="250px" CssClass="GridViewStyle"
                                                        AutoGenerateColumns="False" OnRowCommand="gvPaysumHead_RowCommand" OnRowDeleting="gvPaysumHead_RowDeleting"
                                                        OnRowEditing="gvPaysumHead_RowEditing" OnRowCancelingEdit="gvPaysumHead_RowCancelingEdit"
                                                        OnRowUpdating="gvPaysumHead_RowUpdating">
                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrPaysumHead" runat="server" CssClass="cssLabelHeader" Text="PaysumHead"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvPaysumHead" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "paysumHead").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtgvPaysumHead" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "paysumHead").ToString()%>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtgvPaysumHead" ValidationGroup="vgAdd" runat="server" CssClass="csstxtbox"
                                                                        Width="160px"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="reqPaysumHead" runat="server" ControlToValidate="txtgvPaysumHead"
                                                            ValidationGroup="vgAdd"  ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHoursDistributionAction" CssClass="cssLabelHeader" runat="server"
                                                                        Text="<%$ Resources:Resource,Action %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                        ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                    <%--<asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />--%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="AddNew"
                                                                        ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                    <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                        ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                                <td valign="top">
                                                    <table width="100%" cellpadding="0" cellspacing="2">
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblPaysumElements" CssClass=" cssLabelHeader" Text="Select Paysum Elements"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBoxList ID="chkPaysumElements" runat="server" CssClass="cssCheckBox" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="chkPaysumElements_SelectedIndexChanged" RepeatColumns="2"
                                                                    Width="100%">
                                                                    <asp:ListItem Text="Employee Number" Value="EmployeeNumber"></asp:ListItem>
                                                                    <asp:ListItem Text="Employee Name" Value="EmployeeName"></asp:ListItem>
                                                                    <asp:ListItem Text="Employee DesignationCode" Value="DesignationCode"></asp:ListItem>
                                                                    <asp:ListItem Text="Employee DesignationDesc" Value="DesignationDesc"></asp:ListItem>
                                                                    <asp:ListItem Text="LocationCode" Value="LocationCode"></asp:ListItem>
                                                                    <asp:ListItem Text="HR LocationCode" Value="HrLocationCode"></asp:ListItem>
                                                                    <asp:ListItem Text="ClientCode" Value="ClientCode"></asp:ListItem>
                                                                    <asp:ListItem Text="ClientName" Value="ClientName"></asp:ListItem>
                                                                    <asp:ListItem Text="AssignmentCode" Value="AsmtCode"></asp:ListItem>
                                                                    <asp:ListItem Text="AssignmentAddress" Value="AsmtAddress"></asp:ListItem>
                                                                    <asp:ListItem Text="AssignmentId" Value="AsmtId"></asp:ListItem>
                                                                    <asp:ListItem Text="PostCode" Value="PostCode"></asp:ListItem>
                                                                    <asp:ListItem Text="PostDesc" Value="PostDesc"></asp:ListItem>
                                                                    <asp:ListItem Text="WorkingDaysCount" Value="Working Days Count"></asp:ListItem>
                                                                    <asp:ListItem Text="LeaveDaysCount" Value="Leave Days Count"></asp:ListItem>
                                                                    <asp:ListItem Text="WODaysCount" Value="WO Days Count"></asp:ListItem>
                                                                    <asp:ListItem Text="AbsentDaysCount" Value="Absent Days Count"></asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" cellpadding="3" cellspacing="0" style="width: 700px">
                                            <tr>
                                                <td align="center" style="width: 180px">
                                                    <asp:Label ID="lblHoursHead" runat="server" CssClass="cssLable" Text="Hours Head"></asp:Label>
                                                </td>
                                                <td style="width: 50px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPaysumHead" runat="server" Width="180px" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="ddlPaysumHead_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 50px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalHrs" Width="180px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ListBox ID="lbHoursHead" runat="server" SelectionMode="Multiple" Rows="10" Width="180px">
                                                    </asp:ListBox>
                                                </td>
                                                <td align="center">
                                                    <asp:ImageButton ID="ImgBtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                        OnClick="ImgBtnAdd_Click" ToolTip="<%$ Resources:Resource, Add %>" ImageUrl="../Images/Add.gif" />
                                                    <br>
                                                    <br>
                                                    <asp:ImageButton ID="ImgBtnRemove" runat="server" CssClass="cssImgButton" CommandName="Remove"
                                                        OnClick="ImgBtnRemove_Click" ToolTip="<%$ Resources:Resource, Remove %>" ImageUrl="../Images/Remove.gif" />
                                                </td>
                                                <td>
                                                    <asp:ListBox ID="lbMappedPaysumHead" runat="server" SelectionMode="Multiple" Rows="10"
                                                        Width="180px"></asp:ListBox>
                                                </td>
                                                <td align="center">
                                                    <asp:ImageButton ID="ImgBtnAdd1" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                        OnClick="ImgBtnAdd1_Click" ToolTip="<%$ Resources:Resource, Add %>" ImageUrl="../Images/Add.gif" />
                                                    <br>
                                                    <br>
                                                    <asp:ImageButton ID="ImgBtnRemove1" runat="server" CssClass="cssImgButton" CommandName="Remove"
                                                        OnClick="ImgBtnRemove1_Click" ToolTip="<%$ Resources:Resource, Remove %>" ImageUrl="../Images/Remove.gif" />
                                                </td>
                                                <td>
                                                    <asp:ListBox ID="lbTotalHrs" runat="server" SelectionMode="Multiple" Rows="10" Width="180px">
                                                    </asp:ListBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="height: 26px">
                                                    <asp:Button ID="btnApply" Text="<%$ Resources:Resource, Apply %>" runat="server"
                                                        OnClick="btnApply_Click" CssClass="cssButton" />
                                                </td>
                                                <td colspan="2" align="center">
                                                    <asp:Button ID="btnApplyTotalHrs" Text="<%$ Resources:Resource, Apply %>" runat="server"
                                                        OnClick="btnApplyTotalHrs_Click" CssClass="cssButton" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lblErrPaysum" runat="server" CssClass=" csslblErrMsg"></asp:Label>
                                    </div>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <%--Step11 Define Define Paysum Readiness  --%>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="TabPaysumReadiness" runat="server"
                                TabIndex="8" HeaderText="Step11">
                                <ContentTemplate>
                                    <asp:Label ID="Label29" runat="server" CssClass="cssLabelHeader" Text="Define Paysum Readiness"></asp:Label>
                                    <div class="squareboxcontent">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="hfPId" runat="server" />
                                                    <asp:GridView ID="gvPsrProcess" runat="server" ShowFooter="True" Width="250px" CssClass="GridViewStyle"
                                                        AutoGenerateColumns="False" OnRowEditing="gvPsrProcess_RowEditing" OnRowCancelingEdit="gvPsrProcess_RowCancelingEdit"
                                                        OnRowUpdating="gvPsrProcess_RowUpdating" OnRowDataBound="gvPsrProcess_RowDataBound">
                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle Width="50px" />
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrPaysumHead" Width="200" runat="server" CssClass="cssLabelHeader"
                                                                        Text="Description"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvProcessDesc" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ProcessDesc").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IsSubscribed">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbIsSubscribed" Enabled="false" Checked='<%# Bind("IsSubscribed") %>'
                                                                        CssClass="cssCheckBox" runat="server" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="cbIsSubscribed" CssClass="cssCheckBox" Checked='<%# Bind("IsSubscribed") %>'
                                                                        runat="server" />
                                                                    <asp:HiddenField ID="hfPId2" runat="server" Value='<%# Bind("PId") %>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Level">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblImplementationStatus" Width="80px" CssClass="cssLable" runat="server"
                                                                        Text='<%# Bind("ImplementationStatus") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlImplementationStatus" runat="server" CssClass="cssDropDown">
                                                                        <asp:ListItem Text="Mandatory" Value="Mandatory"></asp:ListItem>
                                                                        <asp:ListItem Text="Informative" Value="Informative"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="hfImplementationStatus" runat="server" Value='<%# Bind("ImplementationStatus") %>' />
                                                                </EditItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="80px" />
                                                                <ItemStyle Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvPaysumReadinessAction" CssClass="cssLabelHeader" runat="server"
                                                                        Text="<%$ Resources:Resource,Action %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                        ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                    <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                        ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                                <td valign="top">
                                                    <table width="100%" cellpadding="0" cellspacing="2">
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="Label30" CssClass=" cssLabelHeader" Text="Select Paysum Readiness Elements"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvProcessParameters" runat="server" ShowFooter="True" Width="250px"
                                                                    CssClass="GridViewStyle" AutoGenerateColumns="False" OnRowEditing="gvProcessParameters_RowEditing"
                                                                    OnRowUpdating="gvProcessParameters_RowUpdating" OnRowCancelingEdit="gvProcessParameters_RowCancelingEdit"
                                                                    OnRowDataBound="gvProcessParameters_RowDataBound">
                                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSerialNoPsr" CssClass="cssLable" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterStyle Width="50px" />
                                                                            <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblgvHdrPaysumReadinessHead" runat="server" CssClass="cssLabelHeader"
                                                                                    Text="Parameters"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgvPaysumReadinessInputParameter" runat="server" CssClass="cssLabel"
                                                                                    Text='<%# DataBinder.Eval(Container.DataItem, "InputParameter").ToString()%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblgvHdrPaysumReadinessHeadValue" runat="server" CssClass="cssLabelHeader"
                                                                                    Text="Value"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgvPaysumReadinessInputParameterValue" runat="server" CssClass="cssLabel"
                                                                                    Text='<%# DataBinder.Eval(Container.DataItem, "InputParameterValue").ToString()%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtgvPaysumReadinessInputParameterValue" runat="server" CssClass="cssLabel"
                                                                                    Text='<%# DataBinder.Eval(Container.DataItem, "InputParameterValue").ToString()%>'></asp:TextBox>
                                                                                <asp:HiddenField ID="hfDataType" runat="server" Value='<%# Bind("DataType") %>' />
                                                                            </EditItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblgvPaysumReadinessAction" CssClass="cssLabelHeader" runat="server"
                                                                                    Text="<%$ Resources:Resource,Action %>"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                                    ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                                    ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                                    ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                            </EditItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                        </AjaxToolKit:TabContainer>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <script type="text/javascript">

        function CallPopup(GUID, RCode) {
            var pageName = "WorkingHrsBusinessRule.aspx?GUID=" + GUID + "&RCode=" + RCode;
            var winW = 1100;
            var winH = 500;
            var winX = (screen.availWidth - winW) / 2;
            var winY = (screen.availHeight - winH) / 2;
            var features = 'left=' + winX + ',top=' + winY + ',height=' + winH + ',' + 'width=' + winW + ',status=yes,' + 'toolbar=no,menubar=no,location=no';
            window.open(pageName, '', features);
        }

        function displayHidden() {
            document.getElementById('divNewPaysumHead').style.display = "block";
        }

        function furmulaBuilder(obj, str) { // add Item
            if (str == 'WeeklyHours' || str == 'WeeklyDays') {
                var selectedItem = str + obj.options[obj.selectedIndex].text;
            }
            else {
                var selectedItem = obj.options[obj.selectedIndex].text;
            }
            var opt = document.createElement("option");

            var listBox = document.getElementById('<%=lbFormulaExp.ClientID %>');

            if (listBox.options.length > 0 && listBox.selectedIndex > 0) {
                if (listBox.options[listBox.selectedIndex].value == "Constant") {
                    listBox.options[listBox.selectedIndex].text = listBox.options[listBox.selectedIndex].text + selectedItem;
                    listBox.selectedIndex = -1;
                    return;
                }
            }
            // Add an Option object to Drop Down/List Box
            document.getElementById('<%=lbFormulaExp.ClientID %>').options.add(opt);        // Assign text and value to Option object
            opt.text = selectedItem;
            opt.value = str;

        }

        function removeItem(obj) { // RemoveItem
            var i;
            for (i = obj.options.length - 1; i >= 0; i--) {
                if (obj.options[i].selected)
                    obj.remove(i);
            }
        }





        function furmulaBuilderExp() {

            var listBox = document.getElementById('<%=lbFormulaExp.ClientID %>');
            var strFormulaType;
            var strFormula;
            strFormulaType = "";
            strFormula = "";
            for (var i = 0; i < listBox.options.length; i++) {
                if (strFormulaType == "") {
                    strFormulaType = listBox.options[i].value;
                    strFormula = listBox.options[i].text;
                }
                else {

                    strFormulaType = strFormulaType + "," + listBox.options[i].value;
                    strFormula = strFormula + "," + listBox.options[i].text;
                }

            }
            document.getElementById('<%=hid_FormulaExpType.ClientID %>').value = strFormulaType;
            document.getElementById('<%=hid_FormulaExp.ClientID %>').value = strFormula;

        }

        function showFormula() {
            var listBox = document.getElementById('<%=lbFormula.ClientID %>');
            alert(listBox.options[listBox.selectedIndex].value);


        }

        function checkNum(evt) {
            var carCode = (evt.which) ? evt.which : event.keyCode
            if (carCode > 31 && (carCode < 48) || (carCode > 57)) {
                return false;
            }
        }
        
        
    </script>
</asp:Content>
