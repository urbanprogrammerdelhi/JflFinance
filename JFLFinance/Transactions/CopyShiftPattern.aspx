<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CopyShiftPattern.aspx.cs" Inherits="Transactions_CopyShiftPattern" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Assembly="DropCheck" Namespace="xMilk" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
<ContentTemplate>
<table>
        <tr>
            <td>
                <div style="width: 950px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 930px;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="Copy Shift Pattern"></asp:Label></tt>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td align="center" style="width: 100%">
                            <asp:Panel ID="PanelSource" Width="800px" BorderWidth="0px" GroupingText= "Source" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,ClientName %> "
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" Width="350px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:Resource,Assignment %> "
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlAsmt" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                               OnSelectedIndexChanged = "ddlAsmt_SelectedIndexChanged" Width="350px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ShiftPattern %> "
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <cc1:DropCheck ID="ddlShiftPattern" runat="server" CssClass="cssDropDown" AutoPostBack="false"
                                               OnSelectedIndexChanged = "ddlShiftPattern_SelectedIndexChanged" Width="350px">
                                            </cc1:DropCheck>
                                        </td>
                                    </tr>
                                </table>
                            </asp:panel>
                            <asp:Panel ID="PanelDestination" Width="800px" BorderWidth="0px" GroupingText= "Destination" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,ClientName %> "
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlClientSelect" runat="server" CssClass="cssDropDown" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlClientSelect_SelectedIndexChanged" Width="350px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,Assignment %> "
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <cc1:DropCheck ID="ddlCopyToAsmt" runat="server" ValidationGroup="vgAsmt"   CssClass="cssDropDown" AutoPostBack="false"
                                                Width="350px">
                                            </cc1:DropCheck>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td width="200px">
                                    </td>
                                    <td align="left" width="400px">
                                        <asp:Button ID="btnCopy" runat="server" Text="<%$Resources:Resource,Copy %>"
                                            CssClass="cssButton" OnClick="btnCopy_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                      </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gvErrorMessage" PageSize="5" Width="650px" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle"   OnRowDataBound="gvErrorMessage_RowDataBound"   OnPageIndexChanging="gvErrorMessage_PageIndexChanging">
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <Columns>
                             <asp:TemplateField HeaderText="<%$ Resources:Resource ,TransactionDesc %>">
                                <ItemTemplate>
                                    <asp:Label ID="lblReason" CssClass="cssLable" runat="server" Text='<%# Bind("MessageString") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="180px" />
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="<%$ Resources:Resource ,Action %>">
                                <ItemTemplate>
                                    <asp:HiddenField ID="msgId" runat="server" Value='<%# Bind("MessageId") %>' />
                                    <asp:LinkButton ID="btnAction" CssClass="cssLable" runat="server" OnClick="btnAction_OnClick"
                                        Text='<%# Bind("comment")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Width="70px" />
                            </asp:TemplateField>--%>
                             <asp:TemplateField HeaderText="<%$ Resources:Resource ,Assignment %>">
                                <ItemTemplate>
                                    <asp:Label ID="lblAsmtCode" CssClass="cssLable" runat="server" Text='<%# Bind("AsmtCode") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="70px" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="<%$ Resources:Resource ,ShiftPattern %>">
                                <ItemTemplate>
                                    <asp:Label ID="lblShiftPattern" CssClass="cssLable" runat="server" Text='<%# Bind("shiftPattern") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="<%$ Resources:Resource ,ShiftPattern %>">
                                <ItemTemplate>
                                    <asp:Label ID="lblShiftPatternDesc" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftPatternDesc") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                  <Triggers>
                    <Ajax:AsyncPostBackTrigger ControlID="btnApply" EventName="Click" />
                  </Triggers>
                </Ajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="Panel6" BackColor="white" ScrollBars="none" CssClass="ScrollBar" runat="server"
                    Visible="false" Height="400" Width="750" Style="border: 1px; border-style: solid;
                    border-color: Red">
                    <asp:Button ID="btn1" runat="server" Style="display: none" />
                    <AjaxToolKit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnCopy"
                        PopupControlID="Panel6" BackgroundCssClass="modalBackground" />
                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="always">
                        <ContentTemplate>
                                <asp:GridView ID="grdPatternInfo" PageSize="5" Width="650px" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" OnPageIndexChanging="grdPatternInfo_PageIndexChanging">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                           <asp:TemplateField HeaderText="<%$ Resources:Resource ,ShiftPattern %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReason" CssClass="cssLable" runat="server" Text='<%# Bind("shiftPattern") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource ,ShiftPattern %>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TxtShiftPattern" Visible="true" Width="200px" Text='<%# Bind("shiftPattern") %>' CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                                <asp:Button ID="btnApply" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource ,Apply %>" OnClick="btnApply_Click"
                                    ValidationGroup="TerminateEmployee"/>
                                <asp:Button ID="btnClose" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource ,Close %>" OnClick="btnClose_Click" />
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </ContentTemplate>
</Ajax:UpdatePanel>
</asp:Content>

