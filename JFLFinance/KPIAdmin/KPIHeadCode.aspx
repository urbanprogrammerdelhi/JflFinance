<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="KPIHeadCode.aspx.cs" Inherits="KPIAdmin_KPIHeadCode" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td>
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="98%" Height="420px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="100%" ID="gvKpiCode" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="8"
                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvKpiCode_RowCommand"
                                            OnRowUpdating="gvKpiCode_RowUpdating" OnRowDeleting="gvKpiCode_RowDeleting" OnRowEditing="gvKpiCode_RowEditing"
                                            OnRowCancelingEdit="gvKpiCode_RowCancelingEdit" OnRowDataBound="gvKpiCode_RowDataBound"
                                            OnPageIndexChanging="gvKpiCode_PageIndexChanging" OnRowCreated="gvKpiCode_RowCreated">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" Font-Size="12px"
                                                Font-Bold="true" Font-Names="Tohana" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                    <HeaderStyle Width="50px" />
                                                    <FooterStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvhdrgvKpiCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "KPIHeadCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvhdrgvKpiCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "KPIHeadCode").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtKpiCode" CssClass="csstxtbox" MaxLength="32" runat="server" Text=""></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvDepartmentCode" ValidationGroup="vgCFooter" ControlToValidate="txtKpiCode"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvKpiCodeDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "KPIHeadDesc").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="250px" ID="txtKpiDesc" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "KPIHeadDesc").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvDepartmentDesc" ValidationGroup="vgCEdit" ControlToValidate="txtKpiDesc"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="250px" ID="txtKpiDesc" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvDepartmentDesc" ValidationGroup="vgCFooter" ControlToValidate="txtKpiDesc"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTargetValue" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TargetValue").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtTargetValue" CssClass="csstxtbox" runat="server"
                                                            MaxLength="18"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvCompanyAddress" ValidationGroup="vgCFooter" ControlToValidate="txtTargetValue"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="lwvalTargetValue" runat="server" MinimumValue="0.0" MaximumValue="999999999999.99"
                                                            ControlToValidate="txtTargetValue" CssClass="csslblErrMsg" ErrorMessage="*" SetFocusOnError="true"></asp:RangeValidator>
                                                        <AjaxToolKit:MaskedEditExtender ID="lwmskTargetValue" runat="server" TargetControlID="txtTargetValue"
                                                            MaskType="Number" Mask="9999999999999999.99" InputDirection="LeftToRight" AutoComplete="false">
                                                        </AjaxToolKit:MaskedEditExtender>
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" Width="100px" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvIsgroupTarget" CssClass="cssLable" runat="server" Text='<%# (Boolean.Parse(Eval("IsGroupTarget").ToString())) ? "Yes" : "No" %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="chkIsgroupTarget" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsGroupTarget")%>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="chkFtrIsgroupTarget" runat="server" />
                                                    </FooterTemplate>
                                                    <FooterStyle Width="70px" VerticalAlign="Top" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <%--  ---------Added New Coloum-------------------------%>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRedFrom" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedFrom").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox   Width="50px" ID="txtRedFrom" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRedFrom" ValidationGroup="vgCFooter" ControlToValidate="txtRedFrom"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvRedFrom" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtRedFrom" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvRedFrom" runat="server" ControlToValidate="txtRedFrom"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$">
                                                        </asp:RegularExpressionValidator>
                                                       
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRedTo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedTo").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtRedTo" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRedTo" ValidationGroup="vgCFooter" ControlToValidate="txtRedTo"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvRedTo" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtRedTo" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvRedTo" runat="server" ControlToValidate="txtRedTo"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                        
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAmberFrom" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberFrom").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtAmberFrom" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAmberFrom" ValidationGroup="vgCFooter" ControlToValidate="txtAmberFrom"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvAmberFrom" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtAmberFrom" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvAmberFrom" runat="server" CssClass="csslblInfoMsg"
                                                            ControlToValidate="txtAmberFrom" SetFocusOnError="true" ErrorMessage="*" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                     
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAmberTo" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Max %>" runat="server"
                                                            Width="100%"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAmberTo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberTo").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtAmberTo" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfAmberTo" ValidationGroup="vgCFooter" ControlToValidate="txtAmberTo"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvAmberTo" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtAmberTo" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvAmberTo" runat="server" CssClass="csslblInfoMsg"
                                                            ControlToValidate="txtAmberTo" SetFocusOnError="true" ErrorMessage="*" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                        
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%--
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrGreenFrom" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Min %>" runat="server"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvGreenFrom" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GreenFrom").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtGreenFrom" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvGreenFrom" ValidationGroup="vgCFooter" ControlToValidate="txtGreenFrom"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvGreenFrom" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtGreenFrom" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvGreenFrom" runat="server" CssClass="csslblInfoMsg"
                                                            ControlToValidate="txtGreenFrom" SetFocusOnError="true" ErrorMessage="*" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                        
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrGreenTo" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Max %>" runat="server"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvGreenTo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GreenTo").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtGreenTo" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvGreenTo" ValidationGroup="vgCFooter" ControlToValidate="txtGreenTo"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvGreenTo" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtGreenTo" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvGreenTo" runat="server" CssClass="csslblInfoMsg"
                                                            ControlToValidate="txtGreenTo" SetFocusOnError="true" ErrorMessage="*" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                        
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <%-- Added Column for New Value range --%>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAmberFromMin" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Min %>"  runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    --%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAmberFromMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberFromMin").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtAmberFromMin" CssClass="csstxtbox" runat="server"
                                                            MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAmberFromMin" ValidationGroup="vgCFooter" ControlToValidate="txtAmberFromMin"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvAmberFromMin" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtAmberFromMin" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvAmberFromMin" runat="server" CssClass="csslblInfoMsg"
                                                            ControlToValidate="txtAmberFromMin" SetFocusOnError="true" ErrorMessage="*" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                     
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle BackColor="#ff9900" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAmberToMin" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Max %>"  runat="server"
                                                            Width="100%"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAmberToMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberToMin").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtAmberToMin" CssClass="csstxtbox" runat="server"
                                                            MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfAmberToMin" ValidationGroup="vgCFooter" ControlToValidate="txtAmberToMin"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvAmberToMin" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtAmberToMin" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvAmberToMin" runat="server" CssClass="csslblInfoMsg"
                                                            ControlToValidate="txtAmberToMin" SetFocusOnError="true" ErrorMessage="*" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                             
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle BackColor="#ff9900" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%-- <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrRedFromMin" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Min %>"  runat="server"></asp:Label>
                                                    </HeaderTemplate--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRedFromMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedFromMin").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtRedFromMin" CssClass="csstxtbox" runat="server"
                                                            MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRedFromMin" ValidationGroup="vgCFooter" ControlToValidate="txtRedFromMin"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvRedFromMin" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtRedFromMin" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvRedFromMin" runat="server" ControlToValidate="txtRedFromMin"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$">
                                                        </asp:RegularExpressionValidator>
                                                        
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle BackColor="#ff9900" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrRedToMin" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Max %>"  runat="server"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRedToMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedToMin").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="50px" ID="txtRedToMin" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRedToMin" ValidationGroup="vgCFooter" ControlToValidate="txtRedToMin"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvRedToMin" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtRedToMin" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ID="rxvRedToMin" runat="server" ControlToValidate="txtRedToMin"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <HeaderStyle BackColor="#ff9900" />
                                                </asp:TemplateField>
                                                <%-----------------------------------------Added New Coloum For Editable or not-----------------------------%>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrEditable" CssClass="cssLabelHeader" Text="Is Editable" runat="server"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEditable" CssClass="cssLable" runat="server" Text='<%# (Boolean.Parse(Eval("IsEditable").ToString())) ? "Yes" : "No" %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <%-- -----------------------------Below this we have to implement Edit functionl--%>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="chkIsEditable" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsEditable")%>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="chkIsEditable" Checked="true" runat="server" />
                                                    </FooterTemplate>
                                                    <ItemStyle Width="100px" />
                                                    <FooterStyle Width="100px" VerticalAlign="Top" />
                                                    <HeaderStyle Width="100px" CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <%-- --------------------Added New Coloumn---------------------------%>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>">
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" Visible="false" />
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
                                                    <ItemStyle Width="150px" />
                                                    <HeaderStyle Width="150px" CssClass="GridViewHeaderStyle" HorizontalAlign="Left" />
                                                    <FooterStyle Width="150px" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <%---------------------------------Middle Panel----------------------------------------%>
                        <asp:Panel runat="server" ID="pnlKpiColorCode" Width="100%">
                            <table>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td align="right" style="width: 16%">
                                                    <asp:Label runat="server" ID="lblElementType" Text="<%$Resources:Resource,ElementType %>"
                                                        CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:HiddenField ID="hiddenStatus" runat="server" />
                                                    <asp:HiddenField ID="hiddenMaxAmndmentNO" runat="server" />
                                                    <asp:DropDownList runat="server" Width="180px" ID="ddElementType" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="ddElementType_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="Country" Text="Country     "></asp:ListItem>
                                                        <asp:ListItem Value="Region" Text="Region       "></asp:ListItem>
                                                        <asp:ListItem Value="Branch" Text="Branch       "></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" style="width: 16%">
                                                    <asp:Label runat="server" ID="Label1" CssClass="cssLabel" Text="<%$Resources:Resource,Status %>" />
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label runat="server" ID="lblStatus" CssClass="csslblErrMsg" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 16%">
                                                    <asp:Label runat="server" ID="lblAmendment" Text="<%$Resources:Resource,AmendmentNo %>"
                                                        CssClass="cssLabel" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList runat="server" ID="ddAmendment" Width="180px" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="ddAmendment_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:Label runat="server" ID="lblDate" CssClass="csslblErrMsg" />
                                                </td>
                                                <td align="right" style="width: 16%">
                                                    <asp:Label runat="server" ID="lblMonth" Text="<%$Resources:Resource,WEFDate %>" CssClass="cssLabel"
                                                        Visible="false" />
                                                </td>
                                                <td align="left" >
                                                    <asp:TextBox runat="server" ID="txtMonth" Visible="false" CssClass="csstxtboxReadonly"> </asp:TextBox>
                                                    <asp:ImageButton ID="imgDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"
                                                        Visible="false"></asp:ImageButton>
                                                    <AjaxToolKit:CalendarExtender ID="calMonth" Format="-yyyy" runat="server" TargetControlID="txtMonth"
                                                        PopupButtonID="imgDate" PopupPosition="TopRight" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RFVDateOfJoining" ValidationGroup="save" Display="Dynamic"
                                                        runat="server" Text="*" ControlToValidate="txtMonth"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton runat="server" ID="lnkLock" CssClass="cssButton" Width="50px" Visible="false"
                                                        Text="<%$Resources:Resource,Lock %>" OnClick="lnkLock_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 16%">
                                                </td>
                                                <td colspan="6" align="left">
                                                    <%--<asp:Button runat="server" ID="btnSave" CssClass="cssButton" Text="Save" Visible="false"
                                                    ValidationGroup="save" OnClick="btnSave_Click" />--%>
                                                    <asp:Button runat="server" ID="btnEdit" CssClass="cssButton" Text="Amend" OnClick="btnEdit_Click"
                                                        Visible="false" />
                                                    <%--<asp:Button ID="btnCorrect" runat="server" Text="Correct" Visible="false" 
                                     onclick="btnCorrect_Click" />--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 16%">
                                                </td>
                                                <td colspan="6" align="left">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <%-- ----------------------------------------------Lower Grid---------------------------------%>
                                <tr>
                                    <td colspan="6">
                                        <asp:GridView Width="100%" ID="gvKpiColorCode" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                            CellPadding="0" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvKpiColorCode_PageIndexChanging"
                                            OnRowUpdating="gvKpiColorCode_RowUpdating" OnRowEditing="gvKpiColorCode_RowEditing"
                                            OnRowCreated="gvKpiColorCode_RowCreated" OnRowCancelingEdit="gvKpiColorCode_RowCancelingEdit"
                                            OnRowDataBound="gvKpiColorCode_RowDataBound">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Left" Font-Size="12px"
                                                Width="50px" Font-Bold="true" Font-Names="Tohana" />
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvhdrgvKpiColorCode" Width="200px" CssClass="cssLable" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "KPIHeadDesc").ToString()%>'></asp:Label>
                                                        <asp:HiddenField ID="HFKPIHeadCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "KPIHeadCode").ToString()%>' />
                                                        <asp:HiddenField ID="HFIsEditable" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IsEditable").ToString()%>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:HiddenField ID="HFKPIHeadCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "KPIHeadCode").ToString()%>' />
                                                        <%-- <asp:HiddenField ID="HFIsEditable" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IsEditable").ToString()%>' />--%>
                                                        <asp:Label ID="lblgvhdrgvKpiColorCode" Width="200px" CssClass="cssLable" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "KPIHeadDesc").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="200px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                   <asp:Label ID="lblgvElementlevel" CssClass="cssLabelHeader" Text="Element Level"
                                                        runat="server"></asp:Label>
                                                </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvElementlevel" Width="80px" CssClass="cssLable" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ElementLevel").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvElementlevel" Width="80px" CssClass="cssLable" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ElementLevel").ToString()%>'> </asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <%--Added New Coloumn For Target Value--%>
                                                <asp:TemplateField>
                                                    <%--<HeaderTemplate>
                                                    <asp:Label ID="lblgvTargetValue" CssClass="cssLabelHeader" Text="Target Value" runat="server"></asp:Label>
                                                </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvTargetValue" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Targetvalue").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="100px" ID="txtTargetValue" CssClass="csstxtbox" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "Targetvalue").ToString()%>' MaxLength="20"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvCompanyAddress1" ValidationGroup="vgCEdit" ControlToValidate="txtTargetValue"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="lwvalTargetValue" runat="server" MinimumValue="0.0" MaximumValue="9999999999999999.99"
                                                            ControlToValidate="txtTargetValue" CssClass="csslblErrMsg" ErrorMessage="*" SetFocusOnError="true"></asp:RangeValidator>
                                                        <AjaxToolKit:MaskedEditExtender ID="lwmskTargetValue" runat="server" TargetControlID="txtTargetValue"
                                                            MaskType="Number" Mask="9999999999999999.99" InputDirection="LeftToRight" AutoComplete="false">
                                                        </AjaxToolKit:MaskedEditExtender>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <%-- END Added New Coloumn For Target  --%>
                                                <asp:TemplateField>
                                                    <%-- <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrRedFrom" CssClass="cssLabelHeader" Text="Red Min" runat="server"></asp:Label>
                                                </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRedFrom" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedFrom").ToString()%>'></asp:Label>
                                                        <%--<asp:Label ID="lblgvRedFromMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedFromMin").ToString()%>'></asp:Label>--%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtRedFrom" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedFrom").ToString()%>' MaxLength="5" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRedFrom" ValidationGroup="vgCEdit" ControlToValidate="txtRedFrom"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalRedFrom" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtRedFrom" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvRedFrom" runat="server" ControlToValidate="txtRedFrom"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                     
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRedTo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedTo").ToString()%>' ></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtRedTo" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedTo").ToString()%>' MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRedTo" ValidationGroup="vgCEdit" ControlToValidate="txtRedTo"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalRedTo" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtRedTo" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvRedTo" runat="server" ControlToValidate="txtRedTo"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%-- <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrAmberFrom" CssClass="cssLabelHeader" Text="Amber Min" runat="server"></asp:Label>
                                                </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAmberFrom" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberFrom").ToString()%>'></asp:Label>
                                                        <%-- <asp:Label ID="lblgvAmberFromMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberFromMin").ToString()%>'></asp:Label>--%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtAmberFrom" CssClass="csstxtbox" runat="server" MaxLength="5" Text='<%# DataBinder.Eval(Container.DataItem, "AmberFrom").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAmberFrom" ValidationGroup="vgCEdit" ControlToValidate="txtAmberFrom"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalAmberFrom" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtAmberFrom" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvAmberFrom" runat="server" ControlToValidate="txtAmberFrom"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAmberTo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberTo").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtAmberTo" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberTo").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAmberTo" ValidationGroup="vgCEdit" ControlToValidate="txtAmberTo"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalAmberTo" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtAmberTo" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvAmberTo" runat="server" ControlToValidate="txtAmberTo"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvGreenFrom" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GreenFrom").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtGreenFrom" CssClass="csstxtbox" runat="server" MaxLength="5" Text='<%# DataBinder.Eval(Container.DataItem, "GreenFrom").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvGreenFrom" ValidationGroup="vgCEdit" ControlToValidate="txtGreenFrom"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalGreenFrom" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtGreenFrom" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvGreenFrom" runat="server" ControlToValidate="txtGreenFrom"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvGreenTo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GreenTo").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtGreenTo" CssClass="csstxtbox" runat="server" MaxLength="5" Text='<%# DataBinder.Eval(Container.DataItem, "GreenTo").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvGreenTo" ValidationGroup="vgCEdit" ControlToValidate="txtGreenTo"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalGreenTo" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtGreenTo" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvGreenTo" runat="server" ControlToValidate="txtGreenTo"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAmberFromMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberFromMin").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtMinAmberFrom" CssClass="csstxtbox" runat="server" MaxLength="5"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "AmberFromMin").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAmberFromMin" ValidationGroup="vgCEdit" ControlToValidate="txtMinAmberFrom"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalAmberFromMin" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtMinAmberFrom" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvAmberFromMin" runat="server" ControlToValidate="txtMinAmberFrom"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAmberToMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmberToMin").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtAmberToMin" CssClass="csstxtbox" runat="server" MaxLength="5"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "AmberToMin").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvAmberToMin" ValidationGroup="vgCEdit" ControlToValidate="txtAmberToMin"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalAmberToMin" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtAmberToMin" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvAmberToMin" runat="server" ControlToValidate="txtAmberToMin"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRedFromMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedFromMin").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtMinRedFrom" CssClass="csstxtbox" runat="server" MaxLength="5"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "RedFromMin").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRedFromMin" ValidationGroup="vgCEdit" ControlToValidate="txtMinRedFrom"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalRedFromMin" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtMinRedFrom" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvRedFromMin" runat="server" ControlToValidate="txtMinRedFrom"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRedToMin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RedToMin").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtMinRedTo" CssClass="csstxtbox" runat="server" MaxLength="5" Text='<%# DataBinder.Eval(Container.DataItem, "RedToMin").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRedToMin" ValidationGroup="vgCEdit" ControlToValidate="txtMinRedTo"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ValidationGroup="vgCEdit" ID="lwvalRedToMin" runat="server" MinimumValue="-9999" MaximumValue="9999"
                                                            Type="Double" ControlToValidate="txtMinRedTo" CssClass="csslblErrMsg" ErrorMessage="*"
                                                            SetFocusOnError="true"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="vgCEdit" ID="rxvRedToMin" runat="server" ControlToValidate="txtMinRedTo"
                                                            SetFocusOnError="true" ErrorMessage="*" CssClass="csslblInfoMsg" ValidationExpression="^-?[0-9]*$"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                                <%-- --------------------Added New Coloumn---------------------------%>
                                                <asp:TemplateField>
                                                    <%--    <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>--%>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" Visible="false" />
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
                                                    <ItemStyle Width="70px" />
                                                    <HeaderStyle Width="70px" />
                                                    <FooterStyle Width="70px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <%-- ------------------------------------Lower Grid End Here--------------------------------------%>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
