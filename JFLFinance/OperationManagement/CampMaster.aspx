<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CampMaster.aspx.cs" Inherits="OperationManagement_CampMaster" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="160px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvCampMaster" Width="950px" CssClass="GridViewStyle" PageSize="10"
                                            runat="server" AllowPaging="True" CellPadding="1" ShowFooter="True" GridLines="None"
                                            AutoGenerateColumns="False" OnRowCancelingEdit="gvCampMaster_RowCancelingEdit"
                                            OnRowCommand="gvCampMaster_RowCommand" OnRowDataBound="gvCampMaster_RowDataBound"
                                            OnRowEditing="gvCampMaster_RowEditing" OnRowUpdating="gvCampMaster_RowUpdating"
                                            OnPageIndexChanging="gvCampMaster_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                                    FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,CampCode %>" HeaderStyle-Width="250px" FooterStyle-Width="250px"
                                                    ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnCCode" runat="server" CssClass="cssImgButton" CommandName="Select"
                                                            ToolTip="<%$ Resources:Resource, ViewDetails %>" ImageUrl="../Images/tick.gif"
                                                            OnClick="ImgbtnCCode_Click" />
                                                        <asp:Label ID="lblCCode" CssClass="cssLable" runat="server" Text='<%# Bind("CampCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCCode" CssClass="cssLable" runat="server" Text='<%# Bind("CampCode") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,CampName %>" HeaderStyle-Width="250px" FooterStyle-Width="250px"
                                                    ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCName" CssClass="cssLable" runat="server" Text='<%# Bind("CampName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:HiddenField runat="server" ID="HfCCode" Value='<%# Bind("CampCode") %>' />
                                                        <asp:TextBox ID="txtEditCName" Width="130px" Text='<%# Bind("CampName") %>' MaxLength="50"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfEditCampName" ValidationGroup="vgCampEdit" runat="server"
                                                            ControlToValidate="txtEditCName" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrCName" Width="130px" MaxLength="50" ValidationGroup="vgCampFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfFtrCampName" ValidationGroup="vgCampFooter" runat="server"
                                                            ControlToValidate="txtFtrCName" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,CampAddress %>" HeaderStyle-Width="250px" FooterStyle-Width="250px"
                                                    ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCAddress" CssClass="cssLable" runat="server" Text='<%# Bind("CampAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditCAddress" Width="130px" Text='<%# Bind("CampAddress") %>'
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfEditCampAdd" ValidationGroup="vgCampEdit" runat="server"
                                                            ControlToValidate="txtEditCAddress" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrCAddress" Width="130px" ValidationGroup="vgCampFooter" CssClass="csstxtbox"
                                                            runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfFtrCampAdd" ValidationGroup="vgCampFooter" runat="server"
                                                            ControlToValidate="txtFtrCAddress" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EffectiveFrom %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditCFromDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                        <%--                                                        <asp:TextBox ID="txtEditCFromDate" Width="100px" CssClass="csstxtbox" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveFrom"))%>'></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditCFromDate" PopupButtonID="IMGDate" />
--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtftrCFromDate" ValidationGroup="vgCampFooter" Width="100px" CssClass="csstxtbox"
                                                            runat="server" Text=""></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrCFromDate" PopupButtonID="IMGDate" />
                                                        <asp:RequiredFieldValidator ID="rfFtrCampFromDate" ValidationGroup="vgCampFooter"
                                                            runat="server" ControlToValidate="txtftrCFromDate" Display="Dynamic" Text="*"
                                                            SetFocusOnError="true" ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px"
                                                    HeaderText=''>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EffectiveTo %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCEffectiveTo" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveTo")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditCToDate" CssClass="csstxtbox" Width="100px" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveTo"))%>'></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender6" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditCToDate" PopupButtonID="IMGDate" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <%--                                                        <asp:TextBox ID="txtftrCToDate" CssClass="csstxtbox" Width="100px" runat="server"
                                                            Text=""></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender7" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrCToDate" PopupButtonID="IMGDate" />
