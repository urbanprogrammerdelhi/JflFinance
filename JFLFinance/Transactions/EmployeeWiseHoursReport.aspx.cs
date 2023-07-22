// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 03-21-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="EmployeeWiseHoursReport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Collections;
/// <summary>
/// Class Transactions_EmployeeWiseHoursReport.
/// </summary>
public partial class Transactions_EmployeeWiseHoursReport : BasePage
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
                int VirtualDirNameLenght = 0;
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
                int VirtualDirNameLenght = 0;
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
                int VirtualDirNameLenght = 0;
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
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                BasePage bp = new BasePage();
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }
    #endregion

    /// <summary>
    /// Gets the report parameters.
    /// </summary>
    /// <value>The report parameters.</value>
    public Hashtable ReportParameters
    {
        get
        {
            if (Session["cxtHashParameters"] != null)
            {
                return (Hashtable)Session["cxtHashParameters"];
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                if (Request.QueryString["ReportName"] != null)
                {
                    //lblReportHeader.Text = Request.QueryString["ReportName"].ToString();
                }
                RadGrid1.DataSource = null;
                RadGrid1.DataBind();
                FillRadGrid1();
            }
        }
    }


    /// <summary>
    /// Back button implemented
    /// </summary>
    protected void btnBack_Click(object sender, EventArgs eventArgs)
    {
        Response.Redirect("../Transactions/RptGroup_Israel.aspx?ReportName=" + "EmployeeWiseHoursReport");
    }

    /// <summary>
    /// Fills the RAD grid1.
    /// </summary>
    protected void FillRadGrid1()
    {
        var objR = new BL.Roster();
        if (ReportParameters != null)
        {
            

            DataSet ds = objR.EmployeeWiseHours(
                this.ReportParameters[DL.Properties.Resources.CompanyCode].ToString(),
                this.ReportParameters[DL.Properties.Resources.LocationAutoId].ToString(),
                this.ReportParameters[DL.Properties.Resources.AreaIncharge].ToString(),
                this.ReportParameters[DL.Properties.Resources.AreaId].ToString(),
                this.ReportParameters[DL.Properties.Resources.FromDate].ToString(),
                this.ReportParameters[DL.Properties.Resources.ToDate].ToString(),
                this.ReportParameters[DL.Properties.Resources.EmployeeNumber].ToString(),
                this.ReportParameters[DL.Properties.Resources.IsAreaIncharge].ToString());


            if (ds != null && ds.Tables.Count > 0)
            {

                ds.Tables[0].Columns["DivisionID"].ColumnName = Resources.Resource.Division;
                ds.Tables[0].Columns["DivisionName"].ColumnName = Resources.Resource.DivisionName;
                ds.Tables[0].Columns["BranchID"].ColumnName = Resources.Resource.BranchID;
                ds.Tables[0].Columns["BranchName"].ColumnName = Resources.Resource.Branch;
                ds.Tables[0].Columns["EmployeeNumber"].ColumnName = Resources.Resource.EmployeeNumber;
                ds.Tables[0].Columns["EmployeeName"].ColumnName = Resources.Resource.EmployeeName;
                ds.Tables[0].Columns["AreaID"].ColumnName = Resources.Resource.AreaID;
                ds.Tables[0].Columns["AreaDesc"].ColumnName = Resources.Resource.AreaDesc;
                ds.Tables[0].Columns["AreaIncharge"].ColumnName = Resources.Resource.AreaIncharge;
                ds.Tables[0].Columns["AreaInchargeName"].ColumnName = Resources.Resource.AreaInchargeName;
                ds.Tables[0].Columns["ActualHour"].ColumnName = Resources.Resource.ActualHours;
                ds.Tables[0].Columns["PlannedHour"].ColumnName = Resources.Resource.PlannedScheduleHours;
                ds.Tables[0].Columns["WeeklyHours"].ColumnName = Resources.Resource.WeeklyNormalHours;
                ds.Tables[0].Columns["DiffSchNormal"].ColumnName = Resources.Resource.DifferenceScheduleNormal;
                ds.Tables[0].Columns["DiffActualNormal"].ColumnName = Resources.Resource.DifferenceActualNormal;
                ds.Tables[0].Columns["Percentage_DiffSchNormal"].ColumnName = Resources.Resource.Percentage_DifferenceScheduleNormal;
                ds.Tables[0].Columns["Percentage_DiffActualNormal"].ColumnName = Resources.Resource.Percentage_DifferenceActualNormal;
                RadGrid1.DataSource = ds.Tables[0];
                //RadGrid1.DataBind();
            }
        }
    }

    /// <summary>
    /// Handles the NeedDataSource event of the RadGrid1 control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {   
        FillRadGrid1();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the RadGrid1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridItemEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            e.Item.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Item.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";


            Label lblSerialNo = (Label) e.Item.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = RadGrid1.CurrentPageIndex * RadGrid1.PageSize + int.Parse(e.Item.ItemIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
        }
    }

    /// <summary>
    /// Handles the ItemCommand event of the RadGrid1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
        {
            ConfigureExport();
            RadGrid1.MasterTableView.ExportToExcel();
        }
        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName)
        {
            ConfigureExport();
            RadGrid1.MasterTableView.ExportToPdf();
        }
        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
        {
            ConfigureExport();
            RadGrid1.MasterTableView.ExportToCSV();
        }
    }
    /// <summary>
    /// Configures the export.
    /// </summary>
    public void ConfigureExport()
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;
    }
}