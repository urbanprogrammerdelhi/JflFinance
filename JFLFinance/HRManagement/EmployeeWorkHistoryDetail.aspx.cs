// ***********************************************************************
// Assembly         : 
// Author           :  Parashar
// Created          : 07-01-2014
//
// ***********************************************************************
// <copyright file="HRManagement_EmployeeWorkHistoryDetail.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_OnJobTrainingDetail.
/// </summary>
public partial class HRManagement_EmployeeWorkHistoryDetail : BasePage
  
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
    public HRManagement_EmployeeWorkHistoryDetail()
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
            lblErrorMsg.Text = string.Empty;
            lblReportHeader.Text = Request["ReportName"];
            FillEmployeeWorkHistoryDetail();
        }
    }

    /// <summary>
    /// Fills the RAD grid rgEmployeeWorkHistory.
    /// </summary>
    protected void FillEmployeeWorkHistoryDetail()
    {
        lblErrorMsg.Text = string.Empty;
        lblConfirmed.Text = string.Empty;
        lblNotConfirmed.Text = string.Empty;
        if (ReportParameters != null)
        {
            var dt = _objRgc.GetEmployeeWorkHistoryDetails(
                Convert.ToInt32(ReportParameters[DL.Properties.Resources.LocationAutoId]),
                Convert.ToString(ReportParameters[DL.Properties.Resources.AreaIncharge]),
                Convert.ToString(ReportParameters[DL.Properties.Resources.AreaId]),
                Convert.ToString(ReportParameters[DL.Properties.Resources.EmployeeNumber]),
                Convert.ToString(ReportParameters[DL.Properties.Resources.ClientCode]),
                Convert.ToString(ReportParameters[DL.Properties.Resources.AsmtId]),
                Convert.ToDateTime(ReportParameters[DL.Properties.Resources.FromDate]),
                Convert.ToDateTime(ReportParameters[DL.Properties.Resources.ToDate]),
                Convert.ToString(ReportParameters[DL.Properties.Resources.ConfirmDuty])
                );

            if (dt != null && dt.Rows.Count > 0)
            {
                rgEmployeeWorkHistory.DataSource = dt;
                lblErrorMsg.Text = Resources.Resource.TotalCount + ": " + dt.Rows.Count;
                var drConfirmed = dt.Select("ConfirmStatus = 'Confirmed'");
                lblConfirmed.Text = Resources.Resource.Confirmed + ": " + drConfirmed.Length;
                lblNotConfirmed.Text = Resources.Resource.NotConfirmed + ": " + (dt.Rows.Count - drConfirmed.Length);
            }
            else if(dt != null && dt.Rows.Count < 1)
            {
                rgEmployeeWorkHistory.DataSource = dt;
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
            }
       }
    }

    /// <summary>
    /// Handles the NeedDataSource event of the rgEmployeeWorkHistory control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void rgEmployeeWorkHistory_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        FillEmployeeWorkHistoryDetail();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the rgEmployeeWorkHistory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridItemEventArgs"/> instance containing the event data.</param>
    protected void rgEmployeeWorkHistory_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (!(e.Item is GridDataItem)) return;
        e.Item.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Item.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
    }

    /// <summary>
    /// Handles the ItemCommand event of the rgEmployeeWorkHistory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs"/> instance containing the event data.</param>
    protected void rgEmployeeWorkHistory_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case RadGrid.ExportToExcelCommandName:
                ConfigureExport();
                rgEmployeeWorkHistory.MasterTableView.ExportToExcel();
                break;
            case RadGrid.ExportToPdfCommandName:
                ConfigureExport();
                rgEmployeeWorkHistory.MasterTableView.ExportToPdf();
                break;
            case RadGrid.ExportToCsvCommandName:
                ConfigureExport();
                rgEmployeeWorkHistory.MasterTableView.ExportToCSV();
                break;
        }
    }

    /// <summary>
    /// Configures the export.
    /// </summary>
    public void ConfigureExport()
    {
        rgEmployeeWorkHistory.ExportSettings.ExportOnlyData = true;
        rgEmployeeWorkHistory.ExportSettings.IgnorePaging = true;
        rgEmployeeWorkHistory.ExportSettings.OpenInNewWindow = true;
    }

    /// <summary>
    /// Function called on Back Button Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../HRManagement/Rpt_EmployeeWorkHistoryDetail.aspx");
    }
}