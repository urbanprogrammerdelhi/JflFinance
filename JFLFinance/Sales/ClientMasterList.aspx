<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientMasterList.aspx.cs" Inherits="Sales_ClientMasterList" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                       <table class="table">
                            <tr>
                                <td align="right" width="250px">
                                    <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td colspan="2" align="left"  width="250px">
                                    <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true" Width="200px" onselectedindexchanged="ddlAreaID_SelectedIndexChanged" ></asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:LinkButton  ID="lbtnAddNew" runat="server" Text="<%$ Resources:Resource, AddNewClient %>"
                                        CssClass="btn btn-primary btn-xs"  OnClick="lbtnAddNew_Click"></asp:LinkButton>
                                     <asp:LinkButton ID="lbtnClientCompanyMapping" runat="server" Text="<%$ Resources:Resource, ClientCompanyMapping %>"
                                        CssClass="btn btn-primary btn-xs" OnClick="lbtnClientCompanyMapping_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:DropDownList AutoPostBack="true" ID="ddlSearchBy" Width="200px" runat="server"
                                        CssClass="cssDropDown" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSearch" Width="200px" CssClass="searchtextbox" runat="server"></asp:TextBox>
                                     <cc1:AutoCompleteExtender ServiceMethod="SearchClientByName"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                        TargetControlID="txtSearch"
                                        ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
                                    </cc1:AutoCompleteExtender>
                                    <asp:HiddenField ID="hfSearchText" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnSearch" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                                        OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnViewAll" Visible="false" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                        OnClick="btnViewAll_Click" />
                                </td>
                                </tr>
                        </table>
                                        <asp:GridView ID="gvClient" CssClass="GridViewStyle table table-bordered" runat="server" Width="100%"
                                            ShowFooter="false" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvClient_RowDataBound"
                                            OnRowDeleting="gvClient_RowDeleting" OnDataBound="gvClient_DataBound" OnPageIndexChanging="gvClient_PageIndexChanging"
                                            OnRowCommand="gvClient_RowCommand">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Width="80px" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                    <HeaderStyle Width="50px" />
                                                    <FooterStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientCode %>">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'
                                                            OnClick="lblgvClientCode_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="200px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ManualClientCode %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvMClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ManualClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="200px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, ClientName %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClientName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtClientName" Columns="50" CssClass="csstxtbox" runat="server"
                                                            MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'
                                                            onKeyUp="javascript:validateString(this)" onBlur="javascript:validateString(this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtClientNameValidator" runat="server" ControlToValidate="txtClientName"
                                                            ErrorMessage="cannot be blank!" ValidationGroup="vg_Edit">*</asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="400px" />
                                                    <HeaderStyle Width="400px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
                                                <div>
                                                <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/Images/firstpage.gif"
                                                    CommandArgument="First" CommandName="Page" /> 
                                                     <asp:ImageButton ID="ImageButton2" runat="server"     ImageUrl="~/Images/prevpage.gif"
                                                    CommandArgument="Prev" CommandName="Page" /> 
                                                   
                                                <asp:Label ID="lblpage" ForeColor="Black" runat="server"   Text="<%$Resources:Resource,Page %>"></asp:Label>
                                              <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                                                </asp:DropDownList>  
                                                <asp:Label ID="lblOf" ForeColor="Black"  runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                                  <asp:Label ID="lblPageCount" ForeColor="Black"  runat="server"></asp:Label> 
                                                <asp:ImageButton ID="ImageButton3" runat="server"   ImageUrl="~/Images/nextpage.gif"
                                                    CommandArgument="Next" CommandName="Page" />  
                                                <asp:ImageButton ID="ImageButton4" runat="server"    ImageUrl="~/Images/lastpage.gif"
                                                    CommandArgument="Last" CommandName="Page" /> 
                                                    </div>
                                            </PagerTemplate>
                                        </asp:GridView>
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
       
</asp:Content>
