<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CitationNCommendation.aspx.cs" Inherits="OperationManagement_CitationNCommendation"
    Title="<%$Resources:Resource,AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="960px" border="0" cellpadding="1" cellspacing="0">
                <tr>
                    <td align="right" width="35%">
                        <asp:Label ID="lblCitNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,CitationNo %>"></asp:Label>
                        <asp:TextBox ID="txtCitNo" MaxLength="35" Width="120px" AutoPostBack="true" CssClass="csstxtbox"
                            runat="server" OnTextChanged="txtCitNo_OnTextChanged"></asp:TextBox>
                        <asp:ImageButton ID="IMGCITNO" AlternateText="<%$ Resources:Resource,SearchCitationAndCommendationNo %>"
                            runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                    </td>
                    <td width="47%">
                        <asp:Label ID="lblCitationType" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,CitationType %>"></asp:Label>
                        <asp:DropDownList ID="ddlCitationType" CssClass="cssDropDown" runat="server" Width="380Px">
                        </asp:DropDownList>
                    </td>
                    <td width="16%" align="right">
                        <asp:Label ID='lblCitS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                        <asp:Label ID='lblCitStatus' Width="110px" Style="font-weight: bold; text-align: left"
                            CssClass="csstxtboxReadonly" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 100%;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width: 930px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label13" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource,AsmtCitDetails %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table border="0">
                                                    <%--<tr>
                                                        <td width="400px" align="right">
                                                            <asp:Label runat="server" ID="lblClientName" Text='<%$ Resources:Resource,ClientName %>'> </asp:Label>
                                                            <asp:DropDownList runat="server" ID="ddlClient" CssClass="cssDropDown" Width="180px"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="500px" align="left">
                                                            <asp:Label runat="server" ID="lblAsmt" Text='<%$ Resources:Resource,AsmtAddress %>'> </asp:Label>
                                                            <asp:DropDownList runat="server" ID="ddlAsmt" CssClass="cssDropDown" Width="300px"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td>
                                                            <table border="0" width="930px">
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblCitType" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,CitType %>"> </asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddlCitType" runat="server" CssClass="cssDropDown" Width="80px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblAwardedOn" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,AwardedOn %>"
                                                                            Font-Bold="true"> </asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtAwardedOn" AutoPostBack="false" Width="110px" CssClass="csstxtbox"
                                                                            runat="server" Style="text-align: justify" ValidationGroup="Save"></asp:TextBox>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtAwardedOn" PopupButtonID="IMGAwardedOn" />
                                                                        <asp:ImageButton ID="IMGAwardedOn" Style="vertical-align: middle" CausesValidation="false"
                                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                            ControlToValidate="txtAwardedOn" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblAwardedby" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,AwardedBy %>"> </asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtAwardedBy" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblDesignation" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Designation %>"> </asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="PanelAssignmentDetails" Width="900px" GroupingText="<%$Resources:Resource,AssignmentDetails %>"
                                                                BorderWidth="0px" runat="server">
                                                                <table border="0" width="900">
                                                                    <tr>
                                                                        <td align="right" width="100">
                                                                            <asp:Label ID="Label7" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AssignmentNumber %>"
                                                                                Font-Bold="true"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="160">
                                                                            <asp:TextBox ID="txtAssignNo" MaxLength="32" CssClass="csstxtbox" Width="110px" runat="server"
                                                                                AutoPostBack="True" OnTextChanged="txtAssignNo_TextChanged"></asp:TextBox>
                                                                            <asp:ImageButton ID="imgAssignSearch" AlternateText="<%$Resources:Resource,SearchAssignment %>"
                                                                                runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtAssignNo" ValidationGroup="Save" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="right" width="130" nowrap="nowrap">
                                                                            <asp:Label ID="Label6" Width="130px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,BranchID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="150">
                                                                            <asp:TextBox ID="txtBranchID" Enabled="false" CssClass="csstxtbox" Width="120px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" width="470">
                                                                            <asp:TextBox runat="server" CssClass="csstxtbox" Width="332px" ID="txtBranchIDDesc"
                                                                                Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="100" nowrap="nowrap">
                                                                            <asp:Label ID="Label8" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CustomerID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="140">
                                                                            <asp:TextBox ID="txtCustomerID" CssClass="csstxtbox" Enabled="false" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" colspan="3">
                                                                            <asp:TextBox ID="txtCustomerDesc" CssClass="csstxtbox" Enabled="false" Width="600px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="100" nowrap="nowrap" style="height: 23px">
                                                                            <asp:Label ID="Label9" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AddressID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="140" style="height: 23px">
                                                                            <asp:TextBox ID="txtAddressID" CssClass="csstxtbox" Enabled="false" Width="140px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" colspan="3" style="height: 23px">
                                                                            <asp:TextBox ID="txtAddressDesc" CssClass="csstxtbox" Enabled="false" Width="600px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="100" nowrap="nowrap">
                                                                            <asp:Label ID="Label10" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreaID %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="140">
                                                                            <asp:TextBox ID="txtAreaID" CssClass="csstxtbox" Enabled="false" Width="140px" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" colspan="3">
                                                                            <asp:TextBox ID="txtAreaDesc" CssClass="csstxtbox" Enabled="false" Width="600px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblGridError" runat="server" Text="" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                                <asp:Panel ID="PanelGridView" Width="900px" GroupingText="<%$ Resources:Resource, CitationDetails %>"
                                    BorderWidth="0px" runat="server">
                                    <table border="0" width="900" style="vertical-align: top">
                                        <tr>
                                            <td>
                                                <asp:GridView Width="890px" ID="gvAwardDetails" CssClass="GridViewStyle" runat="server"
                                                    CellPadding="1" GridLines="None" AutoGenerateColumns="False" AllowSorting="True"
                                                    AllowPaging="true" PageSize="15" onmousemove="TableResize_OnMouseMove(this);"
                                                    onmouseup="TableResize_OnMouseUp(this);" onmousedown="TableResize_OnMouseDown(this);"
                                                    OnRowEditing="gvAwardDetails_RowEditing" OnRowCancelingEdit="gvAwardDetails_RowCancelingEdit"
                                                    OnRowUpdating="gvAwardDetails_RowUpdating" OnRowCommand="gvAwardDetails_RowCommand"
                                                    OnRowDataBound="gvAwardDetails_RowDataBound" OnRowDeleting="gvAwardDetails_RowDeleting"
                                                    OnPageIndexChanging="gvAwardDetails_PageIndexChanging">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px"
                                                            ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label></td>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                    ToolTip="<%$ Resources:Resource, Delete %>" OnClientClick="return confirm('Do you want to Delete');"
                                                                    ImageUrl="../Images/Delete.gif" />
                                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                    ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                    ValidationGroup="vgHrEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                    ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="AddNew"
                                                                    ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                    ToolTip="<%$ Resources:Resource, Reset %>" OnClick="btnReset_Click" ImageUrl="../Images/Reset.gif" />
                                                            </FooterTemplate>
                                                            <ItemStyle Width="70px" />
                                                            <HeaderStyle Width="70px" />
                                                            <FooterStyle Width="70px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="200px" ItemStyle-Width="200px" FooterStyle-Width="200px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblhdrAwardDesc" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource, AwardDesc %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAwardDesc" CssClass="CssLabel" runat="server" Text='<%# Bind("Award_Descripation") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtEditAwardDesc" CssClass="Csstxtbox" runat="server" Text='<%# Bind("Award_Descripation") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgHrEdit"
                                                                    runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtEditAwardDesc"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtAwardDesc" CssClass="csstxtbox" runat="server" Width="180Px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vg_Add"
                                                                    runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtAwardDesc"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblhdrAwardedTo" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource, AwardedTo %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAwardedTo" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblEditAwardedTo" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtAwardedTo" CssClass="csstxtbox" runat="server" Width="100Px"
                                                                    MaxLength="10" OnTextChanged="txtAwardedTo_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <asp:ImageButton ID="imgAwardedTo" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ValidationGroup="vg_Add"
                                                                    runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtAwardedTo"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="200px" ItemStyle-Width="200px" FooterStyle-Width="200px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblhdrName" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource, Name %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" CssClass="CssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblEditName" CssClass="CssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFtrName" CssClass="csstxtboxReadonly" runat="server" Width="200px"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblhdrDesg" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource, Designation %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDesg" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeDesignation") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblEditDesg" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeDesignation") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFtrDesg" CssClass="csstxtboxReadonly" runat="server" Width="150px"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <table>
                                    <tr>
                                        <td colspan="3" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                                            OnClick="btnAddNew_Click" />
                                                        <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Save" runat="server"
                                                            Text="<%$Resources:Resource,Save %>" OnClick="btnSave_Click" Visible="false" />
                                                        <asp:Button ID="btnAuthorize" CssClass="cssButton" runat="server" Text="Authorize"
                                                            OnClick="btnAuthorize_Click" Visible="false" />
                                                        <asp:Button ID="btnEdit" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Edit %>"
                                                            OnClick="btnEdit_Click" Visible="false" />
                                                        <asp:Button ID="btnCancel" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Cancel %>"
                                                            OnClick="btnCancel_Click" Visible="false" />
                                                        <asp:Button ID="btnUpdate" CssClass="cssButton" ValidationGroup="Apply" runat="server"
                                                            Visible="false" Text="<%$Resources:Resource,Update %>" OnClick="btnUpdate_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:HiddenField ID="hfAsmtStartDate" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </Ajax:UpdatePanel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
