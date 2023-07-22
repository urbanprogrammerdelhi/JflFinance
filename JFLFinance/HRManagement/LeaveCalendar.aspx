<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveCalendar.aspx.cs" Inherits="HRManagement_LeaveCalendar" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                                    <asp:Panel ID="Panel1" BorderWidth="0px" runat="server" Width="100%" Height="250px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvLeaveCalendar" Width="100%" CssClass="GridViewStyle" PageSize="15"
                                            runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                            OnRowCancelingEdit="gvLeaveCalendar_RowCancelingEdit" OnRowCommand="gvLeaveCalendar_RowCommand"
                                            OnRowDataBound="gvLeaveCalendar_RowDataBound" OnRowEditing="gvLeaveCalendar_RowEditing" OnRowDeleting="gvLeaveCalendar_RowDeleting"
                                            OnRowUpdating="gvLeaveCalendar_RowUpdating" ShowFooter="True" OnPageIndexChanging="gvLeaveCalendar_PageIndexChanging">
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
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,LeaveCalendarCode %>" HeaderStyle-Width="250px"
                                                    FooterStyle-Width="250px" ItemStyle-Width="250px" >
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnLCCode" runat="server" CssClass="cssImgButton" CommandName="Select"
                                                            ToolTip="<%$ Resources:Resource, ViewDetails %>" ImageUrl="../Images/tick.gif"
                                                            OnClick="ImgbtnLCCode_Click" />
                                                        <asp:Label ID="lblLCCode" CssClass="cssLable" runat="server" Text='<%# Bind("Leave_cal_code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblLCCode" CssClass="cssLable" runat="server" Text='<%# Bind("Leave_cal_code") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate >
                                                        <asp:TextBox ID="txtLCCode" Width="80px" MaxLength="16" ValidationGroup="vgFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvLCCode" runat="server" ControlToValidate="txtLCCode"
                                                            ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,LeaveCalendarDesc %>" HeaderStyle-Width="250px"
                                                    FooterStyle-Width="250px" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLCDesc" CssClass="cssLable" runat="server" Text='<%# Bind("Leave_cal_desc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:HiddenField runat="server" ID="HfLCCode" Value='<%# Bind("Leave_cal_code") %>' />
                                                        <asp:TextBox ID="txtEditLCDesc" Width="130px" Text='<%# Bind("Leave_cal_desc") %>' MaxLength="50" ValidationGroup="vgFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFtrLCDesc" Width="130px" MaxLength="50" ValidationGroup="vgFooter"
                                                            CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EffectiveFrom %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFromDate")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditFromDate" Width="100px"  CssClass="csstxtbox" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveFromDate"))%>'></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditFromDate" PopupButtonID="IMGDate" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtftrFromDate" Width="100px"  CssClass="csstxtbox" runat="server" Text=""></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrFromDate" PopupButtonID="IMGDate" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px"
                                                    HeaderText=''>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EffectiveTo %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveTo" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveTodate")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditToDate" CssClass="csstxtbox" Width="100px" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveTodate"))%>'></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender6" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditToDate" PopupButtonID="IMGDate" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtftrToDate" CssClass="csstxtbox"  Width="100px" runat="server" Text=""></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender7" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrToDate" PopupButtonID="IMGDate" />
                                                    </FooterTemplate>
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
                                                    <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                                                        <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif"
                                                            CssClass="cssImgButton" runat="server" ValidationGroup="vgFooter" CommandName="AddNew" />
                                                        <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif"
                                                            CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                    <asp:HiddenField runat="server" ID="hfglobalLCCode" Value="" />
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    <asp:Panel ID="Panel2" BorderWidth="0px" runat="server" Width="100%" Height="150px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvCalendarCategoryMapping" Width="100%" CssClass="GridViewStyle"
                                            PageSize="15" runat="server" AllowPaging="True" CellPadding="1" GridLines="None"
                                            AutoGenerateColumns="False" 
                                            OnRowCommand="gvCalendarCategoryMapping_RowCommand" OnRowDataBound="gvCalendarCategoryMapping_RowDataBound"
                                            OnRowDeleting="gvCalendarCategoryMapping_RowDeleting" ShowFooter="True" OnPageIndexChanging="gvCalendarCategoryMapping_PageIndexChanging"
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
                                                        <asp:Label ID="lblgvHdrCategorySno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvCategorySno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="250" HeaderStyle-Width="250" FooterStyle-Width="250">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrCategoryCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,CategoryCode %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvCategoryCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryCode").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID ="ddlCategoryCode" Width="200" runat="server" CssClass="cssDropDown" AutoPostBack ="true" OnSelectedIndexChanged="ddlCategoryCode_OnSelectedIndexChanged"   ></asp:DropDownList> 
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="500" HeaderStyle-Width="500" FooterStyle-Width="500">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrCategoryName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,CategoryDescription %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcategoryName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryDesc").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                   <%-- <FooterTemplate>
                                                        <asp:Label ID="lblftrcategoryName" CssClass="cssLable" runat="server" Text=""></asp:Label>
                                                    </FooterTemplate>--%>
                                                    <HeaderStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif"
                                                            CssClass="cssImgButton" runat="server" ValidationGroup="vgFooter1" CommandName="AddNew" />
                                                        <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" ImageUrl="../Images/Reset.gif"
                                                            CssClass="cssImgButton" runat="server" CausesValidation="False" CommandName="Reset" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
</asp:Content>
