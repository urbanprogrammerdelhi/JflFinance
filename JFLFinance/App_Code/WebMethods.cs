// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-14-2014
// ***********************************************************************
// <copyright file="WebMethods.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using BL;
using Resources;
using System.Collections.Generic;

/// <summary>
///     Summary description for WebMethods
/// </summary>
[WebService(Namespace = "MyWeb")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[ScriptService]
public class WebMethods : WebService
{
    private readonly RosterComponent objRost;
    private DataSet ds;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WebMethods" /> class.
    /// </summary>
    public WebMethods()
    {
        objRost = new RosterComponent();
        ds = new DataSet();
    }

    /// <summary>
    ///     Inserts the data.
    /// </summary>
    /// <param name="comnnectionString">The comnnection string.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="shiftPatternCode">The shift pattern code.</param>
    /// <param name="patternPositioon">The pattern positioon.</param>
    /// <param name="rowNumber">The row number.</param>
    /// <param name="post">The post.</param>
    /// <param name="attendanceType">Type of the attendance.</param>
    /// <param name="weekNo">The week no.</param>
    /// <param name="sessionId">The session id.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <param name="clientName">Name of the client.</param>
    /// <param name="assignmentName">Name of the assignment.</param>
    /// <param name="postName">Name of the post.</param>
    /// <param name="areaId"></param>
    /// <param name="areaInchargeNumber"></param>
    /// <param name="isAreaIncharge"></param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string InsertData(string comnnectionString, string locationAutoId, string clientCode, string asmtId,
        string fromDate, string toDate, string employeeNumber, string shiftPatternCode, string patternPositioon,
        string rowNumber, string post, string attendanceType, string weekNo, string sessionId, string modifiedBy,
        string clientName, string assignmentName, string postName, string areaId, string areaInchargeNumber,
        string isAreaIncharge)
    {
        ds = objRost.InsertData(comnnectionString, locationAutoId, clientCode, asmtId, fromDate, toDate, employeeNumber,
            shiftPatternCode, patternPositioon, rowNumber, post, attendanceType, weekNo, sessionId, modifiedBy,
            clientName, assignmentName, postName, areaId, areaInchargeNumber, isAreaIncharge);
        var returnValue = "";
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var view = new DataView(ds.Tables[0]);
            view.RowFilter = "[MessageID]='" + 5 + "'"; //// messageId '100' is for duplicate records
            var duplicateRecord = view.ToTable();
            returnValue = duplicateRecord.Rows.Count > 0
                ? GenerateHtmlScriptforOverwriteMessage(ds.Tables[0], employeeNumber)
                : GenerateHtmlScriptforExceptionMessage(ds, employeeNumber);
        }

        return returnValue;
    }

    /// <summary>
    ///     Overwrites the schedule.
    /// </summary>
    /// <param name="comnnectionString">The comnnection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="weekNumber">The week number.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <param name="scheduleToOverwriteXml">The schedule to overwrite XML.</param>
    /// <param name="attendanceType">Type of the attendance.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string OverwriteSchedule(string comnnectionString, string clientCode, string asmtId, string postCode,
        string employeeNumber, int weekNumber, string locationAutoId, string modifiedBy, string scheduleToOverwriteXml,
        string attendanceType)
    {
        var returnValue = string.Empty;
        ds = objRost.OverwriteSchedule(comnnectionString, clientCode, asmtId, postCode, employeeNumber, weekNumber,
            locationAutoId, modifiedBy, scheduleToOverwriteXml, attendanceType);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            returnValue = ds.Tables[0].Rows[0]["MessageId"].ToString().Equals("1")
                ? ""
                : GenerateHtmlScriptforOverwriteMessage(ds.Tables[0], employeeNumber);
        }
        return returnValue;
    }

    /// <summary>
    ///     Generates the HTML scriptfor exception message.
    /// </summary>
    /// <param name="myDataset">My dataset.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <returns>System.String.</returns>
    public string GenerateHtmlScriptforExceptionMessage(DataSet myDataset, string employeeNumber)
    {
        var dtExceptionLog = new DataTable();
        var strExceptionLog = string.Empty;
        var strExceptionMessage = string.Empty;
        var sb = new StringBuilder();
        var flag = 0;
        if (myDataset.Tables.Count > 1)
        {
            dtExceptionLog = myDataset.Tables[1].Copy();
        }
        sb.Append("<table width=650 border=1 style='font-size:11px' >");
        for (var i = 0; i < myDataset.Tables[0].Rows.Count; i++)
        {
            if (myDataset.Tables[0].Rows[0]["MessageID"].ToString() == "1")
            {
                sb.Append("<tr id='tr" + i + "'  style='color: black; font: Helvetica; display: block;' ><td>");
                sb.Append("<div style='width:110px; display: none'  id='lblMsgID" + i + "' >" +
                          myDataset.Tables[0].Rows[i]["MessageID"] + "</div>");
                sb.Append("</td><td>");
                sb.Append("<div style='width:110px; '  id='lblMsgShiftDuplicate" + i + "' >" +
                          myDataset.Tables[0].Rows[i]["MessageString"] + "</div>");
                sb.Append("</td><td>");
                try
                {
                    sb.Append("<div style='width:110px' id='lblClientCode" + i + "' >" +
                              myDataset.Tables[0].Rows[i]["ClientCode"] + "</div>");
                    sb.Append("</td><td>");
                    sb.Append("<div style='width:110px' id='lblAssignment" + i + "' >" +
                              myDataset.Tables[0].Rows[i]["AsmtID"] + "</div>");
                    sb.Append("</td><td>");
                    sb.Append("<div style='width:110px' id='lblPostDesc" + i + "' >" +
                              myDataset.Tables[0].Rows[i]["Post"] + "</div>");
                    sb.Append("</td><td>");

                    sb.Append("<div style='width:80px' id='lblDutyDate" + i + "' >" +
                              DateTime.Parse(myDataset.Tables[0].Rows[i]["DuplicateDutyDate"].ToString())
                                  .ToString("dd-MMM-yyyy") + "</div>");
                    sb.Append("</td><td>");


                    sb.Append("<div style='width:10px' id='lblShiftCode" + i + "' >" +
                              myDataset.Tables[0].Rows[i]["DuplicateShiftCode"] + "</div>");
                    sb.Append("</td><td>");

                    sb.Append("<div style='width:30px' id='lblTimeFrom" + i + "' >" +
                              DateTime.Parse(myDataset.Tables[0].Rows[i]["DuplicateTimeFrom"].ToString())
                                  .ToString("HH:mm") + "</div>");
                    sb.Append("</td><td>");
                    sb.Append("<div style='width:30px' id='lblTimeTo" + i + "' >" +
                              DateTime.Parse(myDataset.Tables[0].Rows[i]["DuplicateTimeTo"].ToString())
                                  .ToString("HH:mm") + "</div>");
                    sb.Append("</td><td>");


                    sb.Append("<input type='hidden' id='HFTimeFromToOverwrite" + i + "' value='" +
                              DateTime.Parse(myDataset.Tables[0].Rows[i]["TimeFrom"].ToString()).ToString("HH:mm") +
                              "'    />");
                    sb.Append("<input type='hidden' id='HFToTimeToOverwrite" + i + "' value='" +
                              DateTime.Parse(myDataset.Tables[0].Rows[i]["TimeTo"].ToString()).ToString("HH:mm") +
                              "'    />");
                    sb.Append("<input type='hidden' id='HFShiftCodeToOverWrite" + i + "' value='" +
                              myDataset.Tables[0].Rows[i]["ShiftCode"] + "'    />");
                    sb.Append("<input type='hidden' id='HFDutyDateToOverWrite" + i + "' value='" +
                              DateTime.Parse(myDataset.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") +
                              "'    />");
                    sb.Append("<input type='hidden' id='HFRowNumberToOverWrite" + i + "' value='" +
                              myDataset.Tables[0].Rows[i]["RowNumber"] + "'    />");
                    sb.Append("<input type='hidden' id='HFDuplicateSchRosterAutoIDToOverWrite" + i + "' value='" +
                              myDataset.Tables[0].Rows[i]["SchRosterAutoIDToOverwrite"] + "'    />");
                    sb.Append("<input type='hidden' id='HFDuplicateSchRosterAutoID" + i + "' value='" +
                              myDataset.Tables[0].Rows[i]["SchRosterAutoID"] + "'    />");
                    sb.Append("<input type='hidden' id='HFSch" + i + "' value='" + myDataset.Tables[0].Rows[i]["Sch"] +
                              "'    />");
                    sb.Append("<input type='hidden' id='HFOT" + i + "' value='" + myDataset.Tables[0].Rows[i]["OT"] +
                              "'    />");
                    sb.Append("<input type='hidden' id='lblColIndex_dup" + i + "' value='" + (i + 1) + "'    />");
                    sb.Append("</td></tr>");
                }
                catch (Exception)
                {
                }
            }
            // Added to Show Exceptions in Scheduling Screen
            if (dtExceptionLog != null && dtExceptionLog.Rows.Count > 0)
            {
                if (myDataset.Tables[1].Rows.Count > 0)
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        var currentRowMessageID = string.Empty;
                        var nextRowMessageID = string.Empty;
                        for (var k = 0; k < dtExceptionLog.Rows.Count; k++)
                        {
                            try
                            {
                                strExceptionMessage = string.Empty;
                                if (dtExceptionLog.Rows[k]["MessageID"].ToString() ==
                                    dtExceptionLog.Rows[k + 1]["MessageID"].ToString())
                                {
                                    currentRowMessageID =
                                        MessageString_Get(int.Parse(dtExceptionLog.Rows[k]["MessageID"].ToString()));
                                    nextRowMessageID =
                                        MessageString_Get(int.Parse(dtExceptionLog.Rows[k + 1]["MessageID"].ToString()));
                                    strExceptionMessage = strExceptionMessage + currentRowMessageID + "," +
                                                          nextRowMessageID;
                                    k = k + 1;
                                }
                                else
                                {
                                    currentRowMessageID =
                                        MessageString_Get(int.Parse(dtExceptionLog.Rows[k]["MessageID"].ToString())) +
                                        ",";
                                    strExceptionMessage = strExceptionMessage + currentRowMessageID;
                                }
                            }
                            catch (Exception ex)
                            {
                                currentRowMessageID =
                                    MessageString_Get(int.Parse(dtExceptionLog.Rows[k]["MessageID"].ToString())) + ",";
                                strExceptionMessage = strExceptionMessage + currentRowMessageID;
                            }

                            strExceptionLog = strExceptionLog + strExceptionMessage;
                        }
                        sb.Append("<tr id='tr" + i + "' style='display: block'><td>");
                        sb.Append("<div style='width:110px' id='lblMsgID" + 119 + "' >" + "119" + "</div>");
                            // 119 is HardCoded so that it shows confirm box of exceptions
                        sb.Append("</td><td>");
                        sb.Append("<div style='width:110px' id='lblMsgExceptionEmployeeNumber" + 119 + "' >" +
                                  employeeNumber + "</div>");
                            // 119 is HardCoded so that it shows confirm box of exceptions
                        sb.Append("</td><td>");
                        sb.Append("<div style='width:110px' id='lblMsgExceptionMaxToDate" + 119 + "' >" +
                                  DateTime.Parse(dtExceptionLog.Rows[0]["MaxToDate"].ToString()).ToString("dd-MMM-yyyy") +
                                  "</div>"); // 119 is HardCoded so that it shows confirm box of exceptions
                        sb.Append("</td><td>");
                        sb.Append("<div style='width:110px' id='lblMsgException" + 119 + "' >" + strExceptionLog +
                                  "</div>"); // 119 is HardCoded so that it shows confirm box of exceptions
                        sb.Append("</td><td>");
                    }
                }
            }
        }
        sb.Append("<input type='hidden' id='totalDuplicatedCount" + 0 + "' value='" + myDataset.Tables[0].Rows.Count +
                  "'    />");
        sb.Append("<input type='hidden' id='HFIsDuplicateExists" + 0 + "' value='" + "0" + "'    />");
        sb.Append("</td></tr>");
        sb.Append("</table >");
        return sb.ToString();
    }

    /// <summary>
    ///     Generates the HTML scriptfor overwrite message.
    /// </summary>
    /// <param name="myTable">My table.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <returns>System.String.</returns>
    public string GenerateHtmlScriptforOverwriteMessage(DataTable myTable, string employeeNumber)
    {
        var overwriteHtml = new StringBuilder();
        var duplicateExists = 0;

        if (myTable != null && myTable.Rows.Count > 0)
        {
            overwriteHtml.Append("<table width='600px' border=0 style='font-size:11px' >");
            overwriteHtml.Append("<tr>");
            overwriteHtml.Append("<td></td>");
            overwriteHtml.Append("<td><input type='label'  disabled value='" + ResourceValueOfKey_Get("Message") +
                                 "'></td>");
            overwriteHtml.Append("<td><input type='label' disabled value='" + ResourceValueOfKey_Get("ClientName") +
                                 "'></td>");
            overwriteHtml.Append("<td><input type='label'  disabled value='" + ResourceValueOfKey_Get("Assignment") +
                                 "'></td>");
            overwriteHtml.Append("<td><input type='label' disabled value='" + ResourceValueOfKey_Get("PostDesc") +
                                 "'></td>");
            overwriteHtml.Append("<td><input type='label' disabled value='" + ResourceValueOfKey_Get("DutyDate") +
                                 "'></td>");
            overwriteHtml.Append("<td><input type='label' disabled value='" + ResourceValueOfKey_Get("ShiftCode") +
                                 "'></td>");
            overwriteHtml.Append("<td><input type='label' disabled value='" + ResourceValueOfKey_Get("TimeFrom") +
                                 "'></td>");
            overwriteHtml.Append("<td><input type='label' disabled value='" + ResourceValueOfKey_Get("TimeTo") +
                                 "'></td>");
            overwriteHtml.Append("</tr>");

            var totalRowsCount = myTable.Rows.Count;
            var currentRowCount = -1;
            for (var i = 0; i <= myTable.Rows.Count; i++)
            {
                currentRowCount = currentRowCount + 1;
                var tablemessage = new DataTable();
                var tableCombinedmessage = new DataTable();
                var dvfilteredMessage = new DataView(myTable);
                var currentDutyDate = myTable.Rows[0]["DutyDate"].ToString();
                dvfilteredMessage.RowFilter = "[DutyDate]='" + currentDutyDate + "'";
                tablemessage = dvfilteredMessage.ToTable();
                tablemessage.Columns.Add("CombinedMessage", typeof (String));

                myTable.Rows.OfType<DataRow>()
                    .Where(r => r.Field<String>("DutyDate") == myTable.Rows[0]["DutyDate"].ToString())
                    .ToList()
                    .ForEach(r => r.Delete());
                myTable.AcceptChanges();
                i = 0;

                if (tablemessage.Rows.Count > 1)
                {
                    var dvMessage = new DataView(tablemessage) {RowFilter = "[MessageString]='" + "Duplicate" + "'"};
                    tableCombinedmessage = dvMessage.ToTable();
                    if (tableCombinedmessage.Rows.Count > 0)
                    {
                        for (var x = 0; x < tablemessage.Rows.Count; x++)
                        {
                            tableCombinedmessage.Rows[0]["CombinedMessage"] =
                                tableCombinedmessage.Rows[0]["CombinedMessage"] + "," +
                                ResourceValueOfKey_Get(tablemessage.Rows[x]["MessageString"].ToString().Trim());
                        }
                        overwriteHtml = CreateTableForMessage(tableCombinedmessage, overwriteHtml, duplicateExists,
                            currentRowCount);
                    }
                    else
                    {
                        dvMessage = new DataView(tablemessage)
                        {
                            RowFilter = "[MessageString]='" + "WeekOffAndDutyConflict" + "'"
                        };
                        tableCombinedmessage = dvMessage.ToTable();
                        if (tableCombinedmessage.Rows.Count > 0)
                        {
                            for (var x = 0; x < tablemessage.Rows.Count; x++)
                            {
                                tableCombinedmessage.Rows[0]["CombinedMessage"] =
                                    tableCombinedmessage.Rows[0]["CombinedMessage"] + "," +
                                    ResourceValueOfKey_Get(tablemessage.Rows[x]["MessageString"].ToString().Trim());
                            }
                            overwriteHtml = CreateTableForMessage(tableCombinedmessage, overwriteHtml, duplicateExists,
                                currentRowCount);
                        }
                        else
                        {
                            tableCombinedmessage = tablemessage.Copy();
                            for (var x = 0; x < tablemessage.Rows.Count; x++)
                            {
                                tableCombinedmessage.Rows[0]["CombinedMessage"] =
                                    tableCombinedmessage.Rows[0]["CombinedMessage"] + "," +
                                    ResourceValueOfKey_Get(tablemessage.Rows[x]["MessageString"].ToString().Trim());
                                if (x > 0)
                                {
                                    tableCombinedmessage.Rows.RemoveAt(x);
                                }
                            }
                            overwriteHtml = CreateTableForMessage(tableCombinedmessage, overwriteHtml, duplicateExists,
                                currentRowCount);
                        }
                    }
                }
                else
                {
                    tablemessage.Rows[0]["CombinedMessage"] =
                        ResourceValueOfKey_Get(tablemessage.Rows[0]["MessageString"].ToString().Trim());
                    overwriteHtml = CreateTableForMessage(tablemessage, overwriteHtml, duplicateExists, currentRowCount);
                }
            }

            overwriteHtml.Append("</table >");
            overwriteHtml.Append("<input type='hidden' id='totalDuplicatedCount" + 0 + "' value='" + totalRowsCount +
                                 "'    />");
            return overwriteHtml.ToString();
        }
        overwriteHtml.Append("<input type='hidden' id='totalDuplicatedCount" + 0 + "' value='" + 0 + "'    />");
        overwriteHtml.Append("error!");
        return overwriteHtml.ToString();
    }

    /// <summary>
    ///     To Format all exception message
    /// </summary>
    /// <param name="myTable">My table.</param>
    /// <param name="overwriteHtml">The overwrite HTML.</param>
    /// <param name="duplicateExists">The duplicate exists.</param>
    /// <param name="currentRowCount">The current row count.</param>
    /// <returns>StringBuilder.</returns>
    public StringBuilder CreateTableForMessage(DataTable myTable, StringBuilder overwriteHtml, int duplicateExists,
        int currentRowCount)
    {
        for (var i = 0; i < myTable.Rows.Count; i++)
        {
            var newMessageString = ResourceValueOfKey_Get(myTable.Rows[i]["MessageString"].ToString().Trim());
            var messageString = newMessageString.Contains("IDExpired")
                ? newMessageString.Replace("IDExpired", ResourceValueOfKey_Get("IDExpired"))
                : myTable.Rows[i]["CombinedMessage"].ToString().Trim();
            var colorCode = string.Empty;
            if (myTable.Rows[i]["MessageString"].ToString().Trim().ToLower() == "Duplicate".Trim().ToLower())
            {
                colorCode = " background-color:red;";
            }
            else if (myTable.Rows[i]["MessageString"].ToString().Trim().ToLower() == "Converted".Trim().ToLower())
            {
                colorCode = " background-color:lightgreen;";
            }
            else
            {
                colorCode = " background-color:aqua;";
            }
            overwriteHtml.Append("<tr id='tr" + currentRowCount +
                                 "'  style='color: black; font: Helvetica; " + colorCode + "' ><td>");
            overwriteHtml.Append("<div style='display: none'  id='lblMsgID" + currentRowCount + "' >" +
                                 myTable.Rows[i]["MessageID"] + "</div>");
            overwriteHtml.Append("</td><td>");
            overwriteHtml.Append("<div  id='lblMsgShiftDuplicate" + currentRowCount + "' >" + messageString + "</div>");
            overwriteHtml.Append("</td><td>");
            overwriteHtml.Append("<div id='lblClientCode" + currentRowCount + "' >" + myTable.Rows[i]["ClientCode"] +
                                 "</div>");
            overwriteHtml.Append("</td><td>");
            overwriteHtml.Append("<div id='lblAssignment" + currentRowCount + "' >" + myTable.Rows[i]["AsmtID"] +
                                 "</div>");
            overwriteHtml.Append("</td><td>");
            overwriteHtml.Append("<div id='lblPostDesc" + currentRowCount + "' >" + myTable.Rows[i]["Post"] + "</div>");
            overwriteHtml.Append("</td><td>");
            try
            {
                overwriteHtml.Append("<div id='lblDutyDate" + currentRowCount + "' >" +
                                     DateTime.Parse(myTable.Rows[i]["DuplicateDutyDate"].ToString())
                                         .ToString("dd-MMM-yyyy") + "</div>");
                overwriteHtml.Append("</td><td>");
            }
            catch (Exception)
            {
            }
            overwriteHtml.Append("<div id='lblShiftCode" + currentRowCount + "' >" +
                                 myTable.Rows[i]["DuplicateShiftCode"] + "</div>");
            overwriteHtml.Append("</td><td>");
            if (!string.IsNullOrEmpty(myTable.Rows[i]["DuplicateTimeFrom"].ToString()))
            {
                overwriteHtml.Append("<div id='lblTimeFrom" + currentRowCount + "' >" +
                                     DateTime.Parse(myTable.Rows[i]["DuplicateTimeFrom"].ToString()).ToString("HH:mm") +
                                     "</div>");
                overwriteHtml.Append("</td><td>");
            }
            if (!string.IsNullOrEmpty(myTable.Rows[i]["DuplicateTimeTo"].ToString()))
            {
                overwriteHtml.Append("<div id='lblTimeTo" + currentRowCount + "' >" +
                                     DateTime.Parse(myTable.Rows[i]["DuplicateTimeTo"].ToString()).ToString("HH:mm") +
                                     "</div>");
                overwriteHtml.Append("</td><td>");
            }
            if (myTable.Rows[i]["MessageString"].ToString() == "Duplicate" ||
                myTable.Rows[i]["MessageString"].ToString() == "WeekOffAndDutyConflict" ||
                myTable.Rows[i]["MessageString"].ToString() == "not a prefered day" ||
                myTable.Rows[i]["MessageString"].ToString() == "ConflictionWithWeeklyOff" ||
                myTable.Rows[i]["MessageString"].ToString() ==
                "WeeklyRestConflictwithdutySelectandPressoverwritetocontinue")
            {
                if (myTable.Rows[i]["MessageString"].ToString() == "WeekOffAndDutyConflict")
                {
                    overwriteHtml.Append("<input type='checkbox' checked disabled id='chk" + currentRowCount + "' />");
                }
                else
                {
                    overwriteHtml.Append("<input type='checkbox' id='chk" + currentRowCount + "' />");
                }

                if (myTable.Rows[i]["MessageString"].ToString() == "not a prefered day") //
                {
                    overwriteHtml.Append("<input type='hidden' id='HFIsnotapreferedday" + currentRowCount + "' value='" +
                                         "1" + "'  />"); //
                }
                else
                {
                    overwriteHtml.Append("<input type='hidden' id='HFIsnotapreferedday" + currentRowCount + "' value='" +
                                         "0" + "'  />"); //
                }

                overwriteHtml.Append("<input type='hidden' id='HFIsDuplicateExists" + 0 + "' value='" + "1" + "'  />");
                duplicateExists = 1;
            }
            else
            {
                if (duplicateExists.ToString() != "1")
                {
                    overwriteHtml.Append("<input type='hidden' id='HFIsDuplicateExists" + -1 + "' value='" + "0" +
                                         "'    />");
                }

                if (myTable.Rows[i]["MessageString"].ToString() == "Converted")
                {
                    overwriteHtml.Append(Resource.Converted);
                }
            }

            if (!string.IsNullOrEmpty(myTable.Rows[i]["TimeFrom"].ToString()))
            {
                overwriteHtml.Append("<input type='hidden' id='HFTimeFromToOverwrite" + currentRowCount + "' value='" +
                                     DateTime.Parse(myTable.Rows[i]["TimeFrom"].ToString()).ToString("HH:mm") +
                                     "'    />");
                overwriteHtml.Append("<input type='hidden' id='HFToTimeToOverwrite" + currentRowCount + "' value='" +
                                     DateTime.Parse(myTable.Rows[i]["TimeTo"].ToString()).ToString("HH:mm") + "'    />");
            }

            overwriteHtml.Append("<input type='hidden' id='HFShiftCodeToOverWrite" + currentRowCount + "' value='" +
                                 myTable.Rows[i]["ShiftCode"] + "'    />");
            overwriteHtml.Append("<input type='hidden' id='HFDutyDateToOverWrite" + currentRowCount + "' value='" +
                                 DateTime.Parse(myTable.Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "'    />");
            overwriteHtml.Append("<input type='hidden' id='HFRowNumberToOverWrite" + currentRowCount + "' value='" +
                                 myTable.Rows[i]["RowNumber"] + "'    />");
            overwriteHtml.Append("<input type='hidden' id='HFDuplicateSchRosterAutoIDToOverWrite" + currentRowCount +
                                 "' value='" + myTable.Rows[i]["SchRosterAutoIDToOverwrite"] + "'    />");
            overwriteHtml.Append("<input type='hidden' id='HFDuplicateSchRosterAutoID" + currentRowCount + "' value='" +
                                 myTable.Rows[i]["SchRosterAutoID"] + "'    />");
            overwriteHtml.Append("<input type='hidden' id='HFDuplicatePatternPosition" + currentRowCount + "' value='" +
                                 myTable.Rows[i]["PatternPosition"] + "'    />");

            overwriteHtml.Append("<input type='hidden' id='HFSoNo" + currentRowCount + "' value='" +
                                 myTable.Rows[i]["SoNo"] + "'    />");
            overwriteHtml.Append("<input type='hidden' id='HFSoLineNo" + currentRowCount + "' value='" +
                                 myTable.Rows[i]["SoLineNo"] + "'    />");
            overwriteHtml.Append("<input type='hidden' id='HFSoRank" + currentRowCount + "' value='" +
                                 myTable.Rows[i]["SoRank"] + "'    />");
            overwriteHtml.Append("<input type='hidden' id='HFPostAutoID" + currentRowCount + "' value='" +
                                 myTable.Rows[i]["PostAutoID"] + "'    />");


            try
            {
                overwriteHtml.Append("<input type='hidden' id='HFEmployeeNumberToOverWrite" + currentRowCount +
                                     "' value='" + myTable.Rows[i]["EmployeeNumber"] + "'    />");
                overwriteHtml.Append("<input type='hidden' id='HFOT" + currentRowCount + "' value='" +
                                     myTable.Rows[i]["OT"] + "'    />");
            }
            catch (Exception)
            {
            }
            overwriteHtml.Append("<input type='hidden' id='lblColIndex_dup" + currentRowCount + "' value='" + (i + 1) +
                                 "'    />");
            overwriteHtml.Append("</td></tr>");
        }
        return overwriteHtml;
    }

    /// <summary>
    ///     Inserts the data of date.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="dutyDate">The duty date.</param>
    /// <param name="shiftCode">The shift code.</param>
    /// <param name="weekNo">The week no.</param>
    /// <param name="shiftPatternCode">The shift pattern code.</param>
    /// <param name="patternPosition">The pattern position.</param>
    /// <param name="timeFrom">The time from.</param>
    /// <param name="timeTo">The time to.</param>
    /// <param name="scheduleRosterAutoId">The schedule roster auto id.</param>
    /// <param name="rowNumber">The row number.</param>
    /// <param name="screenType">Type of the screen.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="currentSessionId">The current session id.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <param name="clientName">Name of the client.</param>
    /// <param name="assignmentName">Name of the assignment.</param>
    /// <param name="postName">Name of the post.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string InsertDataOfDate(string connectionString, string clientCode, string asmtId, string postCode,
        string employeeNumber, string dutyDate, string shiftCode, string weekNo, string shiftPatternCode,
        string patternPosition, string timeFrom, string timeTo, string scheduleRosterAutoId, string rowNumber,
        string screenType, string fromDate, string toDate, string currentSessionId, string locationAutoId,
        string modifiedBy, string clientName, string assignmentName, string postName)
    {
        ds = objRost.InsertDataOfDate(connectionString, clientCode, asmtId, postCode, employeeNumber, dutyDate,
            shiftCode, weekNo, shiftPatternCode, patternPosition, timeFrom, timeTo, scheduleRosterAutoId, rowNumber,
            screenType, fromDate, toDate, currentSessionId, locationAutoId, modifiedBy, clientName, assignmentName,
            postName);
        var returnValue = string.Empty;

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var duplicateRecord = new DataTable();
            var view = new DataView(ds.Tables[0]);
            view.RowFilter = "[MessageID]='" + 5 + "'";
            duplicateRecord = view.ToTable();

            returnValue = duplicateRecord.Rows.Count > 0
                ? GenerateHtmlScriptforOverwriteMessage(ds.Tables[0], employeeNumber)
                : GenerateHtmlScriptforExceptionMessage(ds, employeeNumber);
        }
        return returnValue;
    }

    /// <summary>
    ///     To Get Employee Count Client Wise and PostWise
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="strCompanyCode">The STR company code.</param>
    /// <param name="strHrlocationCode">The STR hrlocation code.</param>
    /// <param name="strLocationCode">The STR location code.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strPostCode">The STR post code.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="clientCode">The client code.</param>
    /// <returns>System.String.</returns>
    /// GetEmployeeCountClientAndPostWise
    [WebMethod]
    public string GetEmployeeCountClientWiseAndpostWise(string strComnnectionString, string strCompanyCode,
        string strHrlocationCode, string strLocationCode, string strAttendanceType, string strPostCode,
        string strFromDate, string strToDate, string strAsmtCode, string clientCode)
    {
        return objRost.GetEmployeeCountClientWiseAndpostWise(strComnnectionString, strCompanyCode, strHrlocationCode,
            strLocationCode, strAttendanceType, strPostCode, strFromDate, strToDate, strAsmtCode, clientCode);
    }

    /// <summary>
    ///     To Get Employee Count Client Wise and PostWise
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="strCompanyCode">The STR company code.</param>
    /// <param name="strHrlocationCode">The STR hrlocation code.</param>
    /// <param name="strLocationCode">The STR location code.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strPostCode">The STR post code.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="clientCode">The client code.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetEmployeeCountClientAndPostWise(string strComnnectionString, string strCompanyCode,
        string strHrlocationCode, string strLocationCode, string strAttendanceType, string strPostCode,
        string strFromDate, string strToDate, string strAsmtCode, string clientCode)
    {
        return objRost.GetEmployeeCountClientAndPostWise(strComnnectionString, strCompanyCode, strHrlocationCode,
            strLocationCode, strAttendanceType, strPostCode, strFromDate, strToDate, strAsmtCode, clientCode);
    }

    /// <summary>
    ///     Gets the employee detail.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="insertStatus">The insert status.</param>
    /// <param name="areaId">The area id.</param>
    /// <param name="areaInchargeNumber">The area incharge number.</param>
    /// <param name="isAreaIncharge">The is area incharge.</param>
    /// <param name="screenType">Type of the screen.</param>
    /// <param name="companyCode">The company code.</param>
    /// <param name="hrLocationCode">The hr location code.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetEmployeeDetail(string connectionString, string employeeNumber, string clientCode, string asmtId,
        string fromDate, string toDate, string postCode, string insertStatus, string areaId, string areaInchargeNumber,
        string isAreaIncharge, string screenType, string companyCode, string hrLocationCode, string locationAutoId,
        string modifiedBy)
    {
        var returnValue = string.Empty;
        var barredEmployeeStatus = string.Empty;
        ds = objRost.GetEmployeeDetail(connectionString, employeeNumber, clientCode, asmtId, fromDate, toDate, postCode,
            insertStatus, areaId, areaInchargeNumber, isAreaIncharge, screenType, companyCode, hrLocationCode,
            locationAutoId, modifiedBy);
        var sb = new StringBuilder();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (DateTime.Parse(ds.Tables[0].Rows[0]["DateOfJoining"].ToString()) > DateTime.Parse(toDate))
            {
                var dt1 = DateTime.Parse(ds.Tables[0].Rows[0]["DateOfJoining"].ToString());
                sb.Append("1,Invalid," + Resource.EmpJoininDateCannotBeGreaterThanDutyDate + dt1.ToString("dd-MMM-yyyy"));
                returnValue = sb.ToString();
            }
            else if (ds.Tables[0].Rows[0]["DesignationCode"].ToString() == string.Empty)
            {
                var strTotalSkills = string.Empty;
                if (ds.Tables[0].Rows.Count > 1)
                {
                    for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        strTotalSkills = strTotalSkills + ds.Tables[0].Rows[i]["ConstraintDesc"] + '/';
                    }
                }
                else
                {
                    strTotalSkills = strTotalSkills + ds.Tables[0].Rows[0]["ConstraintDesc"] + '/';
                }

                barredEmployeeStatus = "0";
                sb.Append("1,Invalid," + ds.Tables[0].Rows[0]["EmployeeName"] + "," +
                          ds.Tables[0].Rows[0]["RigidityLevel"] + "," + strTotalSkills + "," + barredEmployeeStatus);
                returnValue = sb.ToString();
            }
            else
            {
                var str1 = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                var str2 = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
                var str3 = ds.Tables[0].Rows[0]["WageRate"].ToString();
                var strSkillStatus = ds.Tables[0].Rows[0]["skillStatus"].ToString();
                var strDesignationCode = ds.Tables[0].Rows[0]["DesignationCode"].ToString();
                var strRigidtyLevel = ds.Tables[0].Rows[0]["RigidityLevel"].ToString();
                var strPayrateMismatch = ds.Tables[0].Rows[0]["WageRateStatus"].ToString();
                var optimumProfitabilityMismatch = ds.Tables[0].Rows[0]["OptimumProfitabilityStatus"].ToString();
                var strTotalSkills = string.Empty;
                if (ds.Tables[0].Rows.Count > 1)
                {
                    for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        strTotalSkills = strTotalSkills + ds.Tables[0].Rows[i]["ConstraintDesc"] + '/';
                    }
                }
                else
                {
                    strTotalSkills = strTotalSkills + ds.Tables[0].Rows[0]["ConstraintDesc"] + '/';
                }

                barredEmployeeStatus = ds.Tables[0].Rows[0]["BorrowedEmployeeStatus"].ToString();
                sb.Append("0," + str1 + "," + str2 + "," + str3 + "," + strSkillStatus + "," + strDesignationCode + "," +
                          insertStatus + "," + strRigidtyLevel + "," + strPayrateMismatch + "," + strTotalSkills + "," +
                          barredEmployeeStatus + "," + optimumProfitabilityMismatch);
                returnValue = sb.ToString();
            }
        }

        else
        {
            sb.Append("1,Invalid," + Resource.InvalidEmployee);
            returnValue = sb.ToString();
        }

        return returnValue;
    }

    /// <summary>
    ///     Deletes the schedule.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="scheduleRosterAutoID">The schedule roster auto ID.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="shiftPatternCode">The shift pattern code.</param>
    /// <param name="patternPosition">The pattern position.</param>
    /// <param name="rowNumber">The row number.</param>
    /// <param name="attendanceType">Type of the attendance.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string DeleteSchedule(string strCon, string scheduleRosterAutoID, string employeeNumber, string fromDate,
        string toDate, string clientCode, string asmtId, string postCode, string shiftPatternCode, int patternPosition,
        int rowNumber, string attendanceType)
    {
        ds = objRost.DeleteSchedule(strCon, scheduleRosterAutoID, employeeNumber, fromDate, toDate, clientCode, asmtId,
            postCode, shiftPatternCode, patternPosition, rowNumber, attendanceType);
        var sb = new StringBuilder();
        var combinedString = string.Empty;
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            combinedString = int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) + "," +
                             ResourceValueOfKey_Get(
                                 MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()))) + "," +
                             ds.Tables[0].Rows[0]["SchHrs"];
            sb.Append(combinedString);
        }
        return sb.ToString();
    }

    /// <summary>
    ///     Gets Job Break Down And Role Detail in Scheduling Screen
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="strCompanyCode">The STR company code.</param>
    /// <param name="strHrLocationCode">The STR hr location code.</param>
    /// <param name="strLocationCode">The STR location code.</param>
    /// <param name="strSchRosterAutoId">The STR SCH roster auto id.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strAreaID">The STR area ID.</param>
    /// <param name="strAreaIncharge">The STR area incharge.</param>
    /// <param name="strIsAreaIncharge">The STR is area incharge.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="selectedDate">The selected date.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtid">The asmtid.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetJobBreakDownSummary(string strCon, string strCompanyCode, string strHrLocationCode,
        string strLocationCode, string strSchRosterAutoId, string strAttendanceType, string strAreaID,
        string strAreaIncharge, string strIsAreaIncharge, string strFromDate, string strToDate, string selectedDate,
        string clientCode, string asmtid, string postCode, string employeeNumber)
    {
        return objRost.GetJobBreakDownSummary(strCon, strCompanyCode, strHrLocationCode, strLocationCode,
            strSchRosterAutoId, strAttendanceType, strAreaID, strAreaIncharge, strIsAreaIncharge, strFromDate, strToDate,
            selectedDate, clientCode, asmtid, postCode, employeeNumber);
    }

    /// <summary>
    ///     Gets all clients.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="areaId">The area id.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="isAreaIncharge">The is area incharge.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <returns>Xml Data</returns>
    [WebMethod]
    public string GetAllClients(string strCon, string locationAutoId, string areaId, string clientCode,
        string employeeNumber, string isAreaIncharge, string fromDate, string toDate)
    {
        return objRost.GetAllClients(strCon, locationAutoId, areaId, clientCode, employeeNumber, isAreaIncharge,
            fromDate, toDate);
    }

    /// <summary>
    ///     Gets all assignments.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="isAreaIncharge">The is area incharge.</param>
    /// <param name="areaId">The area id.</param>
    /// <returns>Xml Data</returns>
    [WebMethod]
    public string GetAllAssignments(string strCon, string locationAutoId, string clientCode, string fromDate,
        string toDate, string employeeNumber, string isAreaIncharge, string areaId)
    {
        return objRost.GetAllAssignments(strCon, locationAutoId, clientCode, fromDate, toDate, employeeNumber,
            isAreaIncharge, areaId);
    }

    /// <summary>
    ///     Alls the shifts of asmt.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="intWeekNo">The int week no.</param>
    /// <param name="postCode">The post code.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AllShiftsOfAsmt(string strCon, int locationAutoId, string strAsmtCode, int intWeekNo, string postCode)
    {
        return objRost.AllShiftsOfAsmt(strCon, locationAutoId, strAsmtCode, intWeekNo, postCode);
    }

    /// <summary>
    ///     To  lock unlock status
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="locationAutoId">The location auto ID.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAllLockUnLockStatus(string strCon, string clientCode, string asmtId, string locationAutoId,
        string fromDate, string toDate)
    {
        return objRost.GetAllLockUnLockStatus(strCon, clientCode, asmtId, locationAutoId, fromDate, toDate);
    }

    /// <summary>
    ///     Changes the type of the duty.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="strSchAutoId">The STR SCH auto id.</param>
    /// <param name="strDutyType">Type of the STR duty.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <param name="companyCode">The company code.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string ChangeDutyType(string strCon, string strSchAutoId, string strDutyType, string strAttendanceType,
        string strModifiedBy, string companyCode)
    {
        return objRost.ChangeDutyType(strCon, strSchAutoId, strDutyType, strAttendanceType, strModifiedBy, companyCode);
    }

    /// <summary>
    ///     Applies the week off.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strDutyDate">The STR duty date.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <param name="strShiftPat">The STR shift pat.</param>
    /// <param name="shiftPos">The shift pos.</param>
    /// <param name="strRowNumber">The STR row number.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="schrosterAutoId">The schroster auto id.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string ApplyWeekOff(string strCon, string clientCode, string asmtId, string postCode, int locationAutoId,
        string strEmployeeNumber, string strDutyDate, string strModifiedBy, string strShiftPat, int shiftPos,
        string strRowNumber, string strAttendanceType, string schrosterAutoId)
    {
        return objRost.ApplyWeekOff(strCon, clientCode, asmtId, postCode, locationAutoId, strEmployeeNumber, strDutyDate,
            strModifiedBy, strShiftPat, shiftPos, strRowNumber, strAttendanceType, schrosterAutoId);
    }

    /// <summary>
    ///     Asmts the schedule copy.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="nWeek">The n week.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <param name="pdLineNo">The pd line no.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AsmtScheduleCopy(string strCon, int nWeek, string strAsmtCode, string strFromDate, string strToDate,
        string strAttendanceType, string strModifiedBy, string pdLineNo)
    {
        return objRost.AsmtScheduleCopy(strCon, nWeek, strAsmtCode, strFromDate, strToDate, strAttendanceType,
            strModifiedBy, pdLineNo);
    }

    /// <summary>
    ///     Copy the Schedules.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="nWeek">The n week.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strSchAutoIds">The STR SCH auto ids.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strPatCode">The STR pat code.</param>
    /// <param name="strPos">The STR pos.</param>
    /// <param name="strDefalt">The STR defalt.</param>
    /// <param name="strRowNumber">The STR row number.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string ScheduleCopy(string strCon, int nWeek, string strEmployeeNumber, string strSchAutoIds,
        string strFromDate, string strToDate, string strPatCode, string strPos, string strDefalt, string strRowNumber,
        string strAttendanceType, string strModifiedBy)
    {
        return objRost.ScheduleCopy(strCon, nWeek, strEmployeeNumber, strSchAutoIds, strFromDate, strToDate, strPatCode,
            strPos, strDefalt, strRowNumber, strAttendanceType, strModifiedBy);
    }

    /// <summary>
    ///     Gets all shifts of day.
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="dutyDate">The duty date.</param>
    /// <param name="weekNumber">The week number.</param>
    /// <param name="postCode">The post code.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAllShiftsOfDay(string strComnnectionString, string clientCode, string asmtId,
        string strLocationAutoID, string dutyDate, string weekNumber, string postCode)
    {
        return objRost.GetAllShiftsOfDay(strComnnectionString, clientCode, asmtId, strLocationAutoID, dutyDate,
            weekNumber, postCode);
    }

    /// <summary>
    ///     Gets all post of assignment.
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="AsmtId">The asmt id.</param>
    /// <param name="locationAutoID">The location auto ID.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAllPostOfAssignment(string strComnnectionString, string clientCode, string AsmtId,
        string locationAutoID, string fromDate, string toDate)
    {
        return objRost.GetAllPostOfAssignment(strComnnectionString, clientCode, AsmtId, locationAutoID, fromDate, toDate);
    }

    /// <summary>
    ///     Searches the post ID.
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="strLocationAutoId">The STR location auto ID.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strAreaId">The STR area ID.</param>
    /// <param name="strAreaIncharge">The STR area incharge.</param>
    /// <param name="strIsAreaIncharge">The STR is area incharge.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string SearchPostID(string strComnnectionString, string strLocationAutoId, string strFromDate,
        string strToDate, string strAreaId, string strAreaIncharge, string strIsAreaIncharge)
    {
        return objRost.SearchPostID(strComnnectionString, strLocationAutoId, strFromDate, strToDate, strAreaId,
            strAreaIncharge, strIsAreaIncharge);
    }

    /// <summary>
    ///     Gets the employee schedule.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="intLocationAutoId">The int location auto id.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strAreaId">The STR area ID.</param>
    /// <param name="strAreaIncharge">The STR area incharge.</param>
    /// <param name="strIsAreaIncharge">The STR is area incharge.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetEmployeeSchedule(string strCon, int intLocationAutoId, string strEmployeeNumber, string strFromDate,
        string strToDate, string strAttendanceType, string strAreaId, string strAreaIncharge, string strIsAreaIncharge)
    {
        return objRost.GetEmployeeSchedule(strCon, intLocationAutoId, strEmployeeNumber, strFromDate, strToDate,
            strAttendanceType, strAreaId, strAreaIncharge, strIsAreaIncharge);
    }

    /// <summary>
    ///     Locks the schedule.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string LockSchedule(string connectionString, string clientCode, string asmtId, string postCode,
        string fromDate, string toDate, string locationAutoId, string modifiedBy)
    {
        var sb = new StringBuilder();
        ds = objRost.LockSchedule(connectionString, clientCode, asmtId, postCode, fromDate, toDate, locationAutoId,
            modifiedBy);
        var strGetOutPut = string.Empty;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["MessageId"].ToString() != "69")
            {
                sb.Append(GenerateConvertErrorMessage(ds.Tables[0]));
                strGetOutPut = sb.ToString();
            }
            else
            {
                var i = 0;
                sb.Append("<table width='600px' border=0 style='font-size:11px' >");
                sb.Append("<tr id='tr" + i + "'  style='color: black; font: Helvetica; display: block;' ><td>");
                sb.Append("<div id='lblMessage" + i + "' >" + Resource.MsgSuccessfullyLocked + "</div>");
                sb.Append("</td></tr>");
                sb.Append("</table >");
                strGetOutPut = sb.ToString();
            }
        }
        return strGetOutPut;
    }

    /// <summary>
    ///     Generates the convert error message.
    /// </summary>
    /// <param name="myTable">My table.</param>
    /// <returns>System.String.</returns>
    private string GenerateConvertErrorMessage(DataTable myTable)
    {
        var sb = new StringBuilder();
        if (myTable != null && myTable.Rows.Count > 0)
        {
            sb.Append("<table width='600px' border=1 style='font-size:11px' >");
            sb.Append("<tr>");
            sb.Append("<td><input type='label'  disabled value='" + ResourceValueOfKey_Get("EmployeeNumber") + "'></td>");
            sb.Append("<td><input type='label' disabled value='" + ResourceValueOfKey_Get("DutyDate") + "'></td>");
            sb.Append("<td><input type='label' disabled value='" + ResourceValueOfKey_Get("Message") + "'></td>");
            sb.Append("</tr>");
            for (var i = 0; i < myTable.Rows.Count; i++)
            {
                var newMessageString = ResourceValueOfKey_Get(myTable.Rows[i]["MessageString"].ToString().Trim());
                sb.Append("<tr id='tr" + i + "'  style='color: black; font: Helvetica; display: block;' ><td>");
                sb.Append("<div id='lblConvertEmployeeNumber" + i + "' >" + myTable.Rows[i]["EmployeeNumber"] + "</div>");
                sb.Append("</td><td>");
                try
                {
                    sb.Append("<div  id='lblConvertDutyDate" + i + "' >" +
                              DateTime.Parse(myTable.Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");
                    sb.Append("</td><td>");
                }
                catch (Exception ex1)
                {
                }
                sb.Append("<div id='lblMessage" + i + "' >" + newMessageString + "</div>");
                sb.Append("</td></tr>");
            }

            sb.Append("</table >");
            return sb.ToString();
        }
        const int count = 0;
        sb.Append("<table width='600px' border=0 style='font-size:11px' >");
        sb.Append("<tr id='tr" + count + "'  style='color: black; font: Helvetica; display: block;' ><td>");
        sb.Append("<div id='lblMessage" + count + "' >" + Resource.MsgSuccessfullyLocked + "</div>");
        sb.Append("</td></tr>");
        sb.Append("</table >");
        return sb.ToString();
    }

    /// <summary>
    ///     Confirms the attendance.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtCode">The asmt code.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string ConfirmAttendance(string connectionString, string clientCode, string asmtCode, string postCode,
        string fromDate, string toDate, string locationAutoId, string modifiedBy)
    {
        return objRost.ConfirmAttendance(connectionString, clientCode, asmtCode, postCode, fromDate, toDate,
            locationAutoId, modifiedBy);
    }

    /// <summary>
    ///     Gets the assignment client and post based on asmt auto id.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="otherAssignmentDetail">The other assignment detail.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAssignmentClientAndPostBasedOnAsmtAutoId(string connectionString, string otherAssignmentDetail)
    {
        return objRost.GetAssignmentClientAndPostBasedOnAsmtAutoId(connectionString, otherAssignmentDetail);
    }

    /// <summary>
    ///     Adjustments the hours insert.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="adjustmentDate">The adjustment date.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="adjustmentFromDate">The adjustment from date.</param>
    /// <param name="adjustmentHours">The adjustment hours.</param>
    /// <param name="adjustmentHead">The adjustment head.</param>
    /// <param name="remark">The remark.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AdjustmentHoursInsert(string connectionString, string clientCode, string asmtId, string postCode,
        int locationAutoId, string adjustmentDate, string employeeNumber, string adjustmentFromDate,
        string adjustmentHours, string adjustmentHead, string remark, string modifiedBy)
    {
        var returnValue = string.Empty;
        ds = objRost.AdjustmentHoursInsert(connectionString, clientCode, asmtId, postCode, locationAutoId,
            adjustmentDate, employeeNumber, adjustmentFromDate, adjustmentHours, adjustmentHead, remark, modifiedBy);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            returnValue = ds.Tables[0].Rows[0]["MessageString"].ToString();
        }
        return returnValue;
    }

    /// <summary>
    ///     Adjustments the hours get.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="adjustmentDate">The adjustment date.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AdjustmentHoursGet(string connectionString, string clientCode, string asmtId, string postCode,
        string adjustmentDate, string employeeNumber)
    {
        return objRost.AdjustmentHoursGet(connectionString, clientCode, asmtId, postCode, adjustmentDate, employeeNumber);
    }

    /// <summary>
    ///     Adjustments the hours delete.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="adjustmentDate">The adjustment date.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AdjustmentHoursDelete(string connectionString, string clientCode, string asmtId, string postCode,
        string adjustmentDate, string employeeNumber)
    {
        var returnValue = string.Empty;
        ds = objRost.AdjustmentHoursDelete(connectionString, clientCode, asmtId, postCode, adjustmentDate,
            employeeNumber);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            returnValue = ds.Tables[0].Rows[0]["MessageString"].ToString();
        }
        return returnValue;
    }

    /// <summary>
    ///     Copies the data.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="postCode">The post code.</param>
    /// <param name="weekNo">The week no.</param>
    /// <param name="schRosterAutoID">The SCH roster auto ID.</param>
    /// <param name="screenType">Type of the screen.</param>
    /// <param name="currentSession">The current session.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="clientName">Name of the client.</param>
    /// <param name="asmtName">Name of the asmt.</param>
    /// <param name="postDesc">The post desc.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string CopyData(string connectionString, string clientCode, string asmtId, string postCode, string weekNo,
        string schRosterAutoID, string screenType, string currentSession, string modifiedBy, string fromDate,
        string toDate, string employeeNumber, string clientName, string asmtName, string postDesc)
    {
        var returnValue = string.Empty;
        ds = objRost.CopyData(connectionString, clientCode, asmtId, postCode, weekNo, schRosterAutoID, screenType,
            currentSession, modifiedBy, fromDate, toDate, employeeNumber, clientName, asmtName, postDesc);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var duplicateRecord = new DataTable();
            var view = new DataView(ds.Tables[0]);
            view.RowFilter = "[MessageID]='" + 5 + "'";
            duplicateRecord = view.ToTable();

            if (duplicateRecord.Rows.Count > 0)
            {
                returnValue = GenerateHtmlScriptforOverwriteMessage(ds.Tables[0], employeeNumber);
            }
            else
            {
                returnValue = GenerateHtmlScriptforExceptionMessage(ds, employeeNumber);
            }
        }
        return returnValue;
    }

    /// <summary>
    ///     Resources the value of key_ get.
    /// </summary>
    /// <param name="strKey">The STR key.</param>
    /// <returns>System.String.</returns>
    protected string ResourceValueOfKey_Get(string strKey)
    {
        var strOriginalObject = strKey.Trim();
        var strTextValue = strKey.Replace(" ", "");
        var resorceValue = ResourceValueOfKey_Get1(strTextValue.Trim());
        return resorceValue != strTextValue.Trim() ? resorceValue : strOriginalObject;
    }

    protected string ResourceValueOfKey_Get1(string strKey)
    {
        return Resource.ResourceManager.GetString(strKey) != null &&
               Resource.ResourceManager.GetString(strKey) != ""
            ? Resource.ResourceManager.GetString(strKey)
            : strKey;
    }

    /// <summary>
    ///     Messages the string_ get.
    /// </summary>
    /// <param name="messageId">The message ID.</param>
    /// <returns>System.String.</returns>
    protected string MessageString_Get(int messageId)
    {
        switch (messageId)
        {
            case 1:
                return Resource.MsgDeleteSuccessfully;
            case 6:
                return Resource.MsgDeleteFail;
            case 65:
                return Resource.MsgInValidDateDatecannotBeGreaterThanCurrentDate;
            case 66:
                return Resource.MsgRecordsAlreadyLocked;
            case 67:
                return Resource.MsgCanNotLockedScheduleIsAuthorized;
            case 68:
                return Resource.MsgRotaIsAuthorized;
            case 11:
                return Resource.MsgDuplicateRecordFound;
            case 119:
                return Resource.SelectedEmployeepreferenceisDayShift;
            case 120:
                return Resource.Mondayisnotapreferedday;
            case 121:
                return Resource.Tuesdayisnotapreferedday;
            case 122:
                return Resource.Wednesdayisnotapreferedday;
            case 123:
                return Resource.Thursdayisnotapreferedday;
            case 124:
                return Resource.Fridayisnotapreferedday;
            case 125:
                return Resource.Saturdayisnotapreferedday;
            case 126:
                return Resource.Sundayisnotapreferedday;
            case 127:
                return Resource.SelectedEmployeepreferenceisNightShift;
            case 128:
                return Resource.EmployeeContractDaysIsLessThanNoOfDuty;
            default:
                return Resource.MsgUnknownError;
        }
    }

    /// <summary>
    ///     Shows the sale order deployment.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="post">The post.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string ShowSaleOrderDeployment(string connectionString, string locationAutoId, string clientCode,
        string asmtId, string post)
    {
        return objRost.ShowSaleOrderDeployment(connectionString, locationAutoId, clientCode, asmtId, post);
    }

    /// <summary>
    ///     To get shift pattern details
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtId">The asmt id.</param>
    /// <param name="post">The post.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAllShiftPattern(string connectionString, string locationAutoId, string clientCode, string asmtId,
        string post)
    {
        return objRost.GetAllShiftPattern(connectionString, locationAutoId, clientCode, asmtId, post);
    }

    /// <summary>
    ///     Get Post Wise shift details
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="soNo">The so no.</param>
    /// <param name="soLineNo">The so line no.</param>
    /// <param name="soAmendNo">The so amend no.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetPostWiseShiftDetail(string connectionString, string soNo, string soLineNo, string soAmendNo)
    {
        ds = objRost.GetPostWiseShiftDetail(connectionString, soNo, soLineNo, soAmendNo);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            return GenrateHtmlShiftDetail(ds);
        }
        return string.Empty;
    }

    /// <summary>
    ///     To delete duty replcaed used in kenya
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="autoId">The auto id.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string DutyReplacementDelete(string connectionString, string autoId)
    {
        return objRost.DutyReplacementDelete(connectionString, autoId);
    }

    /// <summary>
    ///     To replace duty used in kenya
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="autoId">The auto id.</param>
    /// <param name="reason">The reason.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string DutyReplacementUpdate(string connectionString, string autoId, string reason)
    {
        return objRost.DutyReplacementUpdate(connectionString, autoId, reason);
    }

    /// <summary>
    ///     To Get the employee details
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="companyCode">The company code.</param>
    /// <param name="hrLocationCode">The hr location code.</param>
    /// <param name="locationCode">The location code.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="areaId">The area id.</param>
    /// <param name="areaIncharge">The area incharge.</param>
    /// <param name="isAreaIncharge">The is area incharge.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string EmployeesScheduleGet(string connectionString, string companyCode, string hrLocationCode,
        string locationCode, string fromDate, string toDate, string areaId, string areaIncharge, string isAreaIncharge)
    {
        return objRost.EmployeesScheduleGet(connectionString, companyCode, hrLocationCode, locationCode, fromDate,
            toDate, areaId, areaIncharge, isAreaIncharge);
    }

    /// <summary>
    ///     To Get The shift details of the selected post
    /// </summary>
    /// <param name="ds">The ds.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GenrateHtmlShiftDetail(DataSet ds)
    {
        var genHtml = new StringBuilder();
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            genHtml.Append(
                "<table width='100%' border='1px' style='font-size:11px; border-style:solid; border-color:Gray;  border-width:thin;'>");
            genHtml.Append("<tr>");
            genHtml.Append(
                "<th>Shift Code</th><th>Week No</th><th>Monday</th><th>Tuesday</th><th>Wednesday</th><th>Thursday</th>");
            genHtml.Append("<th>Friday</th><th>Saturday</th><th>Sunday</th>");
            if (ds.Tables[0].Rows[0]["ParamValue"].ToString() == @"1")
            {
                genHtml.Append("<th>Holiday</th>");
            }
            genHtml.Append("</tr>");

            for (var cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
            {
                genHtml.Append("<tr>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["ShiftCode"] + "</td>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["WeekNo"] + "</td>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["Mon"] + "</td>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["Tue"] + "</td>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["Wed"] + "</td>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["Thu"] + "</td>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["Fri"] + "</td>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["Sat"] + "</td>");
                genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["Sun"] + "</td>");
                if (ds.Tables[0].Rows[0]["ParamValue"].ToString() == @"1")
                {
                    genHtml.Append("<td>" + ds.Tables[0].Rows[cnt]["Holiday"] + "</td>");
                }
                genHtml.Append("</tr>");
            }
        }
        return genHtml.ToString();
    }

    /// <summary>
    ///     To Get Legends details
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="companyCode">The company code.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetLegends(string connectionString, string companyCode)
    {
        var result = new StringBuilder();
        ds = objRost.GetLegends(connectionString, companyCode);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result.Append("<table width='100%' style='font-size:12px;'>");
            result.Append("<tr>");
            for (var cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
            {
                result.Append("<td>");
                var backColor = ds.Tables[0].Rows[cnt]["ColorCode"].ToString();
                result.Append("<img style='width: 10px; height: 10px; background-color: " + backColor + "'></img>");
                var dutyTypeDesc = ds.Tables[0].Rows[cnt]["DutyTypeDesc"].ToString();
                result.Append(ResourceValueOfKey_Get(dutyTypeDesc));
                result.Append("</td>");

                if (cnt == 6)
                {
                    result.Append("</tr>");
                }
            }
            result.Append("</tr></table>");
            return result.ToString();
        }
        return string.Empty;
    }

    /// <summary>
    ///     Gets the week.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="month">The month.</param>
    /// <param name="year">The year.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetWeek(string connectionString, string locationAutoId, string month, string year)
    {
        return objRost.GetWeek(connectionString, locationAutoId, month, year);
    }

    /// <summary>
    ///     Gets all area.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="isAreaIncharge">The is area incharge.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAllArea(string connectionString, string locationAutoId, string employeeNumber,
        string isAreaIncharge, string fromDate, string toDate)
    {
        return objRost.GetAllArea(connectionString, locationAutoId, employeeNumber, isAreaIncharge, fromDate, toDate);
    }

}