--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgCampEdit" />
                                                        <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif"
                                                            CssClass="cssImgButton" runat="server" ValidationGroup="vgCampFooter" CommandName="AddNew" />
                                                        <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif"
                                                            CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField runat="server" ID="hfglobalCCode" Value="" />
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" BorderWidth="1px" runat="server" Width="950px" Height="160px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvBuildingMaster" Width="950px" CssClass="GridViewStyle" PageSize="15"
                                            runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                            OnRowCommand="gvBuildingMaster_RowCommand" OnRowDataBound="gvBuildingMaster_RowDataBound"
                                            OnRowEditing="gvBuildingMaster_RowEditing" OnRowCancelingEdit="gvBuildingMaster_RowCancelingEdit"
                                            OnRowUpdating="gvBuildingMaster_RowUpdating" ShowFooter="True" OnPageIndexChanging="gvBuildingMaster_PageIndexChanging"
                                            onmousemove="TableResize_OnMouseMove(this);" onmouseup="TableResize_OnMouseUp(this);"
                                            onmousedown="TableResize_OnMouseDown(this);">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="50" HeaderStyle-Width="50" FooterStyle-Width="50">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrBuildingSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvBuildingSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="250" HeaderStyle-Width="250" FooterStyle-Width="250">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrBuildingCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, BuildingCode %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnBuildingCode" runat="server" CssClass="cssImgButton" CommandName="Select"
                                                            ToolTip="<%$ Resources:Resource, ViewDetails %>" ImageUrl="../Images/tick.gif"
                                                            OnClick="ImgbtnBuildingCode_Click" />
                                                        <asp:Label ID="lblgvBuildingCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BuildingCode").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150" HeaderStyle-Width="150" FooterStyle-Width="150">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrBuildingName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, BuildingName %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBuildingName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BuildingName").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditBuildingName" Width="130px" Text='<%# DataBinder.Eval(Container.DataItem, "BuildingName").ToString()%>'
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfEditBuildName" ValidationGroup="vgBuildingEdit" runat="server"
                                                            ControlToValidate="txtEditBuildingName" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrBuildingName" Width="130px" MaxLength="50" ValidationGroup="vgBFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfFtrBuildName" ValidationGroup="vgBuildingAdd" runat="server"
                                                            ControlToValidate="txtFtrBuildingName" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150" HeaderStyle-Width="150" FooterStyle-Width="150">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrBuildingAddress" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource, BuildingAddress %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBuildingAddress" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BuildingAddress").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditBuildingAddress" Width="130px" Text='<%# DataBinder.Eval(Container.DataItem, "BuildingAddress").ToString()%>'
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfEditBuildAdd" ValidationGroup="vgBuildingEdit" runat="server"
                                                            ControlToValidate="txtEditBuildingAddress" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrBuildingAddress" Width="130px" ValidationGroup="vgBFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfFtrBuildAdd" ValidationGroup="vgBuildingAdd" runat="server"
                                                            ControlToValidate="txtFtrBuildingAddress" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvBuildingHdrEffectiveFrom" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource, EffectiveFrom %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblhdrBuildingEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditBuildingFromDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                        <%--                                                        <asp:TextBox ID="txtEditBuildingFromDate" Width="100px" CssClass="csstxtbox" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveFrom"))%>'></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditBuildingFromDate" PopupButtonID="IMGDate" />
--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtftrBuildingFromDate" Width="100px" CssClass="csstxtbox" runat="server"
                                                            Text=""></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrBuildingFromDate" PopupButtonID="IMGDate" />
                                                        <asp:RequiredFieldValidator ID="rfFtrBuildFromDate" ValidationGroup="vgBuildingAdd" runat="server"
                                                            ControlToValidate="txtftrBuildingFromDate" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px"
                                                    HeaderText=''>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvBuildingHdrEffectiveTo" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource, EffectiveTo %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblhdrBuildingEffectiveTo" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveTo")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditBuildingToDate" CssClass="csstxtbox" Width="100px" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveTo"))%>'></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender6" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditBuildingToDate" PopupButtonID="IMGDate" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <%--                                                        <asp:TextBox ID="txtftrBuildingToDate" CssClass="csstxtbox" Width="100px" runat="server"
                                                            Text=""></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender7" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrBuildingToDate" PopupButtonID="IMGDate" />
--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgBuildingEdit" />
                                                        <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                        <%--                                                        <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
