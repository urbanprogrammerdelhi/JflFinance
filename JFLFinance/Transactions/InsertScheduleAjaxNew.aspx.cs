// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="InsertScheduleAjaxNew.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Data;

/// <summary>
/// Class Transactions_InsertScheduleAjaxNew.
/// </summary>
public partial class Transactions_InsertScheduleAjaxNew : BasePage
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
        
        string strAsmtCode = Request.QueryString["AsmtCode"];
        string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
        string strDutyDate = Request.QueryString["DutyDate"];
        string strShiftCode = Request.QueryString["ShiftCode"];
        int intWeek;
        if (Request.QueryString["Week"] == "")
        {
            intWeek = 0;
        }
        else
        {
            intWeek = int.Parse(Request.QueryString["Week"]);
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
        //string EntryType = Request.QueryString["EntryType"];
        int intScheduleRosterAutoID = int.Parse(Request.QueryString["ScheduleRosterAutoID"]);
        int PDLineNo = int.Parse(Request.QueryString["PDLineNo"]);
        int RowNumber = int.Parse(Request.QueryString["RowNumber"]);
        string strPost = Request.QueryString["Post"];
        string strAttendanceType = Request.QueryString["AttendanceType"];
        string strFromDate = Request.QueryString["FromDate"];
        string strToDate = Request.QueryString["ToDate"];
        string strSessionValue = HttpContext.Current.Session.SessionID.ToString();
        //if (EntryType.ToString().Trim().ToLower() == "SINGLE".ToString().Trim().ToLower())
        //{
        int k = 0;
        int d = 0;
        // if (intScheduleRosterAutoID == 0)
        //{
        BL.Roster objRost = new BL.Roster();
        DataSet dsSubmit = new DataSet();
        DataTable dtExceptionLog = new DataTable();
        string strExceptionLog = string.Empty;
        string strExceptionMessage = string.Empty;
        int flag = 0;
        if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
        {
            dsSubmit = objRost.NewScheduleRosterInsert(strAsmtCode, strEmployeeNumber, strDutyDate, strShiftCode, intWeek, strRoleCode, strDesignationCode, strShiftPatternCode, strPatternPosition, strDefaultSite, strOPSShift, strSORank, strTimeFrom, strTimeTo, strDutyTypeCode, intScheduleRosterAutoID, PDLineNo, BaseLocationAutoID, BaseUserID, RowNumber, strPost, strFromDate, strToDate, strSessionValue);
        }
        else
        {
            dsSubmit = objRost.RosterEmployeeWiseInsert(strAsmtCode, strEmployeeNumber, strDutyDate, strShiftCode, intWeek, strRoleCode, strDesignationCode, strTimeFrom, strTimeTo, strDutyTypeCode, intScheduleRosterAutoID, PDLineNo, BaseLocationAutoID, BaseUserID, RowNumber, strPost, strFromDate, strToDate, strSessionValue, strShiftPatternCode, strPatternPosition);
        }
        if (dsSubmit != null && dsSubmit.Tables.Count > 0 && dsSubmit.Tables[0].Rows.Count > 0)
        {
            if (dsSubmit.Tables.Count > 1)
            {
                dtExceptionLog = dsSubmit.Tables[1].Copy();
            }
            if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
            {
                if (dsSubmit.Tables[0].Rows[0]["MessageString"].ToString() == "Authorized")
                { Response.Write("Authorized"); Response.End(); }

                Response.Write("<table width=750 border=1 style='font-size:11px' >");
                for (int i = 0; i < dsSubmit.Tables[0].Rows.Count; i++)
                {
                    if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString().ToLower() == "Duplicate".ToLower() || dsSubmit.Tables[0].Rows[i]["MessageString"].ToString().ToLower() == "Converted".ToLower())
                    {
                        HFStatus.Value = "Duplicate";
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString()) + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblAsmtCode_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["AsmtCode"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblPostDesc_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["PostDesc"] + "</div>");
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
                        if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString().ToLower() == "Duplicate".ToLower())
                        {
                            Response.Write("<input type='checkbox' id='chk" + d + "' />");

                        }
                        else
                        {
                            Response.Write(Resources.Resource.Converted);
                        }
                        Response.Write("<input type='hidden' id='HFPatternPosition" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["PatternPosition"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFRowNumber" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["RowNumber"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblDupSchRosterAutoID" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblColIndex_dup" + d + "' value='" + (i + 1) + "'    />");
                        d = d + 1;
                    }
                    if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Insert")
                    {

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
                        Response.Write("<div style='width:50px' id='lblOverWrite" + k + "' >" + "Insert" + "</div>");
                        Response.Write("</td><td>");
                        //}
                        k = k + 1;

                        if (HFStatus.Value != "Duplicate")
                        {
                            HFStatus.Value = "Insert";
                        }
                    }
                    // Added to Show Exceptions in Scheduling Screen
                    if (dtExceptionLog != null && dtExceptionLog.Rows.Count > 0)
                    {
                        if (dsSubmit.Tables[1].Rows.Count > 0)
                        {
                            if (HFStatus.Value == "Insert" && flag == 0)
                            {
                                flag = 1;
                                string currentRowMessageID = string.Empty;
                                string nextRowMessageID = string.Empty;
                                for (int m = 0; m < dtExceptionLog.Rows.Count; m++)
                                {
                                    try
                                    {
                                        strExceptionMessage = string.Empty;
                                        if (dtExceptionLog.Rows[m]["MessageID"].ToString() == dtExceptionLog.Rows[m + 1]["MessageID"].ToString())
                                        {
                                            currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[m]["MessageID"].ToString()));
                                            nextRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[m + 1]["MessageID"].ToString()));
                                            strExceptionMessage = strExceptionMessage + currentRowMessageID + "," + nextRowMessageID;
                                            m = m + 1;
                                        }
                                        else
                                        {
                                            currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[m]["MessageID"].ToString())) + ",";
                                            strExceptionMessage = strExceptionMessage + currentRowMessageID;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[m]["MessageID"].ToString())) + ",";
                                        strExceptionMessage = strExceptionMessage + currentRowMessageID;
                                    }

                                    //strExceptionLog = strExceptionLog + "\n" + (k + 1) + " . " + strExceptionMessage + "\n";
                                    strExceptionLog = strExceptionLog + strExceptionMessage;
                                }
                                Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                                Response.Write("<div style='width:110px' id='lblMsgID" + 119 + "' >" + "119" + "</div>"); // 119 is HardCoded so that it shows confirm box of exceptions
                                Response.Write("</td><td>");
                                Response.Write("<div style='width:110px' id='lblMsgExceptionEmployeeNumber" + 119 + "' >" + dtExceptionLog.Rows[0]["EmployeeNumber"].ToString() + "</div>");// 119 is HardCoded so that it shows confirm box of exceptions
                                Response.Write("</td><td>");
                                Response.Write("<div style='width:110px' id='lblMsgExceptionMaxToDate" + 119 + "' >" + DateTime.Parse(dtExceptionLog.Rows[0]["MaxToDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");// 119 is HardCoded so that it shows confirm box of exceptions
                                Response.Write("</td><td>");
                                Response.Write("<div style='width:110px' id='lblMsgException" + 119 + "' >" + strExceptionLog + "</div>");// 119 is HardCoded so that it shows confirm box of exceptions
                                Response.Write("</td><td>");
                            }
                        }
                    }
                    if (dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() == "5")
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
                        //}
                        k = k + 1;
                    }
                    Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + dsSubmit.Tables[0].Rows.Count + "'    />");
                    Response.Write("</td></tr>");
                }

                Response.Write("</table >");
                Response.End();
            }
            else // For Actual Attendance
            {
                Response.Write("<table width=650 border=1 style='font-size:11px' >");
                for (int i = 0; i < dsSubmit.Tables[0].Rows.Count; i++)
                {
                    if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Duplicate")
                    {
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString()) + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblAsmtCode_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["AsmtCode"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:14px' id='lblPostDesc_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["PostDesc"] + "</div>");
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
                        Response.Write("<input type='checkbox' checked style='display:none;' id='chk" + d + "' />");
                        Response.Write("<input type='hidden' id='HFPatternPosition" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["PatternPosition"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFRowNumber" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["RowNumber"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblDupSchRosterAutoID" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblColIndex_dup" + d + "' value='" + (i + 1) + "'    />");
                        Response.Write("<input type='hidden' id='HFOT" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["OT"].ToString() + "'    />");
                        Response.Write("<div style='width:50px' id='lblMessage" + k + "' >" + "Insert" + "</div>");
                        Response.Write("</td><td>");
                        d = d + 1;
                    }
                    else if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString().ToLower() == "Insert".ToLower())
                    {
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
                        Response.Write("<div style='width:50px' id='lblMessage" + k + "' >" + "Insert" + "</div>");
                        Response.Write("<input type='hidden' id='HFOT" + k + "' value='" + dsSubmit.Tables[0].Rows[i]["OT"].ToString() + "'    />");
                        Response.Write("</td><td>");
                        //if (HFStatus.Value != "Duplicate")
                        //{
                        //    HFStatus.Value = "Insert";
                        //}
                        k = k + 1;

                        // Added to Show Exceptions in Scheduling Screen
                        //if (dtExceptionLog != null && dtExceptionLog.Rows.Count > 0)
                        //{
                        //    if (dsSubmit.Tables[1].Rows.Count > 0)
                        //    {
                        //        if (HFStatus.Value == "Insert" && flag == 0)
                        //        {
                        //            flag = 1;
                        //            string currentRowMessageID = string.Empty;
                        //            string nextRowMessageID = string.Empty;
                        //            for (int m = 0; m < dtExceptionLog.Rows.Count; m++)
                        //            {
                        //                try
                        //                {
                        //                    strExceptionMessage = string.Empty;
                        //                    if (dtExceptionLog.Rows[m]["MessageID"].ToString() == dtExceptionLog.Rows[m + 1]["MessageID"].ToString())
                        //                    {
                        //                        currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[m]["MessageID"].ToString()));
                        //                        nextRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[m + 1]["MessageID"].ToString()));
                        //                        strExceptionMessage = strExceptionMessage + currentRowMessageID + "," + nextRowMessageID;
                        //                        m = m + 1;
                        //                    }
                        //                    else
                        //                    {
                        //                        currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[m]["MessageID"].ToString())) + ",";
                        //                        strExceptionMessage = strExceptionMessage + currentRowMessageID;
                        //                    }
                        //                }
                        //                catch (Exception ex)
                        //                {
                        //                    currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[m]["MessageID"].ToString())) + ",";
                        //                    strExceptionMessage = strExceptionMessage + currentRowMessageID;
                        //                }

                        //                //strExceptionLog = strExceptionLog + "\n" + (k + 1) + " . " + strExceptionMessage + "\n";
                        //                strExceptionLog = strExceptionLog + strExceptionMessage;
                        //            }
                        //            Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        //            Response.Write("<div style='width:110px' id='lblMsgID" + 119 + "' >" + "119" + "</div>"); // 119 is HardCoded so that it shows confirm box of exceptions
                        //            Response.Write("</td><td>");
                        //            Response.Write("<div style='width:110px' id='lblMsgExceptionEmployeeNumber" + 119 + "' >" + dtExceptionLog.Rows[0]["EmployeeNumber"].ToString() + "</div>");// 119 is HardCoded so that it shows confirm box of exceptions
                        //            Response.Write("</td><td>");
                        //            Response.Write("<div style='width:110px' id='lblMsgExceptionMaxToDate" + 119 + "' >" + DateTime.Parse(dtExceptionLog.Rows[0]["MaxToDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");// 119 is HardCoded so that it shows confirm box of exceptions
                        //            Response.Write("</td><td>");
                        //            Response.Write("<div style='width:110px' id='lblMsgException" + 119 + "' >" + strExceptionLog + "</div>");// 119 is HardCoded so that it shows confirm box of exceptions
                        //            Response.Write("</td><td>");
                        //        }
                        //    }
                        //}
                    }


                    else
                    {
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + k + "' >" + "Alert" + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblMessage" + k + "' >" + ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString()) + "</div>");
                        Response.Write("</td><td>");
                        k = k + 1;
                    }
                    Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + dsSubmit.Tables[0].Rows.Count + "'    />");
                    Response.Write("</td></tr>");
                }

                Response.Write("</table >");
                Response.End();
            }
        }
        else
        {
            Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + 0 + "'    />"); // Value is 0 so that it doest give error on return
            Response.Write("error!");
            Response.End();
        }


    }
}
