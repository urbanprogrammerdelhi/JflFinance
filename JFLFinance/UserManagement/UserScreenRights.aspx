<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserScreenRights.aspx.cs" Inherits="UserManagement_UserScreenRights"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/jscript">
        var oldgridSelectedColor;
        var newgridSelectedColor = '#7ca8d3';

        function CheckUncheckAllLoc(ObjCheckBox, ObjNameToCheck) {
            var frm = document.aspnetForm;
            var ChkState = ObjCheckBox.checked;

            var objCell = ObjCheckBox.parentElement.parentElement;
            var objRow = objCell.parentElement;
            var objTable = objRow.parentElement.parentElement;

            var mycolor;
            if (ObjCheckBox.checked == true) {
                oldgridSelectedColor = objCell.style.backgroundColor;
                mycolor = newgridSelectedColor;
            }
            else {
                mycolor = oldgridSelectedColor;
            }

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(ObjNameToCheck) != -1 && e.disabled == false) {
                    e.checked = ChkState;
                    e.parentElement.parentElement.style.backgroundColor = mycolor;
                    CheckUncheckCB(e);
                }
            }
        }
        function CheckUncheckAll(ObjCheckBox, ObjNameToCheck) {
            var frm = document.aspnetForm;
            if (frm == null)
            {
                frm = document.getElementById('aspnetForm');
            }
            var ChkState = ObjCheckBox.checked;

            var objCell = ObjCheckBox.parentElement.parentElement;
            var objRow = objCell.parentElement;
            var objTable = objRow.parentElement.parentElement;

            var mycolor;
            if (ObjCheckBox.checked == true) {
                oldgridSelectedColor = objCell.style.backgroundColor;
                mycolor = newgridSelectedColor;
            }
            else {
                mycolor = oldgridSelectedColor;
            }
            CheckUncheckCB(ObjCheckBox);
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                eObjTable = e.parentElement.parentElement.parentElement.parentElement.parentElement
                if (e.type == 'checkbox' && e.name.indexOf(ObjNameToCheck) != -1 && objTable.id == eObjTable.id && e.disabled == false) {
                    e.checked = ChkState;
                    e.parentElement.parentElement.style.backgroundColor = mycolor;
                    CheckUncheckCB(e);
                }
            }
        }
        function CheckUncheckCB(ObjCheckBox) {
            var mycolor;
            if (ObjCheckBox.checked == false) {
                mycolor = oldgridSelectedColor;
                ObjCheckBox.parentElement.parentElement.style.backgroundColor = mycolor;
                //temp code start

                if (ObjCheckBox.name.indexOf('cbIsRead') != -1) {
                    var ChkState = ObjCheckBox.checked;
                    ObjNameToCheck = ObjCheckBox.id.replace("cbIsRead", "cbIsWrite");
                    ObjToCheck = document.getElementById(ObjNameToCheck);
                    ObjToCheck.checked = ChkState;
                    ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;

                    ObjNameToCheck = ObjCheckBox.id.replace("cbIsRead", "cbIsDelete");
                    ObjToCheck = document.getElementById(ObjNameToCheck);
                    ObjToCheck.checked = ChkState;
                    ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;

                    ObjNameToCheck = ObjCheckBox.id.replace("cbIsRead", "cbIsModify");
                    ObjToCheck = document.getElementById(ObjNameToCheck);
                    ObjToCheck.checked = ChkState;
                    ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;

                    ObjNameToCheck = ObjCheckBox.id.replace("cbIsRead", "cbIsAuthorization");
                    ObjToCheck = document.getElementById(ObjNameToCheck);
                    ObjToCheck.checked = ChkState;
                    ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;

                }
                if (ObjCheckBox.name.indexOf('cbAllScreenRight_Read') != -1) {

                    var ChkState = ObjCheckBox.checked;
                    ObjNameToCheck = ObjCheckBox.id.replace("cbAllScreenRight_Read", "cbAllScreenRight_Write");
                    ObjToCheck = document.getElementById(ObjNameToCheck);
                    ObjToCheck.checked = ChkState;
                    ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;

                    ObjNameToCheck = ObjCheckBox.id.replace("cbAllScreenRight_Read", "cbAllScreenRight_Delete");
                    ObjToCheck = document.getElementById(ObjNameToCheck);
                    ObjToCheck.checked = ChkState;
                    ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;

                    ObjNameToCheck = ObjCheckBox.id.replace("cbAllScreenRight_Read", "cbAllScreenRight_Modify");
                    ObjToCheck = document.getElementById(ObjNameToCheck);
                    ObjToCheck.checked = ChkState;
                    ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;

                    ObjNameToCheck = ObjCheckBox.id.replace("cbAllScreenRight_Read", "cbAllScreenRight_Authorization");
                    ObjToCheck = document.getElementById(ObjNameToCheck);
                    ObjToCheck.checked = ChkState;
                    ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;

                }

                //tempcode end
            }
            else {
                oldgridSelectedColor = ObjCheckBox.parentElement.parentElement.style.backgroundColor;
                mycolor = newgridSelectedColor;
                ObjCheckBox.parentElement.parentElement.style.backgroundColor = mycolor;

                    var ObjNameToCheck = "";
                    var ChkState = ObjCheckBox.checked;
                    //temprary code start
                    if (ObjCheckBox.name.indexOf('cbIsWrite') != -1) {
                        ObjNameToCheck = ObjCheckBox.id.replace("cbIsWrite", "cbIsRead");
                        ObjToCheck = document.getElementById(ObjNameToCheck);
                        ObjToCheck.checked = true;
                        ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;
                    }
                    else if (ObjCheckBox.name.indexOf('cbIsDelete') != -1) {
                        ObjNameToCheck = ObjCheckBox.id.replace("cbIsDelete", "cbIsRead");
                        ObjToCheck = document.getElementById(ObjNameToCheck);
                        ObjToCheck.checked = true;
                        ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;
                    }
                    else if (ObjCheckBox.name.indexOf('cbIsModify') != -1) {
                        ObjNameToCheck = ObjCheckBox.id.replace("cbIsModify", "cbIsRead");
                        ObjToCheck = document.getElementById(ObjNameToCheck);
                        ObjToCheck.checked = true;
                        ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;
                    }

                    else if (ObjCheckBox.name.indexOf('cbIsAuthorization') != -1) {
                        ObjNameToCheck = ObjCheckBox.id.replace("cbIsAuthorization", "cbIsRead");
                        ObjToCheck = document.getElementById(ObjNameToCheck);
                        ObjToCheck.checked = true;
                        ObjToCheck.parentElement.parentElement.style.backgroundColor = mycolor;
                    }

                //temp close

            }
        }
    </script>
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" style="margin: 0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="4"></td>
                    <td align="right">
                        <asp:Button ID="btnBack" runat="server" ToolTip="<%$ Resources:Resource, UserLocationRights %>" Text="<%$ Resources:Resource, BtnBack %>" CssClass="cssButton" OnClick="btnBack_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lblHdrUserGroupCode" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, UserGroupCode %>"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblUserGroupCode" CssClass="cssLabelHeader" runat="server"></asp:Label>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblHdrUserGroupName" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, UserGroupName %>"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblUserGroupName" CssClass="cssLabelHeader" runat="server"></asp:Label>
                    </td>
                    <td></td>
                </tr>
            </table>
                        <div id="divDetails" class="section">
                            <asp:GridView Width="100%" ID="gvUserLocRights" CssClass="GridViewStyle" runat="server"
                                ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                                AutoGenerateColumns="False" OnRowCommand="gvUserLocRights_RowCommand" OnRowDataBound="gvUserLocRights_RowDataBound"
                                OnRowEditing="gvUserLocRights_RowEditing" OnRowCancelingEdit="gvUserLocRights_RowCanceling">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvMenuHead" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuHead %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfgvUserLocRights_MenuHeadAutoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "MenuHeadAutoId").ToString() %>' />
                                            <asp:HiddenField ID="hfgvUserLocRights_MenuHeadCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString() %>'/>
                                            <asp:Label ID="lblgvUserLocRights_MenuHeadName" CssClass="cssLabelHeader" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>
                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Read" Visible="false" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, ReadAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsRead');" />
                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Write" Visible="false" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, WriteAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsWrite');" />
                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Modift" Visible="false" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, EditAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsModify');" />
                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Delete" Visible="false" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, DeleteAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsDelete');" />
                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Authorization" Visible="false" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, AuthorizationAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsAuthorization');" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="ViewChild_Button" runat="server" Text="+" CommandName="Edit" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Button ID="CancelChild_Button" runat="server" Text="-" CommandName="Cancel" />
                                            <asp:GridView Width="100%" ID="gvUserScreenRights" CssClass="GridViewStyle" runat="server"
                                                ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                                                AutoGenerateColumns="False" OnRowCommand="gvUserScreenRights_RowCommand">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrMenuHead" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuHead %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HfgvUserScreenRightsMenuHeadAutoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "MenuHeadAutoId").ToString()%>' />
                                                            <asp:HiddenField ID="HfgvUserScreenRightsMenuHeadCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>' />
                                                            <asp:Label ID="lblgvUserScreenRightsMenuHeadName" CssClass="cssLabelHeader" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadName").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrMenuNodeName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuNodeName %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label Visible="false" ID="lblMenuNodeAutoID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeAutoID").ToString()%>'></asp:Label>
                                                            <asp:Label Visible="false" ID="lblMenuNodeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeCode").ToString()%>'></asp:Label>
                                                            <asp:Label ID="lblMenuNodeName" CssClass="cssLabelHeader" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeName").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Button ID="btnAdd" CssClass="cssSaveButton" runat="server" ToolTip="<%$ Resources:Resource, Save %>" Text="<%$ Resources:Resource, Save %>" CommandName="Save" />
                                                            <asp:ImageButton Visible="false" ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Save" ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllScreenRight_Read" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, ReadAccess%>" onclick="javascript:CheckUncheckAll(this,'cbIsRead');" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbIsRead" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsReadDisabled").ToString())%>' Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsRead").ToString())%>' onclick="javascript:CheckUncheckCB(this);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllScreenRight_Write" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, WriteAccess%>"
                                                                onclick="javascript:CheckUncheckAll(this,'cbIsWrite');" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbIsWrite" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsWriteDisabled").ToString())%>'
                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsWrite").ToString())%>' onclick="javascript:CheckUncheckCB(this);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllScreenRight_Modify" runat="server" CssClass="cssCheckBox"
                                                                Text="<% $ Resources:Resource, EditAccess%>" onclick="javascript:CheckUncheckAll(this,'cbIsModify');" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbIsModify" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsModifyDisabled").ToString())%>'
                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsModify").ToString())%>' onclick="javascript:CheckUncheckCB(this);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllScreenRight_Delete" runat="server" CssClass="cssCheckBox"
                                                                Text="<% $ Resources:Resource, DeleteAccess%>" onclick="javascript:CheckUncheckAll(this,'cbIsDelete');" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbIsDelete" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsDeleteDisabled").ToString())%>'
                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsDelete").ToString())%>' onclick="javascript:CheckUncheckCB(this);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="100" ItemStyle-Width="100">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllScreenRight_Authorization" runat="server" CssClass="cssCheckBox"
                                                                Text="<% $ Resources:Resource, AuthorizationAccess%>" onclick="javascript:CheckUncheckAll(this,'cbIsAuthorization');" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbIsAuthorization" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsAuthorizationDisabled").ToString())%>'
                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsAuthorization").ToString())%>' onclick="javascript:CheckUncheckCB(this);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView Width="100%" ID="gvLevel2" CssClass="GridViewStyle" runat="server" ShowFooter="false" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None" 
                                                AutoGenerateColumns="False" OnRowDataBound="gvLevel2_RowDataBound" OnRowEditing="gvLevel2_OnRowEditing" OnRowCancelingEdit="gvLevel2_RowCanceling" >
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrMenuHead" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuHead %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label Visible="false" ID="lblgvLevel2_MenuHeadAutoID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadAutoID").ToString()%>'></asp:Label>
                                                            <asp:Label Visible="false" ID="lblgvLevel2_MenuHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>'></asp:Label>
                                                            <asp:Label ID="lblgvLevel2_MenuHeadName" CssClass="cssLabelHeader" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadName").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label Visible="false" ID="lblgvLevel2_MenuHeadAutoID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadAutoID").ToString()%>'></asp:Label>
                                                            <asp:Label Visible="false" ID="lblgvLevel2_MenuHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>'></asp:Label>
                                                            <asp:Label ID="lblgvLevel2_MenuHeadName" CssClass="cssLabelHeader" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadName").ToString()%>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Width="150px" />
                                                        <ItemStyle Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Read" Visible="false" runat="server"
                                                                CssClass="cssCheckBox" Text="<% $ Resources:Resource, ReadAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsRead');" />
                                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Write" Visible="false" runat="server"
                                                                CssClass="cssCheckBox" Text="<% $ Resources:Resource, WriteAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsWrite');" />
                                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Modift" Visible="false" runat="server"
                                                                CssClass="cssCheckBox" Text="<% $ Resources:Resource, EditAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsModify');" />
                                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Delete" Visible="false" runat="server"
                                                                CssClass="cssCheckBox" Text="<% $ Resources:Resource, DeleteAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsDelete');" />
                                                            <asp:CheckBox Width="60px" ID="cbAllLocScreenRight_Authorization" Visible="false"
                                                                runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, AuthorizationAccess%>" onclick="javascript:CheckUncheckAllLoc(this,'cbIsAuthorization');" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Button ID="ViewChild_Button" runat="server" Text="+" CommandName="Edit" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Button ID="CancelChild_Button" runat="server" Text="-" CommandName="Cancel" />
                                                            <asp:GridView Width="100%" ID="gvLevel3" CssClass="GridViewStyle" runat="server"
                                                                ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                                                                AutoGenerateColumns="False" OnRowCommand="gvLevel3_RowCommand">
                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblgvhdrMenuHead" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuHead %>"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label Visible="false" ID="lblMenuHeadCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadCode").ToString()%>'></asp:Label>
                                                                            <asp:Label ID="lblMenuHeadName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuHeadName").ToString()%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblgvhdrMenuNodeName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, MenuNodeName %>"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label Visible="false" ID="lblMenuNodeAutoID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeAutoID").ToString()%>'></asp:Label>
                                                                            <asp:Label Visible="false" ID="lblMenuNodeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeCode").ToString()%>'></asp:Label>
                                                                            <asp:Label ID="lblMenuNodeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuNodeName").ToString()%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Button ID="btnAdd" CssClass="cssSaveButton" runat="server" ToolTip="<%$ Resources:Resource, Save %>" Text="<%$ Resources:Resource, Save %>" CommandName="Save" />
                                                                            <asp:ImageButton Visible="false" ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Save" ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="cbAllScreenRight_Read" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, ReadAccess%>"
                                                                                onclick="javascript:CheckUncheckAll(this,'cbIsRead');" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbIsRead" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsReadDisabled").ToString())%>'
                                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsRead").ToString())%>'
                                                                                onclick="javascript:CheckUncheckCB(this);" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="cbAllScreenRight_Write" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, WriteAccess%>"
                                                                                onclick="javascript:CheckUncheckAll(this,'cbIsWrite');" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbIsWrite" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsWriteDisabled").ToString())%>'
                                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsWrite").ToString())%>'
                                                                                onclick="javascript:CheckUncheckCB(this);" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="cbAllScreenRight_Modify" runat="server" CssClass="cssCheckBox"
                                                                                Text="<% $ Resources:Resource, EditAccess%>" onclick="javascript:CheckUncheckAll(this,'cbIsModify');" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbIsModify" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsModifyDisabled").ToString())%>'
                                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsModify").ToString())%>'
                                                                                onclick="javascript:CheckUncheckCB(this);" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="cbAllScreenRight_Delete" runat="server" CssClass="cssCheckBox"
                                                                                Text="<% $ Resources:Resource, DeleteAccess%>" onclick="javascript:CheckUncheckAll(this,'cbIsDelete');" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbIsDelete" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsDeleteDisabled").ToString())%>'
                                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsDelete").ToString())%>'
                                                                                onclick="javascript:CheckUncheckCB(this);" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="100" ItemStyle-Width="100">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="cbAllScreenRight_Authorization" runat="server" CssClass="cssCheckBox"
                                                                                Text="<% $ Resources:Resource, AuthorizationAccess%>" onclick="javascript:CheckUncheckAll(this,'cbIsAuthorization');" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbIsAuthorization" runat="server" CssClass="cssCheckBox" Enabled='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsAuthorizationDisabled").ToString())%>'
                                                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsAuthorization").ToString())%>'
                                                                                onclick="javascript:CheckUncheckCB(this);" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            </ItemTemplate>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
            <asp:Label ID="lblErrorMsg" CssClass="csslblErrMsg" Text="" EnableViewState="false" runat="server"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
