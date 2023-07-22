<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Training.aspx.cs" Inherits="Masters_Training" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button ID="btnExport" Visible="true" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>" OnClick="btnExport_Click" />
    <Ajax:UpdatePanel runat="server" ID="up1">
        <ContentTemplate>
            <asp:Panel ID="Paneldatagrid" BorderWidth="0" runat="server">
                <asp:GridView Width="1350px" ID="gvTraining" UseAccessibleHeader="true" CssClass="GridViewStyle"
                    runat="server" ShowFooter="True" AllowPaging="True" PageSize="7" CellPadding="1"
                    GridLines="None" AutoGenerateColumns="False" AllowSorting="false" OnRowCommand="gvTraining_RowCommand"
                    OnRowDataBound="gvTraining_RowDataBound" OnPageIndexChanging="gvTraining_PageIndexChanging"
                    OnRowCancelingEdit="gvTraining_RowCancelingEdit" OnRowDeleting="gvTraining_RowDeleting"
                    OnRowEditing="gvTraining_RowEditing" OnRowUpdating="gvTraining_RowUpdating" DataKeyNames="CompanyCode,TrainingCode"
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
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,TrainingCode %>" HeaderStyle-Width="200px"
                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                            <EditItemTemplate>
                                <asp:Label ID="lblTrainingCode" CssClass="cssLabel" runat="server" Text='<%# Eval("TrainingCode") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewTrainingCode" CssClass="csstxtbox" Width="85%" MaxLength="16"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewTrainingCode"
                                    ErrorMessage="" ValidationGroup="AddNew" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%--<asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("TrainingCode") %>'></asp:Label>--%>
                                <asp:LinkButton ID="lblItmTrainingCode" CssClass="cssLable" runat="server" Text='<%# Bind("TrainingCode") %>'
                                    OnClick="lblTrainingCode_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,TrainingDesc %>" HeaderStyle-Width="250px"
                            FooterStyle-Width="250px" ItemStyle-Width="250px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTrainingDesc" CssClass="csstxtbox" Width="225px" MaxLength="50"
                                    runat="server" Text='<%# Bind("TrainingDesc") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTrainingDesc"
                                    ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewTrainingDesc" CssClass="csstxtbox" Width="225px" MaxLength="100"
                                    ValidationGroup="AddNew" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewTrainingDesc"
                                    ErrorMessage="" ValidationGroup="AddNew" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" Width="225px" CssClass="cssLabel" runat="server" Text='<%# Bind("TrainingDesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrTrainingCategory" Width="100px" runat="server" Text="<%$ Resources:Resource, TrainingCategory %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvItmTrainingCategory" CssClass="cssLable" Width="100px" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "TrainingCategory").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfTrainingCategory" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TrainingCategoryCode").ToString()%>' />
                                <asp:DropDownList CssClass="cssDropDown" Width="100px" ID="ddlTrainingCategory" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlNewTrainingCategory" Width="100px" CssClass="cssDropDown"
                                    runat="server">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrTrainingLevel" Width="100px" runat="server" Text="<%$ Resources:Resource, TrainingLevel %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvItmTrainingLevel" CssClass="cssLable" Width="100px" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "TrainingLevel").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfTrainingLevel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TrainingLevelCode").ToString()%>' />
                                <asp:DropDownList CssClass="cssDropDown" Width="100px" ID="ddlTrainingLevel" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlNewTrainingLevel" Width="100px" CssClass="cssDropDown" runat="server">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ValidForMonths %>" HeaderStyle-Width="60px"
                            FooterStyle-Width="60px" ItemStyle-Width="60px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNoValidMonths" CssClass="csstxtbox" Width="30px" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ValidMonths").ToString() %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorValidMonths1" runat="server"
                                    ControlToValidate="txtNoValidMonths" ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server" ID="rvNoValidMonths" SetFocusOnError="true" ValidationGroup="Edit"
                                    ControlToValidate="txtNoValidMonths" Type="Integer" MinimumValue="0" MaximumValue="99"
                                    ErrorMessage="*"></asp:RangeValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewNoValidMonths" CssClass="csstxtbox" Width="30px" ValidationGroup="AddNew"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorValidMonths2" runat="server"
                                    ControlToValidate="txtNewNoValidMonths" ErrorMessage="" ValidationGroup="AddNew"
                                    Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server" ID="rvNoValidMonths1" SetFocusOnError="true" ValidationGroup="AddNew"
                                    ControlToValidate="txtNewNoValidMonths" Type="Integer" MinimumValue="0" MaximumValue="99"
                                    ErrorMessage="*"></asp:RangeValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelNoValidMonths" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ValidMonths").ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrRefreshTraining" Width="100px" runat="server" Text="<%$ Resources:Resource, RefresherTraining %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvItmRefreshTraining" CssClass="cssLable" Width="100px" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "RefreshTrainingDesc").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfRefreshTraining" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RefreshTrainingDesc").ToString()%>' />
                                <asp:DropDownList CssClass="cssDropDown" Width="100px" ID="ddlRefreshTraining" runat="server"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlRefreshTraining_SelectedIndexChanged">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlNewRefreshTraining" Width="100px" CssClass="cssDropDown"
                                    runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNewRefreshTraining_SelectedIndexChanged">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrIsTrainingFlexi" Width="100px" runat="server" Text="<%$ Resources:Resource, IsTrainingFlexi %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbIsTrainingFlexi" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsTrainingFlexi").ToString())%>' Enabled="false" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="cbEditIsTrainingFlexi" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsTrainingFlexi").ToString())%>' OnCheckedChanged="cbEditIsTrainingFlexi_OnCheckedChange" AutoPostBack="true" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="cbNewIsTrainingFlexi" CssClass="cssCheckBox" runat="server" Checked='false' OnCheckedChanged="cbNewIsTrainingFlexi_OnCheckedChange" AutoPostBack="true" />
                            </FooterTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrLeeWayDays" Width="100px" runat="server" Text="<%$ Resources:Resource, LeeWayDays %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvItmLeeWayDays" CssClass="cssLable" Width="50px" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "LeeWayDays").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                    <asp:TextBox ID="txtEditLeeWayDays" CssClass="csstxtbox" Width="50px" MaxLength="3"
                                    runat="server" Text='<%# Bind("LeeWayDays") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                    <asp:TextBox ID="txtNewLeeWayDays" CssClass="csstxtbox" Width="50px" MaxLength="3"
                                    runat="server" Text=""></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,RefTrainAfterNMonths %>" HeaderStyle-Width="130px"
                            FooterStyle-Width="130px" ItemStyle-Width="130px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRefTrainAfterNMonths" CssClass="csstxtbox" Width="30px" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "RefTrainAfterNMonths").ToString() %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRefTrainAfterNMonths" runat="server"
                                    ControlToValidate="txtRefTrainAfterNMonths" ErrorMessage="" SetFocusOnError="True"
                                    ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server" ID="rvRefTrainAfterNMonths" SetFocusOnError="true"
                                    ValidationGroup="Edit" ControlToValidate="txtRefTrainAfterNMonths" Type="Integer"
                                    MinimumValue="0" MaximumValue="99" ErrorMessage="*"></asp:RangeValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewRefTrainAfterNMonths" CssClass="csstxtbox" Width="30px" ValidationGroup="AddNew"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRefTrainAfterNMonths1" runat="server"
                                    ControlToValidate="txtNewRefTrainAfterNMonths" ErrorMessage="" ValidationGroup="AddNew"
                                    Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server" ID="rvRefTrainAfterNMonths1" SetFocusOnError="true"
                                    ValidationGroup="AddNew" ControlToValidate="txtNewRefTrainAfterNMonths" Type="Integer"
                                    MinimumValue="0" MaximumValue="99" ErrorMessage="*"></asp:RangeValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelRefTrainAfterNMonths" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RefTrainAfterNMonths").ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,RefTrainingDays %>" HeaderStyle-Width="60px"
                            FooterStyle-Width="60px" ItemStyle-Width="60px">
                            <EditItemTemplate>
                            <%--Added 0 to Minimun Value by Manoj on 05/04/2013--%>
                                <asp:TextBox ID="txtRefTrainingDays" CssClass="csstxtbox" Width="30px" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "RefTrainingDays").ToString() %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRefTrainingDays" runat="server"
                                    ControlToValidate="txtRefTrainingDays" ErrorMessage="" SetFocusOnError="True"
                                    ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server" ID="rvRefTrainingDays" SetFocusOnError="true"
                                    ValidationGroup="Edit" ControlToValidate="txtRefTrainingDays" Type="Integer"
                                    MinimumValue="0" MaximumValue="31" ErrorMessage="*"></asp:RangeValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewRefTrainingDays" CssClass="csstxtbox" Width="30px" ValidationGroup="AddNew"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRefTrainingDays1" runat="server"
                                    ControlToValidate="txtNewRefTrainingDays" ErrorMessage="" ValidationGroup="AddNew"
                                    Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server" ID="rvRefTrainingDays1" SetFocusOnError="true"
                                    ValidationGroup="AddNew" ControlToValidate="txtNewRefTrainingDays" Type="Integer"
                                    MinimumValue="0" MaximumValue="31" ErrorMessage="*"></asp:RangeValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelRefTrainingDays" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RefTrainingDays").ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,DefinePattern %>" HeaderStyle-Width="60px"
                            FooterStyle-Width="60px" ItemStyle-Width="60px">
                            <EditItemTemplate>
                                <asp:Label ID="LabelRefTrainingDaysPatternEdit" CssClass="cssLabel" runat="server"
                                    Text="<%$ Resources:Resource,Define %>"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblItmTrainingDaysPatternItem" CssClass="cssLable" runat="server"
                                    Text="<%$ Resources:Resource,Define %>" OnClick="lblTrainingDaysPatternItem_Click"></asp:LinkButton>
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
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                &nbsp;
                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                    CommandName="Edit" />
                                &nbsp;
                                <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Code" Visible="false">
                            <EditItemTemplate>
                                <asp:Label ID="lblCompanyCode" runat="server" Text='<%# Eval("CompanyCode") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblNewCompanyCode" runat="server" Text="Label" Visible="True"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCompanyCode" runat="server" Text='<%# Bind("CompanyCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:HiddenField ID="hfTrainingCode" runat="server" />
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
            <asp:Panel ID="PanelTrainingSubstituteMapping" runat="server" Visible="false">
                <div class="squareboxgradientcaption" style="height: 20px;">
                    <asp:Label ID="LabelSubstituteTrainingDetails" runat="server" Text="<%$Resources:Resource,SubstituteTrainingDetails %>"></asp:Label>
                </div>
                <div>
                    <asp:GridView Width="100%" ID="gvSubstituteTrainingDetails" AllowPaging="True" PageSize="5"
                        CssClass="GridViewStyle" runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                        ShowFooter="True" OnPageIndexChanging="gvSubstituteTrainingDetails_PageIndexChanging"
                        OnRowCommand="gvSubstituteTrainingDetails_RowCommand" OnRowDataBound="gvSubstituteTrainingDetails_RowDataBound"
                        OnRowDeleting="gvSubstituteTrainingDetails_RowDeleting" OnRowEditing="gvSubstituteTrainingDetails_RowEditing"
                        OnRowCancelingEdit="gvSubstituteTrainingDetails_RowCancelingEdit" OnRowUpdating="gvSubstituteTrainingDetails_RowUpdating">
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                <FooterTemplate>
                                    <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                        CssClass="cssImgButton" ValidationGroup="AddNewSubstituteTrainingDetails" CommandName="AddNewSubstituteTrainingDetails"
                                        ImageUrl="../Images/AddNew.gif" />
                                    &nbsp;
                                    <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                        CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="IBEditSubstituteTrainingDetails" ToolTip="<%$Resources:Resource, Edit %>"
                                        ImageUrl="~/Images/Edit.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                        CommandName="Edit" />
                                    <asp:ImageButton ID="ImgbtnDeleteSubstituteTrainingDetails" ToolTip="<%$Resources:Resource,Delete %>"
                                        ImageUrl="~/Images/Delete.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                        CommandName="Delete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CausesValidation="True"
                                        CommandName="Update" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                    <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CausesValidation="False"
                                        CommandName="Cancel" ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
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
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrSubTrainingDesc" CssClass="cssLabelHeader" Width="400px" runat="server"
                                        Text="<%$ Resources:Resource, TrainingDesc %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvItmSubTrainingDesc" CssClass="cssLable" Width="400px" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "TrainingDesc").ToString()%>'></asp:Label>
                                    <asp:HiddenField ID="hfSubTrainingCodeItm" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "STrainingCode").ToString()%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="hfSubTrainingCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "STrainingCode").ToString()%>' />
                                    <asp:DropDownList CssClass="cssDropDown" Width="400px" ID="ddlSubTrainingDesc" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlNewSubTrainingDesc" Width="400px" CssClass="cssDropDown"
                                        runat="server">
                                    </asp:DropDownList>
                                </FooterTemplate>
                                <ItemStyle Width="400px" />
                                <HeaderStyle Width="400px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
