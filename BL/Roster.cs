// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Roster.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class contains Methods related to rostering module.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Roster
    {
        #region Function Related to Create Pattern Screen For Employee Wise Scheduling
        /// <summary>
        /// To Get the site postcode of assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="sytemParameterValue">The sytem parameter value.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtSitePostGet(string locationAutoId, string clientCode, string asmtId, string postCode, string sytemParameterValue, string fromDate, string toDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.AsmtSitePostGet(locationAutoId, clientCode, asmtId, postCode, sytemParameterValue, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// To Get shift patterrn of assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtNo">The asmt no.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtShiftPatternGet(string locationAutoId, string asmtNo)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.AsmtShiftPatternGet(locationAutoId, asmtNo);
            return ds;
        }
        /// <summary>
        /// Update Pattern Sequence
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="patternSeqAutoId">The pattern seq automatic identifier.</param>
        /// <param name="isActive">The is active.</param>
        /// <returns>DataSet</returns>
        public DataSet PatternsSequenceUpdate(string locationAutoId, string patternSeqAutoId, Boolean isActive)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.PatternsSequenceUpdate(locationAutoId, patternSeqAutoId, isActive);
            return ds;
        }
        /// <summary>
        /// To Get shift pattern of assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="showAllStatus">The show all status.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtShiftPatternGetAll(string locationAutoId, string clientCode, string asmtId, string postCode, string showAllStatus)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.AsmtShiftPatternGetAll(locationAutoId, clientCode, asmtId, postCode, showAllStatus);
            return ds;
        }

        /// <summary>
        /// To Get pattern sequence of assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtNo">The asmt no.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtPatternSequenceGet(string locationAutoId, string asmtNo)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.AsmtPatternSequenceGet(locationAutoId, asmtNo);
            return ds;
        }

        /// <summary>
        /// To Get pattern sequence on the basis of sequence Id
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="patternSequenceAutoId">The pattern sequence automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtShiftPatternSequenceGet(string clientCode, string asmtId, string patternSequenceAutoId, string locationAutoId)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.AsmtShiftPatternSequenceGet(clientCode, asmtId, patternSequenceAutoId, locationAutoId);
            return ds;
        }

        /// <summary>
        /// To Create a new shift pattern
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="shiftPatternId">The shift pattern identifier.</param>
        /// <param name="shiftPattern">The shift pattern.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="action">The action.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtShiftPatternSave(string locationAutoId, string clientCode, string asmtId, string shiftPatternId, string shiftPattern, string shiftPatternCode, string action, string status, string modifiedBy)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.AsmtShiftPatternSave(locationAutoId, clientCode, asmtId, shiftPatternId, shiftPattern, shiftPatternCode, action, status, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To Create new shift pattern sequence
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="patternSequenceAutoId">The pattern sequence automatic identifier.</param>
        /// <param name="patternSequenceCode">The pattern sequence code.</param>
        /// <param name="shiftPatternSequence">The shift pattern sequence.</param>
        /// <param name="action">The action.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtShiftPatternSequenceSave(string locationAutoId, string clientCode, string asmtId, string patternSequenceAutoId, string patternSequenceCode, string shiftPatternSequence, string action, string modifiedBy)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.AsmtShiftPatternSequenceSave(locationAutoId, clientCode, asmtId, patternSequenceAutoId, patternSequenceCode, shiftPatternSequence, action, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Delete Pattern Sequence
        /// </summary>
        /// <param name="patternSequenceAutoId">The pattern sequence automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftPatternSequenceDelete(string patternSequenceAutoId, int locationAutoId)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.AsmtShiftPatternSequenceDelete(patternSequenceAutoId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Get All Sequence for Lock Unlock
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet</returns>
        public DataSet PatternSequenceGet(String locationAutoId, String asmtCode)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.PatternSequenceGet(locationAutoId, asmtCode);
            return ds;
        }
        /// <summary>
        /// To Split Patterns from Sequence
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="patternSeqAutoId">The pattern seq automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet SplitPatternsFromSequence(String locationAutoId, String patternSeqAutoId)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.SplitPatternsFromSequence(locationAutoId, patternSeqAutoId);
            return ds;
        }
        /// <summary>
        /// To Create a new shift pattern from existing shift pattern using copy
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtNo">The asmt no.</param>
        /// <param name="shiftPatternId">The shift pattern identifier.</param>
        /// <param name="userShiftPattern">The user shift pattern.</param>
        /// <param name="copyToAsmt">The copy to asmt.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtCopyShiftPatternSave(string locationAutoId, string asmtNo, string shiftPatternId, string userShiftPattern, string copyToAsmt, string flag)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.AsmtCopyShiftPatternSave(locationAutoId, asmtNo, shiftPatternId, userShiftPattern, copyToAsmt, flag);
            return ds;
        }

        /// <summary>
        /// To Delete existing shift pattern
        /// </summary>
        /// <param name="shiftPattern">The shift pattern.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtShiftPatternDelete(string shiftPattern, string clientCode, string asmtId, int locationAutoId)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AsmtShiftPatternDelete(shiftPattern, clientCode, asmtId, locationAutoId);
            return ds;

        }

        /// <summary>
        /// To Get Shift Code and PDLine No Based on Shift Pattern Id.
        /// </summary>
        /// <param name="locationAutoId">The STR location auto Id.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="shiftPatternId">The STR shift pattern Id.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtShiftPatternGet(string locationAutoId, string clientCode, string asmtId, string shiftPatternId)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AsmtShiftPatternGet(locationAutoId, clientCode, asmtId, shiftPatternId);
            return ds;
        }
        #endregion

        #region Function Related to New Scheduling Screen Employee Wise
        /// <summary>
        /// To Insert Data in Scheduling Table by applying Pattern
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="defaultSite">if set to <c>true</c> [default site].</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="weekNo">The week no.</param>
        /// <returns>dataSet</returns>
        public DataSet EmployeeScheduleInsert(string asmtCode, string fromDate, string toDate, bool defaultSite, string employeeNumber, string designationCode, string shiftPatternCode, int patternPosition, string soRank, string locationAutoId, string modifiedBy, int rowNumber, string postcode, string sessionId, string weekNo)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.EmployeeScheduleInsert(asmtCode, fromDate, toDate, defaultSite, employeeNumber, designationCode, shiftPatternCode, patternPosition, soRank, locationAutoId, modifiedBy, rowNumber, postcode, sessionId, weekNo);
            return ds;

        }

        /// <summary>
        /// Insert Data Single Date DATA in Scheduling Screen.
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="weekNo">The int weekNo.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The STR designation code.</param>
        /// <param name="shiftPatternCode">The STR shift pattern code.</param>
        /// <param name="patternPosition">The STR pattern position.</param>
        /// <param name="defaultSite">The STR default site.</param>
        /// <param name="operationShift">The operation shift.</param>
        /// <param name="soRank">The STR SO rank.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="scheduleRosterAutoId">The int schedule roster auto Id.</param>
        /// <param name="pdLineNo">The PD line no.</param>
        /// <param name="locationAutoId">The STR location auto Id.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="postcode">The STR postcode.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="sessionValue">The STR session value.</param>
        /// <returns>datSet</returns>
        public DataSet NewScheduleRosterInsert(string asmtCode, string employeeNumber, string dutyDate, string shiftCode, int weekNo, string roleCode, string designationCode, string shiftPatternCode, string patternPosition, string defaultSite, string operationShift, string soRank, string timeFrom, string timeTo, string dutyTypeCode, int scheduleRosterAutoId, int pdLineNo, string locationAutoId, string modifiedBy, int rowNumber, string postcode, string fromDate, string toDate, string sessionValue)
        {

            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.NewScheduleRosterInsert(asmtCode, employeeNumber, dutyDate, shiftCode, weekNo, roleCode, designationCode, shiftPatternCode, patternPosition, defaultSite, operationShift, soRank, timeFrom, timeTo, dutyTypeCode, scheduleRosterAutoId, pdLineNo, locationAutoId, modifiedBy, rowNumber, postcode, fromDate, toDate, sessionValue);
            return ds;

        }

        /// <summary>
        /// Function to overwrite Shift.
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="weekNo">The int weekNo.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The STR designation code.</param>
        /// <param name="shiftPatternCode">The STR shift pattern code.</param>
        /// <param name="patternPosition">The STR pattern position.</param>
        /// <param name="defaultSite">The STR default site.</param>
        /// <param name="operationShift">The operation shift.</param>
        /// <param name="soRank">The STR SO rank.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="scheduleRosterAutoId">The int schedule roster auto Id.</param>
        /// <param name="pdLineNo">The PD line no.</param>
        /// <param name="locationAutoId">The STR location auto Id.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="duplicateScheduleRosterAutoId">The STR dup SCH roster auto Id.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <returns>dataSet</returns>
        public DataSet NewScheduleRosterShiftOverwrite(string asmtCode, string employeeNumber, string dutyDate, string shiftCode, int weekNo, string roleCode, string designationCode, string shiftPatternCode, string patternPosition, string defaultSite, string operationShift, string soRank, string timeFrom, string timeTo, string dutyTypeCode, int scheduleRosterAutoId, int pdLineNo, string locationAutoId, string modifiedBy, string duplicateScheduleRosterAutoId, int rowNumber, string fromDate, string toDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.NewScheduleRosterShiftOverwrite(asmtCode, employeeNumber, dutyDate, shiftCode, weekNo, roleCode, designationCode, shiftPatternCode, patternPosition, defaultSite, operationShift, soRank, timeFrom, timeTo, dutyTypeCode, scheduleRosterAutoId, pdLineNo, locationAutoId, modifiedBy, duplicateScheduleRosterAutoId, rowNumber, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// To Delete a single record of schedule on the basis of Id
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>dataSet</returns>
        public DataSet NewScheduleRosterDelete(string scheduleRosterAutoId, int rowNumber)
        {

            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.NewScheduleRosterDelete(scheduleRosterAutoId, rowNumber);
            return ds;
        }

        /// <summary>
        /// To Delete schedule row of an employee
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>dataSet</returns>
        public DataSet EmployeeWiseScheduleDelete(string employeeNumber, string asmtCode, string fromDate, string toDate, string shiftPatternCode, int patternPosition, int rowNumber)
        {

            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.EmployeeWiseScheduleDelete(employeeNumber, asmtCode, fromDate, toDate, shiftPatternCode, patternPosition, rowNumber);
            return ds;
        }

        /// <summary>
        /// To Get schedule record(s) of an employee
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="searchEmployeeNumber">The search employee number.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>

        public DataSet EmployeeWiseScheduleRosterGetAll(string clientCode, string asmtId, string locationAutoId, string fromDate, string toDate, string postcode, string attendanceType, string searchEmployeeNumber, string pageNumber, string areaId, string areaIncharge, string isAreaIncharge)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.EmployeeWiseScheduleRosterGetAll(clientCode, asmtId, locationAutoId, fromDate, toDate, postcode, attendanceType, searchEmployeeNumber, pageNumber, areaId, areaIncharge, isAreaIncharge);
            return ds;
        }


        /// <summary>
        /// To Get list of shift names of an assignment
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="weekNo">The week no.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleRosterEmployeeWiseGetShift(string asmtCode, string locationAutoId, string dutyDate, string weekNo)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.ScheduleRosterEmployeeWiseGetShift(asmtCode, locationAutoId, dutyDate, weekNo);
            return ds;
        }

        /// <summary>
        /// To Get total schedule hours of an employee
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>dataSet</returns>
        public DataTable TotalHoursOfEmployeeGet(string fromDate, string toDate, string employeeNumber, string locationAutoId)
        {
            DL.Roster objRoster = new DL.Roster();
            DataTable ds = objRoster.TotalHoursOfEmployeeGet(fromDate, toDate, employeeNumber, locationAutoId);
            return ds;
        }

        /// <summary>
        /// To Get system parameter values
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="monthStartDate">The month start date.</param>
        /// <param name="scheduleType">Type of the schedule.</param>
        /// <returns>dataTable</returns>
        public DataTable SystemParametersGet(string companyCode, string hrLocationCode, string locationCode, string monthStartDate, string scheduleType)
        {
            DL.Roster objRoster = new DL.Roster();
            DataTable dataTable = objRoster.SystemParametersGet(companyCode, hrLocationCode, locationCode, monthStartDate, scheduleType);
            return dataTable;
        }

        /// <summary>
        /// To get the Allow Borrow Employee System Parameters Value
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataTable.</returns>
        public DataTable AllowBorrowEmployeeSystemParametersGet(string companyCode)
        {
            DL.Roster objRoster = new DL.Roster();
            DataTable dataTable = objRoster.AllowBorrowEmployeeSystemParametersGet(companyCode);
            return dataTable;

        }

        /// <summary>
        /// Get Max Duty Min in A weekNo
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>dataTable</returns>
        public DataSet MaxDutyMinutesInWeekGet(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet dataTable = objRoster.MaxDutyMinutesInWeekGet(companyCode, hrLocationCode, locationCode);
            return dataTable;

        }

        /// <summary>
        /// Get Max Duty Min in A weekNo
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>dataTable</returns>
        public DataSet GetOTAndMaxDutyMinutesInWeekGet(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet dataTable = objRoster.GetOTAndMaxDutyMinutesInWeekGet(companyCode, hrLocationCode, locationCode);
            return dataTable;

        }

        /// <summary>
        /// To Get all Break Hrs of the Employee on a given Date..
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR SCH roster auto Id.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="areaId">The STR area Id.</param>
        /// <param name="areaIncharge">The STR area incharge.</param>
        /// <param name="isAreaIncharge">The STR is area incharge.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <returns>dataSet</returns>
        public DataSet BreakHoursGetAll(string scheduleRosterAutoId, string companyCode, string hrLocationCode, string locationCode, string attendanceType, string areaId, string areaIncharge, string isAreaIncharge, string fromDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.BreakHoursGetAll(scheduleRosterAutoId, companyCode, hrLocationCode, locationCode, attendanceType, areaId, areaIncharge, isAreaIncharge, fromDate);
            return ds;
        }

        /// <summary>
        /// To Insert Break Hrs..
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR schedule roster auto Id.</param>
        /// <param name="scheduleRosterNewAutoId">The STR new emp SCH roster auto Id.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="employeeNumberReplace">The STR employee number rep.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="status">The STR status.</param>
        /// <param name="isPayable">if set to <c>true</c> [is payable].</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="operationType">Type of the STR operation.</param>
        /// <param name="breakHourAutoId">The break hour auto Id.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="assignmentName">Name of the assignment.</param>
        /// <param name="postDesc">The post desc.</param>
        /// <param name="weekNo">The week no.</param>
        /// <returns>dataSet</returns>
        public DataSet BreakHoursInsert(string scheduleRosterAutoId, string scheduleRosterNewAutoId, string employeeNumber, string employeeNumberReplace, string dutyDate, string timeFrom, string timeTo, string status, bool isPayable, string modifiedBy, string attendanceType, string operationType, string breakHourAutoId, string clientCode, string asmtId, string postCode, string clientName, string assignmentName, string postDesc, string weekNo)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.BreakHoursInsert(scheduleRosterAutoId, scheduleRosterNewAutoId, employeeNumber, employeeNumberReplace, dutyDate, timeFrom, timeTo, status, isPayable, modifiedBy, attendanceType, operationType, breakHourAutoId, clientCode, asmtId, postCode, clientName, assignmentName, postDesc, weekNo);
            return ds;
        }

        /// <summary>
        /// To Check if Rule Exists and Check that Rule
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="maxBreakHours">The maximum break hours.</param>
        /// <param name="breakAutoID">The break automatic identifier.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckBreakHoursRule(string scheduleRosterAutoId, string timeFrom, string timeTo, string maxBreakHours,string breakAutoID,string attendanceType)
        {
            var objRoster = new DL.Roster();

            DataSet ds = objRoster.CheckBreakHoursRule(scheduleRosterAutoId, timeFrom, timeTo, maxBreakHours, breakAutoID, attendanceType);
            return ds;
        }
        /// <summary>
        /// To Update Break Hours.
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster auto Id.</param>
        /// <param name="replacedScheduleRosterAutoId">The replaced SCH roster auto Id.</param>
        /// <param name="newEmployeeNumber">The new employee number.</param>
        /// <param name="fromTime">From time.</param>
        /// <param name="toTime">To time.</param>
        /// <param name="isPayable">if set to <c>true</c> [is payable].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="attendanceType">The attendanceType.</param>
        /// <param name="breakHourAutoId">The break hour auto Id.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>dataSet</returns>
        public DataSet BreakHoursUpdate(string scheduleRosterAutoId, string replacedScheduleRosterAutoId, string newEmployeeNumber, string fromTime, string toTime, bool isPayable, string modifiedBy, string attendanceType, string breakHourAutoId, string dutyDate)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet dsUpdate = objRoster.BreakHoursUpdate(scheduleRosterAutoId, replacedScheduleRosterAutoId, newEmployeeNumber, fromTime, toTime, isPayable, modifiedBy, attendanceType, breakHourAutoId, dutyDate);
            return dsUpdate;
        }


        /// <summary>
        /// To Delete Break Hours.
        /// </summary>
        /// <param name="breakHourAutoId">The break hour auto Id.</param>
        /// <param name="scheduleRosterAutoId">The schedule roster auto Id.</param>
        /// <param name="replacedScheduleRosterAutoId">The replaced SCH roster auto Id.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>dataSet</returns>
        public DataSet BreakHoursDelete(string breakHourAutoId, string scheduleRosterAutoId, string replacedScheduleRosterAutoId, string attendanceType)
        {
            DL.Roster objRoster = new DL.Roster();
            DataSet dsDelete = objRoster.BreakHoursDelete(breakHourAutoId, scheduleRosterAutoId, replacedScheduleRosterAutoId, attendanceType);
            return dsDelete;
        }

        /// <summary>
        /// To get monthly schedule
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleEmployeeWiseGet(string month, string year)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.ScheduleEmployeeWiseGet(month, year);
            return ds;
        }

        /// <summary>
        /// To Get Role transaction and Role MAster based on Area Id.
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR SCH roster auto Id.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="areaId">The STR area Id.</param>
        /// <param name="areaIncharge">The STR area incharge.</param>
        /// <param name="isAreaIncharge">The STR is area incharge.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <returns>dataSet</returns>
        public DataSet RoleGetAll(string scheduleRosterAutoId, string companyCode, string hrLocationCode, string locationCode, string attendanceType, string areaId, string areaIncharge, string isAreaIncharge, string fromDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.RoleGetAll(scheduleRosterAutoId, companyCode, hrLocationCode, locationCode, attendanceType, areaId, areaIncharge, isAreaIncharge, fromDate);
            return ds;
        }

        /// <summary>
        /// To Insert duty Role of employee
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>dataSet</returns>
        public DataSet RoleInsert(string scheduleRosterAutoId, string roleCode, string timeFrom, string timeTo, string dutyDate, string locationAutoId, string modifiedBy, string attendanceType)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.RoleInsert(scheduleRosterAutoId, roleCode, timeFrom, timeTo, dutyDate, locationAutoId, modifiedBy, attendanceType);
            return ds;
        }

        /// <summary>
        /// To update employee duty Role
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="roleAutoId">The role automatic identifier.</param>
        /// <returns>dataSet</returns>
        public DataSet RoleUpdate(string scheduleRosterAutoId, string roleCode, string timeFrom, string timeTo, string dutyDate, string locationAutoId, string modifiedBy, string attendanceType, string roleAutoId)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.RoleUpdate(scheduleRosterAutoId, roleCode, timeFrom, timeTo, dutyDate, locationAutoId, modifiedBy, attendanceType, roleAutoId);
            return ds;
        }

        /// <summary>
        /// To Delete Role
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="roleAutoId">The role automatic identifier.</param>
        /// <returns>dataSet</returns>
        public DataSet RoleDelete(string scheduleRosterAutoId, string dutyDate, string attendanceType, string roleAutoId)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.RoleDelete(scheduleRosterAutoId, dutyDate, attendanceType, roleAutoId);
            return ds;
        }
        #region Task Master Related Objects
        /// <summary>
        /// To Get Task transaction and Task MAster based on Area Id.
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR SCH roster auto Id.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="areaId">The STR area Id.</param>
        /// <param name="areaIncharge">The STR area incharge.</param>
        /// <param name="isAreaIncharge">The STR is area incharge.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <returns>dataSet</returns>
        public DataSet TaskGetAll(string scheduleRosterAutoId, string companyCode, string hrLocationCode, string locationCode, string attendanceType, string areaId, string areaIncharge, string isAreaIncharge, string fromDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.TaskGetAll(scheduleRosterAutoId, companyCode, hrLocationCode, locationCode, attendanceType, areaId, areaIncharge, isAreaIncharge, fromDate);
            return ds;
        }
        /// <summary>
        /// To Delete Task
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="taskAutoId">The task automatic identifier.</param>
        /// <param name="trnTaskAutoID">The TRN task automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TaskDelete(string scheduleRosterAutoId, string dutyDate, string attendanceType, string taskAutoId, string trnTaskAutoID)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.TaskDelete(scheduleRosterAutoId, dutyDate, attendanceType, taskAutoId, trnTaskAutoID);
            return ds;
        }
        /// <summary>
        /// To update employee duty Task
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR schedule roster auto ID.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="taskAutoId">The STR Task auto ID.</param>
        /// <param name="trnTaskAutoID">The TRN task automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TaskUpdate(string scheduleRosterAutoId, string timeFrom, string timeTo, string dutyDate, string modifiedBy, string attendanceType, string taskAutoId, string trnTaskAutoID)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.TaskUpdate(scheduleRosterAutoId, timeFrom, timeTo, dutyDate, modifiedBy, attendanceType, taskAutoId, trnTaskAutoID);
            return ds;
        }
        /// <summary>
        /// To Insert duty Task of employee
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR schedule roster auto ID.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="taskAutoId">The STR Task auto ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet TaskInsert(string scheduleRosterAutoId, string timeFrom, string timeTo, string dutyDate, string modifiedBy, string attendanceType, string taskAutoId)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.TaskInsert(scheduleRosterAutoId, timeFrom, timeTo, dutyDate, modifiedBy, attendanceType, taskAutoId);
            return ds;
        }
        #endregion
        /// <summary>
        /// To Get posts of an assignmnet
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>dataSet</returns>
        public DataSet PostGetAll(string clientCode, string asmtId, string locationAutoId, string fromDate, string toDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.PostGetAll(clientCode, asmtId, locationAutoId, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// Get Borrowed Employees Details.
        /// </summary>
        /// <param name="employeeNumber">The emp number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="postcode">The postcode code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">The hf to date.</param>
        /// <param name="maximumDate">The hf max date.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>dataSet</returns>
        public DataSet BorrowedEmployeeDetailsGet(string employeeNumber, string clientCode, string asmtId, string locationAutoId, string postcode, string fromDate, string toDate, string maximumDate, string areaId, string areaIncharge, string isAreaIncharge)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.BorrowedEmployeeDetailsGet(employeeNumber, clientCode, asmtId, locationAutoId, postcode, fromDate, toDate, maximumDate, areaId, areaIncharge, isAreaIncharge);
            return ds;
        }
        #endregion

        #region Function Related Rota to New Scheduling Screen Employee Wise
        /// <summary>
        /// To Get roster (attendance) of postcode.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="searchEmployeeNumber">The search employee number.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>dataSet</returns>

        public DataSet RosterEmployeeWiseGetAll(string clientCode, string asmtId, string locationAutoId, string fromDate, string toDate, string postcode, string attendanceType, string searchEmployeeNumber, string pageNumber, string areaId, string areaIncharge, string isAreaIncharge)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.RosterEmployeeWiseGetAll(clientCode, asmtId, locationAutoId, fromDate, toDate, postcode, attendanceType, searchEmployeeNumber, pageNumber, areaId, areaIncharge, isAreaIncharge);
            return ds;
        }


        /// <summary>
        /// To Insert Single Shift In Actual Mode.
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="weekNo">The int weekNo.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The STR designation code.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="rosterAutoId">The int roster auto Id.</param>
        /// <param name="pdLineNo">The PD line no.</param>
        /// <param name="locationAutoId">The STR location auto Id.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="postcode">The STR postcode.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="sessionId">The STR session Id.</param>
        /// <param name="ShiftPatternCode">The shift pattern code.</param>
        /// <param name="PatternPosition">The pattern position.</param>
        /// <returns>dataSet</returns>
        public DataSet RosterEmployeeWiseInsert(string asmtCode, string employeeNumber, string dutyDate, string shiftCode, int weekNo, string roleCode, string designationCode, string timeFrom, string timeTo, string dutyTypeCode, int rosterAutoId, int pdLineNo, string locationAutoId, string modifiedBy, int rowNumber, string postcode, string fromDate, string toDate, string sessionId, string ShiftPatternCode, string PatternPosition)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.RosterEmployeeWiseInsert(asmtCode, employeeNumber, dutyDate, shiftCode, weekNo, roleCode, designationCode, timeFrom, timeTo, dutyTypeCode, rosterAutoId, pdLineNo, locationAutoId, modifiedBy, rowNumber, postcode, fromDate, toDate, sessionId, ShiftPatternCode, PatternPosition);
            return ds;

        }

        /// <summary>
        /// To OverWrite duplicates schedule records
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyTypeCode">The duty type code.</param>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="duplicateRosterAutoId">The duplicate roster automatic identifier.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>dataSet</returns>
        public DataSet OverwriteDuplicateRota(string asmtCode, string employeeNumber, string dutyDate, string shiftCode, int weekNo, string roleCode, string designationCode, string timeFrom, string timeTo, string dutyTypeCode, int rosterAutoId, int pdLineNo, string locationAutoId, string modifiedBy, string duplicateRosterAutoId, int rowNumber, string fromDate, string toDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.OverwriteDuplicateRota(asmtCode, employeeNumber, dutyDate, shiftCode, weekNo, roleCode, designationCode, timeFrom, timeTo, dutyTypeCode, rosterAutoId, pdLineNo, locationAutoId, modifiedBy, duplicateRosterAutoId, rowNumber, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// To Delete rota
        /// </summary>
        /// <param name="rosterAutoId">The roster auto Id.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="locationAutoId">The STR location auto Id.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <returns>dataSet</returns>
        public DataSet NewRosterDelete(string rosterAutoId, int rowNumber, string dutyDate, string employeeNumber, string locationAutoId, string asmtCode)
        {

            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.NewRosterDelete(rosterAutoId, rowNumber, dutyDate, employeeNumber, locationAutoId, asmtCode);
            return ds;
        }

        /// <summary>
        /// To Delete Rota
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>dataSet</returns>
        public DataSet EmployeeWiseRotaDelete(string employeeNumber, string asmtCode, string fromDate, string toDate, int rowNumber)
        {

            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.EmployeeWiseRotaDelete(employeeNumber, asmtCode, fromDate, toDate, rowNumber);
            return ds;
        }

        /// <summary>
        /// To Insert rota     patternwise
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <returns>dataSet</returns>
        public DataSet RosterEmployeeWiseInsertPattern(string asmtCode, string fromDate, string toDate, string employeeNumber, string designationCode, string shiftPatternCode, int patternPosition, string locationAutoId, string modifiedBy, int rowNumber, string postcode)
        {

            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.RosterEmployeeWiseInsertPattern(asmtCode, fromDate, toDate, employeeNumber, designationCode, shiftPatternCode, patternPosition, locationAutoId, modifiedBy, rowNumber, postcode);
            return ds;

        }

        /// <summary>
        /// To Get total Additional Hours
        /// </summary>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="postcode">The STR postcode code.</param>
        /// <param name="locationAutoId">The STR location auto Id.</param>
        /// <returns>dataSet</returns>
        public DataSet EmployeeWiseTotalAdditionalHoursGet(string fromDate, string toDate, string clientCode, string asmtCode, string postcode, string locationAutoId)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.EmployeeWiseTotalAdditionalHoursGet(fromDate, toDate, clientCode, asmtCode, postcode, locationAutoId);
            return ds;

        }

        /// <summary>
        /// To Search Employee who match or who dont match the Skills entered in Sale Order
        /// </summary>
        /// <param name="asmtCode">The asmtCode.</param>
        /// <param name="postcode">The postcode code.</param>
        /// <param name="locationAutoId">The location auto Id.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaId">The area Id.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="searchEmployeeNumber">The search employee number.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleEmployeeWiseSkillsMatchMismatchGet(string asmtCode, string postcode, string locationAutoId, string fromDate, string toDate, string areaId, string isAreaIncharge, string areaIncharge, string pageNumber, string pageSize, string searchEmployeeNumber)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.ScheduleEmployeeWiseSkillsMatchMismatchGet(asmtCode, postcode, locationAutoId, fromDate, toDate, areaId, isAreaIncharge, areaIncharge, pageNumber, pageSize, searchEmployeeNumber);
            return ds;
        }
        #endregion

        #region Function Related to Schedule

        #region Function Related to Get data

        #region Get Required ManPower Information for Scheduling

        /// <summary>
        /// To Get Requred manpower/hours
        /// </summary>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="asmtMasterAutoId">The int asmt master auto id.</param>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="postcode">The STR postcode code.</param>
        /// <param name="scheduleType">Type of the schedule.</param>
        /// <param name="weekNo">The weekNo no.</param>
        /// <returns>dataSet</returns>
        public DataSet ManpowerRequirementGet(string fromDate, string toDate, int asmtMasterAutoId, int locationAutoId, string postcode, string scheduleType, int weekNo)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ManpowerRequirementGet(fromDate, toDate, asmtMasterAutoId, locationAutoId, postcode, scheduleType, weekNo);
            return ds;
        }

        /// <summary>
        /// To Get required person on a postcode
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="element">The element.</param>
        /// <returns>dataSet</returns>
        public DataSet PersonRequiredOnsiteGet(int asmtMasterAutoId, string fromDate, string toDate, int pdLineNo, string element)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.PersonRequiredOnsiteGet(asmtMasterAutoId, fromDate, toDate, pdLineNo, element);
            return ds;
        }

        #endregion

        #region Get Already Scheduled ManPower Information
        /// <summary>
        /// To Get Schedule Hrs/Count
        /// </summary>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="postcode">The STR postcode code.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduledManpowerGet(string fromDate, string toDate, string asmtCode, int locationAutoId, string postcode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduledManpowerGet(fromDate, toDate, asmtCode, locationAutoId, postcode);
            return ds;
        }
        #endregion
        #region Get Actual ManPower Information
        // Created By   :  
        // Dated        : 24-Jan-2012
        // Purpose      : To get Actual on each date for Schedul;ing screen in Actual Mode
        /// <summary>
        /// To Get Actual Manpower
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="postcode">The postcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet ActualManpowerGet(string fromDate, string toDate, string asmtCode, int locationAutoId, string postcode)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.ActualManpowerGet(fromDate, toDate, asmtCode, locationAutoId, postcode);
            return ds;
        }
        #endregion
        #region Get Asmt Items
        /// <summary>
        /// To Get pdLine(site\postcode) of an assignment
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtItemsGet(string fromDate, string toDate, int asmtMasterAutoId, int locationAutoId, string asmtCode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AsmtItemsGet(fromDate, toDate, asmtMasterAutoId, locationAutoId, asmtCode);
            return ds;
        }
        #endregion

        #region Get Asmt Item Detail
        /// <summary>
        /// To Get PdLine(site\postcode) wise details along with shifts
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>dataSet</returns>
        public DataSet AsmtItemDetailGet(int asmtMasterAutoId, string asmtCode, int locationAutoId, int soLineNo, int pdLineNo, string fromDate, string toDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AsmtItemDetailGet(asmtMasterAutoId, asmtCode, locationAutoId, soLineNo, pdLineNo, fromDate, toDate);
            return ds;
        }
        #endregion

        #region Get AsmtShifts
        /// <summary>
        /// Asmts the shift get.
        /// </summary>
        /// <param name="asmtAutoId">The asmt automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftGet(int asmtAutoId, int soLineNo, int pdLineNo)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AsmtShiftGet(asmtAutoId, soLineNo, pdLineNo);
            return ds;
        }
        #endregion

        #region Get Schedule by pdline
        /// <summary>
        /// To Get Schedule (PdLine wise)
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleGet(int locationAutoId, string asmtCode, int pdLineNo, string fromDate, string toDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleGet(locationAutoId, asmtCode, pdLineNo, fromDate, toDate);
            return ds;
        }
        #endregion

        #region Get Shift Patterns
        /// <summary>
        /// To Get Shift pattern(s)
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="shifts">The shifts.</param>
        /// <returns>dataSet</returns>
        public DataSet ShiftPatternsGet(int locationAutoId, string clientCode, string shifts)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ShiftPatternsGet(locationAutoId, clientCode, shifts);
            return ds;
        }

        /// <summary>
        /// To Get Shift Pattern When We Double Click Shift Pattern TextBox in schedule Roster Screen
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>dataSet</returns>
        public DataSet ShiftPatternGet(int locationAutoId, string asmtCode, int pdLineNo)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ShiftPatternGet(locationAutoId, asmtCode, pdLineNo);
            return ds;
        }
        #endregion

        #region Get Info based on locationAutoId,asmtCode,PDLine Number,With Effective date of termination screen
        /// <summary>
        /// To Get schedule records
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="withEffectiveDate">The with effective date.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleRosterGet(string locationAutoId, string asmtCode, string pdLineNo, DateTime withEffectiveDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.ScheduleRosterGet(locationAutoId, asmtCode, pdLineNo, withEffectiveDate);
            return ds;
        }
        #endregion

        #endregion

        #region Function related to Insert data

        #region Insert Schedule Roster
        /// <summary>
        /// To Save schedule records of an employee
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="dutyTypeCode">The duty type code.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="defaultSite">The default site.</param>
        /// <param name="operationShiftCode">The operation shift code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="soRank">The so rank.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleRosterInsert(int asmtMasterAutoId, string asmtCode, int locationAutoId, int pdLineNo, DataTable dataTable, string employeeNumber, string roleCode, string designationCode, string dutyTypeCode, string shiftPatternCode, int patternPosition, string defaultSite, string operationShiftCode, string modifiedBy, string soRank)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleRosterInsert(asmtMasterAutoId, asmtCode, locationAutoId, pdLineNo, dataTable, employeeNumber, roleCode, designationCode, dutyTypeCode, shiftPatternCode, patternPosition, defaultSite, operationShiftCode, modifiedBy, soRank);
            return ds;
        }
        #endregion

        #region Re Schedule
        /// <summary>
        /// To OverWrite existing schedule
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="dutyTypeCode">The duty type code.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="defaultSite">The default site.</param>
        /// <param name="operationShiftCode">The operation shift code.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="concatenatedDetail">The concatenated detail.</param>
        /// <returns>dataSet</returns>
        public DataSet Reschedule(int asmtMasterAutoId, string asmtCode, int locationAutoId, int pdLineNo, string employeeNumber, string roleCode, string designationCode, string dutyTypeCode, string shiftPatternCode, int patternPosition, string defaultSite, string operationShiftCode, string soRank, string modifiedBy, string concatenatedDetail)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.Reschedule(asmtMasterAutoId, asmtCode, locationAutoId, pdLineNo, employeeNumber, roleCode, designationCode, dutyTypeCode, shiftPatternCode, patternPosition, defaultSite, operationShiftCode, soRank, modifiedBy, concatenatedDetail);
            return ds;
        }
        #endregion

        #region Function to OverWrite single Shift
        /// <summary>
        /// To Overwire the shift in existing schedule
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="dutyTypeCode">The duty type code.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="isDefaultSite">The is default site.</param>
        /// <param name="operationShiftCode">The operation shift code.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleRosterShiftOverwrite(string asmtCode, string employeeNumber, DateTime dutyDate, string shiftCode, int pdLineNo, int asmtMasterAutoId, int rosterAutoId, string locationAutoId, string weekNo, string roleCode, string designationCode, string dutyTypeCode, string shiftPatternCode, string patternPosition, string isDefaultSite, string operationShiftCode, string soRank, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleRosterShiftOverwrite(asmtCode, employeeNumber, dutyDate, shiftCode, pdLineNo, asmtMasterAutoId, rosterAutoId, locationAutoId, weekNo, roleCode, designationCode, dutyTypeCode, shiftPatternCode, patternPosition, isDefaultSite, operationShiftCode, soRank, modifiedBy);
            return ds;
        }
        #endregion

        #endregion

        #region Function related to Delete data

        #region Delete Schedule Roster
        /// <summary>
        /// To Delete schedule of an employee
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleRosterDelete(string asmtCode, int locationAutoId, int pdLineNo, string employeeNumber, string shiftPatternCode, string dateFrom, string dateTo, string shiftCode)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleRosterDelete(asmtCode, locationAutoId, pdLineNo, employeeNumber, shiftPatternCode, dateFrom, dateTo, shiftCode);
            return ds;

        }

        /// <summary>
        /// To Delete schedule in bulk
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleBulkDeletion(string employeeNumber, string dutyDate)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleBulkDeletion(employeeNumber, dutyDate);
            return ds;

        }

        #endregion

        #endregion

        #region Function related to Convert schedule

        #region Convert Schedule Into Rota
        /// <summary>
        /// To Convert schedule into actual rota
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet ConvertScheduleIntoRota(DataTable dataTable, string modifiedBy)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ConvertScheduleIntoRota(dataTable, modifiedBy);
            return ds;

        }
        #endregion

        #endregion

        #region Update Rota
        /// <summary>
        /// To Update Rota
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterUpdate(DataTable dataTable, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RosterUpdate(dataTable, modifiedBy);
            return ds;
        }
        #endregion

        #region Function Related to Planning Efficiency Tool
        /// <summary>
        /// To get two months hours comparision
        /// </summary>
        /// <param name="option">The option.</param>
        /// <param name="monthName">Name of the month.</param>
        /// <returns>dataSet</returns>
        public DataSet HourComparisonGet(string option, string monthName)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.HourComparisonGet(option, monthName);
            return ds;
        }
        #endregion

        #region Update Schedule
        /// <summary>
        /// To update schedule
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleRosterUpdate(DataTable dataTable, string modifiedBy)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleRosterUpdate(dataTable, modifiedBy);
            return ds;

        }
        #endregion

        #region Schedule Authorize
        /// <summary>
        /// To authorize schedule
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="monthValue">The month value.</param>
        /// <param name="yearValue">The year value.</param>
        /// <param name="payPeriodType">Type of the pay period.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleAuthorize(int locationAutoId, int monthValue, int yearValue, string payPeriodType, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleAuthorize(locationAutoId, monthValue, yearValue, payPeriodType, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To Get authorize infomation of shcedule
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="monthValue">The month value.</param>
        /// <param name="yearValue">The year value.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleAuthorizeInformationGet(int locationAutoId, int monthValue, int yearValue)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleAuthorizeInformationGet(locationAutoId, monthValue, yearValue);
            return ds;
        }
        #endregion

        #region Convert Schedule to Actual
        /// <summary>
        /// To convert schedule into actual rota
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet ConvertSchedule2Actual(int locationAutoId, string clientCode, string asmtCode, DateTime fromDate, DateTime toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ConvertSchedule2Actual(locationAutoId, clientCode, asmtCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To Convert schedule into actual rota
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet ConvertEmployeeWiseSchedule2Actual(int locationAutoId, string clientCode, string asmtCode, DateTime fromDate, DateTime toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ConvertEmployeeWiseSchedule2Actual(locationAutoId, clientCode, asmtCode, fromDate, toDate, modifiedBy);
            return ds;
        }
        #endregion

        #region Auto Schedule
        /// <summary>
        /// For auto scheduling
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="nextFromDate">The next from date.</param>
        /// <param name="nextToDate">The next to date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet AutoSchedule(int locationAutoId, string clientCode, string asmtCode, DateTime fromDate, DateTime toDate, DateTime nextFromDate, DateTime nextToDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AutoSchedule(locationAutoId, clientCode, asmtCode, fromDate, toDate, nextFromDate, nextToDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// For auto scheduling (employee wise scheduling)
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="nextFromDate">The next from date.</param>
        /// <param name="nextToDate">The next to date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="startDate">The start date.</param>
        /// <returns>dataSet</returns>
        public DataSet EmployeeWiseAutoSchedule(int locationAutoId, string clientCode, string asmtCode, DateTime fromDate, DateTime toDate, DateTime nextFromDate, DateTime nextToDate, string modifiedBy, DateTime startDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeWiseAutoSchedule(locationAutoId, clientCode, asmtCode, fromDate, toDate, nextFromDate, nextToDate, modifiedBy, startDate);
            return ds;
        }

        #endregion

        #region Function Related to Copy schedule
        /// <summary>
        /// To copy schedule from one date to next date or one weekNo to next weekNo
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="copyToDate">The copy to date.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataTable.</returns>
        public DataTable ScheduleRosterEmployeeWiseCopy(string scheduleRosterAutoId, string locationAutoId, string copyToDate, string asmtCode, string modifiedBy)
        {
            DL.Roster objRoster = new DL.Roster();
            DataTable dataTable = objRoster.ScheduleRosterEmployeeWiseCopy(scheduleRosterAutoId, locationAutoId, copyToDate, asmtCode, modifiedBy);
            return dataTable;
        }
        #endregion

        #region Function Related to Schedule Lock / Unlock (convert 2 actual & revert ). Added on 22 aug 2010
        /// <summary>
        /// To get Lock/unLock information of schedule
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="amtCodes">The amt codes.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="post">The post.</param>
        /// <param name="lockUnlock">The lock unlock.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleLockUnlockGet(int locationAutoId, string clientCode, string amtCodes, string fromDate, string toDate, string post, string lockUnlock)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleLockUnlockGet(locationAutoId, clientCode, amtCodes, fromDate, toDate, post, lockUnlock);
            return ds;
        }

        /// <summary>
        /// To Lock schedule
        /// </summary>
        /// <param name="autoID">The automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleLock(string autoID, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleLock(autoID, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To Unlock schedule
        /// </summary>
        /// <param name="autoID">The automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>dataSet</returns>
        public DataSet ScheduleUnlock(string autoID, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScheduleUnlock(autoID, fromDate, toDate, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Lock All Employees
        /// </summary>
        /// <param name="asmtCodes">The asmt codes.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="post">The post.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="lockUnlock">The lock unlock.</param>
        /// <returns>DataSet.</returns>
        public DataSet TransScheduleLockForAll(String asmtCodes, String fromDate, String toDate, String locationAutoId, String clientCode, String post, String modifiedBy, String lockUnlock)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.TransScheduleLockForAll(asmtCodes, fromDate, toDate, locationAutoId, clientCode, post, modifiedBy, lockUnlock);
            return ds;
        }
        /// <summary>
        /// To Lock All Employees
        /// </summary>
        /// <param name="asmtCodes">The asmt codes.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="post">The post.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="lockUnlock">The lock unlock.</param>
        /// <returns>DataSet.</returns>
        public DataSet TransScheduleUnlockForAll(String asmtCodes, String fromDate, String toDate, String locationAutoId, String clientCode, String post, String modifiedBy, String lockUnlock)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.TransScheduleUnlockForAll(asmtCodes, fromDate, toDate, locationAutoId, clientCode, post, modifiedBy, lockUnlock);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Rota

        #region Rota Authorize
        /// <summary>
        /// To Get Rota authorization detail
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="date">The date.</param>
        /// <returns>dataSet</returns>
        public DataSet RotaAuthorizationDetailGet(string locationAutoId, string date)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaAuthorizationDetailGet(locationAutoId, date);
            return ds;
        }

        /// <summary>
        /// To Get authorization status.
        /// </summary>
        /// <param name="divisionCode">The STR division code.</param>
        /// <param name="branchCode">The STR branch code.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <returns>dataSet</returns>
        public DataSet RotaAuthorizationStatusGet(string divisionCode, string branchCode, int month, int year, string companyCode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaAuthorizationStatusGet(divisionCode, branchCode, month, year, companyCode);
            return ds;
        }


        /// <summary>
        /// For Rota Authorization.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">modifiedBy.</param>
        /// <returns>dataSet</returns>
        public DataSet RotaAuthorize(string fromDate, string toDate, int locationAutoId, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaAuthorize(fromDate, toDate, locationAutoId, modifiedBy);
            return ds;

        }

        /// <summary>
        /// rota un authorize.
        /// </summary>
        /// <param name="locationAutoId">The int location auto Id.</param>
        /// <param name="monthValue">The int month val.</param>
        /// <param name="yearValue">The int year val.</param>
        /// <param name="payPeriodType">Type of the STR pay period.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaUNAuthorize(int locationAutoId, int monthValue, int yearValue, string payPeriodType, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaUNAuthorize(locationAutoId, monthValue, yearValue, payPeriodType, modifiedBy);
            return ds;

        }

        #endregion

        #region Get Asmt Rota and Detail of Site & Posts
        /// <summary>
        /// Get data set with detail of Asmt Rota and site posts
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="status">The status.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtRotaGet(int locationAutoId, string asmtCode, string dutyDate, int pageNumber, int pageSize, int status, string employeeNumber)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AsmtRotaGet(locationAutoId, asmtCode, dutyDate, pageNumber, pageSize, status, employeeNumber);
            return ds;
        }
        #endregion

        #region Function for get daily Rota sheet for barbados
        /// <summary>
        /// get daily Rota sheet for barbados
        /// </summary>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtWiseDailyRotaGet(int locationAutoId, string asmtCode, string dutyDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AsmtWiseDailyRotaGet(locationAutoId, asmtCode, dutyDate);
            return ds;
        }

        #endregion

        #region Get Monthly Rota Detail of Employee
        /// <summary>
        /// Get Monthly Rota Detail of Employee on a single asmt
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="fromDutyDate">From duty date.</param>
        /// <param name="toDutyDate">To duty date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>DataSet with rosterAutoId,ShiftCode,dutyDate,TimeFrom,TimeTo,DutyMin,DutyTypeCode</returns>
        public DataSet EmployeeMonthlyRotaGet(int locationAutoId, string asmtCode, int pdLineNo, string fromDutyDate, string toDutyDate, string employeeNumber, string shiftCode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeMonthlyRotaGet(locationAutoId, asmtCode, pdLineNo, fromDutyDate, toDutyDate, employeeNumber, shiftCode);
            return ds;
        }
        #endregion

        #region Get Daily Rota of an Employee
        /// <summary>
        /// Get data set with detail of Employee Rota/Schedule
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRotaGet(string employeeNumber, string dutyDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeRotaGet(employeeNumber, dutyDate);
            return ds;
        }

        /// <summary>
        /// Get data set with detail of Employee Rota/Schedule for greece.
        /// </summary>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location Id.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRotaGet(string employeeNumber, string fromDate, string toDate, string companyCode, string locationAutoId)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeRotaGet(employeeNumber, fromDate, toDate, companyCode, locationAutoId);
            return ds;
        }

        /// <summary>
        /// get rota of a client for greece
        /// </summary>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location Id.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientRotaGet(string clientCode, string asmtCode, string fromDate, string toDate, string companyCode, string locationAutoId)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ClientRotaGet(clientCode, asmtCode, fromDate, toDate, companyCode, locationAutoId);
            return ds;
        }


        /// <summary>
        /// Totals duty hours of employee get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="option">The option.</param>
        /// <returns>DataSet.</returns>
        public DataSet TotalDutyHoursOfEmployeeGet(string employeeNumber, string fromDate, string toDate, string timeFrom, string timeTo, string option)
        {
            DL.Roster objdlRost = new DL.Roster();
            return objdlRost.TotalDutyHoursOfEmployeeGet(employeeNumber, fromDate, toDate, timeFrom, timeTo, option);

        }


        #endregion

        #region Update Time Status of employee
        /// <summary>
        /// Times the status update.
        /// </summary>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="confirmedBy">The confirmed by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TimeStatusUpdate(string rosterAutoId, string confirmedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.TimeStatusUpdate(rosterAutoId, confirmedBy);
            return ds;
        }


        #endregion

        #region Insert Rota
        /// <summary>
        /// To Insert Rota
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto Id.</param>
        /// <param name="pdLineNo">The int PD line no.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The strdesignation code.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyMinutes">The int duty min.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="timeStatus">The int time status.</param>
        /// <param name="breakHours">The STR break hours.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaInsert(string asmtCode, int locationAutoId, int pdLineNo, string dutyDate, string employeeNumber, string roleCode, string designationCode, string shiftCode, string timeFrom, string timeTo, int dutyMinutes, string dutyTypeCode, int timeStatus, string breakHours, string modifiedBy)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaInsert(asmtCode, locationAutoId, pdLineNo, dutyDate, employeeNumber, roleCode, designationCode, shiftCode, timeFrom, timeTo, dutyMinutes, dutyTypeCode, timeStatus, breakHours, modifiedBy);
            return ds;

        }
        #endregion

        #region Overwrite Duplicate Rota
        /// <summary>
        /// rota_ over write duplicate record ajax.
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto Id.</param>
        /// <param name="pdLineNo">The int PD line no.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The strdesignation code.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyMinutes">The int duty min.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="duplicateRosterAutoId1">The int duplicate roster auto I d1.</param>
        /// <param name="duplicateRosterAutoId2">The int duplicate roster auto I d2.</param>
        /// <param name="duplicateRosterAutoId3">The int duplicate roster auto I d3.</param>
        /// <param name="rosterAutoId">The int roster auto Id.</param>
        /// <param name="timeStatus">The time status.</param>
        /// <param name="breakHours">The STR break hours.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverwriteDuplicateRota(string asmtCode, int locationAutoId, int pdLineNo, string dutyDate, string employeeNumber, string roleCode, string designationCode, string shiftCode, string timeFrom, string timeTo, int dutyMinutes, string dutyTypeCode, string modifiedBy, int duplicateRosterAutoId1, int duplicateRosterAutoId2, int duplicateRosterAutoId3, int rosterAutoId, int timeStatus, string breakHours)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.OverwriteDuplicateRota(asmtCode, locationAutoId, pdLineNo, dutyDate, employeeNumber, roleCode, designationCode, shiftCode, timeFrom, timeTo, dutyMinutes, dutyTypeCode, modifiedBy, duplicateRosterAutoId1, duplicateRosterAutoId2, duplicateRosterAutoId3, rosterAutoId, timeStatus, breakHours);
            return ds;

        }
        #endregion

        #region Update Rota
        /// <summary>
        /// rota_ update.
        /// </summary>
        /// <param name="rosterAutoId">The int roster auto Id.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="designationCode">The strdesignation code.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyMinutes">The int duty min.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="timeStatus">The time status.</param>
        /// <param name="breakHours">The STR break hours.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaUpdate(int rosterAutoId, string asmtCode, string employeeNumber, string designationCode, string shiftCode, string timeFrom, string timeTo, int dutyMinutes, string roleCode, string dutyTypeCode, int timeStatus, string breakHours, string modifiedBy)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaUpdate(rosterAutoId, asmtCode, employeeNumber, designationCode, shiftCode, timeFrom, timeTo, dutyMinutes, roleCode, dutyTypeCode, timeStatus, breakHours, modifiedBy);
            return ds;

        }
        #endregion

        #region Delete Rota
        /// <summary>
        /// rota Delete
        /// </summary>
        /// <param name="rosterAutoId">The int roster auto Id.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaDelete(int rosterAutoId)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaDelete(rosterAutoId);
            return ds;

        }

        /// <summary>
        /// Dlete Record in bulk
        /// </summary>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="reason">The STR reason.</param>
        /// <param name="terminationReason">The STR termination reason.</param>
        /// <param name="resignationDate">The STR resignation date.</param>
        /// <param name="remarks">The STR remarks.</param>
        /// <param name="isSuitableForRehire">if set to <c>true</c> [DDL suitable4 re hire].</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaBulkDeletion(string employeeNumber, string reason, string terminationReason, DateTime resignationDate, string remarks, bool isSuitableForRehire, string modifiedBy)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaBulkDeletion(employeeNumber, reason, terminationReason, resignationDate, remarks, isSuitableForRehire, modifiedBy);
            return ds;

        }

        #endregion

        #region Copy Daily Rota
        /// <summary>
        /// Copy records in daily Rota
        /// </summary>
        /// <param name="tableName">Name of the STR table.</param>
        /// <param name="copyDate">The STR copy date.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto Id.</param>
        /// <returns>DataSet.</returns>
        public DataSet DailyRotaCopy(string tableName, string copyDate, string fromDate, string toDate, string asmtCode, int locationAutoId)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.DailyRotaCopy(tableName, copyDate, fromDate, toDate, asmtCode, locationAutoId);
            return ds;

        }
        #endregion

        #region Function Related to Schecule vs Actual Comparision
        /// <summary>
        /// Actuals the and schedule comparison.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ActualAndScheduleComparison(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ActualAndScheduleComparison(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy);
            return ds;
        }
        #endregion

        #region Over Write Copy Rota
        /// <summary>
        /// Overwrite in case of copy rota
        /// </summary>
        /// <param name="rosterAutoId">The int roster auto Id.</param>
        /// <param name="rosterAutoId1">The int roster auto I d1.</param>
        /// <returns>DataSet.</returns>
        public DataSet CopyRotaOverwrite(int rosterAutoId, int rosterAutoId1)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.CopyRotaOverwrite(rosterAutoId, rosterAutoId1);
            return ds;

        }
        #endregion

        #endregion

        #region Get Employee Weekly off
        #region for Get Data
        /// <summary>
        /// Employees the weekly off get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWeeklyOffGet(string employeeNumber, DateTime fromDate, DateTime toDate, int locationAutoId, string asmtCode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeWeeklyOffGet(employeeNumber, fromDate, toDate, locationAutoId, asmtCode);
            return ds;

        }
        /// <summary>
        /// Employees the weekly off get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="weekOffType">Type of the week off.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWeeklyOffGet(string locationAutoId, DateTime fromDate, DateTime toDate, string weekOffType, string employeeNumber)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.EmployeeWeeklyOffGet(locationAutoId, fromDate, toDate, weekOffType, employeeNumber);
            return ds;
        }

        /// <summary>
        /// Employees the wise weekly off get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWiseWeeklyOffGet(string locationAutoId, DateTime fromDate, DateTime toDate, string asmtCode, string employeeNumber)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.EmployeeWiseWeeklyOffGet(locationAutoId, fromDate, toDate, asmtCode, employeeNumber);
            return ds;
        }
        /// <summary>
        /// Employees the weekly off get.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="date">The date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWeeklyOffGet(string asmtCode, string date, string locationAutoId)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeWeeklyOffGet(asmtCode, date, locationAutoId);
            return ds;
        }
        #endregion
        #region For save Data
        /// <summary>
        /// Employees the weekly off save.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="dataTableWeekOff">The data table week off.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="weekOffType">Type of the week off.</param>
        /// <returns>DataTable.</returns>
        public DataTable EmployeeWeeklyOffSave(string locationAutoId, DataTable dataTableWeekOff, string modifiedBy, string weekOffType)
        {
            DL.Roster objRoster = new DL.Roster();
            DataTable ds = objRoster.EmployeeWeeklyOffSave(locationAutoId, dataTableWeekOff, modifiedBy, weekOffType);
            return ds;
        }
        /// <summary>
        /// Employees the wise weekly off save.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="dataTableWeekOff">The data table week off.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="defaultSite">if set to <c>true</c> [default site].</param>
        /// <param name="soRank">The so rank.</param>
        /// <returns>DataTable.</returns>
        public DataTable EmployeeWiseWeeklyOffSave(string locationAutoId, DataTable dataTableWeekOff, string modifiedBy, string asmtCode, string shiftPatternCode, int patternPosition, bool defaultSite, string soRank)
        {
            DL.Roster objRoster = new DL.Roster();
            DataTable ds = objRoster.EmployeeWiseWeeklyOffSave(locationAutoId, dataTableWeekOff, modifiedBy, asmtCode, shiftPatternCode, patternPosition, defaultSite, soRank);
            return ds;
        }

        /// <summary>
        /// Employees the weekly off delete.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="weekOffType">Type of the week off.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWeeklyOffDelete(string employeeNumber, string dutyDate, string weekOffType, string locationAutoId, string modifiedBy)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.EmployeeWeeklyOffDelete(employeeNumber, dutyDate, weekOffType, locationAutoId, modifiedBy);
            return ds;
        }
        #endregion


        #endregion

        #region Function Related to Vehicle Scheduling

        /// <summary>
        /// Vehicles the scheduling get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet VehicleSchedulingGet(string locationAutoId, DateTime fromDate, DateTime toDate)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.VehicleSchedulingGet(locationAutoId, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// Vehicles the scheduling save.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="tableVehicle">The table vehicle.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet VehicleSchedulingSave(string locationAutoId, DataTable tableVehicle, string modifiedBy)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.VehicleSchedulingSave(locationAutoId, tableVehicle, modifiedBy);
            return ds;
        }

        #endregion

        #region Process Employee Attendance

        /// <summary>
        /// Employees the attendance process.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAttendanceProcess(string companyCode, string businessRuleCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeAttendanceProcess(companyCode, businessRuleCode, fromDate, toDate, modifiedBy);
            return ds;

        }


        /// <summary>
        /// Employees the attendance process.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAttendanceProcess(string companyCode, string hrLocationCode, int locationAutoId, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeAttendanceProcess(companyCode, hrLocationCode, locationAutoId, fromDate, toDate, modifiedBy);
            return ds;

        }

        /// <summary>
        /// Employees the attendance process.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAttendanceProcess(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeAttendanceProcess(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Employees the attendance process greece.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAttendanceProcessGreece(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeAttendanceProcessGreece(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Employees the attendance process greece.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="processType">Type of the process.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="employees">The employees.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAttendanceProcessGreece(string companyCode, string hrLocationCode, string locationCode, string processType, string fromDate, string toDate, string employees, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeAttendanceProcessGreece(companyCode, hrLocationCode, locationCode, processType, fromDate, toDate, employees, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Generates the paysum.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysum(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy, string clientCode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysum(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy, clientCode);
            return ds;
        }

        /// <summary>
        /// Generates the paysum.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="year">The year.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysum(string locationAutoId, string clientCode, string year)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysum(locationAutoId, clientCode, year);
            return ds;
        }

        #endregion

        #region Function Related to Adjusted hrs
        #region Insert Adjusted Hours
        /// <summary>
        /// Adjustments the hours insert.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="adjustmentDate">The adjustment date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="adjustmentFromDate">The adjustment from date.</param>
        /// <param name="adjustmentToDate">The adjustment to date.</param>
        /// <param name="adjustmentHours">The adjustment hours.</param>
        /// <param name="adjustmentHead">The adjustment head.</param>
        /// <param name="remark">The remark.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AdjustmentHoursInsert(string asmtCode, int locationAutoId, string adjustmentDate, string employeeNumber, string adjustmentFromDate, string adjustmentToDate, float adjustmentHours, string adjustmentHead, string remark, string modifiedBy, string fromDate, string toDate)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AdjustmentHoursInsert(asmtCode, locationAutoId, adjustmentDate, employeeNumber, adjustmentFromDate, adjustmentToDate, adjustmentHours, adjustmentHead, remark, modifiedBy, fromDate, toDate);
            return ds;

        }
        #endregion

        #region Get Adjusted Hours
        /// <summary>
        /// Adjustments the hours get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AdjustmentHoursGet(int locationAutoId, string fromDate, string toDate)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AdjustmentHoursGet(locationAutoId, fromDate, toDate);
            return ds;

        }
        #endregion

        #region Delete Adjusted Hours
        /// <summary>
        /// Adjustments the hours delete.
        /// </summary>
        /// <param name="adjustmentHoursTransactionCode">The adjustment hours transaction code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AdjustmentHoursDelete(int adjustmentHoursTransactionCode)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AdjustmentHoursDelete(adjustmentHoursTransactionCode);
            return ds;

        }
        #endregion

        #endregion

        #region function related to contract hrs

        #region Get Contracted Hours of a assignment
        /// <summary>
        /// Contracts the hours of asmt get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractHoursOfAsmtGet(int locationAutoId, string asmtCode, string fromDate, string toDate)
        {

            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ContractHoursOfAsmtGet(locationAutoId, asmtCode, fromDate, toDate);
            return ds;

        }
        #endregion

        #endregion

        #region Function Related to Pay Sum
        /// <summary>
        /// Rosters for paysum get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterForPaysumGet(string locationAutoId, string clientCode, DateTime fromDate, DateTime toDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RosterForPaysumGet(locationAutoId, clientCode, fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// Generates the paysum flat.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="divisionCode">The division code.</param>
        /// <param name="branchCode">The branch code.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumFlat(string companyCode, string divisionCode, string branchCode, int month, int year, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumFlat(companyCode, divisionCode, branchCode, month, year, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Generates the paysum.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="divisionCode">The division code.</param>
        /// <param name="branchCode">The branch code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysum(string companyCode, string divisionCode, string branchCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysum(companyCode, divisionCode, branchCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Generates the paysum egypt.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumEgypt(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumEgypt(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Generates the paysum morocco.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumMorocco(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumMorocco(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Generates the paysum barbados.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumBarbados(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumBarbados(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Generates the paysum greece.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="outputType">Type of the output.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumGreece(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy, string outputType)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumGreece(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy, outputType);
            return ds;
        }

        /// <summary>
        /// Generates the paysum israel.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="outputType">Type of the output.</param>
        /// <param name="countryCode">The country code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumIsrael(string businessRuleCode, string fromDate, string toDate, string outputType,string countryCode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumIsrael(businessRuleCode, fromDate, toDate, outputType, countryCode);
            return ds;
        }
        /// <summary>
        /// BL function used for Saudi PaySum , Calls another function in BL and takes the dataset returned by DL
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="outputType">Type of the output.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumSaudi(string businessRuleCode, string fromDate, string toDate, string outputType)
        {
            var objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumSaudi(businessRuleCode, fromDate, toDate, outputType);
            return ds;
        }

        /// <summary>
        /// Paysum generation Method for Australia added by  on 8-aug-2012
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="outputType">Type of the output.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumAustralia(string businessRuleCode, string fromDate, string toDate, string outputType)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumAustralia(businessRuleCode, fromDate, toDate, outputType);
            return ds;
        }

        /// <summary>
        /// Generates the paysum PNG.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumPng(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumPng(companyCode, hrLocationCode, locationCode, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// To Generate PAYSUM of PNG
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="PayPeriodNumber">The pay period number.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumBSPng(string companyCode, string hrLocationCode, string locationCode, string businessRuleCode, string PayPeriodNumber)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GeneratePaysumBSPng(companyCode, hrLocationCode, locationCode, businessRuleCode, PayPeriodNumber);
            return ds;
        }

        /// <summary>
        /// Generates the weekly paysum greece.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="outputType">Type of the output.</param>
        /// <returns>DataSet.</returns>
        public DataSet GenerateWeeklyPaysumGreece(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy, string outputType)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GenerateWeeklyPaysumGreece(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy, outputType);
            return ds;
        }

        /// <summary>
        /// Generates the job wise paysum barbados.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GenerateJobWisePaysumBarbados(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.GenerateJobWisePaysumBarbados(companyCode, hrLocationCode, locationCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        #endregion

        /// <summary>
        /// Employees the last assignment get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeLastAssignmentGet(string employeeNumber)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeeLastAssignmentGet(employeeNumber);
            return ds;
        }
        /// <summary>
        /// Shiftses the of site post get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftsOfSitePostGet(string locationAutoId, string asmtMasterAutoId, string pdLineNo, string dutyDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ShiftsOfSitePostGet(locationAutoId, asmtMasterAutoId, pdLineNo, dutyDate);
            return ds;
        }

        /// <summary>
        /// To Get Requireds VS schedule Actual hours records.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="asmtStatusAuthorized">The asmt status authorized.</param>
        /// <param name="asmtStatusTerminated">The asmt status terminated.</param>
        /// <param name="filterParam">The filter param.</param>
        /// <param name="areaId">The area id.</param>
        /// <param name="employeeno">The employeeno.</param>
        /// <returns>DataSet.</returns>
        public DataSet RequiredVSScheduleVSActualGet(string locationAutoId, string clientCode, string fromDate, string toDate, string asmtStatusAuthorized, string asmtStatusTerminated, string filterParam, string areaId, string employeeno)
        {
            DL.Roster objRoster = new DL.Roster();

            DataSet ds = objRoster.RequiredVSScheduleVSActualGet(locationAutoId, clientCode, fromDate, toDate, asmtStatusAuthorized, asmtStatusTerminated, filterParam, areaId, employeeno);
            return ds;
        }

        /// <summary>
        /// Rotas the locking get.
        /// </summary>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaLockingGet(string hrLocationCode, int locationAutoId, string clientCode, string asmtCode, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaLockingGet(hrLocationCode, locationAutoId, clientCode, asmtCode, modifiedBy);
            return ds;

        }

        /// <summary>
        /// Rotas the locking update.
        /// </summary>
        /// <param name="tableLockAutoId">The table lock automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="isDeleteAccess">if set to <c>true</c> [is delete access].</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaLockingUpdate(System.Collections.Hashtable tableLockAutoId, string fromDate, string toDate, string modifiedBy, bool isDeleteAccess)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaLockingUpdate(tableLockAutoId, fromDate, toDate, modifiedBy, isDeleteAccess);
            return ds;

        }

        #region function related to Employee & Roster Detail
        /// <summary>
        /// Employeeses the detail with duty hours get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesDetailWithDutyHoursGetAll(string companyCode, string hrLocationCode, string locationCode, string dutyDate, string flag)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeesDetailWithDutyHoursGetAll(companyCode, hrLocationCode, locationCode, dutyDate, flag);
            return ds;

        }

        /// <summary>
        /// Barred Employee
        /// </summary>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="divisionCode">The division code.</param>
        /// <param name="division">The division.</param>
        /// <param name="branchCode">The branch code.</param>
        /// <param name="branch">The branch.</param>
        /// <param name="EmployeeNumber">The employee number.</param>
        /// <param name="EmployeeName">Name of the employee.</param>
        /// <param name="AreaID">The area identifier.</param>
        /// <param name="AreaDesc">The area desc.</param>
        /// <param name="AreaINcharge">The area i ncharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet BarredEmployees(DateTime FromDate, DateTime ToDate, string divisionCode, string division, string branchCode, string branch, string EmployeeNumber, string EmployeeName, string AreaID,string AreaDesc, string AreaINcharge) 
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.BarredEmployees(FromDate,ToDate,divisionCode,division,branchCode,branch,EmployeeNumber,EmployeeName,AreaID,AreaDesc,AreaINcharge);
            return ds;
        
        }

        #endregion

        #region function related to employee not scheduled between given date range
        /// <summary>
        /// To Get Employee Not Scheduled Between Dates For Scheduling Screen
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="maximumDate">The maximum date.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesNotScheduleBetweenDatesGetAll(string companyCode, string locationAutoId, string fromDate, string toDate, string maximumDate, string attendanceType, string areaId, string areaIncharge, string isAreaIncharge)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeesNotScheduleBetweenDatesGetAll(companyCode, locationAutoId, fromDate, toDate, maximumDate, attendanceType, areaId, areaIncharge, isAreaIncharge);
            return ds;

        }

        /// <summary>
        /// Employeeses the not schedule between dates get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesNotScheduleBetweenDatesGetAll(string companyCode, string locationAutoId, string employeeNumber, string fromDate, string toDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeesNotScheduleBetweenDatesGetAll(companyCode, locationAutoId, employeeNumber, fromDate, toDate);
            return ds;

        }

        /// <summary>
        /// To search the employees match the skills and area for the borrow request line no
        /// </summary>
        /// <param name="RequestNo">The request no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="RequestLineNo">The request line no.</param>
        /// <param name="DutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet SearchEmployeeSkillandAreaWiseGetAll(string RequestNo, string locationAutoId, string RequestLineNo, string DutyDate)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.SearchEmployeeSkillandAreaWiseGetAll(RequestNo, locationAutoId, RequestLineNo, DutyDate);
            return ds;
        }

        #endregion

        #region Functions  related To Egypt [Specific]
        /// <summary>
        /// Function For Hour Analysis Egypt
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="divisionCode">The division code.</param>
        /// <param name="branchCode">The branch code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet HourAnalysis(string companyCode, string clientCode, string divisionCode, string branchCode, string fromDate, string toDate, string status)
        {

            DL.Roster objRoster = new DL.Roster();
            DataSet ds = objRoster.HourAnalysis(companyCode, clientCode, divisionCode, branchCode, fromDate, toDate, status);
            return ds;
        }
        #endregion

        #region function related Over time details

        /// <summary>
        /// Overtimes the details get.
        /// </summary>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet OvertimeDetailsGet(string hrLocationCode, string locationCode, string fromDate, string toDate)
        {
            DL.Roster objroster = new DL.Roster();

            DataSet ds = objroster.OvertimeDetailsGet(hrLocationCode, locationCode, fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// Overtimes the reason update.
        /// </summary>
        /// <param name="autoId">The automatic identifier.</param>
        /// <param name="reason">The reason.</param>
        /// <returns>DataSet.</returns>
        public DataSet OvertimeReasonUpdate(string autoId, string reason)
        {
            DL.Roster objroster = new DL.Roster();

            DataSet ds = objroster.OvertimeReasonUpdate(autoId, reason);
            return ds;
        }

        #endregion

        //Added by Bal Mukund Starts
        #region Get Daily Rota of All Employee

        /// <summary>
        /// Get data set with detail of Employee Rota/Schedule
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="confirmDuty">The confirm duty.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaOfAllEmployeesGet(string companyCode, string locationCode, string clientCode, string employeeNumber, string dutyDate, string timeFrom, string timeTo, string confirmDuty)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RotaOfAllEmployeesGet(companyCode, locationCode, clientCode, employeeNumber, dutyDate, timeFrom, timeTo, confirmDuty);
            return ds;
        }


        /// <summary>
        /// Shifts the of all employee get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftOfAllEmployeeGet(string locationAutoId)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ShiftOfAllEmployeeGet(locationAutoId);
            return ds;
        }

        /// <summary>
        /// Shifts the of all employee get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftOfAllEmployeeGet(string locationAutoId, string shiftCode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ShiftOfAllEmployeeGet(locationAutoId, shiftCode);
            return ds;
        }

        #endregion
        //Added by Bal Mukund Ends

        /// <summary>
        /// Employees the post schedule roster.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePostScheduleRoster(string companyCode, string locationCode, string fromDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.EmployeePostScheduleRoster(companyCode, locationCode, fromDate);
            return ds;
        }

        /// <summary>
        /// Legals the schedule roster.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <returns>DataSet.</returns>
        public DataSet LegalScheduleRoster(string companyCode, string locationCode, string fromDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.LegalScheduleRoster(companyCode, locationCode, fromDate);
            return ds;
        }

        //code modified by   on 22-nov-2010

        /// <summary>
        /// Supervisors the schedule roster.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <returns>DataSet.</returns>
        public DataSet SupervisorScheduleRoster(string companyCode, string locationCode, string fromDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.SupervisorScheduleRoster(companyCode, locationCode, fromDate);
            return ds;
        }

        /// <summary>
        /// Screenerses the aviation.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScreenersAviation(string companyCode, string locationCode, string fromDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ScreenersAviation(companyCode, locationCode, fromDate);
            return ds;
        }

        //end of code modified by   on 22-nov-2010

        /// <summary>
        /// Units the register breakup.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet UnitRegisterBreakup(string companyCode, string locationCode, string fromDate, string toDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.UnitRegisterBreakup(companyCode, locationCode, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// Units the register employee breakup.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet UnitRegisterEmployeeBreakup(string companyCode, string locationCode, string fromDate, string toDate)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.UnitRegisterEmployeeBreakup(companyCode, locationCode, fromDate, toDate);
            return ds;
        }

        #region Function Related to NFC

        #region function related to employee Tag reference (specific for Egypt version)
        /// <summary>
        /// Employees the tag reference get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="recordType">Type of the record.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeTagReferenceGet(string employeeNumber, string recordType)
        {
            DL.Roster objroster = new DL.Roster();

            DataSet ds = objroster.EmployeeTagReferenceGet(employeeNumber, recordType);
            return ds;
        }


        /// <summary>
        /// Employees the tag reference insert.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeTagReferenceInsert(string employeeNumber, string tagId, string effectiveFrom, string userId)
        {
            DL.Roster objroster = new DL.Roster();

            DataSet ds = objroster.EmployeeTagReferenceInsert(employeeNumber, tagId, effectiveFrom, userId);
            return ds;
        }


        /// <summary>
        /// Employees the tag reference close.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeTagReferenceClose(string employeeNumber, string tagId, string effectiveTo, string userId)
        {
            DL.Roster objroster = new DL.Roster();

            DataSet ds = objroster.EmployeeTagReferenceClose(employeeNumber, tagId, effectiveTo, userId);
            return ds;
        }


        #endregion


        #region Functions related to Location Tag Reference

        /// <summary>
        /// This function fetches the data related to Location Tag Reference
        /// </summary>
        /// <param name="locationTagId">The location tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet LocationTagReferenceGet(string locationTagId)
        {
            DL.Roster objLocTag = new DL.Roster();

            DataSet ds = objLocTag.LocationTagReferenceGet(locationTagId);
            return ds;
        }

        /// <summary>
        /// Locations the tag reference insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="tagType">Type of the tag.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="tagDesc">The tag desc.</param>
        /// <param name="postId">The post identifier.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet LocationTagReferenceInsert(string locationAutoId, string tagType, string tagId, string tagDesc, string postId, string effectiveFrom, string userId)
        {
            DL.Roster objLocTag = new DL.Roster();

            DataSet ds = objLocTag.LocationTagReferenceInsert(locationAutoId, tagType, tagId, tagDesc, postId, effectiveFrom, userId);
            return ds;
        }

        /// <summary>
        /// Locations the tag reference close.
        /// </summary>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="action">The action.</param>
        /// <returns>DataSet.</returns>
        public DataSet LocationTagReferenceClose(string tagId, string effectiveTo, string userId, string action)
        {
            DL.Roster objLocTag = new DL.Roster();

            DataSet ds = objLocTag.LocationTagReferenceClose(tagId, effectiveTo, userId, action);
            return ds;
        }

        /// <summary>
        /// Posts the get all.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostGetAll(string locationAutoId)
        {
            DL.Roster objLocTag = new DL.Roster();

            DataSet ds = objLocTag.PostGetAll(locationAutoId);
            return ds;
        }
        #endregion


        #region function related to Assignmnet Tag reference (specific for Egypt version)

        /// <summary>
        /// Asmts the tag reference insert.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveFromTime">The effective from time.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtTagReferenceInsert(string clientCode, string asmtCode, string locationAutoId, string tagId, string effectiveFrom, string effectiveFromTime, string postAutoId, string userId)
        {
            DL.Roster objroster = new DL.Roster();

            DataSet ds = objroster.AsmtTagReferenceInsert(clientCode, asmtCode, locationAutoId, tagId, effectiveFrom, effectiveFromTime, postAutoId, userId);
            return ds;
        }


        /// <summary>
        /// Asmts the tag reference close.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="effectiveToTime">The effective to time.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="action">The action.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtTagReferenceClose(string clientCode, string asmtCode, string locationAutoId, string tagId, string effectiveTo, string effectiveToTime, string postAutoId, string userId, string action)
        {
            DL.Roster objroster = new DL.Roster();

            DataSet ds = objroster.AsmtTagReferenceClose(clientCode, asmtCode, locationAutoId, tagId, effectiveTo, effectiveToTime, postAutoId, userId, action);
            return ds;
        }


        #endregion

        #endregion

        #region functions related to Request form to borrow employees
        /// <summary>
        /// Services the managers get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="serviceManager">The service manager.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ServiceManagersGet(string companyCode, string serviceManager, string hrLocationCode)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ServiceManagersGet(companyCode, serviceManager, hrLocationCode);
            return ds;
        }

        /// <summary>
        /// Clients the list get.
        /// </summary>
        /// <param name="serviceManager">The service manager.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientListGet(string serviceManager)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.ClientListGet(serviceManager);
            return ds;
        }

        /// <summary>
        /// Assignmentses the get.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="serviceManager">The service manager.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsGet(string clientCode, string serviceManager)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AssignmentsGet(clientCode, serviceManager);
            return ds;
        }

        /// <summary>
        /// Sites the asmt get.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="serviceManager">The service manager.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteAsmtGet(string clientCode, string asmtCode, string serviceManager)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.SiteAsmtGet(clientCode, asmtCode, serviceManager);
            return ds;
        }

        /// <summary>
        /// To generate a new Borrow Employee Request
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="AsmtId">The asmt identifier.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="requestedToLocationAutoId">The requested to location automatic identifier.</param>
        /// <param name="requestedToAreaId">The requested to area identifier.</param>
        /// <param name="statusFresh">The status fresh.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeRequestInsertHdr(string locationAutoId, string areaId, string clientCode, string AsmtId, string postAutoId, string soRank,
            string requestedToLocationAutoId, string requestedToAreaId, string statusFresh, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.BorrowEmployeeRequestInsertHdr(locationAutoId, areaId, clientCode, AsmtId, postAutoId, soRank,
                requestedToLocationAutoId, requestedToAreaId, statusFresh, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To get the Borrow Employee Details by Location and Request No.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeRequestDetailGet(string locationAutoId, string requestNo)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.BorrowEmployeeRequestDetailGet(locationAutoId, requestNo);
            return ds;
        }

        /// <summary>
        /// Requests the no get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <returns>DataSet.</returns>
        public DataSet RequestNoGet(string locationAutoId, string requestNo)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RequestNoGet(locationAutoId, requestNo);
            return ds;
        }
        /// <summary>
        /// To get the Borrowed Employees Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowedEmployeeGet(string locationAutoId, string requestNo)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.BorrowedEmployeeGet(locationAutoId, requestNo);
            return ds;
        }
        /// <summary>
        /// To Update the Borrow Employee Request Header Info
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="AsmtId">The asmt identifier.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="requestedToLocationAutoId">The requested to location automatic identifier.</param>
        /// <param name="requestedToAreaId">The requested to area identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeRequestUpdateHdr(string locationAutoId, string requestNo, string areaId, string clientCode, string AsmtId, string postAutoId, string soRank,
            string requestedToLocationAutoId, string requestedToAreaId, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.BorrowEmployeeRequestUpdateHdr(locationAutoId, requestNo, areaId, clientCode, AsmtId, postAutoId, soRank,
            requestedToLocationAutoId, requestedToAreaId, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To Delete a Borrow Employee Request in fresh Mode
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeRequestDeleteHdr(string locationAutoId, string requestNo, string status)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.BorrowEmployeeRequestDeleteHdr(locationAutoId, requestNo, status);
            return ds;
        }

        /// <summary>
        /// To Insert the Borrow Employee Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="noOfPerson">The no of person.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="FromTime">From time.</param>
        /// <param name="ToTime">To time.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeDetailInsert(string locationAutoId, string requestNo, int noOfPerson, string designationCode, string FromDate, string ToDate, string FromTime, string ToTime, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.BorrowEmployeeDetailInsert(locationAutoId, requestNo, noOfPerson, designationCode, FromDate, ToDate, FromTime, ToTime, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To Send a Request to Borrow employees
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="statusSent">The status sent.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeRequestSend(string locationAutoId, string requestNo, string statusSent)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.BorrowEmployeeRequestSend(locationAutoId, requestNo, statusSent);
            return ds;
        }

        /// <summary>
        /// To get the Pending Borrowed Employee Requests
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeRequestPendingGet(string locationAutoId, string areaIncharge, string isAreaIncharge)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.BorrowEmployeeRequestPendingGet(locationAutoId, areaIncharge, isAreaIncharge);
            return ds;
        }

        /// <summary>
        /// To Delete a Borrow Request Detail Line
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="requestLineNo">The request line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeDetailDelete(string locationAutoId, string requestNo, string requestLineNo)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.BorrowEmployeeDetailDelete(locationAutoId, requestNo, requestLineNo);
            return ds;
        }

        /// <summary>
        /// To get the Borrow Employee Request Detail For Approval
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeRequestDetailForApprovalGet(string locationAutoId, string requestNo)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.BorrowEmployeeRequestDetailForApprovalGet(locationAutoId, requestNo);
            return ds;
        }

        /// <summary>
        /// To BorrowedEmployee Close Partial Approved Request
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowedEmployeeClosePartialApprovedRequest(string locationAutoId, string requestNo)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.BorrowedEmployeeClosePartialApprovedRequest(locationAutoId, requestNo);
            return ds;
        }

        /// <summary>
        /// Accepts the request.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AcceptRequest(string locationAutoId, string requestNo)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.AcceptRequest(locationAutoId, requestNo);
            return ds;
        }

        /// <summary>
        /// Rejects the request.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <returns>DataSet.</returns>
        public DataSet RejectRequest(string locationAutoId, string requestNo)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RejectRequest(locationAutoId, requestNo);
            return ds;
        }

        /// <summary>
        /// To update The Borrowed Employee to Assign the Employee Number
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="requestLineNo">The request line no.</param>
        /// <param name="requestSubLineNo">The request sub line no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowedEmployeeUpdate(string locationAutoId, string requestNo, string dutyDate, int requestLineNo, int requestSubLineNo, string employeeNumber, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.BorrowedEmployeeUpdate(locationAutoId, requestNo, dutyDate, requestLineNo, requestSubLineNo, employeeNumber, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To insert Data to All Dates of an Employee
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="sLineNo">The s line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet RequestedEmployeeNoCopytoAll(string locationAutoId, string requestNo, string employeeNumber, string dutyDate, string sLineNo)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RequestedEmployeeNoCopytoAll(locationAutoId, requestNo, employeeNumber, dutyDate, sLineNo);
            return ds;
        }


        /// <summary>
        /// Requesteds the employee delete.
        /// </summary>
        /// <param name="requestNo">The request no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet RequestedEmployeeDelete(string requestNo, string locationAutoId, int lineNumber, int rowNumber)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.RequestedEmployeeDelete(requestNo, locationAutoId, lineNumber, rowNumber);
            return ds;
        }

        /// <summary>
        /// To update the Borrow Employee Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="RequestLineNo">The request line no.</param>
        /// <param name="noOfPerson">The no of person.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="FromTime">From time.</param>
        /// <param name="ToTime">To time.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowEmployeeDetailUpdate(string locationAutoId, string requestNo, int RequestLineNo, int noOfPerson, string designationCode, string FromDate, string ToDate, string FromTime, string ToTime, string modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.BorrowEmployeeDetailUpdate(locationAutoId, requestNo, RequestLineNo, noOfPerson, designationCode, FromDate, ToDate, FromTime, ToTime, modifiedBy);
            return ds;
        }
        #endregion

        /*Code modified by   on 2-Aug-2011 to Show list of Borrowed Employes*/
        /// <summary>
        /// Borroweds the employees get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaId">The area id.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowedEmployeesGetAll(string companyCode, string locationAutoId, string clientCode, string asmtId, string postCode, string fromDate, string toDate, string areaId, string areaIncharge, string isAreaIncharge)
        {
            DL.Roster objdlRost = new DL.Roster();

            DataSet ds = objdlRost.BorrowedEmployeesGetAll(companyCode, locationAutoId, clientCode, asmtId, postCode, fromDate, toDate, areaId, areaIncharge, isAreaIncharge);
            return ds;
        }
        /*End of Code modified by   on 2-Aug-2011 to Show list of Borrowed Employes*/



        /// <summary>
        /// Creates the file.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet CreateFile(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.CreateFile(companyCode, hrLocationCode, locationCode, fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// Ylms the duty date get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmDutyDateGet(string locationAutoId, string clientCode, string asmtCode)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.YlmDutyDateGet(locationAutoId, clientCode, asmtCode);
            return ds;
        }

        //public DataSet YlmRosterScheduleDutyGet(string dutyDate, string locationAutoId, string areaId, string clientCode, string asmtCode, string attendanceType)
        //{
        //    DL.Roster obReport = new DL.Roster();

        //    DataSet ds = obReport.YlmRosterScheduleDutyGet(dutyDate, locationAutoId, areaId, clientCode, asmtCode, attendanceType);
        //    return ds;
        //}

        /// <summary>
        /// Ylms the roster schedule duty get.
        /// </summary>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="WithConfirmedDuty">if set to <c>true</c> [with confirmed duty].</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmRosterScheduleDutyGet(string FromDate, string ToDate, string locationAutoId, string areaId, string clientCode, string asmtCode, string attendanceType, bool WithConfirmedDuty)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.YlmRosterScheduleDutyGet(FromDate, ToDate, locationAutoId, areaId, clientCode, asmtCode, attendanceType, WithConfirmedDuty);
            return ds;
        }


        /// <summary>
        /// Ylm Attendance Report  13-07-2012
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmRosterScheduleDutyReportGet(string locationAutoId, string clientCode, string asmtCode, string areaId, string FromDate, string ToDate, string attendanceType)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.YlmRosterScheduleDutyReportGet(locationAutoId, clientCode, asmtCode, areaId, FromDate, ToDate, attendanceType);
            return ds;
        }
        //YLM Raw Data Report 18-10-2012  
        /// <summary>
        /// Ylms the raw data report get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmRawDataReportGet(string locationAutoId, string clientCode, string asmtCode, string areaId, string FromDate, string ToDate)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.YlmRawDataReportGet(locationAutoId, clientCode, asmtCode, areaId, FromDate, ToDate);
            return ds;
        }

        //YLM RAw Data Report End 


        /// <summary>
        /// In report we are showing the schedule Employee and Call time against each employee if attendance recevied
        /// from YLM .
        /// 12-10-2012
        /// Below are the Parameter that we are sending for SP
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmNoShowReportGet(string locationAutoId, string clientCode, string asmtCode, string areaId, string FromDate, string ToDate)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.YlmNoShowReportGet(locationAutoId, clientCode, asmtCode, areaId, FromDate, ToDate);
            return ds;
        }

        //YLM No show Data Report End 

        /// <summary>
        /// Function For Unscheduled Employees Report
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="RosterOrSchedule">The roster or schedule.</param>
        /// <param name="IsAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet UnscheduledEmployees(string CompanyCode, string locationAutoId, string areaIncharge, string areaId, string FromDate, string ToDate, string RosterOrSchedule, string IsAreaIncharge)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.UnscheduledEmployees(CompanyCode, locationAutoId, areaIncharge, areaId, FromDate, ToDate, RosterOrSchedule, IsAreaIncharge);
            return ds;
        }


        /// <summary>
        /// Employee Wise Hours
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="EmployeeNumber">The employee number.</param>
        /// <param name="IsAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWiseHours(string CompanyCode, string locationAutoId, string areaIncharge, string areaId, string FromDate, string ToDate, string EmployeeNumber, string IsAreaIncharge)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.EmployeeWiseHours(CompanyCode, locationAutoId, areaIncharge, areaId, FromDate, ToDate, EmployeeNumber,IsAreaIncharge);
            return ds;
        }


        /// <summary>
        /// Schedules the control.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="AsmtCode">The asmt code.</param>
        /// <param name="Flag">The flag.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="Output">The output.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleControl( string locationAutoId, string areaIncharge, string areaId, string ClientCode, string AsmtCode, string Flag, string FromDate, string ToDate, string Output)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.ScheduleControl( locationAutoId, areaIncharge, areaId, ClientCode, AsmtCode, Flag, FromDate, ToDate, Output);
            return ds;
        }



        /// <summary>
        /// Get Start and End Week
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetStartEndDayWeek(string locationAutoId, string FromDate, string ToDate)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.GetStartEndDayWeek( locationAutoId, FromDate, ToDate);
            return ds;
        }
        /// <summary>
        /// 10-jan-2013
        /// YLM Vacant Post report.In this report we are showing the records of those employee which are leave post early.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmVacantReportGet(string locationAutoId, string clientCode, string asmtCode, string areaId, string FromDate, string ToDate)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.YlmVacantReportGet(locationAutoId, clientCode, asmtCode, areaId, FromDate, ToDate);
            return ds;
        }

        /// <summary>
        /// Ylms the confirm duty save.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="schRosterAutoID">The SCH roster automatic identifier.</param>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="inTime">The in time.</param>
        /// <param name="outTime">The out time.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="confirmStatus">The confirm status.</param>
        /// <param name="actualRosterProcessedYlmAutoId">The actual roster processed ylm automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmConfirmDutySave(string locationAutoId, string employeeNumber, string clientCode, string asmtCode, string pdLineNo, string schRosterAutoID, string rosterAutoId, string dutyDate, string inTime, string outTime, string modifiedBy, string confirmStatus, string actualRosterProcessedYlmAutoId)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.YlmConfirmDutySave(locationAutoId, employeeNumber, clientCode, asmtCode, pdLineNo, schRosterAutoID, rosterAutoId, dutyDate, inTime, outTime, modifiedBy, confirmStatus, actualRosterProcessedYlmAutoId);
            return ds;
        }
        /// <summary>
        /// 11/03/2014
        /// YLM Contact details report
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmContactDetailsReport(string locationAutoId, string clientCode, string asmtCode, string postCode ,string areaId, string areaIncharge )
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.YlmContactDetailsReport(locationAutoId, clientCode, asmtCode, postCode, areaId, areaIncharge);
            return ds;
        }



        #region Funciotn Related to Auto Schedule
        /// <summary>
        /// To Get List of Employees Need to be Scheduled
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="site">The site.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="status">The status.</param>
        /// <returns>dataset</returns>
        public DataSet GetEmployeeScheduleFinished(string key, string locationAutoId, string clientCode, string asmtCode, string site, string year, string month, string areaIncharge, string isAreaIncharge,string status)
        {
            DL.Roster objdlRost = new DL.Roster();
            return objdlRost.GetEmployeeScheduleFinished(key, locationAutoId, clientCode, asmtCode, site, year, month,areaIncharge,  isAreaIncharge, status);
        }
        /// <summary>
        /// For Auto Schedule Employee Wise
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="site">The site.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="sequence">The sequence.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="solineNo">The soline no.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet AutoScheduleEmployee(string key, string locationAutoId, string companyCode, string clientCode, string asmtId, string site, string employeeNumber, string sequence, string dutyDate, string rowNumber, string modifiedBy, string soNo, string solineNo, string soRank, int postAutoId, int patternPosition, string areaIncharge, string isAreaIncharge)
        {
            DL.Roster objdlRost = new DL.Roster();
            //DataSet ds = objdlRost.AutoScheduleEmployee(locationAutoId, companyCode, asmtCode, site, employeeNumber, sequence, dutyDate, rowNumber, modifiedBy);
            DataSet ds = objdlRost.AutoScheduleEmployee(key, locationAutoId, companyCode, clientCode, asmtId, site, employeeNumber, sequence, dutyDate, rowNumber, modifiedBy, soNo, solineNo, soRank, postAutoId, patternPosition,areaIncharge, isAreaIncharge);
            return ds;
        }

        #endregion

        #region Function Related Popup Menu Item
        /// <summary>
        /// To Menu Item Popup
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>Dataset ds</returns>
        public DataSet MenuItemPopupGet(String locationAutoId, String attendanceType)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.MenuItemPopupGet(locationAutoId, attendanceType);
            return ds;
        }
        #endregion


        #region Function Related to ScheduleReportAssignmentWeeklyWise

        /// <summary>
        /// Fills the Grid to Get data for Report "Schedule Weekly Assignment Wise"
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientcode">The clientcode.</param>
        /// <param name="asmtcode">The asmtcode.</param>
        /// <param name="weekstartday">The weekstartday.</param>
        /// <param name="weekendday">The weekendday.</param>
        /// <param name="clientcountonstatus">The clientcountonstatus.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleAssignmentWiseWeekly(int locationAutoId, int month, int year, string areaId, string clientcode, string asmtcode, string weekstartday, string weekendday, string clientcountonstatus)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.ScheduleAssignmentWiseWeekly(locationAutoId, month, year, areaId, clientcode, asmtcode, weekstartday, weekendday, clientcountonstatus);
            return ds;
        }

        #endregion

        #region Functions Related to Swap Duty
        /// <summary>
        /// To Get Roster Data for Emp
        /// </summary>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TranRosterEmployeeWiseGetAllBasedOnRosterAutoId(String rosterAutoId, String locationAutoId)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.TranRosterEmployeeWiseGetAllBasedOnRosterAutoId(rosterAutoId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Get Shift Code
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="empNumber">The emp number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet NewShiftCodeGet(String locationAutoId, String clientCode, string asmtId, string postCode, String empNumber, String dutyDate)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.NewShiftCodeGet(locationAutoId, clientCode, asmtId, postCode, empNumber, dutyDate);
            return ds;
        }
        /// <summary>
        /// To Inster Swap Duty
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="currentRosterAutoId">The current roster automatic identifier.</param>
        /// <param name="swapRosterAutoId">The swap roster automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="swappedBy">The swapped by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SwapDutyInsert(String locationAutoId, String currentRosterAutoId, String swapRosterAutoId, String modifiedBy, String employeeNumber, string clientCode, String asmtId, string postCode, String dutyDate, String swappedBy)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.SwapDutyInsert(locationAutoId, currentRosterAutoId, swapRosterAutoId, modifiedBy, employeeNumber, clientCode, asmtId, postCode, dutyDate, swappedBy);
            return ds;
        }

        /// <summary>
        /// Gets the client for swap duty.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="areaId">The area id.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetClientForSwapDuty(string locationAutoId, string areaId, string clientCode, string areaIncharge, string isAreaIncharge, string fromDate, string toDate)
        {
            var obReport = new DL.Roster();
            DataSet ds = obReport.GetClientForSwapDuty(locationAutoId, areaId, clientCode, areaIncharge, isAreaIncharge, fromDate, toDate);
            return ds;
        }

        #endregion

        #region Function Related to Apply Allowance
        /// <summary>
        /// To Insert Allowance
        /// </summary>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyMin">The duty minimum.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceInsert(String rosterAutoId, String employeeNumber, String allowanceAutoId, String dutyDate, String timeFrom, String timeTo, String dutyMin, String modifiedBy, String locationAutoId, string clientCode, string asmtId, string postCode, string rowNumber)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.RosterAllowanceInsert(rosterAutoId, employeeNumber, allowanceAutoId, dutyDate, timeFrom, timeTo, dutyMin, modifiedBy, locationAutoId, clientCode, asmtId, postCode, rowNumber);
            return ds;
        }
        /// <summary>
        /// To Update Allownace
        /// </summary>
        /// <param name="rosterAllowanceAutoId">The roster allowance automatic identifier.</param>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyMin">The duty minimum.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceUpdate(String rosterAllowanceAutoId, String rosterAutoId, String employeeNumber, String allowanceAutoId, String dutyDate, String timeFrom, String timeTo, String dutyMin, String modifiedBy, String locationAutoId, string clientCode, string asmtId, string postCode, string rowNumber)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.RosterAllowanceUpdate(rosterAllowanceAutoId, rosterAutoId, employeeNumber, allowanceAutoId, dutyDate, timeFrom, timeTo, dutyMin, modifiedBy, locationAutoId, clientCode, asmtId, postCode, rowNumber);
            return ds;
        }
        /// <summary>
        /// To Delete Allowance
        /// </summary>
        /// <param name="rosterAllowanceAutoId">The roster allowance automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceDelete(String rosterAllowanceAutoId, String locationAutoId)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.RosterAllowanceDelete(rosterAllowanceAutoId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Get Allowance
        /// </summary>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceGet(String rosterAutoId, String locationAutoId, string clientCode, string asmtId, string postCode, string rowNumber)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.RosterAllowanceGet(rosterAutoId, locationAutoId, clientCode, asmtId, postCode, rowNumber);
            return ds;
        }
        /// <summary>
        /// To Get Allowance Details by Element
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetElementDetailsByAllowanceAutoId(String allowanceAutoId, String locationAutoId)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.GetElementDetailsByAllowanceAutoId(allowanceAutoId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Get Allowance
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceGet(String locationAutoId)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.AllowanceGet(locationAutoId);
            return ds;
        }

        /// <summary>
        /// Weeklies the rest.
        /// </summary>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="EmployeeNumber">The employee number.</param>
        /// <param name="LocationAutoID">The location automatic identifier.</param>
        /// <param name="AreaID">The area identifier.</param>
        /// <param name="AreaINcharge">The area i ncharge.</param>
        /// <param name="WeeklyRest">The weekly rest.</param>
        /// <returns>DataSet.</returns>
        public DataSet WeeklyRest(DateTime FromDate, DateTime ToDate, string EmployeeNumber, string LocationAutoID, string AreaID, string AreaINcharge, string WeeklyRest)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.WeeklyRest(FromDate, ToDate, EmployeeNumber, LocationAutoID, AreaID, AreaINcharge, WeeklyRest);
            return ds;
        }
        #endregion

        #region Function Related to Apply New Tab Allowance Details 13-Jan-2014
        /// <summary>
        /// To Get Allowance
        /// </summary>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceDetailsGet(String rosterAutoId, String locationAutoId, string clientCode, string asmtId, string postCode, string rowNumber, String dutyDate)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.RosterAllowanceDetailsGet(rosterAutoId, locationAutoId, clientCode, asmtId, postCode, rowNumber, dutyDate);
            return ds;
        }

        /// <summary>
        /// To Get Allowance
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceDescriptionGet(String locationAutoId)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.AllowanceDescriptionGet(locationAutoId);
            return ds;
        }

        /// <summary>
        /// To Get Allowance Details by Element
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ElementDetailsByAllowanceAutoIdGet(String allowanceAutoId)
        {
            var obReport = new DL.Roster();
            return obReport.ElementDetailsByAllowanceAutoIdGet(allowanceAutoId);
        }

        /// <summary>
        /// To Get Allowance Unit Details by Element
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet UnitDetailsByAllowanceAutoIdGet(String allowanceAutoId)
        {
            var obReport = new DL.Roster();
            return obReport.UnitDetailsByAllowanceAutoIdGet(allowanceAutoId);
        }

        /// <summary>
        /// To Delete Allowance Details
        /// </summary>
        /// <param name="trnAllowanceAutoID">The TRN allowance automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceDetailsDelete(String trnAllowanceAutoID, String locationAutoId)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.RosterAllowanceDetailsDelete(trnAllowanceAutoID, locationAutoId);
            return ds;
        }

        /// <summary>
        /// To Insert Allowance
        /// </summary>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyMin">The duty minimum.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="measurement">The measurement.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="amountPaid">The amount paid.</param>
        /// <param name="isBillable">The is billable.</param>
        /// <param name="comment">The comment.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceDetailsInsert(String rosterAutoId, String employeeNumber, String allowanceAutoId, String dutyDate, String timeFrom, String timeTo, String dutyMin, String modifiedBy, String locationAutoId, String clientCode, String asmtId, String postCode, String rowNumber, String measurement, Decimal unit, Decimal amountPaid, Boolean isBillable, String comment)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.RosterAllowanceDetailsInsert(rosterAutoId, employeeNumber, allowanceAutoId, dutyDate, timeFrom, timeTo, dutyMin, modifiedBy, locationAutoId, clientCode, asmtId, postCode, rowNumber, measurement, unit, amountPaid, isBillable, comment);
            return ds;
        }
        /// <summary>
        /// To Update Allownace
        /// </summary>
        /// <param name="rosterAllowanceAutoId">The roster allowance automatic identifier.</param>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyMin">The duty minimum.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="measurement">The measurement.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="amountPaid">The amount paid.</param>
        /// <param name="isBillable">The is billable.</param>
        /// <param name="comment">The comment.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceDetailsUpdate(String rosterAllowanceAutoId, String rosterAutoId, String employeeNumber, String allowanceAutoId, String dutyDate, String timeFrom, String timeTo, String dutyMin, String modifiedBy, String locationAutoId, String clientCode, String asmtId, String postCode, String rowNumber, String measurement, Decimal unit, Decimal amountPaid, Boolean isBillable, String comment)
        {
            DL.Roster obReport = new DL.Roster();
            DataSet ds = obReport.RosterAllowanceDetailsUpdate(rosterAllowanceAutoId, rosterAutoId, employeeNumber, allowanceAutoId, dutyDate, timeFrom, timeTo, dutyMin, modifiedBy, locationAutoId, clientCode, asmtId, postCode, rowNumber, measurement, unit, amountPaid, isBillable, comment);
            return ds;
        }
        #endregion

        #region OT Reason Transactions

        /// <summary>
        /// OT Reason For Combo Get
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="post">The post.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonForComboGet(String locationAutoId, String rosterAutoId, String clientCode, String asmtCode, String post)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.OtReasonForComboGet(locationAutoId, rosterAutoId, clientCode, asmtCode, post);
            return ds;
        }
        /// <summary>
        /// To Get Reasons for GV
        /// </summary>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonTransactionGet(String rosterAutoId, String locationAutoId)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.OtReasonTransactionGet(rosterAutoId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Save OT Reason Transaction
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="reasonAutoId">The reason automatic identifier.</param>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="dutyMin">The duty minimum.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonTranInsert(String locationAutoId, String reasonAutoId, String rosterAutoId, String employeeNumber, String timeFrom, String timeTo, String dutyDate, String dutyMin, String modifiedBy)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.OtReasonTranInsert(locationAutoId, reasonAutoId, rosterAutoId, employeeNumber, timeFrom, timeTo, dutyDate, dutyMin, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update Ot Reason Transaction
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="otReasonTranAutoId">The ot reason tran automatic identifier.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyMin">The duty minimum.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonTranUpdate(String locationAutoId, String otReasonTranAutoId, String timeFrom, String timeTo, String dutyMin)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.OtReasonTranUpdate(locationAutoId, otReasonTranAutoId, timeFrom, timeTo, dutyMin);
            return ds;
        }
        /// <summary>
        /// To Delete OT Reason Transaction
        /// </summary>
        /// <param name="otReasonTranAutoId">The ot reason tran automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonTranDelete(String otReasonTranAutoId, String locationAutoId)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.OtReasonTranDelete(otReasonTranAutoId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Check Time Over Lap
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="otReasonTranAutoId">The ot reason tran automatic identifier.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtReasonEmpTimeOverlapCheck(String employeeNumber, String otReasonTranAutoId, String timeFrom, String timeTo)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.OtReasonEmpTimeOverlapCheck(employeeNumber, otReasonTranAutoId, timeFrom, timeTo);
            return ds;
        }
        /// <summary>
        /// To Get Is OT From System Parameter Table
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet IsOtFromSystemParam(String locationAutoId)
        {
            DL.Roster objdlRost = new DL.Roster();
            DataSet ds = objdlRost.IsOtFromSystemParam(locationAutoId);
            return ds;
        }
        #endregion

        #region Report
        /// <summary>
        /// SCHs the actual asmt wise get.
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="AsmtCode">The asmt code.</param>
        /// <param name="AreaId">The area identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="ScheduleActual">The schedule actual.</param>
        /// <param name="AreaIncharge">The area incharge.</param>
        /// <param name="Option">The option.</param>
        /// <returns>DataSet.</returns>
        public DataSet SchActualAsmtWiseGet(string CompanyCode, string LocationAutoId, string ClientCode, string AsmtCode, string AreaId, string FromDate, string ToDate, string ScheduleActual, string AreaIncharge, string Option)
        {
            DL.Roster objRost = new DL.Roster();
            DataSet ds = objRost.SchActualAsmtWiseGet(CompanyCode, LocationAutoId, ClientCode, AsmtCode, AreaId, FromDate, ToDate, ScheduleActual, AreaIncharge, Option);
            return ds;
        }
        /// <summary>
        /// Invoice Out put CSV format
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="soType">Type of the so.</param>
        /// <returns>DataSet.</returns>
        public DataSet GenerateInvoice(string locationAutoId, string fromDate, string toDate, string soType)
        {
            DL.Roster objRost = new DL.Roster();
            DataSet ds = objRost.GenerateInvoice(locationAutoId, fromDate, toDate, soType);
            return ds;
        }
        #endregion

        /// <summary>
        /// Gets the unit register.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet GetUnitRegister()
        {
            var obReport = new DL.Roster();
            DataSet ds = obReport.GetUnitRegister();
            return ds;
        }

        /// <summary>
        /// TimeSheet Report in Excel format
        /// </summary>
        /// <param name="HrLocationCode">The hr location code.</param>
        /// <param name="locationcode">The locationcode.</param>
        /// <param name="EmployeeNumber">The employee number.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="optionparam">The optionparam.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TimeSheetExcel(string HrLocationCode, string locationcode, string EmployeeNumber, string FromDate, string ToDate, string optionparam, string areaId, string UserID)
        {
            DL.Roster obReport = new DL.Roster();

            DataSet ds = obReport.TimeSheetExcel(HrLocationCode, locationcode, EmployeeNumber, FromDate, ToDate, optionparam, areaId, UserID);
            return ds;
        }

        /// <summary>
        /// Guarding Management Report
        /// </summary>
        /// <param name="Base_CompanyCode">The base_ company code.</param>
        /// <param name="Base_HrLocationCode">The base_ hr location code.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <returns>DataTable.</returns>
        #region Management Report
        public DataTable GuardingManagementProcessGet(string Base_CompanyCode, string Base_HrLocationCode, string FromDate, string ToDate, string ModifiedBy)
        {
            var objdlRost = new DL.Roster();

            using (DataTable dt = objdlRost.GuardingManagementProcessGet(Base_CompanyCode, Base_HrLocationCode, FromDate, ToDate, ModifiedBy))
            {
                return dt;
            }

        }

        /// <summary>
        /// Gets the Max Processed Dates for the report
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <param name="HrLocationCode">The hr location code.</param>
        /// <returns>DataTable.</returns>
        public static DataTable GetGuardingManagementProcessDate(string CompanyCode, string HrLocationCode)
        {
            var objRoster = new DL.Roster();
            using (DataTable dt = objRoster.GetGuardingManagementProcessDate(CompanyCode, HrLocationCode))
            {
                return dt;
            }
        }
        #endregion

        #region function related to Replaced Duty

        /// <summary>
        /// Rosters the detail based on automatic identifier.
        /// </summary>
        /// <param name="autoId">The automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterDetailBasedOnAutoID(string autoId, string fromDate, string toDate)
        {
            var objRoster = new DL.Roster();

            DataSet ds = objRoster.RosterDetailBasedOnAutoID(autoId, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// Checks the employee validity and insert for entry in duty replaced.
        /// </summary>
        /// <param name="autoId">The automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="Status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckEmployeeValidityAndInsertForEntryInDutyReplaced(string autoId, string employeeNumber, string reason, string weekNo, string modifiedBy, string Status)
        {
            var objRoster = new DL.Roster();
            DataSet ds = objRoster.CheckEmployeeValidityAndInsertForEntryInDutyReplaced(autoId, employeeNumber, reason, weekNo, modifiedBy, Status);
            return ds;
        }
        #endregion


        /// <summary>
        /// Deletes the schedule and actual.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet DeleteScheduleAndActual(String locationAutoId, string employeeNumber, string dutyDate)
        {

            var objRoster = new DL.Roster();
            DataSet ds = objRoster.DeleteScheduleAndActual(locationAutoId, employeeNumber, dutyDate);
            return ds;
        }

        #region Added by  on 24-Apr-2014 For POP TAG Reference In Export
        /// <summary>
        /// This function fetches the data related to Location Tag Reference
        /// </summary>
        /// <param name="strLocationTagID">The string location tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlLocationTagRefGet(string strLocationTagID)
        {
            DL.Roster objLocTag = new DL.Roster();
            DataSet ds = new DataSet();
            ds = objLocTag.DlLocationTagRefGet(strLocationTagID);
            return ds;
        }

        /// <summary>
        /// Funtion to get detail of employee and tag ref mapping
        /// </summary>
        /// <param name="Base_LocationAutoID">The base_ location automatic identifier.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlAsmtTagRefGet(string Base_LocationAutoID, string strAsmtCode)
        {
            DL.Roster objroster = new DL.Roster();
            DataSet ds = new DataSet();
            ds = objroster.DlAsmtTagRefGet(Base_LocationAutoID, strAsmtCode);
            return ds;
        }

        /// <summary>
        /// Bls the employee tag reference get.
        /// </summary>
        /// <param name="strEmployeeNumber">The string employee number.</param>
        /// <param name="strRecordType">Type of the string record.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlEmployeeTagRefGet(string strEmployeeNumber, string strRecordType)
        {
            DL.Roster objroster = new DL.Roster();
            DataSet ds = new DataSet();
            ds = objroster.DlEmployeeTagRefGet(strEmployeeNumber, strRecordType);
            return ds;
        }
        #endregion
    }
}
