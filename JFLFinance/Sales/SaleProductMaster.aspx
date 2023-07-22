<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SaleProductMaster.aspx.cs" Inherits="Sales_SaleProductMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvProductMaster" Width="100%" CssClass="GridViewStyle" PageSize="10"
                runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                OnRowCancelingEdit="gvProductMaster_RowCancelingEdit" OnRowCommand="gvProductMaster_RowCommand"
                OnRowDataBound="gvProductMaster_RowDataBound" OnRowDeleting="gvProductMaster_RowDeleting"
                OnRowEditing="gvProductMaster_RowEditing" OnRowUpdating="gvProductMaster_RowUpdating" ShowFooter="True"
                OnPageIndexChanging="gvProductMaster_PageIndexChanging">
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
                    <asp:TemplateField HeaderText="<%$Resources:Resource,SORank %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblSORank" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SORank").ToString()%>' OnClick="lblSORank_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lblSORank" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SORank").ToString()%>' OnClick="lblSORank_Click"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtSORank" Width="380px" MaxLength="50" ValidationGroup="vgFooter" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSORank" runat="server" ControlToValidate="txtSORank" ValidationGroup="vgFooter" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,DesignationCode %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblDesignationCode" CssClass="cssLable" runat="server" Text='<%# Bind("DesignationCode") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField runat="server" ID="HfDesignationCode" Value='<%# Bind("DesignationCode") %>' />
                            <asp:DropDownList CssClass="cssDropDown" Width="200px" ID="ddlDesignationCode" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList CssClass="cssDropDown" Width="200px" ID="ddlDesignationCode" runat="server"></asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,DesignationDescription %>" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                        <ItemTemplate>
                            <asp:Label ID="lblDesignationDesc" CssClass="cssLable" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblDesignationDesc" CssClass="cssLable" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblDesignationDesc" CssClass="cssLable" runat="server" Text=""></asp:Label>
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
            <asp:HiddenField runat="server" id="hfglobalSORank" Value=""/>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
            <asp:HiddenField ID="hfspDecimalPlace"  runat="server" Value="{0:D2}" />
            <asp:GridView ID="gvProductDetail" Width="100%" CssClass="GridViewStyle" PageSize="5"
                runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                OnRowCancelingEdit="gvProductDetail_RowCancelingEdit" OnRowCommand="gvProductDetail_RowCommand"
                OnRowDataBound="gvProductDetail_RowDataBound" OnRowDeleting="gvProductDetail_RowDeleting"
                OnRowEditing="gvProductDetail_RowEditing" OnRowUpdating="gvProductDetail_RowUpdating" ShowFooter="True"
                OnPageIndexChanging="gvProductDetail_PageIndexChanging" onmousemove="TableResize_OnMouseMove(this);" onmouseup="TableResize_OnMouseUp(this);" onmousedown="TableResize_OnMouseDown(this);">
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
                    <asp:TemplateField HeaderText="<%$Resources:Resource,SORank %>" HeaderStyle-Width="400px" FooterStyle-Width="400px" ItemStyle-Width="400px">
                        <ItemTemplate>
                            <asp:Label ID="lblSORank" CssClass="cssLable" runat="server" Text='<%# Bind("SORank") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblSORank" CssClass="cssLable" runat="server" Text='<%# Bind("SORank") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EffectiveFrom %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblEffectiveFrom" CssClass="cssLable" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEffectiveFrom" CssClass="csstxtbox" Width="130" ValidationGroup="vgEdit" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveFrom")) %>' runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnEffectiveFrom" Style="vertical-align: middle" CausesValidation="false" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtEffectiveFrom" PopupButtonID="ImgBtnEffectiveFrom" />
                            <asp:RequiredFieldValidator ID="rfvEffectiveFrom" runat="server" Display="Dynamic" ControlToValidate="txtEffectiveFrom" ValidationGroup="vgEdit" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EffectiveTo %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblEffectiveTo" CssClass="cssLable" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveTo")) %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEffectiveTo" CssClass="csstxtbox" Width="130" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveTo")) %>' runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnEffectiveTo" Style="vertical-align: middle" CausesValidation="false" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtEffectiveTo" PopupButtonID="ImgBtnEffectiveTo" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderTemplate>
                        <asp:Label ID="lblChargeRatePerHrsCurr" CssClass="cssLabelHeader" runat="server" Font-Size=X-Small
                                Text="<%$ Resources:Resource,RatePerHour %>"></asp:Label>
                                                            
                        </HeaderTemplate>
                                                
                        <ItemTemplate>
                            <asp:Label ID="lblRate" CssClass="cssLable" runat="server" Text='<%#String.Format(hfspDecimalPlace.Value,Eval("Rate")) %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtRate" CssClass="csstxtbox" MaxLength="15" Width="80" Text='<%#String.Format(hfspDecimalPlace.Value,Eval("Rate")) %>' runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRate" runat="server" Display="Dynamic" ControlToValidate="txtRate" ValidationGroup="vgEdit" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="vgEdit" />
                            <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <%--<asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
