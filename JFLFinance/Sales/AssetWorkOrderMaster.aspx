<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetWorkOrderMaster.aspx.cs" Inherits="Sales_AssetWorkOrderMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <div style="width: 100%;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 25px; cursor: pointer; background-color: silver;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 12px; width: 60%" align="right">
                                        <asp:Label ID="Label3" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AssetWorkOrder %>"></asp:Label>
                                    </td>
                                    <td style="width: 40%" align="right">
                                        <Ajax:UpdatePanel runat="server" ID="upWOStatus" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label Width="130px" ID="lblfixWoStatus" CssClass="cssLabelHeader" runat="server"
                                                    Text="<%$ Resources:Resource, WOStatus %>"></asp:Label>
                                                <asp:Label Width="130px" Style="font-weight: bold;" ID="lblWOStatus" CssClass="csstxtboxReadonly"
                                                    runat="server"></asp:Label><asp:HiddenField ID="hiddenFieldWoStatus" runat="server" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <Ajax:AsyncPostBackTrigger ControlID="btnAuthorize" EventName="Click" />
                                                <Ajax:AsyncPostBackTrigger ControlID="btnAmend" EventName="Click" />
                                                <Ajax:AsyncPostBackTrigger ControlID="ddlAssetWOAmendNO" EventName="SelectedIndexChanged" />
                                                <Ajax:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                            </Triggers>
                                        </Ajax:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="squareboxcontent">
                            <Ajax:UpdatePanel runat="server" ID="upSOHeader" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblfixWoNo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, AssetWONo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAssetWoNo" Width="90%" CssClass="csstxtboxReadonly" MaxLength="32"
                                                    runat="server" OnTextChanged="txtAssetWoNo_TextChanged"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblfixAssetWOAmendNo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, AssetWOAmendNo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList CssClass="cssDropDown" ID="ddlAssetWOAmendNO" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlAssetWOAmendNO_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hfIsMAXAssetWOAmendNo" runat="server" />
                                                <asp:TextBox ID="txtAssetWOAmendDate" CssClass="csstxtboxReadonly" runat="server"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: top;" ID="HlimgAssetWOAmendDate" runat="server"
                                                    Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblfixAmendWef" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, WithEffectiveFromDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtWefdt" CssClass="csstxtboxRequired" runat="server"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: top;" ID="hlWefdt" runat="server" Height="19px"
                                                    Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CEWefdt" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtWefdt"
                                                    PopupButtonID="hlWefdt" Enabled="True"></AjaxToolKit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblfixClientCode" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtClientCode" CssClass="csstxtboxRequired" MaxLength="16" AutoPostBack="true"
                                                    runat="server" OnTextChanged="TxtClientCode_TextChanged"></asp:TextBox>
                                                <asp:TextBox ID="txtClientName" CssClass="csstxtboxReadonly" Width="61%" ReadOnly="true"
                                                    runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="ImgBtnSearchClient" Height="18px" Width="16px" ImageUrl="../Images/icosearch.gif"
                                                    runat="server" />
                                            </td>
                                        </tr><tr>
                                            <td align="right">
                                                <asp:Label ID="txtasmtBillingID" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, ClientBillingAddress %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:DropDownList CssClass="cssDropDownRequired" Width="98%" ID="ddlAsmtBillingId"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInvoiceType" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, BillingPattern %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlInvoiceType" CssClass="cssDropDown" runat="server" Width="130px">
                                                    <asp:ListItem Text="<%$Resources:Resource,InvTypFixed%>" Value="FIXED"></asp:ListItem>
                                                    <asp:ListItem Text="<%$Resources:Resource,InvTypActual%>" Value="ACTUAL"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRemarks" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox CssClass="csstxtbox" ID="txtRemarks" Width="98%" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 2px;"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 1px; background-color: Gray;"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 2px;"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 1px;">
                                                <div>
                                                    <table>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblfixTerminationDate" CssClass="cssLabel" runat="server" Style="display: none"
                                                                    Text="<%$ Resources:Resource, TerminationDate %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtTerminationDate" CssClass="csstxtbox" runat="server" Style="display: none"></asp:TextBox>
                                                                <asp:HyperLink Style="vertical-align: top; display: none" ID="HlimgTerminationDate"
                                                                    runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                                <AjaxToolKit:CalendarExtender ID="CETerminationDate" Format="dd-MMM-yyyy" runat="server"
                                                                    TargetControlID="txtTerminationDate" PopupButtonID="HlimgTerminationDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblfixTerminationReason" CssClass="cssLabel" runat="server" Style="display: none"
                                                                    Text="<%$ Resources:Resource, TerminationReason %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtTerminationReason" CssClass="csstxtbox" MaxLength="100" Style="display: none"
                                                                    runat="server"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblfixTerminatedBy" CssClass="cssLabel" runat="server" Style="display: none"
                                                                    Text="<%$ Resources:Resource, TerminatedBy %>"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtTerminatedBy" CssClass="csstxtbox" MaxLength="20" Style="display: none"
                                                                    runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="6">
                                                <asp:Button ID="btnEdit" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Edit %>"
                                                    OnClick="BtnEdit_Click" />
                                                <asp:Button ID="btnSave" runat="server" OnClientClick="javascript:HideButton(this);"
                                                    CssClass="cssButton" Text="<%$ Resources:Resource, Save %>" OnClick="BtnSave_Click" />
                                                <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Update %>"
                                                    OnClick="BtnUpdate_Click" />
                                                <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Delete %>"
                                                    OnClick="BtnDelete_Click" />
                                                <asp:Button ID="btnCancel" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Cancel %>"
                                                    OnClick="BtnCancel_Click" />
                                                <asp:Button ID="btnAmend" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, btnAmend %>"
                                                    OnClick="BtnAmendClick" />
                                                <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, btnAuthorize %>"
                                                    OnClick="BtnAuthorize_Click" />
                                                <asp:Button ID="btnBack" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, WorkOrderList %>"
                                                    Text=" <%$ Resources:Resource, WorkOrderList%>" OnClick="BtnBackClick" />
                                                <asp:Button ID="btnContract" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ContractMaster %>"
                                                    Text=" <%$ Resources:Resource, ContractMaster %>" OnClick="BtnContract_Click" />
                                                <asp:Button ID="btnAsmtCreation" Visible="false" Width="150px" runat="server" CssClass="cssButton"
                                                    ToolTip="<%$ Resources:Resource, PostAndDeploymentDetails %>" Text="<%$ Resources:Resource, PostAndDeploymentDetails %>"
                                                    OnClick="BtnAsmtCreationClick" />
                                                <asp:Button ID="btnLoadParentPage" runat="server" Style="display: none" OnClick="BtnLoadParentPageClick" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </Ajax:UpdatePanel>
                        </div>
                    </div>
                </div>
                <table>
                    <tr>
                        <td>
                            <Ajax:UpdatePanel runat="server" ID="upError" UpdateMode="Always">
                                <ContentTemplate>
                                    <div id="divErrorMsg" style="width: 550px; height: 25px; position: absolute; left: 30%; top: 35%; background-color: Transparent;">
                                        <asp:Label Style="border-width: 0px; border-style: solid; background-color: #d4cfcf; font-size: large; z-index: 800;" EnableViewState="false" ID="lblErrorMsg" runat="server"
                                            CssClass="csslblErrMsg" onclick="javascript:this.style.display = 'none';"></asp:Label>
                                    </div>
                                </ContentTemplate>
                            </Ajax:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <AjaxToolKit:TabContainer Style="text-align: left;" Width="100%" runat="server" ID="TabContainer1"
        ActiveTabIndex="0" AutoPostBack="false">
        <AjaxToolKit:TabPanel Style="text-align: left;" ScrollBars="Both" Width="100%" ID="PanelSoService" runat="server" HeaderText="<%$ Resources:Resource, ServiceDetails %>">
            <ContentTemplate>
                <div id="Div2" style="overflow: auto; width: 100%; height: 310px; overflow-x: auto;">
                    <asp:UpdatePanel ID="upSOService" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hiddenFieldAsmtLocId" runat="server"/>
                            <asp:HiddenField ID="hfspDecimalPlace" runat="server" Value="{0:n2}" />
                            <asp:HiddenField ID="hfDefaultPageSize" runat="server" Value="6" />
                            <asp:HiddenField ID="hfTotalRowCount" runat="server" Value="0" />

                           <%-- OnDataBound="gvWorkOrderDetails_DataBound" OnPageIndexChanging="gvWorkOrderDetails_PageIndexChanging"
                                        OnRowCancelingEdit="gvWorkOrderDetails_RowCancelingEdit" OnRowCommand="gvWorkOrderDetails_RowCommand"
                                        OnRowDataBound="gvWorkOrderDetails_RowDataBound" OnRowDeleting="gvWorkOrderDetails_RowDeleting"
                                        OnRowEditing="gvWorkOrderDetails_RowEditing" OnRowUpdating="gvWorkOrderDetails_RowUpdating"
                                        OnSorting="gvWorkOrderDetails_Sorting"--%>

                            <asp:GridView ID="gvWorkOrderDetails" runat="server" AllowPaging="true" AllowSorting="true"
                                        AutoGenerateColumns="False" CellPadding="0" CellSpacing="0" CssClass="GridViewStyle"
                                        GridLines="None" OnDataBound="gvWorkOrderDetails_DataBound" OnPageIndexChanging="gvWorkOrderDetails_PageIndexChanging"
                                        OnRowCancelingEdit="gvWorkOrderDetails_RowCancelingEdit" OnRowCommand="gvWorkOrderDetails_RowCommand"
                                        OnRowDataBound="gvWorkOrderDetails_RowDataBound" OnRowDeleting="gvWorkOrderDetails_RowDeleting"
                                        OnRowEditing="gvWorkOrderDetails_RowEditing" OnRowUpdating="gvWorkOrderDetails_RowUpdating"
                                        OnSorting="gvWorkOrderDetails_Sorting" PageSize="6" ShowFooter="true" ShowHeader="true"
                                        Visible="true" Width="320%">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblaction" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDeployment" runat="server" CommandName="Deployment" Height="16px"
                                                        ImageUrl="~/Images/employee-scheduling-enable.png" ToolTip="<%$ Resources:Resource, Deployment %>"
                                                        Width="16px" />
                                                    <asp:ImageButton ID="imgBtnSkills" runat="server" CommandName="Skills" Height="16px"
                                                        ImageUrl="~/Images/employee-skills.png" ToolTip="<%$ Resources:Resource, Skills %>"
                                                        Width="16px" />
                                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" CssClass="cssImgButton"
                                                            ImageUrl="../Images/Edit.gif" ToolTip="<%$ Resources:Resource, Edit %>"
                                                            />
                                                    <asp:ImageButton ID="ImgbtnDelete" runat="server" CommandName="Delete" CssClass="cssImgButton"
                                                        Height="16px" ImageUrl="../Images/Delete.gif" ToolTip="<%$ Resources:Resource, Delete %>"
                                                        Width="16px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CommandName="Update" CssClass="cssImgButton"
                                                            ImageUrl="../Images/Save.gif" ToolTip="<%$ Resources:Resource, Update %>"
                                                        ValidationGroup="vgCEdit" />
                                                    <asp:ImageButton ID="ImgbtnCancel" runat="server" CommandName="Cancel" CssClass="cssImgButton"
                                                            ImageUrl="../Images/Cancel.gif" ToolTip="<%$ Resources:Resource, Cancel %>"/>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="imgbtnAdd" runat="server" CommandName="Add" CssClass="cssImgButton"
                                                        ImageUrl="../Images/AddNew.gif" ToolTip="<%$ Resources:Resource, Save %>"
                                                        ValidationGroup="vgCFooter" />
                                                    <asp:ImageButton ID="ImgbtnReset" runat="server" CommandName="Reset" CssClass="cssImgButton"
                                                        ImageUrl="../Images/Reset.gif" ToolTip="<%$ Resources:Resource, Reset %>"/>
                                                </FooterTemplate>
                                                <ItemStyle Width="3%"/>
                                                <HeaderStyle Width="3%"/>
                                                <FooterStyle Width="3%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrAssetWoLineNo" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, SerialNumber %>"
                                                        Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvAssetWoLineNo" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "AssetWoLineNo").ToString()%>'
                                                        Width="100%"></asp:Label>
                                                    <asp:HiddenField ID="hiddenFieldAssetWOShift" runat="server" Value='<%#Eval("AssetWOShift")%>' />
                                                    <asp:HiddenField ID="hfAssetWoLineNo" runat="server" Value='<%#Eval("IsAssetWoLineExists")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblgvAssetWoLineNo" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "AssetWoLineNo").ToString()%>'
                                                        Width="100%"></asp:Label>
                                                    <asp:HiddenField ID="hiddenFieldAssetWOShift" runat="server" Value='<%#Eval("AssetWOShift")%>' />
                                                    <%--//TaskId 711--%>
                                                    <asp:HiddenField ID="hfAssetWoLineNo" runat="server" Value='<%#Eval("IsAssetWoLineExists")%>' />
                                                </EditItemTemplate>
                                                <ItemStyle Width="3%" />
                                                <HeaderStyle Width="3%" />
                                                <FooterStyle Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource, AsmtID %>" SortExpression="AsmtId">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrAsmtID" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Assignment %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldAsmtId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AsmtID").ToString()%>' />
                                                    <asp:Label ID="lblgvAsmtId" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtIDAdd").ToString()%>'
                                                        Width="100%" ToolTip='<%# Bind("LocationDesc") %>'> </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldAsmtId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AsmtID").ToString()%>' />
                                                    <asp:DropDownList ID="ddlgvAsmtId" runat="server" AutoPostBack="true" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="DdlgvAsmtIdET_SelectedIndexChanged" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlgvAsmtId" runat="server" AutoPostBack="true" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="DdlgvAsmtIdFT_SelectedIndexChanged" Width="100%">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="9%" />
                                                <HeaderStyle Width="9%" />
                                                <FooterStyle Width="9%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource, PostDesc %>" SortExpression="PostAutoId">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldPostAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PostAutoId").ToString()%>' />
                                                    <asp:Label ID="lblgvPostCode" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldPostAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PostAutoId").ToString()%>' />
                                                    <asp:DropDownList ID="ddlgvPostCode" runat="server" AutoPostBack="true" CssClass="cssDropDown" OnSelectedIndexChanged="ddlgvPostCodeET_SelectedIndexChanged" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlgvPostCode" runat="server" AutoPostBack="true" CssClass="cssDropDown" OnSelectedIndexChanged="ddlgvPostCodeFT_SelectedIndexChanged" Width="80%">
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="imgbtnPost" runat="server" CommandName="Post" CssClass="cssImgButton"
                                                        Height="16px" ImageUrl="../Images/plus.png" ToolTip="<%$ Resources:Resource, CreatePost %>"
                                                        Width="16px" />
                                                </FooterTemplate>
                                                <ItemStyle Width="8%" />
                                                <HeaderStyle Width="8%" />
                                                <FooterStyle Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrAssetName" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, AssetName %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvAssetName" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "AssetName").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldAssetName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AssetAutoId").ToString()%>' />
                                                    <asp:DropDownList ID="ddlAssetName" runat="server" AutoPostBack="true" CssClass="cssDropDown" OnSelectedIndexChanged="ddlAssetNameET_SelectedIndexChanged" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlAssetName" runat="server" AutoPostBack="true" CssClass="cssDropDown" OnSelectedIndexChanged="ddlAssetNameFT_SelectedIndexChanged" Width="100%">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="6%" />
                                                <HeaderStyle Width="6%" />
                                                <FooterStyle Width="6%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrAssetServiceTypeName" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, AssetServiceType %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvAssetServiceTypeName" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "AssetServiceTypeName").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldAssetServiceTypeName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AssetServiceTypeAutoId").ToString()%>' />
                                                    <asp:DropDownList ID="ddlAssetServiceTypeName" runat="server" CssClass="cssDropDown" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlAssetServiceTypeName" runat="server" CssClass="cssDropDown" Width="100%">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="6%" />
                                                <HeaderStyle Width="6%" />
                                                <FooterStyle Width="6%" />
                                            </asp:TemplateField>
                                           <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrContractNumber" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, ContractNumber %>"
                                                        Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldContractNumber" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ContractNumber").ToString()%>' />
                                                    <asp:Label ID="lblgvContractNumber" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "ContractNumber").ToString()%>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldContractNumber" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ContractNumber").ToString()%>' />
                                                    <asp:DropDownList ID="ddlContractNumber" runat="server" AutoPostBack="True" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="DdlContractNumber_SelectedIndexChangedEdit" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlContractNumber" runat="server" AutoPostBack="True" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="DdlContractNumber_SelectedIndexChangedFooter" Width="100%">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="7%" />
                                                <HeaderStyle Width="7%" />
                                                <FooterStyle Width="7%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrWOLineStartDate" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, StartDate %>" Width="90%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvWOLineStartDate" runat="server" CssClass="cssLable" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("WOLineStartDate")) %>'
                                                        Width="60%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenfieldWOLineStartDate" runat="server" />
                                                    <asp:TextBox ID="txtWOLineStartDate" runat="server" Enabled="false" CssClass="csstxtboxRequired"
                                                        Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("WOLineStartDate")) %>' Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgWOLineStartDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;" Visible="false"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CEWOLineStartDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtWOLineStartDate" PopupButtonID="hlimgWOLineStartDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvWOLineStartDate" runat="server" ControlToValidate="txtWOLineStartDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:HiddenField ID="hiddenfieldWOLineStartDate" runat="server" />
                                                    <asp:TextBox ID="txtWOLineStartDate" runat="server" CssClass="csstxtboxRequired"
                                                        Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgWOLineStartDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CEWOLineStartDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtWOLineStartDate" PopupButtonID="hlimgWOLineStartDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvWOLineStartDate" runat="server" ControlToValidate="txtWOLineStartDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrWOLineEndDate" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EndDate %>"
                                                        Width="90%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvWOLineEndDate" runat="server" CssClass="cssLable" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("WOLineEndDate")) %>'
                                                        Width="60%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenfieldWOLineEndDate" runat="server" />
                                                    <asp:HiddenField ID="hiddenFieldPreviousWOLineEndDate" runat="server" Value='<%# String.Format("{0:dd-MMM-yyyy}",Eval("WOLineEndDate")) %>' />
                                                    <asp:TextBox ID="txtWOLineEndDate" runat="server" CssClass="csstxtboxRequired" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("WOLineEndDate")) %>'
                                                        Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgWOLineEndDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CEWOLineEndDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtWOLineEndDate" PopupButtonID="hlimgWOLineEndDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvWOLineEndDate" runat="server" ControlToValidate="txtWOLineEndDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:HiddenField ID="hiddenfieldWOLineEndDate" runat="server" />
                                                    <asp:TextBox ID="txtWOLineEndDate" runat="server" CssClass="csstxtboxRequired" Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgWOLineEndDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CEWOLineEndDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtWOLineEndDate" PopupButtonID="hlimgWOLineEndDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvWOLineEndDate" runat="server" ControlToValidate="txtWOLineEndDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrWOLineWefDate" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, WithEffectiveFromDate %>"
                                                        Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvWOLineWefDate" runat="server" CssClass="cssLable" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("WOLineWefDate")) %>'
                                                        Width="60%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtWOLineWefDate" runat="server" CssClass="csstxtboxRequired" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("WOLineWefDate")) %>'
                                                        Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgWOLineWefDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CEWOLineWefDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtWOLineWefDate" PopupButtonID="hlimgWOLineWefDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvWOLineWefDate" runat="server" ControlToValidate="txtWOLineWefDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtWOLineWefDate" runat="server" CssClass="csstxtboxRequired" Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgWOLineWefDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CEWOLineWefDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtWOLineWefDate" PopupButtonID="hlimgWOLineWefDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvWOLineWefDate" runat="server" ControlToValidate="txtWOLineWefDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrActive" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Active %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkBoxActive" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                        CssClass="cssCheckBox" Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="checkBoxActive" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                        CssClass="cssCheckBox" Enabled="false" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:CheckBox ID="checkBoxActive" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                </FooterTemplate>
                                                <ItemStyle Width="2%" />
                                                <HeaderStyle Width="2%" />
                                                <FooterStyle Width="2%" />
                                            </asp:TemplateField>
                                             <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrBillable" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Billable %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkBoxBillable" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Billable").ToString())%>'
                                                        CssClass="cssCheckBox" Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="checkBoxBillable" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Billable").ToString())%>'
                                                        CssClass="cssCheckBox" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:CheckBox ID="checkBoxBillable" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                </FooterTemplate>
                                                <ItemStyle Width="3%" />
                                                <HeaderStyle Width="3%" />
                                                <FooterStyle Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrRate" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Rate %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvRate" runat="server" CssClass="cssLable" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("Rate")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtRate" runat="server" CssClass="csstxtbox" MaxLength="12"
                                                        Text='<%# String.Format(hfspDecimalPlace.Value,Eval("Rate")) %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtRate" runat="server" CssClass="csstxtbox" MaxLength="12"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrMonthlyBilling" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, MonthlyBilling %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvMonthlyBilling" runat="server" CssClass="cssLable" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonthlyBilling")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtMonthlyBilling" runat="server" CssClass="csstxtbox" MaxLength="12"
                                                        Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonthlyBilling")) %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtMonthlyBilling" runat="server" CssClass="csstxtbox" MaxLength="12"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrSoLineRemarks" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvSoLineRemarks" runat="server" CssClass="cssLable" Text='<%# Eval("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtSoLineRemarks" runat="server" CssClass="csstxtbox" MaxLength="20"
                                                        Text='<%#Eval("Remarks") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtSoLineRemarks" runat="server" CssClass="csstxtbox" MaxLength="20"></asp:TextBox>
                                                    <asp:ImageButton ID="imgbtnAdd1" runat="server" CommandName="Add" CssClass="cssImgButton"
                                                        Height="16px" ImageUrl="../Images/AddNew.gif" ToolTip="<%$Resources:Resource,Save %>"
                                                        ValidationGroup="vgCFooter" Visible="false" Width="16px" />
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument="First" CommandName="Page"
                                                ImageUrl="~/Images/firstpage.gif" />
                                            <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument="Prev" CommandName="Page"
                                                ImageUrl="~/Images/prevpage.gif" />
                                            <asp:Label ID="lblpage" runat="server" ForeColor="Black" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                            <asp:DropDownList ID="ddlPages" runat="server" AutoPostBack="True" CssClass="cssDropDown"
                                                OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblOf" runat="server" ForeColor="Black" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                            <asp:Label ID="lblPageCount" runat="server" ForeColor="Black"></asp:Label>
                                            <asp:ImageButton ID="ImageButton3" runat="server" CommandArgument="Next" CommandName="Page"
                                                ImageUrl="~/Images/nextpage.gif" />
                                            <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument="Last" CommandName="Page"
                                                ImageUrl="~/Images/lastpage.gif" />
                                            <asp:ImageButton ID="ImgbtnClearPaging" runat="server" CssClass="cssImgButton" Height="16px" ToolTip="Remove Paging"
                                                ImageUrl="../Images/Cancel.gif" OnClick="ImgbtnClearPaging_Click" Width="16px" />
                                            <asp:ImageButton ID="ImgbtnApplyPaging" runat="server" CssClass="cssImgButton" Height="16px" ToolTip="Apply Paging"
                                                ImageUrl="../Images/tick.gif" OnClick="ImgbtnApplyPaging_Click" Width="16px" />
                                        </PagerTemplate>
                                    </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAuthorize" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnAmend" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="ddlAssetWOAmendNO" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
    </AjaxToolKit:TabContainer>
    <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" language="javascript" src="../PageJS/AssetWorkOrderMaster.js"></script>
    <script language="javascript" type="text/javascript">
        function ControlInitializer() {
            this.btnLoadParentPage = document.getElementById('<%= btnLoadParentPage.ClientID %>');
        }
    </script>
</asp:Content>