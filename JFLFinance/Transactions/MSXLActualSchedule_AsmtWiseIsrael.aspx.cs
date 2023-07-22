// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="MSXLActualSchedule_AsmtWiseIsrael.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;

/// <summary>
/// Class Transactions_MSXLActualSchedule_AsmtWiseIsrael.
/// </summary>
public partial class Transactions_MSXLActualSchedule_AsmtWiseIsrael : BasePage//System.Web.UI.Page
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
    /// The string report name
    /// </summary>
    public string strReportName;
    /// <summary>
    /// The string from date
    /// </summary>
    public string strFromDate;
    /// <summary>
    /// The string to date
    /// </summary>
    public string strToDate;

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
                    strReportName = Request.QueryString["ReportName"].ToString();
                    strFromDate = this.ReportParameters[DL.Properties.Resources.FromDate].ToString();
                    strToDate = this.ReportParameters[DL.Properties.Resources.ToDate].ToString();

                    var objR = new BL.Roster();
                    if (ReportParameters != null)
                    {
                        DataSet ds = new DataSet();
                            ds = objR.SchActualAsmtWiseGet(this.ReportParameters[DL.Properties.Resources.CompanyCode].ToString(),
                            this.ReportParameters[DL.Properties.Resources.LocationAutoId].ToString(),
                            this.ReportParameters[DL.Properties.Resources.ClientCode].ToString(),
                            this.ReportParameters[DL.Properties.Resources.AsmtCode].ToString(),
                            this.ReportParameters[DL.Properties.Resources.AreaId].ToString(),
                            this.ReportParameters[DL.Properties.Resources.FromDate].ToString(),
                            this.ReportParameters[DL.Properties.Resources.ToDate].ToString(),
                            this.ReportParameters[DL.Properties.Resources.ScheduleActual].ToString(),
                            this.ReportParameters[DL.Properties.Resources.AreaIncharge].ToString(),
                            this.ReportParameters[DL.Properties.Resources.Option].ToString());
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            ExporttoExcel(ds);
                        }
                    }
                }
            }
        }
    }

    #region To Export to Excel From Dataset

    /// <summary>
    /// Exporttoes the excel.
    /// </summary>
    /// <param name="ds">The ds.</param>
    protected void ExporttoExcel(DataSet ds)
    {
        //DataTable dtDayName = new DataTable();
        //int StartDay = int.Parse(DateTime.Parse(strFromDate.ToString()).ToString("dd"));
        //int EndDay = int.Parse(DateTime.Parse(strToDate.ToString()).ToString("dd"));
        //dtDayName.Rows.Add(dtDayName.NewRow());
        //DateTime dtDate = DateTime.Parse(strFromDate.ToString());
        //for (int i = StartDay; i <= EndDay; i++)
        //{
        //    DataColumn dCol1 = new DataColumn(i.ToString(), typeof(System.String));
        //    dtDayName.Columns.Add(dCol1);
        //    dtDayName.Rows[0][i - 1] = dtDate.ToString("ddd");
        //    dtDate = dtDate.AddDays(1);
        //}
        DateTime dtLoopDate = DateTime.Parse(strFromDate);

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + strReportName + ".xls");
        Response.ContentType = "application/octet-stream";
        Response.Write("<html>");
        Response.Write("<head>");
        Response.Write("<style type='text/css'>");
        Response.Write("</style>");
        Response.Write("</head>");
        Response.Write("<body>");
        Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
        Response.Write("<tr>");
        Response.Write("<td style='text-align:center;' bgcolor='aqua' colspan='35'>" + strReportName + "</td>");
        Response.Write("</tr>");
        Response.Write("<tr>");
        Response.Write("<td bgcolor='aqua'>"+Resources.Resource.Company+"</td>");
        Response.Write("<td  bgcolor='yellow'>" + ds.Tables[0].Rows[0]["CompanyDesc"].ToString() + "</td>");
        Response.Write("</tr>");
        Response.Write("<tr>");
        Response.Write("<td bgcolor='aqua'>"+Resources.Resource.Branch+"</td>");
        Response.Write("<td bgcolor='yellow'>" + ds.Tables[0].Rows[0]["LocationDesc"].ToString() + "</td>");
        Response.Write("</tr>");
        Response.Write("<tr>");
        Response.Write("<td bgcolor='aqua'>"+Resources.Resource.FromDate+"</td>");
        Response.Write("<td  bgcolor='yellow'>" + DateTime.Parse(strFromDate).ToString("dd-MMM-yyyy") + "</td>");
        Response.Write("</tr>");
        Response.Write("<tr>");
        Response.Write("<td bgcolor='aqua'>"+Resources.Resource.ToDate+"</td>");
        Response.Write("<td  bgcolor='yellow'>" + DateTime.Parse(strToDate.ToString()).ToString("dd-MMM-yyyy") + "</td>");
        Response.Write("</tr>");
        Response.Write("</table>");

        Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
        Response.Write("<tr></tr>");
        Response.Write("<tr>");
        Response.Write("<td>"+Resources.Resource.Assignment+"</td>");
        Response.Write("<td></td>");
        Response.Write("</tr>");
        Response.Write("<tr>");
        Response.Write("<td>" + Resources.Resource.AsmtId + "</td>");
        Response.Write("<td></td>");
        Response.Write("</tr>");
        Response.Write("<tr>");
        Response.Write("<td>" + Resources.Resource.Post + "</td>");
        Response.Write("<td></td>");
        Response.Write("</tr>");
        Response.Write("<tr>");
        Response.Write("<td>" + Resources.Resource.Rank + "</td>");
        Response.Write("<td></td>");
        Response.Write("</tr>");
        Response.Write("</table>");

        Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
        Response.Write("<tr>");
        Response.Write("<td bgcolor='aqua'>" + Resources.Resource.YLMUniqueId + "</td>");
        Response.Write("<td bgcolor='aqua'>" + Resources.Resource.Shift + "</td>");
        Response.Write("<td bgcolor='aqua'>" + Resources.Resource.Date + "</td>");

        dtLoopDate = DateTime.Parse(strFromDate);
        while (dtLoopDate <= DateTime.Parse(strToDate))
        {
            Response.Write("<td bgcolor='aqua'>" + dtLoopDate.ToString("dd-MMM-yyyy") + "</td>");
            dtLoopDate = dtLoopDate.AddDays(1);
        }
        Response.Write("</tr>");
        Response.Write("<tr>");
        Response.Write("<td></td>");
        Response.Write("<td></td>");
        Response.Write("<td bgcolor='aqua'>" + Resources.Resource.Day + "</td>");
        dtLoopDate = DateTime.Parse(strFromDate);
        while (dtLoopDate <= DateTime.Parse(strToDate))
        {
            Response.Write("<td bgcolor='aqua'>" + dtLoopDate.ToString("ddd") + "</td>");
            dtLoopDate = dtLoopDate.AddDays(1);
        }
        Response.Write("</tr>");
        
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Response.Write("<tr width='100%'>");
            Response.Write("<td>" + ds.Tables[0].Rows[i]["YLMUniqueId"].ToString() + "&nbsp" + "</td>");
            Response.Write("<td>" + ds.Tables[0].Rows[i]["ShiftCode"].ToString() + "&nbsp" + "</td>");
            Response.Write("<td>" + Resources.Resource.FromToTime + "</td>");
            Response.Write("<td bgcolor='yellow'>" + DateTime.Parse(ds.Tables[0].Rows[i]["StdShiftFromTime"].ToString()).ToString("HH:mm") + "-" + DateTime.Parse(ds.Tables[0].Rows[i]["StdShiftToTime"].ToString()).ToString("HH:mm") + "&nbsp" + "</td>");
            Response.Write("</tr>");
            Response.Write("<tr width='100%'>");
            Response.Write("<td></td>");
            Response.Write("<td></td>");
            Response.Write("<td>" + Resources.Resource.Employee + "</td>");
            Response.Write("<td>" + ds.Tables[0].Rows[i]["EmployeeNumber"].ToString() + "-" + ds.Tables[0].Rows[i]["EmpName"].ToString() + "</td>");
            Response.Write("</tr>");
        }
        //********************************************
        Response.Write("</table>");
        Response.Write("</body>");
        Response.Write("</html>");
    }
    #endregion
}