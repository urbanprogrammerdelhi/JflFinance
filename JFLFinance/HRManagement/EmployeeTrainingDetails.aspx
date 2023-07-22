<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeTrainingDetails.aspx.cs" Inherits="HRManagement_EmployeeTrainingDetails"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>

            <td align="center">
                <%--<Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                <div style="width: 950px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 20px;">
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,TrainingDetail %>"></asp:Label>
                        </div>
                        <div>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr align="center">
                                    <td>
                                        <asp:Label CssClass="cssLable" ID="lblEmployeeNumber" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                        <asp:TextBox CssClass="csstxtboxReadonly" ID="txtEmployeeNumber" runat="server" ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox CssClass="csstxtboxReadonly" ID="txtEmployeeName" Width="400px" runat="server"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table border="0" cellpadding="0" cellspacing="0" width="90%">
                                <tr align="center">
                                    <td align="right" style="width: 255px">
                                        <asp:Label CssClass="cssLable" ID="lblTraining" runat="server" Text="<%$Resources:Resource,Training %>"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 255px">
                                        <asp:DropDownList ID="ddlTraining" TabIndex="1" Width="250px" runat="server" AutoPostBack="true"
                                            CssClass="cssDropDown" OnSelectedIndexChanged="ddlTraining_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" style="width: 255px">
                                        <asp:Label CssClass="cssLable" ID="lblTrainingCategory" runat="server" Text="<%$Resources:Resource,Category %>"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 255px">
                                        <asp:TextBox CssClass="csstxtboxReadonly" ID="txtTrainingCategory" Width="200px"
                                            runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 255px">
                                        <asp:Label CssClass="cssLable" ID="lblTrainingLevel" runat="server" Text="<%$Resources:Resource,TrainingLevel %>"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 255px">
                                        <asp:TextBox CssClass="csstxtboxReadonly" ID="txtTrainingLevel" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="right" style="width: 255px">
                                        <asp:Label CssClass="cssLable" ID="lblTrainingDate" runat="server" Text="<%$Resources:Resource,TrainingDate %>"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 255px">
                                        <asp:TextBox ID="txtTrainingDate" AutoPostBack="True" OnTextChanged="txtTrainingDate_TextChanged"
                                            runat="server" ValidationGroup="TrainingDate" CssClass="csstxtboxRequired"></asp:TextBox>
                                        <asp:ImageButton ID="imgTrainingDate" Style="vertical-align: middle" runat="server"
                                            ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtenderTrainingDate" Format="dd-MMM-yyyy"
                                            runat="server" TargetControlID="txtTrainingDate" PopupButtonID="imgTrainingDate"
                                            Enabled="True">
                                        </AjaxToolKit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RFVTrainingDate" ValidationGroup="TrainingDate" Display="Dynamic"
                                            ControlToValidate="txtTrainingDate" runat="server" Text="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" style="width: 255px">
                                        <asp:Label CssClass="cssLable" ID="lblTrainingValidTillDate" runat="server" Text="<%$Resources:Resource,ValidTillDate %>"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 255px">
                                        <asp:Label Width="200px" Style="font-weight: bold;" ID="lblTxtTrainingValidTillDate"
                                            CssClass="csstxtboxReadonly" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr align="center">
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" Text="<%$Resources:Resource,Save %>" CssClass="cssButton"
                                            OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:Resource,Back %>" CssClass="cssButton"
                                            OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                            <div id="divPopInactive" runat="server" style="display: none; width: 100%;">
                                <asp:Panel runat="server" ID="pnlPop" BorderStyle="Solid" BorderWidth="1pt" BackColor="White"
                                    Visible="true" GroupingText="<%$Resources:Resource,EnterDeactivateDate %>" Height="120px" Width="350px">
                                    <div id="divInactive" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td align="right" style="width: 50%;">
                                                    <asp:Label ID="lblValidDate" runat="server" CssClass="csslabel" Text="<%$Resources:Resource,ToDate %>"
                                                        Width="150px"> </asp:Label>
                                                </td>
                                                <td align="left" style="width: 50%;">
                                                    <asp:TextBox ID="txtValidTillDate" runat="server" CssClass="csstxtbox" Width="80px"></asp:TextBox>
                                                    <asp:ImageButton ID="btnPopUp" runat="server" ImageUrl="~/Images/pdate.gif" />
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                                        PopupButtonID="btnPopUp" PopupPosition="BottomRight" TargetControlID="txtValidTillDate">
                                                    </AjaxToolKit:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 50%;">
                                                    <asp:Button ID="btnOKValidTillDate" name="btnOKValidTillDateName" runat="server"
                                                        Text="OK" OnClick="btnOKValidTillDate_Click" OnClientClick="ClickButtonOK(this)" />
                                                </td>
                                                <td align="left" style="width: 50%;">
                                                    <asp:Button ID="btnCancelValidTillDate" runat="server" Text="Cancel" OnClick="btnCancelValidTillDate_Click"
                                                        OnClientClick="ClickButtonOK(this)" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div id="divWarning" runat="server" style="display: none; width: 100%;">
                                <asp:Panel runat="server" ID="Panel1" BorderStyle="Solid" BorderWidth="1pt" BackColor="White"
                                    Visible="true" GroupingText="" Height="70px" Width="650px">
                                    <br />
                                    <asp:Label ID="lblMsg" runat="server" Text="<%$Resources:Resource,EmpSchExistCustMandSkill %>"></asp:Label>
                                    <br />
                                    <asp:Button runat="server" Text="<%$Resources:Resource,OK %>" ID="btnPopOK" CssClass="cssButton" OnClick="btnPopOK_Click" />
                                    <asp:Button runat="server"  Text="<%$Resources:Resource,Cancel %>" ID="btnPopCancel" CssClass="cssButton" OnClick="btnPopCancel_Click" />
                                </asp:Panel>
                            </div>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <%--   <Ajax:UpdatePanel runat="server" ID="up1">
                                                    <ContentTemplate>--%>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Paneldatagrid" BorderWidth="1px" runat="server" Width="950px" Height="200px"
                                                        ScrollBars="Auto" CssClass="ScrollBar">
                                                        <asp:GridView Width="940px" ID="gvTraining" UseAccessibleHeader="true" CssClass="GridViewStyle"
                                                            runat="server" ShowFooter="True" AllowPaging="True" PageSize="7" CellPadding="1"
                                                            GridLines="None" AutoGenerateColumns="False" AllowSorting="false" OnRowCommand="gvTraining_RowCommand"
                                                            OnRowDataBound="gvTraining_RowDataBound" OnPageIndexChanging="gvTraining_PageIndexChanging"
                                                            OnRowCancelingEdit="gvTraining_RowCancelingEdit" OnRowDeleting="gvTraining_RowDeleting"
                                                            OnRowEditing="gvTraining_RowEditing" OnRowUpdating="gvTraining_RowUpdating" DataKeyNames="TrainingCode"
                                                            onmousemove="TableResize_OnMouseMove(this);" onmouseup="TableResize_OnMouseUp(this);"
                                                            onmousedown="TableResize_OnMouseDown(this);">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <AjaxToolKit:ModalPopupExtender ID="mdlPopup" runat="server" CancelControlID="btnCancelValidTillDate"
                                                                            OkControlID="btnOKValidTillDate" TargetControlID="ddlActive" PopupControlID="pnlPop"
                                                                            Drag="false" PopupDragHandleControlID="divInactive" BackgroundCssClass="modalBackground">
                                                                        </AjaxToolKit:ModalPopupExtender>
                                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                                        <asp:HiddenField ID="hfIsActive" runat="server" Value='<%# Eval("IsActive") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,TrainingCode %>" HeaderStyle-Width="200px"
                                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTrainingCode" CssClass="cssLabel" runat="server" Text='<%# Eval("TrainingCode") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblItmTrainingCode" CssClass="cssLable" runat="server" Text='<%# Eval("TrainingCode") %>'
                                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Select"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,TrainingDesc %>" HeaderStyle-Width="350px"
                                                                    FooterStyle-Width="350px" ItemStyle-Width="350px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="LabelEditItemTrainingDesc" Width="325px" CssClass="cssLabel" runat="server"
                                                                            Text='<%# Bind("TrainingDesc") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LabelItemTrainingDesc" Width="325px" CssClass="cssLabel" runat="server"
                                                                            Text='<%# Bind("TrainingDesc") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,TrainingDate %>">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="txtEditTrainingDate" Width="80px" CssClass="cssLabel" runat="server"
                                                                            Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("TrainingDate")) %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LabelItemTrainingDate" CssClass="cssLabel" Width="80px" runat="server"
                                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("TrainingDate")) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ValidTillDate %>">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="LabelEditItemValidTillDate" CssClass="cssLabel" runat="server" Width="80px"
                                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("ValidTillDate")) %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LabelItemValidTillDate" CssClass="cssLabel" runat="server" Width="80px"
                                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("ValidTillDate")) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Active %>">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBDeactivateTran" ToolTip="<%$Resources:Resource,Deactivate %>"
                                                                            ImageUrl="~/Images/activateBtn.gif" Width="25px" Height="15px" runat="server"
                                                                            CssClass="csslnkButton" CausesValidation="False" CommandName="Deactivate" Visible="false"
                                                                            OnClick="OnClick_Deactivate" />
                                                                        <asp:DropDownList ID="ddlActive" Width="100px" runat="server" onchange="javascript:DeactivatePopup(this);"
                                                                            OnSelectedIndexChanged="ddlActive_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 16px">
                                                    <asp:HiddenField ID="hfTrainingCode" runat="server" />
                                                    <asp:HiddenField ID="hfTrainingDate" runat="server" />
                                                    <asp:HiddenField ID="hfValidTillDate" runat="server" />
                                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelEmpRefresherTrainingDetails" runat="server" Width="950px" Visible="false">
                                                        <div style="width: 860px;">
                                                            <div class="squarebox">
                                                                <div class="squareboxgradientcaption" style="height: 20px;">
                                                                            <asp:Label ID="LabelSubstituteTrainingDetails" runat="server" Text="<%$Resources:Resource,RefresherTrainDetails %>"></asp:Label>
                                                                </div>
                                                                <div>
                                                                    <table width="850px" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr align="center">
                                                                            <asp:Label CssClass="cssLable" ID="lblTrainingGridInfo" runat="server"></asp:Label>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView Width="840px" ID="gvEmpRefresherTrainingDetails" AllowPaging="True"
                                                                                    PageSize="5" CssClass="GridViewStyle" runat="server" CellPadding="1" GridLines="None"
                                                                                    AutoGenerateColumns="False" ShowFooter="True" OnPageIndexChanging="gvEmpRefresherTrainingDetails_PageIndexChanging"
                                                                                    OnRowDataBound="gvEmpRefresherTrainingDetails_RowDataBound" OnRowDeleting="gvEmpRefresherTrainingDetails_RowDeleting"
                                                                                    OnRowEditing="gvEmpRefresherTrainingDetails_RowEditing" OnRowCancelingEdit="gvEmpRefresherTrainingDetails_RowCancelingEdit"
                                                                                    OnRowUpdating="gvEmpRefresherTrainingDetails_RowUpdating">
                                                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="IBEditEmpRefresherTrainingDetails" ToolTip="<%$Resources:Resource, Edit %>"
                                                                                                    ImageUrl="~/Images/Edit.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                                                                                    CommandName="Edit" />
                                                                                                <asp:HiddenField ID="hfDeactivate" runat="server" Value='<%# Bind("IsActive") %>' />
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:ImageButton ID="ImgbtnUpdateEmpRefresherTrainingDetails" runat="server" CssClass="cssImgButton"
                                                                                                    CausesValidation="True" CommandName="Update" ToolTip="<%$ Resources:Resource, Update %>"
                                                                                                    ImageUrl="../Images/Save.gif" />
                                                                                                <asp:ImageButton ID="ImgbtnCancelEmpRefresherTrainingDetails" runat="server" CssClass="cssImgButton"
                                                                                                    CausesValidation="False" CommandName="Cancel" ToolTip="<%$ Resources:Resource, Cancel %>"
                                                                                                    ImageUrl="../Images/Cancel.gif" />
                                                                                            </EditItemTemplate>
                                                                                            <FooterStyle Width="80px" />
                                                                                            <HeaderStyle Width="80px" CssClass="cssLabelHeader" />
                                                                                            <ItemStyle Width="80px" VerticalAlign="Middle" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="50px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CompanyCode" Visible="false">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblEditItemCompanyCode" runat="server" Text='<%# Eval("CompanyCode") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblItemCompanyCode" runat="server" Text='<%# Bind("CompanyCode") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="TrainingAutoID" Visible="false">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblEditItemTrainingAutoID" runat="server" Text='<%# Eval("TrainingAutoID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblItemTrainingAutoID" runat="server" Text='<%# Bind("TrainingAutoID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="TrainingCode" Visible="false">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblEditItemTrainingCode" runat="server" Text='<%# Eval("TrainingCode") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblItemTrainingCode" runat="server" Text='<%# Bind("TrainingCode") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeNumber" Visible="false">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblEditItemEmployeeNumber" runat="server" Text='<%# Eval("EmployeeNumber") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblItemEmployeeNumber" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="TrainingDate" Visible="false">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblEditItemTrainingDate" CssClass="cssLabel" runat="server" Width="80px"
                                                                                                    Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("TrainingDate")) %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblItemTrainingDate" CssClass="cssLabel" runat="server" Width="80px"
                                                                                                    Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("TrainingDate")) %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,RefTrainingDate %>">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblEditItemRefTrainingDate" CssClass="cssLabel" runat="server" Width="80px"
                                                                                                    Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("ScheduledTrainingDate")) %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblItemRefTrainingDate" CssClass="cssLabel" runat="server" Width="80px"
                                                                                                    Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("ScheduledTrainingDate")) %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                                            <ItemStyle Width="200px" />
                                                                                            <FooterStyle Width="200px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ActualTrainingDate %>">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtEditItemActualTrainingDate" Width="100px" CssClass="csstxtbox"
                                                                                                    runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("ActualTrainingDate")) %>'
                                                                                                    AutoPostBack="True"></asp:TextBox>
                                                                                                <asp:ImageButton ID="imgEditItemActualTrainingDate" Style="vertical-align: middle"
                                                                                                    CausesValidation="true" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderEditItemActualTrainingDate" Format="dd-MMM-yyyy"
                                                                                                    runat="server" TargetControlID="txtEditItemActualTrainingDate" PopupButtonID="imgEditItemActualTrainingDate"
                                                                                                    PopupPosition="TopRight">
                                                                                                </AjaxToolKit:CalendarExtender>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="LblItemActualTrainingDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("ActualTrainingDate")) %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                                            <ItemStyle Width="200px" />
                                                                                            <FooterStyle Width="200px" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
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
                                        <%--  </ContentTemplate>
                                                </Ajax:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <caption>
                                    <br />
                                    <tr>
                                        <td>
                                            <%--<script language="javascript" src="../javaScript/jquery-1.8.1.min.js" type="text/javascript"></script>--%>
                                            <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.11.3.min.js"></script>
                                            <script language="javascript" src="../PageJS/EmployeeTrainingDetails.js" type="text/javascript"></script>
                                            <script type="text/javascript">

                                                function ControlInitializer() {                                            
                                                    this.gvTraining = document.getElementById('<%= this.gvTraining.ClientID %>');
                                                    this.txtValidTillDate = document.getElementById('<%= this.txtValidTillDate.ClientID %>');
                                                    this.divPopInactive = document.getElementById('<%= this.divPopInactive.ClientID %>');
                                                    this.DeactivatePopupMsg = '<%= Resources.Resource.DoYouWantToDeactivate %>';
                                                  
                                                }
                                            </script>
                                        </td>
                                    </tr>
                                </caption>
                            </table>
                        </div>
                    </div>
                    
                </div>
                <%--     </ContentTemplate>
                </Ajax:UpdatePanel>--%>
            </td>
        </tr>
    </table>
</asp:Content>
