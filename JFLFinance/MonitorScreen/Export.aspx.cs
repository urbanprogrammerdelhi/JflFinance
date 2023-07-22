// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By :  
// Last Modified On : 04-24-2014
// ***********************************************************************
// <copyright file="Export.aspx.cs" company="Magnon">
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


public partial class MonitorScreen_Export : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// Function called on Load event of Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string Type = Request.QueryString["type"];
        DateTime dtf, dtt, tf, tt;
        string asmt, strClientCode, post, scantype, selectedGT, PostString, Scan, EType;
        DataSet ds = new DataSet();
        DL.Misc objMISC = new DL.Misc();

        if (Request.QueryString["dtf"] != null)
        {
            dtf = DateTime.Parse(Request.QueryString["dtf"]);
        }
        else
        {
            dtf = DateTime.Now;
        }

        if (Request.QueryString["tf"] != null)
        {
            tf = DateTime.Parse(Request.QueryString["tf"]);
        }
        else
        {
            tf = DateTime.Now; 
        }
        if (Request.QueryString["tt"] != null)
        {
            tt = DateTime.Parse(Request.QueryString["tt"]);
        }
        else
        {
            tt = DateTime.Now;
        }
        if (Request.QueryString["dtt"] != null)
        {
            dtt = DateTime.Parse(Request.QueryString["dtt"]);
        }
        else
        {
            dtt = DateTime.Now;
        }
        switch (Type)
        {
            case "INCIDENT":

                strClientCode = Request.QueryString["clnt"];

                ds = objMISC.DlNfcIncidentExport(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(tf), DateTimeFormat(tt), DateFormat(dtf), DateFormat(dtt), BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    exportToExcel(ds.Tables[0], "Incident.xls");
                }
                else
                {
                    Response.Write("data not found!");
                }

                break;
            case "PANIC":
                strClientCode = Request.QueryString["clnt"];

                ds = objMISC.DlNfcPanicExport(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(tf), DateTimeFormat(tt), DateFormat(dtf), DateFormat(dtt), BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    exportToExcel(ds.Tables[0], "Panic.xls");
                }
                else
                {
                    Response.Write("data not found!");
                }

                break;
            case "ATTENDANCE":
                asmt = Request.QueryString["asmt"];
                PostString = Request.QueryString["PostString"];
                Scan = Request.QueryString["Scan"];
                string wet = Request.QueryString["wet"].ToString();
                string strFlag = "CLIENT";

                if (asmt.ToUpper() != "ALL")
                {
                    strFlag = Request.QueryString["EType"].ToString();
                }

                //Commented by  on 28-Apr-2014
                //if (asmt.IndexOf("/") > 0)
                //{
                //    asmt = asmt.Substring(0, asmt.IndexOf("/"));
                //}


                dtf = DateTime.Parse(Request.QueryString["dt"]);
                tf = DateTime.Parse(Request.QueryString["tf"]);
                tt = DateTime.Parse(Request.QueryString["tt"]);


                //ds = objMISC.dlNFC_EmployeeAttendance_Export(asmt, dtf, tf, tt, wet, BaseLocationAutoID);
                ds = objMISC.DlClientController(dtf, tf, tt, asmt, wet, BaseLocationAutoID, strFlag, PostString, Scan);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //exportToExcel(ds.Tables[0], "Attendance.xls");

                    #region To Export to Excel From Dataset
                    /******************* Export to Excel Format ******************************************/
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=Attendance.xls");
                    Response.ContentType = "application/octet-stream";
                    Response.Write("<html>");
                    Response.Write("<head>");
                    Response.Write("<style type='text/css'>");
                    Response.Write("</style>");
                    Response.Write("</head>");
                    Response.Write("<body>");
                    Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                    Response.Write("<tr>");
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        Response.Write("<td>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                    }
                    //*******************************
                    Response.Write("</tr>");
                    Response.Write("</table>");
                    Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Response.Write("<tr width='100%'>");
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            Response.Write("<td>" + ds.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
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
                    Response.Write("data not found!");
                }

                break;

            case "GUARDTOUR":
                asmt = Request.QueryString["asmt"];
                strClientCode = Request.QueryString["clnt"];

                scantype = Request.QueryString["scantype"];

                selectedGT = Request.QueryString["selectedGT"];

                //ContentPlaceHolder CPL = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("Content1");
                //DropDownList ddlPostCode = (DropDownList)CPL.FindControl("ddlPostCode");

                //ddlPostCode.SelectedValue.ToString();

                //post = Request.QueryString["post"];
                 post = Session["GuardTourPostCode"].ToString();
                 ds = objMISC.DlNFCGuardTourExport(BaseCompanyCode, BaseLocationAutoID.ToString(), strClientCode, DateTimeFormat(tf), DateTimeFormat(tt), DateFormat(dtf), DateFormat(dtt), BaseUserID, "0", asmt, post, scantype, selectedGT);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //exportToExcel(ds.Tables[0], "GuardTour.xls");

                    #region To Export to Excel From Dataset
                    /******************* Export to Excel Format ******************************************/
                    Response.Clear();
                    //Response.Charset = "utf-8";
                    Response.AddHeader("Content-Disposition", "attachment; filename=GuardTour.xls");
                    Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                    Response.ContentType = "application/octet-stream";
                    Response.Write("<html>");
                    Response.Write("<head>");
                    Response.Write("<style type='text/css'>");
                    Response.Write("</style>");
                    Response.Write("</head>");
                    Response.Write("<body>");
                    Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                    Response.Write("<tr>");
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        Response.Write("<td>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                    }
                    //*******************************
                    Response.Write("</tr>");
                    Response.Write("</table>");
                    Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Response.Write("<tr width='100%'>");
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            Response.Write("<td>" + ds.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
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
                    Response.Write("data not found!");
                }

                break;
            case "POP":
                asmt = Request.QueryString["asmt"];
                ds = objMISC.DlNFCPOPExport(DateFormat(dtf), BaseLocationAutoID, asmt, DateFormat(dtt));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    exportToExcel(ds.Tables[0], "POP.xls");
                }
                else
                {
                    Response.Write("data not found!");
                }

                break;
            case "VACANT":
                strClientCode = Request.QueryString["clnt"];
                ds = objMISC.DlNfcVacantExport(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(tf), DateTimeFormat(tt), DateFormat(dtf), DateFormat(dtt), BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    exportToExcel(ds.Tables[0], "Vacant.xls");
                }
                else
                {
                    Response.Write("data not found!");
                }


                break;
            case "NOSHOW":

                strClientCode = Request.QueryString["clnt"];
                ds = objMISC.DlNfcNoShowExport(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(tf), DateTimeFormat(tt), DateFormat(dtf), DateFormat(dtt), BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    exportToExcel(ds.Tables[0], "NOSHOW.xls");
                }
                else
                {
                    Response.Write("data not found!");
                }
                break;
            case "Unscheduled":

                DL.NFC objNFC = new DL.NFC();  
                asmt = Request.QueryString["asmt"];
                strClientCode = Request.QueryString["clnt"];
                dtf =DateTime.Parse(Request.QueryString["dtf"]);
                dtt = DateTime.Parse(Request.QueryString["dtt"]);
                tf = DateTime.Parse(Request.QueryString["tf"]);
                tt = DateTime.Parse(Request.QueryString["tt"]);
                // post = Request.QueryString["post"];
                post = Session["UncheduledEmployeepost"].ToString();
                //Modify By  on 24-Apr-2014
                //ds = objNFC.dlNfc_UnscheduledEmployee(strClientCode, asmt, post, DateFormat(dtf), DateFormat(dtt), DateTimeFormat(tf), DateTimeFormat(tt),BaseLocationAutoID);
                ds = objNFC.DlNfcUnscheduledEmployee(strClientCode, asmt, post, DateFormat(dtf), DateFormat(dtt), DateTimeFormat(tf), DateTimeFormat(tt), BaseLocationAutoID);
                // dlNfc_UnscheduledEmployee(string ClientCode, string AsmtCode, string PostCode,  string Fromdate, string Todate,string TimeFrom, string TimeTo)
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    exportToExcel(ds.Tables[0], "Unscheduled.xls");
                }
                else
                {
                    Response.Write("data not found!");
                }


                break;

            // string url = "Export.aspx?type=Unscheduled&clnt=" + ddlUnClientCode.SelectedItem.Value.ToString() + "&tf=" + DateTimeFormat(DateTime.Parse(txtUnTimeFrom.Text)) + "&tt=" + DateTimeFormat(DateTime.Parse(txtUnTimeTo.Text)) + "&dtf=" + DateFormat(DateTime.Parse(txtUnWEF.Text)) + "&dtt=" + DateFormat(DateTime.Parse(txtUnTimeFrom.Text)) + "&asmt=" + ddlUnAsmtCode.SelectedItem.Value.ToString() + "&post=" + ddlUnPostCode.SelectedItem.Value;

            case "MASTERPOP":
                EType = Request.QueryString["EType"].ToString();

                if (EType == "LOCATION")
                {
                    BL.Roster objRost = new BL.Roster();
                    DataSet dsTagRef = new DataSet();
                    DataTable dtTagRef = new DataTable();
                    //Modify By  on 24-Apr-2014
                    //dsTagRef = objRost.blLocationTagRef_Get("");
                    dsTagRef = objRost.BlLocationTagRefGet("");
                    if (dsTagRef != null && dsTagRef.Tables.Count > 0 && dsTagRef.Tables[0].Rows.Count > 0)
                    {
                        #region To Export to Excel From Dataset
                        /******************* Export to Excel Format ******************************************/
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=LocationTagMapping.xls");
                        Response.ContentType = "application/octet-stream";
                        Response.Write("<html>");
                        Response.Write("<head>");
                        Response.Write("<style type='text/css'>");
                        Response.Write("</style>");
                        Response.Write("</head>");
                        Response.Write("<body>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        Response.Write("<tr>");
                        for (int i = 0; i < dsTagRef.Tables[0].Columns.Count; i++)
                        {
                            Response.Write("<td>" + dsTagRef.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                        }
                        //*******************************
                        Response.Write("</tr>");
                        Response.Write("</table>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        for (int i = 0; i < dsTagRef.Tables[0].Rows.Count; i++)
                        {
                            Response.Write("<tr width='100%'>");
                            for (int j = 0; j < dsTagRef.Tables[0].Columns.Count; j++)
                            {
                                Response.Write("<td>" + dsTagRef.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
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
                        Response.Write("data not found!");
                    }
                }

                if (EType == "ASSIGNMENT")
                {
                    BL.Roster objRost = new BL.Roster();
                    DataSet dsTagRef = new DataSet();
                    DataTable dtTagRef = new DataTable();
                    //Modify By  on 24-Apr-2014
                    //dsTagRef = objRost.blAsmtTagRef_Get(BaseLocationAutoID, "", "Active");
                    dsTagRef = objRost.BlAsmtTagRefGet(BaseLocationAutoID, "");
                    if (dsTagRef != null && dsTagRef.Tables.Count > 0 && dsTagRef.Tables[0].Rows.Count > 0)
                    {
                        #region To Export to Excel From Dataset
                        /******************* Export to Excel Format ******************************************/
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=AssignmentTagMapping.xls");
                        Response.ContentType = "application/octet-stream";
                        Response.Write("<html>");
                        Response.Write("<head>");
                        Response.Write("<style type='text/css'>");
                        Response.Write("</style>");
                        Response.Write("</head>");
                        Response.Write("<body>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        Response.Write("<tr>");
                        for (int i = 0; i < dsTagRef.Tables[0].Columns.Count; i++)
                        {
                            Response.Write("<td>" + dsTagRef.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                        }
                        //*******************************
                        Response.Write("</tr>");
                        Response.Write("</table>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        for (int i = 0; i < dsTagRef.Tables[0].Rows.Count; i++)
                        {
                            Response.Write("<tr width='100%'>");
                            for (int j = 0; j < dsTagRef.Tables[0].Columns.Count; j++)
                            {
                                Response.Write("<td>" + dsTagRef.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
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
                        Response.Write("data not found!");
                    }
                }

                if (EType == "EMPLOYEE")
                {
                    BL.Roster objRost = new BL.Roster();
                    DataSet dsTagRef = new DataSet();
                    DataTable dtTagRef = new DataTable();
                    //Modify By  on 24-Apr-2014
                    //dsTagRef = objRost.blEmployeeTagRef_Get("", "Active");
                    dsTagRef = objRost.BlEmployeeTagRefGet("", "Active");
                    if (dsTagRef != null && dsTagRef.Tables.Count > 0 && dsTagRef.Tables[0].Rows.Count > 0)
                    {
                        #region To Export to Excel From Dataset
                        /******************* Export to Excel Format ******************************************/
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=EmployeeTagMapping.xls");
                        Response.ContentType = "application/octet-stream";
                        Response.Write("<html>");
                        Response.Write("<head>");
                        Response.Write("<style type='text/css'>");
                        Response.Write("</style>");
                        Response.Write("</head>");
                        Response.Write("<body>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        Response.Write("<tr>");
                        for (int i = 0; i < dsTagRef.Tables[0].Columns.Count; i++)
                        {
                            Response.Write("<td>" + dsTagRef.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
                        }
                        //*******************************
                        Response.Write("</tr>");
                        Response.Write("</table>");
                        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
                        for (int i = 0; i < dsTagRef.Tables[0].Rows.Count; i++)
                        {
                            Response.Write("<tr width='100%'>");
                            for (int j = 0; j < dsTagRef.Tables[0].Columns.Count; j++)
                            {
                                Response.Write("<td>" + dsTagRef.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
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
                        Response.Write("data not found!");
                    }
                }

                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Function used to export record in excel format
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="strFieName"></param>
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
