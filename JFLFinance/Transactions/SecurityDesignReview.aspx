<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SecurityDesignReview.aspx.cs" Inherits="Transactions_SecurityDesignReview"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register TagName="Control" TagPrefix="UserControl" Src="~/UserControls/DateControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="890" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="172" nowrap="nowrap" align="right">
                                    <asp:Label ID="lblDesignNumber" Width="172px" CssClass="cssLabel" runat="server"
                                        Text="<%$Resources:Resource,DesignChgNumber %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDesignNumber" MaxLength="35" Width="110px" AutoPostBack="true"
                                        CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" AlternateText="SearchDesignNumber" runat="server"
                                        ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDesignStatus" runat="server" CssClass="cssLabel" Text=""></asp:Label>
                                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="cssLabel" Text=""></asp:Label>
                                </td>
                                <td width="410px" align="left" colspan="4"></td>
                            </tr>
                        </table>
                        <asp:Panel ID="PanelMain" runat="server" Width="98%">
                            <div style="width: 98%;">
                                <div class="squarebox">
                                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                        <div style="float: left; width:930px;">
                                            <tt style="text-align: center;">
                                                <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,SecurityDesignReview %>"></asp:Label></tt></div>
                                    </div>
                                    <div class="squareboxcontent">
                                        <table border="0" width="890" style="vertical-align: top">
                                            <tr>
                                                <td align="right" width="138">
                                                    <asp:Label ID="Label3" CssClass="cssLabel" Width="138px" runat="server" Text="<%$Resources:Resource,Date %>"></asp:Label>
                                                </td>
                                                <td align="left" width="160">
                                                    <%--<UserControl:Control ID="txtDate" runat="server"></UserControl:Control>--%>
                                                    <asp:TextBox ID="txtDate" runat="server" AutoPostBack="true" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                                </td>
                                                <td align="right" width="140">
                                                    <asp:Label ID="Label4" runat="server" Width="140px" Text="<%$Resources:Resource,DateOfReport %>"></asp:Label>
                                                </td>
                                                <td align="left" width="150">
                                                    <UserControl:Control ID="txtDateOfReport" runat="server"></UserControl:Control>
                                                </td>
                                                <td align="right" width="140">
                                                    <asp:Label ID="Label6" runat="server" Width="140px" Text="Reason For Review"></asp:Label>
                                                </td>
                                                <td align="left" width="140" style="height: 21px">
                                                    <asp:DropDownList ID="ddlInvReason" AutoPostBack="false" Width="145px" CssClass="cssDropDown"
                                                        runat="server" >
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                        ControlToValidate="ddlInvReason" ValidationGroup="Apply" ErrorMessage="*"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" width="260" colspan="9">
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Panel ID="PanelAssignmentDetails" Width="890px" GroupingText="<%$Resources:Resource,AssignmentDetails %>"
                                                        BorderWidth="0px" runat="server">
                                                        <table border="0" width="890" cellpadding="1" cellspacing="1">
                                                            <tr>
                                                                <td align="right" width="140">
                                                                    <asp:Label ID="Label7" Width="140px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AssignmentNumber %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="160">
                                                                    <asp:TextBox ID="txtAssignNo" MaxLength="32" CssClass="csstxtbox" Width="110px" runat="server"
                                                                        AutoPostBack="True"></asp:TextBox>
                                                                    <asp:ImageButton ID="imgSearch" AlternateText="SearchClient" runat="server" ImageUrl="~/Images/icosearch.gif"
                                                                        ToolTip="" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtAssignNo" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="140" nowrap="nowrap">
                                                                    <asp:Label ID="Label8" Width="140px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtCustomerID" MaxLength="16" CssClass="csstxtbox" Enabled="false"
                                                                        Width="140px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3">
                                                                    <asp:TextBox ID="txtCustomerDesc" CssClass="csstxtbox" Enabled="false" Width="550px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="140" nowrap="nowrap" style="height: 23px">
                                                                    <asp:Label ID="Label9" Width="140px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AddressID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140" style="height: 23px">
                                                                    <asp:TextBox ID="txtAddressID" CssClass="csstxtbox" Enabled="false" Width="140px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" style="height: 23px">
                                                                    <asp:TextBox ID="txtAddressDesc" CssClass="csstxtbox" Enabled="false" Width="550px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="140" nowrap="nowrap">
                                                                    <asp:Label ID="Label10" Width="140px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left" width="140">
                                                                    <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3">
                                                                    <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="550px"
                                                                        runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="890" border="0">
                                            <tr>
                                                <td align="right" width="138" nowrap="nowrap">
                                                    <asp:Label ID="Label1" CssClass="cssLabel" Width="138" runat="server" Text="<%$Resources:Resource,RequestIdentifiedBy %>"></asp:Label>
                                                </td>
                                                <td align="left" width="160">
                                                    <asp:TextBox ID="txtConductedBy" CssClass="csstxtbox" Width="140px" ValidationGroup="Save"
                                                        runat="server" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td align="left" colspan="1" width="280px">
                                                    <asp:TextBox ID="txtEmployeeName" CssClass="csstxtbox" Width="280" Enabled="false"
                                                        runat="server"></asp:TextBox>
                                                </td>
                                                <td align="left" width="100px">
                                                    <asp:Label ID="Label5" width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                </td>
                                                <td align="left" width="110px">
                                                    <asp:TextBox ID="txtEmployeeDesignation" CssClass="csstxtbox" Enabled="false" runat="server" width="110px"></asp:TextBox>
                                                </td>
                                                <td align="left" width="260" colspan="4">
                                                                    </td>
                                                
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <table align="center" border="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Apply" runat="server"
                                        Text="<%$Resources:Resource,Save %>" Visible="false" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEdit" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource ,Edit%>" />
                                </td>
                                <td>
                                    <asp:Button ID="btnObservationAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Text="<%$Resources:resource,ObservationAuthorized %>" />
                                </td>
                                <td>
                                    <asp:Button ID="btnActionAuthorize" CssClass="cssButton" Visible="false" runat="server"
                                        Text="<%$Resources:Resource,ActionAuthorized %>" ValidationGroup="ActionAuthorize" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" CssClass="cssButton" runat="server" Visible="false" Text="<%$Resources:Resource,Update %>" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" CssClass="cssButton" Visible="false" runat="server" Text="<%$Resources:Resource,Cancel %>" />
                                </td>
                                <td>
                                    <asp:HiddenField ID="hfMessageToEdit" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <div style="width: 950px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width:930px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="lblDivHdr1" CssClass="squareboxgradientcaption" runat="server" Text="Observations"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <asp:GridView Width="900px" ID="gvSiteInstruction" CssClass="GridViewStyle" runat="server"
                                                    ShowFooter="True" AllowPaging="True" AllowSorting="true" PageSize="6" CellPadding="1"
                                                    GridLines="None" AutoGenerateColumns="False"
                                                    DataKeyNames="SiteInstruction">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                            <EditItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>"
                                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                                    ValidationGroup="EditSiteInstruction" />
                                                                &nbsp;
                                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                    CommandName="Cancel" />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                    CssClass="cssImgButton" ValidationGroup="AddNewSiteInstruction" CommandName="AddNew"
                                                                    ImageUrl="../Images/AddNew.gif" />
                                                                &nbsp;
                                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                    CssClass="csslnkButton" ValidationGroup="EditSiteInstruction" runat="server" CausesValidation="False"
                                                                    CommandName="Edit" />
                                                                &nbsp;
                                                                <asp:ImageButton ID="IBDeleteSiteInstruction"
                                                                    ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete"
                                                                     />
                                                            </ItemTemplate>
                                                            <FooterStyle Width="100px" />
                                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                            <ItemStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                            <FooterStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Row ID" Visible="false" >
                                                            <EditItemTemplate> 
                                                                <asp:Label ID="lblRowID"  CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowID" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="cssLabelHeader" Width="600px" />
                                                            <ItemStyle Width="600px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px"
                                                            ItemStyle-Width="200px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblInstructionType" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Instruction Type"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInstructionType" CssClass="cssLable" runat="server" Text='<%# Bind("ItemDesc") %>' />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList Width="180px" ID="ddlInstructionType" CssClass="csstxtbox" runat="server" />
                                                                <asp:HiddenField ID="hfInstructionType" runat="server" value='<%# Bind("InstructionTypeID") %>'/>                                                                
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList Width="180px" ID="ddlInstructionType" CssClass="csstxtbox" runat="server" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>                                                                                                                 
                                                        <asp:TemplateField HeaderText="Instruction" SortExpression="SiteInstruction">
                                                            <EditItemTemplate> 
                                                                <asp:TextBox ID="txtSiteInstruction" Width="600px" MaxLength="255" CssClass="csstxtbox"  Text='<%# Bind("SiteInstruction") %>'
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="txtSiteInstruction"
                                                                    ErrorMessage="" ValidationGroup="EditSiteInstruction" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                        
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSiteInstruction" CssClass="cssLabel" runat="server" Text='<%# Bind("SiteInstruction") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtNewSiteInstruction" Width="600px" MaxLength="255" CssClass="csstxtbox"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtNewSiteInstruction"
                                                                    ErrorMessage="" ValidationGroup="AddNewSiteInstruction" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                            <HeaderStyle CssClass="cssLabelHeader" Width="600px" />
                                                            <ItemStyle Width="670px" />
                                                            <FooterStyle Width="670px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </td>
                            </tr>
                        </table>                        
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
