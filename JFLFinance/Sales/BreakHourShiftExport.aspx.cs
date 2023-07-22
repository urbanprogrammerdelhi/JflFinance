// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 22-04-2014

// ***********************************************************************
// <copyright file="BreakHourShiftExport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


/// <summary>
/// Class BreakHour_Export
/// </summary>
public partial class BreakHour_Export : BasePage //System.Web.UI.Page
{
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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return
                    IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception("Have not Rights", ex);
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
                RadGrid1.DataSource = null;
                RadGrid1.DataBind();
                FillRadGrid1();
            }
        }

    }



    /// <summary>
    /// Fills the RAD grid1.
    /// </summary>
    protected void FillRadGrid1()
    {

        var objSales = new BL.Sales();
        var ds = objSales.BreakShiftExport(Request.QueryString["Location"], Request.QueryString["Client"],
                                           Request.QueryString["Asmt"],
                                           Request.QueryString["Post"],
                                           double.Parse(Request.QueryString["BreakShift"]),
                                           double.Parse(Request.QueryString["BreakHours"]), Request.QueryString["Status"]);



        if (ds != null && ds.Tables.Count > 0)

            for (var i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                ds.Tables[0].Columns[i].ColumnName =
                    ResourceValueOfKey_Get(ds.Tables[0].Columns[i].ColumnName);
            }

        if (ds != null) RadGrid1.DataSource = ds.Tables[0];
    }


    /// <summary>
    /// Handles the NeedDataSource event of the RadGrid1 control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="gridNeedDataSourceEventArgs">instance containing the event data.</param>
    protected void RadGrid1NeedDataSource(object source, GridNeedDataSourceEventArgs gridNeedDataSourceEventArgs)
    {
        FillRadGrid1();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the RadGrid1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridItemEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            e.Item.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Item.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";


            var lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                var serialNo = RadGrid1.CurrentPageIndex * RadGrid1.PageSize + int.Parse(e.Item.ItemIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
        }
    }

    /// <summary>
    /// Handles the ItemCommand event of the RadGrid1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case RadGrid.ExportToExcelCommandName:
                ConfigureExport();
                RadGrid1.MasterTableView.ExportToExcel();
                break;
            case RadGrid.ExportToPdfCommandName:
                ConfigureExport();
                RadGrid1.MasterTableView.ExportToPdf();
                break;
            case RadGrid.ExportToCsvCommandName:
                ConfigureExport();
                RadGrid1.MasterTableView.ExportToCSV();
                break;
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


