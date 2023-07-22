<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="SaleOrderMaster.aspx.cs" Inherits="Sales_SaleOrderMaster"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <div style="width: 100%;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 25px; cursor: pointer; background-color:silver;" ">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 12px; width: 60%" align="right">
                                            <asp:Label ID="Label3" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SaleOrder %>"></asp:Label>
                                        </td>
                                        <td style="width: 40%" align="right">
                                            <Ajax:UpdatePanel runat="server" ID="upSOStatus" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Label Width="130px" ID="lblfixSoStatus" CssClass="cssLabelHeader" runat="server"
                                                        Text="<%$ Resources:Resource, SOStatus %>"></asp:Label>
                                                    <asp:Label Width="130px" Style="font-weight: bold;" ID="lblSOStatus" CssClass="csstxtboxReadonly"
                                                        runat="server"></asp:Label><asp:HiddenField ID="hiddenFieldSoStatus" runat="server" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <Ajax:AsyncPostBackTrigger ControlID="btnAuthorize" EventName="Click" />
                                                    <Ajax:AsyncPostBackTrigger ControlID="btnAmend" EventName="Click" />
                                                    <Ajax:AsyncPostBackTrigger ControlID="ddlSOAmendNO" EventName="SelectedIndexChanged" />
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
                                                <asp:Label ID="lblfixSoNo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, SONo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSoNo" Width="90%" CssClass="csstxtboxReadonly" MaxLength="32"
                                                    runat="server" OnTextChanged="TxtSoNo_TextChanged"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblfixSOAmendNo" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, SOAmendNo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList CssClass="cssDropDown" ID="ddlSOAmendNO" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DdlSOAmendNO_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hfIsMAXSOAmendNo" runat="server" />
                                                <asp:TextBox ID="txtSOAmendDate" CssClass="csstxtboxReadonly" runat="server"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: top;" ID="HlimgSoAmendDate" runat="server"
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
                                                    PopupButtonID="hlWefdt" Enabled="True">
                                                </AjaxToolKit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblfixSOType" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, SOType %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList CssClass="cssDropDown" Width="92%" ID="ddlSoType" runat="server">
                                                </asp:DropDownList>
                                            </td>
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
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblfixCenterlizeBilling" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, centralizeBillingBranch %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox CssClass="cssCheckBox" ID="cbCenterlizeBilling" runat="server" AutoPostBack="True"
                                                    OnCheckedChanged="CbCenterlizeBilling_CheckedChanged" />
                                                <asp:TextBox ID="txtBillingLocation" Width="60%" CssClass="csstxtbox" runat="server"
                                                    ReadOnly="True"></asp:TextBox>
                                                <asp:ImageButton ID="ImgBtnSearchLocation" Height="18px" Width="16px" ImageUrl="../Images/icosearch.gif"
                                                    runat="server" />
                                                <asp:HiddenField ID="hfBillingLocationAutoID" runat="server" />
                                                <asp:HiddenField ID="hfIsMultipleLocation" runat="server" Value="0" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="txtasmtBillingID" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, ClientBillingAddress %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:DropDownList CssClass="cssDropDownRequired" Width="90%" ID="ddlAsmtBillingId"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblInvoiceType" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, BillingPattern %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlInvoiceType" CssClass="cssDropDown" runat="server" Width="130px">
                                                    <asp:ListItem Text="<%$Resources:Resource,InvTypFixed%>" Value="FIXED"></asp:ListItem>
                                                    <asp:ListItem Text="<%$Resources:Resource,InvTypActual%>" Value="ACTUAL"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblRemarks" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox CssClass="csstxtbox" ID="txtRemarks" Width="89%" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="right">
                                                <asp:Label ID="Label2" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource, QuotationNo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlGrade" CssClass="cssDropDown" runat="server" Width="130px">
                                               
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                
                                            </td>
                                            <td align="left" colspan="3">
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 2px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 1px; background-color: Gray;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 2px;">
                                            </td>
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
                                                                    TargetControlID="txtTerminationDate" PopupButtonID="HlimgTerminationDate" Enabled="True">
                                                                </AjaxToolKit:CalendarExtender>
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
                                                <asp:Button ID="btnBack" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, SaleOrderList %>"
                                                    Text=" <%$ Resources:Resource, SaleOrderList%>" OnClick="BtnBackClick" />
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
                                    <div id="divErrorMsg" style="width: 550px; height: 25px; position: absolute; left: 30%;
                                        top: 35%; background-color: Transparent;">
                                        <asp:Label Style="border-width: 0px; border-style: solid; background-color: #d4cfcf; font-size:large; z-index: 800;" EnableViewState="false" ID="lblErrorMsg" runat="server"
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
                        <div class="squareboxgradientcaption" style="height: 25px; background-color:silver;" ">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 60%" align="right">
                                            <asp:Label ID="lblDivHdr2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ServiceDetails %>"></asp:Label>
                                        </td>
                                        <td style="width: 40%" align="right">
                                            <asp:UpdatePanel ID="upSOServiceValue" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblFixSOLineTotalValue" runat="server" CssClass="cssLabelHeader" Style="text-align: right"
                                                        Text="<%$ Resources:Resource, TotalValue %>"></asp:Label>
                                                    <asp:Label ID="lblDefaultCurrency" runat="server" CssClass="cssLabelHeader"
                                                        Style="text-align: right" Text=""></asp:Label>
                                                    <asp:Label ID="lblSOLineTotalValue" runat="server" CssClass="csstxtboxReadonly" Style="text-align: right;
                                                        font-weight: bold;"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                        </div>
                        <div id="Div2" style="overflow: auto; width: 100%; height: 310px; overflow-x: auto;">
                            <asp:UpdatePanel ID="upSOService" runat="server">
                                <ContentTemplate>
                                    <asp:HiddenField ID="hiddenFieldAsmtIdFilter" runat="server" />
                                    <asp:HiddenField ID="hiddenFieldAsmtLocId" runat="server"/>
                                    <asp:HiddenField ID="hfspDecimalPlace" runat="server" Value="{0:n2}" />
                                    <asp:HiddenField ID="hfDefaultPageSize" runat="server" Value="6" />
                                    <asp:HiddenField ID="hfTotalRowCount" runat="server" Value="0" />
                                    <asp:GridView ID="gvSaleOrderDetails" runat="server" AllowPaging="true" AllowSorting="true"
                                        AutoGenerateColumns="False" CellPadding="0" CellSpacing="0" CssClass="GridViewStyle"
                                        GridLines="None" OnDataBound="GvSaleOrderDetails_DataBound" OnPageIndexChanging="GvSaleOrderDetails_PageIndexChanging"
                                        OnRowCancelingEdit="GvSaleOrderDetails_RowCancelingEdit" OnRowCommand="GvSaleOrderDetails_RowCommand"
                                        OnRowDataBound="GvSaleOrderDetails_RowDataBound" OnRowDeleting="GvSaleOrderDetails_RowDeleting"
                                        OnRowEditing="GvSaleOrderDetails_RowEditing" OnRowUpdating="GvSaleOrderDetails_RowUpdating"
                                        OnSorting="GvSaleOrderDetails_Sorting" PageSize="6" ShowFooter="true" ShowHeader="true"
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
                                                    <asp:Label ID="lblgvhdrSOLineNo" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, SerialNumber %>"
                                                        Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvSoLineNo" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "SOLineNo").ToString()%>'
                                                        Width="100%"></asp:Label>
                                                    <asp:HiddenField ID="hiddenFieldSoDeptShift" runat="server" Value='<%#Eval("SoDeptShift")%>' />
                                                    <asp:HiddenField ID="hfSolineNo" runat="server" Value='<%#Eval("IsSoLineExists")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblgvSoLineNo" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "SOLineNo").ToString()%>'
                                                        Width="100%"></asp:Label>
                                                    <asp:HiddenField ID="hiddenFieldSoDeptShift" runat="server" Value='<%#Eval("SoDeptShift")%>' />
                                                    <%--//TaskId 711--%>
                                                    <asp:HiddenField ID="hfSolineNo" runat="server" Value='<%#Eval("IsSoLineExists")%>' />
                                                </EditItemTemplate>
                                                <ItemStyle Width="3%" />
                                                <HeaderStyle Width="3%" />
                                                <FooterStyle Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrTypeOfService" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, TypeOfService %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvTypeOfService" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "TypeOfService").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldTypeOfService" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TypeOfService").ToString()%>' />
                                                    <asp:DropDownList ID="ddlTypeOfService" runat="server" CssClass="cssDropDown" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlTypeOfService" runat="server" CssClass="cssDropDown" Width="100%">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="6%" />
                                                <HeaderStyle Width="6%" />
                                                <FooterStyle Width="6%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource, AsmtID %>" SortExpression="AsmtId">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrAsmtID" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Assignment %>"></asp:Label>
                                                    <asp:TextBox ID="txtFilterAsmtId" runat="server" CssClass="csstxtbox" Style="background-color:transparent"
                                                        Width="60%"></asp:TextBox>
                                                    <asp:ImageButton ID="imgBtnFilterAsmtId" runat="server" CommandName="FilterAsmtId"
                                                        Height="16px" ImageUrl="~/Images/filter.png" Width="16px" />
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
                                                    <asp:DropDownList ID="ddlgvPostCode" runat="server" CssClass="cssDropDown" Width="100%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlgvPostCode" runat="server" CssClass="cssDropDown" Width="80%">
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
                                                    <asp:Label ID="lblgvhdrServiceCategoryCode" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, ServiceCategoryCode %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvServiceCategoryCode" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceCategoryCode").ToString()%>'
                                                        Width="92%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtServiceCategoryCode" runat="server" CssClass="csstxtbox" MaxLength="11"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ServiceCategoryCode").ToString()%>'
                                                        Width="92%"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtServiceCategoryCode" runat="server" CssClass="csstxtbox" MaxLength="11"
                                                        Width="92%"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:Resource, SORank %>" SortExpression="SORank">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvSORank" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "SORank").ToString()%>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldSoRank" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SORank").ToString()%>' />
                                                    <asp:DropDownList ID="ddlgvSoRank" runat="server" AutoPostBack="true" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="DdlgvSoRank_SelectedIndexChangedEdit" Width="95%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlgvSoRank" runat="server" AutoPostBack="true" CssClass="cssDropDown"
                                                        OnSelectedIndexChanged="DdlgvSoRank_SelectedIndexChangedFooter" Width="95%">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="6%" />
                                                <HeaderStyle Width="6%" />
                                                <FooterStyle Width="6%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrBillingDesignation" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, BillingDesignation %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvBillingDesignation" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "BillingDesignation").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtBillingDesignation" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="50" Text='<%# DataBinder.Eval(Container.DataItem, "BillingDesignation").ToString()%>'
                                                        Width="85%"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtBillingDesignation" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="50" Width="85%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvBillingDesignation" runat="server" ControlToValidate="txtBillingDesignation"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrNoOfPost" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, NoOfPost %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvNoOfPost" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfPost").ToString()%>'
                                                        Width="0%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNoOfPost" runat="server" CssClass="csstxtboxRequired" MaxLength="4"
                                                        Text="1" Width="0%"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtNoOfPost" runat="server" CssClass="csstxtboxRequired" MaxLength="4"
                                                        Text="1" Width="0%"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="0%" />
                                                <HeaderStyle Width="0%" />
                                                <FooterStyle Width="0%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrHours" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Hours %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvHours" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "Hours").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlHours" runat="server" CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hiddenFieldHours" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Hours").ToString()%>' />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlHours" runat="server" CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="0%" />
                                                <HeaderStyle Width="0%" />
                                                <FooterStyle Width="0%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrDeploymentPattern" runat="server" CssClass="cssLabelHeader"
                                                        Text="Deployment Pattern"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvDeploymentPattern" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "DeploymentPattern").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldDeploymentPattern" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DeploymentPattern").ToString()%>' />
                                                    <asp:DropDownList ID="ddlDeploymentPattern" runat="server" CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlDeploymentPattern" runat="server" CssClass="cssDropDown">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="0%" />
                                                <HeaderStyle Width="0%" />
                                                <FooterStyle Width="0%" />
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
                                                    <asp:CheckBox ID="checkBoxBillable" OnCheckedChanged= "checkBoxBillable_OnCheckedChanged"   AutoPostBack="true" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Billable").ToString())%>'
                                                        CssClass="cssCheckBox" />
                                                    <asp:HiddenField ID="hfMinWages" runat="server" Value='<%# String.Format(hfspDecimalPlace.Value,Eval("MinWages")) %>' /> 
                                                    <asp:HiddenField ID="hfDailyMinWages" runat="server" Value='<%# String.Format(hfspDecimalPlace.Value,Eval("DailyMinWages")) %>' />
                                                    <asp:HiddenField ID="hfDailySellingRate" runat="server" Value='<%# String.Format(hfspDecimalPlace.Value,Eval("DailySellingRate")) %>' />                                                                                                             
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
                                                    <asp:Label ID="lblgvhdrChargeRatePerHrs" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, SellingPrice %>" Width="95%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvChargeRatePerHrs" runat="server" CssClass="cssLable" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ChargeRatePerHour")) %>'
                                                        Width="70%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtChargeRatePerHrs" runat="server" CssClass="csstxtboxRequired"
                                                        MaxLength="10" Enabled="false" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("ChargeRatePerHour")) %>'
                                                        Width="70%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvChargeRatePerHrs" runat="server" ControlToValidate="txtChargeRatePerHrs"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtChargeRatePerHrs" runat="server" Enabled="false" CssClass="csstxtboxRequired"
                                                        MaxLength="10" Text="1" Width="70%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvChargeRatePerHrs" runat="server" ControlToValidate="txtChargeRatePerHrs"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrMinWages" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, PayRatePerHour %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvMinWages" runat="server" CssClass="cssLable" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MinWages")) %>'></asp:Label>
                                                    <asp:HiddenField ID="hfMinWages" runat="server" Value='<%# String.Format(hfspDecimalPlace.Value,Eval("MinWages")) %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtMinWages" runat="server" CssClass="csstxtbox" MaxLength="10"
                                                        Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MinWages")) %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvMinWages" runat="server" ControlToValidate="txtMinWages"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtMinWages" runat="server" CssClass="csstxtbox" MaxLength="10"
                                                        Text="1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvMinWages" runat="server" ControlToValidate="txtMinWages"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="0%" />
                                                <HeaderStyle Width="0%" />
                                                <FooterStyle Width="0%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrOtherAllowances" runat="server" CssClass="cssLabelHeader"
                                                        Text="Allowance" Width="95%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvOtherAllowances" runat="server" CssClass="cssLable" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("OtherAllowances")) %>'
                                                        Width="70%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtOtherAllowances" runat="server" CssClass="csstxtbox" MaxLength="5"
                                                        Text='<%# String.Format(hfspDecimalPlace.Value,Eval("OtherAllowances")) %>' Width="70%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvOtherAllowances" runat="server" ControlToValidate="txtOtherAllowances"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtOtherAllowances" runat="server" CssClass="csstxtbox" MaxLength="5"
                                                        Width="70%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvOtherAllowances" runat="server" ControlToValidate="txtOtherAllowances"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrIsAllowanceBillable" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, IsAllowanceBillable %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkBoxIsAllowanceBillable" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsAllowanceBillable").ToString())%>'
                                                        CssClass="cssCheckBox" Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="checkBoxIsAllowanceBillable" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsAllowanceBillable").ToString())%>'
                                                        CssClass="cssCheckBox" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:CheckBox ID="checkBoxIsAllowanceBillable" runat="server" CssClass="cssCheckBox" />
                                                </FooterTemplate>
                                                <ItemStyle Width="3%" />
                                                <HeaderStyle Width="3%" />
                                                <FooterStyle Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrAllowancesMode" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, AllowancesMode %>"
                                                        Width="80%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldAllowancesMode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AllowancesMode").ToString()%>' />
                                                    <asp:Label ID="lblgvAllowancesMode" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "AllowancesMode").ToString()%>'
                                                        Width="80%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenFieldAllowancesMode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AllowancesMode").ToString()%>' />
                                                    <asp:DropDownList ID="ddlAllowancesMode" runat="server" CssClass="cssDropDown" Width="80%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlAllowancesMode" runat="server" CssClass="cssDropDown" Width="80%">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrSOLineStartDate" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, StartDate %>" Width="90%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvSOLineStartDate" runat="server" CssClass="cssLable" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineStartDate")) %>'
                                                        Width="60%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenfieldSoLineStartDate" runat="server" />
                                                    <asp:TextBox ID="txtSoLineStartDate" runat="server" Enabled="false" CssClass="csstxtboxRequired"
                                                        Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineStartDate")) %>' Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgSoLineStartDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;" Visible="false"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CESoLineStartDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtSoLineStartDate" PopupButtonID="hlimgSoLineStartDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvSOLineStartDate" runat="server" ControlToValidate="txtSoLineStartDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:HiddenField ID="hiddenfieldSoLineStartDate" runat="server" />
                                                    <asp:TextBox ID="txtSoLineStartDate" runat="server" CssClass="csstxtboxRequired"
                                                        Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgSoLineStartDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CESoLineStartDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtSoLineStartDate" PopupButtonID="hlimgSoLineStartDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvSOLineStartDate" runat="server" ControlToValidate="txtSoLineStartDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrSOLineEndDate" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EndDate %>"
                                                        Width="90%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvSOLineEndDate" runat="server" CssClass="cssLable" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineEndDate")) %>'
                                                        Width="60%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hiddenfieldSoLineEndDate" runat="server" />
                                                    <asp:HiddenField ID="hiddenFieldPreviousSoLineEndDate" runat="server" Value='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineEndDate")) %>' />
                                                    <asp:TextBox ID="txtSoLineEndDate" runat="server" CssClass="csstxtboxRequired" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineEndDate")) %>'
                                                        Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgSoLineEndDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CESoLineEndDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtSoLineEndDate" PopupButtonID="hlimgSoLineEndDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvSOLineEndDate" runat="server" ControlToValidate="txtSoLineEndDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:HiddenField ID="hiddenfieldSoLineEndDate" runat="server" />
                                                    <asp:TextBox ID="txtSoLineEndDate" runat="server" CssClass="csstxtboxRequired" Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgSoLineEndDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CESoLineEndDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtSoLineEndDate" PopupButtonID="hlimgSoLineEndDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvSOLineEndDate" runat="server" ControlToValidate="txtSoLineEndDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCFooter"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrSOLineWefDate" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, WithEffectiveFromDate %>"
                                                        Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvSOLineWefDate" runat="server" CssClass="cssLable" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineWefDate")) %>'
                                                        Width="60%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtSoLineWefDate" runat="server" CssClass="csstxtboxRequired" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SOLineWefDate")) %>'
                                                        Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgSoLineWefDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CESoLineWefDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtSoLineWefDate" PopupButtonID="hlimgSoLineWefDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvSOLineWefDate" runat="server" ControlToValidate="txtSoLineWefDate"
                                                        ErrorMessage="*" SetFocusOnError="true" ValidationGroup="vgCEdit"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtSoLineWefDate" runat="server" CssClass="csstxtboxRequired" Width="60%"></asp:TextBox>
                                                    <asp:HyperLink ID="hlimgSoLineWefDate" runat="server" ImageUrl="../Images/pdate.gif"
                                                        Style="vertical-align: top;"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CESoLineWefDate" Format="dd-MMM-yyyy" runat="server"
                                                        TargetControlID="txtSoLineWefDate" PopupButtonID="hlimgSoLineWefDate" Enabled="True">
                                                    </AjaxToolKit:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvSOLineWefDate" runat="server" ControlToValidate="txtSoLineWefDate"
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
                                                    <asp:Label ID="lblgvhdrMonthlyBilling" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, MonthlyBilling %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvMonthlyBilling" runat="server" CssClass="cssLable" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonthlyBilling")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtMonthlyBilling" runat="server" CssClass="csstxtbox" MaxLength="20"
                                                        Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MonthlyBilling")) %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtMonthlyBilling" runat="server" CssClass="csstxtbox" MaxLength="20"></asp:TextBox>
                                                    <asp:ImageButton ID="imgbtnAdd1" runat="server" CommandName="Add" CssClass="cssImgButton"
                                                        Height="16px" ImageUrl="../Images/AddNew.gif" ToolTip="<%$Resources:Resource,Save %>"
                                                        ValidationGroup="vgCFooter" Visible="false" Width="16px" />
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrMinProfitability" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, MinProfitability %>" Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvMinProfitability" runat="server" CssClass="cssLable" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MinProfitability")) %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtMinProfitability" runat="server" CssClass="csstxtbox" MaxLength="20"
                                                        Text='<%# String.Format(hfspDecimalPlace.Value,Eval("MinProfitability")) %>'
                                                        Width="95%"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtMinProfitability" runat="server" CssClass="csstxtbox" MaxLength="20"
                                                        Width="95%"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrOptimumProfitability" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, OptimumProfitability %>" Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvOptimumProfitability" runat="server" CssClass="cssLable" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("OptimumProfitability")) %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtOptimumProfitability" runat="server" CssClass="csstxtbox" MaxLength="20"
                                                        Text='<%# String.Format(hfspDecimalPlace.Value,Eval("OptimumProfitability")) %>'
                                                        Width="95%"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtOptimumProfitability" runat="server" CssClass="csstxtbox" MaxLength="20"
                                                        Width="95%"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrDaysInMonth" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, DaysInMonth %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvDaysInMonth" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "DaysInMonth").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDaysInMonth" runat="server" CssClass="csstxtboxRequired" MaxLength="5"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "DaysInMonth").ToString()%>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtDaysInMonth" runat="server" CssClass="csstxtboxRequired" MaxLength="5"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="0%" />
                                                <HeaderStyle Width="0%" />
                                                <FooterStyle Width="0%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrHoursInMonth" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, HoursInMonth %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvHoursInMonth" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "HoursInMonth").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtHoursInMonth" runat="server" CssClass="csstxtboxReadonly" MaxLength="10"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "HoursInMonth").ToString()%>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtHoursInMonth" runat="server" CssClass="csstxtboxReadonly" MaxLength="10"
                                                        Text="0"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="0%" />
                                                <HeaderStyle Width="0%" />
                                                <FooterStyle Width="0%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrTypeOfItem" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, TypeOfItem %>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvTypeOfItem" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "TypeOfItem").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTypeOfItem" runat="server" CssClass="csstxtbox" MaxLength="50"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "TypeOfItem").ToString()%>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtTypeOfItem" runat="server" CssClass="csstxtbox" MaxLength="50"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="0%" />
                                                <HeaderStyle Width="0%" />
                                                <FooterStyle Width="0%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrPostPosition" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, PostPosition %>"
                                                        Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvPostPosition" runat="server" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "PostPosition").ToString()%>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtPostPosition" runat="server" CssClass="csstxtbox" MaxLength="50"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "PostPosition").ToString()%>' Width="95%"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPostPosition" runat="server" CssClass="csstxtbox" MaxLength="50"
                                                        Width="95%"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <FooterStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrProfitabilityCheck" runat="server" CssClass="cssLabelHeader"
                                                        Text="<%$ Resources:Resource, PayRateType %>" Width="100%"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvPayRateType" runat="server" CssClass="cssLable" Width="100%"></asp:Label>
                                                    <asp:HiddenField ID="HFPayRateType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PayRateType").ToString()%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlPayRateType" CssClass="cssDropDown" Width="95%" runat="server"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlPayRateType_SelectedIndexChangedEdit">
                                                        <asp:ListItem Text="<%$ Resources:Resource, Normal %>" Value="Normal"></asp:ListItem>
                                                        <asp:ListItem Text="<%$ Resources:Resource, Post %>" Value="Post"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HFPayRateType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PayRateType").ToString()%>' />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlPayRateType" CssClass="cssDropDown" Width="95%" runat="server">
                                                        <asp:ListItem Text="<%$ Resources:Resource, Normal %>" Value="Normal"></asp:ListItem>
                                                        <asp:ListItem Text="<%$ Resources:Resource, Post %>" Value="Post"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle Width="8%" />
                                                <HeaderStyle Width="8%" />
                                                <FooterStyle Width="8%" />
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
                                    <asp:HiddenField ID="hiddenFieldHoursInMonth" runat="server" Value="0" />
                                    <asp:HiddenField ID="hfDaysInMonth" runat="server" Value="0" />
                                    <asp:HiddenField ID="hfRemainingDays" runat="server" />
                                    <asp:HiddenField ID="hfPayRateType" runat="server" />
                                        <asp:HiddenField ID="hfFixedBillingCheck" runat="server" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAuthorize" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnAmend" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlSOAmendNO" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                <asp:Label ID="Label1" runat="server" Visible="False" CssClass="csslblErrMsg" Text="<%$ Resources:Resource, UseTabScrollBar %>"></asp:Label>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
        <AjaxToolKit:TabPanel Style="text-align: left;" ScrollBars="Both" Width="100%" ID="PanelSoItem" runat="server" HeaderText="<%$ Resources:Resource, EquipmentDetails %>">
            <ContentTemplate>
                <div class="squareboxgradientcaption" style="height: 25px; background-color:silver;">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 60%"; align="right">
                                    <asp:Label ID="Label4" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EquipmentDetails %>"></asp:Label>
                                </td>
                                <td style="width: 40%" align="right">
                                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                                        <ContentTemplate>
                                            <asp:Label Style="text-align: right" ID="Label5" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, TotalValue %>"></asp:Label> 
                                            <asp:Label Style="text-align: right" ID="lblDefaultCurrency2" CssClass="cssLabelHeader" runat="server" Text=""></asp:Label>
                                            <asp:Label Style="text-align: right; font-weight: bold;" ID="lblSOItemTotalValue" CssClass="csstxtboxReadonly" runat="server"></asp:Label>
                                        </ContentTemplate>
                                    </Ajax:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                </div>
                <div id="Div4" style="overflow: auto; width: 100%; height: 310px; overflow-x: auto;">
                    <Ajax:UpdatePanel runat="server" ID="upSOItem" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView Width="1200px" ID="gvSOItemDetails" CssClass="GridViewStyle" runat="server"
                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="10"
                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GvSOItemDetails_RowCommand"
                                OnRowUpdating="GvSOItemDetails_RowUpdating" OnRowDeleting="GvSOItemDetails_RowDeleting"
                                OnRowEditing="GvSOItemDetails_RowEditing" OnPageIndexChanging="GvSOItemDetails_PageIndexChanging"
                                OnRowCancelingEdit="GvSOItemDetails_RowCancelingEdit" OnRowDataBound="GvSOItemDetails_RowDataBound">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                ToolTip="<%$ Resources:Resource, Delete %>" Height="16px" Width="16px" ImageUrl="../Images/Delete.gif" />
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                ToolTip="<%$ Resources:Resource, Edit %>" Height="16px" Width="16px" ImageUrl="../Images/Edit.gif" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="imgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                ValidationGroup="vgCEdit1" ToolTip="<%$ Resources:Resource, Update %>" Height="16px"
                                                Width="16px" ImageUrl="../Images/Save.gif" />
                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                ToolTip="<%$ Resources:Resource, Cancel %>" Height="16px" Width="16px" ImageUrl="../Images/Cancel.gif" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="imgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                ToolTip="<%$ Resources:Resource, Save %>" ValidationGroup="vgCFooter1" Height="16px"
                                                Width="16px" ImageUrl="../Images/AddNew.gif" />
                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                ToolTip="<%$ Resources:Resource, Reset %>" Height="15px" Width="15px" ImageUrl="../Images/Reset.gif" />
                                        </FooterTemplate>
                                        <ItemStyle Width="60px" />
                                        <HeaderStyle Width="60px" />
                                        <FooterStyle Width="60px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                        <HeaderStyle Width="20px" />
                                        <FooterStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrItemTypeCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ItemType %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfgvItemTypeCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ItemTypeCode").ToString()%>' />
                                            <asp:Label ID="lblgvItemTypeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemDesc").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="hfgvItemTypeCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ItemTypeCode").ToString()%>' />
                                            <asp:Label ID="lblgvItemTypeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemDesc").ToString()%>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" OnSelectedIndexChanged="DdlItemTypeCode_SelectedIndexChangedIDET"
                                                Width="140px" runat="server" ID="ddlItemTypeCode">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemStyle Width="150px" />
                                        <HeaderStyle Width="150px" />
                                        <FooterStyle Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrQty" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Qty %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvQty" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:n2}",Eval("Qty")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField runat="server" ID="hiddenFieldPreviousSoLineEndDate" Value='0' />
                                            <asp:TextBox Width="40px" ID="txtQty" AutoPostBack="true" OnTextChanged="TxtQty_TextChangedEdit"
                                                CssClass="csstxtboxRequired" MaxLength="12" runat="server" Text='<%# String.Format("{0:n2}",Eval("Qty")) %>'></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="rfvQty" ValidationGroup="vgCEdit1" SetFocusOnError="true" ControlToValidate="txtQty"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                        runat="server" ID="rvQty" Type="Double" SetFocusOnError="true" ValidationGroup="vgCEdit1"
                                                        ControlToValidate="txtQty" MinimumValue="0.1" MaximumValue="99999999.00" ErrorMessage="*"></asp:RangeValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox Width="40px" ID="txtQty" AutoPostBack="true" CssClass="csstxtboxRequired"
                                                OnTextChanged="TxtQty_TextChanged" MaxLength="12" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="rfvQty" ValidationGroup="vgCFooter1" SetFocusOnError="true" ControlToValidate="txtQty"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                        runat="server" ID="rvQty" Type="Double" SetFocusOnError="true" ValidationGroup="vgCFooter1"
                                                        ControlToValidate="txtQty" MinimumValue="0.1" MaximumValue="99999999.00" ErrorMessage="*"></asp:RangeValidator>
                                        </FooterTemplate>
                                        <ItemStyle Width="60px" />
                                        <HeaderStyle Width="60px" />
                                        <FooterStyle Width="60px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrRate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Rate %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvRate" CssClass="cssLable" runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("Rate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox Width="40px" ID="txtRate" CssClass="csstxtboxRequired" MaxLength="15"
                                                runat="server" Text='<%# String.Format(hfspDecimalPlace.Value,Eval("Rate")) %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvRate" ValidationGroup="vgCEdit1" SetFocusOnError="true"
                                                ControlToValidate="txtRate" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox Width="40px" ID="txtRate" CssClass="csstxtboxRequired" MaxLength="15"
                                                runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvRate" ValidationGroup="vgCFooter1"
                                                    SetFocusOnError="true" ControlToValidate="txtRate" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemStyle Width="60px" />
                                        <HeaderStyle Width="60px" />
                                        <FooterStyle Width="60px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrBillable" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Billable %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkBoxBillable" CssClass="cssCheckBox" Enabled="false" runat="server"
                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Billable").ToString())%>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="checkBoxBillable" OnCheckedChanged="checkBoxBillable_OnCheckedChanged"  AutoPostBack = "true" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Billable").ToString())%>' />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:CheckBox CssClass="cssCheckBox" ID="checkBoxBillable" Checked="true" runat="server" />
                                        </FooterTemplate>
                                        <ItemStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <FooterStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrActive" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Active %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkBoxActive" CssClass="cssCheckBox" Enabled="false" runat="server"
                                                Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="checkBoxActive" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:CheckBox ID="checkBoxActive" CssClass="cssCheckBox" Checked="true" runat="server" />
                                        </FooterTemplate>
                                        <ItemStyle Width="40px" />
                                        <HeaderStyle Width="40px" />
                                        <FooterStyle Width="40px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrItemStartDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, StartDate %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvItemStartDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ItemStartDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="hiddenFieldItemStartDate" runat="server" />
                                            <asp:TextBox Width="65px" ID="txtItemStartDate" CssClass="csstxtboxRequired" runat="server"
                                                Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ItemStartDate")) %>'></asp:TextBox><asp:HyperLink
                                                    Style="vertical-align: top; height: 16px; width: 22px;" ID="hlimgItemStartDate"
                                                    runat="server" ImageUrl="../Images/pdate.gif" Enabled="false"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CEItemStartDate" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtItemStartDate" PopupButtonID="hlimgItemStartDate" Enabled="false">
                                            </AjaxToolKit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvItemStartDate" ValidationGroup="vgCEdit1" SetFocusOnError="true"
                                                ControlToValidate="txtItemStartDate" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:HiddenField ID="hiddenFieldItemStartDate" runat="server" />
                                            <asp:TextBox Width="65px" ID="txtItemStartDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox><asp:HyperLink
                                                Style="vertical-align: top; height: 16px; width: 22px;" ID="hlimgItemStartDate"
                                                runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CEItemStartDate" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtItemStartDate" PopupButtonID="hlimgItemStartDate" Enabled="True">
                                            </AjaxToolKit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvItemStartDate" ValidationGroup="vgCFooter1" SetFocusOnError="true"
                                                ControlToValidate="txtItemStartDate" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemStyle Width="150px" />
                                        <HeaderStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrItemEndDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EndDate %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvItemEndDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ItemEndDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="hiddenFieldItemEndDate" runat="server" />
                                            <asp:TextBox Width="65px" ID="txtItemEndDate" CssClass="csstxtboxRequired" runat="server"
                                                Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ItemEndDate")) %>'></asp:TextBox><asp:HyperLink
                                                    Style="vertical-align: top; height: 16px; width: 22px;" ID="hlimgItemEndDate"
                                                    runat="server" ImageUrl="../Images/pdate.gif" Enabled="False"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CEItemEndDate" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtItemEndDate" PopupButtonID="hlimgItemEndDate" Enabled="False">
                                            </AjaxToolKit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvItemEndDate" ValidationGroup="vgCEdit1" SetFocusOnError="true"
                                                ControlToValidate="txtItemEndDate" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:HiddenField ID="hiddenFieldItemEndDate" runat="server" />
                                            <asp:TextBox Width="65px" ID="txtItemEndDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox><asp:HyperLink
                                                Style="vertical-align: top; height: 16px; width: 22px;" ID="hlimgItemEndDate"
                                                runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CEItemEndDate" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtItemEndDate" PopupButtonID="hlimgItemEndDate" Enabled="True">
                                            </AjaxToolKit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvItemEndDate" ValidationGroup="vgCFooter1" SetFocusOnError="true"
                                                ControlToValidate="txtItemEndDate" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemStyle Width="150px" />
                                        <HeaderStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrItemWefDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, WithEffectiveFromDate %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvItemWefDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ItemWefDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox Width="65px" ID="txtItemWefDate" CssClass="csstxtboxRequired" runat="server"
                                                Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ItemWefDate")) %>'></asp:TextBox><asp:HyperLink
                                                    Style="vertical-align: top; height: 16px; width: 22px;" ID="hlimgItemWefDate"
                                                    runat="server" ImageUrl="../Images/pdate.gif" Enabled="False"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CEItemWefDate" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtItemWefDate" PopupButtonID="hlimgItemWefDate" Enabled="False">
                                            </AjaxToolKit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvItemWefDate" ValidationGroup="vgCEdit1" SetFocusOnError="true"
                                                ControlToValidate="txtItemWefDate" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox Width="65px" ID="txtItemWefDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox><asp:HyperLink
                                                Style="vertical-align: top; height: 16px; width: 22px;" ID="hlimgItemWefDate"
                                                runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CEItemWefDate" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtItemWefDate" PopupButtonID="hlimgItemWefDate" Enabled="True">
                                            </AjaxToolKit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvItemWefDate" ValidationGroup="vgCFooter1" SetFocusOnError="true"
                                                ControlToValidate="txtItemWefDate" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemStyle Width="150px" />
                                        <HeaderStyle Width="100px" />
                                        <FooterStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrContractNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ContractNumber %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hiddenFieldContractNumber" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ContractNumber").ToString()%>' />
                                            <asp:Label ID="lblgvContractNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContractNumber").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="hiddenFieldContractNumber" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ContractNumber").ToString()%>' />
                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" AutoPostBack="true" ID="ddlContractNumber"
                                                runat="server" OnSelectedIndexChanged="DdlContractNumber_SelectedIndexChangedIDET">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList CssClass="cssDropDown" Width="180px" AutoPostBack="true" ID="ddlContractNumber"
                                                runat="server" OnSelectedIndexChanged="DdlContractNumber_SelectedIndexChangedIDFT">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemStyle Width="180px" />
                                        <HeaderStyle Width="180px" />
                                        <FooterStyle Width="180px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <Ajax:AsyncPostBackTrigger ControlID="btnAuthorize" EventName="Click" />
                            <Ajax:AsyncPostBackTrigger ControlID="btnAmend" EventName="Click" />
                            <Ajax:AsyncPostBackTrigger ControlID="ddlSOAmendNO" EventName="SelectedIndexChanged" />
                            <Ajax:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        </Triggers>
                    </Ajax:UpdatePanel>
                </div>
            </ContentTemplate>
        </AjaxToolKit:TabPanel>
    </AjaxToolKit:TabContainer>
    <%--<script language ="javascript" src="../javaScript/jquery-1.8.1.min.js" type ="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" language="javascript" src="../PageJS/SaleOrderMaster.js"></script>
    <script language="javascript" type="text/javascript">

        function ControlInitializer() {
            this.btnLoadParentPage = document.getElementById('<%= btnLoadParentPage.ClientID %>');
            
        }
    </script>
</asp:Content>
