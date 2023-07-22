<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeAddress.aspx.cs" Inherits="HRManagement_EmployeeAddress" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 950px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 20px;">
                                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,Address %>"></asp:Label>
                                </div>
                                <div>
                                    <table border="0" cellpadding="3" cellspacing="0" width="70%">
                                        <tr>
                                            <td width="90" align="left">
                                                <asp:Label CssClass="cssLable" ID="lblEmployeeNumber" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="csstxtboxReadonly" ID="txtEmployeeNumber" runat="server" ReadOnly="true"></asp:TextBox>
                                                <asp:TextBox CssClass="csstxtboxReadonly" ID="txtEmployeeName" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label CssClass="cssLable" ID="LabelStatus" runat="server" Text="<%$Resources:Resource,Status %>"></asp:Label>
                                                <asp:TextBox CssClass="csstxtboxReadonly" ID="txtStatus" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Panel ID="pAddType" Width="" GroupingText="<%$Resources:Resource,AddType %>"
                                        runat="server" BorderWidth="0">
                                        <table border="0" cellpadding="1" cellspacing="0" width="90%">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblAddType" runat="server" Text="<%$ Resources:Resource, SelAddType  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlAddressType" TabIndex="1" Width="184px" runat="server" AutoPostBack="true"
                                                        CssClass="cssDropDown" OnSelectedIndexChanged="ddlAddressType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pAddDetails" Width="" GroupingText="<%$Resources:Resource,AddDetails %>"
                                        runat="server" BorderWidth="0">
                                        <table border="0" cellpadding="1" cellspacing="0" width="70%">
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblAddress1" runat="server" Text="<%$ Resources:Resource, AddressLine1  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:TextBox Width="210px" ID="txtAddressLine1" TabIndex="2" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtAddress1" runat="server"
                                                        ControlToValidate="txtAddressLine1" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblPhone1" runat="server" Text="<%$ Resources:Resource, Phone1  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox Width="150px" ID="txtPhone1" runat="server" TabIndex="9" CssClass="csstxtbox"
                                                        MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblAddress2" runat="server" Text="<%$ Resources:Resource, AddressLine2  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:TextBox Width="210px" ID="txtAddressLine2" TabIndex="3" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="100"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtAddress2" runat="server" ControlToValidate="txtAddress2"
                                                        ValidationGroup="vgClient">*</asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblPhone2" runat="server" Text="<%$ Resources:Resource, Phone2  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox Width="150px" ID="txtPhone2" runat="server" TabIndex="10" CssClass="csstxtbox"
                                                        MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblAddress3" runat="server" Text="<%$ Resources:Resource, AddressLine3  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:TextBox Width="210px" ID="txtAddressLine3" TabIndex="4" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="100"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtAddressLine3" runat="server" ControlToValidate="txtAddressLine3"
                                                        ValidationGroup="vgClient">*</asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblEmail" runat="server" Text="<%$ Resources:Resource, Email  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox Width="150px" ID="txtEmail" runat="server" TabIndex="11" CssClass="csstxtbox"
                                                        MaxLength="100"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatortxtEmail" runat="server"
                                                        ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="vgClient" Display="Dynamic"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblCity" runat="server" Text="<%$ Resources:Resource, City  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:TextBox Width="210px" ID="txtCity" TabIndex="5" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="100"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblFax" runat="server" Text="<%$ Resources:Resource, Fax  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox Width="150px" ID="txtFax" runat="server" TabIndex="12" CssClass="csstxtbox"
                                                        MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblState" runat="server" Text="<%$ Resources:Resource, State  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:TextBox Width="210px" ID="txtState" TabIndex="6" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="100"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblMobileNo" runat="server" Text="<%$ Resources:Resource, MobileNumber  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox Width="150px" ID="txtMobileNumber" runat="server" TabIndex="13" CssClass="csstxtbox"
                                                        MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblCountryCode" runat="server" Text="<%$ Resources:Resource, Country  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:DropDownList Width="210px" runat="server" TabIndex="7" ID="ddlCountryCode" CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblPrefChannelComm" runat="server" Text="<%$ Resources:Resource, PrefChannelComm  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList Width="150px" runat="server" ID="ddlPrefChannelComm" TabIndex="14"
                                                        CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 110px">
                                                    <asp:Label CssClass="cssLable" ID="lblPin" runat="server" Text="<%$ Resources:Resource, Pin  %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="3">
                                                    <asp:DropDownList Width="75px" runat="server" ID="ddlGroupZip" AutoPostBack="True" CssClass="cssDropDown" OnSelectedIndexChanged="ddlGroupZip_SelectedIndexChanged"></asp:DropDownList>
                                                    <asp:DropDownList Width="75px" runat="server" ID="ddlZip" CssClass="cssDropDown"></asp:DropDownList>
                                                    <%--<asp:TextBox Width="210px" ID="txtPin" runat="server" TabIndex="8" CssClass="csstxtboxRequired" MaxLength="100"></asp:TextBox>--%>
                                                </td>
                                                <td align="right">
                                                    <asp:Label CssClass="cssLable" ID="lblContactPerson" runat="server" Text="<%$ Resources:Resource, ContactPerson  %>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox Width="150px" ID="txtContactPerson" runat="server" TabIndex="9" CssClass="csstxtboxRequired"
                                                        MaxLength="100"></asp:TextBox>
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
                                                <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:Resource,Back %>"
                                                    CssClass="cssButton" TabIndex="16" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
