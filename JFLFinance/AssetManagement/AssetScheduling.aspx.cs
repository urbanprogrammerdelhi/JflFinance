using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Scheduler.Views;
using DL;
using System.Data;
public partial class AssetManagement_AssetScheduling : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["AssetCode"] != null)
        {
            hfAssetCode.Value = Request.QueryString["AssetCode"];
        }
        hfAssetCode.Value = "L001";

        AssetScheduler.SelectedDate = DateTime.Now;
        AssetScheduler.FirstDayOfWeek = System.DayOfWeek.Monday;
        AssetScheduler.LastDayOfWeek = System.DayOfWeek.Sunday;
        AssetScheduler.MinutesPerRow = 30;
        ConfigureSchedulerDataSource();
        UpdateScheduler();
    }

    private void ConfigureSchedulerDataSource()
    {
        DL.ConnectionString conString = new DL.ConnectionString();
        SchedulerDataSource.ConnectionString = conString.GetConnectionString();
        AssetDataSource.ConnectionString = conString.GetConnectionString();
        WODataSource.ConnectionString = conString.GetConnectionString();

        SchedulerDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        SchedulerDataSource.SelectCommand = "udpAssetServiceDeptGet";
        //SchedulerDataSource.SelectParameters.Add("AssetCode", System.Data.DbType.String, hfAssetCode.Value);

        SchedulerDataSource.InsertCommandType = SqlDataSourceCommandType.StoredProcedure;
        SchedulerDataSource.InsertCommand = "udpAssetServiceDeptInsert";
        SchedulerDataSource.InsertParameters.Add("WorkOrderId", System.Data.DbType.Int32, "WorkOrderId");
        SchedulerDataSource.InsertParameters.Add("ServiceTypeAutoId", System.Data.DbType.Int32, "ServiceTypeAutoId");
        SchedulerDataSource.InsertParameters.Add("AssetCode", System.Data.DbType.String, "AssetCode");
        SchedulerDataSource.InsertParameters.Add("Description", System.Data.DbType.String, "Description");
        SchedulerDataSource.InsertParameters.Add("StartTime", System.Data.DbType.DateTime, "StartTime");
        SchedulerDataSource.InsertParameters.Add("EndTime", System.Data.DbType.DateTime, "EndTime");
        SchedulerDataSource.InsertParameters.Add("RecurrenceRule", System.Data.DbType.String, "RecurrenceRule");
        SchedulerDataSource.InsertParameters.Add("RecurrenceParentId", System.Data.DbType.Int32, "RecurrenceParentId");
        SchedulerDataSource.InsertParameters.Add("AllDay", System.Data.DbType.Boolean, "AllDay");
        SchedulerDataSource.InsertParameters.Add("EventType", System.Data.DbType.Int32, "EventType");
        SchedulerDataSource.InsertParameters.Add("RecurrenceInfo", System.Data.DbType.String, "RecurrenceInfo");
        SchedulerDataSource.InsertParameters.Add("ReminderInfo", System.Data.DbType.String, "ReminderInfo");

        //SchedulerDataSource.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
        //SchedulerDataSource.UpdateCommand = "";
        //SchedulerDataSource.UpdateParameters.Add("", System.Data.DbType.String, "");

        //SchedulerDataSource.DeleteCommandType = SqlDataSourceCommandType.StoredProcedure;
        //SchedulerDataSource.DeleteCommand = "";
        //SchedulerDataSource.DeleteParameters.Add("", System.Data.DbType.String, "");
        AssetScheduler.DataSourceID = "SchedulerDataSource";


        //AssetDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        //AssetDataSource.SelectCommand = "udpAssetGetByCode";
        //AssetDataSource.SelectParameters.Add("AssetCode", System.Data.DbType.String, hfAssetCode.Value);

    }
    protected void AssetScheduler_ResourceHeaderCreated(object sender, ResourceHeaderCreatedEventArgs e)
    {
        Panel ResourceImageWrapper = e.Container.FindControl("ResourceImageWrapper") as Panel;
        ResourceImageWrapper.CssClass = "Resource" + e.Container.Resource.Key.ToString();

        

        //Label lblAssetCode = e.Container.FindControl("lblAssetCode") as Label;
        //if (lblAssetCode != null) { lblAssetCode.Text = e.Container.Resource.Text; }
        BL.AssetScheduling objAs = new BL.AssetScheduling();
        DataSet ds = new DataSet();
        ds = objAs.AssetGet(e.Container.Resource.Key.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Label lblModelNo = e.Container.FindControl("lblModelNo") as Label;
            if (lblModelNo != null) { lblModelNo.Text = ds.Tables[0].Rows[0]["ModelNo"].ToString(); }
            Label lblModelName = e.Container.FindControl("lblModelName") as Label;
            if (lblModelName != null) { lblModelName.Text = ds.Tables[0].Rows[0]["ModelName"].ToString(); }
            Label lblSerialNo = e.Container.FindControl("lblSerialNo") as Label;
            if (lblSerialNo != null) { lblSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString(); }
            HiddenField hfPhoto = e.Container.FindControl("hfPhoto") as HiddenField;
            if (hfPhoto != null) { 
                hfPhoto.Value = ds.Tables[0].Rows[0]["Photo"].ToString();
                string strPhoto = hfPhoto.Value.Substring((hfPhoto.Value.LastIndexOf("\\")+1),(hfPhoto.Value.Length - (hfPhoto.Value.LastIndexOf("\\") + 1)));

                Image img = e.Container.FindControl("AssetImage") as Image;
                if (img != null)
                {
                    img.ImageUrl = "../DocumentUpload/AssetDocUpload/" + strPhoto;
                }
            }

        }
    }

    private void UpdateScheduler()
    {
        AssetScheduler.GroupBy = "Asset";
        AssetScheduler.GroupingDirection = (GroupingDirection)Enum.Parse(typeof(GroupingDirection), "Vertical");

        var objAs = new BL.AssetScheduling();
        var ds = objAs.AssetGetAll();
        
        AssetScheduler.Rebind();
    }
    protected void AssetScheduler_NavigationCommand(object sender, SchedulerNavigationCommandEventArgs e)
    {
        if (e.Command == SchedulerNavigationCommand.SwitchToTimelineView)
        {
            AssetScheduler.RowHeight = 50;
        }
        else
        {
            AssetScheduler.RowHeight = 20;
        }
    }

    private void ScheduleAppointment(int id, string subject, DateTime start, DateTime end, string employeeNumber)
    {
        //Conditional message if time is not match
        //RadWindowManager1.RadConfirm("Preferred Date Time Mismatch: Are you sure?", null, 330, 180, null, "Confirm", null);


        //EventsDataSource.InsertParameters["Description"].DefaultValue = subject;
        //EventsDataSource.InsertParameters["Start"].DefaultValue = start.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
        //EventsDataSource.InsertParameters["End"].DefaultValue = end.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
        //EventsDataSource.InsertParameters["WorkOrderID"].DefaultValue = id.ToString();
        //EventsDataSource.InsertParameters["RecurrenceRule"].DefaultValue = null;
        //EventsDataSource.InsertParameters["RecurrenceParentID"].DefaultValue = null;
        //EventsDataSource.InsertParameters["EmployeeNumber"].DefaultValue = employeeNumber;
        //EventsDataSource.Insert();
    }

    protected void AssetScheduler_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
    {
        //Appointment app  = e.Appointment;
        //String subject  = app.Subject;
        //DateTime startTime = app.Start;
        //DateTime endTime = app.End;
        //String recurrenceRule = app.RecurrenceRule;
        //Int32 recurrenceParentID = int.Parse(app.RecurrenceParentID.ToString());
        //String description = app.Description;
        //String reminder = app.Reminders.ToString();
        //e.Appointment.Attributes["PreferredFromDate"] = e.Appointment.Start.AddDays(1).ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
        //e.Appointment.Attributes["Status"] = "New";
    }
}