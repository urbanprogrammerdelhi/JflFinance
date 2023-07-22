<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OTReaasonTransaction.aspx.cs"
    Inherits="Transactions_OTReaasonTransaction" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Ajax:ScriptManager ID="script" runat="server">
        </Ajax:ScriptManager>
        <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel1" GroupingText="<%$Resources:Resource,EmployeeDetails %>" Width="100%"
                    runat="server">
                    <table width="300px" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblEmployee" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeNumber" Width="120px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeName %>"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeName" Width="120px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDutyDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DutyDate %>"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDutyDate" Width="80px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblShift" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ShiftCode %>"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtShift" Width="30px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                <asp:TextBox ID="txtTimeFrom" Width="30px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                <asp:TextBox ID="txtTimeTo" Width="30px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                        <asp:HiddenField ID="HFOTFromTime" runat="server" />
                        <asp:HiddenField ID="HFOTToTime" runat="server" />
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                <table style="width:100%">
                    <tr>
                        <td>
                            <asp:GridView Width="100%" ID="gvOTReasonTran" CssClass="GridViewStyle" runat="server"
                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvOTReasonTran_RowDataBound"
                                OnRowCommand="gvOTReasonTran_RowCommand" OnPageIndexChanging="gvOTReasonTran_PageIndexChanging"
                                OnRowCancelingEdit="gvOTReasonTran_RowCancelingEdit" OnRowDeleting="gvOTReasonTran_RowDeleting"
                                OnRowEditing="gvOTReasonTran_RowEditing" OnRowUpdating="gvOTReasonTran_RowUpdating">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
                                            &nbsp;
                                            <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                CommandName="Cancel" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                            &nbsp;
                                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                CommandName="Edit" />
                                            &nbsp;
                                            <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                        </ItemTemplate>
                                        <FooterStyle Width="100px" />
                                        <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                        <ItemStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,OTReason %>" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOTReasonDesc" runat="server" CssClass="cssLabel" Text='<%# Bind("ReasonDesc") %>'></asp:Label>
                                            <asp:HiddenField ID="hfOTReasonTranAutoID" runat="server" Value='<%# Bind("OTReasonTranAutoID") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlOTReasonDesc" Enabled="false" Width="100%" CssClass="cssDropDown" runat="server">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hfResonAutoID" runat="server" Value='<%# Bind("ReasonAutoID") %>' />
                                            <asp:HiddenField ID="hfOTReasonTranAutoID" runat="server" Value='<%# Bind("OTReasonTranAutoID") %>' />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlOTReasonDesc" Width="100%" CssClass="cssDropDown" runat="server">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                      
                                        <HeaderStyle  CssClass="cssLabelHeader" />
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,FromTime %>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTimeFrom" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtTimeFrom" CssClass="csstxtbox" Width="60px" ValidationGroup="Edit" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender34" runat="server" TargetControlID="txtTimeFrom"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator34" runat="server" ControlExtender="MaskedEditExtender34"
                                                ControlToValidate="txtTimeFrom" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                InvalidValueBlurredMessage="*" ValidationGroup="Edit" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterTimeFrom" CssClass="csstxtbox" Width="60px"  ValidationGroup="AddNew" runat="server"></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender33" runat="server" TargetControlID="txtFooterTimeFrom"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator33" runat="server" ControlExtender="MaskedEditExtender33"
                                                ControlToValidate="txtFooterTimeFrom" IsValidEmpty="False" Display="Dynamic"
                                                EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" ValidationGroup="AddNew" />
                                        </FooterTemplate>
                                        <FooterStyle Width="100px" />
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,ToTime %>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTimeTo" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtTimeTo" CssClass="csstxtbox" Width="60px"  ValidationGroup="Edit" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender32" runat="server" TargetControlID="txtTimeTo"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator32" runat="server" ControlExtender="MaskedEditExtender32"
                                                ControlToValidate="txtTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                InvalidValueBlurredMessage="*" ValidationGroup="Edit" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFooterTimeTo" CssClass="csstxtbox"  ValidationGroup="AddNew" Width="60px" runat="server"></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender31" runat="server" TargetControlID="txtFooterTimeTo"
                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                            <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator31" runat="server" ControlExtender="MaskedEditExtender31"
                                                ControlToValidate="txtFooterTimeTo" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                                InvalidValueBlurredMessage="*" ValidationGroup="AddNew" />
                                        </FooterTemplate>
                                        <FooterStyle Width="100px" />
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </Ajax:UpdatePanel>
    </div>
    </form>
</body>
</html>
