using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.Drawing;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class AssetManagement_TaskMaster : BasePage
{
    static int dtflag;
    static int dtflag1;
    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsReadAccess
    {
        get
        {
            try
            {
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }
    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                var bp = new BasePage();
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                FillddlClientCode();
                FillddlSiteId(ddlClientCode.SelectedItem.Value);
                FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
                FillgvTaskMaster();
                pnlDailyTask.Visible = false;
                pnlTaskMaster.Visible = true;
                btnExport.Visible = true;
                pnlTaskImage.Visible = false;
            }
        }
        txtDate.Attributes.Add("readonly", "readonly");
        txtToDate.Attributes.Add("readonly", "readonly");

    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlSiteId(ddlClientCode.SelectedItem.Value);
        FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
        FillgvTaskMaster();
    }
    protected void ddlSiteId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
        FillgvTaskMaster();
    }
    protected void ddlPostCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvTaskMaster();
    }
    private void FillddlClientCode()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlClientCode.DataSource = objAssetManagement.GetClientCode(BaseLocationAutoID);
        ddlClientCode.DataTextField = "ClientCodenName";
        ddlClientCode.DataValueField = "ClientCode";
        ddlClientCode.DataBind();
        // ddlClientCode.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlClientCode.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlClientCode.Items.Add(li);
        }
    }
    private void FillddlSiteId(string ClientCode)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlSiteId.DataSource = objAssetManagement.GetAsmtId(ClientCode, BaseLocationAutoID);
        ddlSiteId.DataTextField = "SiteCodenName";
        ddlSiteId.DataValueField = "AsmtId";
        ddlSiteId.DataBind();
        // ddlSiteId.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlSiteId.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlSiteId.Items.Add(li);
        }
    }
    private void FillddlPostCode(string ClientCode, string AsmtId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlPostCode.DataSource = objAssetManagement.GetPostCode(ClientCode, AsmtId, BaseLocationAutoID);
        ddlPostCode.DataTextField = "PostCodenName";
        ddlPostCode.DataValueField = "PostAutoId";
        ddlPostCode.DataBind();
        ddlPostCode.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlPostCode.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlPostCode.Items.Add(li);
        }
    }
    protected void gvTaskMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTaskMaster.PageIndex = e.NewPageIndex;
        gvTaskMaster.EditIndex = -1;
        FillgvTaskMaster();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Button objLinkButton = (Button)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfAutoId = (HiddenField)gvTaskMaster.Rows[row.RowIndex].FindControl("hfAutoId");
        HiddenField hfAssetScheduleAutoId = (HiddenField)gvTaskMaster.Rows[row.RowIndex].FindControl("hfAssetScheduleAutoId");
        Label lblSiteId = (Label)gvTaskMaster.Rows[row.RowIndex].FindControl("lblSiteId");
        Label lblPerformer = (Label)gvTaskMaster.Rows[row.RowIndex].FindControl("lblPerformer");
        HiddenField hfAssetAutoID1 = (HiddenField)gvTaskMaster.Rows[row.RowIndex].FindControl("hfAssetAutoID1");
        pnlDailyTask.Visible = true;
        pnlTaskMaster.Visible = false;
        btnExport.Visible = false;
        pnlTaskImage.Visible = false;
        hfTaskAutoId.Value = hfAutoId.Value;
        hfAutoAssetID.Value = hfAssetAutoID1.Value;
        hfAssetAutoId.Value = hfAssetScheduleAutoId.Value;
        hfAsmtId.Value = lblSiteId.Text;
        if (lblPerformer.Text == "Employee Not Scheduled")
        {
            hfPerformerName.Value = "NS";
            FillgvDailyTaskUnSchedulled(hfAutoId.Value, lblSiteId.Text);

        }
        else
        {
            hfPerformerName.Value = "S";
            FillgvDailyTask(hfAutoId.Value, lblSiteId.Text, hfAutoAssetID.Value);
        }
    }
    private void FillgvTaskMaster()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsTaskMaster = new DataSet();
            var dtTaskMaster = new DataTable();
            dtflag1 = 1;
            dsTaskMaster = objAssetMgmt.GetPerformerSiteDetails(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value, ddlPostCode.SelectedItem.Value, BaseLocationAutoID, txtDate.Text);
            dtTaskMaster = dsTaskMaster.Tables[0];
            if (dtTaskMaster.Rows.Count == 0)
            {
                dtflag1 = 0;
                dtTaskMaster.Rows.Add(dtTaskMaster.NewRow());
            }
            gvTaskMaster.DataSource = dtTaskMaster;
            gvTaskMaster.DataBind();

            if (dtflag1 == 0)
            {
                gvTaskMaster.Rows[0].Visible = false;
                dtflag1 = 0;
            }
            else
            {
                dtflag1 = 1;
            }

        }
        catch (Exception ex)
        {
        }
    }

    protected void gvDailyTask_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDailyTask.EditIndex = -1;
        if (hfPerformerName.Value == "NS")
        {
            FillgvDailyTaskUnSchedulled(hfTaskAutoId.Value, lblSiteId.Text);
        }
        else
        {
            FillgvDailyTask(hfTaskAutoId.Value, hfAsmtId.Value, hfAutoAssetID.Value);
        }
    }
    protected void gvDailyTask_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvDailyTask_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDailyTask.EditIndex = e.NewEditIndex;
        if (hfPerformerName.Value == "NS")
        {
            FillgvDailyTaskUnSchedulled(hfTaskAutoId.Value, lblSiteId.Text);
        }
        else
        {
            FillgvDailyTask(hfTaskAutoId.Value, hfAsmtId.Value, hfAutoAssetID.Value);
        }
    }
    protected void gvDailyTask_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objAssetMgmt = new BL.AssetManagement();
        Label lblTaskName = (Label)gvDailyTask.Rows[e.RowIndex].FindControl("lblTaskName");
        DropDownList ddlStatus = (DropDownList)gvDailyTask.Rows[e.RowIndex].FindControl("ddlStatus");
        string[] TaskNAmeSplit = lblTaskName.Text.Split('(');
        string Time = TaskNAmeSplit[1].ToString();
        string[] FromTime = Time.Split('-');
        string ToTime1 = FromTime[1].ToString();
        string[] ToTime = ToTime1.Split(')');

        ds = objAssetMgmt.UpdateDailyTaskStatus(hfAssetAutoId.Value, TaskNAmeSplit[0].ToString(), ddlStatus.SelectedItem.Value, BaseLocationAutoID, BaseUserID, txtDate.Text);
        gvDailyTask.EditIndex = -1;
        if (hfPerformerName.Value == "NS")
        {
            FillgvDailyTaskUnSchedulled(hfTaskAutoId.Value, lblSiteId.Text);
        }
        else
        {
            FillgvDailyTask(hfTaskAutoId.Value, hfAsmtId.Value, hfAutoAssetID.Value);
        }
        lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();

    }
    protected void gvDailyTask_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyTask.PageIndex = e.NewPageIndex;
        gvDailyTask.EditIndex = -1;
        if (hfPerformerName.Value == "NS")
        {
            FillgvDailyTaskUnSchedulled(hfTaskAutoId.Value, lblSiteId.Text);
        }
        else
        {
            FillgvDailyTask(hfTaskAutoId.Value, hfAsmtId.Value, hfAutoAssetID.Value);
        }
    }
    private void FillgvDailyTask(string AutoId, string AsmtId, string AssetAutoID)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsDailyTask = new DataSet();
            var dtDailyTask = new DataTable();
            dtflag = 1;
            dsDailyTask = objAssetMgmt.GetDailyTaskDetail(AutoId, AsmtId, BaseLocationAutoID, txtDate.Text, AssetAutoID);
            dtDailyTask = dsDailyTask.Tables[0];
            if (dtDailyTask.Rows.Count == 0)
            {
                dtflag = 0;
                dtDailyTask.Rows.Add(dtDailyTask.NewRow());
            }
            gvDailyTask.DataSource = dtDailyTask;
            gvDailyTask.DataBind();

            if (dtflag == 0)
            {
                gvDailyTask.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }

        }
        catch (Exception ex)
        {
        }
    }

    private void FillgvDailyTaskUnSchedulled(string AutoId, string AsmtId)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsDailyTask = new DataSet();
            var dtDailyTask = new DataTable();
            dtflag = 1;
            dsDailyTask = objAssetMgmt.GetDailyTaskDetailUnSchedulled(AutoId, AsmtId, BaseLocationAutoID);
            dtDailyTask = dsDailyTask.Tables[0];
            if (dtDailyTask.Rows.Count == 0)
            {
                dtflag = 0;
                dtDailyTask.Rows.Add(dtDailyTask.NewRow());
            }
            gvDailyTask.DataSource = dtDailyTask;
            gvDailyTask.DataBind();

            if (dtflag == 0)
            {
                gvDailyTask.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlDailyTask.Visible = false;
        pnlTaskMaster.Visible = true;
        btnExport.Visible = true;
        pnlTaskImage.Visible = false;
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        FillgvTaskMaster();
    }
    protected void gvImage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvImage.PageIndex = e.NewPageIndex;
        gvImage.EditIndex = -1;
        FillgvImage(hfImageAutoId.Value);

    }
    protected void btnbacktaskList_Click(object sender, EventArgs e)
    {
        pnlTaskImage.Visible = false;
        pnlDailyTask.Visible = true;
        pnlTaskMaster.Visible = false;
        btnExport.Visible = false;

    }
    protected void btnImage_Click(object sender, EventArgs e)
    {
        pnlTaskImage.Visible = true;
        pnlDailyTask.Visible = false;
        pnlTaskMaster.Visible = false;
        btnExport.Visible = false;
        Button objLinkButton = (Button)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        Label lblTaskName = (Label)gvDailyTask.Rows[row.RowIndex].FindControl("lblTaskName");
        hfImageAutoId.Value = lblTaskName.Text;
        FillgvImage(lblTaskName.Text);

    }
    protected void FillgvImage(string TaskName)
    {
        string[] TaskNAmeSplit = TaskName.Split('(');
        string Time = TaskNAmeSplit[1].ToString();
        string[] FromTime = Time.Split('-');
        string ToTime1 = FromTime[1].ToString();
        string[] ToTime = ToTime1.Split(')');
        var objAssetMgmt = new BL.AssetManagement();
        var ds = new DataSet();
        var dt = new DataTable();
        dtflag = 1;
        ds = objAssetMgmt.GetDailyTaskImage(TaskNAmeSplit[0].ToString(), BaseLocationAutoID, txtDate.Text, FromTime[0].ToString(), ToTime[0].ToString());
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
        ds.Tables[0].Columns.Add(dc);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["ItemImage"].ToString() != "")
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["ItemImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[i]["ItemImage"])).Length);
            }
            else
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = string.Empty;
            }
        }

        gvImage.DataSource = dt;
        gvImage.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvImage.Rows[0].Visible = false;
        }
    }
    protected void gvTaskMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblPerformer = (Label)e.Row.FindControl("lblPerformer");

            if (lblPerformer.Text == "Employee Not Scheduled")
            {
                lblPerformer.ForeColor = System.Drawing.Color.Red;
                lblPerformer.Font.Bold = true;
                //  hfPerformerName.Value = "Employee Not Scheduled";

            }
        }
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {

        FillgvTaskMaster();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=ScheduledEmployeeReport-" + txtDate.Text + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvTaskMaster.AllowPaging = false;
            FillgvTaskMaster();

            gvTaskMaster.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvTaskMaster.HeaderRow.Cells)
            {
                cell.BackColor = gvTaskMaster.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvTaskMaster.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvTaskMaster.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvTaskMaster.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvTaskMaster.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}