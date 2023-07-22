<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientAsmtPost.aspx.cs" Inherits="Sales_ClientAsmtPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <div align="right">
                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, Client %>" OnClick="imgBack_Click" />
            </div>
            <Ajax:UpdatePanel runat="server" ID="up2" UpdateMode="Conditional">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right" style="min-width:200px">
                                <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                                    Width="200px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblhdrClient" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtClientCode" runat="server" AutoPostBack="True" CssClass="csstxtbox" Width="200px" OnTextChanged="txtClientCode_TextChanged"></asp:TextBox>
                                <asp:Image ID="ImgClientCode_CCH" runat="server" ImageUrl="~/Images/icosearch.gif" />
                                <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                    Width="280px" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblhdrAsmt" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Asmt %>"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAsmt" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                    Width="200px" OnSelectedIndexChanged="ddlAsmt_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </Ajax:UpdatePanel>
            <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
                <ContentTemplate>
                    <asp:HiddenField runat="server" ID="hfAsmtId" Value="" />
                    <asp:HiddenField runat="server" ID="hfClientCode" Value="" />
                    <asp:GridView Width="100%" ID="gvPost" CssClass="GridViewStyle" runat="server" ShowFooter="true"
                        ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15" CellPadding="1"
                        GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvPost_RowCommand"
                        OnRowEditing="gvPost_RowEditing" OnRowCancelingEdit="gvPost_RowCancelingEdit"
                        OnRowUpdating="gvPost_RowUpdating" OnRowDeleting="gvPost_RowDeleting" OnRowDataBound="gvPost_RowDataBound"
                        OnPageIndexChanging="gvPost_PageIndexChanging">
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    <asp:HiddenField ID="HFPostAutoID" runat="server" Value='<%# Eval("PostAutoId")%>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                                <HeaderStyle Width="10px" />
                                <FooterStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrClientCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text=''></asp:Label>
                                </FooterTemplate>
                                <ItemStyle Width="80px" />
                                <HeaderStyle Width="80px" />
                                <FooterStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrAsmtId" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AsmtId %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text=''></asp:Label>
                                </FooterTemplate>
                                <ItemStyle Width="90px" />
                                <HeaderStyle Width="90px" />
                                <FooterStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrPostCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PostCode %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvPostCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostCode").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblgvPostCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostCode").ToString() %>'></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox Width="70px" ID="txtPostCode" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPostCode" ValidationGroup="vgHrFooter" ControlToValidate="txtPostCode"
                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ItemStyle Width="90px" />
                                <HeaderStyle Width="90px" />
                                <FooterStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrShrtPostCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShortPostDesc %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvShrtPostCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ShtPostDesc").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label Width="70px" ID="lblgvShrtPostCode" CssClass="cssLable" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem,"ShtPostDesc").ToString() %>'></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox Width="70px" ID="txtShrtPostCode" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvShrtPostCode" ValidationGroup="vgHrFooter" ControlToValidate="txtShrtPostCode"
                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ItemStyle Width="90px" />
                                <HeaderStyle Width="90px" />
                                <FooterStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrPostDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PostDesc %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvPostDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostDesc").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="180px" ID="txtPostDesc" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtPostDesc"
                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <div style="vertical-align:top;">
                                    <asp:TextBox Width="160px" ID="txtPostDesc" CssClass="" Style="padding:0px; z-index: 2; position: absolute; border:0px; margin-top:3px; margin-left:3px;" runat="server"></asp:TextBox>
                                    <asp:DropDownList runat="server" ID="ddlPost" CssClass="cssDropDown" AutoPostBack="true" Style="padding:0px; margin:0; z-index: 1; position: absolute;" Width="182px" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrFooter" ControlToValidate="txtPostDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ItemStyle Width="210px" />
                                <HeaderStyle Width="210px" />
                                <FooterStyle Width="210px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrPhone" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Phone %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvPostPhone" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Phone").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="130px" ID="txtPostPhone" CssClass="csstxtbox" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "Phone").ToString()%>'></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtPostDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox Width="130px" ID="txtPostPhone" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ID="rfvPostPhone" ValidationGroup="vgHrFooter" ControlToValidate="txtPostPhone"
                                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </FooterTemplate>
                                <ItemStyle Width="150px" />
                                <HeaderStyle Width="150px" />
                                <FooterStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                <HeaderTemplate>
                                    <asp:Label ID="lblgvhdrPostNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PostPositionNo %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvPostNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostPositionNo").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="90px" ID="txtPostNo" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostPositionNo").ToString()%>'></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtPostDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox Width="90px" ID="txtPostNo" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvPostNo" ValidationGroup="vgHrFooter" ControlToValidate="txtPostNo" runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                <HeaderTemplate>
                                    <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                        ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
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
                                        ValidationGroup="vgHrEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                    <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                        ValidationGroup="vgHrEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                                    &nbsp;
                                    <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                        ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                    <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                        Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                        ValidationGroup="vgHrFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                    <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                        ValidationGroup="vgHrFooter" Text="<%$ Resources:Resource, AddNew %>" CommandName="Add"></asp:LinkButton>
                                    &nbsp;
                                    <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                        ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                    <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                        Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                                </FooterTemplate>
                                <FooterStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                </ContentTemplate>
            </Ajax:UpdatePanel>
    <script language="javascript" type="text/javascript">

        window.onbeforeunload = CallParentWindowFunction;
        function CallParentWindowFunction() {
        
            if (window.opener != null) {
                window.opener.ParentWindowFunction();
            }
        }
    </script>
</asp:Content>
