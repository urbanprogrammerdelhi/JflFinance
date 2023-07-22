<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RefresherTrainingSchedulePatternDefinition.aspx.cs" Inherits="Masters_RefresherTrainingSchedulePatternDefinition"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="squareboxgradientcaption" style="height: 20px;">
                <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,RefresherTrainingSchedulePatternDefinition %>"></asp:Label>
            </div>
            <div>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: left">
                    <tr>
                        <td>
                            <asp:Label CssClass="cssLable" ID="lblTrainingCode" runat="server" Text="<%$Resources:Resource,Training %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="csstxtboxReadonly" ID="txtTrainingCode" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="cssLable" ID="lblTrainingDesc" runat="server" Text="<%$Resources:Resource,TrainingDesc %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="csstxtboxReadonly" ID="txtTrainingDesc" Width="500px" runat="server"
                                ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="cssLable" ID="lblValidForMonths" runat="server" Text="<%$Resources:Resource,ValidForMonths %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="csstxtboxReadonly" ID="txtValidForMonths" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="cssLable" ID="lblRefTrainAfterNMonths" runat="server" Text="<%$Resources:Resource,RefTrainAfterNMonths %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="csstxtboxReadonly" ID="txtRefTrainAfterNMonths" runat="server"
                                ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="cssLable" ID="lblRefTrainingDays" runat="server" Text="<%$Resources:Resource,RefTrainingDays %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="csstxtboxReadonly" ID="txtRefTrainingDays" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnSubmit" runat="server" Text="<%$Resources:Resource,Define %>" CssClass="cssButton" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:Resource,Back %>" CssClass="cssButton" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
                <Ajax:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>
                                    <asp:Panel ID="Paneldatagrid" BorderWidth="1px" runat="server" Width="100%" Height="200px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="100%" ID="gvTraining" UseAccessibleHeader="true" CssClass="GridViewStyle"
                                            runat="server" ShowFooter="True" AllowPaging="True" PageSize="7" CellPadding="1"
                                            GridLines="None" AutoGenerateColumns="False" AllowSorting="false" OnRowCommand="gvTraining_RowCommand"
                                            OnRowDataBound="gvTraining_RowDataBound" OnPageIndexChanging="gvTraining_PageIndexChanging"
                                            OnRowCancelingEdit="gvTraining_RowCancelingEdit" OnRowDeleting="gvTraining_RowDeleting"
                                            OnRowEditing="gvTraining_RowEditing" OnRowUpdating="gvTraining_RowUpdating" DataKeyNames="TrainingCode"
                                            OnSelectedIndexChanged="gvTraining_SelectedIndexChanged" onmousemove="TableResize_OnMouseMove(this);"
                                            onmouseup="TableResize_OnMouseUp(this);" onmousedown="TableResize_OnMouseDown(this);"
                                            OnRowCreated="gvTraining_RowCreated">
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
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,TrainingCode %>" HeaderStyle-Width="100px"
                                                    ItemStyle-Width="100px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditTrainingCode" Width="100px" CssClass="cssLabel" runat="server"
                                                            Text='<%# Eval("TrainingCode") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItmTrainingCode" Width="100px" CssClass="cssLabel" runat="server"
                                                            Text='<%# Eval("TrainingCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,MonthAfter %>" HeaderStyle-Width="150px"
                                                    ItemStyle-Width="150px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="LabelEditItemMonth" Width="125px" CssClass="cssLabel" runat="server"
                                                            Text='<%# Bind("MonthVal") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelItemMonth" Width="125px" CssClass="cssLabel" runat="server" Text='<%# Bind("MonthVal") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,RefTrainingDays %>" HeaderStyle-Width="200px"
                                                    ItemStyle-Width="200px">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtRefTrainingDays" CssClass="csstxtbox" Width="30px" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "TrainingDays").ToString() %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRefTrainingDays" runat="server"
                                                            ControlToValidate="txtRefTrainingDays" ErrorMessage="" SetFocusOnError="True"
                                                            ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                                                        <asp:RangeValidator runat="server" ID="rvRefTrainingDays" SetFocusOnError="true"
                                                            ValidationGroup="Edit" ControlToValidate="txtRefTrainingDays" Type="Integer"
                                                            MinimumValue="1" MaximumValue="31" ErrorMessage="*"></asp:RangeValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelRefTrainingDays" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TrainingDays").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                            ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                            ValidationGroup="Edit" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                            CommandName="Cancel" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                            CommandName="Edit" />
                                                    </ItemTemplate>
                                                    <FooterStyle Width="100px" />
                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                    <asp:HiddenField ID="hfTrainingCode" runat="server" />
                                    <asp:HiddenField ID="hfTrainingDate" runat="server" />
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
