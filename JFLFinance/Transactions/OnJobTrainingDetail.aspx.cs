// ***********************************************************************
// Assembly         : 
// Author           :  Parashar
// Created          : 05-26-2014
//
// ***********************************************************************
// <copyright file="Transactions_OnJobTrainingDetail.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_OnJobTrainingDetail.
/// </summary>
public partial class Transactions_OnJobTrainingDetail : BasePage
  
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var bp = new BasePage();
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }
    #endregion

    readonly BL.ReportGeneratorComponent _objRgc=null;

    /// <summary>
    /// Constractor
    /// </summary>
    public Transactions_OnJobTrainingDetail()
    {
         _objRgc = new BL.ReportGeneratorComponent();
    }
    /// <summary>
    /// Gets the report parameters.
    /// </summary>
    /// <value>The report parameters.</value>
    public Hashtable ReportParameters
    {
        get { return Session["cxtHashParameters"] != null ? (Hashtable) Session["cxtHashParameters"] : null; }
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && IsReadAccess && !string.IsNullOrEmpty(Request["ReportName"]))
        {
             lblReportHeader.Text = Request["ReportName"];
             FillOjtDetail();
        }
    }

    /// <summary>
    /// Fills the RAD grid1.
    /// </summary>
    protected void FillOjtDetail()
    {
        if (ReportParameters != null)
        {
            using (var ds = _objRgc.GetOJTDetails(Convert.ToInt32(ReportParameters[DL.Properties.Resources.LocationAutoId]), Convert.ToString(ReportParameters[DL.Properties.Resources.AreaIncharge]), Convert.ToString(ReportParameters[DL.Properties.Resources.AreaId]), Convert.ToString(ReportParameters[DL.Properties.Resources.EmployeeNumber]), Convert.ToString(ReportParameters[DL.Properties.Resources.ScheduleType]), Convert.ToString(ReportParameters[DL.Properties.Resources.Billable]), Convert.ToDateTime(ReportParameters[DL.Properties.Resources.FromDate]), Convert.ToDateTime(ReportParameters[DL.Properties.Resources.ToDate])))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    rgOJTDetail.DataSource = ds.Tables[0];
                }
            }
        }
    }

    /// <summary>
    /// Handles the NeedDataSource event of the rgOJTDetail control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void rgOJTDetail_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        FillOjtDetail();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the rgOJTDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridItemEventArgs"/> instance containing the event data.</param>
    protected void rgOJTDetail_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (!(e.Item is GridDataItem)) return;
        e.Item.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Item.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
       
    }

    /// <summary>
    /// Handles the ItemCommand event of the rgOJTDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs"/> instance containing the event data.</param>
    protected void rgOJTDetail_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case RadGrid.ExportToExcelCommandName:
                ConfigureExport();
                rgOJTDetail.MasterTableView.ExportToExcel();
                break;
            case RadGrid.ExportToPdfCommandName:
                ConfigureExport();
                rgOJTDetail.MasterTableView.ExportToPdf();
                break;
            case RadGrid.ExportToCsvCommandName:
                ConfigureExport();
                rgOJTDetail.MasterTableView.ExportToCSV();
                break;
        }
    }

    /// <summary>
    /// Configures the export.
    /// </summary>
    public void ConfigureExport()
    {
        rgOJTDetail.ExportSettings.ExportOnlyData = true;
        rgOJTDetail.ExportSettings.IgnorePaging = true;
        rgOJTDetail.ExportSettings.OpenInNewWindow = true;
    }
    /// <summary>
    /// Back button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {

        Response.Redirect("../Transactions/RptGroup_OJTEmployeeDetail.aspx");
    }
}