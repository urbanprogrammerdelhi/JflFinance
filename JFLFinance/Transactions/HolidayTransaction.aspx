<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="HolidayTransaction.aspx.cs" Inherits="Transactions_HolidayTransaction"
    Title="<%$ Resources:Resource, AppTitle %>" %>
   <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <%-- <asp:ScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true">--%>
                <Ajax:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>
                        <asp:Panel ID="PanelgvHoliday" BorderWidth="1px" runat="server" Width="1050px" Height="450px"
                            ScrollBars="Auto" CssClass="ScrollBar">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:GridView Width="940px" ID="gvHoliday" CssClass="GridViewStyle" runat="server"
                                            ShowFooter="True" AllowPaging="True" PageSize="15" CellPadding="1" GridLines="None"
                                            AutoGenerateColumns="False" OnPageIndexChanging="GvHoliday_PageIndexChanging"
                                            OnRowCommand="GvHoliday_RowCommand" OnRowDataBound="GvHoliday_RowDataBound" OnRowDeleting="GvHoliday_RowDeleting"
                                            OnDataBound="GvHoliday_DataBound">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                            CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />&nbsp;
                                                        <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                    </ItemTemplate>
                                                    <%--<FooterStyle Width="100px" />
                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                    <ItemStyle Width="100px" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                                    <ItemStyle Width="50px" />
                                                    <FooterStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,HolidayDesc %>">
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlHolidayCode" CssClass="cssDropDown" runat="server"
                                                            OnSelectedIndexChanged="ddlHolidayCode_SelectedIndex">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHolidayCode" CssClass="cssLabel" runat="server" Text='<%# Bind("HolidayDescCode") %>'></asp:Label>
                                                        <asp:HiddenField ID="hfHolidayCode" runat="server" Value='<%# Bind("HolidayCode") %>' />
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle CssClass="cssLabelHeader" />--%>
                                                    
                                                </asp:TemplateField>
                                            <%--  ---------------------------------------SAT048---------------------------------------%>
                                               <asp:TemplateField HeaderText="<%$ Resources:Resource,Client %>">
                                                    <FooterTemplate>
                                                     <telerik:RadComboBox ID="ddlClient" AllowCustomText="true" Filter="Contains" EnableEmbeddedSkins="true"
                                                            CheckBoxes="True" AutoPostBack="true"
                                                            IsCaseSensitive="false" OnSelectedIndexChanged="DdlClientSelectedIndexChanged"
                                                            MarkFirstMatch="true" NoWrap="false"  runat="server">
                                                    </telerik:RadComboBox>
                                                     <asp:RequiredFieldValidator ID="rfvFooterddlClient" runat="server" ControlToValidate="ddlClient" 
                                                        ErrorMessage="" Display="Dynamic"  ValidationGroup="AddNew"  SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                     </FooterTemplate>
                                                    <ItemTemplate>
                                                      <asp:Label ID="lblClientCode" CssClass="cssLabel" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                     <asp:HiddenField ID="hfClientCode" runat="server" Value='<%# Bind("ClientCode") %>' />
                                                    </ItemTemplate>
                                               <%-- <HeaderStyle CssClass="cssLabelHeader" Width="500px" />--%>
                                                   
                                                </asp:TemplateField>
                                            <%-- -------------------------------------Assignment Code --------------------------------%>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Asmt %>">
                                                    <FooterTemplate>
                                                     <telerik:RadComboBox ID="ddlAsmt" AllowCustomText="true" Filter="Contains" EnableEmbeddedSkins="true"
                                                       CheckBoxes="True" AutoPostBack="true" IsCaseSensitive="false" MarkFirstMatch="true" NoWrap="false" runat="server">
                                                    </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="rfvFooterddlAsmt" runat="server" ControlToValidate="ddlAsmt" 
                                                        ErrorMessage="" Display="Dynamic"  ValidationGroup="AddNew"  SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        </FooterTemplate>
                                                    <ItemTemplate>
                                                      <asp:Label ID="lblasmtID" CssClass="cssLabel" runat="server" Text='<%# Bind("AsmtID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                <%-- <HeaderStyle CssClass="cssLabelHeader" Width="500px" />--%>
                                                </asp:TemplateField>
                                            <%--  ---------------------------------------END SAT048-----------------------------------%>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,HolidayDate %>" >
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtHolidayDate" CssClass="csstxtboxReadonly" Width="100px" MaxLength="50"
                                                            ValidationGroup="AddNew" runat="server"></asp:TextBox>
                                                        <asp:HyperLink Style="vertical-align: top;" ID="hlHolidayDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                        <asp:RequiredFieldValidator ID="rfvHolidayDate" runat="server" ControlToValidate="txtHolidayDate"
                                                            ErrorMessage="" ValidationGroup="AddNew" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHolidayDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("HolidayDate")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                  <%-- <HeaderStyle CssClass="cssLabelHeader" Width="150px" />--%>
                                                   <%--  <ItemStyle Width="150px" />
                                                    <FooterStyle Width="150px" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ToDate %>">
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtToDate" CssClass="csstxtboxReadonly" Width="100px" MaxLength="50" ValidationGroup="AddNew" 
                                                            runat="server"></asp:TextBox>
                                                        <asp:HyperLink Style="vertical-align: top;" ID="hlToDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                        <asp:RequiredFieldValidator ID="rfvToDate" runat="server" ControlToValidate="txtToDate"
                                                            ErrorMessage="" ValidationGroup="AddNew" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                    </ItemTemplate>
                                              <%--   <HeaderStyle CssClass="cssLabelHeader" Width="150px" />--%>
                                                      <%-- <FooterStyle Width="150px" />--%>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
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
