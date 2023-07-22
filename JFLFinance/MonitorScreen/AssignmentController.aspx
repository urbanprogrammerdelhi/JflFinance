<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AssignmentController.aspx.cs" Inherits="MonitorScreen_AssignmentController"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4" align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="430px"
                            ScrollBars="Auto" CssClass="ScrollBar">
                            <table border="0" width="100%" cellpadding="1" cellspacing="0">
                                <%--  <tr>
                                    <td align="left">
                                        
                                       <asp:Panel ID="pnlImg" runat="server" ScrollBars="Auto" CssClass="ScrollBar">
                                            
                                        </asp:Panel>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HFClientCode" runat="server" />
                                        <asp:HiddenField ID="HFAsmtCode" runat="server" />
                                        <asp:HiddenField ID="HFPostCode" runat="server" />
                                        <asp:Panel ID="pnlAsmtGrid" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="IBBack" runat="server" CommandName="ImgbtnHyperLink" CssClass="cssImgButton"
                                                            ImageUrl="~/Images/go_Back.gif" OnClick="IBBack_Click" ImageAlign="Left" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnClientDataExport" runat="server" Style="display: none;" CssClass="cssButton"
                                                            Text="Export" OnClick="btnClientDataExport_Click" CausesValidation="False" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                        <asp:Label ID="lblScans" CssClass="cssLabelHeader" runat="server" Text="Scans"></asp:Label>
                                                        <asp:CheckBox ID="chkScans" runat="server" AutoPostBack="true" Checked="false"/>
                                                        &nbsp;
                                                        &nbsp;
                                                        <asp:Label ID="lblScans1" CssClass="cssLabelHeader" Visible="false" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:GridView ID="gvDetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                CellPadding="1" CssClass="GridViewStyle" PageSize="14" Width="950px" OnPageIndexChanging="gvDetail_PageIndexChanging" OnRowDataBound="gvDetail_RowDataBound">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <EmptyDataTemplate>
                                                    Data Not Found !
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="30" HeaderStyle-Width="30" FooterStyle-Width="30" Visible="false">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblHdrScheduleLockUnLockSno" CssClass="cssLabelHeader" runat="server"
                                                                Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblScheduleLockUnLockSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField ItemStyle-Width="90">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkSelectAll" runat="server" EnableViewState="true" AutoPostBack="true"
                                                                OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" Checked='<%# Eval("fldChk")%>'
                                                                OnCheckedChanged="chkSelect_CheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    
                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
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
                                                                OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField FooterStyle-Width="75px" HeaderStyle-Width="75px" HeaderText="Post"
                                                        ItemStyle-Width="75px">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgbtnHyperLink" runat="server" CommandName="ImgbtnHyperLink"
                                                                CssClass="cssImgButton" ImageUrl="../Images/plus.gif" OnClick="ImgbtnHyperLink_Click" />
                                                            <asp:Label ID="lblgvPostCode" runat="server" CssClass="cssLable" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "PostCode").ToString()%>'></asp:Label>
                                                            <asp:Label ID="lblgvPostDesc" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-Width="110px" HeaderStyle-Width="110px" HeaderText="ClientCode"
                                                        ItemStyle-Width="110px" Visible = "false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgvClientCode" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-Width="110px" HeaderStyle-Width="110px" HeaderText="Assignment"
                                                        ItemStyle-Width="110px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgvAsmtCode" runat="server" CssClass="cssLable" Visible = "false" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtCode").ToString()%>'></asp:Label>
                                                            <asp:Label ID="lblAsmt" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "Asmt").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Schedule Count">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSchedule" runat="server" Text='<%# Eval("ScheduleCount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OnDuty Count">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCheckedIn" CssClass="cssLable" runat="server" Text='<%# Eval("ActualCount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incomplete Duty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncompDuty" CssClass="cssLable" runat="server" Text='<%# Eval("IncompleteDuty") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="UnScheduled Count">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnScheuled" CssClass="cssLable" runat="server" Text='<%# Eval("UnScheduledCount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Schedule Match Count">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMatchCount" CssClass="cssLable" runat="server" Text='<%# Eval("ActualScheduleMatchCount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Image ID="IMGRed" runat="server" ToolTip="Resource status:Green ok/ Red Short" /><%--ImageUrl='<%# (int)Eval("Variance")==0 ? Page.ResolveUrl("~/Images/Green1.jpg") : Page.ResolveUrl("~/Images/red.jpg") %>'--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:HiddenField ID="hid_SelectAll" runat="server"/>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlEmpGrd" runat="server" Visible="false">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="ImgbtnPnl" runat="server" CommandName="ImgbtnHyperLink" CssClass="cssImgButton"
                                                            ImageUrl="~/Images/go_Back.gif" OnClick="ImgbtnPnl_Click" ImageAlign="Left" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAsmtDateExport" runat="server" Style="display: none;" CssClass="cssButton"
                                                            Text="Export" OnClick="btnAsmtDateExport_Click" CausesValidation="False" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:GridView ID="gvEmp" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                CellPadding="1" CssClass="GridViewStyle" PageSize="15" Width="950px" OnPageIndexChanging="gvEmp_PageIndexChanging"
                                                OnRowDataBound="gvEmp_OnRowDataBound">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <EmptyDataTemplate>
                                                    Data Not Found !
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <%--<asp:BoundField HeaderText="ClientName" DataField="ClientName" />--%>
                                                    <asp:TemplateField HeaderText="Employee Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'
                                                                CssClass="cssLabel"></asp:Label>
                                                            <asp:HiddenField ID="HFConfirmStatus" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConfirmStatus").ToString()%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="EmployeeNumber" HeaderText="EmployeeNumber" />--%>
                                                    <asp:BoundField DataField="EmpName" HeaderText="EmployeeName" />
                                                    <asp:BoundField DataField="InTime" HeaderText="CheckIn" />
                                                    <asp:BoundField DataField="OutTime" HeaderText="Checkout" />
                                                    <asp:BoundField HeaderText="PhoneID" DataField="IMEI_IN" />
                                                    <asp:TemplateField HeaderText="Duty Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDutyDate" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                                            <%--<asp:Image runat="server" ID="img1" ImageUrl='<%# (int)Eval("EmpStatus")==0 ? Page.ResolveUrl("~/Images/green.gif") : Page.ResolveUrl("~/Images/red.gif") %>' />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("SchEmployeeNumber") %>'></asp:Label>
                                                            <%--<asp:Image runat="server" ID="img1" ImageUrl='<%# (int)Eval("EmpStatus")==0 ? Page.ResolveUrl("~/Images/green.gif") : Page.ResolveUrl("~/Images/red.gif") %>' />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Confirm Duty" Visible = "false" >
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                CssClass="cssImgButton" OnClick="lbADD_Click" ValidationGroup="AddNew" CommandName="AddNew"
                                                                ImageUrl="../Images/AddNew.gif" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm Assignment" CssClass="cssButton" Visible= "false"
                                                OnClick="btnConfirm_Click" />
                                            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <table width="100%" border="0">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel6" BackColor="white" ScrollBars="Auto" CssClass="ScrollBar" runat="server"
                                                        Height="200" Width="600" Style="display: none;">
                                                        <asp:Button ID="Button3" runat="server" Style="display: none" />
                                                        <AjaxToolKit:ModalPopupExtender ID="MPErrorDetail" runat="server" TargetControlID="Button3"
                                                            PopupControlID="Panel6" BackgroundCssClass="modalBackground" />
                                                        <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <div style="width: 600;">
                                                                                <div class="squarebox">
                                                                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                                                        <div style="float: left; width: 550px">
                                                                                            <tt style="text-align: center;">
                                                                                                <asp:Label ID="Label15" CssClass="squareboxgradientcaption" runat="server" Text="Error Details"></asp:Label></tt></div>
                                                                                    </div>
                                                                                    <div class="squareboxcontent">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:GridView ID="gvErrorDetails" Width="600" CssClass="GridViewStyle" runat="server"
                                                                                                        CellPadding="1">
                                                                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                                    </asp:GridView>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </div>
                                                                                
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnOk" runat="server" Text="<%$Resources:Resource, Ok%>" CssClass="cssButton"
                                                                                OnClick="btnOk_onClick" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </Ajax:UpdatePanel>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
