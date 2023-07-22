// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="HrReportsExport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Class HRManagement_HrReportsExport
/// </summary>
public partial class HRManagement_HrReportsExport : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        string Type = Request.QueryString["type"];
        string eType;

        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet dsHRManagement = new DataSet();
        DataTable dtHRManagement = new DataTable();
        switch (Type)
        {
            case "TRAINING":
                eType = Request.QueryString["eType"].ToString();

                if (eType == "dailyRefresherTrainingDue.rpt")
                {
                    eType = "dailyRefresherTrainingDue";
                    string AreaId = Request.QueryString["AreaId"].ToString();
                    string FromDate = Request.QueryString["FromDate"].ToString();
                    string nDays = Request.QueryString["nDays"].ToString();
                    string LocationCode = Request.QueryString["LocationCode"].ToString();
                    string HrLocationCode = Request.QueryString["HrLocationCode"].ToString();
                    string ClientCode = Request.QueryString["ClientCode"].ToString();
                    string AsmtCode = Request.QueryString["AsmtCode"].ToString();
                    string AreaIncharge = Request.QueryString["AreaIncharge"].ToString();
                    string EmpNo = Request.QueryString["EmpNo"].ToString();
                    string TrainingCode = Request.QueryString["TrainingCode"].ToString();

                    dsHRManagement = objHRManagement.ExportHrReportsToExcel(AreaId, FromDate, nDays, LocationCode, HrLocationCode, ClientCode, AsmtCode, AreaIncharge, EmpNo, TrainingCode, BaseCompanyCode, BaseLocationAutoID, BaseUserID, eType, FromDate);

                    if (dsHRManagement != null && dsHRManagement.Tables.Count > 0 && dsHRManagement.Tables[0].Rows.Count > 0)
                    {
                        #region To Export to Excel From Dataset
                        /******************* Export to Excel Format ******************************************/
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + eType + ".xls");
                        Response.ContentType = "application/octet-stream";
                        Response.Write("<html>");
                        Response.Write("<head>");
                        Response.Write("<style type='text/css'>");
                        Response.Write("</style>");
                        Response.Write("</head>");
                        Response.Write("<body>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        Response.Write("<tr>");
                        for (int i = 0; i < dsHRManagement.Tables[0].Columns.Count; i++)
                        {
                            //Code Commented And Added By Ajay Datta On 18-Oct-2012 To pick column names from Resource File
                            //Response.Write("<td>" + dsMaster.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                            Response.Write("<td><b>" + ResourceValueOfKey_Get(dsHRManagement.Tables[0].Columns[i].ColumnName.ToString().Trim()) + "</b></td>");
                        }
                        //*******************************
                        Response.Write("</tr>");
                        Response.Write("</table>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        for (int i = 0; i < dsHRManagement.Tables[0].Rows.Count; i++)
                        {
                            Response.Write("<tr width='100%'>");
                            for (int j = 0; j < dsHRManagement.Tables[0].Columns.Count; j++)
                            {
                                Response.Write("<td>" + dsHRManagement.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
                            }
                            Response.Write("</tr>");
                        }
                        //********************************************
                        Response.Write("</table>");
                        Response.Write("</body>");
                        Response.Write("</html>");
                        /*******************End OF Export to Excel Format ******************************************/
                        #endregion
                    }
                    else
                    {
                        Response.Write(Resources.Resource.NoDataToShow);
                    }
                }

                if (eType == "dateRangeRefresherTrainingDue.rpt")
                {
                    eType = "dateRangeRefresherTrainingDue";
                    string AreaId = Request.QueryString["AreaId"].ToString();
                    string FromDate = Request.QueryString["FromDate"].ToString();
                    string ToDate = Request.QueryString["ToDate"].ToString();
                    string LocationCode = Request.QueryString["LocationCode"].ToString();
                    string HrLocationCode = Request.QueryString["HrLocationCode"].ToString();
                    string ClientCode = Request.QueryString["ClientCode"].ToString();
                    string AsmtCode = Request.QueryString["AsmtCode"].ToString();
                    string AreaIncharge = Request.QueryString["AreaIncharge"].ToString();
                    string EmpNo = Request.QueryString["EmpNo"].ToString();
                    string TrainingCode = Request.QueryString["TrainingCode"].ToString();

                    dsHRManagement = objHRManagement.ExportHrReportsToExcel(AreaId, FromDate, "0", LocationCode, HrLocationCode, ClientCode, AsmtCode, AreaIncharge, EmpNo, TrainingCode, BaseCompanyCode, BaseLocationAutoID, BaseUserID, eType, ToDate);

                    if (dsHRManagement != null && dsHRManagement.Tables.Count > 0 && dsHRManagement.Tables[0].Rows.Count > 0)
                    {
                        #region To Export to Excel From Dataset
                        /******************* Export to Excel Format ******************************************/
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + eType + ".xls");
                        Response.ContentType = "application/octet-stream";
                        Response.Write("<html>");
                        Response.Write("<head>");
                        Response.Write("<style type='text/css'>");
                        Response.Write("</style>");
                        Response.Write("</head>");
                        Response.Write("<body>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        Response.Write("<tr>");
                        for (int i = 0; i < dsHRManagement.Tables[0].Columns.Count; i++)
                        {
                            //Code Commented And Added By Ajay Datta On 18-Oct-2012 To pick column names from Resource File
                            //Response.Write("<td>" + dsMaster.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                            Response.Write("<td><b>" + ResourceValueOfKey_Get(dsHRManagement.Tables[0].Columns[i].ColumnName.ToString().Trim()) + "</b></td>");
                        }
                        //*******************************
                        Response.Write("</tr>");
                        Response.Write("</table>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        for (int i = 0; i < dsHRManagement.Tables[0].Rows.Count; i++)
                        {
                            Response.Write("<tr width='100%'>");
                            for (int j = 0; j < dsHRManagement.Tables[0].Columns.Count; j++)
                            {
                                Response.Write("<td>" + dsHRManagement.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
                            }
                            Response.Write("</tr>");
                        }
                        //********************************************
                        Response.Write("</table>");
                        Response.Write("</body>");
                        Response.Write("</html>");
                        /*******************End OF Export to Excel Format ******************************************/
                        #endregion
                    }
                    else
                    {
                        Response.Write(Resources.Resource.NoDataToShow);
                    }
                }


                if (eType == "dateRangeRefresherTrainingSchedule.rpt")
                {
                    eType = "dateRangeRefresherTrainingSchedule";
                    string AreaId = Request.QueryString["AreaId"].ToString();
                    string FromDate = Request.QueryString["FromDate"].ToString();
                    string ToDate = Request.QueryString["ToDate"].ToString();
                    string LocationCode = Request.QueryString["LocationCode"].ToString();
                    string HrLocationCode = Request.QueryString["HrLocationCode"].ToString();
                    string ClientCode = Request.QueryString["ClientCode"].ToString();
                    string AsmtCode = Request.QueryString["AsmtCode"].ToString();
                    string AreaIncharge = Request.QueryString["AreaIncharge"].ToString();
                    string EmpNo = Request.QueryString["EmpNo"].ToString();
                    string TrainingCode = Request.QueryString["TrainingCode"].ToString();

                    dsHRManagement = objHRManagement.ExportHrReportsToExcel(AreaId, FromDate, "0", LocationCode, HrLocationCode, ClientCode, AsmtCode, AreaIncharge, EmpNo, TrainingCode, BaseCompanyCode, BaseLocationAutoID, BaseUserID, eType, ToDate);

                    if (dsHRManagement != null && dsHRManagement.Tables.Count > 0 && dsHRManagement.Tables[0].Rows.Count > 0)
                    {
                        #region To Export to Excel From Dataset
                        /******************* Export to Excel Format ******************************************/
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + eType + ".xls");
                        Response.ContentType = "application/octet-stream";
                        Response.Write("<html>");
                        Response.Write("<head>");
                        Response.Write("<style type='text/css'>");
                        Response.Write("</style>");
                        Response.Write("</head>");
                        Response.Write("<body>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        Response.Write("<tr>");
                        for (int i = 0; i < dsHRManagement.Tables[0].Columns.Count; i++)
                        {
                            //Code Commented And Added By Ajay Datta On 18-Oct-2012 To pick column names from Resource File
                            //Response.Write("<td>" + dsMaster.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                            Response.Write("<td><b>" + ResourceValueOfKey_Get(dsHRManagement.Tables[0].Columns[i].ColumnName.ToString().Trim()) + "</b></td>");
                        }
                        //*******************************
                        Response.Write("</tr>");
                        Response.Write("</table>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        for (int i = 0; i < dsHRManagement.Tables[0].Rows.Count; i++)
                        {
                            Response.Write("<tr width='100%'>");
                            for (int j = 0; j < dsHRManagement.Tables[0].Columns.Count; j++)
                            {
                                Response.Write("<td>" + dsHRManagement.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
                            }
                            Response.Write("</tr>");
                        }
                        //********************************************
                        Response.Write("</table>");
                        Response.Write("</body>");
                        Response.Write("</html>");
                        /*******************End OF Export to Excel Format ******************************************/
                        #endregion
                    }
                    else
                    {
                        Response.Write(Resources.Resource.NoDataToShow);
                    }
                }


                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Exports to excel.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <param name="strFieName">Name of the STR fie.</param>
    protected void exportToExcel(DataTable dt, string strFieName)
    {

        string attachment = "attachment; filename=" + strFieName;
        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.ContentType = "application/ms-excel";
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        DataGrid dg = new DataGrid();
        dg.DataSource = dt;
        dg.DataBind();
        dg.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
}