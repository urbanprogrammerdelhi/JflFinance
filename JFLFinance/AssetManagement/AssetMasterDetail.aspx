<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetMasterDetail.aspx.cs" Inherits="AssetManagement_AssetMasterDetail" EnableViewState="true" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        function DocumentUpload(id, docType) {
            var pageName = "../AssetManagement/AssetDocumentMaster.aspx?AssetId=" + id + "&Category=" + docType;
            var newWin = window.open(pageName, null, 'status=off,center=yes,scroll=no,Width=1000px,help=no');
            newWin.focus();
            //var newWin = window.showModalDialog(pageName, null, 'status:off;center:yes;scroll:no;dialogWidth:1000px;dialogheight:600px;help:no;');
        }

        function textboxMultilineMaxNumber(txt, maxLen) {
            try {
                if (txt.value.length > (maxLen - 1)) return false;
            } catch (e) {
            }
        }

        function Validate() {
            if (Page_ClientValidate('AssetPurchaseValidation')) {
                return confirm('You can save either Purchase record or Lease record for this Asset. If you proceed it will delete your Lease Records.');
            }
            return false;
        }
        //function ValidateClientMapping() {
        //    if (Page_ClientValidate('AssetClientMapping')) {
        //        return confirm('Do ypu want to delete the ');
        //    }
        //    return false;
        //}
    </script>
    <asp:Label ID="AssetIdQs" runat="server" Visible="false"></asp:Label>
    <asp:Panel ID="PanelAssetMasterDetail" runat="server">
        <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
            <tr>
                <td rowspan="6" id="spanImage" runat="server" visible="false">
                    <asp:Image ID="ImageBox" runat="server" Height="150px" ImageUrl="~/AssetManagement/Images/NoImage.jpg" Style="margin-top: 6px; margin-left: 12px;" Width="210px" Visible="true" />
                    <asp:FileUpload ID="FileUploadAsset" Width="230px" CssClass="csstxtbox" runat="server" />
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server"
                        ControlToValidate="FileUploadAsset" SetFocusOnError="True" ErrorMessage="* .bmp, .gif, .png, .jpeg and .jpg formats are allowed" Style="color: red;"
                        ValidationExpression="(.+\.([Bb][Mm][Pp])|.+\.([Gg][Ii][Ff])|.+\.([Pp][Nn][Gg])|.+\.([Jj][Pp][Ee][Gg])|.+\.([Jj][Pp][Gg]))">
                    </asp:RegularExpressionValidator>
                    <asp:Button ID="btnUpload" CssClass="cssButton" Style="margin-left: 65px;" runat="server" Text="<%$ Resources:Resource,Upload %>" OnClick="btnUpload_Click" />
                    <asp:Label ID="lblImageUrl" Visible="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblAssetCategory" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCategory %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlAssetCategory" runat="server" CssClass="csstxtbox" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlAssetCategory_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblAssetSubCategory" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetSubCategory %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlAssetSubCategory" runat="server" Width="150px" CssClass="csstxtbox"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblAssetManufacture" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ManufacturerName %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlAssetManufacture" runat="server" Width="150px" CssClass="csstxtbox"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" nowrap="nowrap">
                    <asp:Label ID="lblAssetCode" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCode %>"></asp:Label>
                </td>
                <td style="text-align: left;" nowrap="nowrap">
                    <asp:TextBox ID="txtAssetCode" CssClass="csstxtbox" MaxLength="25" ValidationGroup="NewAsset"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtAssetCode" Font-Bold="true" ValidationGroup="NewAsset" ControlToValidate="txtAssetCode" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblAssetName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetName %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtAssetName" MaxLength="100" CssClass="csstxtbox" ValidationGroup="NewAsset"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtAssetName" Font-Bold="true" ValidationGroup="NewAsset" ControlToValidate="txtAssetName" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblDescription" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Description %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtDescription" MaxLength="200" CssClass="csstxtbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblModelNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ModelNo %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtModelNo" MaxLength="50" CssClass="csstxtbox" ValidationGroup="NewAsset" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtModelNo" ValidationGroup="NewAsset" Font-Bold="true" ControlToValidate="txtModelNo" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblModelName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ModelName %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtModelName" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SerialNo %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtSerialNo" MaxLength="50" CssClass="csstxtbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblTagId" CssClass="cssLable" Style="width: 130px;" runat="server" Text="<%$ Resources:Resource,TagID %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtTagID" MaxLength="25" CssClass="csstxtbox" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblCondition" CssClass="cssLable" Style="width: 100px;" runat="server" Text="<%$ Resources:Resource,Condition %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtCondition" MaxLength="50" CssClass="csstxtbox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtCondition" ValidationGroup="NewAsset" Font-Bold="true" ControlToValidate="txtCondition" ForeColor="Red" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblStatus" CssClass="cssLable" Style="width: 100px;" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlStatus" Width="150px" CssClass="csstxtbox" runat="server">
                        <asp:ListItem Text="Working" Value="Working"></asp:ListItem>
                        <asp:ListItem Text="Under Maintenance" Value="Under Maintenance"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblIsActive" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,IsActive %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlIsActive" Width="150px" CssClass="csstxtbox" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIsActive_SelectedIndexChanged">
                        <asp:ListItem Text="True" Value="True"></asp:ListItem>
                        <asp:ListItem Text="False" Value="False"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblActivewef" CssClass="cssLable" Style="width: 100px;" runat="server" Text="<%$ Resources:Resource,ActiveWEF %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtActivewef" MaxLength="50" Width="100px" CssClass="csstxtbox" ValidationGroup="NewAsset"
                        runat="server"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtActivewef" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="rfvtxtActivewef" Font-Bold="true" ForeColor="Red" ValidationGroup="NewAsset" ControlToValidate="txtActivewef" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                 <td style="text-align: right">
                    <asp:Label ID="lblRemarks" CssClass="cssLable" Style="width: 100px;" runat="server" Text="<%$ Resources:Resource,Remarks %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtRemarks" MaxLength="500" CssClass="csstxtbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td style="text-align: right;">
                    <asp:Label ID="lblInactiveWEF" CssClass="cssLable" Style="width: 100px;" runat="server"
                        Text="<%$ Resources:Resource,InactiveWEF %>" Visible="false"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtInactivewef" MaxLength="50" Width="100px" CssClass="csstxtbox" ValidationGroup="NewAsset"
                        runat="server" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="false" Visible="false"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtInactivewef" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="rfvtxtInactivewef" ForeColor="Red" Font-Bold="true" ValidationGroup="NewAsset" ControlToValidate="txtInactivewef" Display="Dynamic" runat="server" Text="*" Enabled="false"></asp:RequiredFieldValidator>
                </td>
              
                <td style="text-align: right;">
                    <asp:Label ID="lblAssetOwner" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetOwner %>" Visible="false"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlAssetOwner" Width="150px" CssClass="csstxtbox" runat="server" Visible="false">
                    <%--    <asp:ListItem Text="Self" Value="Self"></asp:ListItem>--%>
                        <asp:ListItem Text="Client" Value="Client"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right;"></td>
                <td style="text-align: left;"></td>
            </tr>
            <tr>
                <td colspan="7" style="text-align: left;">
                    <asp:Label ID="lblMgmtGuidline" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ManagementGuideline %>"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="text-align: left;">
                    <asp:Panel ID="PanelText" runat="server" CssClass="frameText">
                        <asp:TextBox ID="txtMgmtGuidline" MaxLength="1000" CssClass="noborder" TextMode="MultiLine"
                            runat="server" Width="100%" Height="100%"></asp:TextBox>
                    </asp:Panel>
                    <AjaxToolKit:ResizableControlExtender ID="ResizableControlExtender1" runat="server" TargetControlID="PanelText"
                        ResizableCssClass="resizingText" HandleCssClass="handleText" MinimumHeight="50" MinimumWidth="1050" MaximumHeight="300" MaximumWidth="1050" />

                </td>
            </tr>
        </table>
        <asp:Label ID="lblAssestMaster" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
        <div style="margin-left: 450px; margin-top: 25px;">

            <asp:Button ID="btnedit" runat="server" Text="<%$ Resources:Resource,Update %>" ValidationGroup="NewAsset" CausesValidation="true" CssClass="cssButton" OnClick="btnedit_Click" Visible="false" />
            <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:Resource,Submit %>" ValidationGroup="NewAsset" CausesValidation="true" CssClass="cssButton" OnClick="btnSubmit_Click" Visible="false" />
            <asp:Button ID="btnReset" runat="server" Text="<%$ Resources:Resource,Reset %>" CssClass="cssButton" OnClick="btnReset_Click" Visible="false" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="cssButton" OnClick="btnBack_Click" />
        </div>
    </asp:Panel>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" Visible="false" style="margin-top: 30px">
        <ContentTemplate>
            <div>
                <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="AssetDetails"
                    ActiveTabIndex="0" OnActiveTabChanged="AssetDetails_ActiveTabChanged" AutoPostBack="true">
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelAssetPurchase" runat="server" HeaderText="<%$Resources:Resource,AssetPurchase %>"
                        TabIndex="1" Height="230px">
                        <ContentTemplate>
                            <asp:Panel ID="AssetPurchase" Font-Bold="True" ForeColor="Red" runat="server" Height="280px">
                                <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetName %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchaseAssetName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label7" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CompanyName %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchaseCompanyName" CssClass="csstxtbox" MaxLength="100" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtPurchaseCompanyName" ValidationGroup="AssetPurchaseValidation" ControlToValidate="txtPurchaseCompanyName" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label8" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PurchaseOrderNo %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchaseOrderNo" CssClass="csstxtbox" MaxLength="25" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtPurchaseOrderNo" ValidationGroup="AssetPurchaseValidation" ControlToValidate="txtPurchaseOrderNo" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;" nowrap="nowrap">
                                            <asp:Label ID="Label9" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PurchaseDate %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" nowrap="nowrap">
                                            <asp:TextBox ID="txtPurchaseDate" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            <asp:ImageButton ID="imgPurchaseDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtPurchaseDate" PopupButtonID="imgPurchaseDate"></AjaxToolKit:CalendarExtender>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label10" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PurchasePrice %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchasePrice" MaxLength="18" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="AssetPurchaseValidation" ControlToValidate="txtPurchasePrice" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>

                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label11" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SupplierName %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchaseSuppliername" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label12" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SupplierEmail %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchaseSupplierEmail" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revtxtPurchaseSupplierEmail" runat="server" ErrorMessage="*" ControlToValidate="txtPurchaseSupplierEmail" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="AssetPurchaseValidation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label13" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SupplierPhone %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchaseSupplierPhone" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label14" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SupplierAddress %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchaseSupplierAddress" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label15" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Remarks %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPurchaseRemarks" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblPurchaseImageUpload" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,UploadDocument %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:ImageButton ID="ImgBtnUploadPurchase" runat="server" ImageUrl="~/Images/uploaddoc.png" OnClick="ImgBtnUploadPurchase_Click"></asp:ImageButton>
                                            <asp:Label ID="PurchaseDocCount" CssClass="cssLable" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                            </ItemTemplate>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblErrorAssetPurchase" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                <div style="margin-left: 550px; margin-top: 25px;">

                                    <asp:Button ID="BtnPurchaseEdit" runat="server" Text="<%$ Resources:Resource,Update %>" ValidationGroup="AssetPurchaseValidation" CausesValidation="true" CssClass="cssButton" OnClick="BtnPurchaseEdit_Click" Visible="false" />
                                    <asp:Button ID="BtnPurchaseSave" runat="server" Text="<%$ Resources:Resource,Submit %>" ValidationGroup="AssetPurchaseValidation" CausesValidation="true" CssClass="cssButton" OnClick="BtnPurchaseSave_Click" Visible="false" OnClientClick="return Validate();" />
                                    <asp:Button ID="BtnPurchaseReset" runat="server" Text="<%$ Resources:Resource,Reset %>" CssClass="cssButton" OnClick="BtnPurchaseReset_Click" Visible="false" />
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="AssetLease" runat="server" HeaderText="<%$Resources:Resource,AssetLease %>"
                        TabIndex="2" Height="230px">
                        <ContentTemplate>
                            <asp:Panel ScrollBars="Auto" ID="PanelAssetLease" Font-Bold="True" ForeColor="Red" Height="230px" runat="server">
                                <asp:GridView Width="120%" ID="gvAssetLease" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnRowDataBound="gvAssetLease_RowDataBound" OnRowCommand="gvAssetLease_RowCommand"
                                    OnRowDeleting="gvAssetLease_RowDeleting" OnRowEditing="gvAssetLease_RowEditing" OnPageIndexChanging="gvAssetLease_PageIndexChanging"
                                    OnRowUpdating="gvAssetLease_RowUpdating" OnRowCancelingEdit="gvAssetLease_RowCancelingEdit">
                                    <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="EditAssetLease" />

                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="NewAssetLease" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
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
                                            <FooterStyle Width="100px" />
                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfAssetLeaseAutoId" runat="server" Value='<%# Bind("AssetLeaseAutoId") %>' />
                                                <asp:HiddenField ID="hfLeaseDoc" runat="server" Value='<%# Bind("LeaseDocScanCopy") %>' />
                                                <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:HiddenField ID="hfAssetLeaseAutoIdNew" runat="server" Value="0" />
                                                <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfLeaseDoc" runat="server" Value='<%# Bind("LeaseDocScanCopy") %>' />
                                                <asp:HiddenField ID="hfAssetLeaseAutoId" runat="server" Value='<%# Bind("AssetLeaseAutoId") %>' />
                                                <asp:Label ID="LbAssestName" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,LeasingFirmName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLeasingFirmName" MaxLength="100" ValidationGroup="EditAssetLease" CssClass="csstxtbox" runat="server" Text='<%# Bind("LeasingFirmName") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtLeasingFirmName" runat="server" ControlToValidate="txtLeasingFirmName"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetLease"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtLeasingFirmName" MaxLength="100" ValidationGroup="NewAssetLease" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtLeasingFirmNameNew" runat="server" ControlToValidate="txtLeasingFirmName"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetLease"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblLeaseFirmName" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("LeasingFirmName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,LeasingFirmEmail %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLeasingFirmEmail" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("LeasingFirmEmail") %>'></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="REVtxtLeasingFirmEmail" runat="server" ErrorMessage="*" ControlToValidate="txtLeasingFirmEmail" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetLease" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtLeasingFirmEmail" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="REVtxtLeasingFirmEmailNew" runat="server" ErrorMessage="*" ValidationGroup="NewAssetLease" ForeColor="Red" SetFocusOnError="True" ControlToValidate="txtLeasingFirmEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblLeaseFirmEmail" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("LeasingFirmEmail") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,LeasingFirmPhone %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLeasingFirmPhone" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("LeasingFirmPhone") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtLeasingFirmPhone" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblLeaseFirmPhone" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("LeasingFirmPhone") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,LeasingFirmAddress %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLeasingFirmAddress" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("LeasingFirmAddress") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtLeasingFirmAddress" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblLeaseFirmAddress" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("LeasingFirmAddress") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,TypeOfLease %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="HFLeaseType" runat="server" Value='<%# Bind("TypeOfLease") %>' />
                                                <asp:DropDownList ID="ddlTypeOfLease" runat="server" CssClass="cssDropDown">
                                                    <asp:ListItem Text="Direct Lease" Value="Direct Lease"></asp:ListItem>
                                                    <asp:ListItem Text="Finance Lease" Value="Finance Lease"></asp:ListItem>
                                                    <asp:ListItem Text="Operating Lease" Value="Operating Lease"></asp:ListItem>
                                                    <asp:ListItem Text="Leveraged Lease" Value="Leveraged Lease"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlTypeOfLease" runat="server" CssClass="cssDropDown">
                                                    <asp:ListItem Text="Direct Lease" Value="Direct Lease"></asp:ListItem>
                                                    <asp:ListItem Text="Finance Lease" Value="Finance Lease"></asp:ListItem>
                                                    <asp:ListItem Text="Operating Lease" Value="Operating Lease"></asp:ListItem>
                                                    <asp:ListItem Text="Leveraged Lease" Value="Leveraged Lease"></asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HFLeaseType" runat="server" Value='<%# Bind("TypeOfLease") %>' />
                                                <asp:Label ID="LblTypeOfLease" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("TypeOfLease") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,LeaseAmount %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLeaseAmount" MaxLength="18" CssClass="csstxtbox" runat="server" Text='<%# Bind("LeaseAmount") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtLeaseAmount" MaxLength="18" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaseAmount" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("LeaseAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,LeaseStartDate %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLeaseStartDate" MaxLength="30" Width="90px" Enabled="false" CssClass="csstxtbox" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("LeaseStartDate")) %>'></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton3" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CE9" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtLeaseStartDate" PopupButtonID="ImageButton3" Enabled="True"></AjaxToolKit:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtLeaseStartDate" MaxLength="30" Width="90px" Enabled="false" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton4" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CE5" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtLeaseStartDate" PopupButtonID="ImageButton4" Enabled="True"></AjaxToolKit:CalendarExtender>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaseStartDate" Width="150px" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("LeaseStartDate")) %>'>></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,LeaseEndDate %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLeaseEndDate" MaxLength="30" Width="90px" Enabled="false" CssClass="csstxtbox" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("LeaseEndDate")) %>'></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CE1" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtLeaseEndDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtLeaseEndDate" runat="server" ControlToValidate="txtLeaseEndDate"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetLease" Enabled="false"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtLeaseEndDate" MaxLength="30" Width="90px" Enabled="false" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtLeaseEndDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtLeaseEndDateNew" runat="server" ControlToValidate="txtLeaseEndDate"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetLease" Enabled="false"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaseEndDate" Width="150px" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("LeaseEndDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Remarks %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtRemarks" MaxLength="50" CssClass="csstxtbox" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarks" MaxLength="50" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,UploadDocument %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUpload" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                                <asp:Label ID="LeaseDocCount" CssClass="cssLable" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUpload" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                                <asp:Label ID="LeaseDocCount" CssClass="cssLable" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblAssetLease" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="AssetInsurance" runat="server" HeaderText="<%$Resources:Resource,AssetInsurance %>"
                        TabIndex="3" Height="420px">
                        <ContentTemplate>
                            <asp:Panel ScrollBars="Auto" ID="Panel1" Font-Bold="True" ForeColor="Red" Height="230px" runat="server">
                                <asp:GridView ID="gvAssetInsurance" Width="110%" CssClass="GridViewStyle"
                                    runat="server" AllowPaging="true" CellPadding="3" GridLines="None" DataKeyNames="PolicyNo"
                                    AutoGenerateColumns="False" OnRowCancelingEdit="gvAssetInsurance_RowCancelingEdit"
                                    OnRowCommand="gvAssetInsurance_RowCommand" OnRowDataBound="gvAssetInsurance_RowDataBound"
                                    OnRowDeleting="gvAssetInsurance_RowDeleting" OnRowEditing="gvAssetInsurance_RowEditing" OnRowUpdating="gvAssetInsurance_RowUpdating"
                                    ShowFooter="True" OnPageIndexChanging="gvAssetInsurance_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="100px" ItemStyle-Width="100px">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateAsset" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="Edit" />
                                                <asp:ImageButton ID="ImageButton2Asset" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditAsset" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                <asp:ImageButton ID="IBDeleteAsset" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,AssetName %>" HeaderStyle-Width="150px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="150px" ItemStyle-Width="150px">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfAssetInsuranceAutoId" runat="server" Value='<%# Bind("AssetInsuranceAutoId") %>' />
                                                <asp:Label ID="lblAssetNameInsurance" Width="200px" CssClass="cssLable" runat="server" Text='<%# Eval("AssetName") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfAssetInsuranceAutoId" runat="server" Value='<%# Bind("AssetInsuranceAutoId") %>' />
                                                <asp:Label ID="lblAssetNameInsurance" CssClass="cssLable" Width="200px" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblAssetNameInsurance" CssClass="cssLabel" runat="server"></asp:Label>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,PolicyNo %>" HeaderStyle-Width="150px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="150px" ItemStyle-Width="150px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblPolicyNo" Width="200px" CssClass="cssLable" runat="server" Text='<%# Eval("PolicyNo") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" CssClass="cssLable" Width="180px" runat="server" Text='<%# Bind("PolicyNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewPolicyNo" Width="180px" MaxLength="25" ValidationGroup="AddNew"
                                                    CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPolicyNo"
                                                    ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,SumInsured %>" HeaderStyle-Width="200px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtSumInsured" Width="180px" MaxLength="18" ValidationGroup="Edit"
                                                    CssClass="csstxtbox" runat="server" Text='<%# Bind("SumInsured") %>' Style="word-break: break-all;"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSumInsured" Width="200px" CssClass="cssLable" runat="server" Text='<%# Bind("SumInsured") %>' Style="word-break: break-all;"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewSumInsured" Width="180px" MaxLength="18" ValidationGroup="AddNew"
                                                    CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,InsuranceCompanyName %>" HeaderStyle-Width="200px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtInsuranceCompanyName" Width="180px" MaxLength="100" ValidationGroup="Edit"
                                                    CssClass="csstxtbox" runat="server" Text='<%# Bind("InsuranceCompanyName") %>' Style="word-break: break-all;"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" Width="200px" CssClass="cssLable" runat="server" Text='<%# Bind("InsuranceCompanyName") %>' Style="word-break: break-all;"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewInsuranceCompanyName" Width="180px" MaxLength="100" ValidationGroup="AddNew"
                                                    CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Email %>" HeaderStyle-Width="200px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEmail" Width="180px" MaxLength="100" ValidationGroup="Edit"
                                                    CssClass="csstxtbox" runat="server" Text='<%# Bind("Email") %>' Style="word-break: break-all;"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="REVEmailEdit" runat="server" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="Edit" ErrorMessage="*" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" Width="200px" CssClass="cssLable" runat="server" Style="word-break: break-all;" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewEmail" Width="180px" MaxLength="100" ValidationGroup="AddNew"
                                                    CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="REVEmail" runat="server" ForeColor="Red" ControlToValidate="txtNewEmail" ValidationGroup="AddNew" ErrorMessage="*" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Phone %>" HeaderStyle-Width="200px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPhoneNo" Width="180px" MaxLength="100" ValidationGroup="Edit"
                                                    CssClass="csstxtbox" runat="server" Style="word-break: break-all;" Text='<%# Bind("Phone") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" Width="200px" CssClass="cssLable" Style="word-break: break-all;" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewPhoneNo" Width="180px" MaxLength="100" ValidationGroup="AddNew"
                                                    CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,InsurancePeriodFrom %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtInsurancePeriodFrom" SetFocusOnError="True" CssClass="csstxtbox" Width="90px" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("InsurancePeriodFrom")) %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtInsurancePeriodFrom3" runat="server" ControlToValidate="txtInsurancePeriodFrom" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgEditFromDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgEditFromDate" PopupPosition="TopRight" TargetControlID="txtInsurancePeriodFrom" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtInsurancePeriodFrom" CssClass="csstxtbox" runat="server" Width="90px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtInsurancePeriodFrom" runat="server" ControlToValidate="txtInsurancePeriodFrom" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="AddNew"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgNewFromDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderNewFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgNewFromDate" PopupPosition="TopRight" TargetControlID="txtInsurancePeriodFrom" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInsurancePeriodFrom" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("InsurancePeriodFrom")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,InsurancePeriodTo %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtInsurancePeriodTo" Width="90px" CssClass="csstxtbox" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("InsurancePeriodTo")) %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtInsurancePeriodTo4" runat="server" ControlToValidate="txtInsurancePeriodTo" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgEditToDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderToDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgEditToDate" PopupPosition="TopRight" TargetControlID="txtInsurancePeriodTo" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtInsurancePeriodTo" CssClass="csstxtbox" runat="server" Width="90px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtInsurancePeriodTo" runat="server" ControlToValidate="txtInsurancePeriodTo" ForeColor="Red" SetFocusOnError="true" ErrorMessage="*" ValidationGroup="AddNew"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgNewToDate" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderNewToDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgNewToDate" PopupPosition="TopRight" TargetControlID="txtInsurancePeriodTo" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtInsurancePeriodTo" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("InsurancePeriodTo")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,UploadDocument %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUploadInsurance" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUploadInsurance" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="AssetGurantee" runat="server" HeaderText="<%$Resources:Resource,AssetGuaranty %>"
                        TabIndex="4" Height="230px">
                        <ContentTemplate>
                            <asp:Panel ScrollBars="Auto" ID="Panel2" Font-Bold="True" ForeColor="Red" Height="230px" runat="server">
                                <asp:GridView ID="gvAssetGurantee" Width="100%" CssClass="GridViewStyle"
                                    runat="server" AllowPaging="True" CellPadding="3" GridLines="None"
                                    AutoGenerateColumns="False" OnRowCancelingEdit="gvAssetGurantee_RowCancelingEdit"
                                    OnRowCommand="gvAssetGurantee_RowCommand" OnRowDataBound="gvAssetGurantee_RowDataBound"
                                    OnRowDeleting="gvAssetGurantee_RowDeleting" OnRowEditing="gvAssetGurantee_RowEditing" OnRowUpdating="gvAssetGurantee_RowUpdating"
                                    ShowFooter="True" OnPageIndexChanging="gvAssetGurantee_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateAsset" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="EditGurantee" />
                                                <asp:ImageButton ID="ImageButton3Asset" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditAsset" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                <asp:ImageButton ID="IBDeleteAsset" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="AddGurantee" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfAssetGuarantyAutoId" runat="server" Value='<%# Bind("AssetGuarantyAutoId") %>' />
                                                <asp:Label ID="lblAssetNameGurantee" Width="200px" CssClass="cssLable" runat="server" Text='<%# Eval("AssetName") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfAssetGuarantyAutoId" runat="server" Value='<%# Bind("AssetGuarantyAutoId") %>' />
                                                <asp:Label ID="lblAssetNameGurantee" CssClass="cssLable" Width="180px" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblAssetNameGurantee" CssClass="cssLabel" runat="server"></asp:Label>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,GuranteeExpDate %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtGuranteeExpDate" CssClass="csstxtbox" Width="90px" runat="server" Enabled="false" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("GuarantyExpDate")) %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtGuranteeExpDate3" runat="server" ControlToValidate="txtGuranteeExpDate" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgEditFromDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgEditFromDate" PopupPosition="TopRight" TargetControlID="txtGuranteeExpDate" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtGuranteeExpDate" CssClass="csstxtbox" runat="server" Enabled="false" Width="90px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtGuranteeExpDate" runat="server" ControlToValidate="txtGuranteeExpDate" ForeColor="Red" SetFocusOnError="true" ErrorMessage="*" ValidationGroup="AddGurantee"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgNewFromDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderNewFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgNewFromDate" PopupPosition="TopRight" TargetControlID="txtGuranteeExpDate" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGuranteeExpDate" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("GuarantyExpDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,UploadDocument %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUploadGurantee" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUploadGurantee" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label EnableViewState="False" ID="LabelGurantee" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>

                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="AssetWarranty" runat="server" HeaderText="<%$Resources:Resource,AssetWarranty %>"
                        TabIndex="5" Height="230px">
                        <ContentTemplate>
                            <asp:Panel ScrollBars="Auto" ID="Panel3" Font-Bold="True" ForeColor="Red" Height="230px" runat="server">
                                <asp:GridView ID="gvAssetWarrenty" Width="100%" CssClass="GridViewStyle"
                                    runat="server" AllowPaging="true" CellPadding="3" GridLines="None"
                                    AutoGenerateColumns="False" OnRowCancelingEdit="gvAssetWarrenty_RowCancelingEdit"
                                    OnRowCommand="gvAssetWarrenty_RowCommand" OnRowDataBound="gvAssetWarrenty_RowDataBound"
                                    OnRowDeleting="gvAssetWarrenty_RowDeleting" OnRowEditing="gvAssetWarrenty_RowEditing" OnRowUpdating="gvAssetWarrenty_RowUpdating"
                                    ShowFooter="True" OnPageIndexChanging="gvAssetWarrenty_PageIndexChanging">
                                     <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="100px" ItemStyle-Width="100px">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateAsset" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="EditWarranty" />
                                                <asp:ImageButton ID="ImageButton3Asset" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditAsset" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                <asp:ImageButton ID="IBDeleteAsset" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="AddWarranty" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,AssetName %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="200px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfAssetWarrentyAutoId" runat="server" Value='<%# Bind("AssetWarrentyAutoId") %>' />
                                                <asp:Label ID="lblAssetNameWarrenty" Width="200px" CssClass="cssLable" runat="server" Text='<%# Eval("AssetName") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfAssetWarrentyAutoId" runat="server" Value='<%# Bind("AssetWarrentyAutoId") %>' />
                                                <asp:Label ID="lblAssetNameWarrenty" CssClass="cssLable" Width="180px" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblAssetNameWarrenty" CssClass="cssLabel" runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,WarrantyExpDate %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="150px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="150px" ItemStyle-Width="150px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtWarrentyExpDate" CssClass="csstxtbox" Width="90px" runat="server" Enabled="false" Text='<%# String.Format("{0:d-MMM-yyyy}",Eval("WarrentyExpDate")) %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtWarrentyExpDate3" runat="server" ControlToValidate="txtWarrentyExpDate" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgEditFromDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgEditFromDate" PopupPosition="TopRight" TargetControlID="txtWarrentyExpDate" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtWarrentyExpDate" CssClass="csstxtbox" runat="server" Enabled="false" Width="90px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtWarrentyExpDate" runat="server" ControlToValidate="txtWarrentyExpDate" ForeColor="Red" SetFocusOnError="true" ErrorMessage="*" ValidationGroup="AddWarranty"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgNewFromDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderNewFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgNewFromDate" PopupPosition="TopRight" TargetControlID="txtWarrentyExpDate" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblWarrentyExpDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:d-MMM-yyyy}",Eval("WarrentyExpDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,UploadDocument %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White"
                                            FooterStyle-Width="100px" ItemStyle-Width="100px">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUploadWarranty" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUploadwarranty" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label EnableViewState="false" ID="LabelWarrenty" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="AssetNote" runat="server" HeaderText="<%$Resources:Resource,AssetNote %>"
                        TabIndex="6" Height="230px">
                        <ContentTemplate>
                            <asp:Panel ScrollBars="Auto" ID="Panel4" Font-Bold="True" ForeColor="Red" Height="230px" runat="server">
                                <asp:GridView Width="100%" ID="gvAssetNote" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnRowDataBound="gvAssetNote_RowDataBound"
                                    OnRowCommand="gvAssetNote_RowCommand"
                                    OnRowDeleting="gvAssetNote_RowDeleting" OnRowEditing="gvAssetNote_RowEditing" OnPageIndexChanging="gvAssetNote_PageIndexChanging"
                                    OnRowUpdating="gvAssetNote_RowUpdating" OnRowCancelingEdit="gvAssetNote_RowCancelingEdit">
                                      <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="EditAssetNote" />
                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="NewAssetNote" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
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
                                            <FooterStyle Width="120px" />
                                            <HeaderStyle Width="120px" CssClass="cssLabelHeader" />
                                            <ItemStyle Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ToWhom %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfAssetNoteAutoId" runat="server" Value='<%# Bind("AssetNoteAutoId") %>' />
                                                <asp:HiddenField ID="hfAssetAutoId" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                                                <asp:TextBox ID="txtAssetNoteWhom" CssClass="csstxtbox" runat="server" Text='<%# Bind("Towhom") %>' MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAssetNoteWhom" runat="server" ErrorMessage="*" ControlToValidate="txtAssetNoteWhom" ValidationGroup="EditAssetNote" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:HiddenField ID="hfAssetNoteAutoIdNew" runat="server" Value="0" />
                                                <asp:TextBox ID="txtAssetNoteWhom" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAssetNoteWhomNew" runat="server" ErrorMessage="*" ControlToValidate="txtAssetNoteWhom" ValidationGroup="NewAssetNote" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfAssetNoteAutoId" runat="server" Value='<%# Bind("AssetNoteAutoId") %>' />
                                                <asp:HiddenField ID="hfAssetAutoId" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                                                <asp:Label ID="lblAssestNote" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Towhom") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,NoteType %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfNoteType" runat="server" Value='<%# Bind("NoteType") %>' />
                                                <asp:DropDownList ID="ddlAssetNoteType" runat="server" Width="170px" CssClass="cssDropDown">
                                                    <asp:ListItem Text="Type 1" Value="Type 1"></asp:ListItem>
                                                    <asp:ListItem Text="Type 2" Value="Type 2"></asp:ListItem>
                                                    <asp:ListItem Text="Type 3" Value="Type 3"></asp:ListItem>
                                                    <asp:ListItem Text="Type 4" Value="Type 4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlAssetNoteType" runat="server" Width="170px" CssClass="cssDropDown">
                                                    <asp:ListItem Text="Type 1" Value="Type 1"></asp:ListItem>
                                                    <asp:ListItem Text="Type 2" Value="Type 2"></asp:ListItem>
                                                    <asp:ListItem Text="Type 3" Value="Type 3"></asp:ListItem>
                                                    <asp:ListItem Text="Type 4" Value="Type 4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfNoteType" runat="server" Value='<%# Bind("NoteType") %>' />
                                                <asp:Label ID="lblAssetNoteType" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("NoteType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Note %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAssetNote" CssClass="csstxtbox" runat="server" Style="width: 98%;" Height="50px" TextMode="MultiLine" ValidationGroup="AssetNotice" Text='<%# Bind("Note") %>' onkeypress="return textboxMultilineMaxNumber(this,2000)"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAssetNote" runat="server" ErrorMessage="*" ControlToValidate="txtAssetNote" ValidationGroup="EditAssetNote" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAssetNote" CssClass="csstxtbox" runat="server" Style="width: 98%;" TextMode="MultiLine" Height="50px" ValidationGroup="AssetNotice" onkeypress="return textboxMultilineMaxNumber(this,2000)"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAssetNote" runat="server" ErrorMessage="*" ControlToValidate="txtAssetNote" ValidationGroup="NewAssetNote" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssetNote" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Note") %>' Width="98%"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" />
                                            <ItemStyle Height="50px" />
                                            <FooterStyle Height="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblAssetNoteMsg" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="AssetAMC" runat="server" HeaderText="<%$Resources:Resource,AssetAMC %>"
                        TabIndex="7" Height="230px">
                        <ContentTemplate>
                            <asp:Panel ScrollBars="Auto" ID="Panel5" Font-Bold="True" ForeColor="Red" Height="230px" runat="server">
                                <asp:GridView Width="150%" ID="gvAssetAMC" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnRowDataBound="gvAssetAMC_RowDataBound" OnRowCommand="gvAssetAMC_RowCommand"
                                    OnRowDeleting="gvAssetAMC_RowDeleting" OnRowEditing="gvAssetAMC_RowEditing" OnPageIndexChanging="gvAssetAMC_PageIndexChanging"
                                    OnRowUpdating="gvAssetAMC_RowUpdating" OnRowCancelingEdit="gvAssetAMC_RowCancelingEdit">
                                     <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="EditAssetAMC" />

                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="NewAssetAMC" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />

                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" CausesValidation="false" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                    CommandName="Edit" />
                                                &nbsp;
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterStyle Width="100px" />
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfAssetAMCAutoId" runat="server" Value='<%# Bind("AssetAMCAutoId") %>' />
                                                <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfAssetAMCAutoId" runat="server" Value='<%# Bind("AssetAMCAutoId") %>' />
                                                <asp:Label ID="LbAssestName" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,FirmName %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCFirmName" MaxLength="100" ValidationGroup="EditAssetAMC" CssClass="csstxtbox" runat="server" Text='<%# Bind("FirmName") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCFirmName" runat="server" ControlToValidate="txtAMCFirmName"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetAMC"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCFirmName" MaxLength="100" ValidationGroup="NewAssetAMC" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfctxtAMCFirmName" runat="server" ControlToValidate="txtAMCFirmName"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetAMC"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblAMCFirmName" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("FirmName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,FirmEmail %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCFirmEmail" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("FirmEmail") %>' ValidationGroup="EditAssetAMC"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revtxtAMCFirmEmail" runat="server" ErrorMessage="*" ValidationGroup="EditAssetAMC" ForeColor="Red" ControlToValidate="txtAMCFirmEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCFirmEmail" runat="server" ControlToValidate="txtAMCFirmEmail"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetAMC"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCFirmEmail" MaxLength="100" CssClass="csstxtbox" runat="server" ValidationGroup="NewAssetAMC"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revtxtAMCFirmEmailnew" runat="server" ErrorMessage="*" ControlToValidate="txtAMCFirmEmail" ForeColor="Red" ValidationGroup="NewAssetAMC" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCFirmEmailnew" runat="server" ControlToValidate="txtAMCFirmEmail"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetAMC"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblAMCFirmEmail" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("FirmEmail") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,FirmPhone %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCFirmPhone" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("FirmPhone") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCFirmPhone" runat="server" ControlToValidate="txtAMCFirmPhone"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetAMC"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCFirmPhone" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCFirmPhone" runat="server" ControlToValidate="txtAMCFirmPhone"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetAMC"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblAMCFirmPhone" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("FirmPhone") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,FirmAddress %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCFirmAddress" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("FirmAddress") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCFirmAddress" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblAMCFirmAddress" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("FirmAddress") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AMCType %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCType" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCType" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LblAMCType" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AMCAmount %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCAmount" MaxLength="18" CssClass="csstxtbox" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCAmount" MaxLength="18" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAMCAmount" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,StartDate %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCStartDate" MaxLength="30" Width="90px" CssClass="csstxtbox" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("StartDate")) %>'></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton3" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CE9" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtAMCStartDate" PopupButtonID="ImageButton3" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCStartDate" runat="server" ControlToValidate="txtAMCStartDate"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetAMC"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCStartDate" MaxLength="30" Width="90px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton4" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CE5" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtAMCStartDate" PopupButtonID="ImageButton4" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCStartDate" runat="server" ControlToValidate="txtAMCStartDate"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetAMC"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAMCStartDate" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("StartDate")) %>'>></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EndDate %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCEndDate" MaxLength="30" Width="90px" CssClass="csstxtbox" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("EndDate")) %>'></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CE1" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtAMCEndDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCEndDate" runat="server" ControlToValidate="txtAMCEndDate"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditAssetAMC"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCEndDate" MaxLength="30" Width="90px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtAMCEndDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtAMCEndDate" runat="server" ControlToValidate="txtAMCEndDate"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewAssetAMC"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAMCEndDate" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("EndDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AMCTerms %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAMCTerms" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("Terms") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAMCTerms" MaxLength="100" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAMCTerms" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Terms") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,UploadDocument %>" HeaderStyle-ForeColor="White">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUploadAMC" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnUploadAMC" runat="server" ImageUrl="~/Images/uploaddoc.png"></asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <%--  <asp:ValidationSummary 
            ID="ValidationSummary1" 
            runat="server" 
            HeaderText="Plz Fill the mandatory Fields." 
            ShowMessageBox="false" 
            DisplayMode="List"
            ShowSummary="true"
            BackColor="Snow"
            Width="450"
            ForeColor="Red"
                                     Font-Size="Smaller"
            ValidationGroup="NewAssetAMC"
            
                                  
            />--%>
                                <asp:Label ID="lblAssetAMCMsg" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="AssetClientMapping" runat="server" HeaderText="<%$Resources:Resource,AssetClientMapping %>"
                        TabIndex="8" Height="160px" Visible="false">
                        <ContentTemplate>

                            <asp:Panel ID="Panel6" Font-Bold="True" runat="server" Height="160px">
                                <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true" Width="350px"
                                                OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Client %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="350px"
                                                OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>


                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label16" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Asmt %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlAsmtId" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="350px"
                                                OnSelectedIndexChanged="ddlAsmt_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label17" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Post %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlPost" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                Width="350px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="text-align: right;" nowrap="nowrap">
                                            <asp:Label ID="Label18" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Remark %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" nowrap="nowrap">
                                            <asp:TextBox ID="txtRemark" CssClass="csstxtbox" runat="server" MaxLength="100" Width="350px"></asp:TextBox>

                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label19" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Usage %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtUsage" CssClass="csstxtbox" runat="server" MaxLength="50" Width="350px"></asp:TextBox>
                                    </tr>

                                </table>
                                <div style="margin-left: 550px; margin-top: 25px;">

                                    <asp:Button ID="btnUpdateMapping" runat="server" Text="<%$ Resources:Resource,Update %>" CssClass="cssButton" Visible="false" OnClick="btnUpdateMapping_Click" />
                                    <asp:Button ID="btnSubmitMapping" runat="server" Text="<%$ Resources:Resource,Submit %>" CssClass="cssButton" OnClick="btnSubmit_Click1" Visible="false" />

                                </div>

                                <asp:Label ID="lblMapping" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>

                            </asp:Panel>

                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                </AjaxToolKit:TabContainer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

