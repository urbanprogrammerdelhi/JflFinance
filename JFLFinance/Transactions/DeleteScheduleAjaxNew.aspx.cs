// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="DeleteScheduleAjaxNew.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_DeleteScheduleAjaxNew.
/// </summary>
public partial class Transactions_DeleteScheduleAjaxNew : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        string SchRosterAutoID = Request.QueryString["ScheduleRosterAutoID"];
        int RowNumber = int.Parse(Request.QueryString["RowNumber"]);
        string strAttendanceType = Request.QueryString["AttendanceType"];
        if (SchRosterAutoID != "")
        {

            if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
            {

                ds = objRoster.NewScheduleRosterDelete(SchRosterAutoID, RowNumber);
            }
            else
            {
                string strDutyDate = Request.QueryString["DutyDate"];
                string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
                string strAsmtCode = Request.QueryString["AsmtCode"];
                ds = objRoster.NewRosterDelete(SchRosterAutoID, RowNumber, strDutyDate, strEmployeeNumber, BaseLocationAutoID, strAsmtCode);
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Response.Write(ResourceValueOfKey_Get(MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()))));
                Response.End();
            }
        }
        else
        {
            string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
            string strAsmtCode = Request.QueryString["AsmtCode"];
            string strFromDate = Request.QueryString["FromDate"];
            string strToDate = Request.QueryString["ToDate"];
            string strShiftPatternCode = Request.QueryString["ShiftPatternCode"];
            string strPatternPosition = Request.QueryString["PatternPosition"];
            if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
            {
                ds = objRoster.EmployeeWiseScheduleDelete(strEmployeeNumber, strAsmtCode, strFromDate, strToDate, strShiftPatternCode, int.Parse(strPatternPosition), RowNumber);
            }
            else
            {
                ds = objRoster.EmployeeWiseRotaDelete(strEmployeeNumber, strAsmtCode, strFromDate, strToDate, RowNumber);
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Response.Write(ResourceValueOfKey_Get(MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()))));
                Response.End();
            }
        }
   
    }
}
