<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusinessRulesAus.aspx.cs"
    Inherits="Masters_BusinessRulesAus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .popup
        {
            border: solid 1px #333;
            font-family: Tahoma;
            font-size: 12px;
            display: none;
            position: absolute;
            width: 300px;
            z-index: 60;
        }
        .popuptitle
        {
            background: #6EB6D5;
            color: white;
            font-weight: bold;
            height: 15px;
            padding: 5px;
        }
        .popupbody
        {
            background: #FCFDFD;
            padding: 5px;
            text-align: center;
        }
        #DivJobBreakUp
        {
            top: 100px;
            left: 50px;
        }
        #popup2
        {
            top: 100px;
            left: 400px;
        }
        .TableColor
        {
            background-color: #EFF7FF;
            border: 1px solid #96C2F1;
        }
        .resizeDiv
        {
            width: 700px;
            height: 200px;
            background-color: #EFF7FF;
            border: 1px solid #B7CEEC;
            position: absolute;
            left: 100px;
            top: 100px;
        }
        .resizeDiv h5
        {
            background-color: #B2D3F5;
            padding: 5px;
            margin: 1px;
        }
        .style1
        {
            width: 154px;
        }
        .style2
        {
            width: 114px;
        }
        .style3
        {
            width: 777px;
        }
    </style>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <Ajax:ScriptManager ID="script" runat="server">
        <Services>
        </Services>
    </Ajax:ScriptManager>
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBRCode" Text="Business Rule Code" runat="server" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBusinessRule" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblBusinessRuleDesc" Text="Business Rule Description" runat="server"
                                        CssClass="cssLabel"></asp:Label>
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="txtBusinessRuleDesc" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lblSelectingBR" Text="Select Buisness Rule" runat="server" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBR_SelectedIndexChanged"
                                        Width="128px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl" Text="<%$ Resources:Resource, Company %>"  runat="server" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList Width="400px" ID="ddlCompany" runat="server" CssClass="cssDropDown"
                                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChange" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDivision" Text="<%$ Resources:Resource, HrLocation %>"  runat="server" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList Width="400px" ID="ddlDivision" runat="server" CssClass="cssDropDown"
                                        OnSelectedIndexChanged="ddlDivision_SelectedIndexChange" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBranch" Text="<%$ Resources:Resource, Location %>"  runat="server" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList Width="400px" ID="ddlBranch" runat="server" CssClass="cssDropDown"
                                        OnSelectedIndexChanged="ddlBranch_SelectedIndexChange" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblArea" Text="<%$ Resources:Resource, AreaID %>"  runat="server" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList Width="400px" ID="ddlArea" runat="server" CssClass="cssDropDown"
                                        OnSelectedIndexChanged="ddlArea_SelectedIndexChange" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblClient" Text="<%$ Resources:Resource, ClientName %>"  runat="server" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList Width="400px" ID="ddlClient" runat="server" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnSave" Text="<%$ Resources:Resource, Save %>" runat="server" CssClass="cssButton" OnClick="btnSave_Click" />
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:Resource, Delete %>"  CssClass="cssButton" 
                                        onclick="btnClose_Click" />
                                </td>
                                 <td colspan="2">
                                    <asp:Label ID="lblerror" runat="server" Width="250px" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <Ajax:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="TabLeave"
                            Width="950px" Height="250px" ActiveTabIndex="0" Visible="false">
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="PayConstraint" runat="server"
                                HeaderText="Pay Period">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rbMonthly" runat="server" Text="Monthly" GroupName="PType" OnCheckedChanged="rbMonthly_CheckedChange"
                                                    AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbFortnightly" runat="server" Text="Fortnightly" GroupName="PType"
                                                    OnCheckedChanged="rbFortNightly_CheckedChange" AutoPostBack="true" />
                                            </td>
                                            <td colspan="3">
                                                <asp:RadioButton ID="rbWeekly" runat="server" Text="Weekly" GroupName="PType" OnCheckedChanged="rbWeekly_CheckedChange"
                                                    AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPayPeriod" runat="server" Text="Pay Period" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox ID="txtPayPeriod" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date" CssClass="cssLabel"></asp:Label>
                                                <asp:Label ID="lblStartDay" runat="server" Text="Start Day" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                <asp:DropDownList ID="ddlStartDay" runat="server" CssClass="cssDropDown">
                                                    <asp:ListItem Text="Sunday" Value="Sun"></asp:ListItem>
                                                    <asp:ListItem Text="Monday" Value="Mon"></asp:ListItem>
                                                    <asp:ListItem Text="Tuesday" Value="Tue"></asp:ListItem>
                                                    <asp:ListItem Text="Wednesday" Value="Wed"></asp:ListItem>
                                                    <asp:ListItem Text="Thursday" Value="Thu"></asp:ListItem>
                                                    <asp:ListItem Text="Friday" Value="Fri"></asp:ListItem>
                                                    <asp:ListItem Text="Saturday" Value="Sat"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="imgStartDate" Style="vertical-align: middle" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="calStartDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtStartDate" PopupButtonID="imgStartDate" Enabled="True">
                                                </AjaxToolKit:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFirstDate" runat="server" CssClass="csslabel" Text="First Pay Date"></asp:Label>
                                            </td>
                                            <td>
                                                
                                                <asp:TextBox ID="txtFirstDate" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                <asp:ImageButton ID="imgFirstDate" Style="vertical-align: middle" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="calFirstDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtFirstDate" PopupButtonID="imgFirstDate" Enabled="True">
                                                </AjaxToolKit:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnGenratePayPeriods" runat="server" Text="Genrate Pay Periods for 1 Year" OnClick="btnGenratePayPeriod_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblEndDate" runat="server" Text="End Date" CssClass="cssLabel"></asp:Label>
                                                <asp:Label ID="lblEndDay" runat="server" Text="End Day" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                <asp:DropDownList ID="ddlEndDay" runat="server" CssClass="cssDropDown">
                                                    <asp:ListItem Text="Sunday" Value="Sun"></asp:ListItem>
                                                    <asp:ListItem Text="Monday" Value="Mon"></asp:ListItem>
                                                    <asp:ListItem Text="Tuesday" Value="Tue"></asp:ListItem>
                                                    <asp:ListItem Text="Wednesday" Value="Wed"></asp:ListItem>
                                                    <asp:ListItem Text="Thursday" Value="Thu"></asp:ListItem>
                                                    <asp:ListItem Text="Friday" Value="Fri"></asp:ListItem>
                                                    <asp:ListItem Text="Saturday" Value="Sat"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="imgEndDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif">
                                                </asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="calEndDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEndDate" PopupButtonID="imgEndDate" Enabled="True">
                                                </AjaxToolKit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Button ID="btnSavePayPeriod" Text="Save" runat="server" CssClass="cssButton"
                                                    OnClick="btnSavePayPeriod_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="tbHoursDistribution" runat="server"
                                HeaderText="Hours Distribution">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBasedOnSchedule" Text="Based On Schedule" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMinRequiredHrs" Text="Min Required Hours" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMaxPermittedHrs" Text="Max Permitted Hours" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDaily" Text="Daily" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkDaily" runat="server" CssClass="cssCheckBox" OnCheckedChanged="chkDaily_CheckedChanged" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMinHrsRqDaily" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMaxHrsPrDaily" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblWeekly" Text="Weekly" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkWeekly" runat="server" CssClass="cssCheckBox" OnCheckedChanged="chkWeekly_CheckedChanged" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMinHrsRqWeekly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMaxHrsPrWeekly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFortNightly" Text="Fortnightly" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkFortNightly" runat="server" CssClass="cssCheckBox" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMinHrsRqFortNightly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMaxHrsPrFortNightly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMonthly" Text="Monthly" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkMonthly" runat="server" CssClass="cssCheckBox" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMinHrsRqMonthly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMaxHrsPrMonthly" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLeavHrs" Text="Leave Hours" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkLeaveHrs" runat="server" CssClass="cssCheckBox" />
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtMinHrsRqLeaveHrs" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAbesnteesimHrs" Text="Absentism Hours" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkAbesnteesimHrs" runat="server" CssClass="cssCheckBox" />
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtMinHrsRqAbesnteesimHrs" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNormalDays" Text="Normal Days" runat="server" CssClass="cssLabel"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chkSunday" runat="server" CssClass="cssCheckBox" Text="Sun" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkMonday" runat="server" CssClass="cssCheckBox" Text="Mon" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkTuesday" runat="server" CssClass="cssCheckBox" Text="Tue" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkWednesday" runat="server" CssClass="cssCheckBox" Text="Wed" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkThursday" runat="server" CssClass="cssCheckBox" Text="Thu" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkFriday" runat="server" CssClass="cssCheckBox" Text="Fri" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkSaturday" runat="server" CssClass="cssCheckBox" Text="Sat" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Button ID="btnSaveHrsDist" Text="Save" runat="server" CssClass="cssButton" OnClick="btnSaveHrsDist_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                            <AjaxToolKit:TabPanel Style="text-align: left;" ID="tbOTDetails" runat="server" HeaderText="OT Details">
                                <ContentTemplate>
                                    <asp:Panel ID="PnlAsmtPost" Width="650px" runat="server" ScrollBars="Vertical" Height="250px"
                                        GroupingText="OT Details">
                                        <asp:GridView ID="gvOTDetails" runat="server" Width="610px" AutoGenerateColumns="False"
                                            CellPadding="1" CssClass="GridViewStyle" GridLines="None" PageSize="6" ShowFooter="True"
                                            OnRowCommand="gvOTDetail_RowCommad" OnRowEditing="gvOTDetail_RowEditing" OnRowCancelingEdit="gvOTDetail_RowCanceling"
                                            OnRowDeleting="gvOTDetail_Deleteing" OnRowUpdating="gvOTDetail_RowUpdating">
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblSlno" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSlno" runat="server" CssClass="cssLable" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle Width="50px" />
                                                    <HeaderStyle Width="50px" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblOTCode" runat="server" CssClass="cssLabelHeader" Text="OT Code"
                                                            Width="90px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtOTCode" runat="server" CssClass="csstxtbox" Text='<%# Eval("OTCode")%>'></asp:TextBox>
                                                        <asp:HiddenField ID="hfOTDetailAutoID" runat="server" Value='<%# Eval("OTDetailAutoID")%>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtOTCode" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOTCode" runat="server" CssClass="cssLabel" Text='<%# Eval("OTCode")%>'></asp:Label>
                                                        <asp:HiddenField ID="hfOTDetailAutoID" runat="server" Value='<%# Eval("OTDetailAutoID")%>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblOTRate" runat="server" CssClass="cssLabelHeader" Text="OT Rate"
                                                            Width="90px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtOTRate" runat="server" CssClass="csstxtbox" Text='<%# Eval("OTRate")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtOTRate" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOTRate" runat="server" CssClass="cssLabel" Text='<%# Eval("OTRate")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblApplicbleOn" runat="server" CssClass="cssLabelHeader" Text="Applicable On"
                                                            Width="60px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlApplicableOn" runat="server" CssClass="cssDropDown">
                                                            <asp:ListItem Text="Normal Days" Value="ND"></asp:ListItem>
                                                            <asp:ListItem Text="Week Off Days" Value="WO"></asp:ListItem>
                                                            <asp:ListItem Text="Public Holiday" Value="PH"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hfApplicableOn" Value='<%# Eval("ApplicableOnValue")%>' runat="server" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlApplicableOn" runat="server" CssClass="cssDropDown">
                                                            <asp:ListItem Text="Normal Days" Value="ND"></asp:ListItem>
                                                            <asp:ListItem Text="Week Off Days" Value="WO"></asp:ListItem>
                                                            <asp:ListItem Text="Public Holiday" Value="PH"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplicbleOn" runat="server" CssClass="cssLabelHeader" Text='<%# Eval("ApplicableOn")%>'
                                                            Width="60px"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHdrAction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Action%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="IMGCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                            ToolTip="<%$ Resources:Resource, Save %>" ValidationGroup="vgCFooter" Height="16px"
                                                            Width="16px" ImageUrl="../Images/AddNew.gif" /><asp:ImageButton ID="ImgbtnReset"
                                                                runat="server" CssClass="cssImgButton" CommandName="Reset" ToolTip="<%$ Resources:Resource, Reset %>"
                                                                Height="15px" Width="15px" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IBEditTran" runat="server" CausesValidation="False" CommandName="Edit"
                                                            CssClass="csslnkButton" ImageUrl="~/Images/Edit.gif" ToolTip="<%$Resources:Resource,Edit %>"
                                                            ValidationGroup="Edit" />
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CommandName="Delete" CssClass="cssImgButton"
                                                            ImageUrl="../Images/Delete.gif" ToolTip="Delete" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="60px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </AjaxToolKit:TabPanel>
                        </AjaxToolKit:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    </form>
</body>
</html>
