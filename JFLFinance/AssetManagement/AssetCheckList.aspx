<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetCheckList.aspx.cs" Inherits="AssetManagement_AssetCheckList" EnableViewState="true" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklist" Font-Bold="True" ForeColor="Red" Height="220px" runat="server" GroupingText="Asset CheckList">
                <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetCategory" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCategory %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlAssetCategory" runat="server" CssClass="csstxtbox" Width="150px" Enabled="false"></asp:DropDownList>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetSubCategory" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetSubCategory %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlAssetSubCategory" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"></asp:DropDownList>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetManufacture" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ManufacturerName %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlAssetManufacture" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"></asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: right;" nowrap="nowrap">
                            <asp:Label ID="lblAssetCode" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCode %>"></asp:Label>
                        </td>
                        <td style="text-align: left;" nowrap="nowrap">
                            <asp:TextBox ID="txtAssetCode" CssClass="csstxtbox"
                                runat="server" Enabled="false"></asp:TextBox>

                        </td>

                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetName %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtAssetName" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblDescription" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Description %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtDescription" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblModelNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ModelNo %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtModelNo" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblModelName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ModelName %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtModelName" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>

                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SerialNo %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtSerialNo" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblServicetype" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SelectServiceType %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlServicetype" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlServicetype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblChecklistName" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ChecklistName %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtCheccklistname" CssClass="csstxtbox" MaxLength="100" ValidationGroup="AssetChecklist"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtCheccklistname" ValidationGroup="AssetChecklist" ControlToValidate="txtCheccklistname" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hfAssetId" runat="server" Value="0" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div style="margin-left: 500px; margin-top: -30px;">
                <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:Resource,Submit %>" ValidationGroup="AssetChecklist" CausesValidation="true" CssClass="cssButton" OnClick="btnSubmit_Click" Visible="true" />
              
                   <asp:Button ID="btnCopy" runat="server" Text="Copy Checklist of Other Asset" CssClass="cssButton" OnClick="btnCopy_Click" Visible="true" />
                  <asp:Button ID="btnack" runat="server" Text="<%$ Resources:Resource,Cancel %>" CssClass="cssButton" OnClick="btnack_Click" Visible="true" />
            </div>
            <asp:Label ID="lblChecklistNameError" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>

            <div id="divCopyChecklist" runat="server" visible="false">
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl6" runat="server" Text="To Asset Code" CssClass="cssLabel" style="color:green;font-size:small" Width="150px"></asp:Label>
                        </td>
                        
                         <td>
                            <asp:Label ID="Label2" runat="server" Text="From Asset Service Type" CssClass="cssLabel" style="color:green;font-size:small"></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label1" runat="server" Text="From Asset Code" CssClass="cssLabel" style="color:green;font-size:small"></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label3" runat="server" Text="From Asset Checklist Name" CssClass="cssLabel" style="color:green;font-size:small"></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label4" runat="server" Text="From Asset Sub Checklist Name" CssClass="cssLabel" style="color:green;font-size:small"></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label5" runat="server" Text="From Asset Sub Checklist Item" CssClass="cssLabel" style="color:green;font-size:small"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="txtToAssetCode" runat="server" CssClass="cssLabel" Width="150px" style="color:black;font-size:small" Font-Bold="true"></asp:Label>
                        </td>
                        
                         <td>
                           <asp:DropDownList ID="ddlFromAssetService" runat="server" CssClass="cssDropDown" Width="180px" style="color:black;font-size:small" Font-Bold="true" OnSelectedIndexChanged="ddlFromAssetService_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                          <td>
                            <asp:DropDownList ID="ddlFromAssetCode" runat="server" CssClass="cssDropDown" Width="220px" style="color:black;font-size:small" Font-Bold="true" OnSelectedIndexChanged="ddlFromAssetCode_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
                        </td>
                         <td>
                            <asp:DropDownList ID="ddlFromAssetChecklist" runat="server" CssClass="cssDropDown" Width="200px" style="color:black;font-size:small" Font-Bold="true" OnSelectedIndexChanged="ddlFromAssetChecklist_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
                        </td>
                         <td>
                            <asp:DropDownList ID="ddlFromSubChecklist" runat="server" CssClass="cssDropDown" Width="220px" style="color:black;font-size:small" Font-Bold="true" OnSelectedIndexChanged="ddlFromSubChecklist_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
                        </td>
                         <td>
                            <asp:DropDownList ID="ddlFromAssetItems" runat="server" CssClass="cssDropDown" Width="220px" style="color:black;font-size:small" Font-Bold="true"></asp:DropDownList>
                        </td>
                        
                    </tr>
                   
                </table>
                                <br />
                 <asp:Label ID="lblNodata" runat="server" Visible="false" Text="Unable to copy as no Checklist available for this asset !!" style="color:red;font-size:medium"></asp:Label>
               
                       <asp:Button ID="btncopyChecklist" runat="server" CssClass="cssButton" Text="Copy Checklist" OnClick="btncopyChecklist_Click" ToolTip="Copy Selected Asset Checklist" style="margin-left:300px" Width="200px" />
                 <asp:Button ID="btnbackcopy" runat="server" Text="<%$ Resources:Resource,Back %>" CssClass="cssButton" OnClick="btnbackcopy_Click" Visible="true" />
              
                
                  

            </div>

            <div id="MainItem" runat="server">
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklistDetail" Font-Bold="True" Height="420px" runat="server" Style="margin-top: 40px">
                <asp:GridView Width="14%" ID="gvAssetChecklistName" CssClass="GridViewStyle" runat="server" AllowPaging="True" PageSize="6" CellPadding="1" GridLines="None" OnPageIndexChanging="gvAssetChecklistName_PageIndexChanging" OnRowDataBound="gvAssetChecklistName_RowDataBound"
                    AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#DBDDF8" />
                    <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" />
                    <PagerStyle BackColor="#2E6293" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="10px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="10px" ItemStyle-Width="10px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ChecklistName %>" HeaderStyle-ForeColor="White">

                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetCheckListAutoId" runat="server" Value='<%# Bind("AssetCheckListAutoId") %>' />
                                <asp:LinkButton ID="lbChecklistName" CssClass="cssLabel" runat="server" Text='<%# Bind("CheckListName") %>' OnClick="lbChecklistName_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="30px" />
                            <ItemStyle Width="30px" />
                            <FooterStyle Width="30px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </asp:Panel>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklistNameDetail" Font-Bold="True" ForeColor="Red" Height="300px" runat="server" Style="margin-left: 250px; margin-top: -420px" Visible="false">
                <asp:HiddenField ID="hfid" runat="server" />
                <asp:GridView Width="70%" ID="gvAssetChecklistNameDetail" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAssetChecklistNameDetail_RowDataBound" OnRowCommand="gvAssetChecklistNameDetail_RowCommand"
                    OnRowDeleting="gvAssetChecklistNameDetail_RowDeleting" OnRowEditing="gvAssetChecklistNameDetail_RowEditing" OnPageIndexChanging="gvAssetChecklistNameDetail_PageIndexChanging"
                    OnRowUpdating="gvAssetChecklistNameDetail_RowUpdating" OnRowCancelingEdit="gvAssetChecklistNameDetail_RowCancelingEdit">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#DBDDF8" />
                    <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" />
                    <PagerStyle BackColor="#2E6293" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName%>" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                    ValidationGroup="EditChecklistNameDetail" />

                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                    CommandName="Cancel" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="NewChecklistNameDetail" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />

                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                    CommandName="Edit" />
                                &nbsp;
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                            </ItemTemplate>
                            <FooterStyle Width="80px" />
                            <HeaderStyle Width="80px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ChecklistName %>" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfAssetCheckListDetailAutoId" runat="server" Value='<%# Bind("AssetCheckListDetailAutoId") %>' />
                                <asp:HiddenField ID="hfAssetCheckListNameAutoId" runat="server" Value='<%# Bind("AssetCheckListAutoId") %>' />
                                <asp:Label ID="lblChecklistName" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("CheckListName") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                               
                                <asp:HiddenField ID="hfAssetCheckListNameAutoId" runat="server" Value='<%# Bind("AssetCheckListAutoId") %>' />

                                <asp:Label ID="lblChecklistName" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("CheckListName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblChecklistName" CssClass="cssLabel" runat="server"></asp:Label>
                            </FooterTemplate>

                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sub Check List Name" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <%--  <asp:HiddenField ID="hfAssetSubCategoryAutoId" runat="server" Value='<%# Bind("AssetSubCategoryAutoId") %>' />--%>
                                <asp:TextBox ID="txtChecklistNameDetail" MaxLength="100" ValidationGroup="EditChecklistNameDetail" CssClass="csstxtbox" runat="server" Text='<%# Bind("Items") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtAssetSubCategory" runat="server" ControlToValidate="txtChecklistNameDetail"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditChecklistNameDetail"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <%--  <asp:HiddenField ID="hfAssetSubCategoryAutoIdnew" runat="server" Value="0" />--%>

                                <asp:TextBox ID="txtChecklistNameDetail" MaxLength="100" ValidationGroup="NewChecklistNameDetail" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvnewtxtAsseSubtCategory" runat="server" ControlToValidate="txtChecklistNameDetail"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewChecklistNameDetail"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%--<asp:HiddenField ID="hfAssetSubCategoryAutoId" runat="server" Value='<%# Bind("AssetSubCategoryAutoId") %>' />--%>
                                 <asp:HiddenField ID="hfAssetCheckListDetailAutoId" runat="server" Value='<%# Bind("AssetCheckListDetailAutoId") %>' />
                                <asp:LinkButton ID="lblChecklistNameDetail" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("Items") %>' OnClick="lblChecklistNameDetail_Click"></asp:LinkButton>

                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
                <br />
               
                <asp:Label ID="lblChecklistDetail" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </asp:Panel>
                </div>

        <%--    --------------------------Asset Sub Checklist Grid-------------------------%>

            <div id="divSubitem" runat="server" visible="false">
                 <asp:Panel ScrollBars="Auto" ID="Panel1" Font-Bold="True" ForeColor="Red" Height="320px" runat="server" Style="margin-left: 250px; margin-top: -70px" Visible="true">
         <%-- <asp:Label ID="lbl" Text="HELLO" Font-Size="X-Large" runat="server"></asp:Label>--%>
                      <asp:GridView Width="70%" ID="gvChecklistdetail2" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None" Visible="true"
                    AutoGenerateColumns="False" OnRowDataBound="gvChecklistdetail_RowDataBound" OnRowCommand="gvChecklistdetail_RowCommand"
                    OnRowDeleting="gvChecklistdetail_RowDeleting" OnRowEditing="gvChecklistdetail_RowEditing" OnPageIndexChanging="gvChecklistdetail_PageIndexChanging"
                    OnRowUpdating="gvChecklistdetail_RowUpdating" OnRowCancelingEdit="gvChecklistdetail_RowCancelingEdit">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#DBDDF8" />
                    <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" />
                    <PagerStyle BackColor="#2E6293" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName%>" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                    ValidationGroup="EditSubChecklistNameDetail" />

                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                    CommandName="Cancel" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="NewSubChecklistNameDetail" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />

                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" ValidationGroup="SubEdit1" runat="server" CausesValidation="False"
                                    CommandName="Edit" />
                                &nbsp;
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="70px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sub Check List Name" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfAssetSubCheckListDetailAutoId" runat="server" Value='<%# Bind("AssetSubChecklistDetailAutoID") %>' />                        
                                <asp:Label ID="lblsubChecklistName" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("Items") %>' ></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                  <asp:HiddenField ID="hfAssetSubCheckListDetailAutoId" runat="server" Value='<%# Bind("AssetSubChecklistDetailAutoID") %>' />                        
                                <asp:Label ID="lblsubChecklistName" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("Items") %>' ></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblsubChecklistName" CssClass="cssLabel" runat="server"></asp:Label>
                            </FooterTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sub Check List Items Name" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtsubChecklistNameDetail" MaxLength="100" ValidationGroup="EditSubChecklistNameDetail" CssClass="csstxtbox" runat="server" Text='<%# Bind("SubItems") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtsubChecklistNameDetail" runat="server" ControlToValidate="txtsubChecklistNameDetail"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditSubChecklistNameDetail"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                     <asp:TextBox ID="txtsubChecklistNameDetail" MaxLength="100" ValidationGroup="NewSubChecklistNameDetail" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtsubChecklistNameDetail" runat="server" ControlToValidate="txtsubChecklistNameDetail"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewSubChecklistNameDetail"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                             
                                <asp:Label ID="lblsubChecklistNameDetail" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("SubItems") %>'></asp:Label>

                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type Of Value" HeaderStyle-ForeColor="White">
                            <EditItemTemplate>
                                 
                                   <asp:HiddenField ID="hfValueType2" runat="server" Value='<%# Bind("ValueType") %>' />              
                                   <asp:DropDownList ID="ddlValueType2" Width="100px" CssClass="cssDropDown" runat="server" OnSelectedIndexChanged="ddlValueType_SelectedIndexChanged1" AutoPostBack="true" >
                                    <asp:ListItem Text="Qualitative" Value="Qualitative"></asp:ListItem>
                                    <asp:ListItem Text="Quantitative" Value="Quantitative"></asp:ListItem>
                                    <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                </asp:DropDownList>

                            </EditItemTemplate>
                            <FooterTemplate>                               
                                <asp:DropDownList ID="ddlValueType" Width="100px" CssClass="cssDropDown" runat="server" OnSelectedIndexChanged="ddlValueType_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Qualitative" Value="Qualitative"></asp:ListItem>
                                    <asp:ListItem Text="Quantitative" Value="Quantitative"></asp:ListItem>
                                    <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                </asp:DropDownList>

                            </FooterTemplate>
                            <ItemTemplate>                                               
                                <asp:Label ID="lblValuetype" runat="server" CssClass="cssLabel"  Text='<%# Bind("ValueType") %>'></asp:Label>                                               
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantitative Value" HeaderStyle-ForeColor="White" Visible="true">
                            <EditItemTemplate>
                                    <asp:HiddenField ID="hfQuantitativeValueType" runat="server" Value='<%# Bind("SubValueType") %>' />
                                       <asp:DropDownList ID="ddlQuantitativeValueType" Width="190px" CssClass="cssDropDown" runat="server" OnSelectedIndexChanged="ddlQuantitativeValueType_SelectedIndexChanged1" AutoPostBack="true">
                               
                                    <asp:ListItem Text="Text" Value="Text"></asp:ListItem>
                                       <asp:ListItem Text="Range" Value="Range"></asp:ListItem>
                                </asp:DropDownList>
                                    <div id="divrange" runat="server" visible="true">
                              <asp:Label ID="lblmin" runat="server" CssClass="cssLabel" Text="Min : " ForeColor="Black" Visible="false"></asp:Label> <asp:TextBox ID="txtmin" CssClass="csstxtbox" ValidationGroup="EditSubChecklistNameDetail" runat="server" Width="50px" Visible="false" MaxLength="15" Text='<%# Bind("MinRange") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="rfvtxtmin" runat="server" ControlToValidate="txtmin"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditSubChecklistNameDetail" Enabled="false"></asp:RequiredFieldValidator>
                                      <asp:Label ID="lblmax" runat="server" CssClass="cssLabel" Text="Max : " ForeColor="Black" Visible="false"></asp:Label> <asp:TextBox ID="txtmax" CssClass="csstxtbox" ValidationGroup="EditSubChecklistNameDetail" runat="server" Width="50px" Visible="false" MaxLength="15" Text='<%# Bind("MaxRange") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtmax" runat="server" ControlToValidate="txtmax"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditSubChecklistNameDetail" Enabled="false"></asp:RequiredFieldValidator>
                                       </div>
                            </EditItemTemplate>
                            <FooterTemplate>
                               
                                <asp:DropDownList ID="ddlQuantitativeValueType" Width="190px" CssClass="cssDropDown" runat="server" OnSelectedIndexChanged="ddlQuantitativeValueType_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                                      <asp:ListItem Text="Text" Value="Text"></asp:ListItem>
                                       <asp:ListItem Text="Range" Value="Range"></asp:ListItem>
                                </asp:DropDownList>                                
                              
                                <div id="divrange" runat="server" visible="true">
                              <asp:Label ID="lblmin" runat="server" CssClass="cssLabel" Text="Min : " ForeColor="Black" Visible="false"></asp:Label> <asp:TextBox ID="txtmin" CssClass="csstxtbox" ValidationGroup="NewSubChecklistNameDetail" runat="server" Width="50px" Visible="false" MaxLength="15"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="rfvtxtmin" runat="server" ControlToValidate="txtmin"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewSubChecklistNameDetail"></asp:RequiredFieldValidator>
                                      <asp:Label ID="lblmax" runat="server" CssClass="cssLabel" Text="Max : " ForeColor="Black" Visible="false"></asp:Label> <asp:TextBox ID="txtmax" CssClass="csstxtbox" ValidationGroup="NewSubChecklistNameDetail" runat="server" Width="50px" Visible="false" MaxLength="15"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtmax" runat="server" ControlToValidate="txtmax"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewSubChecklistNameDetail"></asp:RequiredFieldValidator>
                                       </div>    </FooterTemplate>
                            <ItemTemplate>
                                         <asp:Label ID="lblQuantitativeValuetype" runat="server" CssClass="cssLabel" Text='<%# Bind("SubValueType") %>'></asp:Label>
                                          <div id="divrange" runat="server" visible="true">
                                              <asp:Label ID="lblmin1" runat="server" CssClass="cssLabel" Text="Min : " ForeColor="#2F6393" Visible="false" Font-Bold="true"></asp:Label> <asp:Label ID="txtmin1"  CssClass="cssLabel" runat="server" Width="50px" Visible="false" MaxLength="15" Text='<%# Bind("MinRange") %>' ForeColor="Black" Font-Bold="true"></asp:Label>
                                               
                                              <asp:Label ID="lblmax1" runat="server" CssClass="cssLabel" Text="Max : " ForeColor="#2F6393" Visible="false" Font-Bold="true"></asp:Label> <asp:Label ID="txtmax1"  CssClass="cssLabel" runat="server" Width="50px" Visible="false" MaxLength="15" Text='<%# Bind("MaxRange") %>'  ForeColor="Black" Font-Bold="true"></asp:Label>
                     
                                               </div> 
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>                         
                    </Columns>
                </asp:GridView>
                 <asp:Label ID="lblmsg1" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                  </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   </asp:Content>

