<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="WeeklyScheduleActualEMail1.aspx.cs" Inherits="Transactions_WeeklyScheduleActualEMail1"
    Title="Untitled Page" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Note: this screen is developed for Lock & UnLock existing schedule Here Lock means Convert schedule into actual--%>
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="Left">
                <div style="width: 950px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 670px;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label5" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, ScheduleByEmail %>"></asp:Label>
                                </tt>
                            </div>
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
                                                    <asp:DropDownList ID="ddlMonth" Width="70px" runat="server" CssClass="cssDropDownSmall"
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
                                                <td>
                                                    <asp:TextBox MaxLength="4" Width="25px" CssClass="csstxtboxSmall" ID="txtYear" runat="server"
                                                        AutoPostBack="true" OnKeyUp="javascript:validateNumeric(this);" OnTextChanged="txtYear_TextChanged">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWeekNo" runat="server" Text="<%$ Resources:Resource,Week%>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlWeek" Width="200px" AutoPostBack="true" CssClass="cssDropDownSmall"
                                                        OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged" runat="server">
                                                    </asp:DropDownList>
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
                                        <%--<asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>--%>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                        </AjaxToolKit:CalendarExtender>
                                        -
                                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" Width="80px"
                                            AutoPostBack="false" Enabled="false"></asp:TextBox>
                                        <%--<asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>--%>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                        </AjaxToolKit:CalendarExtender>
                                    </td>
                                    <td align="right" style="width: 200px">
                                        <asp:HiddenField ID="HFFromDate" runat="server" />
                                        <asp:HiddenField ID="HFToDate" runat="server" />
                                        <asp:HiddenField ID="HFMaxDate" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 200px">
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
                                <tr>
                                    <td align="left" style="width: 200px">
                                        <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaID %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="DDLAreaID" runat="server" Width="150px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="DDLAreaID_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td align="left" colspan="2">
                                        <telerik:RadComboBox ID="ddlAreaName" runat="server" Width="350px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAreaName_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 200px">
                                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddlClientCode" runat="server" Width="150px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td align="left" colspan="2">
                                        <telerik:RadComboBox ID="ddlClientName" runat="server" Width="350px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 200px">
                                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddlAsmtCode" runat="server" Width="150px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAsmtCode_OnSelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td align="left" colspan="2">
                                        <telerik:RadComboBox ID="ddlAsmtName" runat="server" Width="350px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAsmtName_OnSelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 200px">
                                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddlEmployeeNumber" runat="server" Width="150px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlEmployeeNumber_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td align="left" colspan="2">
                                        <telerik:RadComboBox ID="ddlEmployeeName" runat="server" Width="350px" MaxHeight="350px"
                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlEmployeeName_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="width: 400px">
                                    </td>
                                    <td align="center" style="width: 400px">
                                        <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,Send %>"
                                                CssClass="cssButton" OnClick="btnSend_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="hid_SelectAll" runat="server" />
                                <asp:HiddenField ID="weekStartDate" runat="server" />
                                <asp:HiddenField ID="weekEndDate" runat="server" />
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
</asp:Content>
