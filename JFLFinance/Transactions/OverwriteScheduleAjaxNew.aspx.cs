// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="OverwriteScheduleAjaxNew.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_OverwriteScheduleAjaxNew.
/// </summary>
public partial class Transactions_OverwriteScheduleAjaxNew : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string strAsmtCode = Request.QueryString["AsmtCode"];
        string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
        string strDutyDate = Request.QueryString["DutyDate"];
        string strShiftCode = Request.QueryString["ShiftCode"];
        int intWeek;
        try
        {
             intWeek = int.Parse(Request.QueryString["Week"]);
        }
        catch
        {
            intWeek = 1;
        }
        string strRoleCode = Request.QueryString["RoleCode"];
        string strDesignationCode = Request.QueryString["DesignationCode"];
        string strShiftPatternCode = Request.QueryString["ShiftPatternCode"];
        string strPatternPosition = Request.QueryString["PatternPosition"];
        string strDefaultSite = Request.QueryString["DefaultSite"];
        string strOPSShift = Request.QueryString["OPSShift"];
        string strSORank = Request.QueryString["SORank"];
        string strTimeFrom = Request.QueryString["TimeFrom"];
        string strTimeTo = Request.QueryString["TimeTo"];
        string strDutyTypeCode = Request.QueryString["DutyTypeCode"];
        string EntryType = Request.QueryString["EntryType"];
        int intScheduleRosterAutoID;
        if (Request.QueryString["ScheduleRosterAutoID"].ToString() != "")
        {
            intScheduleRosterAutoID = int.Parse(Request.QueryString["ScheduleRosterAutoID"]);
        }
        else
        {
            intScheduleRosterAutoID = 0;
        }
        int PDLineNo = int.Parse(Request.QueryString["PDLineNo"]);
        string strDuplicateScheduleRosterAutoID = Request.QueryString["DuplicateSchRosterAutoID"];
        int RowNumber = int.Parse(Request.QueryString["RowNumber"]);
        string strAttendanceType = Request.QueryString["AttendanceType"];
        string strFromDate = Request.QueryString["FromDate"];
        string strToDate = Request.QueryString["ToDate"];

        DataSet dsSubmit = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
        {
            dsSubmit = objRoster.NewScheduleRosterShiftOverwrite(strAsmtCode, strEmployeeNumber, strDutyDate, strShiftCode, intWeek, strRoleCode, strDesignationCode, strShiftPatternCode, strPatternPosition, strDefaultSite, strOPSShift, strSORank, strTimeFrom, strTimeTo, strDutyTypeCode, intScheduleRosterAutoID, PDLineNo, BaseLocationAutoID, BaseUserID, strDuplicateScheduleRosterAutoID, RowNumber,strFromDate,strToDate);
        }
        else
        {
            dsSubmit = objRoster.OverwriteDuplicateRota(strAsmtCode, strEmployeeNumber, strDutyDate, strShiftCode, intWeek, strRoleCode, strDesignationCode, strTimeFrom, strTimeTo, strDutyTypeCode, intScheduleRosterAutoID, PDLineNo, BaseLocationAutoID, BaseUserID, strDuplicateScheduleRosterAutoID, RowNumber, strFromDate, strToDate);
        }
        int d = 0;
        int k = 0;
        if (dsSubmit != null && dsSubmit.Tables.Count > 0 && dsSubmit.Tables[0].Rows.Count > 0)
        {
            if (dsSubmit.Tables[0].Rows[0]["MessageString"].ToString() == "Authorized")
            { Response.Write("Authorized"); Response.End(); }

            Response.Write("<table width=650 border=1 style='font-size:11px' >");
            for (int i = 0; i < dsSubmit.Tables[0].Rows.Count; i++)
            {
                if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
                {
                    if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Duplicate" || dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Converted")
                    {
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString()) + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblAsmtCode_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["AsmtCode"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:14px' id='lblShiftCode_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["ShiftCode"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:80px' id='lblDutyDate_dup" + d + "' >" + DateTime.Parse(dsSubmit.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:60px' id='lblEmpNo_dup" + d + "' >" + strEmployeeNumber + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblTimeFrom_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["TimeFrom"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblTimeTo_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["TimeTo"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Duplicate")
                        {
                            Response.Write("<input type='checkbox' id='chk" + d + "' />");

                        }
                        else
                        {
                            Response.Write(Resources.Resource.Converted);
                        }
                        Response.Write("<input type='hidden' id='lblDupSchRosterAutoID" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblColIndex_dup" + d + "' value='" + (i + 1) + "'    />");
                        d = d + 1;
                    }
                    if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Insert")
                    {
                        //  if (dt.Rows.Count > 0)
                        // {
                        //Response.Write("<input type='hidden' id='lblMsgShiftDuplicate" + k + "' value='" + dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() + "'    />");
                        //Response.Write("<input type='hidden' id='lblInsertDutyDate" + k + "' value='" + DateTime.Parse(dsSubmit.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "'    />");
                        //Response.Write("<input type='hidden' id='lblInsertShiftCode" + k + "' value='" + dsSubmit.Tables[0].Rows[i]["ShiftCode"].ToString() + "'    />");
                        //Response.Write("<input type='hidden' id='lblScheduleRosterAutoID" + k + "' value='" + dsSubmit.Tables[0].Rows[i]["SchRosterAutoID"].ToString() + "'    />");

                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + k + "' >" + ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString()) + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblInsertDutyDate" + k + "' >" + DateTime.Parse(dsSubmit.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:14px' id='lblInsertShiftCode" + k + "' >" + dsSubmit.Tables[0].Rows[i]["ShiftCode"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:80px' id='lblScheduleRosterAutoID" + k + "' >" + dsSubmit.Tables[0].Rows[i]["SchRosterAutoID"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblInsertTimeFrom" + k + "' >" + dsSubmit.Tables[0].Rows[i]["TimeFrom"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblInsertTimeTo" + k + "' >" + dsSubmit.Tables[0].Rows[i]["TimeTo"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblOverWrite" + k + "' >" + ResourceValueOfKey_Get("OverWrite") + "</div>");
                        Response.Write("</td><td>");
                        //}
                        k = k + 1;
                    }
                }
                else
                {
                    if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() != "OverWrite")
                    {
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + k + "' >" + "Alert" + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblMessage" + k + "' >" + ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString()) + "</div>");
                        Response.Write("</td><td>");
                    }
                    else
                    {
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + k + "' >" + "OverWrite" + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblMessage" + k + "' >" + ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString()) + "</div>");
                        Response.Write("</td><td>");
                    }
                }
                Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + dsSubmit.Tables[0].Rows.Count + "'    />");
                Response.Write("</td></tr>");
            }

            Response.Write("</table >");
            Response.End();
        }
        else
        {
            Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + 0 + "'    />"); // Value is 0 so that it doest give error on return
            Response.Write("error!");
            Response.End();
        }


    }
}
