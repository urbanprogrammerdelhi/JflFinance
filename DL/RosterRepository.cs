// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 04-27-2015
//
// Last Modified By : Administrator
// Last Modified On : 02-12-2015
// ***********************************************************************
// <copyright file="RosterRepository.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Repository of methods related to Roster
    /// </summary>
    public class RosterRepository
    {

        /// <summary>
        /// The _obj con
        /// </summary>
        readonly ConnectionString _objCon = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RosterRepository"/> class.
        /// </summary>
        public RosterRepository()
        {
            _objCon = new ConnectionString();
        }

        /// <summary>
        /// Inserts the data.
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
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaInchargeNumber">The area incharge number.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>System.String.</returns>
        public DataSet InsertData(string comnnectionString, string locationAutoId, string clientCode, string asmtId, string fromDate, string toDate, string employeeNumber, string shiftPatternCode, string patternPositioon, string rowNumber, string post, string attendanceType, string weekNo, string sessionId, string modifiedBy, string clientName, string assignmentName, string postName, string areaId, string areaInchargeNumber, string isAreaIncharge)
        {
            var connect = _objCon.ConnectionStringGet(comnnectionString);
            using (var scn = new SqlConnection(connect))
            {
                var command = new SqlCommand("udpTransaction_ScheduleEmpWise_Insert", scn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.ShiftPatternCode, SqlDbType.NVarChar).Value = shiftPatternCode;
                command.Parameters.Add(Properties.Resources.PatternPosition, SqlDbType.NVarChar).Value = patternPositioon;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = modifiedBy;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.RowNumber, SqlDbType.NVarChar).Value = rowNumber;
                command.Parameters.Add(Properties.Resources.Post, SqlDbType.NVarChar).Value = post;
                command.Parameters.Add(Properties.Resources.SessionID, SqlDbType.NVarChar).Value = sessionId;
                command.Parameters.Add(Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = weekNo;
                command.Parameters.Add(Properties.Resources.ClientName, SqlDbType.NVarChar).Value = clientName;
                command.Parameters.Add(Properties.Resources.Assignment, SqlDbType.NVarChar).Value = assignmentName;
                command.Parameters.Add(Properties.Resources.PostDesc, SqlDbType.NVarChar).Value = postName;
                command.Parameters.Add(Properties.Resources.AreaId, SqlDbType.NVarChar).Value = areaId;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = areaInchargeNumber;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = isAreaIncharge;

                command.CommandTimeout = 180;
                scn.Open();
                var adapter = new SqlDataAdapter(command);
                var dsSubmit = new DataSet();
                adapter.Fill(dsSubmit);
                return dsSubmit;
            }
        }

        /// <summary>
        /// Inserts the data of date.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="screenType">Type of the screen.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currentSessionId">The current session identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="assignmentName">Name of the assignment.</param>
        /// <param name="postName">Name of the post.</param>
        /// <returns>DataSet.</returns>
        public DataSet InsertDataOfDate(string connectionString, string clientCode, string asmtId, string postCode, string employeeNumber, string dutyDate, string shiftCode, string weekNo, string shiftPatternCode, string patternPosition, string timeFrom, string timeTo, string scheduleRosterAutoId, string rowNumber, string screenType, string fromDate, string toDate, string currentSessionId, string locationAutoId, string modifiedBy, string clientName, string assignmentName, string postName)
        {
            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;

                if (screenType.Trim().ToLower() == "sch".Trim().ToLower())
                {
                    command = new SqlCommand("udpTran_NewScheduleRoster_Insert", scn);
                    command.Parameters.Add(Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value = scheduleRosterAutoId;
                }
                else
                {
                    command = new SqlCommand("udpTrans_RotaEmpWise_Insert", scn);
                    command.Parameters.Add(Properties.Resources.RosterAutoId, SqlDbType.NVarChar).Value = scheduleRosterAutoId;
                }
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = dutyDate;
                command.Parameters.Add(Properties.Resources.ShiftCode, SqlDbType.NVarChar).Value = shiftCode;
                command.Parameters.Add(Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = weekNo;
                command.Parameters.Add(Properties.Resources.ShiftPatternCode, SqlDbType.NVarChar).Value = shiftPatternCode;
                command.Parameters.Add(Properties.Resources.PatternPosition, SqlDbType.NVarChar).Value = patternPosition;
                command.Parameters.Add(Properties.Resources.TimeFrom, SqlDbType.NVarChar).Value = timeFrom;
                command.Parameters.Add(Properties.Resources.TimeTo, SqlDbType.NVarChar).Value = timeTo;

                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = modifiedBy;
                command.Parameters.Add(Properties.Resources.RowNumber, SqlDbType.NVarChar).Value = rowNumber;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.SessionID, SqlDbType.NVarChar).Value = currentSessionId;
                command.Parameters.Add(Properties.Resources.ClientName, SqlDbType.NVarChar).Value = clientName;
                command.Parameters.Add(Properties.Resources.Assignment, SqlDbType.NVarChar).Value = assignmentName;
                command.Parameters.Add(Properties.Resources.PostDesc, SqlDbType.NVarChar).Value = postName;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();
                var returnValue = string.Empty;
                var adapter = new SqlDataAdapter(command);
                var dsSubmit = new DataSet();
                adapter.Fill(dsSubmit);

                return dsSubmit;
            }
        }

        /// <summary>
        /// Gets the employee detail.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="insertStatus">The insert status.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaInchargeNumber">The area incharge number.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="screenType">Type of the screen.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetEmployeeDetail(string connectionString, string employeeNumber, string clientCode, string asmtId, string fromDate, string toDate, string postCode, string insertStatus, string areaId, string areaInchargeNumber, string isAreaIncharge, string screenType, string companyCode, string hrLocationCode, string locationAutoId, string modifiedBy)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {

                SqlCommand command;
                command = new SqlCommand("udpMstHR_EmployeeDetailByEmpNo_Get", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.AreaId, SqlDbType.NVarChar).Value = areaId;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = areaInchargeNumber;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = isAreaIncharge;
                command.Parameters.Add(Properties.Resources.ScreenType, SqlDbType.NVarChar).Value = screenType;
                command.Parameters.Add(Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = companyCode;
                command.Parameters.Add(Properties.Resources.HrLocationCode, SqlDbType.NVarChar).Value = hrLocationCode;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = modifiedBy;
                command.Parameters.Add(Properties.Resources.Status, SqlDbType.NVarChar).Value = "";
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var dsEmpName = new DataSet();
                adapter.Fill(dsEmpName);
                return dsEmpName;
            }

        }

        /// <summary>
        /// Overwrites the schedule.
        /// </summary>
        /// <param name="comnnectionString">The comnnection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="weekNumber">The week number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="scheduleToOverwriteXml">The schedule to overwrite XML.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverwriteSchedule(string comnnectionString, string clientCode, string asmtId, string postCode, string employeeNumber, int weekNumber, string locationAutoId, string modifiedBy, string scheduleToOverwriteXml, string attendanceType)
        {
            var connect = _objCon.ConnectionStringGet(comnnectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                if (attendanceType.ToLower() == "SCH".ToLower())
                {
                    command = new SqlCommand("udpTran_NewScheduleRoster_OverWriteShift", scn);
                }
                else
                {
                    command = new SqlCommand("udpTrans_RotaEmpWise_OverWriteDuplicateRecord", scn);
                }
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.WeekNo, SqlDbType.Int).Value = weekNumber;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = modifiedBy;
                command.Parameters.Add(Properties.Resources.XmlData, SqlDbType.NVarChar).Value = scheduleToOverwriteXml;
                command.CommandTimeout = 180;
                scn.Open();
                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }

        }

        /// <summary>
        /// Gets the employee count client and post wise.
        /// </summary>
        /// <param name="strComnnectionString">The string comnnection string.</param>
        /// <param name="strCompanyCode">The string company code.</param>
        /// <param name="strHrlocationCode">The string hrlocation code.</param>
        /// <param name="strLocationCode">The string location code.</param>
        /// <param name="strAttendanceType">Type of the string attendance.</param>
        /// <param name="strPostCode">The string post code.</param>
        /// <param name="strFromDate">The string from date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>System.String.</returns>
        public string GetEmployeeCountClientAndPostWise(string strComnnectionString, string strCompanyCode, string strHrlocationCode, string strLocationCode, string strAttendanceType, string strPostCode, string strFromDate, string strToDate, string strAsmtCode, string clientCode)
        {

            var connect = _objCon.ConnectionStringGet(strComnnectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTran_EmployeeCountClientWiseAndpostWise_Get", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = strCompanyCode;
                command.Parameters.Add(Properties.Resources.HrLocationCode, SqlDbType.NVarChar).Value = strHrlocationCode;
                command.Parameters.Add(Properties.Resources.LocationCode, SqlDbType.NVarChar).Value = strLocationCode;
                command.Parameters.Add(Properties.Resources.AttendanceType, SqlDbType.NVarChar).Value = strAttendanceType;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = strPostCode;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = strAsmtCode;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                return strRota;
            }
        }

        /// <summary>
        /// Gets the employee count client wise andpost wise.
        /// </summary>
        /// <param name="strComnnectionString">The string comnnection string.</param>
        /// <param name="strCompanyCode">The string company code.</param>
        /// <param name="strHrlocationCode">The string hrlocation code.</param>
        /// <param name="strLocationCode">The string location code.</param>
        /// <param name="strAttendanceType">Type of the string attendance.</param>
        /// <param name="strPostCode">The string post code.</param>
        /// <param name="strFromDate">The string from date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>System.String.</returns>
        public string GetEmployeeCountClientWiseAndpostWise(string strComnnectionString, string strCompanyCode, string strHrlocationCode, string strLocationCode, string strAttendanceType, string strPostCode, string strFromDate, string strToDate, string strAsmtCode, string clientCode)
        {

            var connect = _objCon.ConnectionStringGet(strComnnectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpEmployeeWiseContAndSchAndActHoursTotalGet", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = strCompanyCode;
                command.Parameters.Add(Properties.Resources.HrLocationCode, SqlDbType.NVarChar).Value = strHrlocationCode;
                command.Parameters.Add(Properties.Resources.LocationCode, SqlDbType.NVarChar).Value = strLocationCode;
                command.Parameters.Add(Properties.Resources.AttendanceType, SqlDbType.NVarChar).Value = strAttendanceType;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = strPostCode;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = strAsmtCode;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);

                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                return strRota;
            }
        }

        /// <summary>
        /// Gets the job break down summary.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="strCompanyCode">The string company code.</param>
        /// <param name="strHrLocationCode">The string hr location code.</param>
        /// <param name="strLocationCode">The string location code.</param>
        /// <param name="strSchRosterAutoId">The string SCH roster automatic identifier.</param>
        /// <param name="strAttendanceType">Type of the string attendance.</param>
        /// <param name="strAreaID">The string area identifier.</param>
        /// <param name="strAreaIncharge">The string area incharge.</param>
        /// <param name="strIsAreaIncharge">The string is area incharge.</param>
        /// <param name="strFromDate">The string from date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="selectedDate">The selected date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtid">The asmtid.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>System.String.</returns>
        public string GetJobBreakDownSummary(string strCon, string strCompanyCode, string strHrLocationCode, string strLocationCode, string strSchRosterAutoId, string strAttendanceType, string strAreaID, string strAreaIncharge, string strIsAreaIncharge, string strFromDate, string strToDate, string selectedDate, string clientCode, string asmtid, string postCode, string employeeNumber)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {

                var command = new SqlCommand("udpTransaction_ScheduleEmpWise_JobBreakDownSummary", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value = strSchRosterAutoId;
                command.Parameters.Add(Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = strCompanyCode;
                command.Parameters.Add(Properties.Resources.HrLocationCode, SqlDbType.NVarChar).Value = strHrLocationCode;
                command.Parameters.Add(Properties.Resources.LocationCode, SqlDbType.NVarChar).Value = strLocationCode;
                command.Parameters.Add(Properties.Resources.AttendanceType, SqlDbType.NVarChar).Value = strAttendanceType;
                command.Parameters.Add(Properties.Resources.AreaId, SqlDbType.NVarChar).Value = strAreaID;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = strAreaIncharge;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = strIsAreaIncharge;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
                command.Parameters.Add(Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = selectedDate;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtid;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                ds.Dispose();
                return strRota;
            }
        }

        /// <summary>
        /// Gets all clients.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>System.String.</returns>
        public string GetAllClients(string strCon, string locationAutoId, string areaId, string clientCode, string employeeNumber, string isAreaIncharge, string fromDate, string toDate)
        {


            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTran_ScheduleEmpWise_GetAllClients", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.AreaId, SqlDbType.NVarChar).Value = areaId;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = isAreaIncharge;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds.GetXml().ToString();

            }
        }

        /// <summary>
        /// Gets all assignments.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>System.String.</returns>
        public string GetAllAssignments(string strCon, string locationAutoId, string clientCode, string fromDate, string toDate, string employeeNumber, string isAreaIncharge, string areaId)
        {


            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpOPS_AsmtsOfClient_Get", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.AreaId, SqlDbType.NVarChar).Value = areaId;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = isAreaIncharge;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds.GetXml().ToString();
            }
        }

        /// <summary>
        /// Alls the shifts of asmt.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="intWeekNo">The int week no.</param>
        /// <param name="postCode">The post code.</param>
        /// <returns>System.String.</returns>
        public string AllShiftsOfAsmt(string strCon, int LocationAutoId, string strAsmtCode, int intWeekNo, string postCode)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                var command = new SqlCommand("udpOPS_AllAsmtShift_Get", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = LocationAutoId;
                command.Parameters.Add(Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = intWeekNo;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strShift = ds.GetXml();
                ds.Dispose();
                return strShift;
            }
        }

        /// <summary>
        /// Gets all lock un lock status.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>System.String.</returns>
        public string GetAllLockUnLockStatus(string strCon, string clientCode, string asmtId, string locationAutoID, string fromDate, string toDate)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTran_ScheduleRosterEmpWise_GetLockUnLockStatus", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoID;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strGetOutPut = ds.GetXml();
                return strGetOutPut;
            }
        }

        /// <summary>
        /// Changes the type of the duty.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="strSchAutoId">The string SCH automatic identifier.</param>
        /// <param name="strDutyType">Type of the string duty.</param>
        /// <param name="strAttendanceType">Type of the string attendance.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>System.String.</returns>
        public string ChangeDutyType(string strCon, string strSchAutoId, string strDutyType, string strAttendanceType, string strModifiedBy, string companyCode)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
                {
                    command = new SqlCommand("udpTran_ScheduleRoster_ChangeDutyType", scn);
                }
                else
                {
                    command = new SqlCommand("udpTran_Roster_ChangeDutyType", scn);
                }
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value = strSchAutoId;
                command.Parameters.Add(Properties.Resources.DutyTypeDesc, SqlDbType.NVarChar).Value = strDutyType;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
                command.Parameters.Add(Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = companyCode;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                ds.Dispose();
                return strRota;
            }
        }

        /// <summary>
        /// Applies the week off.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <param name="strEmployeeNumber">The string employee number.</param>
        /// <param name="strDutyDate">The string duty date.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <param name="strShiftPat">The string shift pat.</param>
        /// <param name="shiftPos">The shift position.</param>
        /// <param name="strRowNumber">The string row number.</param>
        /// <param name="strAttendanceType">Type of the string attendance.</param>
        /// <param name="schrosterAutoId">The schroster automatic identifier.</param>
        /// <returns>System.String.</returns>
        public string ApplyWeekOff(string strCon, string clientCode, string asmtId, string postCode, int LocationAutoId, string strEmployeeNumber, string strDutyDate, string strModifiedBy, string strShiftPat, int shiftPos, string strRowNumber, string strAttendanceType, string schrosterAutoId)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;

                if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
                {
                    command = new SqlCommand("udpTrn_SchEmpWiseWeeklyOff_Save", scn);
                }
                else
                {
                    command = new SqlCommand("udpTrn_RosterEmpWiseWeeklyOff_Save", scn);
                }
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = LocationAutoId;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
                command.Parameters.Add(Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = strDutyDate;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
                command.Parameters.Add(Properties.Resources.ShiftPatternCode, SqlDbType.NVarChar).Value = strShiftPat;
                command.Parameters.Add(Properties.Resources.PatternPosition, SqlDbType.NVarChar).Value = shiftPos;
                command.Parameters.Add(Properties.Resources.RowNumber, SqlDbType.Int).Value = int.Parse(strRowNumber);
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value = schrosterAutoId;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                ds.Dispose();
                return strRota;
            }
        }

        /// <summary>
        /// Asmts the schedule copy.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="nWeek">The n week.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="strFromDate">The string from date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strAttendanceType">Type of the string attendance.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>System.String.</returns>
        public string AsmtScheduleCopy(string strCon, int nWeek, string strAsmtCode, string strFromDate, string strToDate, string strAttendanceType, string strModifiedBy, string pdLineNo)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
                {
                    command = new SqlCommand("UdpTrans_CopyScheduleNextWeek", scn);
                }
                else
                {
                    command = new SqlCommand("UdpTrans_CopyRotaNextWeek", scn);
                }
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
                command.Parameters.Add(Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = nWeek;
                command.Parameters.Add(Properties.Resources.PDLineNo, SqlDbType.NVarChar).Value = pdLineNo;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                ds.Dispose();
                return strRota;
            }
        }

        /// <summary>
        /// Schedules the copy.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="nWeek">The n week.</param>
        /// <param name="strEmployeeNumber">The string employee number.</param>
        /// <param name="strSchAutoIds">The string SCH automatic ids.</param>
        /// <param name="strFromDate">The string from date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strPatCode">The string pat code.</param>
        /// <param name="strPos">The string position.</param>
        /// <param name="strDefalt">The string defalt.</param>
        /// <param name="strRowNumber">The string row number.</param>
        /// <param name="strAttendanceType">Type of the string attendance.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <returns>System.String.</returns>
        public string ScheduleCopy(string strCon, int nWeek, string strEmployeeNumber, string strSchAutoIds, string strFromDate, string strToDate, string strPatCode, string strPos, string strDefalt, string strRowNumber, string strAttendanceType, string strModifiedBy)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
                {
                    command = new SqlCommand("udpTran_ScheduleRosterEmpWise_Copy", scn);
                }
                else
                {
                    command = new SqlCommand("udpTran_RosterEmpWise_Copy", scn);
                }
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
                command.Parameters.Add(Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value = strSchAutoIds;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
                command.Parameters.Add(Properties.Resources.ShiftPatternCode, SqlDbType.NVarChar).Value = strPatCode;
                command.Parameters.Add(Properties.Resources.PatternPosition, SqlDbType.NVarChar).Value = strPos;
                command.Parameters.Add(Properties.Resources.IsDefault, SqlDbType.NVarChar).Value = strDefalt;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
                command.Parameters.Add(Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = nWeek;
                command.Parameters.Add(Properties.Resources.RowNumber, SqlDbType.Int).Value = int.Parse(strRowNumber);
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                ds.Dispose();
                return strRota;
            }

        }

        /// <summary>
        /// Gets all shifts of day.
        /// </summary>
        /// <param name="strComnnectionString">The string comnnection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="weekNumber">The week number.</param>
        /// <param name="postCode">The post code.</param>
        /// <returns>System.String.</returns>
        public string GetAllShiftsOfDay(string strComnnectionString, string clientCode, string asmtId, string strLocationAutoID, string dutyDate, string weekNumber, string postCode)
        {

            var connect = _objCon.ConnectionStringGet(strComnnectionString);
            using (var scn = new SqlConnection(connect))
            {
                var command = new SqlCommand("udpTransaction_ScheduleEmpWise_GetShift", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
                command.Parameters.Add(Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = dutyDate;
                command.Parameters.Add(Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = weekNumber;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                ds.Dispose();
                return strRota;
            }
        }

        /// <summary>
        /// Gets all post of assignment.
        /// </summary>
        /// <param name="strComnnectionString">The string comnnection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="AsmtId">The asmt identifier.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>System.String.</returns>
        public string GetAllPostOfAssignment(string strComnnectionString, string clientCode, string AsmtId, string locationAutoID, string fromDate, string toDate)
        {

            var connect = _objCon.ConnectionStringGet(strComnnectionString);
            using (var scn = new SqlConnection(connect))
            {
                var command = new SqlCommand("udpTransaction_ScheduleEmpWise_GetAllPost", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtId;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoID;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                ds.Dispose();
                return strRota;
            }
        }

        /// <summary>
        /// Searches the post identifier.
        /// </summary>
        /// <param name="strComnnectionString">The string comnnection string.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="strFromDate">The string from date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strAreaID">The string area identifier.</param>
        /// <param name="strAreaIncharge">The string area incharge.</param>
        /// <param name="strIsAreaIncharge">The string is area incharge.</param>
        /// <returns>System.String.</returns>
        public string SearchPostID(string strComnnectionString, string strLocationAutoID, string strFromDate, string strToDate, string strAreaID, string strAreaIncharge, string strIsAreaIncharge)
        {

            var connect = _objCon.ConnectionStringGet(strComnnectionString);
            using (var scn = new SqlConnection(connect))
            {
                var command = new SqlCommand("udpTransaction_ScheduleEmpWise_GetPost", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
                command.Parameters.Add(Properties.Resources.AreaId, SqlDbType.NVarChar).Value = strAreaID;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = strAreaIncharge;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = strIsAreaIncharge;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var strRota = ds.GetXml();
                ds.Dispose();
                return strRota;
            }
        }

        /// <summary>
        /// Gets the employee schedule.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="intLocationAutoId">The int location automatic identifier.</param>
        /// <param name="strEmployeeNumber">The string employee number.</param>
        /// <param name="strFromDate">The string from date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strAttendanceType">Type of the string attendance.</param>
        /// <param name="strAreaID">The string area identifier.</param>
        /// <param name="strAreaIncharge">The string area incharge.</param>
        /// <param name="strIsAreaIncharge">The string is area incharge.</param>
        /// <returns>System.String.</returns>
        public string GetEmployeeSchedule(string strCon, int intLocationAutoId, string strEmployeeNumber, string strFromDate, string strToDate, string strAttendanceType, string strAreaID, string strAreaIncharge, string strIsAreaIncharge)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
                {
                    command = new SqlCommand("udpTrans_ScheduleOfEmployee_Get", scn);
                }
                else
                {
                    command = new SqlCommand("udpTrans_RosterOfEmployee_Get", scn);
                }
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = intLocationAutoId;
                //Added Area ID option to search only those employee that belongs to that Area
                command.Parameters.Add(Properties.Resources.AreaId, SqlDbType.NVarChar).Value = strAreaID;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = strAreaIncharge;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = strIsAreaIncharge;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);



                var strSchedule = ds.GetXml();
                ds.Dispose();
                return strSchedule;
            }

        }

        /// <summary>
        /// Locks the schedule.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LockSchedule(string connectionString, string clientCode, string asmtId, string postCode, string fromDate, string toDate, string locationAutoId, string modifiedBy)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTrans_ConvertEmpWise_Schedule2Actual", scn);
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = modifiedBy;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();
                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// Confirms the attendance.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>System.String.</returns>
        public string ConfirmAttendance(string connectionString, string clientCode, string asmtCode, string postCode, string fromDate, string toDate, string locationAutoId, string modifiedBy)
        {
            var objCon = new ConnectionString();
            var connect = objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTrans_RotaEmpWise_ConfirmAttendance", scn);
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = asmtCode;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = modifiedBy;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();
                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var returnData = ds.GetXml();
                return returnData;


            }
        }

        /// <summary>
        /// Gets the assignment client and post based on asmt automatic identifier.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="otherAssignmentDetail">The other assignment detail.</param>
        /// <returns>System.String.</returns>
        public string GetAssignmentClientAndPostBasedOnAsmtAutoId(string connectionString, string otherAssignmentDetail)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTransaction_ScheduleEmpWise_GetAssignmentClientAndPostBasedOnAsmtAutoId", scn);
                command.Parameters.Add(Properties.Resources.OtherAssignmentDetail, SqlDbType.NVarChar).Value = otherAssignmentDetail;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();
                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var returnData = ds.GetXml();
                return returnData;
            }
        }

        /// <summary>
        /// Adjustments the hours insert.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="adjustmentDate">The adjustment date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="adjustmentFromDate">The adjustment from date.</param>
        /// <param name="adjustmentHours">The adjustment hours.</param>
        /// <param name="adjustmentHead">The adjustment head.</param>
        /// <param name="remark">The remark.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AdjustmentHoursInsert(string connectionString, string clientCode, string asmtId, string postCode, int locationAutoId, string adjustmentDate, string employeeNumber, string adjustmentFromDate, string adjustmentHours, string adjustmentHead, string remark, string modifiedBy)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTrans_AdjustmentHrs_Insert", scn);
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.AdjDate, SqlDbType.NVarChar).Value = adjustmentDate;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.AdjHrsFromdate, SqlDbType.NVarChar).Value = adjustmentFromDate;
                command.Parameters.Add(Properties.Resources.AdjHrsToDate, SqlDbType.NVarChar).Value = adjustmentFromDate;
                command.Parameters.Add(Properties.Resources.HrsAdjusted, SqlDbType.NVarChar).Value = adjustmentHours;
                command.Parameters.Add(Properties.Resources.AdjHeadCode, SqlDbType.NVarChar).Value = adjustmentHead;
                command.Parameters.Add(Properties.Resources.Remarks, SqlDbType.NVarChar).Value = remark;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = modifiedBy;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// Adjustments the hours get.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="adjustmentDate">The adjustment date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>System.String.</returns>
        public string AdjustmentHoursGet(string connectionString, string clientCode, string asmtId, string postCode, string adjustmentDate, string employeeNumber)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTrans_AdjustmentHrs_Get", scn);
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.AdjHrsFromdate, SqlDbType.NVarChar).Value = adjustmentDate;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var returnData = ds.GetXml();
                return returnData;

            }
        }

        /// <summary>
        /// Adjustments the hours delete.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="adjustmentDate">The adjustment date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AdjustmentHoursDelete(string connectionString, string clientCode, string asmtId, string postCode, string adjustmentDate, string employeeNumber)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTrans_AdjustmentHrs_Delete", scn);
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.AdjHrsFromdate, SqlDbType.NVarChar).Value = adjustmentDate;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }

        /// <summary>
        /// Copies the data.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="schRosterAutoID">The SCH roster automatic identifier.</param>
        /// <param name="screenType">Type of the screen.</param>
        /// <param name="currentSession">The current session.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="asmtName">Name of the asmt.</param>
        /// <param name="postDesc">The post desc.</param>
        /// <returns>DataSet.</returns>
        public DataSet CopyData(string connectionString, string clientCode, string asmtId, string postCode, string weekNo, string schRosterAutoID, string screenType, string currentSession, string modifiedBy, string fromDate, string toDate, string employeeNumber, string clientName, string asmtName, string postDesc)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTransaction_ScheduleEmpWise_Copy", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;

                command.Parameters.Add(Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = weekNo;
                command.Parameters.Add(Properties.Resources.ScheduleRosterAutoID, SqlDbType.NVarChar).Value = schRosterAutoID;
                command.Parameters.Add(Properties.Resources.AttendanceType, SqlDbType.NVarChar).Value = screenType;
                command.Parameters.Add(Properties.Resources.SessionID, SqlDbType.NVarChar).Value = currentSession;
                command.Parameters.Add(Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = modifiedBy;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.ClientName, SqlDbType.NVarChar).Value = clientName;
                command.Parameters.Add(Properties.Resources.Assignment, SqlDbType.NVarChar).Value = asmtName;
                command.Parameters.Add(Properties.Resources.PostDesc, SqlDbType.NVarChar).Value = postDesc;
                command.CommandTimeout = 180;
                scn.Open();
                var adapter = new SqlDataAdapter(command);
                var dsSubmit = new DataSet();
                adapter.Fill(dsSubmit);
                return dsSubmit;
            }

        }

        /// <summary>
        /// Shows the sale order deployment.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="post">The post.</param>
        /// <returns>System.String.</returns>
        public string ShowSaleOrderDeployment(string connectionString, string locationAutoId, string clientCode, string asmtId, string post)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udp_SaleOrderDetails_GetSalesDetailsBasedOnAssignment", scn);
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = post;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var result = ds.GetXml();
                ds.Dispose();
                return result;

            }
        }

        /// <summary>
        /// Gets all shift pattern.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="post">The post.</param>
        /// <returns>System.String.</returns>
        public string GetAllShiftPattern(string connectionString, string locationAutoId, string clientCode, string asmtId, string post)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udp_Asmtshiftpattern_get", scn);
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = post;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var result = ds.GetXml();
                ds.Dispose();
                return result;

            }
        }

        /// <summary>
        /// Gets the post wise shift detail.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="SoNo">The so no.</param>
        /// <param name="SoLineNo">The so line no.</param>
        /// <param name="SoAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetPostWiseShiftDetail(string connectionString, string SoNo, string SoLineNo, string SoAmendNo)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTransaction_Schedule_PostWise_Shift", scn);
                command.Parameters.Add(Properties.Resources.SONO, SqlDbType.NVarChar).Value = SoNo;
                command.Parameters.Add(Properties.Resources.SoLineNo, SqlDbType.Int).Value = Convert.ToInt32(SoLineNo);
                command.Parameters.Add(Properties.Resources.SOAmendNo, SqlDbType.NVarChar).Value = SoAmendNo;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }

        /// <summary>
        /// Duties the replacement delete.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="autoId">The automatic identifier.</param>
        /// <returns>System.String.</returns>
        public string DutyReplacementDelete(string connectionString, string autoId)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTransaction_Roster_DutyReplacementDelete", scn);
                command.Parameters.Add(Properties.Resources.AutoId, SqlDbType.NVarChar).Value = autoId;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var result = ds.GetXml();
                ds.Dispose();
                return result;

            }
        }

        /// <summary>
        /// Duties the replacement update.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="autoId">The automatic identifier.</param>
        /// <param name="reason">The reason.</param>
        /// <returns>System.String.</returns>
        public string DutyReplacementUpdate(string connectionString, string autoId, string reason)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTransaction_Roster_DutyReplacementUpdate", scn);
                command.Parameters.Add(Properties.Resources.AutoId, SqlDbType.NVarChar).Value = autoId;
                command.Parameters.Add(Properties.Resources.Reason, SqlDbType.NVarChar).Value = reason;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var result = ds.GetXml();
                ds.Dispose();
                return result;

            }
        }

        /// <summary>
        /// Employeeses the schedule get.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>System.String.</returns>
        public string EmployeesScheduleGet(string connectionString, string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string areaId, string areaIncharge, string isAreaIncharge)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("updMstHR_EmployeesWiseSchedule_GetAllEmployee", scn);
                command.Parameters.Add(Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = companyCode;
                command.Parameters.Add(Properties.Resources.HrLocationCode, SqlDbType.NVarChar).Value = hrLocationCode;
                command.Parameters.Add(Properties.Resources.LocationCode, SqlDbType.NVarChar).Value = locationCode;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.AreaId, SqlDbType.NVarChar).Value = areaId;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = areaIncharge;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = isAreaIncharge;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var result = ds.GetXml();
                ds.Dispose();
                return result;

            }
        }

        /// <summary>
        /// Deletes the schedule.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="scheduleRosterAutoID">The schedule roster automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet DeleteSchedule(string strCon, string scheduleRosterAutoID, string employeeNumber, string fromDate, string toDate, string clientCode, string asmtId, string postCode, string shiftPatternCode, int patternPosition, int rowNumber, string attendanceType)
        {

            var connect = _objCon.ConnectionStringGet(strCon);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                if (attendanceType.ToLower() == "SCH".ToLower())
                {
                    command = new SqlCommand("udpTran_EmployeeWiseSchedule_Delete", scn);
                }
                else
                {
                    command = new SqlCommand("udpTran_EmployeeWiseRota_Delete", scn);
                }
                command.Parameters.Add(Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
                command.Parameters.Add(Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
                command.Parameters.Add(Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.Parameters.Add(Properties.Resources.ShiftPatternCode, SqlDbType.NVarChar).Value = shiftPatternCode;
                command.Parameters.Add(Properties.Resources.PatternPosition, SqlDbType.NVarChar).Value = patternPosition;
                command.Parameters.Add(Properties.Resources.RowNumber, SqlDbType.NVarChar).Value = rowNumber;
                if (scheduleRosterAutoID == "")
                {
                    scheduleRosterAutoID = "0";
                }

                command.Parameters.Add(Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value = scheduleRosterAutoID;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();
                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// Gets the legends.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLegends(string connectionString, string companyCode)
        {

            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTransaction_Roster_GetLegends", scn);
                command.Parameters.Add(Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = companyCode;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();
                var result = new StringBuilder();
                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// Gets the week.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>System.String.</returns>
        public string GetWeek(string connectionString, string locationAutoId, string month, string year)
        {


            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpTransaction_Roster_GetWeek", scn);
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.Month, SqlDbType.NVarChar).Value = month;
                command.Parameters.Add(Properties.Resources.Year, SqlDbType.NVarChar).Value = year;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var result = ds.GetXml();
                ds.Dispose();
                return result;

            }
        }

        /// <summary>
        /// Gets all area.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>System.String.</returns>
        public string GetAllArea(string connectionString, string locationAutoId, string employeeNumber, string isAreaIncharge, string fromDate, string toDate)
        {


            var connect = _objCon.ConnectionStringGet(connectionString);
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command;
                command = new SqlCommand("udpMstOperation_AreaMaster_GetAreaID", scn);
                command.Parameters.Add(Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
                command.Parameters.Add(Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = employeeNumber;
                command.Parameters.Add(Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = isAreaIncharge;
                command.Parameters.Add(Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
                command.Parameters.Add(Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                scn.Open();

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);
                var result = ds.GetXml();
                ds.Dispose();
                return result;

            }
        }

        //// --------
    }
}
