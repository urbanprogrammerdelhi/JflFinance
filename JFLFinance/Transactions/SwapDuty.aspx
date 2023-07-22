<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SwapDuty.aspx.cs" Inherits="Transactions_SwapDuty" Title="Swap Duty" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="TabLeave"
                                Width="430px" ActiveTabIndex="0">
                                <AjaxToolKit:TabPanel TabIndex="0" ID="SwapDuty" runat="server" HeaderText="<%$Resources:Resource,SwapDuty%>">
                                    <ContentTemplate>
                                        <Ajax:UpdatePanel runat="server" ID="upSingle" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <tr>
                                                            <td style="width: 120px">
                                                                <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ClientName %>"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="lblClientName" Width="220px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AsmtName %>"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="lblAsmtName" Width="220px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,PostDesc %>"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="lblPostDesc" Width="220px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <td>
                                                            <asp:Label ID="lblSwapEmployee" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSwapEmployee" Width="220px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSwapEmployeeName" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeName %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSwapEmployeeName" Width="220px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCurrentDutyDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DutyDate %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCurrentDutyDate" Width="220px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCurrentShift" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ShiftCode %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCurrentShift" Width="30px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                            <asp:TextBox ID="txtSwapTimeFrom" Width="30px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                            <asp:TextBox ID="txtSwapTimeTo" Width="30px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </Ajax:UpdatePanel>
                                    </ContentTemplate>
                                </AjaxToolKit:TabPanel>
                            </AjaxToolKit:TabContainer>
                        </td>
                        <td align="left">
                            <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="TabContainer1"
                                Width="430px" ActiveTabIndex="0">
                                <AjaxToolKit:TabPanel TabIndex="0" ID="TabPanel1" runat="server" HeaderText="Swap duty With">
                                    <ContentTemplate>
                                        <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNewDutyDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DutyDate %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNewDutyDate" Width="120px" runat="server" OnTextChanged="txtNewDutyDate_TextChanged"
                                                                AutoPostBack="true" CssClass="csstxtbox"></asp:TextBox>
                                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                                TargetControlID="txtNewDutyDate" Enabled="True">
                                                            </AjaxToolKit:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Client %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="ddlClient" AutoPostBack="true" AllowCustomText="true" AccessKey="C" CloseDropDownOnBlur="true"
                                                                Filter="Contains" EmptyMessage="<%$ Resources:Resource, NoDataToShow %>" IsCaseSensitive="false"
                                                                MarkFirstMatch="true" Width="260px" runat="server" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Assignment %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="ddlAsmtCode" AutoPostBack="true" AllowCustomText="true" AccessKey="C" CloseDropDownOnBlur="true"
                                                                Filter="Contains"  EmptyMessage="<%$ Resources:Resource, NoDataToShow %>" IsCaseSensitive="false"
                                                                MarkFirstMatch="true" Width="260px" runat="server" OnSelectedIndexChanged="ddlAsmtCode_SelectedIndexChanged">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Post %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="ddlPost" AutoPostBack="true" AllowCustomText="true" AccessKey="C" CloseDropDownOnBlur="true"
                                                                Filter="Contains" EmptyMessage="<%$ Resources:Resource, NoDataToShow %>" IsCaseSensitive="false"
                                                                MarkFirstMatch="true" Width="260px" runat="server" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>

                                                     <tr>
                                                        <td>
                                                            <asp:Label ID="Label7" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Employee %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="ddlEmployee" AutoPostBack="true" AllowCustomText="true" AccessKey="C" CloseDropDownOnBlur="true"
                                                                Filter="Contains" EmptyMessage="<%$ Resources:Resource, Select %>" IsCaseSensitive="false"
                                                                MarkFirstMatch="true" Width="260px" runat="server" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>

                                                   <%-- <tr>
                                                        <td>
                                                            <asp:Label ID="lblEmpNumber" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtNewEmployeeNumber" Width="80px" AutoPostBack="true"
                                                                OnTextChanged="txtNewEmployeeNumber_TextChanged" CssClass="csstxtbox"></asp:TextBox>
                                                            <asp:TextBox ID="txtNewEmployeeName" Width="120px" Enabled="false" runat="server"
                                                                CssClass="csstxtboxReadonly"></asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNewShift" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ShiftCode %>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlNewShift" Width="120px" runat="server" CssClass="cssDropDown">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSwappedBy" runat="server" CssClass="csslabel" Text="Swapped By"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rbSelf" runat="server" Text="Self" GroupName="SwappedBy" Checked="true" />
                                                            <asp:RadioButton ID="rbManager" runat="server" Text="Manager" GroupName="SwappedBy" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </Ajax:UpdatePanel>
                                    </ContentTemplate>
                                </AjaxToolKit:TabPanel>
                            </AjaxToolKit:TabContainer>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <table>
                                <tr>
                                    <td colspan="8" align="center">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="cssButton" />
                                    </td>
                                    <%-- <td>
                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="cssButton" />
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblErrorMsg" EnableViewState="false" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
   <%-- <script language="javascript" type="text/javascript">

        window.onbeforeunload = CallParentWindowFunction;
        function CallParentWindowFunction() {
            if (window.opener != null) {
                //   window.opener.ParentWindowFunction1();
            }
        }
      
    </script>--%>
</asp:Content>
