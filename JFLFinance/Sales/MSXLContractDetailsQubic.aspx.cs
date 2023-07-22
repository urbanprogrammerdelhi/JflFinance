// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="MSXLContractDetailsQubic.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Sales_MSXLContractDetailsQubic.
/// </summary>
public partial class Sales_MSXLContractDetailsQubic : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.ContractDetailsGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=ContractDetails.xls");
            Response.ContentType = "application/octet-stream";
            Response.Write("<html>");
            Response.Write("<head>");
            Response.Write("<style type='text/css'>");
            Response.Write("</style>");
            Response.Write("</head>");
            Response.Write("<body>");
            Response.Write("<table width=200 border=1 cellspacing=0 cellpadding=2>");
            Response.Write("<tr>");
            Response.Write("<td><font style='font-weight:bold'>Customer</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CompanyID</font></td>");
            Response.Write("<td><font style='font-weight:bold'>LocalCID</font></td>");
            Response.Write("<td><font style='font-weight:bold'>LocalContractID</font></td>");
            Response.Write("<td><font style='font-weight:bold'>StartDate</font></td>");
            Response.Write("<td><font style='font-weight:bold'>EndDate</font></td>");
            Response.Write("<td><font style='font-weight:bold'>PriceReviewDate</font></td>");
            Response.Write("<td><font style='font-weight:bold'>TerminatedDate</font></td>");
            Response.Write("<td><font style='font-weight:bold'>Currency</font></td>");
            Response.Write("<td><font style='font-weight:bold'>MonthlyIncome</font></td>");
            Response.Write("<td><font style='font-weight:bold'>Margin</font></td>");
            Response.Write("<td><font style='font-weight:bold'>PaymentTerms</font></td>");
            Response.Write("<td><font style='font-weight:bold'>Premises</font></td>");
            Response.Write("<td><font style='font-weight:bold'>PerimeterIAControl</font></td>");
            Response.Write("<td><font style='font-weight:bold'>AccessExitControl</font></td>");
            Response.Write("<td><font style='font-weight:bold'>PassSystemAdmin</font></td>");
            Response.Write("<td><font style='font-weight:bold'>Screening</font></td>");
            Response.Write("<td><font style='font-weight:bold'>ResponseServices</font></td>");
            Response.Write("<td><font style='font-weight:bold'>OtherGuarding</font></td>");
            Response.Write("<td><font style='font-weight:bold'>IntegratedTechnical</font></td>");
            Response.Write("<td><font style='font-weight:bold'>IntegratedTechnicalIncome</font></td>");
            Response.Write("<td><font style='font-weight:bold'>IntegratedSafety</font></td>");
            Response.Write("<td><font style='font-weight:bold'>IntegratedSafetyIncome</font></td>");
            Response.Write("<td><font style='font-weight:bold'>IntegratedOther</font></td>");
            Response.Write("<td><font style='font-weight:bold'>IntegratedOtherIncome</font></td>");
            Response.Write("<td><font style='font-weight:bold'>NoGuards</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CLNuclearAny1</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CLNuclearTotal</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CLIndirectAny1</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CLIndirectTotal</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CLOtherAny1</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CLOtherTotal</font></td>");
            Response.Write("<td><font style='font-weight:bold'>TPLIndyFull</font></td>");
            Response.Write("<td><font style='font-weight:bold'>ForceMajCl</font></td>");
            Response.Write("<td><font style='font-weight:bold'>Law</font></td>");
            Response.Write("<td><font style='font-weight:bold'>Jurisdiction</font></td>");
            Response.Write("<td><font style='font-weight:bold'>HighRisk</font></td>");
            Response.Write("<td><font style='font-weight:bold'>5000People</font></td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
            // To Show Day Name**********************
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Response.Write("<tr width='100%'>");
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    Response.Write("<td>" + ds.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
                }
                Response.Write("</tr>");
            }
            //*******************************
            Response.Write("</table>");
            Response.Write("</body>");
            Response.Write("</html>");
        }
        else
        {
            lblErrMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
}
