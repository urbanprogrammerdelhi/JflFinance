<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="BarredReasonMaster.aspx.cs" Inherits="Masters_BarredReasonMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvReasonType" CssClass="GridViewStyle" runat="server"
                ShowFooter="True" AllowPaging="True" AllowSorting="true" PageSize="6" CellPadding="1"
                GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvReasonType_PageIndexChanging"
                OnRowCommand="gvReasonType_RowCommand" OnRowDataBound="gvReasonType_RowDataBound"
                OnRowDeleting="gvReasonType_RowDeleting" DataKeyNames="ReasonCode" OnDataBound="gvReasonType_DataBound">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                        <FooterTemplate>
                            <asp:ImageButton ID="Imgbtnadd" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNewReasonType" CommandName="AddNew"
                                ImageUrl="../Images/AddNew.gif" />
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                        <ItemTemplate>
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
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,Reason %>">
                        <ItemTemplate>
                            <asp:Label ID="lbReason" runat="server" CssClass="cssLabel" Text='<%# Bind("ReasonCode") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtReason" Width="85%" MaxLength="25" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvReason" runat="server" ControlToValidate="txtReason"
                                ErrorMessage="" ValidationGroup="AddNewReasonType" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                        <ItemStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,Description %>">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text='<%# Bind("ReasonDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtReasonDesc" CssClass="csstxtbox" MaxLength="100" Width="350px"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvReasonDesc" runat="server" ControlToValidate="txtReasonDesc"
                                ErrorMessage="" ValidationGroup="AddNewReasonType" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                        <ItemStyle Width="400px" />
                        <FooterStyle Width="400px" />
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
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
            <asp:HiddenField ID="hfReason" runat="server" />
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
