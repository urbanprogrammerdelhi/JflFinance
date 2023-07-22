<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeWiseAdvanceSearch.aspx.cs"
    Inherits="Search_EmployeeWiseAdvanceSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ OutputCache Location="None" VaryByParam="None" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
    <script language="javascript" src="../javaScript/SearchAjax.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../PageJS/EmployeeWiseAdvancedSearch.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="script" runat="server">
        </asp:ScriptManager>
        <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="panel1" runat="server" GroupingText="<%$ Resources:Resource, AssignmentDetails %>"
                    Width="100%">
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px">
                                <asp:Label ID="lblClientCode" Width="100%" runat="server" CssClass="csstxtboxReadonly"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px">
                                <asp:Label ID="lblClientName" Width="100%" runat="server" CssClass="csstxtboxReadonly"></asp:Label>
                            </td>
                            
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, AsmtCode %>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px">
                                <asp:Label ID="lblAsmtCode" Width="100%" runat="server" CssClass="csstxtboxReadonly"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, AsmtAddress %>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px">
                                <asp:Label ID="lblAsmtName" Width="100%" runat="server" CssClass="csstxtboxReadonly"></asp:Label>
                            </td>
                             <td align="right">
                                <asp:Label ID="Label5" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, Post %>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px">
                                <asp:Label ID="lblPostName" Width="100%" runat="server" CssClass="csstxtboxReadonly"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblNoOfMonths" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, NoOfMonths %>"></asp:Label>
                            </td>
                            <td align="left" style="width: 250px">
                                <asp:TextBox ID = "txtNoOfMonths" Width="100%" runat="server" MaxLength="3" CssClass="csstxtbox"></asp:TextBox>
                                <asp:RangeValidator ID="rvNoOfMonths" runat = "server" ControlToValidate = "txtNoOfMonths" MinimumValue ="1" MaximumValue = "999"></asp:RangeValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvEmployeeList" runat="server" CssClass="GridViewStyle" ShowFooter="false"
                                AllowPaging="true" PageSize="10" ShowHeader="true" CellPadding="1" GridLines="None"
                                OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnSorting="gvEmployeeList_Sorting"
                                OnRowCreated="gvEmployeeList_RowCreated" AutoGenerateColumns="False" OnRowDataBound="gvEmployeeList_RowDataBound"
                                AllowSorting="True">
                                <RowStyle CssClass="GridViewRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, SerialNumber %>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, Available %>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpAvailability" CssClass="cssLabel" Style="text-align: center;
                                                cursor: hand;" runat="server" Text="&nbsp;&nbsp;&nbsp;?&nbsp;&nbsp;" ToolTip="<%$ Resources:Resource, Available %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, Preferred %>" SortExpression="EmployeePreferredSiteType">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfpreferred" runat="server" Value='<%# Eval("EmployeePreferredSiteType") %>' />
                                            <asp:CheckBox ID="cbPreferred" CssClass="cssCheckBox" AutoPostBack="true" OnCheckedChanged="cbPreferred_CheckedChanged"
                                                runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, BackUp %>" SortExpression="EmployeeBackUpSiteType">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfBackup" runat="server" Value='<%# Eval("EmployeeBackUpSiteType") %>' />
                                            <asp:CheckBox ID="cbBackup" AutoPostBack="true" OnCheckedChanged="cbBackup_CheckedChanged"
                                                CssClass="cssCheckBox" runat="server" />
                                            <asp:HiddenField ID="hfEmployeeSiteType" runat="server" Value='<%# Eval("EmployeeSiteType") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, WorkHistory %>" SortExpression="WorkHistory">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfWorkHistory" runat="server" Value='<%# Eval("WorkHistory") %>' />
                                            <asp:CheckBox ID="cbWorkHistory" CssClass="cssCheckBox" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, EmployeeNumber %>" SortExpression="EmployeeNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpNo" CssClass="cssLabel" runat="server" Text='<%# Eval("EmployeeNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, Name %>" SortExpression="EmployeeName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpName" CssClass="cssLabel" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, Designation %>" SortExpression="DesignationDesc">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpDesg" CssClass="cssLabel" runat="server" Text='<%# Eval("DesignationDesc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, PayRate %>" SortExpression="PayRate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmppayRate" CssClass="cssLabel" runat="server" Text='<%# Eval("PayRate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, DateOfJoining %>" SortExpression="DateOfJoining">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateOfjoin" CssClass="cssLabel" runat="server" Text='<%# Eval("DateOfJoining") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, DateOfBirth %>" SortExpression="DateOfBirth">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateOfBirth" CssClass="cssLabel" runat="server" Text='<%# Eval("DateOfBirth") %>'
                                                Width="110px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, PrevTotalExp %>" SortExpression="Experience">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExperience" CssClass="cssLabel" runat="server" Text='<%# Eval("Experience") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, ContractDays %>" SortExpression="ContractDays">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContractDays" CssClass="cssLabel" runat="server" Text='<%# Eval("ContractDays") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, Gender %>" SortExpression="Gender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGender" CssClass="cssLabel" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, MandatorySkillMatch %>" SortExpression="MandatoryCheckMatch">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMandatorySkillMatch" CssClass="cssLabel" OnClick="lbMandatorySkillMatch_Click"
                                                runat="server" Text='<%# Eval("MandatoryCheckMatch") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, RecommendedSkillMatch %>"
                                        SortExpression="RecommendedCheckMatch">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbRecommendedSkillMatch" CssClass="cssLabel" OnClick="lbRecommendedSkillMatch_Click"
                                                runat="server" Text='<%# Eval("RecommendedCheckMatch") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource, InformativeSkillMatch %>"
                                        SortExpression="InformativeCheckMatch">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbInformativeSkillMatch" CssClass="cssLabel" OnClick="lbInformativeSkillMatch_Click"
                                                runat="server" Text='<%# Eval("InformativeCheckMatch") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="<%$ Resources:Resource, EmployeePreferances %>" SortExpression="PrefDays">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrefDays" CssClass="cssLabel" runat="server" Text='<%# Eval("PrefDays") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>

              
                <table>
                    <tr>
                        <td>
                            <asp:HiddenField ID="HFStatus" runat="server" />
                            <asp:HiddenField ID="HFSortExpression" runat="server" />
                            <asp:Button ID="btnDefaultSearch" runat="server" Text="<%$ Resources:Resource, DefaultSearch %>"
                                OnClick="btnDefaultSearch_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnAllEmployee" runat="server" Text="<%$ Resources:Resource, AllEmployee %>"
                                OnClick="btnAllEmployee_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnZipCodeSearch" runat="server" Text="Zip Code Search" OnClick="btnZipCodeSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltronLeave" runat="server" Text="<%$ Resources:Resource, OnLeave %>"></asp:Literal>
                            <img alt="Under Post" style="width: 10px; height: 10px; background-color: Yellow"
                                src='../Images/spacer.gif'></img>
                            <asp:Literal ID="ltrScheduled" runat="server" Text="<%$ Resources:Resource, Scheduled %>"></asp:Literal>
                            <img alt="Over Post" style="width: 10px; height: 10px; background-color: Red" src='../Images/spacer.gif'></img>
                            <asp:Literal ID="ltrAvailable" runat="server" Text="<%$ Resources:Resource, Available %>"></asp:Literal>
                            <img alt="Fulfilled" style="width: 10px; height: 10px; background-color: Green" src='../Images/spacer.gif'></img>
                            <asp:Literal ID="ltrWeekOff" runat="server" Text="<%$ Resources:Resource, WeekOff %>"></asp:Literal>
                            <img alt="Default" style="width: 10px; height: 10px; background-color: Gray" src='../Images/spacer.gif'></img>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div id="empAvailabitiltStatus" style="width: 680px; height: 50px; border: 0; border-style: solid">
                                &nbsp;
                            </div>
                        </td>
                    </tr>
                </table>
                
                  <table>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel2" BackColor="white" ScrollBars="Auto" CssClass="ScrollBar" runat="server"
                                Height="200" Width="600" Style="display: none;">
                                <asp:Button ID="Button1" runat="server" Style="display: none" />
                                <AjaxToolKit:ModalPopupExtender ID="MPEPopUp" runat="server" TargetControlID="Button1"
                                    PopupControlID="Panel2" BackgroundCssClass="modalBackground" />
                                <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <div style="width: 550px;">
                                                        <div class="squarebox">
                                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                                <div style="float: left; width: 520px">
                                                                    <tt style="text-align: center;">
                                                                        <asp:Label ID="Label15" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,Constraint %>"></asp:Label></tt></div>
                                                            </div>
                                                            <div class="squareboxcontent">
                                                                <asp:GridView ID="gvSkills" Width="100%" CssClass="GridViewStyle" runat="server"
                                                                    CellPadding="1" PageSize="8" AllowPaging="false">
                                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                </asp:GridView>
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
               
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel6" BackColor="white" ScrollBars="Auto" CssClass="ScrollBar" runat="server"
                                Height="200" Width="600" Style="display: none;">
                                <asp:Button ID="Button3" runat="server" Style="display: none" />
                                <AjaxToolKit:ModalPopupExtender ID="MPEZipCode" runat="server" TargetControlID="Button3"
                                    PopupControlID="Panel6" BackgroundCssClass="modalBackground" />
                                <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnZipSearch" runat="server" Text="<%$Resources:Resource, Search%>"
                                                        CssClass="cssButton" OnClick="btnZipSearch_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnClose" runat="server" Text="<%$Resources:Resource, Close%>" CssClass="cssButton"
                                                        OnClick="btnClose_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </Ajax:UpdatePanel>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </Ajax:UpdatePanel>
    </div>
    </form>
</body>
</html>
