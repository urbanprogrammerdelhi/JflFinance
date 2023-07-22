<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Rpt_HR.aspx.cs" Inherits="HRManagement_Rpt_HR" Title="<%$Resources:Resource,AppTitle %>" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" Width="800px" GroupingText="HR Employee Reports" runat="server">
        <table width="600px" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 210px" align="right">
                    <asp:Label ID="lblReportType" runat="server" Text="<%$Resources:Resource,Reports %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td style="width: 400px" align="left">
                    <asp:DropDownList Width="300px" ID="ddlReportName" runat="server" CssClass="cssDropDown"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblHrLocation" runat="server" Text="<%$Resources:Resource,HrLocation %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                        Width="300px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblBranch" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlBranch" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                        Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LblCalCode" runat="server" Text="<%$Resources:Resource,LeaveCalendarCode %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlCalcode" runat="server" CssClass="cssDropDown" Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblLeaveType" runat="server" Text="<%$Resources:Resource,LeaveType %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlleaveType" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                        Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblEmpCode" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtEmpCode" runat="server" CssClass="csstxtbox">
     
                    </asp:TextBox>
                    <asp:ImageButton ID="ImgbtnSearchFromEmp" Height="18px" Width="16px" ImageUrl="../Images/icosearch.gif"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:Label ID="lblIdType" runat="server" Text="<%$ Resources:Resource, IDType %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <div id="DivEmpId" runat="server">
                        <asp:DropDownList ID="ddlID" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                            Width="180px">
                        </asp:DropDownList>
                        <br>
                        <asp:RadioButton ID="radExp" runat="server" GroupName="EmpID" Checked="true" />
                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, IDExpiry %>"
                            CssClass="cssLable"></asp:Label>
                        <asp:RadioButton ID="radIssue" runat="server" GroupName="EmpID" />
                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, IDIssue %>" CssClass="cssLable"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:Label ID="lblIdTypekam" runat="server" Text="<%$ Resources:Resource, IDType %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <div id="DivEmpIdkam" runat="server">
                        <asp:DropDownList ID="ddlIDkam" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                            Width="180px">
                        </asp:DropDownList>
                        <br>
                        <asp:RadioButton ID="raddata1" runat="server" GroupName="EmpIDkam" Checked="true" />
                        <asp:Label ID="Labelkam1" runat="server" Text="<%$ Resources:Resource, DataEnter %>"
                            CssClass="cssLable"></asp:Label>
                        <asp:RadioButton ID="raddata2" runat="server" GroupName="EmpIDkam" />
                        <asp:Label ID="Labelkam2" runat="server" Text="<%$ Resources:Resource, DataNotEnter %>"
                            CssClass="cssLable"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblDesignation" runat="server" Text="<%$Resources:Resource,Designation %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList Width="180px" ID="ddlDesignation" runat="server" CssClass="cssDropDown">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblCategory" runat="server" Text="<%$Resources:Resource,Category %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList Width="120px" ID="DDLCategory" runat="server" CssClass="cssDropDown">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblGender" runat="server" Text="<%$Resources:Resource,Gender %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList Width="120px" ID="ddlEmployeeGender" runat="server" CssClass="cssDropDown">
                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Resource,Male %>" Value="M"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Resource,Female %>" Value="F"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblNationality" runat="server" Text="<%$Resources:Resource,Nationality %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList Width="120px" ID="ddlNationality" runat="server" CssClass="cssDropDown">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblArea" runat="server" Text="<%$Resources:Resource,Area %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList Width="120px" ID="ddlAreaID" runat="server" CssClass="cssDropDown">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblEmpStatus" runat="server" Text="Employment Status" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList Width="120px" ID="ddlEmployeeStatus" runat="server" CssClass="cssDropDown">
                        <asp:ListItem Text="<%$Resources:Resource,All %>" Value="All"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Resource,Active %>" Value="Active"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Resource,Resigned %>" Value="Resigned"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Resource,Terminated %>" Value="Terminated"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblYear" runat="server" Text="<%$ Resources:Resource, Year %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtYear" runat="server" CssClass="csstxtbox" Width="90px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblRetirementAge" runat="server" Text="<%$ Resources:Resource, RetirementAge %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRtAge" runat="server" Text="" CssClass="csstxtbox" Width="90px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblFromDate" runat="server" Text="<%$Resources:Resource,FromDate %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"></asp:TextBox>
                    <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                    </AjaxToolKit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblToDate" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"></asp:TextBox>
                    <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                    </AjaxToolKit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblEmploymentStatus" runat="server" Text="Employment Status" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList Width="120px" ID="ddlEmploymentStatus" runat="server" CssClass="cssDropDown">
                        <asp:ListItem Text="<%$Resources:Resource,Hire %>" Value="H" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Resource,Resigned %>" Value="R"></asp:ListItem>
                        <%-- <asp:ListItem Text="<%$Resources:Resource,Resigned %>" Value="Resigned"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,Terminated %>" Value="Terminated"></asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="PanelDivision1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label23" runat="server" Text="<%$ Resources:Resource, HrLocation %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddlDivision1" runat="server" Width="150px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlDivision1_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="ddlDivisionName" runat="server" Width="350px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlDivisionName_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelBranch1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label24" runat="server" Text="<%$ Resources:Resource, Branch %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddlBranch1" runat="server" Width="150px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlBranch1_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="ddlBranchName" runat="server" Width="350px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlBranchName_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAreaIncharge" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblAreaIncharge" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaIncharge %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddlAreaInchargeCode" runat="server" Width="150px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaInchargeCode_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="ddlAreaInchargeName" runat="server" Width="350px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaInchargeName_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAreaID1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label20" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaID %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddlAreaID1" runat="server" Width="150px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaID1_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="ddlAreaName" runat="server" Width="350px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaName_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelEmployee1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label25" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddlEmployeeNumber1" runat="server" Width="150px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlEmployeeNumber1_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="ddlEmployeeName" runat="server" Width="350px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlEmployeeName_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlTraining" Width="800px" BorderWidth="0px">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label CssClass="cssLable" ID="lblTraining" runat="server" Text="<%$Resources:Resource,Training %>"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="ddlTraining" runat="server" Width="250px" MaxHeight="350px"
                                        Filter="StartsWith">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="PnlLang" Width="800px" BorderWidth="0px">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label CssClass="cssLable" ID="Label26" runat="server" Text="<%$Resources:Resource,Language %>"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="DdlLanguage" runat="server" Width="250px" MaxHeight="350px"
                                        Filter="StartsWith">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="PnlIdType" Width="800px" BorderWidth="0px">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label CssClass="cssLable" ID="Label27" runat="server" Text="<%$Resources:Resource,IDType %>"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="DdlIdType" runat="server" Width="250px" MaxHeight="350px"
                                        Filter="StartsWith">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="PnlQual" Width="800px" BorderWidth="0px">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label CssClass="cssLable" ID="Label28" runat="server" Text="<%$Resources:Resource,Qualification %>"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="DdlQual" runat="server" Width="250px" MaxHeight="350px"
                                        Filter="StartsWith">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="PnlConstraint" Width="800px" BorderWidth="0px">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label CssClass="cssLable" ID="Label29" runat="server" Text="<%$Resources:Resource,Constraint %>"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="DdlConstraint" runat="server" Width="250px" MaxHeight="350px"
                                        Filter="StartsWith">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="PnlSkill" Width="800px" BorderWidth="0px">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label CssClass="cssLable" ID="Label30" runat="server" Text="<%$Resources:Resource,Skills %>"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="DdlSkill" runat="server" Width="250px" MaxHeight="350px"
                                        Filter="StartsWith">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                        CssClass="cssButton" OnClick="btnViewReport_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        function OnClientDropDownClosedHandler(sender, eventArgs) {

            var ddlEmp = eventArgs.get_domEvent();

            var EmpVal = sender.get_value();
            if (EmpVal == "") {
                sender.trackChanges();
                sender.get_items().getItem(0).select();
                sender.commitChanges();
            }
        }
    </script>
</asp:Content>
