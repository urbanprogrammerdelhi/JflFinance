<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientMaster.aspx.cs" Inherits="Sales_ClientMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                                <div>
                                    <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="ClientDetails" ActiveTabIndex="0">
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelClientDetails" runat="server" HeaderText="<%$Resources:Resource,ClientDetails %>" TabIndex="0">
                                            <ContentTemplate>
                                                <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="right">
                                                            <asp:LinkButton ID="btnList" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource,ClientList %>" OnClick="btnList_Click"></asp:LinkButton>
                                                            <asp:LinkButton  ID="lbtnAddNew" runat="server" Text="<%$ Resources:Resource, AddNewClient %>" CssClass="btn btn-primary btn-xs"  OnClick="lbtnAddNew_Click"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="pClient" Font-Bold="True" GroupingText="<%$ Resources:Resource,Client %>" runat="server" BorderWidth="0px">
                                                    <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="Label3" runat="server" Text="<%$ Resources:Resource,ClientCode %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox CssClass="csstxtboxReadonly" Width="120px" ID="txtClientCode" MaxLength="32" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblManualClientCode" runat="server" Text="<%$ Resources:Resource, ManualClientCode %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="120px" ID="txtManualClientCode" MaxLength="16" runat="server" CssClass="csstxtbox" TabIndex="1"></asp:TextBox>
                                                            </td>
                                                            <td align="left" colspan="1" style="height: 41px">
                                                                <asp:LinkButton ID="lbCheckAvailability"  CssClass="btn btn-primary btn-xs" runat="server" Text="<%$ Resources:Resource,CheckAvailability %>" OnClick="lbCheckAvailability_Click" TabIndex="2"></asp:LinkButton>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblClientName" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtClientName" runat="server" CssClass="csstxtboxRequired" Columns="45" MaxLength="100" TabIndex="3"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfClientName" runat="server" ControlToValidate="txtClientName" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8">
                                                                <asp:Button ID="btnMultilingual" style="display:none;" CssClass="cssButton" runat="server" OnClick="btnMultilingual_Click"
                                                                    Text="<%$ Resources:Resource,MultilingualEntry %>" />
                                                                <asp:Button ID="Button3" runat="server" Style="display: none" />
                                                                <asp:Panel ID="Panel6" BackColor="White" CssClass="ScrollBar" runat="server" Height="170px"
                                                                    Width="510px" Style="display: none;">
                                                                    <AjaxToolKit:ModalPopupExtender ID="MPClientDetail" runat="server" TargetControlID="Button3"
                                                                        PopupControlID="Panel6" X="250" Y="50" BackgroundCssClass="modalBackground"
                                                                        Enabled="True">
                                                                    </AjaxToolKit:ModalPopupExtender>
                                                                    <div style="width: 500px;">
                                                                        <div class="squarebox">
                                                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                                                <div style="float: left; width: 470px;">
                                                                                    <tt style="text-align: center;">
                                                                                        <asp:Label ID="Label7" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource,PersonalDetail1 %>"></asp:Label></tt></div>
                                                                            </div>
                                                                            <div class="squareboxcontent">
                                                                                <table border="0" width="100%">
                                                                                    <tr>
                                                                                        <td style="text-align: right;">
                                                                                            <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ClientName %>"></asp:Label>
                                                                                        </td>
                                                                                        <td style="text-align: left;">
                                                                                            <asp:TextBox ID="txtOtherLanguageClientName" Width="200px" MaxLength="100" CssClass="csstxtboxRequired"
                                                                                                runat="server"></asp:TextBox>
                                                                                            <asp:HiddenField ID="HFOtherLanguageClientName" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: right;">
                                                                                            <asp:Label ID="Label5" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AddressLine1 %>"></asp:Label>
                                                                                        </td>
                                                                                        <td style="text-align: left;">
                                                                                            <asp:TextBox ID="txtOtherLanguageAdd1" Width="200px" MaxLength="100" CssClass="csstxtboxRequired"
                                                                                                runat="server"></asp:TextBox>
                                                                                            <asp:HiddenField ID="HFOtherLanguageAdd1" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: right;">
                                                                                            <asp:Label ID="Label6" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AddressLine2 %>"></asp:Label>
                                                                                        </td>
                                                                                        <td style="text-align: left;">
                                                                                            <asp:TextBox ID="txtOtherLanguageAdd2" Width="200px" MaxLength="100" CssClass="csstxtboxRequired"
                                                                                                runat="server"></asp:TextBox>
                                                                                            <asp:HiddenField ID="HFOtherLanguageAdd2" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: right;">
                                                                                            <asp:Label ID="lblAddressLine33" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AddressLine3 %>"></asp:Label>
                                                                                        </td>
                                                                                        <td style="text-align: left;">
                                                                                            <asp:TextBox ID="txtOtherLanguageAdd3" Width="200px" MaxLength="100" CssClass="csstxtboxRequired"
                                                                                                runat="server"></asp:TextBox>
                                                                                            <asp:HiddenField ID="HFOtherLanguageAdd3" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:Button ID="btnOk" CssClass="cssButton" OnClick="btnOk_Click" runat="server"
                                                                                                Text="<%$ Resources:Resource,OK %>" />
                                                                                            <asp:Button ID="btnMultiLingualCancel" CssClass="cssButton" OnClick="btnMultiLingualCancel_Click"
                                                                                                runat="server" Text="<%$ Resources:Resource,Cancel %>" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pClientAddress" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,ClientAddress %>"
                                                    runat="server" BorderWidth="0px">
                                                    <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblAddressLine1" runat="server" Text="<%$ Resources:Resource, AddressLine1 %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 250px" colspan="3">
                                                                <asp:TextBox Width="210px" ID="txtClientAddressLine1" runat="server" CssClass="csstxtboxRequired"
                                                                    MaxLength="100" TabIndex="4"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClientAddressLine1"
                                                                    ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblCity" runat="server" Text="<%$ Resources:Resource, City %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 170px">
                                                                <asp:TextBox Width="150px" ID="txtCity" runat="server" CssClass="csstxtboxRequired"
                                                                    MaxLength="100" TabIndex="7"></asp:TextBox>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblState" runat="server" Text="<%$ Resources:Resource, State %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 170px">
                                                                <asp:TextBox Width="150px" ID="txtState" runat="server" CssClass="csstxtboxRequired"
                                                                    MaxLength="100" TabIndex="8"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblAddressLine2" runat="server" Text="<%$ Resources:Resource, AddressLine2 %>"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3">
                                                                <asp:TextBox Width="210px" ID="txtClientAddressLine2" runat="server" CssClass="csstxtbox"
                                                                    MaxLength="100" TabIndex="5"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblPin" runat="server" Text="<%$ Resources:Resource, Pin %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList Width="75px" runat="server" ID="ddlGroupZip" AutoPostBack="True"
                                                                    CssClass="cssDropDown" OnSelectedIndexChanged="ddlGroupZip_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:DropDownList Width="75px" runat="server" ID="ddlZip" CssClass="cssDropDown">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblCountryCode" runat="server" Text="<%$ Resources:Resource, Country %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList Width="154px" runat="server" ID="ddlCountryCode" AutoPostBack="True"
                                                                    CssClass="cssDropDown" TabIndex="10" OnSelectedIndexChanged="ddlCountryCode_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblAddressLine3" runat="server" Text="<%$ Resources:Resource, AddressLine3 %>"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3">
                                                                <asp:TextBox Width="210px" ID="txtClientAddressLine3" runat="server" CssClass="csstxtbox"
                                                                    MaxLength="100" TabIndex="6"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblPhone" runat="server" Text="<%$ Resources:Resource, Phone %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="150px" ID="txtPhone" runat="server" CssClass="csstxtbox" MaxLength="100"
                                                                    TabIndex="11"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblFax" runat="server" Text="<%$ Resources:Resource, Fax %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="150px" ID="txtFax" runat="server" CssClass="csstxtbox" MaxLength="100"
                                                                    TabIndex="12"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblWebSite" runat="server" Text="<%$ Resources:Resource, WebSite %>"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3">
                                                                <asp:TextBox Width="210px" ID="txtWebSite" runat="server" CssClass="csstxtbox" MaxLength="100"
                                                                    TabIndex="13"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                                                    ControlToValidate="txtWebSite" ValidationGroup="vgClient" Display="Dynamic" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?">*</asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="lblEmail" runat="server" Text="<%$ Resources:Resource, Email %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="150px" ID="txtEmail" runat="server" CssClass="csstxtbox" MaxLength="100"
                                                                    TabIndex="14"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*"
                                                                    ControlToValidate="txtEmail" ValidationGroup="vgClient" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="right">
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pContactDetails" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,ContactDetails %>"
                                                    runat="server" BorderWidth="0px">
                                                    <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" Width="100px" ID="lblClientContactPerson" runat="server"
                                                                    Text="<%$ Resources:Resource, ContactPerson %>"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3">
                                                                <asp:TextBox Width="150px" ID="txtClientContactPerson" runat="server" CssClass="csstxtboxRequired"
                                                                    MaxLength="100" TabIndex="15"></asp:TextBox>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblClientContactPersonDesignation" runat="server"
                                                                    Text="<%$ Resources:Resource, Designation %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="150px" ID="txtClientContactPersonDesignation" runat="server"
                                                                    CssClass="csstxtboxRequired" MaxLength="100" TabIndex="16"></asp:TextBox>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblClientContactPersonMobile" runat="server" Text="<%$ Resources:Resource, ContactNumber %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="150px" ID="txtClientContactPersonMobile" runat="server" CssClass="csstxtbox"
                                                                    MaxLength="100" TabIndex="17"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label CssClass="cssLable" ID="Label1" runat="server" Text="<%$ Resources:Resource, Email %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="150px" ID="txtContactPersonEmail" runat="server" CssClass="csstxtbox" MaxLength="100"
                                                                    TabIndex="14"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*"
                                                                    ControlToValidate="txtContactPersonEmail" ValidationGroup="vgClient" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pOther" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,Details %>"
                                                    runat="server" BorderWidth="0px">
                                                    <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblCountryOrigin" runat="server" Text="<%$ Resources:Resource, CountryOrigin %>"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3">
                                                                <asp:DropDownList Width="154px" ID="ddlCountryOrigin" CssClass="cssDropDown" runat="server"
                                                                    TabIndex="21">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblIndustryType" runat="server" Text="<%$ Resources:Resource, IndustryType %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList Width="154px" ID="ddlIndustryType" CssClass="cssDropDown" runat="server"
                                                                    TabIndex="22">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblClassification" runat="server" Text="<%$ Resources:Resource, Classification %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList Width="154px" ID="ddlClassification" CssClass="cssDropDown" runat="server"
                                                                    TabIndex="23">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblCustomerType" runat="server" Text="<%$ Resources:Resource, CustomerType %>"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3">
                                                                <asp:DropDownList Width="154px" ID="ddlCustomerType" CssClass="cssDropDown" runat="server"
                                                                    TabIndex="24">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblSector" runat="server" Text="<%$ Resources:Resource, Sector %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList Width="154px" ID="ddlSector" CssClass="cssDropDown" runat="server"
                                                                    TabIndex="25">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblSubSegment" runat="server" Text="<%$ Resources:Resource, SubSegment %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList Width="154px" ID="ddlSubSegment" CssClass="cssDropDown" runat="server"
                                                                    TabIndex="26">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="width: 110px; height: 23px;">
                                                                <asp:Label CssClass="cssLable" ID="lblIsInternational" runat="server" Text="<%$ Resources:Resource, IsInternational %>"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3" style="height: 23px">
                                                                <asp:CheckBox ID="cbIsInternational" runat="server" TabIndex="27" />
                                                            </td>
                                                            <td align="right" style="width: 110px; height: 23px;">
                                                                <asp:Label CssClass="cssLable" ID="lblTurnover" runat="server" Text="<%$ Resources:Resource, Turnover %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 23px">
                                                                <asp:TextBox Width="150px" ID="txtTurnover" runat="server" CssClass="csstxtbox" MaxLength="100"
                                                                    TabIndex="28"></asp:TextBox>
                                                            </td>
                                                            <td align="right" style="width: 110px; height: 23px;">
                                                                <asp:Label CssClass="cssLable" ID="lblComments" runat="server" Text="<%$ Resources:Resource, Comment %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 23px">
                                                                <asp:TextBox Width="150px" ID="txtComments" runat="server" CssClass="csstxtbox" MaxLength="100"
                                                                    TabIndex="29"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pAccountIncharge" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,AccountIncharge %>"
                                                    runat="server">
                                                    <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblOurContactPersonEmpNo" runat="server" Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3">
                                                                <asp:TextBox Width="150px" ID="txtOurContactPersonEmpNo" AutoPostBack="True" runat="server"
                                                                    CssClass="csstxtbox" MaxLength="100" TabIndex="18" OnTextChanged="txtOurContactPersonEmpNo_TextChanged"></asp:TextBox>
                                                                <asp:ImageButton ID="imgEmployeeNumberSearch" runat="server" ImageUrl="~/Images/icosearch.gif" />
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblOurContactPerson" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="150px" ID="txtOurContactPerson" runat="server" CssClass="csstxtbox"
                                                                    MaxLength="100" TabIndex="19"></asp:TextBox>
                                                            </td>
                                                            <td align="right" style="width: 110px">
                                                                <asp:Label CssClass="cssLable" ID="lblOurContactPersonMobile" runat="server" Text="<%$ Resources:Resource, ContactNumber %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox Width="150px" ID="txtOurContactPersonMobile" runat="server" CssClass="csstxtbox"
                                                                    MaxLength="100" TabIndex="20"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <table border="0" cellpadding="1" cellspacing="0" style="width: 945px">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label EnableViewState="False" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:Resource,Submit %>"
                                                                ValidationGroup="vgClient" CssClass="cssButton" OnClick="btnSubmit_Click" TabIndex="30" />
                                                            <asp:Button ID="btnReset" runat="server" Text="<%$ Resources:Resource,Reset %>" CssClass="cssButton"
                                                                OnClick="btnReset_Click" TabIndex="31" />
                                                            <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:Resource,Update %>"
                                                                ValidationGroup="vgClient" CssClass="cssButton" OnClick="btnUpdate_Click" TabIndex="32" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:Resource,Cancel %>"
                                                                CssClass="cssButton" OnClick="btnCancel_Click" TabIndex="33" />
                                                            <asp:Button ID="btnClientDetails" runat="server" Text="<%$ Resources:Resource,ViewAddressList %>"
                                                                CssClass="cssButton" OnClick="btnClientDetails_Click" TabIndex="34" />
                                                            <asp:Button ID="btnCreateAsmtAddress" runat="server" Text="<%$ Resources:Resource,CreateAsmtAddress %>"
                                                                CssClass="cssButton" OnClick="btnCreateAsmtAddress_Click"   TabIndex="35" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelClientConstraintDetails"
                                            runat="server" HeaderText="<%$Resources:Resource,ClientConstraints %>" TabIndex="0">
                                            <ContentTemplate>
                                                   <table class="table table-hover">
                                                    <tr>
                                                        <td align="right" style="width: 80px">
                                                            <asp:Label CssClass="cssLable" ID="lblClientCode" runat="server" Text="<%$ Resources:Resource,ClientCode %>"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 100px">
                                                            <asp:TextBox CssClass="csstxtboxReadonly" Width="80px" ID="txtClientCodeConst" MaxLength="32"
                                                                Enabled="False" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td align="right" style="height: 41px; width: 140px">
                                                            <asp:Label CssClass="cssLable" ID="lblManualClientCodeConst" runat="server" Text="<%$ Resources:Resource, ManualClientCode %>"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 100px; height: 41px;">
                                                            <asp:TextBox Width="120px" ID="txtManualClientCodeConst" MaxLength="16" runat="server"
                                                                Enabled="False" CssClass="csstxtboxReadonly" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                        <td align="right" style="height: 41px; width: 100px">
                                                            <asp:Label CssClass="cssLable" ID="lblClientNameConst" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                                        </td>
                                                        <td align="right" style="height: 41px; width: 300px">
                                                            <asp:TextBox CssClass="csstxtboxReadonly" ID="txtClientNameConst" runat="server"
                                                                Width="300px" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <tr>
                                                            <td colspan="8">
                                                                  <table class="table table-hover">
                                                                    <tr>
                                                                        <td style="vertical-align: top; text-align: left;">
                                                                            <asp:GridView Width="450px" ID="gvQualification" CssClass="GridViewStyle" runat="server"
                                                                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvQualification_RowCommand"
                                                                                OnRowUpdating="gvQualification_RowUpdating" OnRowDataBound="gvQualification_RowDataBound"
                                                                                OnRowCancelingEdit="gvQualification_RowCancelingEdit" OnPageIndexChanging="gvQualification_PageIndexChanging"
                                                                                OnRowDeleting="gvQualification_RowDeleting" OnRowEditing="gvQualification_RowEditing">
                                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblaction" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                                                ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                                                ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblgvhdrQualificationCode" runat="server" Text="<%$ Resources:Resource, QualificationCode %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblgvQualificationCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QualificationDesc").ToString()%>'></asp:Label>
                                                                                            <asp:HiddenField ID="HFQualificationCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "QualificationCode").ToString()%>' />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlQualificationCode"
                                                                                                runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <asp:HiddenField ID="hfQualificationCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "QualificationCode").ToString()%>' />
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlQualificationCode"
                                                                                                runat="server">
                                                                                            </asp:DropDownList>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblgvhdrIsMandatoryQualification" runat="server" Text="<%$ Resources:Resource, RigidityLevel %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblQualificationRigiditylevel" runat="server" CssClass="cssLabel"
                                                                                                Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                                            <asp:HiddenField ID="HFQualificationRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                                             <%--<asp:CheckBox ID="cbIsMandatoryQualification" CssClass="cssCheckBox" runat="server"
                                                                                                Enabled="false" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString())%>' />--%>
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <%--<asp:CheckBox ID="cbIsMandatoryQualification" CssClass="cssCheckBox" runat="server"
                                                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString())%>' />--%>
                                                                                            <asp:HiddenField ID="HFQualificationRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                                            <asp:DropDownList ID="ddlQualificationRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                                            <%--<asp:RadioButtonList ID="RBLQualificationRigidityLevel" runat="server">
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                                            </asp:RadioButtonList>--%>
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                          <%--  <asp:CheckBox ID="cbIsMandatoryQualification" CssClass="cssCheckBox" runat="server" />--%>
                                                                                            <asp:DropDownList ID="ddlQualificationRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                                           <%-- <asp:RadioButtonList ID="RBLQualificationRigidityLevel" runat="server">
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                                                <asp:ListItem Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                                            </asp:RadioButtonList>--%>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                        <td style="width: 20px;">
                                                                        </td>
                                                                        <td style="vertical-align: top; text-align: left;">
                                                                            <asp:GridView Width="450px" ID="gvLanguage" CssClass="GridViewStyle" runat="server"
                                                                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvLanguage_RowCommand"
                                                                                OnRowUpdating="gvLanguage_RowUpdating" OnRowDataBound="gvLanguage_RowDataBound"
                                                                                OnRowCancelingEdit="gvLanguage_RowCancelingEdit" OnPageIndexChanging="gvLanguage_PageIndexChanging"
                                                                                OnRowDeleting="gvLanguage_RowDeleting" OnRowEditing="gvLanguage_RowEditing">
                                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblaction" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                                                ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                                                ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblgvhdrLanguageCode" runat="server" Text="<%$ Resources:Resource, LanguageCode %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblgvLanguageCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LanguageDesc").ToString()%>'></asp:Label>
                                                                                            <asp:HiddenField ID="HFLanguageCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LanguageCode").ToString()%>' />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlLanguageCode" runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <asp:HiddenField ID="hfLanguageCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LanguageCode").ToString()%>' />
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlLanguageCode" runat="server">
                                                                                            </asp:DropDownList>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblgvhdrIsMandatoryLanguage" runat="server" Text="<%$ Resources:Resource, IsMandatory %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%--<asp:CheckBox ID="cbIsMandatoryLanguage" CssClass="cssCheckBox" runat="server" Enabled="false"
                                                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsMandatory").ToString())%>' />--%>
                                                                                            <asp:Label ID="lblLanguageRigiditylevel" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                                            <asp:HiddenField ID="HFLanguageRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <%-- <asp:CheckBox ID="cbIsMandatoryLanguage" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsMandatory").ToString())%>' />--%>
                                                                                            <asp:HiddenField ID="HFLanguageRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                                            <asp:DropDownList ID="ddlLanguageRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                                            <%--<asp:RadioButtonList ID="RBLLanguageRigidityLevel" runat="server">
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                                            </asp:RadioButtonList>--%>
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <%-- <asp:CheckBox ID="cbIsMandatoryLanguage" CssClass="cssCheckBox" runat="server" />--%>
                                                                                            <asp:DropDownList ID="ddlLanguageRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                                            <%--<asp:RadioButtonList ID="RBLLanguageRigidityLevel" runat="server">
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                                                <asp:ListItem Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                                            </asp:RadioButtonList>--%>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; text-align: left;">
                                                                            <asp:GridView Width="450px" ID="gvOSkill" CssClass="GridViewStyle" runat="server"
                                                                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvOSkill_RowCommand"
                                                                                OnRowUpdating="gvOSkill_RowUpdating" OnRowDataBound="gvOSkill_RowDataBound" OnRowCancelingEdit="gvOSkill_RowCancelingEdit"
                                                                                OnRowDeleting="gvOSkill_RowDeleting" OnPageIndexChanging="gvOSkill_PageIndexChanging"
                                                                                OnRowEditing="gvOSkill_RowEditing">
                                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblaction" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                                                ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                                                ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblgvhdrOSkillCode" runat="server" Text="<%$ Resources:Resource, IdDetails %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblgvOSkillCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IDTypeDesc").ToString()%>'></asp:Label>
                                                                                            <asp:HiddenField ID="HFSkillCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OtherSkillCode").ToString()%>' />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlOSkillCode" runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <asp:HiddenField ID="hfOSkillCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OtherSkillCode").ToString()%>' />
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlOSkillCode" runat="server">
                                                                                            </asp:DropDownList>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblgvhdrIsMandatoryOSkill" runat="server" Text="<%$ Resources:Resource, IsMandatory %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblRigiditylevel" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                                            <asp:HiddenField ID="HFRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:HiddenField ID="HFSkillRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                                            <asp:DropDownList ID="ddlSkillRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                                            <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                                            </asp:RadioButtonList>--%>
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:DropDownList ID="ddlSkillRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                                            <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                                                <asp:ListItem Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                                            </asp:RadioButtonList>--%>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                        <td style="width: 20px;">
                                                                        </td>
                                                                        <td style="vertical-align: top; text-align: left;">
                                                                            <asp:GridView Width="450px" ID="gvTraining" CssClass="GridViewStyle" runat="server"
                                                                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="2"
                                                                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvTraining_RowCommand"
                                                                                OnRowUpdating="gvTraining_RowUpdating" OnRowDataBound="gvTraining_RowDataBound"
                                                                                OnRowCancelingEdit="gvTraining_RowCancelingEdit" OnPageIndexChanging="gvTraining_PageIndexChanging"
                                                                                OnRowDeleting="gvTraining_RowDeleting" OnRowEditing="gvTraining_RowEditing">
                                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblaction" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                                                ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                                                ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblgvhdrTrainingCode" runat="server" Text="<%$ Resources:Resource, TrainingCode %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblgvTrainingCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TrainingDesc").ToString()%>'></asp:Label>
                                                                                            <asp:HiddenField ID="HFTrainingCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TrainingCode").ToString()%>' />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlTrainingCode" runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <asp:HiddenField ID="hfTrainingCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TrainingCode").ToString()%>' />
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" ID="ddlTrainingCode" runat="server">
                                                                                            </asp:DropDownList>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblgvhdrIsMandatoryTraining" runat="server" Text="<%$ Resources:Resource, IsMandatory %>"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblRigiditylevel" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                                            <asp:HiddenField ID="HFRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                                        </ItemTemplate>
                                                                                        <EditItemTemplate>
                                                                                            <asp:HiddenField ID="HFTrainingRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RigidityLevel").ToString()%>' />
                                                                                            <asp:DropDownList ID="ddlTrainingRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                                            <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                                            </asp:RadioButtonList>--%>
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:DropDownList ID="ddlTrainingRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                                            <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Mandatory %>" Value="M"></asp:ListItem>
                                                                                                <asp:ListItem Selected="true" Text="<%$Resources:Resource,Recommended %>" Value="R"></asp:ListItem>
                                                                                                <asp:ListItem Text="<%$Resources:Resource,Informative %>" Value="I"></asp:ListItem>
                                                                                            </asp:RadioButtonList>--%>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <td colspan="6">
                                                            <asp:GridView Width="100%" ID="gvClientConstraint" CssClass="GridViewStyle" runat="server"
                                                                ShowFooter="True" AllowPaging="True" PageSize="15" CellPadding="1" GridLines="None"
                                                                AutoGenerateColumns="False" OnRowCommand="gvClientConstraint_RowCommand" OnRowUpdating="gvClientConstraint_RowUpdating"
                                                                OnRowDeleting="gvClientConstraint_RowDeleting" OnRowEditing="gvClientConstraint_RowEditing"
                                                                OnRowCancelingEdit="gvClientConstraint_RowCancelingEdit" OnRowDataBound="gvClientConstraint_RowDataBound"
                                                                OnPageIndexChanging="gvClientConstraint_PageIndexChanging">
                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                                                                Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnEdit" CssClass="csslnkButton"
                                                                                Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                                ValidationGroup="vgCEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                                                                ValidationGroup="vgCEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                                                                Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                                ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                                                                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                                                                Text="<%$ Resources:Resource, AddNew %>" ValidationGroup="vgCFooter" CommandName="Add"></asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                            <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                                                                Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                                                                        </FooterTemplate>
                                                                        <ItemStyle Width="100px" />
                                                                        <HeaderStyle Width="100px" />
                                                                        <FooterStyle Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,Code %>">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblConstraintType" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeDesc").ToString()%>'></asp:Label>
                                                                            <asp:HiddenField ID="HFConstraintTypeAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeAutoID").ToString()%>' />
                                                                            <asp:HiddenField ID="HFClientConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraintAutoID").ToString()%>' />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:DropDownList ID="ddlConstraintType" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                                                OnSelectedIndexChanged="ddlConstraintType_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:HiddenField ID="HFConstraintTypeAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeAutoID").ToString()%>' />
                                                                            <asp:HiddenField ID="HFClientConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientConstraintAutoID").ToString()%>' />
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList ID="ddlConstraintType" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintType_SelectedIndexChanged"
                                                                                runat="server" CssClass="cssDropDown">
                                                                            </asp:DropDownList>
                                                                        </FooterTemplate>
                                                                        <ItemStyle Width="100px" />
                                                                        <HeaderStyle Width="100px" />
                                                                        <FooterStyle Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,Description %>">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblConstraintDesc" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintDesc").ToString()%>'></asp:Label>
                                                                            <asp:HiddenField ID="HFConstraintCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintCode").ToString()%>' />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:DropDownList ID="ddlConstraintDesc" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintDesc_SelectedIndexChanged"
                                                                                runat="server" CssClass="cssDropDown">
                                                                            </asp:DropDownList>
                                                                            <asp:HiddenField ID="HFConstraintCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintCode").ToString()%>' />
                                                                            <asp:HiddenField ID="HFConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintAutoID").ToString()%>' />
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList ID="ddlConstraintDesc" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintDesc_SelectedIndexChanged"
                                                                                runat="server" CssClass="cssDropDown">
                                                                            </asp:DropDownList>
                                                                        </FooterTemplate>
                                                                        <ItemStyle Width="300px" />
                                                                        <HeaderStyle Width="300px" />
                                                                        <FooterStyle Width="300px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,Operator %>">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOperator" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Operator").ToString()%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:HiddenField ID="HFOperator" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OperatorValue").ToString()%>' />
                                                                            <asp:DropDownList ID="ddlOperator" Width="100px" CssClass="cssDropDown" runat="server">
                                                                                <asp:ListItem Text="Greater Than" Value=">"></asp:ListItem>
                                                                                <asp:ListItem Text="Less Than" Value="<"></asp:ListItem>
                                                                                <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                                                                <asp:ListItem Text="Like" Value="%"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList ID="ddlOperator" Width="100px" CssClass="cssDropDown" runat="server">
                                                                                <asp:ListItem Text="Greater Than" Value=">"></asp:ListItem>
                                                                                <asp:ListItem Text="Less Than" Value="<"></asp:ListItem>
                                                                                <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                                                                <asp:ListItem Text="Like" Value="%"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,Value %>">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblValue" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Value").ToString()%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:DropDownList ID="ddlValue" Style="display: none;" Width="150px" runat="server"
                                                                                CssClass="cssDropDown">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="txtValue" Width="150px" runat="server" CssClass="csstxtbox" Text='<%# DataBinder.Eval(Container.DataItem, "Value").ToString()%>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList ID="ddlValue" Style="display: none;" Width="150px" runat="server"
                                                                                CssClass="cssDropDown">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="txtValue" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,RigidityLevel %>">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRigiditylevel" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "RigidityLevelDesc").ToString()%>'></asp:Label>
                                                                            <asp:HiddenField ID="HFRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Rigiditylevel").ToString()%>' />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:HiddenField ID="HFRigidityLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Rigiditylevel").ToString()%>' />
                                                                            <asp:DropDownList ID="ddlRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                            <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                                <asp:ListItem Text="Mandatory" Value="M"></asp:ListItem>
                                                                                <asp:ListItem Text="Recommended" Value="R"></asp:ListItem>
                                                                                <asp:ListItem Text="Informative" Value="I"></asp:ListItem>
                                                                            </asp:RadioButtonList>--%>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList ID="ddlRigidityLevel" CssClass="cssDropDown" Width="150px" runat="server"></asp:DropDownList>
                                                                            <%--<asp:RadioButtonList ID="RBLRigidityLevel" runat="server">
                                                                                <asp:ListItem Text="Mandatory" Value="M"></asp:ListItem>
                                                                                <asp:ListItem Selected="true" Text="Recommended" Value="R"></asp:ListItem>
                                                                                <asp:ListItem Text="Informative" Value="I"></asp:ListItem>
                                                                            </asp:RadioButtonList>--%>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                   <table class="table table-hover">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:LinkButton ID="btnUpdateSaleOrders" runat="server" Text="<%$ Resources:Resource,UpdateToSaleOrders %>" OnClick="btnUpdateSaleOrders_Click"></asp:LinkButton>
                                                        </td>
                                                        <td align="center">
                                                            <asp:LinkButton ID="btnUpdateSaleOrdersWithoutHistory" runat="server" Text="<%$ Resources:Resource,UpdateSaleOrdersWithoutHistory %>" OnClick="btnUpdateSaleOrdersWithoutHistory_Click"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <asp:Label ID="lblConstraintErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <AjaxToolKit:TabPanel runat="server" ID="pnlClientAdditionalDetails" HeaderText="<%$ Resources:Resource,ClientAddDetail %>">
                                            <ContentTemplate>
                                                <asp:Panel ID="pClientAdd" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,ClientAddDetail %>"
                                                    runat="server" BorderWidth="0px">
                                                    <table class="table table-hover">
                                                        <tr>
                                                            <td align="right" style="width: 118px">
                                                                <asp:Label Width="100px" runat="server" ID="lblClientCodeAdd" Text="<%$ Resources:Resource,ClientCode %>"
                                                                    CssClass="cssLable"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 132px">
                                                                <asp:TextBox Width="120px" runat="server" ID="txtClientCodeAdd" CssClass="csstxtboxReadonly"
                                                                    ReadOnly="True" TabIndex="4" ></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtClientCodeAdd"
                                                                    ValidationGroup="vgClientAdd" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="right" style="height: 41px; width: 73px;">
                                                                <asp:Label CssClass="cssLable" ID="lblClientNameAdd" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 41px; width: 233px;">
                                                                <asp:TextBox ID="txtClientNameAdd" runat="server" CssClass="csstxtboxReadonly" Columns="45"
                                                                    MaxLength="100" TabIndex="5" ReadOnly="True"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="req2" runat="server" ControlToValidate="txtClientNameAdd"
                                                                    ValidationGroup="vgClientAdd" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="height: 41px; width: 162px">
                                                                <asp:Label CssClass="cssLable" ID="lblAbvtClientName" runat="server" Text="<%$ Resources:Resource, AbbreviateClientName %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 41px">
                                                                <asp:TextBox ID="txtAbvtClientName" runat="server" CssClass="csstxtbox" Columns="45"
                                                                    MaxLength="50" TabIndex="1" Width="140px"></asp:TextBox>
                                                            </td>
                                                            <td align="right" style="height: 41px; width: 162px;">
                                                                <asp:Label CssClass="cssLable" ID="lblMarketRegulation" runat="server" Text="<%$ Resources:Resource, MarketFinancialRegulation %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 41px">
                                                                <asp:RadioButton runat="server" ID="rbtnMarketRegulationYes" GroupName="grpMarketReg"
                                                                    Text="<%$ Resources:Resource, Yes %>" />
                                                                <asp:RadioButton runat="server" ID="rbtnMarketRegulationNo" Checked="true" GroupName="grpMarketReg"
                                                                    Text="<%$ Resources:Resource, No %>" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="height: 41px; width: 118px;">
                                                                <asp:Label CssClass="cssLable" ID="lblPvtCompNo" runat="server" Text="<%$ Resources:Resource, PrivateCompanyNo %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 41px; width: 132px;">
                                                                <asp:TextBox ID="txtPvtCompNo" runat="server" CssClass="csstxtboxRequired" Columns="45"
                                                                    MaxLength="100" TabIndex="2" Width="120px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="req3" runat="server" ControlToValidate="txtPvtCompNo"
                                                                    ValidationGroup="vgClientAdd" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="right" style="height: 41px; width: 73px;">
                                                                <asp:Label CssClass="cssLable" ID="lblSectorNo" runat="server" Text="<%$ Resources:Resource, VATNo %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 41px">
                                                                <asp:TextBox ID="txtSectorNo" runat="server" CssClass="csstxtboxRequired" Columns="45"
                                                                    MaxLength="20" Width="100px" TabIndex="3"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="req4" runat="server" ControlToValidate="txtSectorNo"
                                                                    ValidationGroup="vgClientAdd" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Label runat="server" ID="lblErrorAddMsg" CssClass="csslblErrMsg"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            <asp:Button ID="btnAddSubmit" runat="server" Text="<%$ Resources:Resource,Submit %>"
                                                                                ValidationGroup="vgClient" CssClass="cssButton" TabIndex="6" OnClick="btnAddSubmit_Click" />
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            <asp:Button ID="btnAddReset" runat="server" Text="<%$ Resources:Resource,Reset %>"
                                                                                CssClass="cssButton" TabIndex="7" OnClick="btnAddReset_Click" />
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            <asp:Button ID="btnAddUpdate" runat="server" Text="<%$ Resources:Resource,Update %>"
                                                                                ValidationGroup="vgClient" CssClass="cssButton" TabIndex="8" OnClick="btnAddUpdate_Click" />
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            <asp:Button ID="btnAddCancel" runat="server" Text="<%$ Resources:Resource,Delete %>"
                                                                                CssClass="cssButton" TabIndex="33" OnClick="btnAddCancel_Click" />
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                    </AjaxToolKit:TabContainer>
                                </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
</asp:Content>
