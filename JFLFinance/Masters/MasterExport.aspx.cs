// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="MasterExport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Class Masters_Export
/// </summary>
public partial class Masters_Export : BasePage //System.Web.UI.Page
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
        
        DL.MastersManagement objMastersManagement = new DL.MastersManagement();
        DataSet dsMaster = new DataSet();
        DataTable dtMaster = new DataTable();
        switch (Type)
        {
            case "MASTER":
                eType = Request.QueryString["eType"].ToString();

                //if (eType == "QUALIFICATION")
                //{
                    //BL.Roster objRost = new BL.Roster();
                    //DataSet dsTagRef = new DataSet();
                    //DataTable dtTagRef = new DataTable();
                    dsMaster = objMastersManagement.ExportMasterToExcel(eType, BaseCompanyCode, BaseLocationAutoID);

                    if (dsMaster != null && dsMaster.Tables.Count > 0 && dsMaster.Tables[0].Rows.Count > 0)
                    {
                        #region To Export to Excel From Dataset
                        /******************* Export to Excel Format ******************************************/
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename="+ eType +".xls");
                        Response.ContentType = "application/octet-stream";
                        Response.Write("<html>");
                        Response.Write("<head>");
                        Response.Write("<style type='text/css'>");
                        Response.Write("</style>");
                        Response.Write("</head>");
                        Response.Write("<body>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        Response.Write("<tr>");
                        for (int i = 0; i < dsMaster.Tables[0].Columns.Count; i++)
                        {
                            //Code Commented And Added By Ajay Datta On 18-Oct-2012 To pick column names from Resource File
                            //Response.Write("<td>" + dsMaster.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                            Response.Write("<td><b>" + ResourceValueOfKey_Get(dsMaster.Tables[0].Columns[i].ColumnName.ToString().Trim()) + "</b></td>");
                        }
                        //*******************************
                        Response.Write("</tr>");
                        Response.Write("</table>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        for (int i = 0; i < dsMaster.Tables[0].Rows.Count; i++)
                        {
                            Response.Write("<tr width='100%'>");
                            for (int j = 0; j < dsMaster.Tables[0].Columns.Count; j++)
                            {
                                Response.Write("<td>" + dsMaster.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
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
                        //Response.Write("data not found!");
                        Response.Write(Resources.Resource.NoDataToShow);
                    }
                //}

                //if (eType == "ASSIGNMENT")
                //{
                //    //BL.Roster objRost = new BL.Roster();
                //    //DataSet dsTagRef = new DataSet();
                //    //DataTable dtTagRef = new DataTable();
                //    dsMaster = objMastersManagement.blAsmtTagRef_Get(BaseLocationAutoID, "", "Active");
                //    if (dsMaster != null && dsMaster.Tables.Count > 0 && dsMaster.Tables[0].Rows.Count > 0)
                //    {
                //        #region To Export to Excel From Dataset
                //        /******************* Export to Excel Format ******************************************/
                //        Response.Clear();
                //        Response.AddHeader("Content-Disposition", "attachment; filename=AssignmentTagMapping.xls");
                //        Response.ContentType = "application/octet-stream";
                //        Response.Write("<html>");
                //        Response.Write("<head>");
                //        Response.Write("<style type='text/css'>");
                //        Response.Write("</style>");
                //        Response.Write("</head>");
                //        Response.Write("<body>");
                //        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                //        Response.Write("<tr>");
                //        for (int i = 0; i < dsMaster.Tables[0].Columns.Count; i++)
                //        {
                //            Response.Write("<td>" + dsMaster.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                //        }
                //        //*******************************
                //        Response.Write("</tr>");
                //        Response.Write("</table>");
                //        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                //        for (int i = 0; i < dsMaster.Tables[0].Rows.Count; i++)
                //        {
                //            Response.Write("<tr width='100%'>");
                //            for (int j = 0; j < dsMaster.Tables[0].Columns.Count; j++)
                //            {
                //                Response.Write("<td>" + dsMaster.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
                //            }
                //            Response.Write("</tr>");
                //        }
                //        //********************************************
                //        Response.Write("</table>");
                //        Response.Write("</body>");
                //        Response.Write("</html>");
                //        /*******************End OF Export to Excel Format ******************************************/
                //        #endregion
                //    }
                //    else
                //    {
                //        //Response.Write("data not found!");
                //        Response.Write(Resources.Resource.NoDataToShow);
                //    }
                //}

                //if (eType == "EMPLOYEE")
                //{
                //    //BL.Roster objRost = new BL.Roster();
                //    //DataSet dsTagRef = new DataSet();
                //    //DataTable dtTagRef = new DataTable();
                //    dsMaster = objMastersManagement.blEmployeeTagRef_Get("", "Active");
                //    if (dsMaster != null && dsMaster.Tables.Count > 0 && dsMaster.Tables[0].Rows.Count > 0)
                //    {
                //        #region To Export to Excel From Dataset
                //        /******************* Export to Excel Format ******************************************/
                //        Response.Clear();
                //        Response.AddHeader("Content-Disposition", "attachment; filename=EmployeeTagMapping.xls");
                //        Response.ContentType = "application/octet-stream";
                //        Response.Write("<html>");
                //        Response.Write("<head>");
                //        Response.Write("<style type='text/css'>");
                //        Response.Write("</style>");
                //        Response.Write("</head>");
                //        Response.Write("<body>");
                //        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                //        Response.Write("<tr>");
                //        for (int i = 0; i < dsMaster.Tables[0].Columns.Count; i++)
                //        {
                //            Response.Write("<td>" + dsMaster.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                //        }
                //        //*******************************
                //        Response.Write("</tr>");
                //        Response.Write("</table>");
                //        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                //        for (int i = 0; i < dsMaster.Tables[0].Rows.Count; i++)
                //        {
                //            Response.Write("<tr width='100%'>");
                //            for (int j = 0; j < dsMaster.Tables[0].Columns.Count; j++)
                //            {
                //                Response.Write("<td>" + dsMaster.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
                //            }
                //            Response.Write("</tr>");
                //        }
                //        //********************************************
                //        Response.Write("</table>");
                //        Response.Write("</body>");
                //        Response.Write("</html>");
                //        /*******************End OF Export to Excel Format ******************************************/
                //        #endregion
                //    }
                //    else
                //    {
                //        //Response.Write("data not found!");
                //        Response.Write(Resources.Resource.NoDataToShow);
                //    }
                //}

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
