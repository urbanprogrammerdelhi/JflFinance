<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerPortalInbox.aspx.cs"
    Inherits="Masters_CustomerPortalInbox" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <style type="text/css">
        .OutlookTable
        {
            background-color: #c4dafa;
            margin-top: 4px;
        }
        
        .MailSubject
        {
            color: #808080;
        }
        
        .SelectedRow_Outlook .MailSubject
        {
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <!-- content start -->
   <%-- <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvChangeRequestInbox">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvChangeRequestInbox" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="panelCustomerDetails" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="panelCustomerConstraint" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="MessageToolbar" />
                    <telerik:AjaxUpdatedControl ControlID="btnReject" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnApprove" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="panelAssignment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="panelDeployment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="PanelHeader" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="PanelFooter" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Office2007" />--%>
    <table width="100%" style="height: 700px">
        <tr>
            <td>
                <telerik:RadSplitter ID="RadSplitter2" LiveResize="true" runat="server" Orientation="Horizontal"
                    Width="100%" Height="700px">
                    <telerik:RadPane ID="Radpane1" Scrolling="None" Height="200px" runat="server">
                        <telerik:RadGrid ID="gvChangeRequestInbox" runat="server" Width="98%" Height="100%"
                            AllowSorting="True" AllowMultiRowSelection="True" AllowPaging="false" ShowGroupPanel="True"
                            GridLines="None" OnItemCommand="gvChangeRequestInbox_ItemCommand" OnNeedDataSource="gvChangeRequestInbox_NeedDataSource"
                            AutoGenerateColumns="False" Skin="Office2007">
                            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                            <MasterTableView AllowMultiColumnSorting="True">
                                <%--<GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <SelectFields>
                                <telerik:GridGroupByField FieldAlias="Received" FieldName="Received" FormatString="{0:D}"
                                    HeaderValueSeparator=" from date: "></telerik:GridGroupByField>
                            </SelectFields>
                            <GroupByFields>
                                <telerik:GridGroupByField SortOrder="Descending" FieldName="Received" FormatString=""
                                    HeaderText=""></telerik:GridGroupByField>
                            </GroupByFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>--%>
                                <Columns>
                                    <telerik:GridBoundColumn SortExpression="RequestType" HeaderText="RequestType" HeaderButtonType="TextButton"
                                        DataField="RequestType">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn2" GroupByExpression="From Group By From"
                                        SortExpression="From" HeaderText="From / Subject">
                                        <ItemStyle Height="35px"></ItemStyle>
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "From") %>
                                            <br />
                                            <div class="MailSubject">
                                                <%# DataBinder.Eval(Container.DataItem, "Subject") %>
                                            </div>
                                            <asp:HiddenField ID="hfGuid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Guid") %>' />
                                            <asp:HiddenField ID="hfRequestType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RequestType") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn SortExpression="Received" HeaderText="Received" HeaderButtonType="TextButton"
                                        DataField="Received" DataFormatString="{0:d}">
                                        <HeaderStyle Width="125px"></HeaderStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="AuthorizationStatus" HeaderText="Status"
                                        HeaderButtonType="TextButton" DataField="AuthorizationStatus">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings AllowDragToGroup="True" EnablePostBackOnRowClick="true">
                                <Selecting AllowRowSelect="True"></Selecting>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                                <ClientMessages DragToGroupOrReorder="Drag to group" />
                                <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True"
                                    ResizeGridOnColumnResize="False"></Resizing>
                            </ClientSettings>
                            <GroupingSettings ShowUnGroupButton="true" />
                        </telerik:RadGrid>
                    </telerik:RadPane>
                    <telerik:RadSplitBar ID="Radsplitbar4" runat="server" CollapseMode="Forward" />
                    <telerik:RadPane ID="Radpane5" Height="100%" Scrolling="None" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <telerik:RadToolBar ID="MessageToolbar" Visible="true" OnButtonClick="MessageToolbar_ButtonClick"
                                        runat="server" Width="100%">
                                        <Items>
                                            <telerik:RadToolBarButton ID="btnApprove" CommandName="AUTHORIZED" ImageUrl="../Images/Approve.png"
                                                runat="server" Text="Approve">
                                            </telerik:RadToolBarButton>
                                            <telerik:RadToolBarButton ID="btnReject" CommandName="REJECTED" ImageUrl="../Images/Reject.png"
                                                runat="server" Text="Reject">
                                            </telerik:RadToolBarButton>
                                        </Items>
                                    </telerik:RadToolBar>
                                    <asp:Panel ID="PanelHeader" Width="100%" runat="server">
                                        <table width="98%">
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:HiddenField ID="hfTypeOfRequest" runat="server" />
                                                    <asp:HiddenField ID="hfRequestGuid" runat="server" />
                                                    <asp:Label ID="lblReceiver" Width="100%" Font-Bold="true" runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMessage" Width="100%" Font-Bold="true" runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="panelCustomerDetails" Visible="false" ScrollBars="Auto" CssClass="ScrollBarPortal"
                                        Height="60%" Width="100%" runat="server">
                                        <table width="98%" style="height: 100%">
                                            <tr>
                                                <td style="width: 5%; text-align: right">
                                                    <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,AddressLine1 %>"></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblOldAddress1" Width="100%" Height="18px" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblNewAddress1" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="width: 2%; text-align: right">
                                                    <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Zip %>"></asp:Label>
                                                </td>
                                                <td style="width: 15%; text-align: left">
                                                    <asp:Label ID="lblOldGroupZip" runat="server" Width="35%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                    <asp:Label ID="lblOldZip" runat="server" Width="55%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 18%; text-align: left">
                                                    <asp:Label ID="lblNewGroupZip" runat="server" Width="40%" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                    <asp:Label ID="lblNewZip" runat="server" Width="53%" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="width: 5%; text-align: right">
                                                    <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,WebSite %>"></asp:Label>
                                                </td>
                                                <td style="width: 12%; text-align: left">
                                                    <asp:Label ID="lblOldWebSite" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewWebSite" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label4" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,AddressLine2 %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldAddress2" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewAddress2" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label5" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Phone %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldPhoneNumber" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewPhoneNumber" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label6" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,City %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldCity" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewCity" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label7" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,AddressLine3 %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldAddress3" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewAddress3" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label8" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Email %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldEmail" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewEmail" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label9" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Country %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldCountry" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewCountry" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label10" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Sector %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldSector" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewSector" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label11" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,CustomerType %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldCustomerType" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewCustomerType" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label12" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Fax %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldFax" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewFax" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label13" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,ContactPerson %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldContactPerson" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewContactPerson" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label14" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Designation %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldDesignation" runat="server" Width="100%" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewDesignation" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label15" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Phone %>"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOldCustomerPhone" runat="server" Height="18px" BackColor="Gray"
                                                        CssClass="cssLabel" ForeColor="White" Width="100%"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblNewCustomerPhone" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label16" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Comment %>"></asp:Label>
                                                </td>
                                                <td colspan="9" style="text-align: left">
                                                    <asp:Label ID="lblComment" Width="100%" Height="40px" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="panelCustomerConstraint" Visible="false" ScrollBars="Auto" CssClass="ScrollBarPortal"
                                        Width="50%" runat="server">
                                        <table width="98%" style="height: 100%">
                                            <tr>
                                                <td style="width: 5%; text-align: right">
                                                    <asp:Label ID="Label18" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Constraint %>"></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblOldConstraint" Width="100%" Height="18px" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblNewConstraint" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%; text-align: right">
                                                    <asp:Label ID="lblOperatorHeading" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Operator %>"></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblOldOperator" Width="100%" Height="18px" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblNewOperator" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%; text-align: right">
                                                    <asp:Label ID="lblValueHeading" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Value %>"></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblOldValue" Width="100%" Height="18px" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblNewValue" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%; text-align: right">
                                                    <asp:Label ID="Label21" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,RigidityLevel %>"></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblOldRigidityLevel" Width="100%" Height="18px" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 16%; text-align: left">
                                                    <asp:Label ID="lblNewRigidityLevel" Width="98%" runat="server" CssClass="cssLabelWithBorder"
                                                        Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="panelAssignment" Visible="false" ScrollBars="Auto" CssClass="ScrollBarPortal"
                                        Width="100%" runat="server">
                                        <table width="98%">
                                            <tr>
                                                <td style="width: 4%; text-align: right">
                                                    <asp:Label ID="Label22" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Assignment %>"></asp:Label>
                                                </td>
                                                <td style="width: 15%; text-align: left">
                                                    <asp:Label ID="lblOldAssignmentName" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 20%; text-align: left">
                                                    <asp:Label ID="lblNewAssignmentName" Width="100%" CssClass="cssLabelWithBorder" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label23" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Address %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldAssignmentAddress" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewAssignmentAddress" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label24" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, City %>"></asp:Label>
                                                </td>
                                                <td style="width: 14%">
                                                    <asp:Label ID="lblOldAssignmentCity" Width="98%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewAssignmentCity" Width="98%" CssClass="cssLabelWithBorder" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label25" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Zip %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldAssignmentGroupZip" Width="35%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server">
                                                    </asp:Label>
                                                    <asp:Label ID="lblOldAssignmentZip" Width="58%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server">
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewAssignmentGroupZip" Width="35%" CssClass="cssLabelWithBorder"
                                                        runat="server">
                                                    </asp:Label>
                                                    <asp:Label ID="lblNewAssignmentZip" Width="58%" CssClass="cssLabelWithBorder" runat="server">
                                                    </asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label26" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Fax %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldAssignmentFax" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewAssignmentFax" Width="100%" CssClass="cssLabelWithBorder" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label27" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Phone %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldAssignmentPhoneNumber" Width="98%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewAssignmentPhoneNumber" Width="98%" CssClass="cssLabelWithBorder"
                                                        runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label28" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Email %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldAssignmentEmail" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewAssignmentEmail" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label29" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Country %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldAssignmentCountry" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server">
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewAssignmentCountry" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server">
                                                    </asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label30" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Area %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldAssignmentArea" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server">
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewAssignmentArea" Width="100%" CssClass="cssLabelWithBorder" runat="server">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label151" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Comment %>"></asp:Label>
                                                </td>
                                                <td colspan="8">
                                                    <asp:Label ID="lblAssignmentComment" Width="98%" CssClass="cssLabelWithBorder" Height="50px"
                                                        runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="panelDeployment" Visible="false" ScrollBars="Auto" CssClass="ScrollBarPortal"
                                        Width="100%" runat="server">
                                        <table width="40%" style="border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label31" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, WeekNo %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldWeekNo" BackColor="Gray" CssClass="cssLabel" ForeColor="White"
                                                        Width="100%" MaxLength="5" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewWeekNo" CssClass="cssLabelWithBorder" Width="98%" MaxLength="5"
                                                        runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label32" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Shift %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldShift" Width="100%" BackColor="Gray" CssClass="cssLabel" ForeColor="White"
                                                        runat="server">
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewShift" Width="98%" CssClass="cssLabelWithBorder" runat="server">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label33" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Date %>"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldWefDate" Width="100%" BackColor="Gray" CssClass="cssLabel" ForeColor="White"
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewWefDate" Width="98%" CssClass="cssLabelWithBorder" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr>
                                                <td style="background-color: #eeeeee;">
                                                </td>
                                                <td style="background-color: #C9DBEC;" width="150px">
                                                    <asp:Label ID="Label34" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Sunday %>"></asp:Label>
                                                </td>
                                                <td style="background-color: #eeeeee;" width="150px">
                                                    <asp:Label ID="Label35" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Monday %>"></asp:Label>
                                                </td>
                                                <td style="background-color: #C9DBEC;" width="150px">
                                                    <asp:Label ID="Label36" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Tuesday %>"></asp:Label>
                                                </td>
                                                <td style="background-color: #eeeeee;" width="150px">
                                                    <asp:Label ID="Label37" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Wednesday %>"></asp:Label>
                                                </td>
                                                <td style="background-color: #C9DBEC;" width="150px">
                                                    <asp:Label ID="Label38" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Thursday %>"></asp:Label>
                                                </td>
                                                <td style="background-color: #eeeeee;" width="150px">
                                                    <asp:Label ID="Label39" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Friday %>"></asp:Label>
                                                </td>
                                                <td style="background-color: #C9DBEC;" width="150px">
                                                    <asp:Label ID="Label40" CssClass="cssLabel" Font-Bold="true" runat="server" Text="<%$ Resources:Resource, Saturday %>"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 0px; text-align: right; white-space: nowrap;">
                                                    <asp:Label ID="Label47" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="Old No of Person "></asp:Label>&nbsp;:&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldSundayNoOfPerson" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldMondayNoOfPerson" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldTuesdayNoOfPerson" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldWednesdayNoOfPerson" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldThursdayNoOfPerson" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldFridayNoOfPerson" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldSaturdayNoOfPerson" Width="100%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 0px; text-align: right; white-space: nowrap;">
                                                    <asp:Label ID="ltrNoOfPersons" CssClass="cssLabel" Font-Size="Smaller" runat="server"
                                                        Text="<%$Resources:Resource,NoOfPersons %>"></asp:Label>&nbsp;:&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewSundayNoOfPerson" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewMondayNoOfPerson" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewTuesdayNoOfPerson" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewWednesdayNoOfPerson" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewThursdayNoOfPerson" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewFridayNoOfPerson" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewSaturdayNoOfPerson" Width="100%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 0px; text-align: right; white-space: nowrap;">
                                                    <asp:Label ID="Label48" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="OldShiftTime"></asp:Label>&nbsp;:&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldSundayTimeFrom" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                    <asp:Label ID="lblSunTo" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblOldSundayTimeTo" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldMondayTimeFrom" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                    <asp:Label ID="Label41" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblOldMondayTimeTo" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldTuesdayTimeFrom" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                    <asp:Label ID="Label42" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblOldTuesdayTimeTo" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldWednesdayTimeFrom" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                    <asp:Label ID="Label43" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblOldWednesdayTimeTo" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldThursdayTimeFrom" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                    <asp:Label ID="Label44" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblOldThursdayTimeTo" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldFridayTimeFrom" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                    <asp:Label ID="Label45" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblOldFridayTimeTo" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOldSaturdayTimeFrom" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                    <asp:Label ID="Label46" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblOldSaturdayTimeTo" Width="40%" BackColor="Gray" CssClass="cssLabel"
                                                        ForeColor="White" runat="server" MaxLength="5"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 0px; text-align: right; white-space: nowrap;">
                                                    <asp:Label ID="lblShiftTime" CssClass="cssLabel" Font-Size="Smaller" runat="server"
                                                        Text="<%$ Resources:Resource, ShiftTime %>"></asp:Label>&nbsp;:&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewSundayTimeFrom" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="5"></asp:Label>
                                                    <asp:Label ID="lblNewSunTo" CssClass="cssLabel" Font-Size="Smaller" runat="server"
                                                        Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblNewSundayTimeTo" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewMondayTimeFrom" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="4"></asp:Label>
                                                    <asp:Label ID="Label50" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblNewMondayTimeTo" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewTuesdayTimeFrom" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="4"></asp:Label>
                                                    <asp:Label ID="Label49" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblNewTuesdayTimeTo" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewWednesdayTimeFrom" Width="38%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                    <asp:Label ID="Label51" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblNewWednesdayTimeTo" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewThursdayTimeFrom" Width="38%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                    <asp:Label ID="Label52" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblNewThursdayTimeTo" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewFridayTimeFrom" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="4"></asp:Label>
                                                    <asp:Label ID="Label53" CssClass="cssLabel" Font-Size="Smaller" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblNewFridayTimeTo" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="5"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNewSaturdayTimeFrom" Width="38%" CssClass="cssLabelWithBorder"
                                                        runat="server" MaxLength="4"></asp:Label>
                                                    <asp:Label ID="Label54" CssClass="cssLabel" Font-Size="XX-Small" runat="server" Text="<%$ Resources:Resource, To %>"></asp:Label>
                                                    <asp:Label ID="lblNewSaturdayTimeTo" Width="38%" CssClass="cssLabelWithBorder" runat="server"
                                                        MaxLength="5"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelFooter" Width="100%" runat="server">
                                        <table width="98%">
                                            <tr>
                                                <td style="width: 5%; text-align: right">
                                                    <asp:Label ID="Label17" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,YourComment %>"></asp:Label>
                                                </td>
                                                <td colspan="3" style="text-align: left">
                                                    <asp:TextBox ID="lblAuthorizedByComment" Height="40px" Width="100%" runat="server"
                                                        CssClass="csstxtbox" TextMode="MultiLine" Text=""></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPane>
                </telerik:RadSplitter>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
