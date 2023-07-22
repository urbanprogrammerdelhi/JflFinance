<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetScheduling.aspx.cs" Inherits="AssetManagement_AssetScheduling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="AssetScheduler">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AssetScheduler" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="RadAjaxLoadingPanel1">
        <asp:HiddenField ID="hfAssetCode" Value ="" runat="server"/>
        <telerik:RadScheduler RenderMode="Lightweight" runat="server" ID="AssetScheduler" GroupBy="Assets" GroupingDirection="Horizontal"
            OnNavigationCommand="AssetScheduler_NavigationCommand" OnAppointmentInsert="AssetScheduler_AppointmentInsert" AppointmentStyleMode="Default" DataKeyField="AssetSchedulerId"
            DataSubjectField="Description" DataStartField="StartDate" DataEndField="EndDate" DataRecurrenceField="RecurrenceRule"
            SelectedView="WeekView" DataRecurrenceParentKeyField="RecurrenceParentId" OnResourceHeaderCreated="AssetScheduler_ResourceHeaderCreated"
            OverflowBehavior="Scroll">
            <AdvancedForm Modal="true"></AdvancedForm>
            <MonthView UserSelectable="false"></MonthView>
            <%--<TimelineView SlotDuration="30:00"></TimelineView>--%>
            <DayView DayStartTime="09:00" DayEndTime="21:00"></DayView>
            <AppointmentTemplate>
                <div class="appointmentHeader">
                    <asp:Panel ID="RecurrencePanel" CssClass="rsAptRecurrence" runat="server" Visible="false">
                    </asp:Panel>
                    <asp:Panel ID="RecurrenceExceptionPanel" CssClass="rsAptRecurrenceException" runat="server" Visible="false">
                    </asp:Panel>
                    <asp:Panel ID="ReminderPanel" CssClass="rsAptReminder" runat="server" Visible="false">
                    </asp:Panel>
                </div>
                <div>
                    <%#Eval("Subject") %>
                    Service Type: <strong>
                        <asp:Label ID="UserLabel" runat="server" Text='<%# Container.Appointment.Resources.GetResourceByType("User") == null ? "None" : Container.Appointment.Resources.GetResourceByType("User").Text %>'></asp:Label></strong><br />
                </div>
            </AppointmentTemplate>
            <AdvancedEditTemplate>
            </AdvancedEditTemplate>
            <ResourceHeaderTemplate>
                <asp:Panel ID="ResourceImageWrapper" runat="server" CssClass="ResCustomClass">
                    <asp:Image ID="AssetImage" runat="server" Width="150px" Height="100px" AlternateText='<%# Eval("Text") %>'></asp:Image><br />
                    Code:&nbsp;<asp:Label ID="lblAssetCode" runat="server" Text='<%# Eval("Key") %>'></asp:Label><br />
                    Name:&nbsp;<asp:Label ID="lblAssetName" runat="server" Text='<%# Eval("Text") %>'></asp:Label><br />
                    Model No.:&nbsp;<asp:Label ID="lblModelNo" runat="server" Text=""></asp:Label><br />
                    Model Name:&nbsp;<asp:Label ID="lblModelName" runat="server" Text=""></asp:Label><br />
                    Serial No.:&nbsp;<asp:Label ID="lblSerialNo" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hfPhoto" Value="" runat="server"/>
                </asp:Panel>
            </ResourceHeaderTemplate>
            <ResourceTypes>
                <telerik:ResourceType KeyField="AssetCode" Name="Asset" TextField="AssetName" ForeignKeyField="AssetCode" DataSourceID="AssetDataSource"></telerik:ResourceType>
            </ResourceTypes>
            <ResourceTypes>
                <telerik:ResourceType KeyField="WorkOrderId" Name="WorkOrder" TextField="WorkOrderId" ForeignKeyField="WorkOrderId" DataSourceID="WODataSource"></telerik:ResourceType>
                <telerik:ResourceType KeyField="ServiceTypeAutoId" Name="ServiceType" TextField="ServiceTypeName" ForeignKeyField="ServiceTypeAutoId" DataSourceID="WODataSource"></telerik:ResourceType>
            </ResourceTypes>
            <TimeSlotContextMenuSettings EnableDefault="true"></TimeSlotContextMenuSettings>
            <AppointmentContextMenuSettings EnableDefault="true"></AppointmentContextMenuSettings>
        </telerik:RadScheduler>
    </telerik:RadAjaxPanel>
    <asp:SqlDataSource ID="SchedulerDataSource" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="WODataSource" runat="server" SelectCommand="Select WO.WorkOrderAutoId, ST.AssetServiceTypeAutoId, ST.AssetServiceTypeName From MstWorkOrder WO (nolock) Inner Join MstAssetServiceType ST (nolock) ON WO.ServiceAutoId = ST.AssetServiceTypeAutoId"></asp:SqlDataSource>
     <asp:SqlDataSource ID="AssetDataSource" runat="server" SelectCommand="udpAssetGet" SelectCommandType="StoredProcedure">
         <%--<SelectParameters>
             <asp:Parameter Name="AssetCode" Type="String"></asp:Parameter>
         </SelectParameters>--%>
     </asp:SqlDataSource>
</asp:Content>

