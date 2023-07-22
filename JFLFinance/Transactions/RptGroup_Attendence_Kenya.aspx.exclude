<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_Attendence_Kenya.aspx.cs" Inherits="Transactions_RptGroup_Attendence_Kenya"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Src="../MS_Control/MultipleSelection.ascx" TagName="MultipleSelection"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="700px" Height="420px" GroupingText="<%$Resources:Resource,Rostering %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <asp:Panel ID="Panel1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,ReportType %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlReportName" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelLocation" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource,HrLocation %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label10" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="4">
                                    <asp:DropDownList ID="ddlBranch" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                                        Width="350px">
                                    </asp:DropDownList>
                                    <%--<uc1:MultipleSelection ID="msddlBranch" runat="server" />--%>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelDesignation" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label11" runat="server" Text="<%$Resources:Resource,Designation %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="cssDropDown" Width="350">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAreaID" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblArea" runat="server" Text="<%$Resources:Resource,Area %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList Width="120px" ID="ddlAreaID" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelEmployee" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,EmployeeNumber %> "
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <Ajax:UpdatePanel runat="server" ID="UPEmployees" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlEmployeeNumber" runat="server" CssClass="cssDropDown" Width="328">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImgBtnEmployees" runat="server" ToolTip="Refresh Employees"
                                                ImageUrl="~/Images/Reset.gif" OnClick="RefreshEmpList_Click" />
                                        </ContentTemplate>
                                    </Ajax:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PnlCategory" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblCategory" runat="server" Text="<%$Resources:Resource,Category %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList Width="120px" ID="DDLCategory" runat="server" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelClientCode" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,ClientName %> "
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="cssDropDown" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged" Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelRadioButtonForUnitregister" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                </td>
                                <td align="left" colspan="3">
                                    <asp:RadioButton ID="rdoAssigmentWise" Checked="true" GroupName="G1" runat="server"
                                        Text="<%$Resources:Resource,AssignmentWise %>" />
                                    <asp:RadioButton ID="rdoPostWise" GroupName="G1" runat="server" Text="<%$Resources:Resource,PostWise %>" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAsmtCode" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label8" runat="server" Text="<%$Resources:Resource,Assignment %> "
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlAsmtCode" runat="server" CssClass="cssDropDown" AutoPostBack="false"
                                        Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelDates" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                    <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                    <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelInvoiceType" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label12" runat="server" Text="<%$Resources:Resource,InvoiceType %> "
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlInvoiceType" Width="152px" CssClass="cssDropDown" runat="server">
                                        <asp:ListItem Text="<%$Resources:Resource,ALL%>" Value="ALL"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource,InvTypFixed%>" Value="FIXED"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource,InvTypActual%>" Value="ACTUAL"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource,InvTypActualDaysInMonth%>" Value="ACTUAL DAYS IN MONTH"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource,InvTypAsPerSchedule%>" Value="AS PER SCHEDULE"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelVariation" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,Variation %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlVariation" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelMonth" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblMonth" runat="server" Text="<%$Resources:Resource,Month  %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMonth" Width="350px" runat="server" CssClass="cssDropDownSmall"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                        <asp:ListItem Text="<%$ Resources:Resource, January%>" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,February%>" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,March%>" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,April%>" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,May%>" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,June%>" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,July%>" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,August%>" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,September%>" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,October%>" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,November%>" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,December%>" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelWeek" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:HiddenField ID="HFFromDate" runat="server" />
                                    <asp:HiddenField ID="HFToDate" runat="server" />
                                    <asp:HiddenField ID="HFMaxDate" runat="server" />
                                    <asp:Label ID="Label14" runat="server" Text="<%$Resources:Resource,Week  %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlWeek" AutoPostBack="true" CssClass="cssDropDownSmall" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged"
                                        Width="30%" runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox Width="30%" MaxLength="4" CssClass="csstxtboxSmall" ID="txtYear" runat="server"
                                        AutoPostBack="true" OnKeyUp="javascript:validateNumeric(this);" OnTextChanged="txtYear_TextChanged">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelShift" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtStartDate" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:HyperLink ID="ImgStartDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtStartDate" PopupButtonID="ImgStartDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblDayStartTime" runat="server" Text="Day Shift Starts From" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDayStartTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                        runat="server" Text="07:00" />
                                    <asp:Label ID="lblDayEndTime" runat="server" Text="Ends at" CssClass="cssLable"></asp:Label>
                                    <asp:TextBox ID="txtDayEndTime" MaxLength="5" CssClass="csstxtbox" Width="50px" runat="server"
                                        Text="14:59" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblNightStartTime" runat="server" Text="Night Shift Starts From" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNightStartTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                        runat="server" Text="23:01" />
                                    <asp:Label ID="lblNightEndTime" runat="server" Text="Ends at" CssClass="cssLable"></asp:Label>
                                    <asp:TextBox ID="txtNightEndTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                        runat="server" Text="06:59" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblSwingStartTime" runat="server" Text="Swing Shift Starts From" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSwingStartTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                        runat="server" Text="15:00" />
                                    <asp:Label ID="lblSwingEndTime" runat="server" Text="Ends at" CssClass="cssLable"></asp:Label>
                                    <asp:TextBox ID="txtSwingEndTime" MaxLength="5" CssClass="csstxtbox" Width="50px"
                                        runat="server" Text="23:00" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelCheckBox" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblChkPresent" runat="server"
                                        Text="<%$ Resources:Resource,Present%>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkPresent" runat="server" Checked />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblChkAbsent" runat="server"
                                        Text="<%$ Resources:Resource,Absent%>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkAbsent" runat="server" Checked />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblChkLeave" runat="server"
                                        Text="<%$ Resources:Resource,Leave%>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkLeave" runat="server" Checked />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblChkWeekOff" runat="server"
                                        Text="<%$ Resources:Resource,WeeklyOff%>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkWeekOff" runat="server" Checked />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelddlReportType" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ReportType %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlReportStatus" Width="350" runat="server" CssClass="cssDropDown">
                                        <asp:ListItem Value="Summary" Text="<%$Resources:Resource,Summary %>" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="Detailed" Text="<%$Resources:Resource,Detailed %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelddlReportType1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label13" runat="server" Text="<%$Resources:Resource,ReportType %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlReportStatus1" Width="350" runat="server" CssClass="cssDropDown">
                                        <asp:ListItem Value="Summary" Text="<%$Resources:Resource,Clientwise %>"></asp:ListItem>
                                        <asp:ListItem Value="Detailed" Text="<%$Resources:Resource,Asgnwise %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PnlReportOption" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="rptOption" runat="server" Text="<%$Resources:Resource,ReportType %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlReportOption" Width="350" runat="server" CssClass="cssDropDown">
                                        <asp:ListItem Value="ACT" Text="<%$Resources:Resource,Actual %>"></asp:ListItem>
                                        <asp:ListItem Value="SCH" Text="<%$Resources:Resource,Scheduled %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="200px">
                                </td>
                                <td align="left" width="400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" OnClientClick="disableButton(this);" />
                                    <asp:Label ID="lblWait" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function disableButton(obj) {
            obj.style.display = "none";
            document.getElementById('<%= lblWait.ClientID %>').innerText = "Please wait.....";

        }
    
    </script>
</asp:Content>
