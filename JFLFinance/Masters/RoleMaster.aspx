<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPage.master"
    CodeFile="RoleMaster.aspx.cs" Inherits="Masters_RoleMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" BorderWidth="0px" runat="server">
                <asp:GridView ID="gvRoleMaster" Width="100%" CssClass="GridViewStyle" PageSize="12"
                    runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                    OnRowCancelingEdit="gvRoleMaster_RowCancelingEdit" OnRowCommand="gvRoleMaster_RowCommand"
                    OnRowDataBound="gvRoleMaster_RowDataBound" OnRowDeleting="gvRoleMaster_RowDeleting"
                    OnRowEditing="gvRoleMaster_RowEditing" OnRowUpdating="gvRoleMaster_RowUpdating" ShowFooter="True"
                    OnPageIndexChanging="gvRoleMaster_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="<%$Resources:Resource,RoleCode %>" HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblRoleCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoleCode").ToString()%>' OnClick="lblRoleCode_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="lblRoleCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoleCode").ToString()%>' OnClick="lblRoleCode_Click"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtRoleCode" Width="80px" MaxLength="25" ValidationGroup="vgFooter" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRoleCode" runat="server" ControlToValidate="txtRoleCode" ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,RoleDesc %>" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblRoleDesc" CssClass="cssLable" runat="server" Text='<%# Bind("RoleDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRoleDesc" Width = "200px"  CssClass="csstxtbox" runat="server" Text='<%# Bind("RoleDesc") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRoleCode1" runat="server" ControlToValidate="txtRoleDesc" ValidationGroup="vgEdit" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtRoleDesc" CssClass="csstxtbox" runat="server" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRoleCode2" runat="server" ControlToValidate="txtRoleDesc" ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgEdit" />
                                <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" CssClass="cssImgButton" runat="server" ValidationGroup="vgFooter" CommandName="AddNew" />
                                <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif" CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:HiddenField runat="server" ID="hfglobalRole" Value="" />
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
            <asp:Panel ID="Panel2" BorderWidth="0px" runat="server">
                <asp:HiddenField ID="hfspDecimalPlace" runat="server" Value="{0:D2}" />
                <asp:GridView ID="gvRoleDetail" Width="100%" CssClass="GridViewStyle" PageSize="15"
                    runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                    OnRowCancelingEdit="gvRoleDetail_RowCancelingEdit" OnRowCommand="gvRoleDetail_RowCommand"
                    OnRowDataBound="gvRoleDetail_RowDataBound" OnRowDeleting="gvRoleDetail_RowDeleting"
                    OnRowEditing="gvRoleDetail_RowEditing" OnRowUpdating="gvRoleDetail_RowUpdating"
                    ShowFooter="True" OnPageIndexChanging="gvRoleDetail_PageIndexChanging" onmousemove="TableResize_OnMouseMove(this);"
                    onmouseup="TableResize_OnMouseUp(this);" onmousedown="TableResize_OnMouseDown(this);">
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
                        <asp:TemplateField HeaderText="<%$Resources:Resource,RoleCode %>" HeaderStyle-Width="400px"
                            FooterStyle-Width="400px" ItemStyle-Width="400px">
                            <ItemTemplate>
                                <asp:Label ID="lblRoleCode" CssClass="cssLable" runat="server" Text='<%# Bind("RoleCode") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblRoleCode" CssClass="cssLable" runat="server" Text='<%# Bind("RoleCode") %>'></asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,EffectiveFrom %>" HeaderStyle-Width="200px"
                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblEffectiveFrom" CssClass="cssLable" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEffectiveFrom" CssClass="csstxtbox" Width="130" ValidationGroup="vgEdit"
                                    Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveFrom")) %>' runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnEffectiveFrom" Style="vertical-align: middle" CausesValidation="false"
                                    runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                    TargetControlID="txtEffectiveFrom" PopupButtonID="ImgBtnEffectiveFrom" PopupPosition="TopLeft" />
                                <asp:RequiredFieldValidator ID="rfvEffectiveFrom" runat="server" Display="Dynamic"
                                    ControlToValidate="txtEffectiveFrom" ValidationGroup="vgEdit" ErrorMessage="*"
                                    Text="*"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,EffectiveTo %>" HeaderStyle-Width="200px"
                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblEffectiveTo" CssClass="cssLable" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveTo")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEffectiveTo" CssClass="csstxtbox" Width="130" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveTo")) %>'
                                    runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnEffectiveTo" Style="vertical-align: middle" CausesValidation="false"
                                    runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                    TargetControlID="txtEffectiveTo" PopupButtonID="ImgBtnEffectiveTo"  PopupPosition="TopLeft" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                            <HeaderTemplate>
                                <asp:Label ID="lblChargeRatePerHrsCurr" CssClass="cssLabelHeader" runat="server"
                                    Font-Size="X-Small" Text="<%$ Resources:Resource,RatePerHour %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRate" CssClass="cssLable" runat="server" Text='<%#String.Format(hfspDecimalPlace.Value,Eval("Rate")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRate" CssClass="csstxtbox" MaxLength="15" Width="80" Text='<%#String.Format(hfspDecimalPlace.Value,Eval("Rate")) %>'
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRate" runat="server" Display="Dynamic" ControlToValidate="txtRate"
                                    ValidationGroup="vgEdit" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                            FooterStyle-Width="100px" ItemStyle-Width="100px">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                    CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgEdit" />
                                <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                    CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                <%--<asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
