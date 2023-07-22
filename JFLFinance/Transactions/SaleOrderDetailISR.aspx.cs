// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 03-13-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SaleOrderDetailISR.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Telerik.Web.UI;
using System.Data;
using System.Collections;
using DL;
/// <summary>
/// Class Transactions_SaleOrderDetailISR.
/// </summary>
public partial class Transactions_SaleOrderDetailISR : BasePage
  
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
                    lblReportHeader.Text = Request.QueryString["ReportName"].ToString();
                }
                FillRadGrid1();
            }
        }
    }

    /// <summary>
    /// Fills the RAD grid1.
    /// </summary>
    protected void FillRadGrid1()
    {
         var objR = new DL.Report();
        if (ReportParameters != null)
        {
            DataSet ds = objR.SaleOrderDetailsISR(
                this.ReportParameters[DL.Properties.Resources.CompanyCode].ToString(),
                this.ReportParameters[DL.Properties.Resources.LocationAutoId].ToString(),
                this.ReportParameters[DL.Properties.Resources.ClientCode].ToString(),
                this.ReportParameters[DL.Properties.Resources.AsmtCode].ToString(),
                this.ReportParameters[DL.Properties.Resources.AreaId].ToString(),
                this.ReportParameters[DL.Properties.Resources.AreaIncharge].ToString(),
                ReportParameters[DL.Properties.Resources.CenterlizeBilling].ToString());
       // DataSet ds = objR.SaleOrderDetailsISR("PNGMSS","2","ALL","ALL","ALL","ALL");

            if (ds != null && ds.Tables.Count > 0)
            {
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

            //Label lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");
            //if (lblSerialNo != null)
            //{
            //    int serialNo = RadGrid1.CurrentPageIndex * RadGrid1.PageSize + int.Parse(e.Item.ItemIndex.ToString());
            //    lblSerialNo.Text = Convert.ToString((serialNo + 1));
            //}
            //// IF there is no scan of employee then we are showing '-' instead of 00:00 Manish 07-08-2012
            //Label lblYLMRawTimeFrom = (Label)e.Item.FindControl("lblYLMRawTimeFrom");
            //Label lblYLMRawTimeTo = (Label)e.Item.FindControl("lblYLMRawTimeTo");
            //Label lblYLMProcessedTimeFrom = (Label)e.Item.FindControl("lblYLMProcessedTimeFrom");
            //Label lblYLMProcessedTimeTo = (Label)e.Item.FindControl("lblYLMProcessedTimeTo");


            //if (lblYLMRawTimeFrom != null)
            //{
            //    if (lblYLMRawTimeFrom.Text == "00:00" || lblYLMRawTimeFrom.Text == "0:00")
            //    {
            //        lblYLMRawTimeFrom.Text = "-";
            //        //cbYLMRawInTime.Visible = false;
            //    }
            //}

            //if (lblYLMRawTimeTo != null)
            //{
            //    if (lblYLMRawTimeTo.Text == "00:00" || lblYLMRawTimeTo.Text == "0:00")
            //    {
            //        lblYLMRawTimeTo.Text = "-";
            //        //cbYLMRawOutTime.Visible = false;
            //    }
            //}


            //if (lblYLMProcessedTimeFrom != null)
            //{
            //    if (lblYLMProcessedTimeFrom.Text == "00:00" || lblYLMProcessedTimeFrom.Text == "0:00")
            //    {
            //        lblYLMProcessedTimeFrom.Text = "-";

            //    }
            //}

            //if (lblYLMProcessedTimeTo != null)
            //{
            //    if (lblYLMProcessedTimeTo.Text == "00:00" || lblYLMProcessedTimeTo.Text == "0:00")
            //    {
            //        lblYLMProcessedTimeTo.Text = "-";


            //}
            //}//End Manish 
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