<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_Client.aspx.cs" Inherits="Sales_RptGroup_Client" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../MS_Control/MultipleSelection.ascx" TagName="MultipleSelection"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="750px" Height="420px" GroupingText="<%$Resources:Resource,Client %>"
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
                    <asp:Panel ID="PanelBranch" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <uc1:MultipleSelection ID="msddlBranch" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelClientName" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlClientName" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                                        Width="350px">
                                    </asp:DropDownList>
                                    <asp:ImageButton ID="ImgBtnSearchClient" Height="18px" Width="16px" ImageUrl="../Images/icosearch.gif"
                                        runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelCenterlize" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="LabelOption" runat="server" Text="<%$Resources:Resource,Option %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlCenterlize" runat="server" CssClass="cssDropDown" Width="150px"
                                        AutoPostBack="True">
                                        <asp:ListItem Value="A" Text="<%$Resources:Resource,All%>"></asp:ListItem>
                                        <asp:ListItem Value="Y" Text="<%$Resources:Resource,CentralizeBilling%>"></asp:ListItem>
                                        <asp:ListItem Value="N" Text="<%$Resources:Resource,NonCentralizeBilling%>"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelSoNo" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,SoNo %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtSoNo" runat="server" Text="" CssClass="csstxtbox"></asp:TextBox>
                                    <asp:ImageButton ID="ImgbtnSearchSoNo" Height="18px" Width="16px" ImageUrl="../Images/icosearch.gif"
                                        runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelMonth" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label12" runat="server" Text="<%$Resources:Resource,Month %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" Width="150px"
                                        AutoPostBack="True">
                                        <asp:ListItem Value="1" Text="<%$Resources:Resource,January%>"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="<%$Resources:Resource,February%>"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="<%$Resources:Resource,March%>"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="<%$Resources:Resource,April%>"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="<%$Resources:Resource,May%>"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="<%$Resources:Resource,June%>"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="<%$Resources:Resource,July%>"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="<%$Resources:Resource,August%>"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="<%$Resources:Resource,September%>"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="<%$Resources:Resource,October%>"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="<%$Resources:Resource,November%>"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="<%$Resources:Resource,December%>"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelYear" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label13" runat="server" Text="<%$Resources:Resource,Year %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtYear" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelDates" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" height="40" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtFromDate" ReadOnly="true" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtToDate" ReadOnly="true" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    
                    
                    
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
                    
                     <asp:Panel ID="PanelClientCode1" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label21" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlClientCode1" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientCode1_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlClientName1" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientName1_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAsmtID1" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label22" runat="server" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlAsmtCode1" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAsmtCode1_OnSelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="ddlAsmtName" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlAsmtName_OnSelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                               <asp:Panel ID="PanelPost1" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="width: 200px" align="right">
                                            <asp:Label ID="Label32" runat="server" Text="<%$Resources:Resource,Post %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlPostCode1" runat="server" Width="150px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlPostCode1_OnSelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlPost1" runat="server" Width="350px" MaxHeight="350px"
                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlPost1_OnSelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                              <asp:Panel runat="server" ID="PnlIsMandatory" Width="800px" BorderWidth="0px">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label CssClass="cssLable" ID="Label31" runat="server" Text="<%$Resources:Resource,ConstraintType %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <telerik:RadComboBox ID="DdlIsMandatory" runat="server" Width="250px" MaxHeight="350px"
                                                Filter="StartsWith">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, All%>" Value="All" />
                                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Mandatory%>" Value="M" />
                                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Informative%>" Value="I" />
                                                    <telerik:RadComboBoxItem Text="<%$ Resources:Resource, Recommended%>" Value="R" />
                                                </Items>
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

                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="300px">
                                </td>
                                <td align="left" width="400px">
                                    <br />
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClientClick="javascript:openNewPage()" OnClick="btnViewReport_Click" />
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
    <script type="text/javascript" language="javascript">
        function openNewPage() {
            if (document.getElementById('<% =ddlReportName.ClientID %>').value == "rptSale_MsxmlClientSectorBreakDown.aspx") {
                if (document.getElementById('<% =txtFromDate.ClientID %>').value != "" && document.getElementById('<% =txtToDate.ClientID %>').value != "") {
                    var PageName = "rptSale_MsxmlClientSectorBreakDown.aspx?FromDate=" + document.getElementById('<% =txtFromDate.ClientID %>').value + "&ToDate=" + document.getElementById('<% =txtToDate.ClientID %>').value + "  ";
                    window.open(PageName, null, 'status=off,center=yes,scroll=no,Width=800px,help=no');
                }
            }
        }
    </script>
</asp:Content>
