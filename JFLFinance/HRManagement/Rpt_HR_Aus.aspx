<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Rpt_HR_Aus.aspx.cs" Inherits="HRManagement_Rpt_HR_Aus" Title="<%$Resources:Resource,AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" Width="500px" GroupingText="HR Employee Reports" runat="server">
       <%-- <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
            <ContentTemplate>--%>
                <table width="100%" cellpadding="1px" cellspacing="0px">
                    <tr>
                        <td style="width: 40%" align="right">
                            <asp:Label ID="lblReportType" runat="server" Text="<%$Resources:Resource,Reports %>"
                                CssClass="cssLable"></asp:Label>
                        </td>
                        <td style="width: 60%" align="left">
                            <asp:DropDownList Width="300px" ID="ddlReportName" runat="server" CssClass="cssDropDown"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
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
                            <asp:Label ID="lblLeaveType" runat="server" Text="<%$Resources:Resource,LeaveType %>" CssClass="cssLable"></asp:Label>
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
                            <asp:Label ID="lblArea" runat="server" Text="<%$Resources:Resource,Area %>"
                                CssClass="cssLable"></asp:Label>
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
                                <asp:ListItem Text="<%$Resources:Resource,Hire %>" Value="H" Selected=True></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,Resigned %>" Value="R"></asp:ListItem>
                               <%-- <asp:ListItem Text="<%$Resources:Resource,Resigned %>" Value="Resigned"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,Terminated %>" Value="Terminated"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                </table>
         <%--   </ContentTemplate>
        </Ajax:UpdatePanel>--%>
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
</asp:Content>
