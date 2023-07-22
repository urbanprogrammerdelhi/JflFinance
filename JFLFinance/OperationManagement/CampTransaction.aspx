<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CampTransaction.aspx.cs" Inherits="OperationManagement_CampTransaction"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 98%;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label13" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, Transaction %>"></asp:Label>
                                        </tt>
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                        <tr>
                                            <td align="right" style="width: 10%">
                                                <asp:Label ID="lblCampName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, CampName %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlCamp" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlCamp_OnSelectedIndexChanged"
                                                    AutoPostBack="true" Width="250px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" style="width: 10%">
                                                <asp:Label ID="lblBuildingName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, BuildingName %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlBuilding" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlBuilding_OnSelectedIndexChanged"
                                                    AutoPostBack="true" Width="250px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblFloorNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, FloorNumber %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlFloor" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlFloor_OnSelectedIndexChanged"
                                                    AutoPostBack="true" Width="100px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblFlatNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, FlatNumber %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlFlat" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlFlat_OnSelectedIndexChanged"
                                                    AutoPostBack="true" Width="100px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblRoomNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, RoomNumber %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlRoom" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlRoom_OnSelectedIndexChanged"
                                                    AutoPostBack="true" Width="100px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 1px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 1px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Panel ID="Panel3" BorderWidth="1px" runat="server" Width="940px" Height="250px"
                                                    ScrollBars="Auto" CssClass="ScrollBar">
                                                    <asp:GridView ID="gvBedRoster" Width="950px" CssClass="GridViewStyle" PageSize="15"
                                                        runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                                        OnRowCancelingEdit="gvBedRoster_RowCancelingEdit" OnRowCommand="gvBedRoster_RowCommand"
                                                        OnRowDataBound="gvBedRoster_RowDataBound" OnRowEditing="gvBedRoster_RowEditing"
                                                        OnRowUpdating="gvBedRoster_RowUpdating" ShowFooter="True" OnPageIndexChanging="gvBedRoster_PageIndexChanging"
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
                                                            <asp:TemplateField ItemStyle-Width="140" HeaderStyle-Width="140" FooterStyle-Width="140">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvHdrBedNo" CssClass="cssLabelHeader" runat="server" Text="Bed No"> </asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvBedNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BedNo").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hfBedAutoID" Visible="true" runat="server" Value='<%#Bind("BedAutoID") %>' />
                                                                    <asp:Label ID="lblEditgvBedNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BedNo").ToString()%>'> </asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlgvBedNo" Width="100" runat="server" CssClass="cssDropDown"
                                                                        AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150" HeaderStyle-Width="150" FooterStyle-Width="150">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblhdrEmployeeNumber" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEditgvEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblEditgvEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'> </asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtGvFtrEmployeeNumber" CssClass="csstxtbox" runat="server" Width="80Px"
                                                                        MaxLength="10" AutoPostBack="true" OnTextChanged="txtGvFtrEmployeeNumber_onTextChanged"></asp:TextBox>
                                                                    <asp:ImageButton ID="imgGvEmployeeNumberSearch" AlternateText="SearchClient" runat="server"
                                                                        ImageUrl="~/Images/icosearch.gif" ToolTip="Search Employee Number" />
                                                                    <asp:RequiredFieldValidator ID="rfEmployeeNumber" ValidationGroup="vgAdd" runat="server"
                                                                        ControlToValidate="txtGvFtrEmployeeNumber" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                                        ErrorMessage=""></asp:RequiredFieldValidator>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="170px" ItemStyle-Width="170px" FooterStyle-Width="170px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblhdrEmpName" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource,Name %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvEmpName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblgvEditEmpName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name").ToString()%>'> </asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblgvftrEmpName" CssClass="cssLable" runat="server" Text=""> </asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblhdrEmpNationlity" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource,Nationality %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvEmpNationlity" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nationality").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblgvEditEmpNationlity" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nationality").ToString()%>'> </asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblgvftrEmpNationlity" CssClass="cssLable" runat="server" Text=""> </asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="140px" FooterStyle-Width="140px" ItemStyle-Width="140px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvBedHdrEffectiveFrom" CssClass="cssLabelHeader" runat="server"
                                                                        Text="<%$ Resources:Resource, EffectiveFrom %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblhdrBedEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblEditBedFromDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                                    <%--                                                                    <asp:TextBox ID="txtEditBedFromDate" Width="100px" CssClass="csstxtbox" runat="server"
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
                                                                    <asp:RequiredFieldValidator ID="rfFromDate" ValidationGroup="vgAdd" runat="server"
                                                                        ControlToValidate="txtftrBedFromDate" Display="Dynamic" Text="*" SetFocusOnError="true"
                                                                        ErrorMessage=""></asp:RequiredFieldValidator>
                                                                        
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="140px" FooterStyle-Width="140px" ItemStyle-Width="140px"
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
                                                                    <%--                                                                    <asp:TextBox ID="txtftrBedToDate" CssClass="csstxtbox" Width="100px" runat="server"
                                                                        Text=""></asp:TextBox>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender7" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtftrBedToDate" PopupButtonID="IMGDate" />
--%>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="70px"
                                                                FooterStyle-Width="70px" ItemStyle-Width="70px">
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                                        CssClass="csslnkButton" runat="server" CommandName="Update"  />
                                                                    <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                                        CssClass="csslnkButton" runat="server" CommandName="Cancel" CausesValidation="False" />
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                        CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:ImageButton ID="ImgbtnADDNew" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif"
                                                                        CssClass="cssImgButton" runat="server" ValidationGroup="vgAdd" CommandName="AddNew" />
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
                                            <td colspan="6">
                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
