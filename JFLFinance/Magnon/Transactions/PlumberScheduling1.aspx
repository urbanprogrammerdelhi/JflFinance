<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlumberScheduling1.aspx.cs" Inherits="Transactions_PlumberScheduling1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/styles.css" rel="stylesheet" />
    <script src="../javaScript/jquery-1.11.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <telerik:RadScriptBlock runat="Server" ID="RadScriptBlock1">
        <script type="text/javascript">
            /* <![CDATA[ */
            Sys.Application.add_load(function () {
                demo.scheduler = $find("<%= RadScheduler1.ClientID %>");
                demo.targetSlotHiddenFieldId = "<%=TargetSlotHiddenField.ClientID %>";
            });
            /* ]]> */
        </script>
        <script type="text/javascript" src="scripts.js"></script>
    </telerik:RadScriptBlock>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
        
        <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="RadAjaxLoadingPanel1">
        <div id="ShowhideHeader" style="cursor:pointer ;background: #555 none repeat scroll 0 0; border: 1px solid #666; border-radius: 3px; color: #ffffff; font-size: 16px; line-height: 30px; margin: auto; padding: 5px; text-align: center;">Click to show/hide Timeline</div>
        <div id="divScheduler" class="demo-container no-bg" style="display:block;">
            <input type="hidden" runat="server" id="TargetSlotHiddenField" />
            <telerik:RadScheduler RenderMode="Lightweight" runat="server" ID="RadScheduler1" GroupBy="Employee" GroupingDirection="Horizontal"
                OnNavigationCommand="RadScheduler1_NavigationCommand" SelectedDate="2016-04-16" 
                AppointmentStyleMode="Default" DataSourceID="EventsDataSource" DataKeyField="ID"
                FirstDayOfWeek="Monday" LastDayOfWeek="Sunday" DataSubjectField="Description"
                DataStartField="Start" DataEndField="End" DataRecurrenceField="RecurrenceRule" MinutesPerRow="30" 
                SelectedView="DayView" DataRecurrenceParentKeyField="RecurrenceParentID" OnResourceHeaderCreated="RadScheduler1_ResourceHeaderCreated"
                OverflowBehavior="Auto">
                <AdvancedForm Modal="true"></AdvancedForm>
                <MonthView UserSelectable="false"></MonthView>
                <TimelineView SlotDuration="15:00"></TimelineView>
                <DayView DayStartTime="09:00" DayEndTime="21:00"></DayView>
                <AppointmentTemplate>
                <div class="appointmentHeader">
                    <asp:Panel ID="RecurrencePanel" CssClass="rsAptRecurrence" runat="server" Visible="false">
                    </asp:Panel>
                    <asp:Panel ID="RecurrenceExceptionPanel" CssClass="rsAptRecurrenceException" runat="server" Visible="false">
                    </asp:Panel>
                    <asp:Panel ID="ReminderPanel" CssClass="rsAptReminder" runat="server" Visible="false">
                    </asp:Panel>
                    <%#Eval("Subject") %>
                </div>
                <div>
                    Assigned to: <strong>
                        <asp:Label ID="UserLabel" runat="server" Text='<%# Container.Appointment.Resources.GetResourceByType("User") == null ? "None" : Container.Appointment.Resources.GetResourceByType("User").Text %>'></asp:Label>
                    </strong>
                    <br />
                    <%--<asp:CheckBox ID="CompletedStatusCheckBox" runat="server" Text="Completed? " TextAlign="Left"
                        Checked='<%# String.IsNullOrEmpty(Container.Appointment.Attributes["Completed"])? false : Boolean.Parse(Container.Appointment.Attributes["Completed"]) %>'
                        AutoPostBack="true" OnCheckedChanged="CompletedStatusCheckBox_CheckedChanged"></asp:CheckBox>--%>
                </div>
            </AppointmentTemplate>
            <AdvancedEditTemplate>

            </AdvancedEditTemplate>
                <ResourceHeaderTemplate>
                    <asp:Panel ID="ResourceImageWrapper" runat="server" CssClass="ResCustomClass">
                        <asp:Image ID="EmployeeImage" runat="server" AlternateText='<%# Eval("Text") %>'></asp:Image><br />
                        <asp:Label Id="lblEmployeeName" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </ResourceHeaderTemplate>
                <ResourceTypes>
                    <telerik:ResourceType KeyField="EmployeeNumber" Name="Employee" TextField="EmployeeName" ForeignKeyField="EmployeeNumber" DataSourceID="EmployeeDataSource"></telerik:ResourceType>
                </ResourceTypes>
                <ResourceStyles>
                    <telerik:ResourceStyleMapping Type="Employee" Key="1" BackColor="#eb901b"></telerik:ResourceStyleMapping>
                    <telerik:ResourceStyleMapping Type="Employee" Key="2" BackColor="#8fd21b"></telerik:ResourceStyleMapping>
                    <telerik:ResourceStyleMapping Type="Employee" Key="3" BackColor="#278ce9"></telerik:ResourceStyleMapping>
                    <telerik:ResourceStyleMapping Type="Employee" Key="4" BackColor="#f14db2"></telerik:ResourceStyleMapping>
                </ResourceStyles>
                <TimeSlotContextMenuSettings EnableDefault="true"></TimeSlotContextMenuSettings>
                <AppointmentContextMenuSettings EnableDefault="true"></AppointmentContextMenuSettings>
            </telerik:RadScheduler>
        </div>
    </telerik:RadAjaxPanel>
    <%--<asp:SqlDataSource ID="EmployeeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:myConnectionString %>"
         SelectCommand="SELECT EmployeeNumber, FirstName + ' ' + LastName as EmployeeName from MstHrEmployeeMaster Where EmployeeNumber in ('006','101034','1231','1336')"></asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="EmployeeDataSource" runat="server"
         SelectCommand="SELECT top 4 EmployeeNumber, FirstName + ' ' + LastName as EmployeeName from MstHrEmployeeMaster"></asp:SqlDataSource>

