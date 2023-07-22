<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyClient.aspx.cs" Inherits="Sales_CompanyClient" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="squareboxgradientcaption" style="height: 20px;">
            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,ClientMaster %>"></asp:Label>
        </div>
        <div>
            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                <tr>
                    <td width="250" align="right">
                        <asp:Label CssClass="cssLable" ID="lblClientddlhdr" runat="server" Text="<%$Resources:Resource,Client %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList Width="400px" ID="ddlClientCompanyNotMapped" AutoPostBack="true" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlClientCompanyNotMapped_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td width="100" align="right">
                        <asp:LinkButton ID="btnList" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$Resources:Resource,ClientList %>" OnClick="btnList_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pClient" Width="" GroupingText="<%$Resources:Resource,Client %>" runat="server" BorderWidth="0">
                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label1" runat="server" Text="<%$Resources:Resource,ClientCode %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label CssClass="csstxtboxReadonly" Width="120px" ID="lblClientCode" runat="server" TabIndex="1"></asp:Label>
                        </td>
                        <td align="right" style="height: 41px">
                            <asp:Label CssClass="cssLable" ID="lblManualClientCode" runat="server" Text="<%$ Resources:Resource, ManualClientCode  %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 160px; height: 41px;">
                            <asp:TextBox Width="120px" ID="txtManualClientCode" runat="server" CssClass="csstxtboxReadonly" TabIndex="2"></asp:TextBox>
                        </td>
                        <td align="left" colspan="1" style="height: 41px">
                        </td>
                        <td align="right" style="height: 41px">
                            <asp:Label CssClass="cssLable" ID="lblClientName" runat="server" Text="<%$ Resources:Resource, ClientName  %>"></asp:Label>
                        </td>
                        <td align="left" style="height: 41px">
                            <asp:TextBox ID="txtClientName" runat="server" CssClass="csstxtboxReadonly" Columns="45" MaxLength="100" TabIndex="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfClientName" runat="server" ControlToValidate="txtClientName" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="7">
                            <asp:LinkButton ID="lbGetHOClientAdd" runat="server" CssClass="" Text="<%$Resources:Resource,ClientAddress %>" OnClick="lbGetHOClientAdd_Click"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pClientAddress" Width="" GroupingText="<%$Resources:Resource,Address %>" runat="server" BorderWidth="0">
                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblAddressLine1" runat="server" Text="<%$ Resources:Resource, AddressLine1  %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 230px" colspan="3">
                            <asp:TextBox Width="210px" ID="txtAddressLine1" runat="server" CssClass="csstxtboxRequired" MaxLength="100" TabIndex="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddressLine1" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblCity" runat="server" Text="<%$ Resources:Resource, City  %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 250">
                            <asp:TextBox Width="150px" ID="txtCity" runat="server" CssClass="csstxtboxRequired" MaxLength="100" TabIndex="7"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCity" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblState" runat="server" Text="<%$ Resources:Resource, State  %>"></asp:Label>
                        </td>
                        <td align="left" style="width: 250">
                            <asp:TextBox Width="150px" ID="txtState" runat="server" CssClass="csstxtboxRequired" MaxLength="100" TabIndex="8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtState" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblAddressLine2" runat="server" Text="<%$ Resources:Resource, AddressLine2  %>"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox Width="210px" ID="txtAddressLine2" runat="server" CssClass="csstxtbox" MaxLength="100" TabIndex="5"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblPin" runat="server" Text="<%$ Resources:Resource, Pin  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="150px" ID="txtPin" runat="server" CssClass="csstxtboxRequired" MaxLength="100" TabIndex="9"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPin" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblCountryCode" runat="server" Text="<%$ Resources:Resource, Country  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList Width="154px" runat="server" ID="ddlCountryCode" CssClass="cssDropDown" TabIndex="10">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblAddressLine3" runat="server" Text="<%$ Resources:Resource, AddressLine3  %>"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox Width="210px" ID="txtAddressLine3" runat="server" CssClass="csstxtbox"
                                MaxLength="100" TabIndex="6"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblPhone" runat="server" Text="<%$ Resources:Resource, Phone  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="150px" ID="txtPhone" runat="server" CssClass="csstxtbox" MaxLength="100" TabIndex="11"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPhone"
                                ValidationGroup="vgClient">*</asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblFax" runat="server" Text="<%$ Resources:Resource, Fax  %>"></asp:Label>
                        </td>
                        <td align="left" >
                            <asp:TextBox Width="150px" ID="txtFax" runat="server" CssClass="csstxtbox" MaxLength="100" TabIndex="12"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFax"
                                ValidationGroup="vgClient">*</asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblWebSite" runat="server" Text="<%$ Resources:Resource, WebSite  %>"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox Width="210px" ID="txtWebSite" runat="server" CssClass="csstxtbox" MaxLength="100" TabIndex="13"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtWebSite" ValidationGroup="vgClient" Display="Dynamic" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?">*</asp:RegularExpressionValidator>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblEmail" runat="server" Text="<%$ Resources:Resource, Email  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="150px" ID="txtEmail" runat="server" CssClass="csstxtbox" MaxLength="100" TabIndex="14"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmail"
                                ValidationGroup="vgClient">*</asp:RequiredFieldValidator>--%>
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
            <asp:Panel ID="pOther" Width="" GroupingText="<%$Resources:Resource,Details %>" runat="server" BorderWidth="0">
                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" Width="100px" ID="lblClientContactPerson" runat="server"
                                Text="<%$ Resources:Resource, ContactPerson  %>"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox Width="150px" ID="txtClientContactPerson" runat="server" CssClass="csstxtboxRequired"
                                MaxLength="100" TabIndex="15"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtClientContactPerson"
                                ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblClientContactPersonDesignation" runat="server"
                                Text="<%$ Resources:Resource, Designation  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="150px" ID="txtClientContactPersonDesignation" runat="server"
                                CssClass="csstxtboxRequired" MaxLength="100" TabIndex="16"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtClientContactPersonDesignation"
                                ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblClientContactPersonMobile" runat="server" Text="<%$ Resources:Resource, ContactNumber  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="150px" ID="txtClientContactPersonMobile" runat="server" CssClass="csstxtbox"
                                MaxLength="100" TabIndex="17"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtClientContactPersonMobile"
                                ValidationGroup="vgClient">*</asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblOurContactPersonEmpNo" runat="server" Text="<%$ Resources:Resource, EmployeeNumber  %>"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox Width="150px" ID="txtOurContactPersonEmpNo" runat="server" CssClass="csstxtboxRequired" MaxLength="100" TabIndex="18"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtOurContactPersonEmpNo" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblOurContactPerson" runat="server" Text="<%$ Resources:Resource, OurRepresentative  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="150px" ID="txtOurContactPerson" runat="server" CssClass="csstxtbox" MaxLength="100" TabIndex="19"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblOurContactPersonMobile" runat="server" Text="<%$ Resources:Resource, ContactNumber  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="150px" ID="txtOurContactPersonMobile" runat="server" CssClass="csstxtbox" MaxLength="100" TabIndex="20"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtOurContactPersonMobile" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                        <td align="right" style="width: 110px">
                            <asp:Label CssClass="cssLable" ID="lblComments" runat="server" Text="<%$ Resources:Resource, Comment  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="150px" ID="txtComments" runat="server" CssClass="csstxtbox" MaxLength="100" TabIndex="21"></asp:TextBox>
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
                        <asp:Button ID="btnSubmit" runat="server" Text="<%$Resources:Resource,Submit %>" ValidationGroup="vgClient"
                            CssClass="cssButton" OnClick="btnSubmit_Click" TabIndex="22" />
                        <asp:Button ID="btnReset" runat="server" Text="<%$Resources:Resource,Reset %>" CssClass="cssButton" OnClick="btnReset_Click" TabIndex="23" />
                            <asp:Button ID="btnUpdate" runat="server" Text="<%$Resources:Resource,Update %>" ValidationGroup="vgClient"
                            CssClass="cssButton" OnClick="btnUpdate_Click" TabIndex="24" />
                        <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:Resource,Cancel %>" CssClass="cssButton" OnClick="btnCancel_Click" TabIndex="25" />
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
</Ajax:UpdatePanel>
</asp:Content>
