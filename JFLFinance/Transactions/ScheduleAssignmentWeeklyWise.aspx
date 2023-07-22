<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ScheduleAssignmentWeeklyWise.aspx.cs"
    MasterPageFile="~/MasterPage/MasterPage.master" Inherits="Transactions_ScheduleAssignmentWeeklyWise" %>
<%@ Register Assembly="DropCheck" Namespace="xMilk" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../../css/WRStyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" >
    </asp:ScriptManager>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table1" width="100%" border="0" cellpadding="3" cellspacing="0" runat="server">
        <tr>
            <td align="left">
                <div id="Div1" runat="server" style="width: 100%;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 100%;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label5" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,ScheduleStatusReport %>"></asp:Label></tt></div>
                        </div>
                        <div id="Div2" class="squareboxcontent" style="text-align: left; width: 100%" runat="server">
                            <table id="Table2" border="0" cellpadding="1" cellspacing="0" style="width: 100%"
                                runat="server">
                                <tr>
                                    <td align="left" style="width: 80px">
                                        <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,Day %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:DropDownList ID="ddlStartDayWeek" runat="server" CssClass="cssDropDown">
                                            <asp:ListItem Selected="False" Text="Monday" Value="Monday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Tuesday" Value="Tuesday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Wednesday" Value="Wednesday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Thrusday" Value="Thrusday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Friday" Value="Friday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Saturday" Value="Saturday"></asp:ListItem>
                                            <asp:ListItem Selected="True" Text="Sunday" Value="Sunday"></asp:ListItem>
                                        </asp:DropDownList>
                                        -
                                        <asp:DropDownList ID="ddlEndDayWeek" runat="server" CssClass="cssDropDown">
                                            <asp:ListItem Selected="False" Text="Monday" Value="Monday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Tuesday" Value="Tuesday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Wednesday" Value="Wednesday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Thrusday" Value="Thrusday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Friday" Value="Friday"></asp:ListItem>
                                            <asp:ListItem Selected="True" Text="Saturday" Value="Saturday"></asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Sunday" Value="Sunday"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 80px">
                                        <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,Month %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:DropDownList runat="server" ID="ddlMonth" CssClass="cssDropDown">
                                            <asp:ListItem Selected="False" Text="January" Value="1">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="Feburary" Value="2">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="March" Value="3">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="April" Value="4">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="May" Value="5">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="June" Value="6">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="July" Value="7">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="August" Value="8">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="September" Value="9">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="October" Value="10">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="November" Value="11">
                                            </asp:ListItem>
                                            <asp:ListItem Selected="False" Text="December" Value="12">
                                            </asp:ListItem>
                                        </asp:DropDownList>
                                      
                                          <asp:TextBox ID="txtYear" runat="server" Width="100px" CssClass="csstxtbox" MaxLength="4"
                                      ></asp:TextBox>
                                    <AjaxToolKit:MaskedEditExtender runat="server" ID="MaskedEditExtender2" TargetControlID="txtyear"
                                        Mask="9999" MaskType="Number" ClearTextOnInvalid="false" InputDirection="LeftToRight" />
                                    <AjaxToolKit:MaskedEditValidator runat="server" ID="MaskedEditValidator" IsValidEmpty="false"
                                     MinimumValue="1900" MaximumValue="9999"  ControlExtender="MaskedEditExtender2" ControlToValidate="txtYear" ErrorMessage="enter valid year"
                                        MaximumrValue='<%# DateTime.Now.Year %>' EmptyValueMessage="Number is required" MinimumValueMessage="Year should be greater than equal to 1900"/>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblBranch" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:DropDownList ID="ddlBranch" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                            OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,Incharge %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:DropDownList ID="ddlInchargeId" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                            OnSelectedIndexChanged="ddlInchargeId_SelectedIndexChanged" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,AreaID %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:DropDownList ID="ddlAreaID" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                            OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label8" runat="server" Text="<%$Resources:Resource,Status %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                            OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="300px">
                                            <asp:ListItem Text="<%$Resources:Resource,ALL %>" Value="ALL"></asp:ListItem>
                                            <asp:ListItem Selected="True" Text="<%$Resources:Resource,Active %>" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="<%$Resources:Resource,InActive %>" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ClientName %> "
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 400px; height: 20px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <cc1:DropCheck ID="ddlClientCode" runat="server" MaxDropDownHeight="200" CssClass="cssDropDown"
                                                        TransitionalMode="true" Width="290px" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                                    </cc1:DropCheck>
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnGo" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Go %>"
                                                        Width="30px" OnClick="btnGo_Click" />
                                                    <asp:HiddenField ID="hdnClientCount" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 21px">
                                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,Asmt %> " CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" style="height: 21px" colspan="2">
                                        <table>
                                            <tr>
                                                <td>
                                                    <cc1:DropCheck ID="ddlAsmtCode" runat="server" MaxDropDownHeight="200" CssClass="cssDropDown"
                                                        Enabled="false" TransitionalMode="true" Width="290px" OnSelectedIndexChanged="ddlAsmtCode_SelectedIndexChanged">
                                                    </cc1:DropCheck>
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnGoAsmt" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Go %>"
                                                        Width="30px" OnClick="btnGoAsmt_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<asp:DropDownList ID="ddlAsmtCode" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                            Enabled="false" Width="300px">
                                        </asp:DropDownList>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" CssClass="cssButton"
                                            Text="<%$ Resources:Resource, Proceed %>" />
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:Button ID="btnExport" runat="server" CssClass="cssButton" OnClick="btnExport_Click"
                                            Text="Export" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
                                            <Triggers>
                                                <Ajax:PostBackTrigger ControlID="btnExport" />
                                                <asp:PostBackTrigger ControlID="btnExport"></asp:PostBackTrigger>
                                                <asp:PostBackTrigger ControlID="btnExport"></asp:PostBackTrigger>
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:Panel ID="panel1" runat="server" GroupingText="" Width="940px">
                                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                    <br></br>
                                                    <asp:GridView ID="gvSummary" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                                                        CellPadding="0" CssClass="GridViewStyle" GridLines="Both" ShowFooter="false"
                                                        ShowHeader="false" Visible="true" Width="600px">
                                                        <%--<ItemStyle CssClass="GridViewRowStyle"/>
                                                        <SelectedItemStyle CssClass="GridViewSelectedRowStyle" />
                                                        <AlternatingItemStyle CssClass="GridViewAlternatingRowStyle" />--%>
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                                                        CellPadding="0" CssClass="GridViewStyle" GridLines="Both" ShowFooter="false"
                                                        ShowHeader="false" Visible="true" Width="960px">
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <PagerStyle CssClass="GridViewFixedPagerStyle" />
                                                        <Columns>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br></br>
                                                    <br></br>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </Ajax:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <%--</form>
</body>
</html>--%>
</asp:Content>
