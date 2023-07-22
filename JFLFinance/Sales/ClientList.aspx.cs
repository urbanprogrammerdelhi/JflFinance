// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ClientList.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Sales_ClientList.
/// </summary>
public partial class Sales_ClientList : BasePage//System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        FillGrid();
    }

    /// <summary>
    /// Fills the grid.
    /// </summary>
    private void FillGrid()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.ClientListGet(BaseCompanyCode);
        ASPxGridView1.DataSource = ds;//dt1.DefaultView;
        ASPxGridView1.DataBind();
    }
    /// <summary>
    /// Handles the Click event of the ExportToExcel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ExportToExcel_Click(object sender, EventArgs e)
    {

        ASPxGridViewExporter1.GridViewID = "ASPxGridView1";
        ASPxGridViewExporter1.WriteCsvToResponse();

    }
}
