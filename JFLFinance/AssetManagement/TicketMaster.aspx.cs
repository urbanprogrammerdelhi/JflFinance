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
using System.Data.SqlClient;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
public partial class AssetManagement_TicketMaster : BasePage
{
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
    static int dtflag;
    string labelclick;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                txtDate.Text = DateTime.Today.AddDays(-30).ToString("dd-MMM-yyyy");
                txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                if (txtUserId != null)
                {
                    txtUserId.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtUserId.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtTicketNo != null)
                {
                    txtTicketNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtTicketNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                ReadOnly();
                //   ddlStatusMain.SelectedItem.Value="ALL";
                FillgvTicketMaster();
                FillTicketDetails();
            }
        }
        txtDate.Attributes.Add("readonly", "readonly");
        txtToDate.Attributes.Add("readonly", "readonly");
    }
    private void FillTicketDetails()
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            if (BaseIsAdmin == "R")
            {
                ds = objAssetMgmt.TicketDetails(BaseLocationAutoID, txtDate.Text, txtToDate.Text,BaseUserID);
            }
            else
            {
                ds = objAssetMgmt.TicketDetails(BaseLocationAutoID, txtDate.Text, txtToDate.Text,"");
            }
            tTicketValuelbl.Text = ds.Tables[0].Rows[0]["TotalTicket"].ToString();
            nTicketValuelbl.Text = ds.Tables[1].Rows[0]["NewTicket"].ToString();
            aTicketValuelbl.Text = ds.Tables[3].Rows[0]["ApprovedTicket"].ToString();
            cTicketValuelbl.Text = ds.Tables[4].Rows[0]["CloseTicket"].ToString();
            rTicketValuelbl.Text = ds.Tables[2].Rows[0]["RejectTicket"].ToString();
        }
        catch (Exception ex)
        { }
    }
    protected void gvTicketMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTicketMaster.PageIndex = e.NewPageIndex;
        gvTicketMaster.EditIndex = -1;
        FillgvTicketMaster();
    }
    protected void gvTicketMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvTicketMaster.PageIndex * gvTicketMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblPerformer = (Label)e.Row.FindControl("lblUserID");

            if (lblPerformer.Text == "Performer Not Scheduled")
            {
                lblPerformer.ForeColor = System.Drawing.Color.Red;
                lblPerformer.Font.Bold = true;
                //  hfPerformerName.Value = "Employee Not Scheduled";
            }
        }
    }
    private void FillgvTicketMaster()
    {
        try
        {
            if (labelclick == "NEW") { labelclick = "NEW"; }
            else if (labelclick == "Approved") { labelclick = "Approved"; }
            else if (labelclick == "Closed") { labelclick = "Close"; }
            else if (labelclick == "Reject") { labelclick = "Reject"; }
            else { labelclick = ddlStatusMain.SelectedItem.Value; }
            //ddlStatusMain.SelectedValue = labelclick.ToString();
            var objAssetMgmt = new BL.AssetManagement();
            var dsTicketMaster = new DataSet();
            var dtTicketMaster = new DataTable();
            dtflag = 1;
            //      dsTicketMaster = objAssetMgmt.GetAllTicketsMaster(BaseLocationAutoID, labelclick, txtTicketNo.Text.Trim(), txtUserId.Text.Trim());
            if (BaseIsAdmin == "R")
            {
                dsTicketMaster = objAssetMgmt.GetAllTickets(BaseLocationAutoID, labelclick, txtTicketNo.Text.Trim(), txtUserId.Text.Trim(), txtDate.Text, txtToDate.Text,BaseUserID);
            }
            else
            {
                dsTicketMaster = objAssetMgmt.GetAllTickets(BaseLocationAutoID, labelclick, txtTicketNo.Text.Trim(), txtUserId.Text.Trim(), txtDate.Text, txtToDate.Text,"");
            }
            //dsTicketMaster = objAssetMgmt.GetAllTickets(BaseLocationAutoID, labelclick, txtTicketNo.Text.Trim(), txtUserId.Text.Trim(), txtDate.Text, txtToDate.Text);
            dtTicketMaster = dsTicketMaster.Tables[0];
            if (dtTicketMaster.Rows.Count == 0)
            {
                dtflag = 0;
                dtTicketMaster.Rows.Add(dtTicketMaster.NewRow());
            }
            gvTicketMaster.DataSource = dtTicketMaster;
            gvTicketMaster.DataBind();

            if (dtflag == 0)
            {
                gvTicketMaster.Rows[0].Visible = false;
                dtflag = 0;
                btnExport.Visible = false;
                lblmsg.Visible = true;
            }
            else
            {
                dtflag = 1;
                btnExport.Visible = true;
                lblmsg.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    //private void FillgvTicketMasterSearch()
    //{
    //    try
    //    {
    //        if (labelclick == "NEW") { labelclick = "NEW"; }
    //        else if (labelclick == "Approved") { labelclick = "Approved"; }
    //        else if (labelclick == "Closed") { labelclick = "Close"; }
    //        else if (labelclick == "Reject") { labelclick = "Reject"; }
    //        else { labelclick = ddlStatusMain.SelectedItem.Value; }

    //        var objAssetMgmt = new BL.AssetManagement();
    //        var dsTicketMaster = new DataSet();
    //        var dtTicketMaster = new DataTable();
    //        dtflag = 1;
    //        dsTicketMaster = objAssetMgmt.GetAllTickets(BaseLocationAutoID, ddlStatus.SelectedItem.Value, txtTicketNo.Text.Trim(), txtUserId.Text.Trim(), txtDate.Text, txtToDate.Text);
    //        dtTicketMaster = dsTicketMaster.Tables[0];
    //        if (dtTicketMaster.Rows.Count == 0)
    //        {
    //            dtflag = 0;
    //            dtTicketMaster.Rows.Add(dtTicketMaster.NewRow());
    //        }
    //        gvTicketMaster.DataSource = dtTicketMaster;
    //        gvTicketMaster.DataBind();

    //        if (dtflag == 0)
    //        {
    //            gvTicketMaster.Rows[0].Visible = false;
    //            dtflag = 0;
    //            btnExport.Visible = false;
    //            lblmsg.Visible = true;
    //        }
    //        else
    //        {
    //            dtflag = 1;
    //            btnExport.Visible = true;
    //            lblmsg.Visible = false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    private void FillTicketDetail(string TicketNo)
    {
        var objAssetMgmt = new BL.AssetManagement();
        var ds = objAssetMgmt.TicketDetail(TicketNo, BaseLocationAutoID);
        try
        {
            lblTicketNo.Text = TicketNo;
            if (ds.Tables.Count > 0)
            {
                txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtSiteName.Text = ds.Tables[0].Rows[0]["AsmtName"].ToString();
                txtDOC.Text = DateFormat(ds.Tables[0].Rows[0]["DateOfCreation"].ToString());
                txtSummary.Text = ds.Tables[0].Rows[0]["SummaryOfIssues"].ToString();
                txtDesc.Text = ds.Tables[0].Rows[0]["DescOfIssues"].ToString();
                txtSeverity.Text = ds.Tables[0].Rows[0]["Severity"].ToString();
                txtCommercialValue.Text = ds.Tables[0].Rows[0]["CommercialValue"].ToString();
                var dt = new DataTable();
                dt = ds.Tables[0];

                DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
                ds.Tables[0].Columns.Add(dc);

                if (ds.Tables[0].Rows[0]["WOImage"].ToString() != "")
                {
                    ds.Tables[0].Rows[0]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])).Length);
                }
                else
                {
                    ds.Tables[0].Rows[0]["ImageBase64String"] = "~/Images/EmployeeImages/NoImageAvailable.jpg";

                }
                ImageBox.ImageUrl = ds.Tables[0].Rows[0]["ImageBase64String"].ToString();

            }
        }
        catch (Exception ex)
        { }
    }
    public void ReadOnly()
    {
        txtClientName.Attributes.Add("readonly", "readonly");
        txtSiteName.Attributes.Add("readonly", "readonly");
        txtDOC.Attributes.Add("readonly", "readonly");
        txtSummary.Attributes.Add("readonly", "readonly");
        txtDesc.Attributes.Add("readonly", "readonly");
        txtSeverity.Attributes.Add("readonly", "readonly");
        txtCommercialValue.Attributes.Add("readonly", "readonly");
    }
    protected string DateFormat(string strdate)
    {
        var dt = new DateTime();
        string formatedDate;
        if (strdate != string.Empty)
        {
            dt = DateTime.Parse(strdate);
            formatedDate = dt.ToString("dd-MMM-yyyy");
        }
        else
        {
            formatedDate = string.Empty;
        }
        return formatedDate;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlTicetMaster.Visible = true;
        pnlTicketDetail.Visible = false;
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            ds = objAssetMgmt.UpdateTicketStatus(lblTicketNo.Text, ddlStatus.SelectedItem.Value, BaseLocationAutoID, BaseUserID);
            lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
            FillTicketDetail(lblTicketNo.Text);
            btnUpdate.Visible = false;
            ddlStatus.Enabled = false;
            FillgvTicketMaster();
            FillTicketDetails();
        }
        catch (Exception ex)
        { }
    }
    protected void txtUserId_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
        FillTicketDetails();
    }
    protected void txtTicketNo_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
        FillTicketDetails();
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        //  txtStatusMain.Text = "ALL";
        FillgvTicketMaster();
        FillTicketDetails();
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        // txtStatusMain.Text = "ALL";
        FillgvTicketMaster();
        FillTicketDetails();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        //var objAssetMgmt = new BL.AssetManagement();
        //var dsTaskMaster = new DataSet();
        //var dtTaskMaster = new DataTable();        
        //labelclick = txtStatusMain.Text;
        //dsTaskMaster = objAssetMgmt.GetAllTickets(BaseLocationAutoID, labelclick, txtTicketNo.Text.Trim(), txtUserId.Text.Trim(), txtDate.Text, txtToDate.Text);
        //dtTaskMaster = dsTaskMaster.Tables[0];
        //WriteExcelWithNPOI("xls", dtTaskMaster);   

        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=TicketReport-" + txtDate.Text + " to " + txtToDate.Text + ".xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //using (StringWriter sw = new StringWriter())
        //{
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    //To Export all pages
        //    gvTicketMaster.AllowPaging = false;
        //    labelclick = txtStatusMain.Text;
        //    FillgvTicketMaster();

        //    gvTicketMaster.HeaderRow.BackColor = Color.White;
        //    foreach (TableCell cell in gvTicketMaster.HeaderRow.Cells)
        //    {
        //        cell.BackColor = gvTicketMaster.HeaderStyle.BackColor;
        //    }
        //    foreach (GridViewRow row in gvTicketMaster.Rows)
        //    {
        //        row.BackColor = Color.White;
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            if (row.RowIndex % 2 == 0)
        //            {
        //                cell.BackColor = gvTicketMaster.AlternatingRowStyle.BackColor;
        //            }
        //            else
        //            {
        //                cell.BackColor = gvTicketMaster.RowStyle.BackColor;
        //            }
        //            cell.CssClass = "textmode";
        //        }
        //    }
        //    gvTicketMaster.RenderControl(hw);
        //    //style to format numbers to string
        //    string style = @"<style> .textmode { } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //}

        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gvTicketMaster.AllowPaging = false;
        // labelclick = txtStatusMain.Text;
        FillgvTicketMaster();
        //Change the Header Row back to white color
        gvTicketMaster.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < gvTicketMaster.HeaderRow.Cells.Count; i++)
        {
            gvTicketMaster.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
        }
        gvTicketMaster.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public void WriteExcelWithNPOI(String extension, DataTable dt)
    {
        // dll refered NPOI.dll and NPOI.OOXML
        IWorkbook workbook;
        if (extension == "xlsx")
        {
            workbook = new XSSFWorkbook();
        }
        else if (extension == "xls")
        {
            workbook = new HSSFWorkbook();
        }
        else
        {
            throw new Exception("This format is not supported");
        }
        ISheet sheet1 = workbook.CreateSheet("Sheet 1");
        //make a header row
        IRow row1 = sheet1.CreateRow(0);
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            ICell cell = row1.CreateCell(j);
            String columnName = dt.Columns[j].ToString();
            cell.SetCellValue(columnName);
        }
        //loops through data
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            IRow row = sheet1.CreateRow(i + 1);
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                ICell cell = row.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(dt.Rows[i][columnName].ToString());
            }
        }
        using (var exportData = new MemoryStream())
        {
            Response.Clear();
            workbook.Write(exportData);
            if (extension == "xlsx") //xlsx file format
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "tpms_Dict.xlsx"));
                Response.BinaryWrite(exportData.ToArray());
            }
            else if (extension == "xls")  //xls file format
            {
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "TaskListReport-" + txtDate.Text + " to " + txtToDate.Text + ".xls"));
                Response.BinaryWrite(exportData.ToArray());
            }
            Response.End();
        }
    }
    protected void lblTicketNo_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblTicketNo = (LinkButton)gvTicketMaster.Rows[row.RowIndex].FindControl("lblTicketNo");
        Label lblTicketStatus = (Label)gvTicketMaster.Rows[row.RowIndex].FindControl("lblTicketStatus");
        FillTicketDetail(lblTicketNo.Text);
        pnlTicetMaster.Visible = false;
        pnlTicketDetail.Visible = true;
        if ((lblTicketStatus.Text == "Approved") || (lblTicketStatus.Text == "Reject"))
        {
            btnUpdate.Visible = false;
            //ddlStatus.Enabled = false;
            ddlStatus.Visible = false;
            hfstatus.Value = lblTicketStatus.Text;
            //    ddlStatus.SelectedValue = lblTicketStatus.Text;
            lblStatus1.Text = lblTicketStatus.Text;
            lblStatus1.Visible = true;
        }
        else if (lblTicketStatus.Text == "Closed")
        {
            btnUpdate.Visible = false;
            //  ddlStatus.Enabled = false;
            ddlStatus.Visible = false;
            lblStatus1.Visible = true;
            lblStatus1.Text = lblTicketStatus.Text;
            hfstatus.Value = lblTicketStatus.Text;
        }
        else
        {
            btnUpdate.Visible = true;
            //  ddlStatus.Enabled = true;
            ddlStatus.Visible = true;
            lblStatus1.Visible = false;
        }
    }
    protected void imgbtnNewticket_Click(object sender, ImageClickEventArgs e)
    {
        labelclick = "NEW";
        txtTicketNo.Text = "";
        txtUserId.Text = "";
        ddlStatusMain.SelectedValue = "NEW";
        //  txtStatusMain.Text = labelclick;
        FillgvTicketMaster();
    }
    protected void imgbtnTotalticket_Click(object sender, ImageClickEventArgs e)
    {
        labelclick = "ALL";
        txtTicketNo.Text = "";
        txtUserId.Text = "";
        ddlStatusMain.SelectedValue = "ALL";
        //  txtStatusMain.Text = labelclick;
        FillgvTicketMaster();
    }
    protected void imgbtnApprovedticket_Click(object sender, ImageClickEventArgs e)
    {
        labelclick = "Approved";
        txtTicketNo.Text = "";
        txtUserId.Text = "";
        ddlStatusMain.SelectedValue = "Approved";
        //   txtStatusMain.Text = labelclick;
        FillgvTicketMaster();
    }
    protected void imgbtnRejectticket_Click(object sender, ImageClickEventArgs e)
    {
        labelclick = "Reject";
        txtTicketNo.Text = "";
        txtUserId.Text = "";
        ddlStatusMain.SelectedValue = "Reject";        
        FillgvTicketMaster();
    }

    protected void ddlStatusMain_SelectedIndexChanged1(object sender, EventArgs e)
    {        
        FillgvTicketMaster();
    }
    protected void imgbtnCloseticket_Click1(object sender, ImageClickEventArgs e)
    {
        try
        {            
            labelclick = "Closed";
            txtTicketNo.Text = "";
            txtUserId.Text = "";                     
            FillgvTicketMaster();
            ddlStatusMain.SelectedValue = "Closed";
        }
        catch (Exception ex) { }
    }
    protected void btnGenerateTicket_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AssetManagement/TicketGeneration.aspx");

    }
    protected void btnSchedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AssetManagement/TicketScheduling.aspx");
    }
}
