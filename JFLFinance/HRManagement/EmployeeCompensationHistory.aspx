<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeCompensationHistory.aspx.cs" Inherits="HRManagement_EmployeeCompensationHistory"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<head id="Head1">
<title></title>
    <%--<script language="javascript" type="text/javascript" src="../javaScript/jquery-1.8.1.min.js"></script>--%>
    <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.11.3.min.js"></script>
</head>
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                                <div class="squareboxgradientcaption" style="height: 20px;">
                                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,compensationDetail %>"></asp:Label>
                                    
                                </div>
                                <div>
                                    <table border="0" cellpadding="3" cellspacing="0" width="70%">
                                        <tr>
                                            <td width="90" align="left">
                                                <asp:Label CssClass="cssLable" ID="lblEmployeeNumber" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="csstxtboxReadonly" ID="txtEmployeeNumber" Width="60px" runat="server"
                                                    ReadOnly="true"></asp:TextBox>
                                                <asp:TextBox CssClass="csstxtboxReadonly" ID="txtEmployeeName" Width="200px" runat="server"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label CssClass="cssLable" ID="LabelStatus" runat="server" Text="<%$Resources:Resource,Status %>"></asp:Label>
                                                <asp:TextBox CssClass="csstxtboxReadonly" ID="txtStatus" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Panel ID="pAddType" Width="" GroupingText="<%$Resources:Resource,Component %>"
                                        runat="server" BorderWidth="0">
                                        <table border="0" cellpadding="1" cellspacing="0" width="90%">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblComponent" runat="server" Text="<%$ Resources:Resource, Component  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlComponent" TabIndex="1" Width="184px" runat="server" AutoPostBack="true"
                                                        CssClass="cssDropDown" OnSelectedIndexChanged="ddlComponent_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    &nbsp; &nbsp; &nbsp;
                                                    <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblChkDisable" runat="server"
                                                        Text="<%$ Resources:Resource,Disable%>"></asp:Label>
                                                    <asp:CheckBox ID="chkDisable" runat="server" />
                                                    &nbsp;
                                                    <asp:Label ID="lblWEFDate" runat="server" Text="<%$Resources:Resource,WEFDate %>"
                                                        CssClass="cssLable"></asp:Label>
                                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtWEFDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                                    <asp:HyperLink ID="ImgWEFDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtenderWEFDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtWEFDate" PopupButtonID="ImgWEFDate">
                                                    </AjaxToolKit:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pAddDetails" Width="" GroupingText="-" runat="server" BorderWidth="0">
                                        <table border="0" cellpadding="1" cellspacing="0" width="70%">
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblPercentageValue" runat="server" Text="<%$ Resources:Resource, PercentageValue  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:DropDownList ID="ddlPercentageValue" TabIndex="1" Width="184px" runat="server"
                                                        AutoPostBack="true" CssClass="cssDropDown" OnSelectedIndexChanged="ddlPercentageValue_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblFrequency" runat="server" Text="<%$ Resources:Resource, Frequency  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:DropDownList ID="ddlFrequency" TabIndex="1" Width="184px" runat="server" AutoPostBack="true"
                                                        CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblValue" runat="server" Text="<%$ Resources:Resource, Value  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:TextBox Width="210px" ID="txtValue" TabIndex="4" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="8"></asp:TextBox> 
                                                    <asp:RangeValidator ID="rvValue" Type="Double" runat="server" ControlToValidate="txtValue" MinimumValue="0.00"
                                                        MaximumValue="99999999" ValidationGroup="vgClient" ErrorMessage="*"></asp:RangeValidator>
                                                    <asp:RequiredFieldValidator ID="RFVValue" ValidationGroup="vgClient" Display="Dynamic"
                                                        runat="server" Text="*" ControlToValidate="txtValue"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblCurrency" runat="server" Text="<%$ Resources:Resource, Currency  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:DropDownList ID="ddlCurrency" TabIndex="1" Width="184px" runat="server" AutoPostBack="true"
                                                        CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblPercentageof" runat="server" Text="<%$ Resources:Resource, Percentageof  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:DropDownList ID="ddlPercentageof" TabIndex="1" Width="184px" runat="server"
                                                        AutoPostBack="true" CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelAddWEFDate" BorderWidth="0px" runat="server">
                                        <table width="70%" border="0" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label ID="lblAddEffectiveFrom" runat="server" Text="<%$Resources:Resource,EffectiveFrom %>"
                                                        CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtAddEffectiveFrom" runat="server"
                                                        AutoPostBack="false"></asp:TextBox>
                                                    <asp:HyperLink ID="ImgAddEffectiveFrom" Style="vertical-align: middle;" runat="server"
                                                        ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtenderAddEffectiveFrom" Format="dd-MMM-yyyy"
                                                        runat="server" TargetControlID="txtAddEffectiveFrom" PopupButtonID="ImgAddEffectiveFrom">
                                                    </AjaxToolKit:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pSelCorrectORUpdate" Width="" runat="server" BorderWidth="0">
                                        <table border="0" cellpadding="1" cellspacing="0" width="70%">
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblSelCorrectORUpdate" runat="server" Text="<%$ Resources:Resource, SelCorrectORUpdate  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:DropDownList ID="ddlSelCorrectORUpdate" TabIndex="1" Width="184px" runat="server"
                                                        AutoPostBack="true" CssClass="cssDropDown" OnSelectedIndexChanged="ddlSelCorrectORUpdate_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label ID="lblUpdateEffectiveFrom" runat="server" Text="<%$Resources:Resource,EffectiveFrom %>"
                                                        CssClass="cssLable"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtUpdateEffectiveFrom" runat="server"
                                                        AutoPostBack="false"></asp:TextBox>
                                                    <asp:HyperLink ID="ImgUpdateEffectiveFrom" Style="vertical-align: middle;" runat="server"
                                                        ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtenderUpdateEffectiveFrom" Format="dd-MMM-yyyy"
                                                        runat="server" TargetControlID="txtUpdateEffectiveFrom" PopupButtonID="ImgUpdateEffectiveFrom">
                                                    </AjaxToolKit:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <table border="0" cellpadding="1" cellspacing="0" style="width: 945px">
                                        <tr>
                                            <td align="center">
                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnSubmit" runat="server" Text="<%$Resources:Resource,Apply %>" ValidationGroup="vgClient"
                                                    CssClass="cssButton" TabIndex="15" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:Resource,Back %>" CssClass="cssButton"
                                                    TabIndex="16" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
</asp:Content>
