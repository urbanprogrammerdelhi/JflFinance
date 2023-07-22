<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserEventMapping.aspx.cs"
    Inherits="Transactions_UserEventMapping" MasterPageFile="~/MasterPage/MasterPage.master"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="600px" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="3" cellspacing="0">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblModule" Text="<%$Resources:Resource,SelectUser%>" runat="server"
                                        CssClass="csslblErrMsg"></asp:Label>
                                    <%--<td style="width: 75%;" align="left">--%>
                                    <asp:DropDownList ID="ddlUser" runat="server" CssClass="cssDropDown" Width="150px"
                                        OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="900px" Height="320px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvUserEventMapping" Width="900" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" CellPadding="3"
                                            GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvUserEventMapping_RowCommand"
                                            OnRowEditing="gvUserEventMapping_RowEditing" OnRowUpdating="gvUserEventMapping_RowUpdating"
                                            OnSelectedIndexChanged="gvUserEventMapping_SelectedIndexChanged" OnPageIndexChanging="gvUserEventMapping_PageIndexChanging"
                                            OnRowDataBound="gvUserEventMapping_RowDataBound" OnRowDeleting="gvUserEventMapping_RowDeleting">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-Width="10px" FooterStyle-Width="10px">
                                                    <HeaderTemplate>
                                                        <asp:Label Width="10px" ID="lblgvHdrEventSno" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label Width="10px" ID="lblgvEventSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100" HeaderStyle-Width="100" FooterStyle-Width="50">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrModuleName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Module %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvModuleName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ModuleCode").ToString()%>'> </asp:Label>
                                                        <%--<asp:DropDownList ID="ddlgvModuleName" CssClass="cssDropDown" runat="server"></asp:DropDownList> --%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label Width="100px" ID="lblgvModuleName" CssClass="cssLable" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ModuleCode").ToString()%>'> </asp:Label>
                                                    </EditItemTemplate>
                                                    <%--<FooterTemplate>
                                                        
                                                        <asp:DropDownList Width="100px" ID="ddlgvModuleName" CssClass="cssDropDown" OnSelectedIndexChanged="ddlgvModuleName_SelectedIndexChanged"
                                                            runat="server">
                                                        </asp:DropDownList>
                                                        
                                                    </FooterTemplate>--%>
                                                    <HeaderStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                    <FooterStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEventDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EventDescription %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEventDesc" Width="150px" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EventDescription").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <%--<asp:TextBox ID="txtEventDesc" CssClass="csstxtbox" runat="server" MaxLength="255"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "EventDescription").ToString()%>'></asp:TextBox>--%>
                                                        <asp:DropDownList Width="150px" ID="ddlgvEventName" CssClass="cssDropDown" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hdnEventName" EnableViewState="true" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "EventCode").ToString()%>' />
                                                    </EditItemTemplate>
                                                    <%--<FooterTemplate>
                                                     
                                                        <asp:DropDownList Width="150px" AutoPostBack="true" ID="ddlgvNewEventName" CssClass="cssDropDown"
                                                            runat="server">
                                                        </asp:DropDownList>
                                                     
                                                    </FooterTemplate>--%>
                                                    <HeaderStyle Width="150px" />
                                                    <ItemStyle Width="150px" />
                                                    <FooterStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEventActive" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,IsActive %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%--<asp:CheckBox runat="server" ID="chkIsActive"  />--%>
                                                        <asp:Label ID="lblIsActive" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsActive").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="chkIsActive" CssClass="cssCheckBox" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive")%>' />
                                                    </EditItemTemplate>
                                                    <%--<FooterTemplate>
                                                        
                                                        <asp:CheckBox ID="chkIsActive" CssClass="cssCheckBox" runat="server" />
                                                    </FooterTemplate>--%>
                                                    <FooterStyle Width="60px" />
                                                    <HeaderStyle Width="60px" />
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEventSubscriber" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,Subscribers %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlgvEventSubscriber" CssClass="cssDropDown" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    <div style="overflow: scroll; vertical-align:baseline; height: 75px;" >
                                                        <asp:CheckBoxList ID="chlgvEventSubscriber" runat="server" CssClass="cssCheckListBox">
                                                        </asp:CheckBoxList>
                                                        </div>
                                                    </EditItemTemplate>
                                                    <%--       <FooterTemplate>
                                                        <div style="overflow: scroll; height: 75px">
                                                            <asp:CheckBoxList ID="chlgvNewEventSubscriber" runat="server" CssClass="cssCheckListBox">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </FooterTemplate>--%>
                                                    <FooterStyle Width="150px" />
                                                    <HeaderStyle Width="150px" />
                                                    <ItemStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvHdrEventSubEmailID" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,SubscribersEmailID %>"> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvEventSubEmailID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SubEmailID").ToString()%>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEventSubEmailID" CssClass="csstxtbox" runat="server" MaxLength="255"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "SubEmailID").ToString()%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <%-- <FooterTemplate>
                                                        <asp:TextBox ID="txtNewSubEmailID" Width="300" CssClass="csstxtbox" runat="server"
                                                            MaxLength="255"></asp:TextBox>
                                                    </FooterTemplate>--%>
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
                                                            ToolTip="<%$ Resources:Resource, Cancel %>" OnClick="lnkBtnCancel_Click" ImageUrl="../Images/Cancel.gif" />
                                                    </EditItemTemplate>
                                                    <%--<FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add New"
                                                            ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" OnClick="btnReset_Click" />
                                                    </FooterTemplate>--%>
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
                                <td>
                                    <table border="1" cellpadding="3" cellspacing="1" style="width: 900px; background-color:#B7CEEC" >
                                        <tr>
                                            <td style="width: 30px">
                                            </td>
                                            <td style="width: 100px">
                                                <asp:DropDownList Width="100px" ID="ddlgvModuleName" CssClass="cssDropDown" runat="server"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlgvModuleName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:DropDownList Width="150px" AutoPostBack="true" ID="ddlgvNewEventName" CssClass="cssDropDown"
                                                    runat="server">
                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 60px">
                                                <asp:CheckBox ID="chkIsActive" CssClass="cssCheckBox" runat="server" />
                                            </td>
                                            <td style="width: 150px" align="left">
                                                <div style="overflow: scroll; vertical-align:baseline; height: 75px;" >
                                                    <asp:CheckBoxList ID="chlgvNewEventSubscriber" runat="server" CssClass="cssCheckListBox" TextAlign="Right">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </td>
                                            <td style="width: 300px">
                                                <asp:TextBox ID="txtNewSubEmailID" Width="300" CssClass="csstxtbox" runat="server"
                                                    MaxLength="255"></asp:TextBox>
                                            </td>
                                            <td style="width: 30px">
                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add New"
                                                    ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" 
                                                    ImageUrl="../Images/AddNew.gif" onclick="ImgbtnAdd_Click" />
                                            </td>
                                            <td style="width: 30px">
                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" OnClick="btnReset_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
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
