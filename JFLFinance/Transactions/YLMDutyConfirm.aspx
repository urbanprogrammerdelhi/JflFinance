<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="true" CodeFile="YLMDutyConfirm.aspx.cs" Inherits="Transactions_YLMDutyConfirm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/jscript">
        var oldgridSelectedColor;
        var newgridSelectedColor = '#7ca8d3';
        function CheckUncheckAll(ObjCheckBox) {
            var frm = document.aspnetForm;
            var ChkState = ObjCheckBox.checked;

            var ObjCheckBoxid = ObjCheckBox.id;
            var ObjCheckBoxChildid

            for (var i = ObjCheckBoxid.length; i >= 0; i--) {
                if (ObjCheckBoxid.charAt(i) == '_') {
                    ObjCheckBoxChildid = ObjCheckBoxid.substring(i + 1, ObjCheckBoxid.length - 3)
                    break;
                }
            }

            var mycolor;
            if (ObjCheckBox.checked == true) {
                oldgridSelectedColor = ObjCheckBox.parentElement.parentElement.style.backgroundColor;
                mycolor = newgridSelectedColor;
            }
            else {
                mycolor = oldgridSelectedColor;
            }

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(ObjCheckBoxChildid) != -1) {
                    e.checked = ChkState;
                }

                //            if (e.type == 'checkbox' && e.name.indexOf('cbYLMProcessedOutTime') != -1) {
                //                e.checked = ChkState;
                //                e.parentElement.parentElement.style.backgroundColor = mycolor;
                //            }
            }
        }
    </script>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="100%">
                    <table border="0" width="100%" cellpadding="1" cellspacing="1">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAreaId" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,AreaID%>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px;">
                                <telerik:RadComboBox ID="ddlAreaId" runat="server" Width="100%" MaxHeight="350px"
                                    AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaId_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <%--  <telerik:RadComboBox ID="ddlAreaName" runat="server" Width="250px" MaxHeight="350px"
                                    AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaName_SelectedIndexChanged">
                                </telerik:RadComboBox>--%>
                            </td>
                            <td align="right" style="width: 100px;">
                                <asp:Label ID="lblclientcode" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Client%>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px;">
                                <telerik:RadComboBox ID="ddlClientCode" runat="server" Width="100%" MaxHeight="350px"
                                    AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <%--  <telerik:RadComboBox ID="ddlClientName" runat="server" Width="250px" MaxHeight="350px"
                                    AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged">
                                </telerik:RadComboBox>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblAsmtCode" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Asmt%>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px;">
                                <telerik:RadComboBox ID="ddlAsmtCode" runat="server" Width="100%" MaxHeight="350px"
                                    AutoPostBack="false" Filter="StartsWith">
                                </telerik:RadComboBox>
                                <%-- <telerik:RadComboBox ID="ddlAsmtName" runat="server" Width="250px" MaxHeight="350px"
                                    AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAsmtName_SelectedIndexChanged">
                                </telerik:RadComboBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,WithConfirmedDuty%>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBox runat="server" ID="cbWithConfirmedDuty" />
                            </td>
                            <td align="right">
                                <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,AttendanceType%>"></asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="ddlAttendanceType" runat="server" Width="250px" MaxHeight="350px"
                                    Filter="StartsWith">
                                    <Items>
                                        <%--<telerik:RadComboBoxItem Text="<%$ Resources:Resource, All%>" Value="0" />
                                        <telerik:RadComboBoxItem Text="Matched" Value="1" />
                                        <telerik:RadComboBoxItem Text="Un-Matched" Value="2" />--%>
                                        <telerik:RadComboBoxItem Text="Incomplete Records" Value="3" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,DutyDate%>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFromDate" ValidationGroup="Submit" Width="70px" runat="server"
                                    CssClass="csstxtbox" AutoPostBack="false" Text=""></asp:TextBox>
                                <asp:Image ID="imgFromDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="ajxCal" runat="server" TargetControlID="txtFromDate"
                                    PopupButtonID="imgFromDate" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate"
                                    ErrorMessage="*" ValidationGroup="Submit" ForeColor="Red" SetFocusOnError="true" />
                                -

                                <asp:TextBox ID="txtToDate" ValidationGroup="Submit" Width="70px" runat="server"
                                    CssClass="csstxtbox" AutoPostBack="false" Text=""></asp:TextBox>
                                <asp:Image ID="imgToDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender1" runat="server"
                                    TargetControlID="txtToDate" PopupButtonID="imgToDate" PopupPosition="BottomLeft" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate"
                                    ErrorMessage="*" ValidationGroup="Submit" ForeColor="Red" SetFocusOnError="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <asp:Button ID="btnSubmit" ValidationGroup="Submit" runat="server" CssClass="cssButton"
                                    Text="<%$ Resources:Resource,Proceed%>" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                     </asp:Panel>
                    <asp:Panel ID="Panel2" BorderWidth="1px" runat="server" Width="100%" Height="350px"
                        ScrollBars="Auto" CssClass="ScrollBar">
                        <asp:GridView ID="gvEmp" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                            CellPadding="1" CssClass="GridViewStyle" Width="1500px" OnRowDataBound="gvEmp_OnRowDataBound">
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
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ClientCode%>" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'
                                            CssClass="cssLabel"></asp:Label><br />
                                        <asp:Label ID="lblClientName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'
                                            CssClass="cssLabel"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,AsmtID%>" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:HiddenField runat="server" ID="hfAsmtCode" Value='<%# DataBinder.Eval(Container.DataItem, "AsmtID").ToString()%>' />
                                        <asp:Label ID="lblAsmtId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtID").ToString()%>'
                                            CssClass="cssLabel"></asp:Label><br />
                                        <asp:Label ID="lblAsmtAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtAddress").ToString()%>'
                                            CssClass="cssLabel"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,PostCode%>" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostCode").ToString()%>'
                                            CssClass="cssLabel"></asp:Label><br />
                                        <asp:Label ID="lblPostDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'
                                            CssClass="cssLabel"></asp:Label>
                                        <asp:HiddenField ID="hfPDlineNo" runat="server" Value='<%# Eval("ActPDLineNo")%>' />
                                        <asp:HiddenField ID="hfActualRosterProcessedYLMAutoID" runat="server" Value='<%# Eval("ActualRosterProcessedYLMAutoID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ServiceCategoryCode%>" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblServiceCategoryCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceCategoryCode").ToString()%>'
                                            CssClass="cssLabel"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber%>" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'
                                            CssClass="cssLabel"></asp:Label><br />
                                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName").ToString()%>'
                                            CssClass="cssLabel"></asp:Label>
                                        <asp:HiddenField ID="HFConfirmStatus" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConfirmStatus").ToString()%>' />
                                        <asp:HiddenField ID="HFLocationAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LocationAutoId").ToString()%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DutyDate%>" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDutyDate" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("YLMProcessedDutyDate"))%>'
                                            CssClass="cssLabel"></asp:Label><br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="100px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblhdrFixSchTimeFrom" runat="server" Text="<%$ Resources:Resource,Schedule%>"
                                            CssClass="cssLabel"></asp:Label>&nbsp;
                                        <asp:Label ID="lblhdrSchTimeFrom" runat="server" Text="<%$ Resources:Resource,TimeFrom%>"
                                            CssClass="cssLabel"></asp:Label>-
                                        <asp:Label ID="lblhdrSchTimeTo" runat="server" Text="<%$ Resources:Resource,TimeTo%>"
                                            CssClass="cssLabel"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfRosterAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RosterAutoID").ToString()%>' />
                                        <asp:HiddenField ID="hfSchRosterAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SchRosterAutoID").ToString()%>' />
                                        <asp:Label ID="lblSchTimeFrom" Width="60px" MaxLength="5" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("SchTimeFrom"))%>'
                                            CssClass="cssLabel"></asp:Label>-
                                        <asp:Label ID="lblSchTimeTo" Width="60px" MaxLength="5" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("SchTimeTo"))%>'
                                            CssClass="cssLabel"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="100px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbActInTimeAll" runat="server" Checked="false" onclick="javascript:CheckUncheckAll(this);" />
                                        <asp:Label ID="lblhdrFixActTimeFrom" runat="server" Text="<%$ Resources:Resource,ActualDuty%>"
                                            CssClass="cssLabel"></asp:Label>&nbsp;
                                        <asp:Label ID="lblhdrActTimeFrom" runat="server" Text="<%$ Resources:Resource,TimeFrom%>"
                                            CssClass="cssLabel"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbActInTime" runat="server" Checked="false" />
                                        <asp:TextBox ID="lblActTimeFrom" Width="60px" MaxLength="5" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("ActTimeFrom"))%>'
                                            CssClass="csstxtbox"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="100px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbActOutTimeAll" runat="server" Checked="false" onclick="javascript:CheckUncheckAll(this);" />
                                        <asp:Label ID="lblhdrFixActTimeTo" runat="server" Text="<%$ Resources:Resource,ActualDuty%>"
                                            CssClass="cssLabel"></asp:Label>&nbsp;
                                        <asp:Label ID="lblhdrActTimeTo" runat="server" Text="<%$ Resources:Resource,TimeTo%>"
                                            CssClass="cssLabel"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbActOutTime" runat="server" Checked="false" />
                                        <asp:TextBox ID="lblActTimeTo" Width="60px" MaxLength="5" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("ActTimeTo"))%>'
                                            CssClass="csstxtbox"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="100px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbYLMRawInTimeAll" runat="server" Checked="false" onclick="javascript:CheckUncheckAll(this);" />
                                        <asp:Label ID="lblhdrFixYLMRawTimeFrom" runat="server" Text="<%$ Resources:Resource,YLMOnline%>"
                                            CssClass="cssLabel"></asp:Label>&nbsp;
                                        <asp:Label ID="lblhdrYLMRawTimeFrom" runat="server" Text="<%$ Resources:Resource,TimeFrom%>"
                                            CssClass="cssLabel"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbYLMRawInTime" runat="server" Checked="false" />
                                        <asp:HiddenField runat="server" ID="hfYLMRawTimeFrom" Value='<%# String.Format("{0:dd-MMM-yyyy}",Eval("YLMRawTimeFrom"))%>' />
                                        <asp:Label ID="lblYLMRawTimeFrom" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("YLMRawTimeFrom"))%>'
                                            CssClass="cssLabel"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="100px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbYLMRawOutTimeAll" runat="server" Checked="false" onclick="javascript:CheckUncheckAll(this);" />
                                        <asp:Label ID="lblhdrFixYLMRawTimeTo" runat="server" Text="<%$ Resources:Resource,YLMOnline%>"
                                            CssClass="cssLabel"></asp:Label>&nbsp;
                                        <asp:Label ID="lblhdrYLMRawTimeTo" runat="server" Text="<%$ Resources:Resource,TimeTo%>"
                                            CssClass="cssLabel"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbYLMRawOutTime" runat="server" Checked="false" />
                                        <asp:HiddenField runat="server" ID="hfYLMRawTimeTo" Value='<%# String.Format("{0:dd-MMM-yyyy}",Eval("YLMRawTimeTo"))%>' />
                                        <asp:Label ID="lblYLMRawTimeTo" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("YLMRawTimeTo"))%>'
                                            CssClass="cssLabel"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="120px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbYLMProcessedInTimeAll" runat="server" Checked="false" onclick="javascript:CheckUncheckAll(this);" />
                                        <asp:Label ID="lblhdrFixYLMProcessedTimeFrom" runat="server" Text="<%$ Resources:Resource,YLMProcessed%>"
                                            CssClass="cssLabel"></asp:Label>&nbsp;
                                        <asp:Label ID="lblhdrYLMProcessedTimeFrom" runat="server" Text="<%$ Resources:Resource,TimeFrom%>"
                                            CssClass="cssLabel"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbYLMProcessedInTime" runat="server" Checked="false" />
                                        <asp:HiddenField runat="server" ID="hfYLMProcessedTimeFrom" Value='<%# String.Format("{0:dd-MMM-yyyy}",Eval("YLMProcessedTimeFrom"))%>' />
                                        <asp:Label ID="lblYLMProcessedTimeFrom" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("YLMProcessedTimeFrom"))%>'
                                            CssClass="cssLabel"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="120px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbYLMProcessedOutTimeAll" runat="server" Checked="false" onclick="javascript:CheckUncheckAll(this);" />
                                        <asp:Label ID="lblhdrFixYLMProcessedTimeTo" runat="server" Text="<%$ Resources:Resource,YLMProcessed%>"
                                            CssClass="cssLabel"></asp:Label>&nbsp;
                                        <asp:Label ID="lblhdrYLMProcessedTimeTo" runat="server" Text="<%$ Resources:Resource,TimeTo%>"
                                            CssClass="cssLabel"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbYLMProcessedOutTime" runat="server" Checked="false" />
                                        <asp:HiddenField runat="server" ID="hfYLMProcessedTimeTo" Value='<%# String.Format("{0:dd-MMM-yyyy}",Eval("YLMProcessedTimeTo"))%>' />
                                        <asp:Label ID="lblYLMProcessedTimeTo" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("YLMProcessedTimeTo"))%>'
                                            CssClass="cssLabel"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Confirm Duty">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                            CssClass="cssImgButton" OnClick="lbADD_Click" ValidationGroup="AddNew" CommandName="AddNew"
                                            ImageUrl="../Images/AddNew.gif" />
                                        <%--<asp:HiddenField runat="server" ID="hfConfirmFlag" Value='<%# DataBinder.Eval(Container.DataItem, "ConfirmFlag").ToString()%>'/>--%>
                                        <asp:HiddenField runat="server" ID="hfConfirmFlag" Value="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnConfirm" runat="server" Text="<%$ Resources:Resource,ConfirmDuty%>"
                            CssClass="cssButton" OnClick="btnConfirm_Click" />
                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                    </asp:Panel>
               
            </ContentTemplate>
        </Ajax:UpdatePanel>
    </telerik:RadAjaxPanel>
</asp:Content>
