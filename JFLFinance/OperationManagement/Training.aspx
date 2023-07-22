<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Training.aspx.cs" Inherits="OperationManagement_Training"
    Title="<%$Resources:Resource,AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="960px" border="0" cellpadding="1" cellspacing="0">
                <tr>
                    <td align="Left" width="30%">
                        <asp:Label ID="lblTrnNo" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,TrainingNo %>"></asp:Label>
                        <asp:TextBox ID="txtTrnNo" MaxLength="35" Width="150px" AutoPostBack="true" CssClass="csstxtbox"
                            runat="server" OnTextChanged="txtTrnNo_OnTextChanged"></asp:TextBox>
                        <asp:ImageButton ID="IMGTrainingSearch" AlternateText="<%$ Resources:Resource,SearchTraining %>"
                            runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                    </td>
                    <td width="50%">
                        <asp:Label ID="lblTrainingType" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,TrainingType %>"></asp:Label>
                        <asp:DropDownList ID="ddlTrainingType" CssClass="cssDropDown" runat="server" Width="300Px">
                        </asp:DropDownList>
                    </td>
                    <td width="20%" align="right">
                        <asp:Label ID='lblTrnS' CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                        <asp:Label ID='lblTrnStatus' Width="110px" Style="font-weight: bold; text-align: left"
                            CssClass="csstxtboxReadonly" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <%-- <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                            <ContentTemplate>--%>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 100%;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width: 930px;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label13" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,AsmtTrainingDetails %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table border="0">
                                                    <tr>
                                                        <td>
                                                            <table border="0" width="930px">
                                                                <tr>
                                                                    <td align="right" width="117px">
                                                                        <asp:Label ID="lblTrnDate" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,TrainingDate %>"
                                                                            Font-Bold="true"> </asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtTrnDate" AutoPostBack="false" Width="110px" CssClass="csstxtbox"
                                                                            runat="server" Style="text-align: justify" ValidationGroup="Apply"></asp:TextBox>
                                                                        <%--                                                                        <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
