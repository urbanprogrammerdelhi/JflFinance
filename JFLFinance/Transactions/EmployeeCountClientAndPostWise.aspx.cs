// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="EmployeeCountClientAndPostWise.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// Class Transactions_EmployeeCountClientAndPostWise.
/// </summary>
public partial class Transactions_EmployeeCountClientAndPostWise : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        HFAsmtCode.Value = Request.QueryString["AsmtCode"];
        HFPost.Value = Request.QueryString["Post"];
        HFClientCode.Value = Request.QueryString["ClientCode"];
        HFAttendanceType.Value = Request.QueryString["AttendanceType"];
        HFFromDate.Value = Request.QueryString["FromDate"];
        HFToDate.Value = Request.QueryString["ToDate"];
        HFConnectionString.Value = Request.QueryString["ConnectionString"];
        HFCompanyCode.Value = Request.QueryString["CompanyCode"];
        HFHrLocationCode.Value = Request.QueryString["HrLocationCode"];
        HFLocationCode.Value = Request.QueryString["LocationCode"];
    }
}