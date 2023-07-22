<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CostSheet.aspx.cs" Inherits="Sales_CostSheet" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


     <table width="960" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td>
                <div style="width: 100%;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 930px;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label13" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,CostSheet %>"></asp:Label></tt></div>
                        </div>
                        <div class="squareboxcontent">
                            <table border="0">
                                <tr>
                                    <td>
                                    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                                    <ContentTemplate>                        
                                        <asp:Panel ID="costSheetHeader" Width="900px" GroupingText="<%$Resources:Resource,CostSheet %>" BorderWidth="0px" runat="server">
                                            <table border="0" width="900">
                                                <tr>
                                                    <td align="right" style="width:150px">
                                                        <asp:Label ID="lblFixCostSheetNo" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CostSheetNo %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:150px">
                                                        <asp:TextBox ID="txtCostSheetNo" CssClass="csstxtboxReadonly" Width="120px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="width:100px">
                                                        <asp:Label ID="lblFixCostSheetDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CostSheetDate %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:125px">
                                                        <asp:TextBox ID="txtCostSheetDate" CssClass="csstxtbox" Width="80px" runat="server" ValidationGroup="SaveUpdate"></asp:TextBox>
                                                        <asp:HyperLink Style="vertical-align: top;" ID="hlCostSheetDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtCostSheetDate" ID="rfvCostSheetDate" ValidationGroup="SaveUpdate"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="right" style="width:125px;">
                                                        <asp:Label ID="lblFixCostSheetStatus" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Status %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:250px">
                                                        <asp:TextBox ID="txtCostSheetStatus" CssClass="csstxtboxReadonly" Width="120px" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width:150px">
                                                        <asp:Label ID="lblFixCostSheetAmendNo" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AmendNo %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:150px">
                                                        <asp:DropDownList ID="ddlCostSheetAmendNo" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="126"></asp:DropDownList>
                                                        <asp:HiddenField ID="hfIsMAXCostSheetAmendNo" runat="server" />
                                                    </td>
                                                    <td align="right" style="width:100px;">
                                                        <asp:Label ID="lblFixClientName" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ClientName %>"></asp:Label>
                                                    </td>
                                                    <td colspan="3" align="left" style="width:500px">
                                                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="380" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width:150px">
                                                        <asp:Label ID="lblFixPreparedBy" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,PreparedBy %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:150px">
                                                        <asp:TextBox ID="txtPreparedBy" CssClass="csstxtbox" Width="120px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="width:100px">
                                                        <asp:Label ID="lblFixPreparedDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,PreparedDate %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:125px">
                                                        <asp:TextBox ID="txtPreparedDate" CssClass="csstxtbox" Width="80px" runat="server"></asp:TextBox>
                                                        <asp:HyperLink Style="vertical-align: top;" ID="hlPreparedDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                    </td>
                                                    <td align="right" style="width:125px;">
                                                        <asp:Label ID="lblFixApprovedBy" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ApprovedBy %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:250px">
                                                        <asp:TextBox ID="txtApprovedBy" CssClass="csstxtbox" Width="120px" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width:150px">
                                                        <asp:Label ID="lblFixVerifiedBy" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,VerifiedBy %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:150px">
                                                        <asp:TextBox ID="txtVerifiedBy" CssClass="csstxtbox" Width="120px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="width:100px">
                                                        <asp:Label ID="lblFixVerifiedDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,VerifiedDate %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:125px">
                                                        <asp:TextBox ID="txtVerifiedDate" CssClass="csstxtbox" Width="80px" runat="server"></asp:TextBox>
                                                        <asp:HyperLink Style="vertical-align: top;" ID="hlVerifiedDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                    </td>
                                                    <td align="right" style="width:125px;">
                                                        <asp:Label ID="lblFixApprovedDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ApprovedDate %>"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:250px">
                                                        <asp:TextBox ID="txtApprovedDate" CssClass="csstxtbox" Width="120px" runat="server"></asp:TextBox>
                                                        <asp:HyperLink Style="vertical-align: top;" ID="hlApprovedDate" runat="server" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" style="text-align:right">
                                                        <asp:Button ID="btnGenerateCostSheetNo" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Save %>" OnClick="btnSave_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                        <Ajax:PostBackTrigger ControlID="btnAmend" />
                                        <Ajax:PostBackTrigger ControlID="btnAuthorize" />
                                        <Ajax:PostBackTrigger ControlID="btnDelete" />
                                        <Ajax:PostBackTrigger ControlID="btnUpdate" />
                                        <Ajax:PostBackTrigger ControlID="btnEdit" />
                                        <Ajax:PostBackTrigger ControlID="btnSave" />
                                    </Triggers>
                                    </Ajax:UpdatePanel>
                                    <Ajax:UpdatePanel runat="server" ID="up2" UpdateMode="Conditional">
                                    <ContentTemplate> 
                                        <asp:Panel ID="CostSheetGrid1" Width="900px" GroupingText="<%$Resources:Resource,CostSheet %>" BorderWidth="0px" runat="server" style="text-align:right">
                                            
                                                <div id="divContaintHolder1" style="width:900px;height:200px;overflow:auto;border-style:solid;border-width:1px;">
                                                <table style="text-align:center;" border="0" width="900">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView Width="1900px" ID="gvCostSheetService" CssClass="GridViewStyle" runat="server"
                                                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                                            CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvCostSheetService_RowCommand"
                                                            OnRowUpdating="gvCostSheetService_RowUpdating" OnRowEditing="gvCostSheetService_RowEditing"
                                                            OnRowCancelingEdit="gvCostSheetService_RowCancelingEdit" OnRowDataBound="gvCostSheetService_RowDataBound" OnRowDeleting="gvCostSheetService_RowDeleting">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField FooterStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblaction" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit" ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update" ValidationGroup="vgCEdit4" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel" ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add" ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset" ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-Width="75px" HeaderStyle-Width="75px" ItemStyle-Width="75px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrCostSheetLineNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, CostSheetLineNo %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostSheetLineNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CostSheetLineNo").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCostSheetLineNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CostSheetLineNo").ToString()%>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrSORank" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SORank %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvSORank" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SORank").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="hfSORank" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SORank").ToString()%>' />
                                                                        <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvSORank" runat="server" OnSelectedIndexChanged="ddlgvSORank_SelectedIndexChangedEdit"></asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvSORank" runat="server" OnSelectedIndexChanged="ddlgvSORank_SelectedIndexChangedFooter"></asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrDesignationDesc" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, DesignationDesc %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvDesignationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DesignationDesc").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" ID="txtDesignationDesc" CssClass="csstxtboxReadonly" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DesignationDesc").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" ID="txtDesignationDesc" CssClass="csstxtboxReadonly" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrUOM" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, UOM %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvUOM" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UOM").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="hfUOM" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "UOM").ToString()%>' />
                                                                        <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvUOM" runat="server" OnSelectedIndexChanged="ddlgvUOM_SelectedIndexChangedEdit"></asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvUOM" runat="server" OnSelectedIndexChanged="ddlgvUOM_SelectedIndexChangedFooter"></asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrNumberOfPerson" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, NumberOfPerson %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvNumberOfPerson" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberOfPerson").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="5" style="text-align:right;" ID="txtNumberOfPerson" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberOfPerson").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="5" style="text-align:right;" ID="txtNumberOfPerson" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrWorkingDay" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, WorkingDay %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvWorkingDay" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkingDay").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtWorkingDay" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkingDay").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtWorkingDay" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrNormalHours" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, NormalHours %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvNormalHours" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NormalHours").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtNormalHours" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NormalHours").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtNormalHours" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOTHours" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, OTHours %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOTHours" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHours").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOTHours" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHours").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOTHours" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrHourlyWageRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, HourlyWageRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvHourlyWageRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HourlyWageRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtHourlyWageRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HourlyWageRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtHourlyWageRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrIncentiveAllowanceYearly" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, IncentiveAllowance %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvIncentiveAllowanceYearly" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IncentiveAllowanceYearly").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtIncentiveAllowanceYearly" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IncentiveAllowanceYearly").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtIncentiveAllowanceYearly" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrIncentiveMonthlyOrYearly" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, IncentiveMonthlyOrYearly %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvIncentiveMonthlyOrYearly" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IncentiveMonthlyOrYearly").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtIncentiveMonthlyOrYearly" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IncentiveMonthlyOrYearly").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtIncentiveMonthlyOrYearly" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrQuotedRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, QuotedRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvQuotedRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuotedRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtQuotedRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuotedRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtQuotedRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotal" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Total %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotal" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Total").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotal" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Total").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotal" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrActual" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Actual %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvActual" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Actual").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtActual" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Actual").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtActual" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrAsPerMargin" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, AsPerMargin %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvAsPerMargin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsPerMargin").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtAsPerMargin" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsPerMargin").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtAsPerMargin" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalHrsVoccationSickTraining" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalHrsVoccationSickTraining %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalHrsVoccationSickTraining" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsVoccationSickTraining").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsVoccationSickTraining" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsVoccationSickTraining").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsVoccationSickTraining" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrDaysPerWeek" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, DaysPerWeek %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvDaysPerWeek" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DaysPerWeek").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtDaysPerWeek" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DaysPerWeek").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtDaysPerWeek" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrHoursPerDay" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, HoursPerDay %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvHoursPerDay" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursPerDay").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtHoursPerDay" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HoursPerDay").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtHoursPerDay" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrPostsRequired" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, PostsRequired %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvPostsRequired" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostsRequired").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtPostsRequired" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostsRequired").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtPostsRequired" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrRecommendedMenByCategory" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, RecommendedMenByCategory %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvRecommendedMenByCategory" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecommendedMenByCategory").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtRecommendedMenByCategory" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecommendedMenByCategory").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtRecommendedMenByCategory" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalHrsPerWeek" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalHrsPerWeek %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalHrsPerWeek" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPerWeek").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPerWeek" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPerWeek").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPerWeek" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalHrsPerYearActual" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalHrsPerYearActual %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalHrsPerYearActual" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPerYearActual").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPerYearActual" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPerYearActual").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPerYearActual" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalRegularHrsPerYear" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalRegularHrsPerYear %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalRegularHrsPerYear" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalRegularHrsPerYear").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalRegularHrsPerYear" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalRegularHrsPerYear").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalRegularHrsPerYear" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalOTHrsPerYear" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalOTHrsPerYear %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalOTHrsPerYear" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOTHrsPerYear").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalOTHrsPerYear" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOTHrsPerYear").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalOTHrsPerYear" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalRegularHrsPayPerDay" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalRegularHrsPayPerDay %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalRegularHrsPayPerDay" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalRegularHrsPayPerDay").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalRegularHrsPayPerDay" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalRegularHrsPayPerDay").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalRegularHrsPayPerDay" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalOTHrsPayPerDay" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalOTHrsPayPerDay %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalOTHrsPayPerDay" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOTHrsPayPerDay").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalOTHrsPayPerDay" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOTHrsPayPerDay").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalOTHrsPayPerDay" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalHrsPayPerDay" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalHrsPayPerDay %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalHrsPayPerDay" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPayPerDay").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPayPerDay" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPayPerDay").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPayPerDay" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalHrsPerWeekAllPost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalHrsPerWeekAllPost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalHrsPerWeekAllPost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPerWeekAllPost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPerWeekAllPost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPerWeekAllPost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPerWeekAllPost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalHrsPerYearAllPost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalHrsPerYearAllPost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalHrsPerYearAllPost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPerYearAllPost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPerYearAllPost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalHrsPerYearAllPost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalHrsPerYearAllPost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalRegularHrsPerYearAllPost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalRegularHrsPerYearAllPost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalRegularHrsPerYearAllPost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalRegularHrsPerYearAllPost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalRegularHrsPerYearAllPost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalRegularHrsPerYearAllPost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalRegularHrsPerYearAllPost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalOTHrsPerYearAllPost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalOTHrsPerYearAllPost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalOTHrsPerYearAllPost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOTHrsPerYearAllPost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalOTHrsPerYearAllPost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOTHrsPerYearAllPost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalOTHrsPerYearAllPost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrBasicWage12HrsPerDay" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, BasicWage12HrsPerDay %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvBasicWage12HrsPerDay" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BasicWage12HrsPerDay").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtBasicWage12HrsPerDay" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BasicWage12HrsPerDay").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtBasicWage12HrsPerDay" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOTFor9th12thHrsOTRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, OTFor9th12thHrsOTRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOTFor9th12thHrsOTRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTFor9th12thHrsOTRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOTFor9th12thHrsOTRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTFor9th12thHrsOTRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOTFor9th12thHrsOTRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOT7thDay12Hrs" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, OT7thDay12Hrs %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOT7thDay12Hrs" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OT7thDay12Hrs").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOT7thDay12Hrs" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OT7thDay12Hrs").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOT7thDay12Hrs" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrIncentiveAllowance" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, IncentiveAllowance %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvIncentiveAllowance" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IncentiveAllowance").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtIncentiveAllowance" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IncentiveAllowance").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtIncentiveAllowance" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrHolidayPay13Days8Hrs" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, HolidayPay13Days8Hrs %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvHolidayPay13Days8Hrs" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HolidayPay13Days8Hrs").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtHolidayPay13Days8Hrs" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HolidayPay13Days8Hrs").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtHolidayPay13Days8Hrs" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrSickPayCompensation" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SickPayCompensation %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvSickPayCompensation" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SickPayCompensation").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSickPayCompensation" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SickPayCompensation").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSickPayCompensation" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrVacationPay" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, VacationPay %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvVacationPay" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VacationPay").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtVacationPay" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VacationPay").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtVacationPay" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrProvidentFund" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, ProvidentFund %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvProvidentFund" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProvidentFund").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtProvidentFund" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProvidentFund").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtProvidentFund" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrSocialWelfareFund" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SocialWelfareFund %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvSocialWelfareFund" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SocialWelfareFund").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSocialWelfareFund" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SocialWelfareFund").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSocialWelfareFund" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrWorkmanCompensationFund" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, WorkmanCompensationFund %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvWorkmanCompensationFund" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkmanCompensationFund").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtWorkmanCompensationFund" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkmanCompensationFund").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtWorkmanCompensationFund" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrMonthlyBonusPayment" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, MonthlyBonusPayment %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvMonthlyBonusPayment" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MonthlyBonusPayment").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtMonthlyBonusPayment" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MonthlyBonusPayment").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtMonthlyBonusPayment" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalDirectLaborCost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalDirectLaborCost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalDirectLaborCost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalDirectLaborCost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalDirectLaborCost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalDirectLaborCost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalDirectLaborCost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrEquipmentsCost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, EquipmentsCost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvEquipmentsCost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EquipmentsCost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtEquipmentsCost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EquipmentsCost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtEquipmentsCost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalOperationCosts" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalOperationCosts %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalOperationCosts" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOperationCosts").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalOperationCosts" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOperationCosts").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalOperationCosts" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalDirectCost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalDirectCost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalDirectCost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalDirectCost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalDirectCost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalDirectCost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalDirectCost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOverHeadAllocation" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, OverHeadAllocation %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOverHeadAllocation" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OverHeadAllocation").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOverHeadAllocation" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OverHeadAllocation").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOverHeadAllocation" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalLocaladministrativeCost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalLocaladministrativeCost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalLocaladministrativeCost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalLocaladministrativeCost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalLocaladministrativeCost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalLocaladministrativeCost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalLocaladministrativeCost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrPhoneAndFax" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, PhoneAndFax %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvPhoneAndFax" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PhoneAndFax").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtPhoneAndFax" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PhoneAndFax").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtPhoneAndFax" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrGeneralLibilityInsurance" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, GeneralLibilityInsurance %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvGeneralLibilityInsurance" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GeneralLibilityInsurance").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtGeneralLibilityInsurance" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GeneralLibilityInsurance").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtGeneralLibilityInsurance" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalLocalOverheadCost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalLocalOverheadCost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalLocalOverheadCost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalLocalOverheadCost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalLocalOverheadCost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalLocalOverheadCost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalLocalOverheadCost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOverAllTotalCost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, OverAllTotalCost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOverAllTotalCost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OverAllTotalCost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOverAllTotalCost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OverAllTotalCost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOverAllTotalCost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrRatePerPostAsPerMargin" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, RatePerPostAsPerMargin %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvRatePerPostAsPerMargin" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RatePerPostAsPerMargin").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtRatePerPostAsPerMargin" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RatePerPostAsPerMargin").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtRatePerPostAsPerMargin" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrSumOfTotalPost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SumOfTotalPost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvSumOfTotalPost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SumOfTotalPost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSumOfTotalPost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SumOfTotalPost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSumOfTotalPost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrSumOfTotalHrs" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SumOfTotalHrs %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvSumOfTotalHrs" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SumOfTotalHrs").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSumOfTotalHrs" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SumOfTotalHrs").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSumOfTotalHrs" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrVoccationHrs" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, VoccationHrs %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvVoccationHrs" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VoccationHrs").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtVoccationHrs" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VoccationHrs").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtVoccationHrs" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrSickProvision" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SickProvision %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvSickProvision" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SickProvision").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSickProvision" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SickProvision").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSickProvision" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTrainingHrs" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TrainingHrs %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTrainingHrs" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TrainingHrs").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTrainingHrs" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TrainingHrs").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTrainingHrs" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOTRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, OTRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOTRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOTRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOTRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrHolidayRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, HolidayRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvHolidayRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HolidayRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtHolidayRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HolidayRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtHolidayRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOT7thDayRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, OT7thDayRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOT7thDayRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OT7thDayRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOT7thDayRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OT7thDayRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOT7thDayRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrSickLeaveValue" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SickLeaveValue %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvSickLeaveValue" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SickLeaveValue").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSickLeaveValue" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SickLeaveValue").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSickLeaveValue" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrVoccationDayValue" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, VoccationDayValue %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvVoccationDayValue" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VoccationDayValue").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtVoccationDayValue" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VoccationDayValue").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtVoccationDayValue" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrBonusPerMonthPerGuardRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, BonusPerMonthPerGuardRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvBonusPerMonthPerGuardRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BonusPerMonthPerGuardRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtBonusPerMonthPerGuardRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BonusPerMonthPerGuardRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtBonusPerMonthPerGuardRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrPfRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, PfRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvPfRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PfRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtPfRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PfRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtPfRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrSocialWelfareRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, SocialWelfareRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvSocialWelfareRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SocialWelfareRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSocialWelfareRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SocialWelfareRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtSocialWelfareRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrWorkmenCommensationRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, WorkmenCommensationRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvWorkmenCommensationRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkmenCommensationRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtWorkmenCommensationRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkmenCommensationRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtWorkmenCommensationRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrTotalEquipmentCost" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TotalEquipmentCost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvTotalEquipmentCost" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalEquipmentCost").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalEquipmentCost" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalEquipmentCost").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotalEquipmentCost" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrOverheadAllocationRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, OverheadAllocationRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvOverheadAllocationRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OverheadAllocationRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOverheadAllocationRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OverheadAllocationRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtOverheadAllocationRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrPhoneFaxRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, PhoneFaxRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvPhoneFaxRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PhoneFaxRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtPhoneFaxRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PhoneFaxRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtPhoneFaxRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblgvhdrGeneralLiabilityInsuranceRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, GeneralLiabilityInsuranceRate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblgvGeneralLiabilityInsuranceRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GeneralLiabilityInsuranceRate").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtGeneralLiabilityInsuranceRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GeneralLiabilityInsuranceRate").ToString()%>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtGeneralLiabilityInsuranceRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </div>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                        <Ajax:PostBackTrigger ControlID="btnGenerateCostSheetNo" />
                                        <Ajax:PostBackTrigger ControlID="ddlCostSheetAmendNo" />
                                        <Ajax:PostBackTrigger ControlID="btnAmend" />
                                        <Ajax:PostBackTrigger ControlID="btnAuthorize" />
                                        <Ajax:PostBackTrigger ControlID="btnDelete" />
                                        <Ajax:PostBackTrigger ControlID="btnUpdate" />
                                        <Ajax:PostBackTrigger ControlID="btnSave" />
                                    </Triggers>
                                    </Ajax:UpdatePanel>
                                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                    <ContentTemplate> 
                                        <asp:Panel ID="CostSheetGrid2" Width="900px" GroupingText="<%$Resources:Resource,CostSheet %>" BorderWidth="0px" runat="server" style="text-align:right">
                                            
                                                <div id="divContaintHolder2"  style="width:900px;height:200px;overflow:auto;border-style:solid;border-width:1px;">
                                                    <table style="text-align:center;" border="0" width="900">
                                                        <tr>
                                                            <td>
                                                                <asp:GridView Width="1400" ID="gvCostSheetItem" CssClass="GridViewStyle" runat="server"
                                                                    ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                                                    CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvCostSheetItem_RowCommand"
                                                                    OnRowUpdating="gvCostSheetItem_RowUpdating" OnRowEditing="gvCostSheetItem_RowEditing"
                                                                    OnRowCancelingEdit="gvCostSheetItem_RowCancelingEdit" OnRowDataBound="gvCostSheetItem_RowDataBound" OnRowDeleting="gvCostSheetItem_RowDeleting">
                                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                    <Columns>
                                                                        <asp:TemplateField FooterStyle-Width="75px" HeaderStyle-Width="75px" ItemStyle-Width="75px">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblaction" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit" ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update" ValidationGroup="vgCEdit4" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel" ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add" ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset" ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField FooterStyle-Width="75px" HeaderStyle-Width="75px" ItemStyle-Width="75px">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblgvhdrCostSheetLineNo" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, CostSheetLineNo %>"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCostSheetLineNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CostSheetLineNo").ToString()%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblCostSheetLineNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CostSheetLineNo").ToString()%>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblgvhdrTypeOfItem" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, TypeOfItem %>"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgvTypeOfItem" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TypeOfItem").ToString()%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:HiddenField ID="hfTypeOfItem" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TypeOfItem").ToString()%>' />
                                                                                <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvTypeOfItem" runat="server" OnSelectedIndexChanged="ddlgvTypeOfItem_SelectedIndexChangedEdit"></asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvTypeOfItem" runat="server" OnSelectedIndexChanged="ddlgvTypeOfItem_SelectedIndexChangedFooter"></asp:DropDownList>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblgvhdrItemTypeCode" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, ItemTypeCode %>"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgvItemTypeCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemTypeCode").ToString()%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:HiddenField ID="hfItemTypeCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ItemTypeCode").ToString()%>' />
                                                                                <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvItemTypeCode" runat="server" OnSelectedIndexChanged="ddlgvItemTypeCode_SelectedIndexChangedEdit"></asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvItemTypeCode" runat="server" OnSelectedIndexChanged="ddlgvItemTypeCode_SelectedIndexChangedFooter"></asp:DropDownList>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblgvhdrItemDesc" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, ItemDesc %>"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgvItemDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemDesc").ToString()%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox Width="100px" ID="txtItemDesc" CssClass="csstxtboxReadonly" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemDesc").ToString()%>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox Width="100px" ID="txtItemDesc" CssClass="csstxtboxReadonly" runat="server" ></asp:TextBox>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblgvhdrUOM" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, UOM %>"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgvUOM" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UOM").ToString()%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:HiddenField ID="hfUOM" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "UOM").ToString()%>' />
                                                                                <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvUOM" runat="server" OnSelectedIndexChanged="ddlgvUOM_SelectedIndexChangedItemEdit"></asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="130px" ID="ddlgvUOM" runat="server" OnSelectedIndexChanged="ddlgvUOM_SelectedIndexChangedItemFooter"></asp:DropDownList>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblgvhdrQty" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Qty %>"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblgvQty" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qty").ToString()%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtQty" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qty").ToString()%>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtQty" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                                </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblgvhdrQuotedRate" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, QuotedRate %>"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblgvQuotedRate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuotedRate").ToString()%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtQuotedRate" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuotedRate").ToString()%>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtQuotedRate" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                                </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblgvhdrTotal" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, Total %>"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblgvTotal" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Total").ToString()%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotal" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Total").ToString()%>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtTotal" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                                </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblgvhdrDepreciationMonthsForEquipment" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, DepreciationMonthsForEquipment %>"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblgvDepreciationMonthsForEquipment" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DepreciationMonthsForEquipment").ToString()%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtDepreciationMonthsForEquipment" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DepreciationMonthsForEquipment").ToString()%>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtDepreciationMonthsForEquipment" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                                </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblgvhdrEquipmentValuePerYear" CssClass="cssLabelGVHeader" runat="server" Text="<%$ Resources:Resource, EquipmentValuePerYear %>"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblgvEquipmentValuePerYear" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EquipmentValuePerYear").ToString()%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtEquipmentValuePerYear" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EquipmentValuePerYear").ToString()%>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:TextBox Width="100px" MaxLength="30" style="text-align:right;" ID="txtEquipmentValuePerYear" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                                </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                        <Ajax:PostBackTrigger ControlID="btnGenerateCostSheetNo" />
                                        <Ajax:PostBackTrigger ControlID="ddlCostSheetAmendNo" />
                                        <Ajax:PostBackTrigger ControlID="btnAmend" />
                                        <Ajax:PostBackTrigger ControlID="btnAuthorize" />
                                        <Ajax:PostBackTrigger ControlID="btnDelete" />
                                        <Ajax:PostBackTrigger ControlID="btnUpdate" />
                                        <Ajax:PostBackTrigger ControlID="btnSave" />
                                    </Triggers>
                                    </Ajax:UpdatePanel>
                                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                    <ContentTemplate> 
                                        <asp:Panel ID="CostSheetCalculation" Width="900px" GroupingText="<%$Resources:Resource,CostSheet %>" BorderWidth="0px" runat="server">       
                                            <table border="0" width="900px">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixBankGuaranteeAmount" Text="<%$Resources:Resource,BankGuaranteeAmount %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtBankGuaranteeAmount" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixMarginPercentage" Text="<%$Resources:Resource,MarginPercentage %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtMarginPercentage" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixContractStampAmount" Text="<%$Resources:Resource,ContractStampAmount %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtContractStampAmount" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixEquipmentRental" Text="<%$Resources:Resource,EquipmentRental %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtEquipmentRental" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtEquipmentRentalTotal" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixAirportFeeAmount" Text="<%$Resources:Resource,AirportFeeAmount %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtAirportFeeAmount" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixTotalSellingPrice" Text="<%$Resources:Resource,TotalSellingPrice %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtTotalSellingPrice" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtTotalSellingPriceTotal" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixTotalequipmentCostyearly" Text="<%$Resources:Resource,TotalEquipmentCostYearly %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtTotalequipmentCostyearly" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixMinusCost" Text="<%$Resources:Resource,MinusCost %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtMinusCost" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtMinusCostTotal" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixOtherAdditionalCharges" Text="<%$Resources:Resource,OtherAdditionalCharges %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtOtherAdditionalCharges" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixGrossProfit" Text="<%$Resources:Resource,GrossProfit %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtGrossProfit" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtGrossProfitTotal" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixTotalAmount" Text="<%$Resources:Resource,TotalAmount %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtTotalAmount" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixGrossMargin" Text="<%$Resources:Resource,GrossMargin %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtGrossMargin" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtGrossMarginTotal" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixTotalAmountWithMargin" Text="<%$Resources:Resource,TotalAmountWithMargin %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtTotalAmountWithMargin" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblFixContributionHead" Text="<%$Resources:Resource,ContributionHead %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtContributionHead" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtContributionHeadTotal" MaxLength="30" style="text-align:right;" Width="160px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="0" width="900">
                                                <tr>
                                                    <td colspan="2" style="text-align:center">
                                                        <asp:Button ID="btnSave" runat="server" ValidationGroup="SaveUpdate" CssClass="cssButton" Text="<%$ Resources:Resource, Save %>" OnClick="btnSave_Click" />
                                                        <asp:Button ID="btnEdit" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Edit %>" OnClick="btnEdit_Click" />
                                                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="SaveUpdate" CssClass="cssButton" Text="<%$ Resources:Resource, Update %>" OnClick="btnUpdate_Click" />
                                                        <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Delete %>" OnClick="btnDelete_Click" />
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Cancel %>" OnClick="btnCancel_Click" />
                                                        <asp:Button ID="btnAmend" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Amend %>" OnClick="btnAmend_Click" />
                                                        <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, btnAuthorize %>" OnClick="btnAuthorize_Click" />
                                                        
                                                        <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, ContractMaster %>" OnClick="imgBack_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align:center">
                                                        <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                        <Ajax:PostBackTrigger ControlID="btnGenerateCostSheetNo" />
                                        <Ajax:PostBackTrigger ControlID="ddlCostSheetAmendNo" />
                                    </Triggers>
                                    </Ajax:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    
                </div>
            </td>
        </tr>
    </table>
</asp:Content>