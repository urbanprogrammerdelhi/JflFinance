// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 02-06-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SaudiPaySum.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_SaudiPaySum.
/// </summary>
public partial class Transactions_SaudiPaySum : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
            FillPayPeriodCollection();
                RadGridSaudiPaysum.Visible = false;
            
        }
    }
    /// <summary>
    /// Prefills the drop downs on page load event
    /// </summary>
    protected void FillData()
    {
        var objR = new BL.BusinessRule();
        using (var ds = objR.BusinessRuleGet("", int.Parse(BaseLocationAutoID)))
        {
            ddlBusinessRuleCode.DataSource = ds.Tables[1];
        }
        ddlBusinessRuleCode.DataValueField = "PaysumCode";
        ddlBusinessRuleCode.DataTextField = "PaysumCodeDesc";
        ddlBusinessRuleCode.DataBind();

    }
    /// <summary>
    /// For filling the Pay Period Dropdown
    /// </summary>
    protected void FillPayPeriodCollection()
    {

        var objBr = new BL.BusinessRule();
        using (var ds = objBr.PayPeriodCollectionGet(ddlBusinessRuleCode.SelectedValue.ToString()))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var periodCollection = new DataTable();
                periodCollection = ds.Tables[0];
                ViewState.Add("MyPeriodCollection", periodCollection);

                ddlPeriodCollection.DataSource = ds.Tables[0];
                ddlPeriodCollection.DataValueField = "PeriodNumber";
                ddlPeriodCollection.DataTextField = "PeriodDesc";
                ddlPeriodCollection.DataBind();

                DataRow[] result = periodCollection.Select("ToDate >= '" + DateTime.Now + "'");
                ddlPeriodCollection.SelectedValue = result[0]["PeriodNumber"].ToString();

            }
            else
            {
                ddlPeriodCollection.Items.Clear();
            }
        }
    }
    /// <summary>
    /// Handles the event when click button on this page is clicked
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGeneratePaysum_Click(object sender, EventArgs e)
    {
        RadGridSaudiPaysum.Visible = true;
        RadGridSaudiPaysum.DataSource = null;
        FillRadGridSaudiPaysum();
        RadGridSaudiPaysum.DataBind();
    }
    /// <summary>
    /// handles the event when grid needs a datasource while it refreshes on different events
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void RadGridSaudiPaysum_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        FillRadGridSaudiPaysum();
    }
    /// <summary>
    /// Fill the grid and bind it to datasource
    /// </summary>
    protected void FillRadGridSaudiPaysum()
    {
        lblErrorMsg.Text = string.Empty; 
        var dt = new DataTable();
        dt = (DataTable)ViewState["MyPeriodCollection"];
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow[] result = dt.Select("PeriodNumber >= " + ddlPeriodCollection.SelectedValue);
            var objRoster = new BL.Roster();
            try
            {
                using (var ds = objRoster.GeneratePaysumSaudi(ddlBusinessRuleCode.SelectedValue, DateTime.Parse(result[0]["FromDate"].ToString()).ToString("dd-MMM-yyyy"), DateTime.Parse(result[0]["ToDate"].ToString()).ToString("dd-MMM-yyyy"), "1"))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        RadGridSaudiPaysum.DataSource = ds.Tables[0];
                        RadGridSaudiPaysum.DataBind();

                    }
                    else
                        lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                }
            }
            catch(Exception ex)
            {
                lblErrorMsg.Text = Resources.Resource.MsgUnknownError;
                
            }
        }

    }

    /// <summary>
    /// Handles the OnColumnCreated event of the RadGridSaudiPaysum control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridColumnCreatedEventArgs"/> instance containing the event data.</param>
    protected void RadGridSaudiPaysum_OnColumnCreated(object sender, GridColumnCreatedEventArgs e)
    {
        try
        {
            if (e.Column.UniqueName.Equals("EmployeeNumber") || e.Column.UniqueName.Equals("RosterAutoID") || e.Column.UniqueName.Equals("ClientName") || e.Column.UniqueName.Equals("EmployeeName") || e.Column.UniqueName.Equals("AsmtAddress") || e.Column.UniqueName.Equals("AsmtID"))
            {
                Telerik.Web.UI.GridBoundColumn gcol = (Telerik.Web.UI.GridBoundColumn)e.Column;
                gcol.AllowFiltering = true; 
            }
            else
            {   Telerik.Web.UI.GridBoundColumn gcol = (Telerik.Web.UI.GridBoundColumn)e.Column;
                gcol.AllowFiltering = false ;    
            }
        }
        catch (Exception)
        {
            lblErrorMsg.Text = string.Empty;
        }
    }
    
    /// <summary>
    /// handles event of index change of business rule code dropdown
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBusinessRuleCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPayPeriodCollection();
        btnGeneratePaysum.Visible = ddlPeriodCollection.Items.Count > 0;
        RadGridSaudiPaysum.Visible = false;
    }
    /// <summary>
    /// Handles the Itembound event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridItemEventArgs"/> instance containing the event data.</param>
    protected void RadGridSaudiPaysum_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridDataItem)
        //{
        //    var lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");
        //    if (lblSerialNo != null)
        //    {
        //        int serialNo = RadGridSaudiPaysum.CurrentPageIndex * RadGridSaudiPaysum.PageSize + int.Parse(e.Item.ItemIndex.ToString());
        //        lblSerialNo.Text = Convert.ToString((serialNo + 1));
        //    }
        //}
    }
    /// <summary>
    /// Handles the export functionality of telerik radgrid when exported to Excel is used.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs"/> instance containing the event data.</param>
    protected void RadGridSaudiPaysum_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.ExportToExcelCommandName)
        {
            ConfigureExport();
            RadGridSaudiPaysum.MasterTableView.ExportToExcel();
        }

    }
    /// <summary>
    /// Handles the export functionality of telerik radgrid
    /// </summary>
    public void ConfigureExport()
    {
        RadGridSaudiPaysum.ExportSettings.ExportOnlyData = true;
        RadGridSaudiPaysum.ExportSettings.IgnorePaging = true;
        RadGridSaudiPaysum.ExportSettings.OpenInNewWindow = true;
    }
}