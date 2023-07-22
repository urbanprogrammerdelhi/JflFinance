<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeePromotion.aspx.cs" Inherits="HRManagement_EmployeePromotion"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" style="height: 100%;" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td>
                <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 950px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width:930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label6" CssClass="squareboxgradientcaption" runat="server" Text="Employee Promotion / Increment"></asp:Label></tt></div>
                                </div>
                                <div class="squareboxcontent" style="height: 430px">
                                    <table width="900" border="0" cellspacing="0" cellpadding="1">
                                        <tr>
                                            <td style="width: 120px" align="right">
                                                <asp:Label ID="LblEmployeeNumber" Width="120px" runat="server" Text="Employee Number"
                                                    CssClass="cssLabel">
                                                </asp:Label>
                                            </td>
                                            <td align="left" width="200">
                                                <asp:TextBox ID="TxtEmployeeNumber" runat="server" CssClass="csstxtboxReadonly" OnTextChanged="TxtEmployeeNumber_OnTextChanged"
                                                    AutoPostBack="true">
                                                </asp:TextBox>
                                                <asp:ImageButton ID="imgEmployeeNumberSearch" AlternateText="SearchClient" runat="server"
                                                    ImageUrl="~/Images/icosearch.gif" ToolTip="Search Employee Number" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                    </table>
                                    <asp:Panel Width="900" ID="Panel1" ForeColor="red" Font-Bold="true" GroupingText="<%$Resources:Resource,compensationDetail %>"
                                        runat="server" ScrollBars="none">
                                        <table align="center" width="900" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td style="text-align: right; width: 120px;">
                                                    <asp:Label ID="lblWageRate" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                        Text="<%$Resources:Resource,wageRate %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 110px;">
                                                    <asp:TextBox ID="txtWageRate" runat="server" CssClass="csstxtboxRequired" Text=""
                                                        ReadOnly="true" MaxLength="8" Style="width: 90px;"></asp:TextBox>
                                                </td>
                                                <td style="text-align: right; width: 60px;">
                                                    <asp:Label ID="lblCurrency" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                        Text="<%$Resources:Resource,currency %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 110px;">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblCurrencyValue" CssClass="cssLable" runat="server" Style="width: 100px;
                                                        font-weight: bold" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right; width: 150px;">
                                                    <asp:Label ID="lblWageRateFequency" CssClass="cssLable" runat="server" Style="width: 150px;"
                                                        Text="<%$Resources:Resource,wageRateFrequency%> "></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 160px;">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblwageRateFrequencyValue" CssClass="cssLable" runat="server" Style="width: 150px;
                                                        font-weight: bold" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 110px;">
                                                    <asp:Label ID="lblContractedHrs" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                        Text="<%$Resources:Resource,ContractHours%>"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 120px;">
                                                    <asp:TextBox ID="txtContractedHrs" runat="server" CssClass="csstxtbox" Text="" MaxLength="5"
                                                        ReadOnly="true" Style="width: 90px;"></asp:TextBox>
                                                </td>
                                                <td style="text-align: right; width: 60px;">
                                                    <asp:Label ID="lblAtRate" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                        Text="@"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 150px;">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblcontractRateFrequencyValue" CssClass="cssLable" runat="server"
                                                        Style="width: 150px; font-weight: bold" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right; width: 150px;">
                                                    <asp:Label ID="lblPaymentFrequency" CssClass="cssLable" runat="server" Style="width: 150px;"
                                                        Text="<%$Resources:Resource,paymentFrequency%>"></asp:Label>
                                                </td>
                                                <td style="text-align: Left; width: 160px;">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblPaymentFrequencyValue" CssClass="cssLable" runat="server" Style="width: 100px;
                                                        font-weight: bold" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel Width="900" ID="Panel2" ForeColor="red" Font-Bold="true" GroupingText=" "
                                        runat="server" ScrollBars="none">
                                        <table align="center" width="900" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td style="text-align: right; width: 120px;">
                                                    <asp:Label ID="lblReasonType" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                        Text="<%$Resources:Resource,ReasonType %>"></asp:Label>
                                                </td>
                                                <td colspan="2" style="text-align: left; width: 150px;">
                                                    <asp:DropDownList ID="ddlReasonType" CssClass="cssDropDown" Style="width: 150px;"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td colspan="4" align="left">
                                                    <asp:TextBox ID="txtEmpNo" runat="server" CssClass="csstxtboxRequired" Text="" ReadOnly="true"
                                                        Style="width: 90px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 120px;">
                                                    <asp:Label ID="Label5" CssClass="cssLable" runat="server" Style="width: 110px;" Text="<%$Resources:Resource,EffectiveFrom %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 110px;">
                                                    <asp:TextBox ID="txtEffectiveFrom" runat="server" CssClass="csstxtboxRequired" Text="" 
                                                        MaxLength="11" ValidationGroup="NewRate" Style="width: 90px;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVtxtEffectiveFrom" ValidationGroup="NewRate" Display="Dynamic"
                                                        runat="server" ErrorMessage="" Text="*" ControlToValidate="txtEffectiveFrom"></asp:RequiredFieldValidator>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtEffectiveFrom" />
                                                                       
                                                </td>
                                                <td style="text-align: right; width: 70px;">
                                                    <asp:Label ID="Label3" CssClass="cssLable" runat="server" Style="width: 100px;" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 150px;">
                                                    <asp:DropDownList ID="ddlDedignation" CssClass="cssDropDown" Style="width: 140px;"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td colspan="3">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 120px;">
                                                    <asp:Label ID="Label1" CssClass="cssLable" runat="server" Style="width: 110px;" Text="<%$Resources:Resource,Increment %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 110px;">
                                                    <asp:TextBox ID="txtIncrement" runat="server" CssClass="csstxtboxRequired" Text=""
                                                        MaxLength="8" ValidationGroup="NewRate" Style="width: 90px;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVtxtWageRate" ValidationGroup="NewRate" Display="Dynamic"
                                                        runat="server" ErrorMessage="" Text="*" ControlToValidate="txtIncrement"></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="text-align: right; width: 70px;">
                                                    <asp:Label ID="Label2" CssClass="cssLable" runat="server" Style="width: 100px;" Text="<%$Resources:Resource,currency %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 110px;">
                                                    <asp:DropDownList ID="ddlCurrency" CssClass="cssDropDown" Style="width: 110px;" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: right; width: 150px;">
                                                    <asp:Label ID="Label4" CssClass="cssLable" runat="server" Style="width: 150px;" Text="<%$Resources:Resource,wageRateFrequency%> "></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 160px;">
                                                    <asp:DropDownList ID="ddlWageRateFrequency" CssClass="cssDropDown" Style="width: 140px;"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlWageRateFrequency" ValidationGroup="NewRate"
                                                        Display="Dynamic" runat="server" ErrorMessage="" Text="*" ControlToValidate="ddlWageRateFrequency"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 120px;">
                                                    <asp:Label ID="Label7" CssClass="cssLable" runat="server" Style="width: 110px;" Text="<%$Resources:Resource,ContractHours%>"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 120px;">
                                                    <asp:TextBox ID="txtNewContractHrs" runat="server" CssClass="csstxtbox" Text="" MaxLength="5"
                                                        Style="width: 90px;"></asp:TextBox>
                                                </td>
                                                <td style="text-align: right; width: 70px;">
                                                    <asp:Label ID="Label8" CssClass="cssLable" runat="server" Style="width: 100px;" Text="@"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 150px;">
                                                    <asp:DropDownList ID="ddlContHrsFreqency" CssClass="cssDropDown" Style="width: 140px;"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: right; width: 150px;">
                                                    <asp:Label ID="Label10" CssClass="cssLable" runat="server" Style="width: 150px;"
                                                        Text="<%$Resources:Resource,paymentFrequency%>"></asp:Label>
                                                </td>
                                                <td style="text-align: Left; width: 160px;">
                                                    <asp:DropDownList ID="ddlPaymntFrequency" CssClass="cssDropDown" Style="width: 140px;"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlPaymntFrequency" ValidationGroup="NewRate"
                                                        Display="Dynamic" runat="server" ErrorMessage="" Text="*" ControlToValidate="ddlPaymntFrequency"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" align="center">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text=" Save " OnClick="btnSave_Click"
                                                        ValidationGroup="NewRate" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" align="center">
                                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" Text="" CssClass="csslblErrMsg"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