<%--    <asp:SqlDataSource ID="EventsDataSource" runat="server"
        SelectCommand="SELECT ID, [Description], Start, [End], WorkOrderID, RecurrenceRule, RecurrenceParentID, EmployeeNumber FROM Grouping_Events" 
        InsertCommand="INSERT INTO [Grouping_Events] ([Description], [Start], [End], [WorkOrderID], [RecurrenceRule], [RecurrenceParentID], [EmployeeNumber]) VALUES (@Description, @Start, @End, @WorkOrderID, @RecurrenceRule, @RecurrenceParentID, @EmployeeNumber)"
        UpdateCommand="UPDATE [Grouping_Events] SET [Description] = @Description, [Start] = @Start, [End] = @End, [WorkOrderID] = @WorkOrderID, [RecurrenceRule] = @RecurrenceRule, [RecurrenceParentID] = @RecurrenceParentID, [EmployeeNumber] = @EmployeeNumber WHERE [ID] = @ID"
        DeleteCommand="DELETE FROM [Grouping_Events] WHERE [ID] = @ID">--%>
        <asp:SqlDataSource ID="EventsDataSource" runat="server"
        SelectCommand="SELECT ID, [Description], Start, [End], WorkOrderID, RecurrenceRule, RecurrenceParentID, EmployeeNumber FROM Grouping_Events" 
        InsertCommand="INSERT INTO [Grouping_Events] ([Description], [Start], [End], [WorkOrderID], [RecurrenceRule], [RecurrenceParentID], [EmployeeNumber]) VALUES (@Description, @Start, @End, @WorkOrderID, @RecurrenceRule, @RecurrenceParentID, @EmployeeNumber)"
        UpdateCommand="UPDATE [Grouping_Events] SET [Description] = @Description, [Start] = @Start, [End] = @End, [WorkOrderID] = @WorkOrderID, [RecurrenceRule] = @RecurrenceRule, [RecurrenceParentID] = @RecurrenceParentID, [EmployeeNumber] = @EmployeeNumber WHERE [ID] = @ID"
        DeleteCommand="DELETE FROM [Grouping_Events] WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Description" Type="String"></asp:Parameter>
            <asp:Parameter Name="Start" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="End" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="WorkOrderID" Type="Int32" DefaultValue="1"></asp:Parameter>
            <asp:Parameter Name="RecurrenceRule" Type="String"></asp:Parameter>
            <asp:Parameter Name="RecurrenceParentID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="EmployeeNumber" Type="String"></asp:Parameter>
            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Description" Type="String"></asp:Parameter>
            <asp:Parameter Name="Start" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="End" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="WorkOrderID" Type="Int32" DefaultValue="1"></asp:Parameter>
            <asp:Parameter Name="RecurrenceRule" Type="String"></asp:Parameter>
            <asp:Parameter Name="RecurrenceParentID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="EmployeeNumber" Type="String"></asp:Parameter>
        </InsertParameters>
    </asp:SqlDataSource>
        
        <div style="margin-left: 56px; border: none;">
        <telerik:RadGrid RenderMode="Lightweight" runat="server" ID="RadGrid1" DataSourceID="GridDataSource" GridLines="None"
                        AutoGenerateColumns="False" OnRowDrop="RadGrid1_RowDrop" Skin="Metro" Style="border: none; outline: 0"
                        Height="100%" ShowFooter="False" OnItemCreated="RadGrid1_ItemCreated"
                        AllowSorting="true">
                        <ClientSettings AllowRowsDragDrop="True">
                            <Selecting AllowRowSelect="True"></Selecting>
                            <ClientEvents OnRowDropping="rowDropping" OnRowDblClick="onRowDoubleClick"></ClientEvents>
                        </ClientSettings>
                        <MasterTableView DataKeyNames="WorkOrderAutoId" InsertItemDisplay="Bottom">
                            <Columns>
                                <telerik:GridTemplateColumn >
                                    <ItemTemplate>
                                        <asp:Button id="AssignEmployee" Text="AssignEmployee" runat="server"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="CustomerId" HeaderText="Customer Id" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblWorkOrderAutoId" Text='<%# Bind("WorkOrderAutoId") %>'></asp:Label>
                                        <asp:Label runat="server" ID="lblServiceAutoId" Text='<%# Bind("ServiceAutoId") %>'></asp:Label>
                                        <asp:Label runat="server" ID="lblCustomerId" Text='<%# Bind("UserId") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="ServiceType" HeaderText="Service Type">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblServiceType" Tooltip='<%# Bind("ServiceType") %>' Text='<%# Bind("ServiceType") %>' style="width: 120px; display: inline-block; white-space: nowrap; overflow: hidden; text-overflow: clip;"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="Server" ID="lblServiceType" Text='<%# Bind("ServiceType") %>' Width="100%"></asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="Location" HeaderText="Location" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblLocation" Text='<%# Bind("Location") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridDateTimeColumn DataField="PreferredFromDate" HeaderText="Preferred From Date" DataFormatString="{0:d}"
                                    HeaderStyle-Width="150px">
                                </telerik:GridDateTimeColumn>
                                <telerik:GridDateTimeColumn DataField="PreferredToDate" HeaderText="Preferred To Date" DataFormatString="{0:d} "
                                    HeaderStyle-Width="150px">
                                </telerik:GridDateTimeColumn>
                                <telerik:GridTemplateColumn DataField="PreferredFromTime" HeaderText="Preferred Time" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPreferredFromTime" Text='<%# Bind("PreferredFromTime") %>'></asp:Label>-
                                        <asp:Label runat="server" ID="lblPreferredToTime" Text='<%# Bind("PreferredToTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="Status" HeaderText="Status" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label runat="Server" ID="lblStatus" Text='<%#Bind("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
            <asp:SqlDataSource ID="GridDataSource" runat="server" 
                SelectCommand="Select WorkOrderAutoId, UserId, Location, ServiceAutoId, PreferredFromDate, PreferredToDate, PreferredFromTime, PreferredToTime, 'Service: Plumbing | Address: ' + isnull(BuildingNo,'') + ', ' + isnull(FloorNo,'') + ', ' + isnull(Locality,'') + ', ' + isnull(Landmark,'') + ', ' + isnull(City,'') + ', ' + isnull(District,'') + ', ' + isnull([State],'') + ', PIN-' + isnull(PIN,'') + ' | Mobile No.: ' + isnull(MobileNo, '') + ' | Preferred Date ' + Convert(Nvarchar(11),PreferredFromDate, 13) + ' To ' + Convert(Nvarchar(11),PreferredToDate, 13) + ' | Preferred Time:' + isnull(PreferredFromTime,'') + ' - ' + isnull(PreferredToTime,'')  as ServiceType, [Status] from MstWorkOrder">
                
            </asp:SqlDataSource>
        </div>
    </div>
    </form>
    <script type="text/javascript">
            
        $("#ShowhideHeader").click(function () {
            $("#divScheduler").toggle();
        });
        </script>
</body>
</html>
