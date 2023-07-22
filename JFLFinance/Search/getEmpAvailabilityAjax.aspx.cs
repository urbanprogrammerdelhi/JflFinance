// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="getEmpAvailabilityAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getEmpAvailabilityAjax.
/// </summary>
public partial class Transactions_getEmpAvailabilityAjax : BasePage//System.Web.UI.Page
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
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        string strEmpNo = Request.QueryString["EmpNo"];
        string strFromDate = Request.QueryString["Date1"];
        string strToDate = Request.QueryString["Date2"];
        string strAttendanceType = Request.QueryString["AttendanceType"];

        if (strAttendanceType == "Sch")
        {
            ds = objHRManagement.EmployeeAvailabilityGet(strEmpNo, strFromDate, strToDate);
        }
        else
        {
            ds = objHRManagement.EmployeeActualAvailabilityGet(strEmpNo, strFromDate, strToDate);
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            Response.Write("<table style='font-family:Verdana; font-size:smaller; cellpadding:0; cellspacing:0; border: 1px; border-style: solid' >");
            Response.Write("<tr><td valign=top width=50>"+ Resources.Resource.Date+ "-><br>"+Resources.Resource.Shift+"-></td>");
            string strShift = "";
            string strColor = "";
            string strShift1 = "";
            string strDate = "";
            string strColor1 = "";
            int cnt = DateTime.Parse(ds.Tables[0].Rows[0]["DutyDate"].ToString()).Day;
            strDate = ds.Tables[0].Rows[0]["DutyDate"].ToString();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Shift"].ToString() == "")
                {
                    strShift = "&nbsp;";
                    strColor = "background-color:green;color:white";
                }
                else if (ds.Tables[0].Rows[i]["Shift"].ToString() == "L")
                {
                    strShift = "L";
                    strColor = "background-color:Yellow";
                }
                else if (ds.Tables[0].Rows[i]["Shift"].ToString() == "0")
                {
                    strShift = "0";
                    strColor = "background-color:gray;color:white";
                }                
                else
                {
                    strShift = ds.Tables[0].Rows[i]["Shift"].ToString();
                    strColor = "background-color:red;color:white";
                }

                if (strDate != ds.Tables[0].Rows[i]["DutyDate"].ToString())
                {
                    Response.Write("<td valign='top' style='width:18px; text-Align:center;" + strColor1 + " '><b>" + cnt + "</b><br>" + strShift1 + "</td>");
                    cnt = DateTime.Parse(ds.Tables[0].Rows[i]["DutyDate"].ToString()).Day;//cnt + 1;
                    strShift1 = ds.Tables[0].Rows[i]["shift"].ToString(); 
                    strDate = ds.Tables[0].Rows[i]["DutyDate"].ToString();
                    strColor1 = strColor;
                }
                else
                {
                    if (strShift1 != "")
                    {
                        strShift1 = strShift1 + "<br>" + ds.Tables[0].Rows[i]["shift"].ToString();
                    }
                    else
                    {
                        strShift1 = ds.Tables[0].Rows[i]["shift"].ToString();

                    }
                    strColor1 = strColor;
                }

                if (i == ds.Tables[0].Rows.Count-1)
                {
                    Response.Write("<td valign='top' style='width:18px; text-Align:center;" + strColor + " '><b>" + cnt + "</b><br>" + strShift1 + "&nbsp;</td>");
                }

            }
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.End();

        }

    }
}
