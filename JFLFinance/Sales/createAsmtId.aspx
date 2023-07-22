<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreateAsmtId.aspx.cs" Inherits="Sales_CreateAssignmentId" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
        <ContentTemplate>--%>
            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="btnList" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$Resources:Resource,ViewAddressList %>" OnClick="btnList_Click"></asp:LinkButton>&nbsp&nbsp&nbsp&nbsp
                    <asp:LinkButton ID="btnClientMaster" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$Resources:Resource,ClientMaster %>" OnClick="btnClientMaster_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pClient" GroupingText="<%$Resources:Resource,Client %>" runat="server" BorderWidth="0">
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label1" runat="server" Text="<%$Resources:Resource,ClientCode %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label CssClass="cssLabelValue" ID="lblClientCode" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label2" runat="server" Text="<%$ Resources:Resource, ManualClientCode  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblManualClientCode" CssClass="cssLabelValue" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label16" runat="server" Text="<%$ Resources:Resource, ClientName  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblClientName" CssClass="cssLabelValue" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel9" GroupingText="<%$Resources:Resource,Asmt %>" runat="server" BorderWidth="0">
                <table border="0" cellpadding="3" cellspacing="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblAsmtId" runat="server" Text="<%$Resources:Resource,AsmtId %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox CssClass="csstxtboxReadonly" ID="txtAsmtId" runat="server" ReadOnly="true" MaxLength="16" Width="100px"></asp:TextBox>
                            <asp:DropDownList ID="ddlIdType" runat="server" AutoPostBack="true" CssClass="cssDropDown"
                                Width="100px" OnSelectedIndexChanged="ddlIdType_SelectedIndexChanged">
                                <asp:ListItem Text="<%$Resources:Resource, AssignmentID %>" Value="A"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource, AsmtBillingID %>" Value="B"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label11" runat="server" Text="<%$Resources:Resource,FromDate %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" ValidationGroup="vgClient" runat="server"
                                Width="100px" AutoPostBack="false" CssClass="csstxtboxReadonly"></asp:TextBox>
                            <asp:ImageButton ID="IMGFromDate" Style="vertical-align: middle" CausesValidation="true"
                                runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtFromDate" PopupButtonID="IMGFromDate" PopupPosition="TopLeft" />
                            <asp:RequiredFieldValidator ID="RfvFromDate" runat="server" ControlToValidate="txtFromDate"
                                ErrorMessage="*" ValidationGroup="vgClient" ForeColor="Red" SetFocusOnError="true" />
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label15" runat="server" Text="<%$Resources:Resource,ToDate %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" Enabled="false" runat="server" Width="100px" AutoPostBack="false"
                                CssClass="csstxtboxReadonly"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="lblAsmtName" runat="server" Text="<%$Resources:Resource,AsmtName %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="210px" ID="txtAddress" runat="server" CssClass="csstxtboxRequired" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            <asp:Label CssClass="cssLable" ID="Label9" runat="server" Text="<%$Resources:Resource,JobNo %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox Width="120px" ID="txtJobNo" runat="server" CssClass="csstxtboxRequired" MaxLength="100"></asp:TextBox>
                        </td>
                        <td colspan="2"></td>
                    </tr>
                </table>
            </asp:Panel>
            <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="ClientDetailsSite" ActiveTabIndex="0" AutoPostBack="true">
                <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelClientDetails" runat="server" HeaderText="<%$Resources:Resource,AssignmentAddress %>" TabIndex="0">
                    <ContentTemplate>
                        <asp:Panel ID="pClientAddress" GroupingText="<%$ Resources:Resource,Address %>" runat="server" BorderWidth="0px">
                            <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblAddress" runat="server" Text="<%$ Resources:Resource, AddressLine1 %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox CssClass="csstxtbox" ID="txtAsmtName" Width="200px" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAsmtName" runat="server" ControlToValidate="txtAsmtName" ValidationGroup="vgClient">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblCity" runat="server" Text="<%$ Resources:Resource, City %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtCity" runat="server" CssClass="csstxtboxRequired" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblState" runat="server" Text="<%$ Resources:Resource, State %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtState" runat="server" CssClass="csstxtboxRequired" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
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
                                        <asp:DropDownList Width="154px" runat="server" ID="ddlCountryCode" CssClass="cssDropDown">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblPhone" runat="server" Text="<%$ Resources:Resource, Phone %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtPhone" runat="server" CssClass="csstxtbox" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblFax" runat="server" Text="<%$ Resources:Resource, Fax %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtFax" runat="server" CssClass="csstxtbox" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblEmail" runat="server" Text="<%$ Resources:Resource, Email %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtEmail" runat="server" CssClass="csstxtbox" MaxLength="100"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtEmail" ValidationGroup="vgClient" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td align="right" colspan="2"></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="6">
                                        <asp:Button ID="btnMultilingual" CssClass="btn btn-primary btn-xs" runat="server" OnClick="btnMultilingual_Click" Text="<%$ Resources:Resource, MultilingualEntry %>" />
                                        <asp:LinkButton ID="lbGetHOClientAdd" runat="server" CssClass="btn btn-primary btn-xs" Text="<%$ Resources:Resource,GetClientMasterAddress %>" OnClick="lbGetHOClientAdd_Click"></asp:LinkButton>
                                        <asp:Button ID="Button3" runat="server" Style="display: none" />
                                        <asp:Panel ID="Panel6" BackColor="White" runat="server" Height="150px" Width="450px" Style="display: none;">
                                            <AjaxToolKit:ModalPopupExtender ID="MPAsmtDetail" runat="server" TargetControlID="Button3" PopupControlID="Panel6" X="250" Y="50" BackgroundCssClass="modalBackground" BehaviorID="_content_MPAsmtDetail" DynamicServicePath="">
                                            </AjaxToolKit:ModalPopupExtender>
                                            <div class="squareboxgradientcaption" style="height: 20px; width: 100%">
                                                <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Resource,Address %>"></asp:Label>
                                            </div>
                                            <div>
                                                <table border="0" width="100%">
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Address %>"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:TextBox ID="txtOtherLanguageADD1" Width="240px" MaxLength="100" CssClass="csstxtboxRequired" runat="server"></asp:TextBox>
                                                            <asp:HiddenField ID="HFOtherLanguageADD1" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <br></br>
                                                            <br></br>
                                                            <asp:Button ID="btnOk" CssClass="cssButton" OnClick="btnOk_Click" runat="server" Text="<%$ Resources:Resource,Save %>" />
                                                            <asp:Button ID="btnMultilingualCancel" CssClass="cssButton" OnClick="btnMultilingualCancel_Click" runat="server" Text="<%$ Resources:Resource,Cancel %>" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pOther" GroupingText="<%$ Resources:Resource,Details %>" runat="server" BorderWidth="0px">
                            <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" Width="100px" Visible="False" ID="lblClientContactPerson"
                                            runat="server" Text="<%$ Resources:Resource, ContactPerson %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtClientContactPerson" Visible="False" runat="server"
                                            CssClass="csstxtboxRequired" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblClientContactPersonDesignation" Visible="False"
                                            runat="server" Text="<%$ Resources:Resource, Designation %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtClientContactPersonDesignation" Visible="False"
                                            runat="server" CssClass="csstxtboxRequired" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblClientContactPersonMobile" Visible="False"
                                            runat="server" Text="<%$ Resources:Resource, ContactNumber %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtClientContactPersonMobile" Visible="False" runat="server"
                                            CssClass="csstxtbox" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblPremisesType" runat="server" Text="<%$ Resources:Resource, PremisesType %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList Width="154px" runat="server" ID="ddlPremisesType" CssClass="cssDropDown">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="Label3" runat="server" Text="<%$ Resources:Resource, AreaId %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList Width="154px" runat="server" ID="ddlAreaId" CssClass="cssDropDown"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlAreaId_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="Label5" runat="server" Text="<%$ Resources:Resource, AreaIncharge %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Enabled="False" CssClass="csstxtboxReadonly" runat="server" ID="txtAreaIncharge"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label CssClass="cssLable" ID="lblComments" runat="server" Text="<%$ Resources:Resource, Comment %>"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Width="150px" ID="txtComments" runat="server" CssClass="csstxtbox" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label EnableViewState="False" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:Resource,Apply %>" ValidationGroup="vgClient"
                                        CssClass="cssButton" OnClick="btnSubmit_Click1"  />
                                    <asp:Button ID="btnReset" runat="server" Text="<%$ Resources:Resource,Reset %>" CssClass="cssButton"
                                        OnClick="btnReset_Click" />
                                    <asp:Button ID="btnResetAll" runat="server" Text="<%$ Resources:Resource,ResetAll %>"
                                        CssClass="cssButton" OnClick="btnResetAll_Click" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:Resource,Update %>"
                                        ValidationGroup="vgClient" CssClass="cssButton" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:Resource,Cancel %>"
                                        CssClass="cssButton" OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </AjaxToolKit:TabPanel>
                <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelContactDetails" runat="server" HeaderText="<%$Resources:Resource,ContactDetails %>" TabIndex="1">
                    <ContentTemplate>
                        <asp:Panel ID="PanelContactInformation" GroupingText="<%$Resources:Resource,ContactDetails %>"
                            runat="server" Width="100%" ScrollBars="Auto" CssClass="ScrollBar">
                            <asp:GridView ID="GvContactInformation" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="1" OnPageIndexChanging="GvContactInformation_PageIndexChanging"
                                OnRowCancelingEdit="GvContactInformation_RowCancelingEdit" OnRowCommand="GvContactInformation_RowCommand"
                                OnRowDataBound="GvContactInformation_RowDataBound" OnRowDeleting="GvContactInformation_RowDeleting"
                                OnRowEditing="GvContactInformation_RowEditing" OnRowUpdating="GvContactInformation_RowUpdating"
                                PageSize="15" ShowFooter="True" Width="100%">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField FooterStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeaderSerial" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, SerialNumber %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerial" runat="server" CssClass="cssLable"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeaderContactUniqueNo" runat="server" CssClass="cssLabelHeader"
                                                Text="Company Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemContactUniqueNo" runat="server" CssClass="cssLable" Text='<%# Bind("ContactUniqueNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditContactUniqueNo" runat="server" CssClass="cssLable" Text='<%# Eval("ContactUniqueNo") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField FooterStyle-Width="200px" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeaderContactName" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Name %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemContactName" runat="server" CssClass="cssLable" Text='<%# Bind("ContactName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditContactName" runat="server" CssClass="csstxtbox" MaxLength="50"
                                                Text='<%# Bind("ContactName") %>' ValidationGroup="vgEdit" Width="160px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEditContactName" runat="server"
                                                ControlToValidate="txtEditContactName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                                ValidationGroup="vgEdit"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewContactName" runat="server" CssClass="csstxtbox" MaxLength="225"
                                                Text='<%# Bind("ContactName") %>' ValidationGroup="AddNew" Width="160px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtNewContactName" runat="server"
                                                ControlToValidate="txtNewContactName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                                ValidationGroup="AddNew">
                                            </asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField FooterStyle-Width="200px" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeaderContactDesignation" runat="server" CssClass="cssLabelHeader"
                                                Text="<%$ Resources:Resource, Designation %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemContactDesignation" runat="server" CssClass="cssLable" Text='<%# Bind("ContactDesignation") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditContactDesignation" runat="server" CssClass="csstxtbox" MaxLength="50"
                                                Text='<%# Bind("ContactDesignation") %>' ValidationGroup="vgEdit" Width="180px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewContactDesignation" runat="server" CssClass="csstxtbox" MaxLength="225"
                                                Text='<%# Bind("ContactDesignation") %>' ValidationGroup="AddNew" Width="180px"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField FooterStyle-Width="200px" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeaderContactDepartment" runat="server" CssClass="cssLabelHeader"
                                                Text="<%$ Resources:Resource, Department %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemContactDepartment" runat="server" CssClass="cssLable" Text='<%# Bind("ContactDepartment") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditContactDepartment" runat="server" CssClass="csstxtbox" MaxLength="50"
                                                Text='<%# Bind("ContactDepartment") %>' ValidationGroup="vgEdit" Width="180px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewContactDepartment" runat="server" CssClass="csstxtbox" MaxLength="225"
                                                Text='<%# Bind("ContactDepartment") %>' ValidationGroup="AddNew" Width="180px"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField FooterStyle-Width="125px" HeaderStyle-Width="125px" ItemStyle-Width="125px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeaderContactNumber" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, ContactNo %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemContactNumber" runat="server" CssClass="cssLable" Text='<%# Bind("ContactNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditContactNumber" runat="server" CssClass="csstxtbox" MaxLength="225"
                                                Text='<%# Bind("ContactNumber") %>' ValidationGroup="vgEdit" Width="120px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewContactNumber" runat="server" CssClass="csstxtbox" MaxLength="225"
                                                Text='<%# Bind("ContactNumber") %>' ValidationGroup="AddNew" Width="120px"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField FooterStyle-Width="125px" HeaderStyle-Width="125px" ItemStyle-Width="125px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeaderEMailAddress" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Email %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemEMailAddress" runat="server" CssClass="cssLable" Text='<%# Bind("EMailAddress") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditEMailAddress" runat="server" CssClass="csstxtbox" MaxLength="225"
                                                Text='<%# Bind("EMailAddress") %>' ValidationGroup="vgEdit" Width="120px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                                ErrorMessage="*" ControlToValidate="txtEditEMailAddress" ValidationGroup="vgEdit"
                                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewEMailAddress" runat="server" CssClass="csstxtbox" MaxLength="225"
                                                Text='<%# Bind("EMailAddress") %>' ValidationGroup="AddNew" Width="120px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                ErrorMessage="*" ControlToValidate="txtNewEMailAddress" ValidationGroup="vgEdit"
                                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField FooterStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeaderAction" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CommandName="Update" CssClass="cssImgButton"
                                                ImageUrl="../Images/Save.gif" ToolTip="<%$ Resources:Resource, Update %>" ValidationGroup="vgEdit" />
                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CommandName="Cancel" CssClass="cssImgButton"
                                                ImageUrl="../Images/Cancel.gif" ToolTip="<%$ Resources:Resource, Cancel %>" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CommandName="Delete" CssClass="cssImgButton"
                                                ImageUrl="../Images/Delete.gif" ToolTip="<%$ Resources:Resource, Delete %>" />
                                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CommandName="Edit" CssClass="cssImgButton"
                                                ImageUrl="../Images/Edit.gif" ToolTip="<%$ Resources:Resource, Edit %>" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            `
                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CommandName="Add" CssClass="cssImgButton"
                                            ImageUrl="../Images/AddNew.gif" ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="AddNew" />
                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CommandName="Reset" CssClass="cssImgButton"
                                                ImageUrl="../Images/Reset.gif" ToolTip="<%$ Resources:Resource, Reset %>" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </AjaxToolKit:TabPanel>
                <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelClientAttendanceDetails" runat="server" HeaderText="<%$Resources:Resource,AssignmentDetails %>" TabIndex="2">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAmendNo" runat="server" Style="display: none;" Text="<%$Resources:Resource,AmendNo %>"
                                        CssClass="cssLabel"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAmendNo" runat="server" Style="display: none;" AutoPostBack="true" CssClass="cssDropDownSmall" OnSelectedIndexChanged="ddlAmendNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAttendanceType" runat="server" Text="<%$Resources:Resource,AttendanceType %>" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList CssClass="cssDropDownRequired" runat="server" ID="ddlAttendanceType" AutoPostBack="false" Width="120px">
                                        <asp:ListItem Text="Electronic" Value="ELC"></asp:ListItem>
                                        <asp:ListItem Text="Manual" Value="MAN"></asp:ListItem>
                                        <asp:ListItem Text="Scheduling" Value="SCH" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="width: 100px">
                                    <asp:Label ID="lblWEFDate" runat="server" Text="<%$Resources:Resource,WithEffectiveFromDate %>" Style="display: none;" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td align="left" style="width: 120px">
                                    <asp:TextBox ID="txtWEFAttendDate" runat="server" Width="80px" CssClass="csstxtbox"
                                        Style="display: none;" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("WEFDate")) %>'></asp:TextBox>
                                    <asp:Image ID="imgDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="display: none;" />
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" PopupButtonID="imgDate"
                                        PopupPosition="Right" runat="server" TargetControlID="txtWEFAttendDate"></AjaxToolKit:CalendarExtender>
                                </td>
                                <td align="right" style="width: 100px">
                                    <asp:Label ID="lblBreak" runat="server" Text="<%$Resources:Resource,BreakHours %>"
                                        CssClass="cssLabel" Visible="false"></asp:Label>
                                </td>
                                <td align="left" style="width: 250px">
                                    <asp:CheckBox ID="chkBreak" runat="server" Checked="false" onClick="javascript:Func_BreakHrs(this);" Visible="false" />
                                    <asp:TextBox ID="txtBreak" runat="server" Text="0" CssClass="csstxtbox" Style="display: none"
                                        MaxLength="4" Width="50px"></asp:TextBox>
                                    <asp:RangeValidator ID="rngVal" runat="server" SetFocusOnError="true" ErrorMessage="*"
                                        Type="Integer" MinimumValue="0" MaximumValue="3600" ControlToValidate="txtBreak"
                                        Width="10px"></asp:RangeValidator>
                                </td>
                            </tr>
                            <%--   ---------------------------Manish 22-07-2013 Added Some New Filed For Setup some Meeting-----------------%>

                            <td align="right">
                                <asp:Label CssClass="cssLable" ID="lblSchSite" runat="server" Text="<%$ Resources:Resource,SchSiteSupervision %>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox CssClass="csstxtboxRequired" Width="80px" ID="txtSchSiteSupervision"
                                    Enabled="false" Text="1" runat="server" MaxLength="2" />
                                <AjaxToolKit:FilteredTextBoxExtender ID="ajxFilterSiteSuper" runat="server" FilterType="Numbers"
                                    TargetControlID="txtSchSiteSupervision" />
                            </td>
                            <td align="right">
                                <asp:Label CssClass="cssLable" ID="lblSiteFrequency" runat="server" Text="<%$ Resources:Resource, Frequency %>" />
                            </td>
                            <td align="left">
                                <asp:DropDownList CssClass="cssDropDownRequired" runat="server" ID="ddlFrequencySite"
                                    OnSelectedIndexChanged="ddlFrequencySite_SelectedIndexChanged" AutoPostBack="true"
                                    Width="120px">
                                    <asp:ListItem Text="1 Per Day" Value="PerDay"></asp:ListItem>
                                    <asp:ListItem Text="2 Per Day" Value="2PerDay"></asp:ListItem>
                                    <asp:ListItem Text="1 Per Week" Value="PerWeek" Selected="True"></asp:ListItem>
                                    <%--<asp:ListItem Text="Per 2 Week" Value="Per2Week"></asp:ListItem>--%>
                                    <asp:ListItem Text="1 Per Month" Value="PerMonth"></asp:ListItem>
                                    <asp:ListItem Text="X Per Month" Value="XPerMonth"></asp:ListItem>
                                    <%--<asp:ListItem Text="Per 2 Month" Value="Per2Month" />
                                    <asp:ListItem Text="Per 3 Month" Value="Per3Month" />
                                    <asp:ListItem Text="Per 6 Month" Value="Per6Month" />--%>
                                </asp:DropDownList>
                                </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="btnSaveAttend" runat="server" Width="100px" Text="<%$Resources:Resource,Save %>"
                                    CssClass="cssButton" OnClick="btnSaveAttend_Click" />
                                <asp:Button ID="btnDeleteAttend" Visible="false" runat="server" Width="100px" Text="<%$Resources:Resource,Delete %>"
                                    CssClass="cssButton" />
                            </td>
                        </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblConstraintErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                    </td>
                                </tr>
                        </table>
                    </ContentTemplate>
                </AjaxToolKit:TabPanel>
                <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelClientYLMDetails" runat="server"
                    HeaderText="<%$Resources:Resource,IsraelDetails %>" TabIndex="3">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" width="930px">
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnlAmend" Width="" runat="server" GroupingText="<%$Resources:Resource,AmendDetails %>"
                                        BorderWidth="0">
                                        <table cellpadding="0" cellspacing="0" width="930px">
                                            <tr>
                                                <td align="right" style="width: 90px">
                                                    <asp:Label CssClass="cssLable" ID="lblAmendYlm" runat="server" Text="<%$ Resources:Resource,AmendNo %>"
                                                        Width="100px"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 100px">
                                                    <asp:DropDownList runat="server" ID="ddlAmendYlm" Width="80px" CssClass="cssDropDownRequired"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlAmendYlm_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label CssClass="cssLable" ID="lblEffectiveFromYlm" runat="server" Text="<%$ Resources:Resource,EffectiveFrom %>"
                                                        Width="100px"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 120px">
                                                    <asp:TextBox CssClass="csstxtboxReadonly" Width="80px" ID="txtEffectiveFromYlm" MaxLength="32"
                                                        Enabled="False" runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="hdfEffectiveFromYlm" runat="server" Value="" />
                                                    <asp:ImageButton ID="imgBtnCalEfrom" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Visible="false" />
                                                    <AjaxToolKit:CalendarExtender ID="calEffectiveFrom" Format="dd-MMM-yyyy" runat="server"
                                                        PopupPosition="Right" PopupButtonID="imgBtnCalEfrom" TargetControlID="txtEffectiveFromYlm"></AjaxToolKit:CalendarExtender>
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label CssClass="cssLable" Width="100px" ID="lblEffectiveToYlm" runat="server"
                                                        Text="<%$ Resources:Resource, EffectiveTo %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px" colspan="2">
                                                    <asp:TextBox CssClass="csstxtboxReadonly" ID="txtEffectiveToYlm" runat="server" Width="80px"
                                                        Enabled="False"></asp:TextBox>
                                                    <asp:ImageButton ID="imgBtnCal" runat="server" ImageUrl="../Images/pdate.gif" Visible="false" />
                                                    <AjaxToolKit:CalendarExtender ID="calEffectiveTo" Format="dd-MMM-yyyy" runat="server"
                                                        PopupPosition="Right" PopupButtonID="imgBtnCal" TargetControlID="txtEffectiveToYlm"></AjaxToolKit:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel1" Width="" GroupingText="<%$Resources:Resource,Client %>" runat="server"
                                        BorderWidth="0">
                                        <table cellpadding="0" cellspacing="0" width="930px">
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label CssClass="cssLable" ID="Label8" runat="server" Text="<%$ Resources:Resource,AsmtId %>"
                                                        Width="100px"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 100px">
                                                    <asp:TextBox CssClass="csstxtboxReadonly" ID="txtAsmtIDYlm" runat="server" ReadOnly="True"
                                                        Width="80px" MaxLength="16"></asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label CssClass="cssLable" ID="Label10" runat="server" Text="<%$ Resources:Resource,ClientCode %>"
                                                        Width="100px"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 100px">
                                                    <asp:TextBox CssClass="csstxtboxReadonly" Width="80px" ID="txtClientCodeYlm" MaxLength="32"
                                                        Enabled="False" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label CssClass="cssLable" Width="100px" ID="Label12" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px" colspan="2">
                                                    <asp:TextBox CssClass="csstxtboxReadonly" ID="txtClientNameYLM" runat="server" Width="200px"
                                                        Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel2" Width="" GroupingText="<%$Resources:Resource,Alert %>" runat="server"
                                        BorderWidth="0">
                                        <table width="930px" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="right" style="width: 10%">
                                                    <asp:Label ID="Label13" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,SuperAlertPriority%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 15%">
                                                    <asp:DropDownList ID="ddlSuperAlertPriority" runat="server" CssClass="cssDropDownRequired">
                                                        <asp:ListItem Selected="True" Text="No Alert" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Text Message" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Email" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" style="width: 10%">
                                                    <asp:Label ID="Label14" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,SuperAlertType%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 15%">
                                                    <asp:TextBox ID="txtSuperAlertType" Width="80px" CssClass="csstxtbox" MaxLength="2"
                                                        runat="server"></asp:TextBox>
                                                    <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSuperAlertType"
                                                    ErrorMessage="2 Digit Number" ValidationExpression="^[0-9]{2}$" ValidationGroup="SMSGrp"
                                                    SetFocusOnError="true" CssClass="csslblErrMsg"></asp:RegularExpressionValidator>--%>
                                                    <asp:RangeValidator MaximumValue="15" CssClass="csslblErrMsg" runat="server" ID="RangeValidator2"
                                                        Width="50px" MinimumValue="0" ControlToValidate="txtSuperAlertType" Type="Integer"
                                                        ErrorMessage="(0-15)" SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                                <td align="right" style="width: 10%">
                                                    <asp:Label ID="lblSuperSms" Width="70px" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource, SuperSMS%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:TextBox ID="txtSuperSMS" runat="server" MaxLength="10" CssClass="csstxtbox"
                                                        Width="80px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="regSupSMS" runat="server" ControlToValidate="txtSuperSMS"
                                                        ErrorMessage="Should be Phone Number" ValidationExpression="(^\d{10}$)|(^\d{3}-\d{6}$)"
                                                        ValidationGroup="SMSGrp" SetFocusOnError="true" CssClass="csslblErrMsg"></asp:RegularExpressionValidator>
                                                    <asp:RangeValidator MaximumValue="9999999999" CssClass="csslblErrMsg" runat="server"
                                                        ID="RangeValidator14" MinimumValue="0" ControlToValidate="txtSuperSMS" Type="Double"
                                                        ErrorMessage="*" SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblSuperEmail" runat="server" Text="<%$Resources:Resource,SuperEmail%>"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <asp:TextBox ID="txtSuperEmail" runat="server" CssClass="csstxtbox" Width="250px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="regEmail" runat="server" ErrorMessage="*" SetFocusOnError="true"
                                                        ControlToValidate="txtSuperEmail" ValidationGroup="vgClient" Display="Dynamic"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                </td>
                                                <td align="right" style="width: 80px;">
                                                    <asp:Label ID="lblSuperAlertTimeGap" runat="server" Text="<%$Resources:Resource,SuperAlertTimeGap%>"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSuperAlertTimeGap" runat="server" Width="110px" MaxLength="3"
                                                        CssClass="csstxtbox"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="RegExpressionValidator2" runat="server" ControlToValidate="txtSuperAlertTimeGap"
                                                    ErrorMessage="Should be Number" ValidationExpression="^[0-9]{3}$" ValidationGroup="SMSGrp"
                                                    SetFocusOnError="true" CssClass="csslblErrMsg"></asp:RegularExpressionValidator>--%>
                                                    <asp:RangeValidator MaximumValue="180" CssClass="csslblErrMsg" runat="server" ID="RangeValidator3"
                                                        MinimumValue="0" ControlToValidate="txtSuperAlertTimeGap" Type="Integer" ErrorMessage="(0-180)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel3" Width="" GroupingText="<%$Resources:Resource,OffDetails%>"
                                        runat="server" BorderWidth="0">
                                        <table width="930px" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td align="right" style="width: 10%">
                                                    <asp:Label ID="lblOfficerAlertPriority" runat="server" CssClass="cssLabel" Text="Officer Alert Priority"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 15%">
                                                    <asp:DropDownList ID="ddlOfficerAlertPriority" runat="server" CssClass="cssDropDownRequired"
                                                        Width="100px">
                                                        <asp:ListItem Selected="True" Text="No Alert" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Text Message" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Email" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" style="width: 10%">
                                                    <asp:Label ID="lblOfficerAlertType" runat="server" Text="<%$Resources:Resource,OffAlertPriority%>"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 15%">
                                                    <asp:TextBox ID="txtOfficerAlertType" Width="80px" runat="server" MaxLength="2" CssClass="csstxtbox"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="regOffAlertType" runat="server" ControlToValidate="txtOfficerAlertType"
                                                    ValidationExpression="^[0-9]{2}$" ValidationGroup="GrpVal" ErrorMessage="Should Be Number"
                                                    SetFocusOnError="true" CssClass="csslblErrMsg"></asp:RegularExpressionValidator>--%>
                                                    <asp:RangeValidator MaximumValue="15" CssClass="csslblErrMsg" runat="server" ID="RangeValidator4"
                                                        MinimumValue="0" ControlToValidate="txtOfficerAlertType" Type="Integer" ErrorMessage="(0-15)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                                <td align="right" style="width: 10%">
                                                    <asp:Label ID="lblOfficer2SMS" runat="server" Text="<%$Resources:Resource,Off2SMS%>"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:TextBox ID="txtOfficer2SMS" runat="server" MaxLength="10" CssClass="csstxtbox"
                                                        Width="70   px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="regOff2SMS" runat="server" ControlToValidate="txtOfficer2SMS"
                                                        ValidationExpression="^(^\d{10}$)|(^\d{3}-\d{6}$)" ValidationGroup="SMSGrp" ErrorMessage="Should be Phone Number"
                                                        SetFocusOnError="true" CssClass="csslblErrMsg"></asp:RegularExpressionValidator>
                                                    <asp:RangeValidator MaximumValue="9999999999" CssClass="csslblErrMsg" runat="server"
                                                        ID="RangeValidator15" MinimumValue="0" ControlToValidate="txtOfficer2SMS" Type="Double"
                                                        ErrorMessage="*" SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblOfficer2Email" runat="server" MaxLength="50" CssClass="cssLabel"
                                                        Text="<%$Resources:Resource,Off2Email%>"></asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <asp:TextBox ID="txtOfficer2Email" runat="server" CssClass="csstxtbox" Width="250px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="regOffEmail" runat="server" ErrorMessage="*"
                                                        SetFocusOnError="true" ControlToValidate="txtOfficer2Email" ValidationGroup="vgClient"
                                                        Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblOff2AlertGap" runat="server" Text="<%$Resources:Resource,Off2AlertTimeGap%>"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtOff2AlertGap" runat="server" MaxLength="3" CssClass="csstxtbox"
                                                        Width="120px"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="regAlertGap" runat="server" ControlToValidate="txtOff2AlertGap"
                                                    ValidationExpression="^[0-9]{0,3}$" ValidationGroup="SMSGrp" ErrorMessage="Should be Number" SetFocusOnError="true"
                                                    CssClass="csslblErrMsg"></asp:RegularExpressionValidator>--%>
                                                    <asp:RangeValidator MaximumValue="180" CssClass="csslblErrMsg" runat="server" ID="RangeValidator1"
                                                        MinimumValue="0" ControlToValidate="txtOff2AlertGap" Type="Integer" ErrorMessage="(0-180)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel4" Width="" GroupingText="<%$Resources:Resource,RoundingOffDetails%>"
                                        runat="server" BorderWidth="0">
                                        <table width="930px" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="right" style="width: 200px">
                                                    <asp:Label ID="lblWorkTime" runat="server" Text="<%$Resources:Resource,MinimumWorkTime%>"
                                                        CssClass="cssLabel" Width="180px"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px">
                                                    <asp:TextBox ID="txtWorkTime" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtWorkTime"
                                                    ValidationExpression="(?!^0*$)(?!^0*\.0*$)^\d{1,18}(\.\d{1,2})?$" ValidationGroup="SMSGrp"
                                                    ErrorMessage="Should be Number" SetFocusOnError="true" CssClass="csslblErrMsg"></asp:RegularExpressionValidator>--%>
                                                    <asp:RangeValidator MaximumValue="1000" CssClass="csslblErrMsg" runat="server" ID="RangeValidator5"
                                                        MinimumValue="0" ControlToValidate="txtWorkTime" Type="Double" ErrorMessage="(0-1000)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblCrossSite" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,CrossSiteFix%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 100px">
                                                    <asp:CheckBox runat="server" ID="chkCrossSite" CssClass="cssCheckBox" />
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblBlockOverQty" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,BlockOver%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 100px">
                                                    <asp:CheckBox runat="server" ID="chkBlockOverQty" CssClass="cssCheckBox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblCutToTekenEnter" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,CutToTekenEnter%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox runat="server" ID="chkCutToTekenEnter" CssClass="cssCheckBox" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblCutToTekenExit" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,CutToTekenExit%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox runat="server" ID="chkCutToTekenExit" CssClass="cssCheckBox" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblRoundEnterCut" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,RoundEnterCut%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox runat="server" ID="txtRoundEnterCut" MaxLength="3" CssClass="csstxtbox"
                                                        Width="80px"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="regCutEnter" runat="server" ControlToValidate="txtRoundEnterCut"
                                                    ValidationExpression="^[0-9]{0,3}$" ValidationGroup="SMSGrp" ErrorMessage="Enter 3 digit Number"
                                                    SetFocusOnError="true" CssClass="csslblErrMsg"></asp:RegularExpressionValidator>--%>
                                                    <asp:RangeValidator MaximumValue="255" CssClass="csslblErrMsg" runat="server" ID="RangeValidator6"
                                                        MinimumValue="0" ControlToValidate="txtRoundEnterCut" Type="Double" ErrorMessage="(0-255)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblRoundExitCut" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,RoundExitCut%>"
                                                        Width="110px"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox runat="server" ID="txtRoundExitCut" MaxLength="3" CssClass="csstxtbox"
                                                        Width="100px"></asp:TextBox>
                                                    <%-- <asp:RegularExpressionValidator ID="regCutExit" runat="server" ControlToValidate="txtRoundExitCut" SetFocusOnError="true"
                                                    Width="120px" ValidationExpression="^[0-9]{0,3}$" ValidationGroup="SMSGrp" ErrorMessage="Enter 3 digit Number"
                                                    CssClass="csslblErrMsg" ></asp:RegularExpressionValidator>--%>
                                                    <asp:RangeValidator MaximumValue="255" CssClass="csslblErrMsg" runat="server" ID="rngRoundExit"
                                                        MinimumValue="0" ControlToValidate="txtRoundExitCut" Type="Integer" ErrorMessage="(0-255)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblRoundEnter" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,RoundEnter%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox runat="server" ID="chkRoundEnter" CssClass="cssCheckBox" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblRoundExit" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,RoundExit%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox runat="server" ID="chkRoundExit" CssClass="cssCheckBox" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%">
                                    <asp:Panel ID="Panel5" runat="server" GroupingText="<%$Resources:Resource,InTimeDetails%>">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 480px;">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="right" style="width: 100px">
                                                                <asp:Label ID="lblSunday" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,SundayInTime%>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 130px">
                                                                <asp:TextBox runat="server" ID="txtSunday" CssClass="csstxtboxTime"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtSunday"
                                                                    Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtSunday" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                                    Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator1"
                                                                    CssClass="csslblErrMsg" />
                                                            </td>
                                                            <td align="right" style="width: 100px">
                                                                <asp:Label ID="lblMonday" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,MondayInTime%>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 130px">
                                                                <asp:TextBox runat="server" ID="txtMonday" CssClass="csstxtboxTime"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtMonday"
                                                                    Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtMonday" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                                    Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator2"
                                                                    CssClass="csslblErrMsg" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="width: 100px">
                                                                <asp:Label ID="lblTuesday" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,TuesdayInTime%>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 130px">
                                                                <asp:TextBox runat="server" ID="txtTuesday" CssClass="csstxtboxTime"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtTuesday"
                                                                    Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtTuesday" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                                    Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator1"
                                                                    CssClass="csslblErrMsg" />
                                                            </td>
                                                            <td align="right" style="width: 100px">
                                                                <asp:Label ID="lblWed" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,WednesdayInTime%>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 130px">
                                                                <asp:TextBox runat="server" ID="txtWed" CssClass="csstxtboxTime"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtWed"
                                                                    Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator4" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtWed" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                                    Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator2"
                                                                    CssClass="csslblErrMsg" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="width: 100px">
                                                                <asp:Label ID="lblThur" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,ThursdayInTime%>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 130px">
                                                                <asp:TextBox runat="server" ID="txtThur" CssClass="csstxtboxTime"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtThur"
                                                                    Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator5" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtThur" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                                    Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator1"
                                                                    CssClass="csslblErrMsg" />
                                                            </td>
                                                            <td align="right" style="width: 100px">
                                                                <asp:Label ID="lblFri" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,FridayInTime%>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 130px">
                                                                <asp:TextBox runat="server" ID="txtFri" CssClass="csstxtboxTime"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtFri"
                                                                    Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator6" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtFri" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                                    Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator2"
                                                                    CssClass="csslblErrMsg" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="width: 100px">
                                                                <asp:Label ID="lblSat" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,SaturdayInTime%>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 130px" colspan="3">
                                                                <asp:TextBox runat="server" ID="txtSat" CssClass="csstxtboxTime"></asp:TextBox>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtSat"
                                                                    Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" />
                                                                <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator7" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtSat" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                                    Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator1"
                                                                    CssClass="csslblErrMsg" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td style="width: 50%">
                                    <asp:Panel ID="Panel06" runat="server" GroupingText="<%$Resources:Resource,OutTimeDetails%>">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblSunOut" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,SundayOutTime%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 110px">
                                                    <asp:TextBox runat="server" ID="txtSunOut" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtSunOut"
                                                        Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator8" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtSunOut" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                        Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator1"
                                                        CssClass="csslblErrMsg" />
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblMinOut" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,MondayOutTime%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 110px">
                                                    <asp:TextBox runat="server" ID="txtMonOut" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txtMonOut"
                                                        Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator9" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtMonOut" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                        Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator2"
                                                        CssClass="csslblErrMsg" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblTueOut" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,TuesdayOutTime%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 110px">
                                                    <asp:TextBox runat="server" ID="txtTueOut" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtTueOut"
                                                        Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator10" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtTueOut" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                        Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator1"
                                                        CssClass="csslblErrMsg" />
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblWebOut" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,WednesdayOutTime%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 110px">
                                                    <asp:TextBox runat="server" ID="txtWedOut" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender11" runat="server" TargetControlID="txtWedOut"
                                                        Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator11" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtWedOut" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                        Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator2"
                                                        CssClass="csslblErrMsg" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblThuOut" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,ThursdayOutTime%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 110px">
                                                    <asp:TextBox runat="server" ID="txtThuOut" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txtThuOut"
                                                        Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator12" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtThuOut" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                        Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator1"
                                                        CssClass="csslblErrMsg" />
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblFriOut" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,FridayOutTime%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 110px">
                                                    <asp:TextBox runat="server" ID="txtFriOut" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtFriOut"
                                                        Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator13" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtFriOut" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                        Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator2"
                                                        CssClass="csslblErrMsg" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblSatOut" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,SaturdayOutTime%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 110px" colspan="3">
                                                    <asp:TextBox runat="server" ID="txtSatOut" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txtSatOut"
                                                        Mask="99:99" MaskType="Time" ClearTextOnInvalid="True" ErrorTooltipEnabled="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" />
                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator14" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtSatOut" IsValidEmpty="true" Display="Dynamic" SetFocusOnError="true"
                                                        Width="10px" InvalidValueBlurredMessage="*" ValidationGroup="vgAdd" ErrorMessage="MaskedEditValidator1"
                                                        CssClass="csslblErrMsg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%">
                                    <asp:Panel ID="Panel7" runat="server" GroupingText="<%$Resources:Resource,TimingDetails%>">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblSundayHrs" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,SundayDailyHrs%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 130px">
                                                    <asp:TextBox ID="txtSundayHrs" runat="server" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <asp:RangeValidator MaximumValue="1000" CssClass="csslblErrMsg" runat="server" ID="RangeValidator7"
                                                        MinimumValue="0" ControlToValidate="txtSundayHrs" Type="Double" ErrorMessage="(0-1000"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblMonHrs" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,MondayDailyHrs%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 130px">
                                                    <asp:TextBox ID="txtMonHrs" runat="server" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <asp:RangeValidator MaximumValue="1000" CssClass="csslblErrMsg" runat="server" ID="RangeValidator8"
                                                        MinimumValue="0" ControlToValidate="txtMonHrs" Type="Double" ErrorMessage="(0-1000)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblTueHrs" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,TuesdayDailyHrs%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 130px">
                                                    <asp:TextBox ID="txtTueHrs" runat="server" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <asp:RangeValidator MaximumValue="1000" CssClass="csslblErrMsg" runat="server" ID="RangeValidator9"
                                                        MinimumValue="0" ControlToValidate="txtTueHrs" Type="Double" ErrorMessage="(0-1000)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblWedHrs" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,WednesdayDailyHrs%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 130px">
                                                    <asp:TextBox ID="txtWedHrs" runat="server" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <asp:RangeValidator MaximumValue="1000" CssClass="csslblErrMsg" runat="server" ID="RangeValidator10"
                                                        MinimumValue="0" ControlToValidate="txtWedHrs" Type="Double" ErrorMessage="(0-1000)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblThurHrs" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,ThursdayDailyHrs%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 130px">
                                                    <asp:TextBox ID="txtThurHrs" runat="server" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <asp:RangeValidator MaximumValue="1000" CssClass="csslblErrMsg" runat="server" ID="RangeValidator11"
                                                        MinimumValue="0" ControlToValidate="txtThurHrs" Type="Double" ErrorMessage="(0-1000)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblFriHrs" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,FridayDailyHrs%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 130px">
                                                    <asp:TextBox ID="txtFriHrs" runat="server" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <asp:RangeValidator MaximumValue="1000" CssClass="csslblErrMsg" runat="server" ID="RangeValidator12"
                                                        MinimumValue="0" ControlToValidate="txtFriHrs" Type="Double" ErrorMessage="(0-1000)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:Label ID="lblSatHrs" runat="server" CssClass="cssLable" Text="<%$Resources:Resource,SaturdayDailyHrs%>"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 130px" colspan="3">
                                                    <asp:TextBox ID="txtSatHrs" runat="server" CssClass="csstxtboxTime"></asp:TextBox>
                                                    <asp:RangeValidator MaximumValue="1000" CssClass="csslblErrMsg" runat="server" ID="RangeValidator13"
                                                        MinimumValue="0" ControlToValidate="txtSatHrs" Type="Double" ErrorMessage="(0-1000)"
                                                        SetFocusOnError="true"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td style="width: 50%">
                                    <asp:Panel ID="Panel8" runat="server" GroupingText="<%$Resources:Resource,OtherDetails%>">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblYoMan" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,Yoman%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox runat="server" ID="cbYoMan" CssClass="cssCheckBox" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblIsInspectorCode" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,IsInspectorCode%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox runat="server" ID="cbIsInspectorCode" CssClass="cssCheckBox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblIsOneTimeContract" CssClass="cssLable" runat="server" Text="<%$Resources:Resource, IsOneTimeContract%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox runat="server" ID="cbIsOneTimeContract" CssClass="cssCheckBox" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblIsReinforcementContract" CssClass="cssLable" runat="server" Text="<%$Resources:Resource, IsReinforcementContract%>"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox runat="server" ID="cbIsReinforcementContract" CssClass="cssCheckBox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblNoOfInspection" CssClass="cssLable" runat="server" Text="<%$Resources:Resource, NoOfInspection%>"></asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <asp:TextBox ID="txtNoOfInspection" Text="0" runat="server" CssClass="csstxtboxTime"
                                                        MaxLength="10"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%">
                                        <tr align="center" style="width: 100%">
                                            <td align="right" style="width: 50%">
                                                <asp:Button ID="btnSaveYlm" runat="server" CssClass="cssButton" OnClick="btnSaveYlm_Click"
                                                    Text="<%$ Resources:Resource,Update %>" ValidationGroup="vgAdd" Width="100px" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCorrectYlm" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Correct %>"
                                                    OnClick="btnCorrectYlm_Click" Width="100px" Visible="true" />
                                            </td>
                                            <td align="left" style="width: 50%">
                                                <asp:Button ID="btnDeleteYlm" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Delete %>"
                                                    OnClick="btnDeleteYlm_Click" Width="100px" Visible="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblErrorYlm" runat="server" class="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </AjaxToolKit:TabPanel>
                <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelGeocode" runat="server"
                    HeaderText="<%$Resources:Resource,GeoCodeAddress %>" TabIndex="4">
                    <ContentTemplate>
                        <div>
                            <table border="0" width="100%">
                                <tr>
                                    <td align="right">Address :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAddressShow" runat="server" Height="96px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                    </td>
                                    <td align="right">Formatted Address :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFormattedAddress" BackColor="LightGray" runat="server" Height="96px" ReadOnly="True" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnGeocode" CssClass="cssButton" runat="server" Text="Geocode Address" OnClick="btnGeocode_Click" />
                                    </td>
                                    <td align="right">GPS Location :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtLocation" runat="server" BackColor="LightGray" ReadOnly="True" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <uc2:GoogleMapForASPNet runat="server" ID="GoogleMapForASPNet1" />
                        </div>
                    </ContentTemplate>
                </AjaxToolKit:TabPanel>
            </AjaxToolKit:TabContainer>
<%--        </ContentTemplate>
    </Ajax:UpdatePanel>--%>
    <script type="text/javascript">
        function Func_BreakHrs(obj) {
            if (obj.checked == true) {
                document.getElementById('<%=txtBreak.ClientID %>').style.display = "block";
            }
            else {
                document.getElementById('<%=txtBreak.ClientID %>').value = "0";
                document.getElementById('<%=txtBreak.ClientID %>').style.display = "none";
            }
        }
    </script>
</asp:Content>
