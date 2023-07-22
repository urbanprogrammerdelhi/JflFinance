<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ScheduleLockUnLoack.aspx.cs" Inherits="Transactions_ScheduleLockUnLoack"
    Title="Untitled Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
            <ContentTemplate>
                <table width="100%" border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td align="Left">
                            <div style="width: 950px;">
                                <div class="squarebox">
                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                        <div style="float: left; width: 670px;">
                                            <tt style="text-align: center;">
                                                <asp:Label ID="Label5" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,Lock %> "></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent" style="text-align: left">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 950px">
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="cssLable" ID="lblMonth" runat="server" Text="<%$ Resources:Resource, Month %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddlMonth" Width="100px" EnableEmbeddedSkins="true" AccessKey="M"
                                                                    AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource, January%>" Value="1" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,February%>" Value="2" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,March%>" Value="3" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,April%>" Value="4" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,May%>" Value="5" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,June%>" Value="6" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,July%>" Value="7" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,August%>" Value="8" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,September%>" Value="9" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,October%>" Value="10" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,November%>" Value="11" />
                                                                        <telerik:RadComboBoxItem Text="<%$ Resources:Resource,December%>" Value="12" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="txtYear" NumberFormat-AllowRounding="false" NumberFormat-DecimalDigits="0"
                                                                    NumberFormat-KeepNotRoundedValue="false" NumberFormat-GroupSeparator="" ShowSpinButtons="true"
                                                                    EmptyMessage="<%$ Resources:Resource, Year %>" MinValue="1950" AutoPostBack="true"
                                                                    OnTextChanged="txtYear_TextChanged" MaxValue="2999" AccessKey="y" runat="server"
                                                                    MaxLength="4" Width="80px">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblWeekNo" runat="server" Text="<%$ Resources:Resource,Week%>"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddlWeek" Width="260px" runat="server" AccessKey="W" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged" EnableEmbeddedSkins="true">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 80px">
                                                    <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,Date %>" CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" Width="80px"
                                                        AutoPostBack="false" Enabled="false"></asp:TextBox>
                                                    <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate" OnClientDateSelectionChanged="DateChanged">
                                                    </AjaxToolKit:CalendarExtender>
                                                    -
                                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" Width="80px"
                                                        AutoPostBack="false" Enabled="false"></asp:TextBox>
                                                    <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtToDate" PopupButtonID="ImgToDate"  OnClientDateSelectionChanged="DateChanged">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:Button ID="btnDateChanged" runat="server" OnClick="Datechanged_Click" style="display:none;" />
                                                </td>
                                                <td align="right" style="width: 200px">
                                                    <asp:HiddenField ID="HFFromDate" runat="server" />
                                                    <asp:HiddenField ID="HFToDate" runat="server" />
                                                    <asp:HiddenField ID="HFMaxDate" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblBranch" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="ddlBranch" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                                                        Width="260px">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ClientName %> "
                                                        CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="ddlClientCode" AllowCustomText="true" AccessKey="C" CloseDropDownOnBlur="true"
                                                        EnableEmbeddedSkins="true" Filter="Contains" AutoPostBack="true" IsCaseSensitive="false"
                                                        MarkFirstMatch="true" Width="260px" runat="server" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,Asmt %> " CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="ddlAsmtCode" AllowCustomText="true" AccessKey="A" Filter="Contains"
                                                        EnableEmbeddedSkins="true" IsCaseSensitive="false" MarkFirstMatch="true" Width="260px"
                                                        runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAsmtCode_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPost" runat="server" Text="<%$Resources:Resource,Post %> " CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="ddlPost" AllowCustomText="true" Filter="Contains" AccessKey="P"
                                                        EnableEmbeddedSkins="true" IsCaseSensitive="false" MarkFirstMatch="true" Width="260px"
                                                        runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblLockUnlockFor" runat="server" Text="<%$Resources:Resource,Lock %> "
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddlLockUnlockFor" AllowCustomText="true" Filter="Contains"
                                                        AutoPostBack="true" AccessKey="P" EnableEmbeddedSkins="true" OnSelectedIndexChanged="ddlLockUnlockFor_IndexChange"
                                                        IsCaseSensitive="false" MarkFirstMatch="true" Width="260px" runat="server">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Text="<%$Resources:Resource,Selected %>" Value="Sel" />
                                                            <telerik:RadComboBoxItem Text="<%$Resources:Resource,All %>" Value="All" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAction" runat="server" Text="<%$Resources:Resource,Action %> "
                                                        CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbLock" runat="server" GroupName="LockUnlock" Text="<%$Resources:Resource,Lock %> "
                                                                    Checked="true" OnCheckedChanged="rbLock_Changed" AutoPostBack="true" />
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbUnlock" runat="server" GroupName="LockUnlock" Text="<%$Resources:Resource,UnLock %> "
                                                                  Visible="False"  Checked="false" OnCheckedChanged="rbUnLock_Changed" AutoPostBack="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" CssClass="cssButton"
                                                        Text="<%$ Resources:Resource, Proceed %>" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="panel1" runat="server" GroupingText="" Width="940px">
                                                        <asp:GridView ID="gvScheduleLockUnLock" runat="server" Width="930px" CssClass="GridViewStyle"
                                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="false" CellPadding="0"
                                                            OnPageIndexChanging="gvScheduleLockUnLock_PageIndexChanging" OnRowCommand="gvScheduleLockUnLock_RowCommand"
                                                            OnRowDataBound="gvScheduleLockUnLock_RowDataBound" GridLines="None" AutoGenerateColumns="False">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="30" HeaderStyle-Width="30" FooterStyle-Width="30">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblHdrScheduleLockUnLockSno" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScheduleLockUnLockSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="150">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblHdrScheduleLockUnLockClientName" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$Resources:Resource,ClientName %> "></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScheduleLockUnLockClientName" CssClass="cssLable" runat="server"
                                                                            Text='<%# Eval("ClientName").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="150">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblHdrScheduleLockUnLockAsmtCode" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$Resources:Resource,Asmt %> "></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScheduleLockUnLockAsmtCode" CssClass="cssLable" runat="server"
                                                                            Text='<%# Eval("Asmt").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="150">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblHdrScheduleLockUnLockPost" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$Resources:Resource,Post %> "></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScheduleLockUnLockAsmtPost" CssClass="cssLable" runat="server"
                                                                            Text='<%# Eval("Post").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="100">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblHdrScheduleLockUnLockEmployeeNumber" CssClass="cssLabelHeader"
                                                                            runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScheduleLockUnLockEmployeeNumber" CssClass="cssLable" runat="server"
                                                                            Text='<%# Eval("EmployeeNumber").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="120">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblHdrScheduleLockUnLockEmployeeName" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScheduleLockUnLockEmployeeName" CssClass="cssLable" runat="server"
                                                                            Text='<%# Eval("EmployeeName").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="100">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblHdrScheduleDutyDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,DutyDate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScheduleLockUnLockDutyDate" CssClass="cssLable" runat="server"
                                                                            Text='<%# DateTime.Parse(Eval("DutyDate").ToString()).ToString("dd MMM yyyy")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="120">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblHdrScheduleLockUnLockSelect" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$ Resources:Resource,Select %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" Checked='<%# Eval("fldChk")%>'
                                                                            OnCheckedChanged="chkSelect_CheckedChanged" />
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:CheckBox ID="chkSelectAll" runat="server" EnableViewState="true" AutoPostBack="true"
                                                                            OnCheckedChanged="chkSelectAll_CheckedChanged" OnClick="javascript:checkAll(this)" />
                                                                        <asp:Button ID="btnLock" CommandName="LockUnlockSchedule" runat="server" CssClass="cssButton"
                                                                            Width="120px" Text="<%$ Resources:Resource, ProcessSelectedEmployee %>" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:HiddenField ID="hid_SelectAll" runat="server" />
                                                        <asp:HiddenField ID="weekStartDate" runat="server" />
                                                        <asp:HiddenField ID="weekEndDate" runat="server" />
                                                        <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                        <asp:GridView ID="GridView1" runat="server" Width="700px" CssClass="GridViewStyle"
                                                            ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="0" GridLines="None"
                                                            AutoGenerateColumns="true">
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </Ajax:UpdatePanel>
    </telerik:RadAjaxPanel>
    
    <script language="javascript" type="text/javascript">
        function DateChanged() {
            document.getElementById('ctl00_ContentPlaceHolder1_btnDateChanged').click();
        }
        
        function checkAll(objRef) {
            var gridView = objRef.parentNode.parentNode.parentNode;
            var inputList = gridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
        
    </script>
</asp:Content>
