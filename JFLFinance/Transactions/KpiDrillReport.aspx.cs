// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 01-03-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// Description      : Page Calls the KpiDrillReport to Show Drilldowns
// ***********************************************************************
// <copyright file="KpiDrillReport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using Telerik.Web.UI;

/// <summary>
/// Class KPIAdmin_KpiDrillReport.
/// </summary>
public partial class KPIAdmin_KpiDrillReport : BasePage//System.Web.UI.Page
{

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Form.Style.Add("Height", "760px");
            ViewState["GridData"] = null;
            BaseUserInformation.CountryCode = Request.QueryString["SessionValue"];
            FillgvKPIDetails(string.Empty);
        }
        //else
        //{
        //    if (Request.QueryString["ReportType"].ToString() == "TotalHoursPaidInMonth")
        //    {
        //        FillgvKPIDetails(string.Empty);
        //    }
        //}
    }

    /// <summary>
    /// Handles the NeedDataSource event of the gvKPI control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridNeedDataSourceEventArgs" /> instance containing the event data.</param>
    protected void gvKPI_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        FillgvKPIDetails("NeedDataSource");
    }
    /// <summary>
    /// Fillgvs the kpi details.
    /// </summary>
    /// <param name="statusNeedDataSource">The status need data source.</param>
    /// <exception cref="System.Exception">Some Problem In KPI Parameter</exception>
    private void FillgvKPIDetails(string statusNeedDataSource)
    {
        pnlGrid.GroupingText = ResourceValueOfKey_Get(Request.QueryString["ReportType"].ToString());
        BL.KPI objKpi = new BL.KPI();
        DataSet ds = new DataSet();
        var AsmtID = string.Empty;
        var HrLocationCode = string.Empty;
        var LocationCode = string.Empty;
        var ClientCode = string.Empty;
        var PostAutoID = string.Empty;
        var CompanyCode = string.Empty;
        var year = string.Empty;
        var month = string.Empty;

        try
        {
            if (Request.QueryString["HrLocationCode"] == null)
            {
                HrLocationCode = "";
            }
            else
            {
                HrLocationCode = Request.QueryString["HrLocationCode"].ToString();

            }
            if (Request.QueryString["LocationCode"] == null)
            {
                LocationCode = "";
            }
            else
            {
                LocationCode = Request.QueryString["LocationCode"].ToString();

            }

            if (Request.QueryString["CompanyCode"] == null)
            {
                CompanyCode = "";
            }
            else
            {
                CompanyCode = Request.QueryString["CompanyCode"].ToString();

            }
            if (Request.QueryString["ClientCode"] == null)
            {
                ClientCode = "";
            }
            else
            {
                ClientCode = Request.QueryString["ClientCode"].ToString();

            }
            if (Request.QueryString["AsmtID"] == null)
            {
                AsmtID = "";
            }
            else
            {
                AsmtID = Request.QueryString["AsmtID"].ToString();

            }

            if (Request.QueryString["PostAutoID"] == null)
            {
                PostAutoID = "0";

            }
            else
            {
                PostAutoID = Request.QueryString["PostAutoID"].ToString();

            }

            if (ViewState["GridData"] == null)
            {
                ds = objKpi.GetKPIDrillDetail(CompanyCode, HrLocationCode, LocationCode, ClientCode, AsmtID, PostAutoID, Request.QueryString["Month"].ToString(), Request.QueryString["Year"].ToString(), Request.QueryString["ReportType"].ToString());
                // ds = objKpi.GetKPISubDetail("PNGMSS", HrLocationCode, LocationCode, ClientCode, AsmtID, PostAutoID, "January", "2012", "TotalHoursBilledInMonth", "DirectLabour");
                ViewState["GridData"] = ds;
            }
            else
            {
                ds = (DataSet)ViewState["GridData"];
            }
            gvKPI.DataSource = ds;
            gvKPI.ExportSettings.ExportOnlyData = true;
            //gvKPI.MasterTableView.ExportToExcel();
            if (statusNeedDataSource == "")
            {
                gvKPI.DataBind();
            }

            //gvKPI.Columns.FindByUniqueNameSafe("EmployeeOpunit").Display = false;
            if (radGridColumn.Items.Count <= 0)
            {
                radGridColumn.DataSource = ds.Tables[0].Columns;
                radGridColumn.DataValueField = "ColumnName";
                radGridColumn.DataTextField = "ColumnName";
                radGridColumn.DataBind();

               
            }
            //if (Request.QueryString["ReportType"].ToString() == "TotalHoursPaidInMonth")
            //{
            //    //Set options to enable Group-by
            //    gvKPI.GroupingEnabled = true;
            //    gvKPI.ShowGroupPanel = true;
            //    gvKPI.ClientSettings.AllowDragToGroup = true;
            //    gvKPI.ClientSettings.AllowColumnsReorder = true;
                
            //    //gvKPI.MasterTableView.GroupByExpressions.Add(new GridGroupByExpression("LocationDesc Group By LocationDesc"));
            //    ////Add a group-by expression by defining fields 
            //    GridGroupByExpression expression = new GridGroupByExpression();

            //    GridGroupByField gridGroupByField = new GridGroupByField();
            //    //Add select fileds (before the "Group By" clause)
            //    gvKPI.MasterTableView.GroupByExpressions.Add(new GridGroupByExpression("EmployeeNumber Group By EmployeeNumber"));
            //    gridGroupByField = new GridGroupByField();
            //    gridGroupByField.FieldName = "EmployeeNumber";
            //    gridGroupByField.FormatString = "Employee: {0}";
            //    expression.SelectFields.Add(gridGroupByField);

            //    //Add a filed for group-by (after the "Group By" clause)
            //    gridGroupByField = new GridGroupByField();
            //    gridGroupByField.FieldName = "EmployeeNumber";
            //    expression.GroupByFields.Add(gridGroupByField);
                
            //    gvKPI.MasterTableView.GroupByExpressions.Add(expression);
            //    gvKPI.MasterTableView.GroupLoadMode = GridGroupLoadMode.Client;
            //    gvKPI.ClientSettings.AllowGroupExpandCollapse = true;
            //    gvKPI.MasterTableView.GroupsDefaultExpanded = false;
            //}

        }
        catch (Exception ex)
        {
            throw new Exception("Some Problem In KPI Parameter", ex);
        }
    }

    /// <summary>
    /// Handles the Click event of the Button1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        gvKPI.MasterTableView.ExportToExcel();
    }

    /// <summary>
    /// To print the Grid
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        gvKPI.AllowPaging = false;
        gvKPI.MasterTableView.AllowFilteringByColumn = false;
        gvKPI.GroupPanel.PanelStyle.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8);
        gvKPI.GroupPanel.PanelStyle.Font.Name = "Arial";
        gvKPI.GroupPanel.Text = ResourceValueOfKey_Get(Request.QueryString["ReportType"].ToString()); 
        
        gvKPI.Rebind();
        ajxPanelGrid.ResponseScripts.Add("PrintRadGrid('" + gvKPI.ClientID + "')");
    }
    //protected void gvKPI_OnItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    //{
    //    if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
    //    {
    //        gvKPI.MasterTableView.ExportToExcel();
    //    }
    //}
    //protected void gvKPI_OnGridExporting(object sender, Telerik.Web.UI.GridExportingArgs e)
    //{
    //    gvKPI.MasterTableView.ExportToExcel();
    //}
    /// <summary>
    /// Handles the OnColumnCreated event of the gvKPI control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridColumnCreatedEventArgs" /> instance containing the event data.</param>
    protected void gvKPI_OnColumnCreated(object sender, GridColumnCreatedEventArgs e)
    {
        try
        {

            gvKPI.ShowFooter = true;
            if (e.Column.UniqueName.Contains("Hours") || e.Column.UniqueName.Contains("Cost") || e.Column.UniqueName.Contains("Value"))
            {
                Telerik.Web.UI.GridBoundColumn gcol = (Telerik.Web.UI.GridBoundColumn)e.Column;
                gcol.FooterAggregateFormatString = "{0:F2}";
                gcol.Aggregate = GridAggregateFunction.Sum;
            }

            IList<RadListBoxItem> collection = radGridColumn.Items;

            if (e.Column.UniqueName != "ExpandColumn")
            {
                if (collection.Count > 0)
                {
                    foreach (RadListBoxItem item in collection)
                    {
                        if (item.Checked == true)
                        {
                            if (e.Column.UniqueName == item.Value)
                            {
                                if (e.Column.Display == true)
                                {
                                    e.Column.Display = false;
                                    // break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Column.UniqueName == item.Value)
                            {
                                if (e.Column.Display == false)
                                {
                                    e.Column.Display = true;
                                    //   break;
                                }
                            }
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            // FillgvKPIDetails(string.Empty);
        }
    }

    /// <summary>
    /// Handles the Click event of the btnHideShow control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnHideShow_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)ViewState["GridData"];
        gvKPI.GroupingEnabled = false;
        gvKPI.ShowGroupPanel = false;
        gvKPI.DataSource = ds;
        gvKPI.ExportSettings.ExportOnlyData = true;
        gvKPI.GroupingEnabled = true;
        gvKPI.ShowGroupPanel = true;
        gvKPI.Rebind();
        if (radGridColumn.Items.Count <= 0)
        {
            radGridColumn.DataSource = ds.Tables[0].Columns;
            radGridColumn.DataValueField = "ColumnName";
            radGridColumn.DataTextField = "ColumnName";
            radGridColumn.DataBind();
        }
    }
    /// <summary>
    /// Handles the PreRender event of the gvKPI control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvKPI_PreRender(object sender, EventArgs e)
    {
        //if (Request.QueryString["ReportType"].ToString() == "TotalHoursPaidInMonth")
        //{
        //    foreach (GridItem gi in (gvKPI as RadGrid).MasterTableView.GetItems(GridItemType.GroupHeader))
        //    {
        //        GridGroupHeaderItem ghi = gi as GridGroupHeaderItem;
        //         ghi.Expanded = false;
        //    }

        //}
    }
    /// <summary>
    /// Handles the Click event of the btnViewMore control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewMore_Click(object sender, EventArgs e)
    {

    }
}