--%>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif"
                                                            CssClass="cssImgButton" runat="server" ValidationGroup="vgBuildingAdd" CommandName="AddNew" />
                                                        <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif"
                                                            CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField runat="server" ID="hfglobalBuildingCode" Value="" />
                                    <%--<asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel3" BorderWidth="1px" runat="server" Width="950px" Height="160px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvBedMaster" Width="950px" CssClass="GridViewStyle" PageSize="15"
                                            runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                            OnRowCancelingEdit="gvBedMaster_RowCancelingEdit" OnRowCommand="gvBedMaster_RowCommand"
                                            OnRowDataBound="gvBedMaster_RowDataBound" OnRowEditing="gvBedMaster_RowEditing"
                                            OnRowUpdating="gvBedMaster_RowUpdating" ShowFooter="True" OnPageIndexChanging="gvBedMaster_PageIndexChanging"
                                            onmousemove="TableResize_OnMouseMove(this);" onmouseup="TableResize_OnMouseUp(this);"
                                            onmousedown="TableResize_OnMouseDown(this);">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="50" HeaderStyle-Width="50" FooterStyle-Width="50">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrBedSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvBedSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150" HeaderStyle-Width="150" FooterStyle-Width="150">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrFloorNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,FloorNumber %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvFloorNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FloorNo").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditgvFloorNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FloorNo").ToString()%>'> </asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrFloorno" Width="110px" MaxLength="10" ValidationGroup="vgBedFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfFtrFloorNo" ValidationGroup="vgBedAdd" runat="server"
                                                            ControlToValidate="txtFtrFloorno" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                            
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150" HeaderStyle-Width="150" FooterStyle-Width="150">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrFlatNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,FlatNumber %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvFlatNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FlatNo").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditgvFlatNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FlatNo").ToString()%>'> </asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrFlatNo" Width="110px" MaxLength="10" ValidationGroup="vgBedFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfFtrFlatNo" ValidationGroup="vgBedAdd" runat="server"
                                                            ControlToValidate="txtFtrFlatNo" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                            
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150" HeaderStyle-Width="150" FooterStyle-Width="150">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrRoomNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,RoomNumber %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvRoomNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoomNo").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditgvRoomNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoomNo").ToString()%>'> </asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrRoomNo" Width="110px" MaxLength="10" ValidationGroup="vgBedFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfFtrRoomNo" ValidationGroup="vgBedAdd" runat="server"
                                                            ControlToValidate="txtFtrRoomNo" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                            
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150" HeaderStyle-Width="150" FooterStyle-Width="150">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrBedNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,BedNumber %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvBedNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BedNo").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditgvBedNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BedNo").ToString()%>'> </asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrBedNo" Width="110px" MaxLength="10" ValidationGroup="vgBFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfFtrBedNo" ValidationGroup="vgBedAdd" runat="server"
                                                            ControlToValidate="txtFtrBedNo" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                            
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvBedHdrEffectiveFrom" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource, EffectiveFrom %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblhdrBedEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditBedFromDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                        <%--                                                        <asp:TextBox ID="txtEditBedFromDate" Width="100px" CssClass="csstxtbox" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveFrom"))%>'></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditBedFromDate" PopupButtonID="IMGDate" />
--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtftrBedFromDate" Width="100px" CssClass="csstxtbox" runat="server"
                                                            Text=""></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrBedFromDate" PopupButtonID="IMGDate" />
                                                        <asp:RequiredFieldValidator ID="rfFtrBedFromDate" ValidationGroup="vgBedAdd" runat="server"
                                                            ControlToValidate="txtftrBedFromDate" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                            ErrorMessage=""></asp:RequiredFieldValidator>
                                                            
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px"
                                                    HeaderText=''>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvBedHdrEffectiveTo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EffectiveTo %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblhdrBedEffectiveTo" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveTo")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditBedToDate" CssClass="csstxtbox" Width="100px" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveTo"))%>'></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender6" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditBedToDate" PopupButtonID="IMGDate" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <%--                                                        <asp:TextBox ID="txtftrBedToDate" CssClass="csstxtbox" Width="100px" runat="server"
                                                            Text=""></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender7" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrBedToDate" PopupButtonID="IMGDate" />
--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Update" />
                                                        <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif"
                                                            CssClass="cssImgButton" runat="server" ValidationGroup="vgBedAdd" CommandName="AddNew" />
                                                        <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif"
                                                            CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
