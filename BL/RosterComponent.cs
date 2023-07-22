// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 04-27-2015
//
// Last Modified By : Administrator
// Last Modified On : 05-01-2015
// ***********************************************************************
// <copyright file="RosterComponent.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class RosterComponent.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class RosterComponent
    {
        /// <summary>
        /// The object rost
        /// </summary>
        DL.RosterRepository objRost = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RosterComponent" /> class.
        /// </summary>
        public RosterComponent()
        {
            objRost = new DL.RosterRepository();
        }
        #region scheduling CRUD operations

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for applying schedule pattern.
        /// </summary>
        /// <param name="comnnectionString">The comnnection string.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPositioon">The pattern positioon.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="post">The post.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="assignmentName">Name of the assignment.</param>
        /// <param name="postName">Name of the post.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaInchargeNumber">The area incharge number.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet InsertData(string comnnectionString, string locationAutoId, string clientCode, string asmtId, string fromDate, string toDate, string employeeNumber, string shiftPatternCode, string patternPositioon, string rowNumber, string post, string attendanceType, string weekNo, string sessionId, string modifiedBy, string clientName, string assignmentName, string postName,string areaId, string areaInchargeNumber, string isAreaIncharge)
        {
            return objRost.InsertData(comnnectionString, locationAutoId, clientCode, asmtId, fromDate, toDate, employeeNumber, shiftPatternCode, patternPositioon, rowNumber, post, attendanceType, weekNo, sessionId, modifiedBy, clientName, assignmentName, postName,areaId, areaInchargeNumber, isAreaIncharge);
        }


        /// <summary>
        /// This method is written to be used as a BL component in UI layer for entrering schedule Date wise.
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
            return objRost.InsertDataOfDate(connectionString, clientCode, asmtId, postCode, employeeNumber, dutyDate, shiftCode, weekNo, shiftPatternCode, patternPosition, timeFrom, timeTo, scheduleRosterAutoId, rowNumber, screenType, fromDate, toDate, currentSessionId, locationAutoId, modifiedBy, clientName, assignmentName, postName);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting employee existing schedule.
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

            return objRost.EmployeesScheduleGet(connectionString, companyCode, hrLocationCode, locationCode, fromDate, toDate, areaId, areaIncharge, isAreaIncharge);

        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for deleting employee schedule.
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

            DataSet ds = objRost.DeleteSchedule(strCon, scheduleRosterAutoID, employeeNumber, fromDate, toDate, clientCode, asmtId, postCode, shiftPatternCode, patternPosition, rowNumber, attendanceType);
            return ds;
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer to get existing schedule of employees.
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

            return objRost.GetEmployeeSchedule(strCon, intLocationAutoId, strEmployeeNumber, strFromDate, strToDate, strAttendanceType, strAreaID, strAreaIncharge, strIsAreaIncharge);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer to overwrite schedule if duplicate exists.
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
            return objRost.OverwriteSchedule(comnnectionString, clientCode, asmtId, postCode, employeeNumber, weekNumber, locationAutoId, modifiedBy, scheduleToOverwriteXml, attendanceType);
        }

        #endregion

        #region Employee related

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting employee details before schedule the employee.
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

            DataSet ds = objRost.GetEmployeeDetail(connectionString, employeeNumber, clientCode, asmtId, fromDate, toDate, postCode, insertStatus, areaId, areaInchargeNumber, isAreaIncharge, screenType, companyCode, hrLocationCode, locationAutoId, modifiedBy);
            return ds;
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting employee count client and post wise.
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

            return objRost.GetEmployeeCountClientAndPostWise(strComnnectionString, strCompanyCode, strHrlocationCode, strLocationCode, strAttendanceType, strPostCode, strFromDate, strToDate, strAsmtCode, clientCode);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting employee total hours client and post wise.
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

            return objRost.GetEmployeeCountClientWiseAndpostWise(strComnnectionString, strCompanyCode, strHrlocationCode, strLocationCode, strAttendanceType, strPostCode, strFromDate, strToDate, strAsmtCode, clientCode);
        }

        #endregion

        #region Method related to Shift Break

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting detail of shift break (job break).
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

            return objRost.GetJobBreakDownSummary(strCon, strCompanyCode, strHrLocationCode, strLocationCode, strSchRosterAutoId, strAttendanceType, strAreaID, strAreaIncharge, strIsAreaIncharge, strFromDate, strToDate, selectedDate, clientCode, asmtid, postCode, employeeNumber);
        }

        #endregion

        #region Methods related to clients and assignments

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting clients detail.
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

            return objRost.GetAllClients(strCon, locationAutoId, areaId, clientCode, employeeNumber, isAreaIncharge, fromDate, toDate);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting assignments of client.
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

            return objRost.GetAllAssignments(strCon, locationAutoId, clientCode, fromDate, toDate, employeeNumber, isAreaIncharge, areaId);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting shifts of assignment.
        /// </summary>
        /// <param name="strCon">The string con.</param>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="intWeekNo">The int week no.</param>
        /// <param name="postCode">The post code.</param>
        /// <returns>System.String.</returns>
        public string AllShiftsOfAsmt(string strCon, int LocationAutoId, string strAsmtCode, int intWeekNo, string postCode)
        {

            return objRost.AllShiftsOfAsmt(strCon, LocationAutoId, strAsmtCode, intWeekNo, postCode);
        }

        #endregion

        #region Methods related to Lock & UnLock

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

            return objRost.GetAllLockUnLockStatus(strCon, clientCode, asmtId, locationAutoID, fromDate, toDate);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for locking employee schedule.
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

            DataSet ds = objRost.LockSchedule(connectionString, clientCode, asmtId, postCode, fromDate, toDate, locationAutoId, modifiedBy);
            return ds;
        }

        #endregion

        #region Miscellaneous methods

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for changing duty type of existing schedule.
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

            return objRost.ChangeDutyType(strCon, strSchAutoId, strDutyType, strAttendanceType, strModifiedBy, companyCode);
        }


        /// <summary>
        /// This method is not handle properly
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

            return objRost.AsmtScheduleCopy(strCon, nWeek, strAsmtCode, strFromDate, strToDate, strAttendanceType, strModifiedBy, pdLineNo);
        }

        /// <summary>
        /// Copy the Schedules.
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

            return objRost.ScheduleCopy(strCon, nWeek, strEmployeeNumber, strSchAutoIds, strFromDate, strToDate, strPatCode, strPos, strDefalt, strRowNumber, strAttendanceType, strModifiedBy);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting shifts based on selected date.
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

            return objRost.GetAllShiftsOfDay(strComnnectionString, clientCode, asmtId, strLocationAutoID, dutyDate, weekNumber, postCode);

        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting posts based on selected assignment.
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

            return objRost.GetAllPostOfAssignment(strComnnectionString, clientCode, AsmtId, locationAutoID, fromDate, toDate);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for serching post Id.
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

            return objRost.SearchPostID(strComnnectionString, strLocationAutoID, strFromDate, strToDate, strAreaID, strAreaIncharge, strIsAreaIncharge);
        }


        /// <summary>
        /// This method is written to be used as a BL component in UI layer for confirming employee attendance.
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

            return objRost.ConfirmAttendance(connectionString, clientCode, asmtCode, postCode, fromDate, toDate, locationAutoId, modifiedBy);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting assignment, client and post based on asmt auto id.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="otherAssignmentDetail">The other assignment detail.</param>
        /// <returns>System.String.</returns>
        public string GetAssignmentClientAndPostBasedOnAsmtAutoId(string connectionString, string otherAssignmentDetail)
        {

            return objRost.GetAssignmentClientAndPostBasedOnAsmtAutoId(connectionString, otherAssignmentDetail);
        }


        /// <summary>
        /// This method is written to be used as a BL component in UI layer for copying rota from one date to next date.
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

            DataSet ds = objRost.CopyData(connectionString, clientCode, asmtId, postCode, weekNo, schRosterAutoID, screenType, currentSession, modifiedBy, fromDate, toDate, employeeNumber, clientName, asmtName, postDesc);
            return ds;
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting sale order deployment detail.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="post">The post.</param>
        /// <returns>System.String.</returns>
        public string ShowSaleOrderDeployment(string connectionString, string locationAutoId, string clientCode, string asmtId, string post)
        {

            return objRost.ShowSaleOrderDeployment(connectionString, locationAutoId, clientCode, asmtId, post);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting existing shift patterns.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="post">The post.</param>
        /// <returns>System.String.</returns>
        public string GetAllShiftPattern(string connectionString, string locationAutoId, string clientCode, string asmtId, string post)
        {

            return objRost.GetAllShiftPattern(connectionString, locationAutoId, clientCode, asmtId, post);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer to get post wise shift detail.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="SoNo">The so no.</param>
        /// <param name="SoLineNo">The so line no.</param>
        /// <param name="SoAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetPostWiseShiftDetail(string connectionString, string SoNo, string SoLineNo, string SoAmendNo)
        {

            DataSet ds = objRost.GetPostWiseShiftDetail(connectionString, SoNo, SoLineNo, SoAmendNo);
            return ds;
        }

        #endregion

        #region methods related to Adjustment

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for adding adjustment hours.
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

            DataSet ds = objRost.AdjustmentHoursInsert(connectionString, clientCode, asmtId, postCode, locationAutoId, adjustmentDate, employeeNumber, adjustmentFromDate, adjustmentHours, adjustmentHead, remark, modifiedBy);
            return ds;
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting adjustment hours.
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

            return objRost.AdjustmentHoursGet(connectionString, clientCode, asmtId, postCode, adjustmentDate, employeeNumber);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for deleting adjustment hours.
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

            DataSet ds = objRost.AdjustmentHoursDelete(connectionString, clientCode, asmtId, postCode, adjustmentDate, employeeNumber);
            return ds;
        }

        #endregion

        #region Duty replacement

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for replacying duty (delete).
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="autoId">The automatic identifier.</param>
        /// <returns>System.String.</returns>
        public string DutyReplacementDelete(string connectionString, string autoId)
        {

            return objRost.DutyReplacementDelete(connectionString, autoId);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for replacying duty (Update).
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="autoId">The automatic identifier.</param>
        /// <param name="reason">The reason.</param>
        /// <returns>System.String.</returns>
        public string DutyReplacementUpdate(string connectionString, string autoId, string reason)
        {

            return objRost.DutyReplacementUpdate(connectionString, autoId, reason);
        }

        #endregion

        #region Legends

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting legends details.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLegends(string connectionString, string companyCode)
        {

            DataSet ds = objRost.GetLegends(connectionString, companyCode);
            return ds;
        }

        #endregion

        #region Methods related to Week

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting weeks of seleced month.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>System.String.</returns>
        public string GetWeek(string connectionString, string locationAutoId, string month, string year)
        {

            return objRost.GetWeek(connectionString, locationAutoId, month, year);
        }

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for applying weekly off.
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

            return objRost.ApplyWeekOff(strCon, clientCode, asmtId, postCode, LocationAutoId, strEmployeeNumber, strDutyDate, strModifiedBy, strShiftPat, shiftPos, strRowNumber, strAttendanceType, schrosterAutoId);
        }

        #endregion

        #region Function related to Area

        /// <summary>
        /// This method is written to be used as a BL component in UI layer for getting Areas.
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

            return objRost.GetAllArea(connectionString, locationAutoId, employeeNumber, isAreaIncharge, fromDate, toDate);
        }

        #endregion

        //// ----------------------------
    }
}
