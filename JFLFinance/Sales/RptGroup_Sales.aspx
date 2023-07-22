<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_Sales.aspx.cs" Inherits="Sales_RptGroup_Sales" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="750px" Height="420px" GroupingText="<%$Resources:Resource,Sales %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                        <ContentTemplate>
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
                            <asp:Panel ID="PanelDetSumm" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblDetSumm" runat="server" Text="<%$ Resources:Resource, DetailSummary %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlDetSumm" runat="server" CssClass="cssDropDown" Width="350px"
                                                OnSelectedIndexChanged="ddlDetSumm_IndexChange" AutoPostBack="true">
                                                <asp:ListItem Text="Summary" Value="S"></asp:ListItem>
                                                <asp:ListItem Text="Detail" Value="D"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelLocation" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblHrLocation" runat="server" Text="<%$Resources:Resource,HrLocation %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                                Width="350px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblBranch" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlBranch" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                                Width="350px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelStatus" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label10" runat="server" Text="<%$Resources:Resource,SoStatus %>" CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlSoStatus" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                                Width="200px">
                                                <asp:ListItem Text="<%$ Resources:Resource, All %>" Value="All"></asp:ListItem>
                                                <asp:ListItem Text="<%$ Resources:Resource, AUTHORIZED %>" Value="AUTHORIZED"></asp:ListItem>
                                                <asp:ListItem Text="<%$ Resources:Resource, AMEND %>" Value="AMEND"></asp:ListItem>
                                                <asp:ListItem Text="<%$ Resources:Resource, SHORTCLOSED %>" Value="SHORT CLOSED"></asp:ListItem>
                                                <asp:ListItem Text="<%$ Resources:Resource, TERMINATED %>" Value="TERMINATED"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelTermination" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label runat="server" ID="label11" CssClass="cssLable" Text="<%$ Resources:Resource, Status %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DdlStatus" Width="200px" CssClass="cssDropDown" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelSoType" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblfixSOType" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, SOType %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList CssClass="cssDropDown" Width="200px" ID="ddlSoType" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="PanelDates" Width="800px" BorderWidth="0px" runat="server">
                                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td align="right" style="width: 200px">
                                                    <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtFromDate" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"
                                                        OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                                    <asp:HyperLink ID="ImgFromDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                                    </AjaxToolKit:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 200px">
                                                    <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtToDate" runat="server" Text="" CssClass="csstxtbox" AutoPostBack="True"></asp:TextBox>
                                                    <asp:HyperLink ID="ImgToDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                                    </AjaxToolKit:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </Ajax:UpdatePanel>
                            <asp:Panel ID="PanelFromToClient" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, FromClientNo %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlFromClientCode" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                                                Width="350px">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImgBtnSearchFromClient" Height="18px" Width="16px" ImageUrl="../Images/icosearch.gif"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, ToClientNo %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlToClientCode" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                                                Width="350px">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImgBtnSearchToClient" Height="18px" Width="16px" ImageUrl="../Images/icosearch.gif"
                                                runat="server" />
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
                                            <asp:DropDownList ID="ddlClientName" runat="server" CssClass="cssDropDown" Width="350px"
                                                OnSelectedIndexChanged="ddlClient_IndexChange" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImgBtnSearchClient" Height="18px" Width="16px" ImageUrl="../Images/icosearch.gif"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelBillNoBill" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource,IsBillable%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlBillNonBill" Width="350" CssClass="cssDropDown" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelInvoiceType" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="lblInvoiceType" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, BillingPattern %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlInvoiceType" Width="130px" CssClass="cssDropDown" runat="server"
                                                OnSelectedIndexChanged="ddlInvoiceType_IndexChange" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAsOnDate" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label runat="server" ID="label4" CssClass="cssLable" Text="<%$ Resources:Resource, AsOnDate %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:TextBox ID="txtAsOnDate" OnTextChanged="txtAsOnDate_TextChanged" AutoPostBack="true"
                                                runat="server" CssClass="csstxtbox"></asp:TextBox>
                                            <asp:HyperLink ID="ImgAsOnDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelSoNo" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label runat="server" ID="SoNo" CssClass="cssLable" Text="<%$ Resources:Resource, SoNo %>"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlSoNo" runat="server" CssClass="cssDropDown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelIncreaseDecrease" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, IncreaseOrDecrease %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:DropDownList ID="ddlIncDecService" runat="server" CssClass="cssDropDown" Width="350px">
                                                <asp:ListItem Text="<%$ Resources:Resource,Increase%>" Value="Increase"></asp:ListItem>
                                                <asp:ListItem Text="<%$ Resources:Resource,Decrease%>" Value="Decrease"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelSummary" Width="800px" BorderWidth="0px" runat="server">
                                <table width="800px" border="0" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 200px">
                                            &nbsp;
                                        </td>
                                        <td align="left" colspan="3">
                                            <asp:RadioButton ID="radSummary" runat="server" GroupName="EmpID" Checked="true" />
                                            <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Resource, Summary %>"
                                                CssClass="cssLable"></asp:Label>
                                            <asp:RadioButton ID="radDetail" runat="server" GroupName="EmpID" />
                                            <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Resource, Details %>"
                                                CssClass="cssLable"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            
                            
                             <asp:Panel ID="PanelDivision" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label14" runat="server" Text="<%$ Resources:Resource, HrLocation %>"
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
                    <asp:Panel ID="PanelBranch" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label15" runat="server" Text="<%$ Resources:Resource, Branch %>" CssClass="cssLable"></asp:Label>
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
                    <asp:Panel ID="PanelAreaID" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label16" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaID %>"></asp:Label>
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
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelClientCode" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label17" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddlClientCode" runat="server" Width="150px" MaxHeight="350px"
                                        AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
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
                    <asp:Panel ID="PanelAsmt" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label18" runat="server" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLable"></asp:Label>
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
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PnlCentralized" runat="server" Width="800px" BorderWidth="0px">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label CssClass="cssLable" ID="Label28" runat="server" Text="<%$Resources:Resource,IncSOCentralize%>"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:CheckBox ID="chkCentralize" runat="server" AutoPostBack="true" Checked="false"
                                        CssClass="cssCheckBox" OnCheckedChanged="chkCentralize_CheckedChanged" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    

                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                   
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="300px">
                                </td>
                                <td align="left" width="400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" />
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
</asp:Content>
