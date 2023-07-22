<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HolidayType.aspx.cs" Inherits="Masters_HolidayType" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <%--<asp:ScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true">--%>
                
                <Ajax:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>
                        <asp:Panel ID="PanelgvHolidayType" BorderWidth="1px" runat="server" Width="950px" Height="450px" ScrollBars="Auto" CssClass="ScrollBar">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:GridView Width="940px" ID="gvHolidayType" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                                        AutoGenerateColumns="False" OnPageIndexChanging="gvHolidayType_PageIndexChanging"
                                        OnRowCancelingEdit="gvHolidayType_RowCancelingEdit" OnRowCommand="gvHolidayType_RowCommand"
                                        OnRowDataBound="gvHolidayType_RowDataBound" OnRowDeleting="gvHolidayType_RowDeleting"
                                        OnRowEditing="gvHolidayType_RowEditing" OnRowUpdating="gvHolidayType_RowUpdating" OnDataBound="gvHolidayType_DataBound">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                                <ItemStyle Width="50px" />
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,HolidayTypeCode %>">
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="LinkHolidayTypeCode" CssClass="csslnkButton" runat="server" Text='<%# Bind("HolidayTypeCode") %>' ></asp:LinkButton>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtNewHolidayTypeCode" CssClass="csstxtbox" Width="85%" MaxLength="16"
                                                        runat="server" ValidationGroup="AddNew"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewHolidayTypeCode"
                                                        ErrorMessage="" ValidationGroup="AddNew" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkHolidayTypeCode" CssClass="csslnkButton" runat="server" Text='<%# Bind("HolidayTypeCode") %>' OnClick="LinkHolidayTypeCode_Click" ></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                <ItemStyle Width="200px" />
                                                <FooterStyle Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,HolidayTypeDesc %>">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtHolidayTypeDesc" CssClass="csstxtbox" Width="550px" MaxLength="50"
                                                        runat="server" ValidationGroup="Edit" Text='<%# Bind("HolidayTypeDesc") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHolidayTypeDesc"
                                                        ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtNewHolidayTypeDesc" CssClass="csstxtbox" Width="550px" MaxLength="50"
                                                        ValidationGroup="AddNew" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewHolidayTypeDesc"
                                                        ErrorMessage="" ValidationGroup="AddNew" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHolidayTypeDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("HolidayTypeDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="600px" />
                                                <ItemStyle Width="600px" />
                                                <FooterStyle Width="600px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                        CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
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
                                                    <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                        CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                        CommandName="Edit" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                        runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                </ItemTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif" CommandArgument="First" CommandName="Page" />
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif" CommandArgument="Prev" CommandName="Page" />
                                            <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                            <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPages_SelectedIndexChanged"> </asp:DropDownList>
                                            <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                            <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif" CommandArgument="Next" CommandName="Page" />
                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif" CommandArgument="Last" CommandName="Page" />
                                        </PagerTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblHolidayTypeCodeHeading" runat="server" style="font-size:12;font-weight:bold;" CssClass="cssLabel"></asp:Label>
                                    <asp:HiddenField ID="hfHolidayTypeCode" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                 <td>   
                                    <asp:GridView Width="940px" ID="gvHoliday" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                                        AutoGenerateColumns="False" OnPageIndexChanging="gvHoliday_PageIndexChanging"
                                        OnRowCancelingEdit="gvHoliday_RowCancelingEdit" OnRowCommand="gvHoliday_RowCommand"
                                        OnRowDataBound="gvHoliday_RowDataBound" OnRowDeleting="gvHoliday_RowDeleting"
                                        OnRowEditing="gvHoliday_RowEditing" OnRowUpdating="gvHoliday_RowUpdating" OnDataBound="gvHoliday_DataBound">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                                <ItemStyle Width="50px" />
                                                <FooterStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,HolidayCode %>">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblHolidayCode" CssClass="cssLabel" runat="server" Text='<%# Bind("HolidayCode") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtHolidayCode" CssClass="csstxtbox" Width="85%" ValidationGroup="gvAddNew" MaxLength="16" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvHolidayCode" runat="server" ControlToValidate="txtHolidayCode" ErrorMessage="*" ValidationGroup="gvAddNew" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHolidayCode" CssClass="cssLabel" runat="server" Text='<%# Bind("HolidayCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                <ItemStyle Width="200px" />
                                                <FooterStyle Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource,HolidayDesc %>">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtHolidayDesc" CssClass="csstxtbox" Width="550px" MaxLength="50" runat="server" Text='<%# Bind("HolidayDesc") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvHolidayDesc" runat="server" ControlToValidate="txtHolidayDesc" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="gvEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtHolidayDesc" CssClass="csstxtbox" Width="550px" MaxLength="50" ValidationGroup="gvAddNew" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvHolidayDesc" runat="server" ControlToValidate="txtHolidayDesc" ErrorMessage="*" ValidationGroup="gvAddNew" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHolidayDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("HolidayDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="cssLabelHeader" Width="600px" />
                                                <ItemStyle Width="600px" />
                                                <FooterStyle Width="600px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" ValidationGroup="gvEdit" CommandName="Update" />&nbsp;
                                                    <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="ImgbtnAdd" runat="server" ToolTip="<%$Resources:Resource,Save %>" CssClass="cssImgButton" ValidationGroup="gvAddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />&nbsp;
                                                    <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server" CssClass="cssImgButton" CausesValidation="False" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />&nbsp;
                                                    <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif" CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Delete" />
                                                </ItemTemplate>
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:ImageButton ID="ImgbtnFirst" runat="server" ImageUrl="~/Images/firstpage.gif" CommandArgument="First" CommandName="Page" />
                                            <asp:ImageButton ID="ImgbtnPrev" runat="server" ImageUrl="~/Images/prevpage.gif" CommandArgument="Prev" CommandName="Page" />
                                            <asp:Label ID="lblpage1" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                            <asp:DropDownList ID="ddlPages1" CssClass="cssDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPages1_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:Label ID="lblOf1" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                            <asp:Label ID="lblPageCount1" ForeColor="Black" runat="server"></asp:Label>
                                            <asp:ImageButton ID="ImgbtnNext" runat="server" ImageUrl="~/Images/nextpage.gif" CommandArgument="Next" CommandName="Page" />
                                            <asp:ImageButton ID="ImgbtnLast" runat="server" ImageUrl="~/Images/lastpage.gif" CommandArgument="Last" CommandName="Page" />
                                        </PagerTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
