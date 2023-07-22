<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="QuickCodeMaster.aspx.cs" Inherits="Misc_QuickCodeMaster" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="squareboxgradientcaption" style="height: 20px;">
                <asp:Label ID="lblDivHdr1" runat="server" Text="<%$Resources:Resource,QuickCodeType %>"></asp:Label>
            </div>
            <div>
                <asp:DropDownList ID="ddlSearch" AutoPostBack="true" Width="150px" CssClass="cssDropDown" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" runat="server"></asp:DropDownList><asp:TextBox ID="txtSearch" runat="server" CssClass="csstxtbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ServiceMethod="Search"
                    MinimumPrefixLength="2"
                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                    TargetControlID="txtSearch"
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                </cc1:AutoCompleteExtender>
                 <asp:Button ID="btnSearch" CssClass="cssButton"  runat="server" Text="Search" OnClick="btnSearch_Click" />
                <asp:GridView Width="100%" ID="gvQuickCodeType" CssClass="GridViewStyle" runat="server"
                    ShowFooter="True" AllowPaging="True" AllowSorting="true" PageSize="6" CellPadding="1"
                    GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvQuickCodeType_PageIndexChanging"
                    OnRowCancelingEdit="gvQuickCodeType_RowCancelingEdit" OnRowCommand="gvQuickCodeType_RowCommand"
                    OnRowDataBound="gvQuickCodeType_RowDataBound" OnRowUpdating="gvQuickCodeType_RowUpdating" OnRowDeleting="gvQuickCodeType_RowDeleting"
                    DataKeyNames="QuickCode" OnRowEditing="gvQuickCodeType_RowEditing" OnSorting="gvQuickCodeType_Sorting"
                    OnDataBound="gvQuickCodeType_DataBound">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>"
                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                    ValidationGroup="EditQuickCodeType" />
                                &nbsp;
                                <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>"
                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                    CommandName="Cancel" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="Imgbtnadd" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="AddNewQuickCodeType" CommandName="AddNew"
                                    ImageUrl="../Images/AddNew.gif" />
                                &nbsp;
                                <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" ValidationGroup="EditQuickCodeType" runat="server" CausesValidation="False"
                                    CommandName="Edit" />
                                &nbsp;
                                <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete"/>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                            <ItemStyle Width="50px" />
                            <FooterStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,QuickCode %>">
                            <EditItemTemplate>
                                <asp:Label ID="lblQuickCode" CssClass="cssLabel" runat="server" Text='<%# Bind("QuickCode") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbQuickCode" CssClass="csslnkButton" runat="server" Text='<%# Bind("QuickCode") %>' OnClick="lbQuickCode_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtQuickCode" Width="85%" MaxLength="16" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQuickCode" runat="server" ControlToValidate="txtQuickCode" ErrorMessage="" ValidationGroup="AddNewQuickCodeType" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,QuickCodeDescription %>">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtQuickCodeDesc" CssClass="csstxtbox" MaxLength="100" Width="350px" runat="server" Text='<%# Bind("QuickCodeDesc") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQuickCodeDesc" runat="server" ControlToValidate="txtQuickCodeDesc" ErrorMessage="" ValidationGroup="EditQuickCodeType" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text='<%# Bind("QuickCodeDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtQuickCodeDesc" CssClass="csstxtbox" MaxLength="100" Width="350px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQuickCodeDesc" runat="server" ControlToValidate="txtQuickCodeDesc"
                                    ErrorMessage="" ValidationGroup="AddNewQuickCodeType" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                            <ItemStyle Width="400px" />
                            <FooterStyle Width="400px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrStatus" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Active %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="checkBoxStatus" CssClass="cssCheckBox" Enabled="false" runat="server"
                                    Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Status").ToString())%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="checkBoxStatus" CssClass="cssCheckBox" runat="server"
                                    Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Status").ToString())%>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="checkBoxStatus" CssClass="cssCheckBox" Checked="true" runat="server" />
                            </FooterTemplate>
                            <ItemStyle Width="40px" />
                            <HeaderStyle Width="40px" />
                            <FooterStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,ParentID %>">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlParentQuickCode" Width="150px" CssClass="cssDropDown" runat="server">
                                </asp:DropDownList>
                                <asp:HiddenField runat="server" ID="hiddenFieldParentQuickCode" Value='<%# Bind("ParentQuickCode") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblParentQuickCode" CssClass="cssLabel" runat="server" Text='<%# Bind("ParentQuickCode") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlParentQuickCode" Width="150px" CssClass="cssDropDown" runat="server">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                        CommandArgument="First" CommandName="Page" />
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                        CommandArgument="Prev" CommandName="Page" />
                                    <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                    <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                    <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                        CommandArgument="Next" CommandName="Page" />
                                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                        CommandArgument="Last" CommandName="Page" />
                                </td>
                            </tr>
                        </table>
                    </PagerTemplate>
                </asp:GridView>
            </div>
        <asp:RadioButton ID="rdbAll" GroupName="Map" AutoPostBack="true" Width="100px" runat="server" Text="All" OnCheckedChanged="rdbAll_CheckedChanged" /><asp:RadioButton ID="rdbMapped" GroupName="Map"  AutoPostBack="true" Width="100px" runat="server" Text="Mapped" OnCheckedChanged="rdbMapped_CheckedChanged" /><asp:RadioButton ID="rdbUnMapped" GroupName="Map" AutoPostBack="true" Width="100px" runat="server" Text="UnMapped" OnCheckedChanged="rdbUnMapped_CheckedChanged" />
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
            <asp:HiddenField ID="hfQuickCode" runat="server" />
                <asp:Panel ID="PanelQuickCodeMaster" Visible="false" BorderWidth="0px" runat="server">
                            <div class="squareboxgradientcaption" style="height: 20px;">
                                <asp:Label ID="Label1" runat="server" Text="Quick Code Master"></asp:Label>
                            </div>
                            <div>
                                <asp:GridView Width="100%" ID="gvQuickCodeMaster" CssClass="GridViewStyle" runat="server"
                                    ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnPageIndexChanging="gvQuickCodeMaster_PageIndexChanging"
                                    OnRowCancelingEdit="gvQuickCodeMaster_RowCancelingEdit" OnRowCommand="gvQuickCodeMaster_RowCommand" OnRowDeleting="gvQuickCodeMaster_RowDeleting"
                                    OnRowDataBound="gvQuickCodeMaster_RowDataBound" EmptyDataText="<%$Resources:Resource,NoData %>"
                                    OnRowEditing="gvQuickCodeMaster_RowEditing" OnRowUpdating="gvQuickCodeMaster_RowUpdating"
                                    OnDataBound="gvQuickCodeMaster_DataBound">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="EditItem" />
                                                &nbsp;
                                                <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="AddNewItem" CommandName="AddNew"
                                                    ImageUrl="../Images/AddNew.gif" />
                                                &nbsp;
                                                <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server"
                                                    CausesValidation="False" CommandName="Edit" />
                                                &nbsp;
                                                <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterStyle Width="100px" />
                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                            <ItemStyle Width="50px" />
                                            <FooterStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,QuickCode %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuickCode" CssClass="cssLabel" Width="150px" runat="server" Text='<%# Bind("QuickCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblQuickCode" Width="150px" CssClass="cssLabel" runat="server"></asp:Label>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,ItemCode %>">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblItemCode" CssClass="csstxtbox" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemCode" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtItemCode" CssClass="csstxtbox" Width="85%" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvItemCode" runat="server" ControlToValidate="txtItemCode" ErrorMessage="" ValidationGroup="AddNewItem" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                                            <ItemStyle Width="400px" />
                                            <FooterStyle Width="400px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,ItemDesc %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtItemDesc" MaxLength="100" CssClass="csstxtbox" Width="85%" runat="server" Text='<%# Bind("ItemDesc") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvItemDesc" runat="server" ControlToValidate="txtItemDesc" ErrorMessage="" ValidationGroup="EditItem" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtItemDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtItemDesc" CssClass="csstxtbox" Width="85%" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvItemDesc" runat="server" ControlToValidate="txtItemDesc"
                                                    ErrorMessage="" ValidationGroup="AddNewItem" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                                            <ItemStyle Width="400px" />
                                            <FooterStyle Width="400px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrStatus" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Active %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkBoxStatus" CssClass="cssCheckBox" Enabled="false" runat="server"
                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Status").ToString())%>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="checkBoxStatus" CssClass="cssCheckBox" runat="server"
                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Status").ToString())%>' />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:CheckBox ID="checkBoxStatus" CssClass="cssCheckBox" Checked="true" runat="server" />
                                        </FooterTemplate>
                                        <ItemStyle Width="40px" />
                                        <HeaderStyle Width="40px" />
                                        <FooterStyle Width="40px" />
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,ParentID %>">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlParentItemCode" Width="150px" CssClass="cssDropDown" runat="server">
                                                </asp:DropDownList>
                                                <asp:HiddenField runat="server" ID="hiddenFieldParentItemCode" Value='<%# Bind("ParentItemCode") %>' />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblParentItemCode" runat="server" CssClass="cssLabel" Text='<%# Bind("ParentItemCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlParentItemCode" Width="150px" CssClass="cssDropDown" runat="server">
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemStyle Width="200px" />
                                            <HeaderStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                            CommandArgument="First" CommandName="Page" />
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                            CommandArgument="Prev" CommandName="Page" />
                                        <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                        <asp:DropDownList ID="ddlPagesQuickCodeMaster" CssClass="cssDropDown" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlPagesQuickCodeMaster_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                        <asp:Label ID="lblPageCountQuickCodeMaster" ForeColor="Black" runat="server"></asp:Label>
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                            CommandArgument="Next" CommandName="Page" />
                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                            CommandArgument="Last" CommandName="Page" />
                                    </PagerTemplate>
                                </asp:GridView>
                            </div>
                </asp:Panel>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
 