--%>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtTrnDate" PopupButtonID="IMGTrnDate" />
                                                                        <asp:ImageButton ID="IMGTrnDate" Style="vertical-align: middle" CausesValidation="true"
                                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                            ControlToValidate="txtTrnDate" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
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
                                                                            <asp:Label ID="Label7" Width="100px" Font-Bold="true" CssClass="cssLabel" runat="server"
                                                                                Text="<%$Resources:Resource,AssignmentNumber %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="160">
                                                                            <asp:TextBox ID="txtAssignNo" MaxLength="32" CssClass="csstxtbox" Width="110px" runat="server"
                                                                                AutoPostBack="True" OnTextChanged="txtAssignNo_TextChanged"></asp:TextBox>
                                                                            <asp:ImageButton ID="imgAssignSearch" AlternateText="<%$Resources:Resource,SearchAssignment %>"
                                                                                runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtAssignNo" ValidationGroup="Apply" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
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
                                                                    <%--<tr>
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
                                                                    </tr>--%>
                                                                    <%--<tr>
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
                                                                    </tr>--%>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:Panel ID="Panel2" Width="900px" GroupingText="Default Details" BorderWidth="0px"
                                                                runat="server">
                                                                <%--<%$Resources:Resource,DefaultDetails %>"--%>
                                                                <table border="0" width="900">
                                                                    <tr>
                                                                        <td align="right" width="100" nowrap="nowrap">
                                                                            <asp:Label ID="Label12" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ConductedBy %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width:120px">
                                                                            <asp:TextBox ID="txtDefaultConductedBy" CssClass="csstxtbox" runat="server" Width="80Px"
                                                                                MaxLength="10" AutoPostBack="true" OnTextChanged="txtDefaultConductedBy_onTextChanged"></asp:TextBox>
                                                                            <asp:ImageButton ID="imgDefaultConductedBySearch" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                                                                runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                                        </td>
                                                                        <td align="right" width="100" nowrap="nowrap">
                                                                            <asp:Label ID="Label14" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Name %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width:160px" colspan="2">
                                                                            <asp:Label ID="lblDefaultConductedByName" CssClass="csstxtboxReadonly" runat="server"
                                                                                Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td align="right" width="100" nowrap="nowrap">
                                                                            <asp:Label ID="Label15" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left"  style="width:115px" colspan="2">
                                                                            <asp:Label ID="lblDefaultConductedByDesg" CssClass="csstxtboxReadonly" runat="server"
                                                                                Width="200px"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="100" nowrap="nowrap">
                                                                            <asp:Label ID="Label1" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AreasToBeCovered %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="7">
                                                                            <asp:TextBox ID="txtAreaToBeCovered" CssClass="csstxtbox" Width="760px" runat="server"
                                                                                AutoPostBack="True" OnTextChanged="txtAreaToBeCovered_TextChanged"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" >
                                                                            <asp:Label ID="Label2" Width="100px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ActualTrainingDate %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="120px">
                                                                            <asp:TextBox ID="txtActualTrainingDate" CssClass="csstxtbox" Width="80px" runat="server"
                                                                                AutoPostBack="True" OnTextChanged="txtActualTrainingDate_TextChanged"></asp:TextBox>
                                                                            <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                                                runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                                                TargetControlID="txtActualTrainingDate" PopupButtonID="IMGDate" PopupPosition="TopRight" />
                                                                        </td>
                                                                        <td align="right" >
                                                                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,TimeFrom %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDefaultTimeFrom" AutoPostBack="true" CssClass="csstxtbox" Width="50px"
                                                                                runat="server" OnTextChanged="txtDefaultTimeFrom_TextChanged"></asp:TextBox>
                                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDefaultTimeFrom"
                                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="TwentyFourHour"
                                                                                ErrorTooltipEnabled="True" />
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,TimeTo %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDefaultTimeTo" Width="50px" CssClass="csstxtbox" runat="server"
                                                                                AutoPostBack="true" OnTextChanged="txtDefaultTimeTo_TextChanged"></asp:TextBox>
                                                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDefaultTimeTo"
                                                                                Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="TwentyFourHour"
                                                                                ErrorTooltipEnabled="True" />
                                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToCompare="txtDefaultTimeFrom"
                                                                                ControlToValidate="txtDefaultTimeTo" Display="static" Operator="GreaterThanEqual"
                                                                                SetFocusOnError="True"></asp:CompareValidator>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:Label ID="Label11" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,TrgHrsCompleted %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDefaultTargetHrs" Width="40px" CssClass="csstxtbox" Enabled="false" runat="server"
                                                                                Text=""></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="60px" nowrap="nowrap">
                                                                            <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Remark %>"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="7">
                                                                            <asp:TextBox runat="server" ID="txtDefaultRemarks" Width="760px" CssClass="csstxtbox"
                                                                                AutoPostBack="true" OnTextChanged="txtDefaultRemarks_TextChanged"></asp:TextBox>
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
                        <%-- </ContentTemplate>
                        </Ajax:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan="0" align="left">
                        <%-- <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                            <ContentTemplate>--%>
                        <asp:Label ID="lblGridError" runat="server" Text="" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
                        <table border="0" width="900">
                            <tr>
                                <td>
                                    <%--<asp:Panel ID="PanelGridView" Width="900px" GroupingText="<%$Resources:Resource,TrainingDetail %>"
                                                BorderWidth="1px" runat="server">--%>
                                    <asp:Panel ID="Panel1" ScrollBars="Horizontal" CssClass="ScrollBar" Height="190px"
                                        Width="900px" BorderWidth="1px" runat="server">
                                        <asp:GridView Width="2000px" ID="gvTrnDetails" CssClass="GridViewStyle" runat="server"
                                            CellPadding="1" GridLines="None" DataKeyNames="EmployeeNumber" AutoGenerateColumns="False"
                                            AllowSorting="True" AllowPaging="true" PageSize="5" OnRowEditing="gvTrnDetails_RowEditing"
                                            OnRowCancelingEdit="gvTrnDetails_RowCancelingEdit" OnRowUpdating="gvTrnDetails_RowUpdating"
                                            OnRowCommand="gvTrnDetails_RowCommand" OnRowDataBound="gvTrnDetails_RowDataBound"
                                            OnRowDeleting="gvTrnDetails_RowDeleting" OnPageIndexChanging="gvTrnDetails_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left"
                                                    HeaderText="<%$ Resources:Resource, EditColName %>">
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
                                                <asp:TemplateField HeaderStyle-Width="140px" ItemStyle-Width="140px" FooterStyle-Width="140px"
                                                    HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeNumber" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditEmployeeNumber" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtEmployeeNumber" CssClass="csstxtbox" runat="server" Width="100Px"
                                                            MaxLength="10" AutoPostBack="true" OnTextChanged="txtEmployeeNumber_onTextChanged"></asp:TextBox>
                                                        <asp:ImageButton ID="imgEmployeeNumberSearch" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                                            runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="200px" ItemStyle-Width="200px" FooterStyle-Width="200px"
                                                    HeaderText="<%$ Resources:Resource,Name %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpName" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditEmpName" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblFtrEmpName" CssClass="csstxtboxReadonly" runat="server" Width="160px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" FooterStyle-Width="120px"
                                                    HeaderText="<%$ Resources:Resource,Designation %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpDesg" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeDesg") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditEmpDesg" CssClass="CssLabel" runat="server" Text='<%# Bind("EmployeeDesg") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblFtrEmpDesg" CssClass="csstxtboxReadonly" runat="server" Width="115px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="170px" ItemStyle-Width="170px" FooterStyle-Width="170px"
                                                    HeaderText="<%$ Resources:Resource,TobeConductedBy %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblConductedBy" CssClass="CssLabel" runat="server" Text='<%# Bind("Conducted_by") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditConductedBy" CssClass="CssLabel" runat="server" Text='<%# Bind("Conducted_by") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtConductedBy" CssClass="csstxtbox" runat="server" Width="100Px"
                                                            MaxLength="10" AutoPostBack="true" OnTextChanged="txtConductedBy_onTextChanged"></asp:TextBox>
                                                        <asp:ImageButton ID="imgConductedBySearch" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                                            runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="170px" ItemStyle-Width="170px" FooterStyle-Width="170px"
                                                    HeaderText="<%$ Resources:Resource,Name %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCondByName" CssClass="CssLabel" runat="server" Text='<%# Bind("Conducted_by_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditCondByName" CssClass="CssLabel" runat="server" Text='<%# Bind("Conducted_by_Name") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblFtrCondByName" CssClass="csstxtboxReadonly" runat="server" Width="160px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" FooterStyle-Width="120px"
                                                    HeaderText="<%$ Resources:Resource,Designation %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCondByDesg" CssClass="CssLabel" runat="server" Text='<%# Bind("Conducted_by_Desg") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditCondByDesg" CssClass="CssLabel" runat="server" Text='<%# Bind("Conducted_by_Desg") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblFtrCondByDesg" CssClass="csstxtboxReadonly" runat="server" Width="115px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="250px" ItemStyle-Width="250px" FooterStyle-Width="250px"
                                                    HeaderText="<%$ Resources:Resource,AreasToBeCovered %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAreasCovered" CssClass="CssLabel" runat="server" Text='<%# Bind("Areas_to_be_covered") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditAreasCovered" CssClass="csstxtbox" runat="server" Text='<%# Bind("Areas_to_be_covered") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtAreasCovered" CssClass="csstxtbox" runat="server" Width="250Px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px" FooterStyle-Width="150px"
                                                    HeaderText="<%$ Resources:Resource,ActualTrainingDate %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTrainingDate" CssClass="CssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("Actual_training_date"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditTrainingDate" Width="80px" CssClass="csstxtbox" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("Actual_training_date"))%>'></asp:TextBox>
                                                        <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" PopupPosition="TopLeft" Format="dd-MMM-yyyy"
                                                            runat="server" TargetControlID="txtEditTrainingDate" PopupButtonID="IMGDate" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTraingDate" CssClass="csstxtbox" runat="server" Width="80Px"
                                                            OnTextChanged="txtTraingDate_OnTextChanged"></asp:TextBox>
                                                        <asp:ImageButton ID="IMGDate" Style="vertical-align: middle" CausesValidation="false"
                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtTraingDate" PopupButtonID="IMGDate" PopupPosition="TopLeft" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px"
                                                    HeaderText="<%$ Resources:Resource,TimeFrom %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTimeFrom" CssClass="CssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("time_from"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditTimeFrom" CssClass="csstxtbox" Width="50px" Text='<%# String.Format("{0:HH:mm}",Eval("time_from"))%>'
                                                            runat="server"></asp:TextBox>
                                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtEditTimeFrom"
                                                            Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="TwentyFourHour"
                                                            ErrorTooltipEnabled="True" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTimeFrom" AutoPostBack="true" OnTextChanged="txtTimeFrom_OnTextChnaged"
                                                            CssClass="csstxtbox" Width="50px" runat="server"></asp:TextBox>
                                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTimeFrom"
                                                            Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="TwentyFourHour"
                                                            ErrorTooltipEnabled="True" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px"
                                                    HeaderText="<%$ Resources:Resource,TimeTo %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTimeto" CssClass="CssLabel" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("time_to"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditTimeTo" Width="50px" CssClass="csstxtbox" Text='<%# String.Format("{0:HH:mm}",Eval("time_to"))%>'
                                                            runat="server" AutoPostBack="true" OnTextChanged="txtEditTimeTo_OnTextChnaged"></asp:TextBox>
                                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtEditTimeTo"
                                                            Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="TwentyFourHour"
                                                            ErrorTooltipEnabled="True" />
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToCompare="txtEditTimeFrom"
                                                            ControlToValidate="txtEditTimeTo" Display="static" Operator="GreaterThanEqual"
                                                            SetFocusOnError="True"></asp:CompareValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTimeTo" Width="50px" CssClass="csstxtbox" runat="server" OnTextChanged="txtTimeTo_OnTextChanged"
                                                            AutoPostBack="true"></asp:TextBox>
                                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTimeTo"
                                                            Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Time" AcceptAMPM="false" ClearTextOnInvalid="true" UserTimeFormat="None"
                                                            ErrorTooltipEnabled="True" />
                                                        <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToCompare="txtTimeFrom"
                                                                        ControlToValidate="txtTimeTo" Display="static" Operator="GreaterThanEqual" SetFocusOnError="True"></asp:CompareValidator>--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px" FooterStyle-Width="150px"
                                                    HeaderText="<%$ Resources:Resource,TrgHrsCompleted %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHrs" CssClass="CssLabel" runat="server" Text='<%# Bind("Hours") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditHrs" CssClass="csstxtbox" Enabled="false" runat="server"
                                                            Text='<%# Bind("Hours") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtHrs" CssClass="csstxtbox" runat="server" Enabled="false" Width="80Px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Remark %>" HeaderStyle-Width="150px"
                                                    ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemarks" CssClass="cssLabel" runat="server" Text='<%# Bind("Remarks")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtEditRemarks" CssClass="csstxtbox" Text='<%# Bind("Remarks")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox runat="server" ID="txtftrRemarks" Width="200px" CssClass="csstxtbox"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                    <%--      </asp:Panel>--%>
                                </td>
                            </tr>
                        </table>
                        <%--</ContentTemplate>
                        </Ajax:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                        OnClick="btnAddNew_Click" />
                                    <asp:Button ID="btnSave" CssClass="cssButton" ValidationGroup="Apply" runat="server"
                                        Text="<%$Resources:Resource,Save %>" OnClick="btnSave_Click" Visible="false" />
                                    <asp:Button ID="btnAuthorize" CssClass="cssButton" runat="server" Text="Authorize"
                                        OnClick="btnAuthorize_Click" Visible="false" />
                                    <asp:Button ID="btnEdit" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Edit %>"
                                        OnClick="btnEdit_Click" Visible="false" />
                                    <%--                            <asp:Button ID="btnCancel" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Cancel %>"
                                OnClick="btnCancel_Click" Visible="false" />
--%>
                                    <asp:Button ID="btnUpdate" CssClass="cssButton" ValidationGroup="Save" runat="server"
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
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
