// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="MSXLPaySumSaudi.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_MSXLPaySumSaudi.
/// </summary>
public partial class Transactions_MSXLPaySumSaudi : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        string strClientCode = Request.QueryString["strClientCode"].ToString();
        DateTime strFromDate = DateTime.Parse(Request.QueryString["strFromDate"].ToString());
        DateTime strToDate = DateTime.Parse(Request.QueryString["strToDate"].ToString());

        ds = objRoster.RosterForPaysumGet(BaseLocationAutoID, strClientCode, strFromDate, strToDate);
        DataTable dtDayName = new DataTable();
        int StartDay = int.Parse(DateTime.Parse(strFromDate.ToString()).ToString("dd"));
        int EndDay = int.Parse(DateTime.Parse(strToDate.ToString()).ToString("dd"));
        dtDayName.Rows.Add(dtDayName.NewRow());
        DateTime dtDate = DateTime.Parse(strFromDate.ToString());
        for (int i = StartDay; i <= EndDay; i++)
        {
            DataColumn dCol1 = new DataColumn(i.ToString(), typeof(System.String));
            dtDayName.Columns.Add(dCol1);
            dtDayName.Rows[0][i - 1] = dtDate.ToString("ddd");
            dtDate = dtDate.AddDays(1);
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=PaySum.xls");
            Response.ContentType = "application/octet-stream";
            Response.Write("<html>");
            Response.Write("<head>");
            Response.Write("<style type='text/css'>");
            Response.Write("</style>");
            Response.Write("</head>");
            Response.Write("<body>");
            Response.Write("<table width=100% border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
            Response.Write("<tr>");
            Response.Write("<td style='text-align:center;'  bgcolor='aqua' colspan='35'></td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td bgcolor='aqua'>" + Resources.Resource.Region + "</td>");
            Response.Write("<td  bgcolor='yellow'>" + ds.Tables[0].Rows[0]["Division"].ToString() + "</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td bgcolor='aqua'>"+ Resources.Resource.HrLocation+"</td>");
            Response.Write("<td bgcolor='yellow'>" + ds.Tables[0].Rows[0]["Branch"].ToString() + "</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td bgcolor='aqua'>" + Resources.Resource.ClientCode + "</td>");
            Response.Write("<td  bgcolor='yellow'>" + ds.Tables[0].Rows[0]["ClientCode"].ToString() + "&nbsp&nbsp" + "</td>");
            Response.Write("</tr>");
            //Response.Write("<tr>");
            //Response.Write("<td bgcolor='aqua'>" + Resources.Resource.ClientName + "</td>");
            //Response.Write("<td  bgcolor='yellow'>" + ds.Tables[0].Rows[0]["ClientName"].ToString() + "&nbsp&nbsp" + "</td>");
            //Response.Write("</tr>");

            //Response.Write("<tr>");
            //Response.Write("<td bgcolor='aqua'>" + Resources.Resource.Asmt + "</td>");
            //Response.Write("<td  bgcolor='yellow'>" + ds.Tables[0].Rows[0]["AsmtCode"].ToString() + "&nbsp&nbsp" + "</td>");
            //Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td bgcolor='aqua'>"+ Resources.Resource.Month+"</td>");
            Response.Write("<td  bgcolor='yellow'>" + DateTime.Parse(strToDate.ToString()).ToString("MMMM") + "</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
            Response.Write("<tr></tr>");
            Response.Write("<tr height=50>");
            Response.Write("<td>"+Resources.Resource.ClientName +" </td>");
            Response.Write("<td>"+ Resources.Resource.ClientName+"</td>");
            Response.Write("<td>");
            Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
            Response.Write("<tr>");
            Response.Write("<td colspan=32 style='text-align:center;' bordercolor='aqua'>" + DateTime.Parse(strFromDate.ToString()).ToString("MMMM") + "&nbsp " + DateTime.Parse(strFromDate.ToString()).ToString("yyyy") + "</td>");
            //Response.Write("<td>"+ DateTime.Parse(strFromDate.ToString()).ToString("yyyy") + "</td>");


            Response.Write("</tr>");
            Response.Write("<tr>");
            // To Show Day Name**********************
            for (int i = 0; i < dtDayName.Columns.Count; i++)
            {
                Response.Write("<td>" + Convert.ToString(dtDayName.Rows[0][i].ToString()).Substring(0, 1) + "</td>");
            }
            //*****************************************
            Response.Write("</tr>");
            Response.Write("<tr>");
            //To Show Date[ Like 1,2,3,4...,30] in excel
            for (int i = 7; i < ds.Tables[0].Columns.Count; i++)
            {
                Response.Write("<td>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
            }
            //*******************************
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</tr>");
            Response.Write("</table>");

            Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
            // To Show Employee Details******************
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Response.Write("<tr width='100%'>");
                for (int j = 5; j < ds.Tables[0].Columns.Count; j++)
                {
                    Response.Write("<td   bgcolor='yellow'>" + ds.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
                }
                Response.Write("</tr>");
            }
            //********************************************
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
