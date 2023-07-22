// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="InsertSchedulePatternWiseAjaxNew.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Data;
using System.Threading;
using System.Globalization;

/// <summary>
/// Class Transactions_InsertSchedulePatternWiseAjaxNew.
/// </summary>
public partial class Transactions_InsertSchedulePatternWiseAjaxNew : BasePage
{

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string strAsmtCode = Request.QueryString["AsmtCode"];
        string strFromDate = Request.QueryString["FromDate"];
        string strToDate = Request.QueryString["ToDate"];
        bool strDefaultSite = bool.Parse(Request.QueryString["DefaultSite"].ToString());
        string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
        string strDesignationCode = Request.QueryString["DesignationCode"];
        string strShiftPatternCode = Request.QueryString["ShiftPatternCode"];
        string strAttendanceType = Request.QueryString["AttendanceType"];
        
        int intPatternPosition;
        if (Request.QueryString["PatternPosition"].ToString() != "")
        {
            intPatternPosition = int.Parse(Request.QueryString["PatternPosition"]);
        }
        else
        {
            intPatternPosition = 1;
        }
        string strSoRank = Request.QueryString["SoRank"];
        string strPost = Request.QueryString["Post"];
        int RowNumber = int.Parse(Request.QueryString["RowNumber"]);
        int d = 0;
        BL.Roster objRost = new BL.Roster();
        DataSet dsSubmit = new DataSet();
        DataTable dtExceptionLog = new DataTable();
        string strExceptionLog = string.Empty;
        string strExceptionMessage = string.Empty;
        int flag = 0;
        string weekNo = Request.QueryString["WeekNo"];
        if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
        {
           // dsSubmit = objRost.EmployeeScheduleInsert(strAsmtCode, strFromDate, strToDate, strDefaultSite, strEmployeeNumber, strDesignationCode, strShiftPatternCode, intPatternPosition, strSoRank, BaseLocationAutoID, BaseUserID, RowNumber, strPost, HttpContext.Current.Session.SessionID.ToString());
            dsSubmit = objRost.EmployeeScheduleInsert(strAsmtCode, strFromDate, strToDate, strDefaultSite, strEmployeeNumber, strDesignationCode, strShiftPatternCode, intPatternPosition, strSoRank, BaseLocationAutoID, BaseUserID, RowNumber, strPost, HttpContext.Current.Session.SessionID.ToString(),weekNo);
        }
        else
        {
            //strToDate = DateTime.Parse(strFromDate).AddDays(double.Parse("6")).ToString();
           // dsSubmit = objRost.blTran_RosterEmpWise_InsertPatternWise(strAsmtCode, strFromDate, strToDate, strEmployeeNumber, strDesignationCode, strShiftPatternCode, intPatternPosition, BaseLocationAutoID, BaseUserID, RowNumber, strPost);
        }
        if (dsSubmit != null && dsSubmit.Tables.Count > 0 && dsSubmit.Tables[0].Rows.Count > 0)
        {
            if (dsSubmit.Tables[0].Rows[0]["MessageString"].ToString() == "Authorized")
            { Response.Write("Authorized"); Response.End(); }
            if (dsSubmit.Tables.Count > 1)
            {
                dtExceptionLog = dsSubmit.Tables[1].Copy();
            }
            string messageDesc = string.Empty;
            Response.Write("<table width=750 border=1 style='font-size:11px' >");
            for (int i = 0; i < dsSubmit.Tables[0].Rows.Count; i++)
            {
                if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
                {
                    if (dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() == "5")
                    {
                        HFStatus.Value = "Duplicate";
                        messageDesc = ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString().Trim());
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgID" + d + "' >" + dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + messageDesc + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblDupAsmtCode" + d + "' >" + dsSubmit.Tables[0].Rows[i]["AsmtCode"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblPostDescdup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["PostDesc"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:14px' id='lblDupShiftCode" + d + "' >" + dsSubmit.Tables[0].Rows[i]["ShiftCode"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:80px' id='lblDupDutyDate" + d + "' >" + DateTime.Parse(dsSubmit.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:60px' id='lblDupEmpNo" + d + "' >" + strEmployeeNumber + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblDupTimeFrom" + d + "' >" + dsSubmit.Tables[0].Rows[i]["TimeFrom"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblDupTimeTo" + d + "' >" + dsSubmit.Tables[0].Rows[i]["TimeTo"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Duplicate")
                        {
                            Response.Write("<input type='checkbox' id='chk" + d + "' />");

                        }
                        else
                        {
                            if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Converted")
                            {
                                Response.Write(Resources.Resource.Converted);
                            }
                        }
                        Response.Write("<input type='hidden' id='HFTimeFromToOverwrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["TimeFromToOverwrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFToTimeToOverwrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["ToTimeToOverwrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFAsmtCodeToOverwrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["AsmtCodeToOverwrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFRoleCodeToOverWrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["RoleCodeToOverWrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFDutyTypeCodeToOverWrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["DutyTypeCodeToOverWrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFPDlineNoToOverwrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["PDlineNoToOverwrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFDutyDateToOverWrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["DutyDateToOverWrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFPatternPosition" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["PatternPosition"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFRowNumber" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["RowNumber"].ToString() + "'    />");


                        Response.Write("<input type='hidden' id='HFDupSchRosterAutoID" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblColIndex_dup" + d + "' value='" + (i + 1) + "'    />");
                        d = d + 1;
                    }

                    if (dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() == "1")
                    {
                        if (HFStatus.Value != "Duplicate")
                        {
                            HFStatus.Value = "Insert";
                        }
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgID" + d + "' >" + dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + "Insert" + "</div>");
                        Response.Write("</td><td>");
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
                                for (int k = 0; k < dtExceptionLog.Rows.Count; k++)
                                {
                                    try
                                    {
                                        strExceptionMessage = string.Empty;
                                        if (dtExceptionLog.Rows[k]["MessageID"].ToString() == dtExceptionLog.Rows[k + 1]["MessageID"].ToString())
                                        {
                                            currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[k]["MessageID"].ToString()));
                                            nextRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[k + 1]["MessageID"].ToString()));
                                            strExceptionMessage = strExceptionMessage + currentRowMessageID + "," + nextRowMessageID;
                                            k = k + 1;
                                        }
                                        else
                                        {
                                            currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[k]["MessageID"].ToString())) + ",";
                                            strExceptionMessage = strExceptionMessage + currentRowMessageID;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        currentRowMessageID = MessageString_Get(int.Parse(dtExceptionLog.Rows[k]["MessageID"].ToString())) + ",";
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

                }
                else // ROTA 
                {
                    if (dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() == "5")
                    {
                        messageDesc = ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString()).Trim();
                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgID" + d + "' >" + dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + messageDesc + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblDupAsmtCode" + d + "' >" + dsSubmit.Tables[0].Rows[i]["AsmtCode"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblPostDesc_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["PostDesc"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:14px' id='lblDupShiftCode" + d + "' >" + dsSubmit.Tables[0].Rows[i]["ShiftCode"] + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:80px' id='lblDupDutyDate" + d + "' >" + DateTime.Parse(dsSubmit.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:60px' id='lblDupEmpNo" + d + "' >" + strEmployeeNumber + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblDupTimeFrom" + d + "' >" + dsSubmit.Tables[0].Rows[i]["TimeFrom"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:50px' id='lblDupTimeTo" + d + "' >" + dsSubmit.Tables[0].Rows[i]["TimeTo"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Duplicate")
                        {
                            Response.Write("<input type='checkbox' id='chk" + d + "' />");

                        }
                        else
                        {
                            if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Converted")
                            {
                                Response.Write(Resources.Resource.Converted);
                            }
                        }
                        Response.Write("<input type='hidden' id='HFTimeFromToOverwrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["TimeFromToOverwrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFToTimeToOverwrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["ToTimeToOverwrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFAsmtCodeToOverwrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["AsmtCodeToOverwrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFRoleCodeToOverWrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["RoleCodeToOverWrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFDutyTypeCodeToOverWrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["DutyTypeCodeToOverWrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFPDlineNoToOverwrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["PDlineNoToOverwrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFDutyDateToOverWrite" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["DutyDateToOverWrite"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFPatternPosition" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["PatternPosition"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='HFRowNumber" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["RowNumber"].ToString() + "'    />");

                        Response.Write("<input type='hidden' id='HFDupSchRosterAutoID" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblColIndex_dup" + d + "' value='" + (i + 1) + "'    />");
                        d = d + 1;
                    }

                    if (dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() == "1")
                    {

                        Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                        Response.Write("<div style='width:110px' id='lblMsgID" + d + "' >" + dsSubmit.Tables[0].Rows[i]["MessageID"].ToString() + "</div>");
                        Response.Write("</td><td>");
                        Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + "Insert" + "</div>");
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



        ////}
        ////else //WHEN EMployee Is Scheduled and an update is required
        ////{

        ////}
        //// }
    }

    #region AJAX Methods
    /// <summary>
    /// Resourcevalues the specified string key.
    /// </summary>
    /// <param name="strKey">The string key.</param>
    /// <param name="name">The name.</param>
    /// <param name="locale">The locale.</param>
    /// <returns>System.String.</returns>
    [Ajax.AjaxMethod]
    public string Resourcevalue(string strKey, string name, string locale)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
        return ResourceValueOfKey_Get(strKey.Trim());
    }

    #endregion
}

