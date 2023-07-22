// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="MSXLClientDetailsQubic.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Sales_MSXLClientDetailsQubic.
/// </summary>
public partial class Sales_MSXLClientDetailsQubic : BasePage
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
        ds = objSales.ClientDetailsGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=ClientDetails.xls");
            Response.ContentType = "application/octet-stream";
            Response.Write("<html>");
            Response.Write("<head>");
            Response.Write("<style type='text/css'>");
            Response.Write("</style>");
            Response.Write("</head>");
            Response.Write("<body>");
            Response.Write("<table width=200 border=1 cellspacing=0 cellpadding=2>");
            Response.Write("<tr>");
            Response.Write("<td><font style='font-weight:bold'>CompanyID</font></td>");
            Response.Write("<td><font style='font-weight:bold'>LocalID</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CustomerName</font></td>");
            Response.Write("<td><font style='font-weight:bold'>Address</font></td>");
            Response.Write("<td><font style='font-weight:bold'>PostCode</font></td>");
            Response.Write("<td><font style='font-weight:bold'>City</font></td>");
            Response.Write("<td><font style='font-weight:bold'>Country</font></td>");
            Response.Write("<td><font style='font-weight:bold'>CRegNo</font></td>");
            Response.Write("<td><font style='font-weight:bold'>IndustryClass</font></td>");
            Response.Write("<td><font style='font-weight:bold'>AccountManager</font></td>");
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
