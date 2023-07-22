using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Scheduler.Views;

public partial class Transactions_PlumberScheduling1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            DL.ConnectionString conString = new DL.ConnectionString();
            EmployeeDataSource.ConnectionString = conString.GetConnectionString();
            EventsDataSource.ConnectionString = conString.GetConnectionString();
            GridDataSource.ConnectionString = conString.GetConnectionString();
            UpdateScheduler();
        //}
    }

    protected void RadScheduler1_ResourceHeaderCreated(object sender, ResourceHeaderCreatedEventArgs e)
    {
        Panel ResourceImageWrapper = e.Container.FindControl("ResourceImageWrapper") as Panel;
        ResourceImageWrapper.CssClass = "Resource" + e.Container.Resource.Key.ToString();

        Image img = e.Container.FindControl("EmployeeImage") as Image;
        img.ImageUrl = "../DocumentUpload/EmployeeImages/" + e.Container.Resource.Key.ToString().ToLower() + ".jpg";

        Label lblEmployeeName = e.Container.FindControl("lblEmployeeName") as Label;
        lblEmployeeName.Text = e.Container.Resource.Text;

    }

    private void UpdateScheduler()
    {
        RadScheduler1.GroupBy = GroupByExpression;
        RadScheduler1.GroupingDirection = (GroupingDirection)Enum.Parse(typeof(GroupingDirection), "Vertical");
        //RadScheduler1.GroupingDirection = (GroupingDirection)Enum.Parse(typeof(GroupingDirection), "Horizontal");

        RadScheduler1.Rebind();
    }

    private string GroupByExpression
    {
        get
        {
            return "Employee";
        }
    }

    protected void GroupingDirectionComboBox_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        UpdateScheduler();
    }

    protected void GroupByDateCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        UpdateScheduler();
    }

    protected void RadScheduler1_NavigationCommand(object sender, SchedulerNavigationCommandEventArgs e)
    {
        if (e.Command == SchedulerNavigationCommand.SwitchToTimelineView)
        {
            RadScheduler1.RowHeight = 50;
        }
        else
        {
            RadScheduler1.RowHeight = 20;
        }

    }

    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridFooterItem && RadGrid1.MasterTableView.IsItemInserted)
        {
            e.Item.Visible = false;
        }
    }

    protected void RadGrid1_RowDrop(object sender, GridDragDropEventArgs e)
    {
        GridDataItem dataItem = e.DraggedItems[0];

        Hashtable values = new Hashtable();
        dataItem.ExtractValues(values);

        int id = int.Parse(dataItem.GetDataKeyValue("WorkOrderAutoId").ToString());
        string subject = (string)values["ServiceType"];
        string targetSlotIndex = TargetSlotHiddenField.Value;

        if (targetSlotIndex != string.Empty)
        {
            HandleSchedulerDrop(id, subject, targetSlotIndex);
            TargetSlotHiddenField.Value = string.Empty;
        }
        RadScheduler1.Rebind();
        RadGrid1.Rebind();
        RadAjaxManager1.AjaxSettings.AddAjaxSetting(RadGrid1, RadScheduler1);
    }

    private void HandleSchedulerDrop(int id, string subject, string targetSlotIndex)
    {
        RadScheduler1.Rebind();

        ISchedulerTimeSlot slot = RadScheduler1.GetTimeSlotFromIndex(targetSlotIndex);

        TimeSpan duration = TimeSpan.FromHours(1);
        if (slot.Duration == TimeSpan.FromDays(1))
        {
            duration = slot.Duration;
        }
        string employeeNumber = slot.Resource.Key.ToString();

        ScheduleAppointment(id, subject, slot.Start, slot.Start.Add(duration), employeeNumber);
    }

    private void ScheduleAppointment(int id, string subject, DateTime start, DateTime end, string employeeNumber)
    {
        //Conditional message if time is not match
        RadWindowManager1.RadConfirm("Preferred Date Time Mismatch: Are you sure?", null, 330, 180, null, "Confirm", null);


        EventsDataSource.InsertParameters["Description"].DefaultValue = subject;
        EventsDataSource.InsertParameters["Start"].DefaultValue = start.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
        EventsDataSource.InsertParameters["End"].DefaultValue = end.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
        EventsDataSource.InsertParameters["WorkOrderID"].DefaultValue = id.ToString();
        EventsDataSource.InsertParameters["RecurrenceRule"].DefaultValue = null;
        EventsDataSource.InsertParameters["RecurrenceParentID"].DefaultValue = null;
        EventsDataSource.InsertParameters["EmployeeNumber"].DefaultValue = employeeNumber;
        EventsDataSource.Insert();
    }

    private static bool OnDataSourceOperationComplete(int count, Exception e)
    {
        if (e != null)
        {
            throw e;
        }
        return true;
    }

    protected void RadScheduler1_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
    {
        e.Appointment.Attributes["PreferredFromDate"] = e.Appointment.Start.AddDays(1).ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
        e.Appointment.Attributes["Status"] = "New";
    }
}