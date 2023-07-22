<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventMaster.aspx.cs" Inherits="Masters_EventMaster"
    MasterPageFile="~/MasterPage/MasterPage.master" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="3" cellspacing="0">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblModule" Text="<%$Resources:Resource,SelectModule%>" runat="server" CssClass="csslabel"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlModule" runat="server" CssClass="cssDropDown" Width="300px" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" AutoPostBack="true" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px" ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvEventMaster" Width="900px" CssClass="GridViewStyle" runat="server" 
                                            ShowFooter="true" ShowHeader="true" AllowPaging="true" CellPadding="3" PageSize="10"
                                            GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvEventMaster_RowCommand"
                                            OnRowEditing="gvEventMaster_RowEditing" OnRowCancelingEdit="gvEventMaster_RowCancelingEdit" OnRowUpdating="gvEventMaster_RowUpdating"
                                            OnSelectedIndexChanged="gvEventMaster_SelectedIndexChanged" OnPageIndexChanging="gvEventMaster_PageIndexChanging" OnDataBound="gvEventMaster_DataBound"
                                            OnRowDataBound="gvEventMaster_RowDataBound" OnRowDeleting="gvEventMaster_RowDeleting">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-Width="10px" FooterStyle-Width="10px">
                                                    <HeaderTemplate>
                                                        <asp:Label Width="10px" ID="lblgvHdrEventSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label Width="10px" ID="lblgvEventSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="110" HeaderStyle-Width="110" FooterStyle-Width="110">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEventCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EventCode %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEventCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EventCode").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvEventCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EventCode").ToString()%>'> </asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtEventCode" Width="100" CssClass="csstxtbox" runat="server" MaxLength="50"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="310" HeaderStyle-Width="310" FooterStyle-Width="310">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEventDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EventDescription %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEventDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EventDescription").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEventDesc" CssClass="csstxtbox" runat="server" MaxLength="255" Text='<%# DataBinder.Eval(Container.DataItem, "EventDescription").ToString()%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtNewEventDesc" Width="300" CssClass="csstxtbox" runat="server" MaxLength="255" ></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100" HeaderStyle-Width="100" FooterStyle-Width="100">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEventActive" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,IsActive %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkIsActive" Enabled="false" CssClass="cssCheckBox" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive")%>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="chkIsActive" CssClass="cssCheckBox" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive")%>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:CheckBox ID="chkIsActive" CssClass="cssCheckBox" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                            ValidationGroup="vg_Edit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add New"
                                                            ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                     <FooterStyle Width="60px" />
                                                    <HeaderStyle Width="60px" />
                                                    <ItemStyle Width="60px" />
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
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
